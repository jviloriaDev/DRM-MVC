using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class LanguageController : Controller
    {
        private ILanguageApiConsumer _ILanguageoApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        //TODO: Declare consturctor and initialize language interface, token and credential of consumer
        public LanguageController(ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ILanguageApiConsumer languageoApiConsumer)
        {
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ILanguageoApiConsumer = languageoApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
        }

        // get : frontal/get
        public ActionResult Get()
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _ILanguageoApiConsumer.SetAuthHeader(_tokenManager.Token);

            IList<Spartane.Core.Domain.Language.SpartanLanguage> SpartanLanguageList = _ILanguageoApiConsumer.GetAll().Resource;

            return View();
        }
    }
}