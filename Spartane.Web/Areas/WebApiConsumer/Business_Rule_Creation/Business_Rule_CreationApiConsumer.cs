using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Business_Rule_Creation;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Business_Rule_Creation
{
    public class Business_Rule_CreationApiConsumer : BaseApiConsumer,IBusiness_Rule_CreationApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Business_Rule_CreationApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Business_Rule_Creation";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Business_Rule_Creation.Business_Rule_Creation>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Business_Rule_Creation.Business_Rule_Creation>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Business_Rule_Creation.Business_Rule_Creation>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Business_Rule_Creation.Business_Rule_Creation>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Business_Rule_Creation.Business_Rule_Creation>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Business_Rule_Creation.Business_Rule_Creation>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Business_Rule_Creation.Business_Rule_Creation> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_Creation>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Business_Rule_Creation.Business_Rule_Creation>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Business_Rule_Creation.Business_Rule_Creation>(false, null);
            }
        }

        public ApiResponse<Business_Rule_CreationPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_CreationPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Business_Rule_Creation.Key_Business_Rule_Creation='" + Key.ToString() + "'"
                        + "&Order=Business_Rule_Creation.Key_Business_Rule_Creation ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Business_Rule_Creation.Business_Rule_CreationPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Business_Rule_Creation.Business_Rule_CreationPagingModel>(false, new Business_Rule_CreationPagingModel() { Business_Rule_Creations = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Business_Rule_CreationInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<bool>(baseApi, ApiControllerUrl + "/Delete?Id=" + Key,
                      Method.DELETE, ApiHeader);

                return new ApiResponse<bool>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>(false, false);
            }
        }

        public ApiResponse<int> Insert(Core.Domain.Business_Rule_Creation.Business_Rule_Creation entity, Core.Domain.User.GlobalData Business_Rule_CreationInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Post",
                      Method.POST, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<int> Update(Core.Domain.Business_Rule_Creation.Business_Rule_Creation entity, Core.Domain.User.GlobalData Business_Rule_CreationInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.Key_Business_Rule_Creation,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Business_Rule_Creation.Business_Rule_Creation>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Business_Rule_Creation.Business_Rule_Creation>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Business_Rule_Creation.Business_Rule_Creation>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Business_Rule_CreationPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Business_Rule_Creation.Business_Rule_CreationPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Business_Rule_Creation.Business_Rule_CreationPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Business_Rule_Creation.Business_Rule_CreationPagingModel>(false, new Business_Rule_CreationPagingModel() { Business_Rule_Creations = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Business_Rule_Creation.Business_Rule_Creation>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

