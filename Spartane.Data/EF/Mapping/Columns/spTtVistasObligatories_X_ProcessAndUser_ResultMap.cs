using Spartane.Core.Domain.Columns;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Data.EF.Mapping.Columns
{
    public class spTtVistasObligatories_X_ProcessAndUser_ResultMap : EntityTypeConfiguration<spTtVistasObligatories_X_ProcessAndUser_Result>
    {
        public spTtVistasObligatories_X_ProcessAndUser_ResultMap()
        {
            this.HasEntitySetName("spTtVistasObligatories_X_ProcessAndUser_Result");
            this.HasKey(a => a.VistaID);
            this.Ignore(a => a.Id1);
        }
    }
}
