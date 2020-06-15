using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Registro_en_Actividad_EventoResources
    {
        //private static IResourceProvider resourceProviderDetalle_Registro_en_Actividad_Evento = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Registro_en_Actividad_EventoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Registro_en_Actividad_Evento = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Registro_en_Actividad_EventoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Registro_en_Actividad_Evento = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Registro_en_Actividad_EventoResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Registro_en_Actividad_Evento</summary>
        public static string Detalle_Registro_en_Actividad_Evento
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Registro_en_Actividad_Evento.GetResource("Detalle_Registro_en_Actividad_Evento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Registro_en_Actividad_Evento.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Actividad</summary>
        public static string Actividad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Registro_en_Actividad_Evento.GetResource("Actividad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha</summary>
        public static string Fecha
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Registro_en_Actividad_Evento.GetResource("Fecha", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Horario</summary>
        public static string Horario
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Registro_en_Actividad_Evento.GetResource("Horario", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Es_para_un_familiar</summary>
        public static string Es_para_un_familiar
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Registro_en_Actividad_Evento.GetResource("Es_para_un_familiar", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_de_Empleado</summary>
        public static string Numero_de_Empleado
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Registro_en_Actividad_Evento.GetResource("Numero_de_Empleado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombres</summary>
        public static string Nombres
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Registro_en_Actividad_Evento.GetResource("Nombres", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Apellido_Paterno</summary>
        public static string Apellido_Paterno
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Registro_en_Actividad_Evento.GetResource("Apellido_Paterno", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Apellido_Materno</summary>
        public static string Apellido_Materno
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Registro_en_Actividad_Evento.GetResource("Apellido_Materno", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_Completo</summary>
        public static string Nombre_Completo
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Registro_en_Actividad_Evento.GetResource("Nombre_Completo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Parentesco</summary>
        public static string Parentesco
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Registro_en_Actividad_Evento.GetResource("Parentesco", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Sexo</summary>
        public static string Sexo
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Registro_en_Actividad_Evento.GetResource("Sexo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_nacimiento</summary>
        public static string Fecha_de_nacimiento
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Registro_en_Actividad_Evento.GetResource("Fecha_de_nacimiento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus_de_la_Reservacion</summary>
        public static string Estatus_de_la_Reservacion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Registro_en_Actividad_Evento.GetResource("Estatus_de_la_Reservacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Codigo_Reservacion</summary>
        public static string Codigo_Reservacion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Registro_en_Actividad_Evento.GetResource("Codigo_Reservacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Registro_en_Actividad_Evento.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
