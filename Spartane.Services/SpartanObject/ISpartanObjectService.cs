using System;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_Object
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_ObjectService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_Object.Spartan_Object> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Object.Spartan_Object> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Object.Spartan_Object> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_Object.Spartan_Object GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_Object.Spartan_Object entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_Object.Spartan_Object entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_Object.Spartan_Object> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_Object.Spartan_Object> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_Object.Spartan_ObjectPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_Object.Spartan_Object> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
