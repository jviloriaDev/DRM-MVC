using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_OperationResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Operation = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_OperationResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Operation = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_OperationResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_BR_Operation</summary>
        public static string Spartan_BR_Operation
        {
            get
            {
                return resourceProviderSpartan_BR_Operation.GetResource("Spartan_BR_Operation", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>OperationId</summary>
        public static string OperationId
        {
            get
            {
                return resourceProviderSpartan_BR_Operation.GetResource("OperationId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_BR_Operation.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
