using System;
using Spartane.Core.Domain.Detalle_Examenes_Laboratorio;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Examenes_Laboratorio
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Examenes_LaboratorioService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_LaboratorioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Examenes_Laboratorio.Detalle_Examenes_Laboratorio> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
