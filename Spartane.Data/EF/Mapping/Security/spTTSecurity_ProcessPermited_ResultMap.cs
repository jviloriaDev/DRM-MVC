using System.Data.Entity.ModelConfiguration;
using Spartane.Core.Domain.Binnacle;

namespace Spartane.Data.EF.Mapping.Security
{
    public partial class spTTSecurity_ProcessPermited_ResultMap : EntityTypeConfiguration<spTTSecurity_ProcessPermited_Result>
    {
        public spTTSecurity_ProcessPermited_ResultMap()
        {
            this.HasEntitySetName("spTTSecurity_ProcessPermited_Result");
            this.HasKey(a => a.IdOperacion);
            this.Ignore(a => a.Id1);
        }
    }
}
