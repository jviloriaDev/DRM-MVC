using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Redes_Sociales_EspecialistaResources
    {
        //private static IResourceProvider resourceProviderDetalle_Redes_Sociales_Especialista = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Redes_Sociales_EspecialistaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Redes_Sociales_Especialista = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Redes_Sociales_EspecialistaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Redes_Sociales_Especialista = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Redes_Sociales_EspecialistaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Redes_Sociales_Especialista</summary>
        public static string Detalle_Redes_Sociales_Especialista
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Redes_Sociales_Especialista.GetResource("Detalle_Redes_Sociales_Especialista", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Redes_Sociales_Especialista.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Red_Social</summary>
        public static string Red_Social
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Redes_Sociales_Especialista.GetResource("Red_Social", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>URL</summary>
        public static string URL
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Redes_Sociales_Especialista.GetResource("URL", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Principal</summary>
        public static string Principal
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Redes_Sociales_Especialista.GetResource("Principal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Redes_Sociales_Especialista.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
