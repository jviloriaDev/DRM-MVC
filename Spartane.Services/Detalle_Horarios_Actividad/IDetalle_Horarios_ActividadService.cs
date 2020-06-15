﻿using System;
using Spartane.Core.Domain.Detalle_Horarios_Actividad;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Horarios_Actividad
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Horarios_ActividadService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_ActividadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Horarios_Actividad.Detalle_Horarios_Actividad> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
