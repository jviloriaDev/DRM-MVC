using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Pantalla_FranciscoResources
    {
        //private static IResourceProvider resourceProviderPantalla_Francisco = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Pantalla_FranciscoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderPantalla_Francisco = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Pantalla_FranciscoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderPantalla_Francisco = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Pantalla_FranciscoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Pantalla_Francisco</summary>
        public static string Pantalla_Francisco
        {
            get
            {
                SetPath();
                return resourceProviderPantalla_Francisco.GetResource("Pantalla_Francisco", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderPantalla_Francisco.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Campo</summary>
        public static string Campo
        {
            get
            {
                SetPath();
                return resourceProviderPantalla_Francisco.GetResource("Campo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderPantalla_Francisco.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
