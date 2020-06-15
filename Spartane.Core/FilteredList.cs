using System;
using System.Collections.Generic;
using System.Linq;
using SqlLinq;
using System.Reflection;

namespace Spartane.Core
{
    /// <summary>
    /// Filtered list
    /// </summary>
    /// <typeparam name="T">T</typeparam>
    [Serializable]
    public class FilteredList<T> : List<T>, IFilteredList<T>
    {
        public IList<string> QueryFilter { get; private set; }
        public IList<object> InnerObjects { get; private set; }

        public FilteredList(IEnumerable<T> source, List<string> queries, List<object> innerObjects)
        {
            this.QueryFilter = queries;
            this.InnerObjects = innerObjects;

            var results = source;
            for (int i = 0; i < QueryFilter.Count(); i++)
            {
                Type classType = this.GetType();
                if (InnerObjects.Count() > i)
                {
                    MethodInfo infoMethod = classType.GetMethod("ApplyJoinFilter").
                        MakeGenericMethod(new Type[] { (InnerObjects[i]).GetType().GetGenericArguments()[0] });
                    object[] parametros = new object[] { results, InnerObjects[i], QueryFilter[i] };
                    results = infoMethod.Invoke(this, parametros) as IEnumerable<T>;
                }
                else
                {
                    MethodInfo infoMethod = classType.GetMethod("ApplySimpleFilter");
                    object[] parametros = new object[] { results, QueryFilter[i] };
                    results = infoMethod.Invoke(this, parametros) as IEnumerable<T>;
                }
            }
            this.AddRange(results);
        }
        public IEnumerable<T> ApplyJoinFilter<TInner>(IEnumerable<T> source, IEnumerable<TInner> inner, string query)
        {
            return source.Query<T, TInner, T>(query, inner);
        }
        public IEnumerable<T> ApplySimpleFilter(IEnumerable<T> source, string query)
        {
            return source.Query<T>(query);
        }
    }
}
