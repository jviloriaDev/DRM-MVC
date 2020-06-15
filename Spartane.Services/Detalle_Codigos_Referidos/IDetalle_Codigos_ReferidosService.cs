using System;
using Spartane.Core.Domain.Detalle_Codigos_Referidos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Codigos_Referidos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Codigos_ReferidosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_ReferidosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Codigos_Referidos.Detalle_Codigos_Referidos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
