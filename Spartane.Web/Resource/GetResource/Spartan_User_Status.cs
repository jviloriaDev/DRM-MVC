using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_User_StatusResources
    {
        //private static IResourceProvider resourceProviderSpartan_User_Status = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_User_StatusResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_User_Status = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_User_StatusResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_User_Status</summary>
        public static string Spartan_User_Status
        {
            get
            {
                return resourceProviderSpartan_User_Status.GetResource("Spartan_User_Status", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>User_Status_Id</summary>
        public static string User_Status_Id
        {
            get
            {
                return resourceProviderSpartan_User_Status.GetResource("User_Status_Id", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_User_Status.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
