using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Facturacion_EspecialistasResources
    {
        //private static IResourceProvider resourceProviderDetalle_Facturacion_Especialistas = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Facturacion_EspecialistasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Facturacion_Especialistas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Facturacion_EspecialistasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Facturacion_Especialistas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Facturacion_EspecialistasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Facturacion_Especialistas</summary>
        public static string Detalle_Facturacion_Especialistas
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Facturacion_Especialistas.GetResource("Detalle_Facturacion_Especialistas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Facturacion_Especialistas.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Facturacion_Especialistas.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio_Factura</summary>
        public static string Folio_Factura
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Facturacion_Especialistas.GetResource("Folio_Factura", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Periodo_Facturado</summary>
        public static string Periodo_Facturado
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Facturacion_Especialistas.GetResource("Periodo_Facturado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad</summary>
        public static string Cantidad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Facturacion_Especialistas.GetResource("Cantidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Archivo_XML</summary>
        public static string Archivo_XML
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Facturacion_Especialistas.GetResource("Archivo_XML", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Archivo_PDF</summary>
        public static string Archivo_PDF
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Facturacion_Especialistas.GetResource("Archivo_PDF", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Facturacion_Especialistas.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_programada_de_Pago</summary>
        public static string Fecha_programada_de_Pago
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Facturacion_Especialistas.GetResource("Fecha_programada_de_Pago", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pagada</summary>
        public static string Pagada
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Facturacion_Especialistas.GetResource("Pagada", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_pago</summary>
        public static string Fecha_de_pago
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Facturacion_Especialistas.GetResource("Fecha_de_pago", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Facturacion_Especialistas.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
