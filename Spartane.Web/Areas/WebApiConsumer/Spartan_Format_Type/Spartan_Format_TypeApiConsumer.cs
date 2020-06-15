using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartan_Format_Type;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Type
{
    public class Spartan_Format_TypeApiConsumer : BaseApiConsumer,ISpartan_Format_TypeApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Spartan_Format_TypeApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_Format_Type";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Format_Type.Spartan_Format_Type>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_Format_Type.Spartan_Format_Type>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_Format_Type.Spartan_Format_Type>>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_Format_Type.Spartan_Format_Type>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Spartan_Format_Type.Spartan_Format_Type>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_Format_Type.Spartan_Format_Type>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_Format_Type.Spartan_Format_Type>>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_Format_Type.Spartan_Format_Type>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Spartan_Format_Type.Spartan_Format_Type> GetByKey(short Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Format_Type.Spartan_Format_Type>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Format_Type.Spartan_Format_Type>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_Format_Type.Spartan_Format_Type>(false, null);
            }
        }

        public ApiResponse<Spartan_Format_TypePagingModel> GetByKeyComplete(short Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Format_Type.Spartan_Format_TypePagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Spartan_Format_Type.FormatTypeId='" + Key.ToString() + "'"
                        + "&Order=Spartan_Format_Type.FormatTypeId ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Format_Type.Spartan_Format_TypePagingModel>(true, varRecords);

            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_Format_Type.Spartan_Format_TypePagingModel>(false, new Spartan_Format_TypePagingModel() { Spartan_Format_Types = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(short Key, Core.Domain.User.GlobalData Spartan_Format_TypeInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<short> Insert(Core.Domain.Spartan_Format_Type.Spartan_Format_Type entity, Core.Domain.User.GlobalData Spartan_Format_TypeInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<short> Update(Core.Domain.Spartan_Format_Type.Spartan_Format_Type entity, Core.Domain.User.GlobalData Spartan_Format_TypeInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<short>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.FormatTypeId,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<short>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<short>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_Format_Type.Spartan_Format_Type>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Format_Type.Spartan_Format_Type>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Format_Type.Spartan_Format_Type>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Spartan_Format_TypePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Format_Type.Spartan_Format_TypePagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Format_Type.Spartan_Format_TypePagingModel>(true, varRecords);


            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_Format_Type.Spartan_Format_TypePagingModel>(false, new Spartan_Format_TypePagingModel() { Spartan_Format_Types = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_Format_Type.Spartan_Format_Type>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

