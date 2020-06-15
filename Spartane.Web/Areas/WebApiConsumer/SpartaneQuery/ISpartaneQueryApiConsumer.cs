using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.SpartaneQuery
{
    public interface ISpartaneQueryApiConsumer
    {
        void SetAuthHeader(string token);
        ApiResponse<object> ExecuteQuery(string query);
        ApiResponse<Dictionary<string, string>> ExecuteQueryDictionary(string query);
        ApiResponse<IEnumerable<dtoDictionary>> ExecuteQueryEnumerable(string query);
        ApiResponse<string> ExecuteRawQuery(string query);
        ApiResponse<string> ExecuteQueryTable(string query);
        T ExecuteRawQuery2<T>(string query, params dynamic[] parameters);
    }
    public class dtoDictionary
    {
        public string Clave { get; set; }
        public string Description { get; set; }
    }
}