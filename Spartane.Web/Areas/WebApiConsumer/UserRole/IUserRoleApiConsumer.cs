//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Spartane.Core.Domain.Data;
//using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

//namespace Spartane.Web.Areas.WebApiConsumer.UserRole
//{
//    public interface IUserRoleApiConsumer
//    {
//        void SetAuthHeader(string token);
//        Int32 SelCount();
//        ApiResponse<IList<Spartane.Core.Domain.UserRole.UserRole>> SelAll(Boolean ConRelaciones);
//        ApiResponse<IList<Spartane.Core.Domain.UserRole.UserRole>> SelAllComplete(Boolean ConRelaciones);
//        ApiResponse<Spartane.Core.Domain.UserRole.UserRole> GetByKey(int? Key, Boolean ConRelaciones);
//        ApiResponse<bool> Delete(int? Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
//        ApiResponse<Int32> Insert(Spartane.Core.Domain.UserRole.UserRole entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
//        ApiResponse<Int32> Update(Spartane.Core.Domain.UserRole.UserRole entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);

//        ApiResponse<IList<Spartane.Core.Domain.UserRole.UserRole>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
//        ApiResponse<IList<Spartane.Core.Domain.UserRole.UserRole>> SelAll(Boolean ConRelaciones, string Where, string Order);
//        ApiResponse<IList<Spartane.Core.Domain.UserRole.UserRole>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
//        //IList<Spartane.Core.Domain.UserRole.UserRole> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
//        ApiResponse<Spartane.Core.Domain.UserRole.UserRolePagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
//        ApiResponse<IList<Spartane.Core.Domain.UserRole.UserRole>> ListaSelAll(Boolean ConRelaciones, string Where);
//    }
//}
