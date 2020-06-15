using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.WebApiConsumer
{
    public static class ApiUrlManager
    {
        static ApiUrlManager()
        {
            _baseUrl = Convert.ToString(ConfigurationManager.AppSettings["BaseUrl"]);
            _baseUrlLocal = Convert.ToString(ConfigurationManager.AppSettings["BaseUrlLocal"]);
            //test code
            //_baseUrl = _baseUrlLocal;
        }
        //Base url of service
        private static string _baseUrl;
        private static string _baseUrlLocal;
        public static string BaseUrl { get { return _baseUrl; } }
        public static string BaseUrlLocal { get { return _baseUrlLocal; } }
    }
}
