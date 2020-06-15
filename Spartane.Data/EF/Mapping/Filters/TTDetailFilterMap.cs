using System.Data.Entity.ModelConfiguration;
using Spartane.Core.Domain.Filters;

namespace Spartane.Data.EF.Mapping.Filters
{
    public partial class TTDetailFilterMap : EntityTypeConfiguration<TTDetailFilter>
    {
        public TTDetailFilterMap()
        {
            this.ToTable("TTFiltro_Detalle");
            this.HasKey(a => new { a.Folio, a.IdTTFiltro });
            this.Ignore(a => a.Id1);
        }
    }
}
