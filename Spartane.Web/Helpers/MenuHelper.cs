using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
//using System.Web.Http.Dependencies;
using System.Web.Mvc;
using Spartane.Core.Domain.Spartan_Additional_Menu;
using Spartane.Core.Domain.SpartaneObject;
using Spartane.Core.Domain.SpartaneUserRoleModule;
using Spartane.Core.Domain.SpartanModule;
using Spartane.Core.Domain.SpartanUserRoleModuleObject;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
using Spartane.Web.Areas.WebApiConsumer.SpartaneFile;
//using Spartane.Web.Areas.WebApiConsumer.SpartaneFunction;
using Spartane.Web.Areas.WebApiConsumer.SpartaneObject;
using Spartane.Web.Areas.WebApiConsumer.SpartaneUserRoleModuleObject;
using Spartane.Web.Areas.WebApiConsumer.SpartaneUserRoleObjectFunction;
using Spartane.Web.Areas.WebApiConsumer.SpartanModule;
using Spartane.Web.Areas.WebApiConsumer.SpartanUserRoleModule;
using System.Web;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Role;

namespace Spartane.Web.Helpers
{
    /// <summary>
    /// Contains the menu for the roles
    /// </summary>
    public static class MenuHelper
    {
        private static readonly ITokenManager _tokenManager;
        private static readonly ISpartanModuleApiConsumer _spartaneModuleApiConsumer;
        private static readonly ISpartanUserRoleModuleApiConsumer _spartanUserRoleModuleApiConsumer;
        private static readonly ISpartan_User_RoleApiConsumer _userRoleApiConsumer;
        private static readonly ISpartaneUserRoleModuleObjectApiConsumer _spartaneUserRoleModuleObjectApiConsumer;
        private static readonly ISpartaneObjectApiConsumer _spartaneObjectApiConsumer;
        private static readonly ISpartaneFileApiConsumer _ISpartane_FileApiConsumer;


        private static List<SpartaneUserRoleModule> lstUserRoleModules;
        private static List<SpartanUserRoleModuleObject> _SpartaneUserRoleModuleObject;
        public static Dictionary<int, List<RecursiveObject>> MenuOrder { get; private set; }

        static MenuHelper()
        {
            //Resolving initialization using the pre-defined dependancy
            //dependencyResolver = S.DependencyResolver;//.GetService(typeof(ICustomAuthenticationService)) as ICustomAuthenticationService;
            _tokenManager = DependencyResolver.Current.GetService<ITokenManager>();//dependencyResolver.GetService(typeof(ITokenManager)) as ITokenManager;
            _spartaneModuleApiConsumer = DependencyResolver.Current.GetService<ISpartanModuleApiConsumer>();//dependencyResolver.GetService(typeof(ISpartanModuleApiConsumer)) as ISpartanModuleApiConsumer;
            _spartanUserRoleModuleApiConsumer = DependencyResolver.Current.GetService<ISpartanUserRoleModuleApiConsumer>();//ISpartanUserRoleModuleApiConsumer.GetService(typeof(ISpartanUserRoleModuleApiConsumer)) as ISpartanUserRoleModuleApiConsumer;
            _userRoleApiConsumer = DependencyResolver.Current.GetService<ISpartan_User_RoleApiConsumer>();//v.GetService(typeof(IUserRoleApiConsumer)) as IUserRoleApiConsumer;
            _spartaneUserRoleModuleObjectApiConsumer = DependencyResolver.Current.GetService<ISpartaneUserRoleModuleObjectApiConsumer>();
            _spartaneObjectApiConsumer = DependencyResolver.Current.GetService<ISpartaneObjectApiConsumer>();
            _ISpartane_FileApiConsumer = DependencyResolver.Current.GetService<ISpartaneFileApiConsumer>();
        }

        /// <summary>
        /// Used to get current role menu
        /// </summary>
        /// <returns></returns>
        public static List<RecursiveObject> GetCurrentRoleMenus()
        {
            var roleId = SessionHelper.Role;
            return MenuOrder != null && MenuOrder.ContainsKey(roleId) ? MenuOrder[roleId] : new List<RecursiveObject>();
        }

