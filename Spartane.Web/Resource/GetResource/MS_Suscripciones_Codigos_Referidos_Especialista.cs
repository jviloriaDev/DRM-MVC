using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class MS_Suscripciones_Codigos_Referidos_EspecialistaResources
    {
        //private static IResourceProvider resourceProviderMS_Suscripciones_Codigos_Referidos_Especialista = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\MS_Suscripciones_Codigos_Referidos_EspecialistaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderMS_Suscripciones_Codigos_Referidos_Especialista = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MS_Suscripciones_Codigos_Referidos_EspecialistaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderMS_Suscripciones_Codigos_Referidos_Especialista = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MS_Suscripciones_Codigos_Referidos_EspecialistaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>MS_Suscripciones_Codigos_Referidos_Especialista</summary>
        public static string MS_Suscripciones_Codigos_Referidos_Especialista
        {
            get
            {
                SetPath();
                return resourceProviderMS_Suscripciones_Codigos_Referidos_Especialista.GetResource("MS_Suscripciones_Codigos_Referidos_Especialista", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderMS_Suscripciones_Codigos_Referidos_Especialista.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Plan_de_Suscripcion</summary>
        public static string Plan_de_Suscripcion
        {
            get
            {
                SetPath();
                return resourceProviderMS_Suscripciones_Codigos_Referidos_Especialista.GetResource("Plan_de_Suscripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderMS_Suscripciones_Codigos_Referidos_Especialista.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
