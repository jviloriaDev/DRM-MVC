using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_Condition_OperatorResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Condition_Operator = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_Condition_OperatorResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Condition_Operator = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Condition_OperatorResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_BR_Condition_Operator</summary>
        public static string Spartan_BR_Condition_Operator
        {
            get
            {
                return resourceProviderSpartan_BR_Condition_Operator.GetResource("Spartan_BR_Condition_Operator", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ConditionOperatorId</summary>
        public static string ConditionOperatorId
        {
            get
            {
                return resourceProviderSpartan_BR_Condition_Operator.GetResource("ConditionOperatorId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_BR_Condition_Operator.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Implementation_Code</summary>
        public static string Implementation_Code
        {
            get
            {
                return resourceProviderSpartan_BR_Condition_Operator.GetResource("Implementation_Code", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