        /// <summary>
        /// Used to get the latest version of the menu
        /// </summary>
        public static void GetLatestMenu()
        {
            //new Thread(() =>
            //{
            if (!_tokenManager.GenerateToken("admin", "admin"))
                throw new ArgumentException("Unable to Authorize the application");

            //Adding Token in each request
            _userRoleApiConsumer.SetAuthHeader(_tokenManager.Token);
            _spartaneModuleApiConsumer.SetAuthHeader(_tokenManager.Token);
            _spartanUserRoleModuleApiConsumer.SetAuthHeader(_tokenManager.Token);
            _spartaneObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            _spartaneUserRoleModuleObjectApiConsumer.SetAuthHeader(_tokenManager.Token);


            var userRoles = _userRoleApiConsumer.SelAll(true).Resource;

            if (!userRoles.Any())
                return;

            //Getting all as the _spartanUserRoleModuleApiConsumer GETByKey method not working
            var userRoleModuleAll = _spartanUserRoleModuleApiConsumer.SelAll(true).Resource;
            if (!userRoleModuleAll.Any())
                return;

            _SpartaneUserRoleModuleObject = _spartaneUserRoleModuleObjectApiConsumer.SelAll(true).Resource.OrderBy(m => m.Order_Shown).ToList();
            if (!_SpartaneUserRoleModuleObject.Any())
                return;
            //Itrating over the list of userRoles for getting the respective menus
            //List<SpartaneUserRoleModule> userRoleModules;

            //Initializing Menu Order
            MenuOrder = new Dictionary<int, List<RecursiveObject>>();

            int languageId = SessionHelper.languageid;

            foreach (var userRole in userRoles)
            {
                var UserAdditionalMenu = _spartaneUserRoleModuleObjectApiConsumer.GetAdditionalMenu(userRole.User_Role_Id, languageId).Resource.ToList();
                lstUserRoleModules = userRoleModuleAll.Where(m => m.Spartan_User_Role == userRole.User_Role_Id).OrderBy(m=> m.Order_Shown).ToList();
                if (!lstUserRoleModules.Any())
                    continue;
                var modules = new List<SpartanModule>();

                foreach (var userRoleModule in lstUserRoleModules)
                {
                    modules.Add(_spartaneModuleApiConsumer.GetByKey(userRoleModule.Module_Id, true).Resource);
                }

                var additionalMenu = CreateUserAdditionalMenuHierachy(UserAdditionalMenu);
                var flatObjects = CreateModuleHierarchy(modules.Where(m => m.Status == 1).ToList());

                var RecursirveAdditionalMenu = GetRecursiveAdditionalMenu(additionalMenu, UserAdditionalMenu);

                MenuOrder.Add(userRole.User_Role_Id, FillRecursive(flatObjects, 0, userRole.User_Role_Id));
                MenuOrder[userRole.User_Role_Id].AddRange(RecursirveAdditionalMenu);

                lstUserRoleModules = null;
            }

            _SpartaneUserRoleModuleObject = null;
        }

        private static List<RecursiveObject> GetRecursiveAdditionalMenu(List<FlatObject> addtionalFlatMenu, List<Spartan_Additional_Menu> additionalMenu)
        {
            List<RecursiveObject> List = new List<RecursiveObject>();
            var Parents = additionalMenu.Where(AM => AM.ParentMenu == null);

            foreach (var Node in Parents)
            {
                if (List.Any(L => L.text == Node.MenuName))
                {
                    RecursiveObject Item = List.FirstOrDefault(L => L.text == Node.MenuName);
                    RecursiveObject item = new RecursiveObject();
                    item.id = Node.idMenu;
                    item.Image = null;
                    item.moduleOrder = Node.idMenu;
                    item.state = new FlatTreeAttribute() { check = false, opened = false, selected = false };
                    item.text = Node.OptionMenu;
                    item.Objects = new List<RecursiveInnerObject>();
                    item.children = new List<RecursiveObject>();
                    item.AdditionalMenu = GetAdditionalMenuChildren(Node.idMenu, additionalMenu);
                    item.Link = Node.OptionPath;
                    Item.AdditionalMenu.Add(item);
                }
                else
                {
                    RecursiveObject item = new RecursiveObject();
                    item.id = Node.idMenu;
                    item.Image = null;
                    item.moduleOrder = Node.idMenu;
                    item.state = new FlatTreeAttribute() { check = false, opened = false, selected = false };
                    item.text = Node.MenuName;
                    item.Objects = new List<RecursiveInnerObject>();
                    item.children = new List<RecursiveObject>();

                    if (!string.IsNullOrWhiteSpace(Node.OptionPath))
                    {
                        RecursiveObject SubMenu = new RecursiveObject();
                        SubMenu.id = Node.idMenu;
                        SubMenu.text = Node.OptionMenu;
                        SubMenu.state = new FlatTreeAttribute() { check = false, opened = false, selected = false };
                        SubMenu.Link = Node.OptionPath;
                        if (item.AdditionalMenu == null) item.AdditionalMenu = new List<RecursiveObject>();
                        item.AdditionalMenu.Add(SubMenu);
                    }
                    if (item.AdditionalMenu == null) item.AdditionalMenu = new List<RecursiveObject>();
                    item.AdditionalMenu.AddRange(GetAdditionalMenuChildren(Node.idMenu, additionalMenu));
                    //item.Link = Node.OptionPath;

                    List.Add(item);
                }
            }


            return List;
        }

