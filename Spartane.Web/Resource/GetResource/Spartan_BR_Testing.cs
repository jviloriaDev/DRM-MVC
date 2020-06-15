using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_TestingResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Testing = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_TestingResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Testing = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_TestingResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_BR_Testing = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_TestingResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_BR_Testing</summary>
        public static string Spartan_BR_Testing
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Testing.GetResource("Spartan_BR_Testing", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Key_Testing</summary>
        public static string Key_Testing
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Testing.GetResource("Key_Testing", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>User_that_reviewed</summary>
        public static string User_that_reviewed
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Testing.GetResource("User_that_reviewed", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Acceptance_Critera</summary>
        public static string Acceptance_Critera
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Testing.GetResource("Acceptance_Critera", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>It_worked</summary>
        public static string It_worked
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Testing.GetResource("It_worked", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Rejection_Reason</summary>
        public static string Rejection_Reason
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Testing.GetResource("Rejection_Reason", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Comments</summary>
        public static string Comments
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Testing.GetResource("Comments", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Evidence</summary>
        public static string Evidence
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Testing.GetResource("Evidence", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderSpartan_BR_Testing.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
