﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion_Proveedores
{
    public class Planes_de_Suscripcion_ProveedoresApiConsumer : BaseApiConsumer,IPlanes_de_Suscripcion_ProveedoresApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Planes_de_Suscripcion_ProveedoresApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Planes_de_Suscripcion_Proveedores";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores>(false, null);
            }
        }

        public ApiResponse<Planes_de_Suscripcion_ProveedoresPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_ProveedoresPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Planes_de_Suscripcion_Proveedores.Clave='" + Key.ToString() + "'"
                        + "&Order=Planes_de_Suscripcion_Proveedores.Clave ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_ProveedoresPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_ProveedoresPagingModel>(false, new Planes_de_Suscripcion_ProveedoresPagingModel() { Planes_de_Suscripcion_Proveedoress = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Planes_de_Suscripcion_ProveedoresInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores entity, Core.Domain.User.GlobalData Planes_de_Suscripcion_ProveedoresInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores entity, Core.Domain.User.GlobalData Planes_de_Suscripcion_ProveedoresInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Planes_de_Suscripcion_ProveedoresPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_ProveedoresPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_ProveedoresPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_ProveedoresPagingModel>(false, new Planes_de_Suscripcion_ProveedoresPagingModel() { Planes_de_Suscripcion_Proveedoress = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Planes_de_Suscripcion_ProveedoresGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Planes_de_Suscripcion_Proveedores_Datos_Generales entity)
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

        public ApiResponse<Planes_de_Suscripcion_Proveedores_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Planes_de_Suscripcion_Proveedores.Planes_de_Suscripcion_Proveedores_Datos_Generales>(false, null);
            }
        }


    }
}

