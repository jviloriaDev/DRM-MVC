using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Caracteristicas_platilloResources
    {
        //private static IResourceProvider resourceProviderCaracteristicas_platillo = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Caracteristicas_platilloResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderCaracteristicas_platillo = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Caracteristicas_platilloResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderCaracteristicas_platillo = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Caracteristicas_platilloResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Caracteristicas_platillo</summary>
        public static string Caracteristicas_platillo
        {
            get
            {
                SetPath();
                return resourceProviderCaracteristicas_platillo.GetResource("Caracteristicas_platillo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderCaracteristicas_platillo.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Caracteristicas</summary>
        public static string Caracteristicas
        {
            get
            {
                SetPath();
                return resourceProviderCaracteristicas_platillo.GetResource("Caracteristicas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderCaracteristicas_platillo.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
