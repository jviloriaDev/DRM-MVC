using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class MS_Exclusion_Ingredientes_PacienteResources
    {
        //private static IResourceProvider resourceProviderMS_Exclusion_Ingredientes_Paciente = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\MS_Exclusion_Ingredientes_PacienteResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderMS_Exclusion_Ingredientes_Paciente = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MS_Exclusion_Ingredientes_PacienteResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderMS_Exclusion_Ingredientes_Paciente = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MS_Exclusion_Ingredientes_PacienteResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>MS_Exclusion_Ingredientes_Paciente</summary>
        public static string MS_Exclusion_Ingredientes_Paciente
        {
            get
            {
                SetPath();
                return resourceProviderMS_Exclusion_Ingredientes_Paciente.GetResource("MS_Exclusion_Ingredientes_Paciente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderMS_Exclusion_Ingredientes_Paciente.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ingrediente</summary>
        public static string Ingrediente
        {
            get
            {
                SetPath();
                return resourceProviderMS_Exclusion_Ingredientes_Paciente.GetResource("Ingrediente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderMS_Exclusion_Ingredientes_Paciente.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
