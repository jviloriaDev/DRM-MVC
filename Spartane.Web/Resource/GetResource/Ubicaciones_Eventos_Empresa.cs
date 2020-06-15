using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Ubicaciones_Eventos_EmpresaResources
    {
        //private static IResourceProvider resourceProviderUbicaciones_Eventos_Empresa = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Ubicaciones_Eventos_EmpresaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderUbicaciones_Eventos_Empresa = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Ubicaciones_Eventos_EmpresaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderUbicaciones_Eventos_Empresa = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Ubicaciones_Eventos_EmpresaResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Ubicaciones_Eventos_Empresa</summary>
        public static string Ubicaciones_Eventos_Empresa
        {
            get
            {
                SetPath();
                return resourceProviderUbicaciones_Eventos_Empresa.GetResource("Ubicaciones_Eventos_Empresa", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderUbicaciones_Eventos_Empresa.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderUbicaciones_Eventos_Empresa.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderUbicaciones_Eventos_Empresa.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderUbicaciones_Eventos_Empresa.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre</summary>
        public static string Nombre
        {
            get
            {
                SetPath();
                return resourceProviderUbicaciones_Eventos_Empresa.GetResource("Nombre", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion</summary>
        public static string Descripcion
        {
            get
            {
                SetPath();
                return resourceProviderUbicaciones_Eventos_Empresa.GetResource("Descripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cupo</summary>
        public static string Cupo
        {
            get
            {
                SetPath();
                return resourceProviderUbicaciones_Eventos_Empresa.GetResource("Cupo", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ubicacion_externa</summary>
        public static string Ubicacion_externa
        {
            get
            {
                SetPath();
                return resourceProviderUbicaciones_Eventos_Empresa.GetResource("Ubicacion_externa", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_del_Lugar</summary>
        public static string Nombre_del_Lugar
        {
            get
            {
                SetPath();
                return resourceProviderUbicaciones_Eventos_Empresa.GetResource("Nombre_del_Lugar", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Empresa</summary>
        public static string Empresa
        {
            get
            {
                SetPath();
                return resourceProviderUbicaciones_Eventos_Empresa.GetResource("Empresa", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderUbicaciones_Eventos_Empresa.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderUbicaciones_Eventos_Empresa.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
