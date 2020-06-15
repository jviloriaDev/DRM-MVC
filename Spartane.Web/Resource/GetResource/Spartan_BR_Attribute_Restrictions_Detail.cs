using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_Attribute_Restrictions_DetailResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Attribute_Restrictions_Detail = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_Attribute_Restrictions_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Attribute_Restrictions_Detail = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Attribute_Restrictions_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_BR_Attribute_Restrictions_Detail</summary>
        public static string Spartan_BR_Attribute_Restrictions_Detail
        {
            get
            {
                return resourceProviderSpartan_BR_Attribute_Restrictions_Detail.GetResource("Spartan_BR_Attribute_Restrictions_Detail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>RestrictionId</summary>
        public static string RestrictionId
        {
            get
            {
                return resourceProviderSpartan_BR_Attribute_Restrictions_Detail.GetResource("RestrictionId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Attribute_Type</summary>
        public static string Attribute_Type
        {
            get
            {
                return resourceProviderSpartan_BR_Attribute_Restrictions_Detail.GetResource("Attribute_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Control_Type</summary>
        public static string Control_Type
        {
            get
            {
                return resourceProviderSpartan_BR_Attribute_Restrictions_Detail.GetResource("Control_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
