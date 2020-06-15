using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Planes_de_RutinasResources
    {
        //private static IResourceProvider resourceProviderDetalle_Planes_de_Rutinas = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Planes_de_RutinasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Planes_de_Rutinas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Planes_de_RutinasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Planes_de_Rutinas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Planes_de_RutinasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Planes_de_Rutinas</summary>
        public static string Detalle_Planes_de_Rutinas
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_de_Rutinas.GetResource("Detalle_Planes_de_Rutinas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_de_Rutinas.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_de_Dia</summary>
        public static string Numero_de_Dia
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_de_Rutinas.GetResource("Numero_de_Dia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha</summary>
        public static string Fecha
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_de_Rutinas.GetResource("Fecha", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Realizado</summary>
        public static string Realizado
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_de_Rutinas.GetResource("Realizado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Planes_de_Rutinas.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
