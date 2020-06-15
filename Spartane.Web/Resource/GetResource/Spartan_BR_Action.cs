using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_ActionResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Action = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_ActionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Action = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_ActionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_BR_Action</summary>
        public static string Spartan_BR_Action
        {
            get
            {
                return resourceProviderSpartan_BR_Action.GetResource("Spartan_BR_Action", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ActionId</summary>
        public static string ActionId
        {
            get
            {
                return resourceProviderSpartan_BR_Action.GetResource("ActionId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_BR_Action.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Classification</summary>
        public static string Classification
        {
            get
            {
                return resourceProviderSpartan_BR_Action.GetResource("Classification", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Implementation_Code</summary>
        public static string Implementation_Code
        {
            get
            {
                return resourceProviderSpartan_BR_Action.GetResource("Implementation_Code", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Configuration</summary>
        public static string Configuration
        {
            get
            {
                return resourceProviderSpartan_BR_Action.GetResource("Configuration", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Attribute_Restrictions</summary>
        public static string Attribute_Restrictions
        {
            get
            {
                return resourceProviderSpartan_BR_Action.GetResource("Attribute_Restrictions", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Operation_Restrictions</summary>
        public static string Operation_Restrictions
        {
            get
            {
                return resourceProviderSpartan_BR_Action.GetResource("Operation_Restrictions", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Process_Event_Restrictions</summary>
        public static string Process_Event_Restrictions
        {
            get
            {
                return resourceProviderSpartan_BR_Action.GetResource("Process_Event_Restrictions", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
