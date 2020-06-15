using System;
using Spartane.Core.Domain.Dias_de_la_semana;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Dias_de_la_semana
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDias_de_la_semanaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semanaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Dias_de_la_semana.Dias_de_la_semana> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
