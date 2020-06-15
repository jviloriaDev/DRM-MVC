using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_Type_HistoryResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Type_History = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_Type_HistoryResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Type_History = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Type_HistoryResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_BR_Type_History = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Type_HistoryResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_BR_Type_History</summary>
        public static string Spartan_BR_Type_History
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Type_History.GetResource("Spartan_BR_Type_History", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Key_Type_History</summary>
        public static string Key_Type_History
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Type_History.GetResource("Key_Type_History", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Type_History.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderSpartan_BR_Type_History.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
