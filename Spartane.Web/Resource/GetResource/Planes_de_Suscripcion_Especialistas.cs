using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Planes_de_Suscripcion_EspecialistasResources
    {
        //private static IResourceProvider resourceProviderPlanes_de_Suscripcion_Especialistas = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Planes_de_Suscripcion_EspecialistasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderPlanes_de_Suscripcion_Especialistas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Planes_de_Suscripcion_EspecialistasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderPlanes_de_Suscripcion_Especialistas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Planes_de_Suscripcion_EspecialistasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Planes_de_Suscripcion_Especialistas</summary>
        public static string Planes_de_Suscripcion_Especialistas
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion_Especialistas.GetResource("Planes_de_Suscripcion_Especialistas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion_Especialistas.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre</summary>
        public static string Nombre
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion_Especialistas.GetResource("Nombre", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Costo</summary>
        public static string Costo
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion_Especialistas.GetResource("Costo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion_Especialistas.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderPlanes_de_Suscripcion_Especialistas.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
