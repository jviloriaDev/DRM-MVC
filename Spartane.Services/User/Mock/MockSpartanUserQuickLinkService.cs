using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.User.Mock
{
    public class MockSpartanUserQuickLinkService : ISpartanUserQuickLinkService
    {
        private IList<Spartan_User_Quicklink> list = null;

        public MockSpartanUserQuickLinkService()
        {
            list = new List<Spartan_User_Quicklink>
            {
                new Spartan_User_Quicklink{ Quicklink=1, Description="Quicklink 1", Order_Shown=1},
                new Spartan_User_Quicklink{ Quicklink=2, Description="Quicklink 2", Order_Shown=2},
                new Spartan_User_Quicklink{ Quicklink=3, Description="Quicklink 3", Order_Shown=3},
                new Spartan_User_Quicklink{ Quicklink=4, Description="Quicklink 4", Order_Shown=4},
                new Spartan_User_Quicklink{ Quicklink=5, Description="Quicklink 5", Order_Shown=5},
                new Spartan_User_Quicklink{ Quicklink=6, Description="Quicklink 6", Order_Shown=6}
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Core.Domain.User.Spartan_User_Quicklink> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Core.Domain.User.Spartan_User_Quicklink> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Core.Domain.User.Spartan_User_Quicklink GetByKey(int? Key, bool ConRelaciones)
        {
            return list.SingleOrDefault(v => v.Quicklink == Key.Value);
        }

        public bool Delete(int? Key, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var user = list.SingleOrDefault(v => v.Quicklink == Key.Value);
                list.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Insert(Core.Domain.User.Spartan_User_Quicklink entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.Quicklink = list.Last().Quicklink++;
            list.Add(entity);

            return entity.Quicklink;
        }

        public int Update(Core.Domain.User.Spartan_User_Quicklink entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.Quicklink == entity.Quicklink);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
