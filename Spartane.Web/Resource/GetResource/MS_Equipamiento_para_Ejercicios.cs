using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class MS_Equipamiento_para_EjerciciosResources
    {
        //private static IResourceProvider resourceProviderMS_Equipamiento_para_Ejercicios = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\MS_Equipamiento_para_EjerciciosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderMS_Equipamiento_para_Ejercicios = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MS_Equipamiento_para_EjerciciosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderMS_Equipamiento_para_Ejercicios = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\MS_Equipamiento_para_EjerciciosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>MS_Equipamiento_para_Ejercicios</summary>
        public static string MS_Equipamiento_para_Ejercicios
        {
            get
            {
                SetPath();
                return resourceProviderMS_Equipamiento_para_Ejercicios.GetResource("MS_Equipamiento_para_Ejercicios", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderMS_Equipamiento_para_Ejercicios.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Equipamento</summary>
        public static string Equipamento
        {
            get
            {
                SetPath();
                return resourceProviderMS_Equipamiento_para_Ejercicios.GetResource("Equipamento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderMS_Equipamiento_para_Ejercicios.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
