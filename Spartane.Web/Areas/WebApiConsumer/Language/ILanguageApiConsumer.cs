using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer
{
    public interface ILanguageApiConsumer
    {
        void SetAuthHeader(string token);

        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Language.SpartanLanguage>> GetAll();
    }
}
