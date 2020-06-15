using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.User.Mock
{
    public class MockSpartanUserFavoriteObjectService : ISpartanUserFavoriteObjectService
    {
        private IList<Spartan_User_Favorite_Object> list = null;

        public MockSpartanUserFavoriteObjectService()
        {
            list = new List<Spartan_User_Favorite_Object>
            {
                new Spartan_User_Favorite_Object{ Favorite_ObjectId=1, Order_Shown=1},
                new Spartan_User_Favorite_Object{ Favorite_ObjectId=2, Order_Shown=2},
                new Spartan_User_Favorite_Object{ Favorite_ObjectId=3, Order_Shown=3},
                new Spartan_User_Favorite_Object{ Favorite_ObjectId=4, Order_Shown=4},
                new Spartan_User_Favorite_Object{ Favorite_ObjectId=5, Order_Shown=5},
                new Spartan_User_Favorite_Object{ Favorite_ObjectId=6, Order_Shown=6}
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Core.Domain.User.Spartan_User_Favorite_Object> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Core.Domain.User.Spartan_User_Favorite_Object> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Core.Domain.User.Spartan_User_Favorite_Object GetByKey(int? Key, bool ConRelaciones)
        {
            return list.SingleOrDefault(v => v.Favorite_ObjectId == Key.Value);
        }

        public bool Delete(int? Key, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var user = list.SingleOrDefault(v => v.Favorite_ObjectId == Key.Value);
                list.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Insert(Core.Domain.User.Spartan_User_Favorite_Object entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.Favorite_ObjectId = list.Last().Favorite_ObjectId++;
            list.Add(entity);

            return entity.Favorite_ObjectId;
        }

        public int Update(Core.Domain.User.Spartan_User_Favorite_Object entity, Core.Domain.User.GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var user = list.SingleOrDefault(v => v.Favorite_ObjectId == entity.Favorite_ObjectId);
            list.Remove(user);
            list.Add(entity);

            return list.Count;
        }
    }
}
