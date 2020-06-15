using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class PaisResources
    {
        //private static IResourceProvider resourceProviderPais = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\PaisResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderPais = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\PaisResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderPais = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\PaisResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Pais</summary>
        public static string Pais
        {
            get
            {
                SetPath();
                return resourceProviderPais.GetResource("Pais", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderPais.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_del_Pais</summary>
        public static string Nombre_del_Pais
        {
            get
            {
                SetPath();
                return resourceProviderPais.GetResource("Nombre_del_Pais", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Abreviatura</summary>
        public static string Abreviatura
        {
            get
            {
                SetPath();
                return resourceProviderPais.GetResource("Abreviatura", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Codigo</summary>
        public static string Codigo
        {
            get
            {
                SetPath();
                return resourceProviderPais.GetResource("Codigo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderPais.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
