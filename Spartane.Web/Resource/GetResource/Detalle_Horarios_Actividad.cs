using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Horarios_ActividadResources
    {
        //private static IResourceProvider resourceProviderDetalle_Horarios_Actividad = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Horarios_ActividadResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Horarios_Actividad = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Horarios_ActividadResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Horarios_Actividad = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Horarios_ActividadResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Horarios_Actividad</summary>
        public static string Detalle_Horarios_Actividad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Horarios_Actividad.GetResource("Detalle_Horarios_Actividad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Horarios_Actividad.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Reservada</summary>
        public static string Reservada
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Horarios_Actividad.GetResource("Reservada", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_de_Cita</summary>
        public static string Numero_de_Cita
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Horarios_Actividad.GetResource("Numero_de_Cita", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_inicio</summary>
        public static string Hora_inicio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Horarios_Actividad.GetResource("Hora_inicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_fin</summary>
        public static string Hora_fin
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Horarios_Actividad.GetResource("Hora_fin", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Horario</summary>
        public static string Horario
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Horarios_Actividad.GetResource("Horario", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Codigo_de_Reservacion</summary>
        public static string Codigo_de_Reservacion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Horarios_Actividad.GetResource("Codigo_de_Reservacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_de_Empleado</summary>
        public static string Numero_de_Empleado
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Horarios_Actividad.GetResource("Numero_de_Empleado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Familiar_del_Empleado</summary>
        public static string Familiar_del_Empleado
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Horarios_Actividad.GetResource("Familiar_del_Empleado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_Completo</summary>
        public static string Nombre_Completo
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Horarios_Actividad.GetResource("Nombre_Completo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Parentesco_con_el_Empleado</summary>
        public static string Parentesco_con_el_Empleado
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Horarios_Actividad.GetResource("Parentesco_con_el_Empleado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Sexo</summary>
        public static string Sexo
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Horarios_Actividad.GetResource("Sexo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Edad</summary>
        public static string Edad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Horarios_Actividad.GetResource("Edad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus_de_la_Reservacion</summary>
        public static string Estatus_de_la_Reservacion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Horarios_Actividad.GetResource("Estatus_de_la_Reservacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Asistio</summary>
        public static string Asistio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Horarios_Actividad.GetResource("Asistio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Horarios_Actividad.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
