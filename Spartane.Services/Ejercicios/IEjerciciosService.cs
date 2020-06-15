using System;
using Spartane.Core.Domain.Ejercicios;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Ejercicios
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IEjerciciosService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Ejercicios.Ejercicios> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Ejercicios.Ejercicios> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Ejercicios.Ejercicios> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Ejercicios.Ejercicios GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Ejercicios.Ejercicios entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Ejercicios.Ejercicios entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Ejercicios.Ejercicios> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Ejercicios.Ejercicios> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Ejercicios.EjerciciosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Ejercicios.Ejercicios> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
