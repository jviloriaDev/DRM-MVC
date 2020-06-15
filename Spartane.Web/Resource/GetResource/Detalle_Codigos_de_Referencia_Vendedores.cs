using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Codigos_de_Referencia_VendedoresResources
    {
        //private static IResourceProvider resourceProviderDetalle_Codigos_de_Referencia_Vendedores = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Codigos_de_Referencia_VendedoresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Codigos_de_Referencia_Vendedores = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Codigos_de_Referencia_VendedoresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Codigos_de_Referencia_Vendedores = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Codigos_de_Referencia_VendedoresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Codigos_de_Referencia_Vendedores</summary>
        public static string Detalle_Codigos_de_Referencia_Vendedores
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Codigos_de_Referencia_Vendedores.GetResource("Detalle_Codigos_de_Referencia_Vendedores", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Codigos_de_Referencia_Vendedores.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Porcentaje_de_descuento</summary>
        public static string Porcentaje_de_descuento
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Codigos_de_Referencia_Vendedores.GetResource("Porcentaje_de_descuento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_inicio_vigencia</summary>
        public static string Fecha_inicio_vigencia
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Codigos_de_Referencia_Vendedores.GetResource("Fecha_inicio_vigencia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_fin_vigencia</summary>
        public static string Fecha_fin_vigencia
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Codigos_de_Referencia_Vendedores.GetResource("Fecha_fin_vigencia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_maxima_de_referenciados</summary>
        public static string Cantidad_maxima_de_referenciados
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Codigos_de_Referencia_Vendedores.GetResource("Cantidad_maxima_de_referenciados", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Codigo_para_referenciados</summary>
        public static string Codigo_para_referenciados
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Codigos_de_Referencia_Vendedores.GetResource("Codigo_para_referenciados", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Autorizado</summary>
        public static string Autorizado
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Codigos_de_Referencia_Vendedores.GetResource("Autorizado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_autoriza</summary>
        public static string Usuario_que_autoriza
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Codigos_de_Referencia_Vendedores.GetResource("Usuario_que_autoriza", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_autorizacion</summary>
        public static string Fecha_de_autorizacion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Codigos_de_Referencia_Vendedores.GetResource("Fecha_de_autorizacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_autorizacion</summary>
        public static string Hora_de_autorizacion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Codigos_de_Referencia_Vendedores.GetResource("Hora_de_autorizacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Codigos_de_Referencia_Vendedores.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Codigos_de_Referencia_Vendedores.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
