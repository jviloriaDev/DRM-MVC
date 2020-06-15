using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Duracion_de_Planes_de_SuscripcionResources
    {
        //private static IResourceProvider resourceProviderDuracion_de_Planes_de_Suscripcion = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Duracion_de_Planes_de_SuscripcionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDuracion_de_Planes_de_Suscripcion = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Duracion_de_Planes_de_SuscripcionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDuracion_de_Planes_de_Suscripcion = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Duracion_de_Planes_de_SuscripcionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Duracion_de_Planes_de_Suscripcion</summary>
        public static string Duracion_de_Planes_de_Suscripcion
        {
            get
            {
                SetPath();
                return resourceProviderDuracion_de_Planes_de_Suscripcion.GetResource("Duracion_de_Planes_de_Suscripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderDuracion_de_Planes_de_Suscripcion.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre</summary>
        public static string Nombre
        {
            get
            {
                SetPath();
                return resourceProviderDuracion_de_Planes_de_Suscripcion.GetResource("Nombre", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_en_Meses</summary>
        public static string Cantidad_en_Meses
        {
            get
            {
                SetPath();
                return resourceProviderDuracion_de_Planes_de_Suscripcion.GetResource("Cantidad_en_Meses", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_en_Dias</summary>
        public static string Cantidad_en_Dias
        {
            get
            {
                SetPath();
                return resourceProviderDuracion_de_Planes_de_Suscripcion.GetResource("Cantidad_en_Dias", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDuracion_de_Planes_de_Suscripcion.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
