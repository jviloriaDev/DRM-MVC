using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Interpretacion_distribucion_grasa_corporalResources
    {
        //private static IResourceProvider resourceProviderInterpretacion_distribucion_grasa_corporal = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Interpretacion_distribucion_grasa_corporalResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderInterpretacion_distribucion_grasa_corporal = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Interpretacion_distribucion_grasa_corporalResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderInterpretacion_distribucion_grasa_corporal = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Interpretacion_distribucion_grasa_corporalResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Interpretacion_distribucion_grasa_corporal</summary>
        public static string Interpretacion_distribucion_grasa_corporal
        {
            get
            {
                SetPath();
                return resourceProviderInterpretacion_distribucion_grasa_corporal.GetResource("Interpretacion_distribucion_grasa_corporal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderInterpretacion_distribucion_grasa_corporal.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion</summary>
        public static string Descripcion
        {
            get
            {
                SetPath();
                return resourceProviderInterpretacion_distribucion_grasa_corporal.GetResource("Descripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderInterpretacion_distribucion_grasa_corporal.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
