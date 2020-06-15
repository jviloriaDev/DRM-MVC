using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Type_Work_Distribution
{
    public interface ISpartan_WorkFlow_Type_Work_DistributionApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution> GetByKey(short Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_DistributionPagingModel> GetByKeyComplete(short Key);
        ApiResponse<bool> Delete(short Key, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Type_Work_DistributionInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int16> Insert(Spartane.Core.Domain.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Type_Work_DistributionInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int16> Update(Spartane.Core.Domain.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_Type_Work_DistributionInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_DistributionPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

