using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Nivel_de_dificultadResources
    {
        //private static IResourceProvider resourceProviderNivel_de_dificultad = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Nivel_de_dificultadResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderNivel_de_dificultad = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Nivel_de_dificultadResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderNivel_de_dificultad = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Nivel_de_dificultadResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Nivel_de_dificultad</summary>
        public static string Nivel_de_dificultad
        {
            get
            {
                SetPath();
                return resourceProviderNivel_de_dificultad.GetResource("Nivel_de_dificultad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderNivel_de_dificultad.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Dificultad</summary>
        public static string Dificultad
        {
            get
            {
                SetPath();
                return resourceProviderNivel_de_dificultad.GetResource("Dificultad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderNivel_de_dificultad.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
