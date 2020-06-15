using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace Spartane.Web.Infrastructure
{
    public class HttpNotFoundAwareDefaultHttpControllerSelector : DefaultHttpControllerSelector
    {
        public HttpNotFoundAwareDefaultHttpControllerSelector(HttpConfiguration configuration)
            : base(configuration)
        {
        }
        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            HttpControllerDescriptor decriptor = null;
            try
            {
                decriptor = base.SelectController(request);
            }
            catch (HttpResponseException ex)
            {
                var code = ex.Response.StatusCode;
                if (code != HttpStatusCode.NotFound)
                    throw;
                var routeValues = request.GetRouteData().Values;
                routeValues["controller"] = "Error";
                routeValues["action"] = "Handle404";
                decriptor = base.SelectController(request);
            }
            return decriptor;
        }
    }
}
