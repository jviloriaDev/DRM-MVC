using System;
using Spartane.Core.Domain.Spartan_BR_Operation;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_BR_Operation
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_OperationService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int16 Insert(Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int16 Update(Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_OperationPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
