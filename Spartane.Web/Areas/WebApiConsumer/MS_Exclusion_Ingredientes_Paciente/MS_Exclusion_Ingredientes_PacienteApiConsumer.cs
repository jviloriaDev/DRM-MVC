using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.MS_Exclusion_Ingredientes_Paciente
{
    public class MS_Exclusion_Ingredientes_PacienteApiConsumer : BaseApiConsumer,IMS_Exclusion_Ingredientes_PacienteApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public MS_Exclusion_Ingredientes_PacienteApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/MS_Exclusion_Ingredientes_Paciente";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente>(false, null);
            }
        }

        public ApiResponse<MS_Exclusion_Ingredientes_PacientePagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_PacientePagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=MS_Exclusion_Ingredientes_Paciente.Folio='" + Key.ToString() + "'"
                        + "&Order=MS_Exclusion_Ingredientes_Paciente.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_PacientePagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_PacientePagingModel>(false, new MS_Exclusion_Ingredientes_PacientePagingModel() { MS_Exclusion_Ingredientes_Pacientes = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData MS_Exclusion_Ingredientes_PacienteInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente entity, Core.Domain.User.GlobalData MS_Exclusion_Ingredientes_PacienteInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente entity, Core.Domain.User.GlobalData MS_Exclusion_Ingredientes_PacienteInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<MS_Exclusion_Ingredientes_PacientePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_PacientePagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_PacientePagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_PacientePagingModel>(false, new MS_Exclusion_Ingredientes_PacientePagingModel() { MS_Exclusion_Ingredientes_Pacientes = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/MS_Exclusion_Ingredientes_PacienteGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(MS_Exclusion_Ingredientes_Paciente_Datos_Generales entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Datos_Generales",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<MS_Exclusion_Ingredientes_Paciente_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.MS_Exclusion_Ingredientes_Paciente.MS_Exclusion_Ingredientes_Paciente_Datos_Generales>(false, null);
            }
        }


    }
}

