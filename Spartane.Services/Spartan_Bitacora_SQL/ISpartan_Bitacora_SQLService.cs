using System;
using Spartane.Core.Domain.Spartan_Bitacora_SQL;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_Bitacora_SQL
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Bitacora_SQLService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQLPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_Bitacora_SQL.Spartan_Bitacora_SQL> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
