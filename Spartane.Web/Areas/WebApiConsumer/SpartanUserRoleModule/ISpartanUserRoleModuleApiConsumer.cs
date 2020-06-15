using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
using Spartane.Core.Domain.Data;


namespace Spartane.Web.Areas.WebApiConsumer.SpartanUserRoleModule
{
   public interface ISpartanUserRoleModuleApiConsumer
    {

        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule> GetByKey(int? Key, Boolean ConRelaciones);
        ApiResponse<bool> Delete(int? Key,int SpartanUserRole,Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        //IList<Spartane.Core.Domain.UserRole.UserRole> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.SpartaneUserRoleModule.SpartaneUserRolePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.SpartaneUserRoleModule.SpartaneUserRoleModule>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
