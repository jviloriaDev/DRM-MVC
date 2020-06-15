using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_UserResources
    {
        //private static IResourceProvider resourceProviderSpartan_User = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_UserResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_User = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_UserResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_User</summary>
        public static string Spartan_User
        {
            get
            {
                return resourceProviderSpartan_User.GetResource("Spartan_User", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Id_User</summary>
        public static string Id_User
        {
            get
            {
                return resourceProviderSpartan_User.GetResource("Id_User", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Name</summary>
        public static string Name
        {
            get
            {
                return resourceProviderSpartan_User.GetResource("Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Role</summary>
        public static string Role
        {
            get
            {
                return resourceProviderSpartan_User.GetResource("Role", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Image</summary>
        public static string Image
        {
            get
            {
                return resourceProviderSpartan_User.GetResource("Image", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Email</summary>
        public static string Email
        {
            get
            {
                return resourceProviderSpartan_User.GetResource("Email", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Status</summary>
        public static string Status
        {
            get
            {
                return resourceProviderSpartan_User.GetResource("Status", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Username</summary>
        public static string Username
        {
            get
            {
                return resourceProviderSpartan_User.GetResource("Username", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Password</summary>
        public static string Password
        {
            get
            {
                return resourceProviderSpartan_User.GetResource("Password", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
