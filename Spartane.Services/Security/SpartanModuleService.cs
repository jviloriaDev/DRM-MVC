using Spartane.Core.Data;
using Spartane.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Security
{
    public class SpartanModuleService : ISpartanModuleService
    {
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public IList<Core.Domain.Security.Spartan_Module> SelAll(bool ConRelaciones)
        {
            throw new NotImplementedException();
        }

        public IList<Core.Domain.Security.Spartan_Module> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public Core.Domain.Security.Spartan_Module GetByKey(int? Key, bool ConRelaciones)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int? Key, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            throw new NotImplementedException();
        }

        public int Insert(Core.Domain.Security.Spartan_Module entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            throw new NotImplementedException();
        }

        public int Update(Core.Domain.Security.Spartan_Module entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            throw new NotImplementedException();
        }
    }
}
