using Spartane.Core.Domain.Security;
using Spartane.Core.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Services.Security.Mock
{
    public class MockSpartanModuleService : ISpartanModuleService
    {
        private IList<Spartan_Module> list = null;

        public MockSpartanModuleService()
        {
            list = new List<Spartan_Module>
            {
                new Spartan_Module{
                 ModuleId=1,
                  Nombre="Opcion 1",
                   Image="",
                   HasChildren=true,
                   Children = new List<Spartan_Module>{
                        new Spartan_Module{
                                ModuleId=11,
                                Nombre="Opcion 11",
                                Image="",
                                ParentId=1
                        },
                        new Spartan_Module{
                                ModuleId=12,
                                Nombre="Opcion 12",
                                Image="",
                                ParentId=1
                        },
                        new Spartan_Module{
                                ModuleId=13,
                                Nombre="Opcion 13",
                                Image="",
                                ParentId=1
                        },
                   }
                },
                new Spartan_Module{
                 ModuleId=2,
                  Nombre="Opcion 2",
                   Image="",
                   HasChildren=true,
                   Children = new List<Spartan_Module>{
                        new Spartan_Module{
                                ModuleId=21,
                                Nombre="Opcion 21",
                                Image="",
                                ParentId=2
                        },
                        new Spartan_Module{
                                ModuleId=22,
                                Nombre="Opcion 22",
                                Image="",
                                ParentId=2
                        },
                        new Spartan_Module{
                                ModuleId=23,
                                Nombre="Opcion 23",
                                Image="",
                                ParentId=2
                        },
                   }
                },
                new Spartan_Module{
                 ModuleId=3,
                  Nombre="Opcion 3",
                   Image="",
                   HasChildren=true,
                   Children=new List<Spartan_Module>{
                        new Spartan_Module{
                                ModuleId=31,
                                Nombre="Opcion 31",
                                Image="",
                                ParentId=3
                        },
                        new Spartan_Module{
                                ModuleId=32,
                                Nombre="Opcion 32",
                                Image="",
                                ParentId=3
                        },
                   }
                },
                new Spartan_Module{
                 ModuleId=4,
                  Nombre="Opcion 4",
                   Image="~/assets/admin/img/icon-img-up.png",
                   HasChildren=true,
                   Children=new List<Spartan_Module>{
                        new Spartan_Module{
                            ModuleId=41,
                            Nombre="Opcion 41",
                            Image="",
                            ParentId=4,
                            HasChildren=true,
                            Children=new List<Spartan_Module>{
                                new Spartan_Module{
                                    ModuleId=411,
                                    Nombre="Opcion 411",
                                    Image="~/assets/admin/img/icon-img-up.png",
                                    ParentId=41
                                }
                            }
                        },
                   }
                },
            };
        }

        public int SelCount()
        {
            return list.Count;
        }

        public IList<Spartan_Module> SelAll(bool ConRelaciones)
        {
            return list;
        }

        public IList<Spartan_Module> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return list;
        }

        public Spartan_Module GetByKey(int? Key, bool ConRelaciones)
        {
            return list.SingleOrDefault(v => v.ModuleId == Key.Value);
        }

        public bool Delete(int? Key, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            try
            {
                var user = list.SingleOrDefault(v => v.ModuleId == Key.Value);
                list.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int Insert(Spartan_Module entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            entity.ModuleId = list.Last().ModuleId++;
            list.Add(entity);

            return entity.ModuleId;
        }

        public int Update(Spartan_Module entity, GlobalData UserInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var module = list.SingleOrDefault(v => v.ModuleId == entity.ModuleId);
            list.Remove(module);
            list.Add(entity);

            return list.Count;
        }
    }
}
