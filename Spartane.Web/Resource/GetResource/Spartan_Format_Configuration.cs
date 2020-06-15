using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Format_ConfigurationResources
    {
        //private static IResourceProvider resourceProviderSpartan_Format_Configuration = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Format_ConfigurationResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Format_Configuration = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Format_ConfigurationResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Format_Configuration</summary>
        public static string Spartan_Format_Configuration
        {
            get
            {
                return resourceProviderSpartan_Format_Configuration.GetResource("Spartan_Format_Configuration", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Format</summary>
        public static string Format
        {
            get
            {
                return resourceProviderSpartan_Format_Configuration.GetResource("Format", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Query_To_Fill_Fields</summary>
        public static string Query_To_Fill_Fields
        {
            get
            {
                return resourceProviderSpartan_Format_Configuration.GetResource("Query_To_Fill_Fields", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Filter_to_Show</summary>
        public static string Filter_to_Show
        {
            get
            {
                return resourceProviderSpartan_Format_Configuration.GetResource("Filter_to_Show", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
