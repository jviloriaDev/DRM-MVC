using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Interpretacion_indice_cintura__cadera;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Interpretacion_indice_cintura__cadera
{
    public class Interpretacion_indice_cintura__caderaApiConsumer : BaseApiConsumer,IInterpretacion_indice_cintura__caderaApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Interpretacion_indice_cintura__caderaApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Interpretacion_indice_cintura__cadera";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera>(false, null);
            }
        }

        public ApiResponse<Interpretacion_indice_cintura__caderaPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__caderaPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Interpretacion_indice_cintura__cadera.Folio='" + Key.ToString() + "'"
                        + "&Order=Interpretacion_indice_cintura__cadera.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__caderaPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__caderaPagingModel>(false, new Interpretacion_indice_cintura__caderaPagingModel() { Interpretacion_indice_cintura__caderas = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Interpretacion_indice_cintura__caderaInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera entity, Core.Domain.User.GlobalData Interpretacion_indice_cintura__caderaInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera entity, Core.Domain.User.GlobalData Interpretacion_indice_cintura__caderaInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Interpretacion_indice_cintura__caderaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__caderaPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__caderaPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__caderaPagingModel>(false, new Interpretacion_indice_cintura__caderaPagingModel() { Interpretacion_indice_cintura__caderas = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Interpretacion_indice_cintura__caderaGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Interpretacion_indice_cintura__cadera_Datos_Generales entity)
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

        public ApiResponse<Interpretacion_indice_cintura__cadera_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Interpretacion_indice_cintura__cadera.Interpretacion_indice_cintura__cadera_Datos_Generales>(false, null);
            }
        }


    }
}

