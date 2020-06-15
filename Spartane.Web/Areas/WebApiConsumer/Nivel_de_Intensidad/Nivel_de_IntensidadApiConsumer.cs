using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Nivel_de_Intensidad;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Nivel_de_Intensidad
{
    public class Nivel_de_IntensidadApiConsumer : BaseApiConsumer,INivel_de_IntensidadApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Nivel_de_IntensidadApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Nivel_de_Intensidad";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad>(false, null);
            }
        }

        public ApiResponse<Nivel_de_IntensidadPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_IntensidadPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Nivel_de_Intensidad.Folio='" + Key.ToString() + "'"
                        + "&Order=Nivel_de_Intensidad.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Nivel_de_Intensidad.Nivel_de_IntensidadPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Nivel_de_Intensidad.Nivel_de_IntensidadPagingModel>(false, new Nivel_de_IntensidadPagingModel() { Nivel_de_Intensidads = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Nivel_de_IntensidadInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad entity, Core.Domain.User.GlobalData Nivel_de_IntensidadInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad entity, Core.Domain.User.GlobalData Nivel_de_IntensidadInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Nivel_de_IntensidadPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_IntensidadPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Nivel_de_Intensidad.Nivel_de_IntensidadPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Nivel_de_Intensidad.Nivel_de_IntensidadPagingModel>(false, new Nivel_de_IntensidadPagingModel() { Nivel_de_Intensidads = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Nivel_de_IntensidadGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Nivel_de_Intensidad_Datos_Generales entity)
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

        public ApiResponse<Nivel_de_Intensidad_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Nivel_de_Intensidad.Nivel_de_Intensidad_Datos_Generales>(false, null);
            }
        }


    }
}

