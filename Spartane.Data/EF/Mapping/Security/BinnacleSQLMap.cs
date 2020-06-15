using System.Data.Entity.ModelConfiguration;
using Spartane.Core.Domain.Binnacle;

namespace Spartane.Data.EF.Mapping.Security
{
    public partial class BinnacleSQLMap : EntityTypeConfiguration<BinnacleSQL>
    {
        public BinnacleSQLMap()
        {
            this.ToTable("TTBitacoraSQL");
            this.HasKey(a => new { a.IdUsuario, a.Folio });
            this.Ignore(a => a.Id1);
        }
    }
}
