using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Tiempos_de_ComidaResources
    {
        //private static IResourceProvider resourceProviderTiempos_de_Comida = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Tiempos_de_ComidaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderTiempos_de_Comida = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Tiempos_de_ComidaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderTiempos_de_Comida = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Tiempos_de_ComidaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Tiempos_de_Comida</summary>
        public static string Tiempos_de_Comida
        {
            get
            {
                SetPath();
                return resourceProviderTiempos_de_Comida.GetResource("Tiempos_de_Comida", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderTiempos_de_Comida.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Comida</summary>
        public static string Comida
        {
            get
            {
                SetPath();
                return resourceProviderTiempos_de_Comida.GetResource("Comida", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_min</summary>
        public static string Hora_min
        {
            get
            {
                SetPath();
                return resourceProviderTiempos_de_Comida.GetResource("Hora_min", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_max</summary>
        public static string Hora_max
        {
            get
            {
                SetPath();
                return resourceProviderTiempos_de_Comida.GetResource("Hora_max", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pais</summary>
        public static string Pais
        {
            get
            {
                SetPath();
                return resourceProviderTiempos_de_Comida.GetResource("Pais", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderTiempos_de_Comida.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
