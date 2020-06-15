//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using RestSharp;
//using Spartane.Core.Domain.Data;

//using Spartane.Core.Domain.User;

//using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

//namespace Spartane.Web.Areas.WebApiConsumer.UserRoleStatus
//{
//    public class UserRoleStatusApiConsumer : BaseApiConsumer, IUserRoleStatusApiConsumer
//    {
//        public override sealed string ApiControllerUrl { get; set; }
//        public string baseApi;

//        public UserRoleStatusApiConsumer()
//        {
//            baseApi = ApiUrlManager.BaseUrl;
//            ApiControllerUrl = "/api/spartan_user_status/";
//        }

//        public ApiResponse<IList<Core.Domain.UserRoleStatus.UserRoleStatus>> GetAll(bool ConRelaciones)
//        {
//            try
//            {
//                var products = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.UserRoleStatus.UserRoleStatus>>(baseApi, ApiControllerUrl + "/GetAll",
//                      Method.GET, ApiHeader);

//                return new ApiResponse<IList<Core.Domain.UserRoleStatus.UserRoleStatus>>(true, products);
//            }
//            catch (Exception)
//            {
//                return new ApiResponse<IList<Core.Domain.UserRoleStatus.UserRoleStatus>>(false, null);
//            }

//        }
//    }
//}