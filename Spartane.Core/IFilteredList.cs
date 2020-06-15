using System;
using System.Collections.Generic;
using System.Linq;

namespace Spartane.Core
{
    public interface IFilteredList<T> : IList<T>
    {
        IList<string> QueryFilter { get; }
        IList<Object> InnerObjects { get; }
    }
}
