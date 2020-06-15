using System;
using System.Collections.Generic;

namespace Spartane.Core.Domain.Filters
{
    public partial class TTFilter:BaseEntity
    {
        public int IdFiltro { get; set; }
        public Nullable<short> ProcesoID { get; set; }
        public Nullable<int> Filtro_Detalle { get; set; }
    }
}
