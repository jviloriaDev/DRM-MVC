using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Contratos_EmpresaResources
    {
        //private static IResourceProvider resourceProviderDetalle_Contratos_Empresa = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Contratos_EmpresaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Contratos_Empresa = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Contratos_EmpresaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Contratos_Empresa = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Contratos_EmpresaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Contratos_Empresa</summary>
        public static string Detalle_Contratos_Empresa
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Contratos_Empresa.GetResource("Detalle_Contratos_Empresa", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Contratos_Empresa.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Suscripcion</summary>
        public static string Suscripcion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Contratos_Empresa.GetResource("Suscripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Contrato</summary>
        public static string Tipo_de_Contrato
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Contratos_Empresa.GetResource("Tipo_de_Contrato", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Documento</summary>
        public static string Documento
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Contratos_Empresa.GetResource("Documento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Firma_de_Contrato</summary>
        public static string Fecha_de_Firma_de_Contrato
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Contratos_Empresa.GetResource("Fecha_de_Firma_de_Contrato", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Contratos_Empresa.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
