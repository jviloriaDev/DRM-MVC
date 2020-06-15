using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Language;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;


namespace Spartane.Web.Areas.WebApiConsumer
{
    public class LanguageApiConsumer : BaseApiConsumer, ILanguageApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public LanguageApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrl;
            ApiControllerUrl = "/api/Spartan_System_Language";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Language.SpartanLanguage>> GetAll()
        {
            try
            {
                var products = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Language.SpartanLanguage>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Language.SpartanLanguage>>(true, products);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.Language.SpartanLanguage>>(false, null);
            }

        }

        
    }
}
