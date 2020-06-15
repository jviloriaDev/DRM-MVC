using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_PlatillosResources
    {
        //private static IResourceProvider resourceProviderDetalle_Platillos = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_PlatillosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Platillos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_PlatillosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Platillos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_PlatillosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Platillos</summary>
        public static string Detalle_Platillos
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Platillos.GetResource("Detalle_Platillos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Platillos.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Lleva_fracciones</summary>
        public static string Lleva_fracciones
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Platillos.GetResource("Lleva_fracciones", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad</summary>
        public static string Cantidad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Platillos.GetResource("Cantidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_fraccion</summary>
        public static string Cantidad_fraccion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Platillos.GetResource("Cantidad_fraccion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Unidad</summary>
        public static string Unidad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Platillos.GetResource("Unidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ingrediente</summary>
        public static string Ingrediente
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Platillos.GetResource("Ingrediente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Caracteristica</summary>
        public static string Caracteristica
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Platillos.GetResource("Caracteristica", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Unidad_SMAE</summary>
        public static string Unidad_SMAE
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Platillos.GetResource("Unidad_SMAE", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Equivalente_Unidad_SMAE</summary>
        public static string Equivalente_Unidad_SMAE
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Platillos.GetResource("Equivalente_Unidad_SMAE", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Porciones</summary>
        public static string Porciones
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Platillos.GetResource("Porciones", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Detalle</summary>
        public static string Detalle
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Platillos.GetResource("Detalle", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Detalle_Super</summary>
        public static string Detalle_Super
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Platillos.GetResource("Detalle_Super", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Platillos.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
