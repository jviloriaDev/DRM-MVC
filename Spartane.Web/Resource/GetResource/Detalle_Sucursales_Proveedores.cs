using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Sucursales_ProveedoresResources
    {
        //private static IResourceProvider resourceProviderDetalle_Sucursales_Proveedores = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Sucursales_ProveedoresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Sucursales_Proveedores = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Sucursales_ProveedoresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Sucursales_Proveedores = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Sucursales_ProveedoresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Sucursales_Proveedores</summary>
        public static string Detalle_Sucursales_Proveedores
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Sucursales_Proveedores.GetResource("Detalle_Sucursales_Proveedores", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Sucursales_Proveedores.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Sucursal</summary>
        public static string Tipo_de_Sucursal
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Sucursales_Proveedores.GetResource("Tipo_de_Sucursal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Email</summary>
        public static string Email
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Sucursales_Proveedores.GetResource("Email", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Telefono</summary>
        public static string Telefono
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Sucursales_Proveedores.GetResource("Telefono", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Calle</summary>
        public static string Calle
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Sucursales_Proveedores.GetResource("Calle", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_exterior</summary>
        public static string Numero_exterior
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Sucursales_Proveedores.GetResource("Numero_exterior", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_interior</summary>
        public static string Numero_interior
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Sucursales_Proveedores.GetResource("Numero_interior", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Colonia</summary>
        public static string Colonia
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Sucursales_Proveedores.GetResource("Colonia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>C_P_</summary>
        public static string C_P_
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Sucursales_Proveedores.GetResource("C_P_", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ciudad</summary>
        public static string Ciudad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Sucursales_Proveedores.GetResource("Ciudad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estado</summary>
        public static string Estado
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Sucursales_Proveedores.GetResource("Estado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pais</summary>
        public static string Pais
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Sucursales_Proveedores.GetResource("Pais", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Sucursales_Proveedores.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
