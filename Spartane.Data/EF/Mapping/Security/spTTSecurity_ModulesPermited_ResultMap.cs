using System.Data.Entity.ModelConfiguration;
using Spartane.Core.Domain.Binnacle;

namespace Spartane.Data.EF.Mapping.Security
{
    public partial class spTTSecurity_ModulesPermited_ResultMap : EntityTypeConfiguration<spTTSecurity_ModulesPermited_Result>
    {
        public spTTSecurity_ModulesPermited_ResultMap()
        {
            this.HasEntitySetName("spTTSecurity_ModulesPermited_Result");
            this.HasKey(a => a.IdProceso);
            this.Ignore(a => a.Id1);
            this.Ignore(a => a.Nombre1);
        }
    }
}
