using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Planes_de_Suscripcion_EspecialistasResources
    {
        //private static IResourceProvider resourceProviderDetalle_Planes_de_Suscripcion_Especialistas = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Planes_de_Suscripcion_EspecialistasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Planes_de_Suscripcion_Especialistas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Planes_de_Suscripcion_EspecialistasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Planes_de_Suscripcion_Especialistas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Planes_de_Suscripcion_EspecialistasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Planes_de_Suscripcion_Especialistas</summary>
        public static string Detalle_Planes_de_Suscripcion_Especialistas
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_de_Suscripcion_Especialistas.GetResource("Detalle_Planes_de_Suscripcion_Especialistas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_de_Suscripcion_Especialistas.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Plan_de_Suscripcion</summary>
        public static string Plan_de_Suscripcion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_de_Suscripcion_Especialistas.GetResource("Plan_de_Suscripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_inicio</summary>
        public static string Fecha_de_inicio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_de_Suscripcion_Especialistas.GetResource("Fecha_de_inicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_fin</summary>
        public static string Fecha_fin
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_de_Suscripcion_Especialistas.GetResource("Fecha_fin", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Frecuencia_de_Pago</summary>
        public static string Frecuencia_de_Pago
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_de_Suscripcion_Especialistas.GetResource("Frecuencia_de_Pago", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Costo</summary>
        public static string Costo
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_de_Suscripcion_Especialistas.GetResource("Costo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Contrato</summary>
        public static string Contrato
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_de_Suscripcion_Especialistas.GetResource("Contrato", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Firmo_Contrato</summary>
        public static string Firmo_Contrato
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_de_Suscripcion_Especialistas.GetResource("Firmo_Contrato", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Planes_de_Suscripcion_Especialistas.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Planes_de_Suscripcion_Especialistas.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
