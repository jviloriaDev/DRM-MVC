using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_Bitacora_SQLResources
    {
        //private static IResourceProvider resourceProviderSpartan_Bitacora_SQL = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_Bitacora_SQLResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_Bitacora_SQL = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Bitacora_SQLResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_Bitacora_SQL = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_Bitacora_SQLResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_Bitacora_SQL</summary>
        public static string Spartan_Bitacora_SQL
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Bitacora_SQL.GetResource("Spartan_Bitacora_SQL", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio</summary>
        public static string Folio
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Bitacora_SQL.GetResource("Folio", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Id_User</summary>
        public static string Id_User
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Bitacora_SQL.GetResource("Id_User", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Type_SQL</summary>
        public static string Type_SQL
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Bitacora_SQL.GetResource("Type_SQL", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Register_Date</summary>
        public static string Register_Date
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Bitacora_SQL.GetResource("Register_Date", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Computer_Name</summary>
        public static string Computer_Name
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Bitacora_SQL.GetResource("Computer_Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Server_Name</summary>
        public static string Server_Name
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Bitacora_SQL.GetResource("Server_Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Database_Name</summary>
        public static string Database_Name
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Bitacora_SQL.GetResource("Database_Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>System_Name</summary>
        public static string System_Name
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Bitacora_SQL.GetResource("System_Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>System_Version</summary>
        public static string System_Version
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Bitacora_SQL.GetResource("System_Version", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Windows_Version</summary>
        public static string Windows_Version
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Bitacora_SQL.GetResource("Windows_Version", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Command_SQL</summary>
        public static string Command_SQL
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Bitacora_SQL.GetResource("Command_SQL", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Folio_SQL</summary>
        public static string Folio_SQL
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Bitacora_SQL.GetResource("Folio_SQL", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Object_Id</summary>
        public static string Object_Id
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Bitacora_SQL.GetResource("Object_Id", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>IP</summary>
        public static string IP
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Bitacora_SQL.GetResource("IP", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Json</summary>
        public static string Json
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Bitacora_SQL.GetResource("Json", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Result</summary>
        public static string Result
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Bitacora_SQL.GetResource("Result", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Error</summary>
        public static string Error
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_Bitacora_SQL.GetResource("Error", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderSpartan_Bitacora_SQL.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
