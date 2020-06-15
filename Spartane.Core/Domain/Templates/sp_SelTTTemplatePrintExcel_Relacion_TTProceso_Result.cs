using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Templates
{
    public partial class sp_SelTTTemplatePrintExcel_Relacion_TTProceso_Result : BaseEntity
    {
        public int IdProceso { get; set; }
        public string Nombre { get; set; }
    }
}
