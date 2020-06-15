using Spartane.Core.Domain.Common;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Common.Mock
{
    public class MockSpartanSystemService : ISpartanSystemService
    {
        private IList<Spartan_System> list = null;

        public MockSpartanSystemService()
        {
            list = new List<Spartan_System>
            {
                new Spartan_System{  SystemId=1, Version="1.0" },
                new Spartan_System{  SystemId=2, Version="1.2" },
                new Spartan_System{  SystemId=3, Version="1.6" },
                new Spartan_System{  SystemId=4, Version="1.8" },
                new Spartan_System{  SystemId=5, Version="2.0" }
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Spartan_System> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Spartan_System> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Spartan_System GetByKey(int? Key, bool ConRelaciones)
        {
            return list.SingleOrDefault(v => v.SystemId == Key.Value);
        }

        public bool Delete(int? Key, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var user = list.SingleOrDefault(v => v.SystemId == Key.Value);
                list.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Insert(Spartan_System entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.SystemId = list.Last().SystemId++;
            list.Add(entity);

            return entity.SystemId;
        }

        public int Update(Spartan_System entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.SystemId == entity.SystemId);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
