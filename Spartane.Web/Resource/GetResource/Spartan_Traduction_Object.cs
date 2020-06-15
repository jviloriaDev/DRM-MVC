using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Traduction_ObjectResources
    {
        //private static IResourceProvider resourceProviderSpartan_Traduction_Object = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Traduction_ObjectResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Traduction_Object = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Traduction_ObjectResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Traduction_Object</summary>
        public static string Spartan_Traduction_Object
        {
            get
            {
                return resourceProviderSpartan_Traduction_Object.GetResource("Spartan_Traduction_Object", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>IdObject</summary>
        public static string IdObject
        {
            get
            {
                return resourceProviderSpartan_Traduction_Object.GetResource("IdObject", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Object_Description</summary>
        public static string Object_Description
        {
            get
            {
                return resourceProviderSpartan_Traduction_Object.GetResource("Object_Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Object_Type</summary>
        public static string Object_Type
        {
            get
            {
                return resourceProviderSpartan_Traduction_Object.GetResource("Object_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        /// <summary>Datos Generales</summary>
        public static string TabDatos_Generales
        {
            get
            {
                return resourceProviderSpartan_Traduction_Object.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

    }
}
