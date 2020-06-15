using System;
using System.Collections.Generic;

namespace Spartane.Core.Domain.Filters
{
    public partial class StringFilterType : FiltersProperties
    {
        public TypesTextFilter FilterType { get; set; }
        public string Text { get; set; }
    }
}
