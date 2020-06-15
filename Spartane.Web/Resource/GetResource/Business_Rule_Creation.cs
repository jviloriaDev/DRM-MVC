using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Business_Rule_CreationResources
    {
        //private static IResourceProvider resourceProviderBusiness_Rule_Creation = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Business_Rule_CreationResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderBusiness_Rule_Creation = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Business_Rule_CreationResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderBusiness_Rule_Creation = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Business_Rule_CreationResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Business_Rule_Creation</summary>
        public static string Business_Rule_Creation
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("Business_Rule_Creation", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Key_Business_Rule_Creation</summary>
        public static string Key_Business_Rule_Creation
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("Key_Business_Rule_Creation", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>User</summary>
        public static string User
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("User", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Creation_Date</summary>
        public static string Creation_Date
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("Creation_Date", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Creation_Hour</summary>
        public static string Creation_Hour
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("Creation_Hour", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Last_Updated_Date</summary>
        public static string Last_Updated_Date
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("Last_Updated_Date", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Last_Updated_Hour</summary>
        public static string Last_Updated_Hour
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("Last_Updated_Hour", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Time_that_took</summary>
        public static string Time_that_took
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("Time_that_took", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Name</summary>
        public static string Name
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("Name", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Documentation</summary>
        public static string Documentation
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("Documentation", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Conditions</summary>
        public static string Conditions
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("Conditions", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Actions_if_conditions_are_True</summary>
        public static string Actions_if_conditions_are_True
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("Actions_if_conditions_are_True", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Actions_if_conditions_are_False</summary>
        public static string Actions_if_conditions_are_False
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("Actions_if_conditions_are_False", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Operations</summary>
        public static string Operations
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("Operations", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Events</summary>
        public static string Events
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("Events", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Peer_Reviews</summary>
        public static string Peer_Reviews
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("Peer_Reviews", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Testing</summary>
        public static string Testing
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("Testing", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Scopes</summary>
        public static string Scopes
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("Scopes", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Status</summary>
        public static string Status
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("Status", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Complexity</summary>
        public static string Complexity
        {
            get
            {
                SetPath();
                return resourceProviderBusiness_Rule_Creation.GetResource("Complexity", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderBusiness_Rule_Creation.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Peer Review</summary>	public static string TabPeer_Review 	{		get		{			SetPath();  			return resourceProviderBusiness_Rule_Creation.GetResource("TabPeer_Review", CultureInfo.CurrentUICulture.Name) as String;             		}	}
	/// <summary>Testing</summary>	public static string TabTesting 	{		get		{			SetPath();  			return resourceProviderBusiness_Rule_Creation.GetResource("TabTesting", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    /// <summary>Testing</summary>
    public static string ErrorName
    {
        get
        {
            SetPath();
            return resourceProviderBusiness_Rule_Creation.GetResource("ErrorName", CultureInfo.CurrentUICulture.Name) as String;
        }
    }

    /// <summary>Testing</summary>
    public static string StatusChanged
    {
        get
        {
            SetPath();
            return resourceProviderBusiness_Rule_Creation.GetResource("StatusChanged", CultureInfo.CurrentUICulture.Name) as String;
        }
    }

    /// <summary>Testing</summary>
    public static string TabHistory
    {
        get
        {
            SetPath();
            return resourceProviderBusiness_Rule_Creation.GetResource("TabHistory", CultureInfo.CurrentUICulture.Name) as String;
        }
    }
        
    }
}
