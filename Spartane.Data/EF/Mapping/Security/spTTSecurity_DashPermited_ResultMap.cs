using System.Data.Entity.ModelConfiguration;
using Spartane.Core.Domain.Binnacle;

namespace Spartane.Data.EF.Mapping.Security
{
    class spTTSecurity_DashPermited_ResultMap: EntityTypeConfiguration<spTTSecurity_DashPermited_Result>
    {
        public spTTSecurity_DashPermited_ResultMap()
        {
            this.HasEntitySetName("spTTSecurity_DashPermited_Result");
            this.HasKey(a => a.idDashBorad);
            this.Ignore(a => a.Id1);
        }
    }
}
