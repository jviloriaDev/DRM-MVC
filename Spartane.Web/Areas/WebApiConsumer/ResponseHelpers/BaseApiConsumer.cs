
using System.Web.Mvc;
namespace Spartane.Web.Areas.WebApiConsumer.ResponseHelpers
{
    public interface IApiConsumer
    { }

    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public abstract class BaseApiConsumer : IApiConsumer
    {
        public OAuthHeader ApiHeader { get; set; }
        public abstract string ApiControllerUrl { get; set; }

        protected BaseApiConsumer()
        { }

        protected BaseApiConsumer(string token)
        {
            ApiHeader = new OAuthHeader(token);
        }

        public void SetAuthHeader(string token)
        {
            ApiHeader = new OAuthHeader(token);
        }
    }
}

