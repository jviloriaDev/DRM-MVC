using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_BR_Testing;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Spartan_BR_Rejection_Reason;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_BR_Testing;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Testing;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Rejection_Reason;

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
    public class Spartan_BR_TestingController : Controller
    {
        #region "variable declaration"

        private ISpartan_BR_TestingService service = null;
        private ISpartan_BR_TestingApiConsumer _ISpartan_BR_TestingApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private ISpartan_BR_Rejection_ReasonApiConsumer _ISpartan_BR_Rejection_ReasonApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Spartan_BR_TestingController(ISpartan_BR_TestingService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_BR_TestingApiConsumer Spartan_BR_TestingApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , ISpartan_BR_Rejection_ReasonApiConsumer Spartan_BR_Rejection_ReasonApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_BR_TestingApiConsumer = Spartan_BR_TestingApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._ISpartan_BR_Rejection_ReasonApiConsumer = Spartan_BR_Rejection_ReasonApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_BR_Testing
        [ObjectAuth(ObjectId = (ModuleObjectId)35348, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35348);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Spartan_BR_Testing/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)35348, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35348);
            ViewBag.Permission = permission;
            var varSpartan_BR_Testing = new Spartan_BR_TestingModel();
			
            ViewBag.ObjectId = "35348";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_TestingApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_BR_TestingData = _ISpartan_BR_TestingApiConsumer.GetByKeyComplete(Id).Resource.Spartan_BR_Testings[0];
                if (Spartan_BR_TestingData == null)
                    return HttpNotFound();

                varSpartan_BR_Testing = new Spartan_BR_TestingModel
                {
                    Key_Testing = (int)Spartan_BR_TestingData.Key_Testing
                    ,User_that_reviewed = Spartan_BR_TestingData.User_that_reviewed
                    ,User_that_reviewedName =  (string)Spartan_BR_TestingData.User_that_reviewed_Spartan_User.Name
                    ,Acceptance_Critera = Spartan_BR_TestingData.Acceptance_Critera
                    ,It_worked = Spartan_BR_TestingData.It_worked.GetValueOrDefault()
                    ,Rejection_Reason = Spartan_BR_TestingData.Rejection_Reason
                    ,Rejection_ReasonDescription =  (string)Spartan_BR_TestingData.Rejection_Reason_Spartan_BR_Rejection_Reason.Description
                    ,Comments = Spartan_BR_TestingData.Comments
                    ,Evidence = Spartan_BR_TestingData.Evidence

                };
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.EvidenceSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varSpartan_BR_Testing.Evidence).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_User_that_reviewed = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_User_that_reviewed != null && Spartan_Users_User_that_reviewed.Resource != null)
                ViewBag.Spartan_Users_User_that_reviewed = Spartan_Users_User_that_reviewed.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ISpartan_BR_Rejection_ReasonApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Rejection_Reasons_Rejection_Reason = _ISpartan_BR_Rejection_ReasonApiConsumer.SelAll(true);
            if (Spartan_BR_Rejection_Reasons_Rejection_Reason != null && Spartan_BR_Rejection_Reasons_Rejection_Reason.Resource != null)
                ViewBag.Spartan_BR_Rejection_Reasons_Rejection_Reason = Spartan_BR_Rejection_Reasons_Rejection_Reason.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.Key_Rejection_Reason)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_BR_Testing);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_BR_Testing(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35348);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_BR_TestingApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_BR_TestingModel varSpartan_BR_Testing= new Spartan_BR_TestingModel();


            if (id.ToString() != "0")
            {
                var Spartan_BR_TestingsData = _ISpartan_BR_TestingApiConsumer.ListaSelAll(0, 1000, "Spartan_BR_Testing.Key_Testing=" + id, "").Resource.Spartan_BR_Testings;
				
				if (Spartan_BR_TestingsData != null && Spartan_BR_TestingsData.Count > 0)
                {
					var Spartan_BR_TestingData = Spartan_BR_TestingsData.First();
					varSpartan_BR_Testing= new Spartan_BR_TestingModel
					{
						Key_Testing  = Spartan_BR_TestingData.Key_Testing 
	                    ,User_that_reviewed = Spartan_BR_TestingData.User_that_reviewed
                    ,User_that_reviewedName =  (string)Spartan_BR_TestingData.User_that_reviewed_Spartan_User.Name
                    ,Acceptance_Critera = Spartan_BR_TestingData.Acceptance_Critera
                    ,It_worked = Spartan_BR_TestingData.It_worked.GetValueOrDefault()
                    ,Rejection_Reason = Spartan_BR_TestingData.Rejection_Reason
                    ,Rejection_ReasonDescription =  (string)Spartan_BR_TestingData.Rejection_Reason_Spartan_BR_Rejection_Reason.Description
                    ,Comments = Spartan_BR_TestingData.Comments
                    ,Evidence = Spartan_BR_TestingData.Evidence

					};
				}
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.EvidenceSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varSpartan_BR_Testing.Evidence).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_User_that_reviewed = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_User_that_reviewed != null && Spartan_Users_User_that_reviewed.Resource != null)
                ViewBag.Spartan_Users_User_that_reviewed = Spartan_Users_User_that_reviewed.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ISpartan_BR_Rejection_ReasonApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Rejection_Reasons_Rejection_Reason = _ISpartan_BR_Rejection_ReasonApiConsumer.SelAll(true);
            if (Spartan_BR_Rejection_Reasons_Rejection_Reason != null && Spartan_BR_Rejection_Reasons_Rejection_Reason.Resource != null)
                ViewBag.Spartan_BR_Rejection_Reasons_Rejection_Reason = Spartan_BR_Rejection_Reasons_Rejection_Reason.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.Key_Rejection_Reason)
                }).ToList();


            return PartialView("AddSpartan_BR_Testing", varSpartan_BR_Testing);
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
        public ActionResult GetSpartan_BR_Rejection_ReasonAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Rejection_ReasonApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Rejection_ReasonApiConsumer.SelAll(false).Resource;
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_BR_TestingPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_BR_TestingApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Testings == null)
                result.Spartan_BR_Testings = new List<Spartan_BR_Testing>();

            return Json(new
            {
                data = result.Spartan_BR_Testings.Select(m => new Spartan_BR_TestingGridModel
                    {
                    Key_Testing = m.Key_Testing
                        ,User_that_reviewedName = (string)m.User_that_reviewed_Spartan_User.Name
			,Acceptance_Critera = m.Acceptance_Critera
			,It_worked = m.It_worked
                        ,Rejection_ReasonDescription = (string)m.Rejection_Reason_Spartan_BR_Rejection_Reason.Description
			,Comments = m.Comments
			,Evidence = m.Evidence

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
                _ISpartan_BR_TestingApiConsumer.SetAuthHeader(_tokenManager.Token);

                Spartan_BR_Testing varSpartan_BR_Testing = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _ISpartan_BR_TestingApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_BR_TestingModel varSpartan_BR_Testing)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_BR_TestingApiConsumer.SetAuthHeader(_tokenManager.Token);


                    if (varSpartan_BR_Testing.EvidenceRemoveAttachment != 0 && varSpartan_BR_Testing.EvidenceFile == null)
                    {
                        varSpartan_BR_Testing.Evidence = 0;
                    }

                    if (varSpartan_BR_Testing.EvidenceFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varSpartan_BR_Testing.EvidenceFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varSpartan_BR_Testing.Evidence = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varSpartan_BR_Testing.EvidenceFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                    
                    var result = "";
                    var Spartan_BR_TestingInfo = new Spartan_BR_Testing
                    {
                        Key_Testing = varSpartan_BR_Testing.Key_Testing
                        ,User_that_reviewed = varSpartan_BR_Testing.User_that_reviewed
                        ,Acceptance_Critera = varSpartan_BR_Testing.Acceptance_Critera
                        ,It_worked = varSpartan_BR_Testing.It_worked
                        ,Rejection_Reason = varSpartan_BR_Testing.Rejection_Reason
                        ,Comments = varSpartan_BR_Testing.Comments
                        ,Evidence = (varSpartan_BR_Testing.Evidence.HasValue && varSpartan_BR_Testing.Evidence != 0) ? ((int?)Convert.ToInt32(varSpartan_BR_Testing.Evidence.Value)) : null


                    };

                    result = !IsNew ?
                        _ISpartan_BR_TestingApiConsumer.Update(Spartan_BR_TestingInfo, null, null).Resource.ToString() :
                         _ISpartan_BR_TestingApiConsumer.Insert(Spartan_BR_TestingInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Spartan_BR_Testing script
        /// </summary>
        /// <param name="oSpartan_BR_TestingElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_BR_TestingModuleAttributeList)
        {
            for (int i = 0; i < Spartan_BR_TestingModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_BR_TestingModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_BR_TestingModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_BR_TestingModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_BR_TestingModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_BR_TestingModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_BR_TestingModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Spartan_BR_TestingModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Spartan_BR_TestingModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Spartan_BR_TestingModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Spartan_BR_TestingModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strSpartan_BR_TestingScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Testing.js")))
            {
                strSpartan_BR_TestingScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_BR_Testing element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_BR_TestingModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_BR_TestingScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_BR_TestingScript.Substring(indexOfArray, strSpartan_BR_TestingScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_BR_TestingModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_BR_TestingModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_BR_TestingScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strSpartan_BR_TestingScript.Substring(indexOfArrayHistory, strSpartan_BR_TestingScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strSpartan_BR_TestingScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_BR_TestingScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_BR_TestingScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Spartan_BR_TestingModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strSpartan_BR_TestingScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_BR_TestingScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_BR_TestingScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_BR_TestingScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Testing.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Testing.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Testing.js")))
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
        public ActionResult Spartan_BR_TestingPropertyBag()
        {
            return PartialView("Spartan_BR_TestingPropertyBag", "Spartan_BR_Testing");
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

            _ISpartan_BR_TestingApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_BR_TestingPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_BR_TestingApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Testings == null)
                result.Spartan_BR_Testings = new List<Spartan_BR_Testing>();

            var data = result.Spartan_BR_Testings.Select(m => new Spartan_BR_TestingGridModel
            {
                Key_Testing = m.Key_Testing
                ,Acceptance_Critera = m.Acceptance_Critera
                ,It_worked = m.It_worked
                ,Comments = m.Comments

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_BR_TestingList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_BR_TestingList_" + DateTime.Now.ToString());
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

            _ISpartan_BR_TestingApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_BR_TestingPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_BR_TestingApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Testings == null)
                result.Spartan_BR_Testings = new List<Spartan_BR_Testing>();

            var data = result.Spartan_BR_Testings.Select(m => new Spartan_BR_TestingGridModel
            {
                Key_Testing = m.Key_Testing
                ,Acceptance_Critera = m.Acceptance_Critera
                ,It_worked = m.It_worked
                ,Comments = m.Comments

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
