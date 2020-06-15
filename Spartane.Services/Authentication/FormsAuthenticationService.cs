using System;
using System.Web;
using System.Web.Security;
using Spartane.Core.Domain.User;
using Spartane.Services.User;

namespace Spartane.Services.Authentication
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class FormsAuthenticationService: IAuthenticationService
    {
        #region Fields
        private readonly HttpContextBase _httpContext;
        private readonly IUserService _userService;
        private readonly TimeSpan _expirationTimeSpan;

        private TTUsuario _cachedUser;
        #endregion

        #region Ctor
        public FormsAuthenticationService(HttpContextBase httpContext,
            IUserService userService)
        {
            this._httpContext = httpContext;
            this._userService = userService;
            this._expirationTimeSpan = FormsAuthentication.Timeout;
        }
        #endregion

        public virtual void SignIn(TTUsuario user, bool createPersistentCookie)
        {
            var now = DateTime.UtcNow.ToLocalTime();

            var ticket = new FormsAuthenticationTicket(
                1 /*version*/,
                user.Clave_de_Acceso,
                now,
                now.Add(_expirationTimeSpan),
                createPersistentCookie,
                user.Clave_de_Acceso,
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }

            _httpContext.Response.Cookies.Add(cookie);
            _cachedUser = user;
            //throw new NotImplementedException();
        }

        public virtual void SignOut()
        {
            _cachedUser = null;
            FormsAuthentication.SignOut();
        }

        public virtual TTUsuario GetAuthenticatedUSer()
        {
            if (_cachedUser != null)
                return _cachedUser;

            if (_httpContext == null ||
                _httpContext.Request == null ||
                !_httpContext.Request.IsAuthenticated ||
                !(_httpContext.User.Identity is FormsIdentity))
            {
                return null;
            }

            var formsIdentity = (FormsIdentity)_httpContext.User.Identity;
            var user = GetAuthenticatedCustomerFromTicket(formsIdentity.Ticket);
            if (user != null)
                _cachedUser = user;
            return _cachedUser;
        }

        public virtual TTUsuario GetAuthenticatedCustomerFromTicket(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");

            var userName = ticket.UserData;

            if (String.IsNullOrWhiteSpace(userName))
                return null;
            var customer = _userService.GetUserByUsername(userName);
            return customer;
        }
    }
}
