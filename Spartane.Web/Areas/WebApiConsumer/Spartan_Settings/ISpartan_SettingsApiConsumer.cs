using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_Settings
{
    public interface ISpartan_SettingsApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings> GetByKey(string Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_Settings.Spartan_SettingsPagingModel> GetByKeyComplete(string Key);
        ApiResponse<bool> Delete(string Key, Spartane.Core.Domain.User.GlobalData Spartan_SettingsInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<String> Insert(Spartane.Core.Domain.Spartan_Settings.Spartan_Settings entity, Spartane.Core.Domain.User.GlobalData Spartan_SettingsInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<String> Update(Spartane.Core.Domain.Spartan_Settings.Spartan_Settings entity, Spartane.Core.Domain.User.GlobalData Spartan_SettingsInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_Settings.Spartan_SettingsPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

