using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Spartane.Core.Enums;
using Spartane.Web.Helpers;

namespace Spartane.Web.AuthFilters
{
    public class ObjectAuthAttribute : FilterAttribute, IAuthorizationFilter
    {
        public ModuleObjectId ObjectId { set; get; }
        public PermissionTypes PermissionType { set; get; }
        public PermissionTypes OptionalPermissionType { set; get; }
        public PermissionTypes OptionalPermissionTypeConsult { set; get; }
        public string OptionalParameter { set; get; }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            //  var sessioninfo = new SessionManager();
            if (!string.IsNullOrEmpty(OptionalParameter) &&
                !string.IsNullOrEmpty(filterContext.HttpContext.Request.Params[OptionalParameter]))
            {

                if (filterContext.HttpContext.Request.Params[OptionalParameter] != "0")
                {
                    PermissionType = OptionalPermissionType;
                }
            }

            var permissionInfo = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, Convert.ToInt32(ObjectId));

            var authorized = Convert.ToBoolean(permissionInfo.GetType()
                .GetProperty(PermissionType.ToString())
                .GetValue(permissionInfo, null));

            if (!authorized && OptionalPermissionTypeConsult > 0)
                authorized = Convert.ToBoolean(permissionInfo.GetType()
                   .GetProperty(OptionalPermissionTypeConsult.ToString())
                   .GetValue(permissionInfo, null));

            if (authorized)
                return;

            var controller = filterContext.RouteData.Values["controller"] ?? "InValid";
            var action = filterContext.RouteData.Values["action"] ?? "InValid";

            filterContext.Result = new HttpUnauthorizedResult();
            HttpContext.Current.Response.Redirect("~/Frontal/Accounts/UnAuthorized?controllerName=" + controller.ToString() + "&actionName=" + action.ToString());
        }
    }



}

