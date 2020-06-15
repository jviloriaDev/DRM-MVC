using Spartane.Core.Data;
using Spartane.Core.Domain.User;
using Spartane.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.User
{
    public class SpartaneUserService : ISpartanUserService
    {
        public int SelCount()
        {
            throw new NotImplementedException();
        }

        public IList<Spartane.Core.Domain.Spartan_User.Spartan_User> SelAll(bool ConRelaciones)
        {
            throw new NotImplementedException();
        }

        public IList<Spartane.Core.Domain.Spartan_User.Spartan_User> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            throw new NotImplementedException();
        }

        public Spartane.Core.Domain.Spartan_User.Spartan_User GetByKey(int? Key, bool ConRelaciones)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int? Key, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            throw new NotImplementedException();
        }

        public int Insert(Spartane.Core.Domain.Spartan_User.Spartan_User entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            throw new NotImplementedException();
        }

        public int Update(Spartane.Core.Domain.Spartan_User.Spartan_User entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            throw new NotImplementedException();
        }
    }
}
