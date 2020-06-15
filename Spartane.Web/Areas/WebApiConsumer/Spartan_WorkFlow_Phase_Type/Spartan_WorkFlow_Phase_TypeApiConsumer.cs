using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartan_WorkFlow_Phase_Type;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phase_Type
{
    public class Spartan_WorkFlow_Phase_TypeApiConsumer : BaseApiConsumer,ISpartan_WorkFlow_Phase_TypeApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Spartan_WorkFlow_Phase_TypeApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_WorkFlow_Phase_Type";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type> GetByKey(short Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type>(false, null);
            }
        }

        public ApiResponse<Spartan_WorkFlow_Phase_TypePagingModel> GetByKeyComplete(short Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_TypePagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Spartan_WorkFlow_Phase_Type.Phase_TypeId='" + Key.ToString() + "'"
                        + "&Order=Spartan_WorkFlow_Phase_Type.Phase_TypeId ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_TypePagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_TypePagingModel>(false, new Spartan_WorkFlow_Phase_TypePagingModel() { Spartan_WorkFlow_Phase_Types = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(short Key, Core.Domain.User.GlobalData Spartan_WorkFlow_Phase_TypeInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<short> Insert(Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type entity, Core.Domain.User.GlobalData Spartan_WorkFlow_Phase_TypeInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<short> Update(Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type entity, Core.Domain.User.GlobalData Spartan_WorkFlow_Phase_TypeInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<short>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.Phase_TypeId,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<short>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<short>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Spartan_WorkFlow_Phase_TypePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_TypePagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_TypePagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_TypePagingModel>(false, new Spartan_WorkFlow_Phase_TypePagingModel() { Spartan_WorkFlow_Phase_Types = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

