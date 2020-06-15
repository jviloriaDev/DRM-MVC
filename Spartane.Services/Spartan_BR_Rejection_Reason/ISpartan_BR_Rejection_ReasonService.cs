using System;
using Spartane.Core.Domain.Spartan_BR_Rejection_Reason;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_BR_Rejection_Reason
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_Rejection_ReasonService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_ReasonPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_BR_Rejection_Reason.Spartan_BR_Rejection_Reason> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
