using RestSharp;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spartane.Web.Areas.WebApiConsumer.SpartaneUserRoleObjectFunction
{
    public class SpartaneUserRoleObjectFunctionApiConsumer: BaseApiConsumer, ISpartaneUserRoleObjectFunctionApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public SpartaneUserRoleObjectFunctionApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrl;
            ApiControllerUrl = "/api/spartan_user_rule_object_function/";
        }

        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>> SelAll(bool ConRelaciones)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>>(true, products);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>>(false, null);
            }
        }

        public ApiResponse<IList<Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>>(true, products);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction> GetByKey(int? Key, bool ConRelaciones)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<Spartane.Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>(true, products);
            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>(false, null);
            }
        }

        public ApiResponse<bool> Delete(int? Key,int SpartanUserRule,Core.Domain.User.GlobalData EmpleadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<bool>(baseApi, ApiControllerUrl + "/Delete?Id=" + Key + "&SpartanUserRule=" + SpartanUserRule,
                      Method.DELETE, ApiHeader);

                return new ApiResponse<bool>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<bool>(false, false);
            }

        }

        public ApiResponse<int> Insert(Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction entity, Core.Domain.User.GlobalData EmpleadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction entity, Core.Domain.User.GlobalData EmpleadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.User_Rule_Object_Function_Id,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<int>(false, -1);
            }
        }

        public ApiResponse<IList<Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunctionPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<Spartane.Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunctionPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunctionPagingModel>(true, products);


            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunctionPagingModel>(false, new Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunctionPagingModel() {  Spartan_User_Rule_Object_Functions = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}