using System;
using Spartane.Core.Domain.Spartan_User_Role;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_User_Role
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_User_RoleService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_User_Role.Spartan_User_RolePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
