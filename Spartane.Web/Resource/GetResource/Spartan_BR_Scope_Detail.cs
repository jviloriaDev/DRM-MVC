using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_Scope_DetailResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Scope_Detail = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_Scope_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Scope_Detail = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Scope_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_BR_Scope_Detail</summary>
        public static string Spartan_BR_Scope_Detail
        {
            get
            {
                return resourceProviderSpartan_BR_Scope_Detail.GetResource("Spartan_BR_Scope_Detail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ScopeDetailId</summary>
        public static string ScopeDetailId
        {
            get
            {
                return resourceProviderSpartan_BR_Scope_Detail.GetResource("ScopeDetailId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Scope</summary>
        public static string Scope
        {
            get
            {
                return resourceProviderSpartan_BR_Scope_Detail.GetResource("Scope", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
