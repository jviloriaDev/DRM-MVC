using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.User.Mock
{
    public class MockSpartanUserAlertStatusService : ISpartanUserAlertStatusService
    {
        private IList<Spartan_User_Alert_Status> list = null;

        public MockSpartanUserAlertStatusService()
        {
            list = new List<Spartan_User_Alert_Status>
            {
                new Spartan_User_Alert_Status{ Id=1, Description="Alert Status 1"},
                new Spartan_User_Alert_Status{ Id=2, Description="Alert Status 2"},
                new Spartan_User_Alert_Status{ Id=3, Description="Alert Status 3"},
                new Spartan_User_Alert_Status{ Id=4, Description="Alert Status 4"},
                new Spartan_User_Alert_Status{ Id=5, Description="Alert Status 5"},
                new Spartan_User_Alert_Status{ Id=6, Description="Alert Status 6"}
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Core.Domain.User.Spartan_User_Alert_Status> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Core.Domain.User.Spartan_User_Alert_Status> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Core.Domain.User.Spartan_User_Alert_Status GetByKey(int? Key, bool ConRelaciones)
        {
            return list.SingleOrDefault(v => v.Id == Key.Value);
        }

        public bool Delete(int? Key, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var user = list.SingleOrDefault(v => v.Id == Key.Value);
                list.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Insert(Core.Domain.User.Spartan_User_Alert_Status entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.Id = list.Last().Id++;
            list.Add(entity);

            return entity.Id;
        }

        public int Update(Core.Domain.User.Spartan_User_Alert_Status entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.Id == entity.Id);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
