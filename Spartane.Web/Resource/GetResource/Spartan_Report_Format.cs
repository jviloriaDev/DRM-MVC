using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Report_FormatResources
    {
        //private static IResourceProvider resourceProviderSpartan_Report_Format = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Report_FormatResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Report_Format = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Report_FormatResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Report_Format</summary>
        public static string Spartan_Report_Format
        {
            get
            {
                return resourceProviderSpartan_Report_Format.GetResource("Spartan_Report_Format", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>FormatId</summary>
        public static string FormatId
        {
            get
            {
                return resourceProviderSpartan_Report_Format.GetResource("FormatId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_Report_Format.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Format_Mask</summary>
        public static string Format_Mask
        {
            get
            {
                return resourceProviderSpartan_Report_Format.GetResource("Format_Mask", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
