using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartan_Traduction_Process_Data;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Process_Data
{
    public class Spartan_Traduction_Process_DataApiConsumer : BaseApiConsumer,ISpartan_Traduction_Process_DataApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Spartan_Traduction_Process_DataApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_Traduction_Process_Data";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>(false, null);
            }
        }

        public ApiResponse<Spartan_Traduction_Process_DataPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_DataPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Spartan_Traduction_Process_Data.Clave='" + Key.ToString() + "'"
                        + "&Order=Spartan_Traduction_Process_Data.Clave ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_DataPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_DataPagingModel>(false, new Spartan_Traduction_Process_DataPagingModel() { Spartan_Traduction_Process_Datas = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Spartan_Traduction_Process_DataInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data entity, Core.Domain.User.GlobalData Spartan_Traduction_Process_DataInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data entity, Core.Domain.User.GlobalData Spartan_Traduction_Process_DataInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.Clave,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Spartan_Traduction_Process_DataPagingModel> ListaSelAll(int object_id, int process)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_DataPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?object_id=" + object_id + "&process=" + process
                    ,Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_DataPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_DataPagingModel>(false, new Spartan_Traduction_Process_DataPagingModel() { Spartan_Traduction_Process_Datas = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

