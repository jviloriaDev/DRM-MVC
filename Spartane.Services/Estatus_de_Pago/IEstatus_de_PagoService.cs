using System;
using Spartane.Core.Domain.Estatus_de_Pago;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Estatus_de_Pago
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatus_de_PagoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Estatus_de_Pago.Estatus_de_Pago> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estatus_de_Pago.Estatus_de_Pago> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estatus_de_Pago.Estatus_de_Pago> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Estatus_de_Pago.Estatus_de_Pago GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Estatus_de_Pago.Estatus_de_Pago entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Estatus_de_Pago.Estatus_de_Pago entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Estatus_de_Pago.Estatus_de_Pago> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Estatus_de_Pago.Estatus_de_Pago> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Estatus_de_Pago.Estatus_de_PagoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Estatus_de_Pago.Estatus_de_Pago> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
