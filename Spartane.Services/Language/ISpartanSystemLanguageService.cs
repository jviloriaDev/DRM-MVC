using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Language;
using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Language
{
    public interface ISpartanSystemLanguageService
    {
        Int32 SelCount();
        IList<Spartan_System_Language> SelAll(Boolean ConRelaciones);
        IList<Spartan_System_Language> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartan_System_Language GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartan_System_Language entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartan_System_Language entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
    }
}
