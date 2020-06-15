using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Condition
{
    public interface ISpartan_WorkFlow_ConditionApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition> GetByKey(short Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_ConditionPagingModel> GetByKeyComplete(short Key);
        ApiResponse<bool> Delete(short Key, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_ConditionInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int16> Insert(Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_ConditionInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int16> Update(Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_ConditionInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_ConditionPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Condition.Spartan_WorkFlow_Condition>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

