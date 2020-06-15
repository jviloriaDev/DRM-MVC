using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.SqlModelMapper;
using RestSharp.Extensions.MonoHttp;

namespace Spartane.Web
{
    public static class GridQueryHelper
    {

        public static GridConfiguration GetConfiguration(NameValueCollection request, ISqlPropertyMapper mapper)
        {
            if ((request.Get("sortField") != null))
            {
                var columnName = request.Get("sortField");
                if (mapper != null)
                    columnName = mapper.GetPropertyName(columnName);
                return new GridConfiguration
                 {
                     OrderByClause = " " + columnName + " " +
                                     (request.Get("sortOrder") != null && request.Get("sortOrder") == "asc"
                                         ? "ASC"
                                         : "DESC")
                     ,
                     WhereClause = GetAllFilterDescriptors(request, mapper)
                 };
            }
            return new GridConfiguration
            {
                OrderByClause = "",
                WhereClause = GetUrlCompatibleString(GetAllFilterDescriptors(request, mapper))
            };

        }
        /// <summary>
        /// Used to get the Url Compatible String
        /// </summary>
        /// <param name="urlData"></param>
        /// <returns></returns>
        public static string GetUrlCompatibleString(string urlData)
        {
            return urlData.Replace("%", "%25");
        }


        public static string GetAllFilterDescriptors(NameValueCollection request, ISqlPropertyMapper mapper)
        {
            return GetCurrentQuery(request, mapper);
        }

        /// <summary>
        /// Loop through all the CompositeFilterDescriptor
        /// </summary>
        /// <returns></returns>
        private static string GetCurrentQuery(NameValueCollection request, ISqlPropertyMapper mapper)
        {
            string query = "";
            var keyValue = "";
            foreach (var key in request.Keys)
            {
                keyValue = Convert.ToString(key);
                if (keyValue == "sortOrder" || keyValue == "sortField" || keyValue == "pageIndex" || keyValue == "format" || keyValue == "pageSize" || keyValue == "_" || keyValue == "-")
                    continue;

                var newQuery = mapper.GetOperatorString(request[key.ToString()], key.ToString());
                if (!string.IsNullOrEmpty(newQuery))
                    query += ((query != "") ? " AND " : "") + newQuery;

            }
            return query;

        }


        public static GridConfiguration GetDataTableConfiguration(NameValueCollection request, ISqlPropertyMapper mapper)
        {
            return new GridConfiguration
            {
                OrderByClause = "",
                WhereClause = GetUrlCompatibleString(GetDataTableCurrentQuery(request, mapper))
            };
        }

        private static string GetDataTableCurrentQuery(NameValueCollection request, ISqlPropertyMapper mapper)
        {
            string query = "";
            var keyValue = "";

            
                for (int i = 0; i < request.Keys.Count - 1; i++)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(request["mDataProp_" + i])) && !string.IsNullOrEmpty(Convert.ToString(request["sSearch_" + i])))
                    {
                        keyValue = Convert.ToString(request["mDataProp_" + i]);
                        if (keyValue == "sortOrder" || keyValue == "sortField" || keyValue == "pageIndex" || keyValue == "format" || keyValue == "pageSize" || keyValue == "_" || keyValue == "-")
                            continue;

                        var newQuery = mapper.GetOperatorString(request["sSearch_" + i], Convert.ToString(request["mDataProp_" + i]));
                        if (!string.IsNullOrEmpty(newQuery))
                            query += ((query != "") ? " AND " : "") + newQuery;
                    }
                }           
            return query;

        }
        public static GridConfiguration GetDataTableConfigurationNew(UrlParametersModel param, ISqlPropertyMapper mapper)
        {
            return new GridConfiguration
            {
                OrderByClause = "",
                WhereClause = GetUrlCompatibleString(GetDataTableCurrentQueryNew(param, mapper))
            };
        }

        private static string GetDataTableCurrentQueryNew(UrlParametersModel param, ISqlPropertyMapper mapper)
        {
            NameValueCollection request = HttpUtility.ParseQueryString(param.filters);
            string query = "";
            var keyValue = "";


            for (int i = 1; i < request.Keys.Count; i++)
            {
                if (!string.IsNullOrEmpty(param.columns[i].name))
                {
                    keyValue = Convert.ToString(request[i]);
                    //if (keyValue == "sortOrder" || keyValue == "sortField" || keyValue == "pageIndex" || keyValue == "format" || keyValue == "pageSize" || keyValue == "_" || keyValue == "-")
                    // continue;
                    if (keyValue != "undefined" && keyValue != "on")
                    {
                        var newQuery = mapper.GetOperatorString(keyValue, param.columns[i].name);
                        if (!string.IsNullOrEmpty(newQuery))
                            query += ((query != "") ? " AND " : "") + newQuery;
                    }
                }
            }
            return query;

        }

    }
}
