using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class MedicosResources
    {
        //private static IResourceProvider resourceProviderMedicos = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\MedicosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderMedicos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MedicosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderMedicos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MedicosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Medicos</summary>
        public static string Medicos
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Medicos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Titulo_Personal</summary>
        public static string Titulo_Personal
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Titulo_Personal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombres</summary>
        public static string Nombres
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Nombres", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Apellido_Paterno</summary>
        public static string Apellido_Paterno
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Apellido_Paterno", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Apellido_Materno</summary>
        public static string Apellido_Materno
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Apellido_Materno", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_Completo</summary>
        public static string Nombre_Completo
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Nombre_Completo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Especialista</summary>
        public static string Tipo_de_Especialista
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Tipo_de_Especialista", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Foto</summary>
        public static string Foto
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Foto", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_de_usuario</summary>
        public static string Nombre_de_usuario
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Nombre_de_usuario", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_Registrado</summary>
        public static string Usuario_Registrado
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Usuario_Registrado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Email</summary>
        public static string Email
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Email", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Celular</summary>
        public static string Celular
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Celular", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_nacimiento</summary>
        public static string Fecha_de_nacimiento
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Fecha_de_nacimiento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pais_de_nacimiento</summary>
        public static string Pais_de_nacimiento
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Pais_de_nacimiento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Entidad_de_nacimiento</summary>
        public static string Entidad_de_nacimiento
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Entidad_de_nacimiento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Sexo</summary>
        public static string Sexo
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Sexo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Email_institucional</summary>
        public static string Email_institucional
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Email_institucional", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Email_ppal_publico</summary>
        public static string Email_ppal_publico
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Email_ppal_publico", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Email_de_contacto</summary>
        public static string Email_de_contacto
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Email_de_contacto", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Calle</summary>
        public static string Calle
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Calle", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_exterior</summary>
        public static string Numero_exterior
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Numero_exterior", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_interior</summary>
        public static string Numero_interior
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Numero_interior", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Colonia</summary>
        public static string Colonia
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Colonia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>CP</summary>
        public static string CP
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("CP", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ciudad</summary>
        public static string Ciudad
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Ciudad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estado</summary>
        public static string Estado
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Estado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pais</summary>
        public static string Pais
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Pais", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Telefonos</summary>
        public static string Telefonos
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Telefonos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>En_Hospital</summary>
        public static string En_Hospital
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("En_Hospital", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_del_Hospital</summary>
        public static string Nombre_del_Hospital
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Nombre_del_Hospital", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Piso_hospital</summary>
        public static string Piso_hospital
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Piso_hospital", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_de_consultorio</summary>
        public static string Numero_de_consultorio
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Numero_de_consultorio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Redes_sociales</summary>
        public static string Redes_sociales
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Redes_sociales", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Aseguradoras_con_convenio</summary>
        public static string Aseguradoras_con_convenio
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Aseguradoras_con_convenio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Se_ajusta_tabulador</summary>
        public static string Se_ajusta_tabulador
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Se_ajusta_tabulador", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Profesion</summary>
        public static string Profesion
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Profesion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Especialidad</summary>
        public static string Especialidad
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Especialidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Titulos</summary>
        public static string Titulos
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Titulos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Resumen_Profesional</summary>
        public static string Resumen_Profesional
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Resumen_Profesional", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Regimen_Fiscal</summary>
        public static string Regimen_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Regimen_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_o_Razon_Social</summary>
        public static string Nombre_o_Razon_Social
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Nombre_o_Razon_Social", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>RFC</summary>
        public static string RFC
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("RFC", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Calle_Fiscal</summary>
        public static string Calle_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Calle_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_exterior_Fiscal</summary>
        public static string Numero_exterior_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Numero_exterior_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_interior_Fiscal</summary>
        public static string Numero_interior_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Numero_interior_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Colonia_Fiscal</summary>
        public static string Colonia_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Colonia_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>CP_Fiscal</summary>
        public static string CP_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("CP_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ciudad_Fiscal</summary>
        public static string Ciudad_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Ciudad_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estado_Fiscal</summary>
        public static string Estado_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Estado_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pais_Fiscal</summary>
        public static string Pais_Fiscal
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Pais_Fiscal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Telefono</summary>
        public static string Telefono
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Telefono", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fax</summary>
        public static string Fax
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Fax", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Identificacion_Oficial</summary>
        public static string Identificacion_Oficial
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Identificacion_Oficial", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cedula_Fiscal_Documento</summary>
        public static string Cedula_Fiscal_Documento
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Cedula_Fiscal_Documento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Comprobante_de_Domicilio</summary>
        public static string Comprobante_de_Domicilio
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Comprobante_de_Domicilio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Codigos_para_Referenciar_Pacientes</summary>
        public static string Codigos_para_Referenciar_Pacientes
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Codigos_para_Referenciar_Pacientes", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Suscripcion_Red_de_Especialistas</summary>
        public static string Suscripcion_Red_de_Especialistas
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Suscripcion_Red_de_Especialistas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Calificacion_Red_de_Medicos</summary>
        public static string Calificacion_Red_de_Medicos
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Calificacion_Red_de_Medicos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Banco</summary>
        public static string Banco
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Banco", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>CLABE_Interbancaria</summary>
        public static string CLABE_Interbancaria
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("CLABE_Interbancaria", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_de_Cuenta</summary>
        public static string Numero_de_Cuenta
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Numero_de_Cuenta", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_del_Titular</summary>
        public static string Nombre_del_Titular
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Nombre_del_Titular", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Facturas</summary>
        public static string Facturas
        {
            get
            {
                SetPath();
                return resourceProviderMedicos.GetResource("Facturas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderMedicos.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Datos de Contacto</summary>	public static string TabDatos_de_Contacto 	{		get		{			SetPath();  			return resourceProviderMedicos.GetResource("TabDatos_de_Contacto", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Datos Profesionales</summary>	public static string TabDatos_Profesionales 	{		get		{			SetPath();  			return resourceProviderMedicos.GetResource("TabDatos_Profesionales", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Datos Fiscales</summary>	public static string TabDatos_Fiscales 	{		get		{			SetPath();  			return resourceProviderMedicos.GetResource("TabDatos_Fiscales", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Documentación</summary>	public static string TabDocumentacion 	{		get		{			SetPath();  			return resourceProviderMedicos.GetResource("TabDocumentacion", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Códigos de Referencia</summary>	public static string TabCodigos_de_Referencia 	{		get		{			SetPath();  			return resourceProviderMedicos.GetResource("TabCodigos_de_Referencia", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Suscripción Red de Especialistas</summary>	public static string TabSuscripcion_Red_de_Especialistas 	{		get		{			SetPath();  			return resourceProviderMedicos.GetResource("TabSuscripcion_Red_de_Especialistas", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Datos Bancarios</summary>	public static string TabDatos_Bancarios 	{		get		{			SetPath();  			return resourceProviderMedicos.GetResource("TabDatos_Bancarios", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Facturación</summary>	public static string TabFacturacion 	{		get		{			SetPath();  			return resourceProviderMedicos.GetResource("TabFacturacion", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
