using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Search;
using Spartane.Core.Domain.Templates;
using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Templates
{
    public partial interface ITTTemplatePrintExcelFieldService
    {
        Int32 SelCount();
        IList<TTTemplatePrintExcelField> SelAll(Boolean ConRelaciones);
        IList<TTTemplatePrintExcelField> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Int32 CurrentPosicion(int? Key);
        TTTemplatePrintExcelField GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(TTTemplatePrintExcelField entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(TTTemplatePrintExcelField entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Boolean ValidaExistencia(int? Key);
        void FillDataIdTemplate(Object ctr);
        void FillDataDNTID(Object ctr);
        void FillDataDTID(Object ctr);
        void FillDataDTID(Object ctr, int Key);
        void applyFilterToObject(IList<TTTemplatePrintExcelField> filters, Core.Domain.Search.TTSearchAdvancedDataDetails tTSearchAdvancedDataDetails, int indexFilter);
        IList<TTSearchAdvancedData> FiltersObligatories(GlobalData GlobalInformation);
        void AddFilterXDT(IList<TTTemplatePrintExcelField> filters, string sDTid, Object filter, int indexFilter);
    }
}
