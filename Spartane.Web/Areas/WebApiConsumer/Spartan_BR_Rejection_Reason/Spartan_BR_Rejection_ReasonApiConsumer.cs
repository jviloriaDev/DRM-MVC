using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartan_BR_Rejection_Reason;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Rejection_Reason
{
    public class Spartan_BR_Rejection_ReasonApiConsumer : BaseApiConsumer,ISpartan_BR_Rejection_ReasonApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Spartan_BR_Rejection_ReasonApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_BR_Rejection_Reason";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason>(false, null);
            }
        }

        public ApiResponse<Spartan_BR_Rejection_ReasonPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_ReasonPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Spartan_BR_Rejection_Reason.Key_Rejection_Reason='" + Key.ToString() + "'"
                        + "&Order=Spartan_BR_Rejection_Reason.Key_Rejection_Reason ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_ReasonPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_ReasonPagingModel>(false, new Spartan_BR_Rejection_ReasonPagingModel() { Spartan_BR_Rejection_Reasons = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Spartan_BR_Rejection_ReasonInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason entity, Core.Domain.User.GlobalData Spartan_BR_Rejection_ReasonInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason entity, Core.Domain.User.GlobalData Spartan_BR_Rejection_ReasonInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.Key_Rejection_Reason,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Spartan_BR_Rejection_ReasonPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_ReasonPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_ReasonPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_ReasonPagingModel>(false, new Spartan_BR_Rejection_ReasonPagingModel() { Spartan_BR_Rejection_Reasons = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

