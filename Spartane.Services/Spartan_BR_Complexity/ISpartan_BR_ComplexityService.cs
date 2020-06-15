using System;
using Spartane.Core.Domain.Spartan_BR_Complexity;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_BR_Complexity
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_ComplexityService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_ComplexityPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_BR_Complexity.Spartan_BR_Complexity> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
