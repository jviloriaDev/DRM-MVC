using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Indicadores_LaboratorioResources
    {
        //private static IResourceProvider resourceProviderIndicadores_Laboratorio = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Indicadores_LaboratorioResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderIndicadores_Laboratorio = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Indicadores_LaboratorioResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderIndicadores_Laboratorio = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Indicadores_LaboratorioResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Indicadores_Laboratorio</summary>
        public static string Indicadores_Laboratorio
        {
            get
            {
                SetPath();
                return resourceProviderIndicadores_Laboratorio.GetResource("Indicadores_Laboratorio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderIndicadores_Laboratorio.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Indicador</summary>
        public static string Indicador
        {
            get
            {
                SetPath();
                return resourceProviderIndicadores_Laboratorio.GetResource("Indicador", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Unidad_de_Medida</summary>
        public static string Unidad_de_Medida
        {
            get
            {
                SetPath();
                return resourceProviderIndicadores_Laboratorio.GetResource("Unidad_de_Medida", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Limite_inferior</summary>
        public static string Limite_inferior
        {
            get
            {
                SetPath();
                return resourceProviderIndicadores_Laboratorio.GetResource("Limite_inferior", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Limite_superior</summary>
        public static string Limite_superior
        {
            get
            {
                SetPath();
                return resourceProviderIndicadores_Laboratorio.GetResource("Limite_superior", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderIndicadores_Laboratorio.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
