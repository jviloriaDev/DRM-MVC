using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_WorkFlow_Conditions_by_StateResources
    {
        //private static IResourceProvider resourceProviderSpartan_WorkFlow_Conditions_by_State = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_WorkFlow_Conditions_by_StateResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_WorkFlow_Conditions_by_State = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlow_Conditions_by_StateResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_WorkFlow_Conditions_by_State = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlow_Conditions_by_StateResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_WorkFlow_Conditions_by_State</summary>
        public static string Spartan_WorkFlow_Conditions_by_State
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Conditions_by_State.GetResource("Spartan_WorkFlow_Conditions_by_State", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Conditions_by_StateId</summary>
        public static string Conditions_by_StateId
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Conditions_by_State.GetResource("Conditions_by_StateId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Phase</summary>
        public static string Phase
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Conditions_by_State.GetResource("Phase", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>State</summary>
        public static string State
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Conditions_by_State.GetResource("State", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Condition_Operator</summary>
        public static string Condition_Operator
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Conditions_by_State.GetResource("Condition_Operator", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Attribute</summary>
        public static string Attribute
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Conditions_by_State.GetResource("Attribute", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Condition</summary>
        public static string Condition
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Conditions_by_State.GetResource("Condition", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Operator</summary>
        public static string Operator
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Conditions_by_State.GetResource("Operator", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Operator_Value</summary>
        public static string Operator_Value
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Conditions_by_State.GetResource("Operator_Value", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Priority</summary>
        public static string Priority
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Conditions_by_State.GetResource("Priority", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        /// <summary>Datos Generales</summary>
        public static string TabDatos_Generales
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_WorkFlow_Conditions_by_State.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

    }
}
