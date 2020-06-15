using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Planes_AlimenticiosResources
    {
        //private static IResourceProvider resourceProviderDetalle_Planes_Alimenticios = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Planes_AlimenticiosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Planes_Alimenticios = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Planes_AlimenticiosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Planes_Alimenticios = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Planes_AlimenticiosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Planes_Alimenticios</summary>
        public static string Detalle_Planes_Alimenticios
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_Alimenticios.GetResource("Detalle_Planes_Alimenticios", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_Alimenticios.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tiempo_de_Comida</summary>
        public static string Tiempo_de_Comida
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_Alimenticios.GetResource("Tiempo_de_Comida", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_de_Dia</summary>
        public static string Numero_de_Dia
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_Alimenticios.GetResource("Numero_de_Dia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha</summary>
        public static string Fecha
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_Alimenticios.GetResource("Fecha", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Platillo</summary>
        public static string Platillo
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_Alimenticios.GetResource("Platillo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Modificado</summary>
        public static string Modificado
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_Alimenticios.GetResource("Modificado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Planes_Alimenticios.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
