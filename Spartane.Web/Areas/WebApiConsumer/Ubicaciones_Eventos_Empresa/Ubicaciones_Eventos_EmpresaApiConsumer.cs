using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Ubicaciones_Eventos_Empresa;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Ubicaciones_Eventos_Empresa
{
    public class Ubicaciones_Eventos_EmpresaApiConsumer : BaseApiConsumer,IUbicaciones_Eventos_EmpresaApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Ubicaciones_Eventos_EmpresaApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Ubicaciones_Eventos_Empresa";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa>(false, null);
            }
        }

        public ApiResponse<Ubicaciones_Eventos_EmpresaPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_EmpresaPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Ubicaciones_Eventos_Empresa.Folio='" + Key.ToString() + "'"
                        + "&Order=Ubicaciones_Eventos_Empresa.Folio ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_EmpresaPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_EmpresaPagingModel>(false, new Ubicaciones_Eventos_EmpresaPagingModel() { Ubicaciones_Eventos_Empresas = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Ubicaciones_Eventos_EmpresaInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa entity, Core.Domain.User.GlobalData Ubicaciones_Eventos_EmpresaInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa entity, Core.Domain.User.GlobalData Ubicaciones_Eventos_EmpresaInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Ubicaciones_Eventos_EmpresaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_EmpresaPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_EmpresaPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_EmpresaPagingModel>(false, new Ubicaciones_Eventos_EmpresaPagingModel() { Ubicaciones_Eventos_Empresas = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
		
		public ApiResponse<int> GenerateID()
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Ubicaciones_Eventos_EmpresaGenerateID",
                      Method.GET, ApiHeader);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }
		
public ApiResponse<int> Update_Datos_Generales(Ubicaciones_Eventos_Empresa_Datos_Generales entity)
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

        public ApiResponse<Ubicaciones_Eventos_Empresa_Datos_Generales> Get_Datos_Generales(string Key)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa_Datos_Generales>(baseApi, ApiControllerUrl + "/Get_Datos_Generales?id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa_Datos_Generales>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Ubicaciones_Eventos_Empresa.Ubicaciones_Eventos_Empresa_Datos_Generales>(false, null);
            }
        }


    }
}

