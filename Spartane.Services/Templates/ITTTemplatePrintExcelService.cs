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
    public partial interface ITTTemplatePrintExcelService
    {
        Int32 SelCount();
        IList<TTTemplatePrintExcel> SelAll(Boolean ConRelaciones);
        IList<TTTemplatePrintExcel> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Int32 CurrentPosicion(int? Key);
        TTTemplatePrintExcel GetByKey(int? Key, Boolean ConRelaciones);
        bool Delete(int? Key, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(TTTemplatePrintExcel entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(TTTemplatePrintExcel entity, GlobalData UserInformation, DataLayerFieldsBitacora DataReference);
        Boolean ValidaExistencia(int? Key);
        void FillDataProcesoId(Object ctr);
        void FillDataConfiguracionCampos(Object ctr);
        void applyFilterToObject(IList<TTTemplatePrintExcel> filters, TTSearchAdvancedDataDetails tTSearchAdvancedDataDetails, int indexFilter);
        IList<TTSearchAdvancedData> FiltersObligatories(GlobalData GlobalInformation);
        void AddFilterXDT(IList<TTTemplatePrintExcel> filters, string sDTid, Object filter, int indexFilter);
    }
}
