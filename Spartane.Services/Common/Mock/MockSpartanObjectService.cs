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
    public class MockSpartanObjectService : ISpartanObjectService
    {
        private IList<Spartane.Core.Domain.Spartan_Object.Spartan_Object> list = null;

        public MockSpartanObjectService()
        {
            list = new List<Spartane.Core.Domain.Spartan_Object.Spartan_Object>
            {
                new Spartane.Core.Domain.Spartan_Object.Spartan_Object{  Object_Id=1, URL="Object 1" },
                new Spartane.Core.Domain.Spartan_Object.Spartan_Object{  Object_Id=2, URL="Object 2" },
                new Spartane.Core.Domain.Spartan_Object.Spartan_Object{  Object_Id=3, URL="Object 3" },
                new Spartane.Core.Domain.Spartan_Object.Spartan_Object{  Object_Id=4, URL="Object 4" },
                new Spartane.Core.Domain.Spartan_Object.Spartan_Object{  Object_Id=5, URL="Object 5" }
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Spartane.Core.Domain.Spartan_Object.Spartan_Object> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Spartane.Core.Domain.Spartan_Object.Spartan_Object> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Spartane.Core.Domain.Spartan_Object.Spartan_Object GetByKey(int? Key, bool ConRelaciones)
        {
            return list.SingleOrDefault(v => v.Object_Id == Key.Value);
        }

        public bool Delete(int? Key, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var user = list.SingleOrDefault(v => v.Object_Id == Key.Value);
                list.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Insert(Spartane.Core.Domain.Spartan_Object.Spartan_Object entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.Object_Id = list.Last().Object_Id++;
            list.Add(entity);

            return entity.Object_Id;
        }

        public int Update(Spartane.Core.Domain.Spartan_Object.Spartan_Object entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.Object_Id == entity.Object_Id);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
