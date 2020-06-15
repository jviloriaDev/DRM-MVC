using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phases
{
    public interface ISpartan_WorkFlow_PhasesApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_PhasesPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_PhasesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_PhasesInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases entity, Spartane.Core.Domain.User.GlobalData Spartan_WorkFlow_PhasesInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_PhasesPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

