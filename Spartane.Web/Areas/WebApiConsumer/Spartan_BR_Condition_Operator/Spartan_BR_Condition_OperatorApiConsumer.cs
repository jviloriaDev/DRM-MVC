using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartan_BR_Condition_Operator;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Condition_Operator
{
    public class Spartan_BR_Condition_OperatorApiConsumer : BaseApiConsumer,ISpartan_BR_Condition_OperatorApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Spartan_BR_Condition_OperatorApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_BR_Condition_Operator";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator> GetByKey(short Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>(false, null);
            }
        }

        public ApiResponse<Spartan_BR_Condition_OperatorPagingModel> GetByKeyComplete(short Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_OperatorPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Spartan_BR_Condition_Operator.ConditionOperatorId='" + Key.ToString() + "'"
                        + "&Order=Spartan_BR_Condition_Operator.ConditionOperatorId ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_OperatorPagingModel>(true, varRecords);

            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_OperatorPagingModel>(false, new Spartan_BR_Condition_OperatorPagingModel() { Spartan_BR_Condition_Operators = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(short Key, Core.Domain.User.GlobalData Spartan_BR_Condition_OperatorInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<bool>(baseApi, ApiControllerUrl + "/Delete?Id=" + Key,
                      Method.DELETE, ApiHeader);

                return new ApiResponse<bool>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<bool>(false, false);
            }
        }

        public ApiResponse<short> Insert(Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator entity, Core.Domain.User.GlobalData Spartan_BR_Condition_OperatorInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<short>(baseApi, ApiControllerUrl + "/Post",
                      Method.POST, ApiHeader, entity);

                return new ApiResponse<short>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<short>(false, -1 );
            }
        }

        public ApiResponse<short> Update(Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator entity, Core.Domain.User.GlobalData Spartan_BR_Condition_OperatorInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<short>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.ConditionOperatorId,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<short>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<short>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Spartan_BR_Condition_OperatorPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_OperatorPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_OperatorPagingModel>(true, varRecords);


            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_OperatorPagingModel>(false, new Spartan_BR_Condition_OperatorPagingModel() { Spartan_BR_Condition_Operators = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Condition_Operator.Spartan_BR_Condition_Operator>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

