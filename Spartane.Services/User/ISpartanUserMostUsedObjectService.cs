using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.User
{
    public interface ISpartanUserMostUsedObjectService
    {
        Int32 SelCount();
        IList<Spartan_User_Most_Used_Object> SelAll(Boolean ConRelaciones);
        IList<Spartan_User_Most_Used_Object> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartan_User_Most_Used_Object GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartan_User_Most_Used_Object entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartan_User_Most_Used_Object entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
    }
}
