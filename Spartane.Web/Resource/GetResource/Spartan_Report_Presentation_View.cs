using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Report_Presentation_ViewResources
    {
        //private static IResourceProvider resourceProviderSpartan_Report_Presentation_View = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Report_Presentation_ViewResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Report_Presentation_View = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Report_Presentation_ViewResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Report_Presentation_View</summary>
        public static string Spartan_Report_Presentation_View
        {
            get
            {
                return resourceProviderSpartan_Report_Presentation_View.GetResource("Spartan_Report_Presentation_View", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>PresentationViewId</summary>
        public static string PresentationViewId
        {
            get
            {
                return resourceProviderSpartan_Report_Presentation_View.GetResource("PresentationViewId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_Report_Presentation_View.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Presentation_Type</summary>
        public static string Presentation_Type
        {
            get
            {
                return resourceProviderSpartan_Report_Presentation_View.GetResource("Presentation_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
