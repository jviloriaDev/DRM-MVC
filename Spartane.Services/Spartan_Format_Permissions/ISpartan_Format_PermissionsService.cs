using System;
using Spartane.Core.Domain.Spartan_Format_Permissions;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_Format_Permissions
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Format_PermissionsService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_PermissionsPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_Format_Permissions.Spartan_Format_Permissions> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
