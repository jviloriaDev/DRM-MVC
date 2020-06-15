using System.Data.Entity.ModelConfiguration;
using Spartane.Core.Domain.Templates;

namespace Spartane.Data.EF.Mapping.Templates
{
    public partial class TTTemplatePrintExcelMap : EntityTypeConfiguration<TTTemplatePrintExcel>
    {
        public TTTemplatePrintExcelMap()
        {
            this.ToTable("TTTemplatePrintExcel");
            this.HasKey(a => a.IdTemplate);
            this.Ignore(a => a.Id1);
        }
    }
}
