using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Datos_Bancarios_EspecialistasResources
    {
        //private static IResourceProvider resourceProviderDatos_Bancarios_Especialistas = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Datos_Bancarios_EspecialistasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDatos_Bancarios_Especialistas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Datos_Bancarios_EspecialistasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDatos_Bancarios_Especialistas = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Datos_Bancarios_EspecialistasResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Datos_Bancarios_Especialistas</summary>
        public static string Datos_Bancarios_Especialistas
        {
            get
            {
                SetPath();
                return resourceProviderDatos_Bancarios_Especialistas.GetResource("Datos_Bancarios_Especialistas", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDatos_Bancarios_Especialistas.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Banco</summary>
        public static string Banco
        {
            get
            {
                SetPath();
                return resourceProviderDatos_Bancarios_Especialistas.GetResource("Banco", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>CLABE_Interbancaria</summary>
        public static string CLABE_Interbancaria
        {
            get
            {
                SetPath();
                return resourceProviderDatos_Bancarios_Especialistas.GetResource("CLABE_Interbancaria", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Num_Cuenta</summary>
        public static string Num_Cuenta
        {
            get
            {
                SetPath();
                return resourceProviderDatos_Bancarios_Especialistas.GetResource("Num_Cuenta", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_del_Titular</summary>
        public static string Nombre_del_Titular
        {
            get
            {
                SetPath();
                return resourceProviderDatos_Bancarios_Especialistas.GetResource("Nombre_del_Titular", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Principal</summary>
        public static string Principal
        {
            get
            {
                SetPath();
                return resourceProviderDatos_Bancarios_Especialistas.GetResource("Principal", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDatos_Bancarios_Especialistas.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
