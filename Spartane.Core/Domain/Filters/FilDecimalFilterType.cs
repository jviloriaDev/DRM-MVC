using System;
using System.Collections.Generic;

namespace Spartane.Core.Domain.Filters
{
    public partial class FilDecimalFilterType : FiltersProperties
    {
        public Nullable<Decimal> From { get; set; }
        public Nullable<Decimal> To { get; set; }
    }
}
