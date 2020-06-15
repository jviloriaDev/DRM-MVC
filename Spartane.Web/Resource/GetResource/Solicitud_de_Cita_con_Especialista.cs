using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Solicitud_de_Cita_con_EspecialistaResources
    {
        //private static IResourceProvider resourceProviderSolicitud_de_Cita_con_Especialista = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Solicitud_de_Cita_con_EspecialistaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSolicitud_de_Cita_con_Especialista = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Solicitud_de_Cita_con_EspecialistaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSolicitud_de_Cita_con_Especialista = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Solicitud_de_Cita_con_EspecialistaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Solicitud_de_Cita_con_Especialista</summary>
        public static string Solicitud_de_Cita_con_Especialista
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Cita_con_Especialista.GetResource("Solicitud_de_Cita_con_Especialista", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Cita_con_Especialista.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_solicitud</summary>
        public static string Fecha_de_solicitud
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Cita_con_Especialista.GetResource("Fecha_de_solicitud", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_solicitud</summary>
        public static string Hora_de_solicitud
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Cita_con_Especialista.GetResource("Hora_de_solicitud", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_solicita</summary>
        public static string Usuario_que_solicita
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Cita_con_Especialista.GetResource("Usuario_que_solicita", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_Completo</summary>
        public static string Nombre_Completo
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Cita_con_Especialista.GetResource("Nombre_Completo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Correo_del_Paciente</summary>
        public static string Correo_del_Paciente
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Cita_con_Especialista.GetResource("Correo_del_Paciente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Celular_del_Paciente</summary>
        public static string Celular_del_Paciente
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Cita_con_Especialista.GetResource("Celular_del_Paciente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Especialista</summary>
        public static string Especialista
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Cita_con_Especialista.GetResource("Especialista", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Correo_del_Especialista</summary>
        public static string Correo_del_Especialista
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Cita_con_Especialista.GetResource("Correo_del_Especialista", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Correo_enviado</summary>
        public static string Correo_enviado
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Cita_con_Especialista.GetResource("Correo_enviado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Retroalimentacion</summary>
        public static string Fecha_de_Retroalimentacion
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Cita_con_Especialista.GetResource("Fecha_de_Retroalimentacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Retroalimentacion</summary>
        public static string Hora_de_Retroalimentacion
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Cita_con_Especialista.GetResource("Hora_de_Retroalimentacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Asististe_a_tu_cita</summary>
        public static string Asististe_a_tu_cita
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Cita_con_Especialista.GetResource("Asististe_a_tu_cita", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Calificacion_Especialista</summary>
        public static string Calificacion_Especialista
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Cita_con_Especialista.GetResource("Calificacion_Especialista", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Motivo_no_concreto_cita</summary>
        public static string Motivo_no_concreto_cita
        {
            get
            {
                SetPath();
                return resourceProviderSolicitud_de_Cita_con_Especialista.GetResource("Motivo_no_concreto_cita", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderSolicitud_de_Cita_con_Especialista.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Solicitud</summary>	public static string TabSolicitud 	{		get		{			SetPath();  			return resourceProviderSolicitud_de_Cita_con_Especialista.GetResource("TabSolicitud", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
