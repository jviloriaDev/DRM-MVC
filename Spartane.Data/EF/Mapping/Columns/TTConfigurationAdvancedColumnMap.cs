using System.Data.Entity.ModelConfiguration;
using Spartane.Core.Domain.Columns;

namespace Spartane.Data.EF.Mapping.Columns
{
    public partial class TTConfigurationAdvancedColumnMap : EntityTypeConfiguration<TTConfigurationAdvancedColumn>
    {
        public TTConfigurationAdvancedColumnMap()
        {
            this.ToTable("TTConfigurationAdvancedColumn");
            this.HasKey(a => a.IdConfiguration);
            this.Ignore(a => a.Id1);
                
        }
    }
}
