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
    public class MockSpartanObjectStatusService : ISpartanObjectStatusService
    {
        private IList<Spartan_Object_Status> list = null;

        public MockSpartanObjectStatusService()
        {
            list = new List<Spartan_Object_Status>
            {
                new Spartan_Object_Status{  Id=1, Description="Object Status 1" },
                new Spartan_Object_Status{  Id=2, Description="Object Status 2" },
                new Spartan_Object_Status{  Id=3, Description="Object Status 3" },
                new Spartan_Object_Status{  Id=4, Description="Object Status 4" },
                new Spartan_Object_Status{  Id=5, Description="Object Status 5" }
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Spartan_Object_Status> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Spartan_Object_Status> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Spartan_Object_Status GetByKey(int? Key, bool ConRelaciones)
        {
            return list.SingleOrDefault(v => v.Id == Key.Value);
        }

        public bool Delete(int? Key, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
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

        public int Insert(Spartan_Object_Status entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.Id = list.Last().Id++;
            list.Add(entity);

            return entity.Id;
        }

        public int Update(Spartan_Object_Status entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.Id == entity.Id);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
