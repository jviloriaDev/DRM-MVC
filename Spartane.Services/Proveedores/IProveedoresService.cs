using System;
using Spartane.Core.Domain.Proveedores;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Proveedores
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IProveedoresService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Proveedores.Proveedores> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Proveedores.Proveedores> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Proveedores.Proveedores> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Proveedores.Proveedores GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Proveedores.Proveedores entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Proveedores.Proveedores entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Proveedores.Proveedores> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Proveedores.Proveedores> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Proveedores.ProveedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Proveedores.Proveedores> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
