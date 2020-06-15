using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_Conditions_DetailResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Conditions_Detail = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_Conditions_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Conditions_Detail = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Conditions_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        public static void SetPath()
        {
            resourceProviderSpartan_BR_Conditions_Detail = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Conditions_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_BR_Conditions_Detail</summary>
        public static string Spartan_BR_Conditions_Detail
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Conditions_Detail.GetResource("Spartan_BR_Conditions_Detail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ConditionsDetailId</summary>
        public static string ConditionsDetailId
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Conditions_Detail.GetResource("ConditionsDetailId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Condition_Operator</summary>
        public static string Condition_Operator
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Conditions_Detail.GetResource("Condition_Operator", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>First_Operator_Type</summary>
        public static string First_Operator_Type
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Conditions_Detail.GetResource("First_Operator_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>First_Operator_Value</summary>
        public static string First_Operator_Value
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Conditions_Detail.GetResource("First_Operator_Value", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Condition</summary>
        public static string Condition
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Conditions_Detail.GetResource("Condition", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Second_Operator_Type</summary>
        public static string Second_Operator_Type
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Conditions_Detail.GetResource("Second_Operator_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Second_Operator_Value</summary>
        public static string Second_Operator_Value
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Conditions_Detail.GetResource("Second_Operator_Value", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
