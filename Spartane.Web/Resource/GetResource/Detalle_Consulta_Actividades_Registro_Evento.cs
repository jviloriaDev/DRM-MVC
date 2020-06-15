using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Consulta_Actividades_Registro_EventoResources
    {
        //private static IResourceProvider resourceProviderDetalle_Consulta_Actividades_Registro_Evento = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Consulta_Actividades_Registro_EventoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Consulta_Actividades_Registro_Evento = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Consulta_Actividades_Registro_EventoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Consulta_Actividades_Registro_Evento = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Consulta_Actividades_Registro_EventoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Consulta_Actividades_Registro_Evento</summary>
        public static string Detalle_Consulta_Actividades_Registro_Evento
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Consulta_Actividades_Registro_Evento.GetResource("Detalle_Consulta_Actividades_Registro_Evento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Consulta_Actividades_Registro_Evento.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Actividad</summary>
        public static string Actividad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Consulta_Actividades_Registro_Evento.GetResource("Actividad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Actividad</summary>
        public static string Tipo_de_Actividad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Consulta_Actividades_Registro_Evento.GetResource("Tipo_de_Actividad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Especialidad</summary>
        public static string Especialidad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Consulta_Actividades_Registro_Evento.GetResource("Especialidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Imparte</summary>
        public static string Imparte
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Consulta_Actividades_Registro_Evento.GetResource("Imparte", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha</summary>
        public static string Fecha
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Consulta_Actividades_Registro_Evento.GetResource("Fecha", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Lugares_disponibles</summary>
        public static string Lugares_disponibles
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Consulta_Actividades_Registro_Evento.GetResource("Lugares_disponibles", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Horarios_disponibles</summary>
        public static string Horarios_disponibles
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Consulta_Actividades_Registro_Evento.GetResource("Horarios_disponibles", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ubicacion</summary>
        public static string Ubicacion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Consulta_Actividades_Registro_Evento.GetResource("Ubicacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Consulta_Actividades_Registro_Evento.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
