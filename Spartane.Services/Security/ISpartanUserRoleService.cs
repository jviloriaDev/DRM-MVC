using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Security;
using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Security
{
    public interface ISpartanUserRoleService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
    }
}
