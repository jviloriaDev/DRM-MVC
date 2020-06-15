



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Models;

namespace Spartane.Web.Areas.WebApiConsumer
{
    public interface ISpartanSecurityApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();

        ApiResponse<Int32> Insert(Spartan_Security_Log entity);
        ApiResponse<VersionValidation> GetVersions();
    }
}
