using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Empleado;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
using Spartane.Web.Models;

namespace Spartane.Web.Areas.WebApiConsumer
{
    public class TokenManager : ITokenManager
    {
        public IAuthenticationApiConsumer _IAuthenticationApiConsumer;
        public string Token { get; set; }
        public ApiToken _ApiToken;
        public Spartane_Credential _UserCredential;
        public ITokenApiConsumer _TokenApiConsumer;

        public TokenManager()
        {

            
            _ApiToken = SessionHelper.UserApiToken;
            _IAuthenticationApiConsumer = new AuthenticationApiConsumer();
            _UserCredential = SessionHelper.UserCredential;
            //  var applicationManagerDependencyResolver = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ICustomAuthenticationService)) as ICustomAuthenticationService;
            _TokenApiConsumer = new TokenApiConsumer();

        }


        public bool GenerateToken()
        {
            try
            {
                if (_ApiToken != null)
                {
                    _TokenApiConsumer.SetAuthHeader(_ApiToken.Token);
                    if (_TokenApiConsumer.RefeshToken().Resource)
                    {
                        Token = _ApiToken.Token;
                        return true;
                    }
                }
                if (_UserCredential == null)
                {
                    _UserCredential = SessionHelper.UserCredential;
                }
                var tokenInformation = _IAuthenticationApiConsumer.GetApiToken(_UserCredential.UserName,
                    _UserCredential.Password);
                if (tokenInformation != null && tokenInformation.Token != null)
                {
                    SessionHelper.UserApiToken = tokenInformation;
                    Token = tokenInformation.Token;
                    return true;
                }
                return false;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool GenerateToken(string UserName, string Password)
        {
            try
            {
                if (_ApiToken != null)
                {
                    _TokenApiConsumer.SetAuthHeader(_ApiToken.Token);
                    if (_TokenApiConsumer.RefeshToken().Resource)
                    {
                        Token = _ApiToken.Token;
                        return true;
                    }
                }
                _UserCredential = new Spartane_Credential
                {
                    Password = Password,
                    UserName = UserName,
                };

                var tokenInformation = _IAuthenticationApiConsumer.GetApiToken(_UserCredential.UserName,
                    _UserCredential.Password);
                if (tokenInformation != null && tokenInformation.Token != null)
                {
                    SessionHelper.UserApiToken = tokenInformation;
                    Token = tokenInformation.Token;
                    return true;
                }
                return false;

            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
