using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Nivel_de_IntensidadResources
    {
        //private static IResourceProvider resourceProviderNivel_de_Intensidad = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Nivel_de_IntensidadResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderNivel_de_Intensidad = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Nivel_de_IntensidadResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderNivel_de_Intensidad = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Nivel_de_IntensidadResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Nivel_de_Intensidad</summary>
        public static string Nivel_de_Intensidad
        {
            get
            {
                SetPath();
                return resourceProviderNivel_de_Intensidad.GetResource("Nivel_de_Intensidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderNivel_de_Intensidad.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Intensidad</summary>
        public static string Intensidad
        {
            get
            {
                SetPath();
                return resourceProviderNivel_de_Intensidad.GetResource("Intensidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderNivel_de_Intensidad.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
