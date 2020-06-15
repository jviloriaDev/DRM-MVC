using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_Modifications_LogResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Modifications_Log = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_Modifications_LogResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Modifications_Log = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Modifications_LogResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_BR_Modifications_Log</summary>
        public static string Spartan_BR_Modifications_Log
        {
            get
            {
                return resourceProviderSpartan_BR_Modifications_Log.GetResource("Spartan_BR_Modifications_Log", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ModificationId</summary>
        public static string ModificationId
        {
            get
            {
                return resourceProviderSpartan_BR_Modifications_Log.GetResource("ModificationId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Modification_Date</summary>
        public static string Modification_Date
        {
            get
            {
                return resourceProviderSpartan_BR_Modifications_Log.GetResource("Modification_Date", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Modification_Hour</summary>
        public static string Modification_Hour
        {
            get
            {
                return resourceProviderSpartan_BR_Modifications_Log.GetResource("Modification_Hour", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Modification_User</summary>
        public static string Modification_User
        {
            get
            {
                return resourceProviderSpartan_BR_Modifications_Log.GetResource("Modification_User", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Comments</summary>
        public static string Comments
        {
            get
            {
                return resourceProviderSpartan_BR_Modifications_Log.GetResource("Comments", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Implementation_Code</summary>
        public static string Implementation_Code
        {
            get
            {
                return resourceProviderSpartan_BR_Modifications_Log.GetResource("Implementation_Code", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
