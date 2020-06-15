using System;
using System.Collections.Generic;

namespace Spartane.Core.Domain.Filters
{
    public partial class NumericFilterType: FiltersProperties
    {
        public Nullable<int> From {get; set; }
        public Nullable<int> To {get;set;}
    }
}
