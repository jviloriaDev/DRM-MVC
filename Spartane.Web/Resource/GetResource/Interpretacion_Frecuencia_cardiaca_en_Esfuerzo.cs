using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Interpretacion_Frecuencia_cardiaca_en_EsfuerzoResources
    {
        //private static IResourceProvider resourceProviderInterpretacion_Frecuencia_cardiaca_en_Esfuerzo = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Interpretacion_Frecuencia_cardiaca_en_EsfuerzoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderInterpretacion_Frecuencia_cardiaca_en_Esfuerzo = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Interpretacion_Frecuencia_cardiaca_en_EsfuerzoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderInterpretacion_Frecuencia_cardiaca_en_Esfuerzo = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Interpretacion_Frecuencia_cardiaca_en_EsfuerzoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Interpretacion_Frecuencia_cardiaca_en_Esfuerzo</summary>
        public static string Interpretacion_Frecuencia_cardiaca_en_Esfuerzo
        {
            get
            {
                SetPath();
                return resourceProviderInterpretacion_Frecuencia_cardiaca_en_Esfuerzo.GetResource("Interpretacion_Frecuencia_cardiaca_en_Esfuerzo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderInterpretacion_Frecuencia_cardiaca_en_Esfuerzo.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion</summary>
        public static string Descripcion
        {
            get
            {
                SetPath();
                return resourceProviderInterpretacion_Frecuencia_cardiaca_en_Esfuerzo.GetResource("Descripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderInterpretacion_Frecuencia_cardiaca_en_Esfuerzo.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
