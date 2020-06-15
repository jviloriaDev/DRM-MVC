using System;
using Spartane.Core.Domain.Periodo_del_dia;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Periodo_del_dia
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IPeriodo_del_diaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Periodo_del_dia.Periodo_del_diaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Periodo_del_dia.Periodo_del_dia> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
