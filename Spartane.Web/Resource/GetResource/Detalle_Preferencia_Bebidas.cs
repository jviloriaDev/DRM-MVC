using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Preferencia_BebidasResources
    {
        //private static IResourceProvider resourceProviderDetalle_Preferencia_Bebidas = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Preferencia_BebidasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Preferencia_Bebidas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Preferencia_BebidasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Preferencia_Bebidas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Preferencia_BebidasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Preferencia_Bebidas</summary>
        public static string Detalle_Preferencia_Bebidas
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Preferencia_Bebidas.GetResource("Detalle_Preferencia_Bebidas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Preferencia_Bebidas.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Bebida</summary>
        public static string Bebida
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Preferencia_Bebidas.GetResource("Bebida", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad</summary>
        public static string Cantidad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Preferencia_Bebidas.GetResource("Cantidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Preferencia_Bebidas.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
