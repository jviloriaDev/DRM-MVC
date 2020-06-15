using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Planes_de_Suscripcion_ProveedoresResources
    {
        //private static IResourceProvider resourceProviderPlanes_de_Suscripcion_Proveedores = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Planes_de_Suscripcion_ProveedoresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderPlanes_de_Suscripcion_Proveedores = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Planes_de_Suscripcion_ProveedoresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderPlanes_de_Suscripcion_Proveedores = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Planes_de_Suscripcion_ProveedoresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Planes_de_Suscripcion_Proveedores</summary>
        public static string Planes_de_Suscripcion_Proveedores
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion_Proveedores.GetResource("Planes_de_Suscripcion_Proveedores", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion_Proveedores.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion</summary>
        public static string Descripcion
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion_Proveedores.GetResource("Descripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderPlanes_de_Suscripcion_Proveedores.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
