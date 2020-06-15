using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Pacientes;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Pacientes
{
    public class PacientesApiConsumer : BaseApiConsumer,IPacientesApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public PacientesApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Pacientes";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Pacientes.Pacientes>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Pacientes.Pacientes>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Pacientes.Pacientes>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Pacientes.Pacientes>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Pacientes.Pacientes>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Pacientes.Pacientes>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Pacientes.Pacientes>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Pacientes.Pacientes>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Pacientes.Pacientes> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Pacientes.Pacientes>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Pacientes.Pacientes>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Pacientes.Pacientes>(false, null);
            }
        }

        public ApiResponse<PacientesPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Pacientes.PacientesPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Pacientes.Folio='" + Key.ToString() + "'"
                        + "&Order=Pacientes.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Pacientes.PacientesPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Pacientes.PacientesPagingModel>(false, new PacientesPagingModel() { Pacientess = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData PacientesInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Pacientes.Pacientes entity, Core.Domain.User.GlobalData PacientesInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Pacientes.Pacientes entity, Core.Domain.User.GlobalData PacientesInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Pacientes.Pacientes>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Pacientes.Pacientes>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Pacientes.Pacientes>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<PacientesPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Pacientes.PacientesPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Pacientes.PacientesPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Pacientes.PacientesPagingModel>(false, new PacientesPagingModel() { Pacientess = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Pacientes.Pacientes>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/PacientesGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Pacientes_Datos_Generales entity)
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

        public ApiResponse<Pacientes_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Pacientes.Pacientes_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Pacientes.Pacientes_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Pacientes.Pacientes_Datos_Generales>(false, null);
            }
        }

public ApiResponse<int> Update_Padecimientos(Pacientes_Padecimientos entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Padecimientos",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Pacientes_Padecimientos> Get_Padecimientos(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Pacientes.Pacientes_Padecimientos>(baseApi, ApiControllerUrl + "/Get_Padecimientos?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Pacientes.Pacientes_Padecimientos>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Pacientes.Pacientes_Padecimientos>(false, null);
            }
        }

public ApiResponse<int> Update_Antecedentes(Pacientes_Antecedentes entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Antecedentes",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Pacientes_Antecedentes> Get_Antecedentes(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Pacientes.Pacientes_Antecedentes>(baseApi, ApiControllerUrl + "/Get_Antecedentes?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Pacientes.Pacientes_Antecedentes>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Pacientes.Pacientes_Antecedentes>(false, null);
            }
        }

public ApiResponse<int> Update_Mediciones_Iniciales(Pacientes_Mediciones_Iniciales entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Mediciones_Iniciales",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Pacientes_Mediciones_Iniciales> Get_Mediciones_Iniciales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Pacientes.Pacientes_Mediciones_Iniciales>(baseApi, ApiControllerUrl + "/Get_Mediciones_Iniciales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Pacientes.Pacientes_Mediciones_Iniciales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Pacientes.Pacientes_Mediciones_Iniciales>(false, null);
            }
        }

public ApiResponse<int> Update_Datos_Ginecologicos(Pacientes_Datos_Ginecologicos entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Datos_Ginecologicos",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Pacientes_Datos_Ginecologicos> Get_Datos_Ginecologicos(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Pacientes.Pacientes_Datos_Ginecologicos>(baseApi, ApiControllerUrl + "/Get_Datos_Ginecologicos?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Pacientes.Pacientes_Datos_Ginecologicos>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Pacientes.Pacientes_Datos_Ginecologicos>(false, null);
            }
        }

public ApiResponse<int> Update_Historia_Nutricional(Pacientes_Historia_Nutricional entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Historia_Nutricional",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Pacientes_Historia_Nutricional> Get_Historia_Nutricional(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Pacientes.Pacientes_Historia_Nutricional>(baseApi, ApiControllerUrl + "/Get_Historia_Nutricional?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Pacientes.Pacientes_Historia_Nutricional>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Pacientes.Pacientes_Historia_Nutricional>(false, null);
            }
        }

public ApiResponse<int> Update_Estilo_de_Vida(Pacientes_Estilo_de_Vida entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Estilo_de_Vida",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Pacientes_Estilo_de_Vida> Get_Estilo_de_Vida(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Pacientes.Pacientes_Estilo_de_Vida>(baseApi, ApiControllerUrl + "/Get_Estilo_de_Vida?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Pacientes.Pacientes_Estilo_de_Vida>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Pacientes.Pacientes_Estilo_de_Vida>(false, null);
            }
        }

public ApiResponse<int> Update_Resultados(Pacientes_Resultados entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Resultados",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Pacientes_Resultados> Get_Resultados(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Pacientes.Pacientes_Resultados>(baseApi, ApiControllerUrl + "/Get_Resultados?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Pacientes.Pacientes_Resultados>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Pacientes.Pacientes_Resultados>(false, null);
            }
        }

public ApiResponse<int> Update_Suscripcion(Pacientes_Suscripcion entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Suscripcion",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Pacientes_Suscripcion> Get_Suscripcion(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Pacientes.Pacientes_Suscripcion>(baseApi, ApiControllerUrl + "/Get_Suscripcion?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Pacientes.Pacientes_Suscripcion>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Pacientes.Pacientes_Suscripcion>(false, null);
            }
        }


    }
}

