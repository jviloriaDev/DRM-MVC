using System;
using System.Collections.Generic;

namespace Spartane.Core.Domain.Filters
{
    public partial class DependentFilterType : FiltersProperties
    {
        public ICollection<string> DependentList { get; set;}
    }
}
