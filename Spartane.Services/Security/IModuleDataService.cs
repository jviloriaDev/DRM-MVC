using Spartane.Core.Domain.Binnacle;
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
    public interface ISpartanModuleService
    {
        Int32 SelCount();
        IList<Spartan_Module> SelAll(Boolean ConRelaciones);
        IList<Spartan_Module> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartan_Module GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartan_Module entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartan_Module entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
    }
}
