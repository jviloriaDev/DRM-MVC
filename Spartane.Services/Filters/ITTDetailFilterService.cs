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
    public partial interface ITTDetailFilterService
    {
        Int32 SelCount();
        IList<TTDetailFilter> SelAll(Boolean ConRelaciones);
        IList<TTDetailFilter> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        TTDetailFilter GetByKey(String Key, Boolean ConRelaciones);
        bool Delete(String Key, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        String Insert(TTDetailFilter entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        String Update(TTDetailFilter entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Boolean ValidaExistencia(String Key);
        void FillDataIdTTFiltro(Object ctr);
        void FillDataFolio(Object ctr);
        void FillDataDNTFiltro(Object ctr);
        void FillDataDt_Filtro(Object ctr);
        void FillDataDt_Filtro(Object ctr, int Key);
        void FillDataMes(Object ctr);
        void FillDataSi_No(Object ctr);
        void FillDataCondicionTexto(Object ctr);
    }
}
