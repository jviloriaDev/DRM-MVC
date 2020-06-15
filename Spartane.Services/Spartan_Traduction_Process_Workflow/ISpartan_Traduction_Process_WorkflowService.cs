using System;
using Spartane.Core.Domain.Spartan_Traduction_Process_Workflow;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_Traduction_Process_Workflow
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Traduction_Process_WorkflowService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_WorkflowPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_Traduction_Process_Workflow.Spartan_Traduction_Process_Workflow> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
