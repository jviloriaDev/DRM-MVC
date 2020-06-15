using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.WebApiConsumer.SpartaneUserRoleObjectFunction
{
    public interface ISpartaneUserRoleObjectFunctionApiConsumer
    {
        void SetAuthHeader(string token);

        Int32 SelCount();

        ApiResponse<IList<Spartane.Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>> SelAll(Boolean ConRelaciones);

        ApiResponse<IList<Spartane.Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>> SelAllComplete(Boolean ConRelaciones);

        ApiResponse<Spartane.Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction> GetByKey(int? Key, Boolean ConRelaciones);

        ApiResponse<bool> Delete(int? Key,int SpartanUserRule,Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<Int32> Insert(Spartane.Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<Int32> Update(Spartane.Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);

        ApiResponse<IList<Spartane.Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>> SelAll(Boolean ConRelaciones, string Where, string Order);

        ApiResponse<IList<Spartane.Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);

        ApiResponse<Spartane.Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunctionPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);

        ApiResponse<IList<Spartane.Core.Domain.SpartaneUserRoleObjectFunction.SpartaneUserRoleObjectFunction>> ListaSelAll(Boolean ConRelaciones, string Where);



    }
}
