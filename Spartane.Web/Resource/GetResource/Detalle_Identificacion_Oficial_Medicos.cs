using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Identificacion_Oficial_MedicosResources
    {
        //private static IResourceProvider resourceProviderDetalle_Identificacion_Oficial_Medicos = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Identificacion_Oficial_MedicosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Identificacion_Oficial_Medicos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Identificacion_Oficial_MedicosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Identificacion_Oficial_Medicos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Identificacion_Oficial_MedicosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Identificacion_Oficial_Medicos</summary>
        public static string Detalle_Identificacion_Oficial_Medicos
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Identificacion_Oficial_Medicos.GetResource("Detalle_Identificacion_Oficial_Medicos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Identificacion_Oficial_Medicos.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Identificacion_Oficial</summary>
        public static string Tipo_de_Identificacion_Oficial
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Identificacion_Oficial_Medicos.GetResource("Tipo_de_Identificacion_Oficial", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Documento</summary>
        public static string Documento
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Identificacion_Oficial_Medicos.GetResource("Documento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Identificacion_Oficial_Medicos.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
