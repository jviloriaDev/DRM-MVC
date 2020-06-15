using Spartane.Core.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Data.EF.Mapping.Filters
{
    public partial class sp_selTTFiltro_Detalle_Relacion_TTMetadata_ResultMap : EntityTypeConfiguration<sp_selTTFiltro_Detalle_Relacion_TTMetadata_Result>
    {
        public sp_selTTFiltro_Detalle_Relacion_TTMetadata_ResultMap()
        {
            this.HasEntitySetName("sp_selTTFiltro_Detalle_Relacion_TTMetadata_Result");
            this.HasKey(a => a.DTID);
            this.Ignore(a => a.Id1);
        }
    }
}
