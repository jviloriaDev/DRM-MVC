using Spartane.Core.Domain.Templates;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Data.EF.Mapping.Templates
{
    public partial class sp_SelTTTemplatePrintExcel_Relacion_TTProceso_ResultMap : EntityTypeConfiguration<sp_SelTTTemplatePrintExcel_Relacion_TTProceso_Result>
    {
        public sp_SelTTTemplatePrintExcel_Relacion_TTProceso_ResultMap()
        {
            this.HasEntitySetName("sp_SelTTTemplatePrintExcel_Relacion_TTProceso_Result");
            this.HasKey(a => a.IdProceso);
            this.Ignore(a => a.Id1);
        }
    }
}
