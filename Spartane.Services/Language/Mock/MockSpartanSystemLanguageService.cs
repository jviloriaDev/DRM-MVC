using Spartane.Core.Domain.Language;
using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Language.Mock
{
    public class MockSpartanSystemLanguageService : ISpartanSystemLanguageService
    {
        private IList<Spartan_System_Language> list = null;

        public MockSpartanSystemLanguageService()
        {
            list = new List<Spartan_System_Language>
            {
                new Spartan_System_Language{  System_LanguageId=1, ResourceId="1" },
                new Spartan_System_Language{  System_LanguageId=2, ResourceId="2" },
                new Spartan_System_Language{  System_LanguageId=3, ResourceId="3" },
                new Spartan_System_Language{  System_LanguageId=4, ResourceId="4" },
                new Spartan_System_Language{  System_LanguageId=5, ResourceId="5" }
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Spartan_System_Language> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Spartan_System_Language> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Spartan_System_Language GetByKey(int? Key, bool ConRelaciones)
        {
            return list.SingleOrDefault(v => v.System_LanguageId == Key.Value);
        }

        public bool Delete(int? Key, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var user = list.SingleOrDefault(v => v.System_LanguageId == Key.Value);
                list.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Insert(Spartan_System_Language entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.System_LanguageId = list.Last().System_LanguageId++;
            list.Add(entity);

            return entity.System_LanguageId;
        }

        public int Update(Spartan_System_Language entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.System_LanguageId == entity.System_LanguageId);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
