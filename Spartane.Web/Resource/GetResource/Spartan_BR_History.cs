using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_HistoryResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_History = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_HistoryResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_History = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_HistoryResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_BR_History = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_HistoryResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_BR_History</summary>
        public static string Spartan_BR_History
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_History.GetResource("Spartan_BR_History", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Key_History</summary>
        public static string Key_History
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_History.GetResource("Key_History", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>User_logged</summary>
        public static string User_logged
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_History.GetResource("User_logged", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Status</summary>
        public static string Status
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_History.GetResource("Status", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Change_Date</summary>
        public static string Change_Date
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_History.GetResource("Change_Date", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hour_Date</summary>
        public static string Hour_Date
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_History.GetResource("Hour_Date", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Time_elapsed</summary>
        public static string Time_elapsed
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_History.GetResource("Time_elapsed", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Change_Type</summary>
        public static string Change_Type
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_History.GetResource("Change_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Conditions</summary>
        public static string Conditions
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_History.GetResource("Conditions", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Actions_True</summary>
        public static string Actions_True
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_History.GetResource("Actions_True", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Actions_False</summary>
        public static string Actions_False
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_History.GetResource("Actions_False", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderSpartan_BR_History.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
