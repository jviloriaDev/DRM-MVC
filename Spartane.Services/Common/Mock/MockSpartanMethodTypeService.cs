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
    public class MockSpartanMethodTypeService : ISpartanMethodTypeService
    {
        private IList<Spartan_Method_Type> list = null;

        public MockSpartanMethodTypeService()
        {
            list = new List<Spartan_Method_Type>
            {
                new Spartan_Method_Type{  Method_TypeId=1, Description="Tipo Metodo 1" },
                new Spartan_Method_Type{  Method_TypeId=2, Description="Tipo Metodo 2" },
                new Spartan_Method_Type{  Method_TypeId=3, Description="Tipo Metodo 3" },
                new Spartan_Method_Type{  Method_TypeId=4, Description="Tipo Metodo 4" },
                new Spartan_Method_Type{  Method_TypeId=5, Description="Tipo Metodo 5" }
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Spartan_Method_Type> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Spartan_Method_Type> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Spartan_Method_Type GetByKey(int? Key, bool ConRelaciones)
        {
            return list.SingleOrDefault(v => v.Method_TypeId == Key.Value);
        }

        public bool Delete(int? Key, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var user = list.SingleOrDefault(v => v.Method_TypeId == Key.Value);
                list.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Insert(Spartan_Method_Type entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.Method_TypeId = list.Last().Method_TypeId++;
            list.Add(entity);

            return entity.Method_TypeId;
        }

        public int Update(Spartan_Method_Type entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.Method_TypeId == entity.Method_TypeId);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
