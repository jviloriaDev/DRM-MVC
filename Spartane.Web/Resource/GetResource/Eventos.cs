using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class EventosResources
    {
        //private static IResourceProvider resourceProviderEventos = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\EventosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderEventos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\EventosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderEventos = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\EventosResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Eventos</summary>
        public static string Eventos
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Eventos", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_de_Registro</summary>
        public static string Fecha_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Fecha_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Hora_de_Registro</summary>
        public static string Hora_de_Registro
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Hora_de_Registro", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Usuario_que_Registra</summary>
        public static string Usuario_que_Registra
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Usuario_que_Registra", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Empresa</summary>
        public static string Empresa
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Empresa", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_del_Evento</summary>
        public static string Nombre_del_Evento
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Nombre_del_Evento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Descripcion</summary>
        public static string Descripcion
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Descripcion", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_inicio_del_Evento</summary>
        public static string Fecha_inicio_del_Evento
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Fecha_inicio_del_Evento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Fecha_fin_del_Evento</summary>
        public static string Fecha_fin_del_Evento
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Fecha_fin_del_Evento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Cantidad_de_dias</summary>
        public static string Cantidad_de_dias
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Cantidad_de_dias", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Evento_en_Empresa</summary>
        public static string Evento_en_Empresa
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Evento_en_Empresa", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Nombre_del_Lugar</summary>
        public static string Nombre_del_Lugar
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Nombre_del_Lugar", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Calle</summary>
        public static string Calle
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Calle", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_exterior</summary>
        public static string Numero_exterior
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Numero_exterior", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Numero_interior</summary>
        public static string Numero_interior
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Numero_interior", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Colonia</summary>
        public static string Colonia
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Colonia", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>CP</summary>
        public static string CP
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("CP", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Ciudad</summary>
        public static string Ciudad
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Ciudad", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estado</summary>
        public static string Estado
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Estado", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Pais</summary>
        public static string Pais
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Pais", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Permite_Familiares</summary>
        public static string Permite_Familiares
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Permite_Familiares", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Estatus</summary>
        public static string Estatus
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Estatus", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Actividades_del_Evento</summary>
        public static string Actividades_del_Evento
        {
            get
            {
                SetPath();
                return resourceProviderEventos.GetResource("Actividades_del_Evento", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderEventos.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Actividades</summary>	public static string TabActividades 	{		get		{			SetPath();  			return resourceProviderEventos.GetResource("TabActividades", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
