using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class ProveedoresResources
    {
        //private static IResourceProvider resourceProviderProveedores = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\ProveedoresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderProveedores = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\ProveedoresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderProveedores = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\ProveedoresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Proveedores</summary>
        public static string Proveedores
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Proveedores", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_del_Proveedor</summary>
        public static string Nombre_del_Proveedor
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Nombre_del_Proveedor", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Proveedor</summary>
        public static string Tipo_de_Proveedor
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Tipo_de_Proveedor", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Sucursales</summary>
        public static string Sucursales
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Sucursales", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombres</summary>
        public static string Nombres
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Nombres", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Apellido_Paterno</summary>
        public static string Apellido_Paterno
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Apellido_Paterno", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Apellido_Materno</summary>
        public static string Apellido_Materno
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Apellido_Materno", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_Completo</summary>
        public static string Nombre_Completo
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Nombre_Completo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_de_Usuario</summary>
        public static string Nombre_de_Usuario
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Nombre_de_Usuario", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_Registrado</summary>
        public static string Usuario_Registrado
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Usuario_Registrado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Email</summary>
        public static string Email
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Email", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Celular</summary>
        public static string Celular
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Celular", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Nacimiento</summary>
        public static string Fecha_de_Nacimiento
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Fecha_de_Nacimiento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pais_de_nacimiento</summary>
        public static string Pais_de_nacimiento
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Pais_de_nacimiento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Entidad_de_nacimiento</summary>
        public static string Entidad_de_nacimiento
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Entidad_de_nacimiento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Sexo</summary>
        public static string Sexo
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Sexo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Suscripcion_Red_de_Especialistas</summary>
        public static string Suscripcion_Red_de_Especialistas
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Suscripcion_Red_de_Especialistas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Regimen_Fiscal</summary>
        public static string Regimen_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Regimen_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_o_Razon_Social</summary>
        public static string Nombre_o_Razon_Social
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Nombre_o_Razon_Social", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>RFC</summary>
        public static string RFC
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("RFC", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Calle_Fiscal</summary>
        public static string Calle_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Calle_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_exterior_Fiscal</summary>
        public static string Numero_exterior_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Numero_exterior_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_interior_Fiscal</summary>
        public static string Numero_interior_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Numero_interior_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Colonia_Fiscal</summary>
        public static string Colonia_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Colonia_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>C_P__Fiscal</summary>
        public static string C_P__Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("C_P__Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ciudad_Fiscal</summary>
        public static string Ciudad_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Ciudad_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estado_Fiscal</summary>
        public static string Estado_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Estado_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pais_Fiscal</summary>
        public static string Pais_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Pais_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Telefono</summary>
        public static string Telefono
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Telefono", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fax</summary>
        public static string Fax
        {
            get
            {
                SetPath();
                return resourceProviderProveedores.GetResource("Fax", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderProveedores.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Datos de Contacto</summary>	public static string TabDatos_de_Contacto 	{		get		{			SetPath();  			return resourceProviderProveedores.GetResource("TabDatos_de_Contacto", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Red de Proveedores</summary>	public static string TabRed_de_Proveedores 	{		get		{			SetPath();  			return resourceProviderProveedores.GetResource("TabRed_de_Proveedores", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Datos Fiscales</summary>	public static string TabDatos_Fiscales 	{		get		{			SetPath();  			return resourceProviderProveedores.GetResource("TabDatos_Fiscales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
