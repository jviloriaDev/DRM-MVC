using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Traduction_Concept_TypeResources
    {
        //private static IResourceProvider resourceProviderSpartan_Traduction_Concept_Type = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Traduction_Concept_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Traduction_Concept_Type = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Traduction_Concept_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Traduction_Concept_Type</summary>
        public static string Spartan_Traduction_Concept_Type
        {
            get
            {
                return resourceProviderSpartan_Traduction_Concept_Type.GetResource("Spartan_Traduction_Concept_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>IdConcept</summary>
        public static string IdConcept
        {
            get
            {
                return resourceProviderSpartan_Traduction_Concept_Type.GetResource("IdConcept", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Concept_Description</summary>
        public static string Concept_Description
        {
            get
            {
                return resourceProviderSpartan_Traduction_Concept_Type.GetResource("Concept_Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        /// <summary>Datos Generales</summary>
        public static string TabDatos_Generales
        {
            get
            {
                return resourceProviderSpartan_Traduction_Concept_Type.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

    }
}
