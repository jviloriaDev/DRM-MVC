using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Template_Dashboard_DetailResources
    {
        //private static IResourceProvider resourceProviderTemplate_Dashboard_Detail = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Template_Dashboard_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderTemplate_Dashboard_Detail = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Template_Dashboard_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderTemplate_Dashboard_Detail = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Template_Dashboard_DetailResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Template_Dashboard_Detail</summary>
        public static string Template_Dashboard_Detail
        {
            get
            {
                SetPath();
                return resourceProviderTemplate_Dashboard_Detail.GetResource("Template_Dashboard_Detail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Detail_Id</summary>
        public static string Detail_Id
        {
            get
            {
                SetPath();
                return resourceProviderTemplate_Dashboard_Detail.GetResource("Detail_Id", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Row_Number</summary>
        public static string Row_Number
        {
            get
            {
                SetPath();
                return resourceProviderTemplate_Dashboard_Detail.GetResource("Row_Number", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Columns</summary>
        public static string Columns
        {
            get
            {
                SetPath();
                return resourceProviderTemplate_Dashboard_Detail.GetResource("Columns", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderTemplate_Dashboard_Detail.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
