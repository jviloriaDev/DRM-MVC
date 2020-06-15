using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_BR_Peer_Review;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Spartan_BR_Rejection_Reason;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_BR_Peer_Review;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Peer_Review;
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
    public class Spartan_BR_Peer_ReviewController : Controller
    {
        #region "variable declaration"

        private ISpartan_BR_Peer_ReviewService service = null;
        private ISpartan_BR_Peer_ReviewApiConsumer _ISpartan_BR_Peer_ReviewApiConsumer;
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

        
        public Spartan_BR_Peer_ReviewController(ISpartan_BR_Peer_ReviewService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_BR_Peer_ReviewApiConsumer Spartan_BR_Peer_ReviewApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , ISpartan_BR_Rejection_ReasonApiConsumer Spartan_BR_Rejection_ReasonApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_BR_Peer_ReviewApiConsumer = Spartan_BR_Peer_ReviewApiConsumer;
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

        // GET: Frontal/Spartan_BR_Peer_Review
        [ObjectAuth(ObjectId = (ModuleObjectId)35347, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35347);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Spartan_BR_Peer_Review/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)35347, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35347);
            ViewBag.Permission = permission;
            var varSpartan_BR_Peer_Review = new Spartan_BR_Peer_ReviewModel();
			
            ViewBag.ObjectId = "35347";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Peer_ReviewApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_BR_Peer_ReviewData = _ISpartan_BR_Peer_ReviewApiConsumer.GetByKeyComplete(Id).Resource.Spartan_BR_Peer_Reviews[0];
                if (Spartan_BR_Peer_ReviewData == null)
                    return HttpNotFound();

                varSpartan_BR_Peer_Review = new Spartan_BR_Peer_ReviewModel
                {
                    Key_Peer_Review = (int)Spartan_BR_Peer_ReviewData.Key_Peer_Review
                    ,User_that_reviewed = Spartan_BR_Peer_ReviewData.User_that_reviewed
                    ,User_that_reviewedName =  (string)Spartan_BR_Peer_ReviewData.User_that_reviewed_Spartan_User.Name
                    ,Acceptance_Criteria = Spartan_BR_Peer_ReviewData.Acceptance_Criteria
                    ,It_worked = Spartan_BR_Peer_ReviewData.It_worked.GetValueOrDefault()
                    ,Rejection_reason = Spartan_BR_Peer_ReviewData.Rejection_reason
                    ,Rejection_reasonDescription =  (string)Spartan_BR_Peer_ReviewData.Rejection_reason_Spartan_BR_Rejection_Reason.Description
                    ,Comments = Spartan_BR_Peer_ReviewData.Comments
                    ,Evidence = Spartan_BR_Peer_ReviewData.Evidence

                };
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.EvidenceSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varSpartan_BR_Peer_Review.Evidence).Resource;

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
            var Spartan_BR_Rejection_Reasons_Rejection_reason = _ISpartan_BR_Rejection_ReasonApiConsumer.SelAll(true);
            if (Spartan_BR_Rejection_Reasons_Rejection_reason != null && Spartan_BR_Rejection_Reasons_Rejection_reason.Resource != null)
                ViewBag.Spartan_BR_Rejection_Reasons_Rejection_reason = Spartan_BR_Rejection_Reasons_Rejection_reason.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.Key_Rejection_Reason)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_BR_Peer_Review);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_BR_Peer_Review(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35347);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_BR_Peer_ReviewApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_BR_Peer_ReviewModel varSpartan_BR_Peer_Review= new Spartan_BR_Peer_ReviewModel();


            if (id.ToString() != "0")
            {
                var Spartan_BR_Peer_ReviewsData = _ISpartan_BR_Peer_ReviewApiConsumer.ListaSelAll(0, 1000, "Spartan_BR_Peer_Review.Key_Peer_Review=" + id, "").Resource.Spartan_BR_Peer_Reviews;
				
				if (Spartan_BR_Peer_ReviewsData != null && Spartan_BR_Peer_ReviewsData.Count > 0)
                {
					var Spartan_BR_Peer_ReviewData = Spartan_BR_Peer_ReviewsData.First();
					varSpartan_BR_Peer_Review= new Spartan_BR_Peer_ReviewModel
					{
						Key_Peer_Review  = Spartan_BR_Peer_ReviewData.Key_Peer_Review 
	                    ,User_that_reviewed = Spartan_BR_Peer_ReviewData.User_that_reviewed
                    ,User_that_reviewedName =  (string)Spartan_BR_Peer_ReviewData.User_that_reviewed_Spartan_User.Name
                    ,Acceptance_Criteria = Spartan_BR_Peer_ReviewData.Acceptance_Criteria
                    ,It_worked = Spartan_BR_Peer_ReviewData.It_worked.GetValueOrDefault()
                    ,Rejection_reason = Spartan_BR_Peer_ReviewData.Rejection_reason
                    ,Rejection_reasonDescription =  (string)Spartan_BR_Peer_ReviewData.Rejection_reason_Spartan_BR_Rejection_Reason.Description
                    ,Comments = Spartan_BR_Peer_ReviewData.Comments
                    ,Evidence = Spartan_BR_Peer_ReviewData.Evidence

					};
				}
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.EvidenceSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varSpartan_BR_Peer_Review.Evidence).Resource;

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
            var Spartan_BR_Rejection_Reasons_Rejection_reason = _ISpartan_BR_Rejection_ReasonApiConsumer.SelAll(true);
            if (Spartan_BR_Rejection_Reasons_Rejection_reason != null && Spartan_BR_Rejection_Reasons_Rejection_reason.Resource != null)
                ViewBag.Spartan_BR_Rejection_Reasons_Rejection_reason = Spartan_BR_Rejection_Reasons_Rejection_reason.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.Key_Rejection_Reason)
                }).ToList();


            return PartialView("AddSpartan_BR_Peer_Review", varSpartan_BR_Peer_Review);
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_BR_Peer_ReviewPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_BR_Peer_ReviewApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Peer_Reviews == null)
                result.Spartan_BR_Peer_Reviews = new List<Spartan_BR_Peer_Review>();

            return Json(new
            {
                data = result.Spartan_BR_Peer_Reviews.Select(m => new Spartan_BR_Peer_ReviewGridModel
                    {
                    Key_Peer_Review = m.Key_Peer_Review
                        ,User_that_reviewedName = (string)m.User_that_reviewed_Spartan_User.Name
			,Acceptance_Criteria = m.Acceptance_Criteria
			,It_worked = m.It_worked
                        ,Rejection_reasonDescription = (string)m.Rejection_reason_Spartan_BR_Rejection_Reason.Description
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
                _ISpartan_BR_Peer_ReviewApiConsumer.SetAuthHeader(_tokenManager.Token);

                Spartan_BR_Peer_Review varSpartan_BR_Peer_Review = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _ISpartan_BR_Peer_ReviewApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_BR_Peer_ReviewModel varSpartan_BR_Peer_Review)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_BR_Peer_ReviewApiConsumer.SetAuthHeader(_tokenManager.Token);


                    if (varSpartan_BR_Peer_Review.EvidenceRemoveAttachment != 0 && varSpartan_BR_Peer_Review.EvidenceFile == null)
                    {
                        varSpartan_BR_Peer_Review.Evidence = 0;
                    }

                    if (varSpartan_BR_Peer_Review.EvidenceFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varSpartan_BR_Peer_Review.EvidenceFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varSpartan_BR_Peer_Review.Evidence = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varSpartan_BR_Peer_Review.EvidenceFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                    
                    var result = "";
                    var Spartan_BR_Peer_ReviewInfo = new Spartan_BR_Peer_Review
                    {
                        Key_Peer_Review = varSpartan_BR_Peer_Review.Key_Peer_Review
                        ,User_that_reviewed = varSpartan_BR_Peer_Review.User_that_reviewed
                        ,Acceptance_Criteria = varSpartan_BR_Peer_Review.Acceptance_Criteria
                        ,It_worked = varSpartan_BR_Peer_Review.It_worked
                        ,Rejection_reason = varSpartan_BR_Peer_Review.Rejection_reason
                        ,Comments = varSpartan_BR_Peer_Review.Comments
                        ,Evidence = (varSpartan_BR_Peer_Review.Evidence.HasValue && varSpartan_BR_Peer_Review.Evidence != 0) ? ((int?)Convert.ToInt32(varSpartan_BR_Peer_Review.Evidence.Value)) : null


                    };

                    result = !IsNew ?
                        _ISpartan_BR_Peer_ReviewApiConsumer.Update(Spartan_BR_Peer_ReviewInfo, null, null).Resource.ToString() :
                         _ISpartan_BR_Peer_ReviewApiConsumer.Insert(Spartan_BR_Peer_ReviewInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Spartan_BR_Peer_Review script
        /// </summary>
        /// <param name="oSpartan_BR_Peer_ReviewElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_BR_Peer_ReviewModuleAttributeList)
        {
            for (int i = 0; i < Spartan_BR_Peer_ReviewModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_BR_Peer_ReviewModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_BR_Peer_ReviewModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_BR_Peer_ReviewModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_BR_Peer_ReviewModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_BR_Peer_ReviewModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_BR_Peer_ReviewModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Spartan_BR_Peer_ReviewModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Spartan_BR_Peer_ReviewModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Spartan_BR_Peer_ReviewModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Spartan_BR_Peer_ReviewModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strSpartan_BR_Peer_ReviewScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Peer_Review.js")))
            {
                strSpartan_BR_Peer_ReviewScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_BR_Peer_Review element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_BR_Peer_ReviewModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_BR_Peer_ReviewScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_BR_Peer_ReviewScript.Substring(indexOfArray, strSpartan_BR_Peer_ReviewScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_BR_Peer_ReviewModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_BR_Peer_ReviewModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_BR_Peer_ReviewScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strSpartan_BR_Peer_ReviewScript.Substring(indexOfArrayHistory, strSpartan_BR_Peer_ReviewScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strSpartan_BR_Peer_ReviewScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_BR_Peer_ReviewScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_BR_Peer_ReviewScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Spartan_BR_Peer_ReviewModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strSpartan_BR_Peer_ReviewScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_BR_Peer_ReviewScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_BR_Peer_ReviewScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_BR_Peer_ReviewScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Peer_Review.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Peer_Review.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Peer_Review.js")))
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
        public ActionResult Spartan_BR_Peer_ReviewPropertyBag()
        {
            return PartialView("Spartan_BR_Peer_ReviewPropertyBag", "Spartan_BR_Peer_Review");
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

            _ISpartan_BR_Peer_ReviewApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_BR_Peer_ReviewPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_BR_Peer_ReviewApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Peer_Reviews == null)
                result.Spartan_BR_Peer_Reviews = new List<Spartan_BR_Peer_Review>();

            var data = result.Spartan_BR_Peer_Reviews.Select(m => new Spartan_BR_Peer_ReviewGridModel
            {
                Key_Peer_Review = m.Key_Peer_Review
                ,Acceptance_Criteria = m.Acceptance_Criteria
                ,It_worked = m.It_worked
                ,Comments = m.Comments

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_BR_Peer_ReviewList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_BR_Peer_ReviewList_" + DateTime.Now.ToString());
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

            _ISpartan_BR_Peer_ReviewApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_BR_Peer_ReviewPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_BR_Peer_ReviewApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Peer_Reviews == null)
                result.Spartan_BR_Peer_Reviews = new List<Spartan_BR_Peer_Review>();

            var data = result.Spartan_BR_Peer_Reviews.Select(m => new Spartan_BR_Peer_ReviewGridModel
            {
                Key_Peer_Review = m.Key_Peer_Review
                ,Acceptance_Criteria = m.Acceptance_Criteria
                ,It_worked = m.It_worked
                ,Comments = m.Comments

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
