using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Filters
{
    public partial class sp_selTTFiltro_Detalle_Relacion_TTDNT_Result : BaseEntity
    {
        public int DNTID { get; set; }
        public string Nombre_Tabla { get; set; }
    }
}
