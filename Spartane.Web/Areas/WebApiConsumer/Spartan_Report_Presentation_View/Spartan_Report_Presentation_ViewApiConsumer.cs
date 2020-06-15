using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartan_Report_Presentation_View;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Presentation_View
{
    public class Spartan_Report_Presentation_ViewApiConsumer : BaseApiConsumer,ISpartan_Report_Presentation_ViewApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Spartan_Report_Presentation_ViewApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_Report_Presentation_View";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> GetByKey(int Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>(false, null);
            }
        }

        public ApiResponse<Spartan_Report_Presentation_ViewPagingModel> GetByKeyComplete(int Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_ViewPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Spartan_Report_Presentation_View.PresentationViewId='" + Key.ToString() + "'"
                        + "&Order=Spartan_Report_Presentation_View.PresentationViewId ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_ViewPagingModel>(true, varRecords);

            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_ViewPagingModel>(false, new Spartan_Report_Presentation_ViewPagingModel() { Spartan_Report_Presentation_Views = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(int Key, Core.Domain.User.GlobalData Spartan_Report_Presentation_ViewInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Insert(Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View entity, Core.Domain.User.GlobalData Spartan_Report_Presentation_ViewInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<int> Update(Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View entity, Core.Domain.User.GlobalData Spartan_Report_Presentation_ViewInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<int>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.PresentationViewId,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<int>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<int>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Spartan_Report_Presentation_ViewPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_ViewPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_ViewPagingModel>(true, varRecords);


            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_ViewPagingModel>(false, new Spartan_Report_Presentation_ViewPagingModel() { Spartan_Report_Presentation_Views = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

