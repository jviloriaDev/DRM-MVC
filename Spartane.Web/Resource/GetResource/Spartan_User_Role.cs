using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_User_RoleResources
    {
        //private static IResourceProvider resourceProviderSpartan_User_Role = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_User_RoleResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_User_Role = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_User_RoleResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_User_Role</summary>
        public static string Spartan_User_Role
        {
            get
            {
                return resourceProviderSpartan_User_Role.GetResource("Spartan_User_Role", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>User_Role_Id</summary>
        public static string User_Role_Id
        {
            get
            {
                return resourceProviderSpartan_User_Role.GetResource("User_Role_Id", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_User_Role.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Status</summary>
        public static string Status
        {
            get
            {
                return resourceProviderSpartan_User_Role.GetResource("Status", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
