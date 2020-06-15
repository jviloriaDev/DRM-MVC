using System;
using Spartane.Core.Domain.Especialidades;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Especialidades
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEspecialidadesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Especialidades.Especialidades> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Especialidades.Especialidades> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Especialidades.Especialidades> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Especialidades.Especialidades GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Especialidades.Especialidades entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Especialidades.Especialidades entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Especialidades.Especialidades> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Especialidades.Especialidades> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Especialidades.EspecialidadesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Especialidades.Especialidades> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
