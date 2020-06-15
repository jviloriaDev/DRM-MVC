using System;
using Spartane.Core.Domain.Spartan_ChangePasswordAutorization;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_ChangePasswordAutorization
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_ChangePasswordAutorizationService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorizationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_ChangePasswordAutorization.Spartan_ChangePasswordAutorization> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
