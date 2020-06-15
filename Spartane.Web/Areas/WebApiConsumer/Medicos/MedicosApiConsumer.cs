using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Medicos;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Medicos
{
    public class MedicosApiConsumer : BaseApiConsumer,IMedicosApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public MedicosApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Medicos";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Medicos.Medicos>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Medicos.Medicos>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Medicos.Medicos>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Medicos.Medicos>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Medicos.Medicos>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Medicos.Medicos>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Medicos.Medicos>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Medicos.Medicos>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Medicos.Medicos> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Medicos.Medicos>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Medicos.Medicos>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Medicos.Medicos>(false, null);
            }
        }

        public ApiResponse<MedicosPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Medicos.MedicosPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Medicos.Folio='" + Key.ToString() + "'"
                        + "&Order=Medicos.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Medicos.MedicosPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Medicos.MedicosPagingModel>(false, new MedicosPagingModel() { Medicoss = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData MedicosInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Medicos.Medicos entity, Core.Domain.User.GlobalData MedicosInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Medicos.Medicos entity, Core.Domain.User.GlobalData MedicosInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Medicos.Medicos>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Medicos.Medicos>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Medicos.Medicos>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<MedicosPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Medicos.MedicosPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Medicos.MedicosPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Medicos.MedicosPagingModel>(false, new MedicosPagingModel() { Medicoss = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Medicos.Medicos>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/MedicosGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Medicos_Datos_Generales entity)
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

        public ApiResponse<Medicos_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Medicos.Medicos_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Medicos.Medicos_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Medicos.Medicos_Datos_Generales>(false, null);
            }
        }

public ApiResponse<int> Update_Datos_de_Contacto(Medicos_Datos_de_Contacto entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Datos_de_Contacto",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Medicos_Datos_de_Contacto> Get_Datos_de_Contacto(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Medicos.Medicos_Datos_de_Contacto>(baseApi, ApiControllerUrl + "/Get_Datos_de_Contacto?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Medicos.Medicos_Datos_de_Contacto>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Medicos.Medicos_Datos_de_Contacto>(false, null);
            }
        }

public ApiResponse<int> Update_Datos_Profesionales(Medicos_Datos_Profesionales entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Datos_Profesionales",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Medicos_Datos_Profesionales> Get_Datos_Profesionales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Medicos.Medicos_Datos_Profesionales>(baseApi, ApiControllerUrl + "/Get_Datos_Profesionales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Medicos.Medicos_Datos_Profesionales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Medicos.Medicos_Datos_Profesionales>(false, null);
            }
        }

public ApiResponse<int> Update_Datos_Fiscales(Medicos_Datos_Fiscales entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Datos_Fiscales",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Medicos_Datos_Fiscales> Get_Datos_Fiscales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Medicos.Medicos_Datos_Fiscales>(baseApi, ApiControllerUrl + "/Get_Datos_Fiscales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Medicos.Medicos_Datos_Fiscales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Medicos.Medicos_Datos_Fiscales>(false, null);
            }
        }

public ApiResponse<int> Update_Documentacion(Medicos_Documentacion entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Documentacion",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Medicos_Documentacion> Get_Documentacion(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Medicos.Medicos_Documentacion>(baseApi, ApiControllerUrl + "/Get_Documentacion?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Medicos.Medicos_Documentacion>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Medicos.Medicos_Documentacion>(false, null);
            }
        }

public ApiResponse<int> Update_Codigos_de_Referencia(Medicos_Codigos_de_Referencia entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Codigos_de_Referencia",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Medicos_Codigos_de_Referencia> Get_Codigos_de_Referencia(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Medicos.Medicos_Codigos_de_Referencia>(baseApi, ApiControllerUrl + "/Get_Codigos_de_Referencia?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Medicos.Medicos_Codigos_de_Referencia>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Medicos.Medicos_Codigos_de_Referencia>(false, null);
            }
        }

public ApiResponse<int> Update_Suscripcion_Red_de_Especialistas(Medicos_Suscripcion_Red_de_Especialistas entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Suscripcion_Red_de_Especialistas",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Medicos_Suscripcion_Red_de_Especialistas> Get_Suscripcion_Red_de_Especialistas(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Medicos.Medicos_Suscripcion_Red_de_Especialistas>(baseApi, ApiControllerUrl + "/Get_Suscripcion_Red_de_Especialistas?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Medicos.Medicos_Suscripcion_Red_de_Especialistas>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Medicos.Medicos_Suscripcion_Red_de_Especialistas>(false, null);
            }
        }

public ApiResponse<int> Update_Datos_Bancarios(Medicos_Datos_Bancarios entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Datos_Bancarios",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Medicos_Datos_Bancarios> Get_Datos_Bancarios(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Medicos.Medicos_Datos_Bancarios>(baseApi, ApiControllerUrl + "/Get_Datos_Bancarios?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Medicos.Medicos_Datos_Bancarios>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Medicos.Medicos_Datos_Bancarios>(false, null);
            }
        }

public ApiResponse<int> Update_Facturacion(Medicos_Facturacion entity)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put_Facturacion",
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<Medicos_Facturacion> Get_Facturacion(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Medicos.Medicos_Facturacion>(baseApi, ApiControllerUrl + "/Get_Facturacion?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Medicos.Medicos_Facturacion>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Medicos.Medicos_Facturacion>(false, null);
            }
        }


    }
}

