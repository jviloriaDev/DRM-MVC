using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.User
{
    public partial interface ISpartanUserService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Spartan_User.Spartan_User> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Spartan_User.Spartan_User> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Spartan_User.Spartan_User GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Spartan_User.Spartan_User entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Spartan_User.Spartan_User entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
    }
}
