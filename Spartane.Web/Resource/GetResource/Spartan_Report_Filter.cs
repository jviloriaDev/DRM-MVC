using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Report_FilterResources
    {
        //private static IResourceProvider resourceProviderSpartan_Report_Filter = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Report_FilterResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Report_Filter = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Report_FilterResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_Report_Filter = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Report_FilterResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_Report_Filter</summary>
        public static string Spartan_Report_Filter
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report_Filter.GetResource("Spartan_Report_Filter", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ReportFilterId</summary>
        public static string ReportFilterId
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report_Filter.GetResource("ReportFilterId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Field</summary>
        public static string Field
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report_Filter.GetResource("Field", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>QuickFilter</summary>
        public static string QuickFilter
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report_Filter.GetResource("QuickFilter", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>AdvanceFilter</summary>
        public static string AdvanceFilter
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report_Filter.GetResource("AdvanceFilter", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderSpartan_Report_Filter.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
