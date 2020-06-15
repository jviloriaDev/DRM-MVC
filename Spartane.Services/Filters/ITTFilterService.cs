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
    public partial interface ITTFilterService
    {
        Int32 SelCount();
        IList<TTFilter> SelAll(Boolean ConRelaciones);
        IList<TTFilter> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Int32 CurrentPosicion(int? Key);
        TTFilter GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(TTFilter entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(TTFilter entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Boolean ValidaExistencia(int? Key);
        void FillDataProcesoID(Object ctr);
        void FillDataFiltro_Detalle(Object ctr);
        void FillDataFiltro_Dependientes(Object ctr);
        String GenerateLeftJoin();
        String GenerateWhereWithLeftJoin(int? DTIDRelation);
        String GenerateWhereWithLeftJoin(int? DTIDRelation, string ParentAlias);
        String GenerateWhereWithOutLeftJoin(int? DTIDRelation);
        String GenerateWhere();
    }
}
