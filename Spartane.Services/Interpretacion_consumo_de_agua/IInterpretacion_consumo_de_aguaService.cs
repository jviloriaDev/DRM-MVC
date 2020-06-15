using System;
using Spartane.Core.Domain.Interpretacion_consumo_de_agua;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Interpretacion_consumo_de_agua
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IInterpretacion_consumo_de_aguaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_aguaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Interpretacion_consumo_de_agua.Interpretacion_consumo_de_agua> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
