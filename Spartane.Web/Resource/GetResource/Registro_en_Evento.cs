using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Registro_en_EventoResources
    {
        //private static IResourceProvider resourceProviderRegistro_en_Evento = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Registro_en_EventoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderRegistro_en_Evento = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Registro_en_EventoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderRegistro_en_Evento = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Registro_en_EventoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Registro_en_Evento</summary>
        public static string Registro_en_Evento
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_en_Evento.GetResource("Registro_en_Evento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_en_Evento.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_en_Evento.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_en_Evento.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_en_Evento.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Evento</summary>
        public static string Evento
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_en_Evento.GetResource("Evento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion</summary>
        public static string Descripcion
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_en_Evento.GetResource("Descripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_inicio_del_Evento</summary>
        public static string Fecha_inicio_del_Evento
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_en_Evento.GetResource("Fecha_inicio_del_Evento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_fin_del_Evento</summary>
        public static string Fecha_fin_del_Evento
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_en_Evento.GetResource("Fecha_fin_del_Evento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Lugar</summary>
        public static string Lugar
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_en_Evento.GetResource("Lugar", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Actividades_del_Evento</summary>
        public static string Actividades_del_Evento
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_en_Evento.GetResource("Actividades_del_Evento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Inscripcion_en_Actividades</summary>
        public static string Inscripcion_en_Actividades
        {
            get
            {
                SetPath();
                return resourceProviderRegistro_en_Evento.GetResource("Inscripcion_en_Actividades", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderRegistro_en_Evento.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
