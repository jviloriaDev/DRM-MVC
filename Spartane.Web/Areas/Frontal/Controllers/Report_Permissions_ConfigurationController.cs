using Newtonsoft.Json;
using Spartane.Core.Domain.Spartan_Format_Permissions;
using Spartane.Core.Domain.Spartan_Report_Permissions;
using Spartane.Core.Domain.User;
using Spartane.Services.Security;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Permission_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Permissions;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Role;
using Spartane.Web.Areas.WebApiConsumer.SpartaneObject;
using Spartane.Web.Controllers;
using Spartane.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    public class Report_Permissions_ConfigurationController : Controller
    {
        #region "Variable Declaration"
        private ISpartan_User_RoleApiConsumer _IUserRoleApiConsumer;
        private ISpartan_ReportApiConsumer _ISpartan_ReportApiConsumer;
        private ISpartan_Report_Permission_TypeApiConsumer _ISpartan_Report_Permission_TypeApiConsumer;
        private ISpartan_Report_PermissionsApiConsumer _ISpartan_Report_PermissionsApiConsumer;

        private Spartane_Credential _userCredential = null;
        private ISpartanUserRoleService service = null;
        private ITokenManager _tokenManager = null;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private ISpartaneObjectApiConsumer _ISpartaneObjectApiConsumer;


        private ISpartanUserRoleService _ISpartanUserRoleService; // nsu


        #endregion


        #region "Cusontructor"

        public Report_Permissions_ConfigurationController(ISpartan_User_RoleApiConsumer RoleoApiConsumer, ITokenManager tokenManager, ISpartan_ReportApiConsumer ISpartan_ReportApiConsumer, ISpartan_Report_Permission_TypeApiConsumer ISpartan_Report_Permission_TypeApiConsumer, ISpartan_Report_PermissionsApiConsumer ISpartan_Report_PermissionsApiConsumer)
        {
            //this.service = service;
            //this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._tokenManager = tokenManager;
            this._IUserRoleApiConsumer = RoleoApiConsumer;

            this._ISpartan_ReportApiConsumer = ISpartan_ReportApiConsumer;
            this._ISpartan_Report_Permission_TypeApiConsumer = ISpartan_Report_Permission_TypeApiConsumer;
            this._ISpartan_Report_PermissionsApiConsumer = ISpartan_Report_PermissionsApiConsumer;
        }

        #endregion



        #region "Views"

        public ActionResult Index()
        {
            bool token = _tokenManager.GenerateToken();
            try
            {
                if (!token)
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    _IUserRoleApiConsumer.SetAuthHeader(_tokenManager.Token);
                    ViewBag.combo = _IUserRoleApiConsumer.ListaSelAll(1, int.MaxValue, "", "").Resource.Spartan_User_Roles;
                    return View();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpPost]
        public JsonResult getReportFormat()
        {
            string respuesta = "";
            bool token = _tokenManager.GenerateToken();
            if (!token)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);
                respuesta = JsonConvert.SerializeObject(_ISpartan_ReportApiConsumer.ListaSelAll(1, int.MaxValue, "", ""));
                return Json(_ISpartan_ReportApiConsumer.ListaSelAll(1, int.MaxValue, "", "").Resource.Spartan_Reports, JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        public JsonResult getSpartanReportPermissionType()
        {
            string respuesta = "";
            bool token = _tokenManager.GenerateToken();
            if (!token)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                _ISpartan_Report_Permission_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                respuesta = JsonConvert.SerializeObject(_ISpartan_Report_Permission_TypeApiConsumer.ListaSelAll(1, int.MaxValue, "", ""));
                return Json(_ISpartan_Report_Permission_TypeApiConsumer.ListaSelAll(1, int.MaxValue, "", "").Resource.Spartan_Report_Permission_Types, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        [WebMethod(EnableSession=true)]
        public JsonResult getSpartanReportPermissions(int id)
        {
            string respuesta = "";
            bool token = _tokenManager.GenerateToken();
            if (!token)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                _ISpartan_Report_PermissionsApiConsumer.SetAuthHeader(_tokenManager.Token);
                respuesta = JsonConvert.SerializeObject(_ISpartan_Report_PermissionsApiConsumer.ListaSelAll(1, int.MaxValue, "User_Role = " + id, "").Resource.Spartan_Report_Permissionss.ToList());
                List<Spartan_Report_Permissions> listaOrginal = (List<Spartan_Report_Permissions>)_ISpartan_Report_PermissionsApiConsumer.ListaSelAll(1, int.MaxValue, "User_Role = " + id, "").Resource.Spartan_Report_Permissionss.ToList();
                Session["listaOrginal"] = listaOrginal;
                return Json(_ISpartan_Report_PermissionsApiConsumer.ListaSelAll(1, int.MaxValue, "User_Role = " + id, "").Resource.Spartan_Report_Permissionss, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        [WebMethod(EnableSession = true)]
        public JsonResult processReportPermissions(List<Spartan_Report_Permissions> list)
        {
            string respuesta = "";
            bool token = _tokenManager.GenerateToken();
            if (!token)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<Spartan_Report_Permissions> listaOrginal = (List<Spartan_Report_Permissions>)Session["listaOrginal"];

                


                _ISpartan_Report_PermissionsApiConsumer.SetAuthHeader(_tokenManager.Token);
                foreach (Spartan_Report_Permissions s in listaOrginal)
                {

                    //buscando el elemento existente
                    //var query = from firstItem in listaOrginal
                    //            join secondItem in list
                    //            on firstItem.ReportPermissionId equals secondItem.ReportPermissionId
                    //            where (s.ReportPermissionId == secondItem.ReportPermissionId)
                    //            select firstItem;

                    bool containsItem = list != null && list.Any(item => item.ReportPermissionId == s.ReportPermissionId);

                    if (containsItem == false)
                    {
                        respuesta = JsonConvert.SerializeObject(_ISpartan_Report_PermissionsApiConsumer.Delete(s.ReportPermissionId, null, null));
                    }

                }


                if (list != null)
                {
                    foreach (Spartan_Report_Permissions s in list)
                    {

                        bool containsItem = listaOrginal.Any(item => item.ReportPermissionId == s.ReportPermissionId);

                        if (containsItem)
                        {
                            respuesta = JsonConvert.SerializeObject(_ISpartan_Report_PermissionsApiConsumer.Update(s, null, null));
                        }
                        else
                        {
                            respuesta = JsonConvert.SerializeObject(_ISpartan_Report_PermissionsApiConsumer.Insert(s, null, null));
                        }
                        //return Json(_ISpartan_Format_PermissionsApiConsumer.Insert(s, null, null), JsonRequestBehavior.AllowGet);
                    }
                }
                Spartane.Web.Helpers.MenuHelper.GetLatestMenu();
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion



    }
}