        private static List<RecursiveObject> GetAdditionalMenuChildren(int idMenu, List<Spartan_Additional_Menu> additionalMenu)
        {
            List<RecursiveObject> List = new List<RecursiveObject>();
            var Parents = additionalMenu.Where(AM => AM.ParentMenu == idMenu);

            foreach (var Node in Parents)
            {
                if (List.Any(L => L.text == Node.MenuName))
                {
                    RecursiveObject Item = List.FirstOrDefault(L => L.text == Node.MenuName);
                    RecursiveObject item = new RecursiveObject();
                    item.id = Node.idMenu;
                    item.Image = null;
                    item.moduleOrder = Node.idMenu;
                    item.state = new FlatTreeAttribute() { check = false, opened = false, selected = false };
                    item.text = Node.OptionMenu;
                    item.Objects = new List<RecursiveInnerObject>();
                    item.children = new List<RecursiveObject>();
                    item.AdditionalMenu = GetAdditionalMenuChildren(Node.idMenu, additionalMenu);
                    item.Link = Node.OptionPath;

                    Item.AdditionalMenu.Add(item);
                }
                else
                {
                    RecursiveObject item = new RecursiveObject();
                    item.id = Node.idMenu;
                    item.Image = null;
                    item.moduleOrder = Node.idMenu;
                    item.state = new FlatTreeAttribute() { check = false, opened = false, selected = false };
                    item.text = Node.MenuName;
                    item.Objects = new List<RecursiveInnerObject>();
                    item.children = new List<RecursiveObject>();

                    if (!string.IsNullOrWhiteSpace(Node.OptionPath))
                    {
                        RecursiveObject SubMenu = new RecursiveObject();
                        SubMenu.id = Node.idMenu;
                        SubMenu.text = Node.OptionMenu;
                        SubMenu.state = new FlatTreeAttribute() { check = false, opened = false, selected = false };
                        SubMenu.Link = Node.OptionPath;
                        if (item.AdditionalMenu == null) item.AdditionalMenu = new List<RecursiveObject>();
                        item.AdditionalMenu.Add(SubMenu);
                    }
                    if (item.AdditionalMenu == null) item.AdditionalMenu = new List<RecursiveObject>();
                    item.AdditionalMenu.AddRange(GetAdditionalMenuChildren(Node.idMenu, additionalMenu));
                    //item.Link = Node.OptionPath;

                    List.Add(item);
                }
            }


            return List;
        }

        private static List<FlatObject> CreateUserAdditionalMenuHierachy(IList<Core.Domain.Spartan_Additional_Menu.Spartan_Additional_Menu> userAdditionalMenu)
        {
            List<FlatObject> lstFlatObject = new List<FlatObject>();

            foreach (Spartan_Additional_Menu spartanModule in userAdditionalMenu)
            {
                FlatObject flatObject = new FlatObject(spartanModule.MenuName, spartanModule.idMenu, spartanModule.ParentMenu ?? 0, 0, null);
                lstFlatObject.Add(flatObject);
            }

            return lstFlatObject;
        }


        /// <summary>
        /// Method to create Module Structure from Spartane Modules obtained
        /// </summary>
        /// <param name="result"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns></returns>
        private static List<FlatObject> CreateModuleHierarchy(IList<SpartanModule> result)
        {

            List<FlatObject> lstFlatObject = new List<FlatObject>();

            foreach (SpartanModule spartanModule in result)
            {

                FlatObject flatObject = new FlatObject(spartanModule.Name, spartanModule.Module_Id, spartanModule.Parent_Module ?? 0, spartanModule.Order_Shown, Convert.ToInt32(spartanModule.Image));

                lstFlatObject.Add(flatObject);
            }

            return lstFlatObject;
        }

