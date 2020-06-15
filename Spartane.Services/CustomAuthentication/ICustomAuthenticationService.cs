using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.CustomAuthentication
{
    public partial interface ICustomAuthenticationService
    {
        Spartane.Core.Domain.User.TTUsuario GetUserDetails(string userName, string password);
    }

}
