using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_Action_ResultResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Action_Result = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_Action_ResultResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Action_Result = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Action_ResultResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_BR_Action_Result</summary>
        public static string Spartan_BR_Action_Result
        {
            get
            {
                return resourceProviderSpartan_BR_Action_Result.GetResource("Spartan_BR_Action_Result", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ActionResultId</summary>
        public static string ActionResultId
        {
            get
            {
                return resourceProviderSpartan_BR_Action_Result.GetResource("ActionResultId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_BR_Action_Result.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
