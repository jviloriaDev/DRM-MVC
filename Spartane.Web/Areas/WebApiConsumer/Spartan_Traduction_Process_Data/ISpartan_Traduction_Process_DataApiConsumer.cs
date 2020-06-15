using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Process_Data
{
    public interface ISpartan_Traduction_Process_DataApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_DataPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_Traduction_Process_DataInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data entity, Spartane.Core.Domain.User.GlobalData Spartan_Traduction_Process_DataInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data entity, Spartane.Core.Domain.User.GlobalData Spartan_Traduction_Process_DataInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_DataPagingModel> ListaSelAll(int object_id, int process);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_Traduction_Process_Data.Spartan_Traduction_Process_Data>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

