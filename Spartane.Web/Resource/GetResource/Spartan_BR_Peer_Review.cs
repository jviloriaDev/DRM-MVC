using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Globalization;
using System.Configuration;
using System.IO;

namespace Resources
{
    public partial class Spartan_BR_Peer_ReviewResources
    {
        //private static IResourceProvider resourceProviderSpartan_BR_Peer_Review = new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Uploads\Resources\Spartan_BR_Peer_ReviewResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        private static IResourceProvider resourceProviderSpartan_BR_Peer_Review = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Peer_ReviewResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        
        public static void SetPath()
        {
            resourceProviderSpartan_BR_Peer_Review = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Spartan_BR_Peer_ReviewResource." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        /// <summary>Spartan_BR_Peer_Review</summary>
        public static string Spartan_BR_Peer_Review
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Peer_Review.GetResource("Spartan_BR_Peer_Review", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Key_Peer_Review</summary>
        public static string Key_Peer_Review
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Peer_Review.GetResource("Key_Peer_Review", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>User_that_reviewed</summary>
        public static string User_that_reviewed
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Peer_Review.GetResource("User_that_reviewed", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Acceptance_Criteria</summary>
        public static string Acceptance_Criteria
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Peer_Review.GetResource("Acceptance_Criteria", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>It_worked</summary>
        public static string It_worked
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Peer_Review.GetResource("It_worked", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Rejection_reason</summary>
        public static string Rejection_reason
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Peer_Review.GetResource("Rejection_reason", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Comments</summary>
        public static string Comments
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Peer_Review.GetResource("Comments", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Evidence</summary>
        public static string Evidence
        {
            get
            {
                SetPath();
                return resourceProviderSpartan_BR_Peer_Review.GetResource("Evidence", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


	/// <summary>Datos Generales</summary>	public static string TabDatos_Generales 	{		get		{			SetPath();  			return resourceProviderSpartan_BR_Peer_Review.GetResource("TabDatos_Generales", CultureInfo.CurrentUICulture.Name) as String;             		}	}

    }
}
