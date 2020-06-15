using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.WebApiConsumer
{
    public interface ITokenManager
    {
        string Token { set; get; }
        bool GenerateToken();
        bool GenerateToken(string UserName, string Password);
    }
}
