using System;
using Spartane.Core.Domain.Estatus_Eventos;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Estatus_Eventos
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatus_EventosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Estatus_Eventos.Estatus_Eventos> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estatus_Eventos.Estatus_Eventos> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estatus_Eventos.Estatus_Eventos> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Estatus_Eventos.Estatus_Eventos GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Estatus_Eventos.Estatus_Eventos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Estatus_Eventos.Estatus_Eventos entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Estatus_Eventos.Estatus_Eventos> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Estatus_Eventos.Estatus_Eventos> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Estatus_Eventos.Estatus_EventosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Estatus_Eventos.Estatus_Eventos> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
