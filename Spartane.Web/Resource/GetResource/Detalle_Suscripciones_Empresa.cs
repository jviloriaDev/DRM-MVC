using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Suscripciones_EmpresaResources
    {
        //private static IResourceProvider resourceProviderDetalle_Suscripciones_Empresa = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Suscripciones_EmpresaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Suscripciones_Empresa = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Suscripciones_EmpresaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Suscripciones_Empresa = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Suscripciones_EmpresaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Suscripciones_Empresa</summary>
        public static string Detalle_Suscripciones_Empresa
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripciones_Empresa.GetResource("Detalle_Suscripciones_Empresa", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripciones_Empresa.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_de_Beneficiarios</summary>
        public static string Cantidad_de_Beneficiarios
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripciones_Empresa.GetResource("Cantidad_de_Beneficiarios", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Suscripcion</summary>
        public static string Suscripcion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripciones_Empresa.GetResource("Suscripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_inicio</summary>
        public static string Fecha_de_inicio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripciones_Empresa.GetResource("Fecha_de_inicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_Fin</summary>
        public static string Fecha_Fin
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripciones_Empresa.GetResource("Fecha_Fin", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_de_la_Suscripcion</summary>
        public static string Nombre_de_la_Suscripcion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripciones_Empresa.GetResource("Nombre_de_la_Suscripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Frecuencia_de_Pago</summary>
        public static string Frecuencia_de_Pago
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripciones_Empresa.GetResource("Frecuencia_de_Pago", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Costo</summary>
        public static string Costo
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripciones_Empresa.GetResource("Costo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripciones_Empresa.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Suscripciones_Empresa.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
