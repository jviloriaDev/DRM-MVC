using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Spartan_Settings;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_Settings
{
    public class Spartan_SettingsApiConsumer : BaseApiConsumer,ISpartan_SettingsApiConsumer
    {
        public override sealed string ApiControllerUrl { get; set; }
        public string baseApi;

        public Spartan_SettingsApiConsumer()
        {
            baseApi = ApiUrlManager.BaseUrlLocal;
            ApiControllerUrl = "/api/Spartan_Settings";
        }
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Settings.Spartan_Settings>> SelAll(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings>>(baseApi, ApiControllerUrl + "/GetAll",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_Settings.Spartan_Settings>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_Settings.Spartan_Settings>>(false, null);
            }

        }

        public ApiResponse<IList<Core.Domain.Spartan_Settings.Spartan_Settings>> SelAllComplete(bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<IList<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings>>(baseApi, ApiControllerUrl + "/GetAllComplete",
                      Method.GET, ApiHeader);

                return new ApiResponse<IList<Core.Domain.Spartan_Settings.Spartan_Settings>>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<IList<Core.Domain.Spartan_Settings.Spartan_Settings>>(false, null);
            }
        }

        public ApiResponse<Core.Domain.Spartan_Settings.Spartan_Settings> GetByKey(string Key, bool ConRelaciones)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings>(baseApi, ApiControllerUrl + "/Get?Id=" + Key,
                      Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Settings.Spartan_Settings>(true, varRecords);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_Settings.Spartan_Settings>(false, null);
            }
        }

        public ApiResponse<Spartan_SettingsPagingModel> GetByKeyComplete(string Key)
        {
            try
            {
                    var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Settings.Spartan_SettingsPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=1&maximumRows=1" 
                        + "&Where=Spartan_Settings.Clave='" + Key.ToString() + "'"
                        + "&Order=Spartan_Settings.Clave ASC",
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Settings.Spartan_SettingsPagingModel>(true, varRecords);

            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_Settings.Spartan_SettingsPagingModel>(false, new Spartan_SettingsPagingModel() { Spartan_Settingss = null, RowCount = 0 });
            }
        }

        public ApiResponse<bool> Delete(string Key, Core.Domain.User.GlobalData Spartan_SettingsInformation, DataLayerFieldsBitacora DataReference)
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

        public ApiResponse<string> Insert(Core.Domain.Spartan_Settings.Spartan_Settings entity, Core.Domain.User.GlobalData Spartan_SettingsInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<string>(baseApi, ApiControllerUrl + "/Post",
                      Method.POST, ApiHeader, entity);

                return new ApiResponse<string>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>(false, "-1" );
            }
        }

        public ApiResponse<string> Update(Core.Domain.Spartan_Settings.Spartan_Settings entity, Core.Domain.User.GlobalData Spartan_SettingsInformation, DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var result = RestApiHelper.InvokeApi<string>(baseApi, ApiControllerUrl + "/Put?Id=" + entity.Clave,
                      Method.PUT, ApiHeader, entity);

                return new ApiResponse<string>(true, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse<string>(false, "-1" );
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_Settings.Spartan_Settings>> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Settings.Spartan_Settings>> SelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<IList<Core.Domain.Spartan_Settings.Spartan_Settings>> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            throw new NotImplementedException();
        }

        public ApiResponse<Spartan_SettingsPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            try
            {
                var varRecords = RestApiHelper.InvokeApi<Spartane.Core.Domain.Spartan_Settings.Spartan_SettingsPagingModel>(baseApi, ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                    "&maximumRows=" + maximumRows +
                    (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                     (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order),
                     Method.GET, ApiHeader);

                return new ApiResponse<Core.Domain.Spartan_Settings.Spartan_SettingsPagingModel>(true, varRecords);


            }
            catch (Exception ex)
            {
                return new ApiResponse<Core.Domain.Spartan_Settings.Spartan_SettingsPagingModel>(false, new Spartan_SettingsPagingModel() { Spartan_Settingss = null, RowCount = 0 });
            }
        }

        public ApiResponse<IList<Core.Domain.Spartan_Settings.Spartan_Settings>> ListaSelAll(bool ConRelaciones, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

