using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.ApiAuthentication
{
    public partial interface IAuthenticationApiConsumer
    {

        ApiToken GetApiToken(string username, string password);

    }
}
