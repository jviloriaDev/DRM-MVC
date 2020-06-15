//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using RestSharp;
//using Spartane.Core.Domain.User;
//using Spartane.Core.Domain.Data;
//using Spartane.Core.Domain.Spartane_File;
//using Spartane.Web.Areas.WebApiConsumer;
//using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;


//namespace Spartane.Web.Areas.WebApiConsumer
//{
//    public class UserApiConsumer : BaseApiConsumer, IUserApiConsumer
//    {
//        public override sealed string ApiControllerUrl { get; set; }
//        public string baseApi;

//        public UserApiConsumer()
//        {
//            baseApi = ApiUrlManager.BaseUrl;
//            ApiControllerUrl = "/api/Spartan_User";
//        }
//        public int SelCount()
//        {
//            throw new NotImplementedException();
//        }
//        //Start Modificacion SB
//        public ApiResponse<IList<Core.Domain.User.Spartan_UserObject>> SelAll(bool ConRelaciones)
//        {
//            try
//            {
//                var products = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.User.Spartan_UserObject>>(baseApi, ApiControllerUrl + "/GetAll",
//                      Method.GET, ApiHeader);

//                return new ApiResponse<IList<Core.Domain.User.Spartan_UserObject>>(true, products);
//            }
//            catch (Exception)
//            {
//                return new ApiResponse<IList<Core.Domain.User.Spartan_UserObject>>(false, null);
//            }

//        }
//        //End Modificacion SB
//        public ApiResponse<IList<Core.Domain.User.Spartan_UserObject>> SelAllObject(bool ConRelaciones)
//        {
//            try
//            {
//                var products = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.User.Spartan_UserObject>>(baseApi, ApiControllerUrl + "/GetAll",
//                      Method.GET, ApiHeader);

//                return new ApiResponse<IList<Core.Domain.User.Spartan_UserObject>>(true, products);
//            }
//            catch (Exception)
//            {
//                return new ApiResponse<IList<Core.Domain.User.Spartan_UserObject>>(false, null);
//            }

//        }

//        public ApiResponse<Spartan_UserPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
//        {
//            try
//            {
//                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.User.Spartan_UserPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
//                    "&maximumRows=" + maximumRows +
//                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
//                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
//                     Method.GET, ApiHeader);

//                return new ApiResponse<Core.Domain.User.Spartan_UserPagingModel>(true, varRecords);


//            }
//            catch (Exception)
//            {
//                return new ApiResponse<Core.Domain.User.Spartan_UserPagingModel>(false, new Spartan_UserPagingModel() { Spartan_Users = null, RowCount = 0 });
//            }
//        }

//        public ApiResponse<Spartan_User_Core> ValidateUser(int startRowindex, int maximumrows, string WhereCondition)
//        {
//            try
//            {
//                var users = RestApiHelper.InvokeApi<Spartan_User_Core>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowindex=" + startRowindex + "&maximumrows=" +
//                    maximumrows +"&where=" + WhereCondition,
//                      Method.GET, ApiHeader);

//                return new ApiResponse<Spartan_User_Core>(true, users);
//            }
//            catch (Exception)
//            {
//                return new ApiResponse<Spartan_User_Core>(false, null);
//            }
//        }

//        public ApiResponse<int> Update(Core.Domain.User.SpartanUser entity)
//        {
//            try
//            {
//                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.Id_User,
//                      Method.PUT, ApiHeader, entity);

//                return new ApiResponse<int>(true, result);
//            }
//            catch (Exception)
//            {
//                return new ApiResponse<int>(false, -1);
//            }
//        }

        
//    }
//}
