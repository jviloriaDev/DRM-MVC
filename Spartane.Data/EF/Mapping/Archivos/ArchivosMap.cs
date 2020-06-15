using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Departamento
{
    public partial class ArchivosMap : EntityTypeConfiguration<Spartane.Core.Domain.Archivos.Archivos>
    {
        public ArchivosMap()
        {
            this.ToTable("Archivos");
            this.HasKey(a => a.Clave);
            this.Ignore(a => a.Id1);
        }
    }
}

