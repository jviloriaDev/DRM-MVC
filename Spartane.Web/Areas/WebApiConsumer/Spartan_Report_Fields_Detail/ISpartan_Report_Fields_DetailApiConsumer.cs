using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Fields_Detail
{
    public interface ISpartan_Report_Fields_DetailApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_Report_Fields_Detail.Spartan_Report_Fields_DetailPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_Report_Fields_DetailInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail entity, Spartane.Core.Domain.User.GlobalData Spartan_Report_Fields_DetailInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail entity, Spartane.Core.Domain.User.GlobalData Spartan_Report_Fields_DetailInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_Report_Fields_Detail.Spartan_Report_Fields_DetailPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Report_Fields_Detail.Spartan_Report_Fields_Detail>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

