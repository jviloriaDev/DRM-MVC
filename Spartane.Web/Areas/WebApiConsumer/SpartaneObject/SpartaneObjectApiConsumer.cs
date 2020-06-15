using RestSharp;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spartane.Web.Areas.WebApiConsumer.SpartaneObject
{
    public class SpartaneObjectApiConsumer : BaseApiConsumer, ISpartaneObjectApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public SpartaneObjectApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrl;
            ApiControllerUrl = "/api/spartan_object/";
        }

        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.SpartaneObject.SpartaneObject>> SelAll(bool ConRelaciones)
        {
            try
            {
                var modules = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.SpartaneObject.SpartaneObject>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.SpartaneObject.SpartaneObject>>(true, modules);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.SpartaneObject.SpartaneObject>>(false, null);
            }
        }

        public ResponseHelpers.ApiResponse<IList<Core.Domain.SpartaneObject.SpartaneObject>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.SpartaneObject.SpartaneObject>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.SpartaneObject.SpartaneObject>>(true, products);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.SpartaneObject.SpartaneObject>>(false, null);
            }
        }

        public ResponseHelpers.ApiResponse<Core.Domain.SpartaneObject.SpartaneObject> GetByKey(int? Key, bool ConRelaciones)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<Spartane.Core.Domain.SpartaneObject.SpartaneObject>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.SpartaneObject.SpartaneObject>(true, products);
            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.SpartaneObject.SpartaneObject>(false, null);
            }
        }

        public ResponseHelpers.ApiResponse<bool> Delete(int? Key, Core.Domain.User.GlobalData EmpleadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
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

        public ResponseHelpers.ApiResponse<int> Insert(Core.Domain.SpartaneObject.SpartaneObject entity, Core.Domain.User.GlobalData EmpleadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
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

        public ResponseHelpers.ApiResponse<int> Update(Core.Domain.SpartaneObject.SpartaneObject entity, Core.Domain.User.GlobalData EmpleadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.Object_Id,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<int>(false, -1);
            }
        }

        public ResponseHelpers.ApiResponse<IList<Core.Domain.SpartaneObject.SpartaneObject>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ResponseHelpers.ApiResponse<IList<Core.Domain.SpartaneObject.SpartaneObject>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.SpartaneObject.SpartaneObject>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }


        public ResponseHelpers.ApiResponse<Core.Domain.SpartaneObject.SpartaneObjectPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            var products = RestApiHelper.InvokeApi<Spartane.Core.Domain.SpartaneObject.SpartaneObjectPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

            return new ApiResponse<Core.Domain.SpartaneObject.SpartaneObjectPagingModel>(true, products);
        }

        

        public ResponseHelpers.ApiResponse<IList<Core.Domain.SpartaneObject.SpartaneObject>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }


      
    }
}