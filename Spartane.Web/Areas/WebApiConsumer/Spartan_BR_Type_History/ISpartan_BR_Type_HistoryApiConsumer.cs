using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Type_History
{
    public interface ISpartan_BR_Type_HistoryApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Type_History.Spartan_BR_Type_History>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Type_History.Spartan_BR_Type_History>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_BR_Type_History.Spartan_BR_Type_History> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_BR_Type_History.Spartan_BR_Type_HistoryPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_BR_Type_HistoryInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Spartan_BR_Type_History.Spartan_BR_Type_History entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Type_HistoryInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Spartan_BR_Type_History.Spartan_BR_Type_History entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Type_HistoryInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Type_History.Spartan_BR_Type_History>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Type_History.Spartan_BR_Type_History>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Type_History.Spartan_BR_Type_History>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_BR_Type_History.Spartan_BR_Type_HistoryPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Type_History.Spartan_BR_Type_History>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

