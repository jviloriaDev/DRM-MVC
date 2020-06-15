using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.User.Mock
{
    public class MockSpartanUserStatusService : ISpartanUserStatusService
    {
        private IList<Spartane.Core.Domain.Spartan_User_Status.Spartan_User_Status> list = null;

        public MockSpartanUserStatusService()
        {
            list = new List<Spartane.Core.Domain.Spartan_User_Status.Spartan_User_Status>
            {
                new Spartane.Core.Domain.Spartan_User_Status.Spartan_User_Status{ User_Status_Id=1, Description="Status 1"},
                new Spartane.Core.Domain.Spartan_User_Status.Spartan_User_Status{ User_Status_Id=2, Description="Status 2"},
                new Spartane.Core.Domain.Spartan_User_Status.Spartan_User_Status{ User_Status_Id=3, Description="Status 3"},
                new Spartane.Core.Domain.Spartan_User_Status.Spartan_User_Status{ User_Status_Id=4, Description="Status 4"},
                new Spartane.Core.Domain.Spartan_User_Status.Spartan_User_Status{ User_Status_Id=5, Description="Status 5"},
                new Spartane.Core.Domain.Spartan_User_Status.Spartan_User_Status{ User_Status_Id=6, Description="Status 6"}
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Spartane.Core.Domain.Spartan_User_Status.Spartan_User_Status> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Spartane.Core.Domain.Spartan_User_Status.Spartan_User_Status> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Spartane.Core.Domain.Spartan_User_Status.Spartan_User_Status GetByKey(int? Key, bool ConRelaciones)
        {
            return list.SingleOrDefault(v => v.User_Status_Id == Key.Value);
        }

        public bool Delete(int? Key, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var user = list.SingleOrDefault(v => v.User_Status_Id == Key.Value);
                list.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Insert(Spartane.Core.Domain.Spartan_User_Status.Spartan_User_Status entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.User_Status_Id = list.Last().User_Status_Id++;
            list.Add(entity);

            return entity.User_Status_Id;
        }

        public int Update(Spartane.Core.Domain.Spartan_User_Status.Spartan_User_Status entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.User_Status_Id == entity.User_Status_Id);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
