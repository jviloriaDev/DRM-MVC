using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Search;
using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Search
{
    public interface ITTSearchAdvancedDataService
    {
        TTSearchAdvancedData GetStructView(int vistaId);
        void Delete(int vistaId, GlobalData userInformation, DataLayerFieldsBitacora dataReference);
    }
}
