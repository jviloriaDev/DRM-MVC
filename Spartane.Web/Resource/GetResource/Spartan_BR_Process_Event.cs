using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_Process_EventResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Process_Event = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_Process_EventResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Process_Event = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Process_EventResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_BR_Process_Event</summary>
        public static string Spartan_BR_Process_Event
        {
            get
            {
                return resourceProviderSpartan_BR_Process_Event.GetResource("Spartan_BR_Process_Event", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ProcessEventId</summary>
        public static string ProcessEventId
        {
            get
            {
                return resourceProviderSpartan_BR_Process_Event.GetResource("ProcessEventId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_BR_Process_Event.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
