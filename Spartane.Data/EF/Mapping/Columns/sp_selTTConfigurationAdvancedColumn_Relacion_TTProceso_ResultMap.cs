using Spartane.Core.Domain.Columns;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Data.EF.Mapping.Columns
{
    public class sp_selTTConfigurationAdvancedColumn_Relacion_TTProceso_ResultMap : EntityTypeConfiguration<sp_selTTConfigurationAdvancedColumn_Relacion_TTProceso_Result>
    {
        public sp_selTTConfigurationAdvancedColumn_Relacion_TTProceso_ResultMap()
        {
            this.HasEntitySetName("sp_selTTConfigurationAdvancedColumn_Relacion_TTProceso_Result");
            this.HasKey(a => a.IdProceso);
            this.Ignore(a => a.Id1);
        }
    }
}
