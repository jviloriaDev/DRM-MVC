using RestSharp;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spartane.Web.Areas.WebApiConsumer.SpartanModule
{
    public class SpartanModuleApiConsumer : BaseApiConsumer, ISpartanModuleApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public SpartanModuleApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrl;
            ApiControllerUrl = "/api/spartan_module/";
        }

        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.SpartanModule.SpartanModule>> SelAll(bool ConRelaciones)
        {
            try
            {
                var modules = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.SpartanModule.SpartanModule>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.SpartanModule.SpartanModule>>(true, modules);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.SpartanModule.SpartanModule>>(false, null);
            }
        }

        public ResponseHelpers.ApiResponse<IList<Core.Domain.SpartanModule.SpartanModule>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.SpartanModule.SpartanModule>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.SpartanModule.SpartanModule>>(true, products);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.SpartanModule.SpartanModule>>(false, null);
            }
        }

        public ResponseHelpers.ApiResponse<Core.Domain.SpartanModule.SpartanModule> GetByKey(int? Key, bool ConRelaciones)
        {
            try
            {
                var products = RestApiHelper.InvokeApi<Spartane.Core.Domain.SpartanModule.SpartanModule>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.SpartanModule.SpartanModule>(true, products);
            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.SpartanModule.SpartanModule>(false, null);
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

        public ResponseHelpers.ApiResponse<int> Insert(Core.Domain.SpartanModule.SpartanModule entity, Core.Domain.User.GlobalData EmpleadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
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

        public ResponseHelpers.ApiResponse<int> Update(Core.Domain.SpartanModule.SpartanModule entity, Core.Domain.User.GlobalData EmpleadoInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.Module_Id,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<int>(false, -1);
            }
        }

        public ResponseHelpers.ApiResponse<IList<Core.Domain.SpartanModule.SpartanModule>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ResponseHelpers.ApiResponse<IList<Core.Domain.SpartanModule.SpartanModule>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.SpartanModule.SpartanModulePagingModel>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }


        public ResponseHelpers.ApiResponse<Core.Domain.SpartanModule.SpartanModulePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            var products = RestApiHelper.InvokeApi<Spartane.Core.Domain.SpartanModule.SpartanModulePagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

            return new ApiResponse<Core.Domain.SpartanModule.SpartanModulePagingModel>(true, products);
        }

        

        public ResponseHelpers.ApiResponse<IList<Core.Domain.SpartanModule.SpartanModule>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }


        ApiResponse<IList<Core.Domain.SpartanModule.SpartanModule>> ISpartanModuleApiConsumer.ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        ApiResponse<Core.Domain.SpartanModule.SpartanModule> ISpartanModuleApiConsumer.ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            throw new NotImplementedException();
        }
    }
}