using System;
using Spartane.Core.Domain.Medicos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Medicos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IMedicosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Medicos.Medicos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Medicos.Medicos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Medicos.Medicos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Medicos.Medicos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Medicos.Medicos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Medicos.Medicos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Medicos.Medicos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Medicos.Medicos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Medicos.MedicosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Medicos.Medicos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
