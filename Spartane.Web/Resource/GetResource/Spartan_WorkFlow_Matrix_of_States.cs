using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_WorkFlow_Matrix_of_StatesResources
    {
        //private static IResourceProvider resourceProviderSpartan_WorkFlow_Matrix_of_States = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_WorkFlow_Matrix_of_StatesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_WorkFlow_Matrix_of_States = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlow_Matrix_of_StatesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_WorkFlow_Matrix_of_States = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlow_Matrix_of_StatesResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_WorkFlow_Matrix_of_States</summary>
        public static string Spartan_WorkFlow_Matrix_of_States
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Matrix_of_States.GetResource("Spartan_WorkFlow_Matrix_of_States", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Matrix_of_StatesId</summary>
        public static string Matrix_of_StatesId
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Matrix_of_States.GetResource("Matrix_of_StatesId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Phase</summary>
        public static string Phase
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Matrix_of_States.GetResource("Phase", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>State</summary>
        public static string State
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Matrix_of_States.GetResource("State", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Attribute</summary>
        public static string Attribute
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Matrix_of_States.GetResource("Attribute", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Visible</summary>
        public static string Visible
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Matrix_of_States.GetResource("Visible", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Required</summary>
        public static string Required
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Matrix_of_States.GetResource("Required", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Read_Only</summary>
        public static string Read_Only
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Matrix_of_States.GetResource("Read_Only", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Label</summary>
        public static string Label
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Matrix_of_States.GetResource("Label", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Default_Value</summary>
        public static string Default_Value
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Matrix_of_States.GetResource("Default_Value", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Help_Text</summary>
        public static string Help_Text
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Matrix_of_States.GetResource("Help_Text", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        /// <summary>Datos Generales</summary>
        public static string TabDatos_Generales
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Matrix_of_States.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

    }
}
