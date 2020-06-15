using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_WorkFlow_Information_by_StateResources
    {
        //private static IResourceProvider resourceProviderSpartan_WorkFlow_Information_by_State = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_WorkFlow_Information_by_StateResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_WorkFlow_Information_by_State = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlow_Information_by_StateResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_WorkFlow_Information_by_State = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlow_Information_by_StateResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_WorkFlow_Information_by_State</summary>
        public static string Spartan_WorkFlow_Information_by_State
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Information_by_State.GetResource("Spartan_WorkFlow_Information_by_State", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Information_by_StateId</summary>
        public static string Information_by_StateId
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Information_by_State.GetResource("Information_by_StateId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Phase</summary>
        public static string Phase
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Information_by_State.GetResource("Phase", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>State</summary>
        public static string State
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Information_by_State.GetResource("State", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folder</summary>
        public static string Folder
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Information_by_State.GetResource("Folder", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Visible</summary>
        public static string Visible
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Information_by_State.GetResource("Visible", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Read_Only</summary>
        public static string Read_Only
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Information_by_State.GetResource("Read_Only", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Required</summary>
        public static string Required
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Information_by_State.GetResource("Required", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Label</summary>
        public static string Label
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Information_by_State.GetResource("Label", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        /// <summary>Datos Generales</summary>
        public static string TabDatos_Generales
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Information_by_State.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

    }
}
