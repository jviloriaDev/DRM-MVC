//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using RestSharp;
//using Spartane.Core.Domain.Data;

//using Spartane.Core.Domain.User;

//using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

//namespace Spartane.Web.Areas.WebApiConsumer.UserRole
//{
//    public class UserRoleApiConsumer : BaseApiConsumer,IUserRoleApiConsumer
//    {
//        public override sealed string ApiControllerUrl { get; set; }
//        public string baseApi;

//        public UserRoleApiConsumer()
//        {
//            baseApi = ApiUrlManager.BaseUrl;
//            ApiControllerUrl = "/api/spartan_user_role/";
//        }
//        public int SelCount()
//        {
//            throw new NotImplementedException();
//        }

//        public ApiResponse<IList<Core.Domain.UserRole.UserRole>> SelAll(bool ConRelaciones)
//        {
//            try
//            {
//                var products = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.UserRole.UserRole>>(baseApi, ApiControllerUrl + "/GetAll",
//                      Method.GET, ApiHeader);

//                return new ApiResponse<IList<Core.Domain.UserRole.UserRole>>(true, products);
//            }
//            catch (Exception)
//            {
//                return new ApiResponse<IList<Core.Domain.UserRole.UserRole>>(false, null);
//            }

//        }

//        public ApiResponse<IList<Core.Domain.UserRole.UserRole>> SelAllComplete(bool ConRelaciones)
//        {
//            try
//            {
//                var products = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.UserRole.UserRole>>(baseApi, ApiControllerUrl + "/GetAllComplete",
//                      Method.GET, ApiHeader);

//                return new ApiResponse<IList<Core.Domain.UserRole.UserRole>>(true, products);
//            }
//            catch (Exception)
//            {
//                return new ApiResponse<IList<Core.Domain.UserRole.UserRole>>(false, null);
//            }
//        }

//        public ApiResponse<Core.Domain.UserRole.UserRole> GetByKey(int? Key, bool ConRelaciones)
//        {
//            try
//            {
//                var products = RestApiHelper.InvokeApi<Spartane.Core.Domain.UserRole.UserRole>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
//                      Method.GET, ApiHeader);

//                return new ApiResponse<Core.Domain.UserRole.UserRole>(true, products);
//            }
//            catch (Exception)
//            {
//                return new ApiResponse<Core.Domain.UserRole.UserRole>(false, null);
//            }
//        }

//        public ApiResponse<bool> Delete(int? Key, GlobalData UserRoleInformation, DataLayerFieldsBitacora DataReference)
//        {
//            try
//            {
//                var result = RestApiHelper.InvokeApi<bool>(baseApi, ApiControllerUrl + "/Delete?Id=" + Key,
//                      Method.DELETE, ApiHeader);

//                return new ApiResponse<bool>(true, result);
//            }
//            catch (Exception)
//            {
//                return new ApiResponse<bool>(false, false);
//            }
//        }

//        public ApiResponse<int> Insert(Core.Domain.UserRole.UserRole entity, GlobalData UserRoleInformation, DataLayerFieldsBitacora DataReference)
//        {
//            try
//            {
//                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Post",
//                      Method.POST, ApiHeader, entity);

//                return new ApiResponse<int>(true, result);
//            }
//            catch (Exception)
//            {
//                return new ApiResponse<int>(false, -1);
//            }
//        }

//        public ApiResponse<int> Update(Core.Domain.UserRole.UserRole entity, GlobalData UserRoleInformation, DataLayerFieldsBitacora DataReference)
//        {
//            try
//            {
//                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.User_Role_Id,
//                      Method.PUT, ApiHeader, entity);

//                return new ApiResponse<int>(true, result);
//            }
//            catch (Exception)
//            {
//                return new ApiResponse<int>(false, -1);
//            }
//        }

//        public ApiResponse<IList<Core.Domain.UserRole.UserRole>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
//        {
//            throw new NotImplementedException();
//        }

//        public ApiResponse<IList<Core.Domain.UserRole.UserRole>> SelAll(bool ConRelaciones, string Where, string Order)
//        {
//            throw new NotImplementedException();
//        }

//        public ApiResponse<IList<Core.Domain.UserRole.UserRole>> ListaSelAll(bool ConRelaciones, string Where, string Order)
//        {
//            throw new NotImplementedException();
//        }

//        public ApiResponse<Core.Domain.UserRole.UserRolePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
//        {
//            try
//            {
//                var products = RestApiHelper.InvokeApi<Spartane.Core.Domain.UserRole.UserRolePagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
//                    "&maximumRows=" + maximumRows +
//                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
//                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
//                     Method.GET, ApiHeader);

//                return new ApiResponse<Core.Domain.UserRole.UserRolePagingModel>(true, products);


//            }
//            catch (Exception)
//            {
//                return new ApiResponse<Core.Domain.UserRole.UserRolePagingModel>(false, new Core.Domain.UserRole.UserRolePagingModel() { Spartan_User_Roles = null, RowCount = 0 });
//            }
//        }

//        public ApiResponse<IList<Core.Domain.UserRole.UserRole>> ListaSelAll(bool ConRelaciones, string Where)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
