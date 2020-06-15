using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Detalle_Convenio_Medicos_Aseguradoras
{
    public class Detalle_Convenio_Medicos_AseguradorasApiConsumer : BaseApiConsumer,IDetalle_Convenio_Medicos_AseguradorasApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Detalle_Convenio_Medicos_AseguradorasApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Detalle_Convenio_Medicos_Aseguradoras";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras>(false, null);
            }
        }

        public ApiResponse<Detalle_Convenio_Medicos_AseguradorasPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_AseguradorasPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Detalle_Convenio_Medicos_Aseguradoras.Folio='" + Key.ToString() + "'"
                        + "&Order=Detalle_Convenio_Medicos_Aseguradoras.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_AseguradorasPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_AseguradorasPagingModel>(false, new Detalle_Convenio_Medicos_AseguradorasPagingModel() { Detalle_Convenio_Medicos_Aseguradorass = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Detalle_Convenio_Medicos_AseguradorasInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras entity, Core.Domain.User.GlobalData Detalle_Convenio_Medicos_AseguradorasInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras entity, Core.Domain.User.GlobalData Detalle_Convenio_Medicos_AseguradorasInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Detalle_Convenio_Medicos_AseguradorasPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_AseguradorasPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_AseguradorasPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_AseguradorasPagingModel>(false, new Detalle_Convenio_Medicos_AseguradorasPagingModel() { Detalle_Convenio_Medicos_Aseguradorass = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Detalle_Convenio_Medicos_AseguradorasGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Detalle_Convenio_Medicos_Aseguradoras_Datos_Generales entity)
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

        public ApiResponse<Detalle_Convenio_Medicos_Aseguradoras_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_Convenio_Medicos_Aseguradoras.Detalle_Convenio_Medicos_Aseguradoras_Datos_Generales>(false, null);
            }
        }


    }
}

