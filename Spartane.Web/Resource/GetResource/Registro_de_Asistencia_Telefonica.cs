using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Registro_de_Asistencia_TelefonicaResources
    {
        //private static IResourceProvider resourceProviderRegistro_de_Asistencia_Telefonica = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Registro_de_Asistencia_TelefonicaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderRegistro_de_Asistencia_Telefonica = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Registro_de_Asistencia_TelefonicaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderRegistro_de_Asistencia_Telefonica = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Registro_de_Asistencia_TelefonicaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Registro_de_Asistencia_Telefonica</summary>
        public static string Registro_de_Asistencia_Telefonica
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_de_Asistencia_Telefonica.GetResource("Registro_de_Asistencia_Telefonica", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_de_Asistencia_Telefonica.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_llamada</summary>
        public static string Fecha_de_llamada
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_de_Asistencia_Telefonica.GetResource("Fecha_de_llamada", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_llamada</summary>
        public static string Hora_de_llamada
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_de_Asistencia_Telefonica.GetResource("Hora_de_llamada", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_llama</summary>
        public static string Usuario_que_llama
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_de_Asistencia_Telefonica.GetResource("Usuario_que_llama", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Dispositivo</summary>
        public static string Dispositivo
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_de_Asistencia_Telefonica.GetResource("Dispositivo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_Paciente</summary>
        public static string Nombre_Paciente
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_de_Asistencia_Telefonica.GetResource("Nombre_Paciente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Suscripcion</summary>
        public static string Suscripcion
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_de_Asistencia_Telefonica.GetResource("Suscripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_telefonico_del_Paciente</summary>
        public static string Numero_telefonico_del_Paciente
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_de_Asistencia_Telefonica.GetResource("Numero_telefonico_del_Paciente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Correo_del_Paciente</summary>
        public static string Correo_del_Paciente
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_de_Asistencia_Telefonica.GetResource("Correo_del_Paciente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Telefono_de_Asistencia_marcado</summary>
        public static string Telefono_de_Asistencia_marcado
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_de_Asistencia_Telefonica.GetResource("Telefono_de_Asistencia_marcado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_inicio_de_la_Llamada</summary>
        public static string Hora_inicio_de_la_Llamada
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_de_Asistencia_Telefonica.GetResource("Hora_inicio_de_la_Llamada", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_fin_de_la_Llamada</summary>
        public static string Hora_fin_de_la_Llamada
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_de_Asistencia_Telefonica.GetResource("Hora_fin_de_la_Llamada", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Duracion_minutos</summary>
        public static string Duracion_minutos
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_de_Asistencia_Telefonica.GetResource("Duracion_minutos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Asunto_de_la_Llamada</summary>
        public static string Asunto_de_la_Llamada
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_de_Asistencia_Telefonica.GetResource("Asunto_de_la_Llamada", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Atendio</summary>
        public static string Atendio
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_de_Asistencia_Telefonica.GetResource("Atendio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Comentarios</summary>
        public static string Comentarios
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_de_Asistencia_Telefonica.GetResource("Comentarios", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_de_Asistencia_Telefonica.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderRegistro_de_Asistencia_Telefonica.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
