using System.Data.Entity.ModelConfiguration;
using Spartane.Core.Domain.Filters;
using System.ComponentModel.DataAnnotations.Schema;


namespace Spartane.Data.EF.Mapping.Filters
{
    public partial class TTDependentFilterMap : EntityTypeConfiguration<TTDependentFilter>
    {
        public TTDependentFilterMap()
        {
            this.ToTable("TTFiltro_Dependientes");
            this.HasKey(a => new { a.IdFiltro, a.IdFiltro_Dependientes });
            this.Property(e => e.IdFiltro_Dependientes).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Ignore(a => a.Id1);
        }
    }
}
