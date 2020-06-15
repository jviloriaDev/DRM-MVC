using System;
using Spartane.Core.Domain.Spartan_User;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_User
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_UserService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_User.Spartan_User> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_User.Spartan_User> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_User.Spartan_User> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_User.Spartan_User GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_User.Spartan_User entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_User.Spartan_User entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_User.Spartan_User> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_User.Spartan_User> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_User.Spartan_UserPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_User.Spartan_User> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
