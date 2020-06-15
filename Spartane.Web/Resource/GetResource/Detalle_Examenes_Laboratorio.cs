using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Examenes_LaboratorioResources
    {
        //private static IResourceProvider resourceProviderDetalle_Examenes_Laboratorio = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Examenes_LaboratorioResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Examenes_Laboratorio = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Examenes_LaboratorioResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Examenes_Laboratorio = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Examenes_LaboratorioResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Examenes_Laboratorio</summary>
        public static string Detalle_Examenes_Laboratorio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Examenes_Laboratorio.GetResource("Detalle_Examenes_Laboratorio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Examenes_Laboratorio.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Indicador</summary>
        public static string Indicador
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Examenes_Laboratorio.GetResource("Indicador", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Resultado</summary>
        public static string Resultado
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Examenes_Laboratorio.GetResource("Resultado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Unidad</summary>
        public static string Unidad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Examenes_Laboratorio.GetResource("Unidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Intervalo_de_Referencia</summary>
        public static string Intervalo_de_Referencia
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Examenes_Laboratorio.GetResource("Intervalo_de_Referencia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Resultado</summary>
        public static string Fecha_de_Resultado
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Examenes_Laboratorio.GetResource("Fecha_de_Resultado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus_Indicador</summary>
        public static string Estatus_Indicador
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Examenes_Laboratorio.GetResource("Estatus_Indicador", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Examenes_Laboratorio.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
