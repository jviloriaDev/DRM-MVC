using System.Web.Mvc;

namespace Spartane.Web.Areas.Frontal
{
    public class WebAPIAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Frontal";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Frontal_default",
                "Frontal/{controller}/{action}/{id}",
                new {action= "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Spartane.Web.Areas.Frontal.Controllers"}
            );
            //context.MapRoute(
            //    "WebAPI_default",
            //    "Frontal/api/{controller}/{id}",
            //    new { action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}