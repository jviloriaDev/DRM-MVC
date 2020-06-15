using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_de_PadecimientosResources
    {
        //private static IResourceProvider resourceProviderDetalle_de_Padecimientos = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_de_PadecimientosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_de_Padecimientos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_de_PadecimientosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_de_Padecimientos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_de_PadecimientosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_de_Padecimientos</summary>
        public static string Detalle_de_Padecimientos
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Padecimientos.GetResource("Detalle_de_Padecimientos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Padecimientos.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Padecimiento</summary>
        public static string Padecimiento
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Padecimientos.GetResource("Padecimiento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tiempo_con_el_diagnostico</summary>
        public static string Tiempo_con_el_diagnostico
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Padecimientos.GetResource("Tiempo_con_el_diagnostico", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Intervencion_quirurgica</summary>
        public static string Intervencion_quirurgica
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Padecimientos.GetResource("Intervencion_quirurgica", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tratamiento</summary>
        public static string Tratamiento
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Padecimientos.GetResource("Tratamiento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estado_actual</summary>
        public static string Estado_actual
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_de_Padecimientos.GetResource("Estado_actual", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_de_Padecimientos.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
