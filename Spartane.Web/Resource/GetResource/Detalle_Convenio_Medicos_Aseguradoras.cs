using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Convenio_Medicos_AseguradorasResources
    {
        //private static IResourceProvider resourceProviderDetalle_Convenio_Medicos_Aseguradoras = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Convenio_Medicos_AseguradorasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Convenio_Medicos_Aseguradoras = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Convenio_Medicos_AseguradorasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Convenio_Medicos_Aseguradoras = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Convenio_Medicos_AseguradorasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Convenio_Medicos_Aseguradoras</summary>
        public static string Detalle_Convenio_Medicos_Aseguradoras
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Convenio_Medicos_Aseguradoras.GetResource("Detalle_Convenio_Medicos_Aseguradoras", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Convenio_Medicos_Aseguradoras.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Aseguradora_medico</summary>
        public static string Aseguradora_medico
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Convenio_Medicos_Aseguradoras.GetResource("Aseguradora_medico", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Convenio_Medicos_Aseguradoras.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
