using System;
using Spartane.Core.Domain.Registro_en_Evento;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Registro_en_Evento
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IRegistro_en_EventoService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Registro_en_Evento.Registro_en_EventoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Registro_en_Evento.Registro_en_Evento> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
