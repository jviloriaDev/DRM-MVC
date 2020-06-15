using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_WorkFlow_Type_Work_DistributionResources
    {
        //private static IResourceProvider resourceProviderSpartan_WorkFlow_Type_Work_Distribution = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_WorkFlow_Type_Work_DistributionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_WorkFlow_Type_Work_Distribution = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlow_Type_Work_DistributionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_WorkFlow_Type_Work_Distribution</summary>
        public static string Spartan_WorkFlow_Type_Work_Distribution
        {
            get
            {
                return resourceProviderSpartan_WorkFlow_Type_Work_Distribution.GetResource("Spartan_WorkFlow_Type_Work_Distribution", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Type_of_Work_DistributionId</summary>
        public static string Type_of_Work_DistributionId
        {
            get
            {
                return resourceProviderSpartan_WorkFlow_Type_Work_Distribution.GetResource("Type_of_Work_DistributionId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_WorkFlow_Type_Work_Distribution.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
