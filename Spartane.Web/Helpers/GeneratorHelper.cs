using RestSharp;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Spartane.Web.Helpers
{
    public static class GeneratorHelper
    {
        public static bool PublishWebApi(int projectId, string token)
        {
            try
            {
                string apiEngine = ConfigurationManager.AppSettings["BaseURLApiGenerator"];
                var result = RestApiHelper.InvokeApi<string>(apiEngine, "/api/SpartaneEngine/PublishWebApi?projectId=" + projectId.ToString(),
                      Method.GET, new OAuthHeader(token));

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}