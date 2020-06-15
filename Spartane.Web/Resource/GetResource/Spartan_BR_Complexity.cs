using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_ComplexityResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Complexity = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_ComplexityResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Complexity = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_ComplexityResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_BR_Complexity = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_ComplexityResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_BR_Complexity</summary>
        public static string Spartan_BR_Complexity
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Complexity.GetResource("Spartan_BR_Complexity", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Key_Complexity</summary>
        public static string Key_Complexity
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Complexity.GetResource("Key_Complexity", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Complexity.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderSpartan_BR_Complexity.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
