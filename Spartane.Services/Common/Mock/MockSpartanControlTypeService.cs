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
    public class MockSpartanControlTypeService : ISpartanControlTypeService
    {
        private IList<Spartan_Control_Type> list = null;

        public MockSpartanControlTypeService()
        {
            list = new List<Spartan_Control_Type>
            {
                new Spartan_Control_Type{  Control_TypeId=1, Order_Shown=1 },
                new Spartan_Control_Type{  Control_TypeId=2, Order_Shown=2 },
                new Spartan_Control_Type{  Control_TypeId=3, Order_Shown=3 },
                new Spartan_Control_Type{  Control_TypeId=4, Order_Shown=4 },
                new Spartan_Control_Type{  Control_TypeId=5, Order_Shown=5 }
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Spartan_Control_Type> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Spartan_Control_Type> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Spartan_Control_Type GetByKey(int? Key, bool ConRelaciones)
        {
            return list.SingleOrDefault(v => v.Control_TypeId == Key.Value);
        }

        public bool Delete(int? Key, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var user = list.SingleOrDefault(v => v.Control_TypeId == Key.Value);
                list.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Insert(Spartan_Control_Type entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.Control_TypeId = list.Last().Control_TypeId++;
            list.Add(entity);

            return entity.Control_TypeId;
        }

        public int Update(Spartan_Control_Type entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.Control_TypeId == entity.Control_TypeId);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
