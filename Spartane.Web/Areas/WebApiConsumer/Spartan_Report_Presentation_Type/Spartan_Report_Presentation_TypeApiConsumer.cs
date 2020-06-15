using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartan_Report_Presentation_Type;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Presentation_Type
{
    public class Spartan_Report_Presentation_TypeApiConsumer : BaseApiConsumer,ISpartan_Report_Presentation_TypeApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Spartan_Report_Presentation_TypeApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_Report_Presentation_Type";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>(false, null);
            }
        }

        public ApiResponse<Spartan_Report_Presentation_TypePagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_TypePagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Spartan_Report_Presentation_Type.PresentationTypeId='" + Key.ToString() + "'"
                        + "&Order=Spartan_Report_Presentation_Type.PresentationTypeId ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_TypePagingModel>(true, varRecords);

            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_TypePagingModel>(false, new Spartan_Report_Presentation_TypePagingModel() { Spartan_Report_Presentation_Types = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Spartan_Report_Presentation_TypeInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type entity, Core.Domain.User.GlobalData Spartan_Report_Presentation_TypeInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type entity, Core.Domain.User.GlobalData Spartan_Report_Presentation_TypeInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.PresentationTypeId,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Spartan_Report_Presentation_TypePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_TypePagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_TypePagingModel>(true, varRecords);


            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_TypePagingModel>(false, new Spartan_Report_Presentation_TypePagingModel() { Spartan_Report_Presentation_Types = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

