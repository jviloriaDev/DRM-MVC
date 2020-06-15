using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Antecedentes_FamiliaresResources
    {
        //private static IResourceProvider resourceProviderDetalle_Antecedentes_Familiares = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Antecedentes_FamiliaresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Antecedentes_Familiares = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Antecedentes_FamiliaresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Antecedentes_Familiares = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Antecedentes_FamiliaresResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Antecedentes_Familiares</summary>
        public static string Detalle_Antecedentes_Familiares
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Antecedentes_Familiares.GetResource("Detalle_Antecedentes_Familiares", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Antecedentes_Familiares.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Enfermedad</summary>
        public static string Enfermedad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Antecedentes_Familiares.GetResource("Enfermedad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Parentesco</summary>
        public static string Parentesco
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Antecedentes_Familiares.GetResource("Parentesco", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Antecedentes_Familiares.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
