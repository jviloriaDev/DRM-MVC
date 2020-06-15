using System;
using Spartane.Core.Domain.Spartan_BR_Condition;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_BR_Condition
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_ConditionService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_BR_Condition.Spartan_BR_Condition> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Condition.Spartan_BR_Condition> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Condition.Spartan_BR_Condition> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_BR_Condition.Spartan_BR_Condition GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int16 Insert(Spartane.Core.Domain.Spartan_BR_Condition.Spartan_BR_Condition entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int16 Update(Spartane.Core.Domain.Spartan_BR_Condition.Spartan_BR_Condition entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_BR_Condition.Spartan_BR_Condition> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_BR_Condition.Spartan_BR_Condition> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_BR_Condition.Spartan_BR_ConditionPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_BR_Condition.Spartan_BR_Condition> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
