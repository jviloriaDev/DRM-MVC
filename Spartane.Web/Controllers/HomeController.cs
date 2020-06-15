using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Spartane.Services.Security;
using Spartane.Services.Authentication;

namespace Spartane.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPermissionService _permissionService;
        private readonly IAuthenticationService _authenticationService;

        public HomeController(IPermissionService permissionService,
                               IAuthenticationService authenticationService)
        {
            this._permissionService = permissionService;
            this._authenticationService = authenticationService;
        }
        public ActionResult Index()
        
        {
            //var item = _principalPageService.GetByKey(1);
            //var itemAuth = _authenticationService.Login("admin", "admin",0);
            //var itemPerm = _permissionService.ModulesPermited(itemAuth);
            //ViewBag.Message = item!= null ? item.Texto_Largo + " " + item.Combo_Autocompletable.Descripcion: "Page Index Not found";
            //_authenticationService.LogOff(itemAuth);
            return RedirectToAction("Index", "Home", new { area = "Frontal" });
            //return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Corporate Totaltech.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Corporate Totaltech.";

            return View();
        }
        public ActionResult BusinessRulesTest01()
        {
            ViewBag.Message = "Business Rules Test01";
            return View();
        }

        public ActionResult Users()
        {
            return View("../User/Index");
        }

        public ActionResult Departamento()
        {
            return View("../Departamento/Index");
        }
    }
}