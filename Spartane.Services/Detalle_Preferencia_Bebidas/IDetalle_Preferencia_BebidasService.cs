using System;
using Spartane.Core.Domain.Detalle_Preferencia_Bebidas;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Preferencia_Bebidas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Preferencia_BebidasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_BebidasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Preferencia_Bebidas.Detalle_Preferencia_Bebidas> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
