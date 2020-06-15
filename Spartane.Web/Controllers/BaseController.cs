using Spartane.Web.Areas.Frontal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spartane.Web.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class BaseController : Controller
    {

            public BaseController()
            {
            }

            public UserContextViewModel CurrentUser
            {
                get
                {
                    if (User.Identity.IsAuthenticated)
                        return (User as AuthenticationExt.Authentication).UserContext;
                    return null;
                }
            }

            protected override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                string actionName = filterContext.ActionDescriptor.ActionName;
                string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            }

        
    }
}