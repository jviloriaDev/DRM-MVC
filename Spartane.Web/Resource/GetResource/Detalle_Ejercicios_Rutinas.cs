using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Ejercicios_RutinasResources
    {
        //private static IResourceProvider resourceProviderDetalle_Ejercicios_Rutinas = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Ejercicios_RutinasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Ejercicios_Rutinas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Ejercicios_RutinasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Ejercicios_Rutinas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Ejercicios_RutinasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Ejercicios_Rutinas</summary>
        public static string Detalle_Ejercicios_Rutinas
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Ejercicios_Rutinas.GetResource("Detalle_Ejercicios_Rutinas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Ejercicios_Rutinas.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Orden_de_realizacion</summary>
        public static string Orden_de_realizacion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Ejercicios_Rutinas.GetResource("Orden_de_realizacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_de_serie</summary>
        public static string Numero_de_serie
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Ejercicios_Rutinas.GetResource("Numero_de_serie", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ejercicio</summary>
        public static string Ejercicio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Ejercicios_Rutinas.GetResource("Ejercicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_de_Repeticiones</summary>
        public static string Cantidad_de_Repeticiones
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Ejercicios_Rutinas.GetResource("Cantidad_de_Repeticiones", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Ejercicios_Rutinas.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
