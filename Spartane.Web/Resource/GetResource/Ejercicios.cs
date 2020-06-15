using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class EjerciciosResources
    {
        //private static IResourceProvider resourceProviderEjercicios = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\EjerciciosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderEjercicios = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\EjerciciosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderEjercicios = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\EjerciciosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Ejercicios</summary>
        public static string Ejercicios
        {
            get
            {
                SetPath();
                return resourceProviderEjercicios.GetResource("Ejercicios", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderEjercicios.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderEjercicios.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderEjercicios.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderEjercicios.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_del_Ejercicio</summary>
        public static string Nombre_del_Ejercicio
        {
            get
            {
                SetPath();
                return resourceProviderEjercicios.GetResource("Nombre_del_Ejercicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion_del_Ejercicio</summary>
        public static string Descripcion_del_Ejercicio
        {
            get
            {
                SetPath();
                return resourceProviderEjercicios.GetResource("Descripcion_del_Ejercicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Ejercicio</summary>
        public static string Tipo_de_Ejercicio
        {
            get
            {
                SetPath();
                return resourceProviderEjercicios.GetResource("Tipo_de_Ejercicio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nivel_de_dificultad</summary>
        public static string Nivel_de_dificultad
        {
            get
            {
                SetPath();
                return resourceProviderEjercicios.GetResource("Nivel_de_dificultad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Sexo</summary>
        public static string Sexo
        {
            get
            {
                SetPath();
                return resourceProviderEjercicios.GetResource("Sexo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Musculos_trabajados</summary>
        public static string Musculos_trabajados
        {
            get
            {
                SetPath();
                return resourceProviderEjercicios.GetResource("Musculos_trabajados", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Equipamento</summary>
        public static string Equipamento
        {
            get
            {
                SetPath();
                return resourceProviderEjercicios.GetResource("Equipamento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Imagen</summary>
        public static string Imagen
        {
            get
            {
                SetPath();
                return resourceProviderEjercicios.GetResource("Imagen", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Video</summary>
        public static string Video
        {
            get
            {
                SetPath();
                return resourceProviderEjercicios.GetResource("Video", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderEjercicios.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderEjercicios.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
