using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Dashboard_StatusResources
    {
        //private static IResourceProvider resourceProviderDashboard_Status = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Dashboard_StatusResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDashboard_Status = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Dashboard_StatusResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDashboard_Status = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Dashboard_StatusResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Dashboard_Status</summary>
        public static string Dashboard_Status
        {
            get
            {
                SetPath();
                return resourceProviderDashboard_Status.GetResource("Dashboard_Status", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Status_Id</summary>
        public static string Status_Id
        {
            get
            {
                SetPath();
                return resourceProviderDashboard_Status.GetResource("Status_Id", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                SetPath();
                return resourceProviderDashboard_Status.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDashboard_Status.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
