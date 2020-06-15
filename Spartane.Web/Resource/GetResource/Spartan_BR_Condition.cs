using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_ConditionResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Condition = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_ConditionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Condition = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_ConditionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_BR_Condition</summary>
        public static string Spartan_BR_Condition
        {
            get
            {
                return resourceProviderSpartan_BR_Condition.GetResource("Spartan_BR_Condition", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ConditionId</summary>
        public static string ConditionId
        {
            get
            {
                return resourceProviderSpartan_BR_Condition.GetResource("ConditionId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_BR_Condition.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Implementation_Code</summary>
        public static string Implementation_Code
        {
            get
            {
                return resourceProviderSpartan_BR_Condition.GetResource("Implementation_Code", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
