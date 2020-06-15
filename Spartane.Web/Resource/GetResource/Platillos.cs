using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class PlatillosResources
    {
        //private static IResourceProvider resourceProviderPlatillos = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\PlatillosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderPlatillos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\PlatillosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderPlatillos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\PlatillosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Platillos</summary>
        public static string Platillos
        {
            get
            {
                SetPath();
                return resourceProviderPlatillos.GetResource("Platillos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderPlatillos.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderPlatillos.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderPlatillos.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderPlatillos.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_de_Platillo</summary>
        public static string Nombre_de_Platillo
        {
            get
            {
                SetPath();
                return resourceProviderPlatillos.GetResource("Nombre_de_Platillo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Imagen</summary>
        public static string Imagen
        {
            get
            {
                SetPath();
                return resourceProviderPlatillos.GetResource("Imagen", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Calorias</summary>
        public static string Calorias
        {
            get
            {
                SetPath();
                return resourceProviderPlatillos.GetResource("Calorias", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Dificultad</summary>
        public static string Dificultad
        {
            get
            {
                SetPath();
                return resourceProviderPlatillos.GetResource("Dificultad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Categoria_del_Platillo</summary>
        public static string Categoria_del_Platillo
        {
            get
            {
                SetPath();
                return resourceProviderPlatillos.GetResource("Categoria_del_Platillo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tiempo_de_comida</summary>
        public static string Tiempo_de_comida
        {
            get
            {
                SetPath();
                return resourceProviderPlatillos.GetResource("Tiempo_de_comida", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_comida</summary>
        public static string Tipo_de_comida
        {
            get
            {
                SetPath();
                return resourceProviderPlatillos.GetResource("Tipo_de_comida", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Caracteristicas</summary>
        public static string Caracteristicas
        {
            get
            {
                SetPath();
                return resourceProviderPlatillos.GetResource("Caracteristicas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Calificacion</summary>
        public static string Calificacion
        {
            get
            {
                SetPath();
                return resourceProviderPlatillos.GetResource("Calificacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Detalle_Platillos</summary>
        public static string Detalle_Platillos
        {
            get
            {
                SetPath();
                return resourceProviderPlatillos.GetResource("Detalle_Platillos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Detalle_Platillo_MR2</summary>
        public static string Detalle_Platillo_MR2
        {
            get
            {
                SetPath();
                return resourceProviderPlatillos.GetResource("Detalle_Platillo_MR2", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Modo_de_Preparacion</summary>
        public static string Modo_de_Preparacion
        {
            get
            {
                SetPath();
                return resourceProviderPlatillos.GetResource("Modo_de_Preparacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderPlatillos.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
