using System;
using Spartane.Core.Domain.Tipo_Paciente;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Tipo_Paciente
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipo_PacienteService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Tipo_Paciente.Tipo_Paciente> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tipo_Paciente.Tipo_Paciente> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tipo_Paciente.Tipo_Paciente> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Tipo_Paciente.Tipo_Paciente GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Tipo_Paciente.Tipo_Paciente entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Tipo_Paciente.Tipo_Paciente entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Tipo_Paciente.Tipo_Paciente> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Tipo_Paciente.Tipo_Paciente> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Tipo_Paciente.Tipo_PacientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Tipo_Paciente.Tipo_Paciente> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
