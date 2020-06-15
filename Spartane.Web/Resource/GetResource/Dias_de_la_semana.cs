using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Dias_de_la_semanaResources
    {
        //private static IResourceProvider resourceProviderDias_de_la_semana = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Dias_de_la_semanaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDias_de_la_semana = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Dias_de_la_semanaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDias_de_la_semana = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Dias_de_la_semanaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Dias_de_la_semana</summary>
        public static string Dias_de_la_semana
        {
            get
            {
                SetPath();
                return resourceProviderDias_de_la_semana.GetResource("Dias_de_la_semana", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderDias_de_la_semana.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Texto</summary>
        public static string Texto
        {
            get
            {
                SetPath();
                return resourceProviderDias_de_la_semana.GetResource("Texto", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Dia</summary>
        public static string Dia
        {
            get
            {
                SetPath();
                return resourceProviderDias_de_la_semana.GetResource("Dia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDias_de_la_semana.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
