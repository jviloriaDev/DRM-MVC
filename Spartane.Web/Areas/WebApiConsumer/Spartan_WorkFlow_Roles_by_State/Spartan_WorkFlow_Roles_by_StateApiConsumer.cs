using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Roles_by_State
{
    public class Spartan_WorkFlow_Roles_by_StateApiConsumer : BaseApiConsumer,ISpartan_WorkFlow_Roles_by_StateApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Spartan_WorkFlow_Roles_by_StateApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_WorkFlow_Roles_by_State";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>(false, null);
            }
        }

        public ApiResponse<Spartan_WorkFlow_Roles_by_StatePagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_StatePagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Spartan_WorkFlow_Roles_by_State.Roles_by_StateId='" + Key.ToString() + "'"
                        + "&Order=Spartan_WorkFlow_Roles_by_State.Roles_by_StateId ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_StatePagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_StatePagingModel>(false, new Spartan_WorkFlow_Roles_by_StatePagingModel() { Spartan_WorkFlow_Roles_by_States = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Spartan_WorkFlow_Roles_by_StateInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State entity, Core.Domain.User.GlobalData Spartan_WorkFlow_Roles_by_StateInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State entity, Core.Domain.User.GlobalData Spartan_WorkFlow_Roles_by_StateInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.Roles_by_StateId,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Spartan_WorkFlow_Roles_by_StatePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_StatePagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_StatePagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_StatePagingModel>(false, new Spartan_WorkFlow_Roles_by_StatePagingModel() { Spartan_WorkFlow_Roles_by_States = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

