using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Traduction_Object_TypeResources
    {
        //private static IResourceProvider resourceProviderSpartan_Traduction_Object_Type = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Traduction_Object_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Traduction_Object_Type = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Traduction_Object_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Traduction_Object_Type</summary>
        public static string Spartan_Traduction_Object_Type
        {
            get
            {
                return resourceProviderSpartan_Traduction_Object_Type.GetResource("Spartan_Traduction_Object_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>IdType</summary>
        public static string IdType
        {
            get
            {
                return resourceProviderSpartan_Traduction_Object_Type.GetResource("IdType", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Object_Type_Description</summary>
        public static string Object_Type_Description
        {
            get
            {
                return resourceProviderSpartan_Traduction_Object_Type.GetResource("Object_Type_Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        /// <summary>Datos Generales</summary>
        public static string TabDatos_Generales
        {
            get
            {
                return resourceProviderSpartan_Traduction_Object_Type.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

    }
}
