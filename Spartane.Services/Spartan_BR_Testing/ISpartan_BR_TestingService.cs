using System;
using Spartane.Core.Domain.Spartan_BR_Testing;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_BR_Testing
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_TestingService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_TestingPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_BR_Testing.Spartan_BR_Testing> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
