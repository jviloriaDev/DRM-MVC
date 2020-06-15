using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Traduction_LanguageResources
    {
        //private static IResourceProvider resourceProviderSpartan_Traduction_Language = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Traduction_LanguageResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Traduction_Language = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Traduction_LanguageResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Traduction_Language</summary>
        public static string Spartan_Traduction_Language
        {
            get
            {
                return resourceProviderSpartan_Traduction_Language.GetResource("Spartan_Traduction_Language", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>IdLanguage</summary>
        public static string IdLanguage
        {
            get
            {
                return resourceProviderSpartan_Traduction_Language.GetResource("IdLanguage", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>LanguageT</summary>
        public static string LanguageT
        {
            get
            {
                return resourceProviderSpartan_Traduction_Language.GetResource("LanguageT", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        /// <summary>Datos Generales</summary>
        public static string TabDatos_Generales
        {
            get
            {
                return resourceProviderSpartan_Traduction_Language.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

    }
}
