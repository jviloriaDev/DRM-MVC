using Spartane.Core.Domain.Security;
using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Security.Mock
{
    public class MockSpartanUserRoleService : ISpartanUserRoleService
    {
        private IList<Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role> list = null;

        public MockSpartanUserRoleService()
        {
            list = new List<Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role>
            {
                new Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role{  User_Role_Id=1, Description="User Role 1" },
                new Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role{  User_Role_Id=2, Description="User Role 2" },
                new Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role{  User_Role_Id=3, Description="User Role 3" },
                new Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role{  User_Role_Id=4, Description="User Role 4" },
                new Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role{  User_Role_Id=5, Description="User Role 5" }
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role GetByKey(int? Key, bool ConRelaciones)
        {
            return list.SingleOrDefault(v => v.User_Role_Id == Key.Value);
        }

        public bool Delete(int? Key, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var user = list.SingleOrDefault(v => v.User_Role_Id == Key.Value);
                list.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Insert(Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.User_Role_Id = list.Last().User_Role_Id++;
            list.Add(entity);

            return entity.User_Role_Id;
        }

        public int Update(Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.User_Role_Id == entity.User_Role_Id);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
