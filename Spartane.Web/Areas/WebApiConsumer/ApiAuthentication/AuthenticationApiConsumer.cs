using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.ApiAuthentication
{
    public partial class AuthenticationApiConsumer : BaseApiConsumer, IAuthenticationApiConsumer
    {
        public string baseApi;

        public override sealed string ApiControllerUrl { get; set; }

        public AuthenticationApiConsumer()
            : base(string.Empty)
        {
            baseApi = ApiUrlManager.BaseUrl;
            ApiControllerUrl = "/oauth/token";
        }
        /// <summary>
        /// Used to obtaine authentication token
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ApiToken GetApiToken(string username, string password)
        {
            var url = ApiControllerUrl;
            var objApiTokenObject = new ApiTokenObject
            {
                grant_type = "password",
                username = username,
                password = password
            };
            return RestApiHelper.GetAuthentication<ApiToken>(baseApi, url, Method.POST, username, password);
            //return RestApiHelper.InvokeApi<ApiToken>(baseApi, url, Method.POST, body: objApiTokenObject);
        }
    }
}
