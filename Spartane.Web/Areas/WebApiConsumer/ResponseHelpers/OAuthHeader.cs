using System.Collections.Generic;
using Newtonsoft.Json;

namespace Spartane.Web.Areas.WebApiConsumer.ResponseHelpers
{
    public class OAuthHeader
    {
        public static string TokenType = "Bearer";
        public static string AuthorizationHeaderName = "Authorization";

        public OAuthHeader(string token)
        {
            Token = token;
        }

        public string Token { get; set; }

        public IDictionary<string, string> GetHeaders()
        {
            var headers = new Dictionary<string, string>
            {
                 {AuthorizationHeaderName,TokenType +" "+ Token}
            };

            return headers;
        }
    }

    public class ApiToken
    {
        [JsonProperty(PropertyName = "access_token")]
        public string Token { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public long ExpiresIn { get; set; }

        [JsonProperty(PropertyName = "refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }
    }

    public class ApiTokenObject
    {
        public string grant_type { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
