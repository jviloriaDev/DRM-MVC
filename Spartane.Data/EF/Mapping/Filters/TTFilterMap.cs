using System.Data.Entity.ModelConfiguration;
using Spartane.Core.Domain.Filters;


namespace Spartane.Data.EF.Mapping.Filters
{
    public partial class TTFilterMap : EntityTypeConfiguration<TTFilter>
    {
        public TTFilterMap()
        {
            this.ToTable("TTFiltro");
            this.HasKey(a => a.IdFiltro);
            this.Ignore(a => a.Id1);
                
        }
    }
}
