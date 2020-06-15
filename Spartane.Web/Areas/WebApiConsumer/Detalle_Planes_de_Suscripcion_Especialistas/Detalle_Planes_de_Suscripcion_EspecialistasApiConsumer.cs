using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Detalle_Planes_de_Suscripcion_Especialistas
{
    public class Detalle_Planes_de_Suscripcion_EspecialistasApiConsumer : BaseApiConsumer,IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Detalle_Planes_de_Suscripcion_EspecialistasApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Detalle_Planes_de_Suscripcion_Especialistas";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas>(false, null);
            }
        }

        public ApiResponse<Detalle_Planes_de_Suscripcion_EspecialistasPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_EspecialistasPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Detalle_Planes_de_Suscripcion_Especialistas.Folio='" + Key.ToString() + "'"
                        + "&Order=Detalle_Planes_de_Suscripcion_Especialistas.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_EspecialistasPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_EspecialistasPagingModel>(false, new Detalle_Planes_de_Suscripcion_EspecialistasPagingModel() { Detalle_Planes_de_Suscripcion_Especialistass = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Detalle_Planes_de_Suscripcion_EspecialistasInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas entity, Core.Domain.User.GlobalData Detalle_Planes_de_Suscripcion_EspecialistasInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas entity, Core.Domain.User.GlobalData Detalle_Planes_de_Suscripcion_EspecialistasInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Detalle_Planes_de_Suscripcion_EspecialistasPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_EspecialistasPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_EspecialistasPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_EspecialistasPagingModel>(false, new Detalle_Planes_de_Suscripcion_EspecialistasPagingModel() { Detalle_Planes_de_Suscripcion_Especialistass = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Detalle_Planes_de_Suscripcion_EspecialistasGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Detalle_Planes_de_Suscripcion_Especialistas_Datos_Generales entity)
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

        public ApiResponse<Detalle_Planes_de_Suscripcion_Especialistas_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas.Detalle_Planes_de_Suscripcion_Especialistas_Datos_Generales>(false, null);
            }
        }


    }
}

