using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Rango_Consumo_Bebidas;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Rango_Consumo_Bebidas
{
    public class Rango_Consumo_BebidasApiConsumer : BaseApiConsumer,IRango_Consumo_BebidasApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Rango_Consumo_BebidasApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Rango_Consumo_Bebidas";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas>(false, null);
            }
        }

        public ApiResponse<Rango_Consumo_BebidasPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_BebidasPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Rango_Consumo_Bebidas.Clave='" + Key.ToString() + "'"
                        + "&Order=Rango_Consumo_Bebidas.Clave ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_BebidasPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_BebidasPagingModel>(false, new Rango_Consumo_BebidasPagingModel() { Rango_Consumo_Bebidass = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Rango_Consumo_BebidasInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas entity, Core.Domain.User.GlobalData Rango_Consumo_BebidasInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas entity, Core.Domain.User.GlobalData Rango_Consumo_BebidasInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Rango_Consumo_BebidasPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_BebidasPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_BebidasPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_BebidasPagingModel>(false, new Rango_Consumo_BebidasPagingModel() { Rango_Consumo_Bebidass = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Rango_Consumo_BebidasGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Rango_Consumo_Bebidas_Datos_Generales entity)
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

        public ApiResponse<Rango_Consumo_Bebidas_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Rango_Consumo_Bebidas.Rango_Consumo_Bebidas_Datos_Generales>(false, null);
            }
        }


    }
}

