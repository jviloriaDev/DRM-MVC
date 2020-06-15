using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Report_Advance_FilterResources
    {
        //private static IResourceProvider resourceProviderSpartan_Report_Advance_Filter = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Report_Advance_FilterResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Report_Advance_Filter = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Report_Advance_FilterResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_Report_Advance_Filter = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Report_Advance_FilterResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_Report_Advance_Filter</summary>
        public static string Spartan_Report_Advance_Filter
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report_Advance_Filter.GetResource("Spartan_Report_Advance_Filter", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report_Advance_Filter.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Report</summary>
        public static string Report
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report_Advance_Filter.GetResource("Report", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>AttributeId</summary>
        public static string AttributeId
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report_Advance_Filter.GetResource("AttributeId", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Defect_Value_From</summary>
        public static string Defect_Value_From
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report_Advance_Filter.GetResource("Defect_Value_From", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Defect_Value_To</summary>
        public static string Defect_Value_To
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Report_Advance_Filter.GetResource("Defect_Value_To", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderSpartan_Report_Advance_Filter.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
