using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Cantidad_fraccion_platillosResources
    {
        //private static IResourceProvider resourceProviderCantidad_fraccion_platillos = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Cantidad_fraccion_platillosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderCantidad_fraccion_platillos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Cantidad_fraccion_platillosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderCantidad_fraccion_platillos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Cantidad_fraccion_platillosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Cantidad_fraccion_platillos</summary>
        public static string Cantidad_fraccion_platillos
        {
            get
            {
                SetPath();
                return resourceProviderCantidad_fraccion_platillos.GetResource("Cantidad_fraccion_platillos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderCantidad_fraccion_platillos.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad</summary>
        public static string Cantidad
        {
            get
            {
                SetPath();
                return resourceProviderCantidad_fraccion_platillos.GetResource("Cantidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderCantidad_fraccion_platillos.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
