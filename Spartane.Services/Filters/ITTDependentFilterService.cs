using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Filters;
using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Filters
{
    public partial interface ITTDependentFilterService
    {
        Int32 SelCount();
        IList<TTDependentFilter> SelAll(Boolean ConRelaciones);
        IList<TTDependentFilter> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Int32 CurrentPosicion(int? Key);
        TTDependentFilter GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(TTDependentFilter entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(TTDependentFilter entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Boolean ValidaExistencia(int? Key);
        void FillDataIdFiltro(Object ctr);
        void FillDataDT(Object ctr);
        void FillDataDT(Object ctr, int Key);
    }
}
