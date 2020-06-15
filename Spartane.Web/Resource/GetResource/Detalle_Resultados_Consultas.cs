using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Resultados_ConsultasResources
    {
        //private static IResourceProvider resourceProviderDetalle_Resultados_Consultas = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Resultados_ConsultasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Resultados_Consultas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Resultados_ConsultasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Resultados_Consultas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Resultados_ConsultasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Resultados_Consultas</summary>
        public static string Detalle_Resultados_Consultas
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Resultados_Consultas.GetResource("Detalle_Resultados_Consultas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Resultados_Consultas.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio_Pacientes</summary>
        public static string Folio_Pacientes
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Resultados_Consultas.GetResource("Folio_Pacientes", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Consulta</summary>
        public static string Fecha_de_Consulta
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Resultados_Consultas.GetResource("Fecha_de_Consulta", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Indicador</summary>
        public static string Indicador
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Resultados_Consultas.GetResource("Indicador", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Resultado</summary>
        public static string Resultado
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Resultados_Consultas.GetResource("Resultado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Interpretacion</summary>
        public static string Interpretacion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Resultados_Consultas.GetResource("Interpretacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>IMC</summary>
        public static string IMC
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Resultados_Consultas.GetResource("IMC", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>IMC_Pediatria</summary>
        public static string IMC_Pediatria
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Resultados_Consultas.GetResource("IMC_Pediatria", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Resultados_Consultas.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
