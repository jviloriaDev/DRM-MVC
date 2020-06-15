using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class ManagerController : Controller
    {
        public ManagerController()
        {
            SessionHelper.User = new Spartan_User
            {
                Email = "otero.javier@gmail.com",
                Name = "Javier Alejandro Otero",
                UserId = 1,
                Status = new Spartan_User_Status { Description = "OK", Id = 1 }
            };

            SessionHelper.System = new Spartan_System
            {
                SystemId = 1,
                Version = "v 10.01.1"
            };
            //SessionHelper.UserLayout = "~/Areas/Frontal/Views/Shared/_Layout.cshtml";
        }

        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangeLayout()
        {
            SessionHelper.UserLayout = (SessionHelper.UserLayout == "~/Areas/Frontal/Views/Shared/_Layout.cshtml") ? "~/Areas/Frontal/Views/Shared/_LayoutHorizontal.cshtml" : "~/Areas/Frontal/Views/Shared/_Layout.cshtml";

            return RedirectToAction("Index", "Home");
        }

        public ActionResult SideBar()
        {
            return View(this.generateMenu());
        }

        public ActionResult MenuHorizontal()
        {
            return View(this.generateMenu());
        }

        public ActionResult MenuHorizontalResponsive()
        {
            return View(this.generateMenu());
        }

        public ActionResult Ejemplo1()
        {
            return View();
        }

        public ActionResult getMessages()
        {
            var messages = new List<Spartan_User_Alert> {
                new Spartan_User_Alert {
                    User_AlertId = 1,
                    Description = "Descripción Alerta #1",
                    Alert_Type = new Spartan_User_Alert_Type { Id = 1, Description = "Alerta"},
                    Status = new Spartan_User_Alert_Status { Id = 1, Description = "New" },
                    URL = "Messages/Read/1",
                    User = 1
                }
            };

            return this.Json(messages, JsonRequestBehavior.AllowGet);
        }

        private List<SideBar> generateMenu()
        {
            return new List<SideBar> {
                new SideBar
                {
                    Id = 1,
                    Label="Opcion 1",
                    IconClass = "icon-briefcase",
                    Opciones = new List<SideBar>
                    {
                        new SideBar
                        {
                            Id = 2,
                            Titulo="Título de Página",
                            Descripcion="Descripción de prueba TotalTech",
                            Label = "Opcion 1.1",
                            Tabs = "[{\"label\":\"Home\",\"url\":\"Home/About\", \"close\":false, \"cache\":true},{\"label\":\"Contacto\",\"url\":\"Home/Contact\", \"close\":false, \"cache\":true}]",
                            Controller = "Home"
                        },
                        new SideBar
                        {
                            Id = 3,
                            Titulo="Usuarios",
                            Descripcion="Gestión de Usuarios",
                            Label = "Usuarios",
                            Tabs = "[{\"label\":\"Listado\",\"url\":\"Users/Index\", \"close\":false, \"cache\":true},{\"label\":\"Grid MVVM\",\"url\":\"Users/GridMvvm\", \"close\":false, \"cache\":true},{\"label\":\"Nuevo\",\"url\":\"Users/Create\", \"close\":false, \"cache\":true}]",
                            Controller = "Users"
                        },
                        new SideBar
                        {
                            Id = 4,
                            Titulo="Modulos",
                            Descripcion="Gestión de Modulos",
                            Label = "Modulos",
                            Tabs = "[{\"label\":\"Listado\",\"url\":\"Home/Modulos\", \"close\":false, \"cache\":true}]",
                            Controller = "Users"
                        },
                        new SideBar
                        {
                            Id = 5,
                            Titulo="Departamento",
                            Descripcion="Gestión de Departamentos",
                            Label = "Departamento",
                            Tabs = "[{\"label\":\"Listado\",\"url\":\"Departamento/Index\", \"close\":false, \"cache\":true},{\"label\":\"Grid MVVM\",\"url\":\"Departamento/GridMvvm\", \"close\":false, \"cache\":true},{\"label\":\"Nuevo\",\"url\":\"Departamento/Create\", \"close\":false, \"cache\":true}]",
                            Controller = "Departamento"
                        }
                    }
                }
            };
        }
    }
}