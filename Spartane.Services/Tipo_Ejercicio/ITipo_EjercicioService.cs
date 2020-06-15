using System;
using Spartane.Core.Domain.Tipo_Ejercicio;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Tipo_Ejercicio
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ITipo_EjercicioService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Tipo_Ejercicio.Tipo_Ejercicio> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tipo_Ejercicio.Tipo_Ejercicio> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Tipo_Ejercicio.Tipo_Ejercicio> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Tipo_Ejercicio.Tipo_Ejercicio GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Tipo_Ejercicio.Tipo_Ejercicio entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Tipo_Ejercicio.Tipo_Ejercicio entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Tipo_Ejercicio.Tipo_Ejercicio> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Tipo_Ejercicio.Tipo_Ejercicio> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Tipo_Ejercicio.Tipo_EjercicioPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Tipo_Ejercicio.Tipo_Ejercicio> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
