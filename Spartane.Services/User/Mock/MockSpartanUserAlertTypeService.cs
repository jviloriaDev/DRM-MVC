using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.User.Mock
{
    public class MockSpartanUserAlertTypeService : ISpartanUserAlertTypeService
    {
        private IList<Spartan_User_Alert_Type> list = null;

        public MockSpartanUserAlertTypeService()
        {
            list = new List<Spartan_User_Alert_Type>
            {
                new Spartan_User_Alert_Type{ Id=1, Description="Alert Type 1"},
                new Spartan_User_Alert_Type{ Id=2, Description="Alert Type 2"},
                new Spartan_User_Alert_Type{ Id=3, Description="Alert Type 3"},
                new Spartan_User_Alert_Type{ Id=4, Description="Alert Type 4"},
                new Spartan_User_Alert_Type{ Id=5, Description="Alert Type 5"},
                new Spartan_User_Alert_Type{ Id=6, Description="Alert Type 6"}
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Core.Domain.User.Spartan_User_Alert_Type> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Core.Domain.User.Spartan_User_Alert_Type> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Core.Domain.User.Spartan_User_Alert_Type GetByKey(int? Key, bool ConRelaciones)
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

        public int Insert(Core.Domain.User.Spartan_User_Alert_Type entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.Id = list.Last().Id++;
            list.Add(entity);

            return entity.Id;
        }

        public int Update(Core.Domain.User.Spartan_User_Alert_Type entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.Id == entity.Id);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
