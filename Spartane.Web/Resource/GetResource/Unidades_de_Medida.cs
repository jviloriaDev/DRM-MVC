using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Unidades_de_MedidaResources
    {
        //private static IResourceProvider resourceProviderUnidades_de_Medida = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Unidades_de_MedidaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderUnidades_de_Medida = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Unidades_de_MedidaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderUnidades_de_Medida = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Unidades_de_MedidaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Unidades_de_Medida</summary>
        public static string Unidades_de_Medida
        {
            get
            {
                SetPath();
                return resourceProviderUnidades_de_Medida.GetResource("Unidades_de_Medida", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderUnidades_de_Medida.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Unidad</summary>
        public static string Unidad
        {
            get
            {
                SetPath();
                return resourceProviderUnidades_de_Medida.GetResource("Unidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Abreviacion</summary>
        public static string Abreviacion
        {
            get
            {
                SetPath();
                return resourceProviderUnidades_de_Medida.GetResource("Abreviacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Texto_Singular</summary>
        public static string Texto_Singular
        {
            get
            {
                SetPath();
                return resourceProviderUnidades_de_Medida.GetResource("Texto_Singular", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Texto_Plural</summary>
        public static string Texto_Plural
        {
            get
            {
                SetPath();
                return resourceProviderUnidades_de_Medida.GetResource("Texto_Plural", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderUnidades_de_Medida.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
