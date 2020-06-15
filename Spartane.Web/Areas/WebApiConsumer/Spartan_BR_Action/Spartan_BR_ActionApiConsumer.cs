using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartan_BR_Action;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action
{
    public class Spartan_BR_ActionApiConsumer : BaseApiConsumer,ISpartan_BR_ActionApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Spartan_BR_ActionApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_BR_Action";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Action.Spartan_BR_Action>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_Action>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_BR_Action.Spartan_BR_Action>>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_BR_Action.Spartan_BR_Action>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Action.Spartan_BR_Action>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_Action>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_BR_Action.Spartan_BR_Action>>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_BR_Action.Spartan_BR_Action>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Spartan_BR_Action.Spartan_BR_Action> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_Action>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_BR_Action.Spartan_BR_Action>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_BR_Action.Spartan_BR_Action>(false, null);
            }
        }

        public ApiResponse<Spartan_BR_ActionPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_ActionPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Spartan_BR_Action.ActionId='" + Key.ToString() + "'"
                        + "&Order=Spartan_BR_Action.ActionId ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_BR_Action.Spartan_BR_ActionPagingModel>(true, varRecords);

            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_BR_Action.Spartan_BR_ActionPagingModel>(false, new Spartan_BR_ActionPagingModel() { Spartan_BR_Actions = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Spartan_BR_ActionInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Spartan_BR_Action.Spartan_BR_Action entity, Core.Domain.User.GlobalData Spartan_BR_ActionInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Post",
                      Method.POST, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<int> Update(Core.Domain.Spartan_BR_Action.Spartan_BR_Action entity, Core.Domain.User.GlobalData Spartan_BR_ActionInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.ActionId,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Action.Spartan_BR_Action>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Action.Spartan_BR_Action>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Action.Spartan_BR_Action>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Spartan_BR_ActionPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_ActionPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_BR_Action.Spartan_BR_ActionPagingModel>(true, varRecords);


            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_BR_Action.Spartan_BR_ActionPagingModel>(false, new Spartan_BR_ActionPagingModel() { Spartan_BR_Actions = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Action.Spartan_BR_Action>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

