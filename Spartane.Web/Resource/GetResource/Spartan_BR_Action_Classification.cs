using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_Action_ClassificationResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Action_Classification = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_Action_ClassificationResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Action_Classification = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Action_ClassificationResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_BR_Action_Classification</summary>
        public static string Spartan_BR_Action_Classification
        {
            get
            {
                return resourceProviderSpartan_BR_Action_Classification.GetResource("Spartan_BR_Action_Classification", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ClassificationId</summary>
        public static string ClassificationId
        {
            get
            {
                return resourceProviderSpartan_BR_Action_Classification.GetResource("ClassificationId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_BR_Action_Classification.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
