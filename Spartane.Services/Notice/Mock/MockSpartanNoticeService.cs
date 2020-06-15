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
    public class MockSpartanNoticeService : ISpartanNoticeService
    {
        private IList<Spartan_Notice> list = null;

        public MockSpartanNoticeService()
        {
            list = new List<Spartan_Notice>
            {
                new Spartan_Notice{  NoticeId=1, Description="Ejemplo de noticia #1", Start_Date=DateTime.Now, End_Date=DateTime.Now.AddDays(1), Type = new Spartan_Notice_Type {Id = 1, Description = "Type #1"} },
                new Spartan_Notice{  NoticeId=2, Description="Ejemplo de noticia #2", Start_Date=DateTime.Now, End_Date=DateTime.Now.AddDays(1), Type = new Spartan_Notice_Type {Id = 1, Description = "Type #1"} },
                new Spartan_Notice{  NoticeId=3, Description="Ejemplo de noticia #3", Start_Date=DateTime.Now, End_Date=DateTime.Now.AddDays(1), Type = new Spartan_Notice_Type {Id = 1, Description = "Type #2"} },
                new Spartan_Notice{  NoticeId=4, Description="Ejemplo de noticia #4", Start_Date=DateTime.Now, End_Date=DateTime.Now.AddDays(1), Type = new Spartan_Notice_Type {Id = 1, Description = "Type #2"} },
                new Spartan_Notice{  NoticeId=5, Description="Ejemplo de noticia #5", Start_Date=DateTime.Now, End_Date=DateTime.Now.AddDays(1), Type = new Spartan_Notice_Type {Id = 1, Description = "Type #2"} }
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Spartan_Notice> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Spartan_Notice> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Spartan_Notice GetByKey(int? Key, bool ConRelaciones)
        {
            return list.SingleOrDefault(v => v.NoticeId == Key.Value);
        }

        public bool Delete(int? Key, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var user = list.SingleOrDefault(v => v.NoticeId == Key.Value);
                list.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Insert(Spartan_Notice entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.NoticeId = list.Last().NoticeId++;
            list.Add(entity);

            return entity.NoticeId;
        }

        public int Update(Spartan_Notice entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.NoticeId == entity.NoticeId);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
