using System.Data.Entity.ModelConfiguration;
using Spartane.Core.Domain.Binnacle;


namespace Spartane.Data.EF.Mapping.Security
{
    public partial class ModulesDataMap: EntityTypeConfiguration<ModulesData>
    {
         public ModulesDataMap()
        {
            this.ToTable("TTModulo");
            this.HasKey(a => a.IdModulo);
            this.Ignore(a => a.Id1);
        }
    }
}
