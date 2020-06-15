using Spartane.Core.Domain.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartan_ChangePasswordAutorization;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.SpartaneQuery;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Settings;
using Spartane.Core.Domain.Spartan_ChangePasswordAutorization;
using Spartane.Web.Helpers;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Historical_Password;
using Spartane.Core.Domain.Spartan_User_Historical_Password;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    public class AccountsController : Controller
    {
        private ITokenManager _tokenManager = null;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer { get; set; }

        private ISpartaneQueryApiConsumer _ISpartaneQueryApiConsumer;

        private ISpartan_ChangePasswordAutorizationApiConsumer _ISpartan_ChangePasswordAutorizationApiConsumer;

        private ISpartan_SettingsApiConsumer _ISpartan_SettingsApiConsumer;
        private ISpartan_User_Historical_PasswordApiConsumer _ISpartan_User_Historical_PasswordApiConsumer;

        public AccountsController(ITokenManager tokenManager, ISpartan_UserApiConsumer Spartan_UserApiConsumer, ISpartaneQueryApiConsumer SpartaneQueryApiConsumer, ISpartan_SettingsApiConsumer Spartan_SettingsApiConsumer, ISpartan_ChangePasswordAutorizationApiConsumer Spartan_ChangePasswordAutorizationApiConsumer, ISpartan_User_Historical_PasswordApiConsumer Spartan_User_Historical_PasswordApiConsumer)
        {
            this._tokenManager = tokenManager;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;

            this._ISpartaneQueryApiConsumer = SpartaneQueryApiConsumer;
            this._ISpartan_SettingsApiConsumer = Spartan_SettingsApiConsumer;
            this._ISpartan_ChangePasswordAutorizationApiConsumer = Spartan_ChangePasswordAutorizationApiConsumer;
            this._ISpartan_User_Historical_PasswordApiConsumer = Spartan_User_Historical_PasswordApiConsumer;
        }
        // GET: Frontal/Accounts
        public ActionResult UnAuthorized(string controllerName, string actionName)
        {
            ViewBag.ControllerName = controllerName;
            ViewBag.ActionName = actionName;

            return View();
        }

        public ActionResult CollapseDesign()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_ChangePasswordAutorizationApiConsumer.SetAuthHeader(_tokenManager.Token);
            int userId = Convert.ToInt32(Session["USERID"]);
            var model = _ISpartan_UserApiConsumer.GetByKey(userId, false).Resource;
            
            var passwordAutorizations = _ISpartan_ChangePasswordAutorizationApiConsumer.ListaSelAll(0, 100, "Spartan_ChangePasswordAutorization.Usuario=" + userId, "Spartan_ChangePasswordAutorization.Clave DESC").Resource;
            
            Session["EstatusChangePassword"] = 0;
            if (passwordAutorizations.RowCount > 0)
            {
                Session["EstatusChangePassword"] = passwordAutorizations.Spartan_ChangePasswordAutorizations.First().Estatus;
            }
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult ChangePassword(Spartan_User spartan_user)
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            int userId = Convert.ToInt32(Session["USERID"]);
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_ChangePasswordAutorizationApiConsumer.SetAuthHeader(_tokenManager.Token);
            var user = _ISpartan_UserApiConsumer.GetByKey(userId, false).Resource;
            if (Session["EstatusChangePassword"].ToString() == "0" || Session["EstatusChangePassword"].ToString() == "4")
            {                
                Spartan_ChangePasswordAutorization newChange = new Spartan_ChangePasswordAutorization();
                newChange.Estatus = 1;
                newChange.Fecha_de_Registro = DateTime.Now;
                newChange.Hora_de_Registro = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString();
                newChange.Usuario = userId;
                newChange.Email = user.Email;

                var result = _ISpartan_ChangePasswordAutorizationApiConsumer.Insert(newChange, null, null).Resource;

                //SEND EMAIL TO ADMIN
                var usersAdmin = _ISpartan_UserApiConsumer.ListaSelAll(0, 10, "Spartan_User.Role = 1", "").Resource;
                List<string> to = new List<string>();
                if (usersAdmin.RowCount > 0)
                {
                    foreach (var userAdmin in usersAdmin.Spartan_Users)
                    {
                        to.Add(userAdmin.Email);
                    }
                    Helper.SendEmail(to, "Pedido de cambio de Password", "El usuario " + user.Name + " con ID=" + user.Id_User + " ha solicitado cambio de password.");
                }
            }
            else
            {
                _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
                _ISpartan_User_Historical_PasswordApiConsumer.SetAuthHeader(_tokenManager.Token);
                
                var model = _ISpartan_UserApiConsumer.GetByKey(spartan_user.Id_User, false).Resource;
                model.Password = EncryptHelper.CalculateMD5Hash(spartan_user.Password);
                _ISpartan_UserApiConsumer.Update(model, null, null);
                _ISpartan_SettingsApiConsumer.SetAuthHeader(_tokenManager.Token);
                var ExpirationDaysDB = _ISpartan_SettingsApiConsumer.GetByKey("ExpirationDays", false).Resource;
                int ExpirationDays = Convert.ToInt32(ExpirationDaysDB.Valor);
                DateTime newDateExpiracion = DateTime.Now.AddDays(ExpirationDays);
                var fechaJSON = _ISpartaneQueryApiConsumer.ExecuteRawQuery("UPDATE Spartan_User SET Fecha_de_Expiracion = '" + newDateExpiracion.ToString("yyyy-MM-dd") + "' where Id_User=" + spartan_user.Id_User).Resource;

                var changes = _ISpartan_ChangePasswordAutorizationApiConsumer.ListaSelAll(0, 10, "Spartan_ChangePasswordAutorization.Estatus=2", "").Resource;
                if (changes.RowCount > 0)
                {
                    var lastChange = changes.Spartan_ChangePasswordAutorizations.First();
                    lastChange.Estatus = 4;
                    var result = _ISpartan_ChangePasswordAutorizationApiConsumer.Update(lastChange, null, null).Resource;
                }

                //ADD TO HISTORICAL
                Spartan_User_Historical_Password newData = new Spartan_User_Historical_Password();
                newData.Fecha_de_Registro = DateTime.Now;
                newData.Password = EncryptHelper.CalculateMD5Hash(spartan_user.Password);
                newData.Usuario = spartan_user.Id_User;
                var resultInsert = _ISpartan_User_Historical_PasswordApiConsumer.Insert(newData, null, null).Resource;
               
            }
            return Redirect("~/");
        }

        [HttpGet]
        public JsonResult ValidateOldPassword(string password)
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            int userId = Convert.ToInt32(Session["USERID"]);
            _ISpartan_SettingsApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_User_Historical_PasswordApiConsumer.SetAuthHeader(_tokenManager.Token);
            var CountSamePasswordDB = _ISpartan_SettingsApiConsumer.GetByKey("CountSamePassword", false).Resource;
            int CountSamePassword = Convert.ToInt32(CountSamePasswordDB.Valor);
            bool wasUsed = false;
            var listOldPasswords = _ISpartan_User_Historical_PasswordApiConsumer.ListaSelAll(0, 10, "Spartan_User_Historical_Password.Usuario=" + userId, "").Resource;
            if (listOldPasswords.RowCount > 0)
            {
                foreach (var oldPass in listOldPasswords.Spartan_User_Historical_Passwords)
                {
                    if (oldPass.Password == EncryptHelper.CalculateMD5Hash(password) && DateTime.Now.AddDays(CountSamePassword * -1) < oldPass.Fecha_de_Registro)
                        wasUsed = true;
                }
            }

            return Json(wasUsed, JsonRequestBehavior.AllowGet);
        }
    }
}