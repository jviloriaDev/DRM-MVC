using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.Http;
using System.Web.SessionState;
using Spartane.Core.Infraestructure;
using System.Net.Http.Formatting;
using Spartane.Core.Log;
using Spartane.Web.Helpers;
using Spartane.Web.ModelBinders;

namespace Spartane.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //initialize engine context
            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            EngineContext.Initialize(false);
            AutofacConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
            System.Web.Mvc.ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());
        }

        protected void Application_Error()
        {
            var exception = Server.GetLastError();

            LoggerHelper.LogError(exception.Message, exception);
        }
    }
}
