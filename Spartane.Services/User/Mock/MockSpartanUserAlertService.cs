using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.User.Mock
{
    public class MockSpartanUserAlertService : ISpartanUserAlertService
    {
        private IList<Spartan_User_Alert> list = null;

        public MockSpartanUserAlertService()
        {
            Spartan_User_Alert_Status status = new Spartan_User_Alert_Status
            {
                Id = 1,
                Description = "Pendiente"
            };

            Spartan_User_Alert_Type type = new Spartan_User_Alert_Type
            {
                Id = 1,
                Description = "Alerta"
            };


            list = new List<Spartan_User_Alert>
            {
                new Spartan_User_Alert{  User_AlertId=1, Description="Alert 1", Url="", Status = status, Alert_Type = type  },
                new Spartan_User_Alert{  User_AlertId=2, Description="Alert 2", Url="", Status = status, Alert_Type = type },
                new Spartan_User_Alert{  User_AlertId=3, Description="Alert 3", Url="", Status = status, Alert_Type = type },
                new Spartan_User_Alert{  User_AlertId=4, Description="Alert 4", Url="", Status = status, Alert_Type = type },
                new Spartan_User_Alert{  User_AlertId=5, Description="Alert 5", Url="", Status = status, Alert_Type = type }
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Core.Domain.User.Spartan_User_Alert> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Core.Domain.User.Spartan_User_Alert> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Core.Domain.User.Spartan_User_Alert GetByKey(int? Key, bool ConRelaciones)
        {
            return list.SingleOrDefault(v => v.User_AlertId == Key.Value);
        }

        public bool Delete(int? Key, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var user = list.SingleOrDefault(v => v.User_AlertId == Key.Value);
                list.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Insert(Core.Domain.User.Spartan_User_Alert entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.User_AlertId = list.Last().User_AlertId++;
            list.Add(entity);

            return entity.User_AlertId;
        }

        public int Update(Core.Domain.User.Spartan_User_Alert entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.User_AlertId == entity.User_AlertId);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
