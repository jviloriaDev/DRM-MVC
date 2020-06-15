using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_Process_Event_DetailResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Process_Event_Detail = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_Process_Event_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Process_Event_Detail = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Process_Event_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_BR_Process_Event_Detail</summary>
        public static string Spartan_BR_Process_Event_Detail
        {
            get
            {
                return resourceProviderSpartan_BR_Process_Event_Detail.GetResource("Spartan_BR_Process_Event_Detail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ProcessEventDetailId</summary>
        public static string ProcessEventDetailId
        {
            get
            {
                return resourceProviderSpartan_BR_Process_Event_Detail.GetResource("ProcessEventDetailId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Process_Event</summary>
        public static string Process_Event
        {
            get
            {
                return resourceProviderSpartan_BR_Process_Event_Detail.GetResource("Process_Event", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
