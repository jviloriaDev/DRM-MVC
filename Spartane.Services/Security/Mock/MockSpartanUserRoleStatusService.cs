using Spartane.Core.Domain.Common;
using Spartane.Core.Domain.Security;
using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Security.Mock
{
    public class MockSpartanUserRoleStatusService : ISpartanUserRoleStatusService
    {
        private IList<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status> list = null;

        public MockSpartanUserRoleStatusService()
        {
            list = new List<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status>
            {
                new Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status{ User_Role_Status_Id=1, Description="User Role Status 1" },
                new Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status{  User_Role_Status_Id=2, Description="User Role Status 2" },
                new Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status{  User_Role_Status_Id=3, Description="User Role Status 3" },
                new Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status{  User_Role_Status_Id=4, Description="User Role Status 4" },
                new Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status{  User_Role_Status_Id=5, Description="User Role Status 5" }
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status GetByKey(int? Key, bool ConRelaciones)
        {
            return list.SingleOrDefault(v => v.User_Role_Status_Id == Key.Value);
        }

        public bool Delete(int? Key, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var user = list.SingleOrDefault(v => v.User_Role_Status_Id == Key.Value);
                list.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Insert(Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.User_Role_Status_Id = list.Last().User_Role_Status_Id++;
            list.Add(entity);

            return entity.User_Role_Status_Id;
        }

        public int Update(Spartane.Core.Domain.Spartan_User_Role_Status.Spartan_User_Role_Status entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.User_Role_Status_Id == entity.User_Role_Status_Id);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
