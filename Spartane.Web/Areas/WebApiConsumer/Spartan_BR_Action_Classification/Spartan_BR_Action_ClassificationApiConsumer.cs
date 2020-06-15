using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartan_BR_Action_Classification;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Classification
{
    public class Spartan_BR_Action_ClassificationApiConsumer : BaseApiConsumer,ISpartan_BR_Action_ClassificationApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Spartan_BR_Action_ClassificationApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_BR_Action_Classification";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification> GetByKey(short Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>(true, varRecords);
            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>(false, null);
            }
        }

        public ApiResponse<Spartan_BR_Action_ClassificationPagingModel> GetByKeyComplete(short Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_ClassificationPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Spartan_BR_Action_Classification.ClassificationId='" + Key.ToString() + "'"
                        + "&Order=Spartan_BR_Action_Classification.ClassificationId ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_ClassificationPagingModel>(true, varRecords);

            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_ClassificationPagingModel>(false, new Spartan_BR_Action_ClassificationPagingModel() { Spartan_BR_Action_Classifications = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(short Key, Core.Domain.User.GlobalData Spartan_BR_Action_ClassificationInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<short> Insert(Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification entity, Core.Domain.User.GlobalData Spartan_BR_Action_ClassificationInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<short> Update(Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification entity, Core.Domain.User.GlobalData Spartan_BR_Action_ClassificationInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<short>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.ClassificationId,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<short>(true, result);
            }
            catch (Exception)
            {
                return new ApiResponse<short>(false, -1 );
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Spartan_BR_Action_ClassificationPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_ClassificationPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_ClassificationPagingModel>(true, varRecords);


            }
            catch (Exception)
            {
                return new ApiResponse<Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_ClassificationPagingModel>(false, new Spartan_BR_Action_ClassificationPagingModel() { Spartan_BR_Action_Classifications = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

