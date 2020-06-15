using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Dashboard_Config_DetailResources
    {
        //private static IResourceProvider resourceProviderDashboard_Config_Detail = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Dashboard_Config_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDashboard_Config_Detail = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Dashboard_Config_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDashboard_Config_Detail = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Dashboard_Config_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Dashboard_Config_Detail</summary>
        public static string Dashboard_Config_Detail
        {
            get
            {
                SetPath();
                return resourceProviderDashboard_Config_Detail.GetResource("Dashboard_Config_Detail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Detail_Id</summary>
        public static string Detail_Id
        {
            get
            {
                SetPath();
                return resourceProviderDashboard_Config_Detail.GetResource("Detail_Id", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Report_Id</summary>
        public static string Report_Id
        {
            get
            {
                SetPath();
                return resourceProviderDashboard_Config_Detail.GetResource("Report_Id", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Report_Name</summary>
        public static string Report_Name
        {
            get
            {
                SetPath();
                return resourceProviderDashboard_Config_Detail.GetResource("Report_Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ConfigRow</summary>
        public static string ConfigRow
        {
            get
            {
                SetPath();
                return resourceProviderDashboard_Config_Detail.GetResource("ConfigRow", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ConfigColumn</summary>
        public static string ConfigColumn
        {
            get
            {
                SetPath();
                return resourceProviderDashboard_Config_Detail.GetResource("ConfigColumn", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDashboard_Config_Detail.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
