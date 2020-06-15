using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class EmpresasResources
    {
        //private static IResourceProvider resourceProviderEmpresas = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\EmpresasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderEmpresas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\EmpresasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderEmpresas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\EmpresasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Empresas</summary>
        public static string Empresas
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Empresas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_de_la_Empresa</summary>
        public static string Nombre_de_la_Empresa
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Nombre_de_la_Empresa", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Empresa</summary>
        public static string Tipo_de_Empresa
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Tipo_de_Empresa", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Email</summary>
        public static string Email
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Email", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Telefono</summary>
        public static string Telefono
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Telefono", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Calle</summary>
        public static string Calle
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Calle", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_exterior</summary>
        public static string Numero_exterior
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Numero_exterior", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_interior</summary>
        public static string Numero_interior
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Numero_interior", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Colonia</summary>
        public static string Colonia
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Colonia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>CP</summary>
        public static string CP
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("CP", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ciudad</summary>
        public static string Ciudad
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Ciudad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estado</summary>
        public static string Estado
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Estado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pais</summary>
        public static string Pais
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Pais", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Contactos</summary>
        public static string Contactos
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Contactos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Regimen_Fiscal</summary>
        public static string Regimen_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Regimen_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_o_Razon_Social</summary>
        public static string Nombre_o_Razon_Social
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Nombre_o_Razon_Social", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>RFC</summary>
        public static string RFC
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("RFC", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Calle_Fiscal</summary>
        public static string Calle_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Calle_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_exterior_Fiscal</summary>
        public static string Numero_exterior_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Numero_exterior_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_interior_Fiscal</summary>
        public static string Numero_interior_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Numero_interior_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Colonia_Fiscal</summary>
        public static string Colonia_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Colonia_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>CP_Fiscal</summary>
        public static string CP_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("CP_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ciudad_Fiscal</summary>
        public static string Ciudad_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Ciudad_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estado_Fiscal</summary>
        public static string Estado_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Estado_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pais_Fiscal</summary>
        public static string Pais_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Pais_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Telefono_Fiscal</summary>
        public static string Telefono_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Telefono_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fax</summary>
        public static string Fax
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Fax", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombres_del_Representante_Legal</summary>
        public static string Nombres_del_Representante_Legal
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Nombres_del_Representante_Legal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Apellido_Paterno_del_Representante_Legal</summary>
        public static string Apellido_Paterno_del_Representante_Legal
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Apellido_Paterno_del_Representante_Legal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Apellido_Materno_del_Representante_Legal</summary>
        public static string Apellido_Materno_del_Representante_Legal
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Apellido_Materno_del_Representante_Legal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_Completo_del_Representante_Legal</summary>
        public static string Nombre_Completo_del_Representante_Legal
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Nombre_Completo_del_Representante_Legal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Suscripciones</summary>
        public static string Suscripciones
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Suscripciones", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pagos</summary>
        public static string Pagos
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Pagos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Beneficiarios</summary>
        public static string Beneficiarios
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Beneficiarios", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cedula_Fiscal</summary>
        public static string Cedula_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Cedula_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Contratos</summary>
        public static string Contratos
        {
            get
            {
                SetPath();
                return resourceProviderEmpresas.GetResource("Contratos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderEmpresas.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Datos de Contacto</summary>	public static string TabDatos_de_Contacto 	{		get		{			SetPath();  			return resourceProviderEmpresas.GetResource("TabDatos_de_Contacto", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Datos Fiscales</summary>	public static string TabDatos_Fiscales 	{		get		{			SetPath();  			return resourceProviderEmpresas.GetResource("TabDatos_Fiscales", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Suscripción</summary>	public static string TabSuscripcion 	{		get		{			SetPath();  			return resourceProviderEmpresas.GetResource("TabSuscripcion", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Documentación</summary>	public static string TabDocumentacion 	{		get		{			SetPath();  			return resourceProviderEmpresas.GetResource("TabDocumentacion", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
