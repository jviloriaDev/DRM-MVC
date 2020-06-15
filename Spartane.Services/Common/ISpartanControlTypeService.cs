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
    public interface ISpartanControlTypeService
    {
        Int32 SelCount();
        IList<Spartan_Control_Type> SelAll(Boolean ConRelaciones);
        IList<Spartan_Control_Type> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartan_Control_Type GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartan_Control_Type entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartan_Control_Type entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
    }
}
