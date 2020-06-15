using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Dashboard_EditorResources
    {
        //private static IResourceProvider resourceProviderDashboard_Editor = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Dashboard_EditorResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDashboard_Editor = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Dashboard_EditorResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDashboard_Editor = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Dashboard_EditorResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Dashboard_Editor</summary>
        public static string Dashboard_Editor
        {
            get
            {
                SetPath();
                return resourceProviderDashboard_Editor.GetResource("Dashboard_Editor", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Dashboard_Id</summary>
        public static string Dashboard_Id
        {
            get
            {
                SetPath();
                return resourceProviderDashboard_Editor.GetResource("Dashboard_Id", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Registration_Date</summary>
        public static string Registration_Date
        {
            get
            {
                SetPath();
                return resourceProviderDashboard_Editor.GetResource("Registration_Date", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Registration_User</summary>
        public static string Registration_User
        {
            get
            {
                SetPath();
                return resourceProviderDashboard_Editor.GetResource("Registration_User", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Name</summary>
        public static string Name
        {
            get
            {
                SetPath();
                return resourceProviderDashboard_Editor.GetResource("Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Dashboard_Template</summary>
        public static string Dashboard_Template
        {
            get
            {
                SetPath();
                return resourceProviderDashboard_Editor.GetResource("Dashboard_Template", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Show_in_Home</summary>
        public static string Show_in_Home
        {
            get
            {
                SetPath();
                return resourceProviderDashboard_Editor.GetResource("Show_in_Home", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Status</summary>
        public static string Status
        {
            get
            {
                SetPath();
                return resourceProviderDashboard_Editor.GetResource("Status", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Spartan_Object</summary>
        public static string Spartan_Object
        {
            get
            {
                SetPath();
                return resourceProviderDashboard_Editor.GetResource("Spartan_Object", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Detail</summary>
        public static string Detail
        {
            get
            {
                SetPath();
                return resourceProviderDashboard_Editor.GetResource("Detail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDashboard_Editor.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Configuración</summary>	public static string TabConfiguracion 	{		get		{			SetPath();  			return resourceProviderDashboard_Editor.GetResource("TabConfiguracion", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
