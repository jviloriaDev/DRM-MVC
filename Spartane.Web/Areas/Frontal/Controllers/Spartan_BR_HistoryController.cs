using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_BR_History;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Spartan_BR_Status;
using Spartane.Core.Domain.Spartan_BR_Type_History;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_BR_History;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_History;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Type_History;

using Spartane.Web.AuthFilters;
using Spartane.Web.Helpers;
using Spartane.Web.Models;
using Spartane.Web.SqlModelMapper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;
using Spartane.Core.Domain.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event_Detail;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Spartan_BR_HistoryController : Controller
    {
        #region "variable declaration"

        private ISpartan_BR_HistoryService service = null;
        private ISpartan_BR_HistoryApiConsumer _ISpartan_BR_HistoryApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private ISpartan_BR_StatusApiConsumer _ISpartan_BR_StatusApiConsumer;
        private ISpartan_BR_Type_HistoryApiConsumer _ISpartan_BR_Type_HistoryApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Spartan_BR_HistoryController(ISpartan_BR_HistoryService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_BR_HistoryApiConsumer Spartan_BR_HistoryApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , ISpartan_BR_StatusApiConsumer Spartan_BR_StatusApiConsumer , ISpartan_BR_Type_HistoryApiConsumer Spartan_BR_Type_HistoryApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_BR_HistoryApiConsumer = Spartan_BR_HistoryApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._ISpartan_BR_StatusApiConsumer = Spartan_BR_StatusApiConsumer;
            this._ISpartan_BR_Type_HistoryApiConsumer = Spartan_BR_Type_HistoryApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_BR_History
        [ObjectAuth(ObjectId = (ModuleObjectId)35398, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35398);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Spartan_BR_History/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)35398, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35398);
            ViewBag.Permission = permission;
            var varSpartan_BR_History = new Spartan_BR_HistoryModel();
			
            ViewBag.ObjectId = "35398";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_HistoryApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_BR_HistoryData = _ISpartan_BR_HistoryApiConsumer.GetByKeyComplete(Id).Resource.Spartan_BR_Historys[0];
                if (Spartan_BR_HistoryData == null)
                    return HttpNotFound();

                varSpartan_BR_History = new Spartan_BR_HistoryModel
                {
                    Key_History = (int)Spartan_BR_HistoryData.Key_History
                    ,User_logged = Spartan_BR_HistoryData.User_logged
                    ,User_loggedName =  (string)Spartan_BR_HistoryData.User_logged_Spartan_User.Name
                    ,Status = Spartan_BR_HistoryData.Status
                    ,StatusDescription =  (string)Spartan_BR_HistoryData.Status_Spartan_BR_Status.Description
                    ,Change_Date = (Spartan_BR_HistoryData.Change_Date == null ? string.Empty : Convert.ToDateTime(Spartan_BR_HistoryData.Change_Date).ToString(ConfigurationProperty.DateFormat))
                    ,Hour_Date = Spartan_BR_HistoryData.Hour_Date
                    ,Time_elapsed = Spartan_BR_HistoryData.Time_elapsed
                    ,Change_Type = Spartan_BR_HistoryData.Change_Type
                    ,Change_TypeDescription =  (string)Spartan_BR_HistoryData.Change_Type_Spartan_BR_Type_History.Description
                    ,Conditions = Spartan_BR_HistoryData.Conditions
                    ,Actions_True = Spartan_BR_HistoryData.Actions_True
                    ,Actions_False = Spartan_BR_HistoryData.Actions_False

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_User_logged = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_User_logged != null && Spartan_Users_User_logged.Resource != null)
                ViewBag.Spartan_Users_User_logged = Spartan_Users_User_logged.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ISpartan_BR_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Statuss_Status = _ISpartan_BR_StatusApiConsumer.SelAll(true);
            if (Spartan_BR_Statuss_Status != null && Spartan_BR_Statuss_Status.Resource != null)
                ViewBag.Spartan_BR_Statuss_Status = Spartan_BR_Statuss_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.StatusId)
                }).ToList();
            _ISpartan_BR_Type_HistoryApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Type_Historys_Change_Type = _ISpartan_BR_Type_HistoryApiConsumer.SelAll(true);
            if (Spartan_BR_Type_Historys_Change_Type != null && Spartan_BR_Type_Historys_Change_Type.Resource != null)
                ViewBag.Spartan_BR_Type_Historys_Change_Type = Spartan_BR_Type_Historys_Change_Type.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.Key_Type_History)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_BR_History);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_BR_History(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35398);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_BR_HistoryApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_BR_HistoryModel varSpartan_BR_History= new Spartan_BR_HistoryModel();


            if (id.ToString() != "0")
            {
                var Spartan_BR_HistorysData = _ISpartan_BR_HistoryApiConsumer.ListaSelAll(0, 1000, "Spartan_BR_History.Key_History=" + id, "").Resource.Spartan_BR_Historys;
				
				if (Spartan_BR_HistorysData != null && Spartan_BR_HistorysData.Count > 0)
                {
					var Spartan_BR_HistoryData = Spartan_BR_HistorysData.First();
					varSpartan_BR_History= new Spartan_BR_HistoryModel
					{
						Key_History  = Spartan_BR_HistoryData.Key_History 
	                    ,User_logged = Spartan_BR_HistoryData.User_logged
                    ,User_loggedName =  (string)Spartan_BR_HistoryData.User_logged_Spartan_User.Name
                    ,Status = Spartan_BR_HistoryData.Status
                    ,StatusDescription =  (string)Spartan_BR_HistoryData.Status_Spartan_BR_Status.Description
                    ,Change_Date = (Spartan_BR_HistoryData.Change_Date == null ? string.Empty : Convert.ToDateTime(Spartan_BR_HistoryData.Change_Date).ToString(ConfigurationProperty.DateFormat))
                    ,Hour_Date = Spartan_BR_HistoryData.Hour_Date
                    ,Time_elapsed = Spartan_BR_HistoryData.Time_elapsed
                    ,Change_Type = Spartan_BR_HistoryData.Change_Type
                    ,Change_TypeDescription =  (string)Spartan_BR_HistoryData.Change_Type_Spartan_BR_Type_History.Description
                    ,Conditions = Spartan_BR_HistoryData.Conditions
                    ,Actions_True = Spartan_BR_HistoryData.Actions_True
                    ,Actions_False = Spartan_BR_HistoryData.Actions_False

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_User_logged = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_User_logged != null && Spartan_Users_User_logged.Resource != null)
                ViewBag.Spartan_Users_User_logged = Spartan_Users_User_logged.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ISpartan_BR_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Statuss_Status = _ISpartan_BR_StatusApiConsumer.SelAll(true);
            if (Spartan_BR_Statuss_Status != null && Spartan_BR_Statuss_Status.Resource != null)
                ViewBag.Spartan_BR_Statuss_Status = Spartan_BR_Statuss_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.StatusId)
                }).ToList();
            _ISpartan_BR_Type_HistoryApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Type_Historys_Change_Type = _ISpartan_BR_Type_HistoryApiConsumer.SelAll(true);
            if (Spartan_BR_Type_Historys_Change_Type != null && Spartan_BR_Type_Historys_Change_Type.Resource != null)
                ViewBag.Spartan_BR_Type_Historys_Change_Type = Spartan_BR_Type_Historys_Change_Type.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.Key_Type_History)
                }).ToList();


            return PartialView("AddSpartan_BR_History", varSpartan_BR_History);
        }


        [HttpGet]
        public FileResult GetFile(int id)
        {

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var fileInfo = _ISpartane_FileApiConsumer.GetByKey(id).Resource;
            if (fileInfo == null)
                return null;
            return File(fileInfo.File, System.Net.Mime.MediaTypeNames.Application.Octet, fileInfo.Description);
        }

        [HttpGet]
        public ActionResult GetSpartan_UserAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_UserApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_BR_StatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_StatusApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_BR_Type_HistoryAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Type_HistoryApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Type_HistoryApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }




        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_BR_HistoryPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_BR_HistoryApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Historys == null)
                result.Spartan_BR_Historys = new List<Spartan_BR_History>();

            return Json(new
            {
                data = result.Spartan_BR_Historys.Select(m => new Spartan_BR_HistoryGridModel
                    {
                    Key_History = m.Key_History
                        ,User_loggedName = (string)m.User_logged_Spartan_User.Name
                        ,StatusDescription = (string)m.Status_Spartan_BR_Status.Description
                        ,Change_Date = (m.Change_Date == null ? string.Empty : Convert.ToDateTime(m.Change_Date).ToString(ConfigurationProperty.DateFormat))
			,Hour_Date = m.Hour_Date
			,Time_elapsed = m.Time_elapsed
                        ,Change_TypeDescription = (string)m.Change_Type_Spartan_BR_Type_History.Description
			,Conditions = m.Conditions
			,Actions_True = m.Actions_True
			,Actions_False = m.Actions_False

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }







       

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }



        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_HistoryApiConsumer.SetAuthHeader(_tokenManager.Token);

                Spartan_BR_History varSpartan_BR_History = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _ISpartan_BR_HistoryApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_BR_HistoryModel varSpartan_BR_History)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_BR_HistoryApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Spartan_BR_HistoryInfo = new Spartan_BR_History
                    {
                        Key_History = varSpartan_BR_History.Key_History
                        ,User_logged = varSpartan_BR_History.User_logged
                        ,Status = varSpartan_BR_History.Status
                        ,Change_Date = (!String.IsNullOrEmpty(varSpartan_BR_History.Change_Date)) ? DateTime.ParseExact(varSpartan_BR_History.Change_Date, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hour_Date = varSpartan_BR_History.Hour_Date
                        ,Time_elapsed = varSpartan_BR_History.Time_elapsed
                        ,Change_Type = varSpartan_BR_History.Change_Type
                        ,Conditions = varSpartan_BR_History.Conditions
                        ,Actions_True = varSpartan_BR_History.Actions_True
                        ,Actions_False = varSpartan_BR_History.Actions_False

                    };

                    result = !IsNew ?
                        _ISpartan_BR_HistoryApiConsumer.Update(Spartan_BR_HistoryInfo, null, null).Resource.ToString() :
                         _ISpartan_BR_HistoryApiConsumer.Insert(Spartan_BR_HistoryInfo, null, null).Resource.ToString();

                    return Json(result, JsonRequestBehavior.AllowGet);
				}
				return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Spartan_BR_History script
        /// </summary>
        /// <param name="oSpartan_BR_HistoryElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_BR_HistoryModuleAttributeList)
        {
            for (int i = 0; i < Spartan_BR_HistoryModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_BR_HistoryModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_BR_HistoryModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_BR_HistoryModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_BR_HistoryModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_BR_HistoryModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_BR_HistoryModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Spartan_BR_HistoryModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Spartan_BR_HistoryModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Spartan_BR_HistoryModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Spartan_BR_HistoryModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strSpartan_BR_HistoryScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_BR_History.js")))
            {
                strSpartan_BR_HistoryScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_BR_History element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_BR_HistoryModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_BR_HistoryScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_BR_HistoryScript.Substring(indexOfArray, strSpartan_BR_HistoryScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_BR_HistoryModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_BR_HistoryModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_BR_HistoryScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strSpartan_BR_HistoryScript.Substring(indexOfArrayHistory, strSpartan_BR_HistoryScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strSpartan_BR_HistoryScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_BR_HistoryScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_BR_HistoryScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Spartan_BR_HistoryModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strSpartan_BR_HistoryScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_BR_HistoryScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_BR_HistoryScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_BR_HistoryScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_BR_History.js")))
            {
                w.WriteLine(finalResponse);
            }
            
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        

        [HttpPost]
        public JsonResult ReadScriptSettings()
        {
            string strCustomScript = string.Empty;
            
            CustomElementAttribute oCustomElementAttribute = new CustomElementAttribute();

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_BR_History.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_BR_History.js")))
                {
                    strCustomScript = r.ReadToEnd();
                
                }

                int indexOfArray = strCustomScript.IndexOf("inpuElementArray");
                string splittedString = strCustomScript.Substring(indexOfArray, strCustomScript.Length - indexOfArray);                
                int indexOfMainElement = splittedString.IndexOf('[');                
                int endIndexOfMainElement = splittedString.IndexOf(']') + 1;                
                string mainJsonArray = splittedString.Substring(indexOfMainElement, endIndexOfMainElement - indexOfMainElement);

                int indexOfChildArray = strCustomScript.IndexOf("inpuElementChildArray");
				string childJsonArray = "";
                if (indexOfChildArray != -1)
                {
					string splittedChildString = strCustomScript.Substring(indexOfChildArray, strCustomScript.Length - indexOfChildArray);
					int indexOfChildElement = splittedChildString.IndexOf('[');
					int endIndexOfChildElement = splittedChildString.IndexOf(']') + 1;
					childJsonArray = splittedChildString.Substring(indexOfChildElement, endIndexOfChildElement - indexOfChildElement);
				}
                var MainElementList = JsonConvert.DeserializeObject(mainJsonArray);
                var ChildElementList = JsonConvert.DeserializeObject(childJsonArray);

                oCustomElementAttribute.MainElement = MainElementList.ToString();
				if (indexOfChildArray != -1)
                {
					oCustomElementAttribute.ChildElement = ChildElementList.ToString();
				}
            }
            else
            {
                oCustomElementAttribute.MainElement = string.Empty;
                oCustomElementAttribute.ChildElement = string.Empty;
            }        
            return Json(oCustomElementAttribute, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Spartan_BR_HistoryPropertyBag()
        {
            return PartialView("Spartan_BR_HistoryPropertyBag", "Spartan_BR_History");
        }
		
		public List<Spartan_Business_Rule> GetBusinessRules(int ObjectId, int Attribute)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            List<Spartan_Business_Rule> result = new List<Spartan_Business_Rule>();
            _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (Attribute != 0)
            {
                result = _ISpartan_Business_RuleApiConsumer.ListaSelAll(0, 1000, "Object = " + ObjectId + " AND Attribute = " + Attribute, "").Resource.Spartan_Business_Rules;
            }
            else
            {
                List<Spartan_Business_Rule> partialResult = _ISpartan_Business_RuleApiConsumer.ListaSelAll(0, 1000, "Object = " + ObjectId, "").Resource.Spartan_Business_Rules;
                foreach (var item in partialResult)
                {
                    if (item.Attribute == Attribute)
                    {
                        result.Add(item);
                    }
                    else//Busco las reglas con el event process en cuestion
                    {
                        _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                        var eventProcess = _ISpartan_BR_Process_Event_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + item.BusinessRuleId, "").Resource;
                        if (Attribute == 0 && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 1).Count() > 0)
                        {
                            result.Add(item);
                        }
                        if ((Attribute == 2) && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 2 || x.Process_Event == 3).Count() > 0)
                        {
                            result.Add(item);
                        }
                        if ((Attribute == 3) && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 4 || x.Process_Event == 5).Count() > 0)
                        {
                            result.Add(item);
                        }
                        //TODO Faltan en la base de datos cuando creas una row de grilla
                    }
                }
            }
            return result;
        }



        #endregion "Controller Methods"

        #region "Custom methods"

        [HttpGet]
        public void Export(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return;

            _ISpartan_BR_HistoryApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_BR_HistoryPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_BR_HistoryApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Historys == null)
                result.Spartan_BR_Historys = new List<Spartan_BR_History>();

            var data = result.Spartan_BR_Historys.Select(m => new Spartan_BR_HistoryGridModel
            {
                Key_History = m.Key_History
                ,Hour_Date = m.Hour_Date
                ,Time_elapsed = m.Time_elapsed
                ,Conditions = m.Conditions
                ,Actions_True = m.Actions_True
                ,Actions_False = m.Actions_False

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_BR_HistoryList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_BR_HistoryList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "EmployeeList_" + DateTime.Now.ToString());
                    break;
            }
        }

        [HttpGet]
        //[ObjectAuth(ObjectId = ModuleObjectId.EMPLEADOS_OBJECT, PermissionType = PermissionTypes.Export)]
        public ActionResult Print(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return null;

            _ISpartan_BR_HistoryApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_BR_HistoryPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_BR_HistoryApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Historys == null)
                result.Spartan_BR_Historys = new List<Spartan_BR_History>();

            var data = result.Spartan_BR_Historys.Select(m => new Spartan_BR_HistoryGridModel
            {
                Key_History = m.Key_History
                ,Hour_Date = m.Hour_Date
                ,Time_elapsed = m.Time_elapsed
                ,Conditions = m.Conditions
                ,Actions_True = m.Actions_True
                ,Actions_False = m.Actions_False

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
