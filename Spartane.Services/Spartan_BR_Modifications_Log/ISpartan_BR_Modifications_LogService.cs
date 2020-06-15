using System;
using Spartane.Core.Domain.Spartan_BR_Modifications_Log;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_BR_Modifications_Log
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_BR_Modifications_LogService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_LogPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
