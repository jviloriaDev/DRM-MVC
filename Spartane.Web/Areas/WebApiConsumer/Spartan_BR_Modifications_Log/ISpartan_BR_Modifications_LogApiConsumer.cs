using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Modifications_Log
{
    public interface ISpartan_BR_Modifications_LogApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_LogPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_BR_Modifications_LogInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Modifications_LogInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log entity, Spartane.Core.Domain.User.GlobalData Spartan_BR_Modifications_LogInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_LogPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_BR_Modifications_Log.Spartan_BR_Modifications_Log>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

