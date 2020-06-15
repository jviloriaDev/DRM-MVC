using System;
using Spartane.Core.Domain.Detalle_Pagos_Paciente;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Pagos_Paciente
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Pagos_PacienteService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Pagos_Paciente.Detalle_Pagos_PacientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Pagos_Paciente.Detalle_Pagos_Paciente> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
