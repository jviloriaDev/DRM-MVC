using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace Resources
{
    public partial class SecurityAdminResources
    {
        private static IResourceProvider resourceProviderSecurityAdmin = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Resources." + CultureInfo.CurrentUICulture.Name + ".xml"));

        public static void SetPath()
        {
            resourceProviderSecurityAdmin = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Resources." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>SecurityAdministration</summary>
        public static string SecurityAdministration
        {
            get
            {
                SetPath();
                return resourceProviderSecurityAdmin.GetResource("SecurityAdministration", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>
        /// Modules
        /// </summary>
        public static string Modules
        {
            get
            {
                SetPath();
                return resourceProviderSecurityAdmin.GetResource("Modules", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string Configuration
        {
            get
            {
                SetPath();
                return resourceProviderSecurityAdmin.GetResource("Configuration", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string UserRole
        {
            get
            {
                SetPath();
                return resourceProviderSecurityAdmin.GetResource("UserRole", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string ObjectModule
        {
            get
            {
                SetPath();
                return resourceProviderSecurityAdmin.GetResource("ObjectModule", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string Object
        {
            get
            {
                SetPath();
                return resourceProviderSecurityAdmin.GetResource("Object", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string textMessagge1
        {
            get
            {
                SetPath();
                return resourceProviderSecurityAdmin.GetResource("textMessagge1", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string textMessagge2
        {
            get
            {
                SetPath();
                return resourceProviderSecurityAdmin.GetResource("textMessagge2", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string allowall
        {
            get
            {
                SetPath();
                return resourceProviderSecurityAdmin.GetResource("allowall", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        

        public static string newtext
        {
            get
            {
                SetPath();
                return resourceProviderSecurityAdmin.GetResource("new", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        
        
        public static string Export
        {
            get
            {
                SetPath();
                return resourceProviderSecurityAdmin.GetResource("export", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        
        //public static string Configure
        //{
        //    get
        //    {
        //        return resourceProvider.GetResource("configure", CultureInfo.CurrentUICulture.Name) as String;
        //    }
        //}

        public static string SelectStatus
        {
            get
            {
                SetPath();
                return resourceProviderSecurityAdmin.GetResource("SelectStatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        
    }
}