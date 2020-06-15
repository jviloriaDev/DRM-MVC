using System;
using Spartane.Core.Domain.Detalle_Facturacion_Vendedores;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Facturacion_Vendedores
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Facturacion_VendedoresService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Facturacion_Vendedores.Detalle_Facturacion_VendedoresPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Facturacion_Vendedores.Detalle_Facturacion_Vendedores> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
