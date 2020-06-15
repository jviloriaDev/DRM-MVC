using System.Data.Entity.ModelConfiguration;
using Spartane.Core.Domain.Templates;

namespace Spartane.Data.EF.Mapping.Templates
{
    public partial class TTTemplatePrintExcelFieldMap : EntityTypeConfiguration<TTTemplatePrintExcelField>
    {
        public TTTemplatePrintExcelFieldMap()
        {
            this.ToTable("TTTemplatePrintExcel_Campos");
            this.HasKey(a => new { a.IdTemplate, a.Folio});
            this.Ignore(a => a.Id1);
        }
    }
}
