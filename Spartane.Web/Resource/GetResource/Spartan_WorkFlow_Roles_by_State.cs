using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_WorkFlow_Roles_by_StateResources
    {
        //private static IResourceProvider resourceProviderSpartan_WorkFlow_Roles_by_State = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_WorkFlow_Roles_by_StateResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_WorkFlow_Roles_by_State = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlow_Roles_by_StateResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_WorkFlow_Roles_by_State = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlow_Roles_by_StateResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_WorkFlow_Roles_by_State</summary>
        public static string Spartan_WorkFlow_Roles_by_State
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Roles_by_State.GetResource("Spartan_WorkFlow_Roles_by_State", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Roles_by_StateId</summary>
        public static string Roles_by_StateId
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Roles_by_State.GetResource("Roles_by_StateId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Phase</summary>
        public static string Phase
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Roles_by_State.GetResource("Phase", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>State</summary>
        public static string State
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Roles_by_State.GetResource("State", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>User_Role</summary>
        public static string User_Role
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Roles_by_State.GetResource("User_Role", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Phase_Transition</summary>
        public static string Phase_Transition
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Roles_by_State.GetResource("Phase_Transition", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Permission_To_Consult</summary>
        public static string Permission_To_Consult
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Roles_by_State.GetResource("Permission_To_Consult", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Permission_To_New</summary>
        public static string Permission_To_New
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Roles_by_State.GetResource("Permission_To_New", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Permission_To_Modify</summary>
        public static string Permission_To_Modify
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Roles_by_State.GetResource("Permission_To_Modify", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Permission_to_Delete</summary>
        public static string Permission_to_Delete
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Roles_by_State.GetResource("Permission_to_Delete", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Permission_To_Export</summary>
        public static string Permission_To_Export
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Roles_by_State.GetResource("Permission_To_Export", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Permission_To_Print</summary>
        public static string Permission_To_Print
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Roles_by_State.GetResource("Permission_To_Print", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Permission_Settings</summary>
        public static string Permission_Settings
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Roles_by_State.GetResource("Permission_Settings", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        /// <summary>Datos Generales</summary>
        public static string TabDatos_Generales
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Roles_by_State.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

    }
}
