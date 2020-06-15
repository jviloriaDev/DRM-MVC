using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_de_IngredientesResources
    {
        //private static IResourceProvider resourceProviderDetalle_de_Ingredientes = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_de_IngredientesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_de_Ingredientes = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_de_IngredientesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_de_Ingredientes = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_de_IngredientesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_de_Ingredientes</summary>
        public static string Detalle_de_Ingredientes
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Ingredientes.GetResource("Detalle_de_Ingredientes", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Ingredientes.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad</summary>
        public static string Cantidad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Ingredientes.GetResource("Cantidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Unidad</summary>
        public static string Unidad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Ingredientes.GetResource("Unidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_del_Ingrediente</summary>
        public static string Nombre_del_Ingrediente
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Ingredientes.GetResource("Nombre_del_Ingrediente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_de_presentacion</summary>
        public static string Nombre_de_presentacion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Ingredientes.GetResource("Nombre_de_presentacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_de_Marca</summary>
        public static string Nombre_de_Marca
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Ingredientes.GetResource("Nombre_de_Marca", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_de_Ingredientes.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
