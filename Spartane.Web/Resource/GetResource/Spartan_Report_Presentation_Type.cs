using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Report_Presentation_TypeResources
    {
        //private static IResourceProvider resourceProviderSpartan_Report_Presentation_Type = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Report_Presentation_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Report_Presentation_Type = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Report_Presentation_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Report_Presentation_Type</summary>
        public static string Spartan_Report_Presentation_Type
        {
            get
            {
                return resourceProviderSpartan_Report_Presentation_Type.GetResource("Spartan_Report_Presentation_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>PresentationTypeId</summary>
        public static string PresentationTypeId
        {
            get
            {
                return resourceProviderSpartan_Report_Presentation_Type.GetResource("PresentationTypeId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_Report_Presentation_Type.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
