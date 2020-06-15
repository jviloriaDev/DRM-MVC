using System;
using Spartane.Core.Domain.Frecuencia_Sustancias;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Frecuencia_Sustancias
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IFrecuencia_SustanciasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_SustanciasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Frecuencia_Sustancias.Frecuencia_Sustancias> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
