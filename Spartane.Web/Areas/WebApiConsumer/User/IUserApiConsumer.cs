//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Spartane.Core.Domain.Data;
//using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
//using Spartane.Core.Domain.User;

//namespace Spartane.Web.Areas.WebApiConsumer
//{
//    public interface IUserApiConsumer
//    {
//        void SetAuthHeader(string token);

//        Int32 SelCount();
//        //Start Modificacion SB
//        ApiResponse<IList<Spartane.Core.Domain.User.Spartan_UserObject>> SelAll(Boolean ConRelaciones);
//        //End Modificacion SB
//        ApiResponse<IList<Spartane.Core.Domain.User.Spartan_UserObject>> SelAllObject(Boolean ConRelaciones);
//        ApiResponse<Spartane.Core.Domain.Spartan_User.Spartan_UserPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
//        /// <summary>
//        /// Validate User
//        /// </summary>
//        /// <param name="startRowindex"></param>
//        /// <param name="maximumrows"></param>
//        /// <param name="WhereCondition"></param>
//        /// <returns></returns>
//        ApiResponse<Spartan_User_Core> ValidateUser(int startRowindex, int maximumrows, string WhereCondition);
        
//        /// <summary>
//        /// Update User Entity
//        /// </summary>
//        /// <param name="entity"></param>
//        /// <returns></returns>
//        ApiResponse<int> Update(Core.Domain.User.SpartanUser entity);
//    }
//}
