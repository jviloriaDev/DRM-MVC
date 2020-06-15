using System;
using Spartane.Core.Domain.Spartan_Report_Presentation_View;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Spartan_Report_Presentation_View
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface ISpartan_Report_Presentation_ViewService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_ViewPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
