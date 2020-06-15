using Resources.Abstract;
using Resources.Concrete;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;

namespace Resources
{
    public static class LoginResources
    {
        private static IResourceProvider resourceLoginProvider = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Resources." + CultureInfo.CurrentUICulture.Name + ".xml"));

        public static void SetPath()
        {
            resourceLoginProvider = new XmlResourceProvider(Path.Combine(ConfigurationManager.AppSettings["BaseDirectoyPhysical"].ToString(), @"Uploads\Resources\Resources." + CultureInfo.CurrentUICulture.Name + ".xml"));
        }
        
        /// <summary>UserName</summary>
        public static string UserName
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("UserName", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        
        /// <summary>Password</summary>
        public static string Password
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("Password", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>RememberMe</summary>
        public static string RememberMe
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("RememberMe", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Login</summary>
        public static string Login
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("Login", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>WelcomeSpartan</summary>
        public static string WelcomeSpartan
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("WelcomeSpartan", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>SpartanLogin</summary>
        public static string SpartanLogin
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("SpartanLogin", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>SpartanLoginHeader</summary>
        public static string SpartanLoginHeader
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("SpartanLoginHeader", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>Language</summary>
        public static string Language
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("Language", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>UserNameRequired</summary>
        public static string UserNameRequired
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("UserNameRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>PasswordRequired</summary>
        public static string PasswordRequired
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("PasswordRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>InvalidUserPassword</summary>
        public static string InvalidUserPassword
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("InvalidUserPassword", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>DeactivateAccount</summary>
        public static string DeactivateAccount
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("DeactivateAccount", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>SessionExpired</summary>
        public static string SessionExpired
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("SessionExpired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>InvalidPassword</summary>
        public static string InvalidPassword
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("InvalidPassword", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        /// <summary>Email</summary>
        public static string Email
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("Email", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>EmailRequired</summary>
        public static string EmailRequired
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("EmailRequired", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>InvalidEmailUserName</summary>
        public static string InvalidEmailUserName
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("InvalidEmailUserName", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>InvalidEmail</summary>
        public static string InvalidEmail
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("InvalidEmail", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ForgotPassword</summary>
        public static string ForgotPassword
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("ForgotPassword", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ForgotPasswordSuccess</summary>
        public static string ForgotPasswordSuccess
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("ForgotPasswordSuccess", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ForgotPasswordButton</summary>
        public static string ForgotPasswordButton
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("ForgotPasswordButton", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        

        /// <summary>ForgotPasswordEmailError</summary>
        public static string ForgotPasswordEmailError
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("ForgotPasswordEmailError", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ForgotPasswordEmailSubject</summary>
        public static string ForgotPasswordEmailSubject
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("ForgotPasswordEmailSubject", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ChangePassword</summary>
        public static string ChangePassword
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("ChangePassword", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>CurrentPassword</summary>
        public static string CurrentPassword
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("CurrentPassword", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>CharactersLong</summary>
        public static string CharactersLong
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("CharactersLong", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>NewPassword</summary>
        public static string NewPassword
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("NewPassword", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ConfirmNewPassword</summary>
        public static string ConfirmNewPassword
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("ConfirmNewPassword", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>PasswordMatch</summary>
        public static string PasswordMatch
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("PasswordMatch", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>PasswordChanged</summary>
        public static string PasswordChanged
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("PasswordChanged", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>EnteredPasswordInCorrect</summary>
        public static string EnteredPasswordInCorrect
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("EnteredPasswordInCorrect", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        /// <summary>ErrorUpdatePassword</summary>
        public static string ErrorUpdatePassword
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("ErrorUpdatePassword", CultureInfo.CurrentUICulture.Name) as String;
            }
        }


        /// <summary>ErrorUpdatePassword</summary>
        public static string SessionEnd
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("SessionEnd", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /// <summary>ExpiredPassword</summary>
        public static string ExpiredPassword
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("ExpiredPassword", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        /*For html Template */
        public static string Hello
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("Hello", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string textTemplateEmail1
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("textTemplateEmail1", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
        public static string textTemplateEmail2
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("textTemplateEmail2", CultureInfo.CurrentUICulture.Name) as String;
            }
        }

        public static string ErrorNewPassword
        {
            get
            {
                SetPath();
                return resourceLoginProvider.GetResource("ErrorNewPassword", CultureInfo.CurrentUICulture.Name) as String;
            }
        }
    }

}