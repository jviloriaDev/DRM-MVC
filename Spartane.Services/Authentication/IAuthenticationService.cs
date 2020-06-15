using System;
using Spartane.Core.Domain.User; 

namespace Spartane.Services.Authentication
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IAuthenticationService
    {
        /// <summary>
        /// Login user with credentials
        /// </summary>
        /// <param name="sUser"></param>
        /// <param name="sPassword"></param>
        /// <param name="Language"></param>
        /// <returns></returns>
        void SignIn(TTUsuario user, bool createPersistentCookie);
        /// <summary>
        /// Logoff user authenticated
        /// </summary>
        /// <param name="UserInformation"></param>
        /// <returns></returns>
        void SignOut();
        /// <summary>
        /// GEt the user authenticated
        /// </summary>
        /// <returns></returns>
        TTUsuario GetAuthenticatedUSer();
    }
}
