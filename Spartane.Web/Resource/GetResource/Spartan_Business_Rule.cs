using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Business_RuleResources
    {
        //private static IResourceProvider resourceProviderSpartan_Business_Rule = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Business_RuleResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Business_Rule = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Business_RuleResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_Business_Rule</summary>
        public static string Spartan_Business_Rule
        {
            get
            {
                return resourceProviderSpartan_Business_Rule.GetResource("Spartan_Business_Rule", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>BusinessRuleId</summary>
        public static string BusinessRuleId
        {
            get
            {
                return resourceProviderSpartan_Business_Rule.GetResource("BusinessRuleId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Registration_Date</summary>
        public static string Registration_Date
        {
            get
            {
                return resourceProviderSpartan_Business_Rule.GetResource("Registration_Date", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Registration_Hour</summary>
        public static string Registration_Hour
        {
            get
            {
                return resourceProviderSpartan_Business_Rule.GetResource("Registration_Hour", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>User_who_registers</summary>
        public static string User_who_registers
        {
            get
            {
                return resourceProviderSpartan_Business_Rule.GetResource("User_who_registers", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_Business_Rule.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Object</summary>
        public static string Object
        {
            get
            {
                return resourceProviderSpartan_Business_Rule.GetResource("Object", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Scope</summary>
        public static string Scope
        {
            get
            {
                return resourceProviderSpartan_Business_Rule.GetResource("Scope", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Attribute</summary>
        public static string Attribute
        {
            get
            {
                return resourceProviderSpartan_Business_Rule.GetResource("Attribute", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Operation</summary>
        public static string Operation
        {
            get
            {
                return resourceProviderSpartan_Business_Rule.GetResource("Operation", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Process_Event</summary>
        public static string Process_Event
        {
            get
            {
                return resourceProviderSpartan_Business_Rule.GetResource("Process_Event", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Conditions</summary>
        public static string Conditions
        {
            get
            {
                return resourceProviderSpartan_Business_Rule.GetResource("Conditions", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Actions_if_Fulfills</summary>
        public static string Actions_if_Fulfills
        {
            get
            {
                return resourceProviderSpartan_Business_Rule.GetResource("Actions_if_Fulfills", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Actions_if_not_Fulfills</summary>
        public static string Actions_if_not_Fulfills
        {
            get
            {
                return resourceProviderSpartan_Business_Rule.GetResource("Actions_if_not_Fulfills", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Modifications_Log</summary>
        public static string Modifications_Log
        {
            get
            {
                return resourceProviderSpartan_Business_Rule.GetResource("Modifications_Log", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Implementation_Code</summary>
        public static string Implementation_Code
        {
            get
            {
                return resourceProviderSpartan_Business_Rule.GetResource("Implementation_Code", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
