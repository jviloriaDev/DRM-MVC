using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Equipamiento_para_EjerciciosResources
    {
        //private static IResourceProvider resourceProviderEquipamiento_para_Ejercicios = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Equipamiento_para_EjerciciosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderEquipamiento_para_Ejercicios = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Equipamiento_para_EjerciciosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderEquipamiento_para_Ejercicios = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Equipamiento_para_EjerciciosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Equipamiento_para_Ejercicios</summary>
        public static string Equipamiento_para_Ejercicios
        {
            get
            {
                SetPath();
                return resourceProviderEquipamiento_para_Ejercicios.GetResource("Equipamiento_para_Ejercicios", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderEquipamiento_para_Ejercicios.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion</summary>
        public static string Descripcion
        {
            get
            {
                SetPath();
                return resourceProviderEquipamiento_para_Ejercicios.GetResource("Descripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderEquipamiento_para_Ejercicios.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
