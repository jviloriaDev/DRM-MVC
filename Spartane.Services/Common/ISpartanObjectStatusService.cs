using Spartane.Core.Domain.Common;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Common
{
    public interface ISpartanObjectStatusService
    {
        Int32 SelCount();
        IList<Spartan_Object_Status> SelAll(Boolean ConRelaciones);
        IList<Spartan_Object_Status> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartan_Object_Status GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartan_Object_Status entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartan_Object_Status entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
    }
}
