using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Presentation_View
{
    public interface ISpartan_Report_Presentation_ViewApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_ViewPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_Report_Presentation_ViewInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View entity, Spartane.Core.Domain.User.GlobalData Spartan_Report_Presentation_ViewInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View entity, Spartane.Core.Domain.User.GlobalData Spartan_Report_Presentation_ViewInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_ViewPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

