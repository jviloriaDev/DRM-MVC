using System;
using Spartane.Core.Domain.Eventos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Eventos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEventosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Eventos.Eventos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Eventos.Eventos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Eventos.Eventos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Eventos.Eventos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Eventos.Eventos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Eventos.Eventos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Eventos.Eventos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Eventos.Eventos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Eventos.EventosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Eventos.Eventos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
