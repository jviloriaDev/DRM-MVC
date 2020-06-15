using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Format_TypeResources
    {
        //private static IResourceProvider resourceProviderSpartan_Format_Type = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Format_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Format_Type = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Format_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Format_Type</summary>
        public static string Spartan_Format_Type
        {
            get
            {
                return resourceProviderSpartan_Format_Type.GetResource("Spartan_Format_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>FormatTypeId</summary>
        public static string FormatTypeId
        {
            get
            {
                return resourceProviderSpartan_Format_Type.GetResource("FormatTypeId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_Format_Type.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
