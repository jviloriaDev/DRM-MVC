using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_Action_Configuration_DetailResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Action_Configuration_Detail = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_Action_Configuration_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Action_Configuration_Detail = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Action_Configuration_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_BR_Action_Configuration_Detail</summary>
        public static string Spartan_BR_Action_Configuration_Detail
        {
            get
            {
                return resourceProviderSpartan_BR_Action_Configuration_Detail.GetResource("Spartan_BR_Action_Configuration_Detail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ActionConfigurationId</summary>
        public static string ActionConfigurationId
        {
            get
            {
                return resourceProviderSpartan_BR_Action_Configuration_Detail.GetResource("ActionConfigurationId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Parameter_Name</summary>
        public static string Parameter_Name
        {
            get
            {
                return resourceProviderSpartan_BR_Action_Configuration_Detail.GetResource("Parameter_Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Parameter_Type</summary>
        public static string Parameter_Type
        {
            get
            {
                return resourceProviderSpartan_BR_Action_Configuration_Detail.GetResource("Parameter_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
