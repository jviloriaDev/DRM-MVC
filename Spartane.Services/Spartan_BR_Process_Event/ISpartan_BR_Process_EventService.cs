using System;
using Spartane.Core.Domain.Spartan_BR_Process_Event;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_BR_Process_Event
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_Process_EventService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event GetByKey(short Key, Boolean ConRelaciones);
        bool Delete(short Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int16 Insert(Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int16 Update(Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_EventPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
