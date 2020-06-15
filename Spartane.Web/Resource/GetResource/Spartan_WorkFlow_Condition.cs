using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_WorkFlow_ConditionResources
    {
        //private static IResourceProvider resourceProviderSpartan_WorkFlow_Condition = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_WorkFlow_ConditionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_WorkFlow_Condition = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlow_ConditionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_WorkFlow_Condition</summary>
        public static string Spartan_WorkFlow_Condition
        {
            get
            {
                return resourceProviderSpartan_WorkFlow_Condition.GetResource("Spartan_WorkFlow_Condition", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ConditionId</summary>
        public static string ConditionId
        {
            get
            {
                return resourceProviderSpartan_WorkFlow_Condition.GetResource("ConditionId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_WorkFlow_Condition.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
