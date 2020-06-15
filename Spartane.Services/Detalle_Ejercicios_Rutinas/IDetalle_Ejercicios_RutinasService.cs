using System;
using Spartane.Core.Domain.Detalle_Ejercicios_Rutinas;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Ejercicios_Rutinas
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Ejercicios_RutinasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_RutinasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Ejercicios_Rutinas.Detalle_Ejercicios_Rutinas> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
