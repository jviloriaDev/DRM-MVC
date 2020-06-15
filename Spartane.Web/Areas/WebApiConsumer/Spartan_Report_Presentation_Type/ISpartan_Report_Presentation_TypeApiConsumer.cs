using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Presentation_Type
{
    public interface ISpartan_Report_Presentation_TypeApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_TypePagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_Report_Presentation_TypeInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type entity, Spartane.Core.Domain.User.GlobalData Spartan_Report_Presentation_TypeInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type entity, Spartane.Core.Domain.User.GlobalData Spartan_Report_Presentation_TypeInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_TypePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

