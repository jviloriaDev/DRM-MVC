using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.Notice;
using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Notice.Mock
{
    public class MockSpartanNoticeTypeService : ISpartanNoticeTypeService
    {
        private IList<Spartan_Notice_Type> list = null;

        public MockSpartanNoticeTypeService()
        {
            list = new List<Spartan_Notice_Type>
            {
                new Spartan_Notice_Type{  Id=1, Description="Notice Type 1" },
                new Spartan_Notice_Type{  Id=2, Description="Notice Type 2" },
                new Spartan_Notice_Type{  Id=3, Description="Notice Type 3" },
                new Spartan_Notice_Type{  Id=4, Description="Notice Type 4" },
                new Spartan_Notice_Type{  Id=5, Description="Notice Type 5" }
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Spartan_Notice_Type> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Spartan_Notice_Type> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Spartan_Notice_Type GetByKey(int? Key, bool ConRelaciones)
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

        public int Insert(Spartan_Notice_Type entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.Id = list.Last().Id++;
            list.Add(entity);

            return entity.Id;
        }

        public int Update(Spartan_Notice_Type entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.Id == entity.Id);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
