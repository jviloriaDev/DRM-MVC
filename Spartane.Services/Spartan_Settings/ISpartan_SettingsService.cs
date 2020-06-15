using System;
using Spartane.Core.Domain.Spartan_Settings;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_Settings
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_SettingsService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_Settings.Spartan_Settings GetByKey(string Key, Boolean ConRelaciones);
        bool Delete(string Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        String Insert(Spartane.Core.Domain.Spartan_Settings.Spartan_Settings entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        String Update(Spartane.Core.Domain.Spartan_Settings.Spartan_Settings entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_Settings.Spartan_SettingsPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_Settings.Spartan_Settings> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
