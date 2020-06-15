using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Columns
{
    public partial class sp_selTTConfigurationAdvancedColumn_Relacion_TTProceso_Result : BaseEntity
    {
        public int IdProceso { get; set; }
        public string Nombre { get; set; }
    }
}
