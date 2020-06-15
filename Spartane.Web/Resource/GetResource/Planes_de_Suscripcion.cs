using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Planes_de_SuscripcionResources
    {
        //private static IResourceProvider resourceProviderPlanes_de_Suscripcion = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Planes_de_SuscripcionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderPlanes_de_Suscripcion = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Planes_de_SuscripcionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderPlanes_de_Suscripcion = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Planes_de_SuscripcionResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Planes_de_Suscripcion</summary>
        public static string Planes_de_Suscripcion
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion.GetResource("Planes_de_Suscripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Tipo_de_Beneficiario</summary>
        public static string Tipo_de_Beneficiario
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion.GetResource("Tipo_de_Beneficiario", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre</summary>
        public static string Nombre
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion.GetResource("Nombre", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_del_Plan</summary>
        public static string Nombre_del_Plan
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion.GetResource("Nombre_del_Plan", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Duracion_en_meses</summary>
        public static string Duracion_en_meses
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion.GetResource("Duracion_en_meses", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Duracion</summary>
        public static string Duracion
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion.GetResource("Duracion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Dietas_por_mes</summary>
        public static string Dietas_por_mes
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion.GetResource("Dietas_por_mes", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Rutinas_por_mes</summary>
        public static string Rutinas_por_mes
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion.GetResource("Rutinas_por_mes", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Costo_mensual</summary>
        public static string Costo_mensual
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion.GetResource("Costo_mensual", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Precio_Final</summary>
        public static string Precio_Final
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion.GetResource("Precio_Final", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderPlanes_de_Suscripcion.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderPlanes_de_Suscripcion.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
