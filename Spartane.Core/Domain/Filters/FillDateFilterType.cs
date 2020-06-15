using System;
using System.Collections.Generic;

namespace Spartane.Core.Domain.Filters
{
    public partial class FillDateFilterType : FiltersProperties
    {
        public Nullable<DateTime> From { get; set; }
        public Nullable<DateTime> To   { get; set; }
    }
}
