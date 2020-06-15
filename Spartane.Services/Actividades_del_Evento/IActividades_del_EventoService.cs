using System;
using Spartane.Core.Domain.Actividades_del_Evento;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Actividades_del_Evento
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IActividades_del_EventoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_EventoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Actividades_del_Evento.Actividades_del_Evento> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
