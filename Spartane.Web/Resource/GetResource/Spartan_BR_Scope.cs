using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_ScopeResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Scope = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_ScopeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Scope = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_ScopeResource." + CultureInfo.CurrentUICulture.Name + ".xml"));

        /// <summary>Spartan_BR_Scope</summary>
        public static string Spartan_BR_Scope
        {
            get
            {
                return resourceProviderSpartan_BR_Scope.GetResource("Spartan_BR_Scope", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ScopeId</summary>
        public static string ScopeId
        {
            get
            {
                return resourceProviderSpartan_BR_Scope.GetResource("ScopeId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                return resourceProviderSpartan_BR_Scope.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


    }
}
