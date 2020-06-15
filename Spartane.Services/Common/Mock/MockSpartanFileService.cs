using Spartane.Core.Domain.Common;
using Spartane.Core.Domain.Data;
using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Common.Mock
{
    public class MockSpartanFileService : ISpartanFileService
    {
        private IList<Spartan_File> list = null;

        public MockSpartanFileService()
        {
            list = new List<Spartan_File>
            {
                new Spartan_File{  FileId=1, Description="File 1",FechaHora=DateTime.Now },
                new Spartan_File{  FileId=2, Description="File 2",FechaHora=DateTime.Now },
                new Spartan_File{  FileId=3, Description="File 3",FechaHora=DateTime.Now },
                new Spartan_File{  FileId=4, Description="File 4",FechaHora=DateTime.Now },
                new Spartan_File{  FileId=5, Description="File 5",FechaHora=DateTime.Now }
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Spartan_File> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Spartan_File> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Spartan_File GetByKey(int? Key, bool ConRelaciones)
        {
            return list.SingleOrDefault(v => v.FileId == Key.Value);
        }

        public bool Delete(int? Key, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var user = list.SingleOrDefault(v => v.FileId == Key.Value);
                list.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Insert(Spartan_File entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.FileId = list.Last().FileId++;
            list.Add(entity);

            return entity.FileId;
        }

        public int Update(Spartan_File entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.FileId == entity.FileId);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
