using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Cantidad_fraccion_platillos;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Cantidad_fraccion_platillos
{
    public class Cantidad_fraccion_platillosApiConsumer : BaseApiConsumer,ICantidad_fraccion_platillosApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Cantidad_fraccion_platillosApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Cantidad_fraccion_platillos";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>(false, null);
            }
        }

        public ApiResponse<Cantidad_fraccion_platillosPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillosPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Cantidad_fraccion_platillos.Folio='" + Key.ToString() + "'"
                        + "&Order=Cantidad_fraccion_platillos.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillosPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillosPagingModel>(false, new Cantidad_fraccion_platillosPagingModel() { Cantidad_fraccion_platilloss = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Cantidad_fraccion_platillosInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos entity, Core.Domain.User.GlobalData Cantidad_fraccion_platillosInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos entity, Core.Domain.User.GlobalData Cantidad_fraccion_platillosInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Cantidad_fraccion_platillosPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillosPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillosPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillosPagingModel>(false, new Cantidad_fraccion_platillosPagingModel() { Cantidad_fraccion_platilloss = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Cantidad_fraccion_platillosGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Cantidad_fraccion_platillos_Datos_Generales entity)
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

        public ApiResponse<Cantidad_fraccion_platillos_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Cantidad_fraccion_platillos.Cantidad_fraccion_platillos_Datos_Generales>(false, null);
            }
        }


    }
}

