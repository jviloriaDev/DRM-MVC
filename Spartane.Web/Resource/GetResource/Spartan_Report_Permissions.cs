using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Report_PermissionsResources
    {
        //private static IResourceProvider resourceProviderSpartan_Report_Permissions = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Report_PermissionsResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Report_Permissions = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Report_PermissionsResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Report_Permissions</summary>
        public static string Spartan_Report_Permissions
        {
            get
            {
                return resourceProviderSpartan_Report_Permissions.GetResource("Spartan_Report_Permissions", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ReportPermissionId</summary>
        public static string ReportPermissionId
        {
            get
            {
                return resourceProviderSpartan_Report_Permissions.GetResource("ReportPermissionId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>User_Role</summary>
        public static string User_Role
        {
            get
            {
                return resourceProviderSpartan_Report_Permissions.GetResource("User_Role", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Report</summary>
        public static string Report
        {
            get
            {
                return resourceProviderSpartan_Report_Permissions.GetResource("Report", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Permission_Type</summary>
        public static string Permission_Type
        {
            get
            {
                return resourceProviderSpartan_Report_Permissions.GetResource("Permission_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
