using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Pagos_PacienteResources
    {
        //private static IResourceProvider resourceProviderDetalle_Pagos_Paciente = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Pagos_PacienteResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Pagos_Paciente = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Pagos_PacienteResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Pagos_Paciente = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Pagos_PacienteResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Pagos_Paciente</summary>
        public static string Detalle_Pagos_Paciente
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Paciente.GetResource("Detalle_Pagos_Paciente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Paciente.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Suscripcion</summary>
        public static string Suscripcion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Paciente.GetResource("Suscripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Concepto_de_Pago</summary>
        public static string Concepto_de_Pago
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Paciente.GetResource("Concepto_de_Pago", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Suscripcion</summary>
        public static string Fecha_de_Suscripcion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Paciente.GetResource("Fecha_de_Suscripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_de_Pago</summary>
        public static string Numero_de_Pago
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Paciente.GetResource("Numero_de_Pago", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>De_Total_de_Pagos</summary>
        public static string De_Total_de_Pagos
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Paciente.GetResource("De_Total_de_Pagos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_Limite_de_Pago</summary>
        public static string Fecha_Limite_de_Pago
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Paciente.GetResource("Fecha_Limite_de_Pago", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Recordatorio_dias</summary>
        public static string Recordatorio_dias
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Paciente.GetResource("Recordatorio_dias", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Forma_de_Pago</summary>
        public static string Forma_de_Pago
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Paciente.GetResource("Forma_de_Pago", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Pago</summary>
        public static string Fecha_de_Pago
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Paciente.GetResource("Fecha_de_Pago", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Pagos_Paciente.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Pagos_Paciente.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
