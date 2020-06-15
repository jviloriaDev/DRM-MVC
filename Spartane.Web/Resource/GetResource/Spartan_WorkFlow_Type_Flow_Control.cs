using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_WorkFlow_Type_Flow_ControlResources
    {
        //private static IResourceProvider resourceProviderSpartan_WorkFlow_Type_Flow_Control = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_WorkFlow_Type_Flow_ControlResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_WorkFlow_Type_Flow_Control = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_WorkFlow_Type_Flow_ControlResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_WorkFlow_Type_Flow_Control</summary>
        public static string Spartan_WorkFlow_Type_Flow_Control
        {
            get
            {
                return resourceProviderSpartan_WorkFlow_Type_Flow_Control.GetResource("Spartan_WorkFlow_Type_Flow_Control", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Type_Flow_ControlId</summary>
        public static string Type_Flow_ControlId
        {
            get
            {
                return resourceProviderSpartan_WorkFlow_Type_Flow_Control.GetResource("Type_Flow_ControlId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_WorkFlow_Type_Flow_Control.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
