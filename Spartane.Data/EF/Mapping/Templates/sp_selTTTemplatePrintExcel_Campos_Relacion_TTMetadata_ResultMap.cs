using Spartane.Core.Domain.Templates;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Data.EF.Mapping.Templates
{
    class sp_selTTTemplatePrintExcel_Campos_Relacion_TTMetadata_ResultMap : EntityTypeConfiguration<sp_selTTTemplatePrintExcel_Campos_Relacion_TTMetadata_Result>
    {
        public sp_selTTTemplatePrintExcel_Campos_Relacion_TTMetadata_ResultMap()
        {
            this.HasEntitySetName("sp_selTTTemplatePrintExcel_Campos_Relacion_TTMetadata_Result");
            this.HasKey(a => a.DTID);
            this.Ignore(a => a.Id1);
        }
    }
}
