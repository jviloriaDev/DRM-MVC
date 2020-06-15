using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartan_Bitacora_SQL;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_Bitacora_SQL
{
    public class Spartan_Bitacora_SQLApiConsumer : BaseApiConsumer,ISpartan_Bitacora_SQLApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Spartan_Bitacora_SQLApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_Bitacora_SQL";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL>(false, null);
            }
        }

        public ApiResponse<Spartan_Bitacora_SQLPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQLPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Spartan_Bitacora_SQL.Folio='" + Key.ToString() + "'"
                        + "&Order=Spartan_Bitacora_SQL.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQLPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQLPagingModel>(false, new Spartan_Bitacora_SQLPagingModel() { Spartan_Bitacora_SQLs = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Spartan_Bitacora_SQLInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL entity, Core.Domain.User.GlobalData Spartan_Bitacora_SQLInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL entity, Core.Domain.User.GlobalData Spartan_Bitacora_SQLInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.Folio,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Spartan_Bitacora_SQLPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQLPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQLPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQLPagingModel>(false, new Spartan_Bitacora_SQLPagingModel() { Spartan_Bitacora_SQLs = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

