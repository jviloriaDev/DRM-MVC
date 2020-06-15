using System;
using Spartane.Core.Domain.Spartan_WorkFlow_Status;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_WorkFlow_Status
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_WorkFlow_StatusService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int16 Insert(Spartane.Core.Domain.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int16 Update(Spartane.Core.Domain.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_WorkFlow_Status.Spartan_WorkFlow_StatusPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
