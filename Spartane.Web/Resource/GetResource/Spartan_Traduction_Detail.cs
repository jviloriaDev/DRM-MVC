using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Traduction_DetailResources
    {
        //private static IResourceProvider resourceProviderSpartan_Traduction_Detail = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Traduction_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Traduction_Detail = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Traduction_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        public static void SetPath()
        {
            resourceProviderSpartan_Traduction_Detail = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Traduction_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_Traduction_Detail</summary>
        public static string Spartan_Traduction_Detail
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Detail.GetResource("Spartan_Traduction_Detail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>IdTraductionDetail</summary>
        public static string IdTraductionDetail
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Detail.GetResource("IdTraductionDetail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Concept</summary>
        public static string Concept
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Detail.GetResource("Concept", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>IdConcept</summary>
        public static string IdConcept
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Detail.GetResource("IdConcept", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Original_Text</summary>
        public static string Original_Text
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Detail.GetResource("Original_Text", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Translated_Text</summary>
        public static string Translated_Text
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Detail.GetResource("Translated_Text", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        /// <summary>Datos Generales</summary>
        public static string TabDatos_Generales
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Detail.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

    }
}
