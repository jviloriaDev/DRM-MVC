using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Spartane.Web.Areas.Frontal.Models;
using Spartane.Core.Domain.SpartaneUserRoleModule;
using Spartane.Core.Domain.SpartanModule;
using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
using Spartane.Web.Models;
using Spartan_User = Spartane.Web.Models.Spartan_User;

//using Spartane.Core.Domain.User;

namespace Spartane.Web
{
    public class SessionHelper
    {

      



        public static Spartane_Credential UserCredential
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["Spartan_User_Credentials"] != null)
                    return (Spartane_Credential)HttpContext.Current.Session["Spartan_User_Credentials"];
                else
                    return null;
            }

            set
            {
                HttpContext.Current.Session["Spartan_User_Credentials"] = value;
            }
        }


        public static ApiToken UserApiToken
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["Spartan_User_Token"] != null)
                    return (ApiToken)HttpContext.Current.Session["Spartan_User_Token"];
                else
                    return null;
            }

            set
            {
                if (HttpContext.Current.Session != null)
                HttpContext.Current.Session["Spartan_User_Token"] = value;
            }
        }




        public static SpartanUser UserEntity
        {

            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["Spartan_User_Information"] != null)
                    return (SpartanUser)HttpContext.Current.Session["Spartan_User_Information"];
                else
                    return null;
            }

            set
            {
                HttpContext.Current.Session["Spartan_User_Information"] = value;
            }

        }


        public static byte[] UserImage
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["Spartan_User_Image"] != null)
                    return (byte[])HttpContext.Current.Session["Spartan_User_Image"];
                else
                    return null;
            }

            set
            {
                HttpContext.Current.Session["Spartan_User_Image"] = value;
            }
        }


        public static Spartan_User User
        {

            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["Spartan_User"] != null)
                    return (Spartan_User)HttpContext.Current.Session["Spartan_User"];
                else 
                    return null;            
            }

            set
            {
                HttpContext.Current.Session["Spartan_User"] = value;
            }
        
        }

        public static Spartan_System System
        {

            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["Spartan_System"] != null)
                    return (Spartan_System)HttpContext.Current.Session["Spartan_System"];
                else
                    return null;
            }

            set
            {
                HttpContext.Current.Session["Spartan_System"] = value;
            }

        }

        public static string UserLayout
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["UserLayout"] != null)
                    return (string)HttpContext.Current.Session["UserLayout"];
                else
                    return "~/Areas/Frontal/Views/Shared/_Layout.cshtml";
            }

            set
            {
                HttpContext.Current.Session["UserLayout"] = value;
            }
        }

        /// <summary>
        /// Store Role Id in session
        /// </summary>
        public static int Role
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["Spartan_Role"] != null)
                    return (int)HttpContext.Current.Session["Spartan_Role"];
                else
                    return 0;
            }
            set
            {
                HttpContext.Current.Session["Spartan_Role"] = value;
            }
        }

        public static Spartane.Core.Domain.User.RoleSpartanUserRole Sprtan_Role
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["Spartan_RoleSpartanUserRole"] != null)
                    return (Spartane.Core.Domain.User.RoleSpartanUserRole)HttpContext.Current.Session["Spartan_RoleSpartanUserRole"];
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Session["Spartan_RoleSpartanUserRole"] = value;
            }
        }


        public static int languageid
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["LANGUAGEID"] != null)
                    return (int)HttpContext.Current.Session["LANGUAGEID"];
                else
                    return 1;
            }
            set
            {
                HttpContext.Current.Session["LANGUAGEID"] = value;
            }
        }

        public static bool Relogin
        {
            get
            {
                if (HttpContext.Current.Session != null && HttpContext.Current.Session["Relogin"] != null)
                    return Convert.ToBoolean(HttpContext.Current.Session["Relogin"]);
                else
                    return false;
            }
            set
            {
                HttpContext.Current.Session["Relogin"] = value;
            }
        }
    }
}