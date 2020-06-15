using System;
using Spartane.Core.Domain.Spartan_WorkFlow_Information_by_State;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_WorkFlow_Information_by_State
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_WorkFlow_Information_by_StateService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_StatePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow_Information_by_State> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
