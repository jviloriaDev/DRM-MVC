using System;
using Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Registro_en_Actividad_Evento
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Registro_en_Actividad_EventoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_EventoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento.Detalle_Registro_en_Actividad_Evento> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
