using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Attribute_Control_TypeResources
    {
        //private static IResourceProvider resourceProviderSpartan_Attribute_Control_Type = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Attribute_Control_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Attribute_Control_Type = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Attribute_Control_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Attribute_Control_Type</summary>
        public static string Spartan_Attribute_Control_Type
        {
            get
            {
                return resourceProviderSpartan_Attribute_Control_Type.GetResource("Spartan_Attribute_Control_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ControlTypeId</summary>
        public static string ControlTypeId
        {
            get
            {
                return resourceProviderSpartan_Attribute_Control_Type.GetResource("ControlTypeId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_Attribute_Control_Type.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
