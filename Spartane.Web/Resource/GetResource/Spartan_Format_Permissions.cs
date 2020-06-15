using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Format_PermissionsResources
    {
        //private static IResourceProvider resourceProviderSpartan_Format_Permissions = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Format_PermissionsResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Format_Permissions = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Format_PermissionsResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Format_Permissions</summary>
        public static string Spartan_Format_Permissions
        {
            get
            {
                return resourceProviderSpartan_Format_Permissions.GetResource("Spartan_Format_Permissions", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>PermissionId</summary>
        public static string PermissionId
        {
            get
            {
                return resourceProviderSpartan_Format_Permissions.GetResource("PermissionId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Format</summary>
        public static string Format
        {
            get
            {
                return resourceProviderSpartan_Format_Permissions.GetResource("Format", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Permission_Type</summary>
        public static string Permission_Type
        {
            get
            {
                return resourceProviderSpartan_Format_Permissions.GetResource("Permission_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Apply</summary>
        public static string Apply
        {
            get
            {
                return resourceProviderSpartan_Format_Permissions.GetResource("Apply", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Spartan_User_Role</summary>
        public static string Spartan_User_Role
        {
            get
            {
                return resourceProviderSpartan_Format_Permissions.GetResource("Spartan_User_Role", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
