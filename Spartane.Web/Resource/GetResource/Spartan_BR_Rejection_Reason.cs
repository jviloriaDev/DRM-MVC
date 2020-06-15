using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_Rejection_ReasonResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Rejection_Reason = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_Rejection_ReasonResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Rejection_Reason = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Rejection_ReasonResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_BR_Rejection_Reason = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Rejection_ReasonResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_BR_Rejection_Reason</summary>
        public static string Spartan_BR_Rejection_Reason
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Rejection_Reason.GetResource("Spartan_BR_Rejection_Reason", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Key_Rejection_Reason</summary>
        public static string Key_Rejection_Reason
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Rejection_Reason.GetResource("Key_Rejection_Reason", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Rejection_Reason.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderSpartan_BR_Rejection_Reason.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
