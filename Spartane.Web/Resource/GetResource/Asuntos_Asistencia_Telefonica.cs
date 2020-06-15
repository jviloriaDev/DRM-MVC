using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Asuntos_Asistencia_TelefonicaResources
    {
        //private static IResourceProvider resourceProviderAsuntos_Asistencia_Telefonica = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Asuntos_Asistencia_TelefonicaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderAsuntos_Asistencia_Telefonica = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Asuntos_Asistencia_TelefonicaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderAsuntos_Asistencia_Telefonica = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Asuntos_Asistencia_TelefonicaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Asuntos_Asistencia_Telefonica</summary>
        public static string Asuntos_Asistencia_Telefonica
        {
            get
            {
                SetPath();
                return resourceProviderAsuntos_Asistencia_Telefonica.GetResource("Asuntos_Asistencia_Telefonica", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderAsuntos_Asistencia_Telefonica.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion</summary>
        public static string Descripcion
        {
            get
            {
                SetPath();
                return resourceProviderAsuntos_Asistencia_Telefonica.GetResource("Descripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderAsuntos_Asistencia_Telefonica.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
