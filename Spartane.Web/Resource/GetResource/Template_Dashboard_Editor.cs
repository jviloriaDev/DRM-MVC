using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Template_Dashboard_EditorResources
    {
        //private static IResourceProvider resourceProviderTemplate_Dashboard_Editor = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Template_Dashboard_EditorResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderTemplate_Dashboard_Editor = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Template_Dashboard_EditorResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderTemplate_Dashboard_Editor = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Template_Dashboard_EditorResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Template_Dashboard_Editor</summary>
        public static string Template_Dashboard_Editor
        {
            get
            {
                SetPath();
                return resourceProviderTemplate_Dashboard_Editor.GetResource("Template_Dashboard_Editor", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Template_Id</summary>
        public static string Template_Id
        {
            get
            {
                SetPath();
                return resourceProviderTemplate_Dashboard_Editor.GetResource("Template_Id", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Description</summary>
        public static string Description
        {
            get
            {
                SetPath();
                return resourceProviderTemplate_Dashboard_Editor.GetResource("Description", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Template_Image_Thumbnail</summary>
        public static string Template_Image_Thumbnail
        {
            get
            {
                SetPath();
                return resourceProviderTemplate_Dashboard_Editor.GetResource("Template_Image_Thumbnail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Detail</summary>
        public static string Detail
        {
            get
            {
                SetPath();
                return resourceProviderTemplate_Dashboard_Editor.GetResource("Detail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderTemplate_Dashboard_Editor.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
