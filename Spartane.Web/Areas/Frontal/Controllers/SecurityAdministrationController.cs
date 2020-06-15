using Newtonsoft.Json.Linq;
using Resources;
using Spartane.Core.Domain.Spartan_Traduction_Detail;
using Spartane.Core.Domain.SpartaneModuleObject;
using Spartane.Core.Domain.SpartaneObject;
using Spartane.Core.Domain.SpartaneUserRoleModule;
using Spartane.Core.Domain.SpartaneUserRoleObjectFunction;
using Spartane.Core.Domain.SpartanModule;
using Spartane.Core.Domain.SpartanUserRoleModuleObject;
using Spartane.Core.Enums;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Role;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Role_Status;
using Spartane.Web.Areas.WebApiConsumer.SpartaneModuleObject;
using Spartane.Web.Areas.WebApiConsumer.SpartaneObject;
using Spartane.Web.Areas.WebApiConsumer.SpartaneQuery;
using Spartane.Web.Areas.WebApiConsumer.SpartaneUserRoleModuleObject;
using Spartane.Web.Areas.WebApiConsumer.SpartaneUserRoleObjectFunction;
using Spartane.Web.Areas.WebApiConsumer.SpartanModule;
using Spartane.Web.Areas.WebApiConsumer.SpartanUserRoleModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class SecurityAdministrationController : Controller
    {
        #region fields

        private ITokenManager _tokenManager = null;
        private ISpartan_User_RoleApiConsumer _IUserRoleApiConsumer;
        private ISpartanModuleApiConsumer _ISpartanModuleApiConsumer;
        private ISpartanUserRoleModuleApiConsumer _ISpartanUserRoleModuleApiConsumer;
        private ISpartaneModuleObjectApiConsumer _ISpartaneModuleObjectApiConsumer;
        private ISpartaneUserRoleModuleObjectApiConsumer _ISpartaneUserRoleModuleObjectApiConsumer;
        private ISpartaneUserRoleObjectFunctionApiConsumer _ISpartaneUserRoleObjectFunctionApiConsumer;
        private ISpartaneObjectApiConsumer _ISpartaneObjectApiConsumer;
        private ISpartan_User_Role_StatusApiConsumer _IUserRoleStatusApiConsumer;
        private ISpartan_MetadataApiConsumer _ISpartan_MetadataApiConsumer;
        private ISpartan_Traduction_DetailApiConsumer _ISpartan_Traduction_DetailApiConsumer;
        private ISpartaneQueryApiConsumer _ISpartaneQueryApiConsumer;

        private List<FlatObject> lstFlatObject;
        private List<SpartaneUserRoleModule> lstUserRoleModules;
        private static List<SpartaneModuleObject> lstGlobalSpartaneModuleObject = new List<SpartaneModuleObject>();

        private static List<SpartaneUserRoleModule> lstGlobalUserRoleModule = new List<SpartaneUserRoleModule>();
        private static List<SpartanUserRoleModuleObject> lsGlobalUserRoleModuleObject = new List<SpartanUserRoleModuleObject>();
        private static List<SpartaneUserRoleObjectFunction> lstGlobalUserRoleOjectFunction = new List<SpartaneUserRoleObjectFunction>();
        private static List<SpartaneObject> lstGlobalSpartaneObject = new List<SpartaneObject>();

        #endregion fields

        #region constructor

        public SecurityAdministrationController(ITokenManager tokenManager, ISpartan_User_RoleApiConsumer userRoleApiConsumer, ISpartan_User_Role_StatusApiConsumer userRoleStatusApiConsumer, ISpartanModuleApiConsumer spartanModuleApiConsumer, ISpartanUserRoleModuleApiConsumer SpartanUserRoleModuleApiConsumer, ISpartaneModuleObjectApiConsumer SpartaneModuleObjectApiConsumer, ISpartaneUserRoleModuleObjectApiConsumer SpartaneUserRoleModuleObjectApiConsumer, ISpartaneUserRoleObjectFunctionApiConsumer SpartaneUserRoleObjectFunctionApiConsumer, ISpartaneObjectApiConsumer SpartaneObjectApiConsumer, ISpartan_MetadataApiConsumer Spartan_MetadataApiConsumer, ISpartan_Traduction_DetailApiConsumer Spartan_Traduction_DetailApiConsumer, ISpartaneQueryApiConsumer SpartaneQueryApiConsumer)
        {
            this._IUserRoleApiConsumer = userRoleApiConsumer;
            this._IUserRoleStatusApiConsumer = userRoleStatusApiConsumer;
            this._ISpartanModuleApiConsumer = spartanModuleApiConsumer;
            this._ISpartanUserRoleModuleApiConsumer = SpartanUserRoleModuleApiConsumer;
            this._ISpartaneModuleObjectApiConsumer = SpartaneModuleObjectApiConsumer;
            this._ISpartaneUserRoleModuleObjectApiConsumer = SpartaneUserRoleModuleObjectApiConsumer;
            this._ISpartaneUserRoleObjectFunctionApiConsumer = SpartaneUserRoleObjectFunctionApiConsumer;
            this._ISpartaneObjectApiConsumer = SpartaneObjectApiConsumer;
            this._tokenManager = tokenManager;
            this._ISpartan_MetadataApiConsumer = Spartan_MetadataApiConsumer;
            this._ISpartan_Traduction_DetailApiConsumer = Spartan_Traduction_DetailApiConsumer;
            this._ISpartaneQueryApiConsumer = SpartaneQueryApiConsumer;
        }

        #endregion constructor

        #region Action Methods

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Used to get the user Role
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUserRoles()
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _IUserRoleApiConsumer.SetAuthHeader(_tokenManager.Token);

            var result = _IUserRoleApiConsumer.SelAll(false).Resource;

            foreach (var r in result)
            {
                string roleDescription = Roles.GetRoleValueById(r.User_Role_Id);

                r.Description = roleDescription;
            }

            return Json(result == null ? null : result.Select(m => new { Text = m.Description, Value = m.User_Role_Id, Status = m.Status }), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Used to get the user Status
        /// </summary>
        /// <returns></returns>
        public JsonResult GetUserRoleStatus()
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _IUserRoleStatusApiConsumer.SetAuthHeader(_tokenManager.Token);

            var result = _IUserRoleStatusApiConsumer.GetAll(false).Resource;

            return Json(result == null ? null : result.Select(m => new { Text = m.Description, Value = m.User_Role_Status_Id }), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get Spartan Modules
        /// </summary>
        /// <param name="roleID">
        /// Fetch the Modules by RoleID Passed
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public string GetSpartanModules(string roleID)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartanModuleApiConsumer.SetAuthHeader(_tokenManager.Token);

            var result = _ISpartanModuleApiConsumer.SelAll(false).Resource;

            lstUserRoleModules = GetSpartaneUserRoleModules(Convert.ToInt32(roleID));

            if (result != null)
                lstFlatObject = CreateModuleHierarchy(result);

            List<RecursiveObject> lstRecursieveObjects;

            lstRecursieveObjects = FillRecursive(lstFlatObject, 0);

            lstRecursieveObjects = lstRecursieveObjects.OrderBy(m => m.moduleOrder).ThenBy(m => m.originalOrder).ToList();

            string myjsonmodel = new JavaScriptSerializer().Serialize(lstRecursieveObjects);

            string jsonData = myjsonmodel.Replace("selected", "checked");

            return jsonData;
        }

        /// <summary>
        /// Get Spratane Module by UserRole
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>
        /// TODO:
        /// Correct GetByID Method of WebAPI Spartan_User_Role_Module (Ask Ricardo)
        /// </remarks>
        /// <returns></returns>

        public JsonResult GetSpartanUserRoleModuleByID(string id)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartanUserRoleModuleApiConsumer.SetAuthHeader(_tokenManager.Token);

            var result = _ISpartanUserRoleModuleApiConsumer.GetByKey(1, false).Resource;

            return Json(result == null ? null : (new { ModuleID = result.Module_Id, OrderShown = result.Order_Shown, SpartanUserRole = result.Spartan_User_Role })
                , JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetModuleByID(int id)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartanModuleApiConsumer.SetAuthHeader(_tokenManager.Token);

            var result = _ISpartanModuleApiConsumer.GetByKey(id, false).Resource;

            return Json(result == null ? null : (new { ModuleID = result.Module_Id, Name = result.Name, Status = result.Status, Parent_Module = result.Parent_Module })
                , JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Add new user roles
        /// </summary>
        /// <remarks>
        /// Dummy Data has been passed as of now for test.
        /// Actual form will be provided by Ricardo later.
        /// </remarks>
        /// <returns></returns>
        public JsonResult AddOrUpdateUserRol(Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role role)
        {
            var successRecord = false;

            if (!_tokenManager.GenerateToken())
                return null;
            _IUserRoleApiConsumer.SetAuthHeader(_tokenManager.Token);

            Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role userRole = new Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role()
            {
                Description = role.Description,
                Id1 = 0,
                Status = role.Status,
                Status_Spartan_User_Role_Status = null,
                User_Role_Id = role.User_Role_Id
            };

            if (role.User_Role_Id == 0)
            {
                var roleAdded = _IUserRoleApiConsumer.Insert(role, null, null);
                if (roleAdded != null)
                {
                    successRecord = true;
                    role.User_Role_Id = roleAdded.Resource;

                    //ADD TO TRADUCTION DETAIL TABLE
                    _ISpartan_Traduction_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                    Spartan_Traduction_Detail traduction_detail_Spanish = new Spartan_Traduction_Detail();
                    traduction_detail_Spanish.Concept = 1;
                    traduction_detail_Spanish.Spartan_Traduction_Process = 1;
                    traduction_detail_Spanish.IdConcept = roleAdded.Resource;
                    traduction_detail_Spanish.Original_Text = role.Description;
                    traduction_detail_Spanish.Translated_Text = role.Description;
                    _ISpartan_Traduction_DetailApiConsumer.Insert(traduction_detail_Spanish, null, null);
                    Spartan_Traduction_Detail traduction_detail_English = new Spartan_Traduction_Detail();
                    traduction_detail_English.Concept = 1;
                    traduction_detail_English.Spartan_Traduction_Process = 3;
                    traduction_detail_English.IdConcept = roleAdded.Resource;
                    traduction_detail_English.Original_Text = role.Description;
                    traduction_detail_English.Translated_Text = role.Description;
                    _ISpartan_Traduction_DetailApiConsumer.Insert(traduction_detail_English, null, null);
                }
            }
            else
            {
                var roleUpdated = _IUserRoleApiConsumer.Update(role, null, null);
                if (roleUpdated != null)
                    successRecord = true;
            }

            if (successRecord)
            {
                Roles.InsertUpdateObject(role.User_Role_Id, role.Description, "en-us");
                Roles.InsertUpdateObject(role.User_Role_Id, role.Description, "es-es");
            }

            return Json(successRecord ? "success" : "error", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Add new user roles
        /// </summary>
        /// <remarks>
        /// Dummy Data has been passed as of now for test.
        /// Actual form will be provided by Ricardo later.
        /// </remarks>
        /// <returns></returns>
        public JsonResult AddOrUpdateModule(SpartanModule module)
        {
            var successRecord = false;

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartanModuleApiConsumer.SetAuthHeader(_tokenManager.Token);

            if (module != null)
            {
                module.System_Id = 1;
                module.Order_Shown = 1;
                module.Image = 11;
            }

            if (module.Module_Id == 0)
            {
                var moduleAdded = _ISpartanModuleApiConsumer.Insert(module, null, null);
                if (moduleAdded != null)
                {
                    successRecord = true;
                    module.Module_Id = moduleAdded.Resource;

                    //ADD TO TRADUCTION DETAIL TABLE
                    _ISpartan_Traduction_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                    Spartan_Traduction_Detail traduction_detail_Spanish = new Spartan_Traduction_Detail();
                    traduction_detail_Spanish.Concept = 2;
                    traduction_detail_Spanish.Spartan_Traduction_Process = 2;
                    traduction_detail_Spanish.IdConcept = moduleAdded.Resource;
                    traduction_detail_Spanish.Original_Text = module.Name;
                    traduction_detail_Spanish.Translated_Text = module.Name;
                    _ISpartan_Traduction_DetailApiConsumer.Insert(traduction_detail_Spanish, null, null);
                    Spartan_Traduction_Detail traduction_detail_English = new Spartan_Traduction_Detail();
                    traduction_detail_English.Concept = 2;
                    traduction_detail_English.Spartan_Traduction_Process = 4;
                    traduction_detail_English.IdConcept = moduleAdded.Resource;
                    traduction_detail_English.Original_Text = module.Name;
                    traduction_detail_English.Translated_Text = module.Name;
                    _ISpartan_Traduction_DetailApiConsumer.Insert(traduction_detail_English, null, null);
                }
            }
            else
            {
                var roleUpdated = _ISpartanModuleApiConsumer.Update(module, null, null);
                if (roleUpdated != null)
                    successRecord = true;
            }
            


            if (successRecord)
            {
                Modules.InsertUpdateModule(module.Module_Id, module.Name, "en-us");
                Modules.InsertUpdateModule(module.Module_Id, module.Name, "es-es");
            }

            return Json(successRecord ? "success" : "error", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// To Delete existing user role.
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public JsonResult DeleteUserRoles(int roleID)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _IUserRoleApiConsumer.SetAuthHeader(_tokenManager.Token);

            var result = _IUserRoleApiConsumer.Delete(roleID, null, null);

            return Json(result == null ? null : "deleted", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteSpartanModule(string ModuleID)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartanModuleApiConsumer.SetAuthHeader(_tokenManager.Token);

            int mid = Convert.ToInt32(ModuleID);
            _ISpartanUserRoleModuleApiConsumer.SetAuthHeader(_tokenManager.Token);
            var relations = _ISpartanUserRoleModuleApiConsumer.SelAll(false, "Spartan_User_Rule_Module.Module_Id=" + ModuleID, "Spartan_User_Rule_Module.Module_Id").Resource;

            if (relations.Count == 0)
            {
                var result = _ISpartanModuleApiConsumer.Delete(mid, null, null);
                return Json(result.Success, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);

        }

        //Cambios de josefina
        [HttpGet]
        public EmptyResult RegenerateMenu()
        {
            Spartane.Web.Helpers.PermissionHelper.SetPermissions();
            Spartane.Web.Helpers.MenuHelper.GetLatestMenu();
            return new EmptyResult();
        }

        [HttpPost]
        public JsonResult AssignSpartaneUserRoleModuleObject(SpartanUserRoleModuleObject dataHolder)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return null;
                _ISpartaneUserRoleModuleObjectApiConsumer.SetAuthHeader(_tokenManager.Token);

                var result = _ISpartaneUserRoleModuleObjectApiConsumer.Insert(dataHolder, null, null);

                if (result.Success)
                {
                    return Json(Convert.ToInt32(result.Resource), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("0", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json("-1", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AssignUserRoleFunctions(SpartaneUserRoleObjectFunction dataHolder)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return null;
                _ISpartaneUserRoleObjectFunctionApiConsumer.SetAuthHeader(_tokenManager.Token);

                var result = _ISpartaneUserRoleObjectFunctionApiConsumer.Insert(dataHolder, null, null);

                if (result.Success)
                {

                    return Json(Convert.ToInt32(result.Resource), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("0", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json("-1", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult UnAssignUserRoleFunctions(int userRoleObjectFunctionId, int userRole)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return null;
                _ISpartaneUserRoleObjectFunctionApiConsumer.SetAuthHeader(_tokenManager.Token);

                var result = _ISpartaneUserRoleObjectFunctionApiConsumer.Delete(userRoleObjectFunctionId, userRole, null, null);

                if (result.Success)
                {
                    //Spartane.Web.Helpers.MenuHelper.GetLatestMenu();
                    return Json(Convert.ToInt32(result.Resource), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("0", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json("-1", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult UnAssignSpartaneUserRoleModuleObject(string userRoleModuleObjectID, string UserRole)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return null;
                _ISpartaneUserRoleModuleObjectApiConsumer.SetAuthHeader(_tokenManager.Token);

                var result = _ISpartaneUserRoleModuleObjectApiConsumer.Delete(Convert.ToInt32(userRoleModuleObjectID), Convert.ToInt32(UserRole), null, null);

                if (result.Success)
                {
                    //Spartane.Web.Helpers.MenuHelper.GetLatestMenu();
                    return Json("1", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("0", JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception)
            {
                return Json("-1", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult AddSpartanUserRoleModules(CustomDataHolder dataHolder)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartanUserRoleModuleApiConsumer.SetAuthHeader(_tokenManager.Token);

            List<SpartaneUserRoleModule> lstAddSpartneUserRoleModule = new List<SpartaneUserRoleModule>();

            lstAddSpartneUserRoleModule = CreateModuleHierarchy(dataHolder);

            int success = 1;

            foreach (SpartaneUserRoleModule spUserRoleModule in lstAddSpartneUserRoleModule)
            {
                var result = _ISpartanUserRoleModuleApiConsumer.Insert(spUserRoleModule, null, null);

                if (result == null)
                {
                    success = 0;
                    return Json(success, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(success, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteSpartanUserRoleModules(CustomDataHolder dataHolder)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartanUserRoleModuleApiConsumer.SetAuthHeader(_tokenManager.Token);

            int success = 1;

            List<SpartaneUserRoleModule> lstDeleteSpartneUserRoleModule = new List<SpartaneUserRoleModule>();

            lstDeleteSpartneUserRoleModule = CreateModuleHierarchy(dataHolder);

            foreach (SpartaneUserRoleModule spModule in lstDeleteSpartneUserRoleModule)
            {
                var result = _ISpartanUserRoleModuleApiConsumer.Delete(spModule.User_Rule_Module_Id, spModule.Spartan_User_Role, null, null);

                if (result.Success == false)
                {
                    success = 0;
                    return Json(success, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(success, JsonRequestBehavior.AllowGet);
        }

        //Cambios de josefina
        [HttpPost]
        public JsonResult GetAllSpartaneModuleObject(string ModuleID, string RoleID, bool All)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartaneUserRoleModuleObjectApiConsumer.SetAuthHeader(_tokenManager.Token);

            int mid = Convert.ToInt32(ModuleID);
            int roleID = Convert.ToInt32(RoleID);

            var spartaneObject = new List<SpartaneObject>();
            spartaneObject = _ISpartaneObjectApiConsumer.ListaSelAll(1, int.MaxValue, string.Empty, string.Empty).Resource.Spartan_Objects;

            string whereClause = "Spartan_User_Rule_Module_Object.Module_Id=" + ModuleID + " AND Spartan_User_Role = " + RoleID; // Can be added later in ListaSelAll method.            
            var result = _ISpartaneUserRoleModuleObjectApiConsumer.SelAll(false, whereClause, "Spartan_User_Rule_Module_Object.Object_Id");
            var lstGlobalSpartaneRuleModuleObject = (List<SpartanUserRoleModuleObject>)result.Resource;

            var lstCustomDataHolder = GetModuleRoleObject(spartaneObject, lstGlobalSpartaneRuleModuleObject, mid, roleID, All);

            if (lstCustomDataHolder == null)
                return Json("", JsonRequestBehavior.AllowGet);
            else
                return Json(lstCustomDataHolder, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetPermissionsForObjects(string moduleID, string RoleID)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return null;
                _ISpartaneUserRoleObjectFunctionApiConsumer.SetAuthHeader(_tokenManager.Token);

                int mID = Convert.ToInt32(moduleID);
                int roleID = Convert.ToInt32(RoleID);

                List<SpartaneUserRoleObjectFunction> lstSpUsrRoleObjectFunction;

                var result = _ISpartaneUserRoleObjectFunctionApiConsumer.SelAll(false).Resource.ToList();

                lstSpUsrRoleObjectFunction = result.Where(m => m.Module_Id == mID && m.Spartan_User_Rule == roleID).ToList();

                if (lstSpUsrRoleObjectFunction == null || lstSpUsrRoleObjectFunction.Count == 0)
                    return Json("", JsonRequestBehavior.AllowGet);
                else
                    return Json(lstSpUsrRoleObjectFunction, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("-1", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetSpartaneObjects(string roleID, string filter)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return null;
                _ISpartaneObjectApiConsumer.SetAuthHeader(_tokenManager.Token);

                //Begin Modificacion SB
                string where = "Object_Id not in (";
                where += "select so.Object_Id from [dbo].[Spartan_Object] so";
                where += " left join Spartan_User_Rule_Module_Object sur";
                where += " on sur.Object_Id = so.Object_Id";
                where += " where sur.Spartan_User_Role = " + roleID + ")";
                //End Modificacion SB
                if (filter != "")
                {
                    where += " AND Spartan_Object.Description like '%" + filter + "%'";
                }

                var spartaneObject = _ISpartaneObjectApiConsumer.ListaSelAll(1, int.MaxValue, where, "").Resource;

                //var spartaneObject = _ISpartaneObjectApiConsumer.ListaSelAll(1, int.MaxValue,"","").Resource;

                if (spartaneObject == null ||
                    spartaneObject.Spartan_Objects == null)
                    return Json("", JsonRequestBehavior.AllowGet);
                else
                    return Json(spartaneObject, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("-1", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ReOrderUserRoleModules(string userRole, string module, string order, string direction)
        {
            try
            {
                List<SpartaneUserRoleModule> lstUserRoleModule;
                List<SpartaneUserRoleModule> lstModulestoUpdate = new List<SpartaneUserRoleModule>();
                int role = Convert.ToInt32(userRole);
                int moduleID = Convert.ToInt32(module);
                int orderShown = Convert.ToInt32(order);
                //int count = 0;
                int success = 1;

                if (lstGlobalUserRoleModule.Count != 0 && lstGlobalUserRoleModule != null)
                {
                    lstUserRoleModule = lstGlobalUserRoleModule.Where(m => m.Spartan_User_Role == role).ToList();
                }
                else
                {
                    lstUserRoleModule = GetSpartaneUserRoleModules(Convert.ToInt32(userRole));
                }

                lstUserRoleModule = lstUserRoleModule.OrderBy(m => m.Order_Shown).ToList();

                lstModulestoUpdate = OrderModules(lstUserRoleModule, direction, moduleID, orderShown);

                //Update Orders

                if (!_tokenManager.GenerateToken())
                    return null;
                _ISpartanUserRoleModuleApiConsumer.SetAuthHeader(_tokenManager.Token);

                foreach (SpartaneUserRoleModule oUserRoleModule in lstModulestoUpdate)
                {
                    var result = _ISpartanUserRoleModuleApiConsumer.Update(oUserRoleModule, null, null);

                    if (!(result.Success))
                    {
                        success = 0;
                        return Json(success, JsonRequestBehavior.AllowGet);
                    }
                }

                return Json(success, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json("-1", JsonRequestBehavior.AllowGet);
            }
        }

        #endregion Action Methods

        #region helpermethods

        //Cambios de josefina
        private List<CustomDataHolder> GetModuleRoleObject(List<SpartaneObject> objects, List<SpartanUserRoleModuleObject> lstspartaneModuleObject, int mid, int roleID, bool all)
        {
            _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
            List<SpartanUserRoleModuleObject> lsRoleModuleObject = GetSpartaneUserRoleModuleObjects(mid, roleID);
            int objectType;
            List<CustomDataHolder> lstdataHolder = new List<CustomDataHolder>();

            if (!all)
                objects = objects.Where(obj => lstspartaneModuleObject.Where(obj2 => obj2.Object_Id == obj.Object_Id).Count() > 0).ToList();
            if (objects.Count != 0)
            {
                var haveObjects = lstspartaneModuleObject.Count > 0;
                foreach (SpartaneObject sprtnModObject in objects)
                {
                    CustomDataHolder dataHolder = new CustomDataHolder();

                    var item = haveObjects ? lstspartaneModuleObject.Where(obj => obj.Object_Id == sprtnModObject.Object_Id).FirstOrDefault() : null;
                    if (item == null)
                    {
                        dataHolder.Checked = "";
                    }
                    else
                    {
                        dataHolder.Checked = "checked";
                        dataHolder.User_Rule_Module_Object_Id = item.User_Rule_Module_Object_Id;
                    }

                    // objectName = Objects.GetObjectValueById(sprtnModObject.Object_Id);

                    dataHolder.Module_Object_Id = sprtnModObject.Object_Id;
                    dataHolder.Data = sprtnModObject.Name;
                    dataHolder.ObjectID = sprtnModObject.Object_Id;
                    objectType = (int)sprtnModObject.Object_Type;
                    dataHolder.ParentObjectId = -1;
                    if (objectType == 6)
                    {
                        var parentObject = _ISpartan_MetadataApiConsumer.ListaSelAll(0, 100, "Spartan_Metadata.Object_Id=" + sprtnModObject.Object_Id + " AND Identifier_Type=2 ", "").Resource;
                        if (parentObject.RowCount != 0 && parentObject.Spartan_Metadatas.First().Related_Object_Id!= null)
                        {
                            int parentObjectId = parentObject.Spartan_Metadatas.First().Related_Object_Id.Value;
                            dataHolder.ParentObjectId = parentObjectId;
                        }
                    }


                    //Get ObjectType and ObjectTypeDescription

                    string objectDescription = Enum.GetName(typeof(Spartan_Object_Type), objectType);
                    dataHolder.ObjectType = objectType;
                    dataHolder.ObjectTypeDescription = objectDescription;

                    ////Set New And Delete Checkboxes
                    /*if (objectType != 1)
                        dataHolder.NewEditDisabled = "disabled";
                    else
                        dataHolder.NewEditDisabled = "";*/

                    lstdataHolder.Add(dataHolder);
                }

                return lstdataHolder;
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// Get Spartane Modules associated with Specific role.
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public List<SpartaneUserRoleModule> GetSpartaneUserRoleModules(int roleID)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartanUserRoleModuleApiConsumer.SetAuthHeader(_tokenManager.Token);

            var result = _ISpartanUserRoleModuleApiConsumer.SelAll(false).Resource;

            if (result != null)
            {
                lstGlobalUserRoleModule = result.ToList();
                return result.Where(m => m.Spartan_User_Role == roleID).ToList();
            }
            else
                return null;
        }

        /// <summary>
        /// Method to create Module Structure from Spartane Modules obtained
        /// </summary>
        /// <param name="result"></param>
        /// <remarks>
        ///
        /// </remarks>
        /// <returns></returns>
        private List<FlatObject> CreateModuleHierarchy(IList<SpartanModule> result)
        {
            List<FlatObject> lstFlatObject = new List<FlatObject>();
            string moduleName;

            foreach (SpartanModule spartanModule in result)
            {
                moduleName = Modules.GetModuleValueById(spartanModule.Module_Id);

                FlatObject flatObject = new FlatObject(moduleName, spartanModule.Module_Id, spartanModule.Parent_Module ?? 0, spartanModule.Order_Shown);

                lstFlatObject.Add(flatObject);
            }

            return lstFlatObject;
        }

        private List<SpartaneUserRoleModule> CreateModuleHierarchy(CustomDataHolder dataHolder)
        {
            try
            {
                int maxOrder = GetMaxOrder(dataHolder.ModuleID, dataHolder.UserRoleID);

                string[] childrens = dataHolder.childrens;

                List<SpartaneUserRoleModule> lstSpartaneUserRoleModule = new List<SpartaneUserRoleModule>();

                SpartaneUserRoleModule usrRoleModule = new SpartaneUserRoleModule();
                usrRoleModule.Module_Id = dataHolder.ModuleID;
                usrRoleModule.Spartan_User_Role = dataHolder.UserRoleID;
                usrRoleModule.Order_Shown = ++maxOrder;
                usrRoleModule.User_Rule_Module_Id = GetUserRoleModuleID(dataHolder.ModuleID, dataHolder.UserRoleID);
                lstSpartaneUserRoleModule.Add(usrRoleModule);

                if (childrens != null)
                {
                    foreach (string child in childrens)
                    {
                        SpartaneUserRoleModule tempModule = new SpartaneUserRoleModule();
                        tempModule.Module_Id = Convert.ToInt32(child);
                        tempModule.Spartan_User_Role = dataHolder.UserRoleID;
                        tempModule.Order_Shown = ++maxOrder;
                        tempModule.User_Rule_Module_Id = GetUserRoleModuleID(Convert.ToInt32(child), dataHolder.UserRoleID);
                        lstSpartaneUserRoleModule.Add(tempModule);
                    }
                }

                return lstSpartaneUserRoleModule;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Method to build Object to bind
        /// JSTree with structured data.
        /// </summary>
        /// <param name="flatObjects"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        private List<RecursiveObject> FillRecursive(List<FlatObject> flatObjects, Int64 parentId)
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

                if (index >= 0)
                    moduleSelected = true;
                else
                    moduleSelected = false;

                recursiveObjects.Add(new RecursiveObject
                {
                    id = item.Id,
                    text = item.data,
                    state = new FlatTreeAttribute
                    {
                        opened = moduleSelected,
                        selected = moduleSelected
                    },
                    children = FillRecursive(flatObjects, item.Id),
                    originalOrder = item.Order_Shown,
                    moduleOrder = orderShown
                });
            }

            return recursiveObjects;
        }

        private int GetMaxOrder(int moduleID, int userRoleID)
        {
            int maxOrder = 0;

            try
            {
                maxOrder = lstGlobalUserRoleModule.Where(m => m.Spartan_User_Role == userRoleID).Max(m => m.Order_Shown);
                return maxOrder;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private int GetUserRoleModuleID(int moduleID, int userRoleID)
        {
            int userRoleModuleID = 0;

            try
            {
                if (lstGlobalUserRoleModule.Count != 0)
                {
                    userRoleModuleID = lstGlobalUserRoleModule.Where(m => m.Spartan_User_Role == userRoleID && m.Module_Id == moduleID).Select(m => m.User_Rule_Module_Id).FirstOrDefault();
                    return userRoleModuleID;
                }
                else
                {
                    List<SpartaneUserRoleModule> lstSpUserRoleModule = GetSpartaneUserRoleModules(userRoleID).ToList();
                    userRoleModuleID = lstSpUserRoleModule.Where(m => m.Spartan_User_Role == userRoleID && m.Spartan_User_Role == userRoleID).Select(m => m.User_Rule_Module_Id).FirstOrDefault();
                    return userRoleModuleID;
                }
            }
            catch (Exception)
            {
                return userRoleID;
            }
        }

        private List<SpartanUserRoleModuleObject> GetSpartaneUserRoleModuleObjects(int moduleID, int userRoleID)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return null;
                _ISpartaneUserRoleModuleObjectApiConsumer.SetAuthHeader(_tokenManager.Token);

                List<SpartanUserRoleModuleObject> lstSpUsrRoleModuleObject;

                //if (lstGlobalSpartaneModuleObject.Count != 0)
                //{
                //    lstSpUsrRoleModuleObject = lsGlobalUserRoleModuleObject.Where(m => m.Module_Id == moduleID && m.Spartan_User_Role == userRoleID).ToList();
                //}
                //else
                //{
                var result = _ISpartaneUserRoleModuleObjectApiConsumer.SelAll(false).Resource;
                lsGlobalUserRoleModuleObject = result.ToList();

                lstSpUsrRoleModuleObject = lsGlobalUserRoleModuleObject.Where(m => m.Module_Id == moduleID && m.Spartan_User_Role == userRoleID).ToList();
                //}
                return lstSpUsrRoleModuleObject;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private List<SpartaneObject> GetAllSpartaneObjects()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return null;
                _ISpartaneObjectApiConsumer.SetAuthHeader(_tokenManager.Token);

                return _ISpartaneObjectApiConsumer.SelAll(false).Resource.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<SpartaneUserRoleModule> OrderModules(List<SpartaneUserRoleModule> lstUserRoleModule, string direction, int moduleID, int orderShown)
        {
            try
            {
                List<SpartaneUserRoleModule> lstModulestoUpdate = new List<SpartaneUserRoleModule>();

                SpartaneUserRoleModule spCurrentModule = lstUserRoleModule.Where(m => m.Module_Id == moduleID).FirstOrDefault();
                SpartaneUserRoleModule moduleToSwap = null;
                int count = 0;

                foreach (SpartaneUserRoleModule oUserRoleModule in lstUserRoleModule)
                {
                    if (oUserRoleModule.Module_Id == moduleID)
                    {
                        if (direction.ToLower().Equals("up"))
                        {
                            moduleToSwap = lstUserRoleModule[--count];
                        }
                        else if (direction.ToLower().Equals("down"))
                        {
                            moduleToSwap = lstUserRoleModule[++count];
                        }

                        break;
                    }

                    ++count;
                }
                spCurrentModule.Order_Shown = moduleToSwap.Order_Shown;
                moduleToSwap.Order_Shown = orderShown;
                lstModulestoUpdate.Add(spCurrentModule);
                lstModulestoUpdate.Add(moduleToSwap);

                return lstModulestoUpdate;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion helpermethods

        public PartialViewResult _GetObjectModuleList()
        {
            var model = new List<ObjectModuleListModel>();
            for (int i = 0; i < 50; i++)
                model.Add(new ObjectModuleListModel()
                {
                    IsSelected = i % 5 == 0,
                    Name = "Checkbox" + (i + 1),
                    Value = Convert.ToString(i)
                });
            return PartialView(model);
        }

        public PartialViewResult _PermissionForCatalog()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult ReorderObjects(List<Ordered> data)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartaneQueryApiConsumer.SetAuthHeader(_tokenManager.Token);
            StringBuilder query = new StringBuilder();
            foreach (var item in data)
            {
                query.AppendLine("update Spartan_User_Rule_Module_Object set Order_Shown=" + item.order_shown);
                query.AppendLine(" where Object_Id = "+item.object_id+" AND Module_Id = "+ item.moduleId + " AND Spartan_User_Role = " + item.roleId);
            }
            _ISpartaneQueryApiConsumer.ExecuteQuery(query.ToString());
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
    }

    public class Ordered
    {
        public int object_id { get; set; }
        public int order_shown { get; set; }
        public int roleId { get; set; }
        public int moduleId { get; set; }
    }
}