using System.Data.Entity.ModelConfiguration;
using Spartane.Core.Domain.User;

namespace Spartane.Data.EF.Mapping.User
{
    public partial class TTUsuarioMap : EntityTypeConfiguration<TTUsuario>
    {
        public TTUsuarioMap()
        {
            this.ToTable("TTUsuarios");
            this.HasKey(a => a.IdUsuario);
            this.Ignore(a => a.Id1);
        }
    }
}
