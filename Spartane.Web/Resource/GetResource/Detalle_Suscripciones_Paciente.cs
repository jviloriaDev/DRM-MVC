using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Suscripciones_PacienteResources
    {
        //private static IResourceProvider resourceProviderDetalle_Suscripciones_Paciente = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Suscripciones_PacienteResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Suscripciones_Paciente = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Suscripciones_PacienteResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Suscripciones_Paciente = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Suscripciones_PacienteResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Suscripciones_Paciente</summary>
        public static string Detalle_Suscripciones_Paciente
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripciones_Paciente.GetResource("Detalle_Suscripciones_Paciente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripciones_Paciente.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Suscripcion</summary>
        public static string Suscripcion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripciones_Paciente.GetResource("Suscripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_inicio</summary>
        public static string Fecha_de_inicio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripciones_Paciente.GetResource("Fecha_de_inicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_fin</summary>
        public static string Fecha_fin
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripciones_Paciente.GetResource("Fecha_fin", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_de_la_Suscripcion</summary>
        public static string Nombre_de_la_Suscripcion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripciones_Paciente.GetResource("Nombre_de_la_Suscripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Frecuencia_de_Pago</summary>
        public static string Frecuencia_de_Pago
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripciones_Paciente.GetResource("Frecuencia_de_Pago", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Costo</summary>
        public static string Costo
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripciones_Paciente.GetResource("Costo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Suscripciones_Paciente.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Suscripciones_Paciente.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
