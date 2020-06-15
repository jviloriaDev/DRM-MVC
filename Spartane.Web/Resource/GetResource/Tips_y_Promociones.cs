using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Tips_y_PromocionesResources
    {
        //private static IResourceProvider resourceProviderTips_y_Promociones = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Tips_y_PromocionesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderTips_y_Promociones = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Tips_y_PromocionesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderTips_y_Promociones = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Tips_y_PromocionesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Tips_y_Promociones</summary>
        public static string Tips_y_Promociones
        {
            get
            {
                SetPath();
                return resourceProviderTips_y_Promociones.GetResource("Tips_y_Promociones", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderTips_y_Promociones.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_registro</summary>
        public static string Fecha_de_registro
        {
            get
            {
                SetPath();
                return resourceProviderTips_y_Promociones.GetResource("Fecha_de_registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderTips_y_Promociones.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderTips_y_Promociones.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre</summary>
        public static string Nombre
        {
            get
            {
                SetPath();
                return resourceProviderTips_y_Promociones.GetResource("Nombre", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion_Corta</summary>
        public static string Descripcion_Corta
        {
            get
            {
                SetPath();
                return resourceProviderTips_y_Promociones.GetResource("Descripcion_Corta", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion_Larga</summary>
        public static string Descripcion_Larga
        {
            get
            {
                SetPath();
                return resourceProviderTips_y_Promociones.GetResource("Descripcion_Larga", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Imagen</summary>
        public static string Imagen
        {
            get
            {
                SetPath();
                return resourceProviderTips_y_Promociones.GetResource("Imagen", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_inicio_de_Vigencia</summary>
        public static string Fecha_inicio_de_Vigencia
        {
            get
            {
                SetPath();
                return resourceProviderTips_y_Promociones.GetResource("Fecha_inicio_de_Vigencia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_fin_de_Vigencia</summary>
        public static string Fecha_fin_de_Vigencia
        {
            get
            {
                SetPath();
                return resourceProviderTips_y_Promociones.GetResource("Fecha_fin_de_Vigencia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Especialidad</summary>
        public static string Especialidad
        {
            get
            {
                SetPath();
                return resourceProviderTips_y_Promociones.GetResource("Especialidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Especialista</summary>
        public static string Especialista
        {
            get
            {
                SetPath();
                return resourceProviderTips_y_Promociones.GetResource("Especialista", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Vendedor</summary>
        public static string Vendedor
        {
            get
            {
                SetPath();
                return resourceProviderTips_y_Promociones.GetResource("Vendedor", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderTips_y_Promociones.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderTips_y_Promociones.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
