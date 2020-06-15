using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Empleado
{
    public interface ITokenApiConsumer
    {
        void SetAuthHeader(string token);
        ApiResponse<bool> RefeshToken();
    }
}
