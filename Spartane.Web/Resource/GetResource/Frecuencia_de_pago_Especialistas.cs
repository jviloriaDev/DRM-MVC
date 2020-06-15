using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Frecuencia_de_pago_EspecialistasResources
    {
        //private static IResourceProvider resourceProviderFrecuencia_de_pago_Especialistas = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Frecuencia_de_pago_EspecialistasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderFrecuencia_de_pago_Especialistas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Frecuencia_de_pago_EspecialistasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderFrecuencia_de_pago_Especialistas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Frecuencia_de_pago_EspecialistasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Frecuencia_de_pago_Especialistas</summary>
        public static string Frecuencia_de_pago_Especialistas
        {
            get
            {
                SetPath();
                return resourceProviderFrecuencia_de_pago_Especialistas.GetResource("Frecuencia_de_pago_Especialistas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderFrecuencia_de_pago_Especialistas.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre</summary>
        public static string Nombre
        {
            get
            {
                SetPath();
                return resourceProviderFrecuencia_de_pago_Especialistas.GetResource("Nombre", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderFrecuencia_de_pago_Especialistas.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
