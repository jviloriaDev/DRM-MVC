using System;
using Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Suscripcion_Red_de_Especialistas_Proveedores
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_ProveedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Detalle_Suscripcion_Red_de_Especialistas_Proveedores> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
