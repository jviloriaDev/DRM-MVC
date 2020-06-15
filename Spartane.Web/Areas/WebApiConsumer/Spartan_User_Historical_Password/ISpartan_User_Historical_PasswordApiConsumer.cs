using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Spartan_User_Historical_Password
{
    public interface ISpartan_User_Historical_PasswordApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_PasswordPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Spartan_User_Historical_PasswordInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password entity, Spartane.Core.Domain.User.GlobalData Spartan_User_Historical_PasswordInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password entity, Spartane.Core.Domain.User.GlobalData Spartan_User_Historical_PasswordInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_PasswordPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password>> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}

