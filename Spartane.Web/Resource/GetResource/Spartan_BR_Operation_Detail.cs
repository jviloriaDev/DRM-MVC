using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_Operation_DetailResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Operation_Detail = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_Operation_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Operation_Detail = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Operation_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_BR_Operation_Detail</summary>
        public static string Spartan_BR_Operation_Detail
        {
            get
            {
                return resourceProviderSpartan_BR_Operation_Detail.GetResource("Spartan_BR_Operation_Detail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>OperationDetailId</summary>
        public static string OperationDetailId
        {
            get
            {
                return resourceProviderSpartan_BR_Operation_Detail.GetResource("OperationDetailId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Operation</summary>
        public static string Operation
        {
            get
            {
                return resourceProviderSpartan_BR_Operation_Detail.GetResource("Operation", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
