using System;
using Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_WorkFlow_Type_Flow_Control
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_WorkFlow_Type_Flow_ControlService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int16 Insert(Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int16 Update(Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_ControlPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
