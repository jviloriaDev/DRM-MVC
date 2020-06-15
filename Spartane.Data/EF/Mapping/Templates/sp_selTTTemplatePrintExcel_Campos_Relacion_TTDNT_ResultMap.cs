using Spartane.Core.Domain.Templates;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Data.EF.Mapping.Templates
{
    public partial class sp_selTTTemplatePrintExcel_Campos_Relacion_TTDNT_ResultMap : EntityTypeConfiguration<sp_selTTTemplatePrintExcel_Campos_Relacion_TTDNT_Result>
    {
        public sp_selTTTemplatePrintExcel_Campos_Relacion_TTDNT_ResultMap()
        {
            this.HasEntitySetName("sp_selTTTemplatePrintExcel_Campos_Relacion_TTDNT_Result");
            this.HasKey(a => a.DNTID);
            this.Ignore(a => a.Id1);
        }
    }
}
