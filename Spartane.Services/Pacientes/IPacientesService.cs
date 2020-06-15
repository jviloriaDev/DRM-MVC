using System;
using Spartane.Core.Domain.Pacientes;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Pacientes
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPacientesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Pacientes.Pacientes> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Pacientes.Pacientes> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Pacientes.Pacientes> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Pacientes.Pacientes GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Pacientes.Pacientes entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Pacientes.Pacientes entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Pacientes.Pacientes> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Pacientes.Pacientes> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Pacientes.PacientesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Pacientes.Pacientes> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
