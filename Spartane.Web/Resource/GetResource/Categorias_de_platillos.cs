using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Categorias_de_platillosResources
    {
        //private static IResourceProvider resourceProviderCategorias_de_platillos = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Categorias_de_platillosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderCategorias_de_platillos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Categorias_de_platillosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderCategorias_de_platillos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Categorias_de_platillosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Categorias_de_platillos</summary>
        public static string Categorias_de_platillos
        {
            get
            {
                SetPath();
                return resourceProviderCategorias_de_platillos.GetResource("Categorias_de_platillos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderCategorias_de_platillos.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Categoria</summary>
        public static string Categoria
        {
            get
            {
                SetPath();
                return resourceProviderCategorias_de_platillos.GetResource("Categoria", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderCategorias_de_platillos.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
