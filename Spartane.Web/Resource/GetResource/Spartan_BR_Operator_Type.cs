using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_Operator_TypeResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Operator_Type = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_Operator_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Operator_Type = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Operator_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_BR_Operator_Type</summary>
        public static string Spartan_BR_Operator_Type
        {
            get
            {
                return resourceProviderSpartan_BR_Operator_Type.GetResource("Spartan_BR_Operator_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>OperatorTypeId</summary>
        public static string OperatorTypeId
        {
            get
            {
                return resourceProviderSpartan_BR_Operator_Type.GetResource("OperatorTypeId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_BR_Operator_Type.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Presentation_Control_Type</summary>
        public static string Presentation_Control_Type
        {
            get
            {
                return resourceProviderSpartan_BR_Operator_Type.GetResource("Presentation_Control_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Query_for_Fill_Condition</summary>
        public static string Query_for_Fill_Condition
        {
            get
            {
                return resourceProviderSpartan_BR_Operator_Type.GetResource("Query_for_Fill_Condition", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Code_for_Fill_Condition</summary>
        public static string Code_for_Fill_Condition
        {
            get
            {
                return resourceProviderSpartan_BR_Operator_Type.GetResource("Code_for_Fill_Condition", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Implementation_Code</summary>
        public static string Implementation_Code
        {
            get
            {
                return resourceProviderSpartan_BR_Operator_Type.GetResource("Implementation_Code", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
