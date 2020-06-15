using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Planes_AlimenticiosResources
    {
        //private static IResourceProvider resourceProviderPlanes_Alimenticios = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Planes_AlimenticiosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderPlanes_Alimenticios = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Planes_AlimenticiosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderPlanes_Alimenticios = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Planes_AlimenticiosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Planes_Alimenticios</summary>
        public static string Planes_Alimenticios
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_Alimenticios.GetResource("Planes_Alimenticios", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_Alimenticios.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_Alimenticios.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_Alimenticios.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_Alimenticios.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_inicio_del_Plan</summary>
        public static string Fecha_inicio_del_Plan
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_Alimenticios.GetResource("Fecha_inicio_del_Plan", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_fin_del_Plan</summary>
        public static string Fecha_fin_del_Plan
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_Alimenticios.GetResource("Fecha_fin_del_Plan", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Semana</summary>
        public static string Semana
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_Alimenticios.GetResource("Semana", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Paciente</summary>
        public static string Paciente
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_Alimenticios.GetResource("Paciente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_Alimenticios.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Platillos</summary>
        public static string Platillos
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_Alimenticios.GetResource("Platillos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderPlanes_Alimenticios.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
