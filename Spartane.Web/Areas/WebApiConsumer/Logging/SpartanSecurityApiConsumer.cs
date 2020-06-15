using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Models;

namespace Spartane.Web.Areas.WebApiConsumer
{
    public class SpartanSecurityApiConsumer : BaseApiConsumer,ISpartanSecurityApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public SpartanSecurityApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrl;
            ApiControllerUrl = "/api/Spartan_Security_Log";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<int> Insert(Spartan_Security_Log entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Post",
                      Method.POST, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<int>(false, -1);
            }
        }


        public ApiResponse<VersionValidation> GetVersions()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<VersionValidation>(baseApi, ApiControllerUrl + "/GetVersions",
                      Method.GET, ApiHeader);

                return new ApiResponse<VersionValidation>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<VersionValidation>(false, null);
            }
        }

    }
}
