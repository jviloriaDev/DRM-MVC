using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_WorkFlow_StateResources
    {
        //private static IResourceProvider resourceProviderSpartan_WorkFlow_State = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_WorkFlow_StateResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_WorkFlow_State = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlow_StateResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_WorkFlow_State = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlow_StateResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_WorkFlow_State</summary>
        public static string Spartan_WorkFlow_State
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_State.GetResource("Spartan_WorkFlow_State", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>StateId</summary>
        public static string StateId
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_State.GetResource("StateId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Phase</summary>
        public static string Phase
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_State.GetResource("Phase", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Attribute</summary>
        public static string Attribute
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_State.GetResource("Attribute", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>State_Code</summary>
        public static string State_Code
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_State.GetResource("State_Code", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Name</summary>
        public static string Name
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_State.GetResource("Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Value</summary>
        public static string Value
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_State.GetResource("Value", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Text</summary>
        public static string Text
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_State.GetResource("Text", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        /// <summary>Datos Generales</summary>
        public static string TabDatos_Generales
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_State.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

    }
}
