using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class VendedoresResources
    {
        //private static IResourceProvider resourceProviderVendedores = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\VendedoresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderVendedores = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\VendedoresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderVendedores = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\VendedoresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Vendedores</summary>
        public static string Vendedores
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Vendedores", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombres</summary>
        public static string Nombres
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Nombres", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Apellido_Paterno</summary>
        public static string Apellido_Paterno
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Apellido_Paterno", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Apellido_Materno</summary>
        public static string Apellido_Materno
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Apellido_Materno", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_Completo</summary>
        public static string Nombre_Completo
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Nombre_Completo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_de_Usuario</summary>
        public static string Nombre_de_Usuario
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Nombre_de_Usuario", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_Registrado</summary>
        public static string Usuario_Registrado
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Usuario_Registrado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Email</summary>
        public static string Email
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Email", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Celular</summary>
        public static string Celular
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Celular", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_nacimiento</summary>
        public static string Fecha_de_nacimiento
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Fecha_de_nacimiento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pais_de_nacimiento</summary>
        public static string Pais_de_nacimiento
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Pais_de_nacimiento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Entidad_de_nacimiento</summary>
        public static string Entidad_de_nacimiento
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Entidad_de_nacimiento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Sexo</summary>
        public static string Sexo
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Sexo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Codigos_para_Referenciar_Pacientes</summary>
        public static string Codigos_para_Referenciar_Pacientes
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Codigos_para_Referenciar_Pacientes", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Banco</summary>
        public static string Banco
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Banco", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>CLABE_Interbancaria</summary>
        public static string CLABE_Interbancaria
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("CLABE_Interbancaria", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_de_Cuenta</summary>
        public static string Numero_de_Cuenta
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Numero_de_Cuenta", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_del_Titular</summary>
        public static string Nombre_del_Titular
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Nombre_del_Titular", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Facturas</summary>
        public static string Facturas
        {
            get
            {
                SetPath();
                return resourceProviderVendedores.GetResource("Facturas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderVendedores.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Códigos de Referencia</summary>	public static string TabCodigos_de_Referencia 	{		get		{			SetPath();  			return resourceProviderVendedores.GetResource("TabCodigos_de_Referencia", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Datos Bancarios</summary>	public static string TabDatos_Bancarios 	{		get		{			SetPath();  			return resourceProviderVendedores.GetResource("TabDatos_Bancarios", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Facturación</summary>	public static string TabFacturacion 	{		get		{			SetPath();  			return resourceProviderVendedores.GetResource("TabFacturacion", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
