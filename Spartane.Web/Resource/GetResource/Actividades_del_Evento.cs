using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Actividades_del_EventoResources
    {
        //private static IResourceProvider resourceProviderActividades_del_Evento = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Actividades_del_EventoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderActividades_del_Evento = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Actividades_del_EventoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderActividades_del_Evento = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Actividades_del_EventoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Actividades_del_Evento</summary>
        public static string Actividades_del_Evento
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Actividades_del_Evento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Evento</summary>
        public static string Evento
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Evento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Actividad</summary>
        public static string Actividad
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Actividad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion</summary>
        public static string Descripcion
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Descripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Dia</summary>
        public static string Dia
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Dia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_inicio</summary>
        public static string Hora_inicio
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Hora_inicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_fin</summary>
        public static string Hora_fin
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Hora_fin", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tiene_receso</summary>
        public static string Tiene_receso
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Tiene_receso", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_inicio_receso</summary>
        public static string Hora_inicio_receso
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Hora_inicio_receso", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_fin_receso</summary>
        public static string Hora_fin_receso
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Hora_fin_receso", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ubicacion</summary>
        public static string Ubicacion
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Ubicacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Actividad</summary>
        public static string Tipo_de_Actividad
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Tipo_de_Actividad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Quien_imparte</summary>
        public static string Quien_imparte
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Quien_imparte", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Especialidad</summary>
        public static string Especialidad
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Especialidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cupo_limitado</summary>
        public static string Cupo_limitado
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Cupo_limitado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cupo_maximo</summary>
        public static string Cupo_maximo
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Cupo_maximo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Duracion_maxima_por_Paciente_mins</summary>
        public static string Duracion_maxima_por_Paciente_mins
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Duracion_maxima_por_Paciente_mins", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Horarios</summary>
        public static string Horarios
        {
            get
            {
                SetPath();
                return resourceProviderActividades_del_Evento.GetResource("Horarios", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderActividades_del_Evento.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Agenda</summary>	public static string TabAgenda 	{		get		{			SetPath();  			return resourceProviderActividades_del_Evento.GetResource("TabAgenda", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
