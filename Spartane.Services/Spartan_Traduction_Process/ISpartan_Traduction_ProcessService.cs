using System;
using Spartane.Core.Domain.Spartan_Traduction_Process;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_Traduction_Process
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Traduction_ProcessService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_Traduction_Process.Spartan_Traduction_Process> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Traduction_Process.Spartan_Traduction_Process> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Traduction_Process.Spartan_Traduction_Process> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_Traduction_Process.Spartan_Traduction_Process GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_Traduction_Process.Spartan_Traduction_Process entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_Traduction_Process.Spartan_Traduction_Process entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_Traduction_Process.Spartan_Traduction_Process> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_Traduction_Process.Spartan_Traduction_Process> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_Traduction_Process.Spartan_Traduction_ProcessPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_Traduction_Process.Spartan_Traduction_Process> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
