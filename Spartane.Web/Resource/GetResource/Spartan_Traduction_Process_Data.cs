using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Traduction_Process_DataResources
    {
        //private static IResourceProvider resourceProviderSpartan_Traduction_Process_Data = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Traduction_Process_DataResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Traduction_Process_Data = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Traduction_Process_DataResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_Traduction_Process_Data = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Traduction_Process_DataResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_Traduction_Process_Data</summary>
        public static string Spartan_Traduction_Process_Data
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process_Data.GetResource("Spartan_Traduction_Process_Data", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process_Data.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Concept</summary>
        public static string Concept
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process_Data.GetResource("Concept", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Name_of_Control</summary>
        public static string Name_of_Control
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process_Data.GetResource("Name_of_Control", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Original_Text</summary>
        public static string Original_Text
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process_Data.GetResource("Original_Text", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Translated_Text</summary>
        public static string Translated_Text
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process_Data.GetResource("Translated_Text", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderSpartan_Traduction_Process_Data.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
