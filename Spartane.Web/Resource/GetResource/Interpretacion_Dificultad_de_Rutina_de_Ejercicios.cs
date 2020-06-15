using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Interpretacion_Dificultad_de_Rutina_de_EjerciciosResources
    {
        //private static IResourceProvider resourceProviderInterpretacion_Dificultad_de_Rutina_de_Ejercicios = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Interpretacion_Dificultad_de_Rutina_de_EjerciciosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderInterpretacion_Dificultad_de_Rutina_de_Ejercicios = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Interpretacion_Dificultad_de_Rutina_de_EjerciciosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderInterpretacion_Dificultad_de_Rutina_de_Ejercicios = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Interpretacion_Dificultad_de_Rutina_de_EjerciciosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Interpretacion_Dificultad_de_Rutina_de_Ejercicios</summary>
        public static string Interpretacion_Dificultad_de_Rutina_de_Ejercicios
        {
            get
            {
                SetPath();
                return resourceProviderInterpretacion_Dificultad_de_Rutina_de_Ejercicios.GetResource("Interpretacion_Dificultad_de_Rutina_de_Ejercicios", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderInterpretacion_Dificultad_de_Rutina_de_Ejercicios.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion</summary>
        public static string Descripcion
        {
            get
            {
                SetPath();
                return resourceProviderInterpretacion_Dificultad_de_Rutina_de_Ejercicios.GetResource("Descripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderInterpretacion_Dificultad_de_Rutina_de_Ejercicios.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
