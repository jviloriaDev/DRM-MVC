using System;
using Spartane.Core.Domain.Estatus_Reservaciones_Actividad;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Estatus_Reservaciones_Actividad
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEstatus_Reservaciones_ActividadService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_ActividadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Estatus_Reservaciones_Actividad.Estatus_Reservaciones_Actividad> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
