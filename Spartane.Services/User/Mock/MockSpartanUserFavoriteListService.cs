using Spartane.Core.Domain.User;
using Spartane.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.User.Mock
{
    public class MockSpartanUserFavoriteListService : ISpartanUserFavoriteListService
    {
        private IList<Spartan_User_Favorite_List> list = null;

        public MockSpartanUserFavoriteListService()
        {
            list = new List<Spartan_User_Favorite_List>
            {
                new Spartan_User_Favorite_List{ Favorite_ListId=1, Order_Shown=1, Object = new Spartane.Core.Domain.Spartan_Object.Spartan_Object { Object_Id=1, URL = "Users/Index", Name = "Usuarios" }},
                new Spartan_User_Favorite_List{ Favorite_ListId=2, Order_Shown=2, Object = new Spartane.Core.Domain.Spartan_Object.Spartan_Object { Object_Id=2, URL = "Users/GridMvvm", Name = "Usuarios MVVM" }}
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Core.Domain.User.Spartan_User_Favorite_List> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Core.Domain.User.Spartan_User_Favorite_List> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Core.Domain.User.Spartan_User_Favorite_List GetByKey(int? Key, bool ConRelaciones)
        {
            return list.SingleOrDefault(v => v.Favorite_ListId == Key.Value);
        }

        public bool Delete(int? Key, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var user = list.SingleOrDefault(v => v.Favorite_ListId == Key.Value);
                list.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Insert(Core.Domain.User.Spartan_User_Favorite_List entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.Favorite_ListId = list.Last().Favorite_ListId++;
            list.Add(entity);

            return entity.Favorite_ListId;
        }

        public int Update(Core.Domain.User.Spartan_User_Favorite_List entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.Favorite_ListId == entity.Favorite_ListId);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
