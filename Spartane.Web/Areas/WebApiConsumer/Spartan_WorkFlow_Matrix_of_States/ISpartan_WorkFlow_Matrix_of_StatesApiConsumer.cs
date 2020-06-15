using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Matrix_of_States
{
    public interface ISpartan_WorkFlow_Matrix_of_StatesApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_StatesPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Matrix_of_StatesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Matrix_of_StatesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Matrix_of_StatesInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_StatesPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow_Matrix_of_States>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

