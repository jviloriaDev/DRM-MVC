using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_Event_Restrictions_DetailResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Event_Restrictions_Detail = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_Event_Restrictions_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Event_Restrictions_Detail = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Event_Restrictions_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_BR_Event_Restrictions_Detail</summary>
        public static string Spartan_BR_Event_Restrictions_Detail
        {
            get
            {
                return resourceProviderSpartan_BR_Event_Restrictions_Detail.GetResource("Spartan_BR_Event_Restrictions_Detail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>RestrictionId</summary>
        public static string RestrictionId
        {
            get
            {
                return resourceProviderSpartan_BR_Event_Restrictions_Detail.GetResource("RestrictionId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Process_Event</summary>
        public static string Process_Event
        {
            get
            {
                return resourceProviderSpartan_BR_Event_Restrictions_Detail.GetResource("Process_Event", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
