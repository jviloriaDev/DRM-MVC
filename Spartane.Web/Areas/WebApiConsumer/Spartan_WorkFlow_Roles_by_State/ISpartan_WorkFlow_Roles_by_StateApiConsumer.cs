using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Roles_by_State
{
    public interface ISpartan_WorkFlow_Roles_by_StateApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_StatePagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Roles_by_StateInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Roles_by_StateInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Roles_by_StateInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_StatePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow_Roles_by_State>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

