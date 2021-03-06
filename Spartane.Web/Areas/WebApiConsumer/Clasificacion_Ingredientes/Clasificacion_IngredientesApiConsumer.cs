﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Clasificacion_Ingredientes;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Clasificacion_Ingredientes
{
    public class Clasificacion_IngredientesApiConsumer : BaseApiConsumer,IClasificacion_IngredientesApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Clasificacion_IngredientesApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Clasificacion_Ingredientes";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes>(false, null);
            }
        }

        public ApiResponse<Clasificacion_IngredientesPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_IngredientesPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Clasificacion_Ingredientes.Clave='" + Key.ToString() + "'"
                        + "&Order=Clasificacion_Ingredientes.Clave ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Clasificacion_Ingredientes.Clasificacion_IngredientesPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Clasificacion_Ingredientes.Clasificacion_IngredientesPagingModel>(false, new Clasificacion_IngredientesPagingModel() { Clasificacion_Ingredientess = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Clasificacion_IngredientesInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes entity, Core.Domain.User.GlobalData Clasificacion_IngredientesInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes entity, Core.Domain.User.GlobalData Clasificacion_IngredientesInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Clasificacion_IngredientesPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_IngredientesPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Clasificacion_Ingredientes.Clasificacion_IngredientesPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Clasificacion_Ingredientes.Clasificacion_IngredientesPagingModel>(false, new Clasificacion_IngredientesPagingModel() { Clasificacion_Ingredientess = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Clasificacion_IngredientesGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Clasificacion_Ingredientes_Datos_Generales entity)
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

        public ApiResponse<Clasificacion_Ingredientes_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Clasificacion_Ingredientes.Clasificacion_Ingredientes_Datos_Generales>(false, null);
            }
        }


    }
}

