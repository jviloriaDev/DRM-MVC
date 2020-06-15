using System;
using System.Collections.Generic;

namespace Spartane.Core.Domain.Filters
{
    public partial class TTDependentFilter: BaseEntity
    {
        public int IdFiltro { get; set; }
        public int IdFiltro_Dependientes { get; set; }
        public Nullable<int> DT { get; set; }
        public string Valor { get; set; }
    }
}
