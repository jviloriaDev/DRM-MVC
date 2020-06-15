using Spartane.Core.Domain.Binnacle;
using Spartane.Core.Domain.Language;
using Spartane.Core.Domain.User;
using Spartane.Core.Enums;
using Spartane.Services.Authentication;
using Spartane.Services.Security;
using Spartane.Services.User;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Settings;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Historical_Password;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.SpartaneQuery;
using Spartane.Web.AuthenticationExt;
using Spartane.Web.Helpers;
using Spartane.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Spartane.Web.Controllers
{
    [Authorize]
    public partial class AccountController : BaseController
    {
        #region "variable Declaration"

        private readonly IAuthenticationService _authenticationService;
        private readonly IUserService _userService;
        private readonly IPermissionService _permissionService;

        private ILanguageApiConsumer _ILanguageoApiConsumer;
        private ISpartan_UserApiConsumer _IUseroApiConsumer;
        private ISpartanSecurityApiConsumer _ISpartanSecurityApiConsumer;
        private ISpartanSessionApiConsumer _ISpartanSessionApiConsumer;

        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        private ISpartan_SettingsApiConsumer _ISpartan_SettingsApiConsumer;
        private ISpartaneQueryApiConsumer _ISpartaneQueryApiConsumer;

        #endregion "variable Declaration"

        #region "Constructor"

        public AccountController(IAuthenticationService authenticationService,
            IUserService userService, ISpartane_FileApiConsumer Spartane_FileApiConsumer, 
            IPermissionService permissionService, ITokenManager tokenManager, 
            IAuthenticationApiConsumer authenticationApiConsumer, ILanguageApiConsumer languageoApiConsumer, 
            ISpartan_UserApiConsumer UseroApiConsumer, ISpartanSessionApiConsumer oSpartanSessionAPIConsumer,
            ISpartanSecurityApiConsumer oSpartanSecurityAPIConsumer, ISpartan_SettingsApiConsumer Spartan_SettingsApiConsumer,
            ISpartaneQueryApiConsumer SpartaneQueryApiConsumer)
        {
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._authenticationService = authenticationService;
            this._userService = userService;
            this._permissionService = permissionService;

            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;

            this._ILanguageoApiConsumer = languageoApiConsumer;
            this._IUseroApiConsumer = UseroApiConsumer;

            this._ISpartanSecurityApiConsumer = oSpartanSecurityAPIConsumer;
            this._ISpartanSessionApiConsumer = oSpartanSessionAPIConsumer;

            this._ISpartan_SettingsApiConsumer = Spartan_SettingsApiConsumer;
            this._ISpartaneQueryApiConsumer = SpartaneQueryApiConsumer;
        }

        #endregion "Constructor"

        #region Login / Logout

        /// <summary>
        /// Get Login View
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            VersionValidation version = ValidateVersion();
            string versionError = "";
            if (version != null)
            {
                if (version.VersionWebApi != version.VersionMVC)
                {
                    versionError += "La version de WebAPI no corresponde con el proyecto MVC <br />";
                }
                if (version.VersionDB != version.VersionMVC)
                {
                    versionError += "La version de Base de Datos no corresponde con el proyecto MVC";
                }
            }
            else
                versionError = "Error al validar version";
            LoginViewModel oLoginViewModel = new LoginViewModel();

            oLoginViewModel.LanguageList = GetLanguage();
            oLoginViewModel.FailedAttempts = 1;

            

            ViewBag.ReturnUrl = returnUrl;
            if (ConfigurationManager.AppSettings["ActivateValidation"] != null && Convert.ToBoolean(ConfigurationManager.AppSettings["ActivateValidation"]))
                ViewBag.VersionError = versionError;
            return View(oLoginViewModel);
        }

        /// <summary>
        /// Login Post method for check authorization and logged in with system
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl= "")
        {
            
            Session["BlockUser"] = null;
            if (ModelState.ContainsKey("LanguageList"))
            { ModelState["LanguageList"].Errors.Clear(); }

            if (ModelState.IsValid)
            {
                string passwordEncripted = EncryptHelper.CalculateMD5Hash(model.Password);
                if (!_tokenManager.GenerateToken(model.UserName, passwordEncripted))
                {
                    ModelState.AddModelError("", Resources.LoginResources.InvalidUserPassword);
                    if (SessionHelper.Relogin) 
                        return Json(Resources.LoginResources.InvalidUserPassword);
                }

                _ISpartan_SettingsApiConsumer.SetAuthHeader(_tokenManager.Token);
                var FailedAttemptDB = _ISpartan_SettingsApiConsumer.GetByKey("FailedAttempts", false).Resource;
                int FailedAttempts = Convert.ToInt32(FailedAttemptDB.Valor);
                model.MaxFailedAttempts = FailedAttempts;

                if (Session["UserName"] != null && Session["UserName"].ToString() != model.UserName)
                {
                    model.FailedAttempts = 1;
                }
                Session["UserName"] = model.UserName;
                _IUseroApiConsumer.SetAuthHeader(_tokenManager.Token);
                
                Spartan_Security_Log oSecurityLog = new Spartan_Security_Log();
                var users = _ISpartaneQueryApiConsumer.ExecuteRawQuery2<List<Spartane.Core.Domain.Spartan_User.Spartan_User>>
                   ("select * from spartan_user where username = @p1 COLLATE SQL_Latin1_General_CP1_CS_AS and Password = @p2 COLLATE SQL_Latin1_General_CP1_CS_AS",
                   model.UserName, passwordEncripted);
                var UsersByName = _IUseroApiConsumer.ListaSelAll(0, 10, "Spartan_User.Username = '" + model.UserName + "'", "").Resource;
                if (UsersByName.RowCount == 0 || (users == null || users.Count == 0))
                {
                    ModelState.AddModelError("", Resources.LoginResources.InvalidUserPassword);
                    model.LanguageList = GetLanguage();
                    SessionHelper.Relogin = false;
                    return View(model);
                }
                // Call Validate User API for user Exists in application
                Spartan_User_Core UserDetails = _IUseroApiConsumer.ValidateUser(1, 10, "Username = '" + model.UserName + "'  COLLATE SQL_Latin1_General_CP1_CS_AS And Password = '" + EncryptHelper.CalculateMD5Hash(model.Password) + "'  COLLATE SQL_Latin1_General_CP1_CS_AS").Resource;
                if (UserDetails.Spartan_Users != null && UserDetails.Spartan_Users.Count() > 0)
                {
                    if (UserDetails.Spartan_Users[0].Status == 1)
                    {
                        var spartan_user = new Core.Domain.Spartan_User.Spartan_User
                        {
                            Id_User = UserDetails.Spartan_Users[0].Id_User,
                            Name = UserDetails.Spartan_Users[0].Name,
                            Password = UserDetails.Spartan_Users[0].Password
                        };

                        TTUsuario user = new TTUsuario
                        {
                            IdUsuario = Convert.ToInt16(UserDetails.Spartan_Users[0].Id_User),
                            Nombre = Convert.ToString(UserDetails.Spartan_Users[0].Name),
                            Clave_de_Acceso = UserDetails.Spartan_Users[0].Username,
                            //Activo = UserDetails.Spartan_Users[0].Status
                        };

                        SetSecurityLogging(ref oSecurityLog, (short)Event_Type.Login, UserDetails.Spartan_Users[0].Id_User, UserDetails.Spartan_Users[0].Role, (short)Result_Type.Granted);
                        int SecurityLogId = _ISpartanSecurityApiConsumer.Insert(oSecurityLog).Resource;

                        SetAuthentication(UserDetails);
                        //_authenticationService.SignIn(user, model.RememberMe);

                        //Adding user Core entity Data
                        SessionHelper.UserEntity = UserDetails.Spartan_Users[0];

                        //Getting User Image
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        var userImage =
                            _ISpartane_FileApiConsumer.GetByKey(Convert.ToInt32(UserDetails.Spartan_Users[0].Image))
                                .Resource;
                        if (userImage != null && userImage.File != null)
                            SessionHelper.UserImage = userImage.File;
                        Response.Cookies["UserSettings"]["SecurityLogId"] = SecurityLogId.ToString();

                        Spartan_Session_Log oSessionLog = new Spartan_Session_Log();
                        SetSessionLogging(ref oSessionLog, (short)Event_Type.Login, (short)Event_Type.Login, SecurityLogId, UserDetails.Spartan_Users[0].Id_User, UserDetails.Spartan_Users[0].Role, (short)Result_Type.Granted);
                        _ISpartanSessionApiConsumer.Insert(oSessionLog);


                        //Saving Credentials
                        SessionHelper.UserCredential = new Spartane_Credential
                        {
                            Password = EncryptHelper.CalculateMD5Hash(model.Password),
                            UserName = model.UserName,
                        };
                        // save role id in session
                        SessionHelper.Role = UserDetails.Spartan_Users[0].Role;
                        // save role object in session
                        SessionHelper.Sprtan_Role = new RoleSpartanUserRole
                        {
                            Id = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.Id,
                            Description = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.Description,
                            Status = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.Status,
                            Status_Spartan_User_Role_Status = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.Status_Spartan_User_Role_Status,
                            User_Role_Id = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.User_Role_Id,
                        };
                        Session["USERID"] = user.IdUsuario;
                        Session["USERROLEID"] = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.User_Role_Id;
                        Session.Timeout = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]);
                        Session["LANGUAGEID"] = (model.SelectedLanguage.HasValue) ? model.SelectedLanguage.Value : 1;
                        SessionHelper.Relogin = false;
                        PermissionHelper.SetPermissions();
                        MenuHelper.GetLatestMenu();
                        return RedirectToLocal("~/Frontal/Home/Index");
                    }
                    else
                    {
                        SetSecurityLogging(ref oSecurityLog, (short)Event_Type.Login, null, null, (short)Result_Type.Denied);
                        _ISpartanSecurityApiConsumer.Insert(oSecurityLog);

                        ModelState.AddModelError("", Resources.LoginResources.DeactivateAccount);
                        if (SessionHelper.Relogin) 
                            return Json(Resources.LoginResources.DeactivateAccount);
                    }
                }
                else
                {
                    SetSecurityLogging(ref oSecurityLog, (short)Event_Type.Login, null, null, (short)Result_Type.Denied);
                    _ISpartanSecurityApiConsumer.Insert(oSecurityLog);
                   
                    if (model.FailedAttempts < model.MaxFailedAttempts)
                    {
						ModelState.AddModelError("", Resources.LoginResources.InvalidUserPassword);
                        model.FailedAttempts = model.FailedAttempts + 1;
                    }
                    else
                    {
                        
                        if (UsersByName.RowCount == 1)
                        {
                            var UserByName = UsersByName.Spartan_Users.First();
                            UserByName.Status = 2;
                            int status = _IUseroApiConsumer.Update(UserByName, null, null).Resource;
                            model.FailedAttempts = 1;
							ModelState.AddModelError("", Resources.LoginResources.DeactivateAccount);
                        }
                        Session["BlockUser"] = true;
                    }
                    if (SessionHelper.Relogin) 
                        return Json(Resources.LoginResources.InvalidUserPassword);
                }
            }
            model.LanguageList = GetLanguage();
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ReLogin(LoginViewModel model, string returnUrl)
        {
           
                if (ModelState.ContainsKey("LanguageList"))
                { ModelState["LanguageList"].Errors.Clear(); }


                SessionHelper.Relogin = true;

                if (Session.Count <= 1)
                {
                    LoginViewModel oLoginViewModel = new LoginViewModel();
                    oLoginViewModel.LanguageList = GetLanguage();
                    oLoginViewModel.UserName = model.UserName;
                    oLoginViewModel.Password = model.Password;
                    return Login(oLoginViewModel);
                }

          

                if (ModelState.IsValid)
                {
                    if (!_tokenManager.GenerateToken(model.UserName, EncryptHelper.CalculateMD5Hash(model.Password)))
                    {
                        ModelState.AddModelError("", Resources.LoginResources.InvalidUserPassword);
                        return Json(Resources.LoginResources.InvalidUserPassword);
                    }

                    _IUseroApiConsumer.SetAuthHeader(_tokenManager.Token);

                    // Call Validate User API for user Exists in application
                    Spartan_User_Core UserDetails = _IUseroApiConsumer.ValidateUser(1, 10, "Username = '" + model.UserName + "'  COLLATE SQL_Latin1_General_CP1_CS_AS And Password = '" + EncryptHelper.CalculateMD5Hash(model.Password) + "'  COLLATE SQL_Latin1_General_CP1_CS_AS").Resource;
                    if (UserDetails.Spartan_Users != null && UserDetails.Spartan_Users.Count() > 0)
                    {
                        //return Json(string.Empty);
                        if (UserDetails.Spartan_Users[0].Status == 1)
                        {
                            TTUsuario user = new TTUsuario
                            {
                                IdUsuario = Convert.ToInt16(UserDetails.Spartan_Users[0].Id_User),
                                Nombre = Convert.ToString(UserDetails.Spartan_Users[0].Name),
                                Clave_de_Acceso = UserDetails.Spartan_Users[0].Username,
                                //Activo = UserDetails.Spartan_Users[0].Status
                            };


                            SetAuthentication(UserDetails);
                            //_authenticationService.SignIn(user, model.RememberMe);


                            //Saving Credentials
                            SessionHelper.UserCredential = new Spartane_Credential
                            {
                                Password = EncryptHelper.CalculateMD5Hash(model.Password),
                                UserName = model.UserName,
                            };
                            // save role id in session
                            SessionHelper.Role = UserDetails.Spartan_Users[0].Role;
                            // save role object in session
                            SessionHelper.Sprtan_Role = new RoleSpartanUserRole
                            {
                                Id = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.Id,
                                Description = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.Description,
                                Status = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.Status,
                                Status_Spartan_User_Role_Status = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.Status_Spartan_User_Role_Status,
                                User_Role_Id = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.User_Role_Id,
                            };
                            Session["USERID"] = user.IdUsuario;
                            Session["USERROLEID"] = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.User_Role_Id;
                            Session.Timeout = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]);

                            SessionHelper.Relogin = false;
                            return Json(string.Empty);

                        }
                        else
                        {
                            ModelState.AddModelError("", Resources.LoginResources.DeactivateAccount);
                            return Json(Resources.LoginResources.DeactivateAccount);
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", Resources.LoginResources.InvalidPassword);
                        return Json(Resources.LoginResources.InvalidPassword);
                    }

                }
               
            return Json("SessionExpired");
        }

        // POST: /Account/LogOff
        [HttpPost]
        public ActionResult LogOff()
        {

            Spartan_Session_Log oSessionLog = new Spartan_Session_Log();
            SetSessionLogging(ref oSessionLog, (short)Event_Type.Login, (short)Event_Type.LogOut, Convert.ToInt32(Request.Cookies["UserSettings"]["SecurityLogId"]), CurrentUser.CurrentUser.Id_User, CurrentUser.CurrentUser.Role, (short)Result_Type.Granted);
            _ISpartanSessionApiConsumer.Insert(oSessionLog);

            FormsAuthentication.SignOut();

            // clear all session
            Session.Abandon();
            // Clear authentication cookie.
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);
            HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Response.Cache.SetNoServerCaching();
            HttpContext.Response.Cache.SetNoStore();

            return RedirectToAction("Login", "Account");
        }


        #endregion Login / Logout

        #region "Forgot password"

        [HttpPost]
        [AllowAnonymous]
        public JsonResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Spartan_User_Core UserDetails = _IUseroApiConsumer.ValidateUser(1, 10, "Username = '" + model.UserName + "'  COLLATE SQL_Latin1_General_CP1_CS_AS And Email = '" + model.Email + "'").Resource;
                    if (UserDetails.Spartan_Users != null && UserDetails.Spartan_Users.Count() > 0)
                    {
                        if (System.IO.File.Exists(Server.MapPath("~/HTMLTemplates/ForgotPassword.html")))
                        {
                            // Get HTML Template for Forgot password
                            StreamReader sread = new StreamReader(Server.MapPath("~/HTMLTemplates/ForgotPassword.html"));
                            string strBodyTemplate = sread.ReadToEnd();
                            // Replace User Full Name
                            strBodyTemplate = strBodyTemplate.Replace("*|fullname|*", UserDetails.Spartan_Users[0].Name);
                            strBodyTemplate = strBodyTemplate.Replace("*|username|*", UserDetails.Spartan_Users[0].Username);
                            strBodyTemplate = strBodyTemplate.Replace("*|email|*", UserDetails.Spartan_Users[0].Email);
                            //strBodyTemplate = strBodyTemplate.Replace("*|password|*", UserDetails.Spartan_Users[0].Password);


                            //Replace text for apropiates values in Resources
                            strBodyTemplate = strBodyTemplate.Replace("*|text1|*", Resources.LoginResources.Hello);
                            strBodyTemplate = strBodyTemplate.Replace("*|text2|*", Resources.LoginResources.textTemplateEmail1);
                            strBodyTemplate = strBodyTemplate.Replace("*|text3|*", Resources.LoginResources.UserName.ToString());
                            strBodyTemplate = strBodyTemplate.Replace("*|text4|*", Resources.LoginResources.Email.ToString());
                            strBodyTemplate = strBodyTemplate.Replace("*|text5|*", Resources.LoginResources.Password);
                            strBodyTemplate = strBodyTemplate.Replace("*|text6|*", Resources.LoginResources.textTemplateEmail2.ToString()); 


                            if (!_tokenManager.GenerateToken("admin", "admin"))
                                return null;

                            var userApi = new Spartan_UserApiConsumer();
                            userApi.SetAuthHeader(_tokenManager.Token);
                            var tmpuser = userApi.GetByKey(UserDetails.Spartan_Users[0].Id_User, false);                            
                            var pass = System.Web.Security.Membership.GeneratePassword(7, 0);
                            pass = System.Text.RegularExpressions.Regex.Replace(pass, @"[^a-zA-Z0-9]", m => "9");
                            tmpuser.Resource.Password = EncryptHelper.CalculateMD5Hash(pass);
                            var res = userApi.Update(tmpuser.Resource, null, null);

                            var userhistApi = new Spartan_User_Historical_PasswordApiConsumer();
                            userhistApi.SetAuthHeader(_tokenManager.Token);

                            res = userhistApi.Insert(new Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password()
                            {
                                Fecha_de_Registro = DateTime.Now,
                                Usuario = tmpuser.Resource.Id_User,
                                Password = tmpuser.Resource.Password
                            }, null, null);

                            strBodyTemplate = strBodyTemplate.Replace("*|password|*", pass);

                            // Replace ForgotPassword Link with Token and Encrypted Email
                            List<string> emails = new List<string>();
                            emails.Add(model.Email);
                            if (Helper.SendEmail(emails, string.Format(Resources.LoginResources.ForgotPasswordEmailSubject, model.UserName), strBodyTemplate))
                            {
                                return Json(string.Format(Resources.LoginResources.ForgotPasswordSuccess, model.Email));
                            }
                            else
                                return Json(Resources.LoginResources.ForgotPasswordEmailError);
                        }
                        else { return Json(Resources.LoginResources.ForgotPasswordEmailError); }
                    }
                    else
                    {
                        return Json(Resources.LoginResources.InvalidEmailUserName);
                    }
                }
                catch (Exception)
                {
                    return Json(Resources.LoginResources.ForgotPasswordEmailError);
                }
            }
            else
            {
                return Json(Resources.LoginResources.InvalidEmailUserName);
            }
        }

        #endregion


        #region "Change Language"

        /// <summary>
        /// Language Drop down change event
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult ChangeLanguage(string culture)
        {
            
            // To Do : currently we are not getting culture from language api once we got language culture than comment below line
            culture = (culture == "1" ? "en-US" : "es-ES");
            //culture = "es-ES";

            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;

            RouteData.Values["culture"] = culture;

            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);

            return RedirectToAction("Login");
        }

        /// <summary>
        /// Get List of language from API
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public IList<LanguageModel> GetLanguage()
        {
            IList<LanguageModel> LanguageList;

            // get language from API and cast from one entity to another entity list using generic reflection function
            LanguageList = Helper.ConvertToList<LanguageModel, SpartanLanguage>(_ILanguageoApiConsumer.GetAll().Resource);
            if (LanguageList == null)
            {
                LanguageList = new List<LanguageModel>();
            }


            return LanguageList;
        }

        #endregion "Change Language"

        #region Manage Information account

        // GET: /Account/Manage
        public ActionResult Manage()
        {
            InformationUser modelInformationUser = new InformationUser();

            var loginName = this.HttpContext.User.Identity.Name;
            var userGlobalData = _userService.GetGlobalDataByUserName(loginName);
            //var itemPerm = _permissionService.ModulesPermited(userGlobalData);
            //var dashboardsPermited = _permissionService.DashBoardsPermited(userGlobalData);
            //modelInformationUser.DashBoardsPermited = dashboardsPermited;
            modelInformationUser.GlobalData = userGlobalData;
            //modelInformationUser.ModulesPermited = itemPerm;
            modelInformationUser.OperationsPermited = new List<OperationPermited>();
            foreach (Operations operation in Enum.GetValues(typeof(Operations)))
            {
                OperationPermited operationPermited = new OperationPermited();
                operationPermited.Operation = operation;
                //operationPermited.Permited = _permissionService.isOperationPermited(6400, operation, userGlobalData);
                modelInformationUser.OperationsPermited.Add(operationPermited);
            }
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View(modelInformationUser);
        }

        #endregion Manage Information account

        #region Helpers

        /// <summary>
        /// Redirect to return URL
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [AllowAnonymous]
        public ActionResult ChangePassword()
        {
            var spartan_user = new ChangePasswordViewModel();
            spartan_user.Id_User = Convert.ToInt32(Session["tmpIdUser"]);
            spartan_user.UserName = Session["tmpUsername"].ToString();
            spartan_user.OldPassword = Session["tmpPassword"].ToString();
            spartan_user.ExpirationMessage = Session["tmpExpira"].ToString() == "1" ? Resources.LoginResources.ExpiredPassword : string.Empty;

            Session.Remove("tmpExpira");
            Session.Remove("tmpIdUser");
            Session.Remove("tmpUsername");
            Session.Remove("tmpPassword");

            return PartialView(spartan_user);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult UpdatePassword(string action, string oldpassword, string password, int iduser)
        {
            try
            {
                if (action == "cancel")
                {
                    //cancel
                    return Json(new { valor = 0, href = Url.Action("Login", "Account")});
                }
                else
                {
                    //guardar
                    if (!_tokenManager.GenerateToken("pepe", EncryptHelper.CalculateMD5Hash(password)))
                    {
                        ModelState.AddModelError("", Resources.LoginResources.InvalidUserPassword);
                    }

                    var userApi = new Spartan_UserApiConsumer();
                    userApi.SetAuthHeader(_tokenManager.Token);

                    var tmpuser = userApi.GetByKey(iduser, false);

                    if (tmpuser != null && tmpuser.Resource != null)
                    {

                        if (oldpassword == password)
                        {
                            return Json(new { valor = 2, message = Resources.LoginResources.ErrorNewPassword });
                        }

                        tmpuser.Resource.Password = EncryptHelper.CalculateMD5Hash(password);
                        var rta = userApi.Update(tmpuser.Resource, null, null);

                        var userhistApi = new Spartan_User_Historical_PasswordApiConsumer();
                        userhistApi.SetAuthHeader(_tokenManager.Token);

                        rta = userhistApi.Insert(new Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password()
                        {
                            Fecha_de_Registro = DateTime.Now,
                            Usuario = iduser,
                            Password = EncryptHelper.CalculateMD5Hash(password)
                        }, null, null);

                        return Json(new { valor = 1, href = Url.Action("Login", "Account") });
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                //error
                return null;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ValidateLogin(string username, string password)
        {
            try
            {
                string passEncripted = EncryptHelper.CalculateMD5Hash(password);
                var UserDetails = _IUseroApiConsumer.ValidateUser(1, 10, "Username = '" + username + "'  COLLATE SQL_Latin1_General_CP1_CS_AS And Password = '" + EncryptHelper.CalculateMD5Hash(password) + "'  COLLATE SQL_Latin1_General_CP1_CS_AS").Resource;
                if (UserDetails.Spartan_Users != null && UserDetails.Spartan_Users.Count() > 0)
                {
                    if (!_tokenManager.GenerateToken(username, EncryptHelper.CalculateMD5Hash(password)))
                    {
                        ModelState.AddModelError("", Resources.LoginResources.InvalidUserPassword);
                    }
                    if (UserDetails.Spartan_Users.FirstOrDefault().Status == 2)
                    {
                        ModelState.AddModelError("", Resources.LoginResources.DeactivateAccount);
                        return Json(new { valor = 0 });
                    }
                    var histPasswordApi = new Spartan_User_Historical_PasswordApiConsumer();
                    histPasswordApi.SetAuthHeader(_tokenManager.Token);

                    var histUser = histPasswordApi.ListaSelAll(0, 9999, "Spartan_User_Historical_Password.Usuario=" + UserDetails.Spartan_Users[0].Id_User, "").Resource;

                    //validacion de cantidades de logins realizados
                    if (histUser.RowCount > 0)
                    {
                        //validacion de expirtacion
                        _ISpartan_SettingsApiConsumer.SetAuthHeader(_tokenManager.Token);
                        var ExpirationDaysDB = _ISpartan_SettingsApiConsumer.GetByKey("ExpirationDays", false).Resource;
                        int ExpirationDays = Convert.ToInt32(ExpirationDaysDB.Valor);
                        //TODO: obtener cantidad de dias para expirtacion de pwd
                        var lastLogin = histUser.Spartan_User_Historical_Passwords.OrderByDescending(h => h.Clave).FirstOrDefault();
                        if ((DateTime.Now - Convert.ToDateTime(lastLogin.Fecha_de_Registro)).TotalDays > ExpirationDays)
                        {
                            //debe cambiar la password por expiracion
                            Session["tmpExpira"] = 1;
                            Session["tmpIdUser"] = UserDetails.Spartan_Users[0].Id_User;
                            Session["tmpUsername"] = username;
                            Session["tmpPassword"] = password;
                            return Json(new { valor = 1 });
                        }
                        else
                        {
                            //inicia sesion normalmente
                            return Json(new { valor = 2 });
                        }
                    }
                    else
                    {
                        //debe cambiar la password por ser el primer login
                        Session["tmpExpira"] = 0;
                        Session["tmpIdUser"] = UserDetails.Spartan_Users[0].Id_User;
                        Session["tmpUsername"] = username;
                        Session["tmpPassword"] = password;
                        return Json(new { valor = 1 });
                    }
                }

                //credenciales incorrectas
                return Json(new { valor = 0 });
            }
            catch (Exception ex)
            {
                //error
                return null;
            }
        }

        private void SetAuthentication(Spartan_User_Core UserDetails)
        {
            // create instance of context view model
            ContextViewModel CM = new ContextViewModel();

            // set logged in values with context view model to store values with cookies
            CM.Email = UserDetails.Spartan_Users[0].Email;
            CM.Id = UserDetails.Spartan_Users[0].Id;
            CM.Id_User = UserDetails.Spartan_Users[0].Id_User;
            CM.Password = UserDetails.Spartan_Users[0].Password;
            CM.Role = UserDetails.Spartan_Users[0].Role;
            CM.Status = UserDetails.Spartan_Users[0].Status;
            CM.Name = UserDetails.Spartan_Users[0].Name;
            CM.UserName = UserDetails.Spartan_Users[0].Username;

            AuthenticationSerialize serialiseAuth = new AuthenticationSerialize();

            UserContextViewModel userContext = new UserContextViewModel();
            userContext.CurrentUser = CM;
            serialiseAuth.UserContext = userContext;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string userData = serializer.Serialize(serialiseAuth);

            // set login cookie time for user
            var tenDaysFromNow = DateTime.UtcNow.AddMinutes(Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeOut"]));

            // set form authentication ticket with logged int user values
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                            1,
                             serialiseAuth.UserContext.CurrentUser.UserName + " " + serialiseAuth.UserContext.CurrentUser.UserName,
                             DateTime.Now,
                             tenDaysFromNow,
                             false,
                            userData);

            string encTicket = FormsAuthentication.Encrypt(authTicket);
            HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

            // Add values of user with browser cookie
            Response.Cookies.Add(faCookie);
        }

        private void SetSecurityLogging(ref Spartan_Security_Log oSecurityLog, short Event_Type, int? User_Id, int? User_Role_Id, short Result_Id)
        {
            oSecurityLog.Event_Type = Event_Type;
            oSecurityLog.Result_Id = Result_Id;
            oSecurityLog.Log_Date = DateTime.Now;
            oSecurityLog.User_Role_Id = User_Role_Id;
            oSecurityLog.User_Id = User_Id;
            oSecurityLog.IP_Address_Source = Helper.IPAddress();
            oSecurityLog.IP_Address_Target = Helper.IPAddress();
            oSecurityLog.Computer_Name = System.Environment.MachineName;
            oSecurityLog.Language_Id = 1;
            oSecurityLog.Security_Log_Id = 0;
            oSecurityLog.URL = HttpContext.Request.Url.ToString();
        }

        private void SetSessionLogging(ref Spartan_Session_Log oSessionLog, short Event_Type, short Event_Type2, int Security_Log_Id, int User_Id, int User_Role_Id, short Result_Id)
        {

            oSessionLog.Event_Type = Event_Type;
            oSessionLog.Result_Id = Result_Id;
            oSessionLog.Log_Date = DateTime.Now;
            oSessionLog.User_Role_Id = User_Role_Id;
            oSessionLog.User_Id = User_Id;
            oSessionLog.IP_Address_Source = Helper.IPAddress();
            oSessionLog.IP_Address_Target = Helper.IPAddress();
            oSessionLog.Computer_Name = System.Environment.MachineName;
            oSessionLog.Language_Id = 1;
            oSessionLog.URL = HttpContext.Request.Url.ToString();
            oSessionLog.Event_Type2 = Event_Type2;
            oSessionLog.Security_Log_Id = Security_Log_Id;
            oSessionLog.Session_Log_Id = 0;
        }

        #endregion Helpers


        public VersionValidation ValidateVersion()
        {
            try
            {
                var versions = _ISpartanSecurityApiConsumer.GetVersions().Resource;
                if (versions != null)
                {
                    if (ConfigurationManager.AppSettings["VersionApp"] != null)
                    {
                        versions.VersionMVC = ConfigurationManager.AppSettings["VersionApp"].ToString();
                    }
                }
                return versions;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
		
		
    }
}