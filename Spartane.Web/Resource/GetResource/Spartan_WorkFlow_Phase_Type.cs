using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_WorkFlow_Phase_TypeResources
    {
        //private static IResourceProvider resourceProviderSpartan_WorkFlow_Phase_Type = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_WorkFlow_Phase_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_WorkFlow_Phase_Type = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlow_Phase_TypeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_WorkFlow_Phase_Type</summary>
        public static string Spartan_WorkFlow_Phase_Type
        {
            get
            {
                return resourceProviderSpartan_WorkFlow_Phase_Type.GetResource("Spartan_WorkFlow_Phase_Type", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Phase_TypeId</summary>
        public static string Phase_TypeId
        {
            get
            {
                return resourceProviderSpartan_WorkFlow_Phase_Type.GetResource("Phase_TypeId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_WorkFlow_Phase_Type.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
