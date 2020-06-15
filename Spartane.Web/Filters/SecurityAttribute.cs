using Spartane.Core.Domain.User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.AuthenticationExt;
using Spartane.Web.Models;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Spartane.Web.Filters
{
    // For All Permission
    public class AppAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public string Permissions { get; set; }

        protected virtual IPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as IPrincipal; }
        }

        private void CacheValidateHandler(HttpContext context, object data, ref HttpValidationStatus validationStatus)
        {
            validationStatus = this.OnCacheAuthorization(new HttpContextWrapper(context));
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string action = filterContext.ActionDescriptor.ActionName;
            Authentication auth = null;
            if (CurrentUser != null && CurrentUser.Identity != null && CurrentUser.Identity.IsAuthenticated && SessionHelper.Relogin == false)
            {
                // Get cookies values of user
                HttpCookie authCookie =
                  filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null && !string.IsNullOrWhiteSpace(authCookie.Value))
                {
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    AuthenticationSerialize serialiseAuth = serializer.Deserialize<AuthenticationSerialize>(authTicket.UserData);
                    auth = new Authentication(authTicket.Name);
                    // set user context from cookies
                    if (authCookie != null && !string.IsNullOrWhiteSpace(authCookie.Value))
                        auth.UserContext = serialiseAuth.UserContext;

                    if (SessionHelper.UserEntity == null || SessionHelper.UserCredential == null)
                    {
                        ISpartan_UserApiConsumer _IUseroApiConsumer = new Spartan_UserApiConsumer();
                        ISpartane_FileApiConsumer _ISpartane_FileApiConsumer = new Spartane_FileApiConsumer();

                        // Call Validate User API for user Exists in application
                        Spartan_User_Core UserDetails = _IUseroApiConsumer.ValidateUser(1, 10, "Username = '" + auth.UserContext.CurrentUser.UserName + "'  COLLATE SQL_Latin1_General_CP1_CS_AS And Password = '" + auth.UserContext.CurrentUser.Password + "'  COLLATE SQL_Latin1_General_CP1_CS_AS").Resource;
                        if (UserDetails.Spartan_Users != null && UserDetails.Spartan_Users.Count > 0)
                        {
                            if (UserDetails.Spartan_Users[0].Status == 1)
                            {
                                TTUsuario user = new TTUsuario
                                {
                                    IdUsuario = Convert.ToInt16(UserDetails.Spartan_Users[0].Id_User),
                                    Nombre = Convert.ToString(UserDetails.Spartan_Users[0].Name),
                                    Clave_de_Acceso = UserDetails.Spartan_Users[0].Username,
                                    //Activo = UserDetails.Spartan_Users[0].Status
                                };

                                //Adding user Core entity Data
                                SessionHelper.UserEntity = UserDetails.Spartan_Users[0];

                                var userImage =
                                    _ISpartane_FileApiConsumer.GetByKey(Convert.ToInt32(UserDetails.Spartan_Users[0].Image))
                                        .Resource;
                                if (userImage != null && userImage.File != null)
                                    SessionHelper.UserImage = userImage.File;

                                //Saving Credentials
                                SessionHelper.UserCredential = new Spartane_Credential
                                {
                                    Password = auth.UserContext.CurrentUser.Password,
                                    UserName = auth.UserContext.CurrentUser.UserName,
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
                                HttpContext.Current.Session["USERID"] = user.IdUsuario;
                                HttpContext.Current.Session["USERROLEID"] = UserDetails.Spartan_Users[0].Role_Spartan_User_Role.User_Role_Id;

                            }
                        }
                         else if (controller != "Account" && action != "Login")
                        {
                            filterContext.Controller.TempData["cssClass"] = "error";
                            filterContext.Controller.TempData["message"] = "You are not logged in.";
                            filterContext.Result = new RedirectResult("~/Account/Login"); //new RedirectResult("/Account/Login");
                            auth = null;
            
                        }
                    }
                    HttpContext.Current.User = auth;
                }
            }
            // write code here as per role RoleType
            else if (controller != "Account" && action != "Login")
            {
                if ((controller == "General") && (action == "ExecuteQueryTable"))
                { }
                else
                {
                    filterContext.Controller.TempData["cssClass"] = "error";
                    filterContext.Controller.TempData["message"] = "You are not logged in.";
                    filterContext.Result = new RedirectResult("~/Account/Login"); //new RedirectResult("/Account/Login");
                }
            }
        }
    }
}

//For Admin User
public class AdminAuthFilterAttribute : FilterAttribute, IAuthorizationFilter
{
    public string Permissions { get; set; }

    protected virtual IPrincipal CurrentUser
    {
        get { return HttpContext.Current.User as IPrincipal; }
    }

    public void OnAuthorization(AuthorizationContext filterContext)
    {
        string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
        string action = filterContext.ActionDescriptor.ActionName;
        Authentication auth = null;
        if (CurrentUser != null && CurrentUser.Identity != null && CurrentUser.Identity.IsAuthenticated)
        {
            HttpCookie authCookie =
              filterContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null && !string.IsNullOrWhiteSpace(authCookie.Value))
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                AuthenticationSerialize serialiseAuth = serializer.Deserialize<AuthenticationSerialize>(authTicket.UserData);
                auth = new Authentication(authTicket.Name);
                if (authCookie != null && !string.IsNullOrWhiteSpace(authCookie.Value))
                    auth.UserContext = serialiseAuth.UserContext;

                //if (auth.UserContext.RoleId == 1)
                //{
                //    HttpContext.Current.User = auth;
                //}
                //else
                //{
                //    filterContext.Result = new RedirectResult("/Home/UnAuthorized");
                //}

                //HttpContext.Current.User = auth;
            }
        }
    }
}