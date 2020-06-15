using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Report_Field_TypeResources
    {
        //private static IResourceProvider resourceProviderSpartan_Report_Field_Type = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Report_Field_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Report_Field_Type = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Report_Field_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Report_Field_Type</summary>
        public static string Spartan_Report_Field_Type
        {
            get
            {
                return resourceProviderSpartan_Report_Field_Type.GetResource("Spartan_Report_Field_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>FieldTypeId</summary>
        public static string FieldTypeId
        {
            get
            {
                return resourceProviderSpartan_Report_Field_Type.GetResource("FieldTypeId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_Report_Field_Type.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
