using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class SpartanChangePasswordAutorizationEstatusResources
    {
        //private static IResourceProvider resourceProviderSpartanChangePasswordAutorizationEstatus = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\SpartanChangePasswordAutorizationEstatusResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartanChangePasswordAutorizationEstatus = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\SpartanChangePasswordAutorizationEstatusResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartanChangePasswordAutorizationEstatus = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\SpartanChangePasswordAutorizationEstatusResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>SpartanChangePasswordAutorizationEstatus</summary>
        public static string SpartanChangePasswordAutorizationEstatus
        {
            get
            {
                SetPath();
                return resourceProviderSpartanChangePasswordAutorizationEstatus.GetResource("SpartanChangePasswordAutorizationEstatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Clave</summary>
        public static string Clave
        {
            get
            {
                SetPath();
                return resourceProviderSpartanChangePasswordAutorizationEstatus.GetResource("Clave", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion</summary>
        public static string Descripcion
        {
            get
            {
                SetPath();
                return resourceProviderSpartanChangePasswordAutorizationEstatus.GetResource("Descripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderSpartanChangePasswordAutorizationEstatus.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
