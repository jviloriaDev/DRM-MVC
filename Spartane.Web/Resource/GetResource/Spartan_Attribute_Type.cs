using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Attribute_TypeResources
    {
        //private static IResourceProvider resourceProviderSpartan_Attribute_Type = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Attribute_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Attribute_Type = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Attribute_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Attribute_Type</summary>
        public static string Spartan_Attribute_Type
        {
            get
            {
                return resourceProviderSpartan_Attribute_Type.GetResource("Spartan_Attribute_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Attribute_Type_Id</summary>
        public static string Attribute_Type_Id
        {
            get
            {
                return resourceProviderSpartan_Attribute_Type.GetResource("Attribute_Type_Id", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_Attribute_Type.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
