using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Antecedentes_No_PatologicosResources
    {
        //private static IResourceProvider resourceProviderDetalle_Antecedentes_No_Patologicos = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Antecedentes_No_PatologicosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Antecedentes_No_Patologicos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Antecedentes_No_PatologicosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Antecedentes_No_Patologicos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Antecedentes_No_PatologicosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Antecedentes_No_Patologicos</summary>
        public static string Detalle_Antecedentes_No_Patologicos
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Antecedentes_No_Patologicos.GetResource("Detalle_Antecedentes_No_Patologicos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Antecedentes_No_Patologicos.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Sustancia</summary>
        public static string Sustancia
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Antecedentes_No_Patologicos.GetResource("Sustancia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Frecuencia</summary>
        public static string Frecuencia
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Antecedentes_No_Patologicos.GetResource("Frecuencia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad</summary>
        public static string Cantidad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Antecedentes_No_Patologicos.GetResource("Cantidad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Antecedentes_No_Patologicos.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