        /// <summary>
        /// Method to build Object to bind 
        /// Menu with structured data.
        /// </summary>
        /// <param name="flatObjects"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        private static List<RecursiveObject> FillRecursive(List<FlatObject> flatObjects, Int64 parentId, int roleId)
        {
            List<RecursiveObject> recursiveObjects = new List<RecursiveObject>();

            int maxOrder = flatObjects.Max(m => m.Order_Shown);


            foreach (var item in flatObjects.Where(x => x.ParentId.Equals(parentId)))
            {
                bool moduleSelected = false;
                int orderShown;

                int index = lstUserRoleModules.FindIndex(m => m.Module_Id == item.Id);

                orderShown = lstUserRoleModules.Where(m => m.Module_Id == item.Id).Select(i => i.Order_Shown).FirstOrDefault();

                if (orderShown == 0)
                    orderShown = new Random().Next(maxOrder, maxOrder + 10);

                moduleSelected = index >= 0;



                recursiveObjects.Add(new RecursiveObject
                {
                    id = item.Id,
                    text = item.data,
                    state = new FlatTreeAttribute
                    {
                        opened = moduleSelected,
                        selected = moduleSelected
                    },
                    children = FillRecursive(flatObjects, item.Id, roleId),
                    originalOrder = item.Order_Shown,
                    moduleOrder = orderShown,
                    Objects = GetModuleObjects(roleId, item.Id),
                    Image = GetImageBytes(item.Image)

                });
            }

            return recursiveObjects;
        }

        private static byte[] GetImageBytes(int? imageId)
        {
            if (imageId == null || imageId == 0)
                return null;

            if (!_tokenManager.GenerateToken())
                return null;

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var fileInfo = _ISpartane_FileApiConsumer.GetByKey(imageId).Resource;
            if (fileInfo == null)
                return null;
            return fileInfo.File;
        }

        /// <summary>
        /// Used to get the Modules
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public static List<RecursiveInnerObject> GetModuleObjects(int roleId, long moduleId)
        {
            var result = new List<RecursiveInnerObject>();
            var userRoleModuleObjects =
                _SpartaneUserRoleModuleObject.Where(m => m.Module_Id == moduleId && m.Spartan_User_Role == roleId).OrderBy(o => o.Order_Shown);
            //SpartaneObject spartaneObject;
            if (userRoleModuleObjects != null && userRoleModuleObjects.Any())
                foreach (var spartanUserRoleModuleObject in userRoleModuleObjects)
                {
                    //////////////////// ModificacionJO (los parámetros iban invertidos) ///////////////////////////
                    if (PermissionHelper.GetRoleObjectPermission(roleId, spartanUserRoleModuleObject.Object_Id).Consult)
                    {
                        var objectData =
                            _spartaneObjectApiConsumer.GetByKey(spartanUserRoleModuleObject.Object_Id, true).Resource;
                        if (objectData != null)
                        {
                            if (objectData.Object_Type != 6)
                            {
                                result.Add(new RecursiveInnerObject
                                {
                                    Description = objectData.Description,
                                    Image_Spartan_File = objectData.Image_Spartan_File,
                                    Id = objectData.Id,
                                    Name = objectData.Name,
                                    Object_Id = objectData.Object_Id,
                                    Object_Type = (int)objectData.Object_Type,
                                    Object_Type_Spartan_Object_Type = objectData.Object_Type_Spartan_Object_Type,
                                    Status = (int)objectData.Status,
                                    Status_Spartan_Object_Status = objectData.Status_Spartan_Object_Status,
                                    URL = objectData.URL,
                                    Tags = objectData.Tags,
                                    Image = GetImageBytes(Convert.ToInt32(objectData.Image))
                                });
                            }
                        }
                    }

                }


            return result;
        }

        public static string GetImageBase64(byte[] image)
        {
            if (image == null)
                return "";
            var base64 = Convert.ToBase64String(image);
            return String.Format("data:image/gif;base64,{0}", base64);

        }

        /// <summary>
        /// Used to get the menu based on the role id 
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static object GetMenuByRole(int roleId)
        {
            return new object();
        }
        /// <summary>
        /// Used to get the Latest Role by Id
        /// </summary>
        /// <param name="roleId"></param>
        private static void GetLatestMenuByRole(int roleId)
        {

        }

    }
}

