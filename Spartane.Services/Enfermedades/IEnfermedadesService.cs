using System;
using Spartane.Core.Domain.Enfermedades;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Enfermedades
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEnfermedadesService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Enfermedades.Enfermedades> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Enfermedades.Enfermedades> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Enfermedades.Enfermedades> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Enfermedades.Enfermedades GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Enfermedades.Enfermedades entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Enfermedades.Enfermedades entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Enfermedades.Enfermedades> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Enfermedades.Enfermedades> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Enfermedades.EnfermedadesPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Enfermedades.Enfermedades> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
