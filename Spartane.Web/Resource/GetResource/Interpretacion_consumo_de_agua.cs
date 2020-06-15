using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Interpretacion_consumo_de_aguaResources
    {
        //private static IResourceProvider resourceProviderInterpretacion_consumo_de_agua = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Interpretacion_consumo_de_aguaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderInterpretacion_consumo_de_agua = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Interpretacion_consumo_de_aguaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderInterpretacion_consumo_de_agua = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Interpretacion_consumo_de_aguaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Interpretacion_consumo_de_agua</summary>
        public static string Interpretacion_consumo_de_agua
        {
            get
            {
                SetPath();
                return resourceProviderInterpretacion_consumo_de_agua.GetResource("Interpretacion_consumo_de_agua", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderInterpretacion_consumo_de_agua.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion</summary>
        public static string Descripcion
        {
            get
            {
                SetPath();
                return resourceProviderInterpretacion_consumo_de_agua.GetResource("Descripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderInterpretacion_consumo_de_agua.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
