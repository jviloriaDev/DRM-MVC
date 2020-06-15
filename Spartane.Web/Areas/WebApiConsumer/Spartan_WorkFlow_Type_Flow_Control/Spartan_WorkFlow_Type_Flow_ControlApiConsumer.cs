using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Type_Flow_Control
{
    public class Spartan_WorkFlow_Type_Flow_ControlApiConsumer : BaseApiConsumer,ISpartan_WorkFlow_Type_Flow_ControlApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Spartan_WorkFlow_Type_Flow_ControlApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_WorkFlow_Type_Flow_Control";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> GetByKey(short Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control>(false, null);
            }
        }

        public ApiResponse<Spartan_WorkFlow_Type_Flow_ControlPagingModel> GetByKeyComplete(short Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_ControlPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Spartan_WorkFlow_Type_Flow_Control.Type_Flow_ControlId='" + Key.ToString() + "'"
                        + "&Order=Spartan_WorkFlow_Type_Flow_Control.Type_Flow_ControlId ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_ControlPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_ControlPagingModel>(false, new Spartan_WorkFlow_Type_Flow_ControlPagingModel() { Spartan_WorkFlow_Type_Flow_Controls = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(short Key, Core.Domain.User.GlobalData Spartan_WorkFlow_Type_Flow_ControlInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<short> Insert(Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control entity, Core.Domain.User.GlobalData Spartan_WorkFlow_Type_Flow_ControlInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<short>(baseApi, ApiControllerUrl + "/Post",
                      Method.POST, ApiHeader, entity);

                return new ApiResponse<short>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<short>(false, -1 );
            }
        }

        public ApiResponse<short> Update(Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control entity, Core.Domain.User.GlobalData Spartan_WorkFlow_Type_Flow_ControlInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<short>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.Type_Flow_ControlId,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<short>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<short>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Spartan_WorkFlow_Type_Flow_ControlPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_ControlPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_ControlPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_ControlPagingModel>(false, new Spartan_WorkFlow_Type_Flow_ControlPagingModel() { Spartan_WorkFlow_Type_Flow_Controls = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

