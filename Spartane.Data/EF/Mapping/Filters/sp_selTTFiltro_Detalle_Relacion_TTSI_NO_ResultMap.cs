using Spartane.Core.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Data.EF.Mapping.Filters
{
    public partial class sp_selTTFiltro_Detalle_Relacion_TTSI_NO_ResultMap : EntityTypeConfiguration<sp_selTTFiltro_Detalle_Relacion_TTSI_NO_Result>
    {
        public sp_selTTFiltro_Detalle_Relacion_TTSI_NO_ResultMap()
        {
            this.HasEntitySetName("sp_selTTFiltro_Detalle_Relacion_TTSI_NO_Result");
            this.HasKey(a => a.IdSI_NO);
            this.Ignore(a => a.Id1);
        }
    }
}
