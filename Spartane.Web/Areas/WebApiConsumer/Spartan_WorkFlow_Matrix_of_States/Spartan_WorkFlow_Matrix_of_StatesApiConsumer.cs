using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Matrix_of_States
{
    public class Spartan_WorkFlow_Matrix_of_StatesApiConsumer : BaseApiConsumer,ISpartan_WorkFlow_Matrix_of_StatesApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Spartan_WorkFlow_Matrix_of_StatesApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_WorkFlow_Matrix_of_States";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>(false, null);
            }
        }

        public ApiResponse<Spartan_WorkFlow_Matrix_of_StatesPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_StatesPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Spartan_WorkFlow_Matrix_of_States.Matrix_of_StatesId='" + Key.ToString() + "'"
                        + "&Order=Spartan_WorkFlow_Matrix_of_States.Matrix_of_StatesId ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_StatesPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_StatesPagingModel>(false, new Spartan_WorkFlow_Matrix_of_StatesPagingModel() { Spartan_WorkFlow_Matrix_of_Statess = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Spartan_WorkFlow_Matrix_of_StatesInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States entity, Core.Domain.User.GlobalData Spartan_WorkFlow_Matrix_of_StatesInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States entity, Core.Domain.User.GlobalData Spartan_WorkFlow_Matrix_of_StatesInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.Matrix_of_StatesId,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Spartan_WorkFlow_Matrix_of_StatesPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_StatesPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_StatesPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_StatesPagingModel>(false, new Spartan_WorkFlow_Matrix_of_StatesPagingModel() { Spartan_WorkFlow_Matrix_of_Statess = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

