using System;
using Spartane.Core.Domain.Spartan_Report;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_Report
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_ReportService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_Report.Spartan_Report> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Report.Spartan_Report> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Report.Spartan_Report> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_Report.Spartan_Report GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_Report.Spartan_Report entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_Report.Spartan_Report entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_Report.Spartan_Report> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_Report.Spartan_Report> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_Report.Spartan_ReportPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_Report.Spartan_Report> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
