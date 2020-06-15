using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Spartane.Core.Domain.Permission;
using Spartane.Core.Domain.SpartaneFunction;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.SpartaneFunction;
using Spartane.Web.Areas.WebApiConsumer.SpartaneUserRoleObjectFunction;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phases;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Roles_by_State;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;

namespace Spartane.Web.Helpers
{

    public static class PermissionHelper
    {
        private static readonly ISpartaneUserRoleObjectFunctionApiConsumer _spartaneUserRoleObjectFunctionApiConsumer;
        private static readonly ISpartaneFunctionApiConsumer _spartaneFunctionApiConsumer;
        private static readonly ITokenManager _tokenManager;
        //WorkFlows Permissions
        private static readonly ISpartan_WorkFlowApiConsumer _Spartan_WorkFlowApiConsumer;
        private static readonly ISpartan_WorkFlow_PhasesApiConsumer _Spartan_WorkFlow_PhasesApiConsumer;
        private static readonly ISpartan_WorkFlow_Roles_by_StateApiConsumer _Spartan_WorkFlow_Roles_by_StateApiConsumer;

        private static readonly ISpartan_MetadataApiConsumer _ISpartan_MetadataApiConsumer;
        static PermissionHelper()
        {
            _tokenManager = DependencyResolver.Current.GetService<ITokenManager>();
            _spartaneUserRoleObjectFunctionApiConsumer = DependencyResolver.Current.GetService<ISpartaneUserRoleObjectFunctionApiConsumer>();
            _spartaneFunctionApiConsumer = DependencyResolver.Current.GetService<ISpartaneFunctionApiConsumer>();
            //WorkFlows Permissions
            _Spartan_WorkFlowApiConsumer = DependencyResolver.Current.GetService<ISpartan_WorkFlowApiConsumer>();
            _Spartan_WorkFlow_PhasesApiConsumer = DependencyResolver.Current.GetService<ISpartan_WorkFlow_PhasesApiConsumer>();
            _Spartan_WorkFlow_Roles_by_StateApiConsumer = DependencyResolver.Current.GetService<ISpartan_WorkFlow_Roles_by_StateApiConsumer>();
            _ISpartan_MetadataApiConsumer = DependencyResolver.Current.GetService<ISpartan_MetadataApiConsumer>();
        }
        //CAMBIOS PERMISOS
        public static Permission GetRoleObjectPermission(int roleId, int objectId = 0, int moduleId = 0, int attributeId = 0)
        {
            if (!_tokenManager.GenerateToken("admin", "admin"))
                throw new ArgumentException("Unable to Authorize the application");
            if (objectId == 0 && attributeId != 0)
            {
                _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
                var resultMeta = _ISpartan_MetadataApiConsumer.GetByKey(attributeId, false).Resource;
                objectId = Convert.ToInt32(resultMeta.Related_Object_Id);
            }
            if (System.Web.HttpContext.Current.Session["Permissions"] == null)
            {
                SetPermissions();
            }
            List<Permission> ret = (List<Permission>)System.Web.HttpContext.Current.Session["Permissions"];
            if (ret != null)
            {
                ret = ret.Where(x => x.Role == roleId).ToList();
                if (moduleId != 0)
                {
                    ret = ret.Where(x => x.Module == moduleId).ToList();
                }
                if (objectId != 0)
                {
                    ret = ret.Where(x => x.Object == objectId).ToList();
                }
                if (ret.Count == 0)
                {
                    ret.Add(new Permission());
                }
                return ret.FirstOrDefault();
            }
            return null;
        }
        //CAMBIOS PERMISOS
        public static void SetPermissions()
        {
            List<Permission> permissions = new List<Permission>();
            if (!_tokenManager.GenerateToken("admin", "admin"))
                throw new ArgumentException("Unable to Authorize the application");
            _spartaneUserRoleObjectFunctionApiConsumer.SetAuthHeader(_tokenManager.Token);
            _spartaneFunctionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var userRoleObjectFunctions = _spartaneUserRoleObjectFunctionApiConsumer.ListaSelAll(1, int.MaxValue, "", "").Resource;

            if (userRoleObjectFunctions == null || userRoleObjectFunctions.Spartan_User_Rule_Object_Functions == null)
                System.Web.HttpContext.Current.Session["Permissions"] = null;

            var spartaneFuctions = new List<SpartaneFunction>();
            Permission ObjectPermission = null;
            bool exist = true;
            foreach (var userRoleObjectFunction in userRoleObjectFunctions.Spartan_User_Rule_Object_Functions)
            {
                exist = true;
                ObjectPermission = permissions.Where(x => x.Module == userRoleObjectFunction.Module_Id && x.Role == userRoleObjectFunction.Spartan_User_Rule && x.Object == userRoleObjectFunction.Object_Id).FirstOrDefault();
                if (ObjectPermission == null)
                {
                    ObjectPermission = new Permission();
                    ObjectPermission.New = false;
                    ObjectPermission.Consult = false;
                    ObjectPermission.Edit = false;
                    ObjectPermission.Delete = false;
                    ObjectPermission.Export = false;
                    ObjectPermission.Print = false;
                    ObjectPermission.Configure = false;
                    exist = false;
                }

                ObjectPermission.Module = userRoleObjectFunction.Module_Id;
                ObjectPermission.Role = userRoleObjectFunction.Spartan_User_Rule;
                ObjectPermission.Object = userRoleObjectFunction.Object_Id;
                switch (userRoleObjectFunction.Fuction_Id)
                {
                    case 1: ObjectPermission.Consult = true;
                        break;
                    case 2: ObjectPermission.New = true;
                        break;
                    case 3: ObjectPermission.Edit = true;
                        break;
                    case 4: ObjectPermission.Delete = true;
                        break;
                    case 5: ObjectPermission.Export = true;
                        break;
                    case 6: ObjectPermission.Print = true;
                        break;
                    case 7: ObjectPermission.Configure = true;
                        break;

                }
                if (!exist)
                    permissions.Add(ObjectPermission);
            }

            System.Web.HttpContext.Current.Session["Permissions"] = permissions;
        }

        private static Permission GetSpartanePermission(IEnumerable<SpartaneFunction> spartaneFunctions)
        {
            var permission = new Permission();
            try
            {
                foreach (var spartaneFunction in spartaneFunctions)
                {
                    if (spartaneFunction.Status == 1)
                        switch (spartaneFunction.Description.ToUpper())
                        {
                            case "CONSULT": permission.Consult = true;
                                break;
                            case "NEW": permission.New = true;
                                break;
                            case "EDIT": permission.Edit = true;
                                break;
                            case "DELETE": permission.Delete = true;
                                break;
                            case "EXPORT": permission.Export = true;
                                break;
                            case "PRINT": permission.Print = true;
                                break;
                            case "CONFIGURE": permission.Configure = true;
                                break;

                        }
                }
                return permission;
            }
            catch (Exception)
            {
                return permission;
            }
        }
    }
}
