using System;
using Spartane.Core.Domain.Spartan_User_Historical_Password;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_User_Historical_Password
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_User_Historical_PasswordService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_PasswordPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
