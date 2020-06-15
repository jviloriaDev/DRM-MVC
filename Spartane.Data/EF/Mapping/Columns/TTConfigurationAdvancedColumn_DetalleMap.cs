using System.Data.Entity.ModelConfiguration;
using Spartane.Core.Domain.Columns;

namespace Spartane.Data.EF.Mapping.Columns
{
    public partial class TTConfigurationAdvancedColumn_DetalleMap : EntityTypeConfiguration<TTConfigurationAdvancedColumn_Detalle>
    {
        public TTConfigurationAdvancedColumn_DetalleMap()
        {
            this.ToTable("TTConfigurationAdvancedColumn_Detalle");
            this.HasKey(a => a.IdConfiguration);
            this.HasKey(a => a.IdConfiguraionDetalle);
            this.Ignore(a => a.Id1);
        }
    }
}
