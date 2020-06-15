using System;
using Spartane.Core.Domain.Sustancias;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Sustancias
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISustanciasService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Sustancias.Sustancias> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Sustancias.Sustancias> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Sustancias.Sustancias> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Sustancias.Sustancias GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Sustancias.Sustancias entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Sustancias.Sustancias entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Sustancias.Sustancias> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Sustancias.Sustancias> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Sustancias.SustanciasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Sustancias.Sustancias> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
