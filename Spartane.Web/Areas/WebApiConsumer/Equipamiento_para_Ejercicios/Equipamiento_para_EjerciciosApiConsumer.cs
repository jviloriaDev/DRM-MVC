using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Equipamiento_para_Ejercicios;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Equipamiento_para_Ejercicios
{
    public class Equipamiento_para_EjerciciosApiConsumer : BaseApiConsumer,IEquipamiento_para_EjerciciosApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Equipamiento_para_EjerciciosApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Equipamiento_para_Ejercicios";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>(false, null);
            }
        }

        public ApiResponse<Equipamiento_para_EjerciciosPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_EjerciciosPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Equipamiento_para_Ejercicios.Folio='" + Key.ToString() + "'"
                        + "&Order=Equipamiento_para_Ejercicios.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_EjerciciosPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_EjerciciosPagingModel>(false, new Equipamiento_para_EjerciciosPagingModel() { Equipamiento_para_Ejercicioss = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Equipamiento_para_EjerciciosInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios entity, Core.Domain.User.GlobalData Equipamiento_para_EjerciciosInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios entity, Core.Domain.User.GlobalData Equipamiento_para_EjerciciosInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Equipamiento_para_EjerciciosPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_EjerciciosPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_EjerciciosPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_EjerciciosPagingModel>(false, new Equipamiento_para_EjerciciosPagingModel() { Equipamiento_para_Ejercicioss = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Equipamiento_para_EjerciciosGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Equipamiento_para_Ejercicios_Datos_Generales entity)
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

        public ApiResponse<Equipamiento_para_Ejercicios_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Equipamiento_para_Ejercicios.Equipamiento_para_Ejercicios_Datos_Generales>(false, null);
            }
        }


    }
}

