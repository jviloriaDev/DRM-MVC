using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Actividades_EventoResources
    {
        //private static IResourceProvider resourceProviderDetalle_Actividades_Evento = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Actividades_EventoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Actividades_Evento = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Actividades_EventoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Actividades_Evento = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Actividades_EventoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Actividades_Evento</summary>
        public static string Detalle_Actividades_Evento
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Actividades_Evento.GetResource("Detalle_Actividades_Evento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Actividades_Evento.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Actividad</summary>
        public static string Tipo_de_Actividad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Actividades_Evento.GetResource("Tipo_de_Actividad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Especialidad</summary>
        public static string Especialidad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Actividades_Evento.GetResource("Especialidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_de_la_Actividad</summary>
        public static string Nombre_de_la_Actividad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Actividades_Evento.GetResource("Nombre_de_la_Actividad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion</summary>
        public static string Descripcion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Actividades_Evento.GetResource("Descripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Quien_imparte</summary>
        public static string Quien_imparte
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Actividades_Evento.GetResource("Quien_imparte", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Dia</summary>
        public static string Dia
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Actividades_Evento.GetResource("Dia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_inicio</summary>
        public static string Hora_inicio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Actividades_Evento.GetResource("Hora_inicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_fin</summary>
        public static string Hora_fin
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Actividades_Evento.GetResource("Hora_fin", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tiene_receso</summary>
        public static string Tiene_receso
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Actividades_Evento.GetResource("Tiene_receso", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_inicio_receso</summary>
        public static string Hora_inicio_receso
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Actividades_Evento.GetResource("Hora_inicio_receso", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_fin_receso</summary>
        public static string Hora_fin_receso
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Actividades_Evento.GetResource("Hora_fin_receso", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Duracion_maxima_por_paciente_mins</summary>
        public static string Duracion_maxima_por_paciente_mins
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Actividades_Evento.GetResource("Duracion_maxima_por_paciente_mins", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cupo_limitado</summary>
        public static string Cupo_limitado
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Actividades_Evento.GetResource("Cupo_limitado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cupo_maximo</summary>
        public static string Cupo_maximo
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Actividades_Evento.GetResource("Cupo_maximo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ubicacion</summary>
        public static string Ubicacion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Actividades_Evento.GetResource("Ubicacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus_de_la_Actividad</summary>
        public static string Estatus_de_la_Actividad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Actividades_Evento.GetResource("Estatus_de_la_Actividad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Actividades_Evento.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
