using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.WebApiConsumer.SpartaneUserRoleModuleObject
{
   public interface ISpartaneUserRoleModuleObjectApiConsumer
    {
        void SetAuthHeader(string token);

        Int32 SelCount();

        ApiResponse<IList<Spartane.Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>> SelAll(Boolean ConRelaciones);

        ApiResponse<IList<Spartane.Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>> SelAllComplete(Boolean ConRelaciones);

        ApiResponse<Spartane.Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject> GetByKey(int? Key, Boolean ConRelaciones);

        ApiResponse<bool> Delete(int? Key,int spartaneUserRole, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<Int32> Insert(Spartane.Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<Int32> Update(Spartane.Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);

        ApiResponse<IList<Spartane.Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>> SelAll(Boolean ConRelaciones, string Where, string Order);

        ApiResponse<IList<Spartane.Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);

        ApiResponse<Spartane.Core.Domain.SpartanUserRoleModuleObject.SpartaneUserRoleModuleObjectPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);

        ApiResponse<IList<Spartane.Core.Domain.SpartanUserRoleModuleObject.SpartanUserRoleModuleObject>> ListaSelAll(Boolean ConRelaciones, string Where);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_Additional_Menu.Spartan_Additional_Menu>> GetAdditionalMenu(int user_Role_Id, int language_id);
    }
}
