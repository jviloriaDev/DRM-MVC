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

namespace Spartane.Web.Areas.WebApiConsumer
{
    public class SpartanSessionApiConsumer : BaseApiConsumer, ISpartanSessionApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public SpartanSessionApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrl;
            ApiControllerUrl = "/api/Spartan_Session_Log";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<int> Insert(Spartan_Session_Log entity)
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

    }
}
