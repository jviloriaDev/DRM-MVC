using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.SpartanChangePasswordAutorizationEstatus
{
    public class SpartanChangePasswordAutorizationEstatusApiConsumer : BaseApiConsumer,ISpartanChangePasswordAutorizationEstatusApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public SpartanChangePasswordAutorizationEstatusApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/SpartanChangePasswordAutorizationEstatus";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>(false, null);
            }
        }

        public ApiResponse<SpartanChangePasswordAutorizationEstatusPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatusPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=SpartanChangePasswordAutorizationEstatus.Clave='" + Key.ToString() + "'"
                        + "&Order=SpartanChangePasswordAutorizationEstatus.Clave ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatusPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatusPagingModel>(false, new SpartanChangePasswordAutorizationEstatusPagingModel() { SpartanChangePasswordAutorizationEstatuss = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData SpartanChangePasswordAutorizationEstatusInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus entity, Core.Domain.User.GlobalData SpartanChangePasswordAutorizationEstatusInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus entity, Core.Domain.User.GlobalData SpartanChangePasswordAutorizationEstatusInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<IList<Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<SpartanChangePasswordAutorizationEstatusPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatusPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatusPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatusPagingModel>(false, new SpartanChangePasswordAutorizationEstatusPagingModel() { SpartanChangePasswordAutorizationEstatuss = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.SpartanChangePasswordAutorizationEstatus.SpartanChangePasswordAutorizationEstatus>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

