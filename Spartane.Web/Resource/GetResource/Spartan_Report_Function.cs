using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Report_FunctionResources
    {
        //private static IResourceProvider resourceProviderSpartan_Report_Function = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Report_FunctionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Report_Function = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Report_FunctionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Report_Function</summary>
        public static string Spartan_Report_Function
        {
            get
            {
                return resourceProviderSpartan_Report_Function.GetResource("Spartan_Report_Function", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>FunctionId</summary>
        public static string FunctionId
        {
            get
            {
                return resourceProviderSpartan_Report_Function.GetResource("FunctionId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_Report_Function.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
