using RestSharp;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spartane.Web.Areas.WebApiConsumer.SpartaneFunction
{
    public class SpartaneFunctionApiConsumer : BaseApiConsumer, ISpartaneFunctionApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public SpartaneFunctionApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrl;
            ApiControllerUrl = "/api/spartan_function/";
        }

        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.SpartaneFunction.SpartaneFunction>> SelAll(bool ConRelaciones)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.SpartaneFunction.SpartaneFunction>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.SpartaneFunction.SpartaneFunction>>(true, products);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.SpartaneFunction.SpartaneFunction>>(false, null);
            }
        }

        public ApiResponse<IList<Core.Domain.SpartaneFunction.SpartaneFunction>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.SpartaneFunction.SpartaneFunction>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.SpartaneFunction.SpartaneFunction>>(true, products);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.SpartaneFunction.SpartaneFunction>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.SpartaneFunction.SpartaneFunction> GetByKey(int? Key, bool ConRelaciones)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<Spartane.Core.Domain.SpartaneFunction.SpartaneFunction>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.SpartaneFunction.SpartaneFunction>(true, products);
            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.SpartaneFunction.SpartaneFunction>(false, null);
            }
        }

        public ApiResponse<bool> Delete(int? Key, Core.Domain.User.GlobalData EmpleadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<bool>(baseApi, ApiControllerUrl + "/Delete?Id=" + Key,
                      Method.DELETE, ApiHeader);

                return new ApiResponse<bool>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<bool>(false, false);
            }

        }

        public ApiResponse<int> Insert(Core.Domain.SpartaneFunction.SpartaneFunction entity, Core.Domain.User.GlobalData EmpleadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.SpartaneFunction.SpartaneFunction entity, Core.Domain.User.GlobalData EmpleadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.Function_Id,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<int>(false, -1);
            }
        }

        public ApiResponse<IList<Core.Domain.SpartaneFunction.SpartaneFunction>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.SpartaneFunction.SpartaneFunction>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.SpartaneFunction.SpartaneFunctionPagingModel>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Core.Domain.SpartaneFunction.SpartaneFunctionPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<Spartane.Core.Domain.SpartaneFunction.SpartaneFunctionPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.SpartaneFunction.SpartaneFunctionPagingModel>(true, products);


            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.SpartaneFunction.SpartaneFunctionPagingModel>(false, new Core.Domain.SpartaneFunction.SpartaneFunctionPagingModel() { Spartane_Functions = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.SpartaneFunction.SpartaneFunction>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}