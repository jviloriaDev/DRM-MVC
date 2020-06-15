using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Detalle_Titulos_MedicosResources
    {
        //private static IResourceProvider resourceProviderDetalle_Titulos_Medicos = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Detalle_Titulos_MedicosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderDetalle_Titulos_Medicos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Titulos_MedicosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderDetalle_Titulos_Medicos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Detalle_Titulos_MedicosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Detalle_Titulos_Medicos</summary>
        public static string Detalle_Titulos_Medicos
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Titulos_Medicos.GetResource("Detalle_Titulos_Medicos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Titulos_Medicos.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_del_Titulo</summary>
        public static string Nombre_del_Titulo
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Titulos_Medicos.GetResource("Nombre_del_Titulo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Institucion_Facultad</summary>
        public static string Institucion_Facultad
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Titulos_Medicos.GetResource("Institucion_Facultad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Titulacion</summary>
        public static string Fecha_de_Titulacion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Titulos_Medicos.GetResource("Fecha_de_Titulacion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Titulo</summary>
        public static string Titulo
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Titulos_Medicos.GetResource("Titulo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_de_Cedula</summary>
        public static string Numero_de_Cedula
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Titulos_Medicos.GetResource("Numero_de_Cedula", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Expedicion</summary>
        public static string Fecha_de_Expedicion
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Titulos_Medicos.GetResource("Fecha_de_Expedicion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cedula_Frente</summary>
        public static string Cedula_Frente
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Titulos_Medicos.GetResource("Cedula_Frente", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cedula_Reverso</summary>
        public static string Cedula_Reverso
        {
            get
            {
                SetPath();
                return resourceProviderDetalle_Titulos_Medicos.GetResource("Cedula_Reverso", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderDetalle_Titulos_Medicos.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
