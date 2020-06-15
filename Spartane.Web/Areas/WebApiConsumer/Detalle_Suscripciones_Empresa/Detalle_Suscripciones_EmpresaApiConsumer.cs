using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Detalle_Suscripciones_Empresa;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Detalle_Suscripciones_Empresa
{
    public class Detalle_Suscripciones_EmpresaApiConsumer : BaseApiConsumer,IDetalle_Suscripciones_EmpresaApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Detalle_Suscripciones_EmpresaApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Detalle_Suscripciones_Empresa";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>(false, null);
            }
        }

        public ApiResponse<Detalle_Suscripciones_EmpresaPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_EmpresaPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Detalle_Suscripciones_Empresa.Folio='" + Key.ToString() + "'"
                        + "&Order=Detalle_Suscripciones_Empresa.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_EmpresaPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_EmpresaPagingModel>(false, new Detalle_Suscripciones_EmpresaPagingModel() { Detalle_Suscripciones_Empresas = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Detalle_Suscripciones_EmpresaInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa entity, Core.Domain.User.GlobalData Detalle_Suscripciones_EmpresaInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa entity, Core.Domain.User.GlobalData Detalle_Suscripciones_EmpresaInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Detalle_Suscripciones_EmpresaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_EmpresaPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_EmpresaPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_EmpresaPagingModel>(false, new Detalle_Suscripciones_EmpresaPagingModel() { Detalle_Suscripciones_Empresas = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Detalle_Suscripciones_EmpresaGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Detalle_Suscripciones_Empresa_Datos_Generales entity)
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

        public ApiResponse<Detalle_Suscripciones_Empresa_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Detalle_Suscripciones_Empresa.Detalle_Suscripciones_Empresa_Datos_Generales>(false, null);
            }
        }


    }
}

