using Newtonsoft.Json;
using Spartane.Core.Domain.Spartan_Format_Permissions;
using Spartane.Core.Domain.User;
using Spartane.Services.Security;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Permission_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Permissions;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Role;
using Spartane.Web.Areas.WebApiConsumer.SpartaneObject;
using Spartane.Web.Controllers;
using Spartane.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    public class Format_Permissions_ConfigurationController : Controller
    {
        #region "Variable Declaration"
        private ISpartan_User_RoleApiConsumer _IUserRoleApiConsumer;
        private ISpartan_FormatApiConsumer _ISpartan_FormatApiConsumer;
        private ISpartan_Format_Permission_TypeApiConsumer _ISpartan_Format_Permission_TypeApiConsumer;
        private ISpartan_Format_PermissionsApiConsumer _ISpartan_Format_PermissionsApiConsumer;
        private ITokenManager _tokenManager = null;
        #endregion

        #region "Cusontructor"

        public Format_Permissions_ConfigurationController(ISpartan_User_RoleApiConsumer RoleoApiConsumer, ITokenManager tokenManager, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_Permission_TypeApiConsumer ISpartan_Format_Permission_TypeApiConsumer, ISpartan_Format_PermissionsApiConsumer ISpartanFormatPermissionsApiConsumer)
        {
            //this.service = service;
            //this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._tokenManager = tokenManager;
            this._IUserRoleApiConsumer = RoleoApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_Permission_TypeApiConsumer = ISpartan_Format_Permission_TypeApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = ISpartanFormatPermissionsApiConsumer;
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
        public JsonResult getSpartanFormat()
        {
            string respuesta = "";
            bool token = _tokenManager.GenerateToken();
            if (!token)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);
                respuesta = JsonConvert.SerializeObject(_ISpartan_FormatApiConsumer.ListaSelAll(1, int.MaxValue, "", ""));
                 var data = _ISpartan_FormatApiConsumer.ListaSelAll(1, int.MaxValue, "", "");
                 var jsonResult=Json(data, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;  
            }

        }


        [HttpPost]
        public JsonResult getSpartanFormatPermissionType()
        {
            string respuesta = "";
            bool token = _tokenManager.GenerateToken();
            if (!token)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                _ISpartan_Format_Permission_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                respuesta = JsonConvert.SerializeObject(_ISpartan_Format_Permission_TypeApiConsumer.ListaSelAll(1, int.MaxValue, "", ""));
                return Json(_ISpartan_Format_Permission_TypeApiConsumer.ListaSelAll(1, int.MaxValue, "", ""), JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult getSpartanFormatPermissions(int id)
        {
            string respuesta = "";
            bool token = _tokenManager.GenerateToken();
            if (!token)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                _ISpartan_Format_PermissionsApiConsumer.SetAuthHeader(_tokenManager.Token);
                respuesta = JsonConvert.SerializeObject(_ISpartan_Format_PermissionsApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_User_Role = " + id, "").Resource.Spartan_Format_Permissionss);
                return Json(_ISpartan_Format_PermissionsApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_User_Role = " + id, "").Resource.Spartan_Format_Permissionss, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult processPermissions(List<Spartan_Format_Permissions> list)
        {
            string respuesta = "";
            bool token = _tokenManager.GenerateToken();
            if (!token)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                _ISpartan_Format_PermissionsApiConsumer.SetAuthHeader(_tokenManager.Token);
                foreach (Spartan_Format_Permissions s in list)
                {
                    if (s.Apply == true)
                    {
                        if (s.PermissionId > 0)
                        {
                            respuesta = JsonConvert.SerializeObject(_ISpartan_Format_PermissionsApiConsumer.Update(s, null, null));
                        }
                        else
                        {
                            respuesta = JsonConvert.SerializeObject(_ISpartan_Format_PermissionsApiConsumer.Insert(s, null, null));
                        }
                    }
                    else
                    {
                        respuesta = JsonConvert.SerializeObject(_ISpartan_Format_PermissionsApiConsumer.Delete(s.PermissionId, null, null));
                    }

                    
                    //return Json(_ISpartan_Format_PermissionsApiConsumer.Insert(s, null, null), JsonRequestBehavior.AllowGet);
                }

                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

    }
}