using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Traduction_ProcessResources
    {
        //private static IResourceProvider resourceProviderSpartan_Traduction_Process = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Traduction_ProcessResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Traduction_Process = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Traduction_ProcessResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_Traduction_Process = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Traduction_ProcessResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_Traduction_Process</summary>
        public static string Spartan_Traduction_Process
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process.GetResource("Spartan_Traduction_Process", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>IdTraduction</summary>
        public static string IdTraduction
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process.GetResource("IdTraduction", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Spartan_Traduction_Process_Data</summary>
        public static string Spartan_Traduction_Process_Data
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process.GetResource("Spartan_Traduction_Process_Data", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>LanguageT</summary>
        public static string LanguageT
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process.GetResource("LanguageT", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Object_Type</summary>
        public static string Object_Type
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process.GetResource("Object_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ObjectT</summary>
        public static string ObjectT
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process.GetResource("ObjectT", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Spartan_Traduction_Detail</summary>
        public static string Spartan_Traduction_Detail
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process.GetResource("Spartan_Traduction_Detail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Spartan_Traduction_Workflow</summary>
        public static string Spartan_Traduction_Workflow
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Traduction_Process.GetResource("Spartan_Traduction_Workflow", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderSpartan_Traduction_Process.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
