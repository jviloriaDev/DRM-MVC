using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.User.Mock
{
    public class MockSpartanUserService : ISpartanUserService
    {
        private IList<Spartane.Core.Domain.Spartan_User.Spartan_User> userList = null;

        public MockSpartanUserService()
        {

            userList = new List<Spartane.Core.Domain.Spartan_User.Spartan_User>
            {
                new Spartane.Core.Domain.Spartan_User.Spartan_User{ Id_User=1, Name="TotalTech", Email="info@totaltech.com.mx", Role_Spartan_User_Role = new Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role { User_Role_Id=1, Description="Administrador" } },
                new Spartane.Core.Domain.Spartan_User.Spartan_User{ Id_User=2, Name="User 2", Email=""}
            };
        }

        public int SelCount()
        {
            return userList.Count;
        }

        public IList<Spartane.Core.Domain.Spartan_User.Spartan_User> SelAll(bool ConRelaciones)
        {
            return userList;
        }

        public IList<Spartane.Core.Domain.Spartan_User.Spartan_User> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return userList;
        }

        public Spartane.Core.Domain.Spartan_User.Spartan_User GetByKey(int? Key, bool ConRelaciones)
        {
            return userList.SingleOrDefault(v => v.Id_User == Key.Value);
        }

        public bool Delete(int? Key, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var user = userList.SingleOrDefault(v => v.Id_User == Key.Value);
                userList.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Insert(Spartane.Core.Domain.Spartan_User.Spartan_User entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.Id_User = userList.Last().Id_User++;
            userList.Add(entity);

            return entity.Id_User;
        }

        public int Update(Spartane.Core.Domain.Spartan_User.Spartan_User entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = userList.SingleOrDefault(v => v.Id_User == entity.Id_User);
            userList.Remove(user);
            userList.Add(entity);

            return userList.Count;
        }
    }
}
