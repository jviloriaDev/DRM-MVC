using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Spartane.Web.Helpers
{
    public static class ConfigurationProperty
    {
        public static string DateFormat { set; get; }
        public static string DateFormatDatePicker { set; get; }
        public static string BaseDirectoyPhysicalWebApi { set; get; }
        static ConfigurationProperty()
        {
            DateFormat = ConfigurationManager.AppSettings["DateFormat"].ToString();
            DateFormatDatePicker = ConfigurationManager.AppSettings["DateFormatDatePicker"].ToString();
            BaseDirectoyPhysicalWebApi = ConfigurationManager.AppSettings["BaseDirectoyPhysicalWebApi"].ToString();
        }

    }
}