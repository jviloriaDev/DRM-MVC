using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Suscripcion_Red_de_Especialistas_ProveedoresResources
    {
        //private static IResourceProvider resourceProviderDetalle_Suscripcion_Red_de_Especialistas_Proveedores = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Suscripcion_Red_de_Especialistas_ProveedoresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Suscripcion_Red_de_Especialistas_Proveedores = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Suscripcion_Red_de_Especialistas_ProveedoresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Suscripcion_Red_de_Especialistas_Proveedores = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Suscripcion_Red_de_Especialistas_ProveedoresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Suscripcion_Red_de_Especialistas_Proveedores</summary>
        public static string Detalle_Suscripcion_Red_de_Especialistas_Proveedores
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripcion_Red_de_Especialistas_Proveedores.GetResource("Detalle_Suscripcion_Red_de_Especialistas_Proveedores", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripcion_Red_de_Especialistas_Proveedores.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Plan_de_Suscripcion</summary>
        public static string Plan_de_Suscripcion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripcion_Red_de_Especialistas_Proveedores.GetResource("Plan_de_Suscripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_inicio</summary>
        public static string Fecha_inicio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripcion_Red_de_Especialistas_Proveedores.GetResource("Fecha_inicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_fin</summary>
        public static string Fecha_fin
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripcion_Red_de_Especialistas_Proveedores.GetResource("Fecha_fin", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Costo</summary>
        public static string Costo
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripcion_Red_de_Especialistas_Proveedores.GetResource("Costo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Contrato</summary>
        public static string Contrato
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripcion_Red_de_Especialistas_Proveedores.GetResource("Contrato", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Firmo_Contrato</summary>
        public static string Firmo_Contrato
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripcion_Red_de_Especialistas_Proveedores.GetResource("Firmo_Contrato", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripcion_Red_de_Especialistas_Proveedores.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Suscripcion_Red_de_Especialistas_Proveedores.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
