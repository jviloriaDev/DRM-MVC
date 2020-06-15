using Spartane.Core.Domain.Filters;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Data.EF.Mapping.Filters
{
    public partial class sp_SelTTFiltro_Relacion_TTProceso_ResultMap : EntityTypeConfiguration<sp_SelTTFiltro_Relacion_TTProceso_Result>
    {
        public sp_SelTTFiltro_Relacion_TTProceso_ResultMap()
        {
            this.HasEntitySetName("sp_SelTTFiltro_Relacion_TTProceso_Result");
            this.HasKey(a => a.IdProceso);
            this.Ignore(a => a.Id1);
        }
    }
}
