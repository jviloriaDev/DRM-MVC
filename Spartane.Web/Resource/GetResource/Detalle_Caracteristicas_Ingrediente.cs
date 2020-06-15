using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Caracteristicas_IngredienteResources
    {
        //private static IResourceProvider resourceProviderDetalle_Caracteristicas_Ingrediente = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Caracteristicas_IngredienteResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Caracteristicas_Ingrediente = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Caracteristicas_IngredienteResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Caracteristicas_Ingrediente = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Caracteristicas_IngredienteResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Caracteristicas_Ingrediente</summary>
        public static string Detalle_Caracteristicas_Ingrediente
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Caracteristicas_Ingrediente.GetResource("Detalle_Caracteristicas_Ingrediente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Caracteristicas_Ingrediente.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Caracteristica_combo</summary>
        public static string Caracteristica_combo
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Caracteristicas_Ingrediente.GetResource("Caracteristica_combo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion_texto</summary>
        public static string Descripcion_texto
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Caracteristicas_Ingrediente.GetResource("Descripcion_texto", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Caracteristicas_Ingrediente.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
