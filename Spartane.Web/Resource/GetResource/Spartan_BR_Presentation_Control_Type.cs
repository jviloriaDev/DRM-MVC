using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_Presentation_Control_TypeResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Presentation_Control_Type = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_Presentation_Control_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Presentation_Control_Type = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Presentation_Control_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_BR_Presentation_Control_Type</summary>
        public static string Spartan_BR_Presentation_Control_Type
        {
            get
            {
                return resourceProviderSpartan_BR_Presentation_Control_Type.GetResource("Spartan_BR_Presentation_Control_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>PresentationControlTypeId</summary>
        public static string PresentationControlTypeId
        {
            get
            {
                return resourceProviderSpartan_BR_Presentation_Control_Type.GetResource("PresentationControlTypeId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_BR_Presentation_Control_Type.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
