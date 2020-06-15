using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Departamento
{
    public partial class TTArchivosMap : EntityTypeConfiguration<Spartane.Core.Domain.TTArchivos.TTArchivos>
    {
        public TTArchivosMap()
        {
            this.ToTable("TTArchivos");
            this.HasKey(a => a.Folio);
            this.Ignore(a => a.Id1);
        }
    }
}

