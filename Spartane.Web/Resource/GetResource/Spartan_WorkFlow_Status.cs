using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_WorkFlow_StatusResources
    {
        //private static IResourceProvider resourceProviderSpartan_WorkFlow_Status = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_WorkFlow_StatusResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_WorkFlow_Status = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlow_StatusResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_WorkFlow_Status</summary>
        public static string Spartan_WorkFlow_Status
        {
            get
            {
                return resourceProviderSpartan_WorkFlow_Status.GetResource("Spartan_WorkFlow_Status", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>StatusId</summary>
        public static string StatusId
        {
            get
            {
                return resourceProviderSpartan_WorkFlow_Status.GetResource("StatusId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_WorkFlow_Status.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
