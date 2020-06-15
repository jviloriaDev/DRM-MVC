using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_WorkFlow_OperatorResources
    {
        //private static IResourceProvider resourceProviderSpartan_WorkFlow_Operator = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_WorkFlow_OperatorResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_WorkFlow_Operator = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlow_OperatorResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_WorkFlow_Operator</summary>
        public static string Spartan_WorkFlow_Operator
        {
            get
            {
                return resourceProviderSpartan_WorkFlow_Operator.GetResource("Spartan_WorkFlow_Operator", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>OperatorId</summary>
        public static string OperatorId
        {
            get
            {
                return resourceProviderSpartan_WorkFlow_Operator.GetResource("OperatorId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_WorkFlow_Operator.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
