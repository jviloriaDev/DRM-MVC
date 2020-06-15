using System;
using Spartane.Core.Domain.Spartan_Report_Advance_Filter;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_Report_Advance_Filter
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Report_Advance_FilterService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_FilterPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_Report_Advance_Filter.Spartan_Report_Advance_Filter> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
