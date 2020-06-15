using System;
using Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Consulta_Actividades_Registro_Evento
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Consulta_Actividades_Registro_EventoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_EventoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento.Detalle_Consulta_Actividades_Registro_Evento> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
