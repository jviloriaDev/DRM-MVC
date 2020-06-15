using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class RutinasResources
    {
        //private static IResourceProvider resourceProviderRutinas = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\RutinasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderRutinas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\RutinasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderRutinas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\RutinasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Rutinas</summary>
        public static string Rutinas
        {
            get
            {
                SetPath();
                return resourceProviderRutinas.GetResource("Rutinas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderRutinas.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderRutinas.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderRutinas.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderRutinas.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_de_la_Rutina</summary>
        public static string Nombre_de_la_Rutina
        {
            get
            {
                SetPath();
                return resourceProviderRutinas.GetResource("Nombre_de_la_Rutina", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion</summary>
        public static string Descripcion
        {
            get
            {
                SetPath();
                return resourceProviderRutinas.GetResource("Descripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Equipamento</summary>
        public static string Equipamento
        {
            get
            {
                SetPath();
                return resourceProviderRutinas.GetResource("Equipamento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Equipamento_alterno</summary>
        public static string Equipamento_alterno
        {
            get
            {
                SetPath();
                return resourceProviderRutinas.GetResource("Equipamento_alterno", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nivel_de_dificultad</summary>
        public static string Nivel_de_dificultad
        {
            get
            {
                SetPath();
                return resourceProviderRutinas.GetResource("Nivel_de_dificultad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Intensidad</summary>
        public static string Intensidad
        {
            get
            {
                SetPath();
                return resourceProviderRutinas.GetResource("Intensidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Duracion_aproximada_minutos</summary>
        public static string Duracion_aproximada_minutos
        {
            get
            {
                SetPath();
                return resourceProviderRutinas.GetResource("Duracion_aproximada_minutos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Genero</summary>
        public static string Genero
        {
            get
            {
                SetPath();
                return resourceProviderRutinas.GetResource("Genero", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderRutinas.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ejercicios</summary>
        public static string Ejercicios
        {
            get
            {
                SetPath();
                return resourceProviderRutinas.GetResource("Ejercicios", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderRutinas.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
