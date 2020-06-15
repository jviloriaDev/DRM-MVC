using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Contactos_EmpresaResources
    {
        //private static IResourceProvider resourceProviderDetalle_Contactos_Empresa = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Contactos_EmpresaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Contactos_Empresa = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Contactos_EmpresaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Contactos_Empresa = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Contactos_EmpresaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Contactos_Empresa</summary>
        public static string Detalle_Contactos_Empresa
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Contactos_Empresa.GetResource("Detalle_Contactos_Empresa", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Contactos_Empresa.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_completo</summary>
        public static string Nombre_completo
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Contactos_Empresa.GetResource("Nombre_completo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Correo</summary>
        public static string Correo
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Contactos_Empresa.GetResource("Correo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Telefono</summary>
        public static string Telefono
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Contactos_Empresa.GetResource("Telefono", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Contacto_Principal</summary>
        public static string Contacto_Principal
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Contactos_Empresa.GetResource("Contacto_Principal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Area</summary>
        public static string Area
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Contactos_Empresa.GetResource("Area", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Acceso_al_Sistema</summary>
        public static string Acceso_al_Sistema
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Contactos_Empresa.GetResource("Acceso_al_Sistema", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_de_usuario</summary>
        public static string Nombre_de_usuario
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Contactos_Empresa.GetResource("Nombre_de_usuario", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Recibe_Alertas</summary>
        public static string Recibe_Alertas
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Contactos_Empresa.GetResource("Recibe_Alertas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Contactos_Empresa.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Contactos_Empresa.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
