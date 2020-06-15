using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Planes_de_RutinasResources
    {
        //private static IResourceProvider resourceProviderPlanes_de_Rutinas = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Planes_de_RutinasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderPlanes_de_Rutinas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Planes_de_RutinasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderPlanes_de_Rutinas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Planes_de_RutinasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Planes_de_Rutinas</summary>
        public static string Planes_de_Rutinas
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Rutinas.GetResource("Planes_de_Rutinas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Rutinas.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Rutinas.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Rutinas.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Rutinas.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_inicio_del_Plan</summary>
        public static string Fecha_inicio_del_Plan
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Rutinas.GetResource("Fecha_inicio_del_Plan", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_fin_del_Plan</summary>
        public static string Fecha_fin_del_Plan
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Rutinas.GetResource("Fecha_fin_del_Plan", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Semana</summary>
        public static string Semana
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Rutinas.GetResource("Semana", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Paciente</summary>
        public static string Paciente
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Rutinas.GetResource("Paciente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Rutinas</summary>
        public static string Rutinas
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Rutinas.GetResource("Rutinas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Modificado</summary>
        public static string Modificado
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Rutinas.GetResource("Modificado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Rutinas.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Seguimiento_de_Rutina</summary>
        public static string Seguimiento_de_Rutina
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Rutinas.GetResource("Seguimiento_de_Rutina", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderPlanes_de_Rutinas.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
