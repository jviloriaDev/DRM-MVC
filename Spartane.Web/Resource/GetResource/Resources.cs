using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace Resources
{
    public partial class Resources
    {
        private static IResourceProvider resourceProvider = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Resources." + CultureInfo.CurrentUICulture.Name + ".xml"));

        public static void SetPath()
        {
            resourceProvider = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Resources." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
    }
}