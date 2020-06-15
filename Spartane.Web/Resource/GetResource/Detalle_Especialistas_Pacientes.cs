using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Especialistas_PacientesResources
    {
        //private static IResourceProvider resourceProviderDetalle_Especialistas_Pacientes = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Especialistas_PacientesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Especialistas_Pacientes = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Especialistas_PacientesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Especialistas_Pacientes = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Especialistas_PacientesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Especialistas_Pacientes</summary>
        public static string Detalle_Especialistas_Pacientes
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Especialistas_Pacientes.GetResource("Detalle_Especialistas_Pacientes", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Especialistas_Pacientes.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Especialista</summary>
        public static string Especialista
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Especialistas_Pacientes.GetResource("Especialista", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Especialidad</summary>
        public static string Especialidad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Especialistas_Pacientes.GetResource("Especialidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_inicio</summary>
        public static string Fecha_inicio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Especialistas_Pacientes.GetResource("Fecha_inicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_fin</summary>
        public static string Fecha_fin
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Especialistas_Pacientes.GetResource("Fecha_fin", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_consultas</summary>
        public static string Cantidad_consultas
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Especialistas_Pacientes.GetResource("Cantidad_consultas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Principal</summary>
        public static string Principal
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Especialistas_Pacientes.GetResource("Principal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Especialistas_Pacientes.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Especialistas_Pacientes.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
