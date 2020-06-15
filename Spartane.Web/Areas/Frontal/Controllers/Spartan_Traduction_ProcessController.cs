using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_Traduction_Process;
using Spartane.Core.Domain.Spartan_Traduction_Process_Data;
using Spartane.Core.Domain.Spartan_Traduction_Concept_Type;

using Spartane.Core.Domain.Spartan_Traduction_Language;
using Spartane.Core.Domain.Spartan_Traduction_Object_Type;
using Spartane.Core.Domain.SpartanObject;
using Spartane.Core.Domain.Spartan_Traduction_Detail;
using Spartane.Core.Domain.Spartan_Traduction_Concept_Type;

using Spartane.Core.Domain.Spartan_Traduction_Process_Workflow;
using Spartane.Core.Domain.Spartan_Traduction_Concept_Type;


using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_Traduction_Process;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Process;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Process_Data;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Concept_Type;

using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Language;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Object_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Concept_Type;

using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Process_Workflow;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Traduction_Concept_Type;


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

using Spartane.Web.Areas.WebApiConsumer.Spartan_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Permissions;
using Spartane.Web.Areas.WebApiConsumer.GeneratePDF;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.SpartaneObject;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Spartan_Traduction_ProcessController : Controller
    {
        #region "variable declaration"

        private ISpartan_Traduction_ProcessService service = null;
        private ISpartan_Traduction_ProcessApiConsumer _ISpartan_Traduction_ProcessApiConsumer;
        private ISpartan_Traduction_Process_DataApiConsumer _ISpartan_Traduction_Process_DataApiConsumer;
        private ISpartan_Traduction_Concept_TypeApiConsumer _ISpartan_Traduction_Concept_TypeApiConsumer;

        private ISpartan_Traduction_LanguageApiConsumer _ISpartan_Traduction_LanguageApiConsumer;
        private ISpartan_Traduction_Object_TypeApiConsumer _ISpartan_Traduction_Object_TypeApiConsumer;
        private ISpartaneObjectApiConsumer _ISpartanObjectApiConsumer;
        private ISpartan_Traduction_DetailApiConsumer _ISpartan_Traduction_DetailApiConsumer;

        private ISpartan_Traduction_Process_WorkflowApiConsumer _ISpartan_Traduction_Process_WorkflowApiConsumer;


        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;
        private IGeneratePDFApiConsumer _IGeneratePDFApiConsumer;
        private ISpartan_FormatApiConsumer _ISpartan_FormatApiConsumer;
        private ISpartan_Format_PermissionsApiConsumer _ISpartan_Format_PermissionsApiConsumer;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Spartan_Traduction_ProcessController(ISpartan_Traduction_ProcessService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_Traduction_ProcessApiConsumer Spartan_Traduction_ProcessApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer , ISpartan_Traduction_Process_DataApiConsumer Spartan_Traduction_Process_DataApiConsumer , ISpartan_Traduction_Concept_TypeApiConsumer Spartan_Traduction_Concept_TypeApiConsumer  , ISpartan_Traduction_LanguageApiConsumer Spartan_Traduction_LanguageApiConsumer , ISpartan_Traduction_Object_TypeApiConsumer Spartan_Traduction_Object_TypeApiConsumer , ISpartaneObjectApiConsumer SpartanObjectApiConsumer , ISpartan_Traduction_DetailApiConsumer Spartan_Traduction_DetailApiConsumer  , ISpartan_Traduction_Process_WorkflowApiConsumer Spartan_Traduction_Process_WorkflowApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_Traduction_ProcessApiConsumer = Spartan_Traduction_ProcessApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
            this._ISpartan_Traduction_Process_DataApiConsumer = Spartan_Traduction_Process_DataApiConsumer;
            this._ISpartan_Traduction_Concept_TypeApiConsumer = Spartan_Traduction_Concept_TypeApiConsumer;

            this._ISpartan_Traduction_LanguageApiConsumer = Spartan_Traduction_LanguageApiConsumer;
            this._ISpartan_Traduction_Object_TypeApiConsumer = Spartan_Traduction_Object_TypeApiConsumer;
            this._ISpartanObjectApiConsumer = SpartanObjectApiConsumer;
            this._ISpartan_Traduction_DetailApiConsumer = Spartan_Traduction_DetailApiConsumer;
            this._ISpartan_Traduction_Concept_TypeApiConsumer = Spartan_Traduction_Concept_TypeApiConsumer;

            this._ISpartan_Traduction_Process_WorkflowApiConsumer = Spartan_Traduction_Process_WorkflowApiConsumer;
            this._ISpartan_Traduction_Concept_TypeApiConsumer = Spartan_Traduction_Concept_TypeApiConsumer;


        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_Traduction_Process
        [ObjectAuth(ObjectId = (ModuleObjectId)110, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index(int ModuleId=0)
        {
			if (Session["AdvanceReportFilter"] != null)
            {
                Session["AdvanceReportFilter"] = null;
                Session["AdvanceSearch"] = null;
            }
			if (ModuleId == 0)
            {
                ModuleId = Convert.ToInt32(Session["CurrentModuleId"]);
                if (ModuleId == 0)
                {
                    Response.Redirect("~/");
                }
            }
            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 110, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_Format_PermissionsApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);

            var whereClause = " Spartan_Format_Permissions.Spartan_User_Role = " + SessionHelper.Role + " AND Spartan_Format_Permissions_Permission_Type = " + PermissionTypes.Consult + " AND Apply=1 ";
            var formatsPermisions=_ISpartan_Format_PermissionsApiConsumer.SelAll(false, whereClause, string.Empty);
            if (formatsPermisions != null && formatsPermisions.Resource != null)
            {
                var formats = string.Join(",", formatsPermisions.Resource.Select(f => f.Format).ToArray());
                var whereClauseFormat = "Object = 110 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);
                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats!= null)
                {
                    ViewBag.Spartan_Formats = Spartan_Formats.Resource.Spartan_Formats.Select(m => new SelectListItem
                    {
                        Text = m.Format_Name.ToString(),
                        Value = Convert.ToString(m.FormatId)
                    }).ToList();

                }
            }
            return View();
        }

        // GET: Frontal/Spartan_Traduction_Process/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)110, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 110, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varSpartan_Traduction_Process = new Spartan_Traduction_ProcessModel();
			
            ViewBag.ObjectId = "110";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionSpartan_Traduction_Process_Data = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 112, ModuleId);
            ViewBag.PermissionSpartan_Traduction_Process_Data = permissionSpartan_Traduction_Process_Data;
            var permissionSpartan_Traduction_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 111, ModuleId);
            ViewBag.PermissionSpartan_Traduction_Detail = permissionSpartan_Traduction_Detail;
            var permissionSpartan_Traduction_Process_Workflow = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 113, ModuleId);
            ViewBag.PermissionSpartan_Traduction_Process_Workflow = permissionSpartan_Traduction_Process_Workflow;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Traduction_ProcessApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_Traduction_ProcessData = _ISpartan_Traduction_ProcessApiConsumer.GetByKeyComplete(Id).Resource.Spartan_Traduction_Processs[0];
                if (Spartan_Traduction_ProcessData == null)
                    return HttpNotFound();

                varSpartan_Traduction_Process = new Spartan_Traduction_ProcessModel
                {
                    IdTraduction = (int)Spartan_Traduction_ProcessData.IdTraduction
                    ,LanguageT = Spartan_Traduction_ProcessData.LanguageT
                    ,LanguageTLanguageT =  (string)Spartan_Traduction_ProcessData.LanguageT_Spartan_Traduction_Language.LanguageT
                    ,Object_Type = Spartan_Traduction_ProcessData.Object_Type
                    ,Object_TypeObject_Type_Description =  (string)Spartan_Traduction_ProcessData.Object_Type_Spartan_Traduction_Object_Type.Object_Type_Description
                    ,ObjectT = Spartan_Traduction_ProcessData.ObjectT
                    ,ObjectTName =  (string)Spartan_Traduction_ProcessData.ObjectT_SpartanObject.Name

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Traduction_LanguageApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Traduction_Languages_LanguageT = _ISpartan_Traduction_LanguageApiConsumer.SelAll(true);
            if (Spartan_Traduction_Languages_LanguageT != null && Spartan_Traduction_Languages_LanguageT.Resource != null)
                ViewBag.Spartan_Traduction_Languages_LanguageT = Spartan_Traduction_Languages_LanguageT.Resource.OrderBy(m => m.LanguageT).Select(m => new SelectListItem
                {
                    Text = m.LanguageT.ToString(), Value = Convert.ToString(m.IdLanguage)
                }).ToList();
            _ISpartan_Traduction_Object_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Traduction_Object_Types_Object_Type = _ISpartan_Traduction_Object_TypeApiConsumer.SelAll(true);
            if (Spartan_Traduction_Object_Types_Object_Type != null && Spartan_Traduction_Object_Types_Object_Type.Resource != null)
                ViewBag.Spartan_Traduction_Object_Types_Object_Type = Spartan_Traduction_Object_Types_Object_Type.Resource.OrderBy(m => m.Object_Type_Description).Select(m => new SelectListItem
                {
                    Text = m.Object_Type_Description.ToString(), Value = Convert.ToString(m.IdType)
                }).ToList();
            _ISpartanObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            var SpartanObjects_ObjectT = _ISpartanObjectApiConsumer.SelAll(true);
            if (SpartanObjects_ObjectT != null && SpartanObjects_ObjectT.Resource != null)
                ViewBag.SpartanObjects_ObjectT = SpartanObjects_ObjectT.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Object_Id)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_Traduction_Process);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_Traduction_Process(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 110);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_Traduction_ProcessApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_Traduction_ProcessModel varSpartan_Traduction_Process= new Spartan_Traduction_ProcessModel();
            var permissionSpartan_Traduction_Process_Data = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35162, ModuleId);
            ViewBag.PermissionSpartan_Traduction_Process_Data = permissionSpartan_Traduction_Process_Data;
            var permissionSpartan_Traduction_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35167, ModuleId);
            ViewBag.PermissionSpartan_Traduction_Detail = permissionSpartan_Traduction_Detail;
            var permissionSpartan_Traduction_Process_Workflow = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35190, ModuleId);
            ViewBag.PermissionSpartan_Traduction_Process_Workflow = permissionSpartan_Traduction_Process_Workflow;


            if (id.ToString() != "0")
            {
                var Spartan_Traduction_ProcesssData = _ISpartan_Traduction_ProcessApiConsumer.ListaSelAll(0, 1000, "IdTraduction=" + id, "").Resource.Spartan_Traduction_Processs;
				
				if (Spartan_Traduction_ProcesssData != null && Spartan_Traduction_ProcesssData.Count > 0)
                {
					var Spartan_Traduction_ProcessData = Spartan_Traduction_ProcesssData.First();
					varSpartan_Traduction_Process= new Spartan_Traduction_ProcessModel
					{
						IdTraduction  = Spartan_Traduction_ProcessData.IdTraduction 
	                    ,LanguageT = Spartan_Traduction_ProcessData.LanguageT
                    ,LanguageTLanguageT =  (string)Spartan_Traduction_ProcessData.LanguageT_Spartan_Traduction_Language.LanguageT
                    ,Object_Type = Spartan_Traduction_ProcessData.Object_Type
                    ,Object_TypeObject_Type_Description =  (string)Spartan_Traduction_ProcessData.Object_Type_Spartan_Traduction_Object_Type.Object_Type_Description
                    ,ObjectT = Spartan_Traduction_ProcessData.ObjectT
                    ,ObjectTName =  (string)Spartan_Traduction_ProcessData.ObjectT_SpartanObject.Name

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Traduction_LanguageApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Traduction_Languages_LanguageT = _ISpartan_Traduction_LanguageApiConsumer.SelAll(true);
            if (Spartan_Traduction_Languages_LanguageT != null && Spartan_Traduction_Languages_LanguageT.Resource != null)
                ViewBag.Spartan_Traduction_Languages_LanguageT = Spartan_Traduction_Languages_LanguageT.Resource.OrderBy(m => m.LanguageT).Select(m => new SelectListItem
                {
                    Text = m.LanguageT.ToString(), Value = Convert.ToString(m.IdLanguage)
                }).ToList();
            _ISpartan_Traduction_Object_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Traduction_Object_Types_Object_Type = _ISpartan_Traduction_Object_TypeApiConsumer.SelAll(true);
            if (Spartan_Traduction_Object_Types_Object_Type != null && Spartan_Traduction_Object_Types_Object_Type.Resource != null)
                ViewBag.Spartan_Traduction_Object_Types_Object_Type = Spartan_Traduction_Object_Types_Object_Type.Resource.OrderBy(m => m.Object_Type_Description).Select(m => new SelectListItem
                {
                    Text = m.Object_Type_Description.ToString(), Value = Convert.ToString(m.IdType)
                }).ToList();
            _ISpartanObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            var SpartanObjects_ObjectT = _ISpartanObjectApiConsumer.SelAll(true);
            if (SpartanObjects_ObjectT != null && SpartanObjects_ObjectT.Resource != null)
                ViewBag.SpartanObjects_ObjectT = SpartanObjects_ObjectT.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Object_Id)
                }).ToList();


            return PartialView("AddSpartan_Traduction_Process", varSpartan_Traduction_Process);
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
        public ActionResult GetSpartan_Traduction_LanguageAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Traduction_LanguageApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Traduction_LanguageApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_Traduction_Object_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Traduction_Object_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Traduction_Object_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartanObjectAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartanObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartanObjectApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }




        [HttpPost]
        public JsonResult ClearAdvanceFilter()
        {
            Session["AdvanceSearch"] = null;
            return Json(new { result = Session["AdvanceSearch"] == null }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ShowAdvanceFilter(Spartan_Traduction_ProcessAdvanceSearchModel model, int idFilter = -1)
        {
            if (ModelState.IsValid)
            {
                Session["AdvanceSearch"] = model;
				if (idFilter != -1)
                {
                    Session["AdvanceReportFilter"] = GetAdvanceFilter(model);
                    return RedirectToAction("Index", "Report", new { id = idFilter });
                }
                return RedirectToAction("Index");
            }
            ViewBag.Filter = new List<SelectListItem>
            {
                new SelectListItem() {Text = Resources.Resources.BeginWith, Value = "1"},
                new SelectListItem() {Text = Resources.Resources.EndWith, Value = "2"},
                new SelectListItem() {Text = Resources.Resources.Contains, Value = "4"},
                new SelectListItem() {Text = Resources.Resources.Exact, Value = "3"},
            };
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Traduction_LanguageApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Traduction_Languages_LanguageT = _ISpartan_Traduction_LanguageApiConsumer.SelAll(true);
            if (Spartan_Traduction_Languages_LanguageT != null && Spartan_Traduction_Languages_LanguageT.Resource != null)
                ViewBag.Spartan_Traduction_Languages_LanguageT = Spartan_Traduction_Languages_LanguageT.Resource.OrderBy(m => m.LanguageT).Select(m => new SelectListItem
                {
                    Text = m.LanguageT.ToString(), Value = Convert.ToString(m.IdLanguage)
                }).ToList();
            _ISpartan_Traduction_Object_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Traduction_Object_Types_Object_Type = _ISpartan_Traduction_Object_TypeApiConsumer.SelAll(true);
            if (Spartan_Traduction_Object_Types_Object_Type != null && Spartan_Traduction_Object_Types_Object_Type.Resource != null)
                ViewBag.Spartan_Traduction_Object_Types_Object_Type = Spartan_Traduction_Object_Types_Object_Type.Resource.OrderBy(m => m.Object_Type_Description).Select(m => new SelectListItem
                {
                    Text = m.Object_Type_Description.ToString(), Value = Convert.ToString(m.IdType)
                }).ToList();
            _ISpartanObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            var SpartanObjects_ObjectT = _ISpartanObjectApiConsumer.SelAll(true);
            if (SpartanObjects_ObjectT != null && SpartanObjects_ObjectT.Resource != null)
                ViewBag.SpartanObjects_ObjectT = SpartanObjects_ObjectT.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Object_Id)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Traduction_LanguageApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Traduction_Languages_LanguageT = _ISpartan_Traduction_LanguageApiConsumer.SelAll(true);
            if (Spartan_Traduction_Languages_LanguageT != null && Spartan_Traduction_Languages_LanguageT.Resource != null)
                ViewBag.Spartan_Traduction_Languages_LanguageT = Spartan_Traduction_Languages_LanguageT.Resource.OrderBy(m => m.LanguageT).Select(m => new SelectListItem
                {
                    Text = m.LanguageT.ToString(), Value = Convert.ToString(m.IdLanguage)
                }).ToList();
            _ISpartan_Traduction_Object_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Traduction_Object_Types_Object_Type = _ISpartan_Traduction_Object_TypeApiConsumer.SelAll(true);
            if (Spartan_Traduction_Object_Types_Object_Type != null && Spartan_Traduction_Object_Types_Object_Type.Resource != null)
                ViewBag.Spartan_Traduction_Object_Types_Object_Type = Spartan_Traduction_Object_Types_Object_Type.Resource.OrderBy(m => m.Object_Type_Description).Select(m => new SelectListItem
                {
                    Text = m.Object_Type_Description.ToString(), Value = Convert.ToString(m.IdType)
                }).ToList();
            _ISpartanObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            var SpartanObjects_ObjectT = _ISpartanObjectApiConsumer.SelAll(true);
            if (SpartanObjects_ObjectT != null && SpartanObjects_ObjectT.Resource != null)
                ViewBag.SpartanObjects_ObjectT = SpartanObjects_ObjectT.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Object_Id)
                }).ToList();


            var previousFiltersObj = new Spartan_Traduction_ProcessAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Spartan_Traduction_ProcessAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Spartan_Traduction_ProcessAdvanceSearchModel());
            }

            ViewBag.Filter = new List<SelectListItem>
            {
                new SelectListItem() {Text = Resources.Resources.BeginWith, Value = "1"},
                new SelectListItem() {Text = Resources.Resources.EndWith, Value = "2"},
                new SelectListItem() {Text = Resources.Resources.Contains, Value = "4"},
                new SelectListItem() {Text = Resources.Resources.Exact, Value = "3"},

            };

            return View(previousFiltersObj);
        }

        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Traduction_ProcessPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_Traduction_ProcessApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Traduction_Processs == null)
                result.Spartan_Traduction_Processs = new List<Spartan_Traduction_Process>();

            return Json(new
            {
                data = result.Spartan_Traduction_Processs.Select(m => new Spartan_Traduction_ProcessGridModel
                    {
                    IdTraduction = m.IdTraduction
                        ,LanguageTLanguageT = (string)m.LanguageT_Spartan_Traduction_Language.LanguageT
                        ,Object_TypeObject_Type_Description = (string)m.Object_Type_Spartan_Traduction_Object_Type.Object_Type_Description
                        ,ObjectTName = (string)m.ObjectT_SpartanObject.Name

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_Traduction_Process from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_Traduction_Process Entity</returns>
        public ActionResult GetSpartan_Traduction_ProcessList(int sEcho, int iDisplayStart, int iDisplayLength, string where, string order)
        {
		
			where =HttpUtility.UrlEncode(where);
            int sortColumn = -1;
            string sortDirection = "asc";
            if (iDisplayLength == -1)
            {
                //length = TOTAL_ROWS;
                iDisplayLength = Int32.MaxValue;
            }
            // note: we only sort one column at a time
            if (Request.QueryString["iSortCol_0"] != null)
            {
                sortColumn = int.Parse(Request.QueryString["iSortCol_0"]);
            }
            if (Request.QueryString["sSortDir_0"] != null)
            {
                sortDirection = Request.QueryString["sSortDir_0"];
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_Traduction_ProcessApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_Traduction_ProcessPropertyMapper());
			if (!String.IsNullOrEmpty(where))
            {
                 configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            configuration.WhereClause = configuration.WhereClause.Replace("SpartanObject", "Spartan_Object");
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True" && Session["AdvanceSearch"]!=null)
            {
				if (Session["AdvanceSearch"].GetType() == typeof(Spartan_Traduction_ProcessAdvanceSearchModel))
                {
					var advanceFilter =
                    (Spartan_Traduction_ProcessAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Spartan_Traduction_ProcessPropertyMapper oSpartan_Traduction_ProcessPropertyMapper = new Spartan_Traduction_ProcessPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = oSpartan_Traduction_ProcessPropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISpartan_Traduction_ProcessApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Traduction_Processs == null)
                result.Spartan_Traduction_Processs = new List<Spartan_Traduction_Process>();

            return Json(new
            {
                aaData = result.Spartan_Traduction_Processs.Select(m => new Spartan_Traduction_ProcessGridModel
            {
                    IdTraduction = m.IdTraduction
                        ,LanguageTLanguageT = (string)m.LanguageT_Spartan_Traduction_Language.LanguageT
                        ,Object_TypeObject_Type_Description = (string)m.Object_Type_Spartan_Traduction_Object_Type.Object_Type_Description
                        ,ObjectTName = (string)m.ObjectT_SpartanObject.Name

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(Spartan_Traduction_ProcessAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromIdTraduction) || !string.IsNullOrEmpty(filter.ToIdTraduction))
            {
                if (!string.IsNullOrEmpty(filter.FromIdTraduction))
                    where += " AND Spartan_Traduction_Process.IdTraduction >= " + filter.FromIdTraduction;
                if (!string.IsNullOrEmpty(filter.ToIdTraduction))
                    where += " AND Spartan_Traduction_Process.IdTraduction <= " + filter.ToIdTraduction;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceLanguageT))
            {
                switch (filter.LanguageTFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Traduction_Language.LanguageT LIKE '" + filter.AdvanceLanguageT + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Traduction_Language.LanguageT LIKE '%" + filter.AdvanceLanguageT + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Traduction_Language.LanguageT = '" + filter.AdvanceLanguageT + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Traduction_Language.LanguageT LIKE '%" + filter.AdvanceLanguageT + "%'";
                        break;
                }
            }
            else if (filter.AdvanceLanguageTMultiple != null && filter.AdvanceLanguageTMultiple.Count() > 0)
            {
                var LanguageTIds = string.Join(",", filter.AdvanceLanguageTMultiple);

                where += " AND Spartan_Traduction_Process.LanguageT In (" + LanguageTIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceObject_Type))
            {
                switch (filter.Object_TypeFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Traduction_Object_Type.Object_Type_Description LIKE '" + filter.AdvanceObject_Type + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Traduction_Object_Type.Object_Type_Description LIKE '%" + filter.AdvanceObject_Type + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Traduction_Object_Type.Object_Type_Description = '" + filter.AdvanceObject_Type + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Traduction_Object_Type.Object_Type_Description LIKE '%" + filter.AdvanceObject_Type + "%'";
                        break;
                }
            }
            else if (filter.AdvanceObject_TypeMultiple != null && filter.AdvanceObject_TypeMultiple.Count() > 0)
            {
                var Object_TypeIds = string.Join(",", filter.AdvanceObject_TypeMultiple);

                where += " AND Spartan_Traduction_Process.Object_Type In (" + Object_TypeIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceObjectT))
            {
                switch (filter.ObjectTFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND SpartanObject.Name LIKE '" + filter.AdvanceObjectT + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND SpartanObject.Name LIKE '%" + filter.AdvanceObjectT + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND SpartanObject.Name = '" + filter.AdvanceObjectT + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND SpartanObject.Name LIKE '%" + filter.AdvanceObjectT + "%'";
                        break;
                }
            }
            else if (filter.AdvanceObjectTMultiple != null && filter.AdvanceObjectTMultiple.Count() > 0)
            {
                var ObjectTIds = string.Join(",", filter.AdvanceObjectTMultiple);

                where += " AND Spartan_Traduction_Process.ObjectT In (" + ObjectTIds + ")";
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

        public ActionResult GetSpartan_Traduction_Process_Data(int draw, int start, int length, string RelationId = "0", int object_id = 0, int process = 0)
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_Traduction_Process_DataGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_Traduction_Process_DataApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_Traduction_Process_Data.Spartan_Traduction_Process=" + RelationId;
            if ("int" == "string")
            {
                where = "Spartan_Traduction_Process_Data.Spartan_Traduction_Process='" + RelationId + "'";
            }
            var result = _ISpartan_Traduction_Process_DataApiConsumer.ListaSelAll(object_id, process).Resource;
            if (result.Spartan_Traduction_Process_Datas == null)
                result.Spartan_Traduction_Process_Datas = new List<Spartan_Traduction_Process_Data>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_Traduction_Process_Datas.Select(m => new Spartan_Traduction_Process_DataGridModel
                {
                    Clave = m.Clave
                        ,
                    Concept = m.Concept
                        ,
                    ConceptConcept_Description = (string)m.Concept_Spartan_Traduction_Concept_Type.Concept_Description
            ,
                    Name_of_Control = m.Name_of_Control
            ,
                    Original_Text = m.Original_Text
            ,
                    Translated_Text = m.Translated_Text

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_Traduction_Detail(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_Traduction_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_Traduction_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_Traduction_Detail.Spartan_Traduction_Process=" + RelationId;
            if("int" == "string")
            {
	           where = "Spartan_Traduction_Detail.Spartan_Traduction_Process='" + RelationId + "'";
            }
            var result = _ISpartan_Traduction_DetailApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Spartan_Traduction_Details == null)
                result.Spartan_Traduction_Details = new List<Spartan_Traduction_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_Traduction_Details.Select(m => new Spartan_Traduction_DetailGridModel
                {
                    IdTraductionDetail = m.IdTraductionDetail
                        ,Concept = m.Concept
                        ,ConceptConcept_Description = (string)m.Concept_Spartan_Traduction_Concept_Type.Concept_Description
			,IdConcept = m.IdConcept
			,Original_Text = m.Original_Text
			,Translated_Text = m.Translated_Text

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_Traduction_Process_Workflow(int draw, int start, int length, string RelationId = "0", int object_id = 0, int process = 0)
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_Traduction_Process_WorkflowGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_Traduction_Process_WorkflowApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_Traduction_Process_Workflow.Process=" + RelationId;
            if("int" == "string")
            {
	           where = "Spartan_Traduction_Process_Workflow.Process='" + RelationId + "'";
            }
            var result = _ISpartan_Traduction_Process_WorkflowApiConsumer.ListaSelAll(object_id, process).Resource;
            if (result.Spartan_Traduction_Process_Workflows == null)
                result.Spartan_Traduction_Process_Workflows = new List<Spartan_Traduction_Process_Workflow>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_Traduction_Process_Workflows.Select(m => new Spartan_Traduction_Process_WorkflowGridModel
                {
                    Clave = m.Clave
                        ,Concept = m.Concept
                        ,ConceptConcept_Description = (string)m.Concept_Spartan_Traduction_Concept_Type.Concept_Description
			,ID_of_Step = m.ID_of_Step
			,Original_Text = m.Original_Text
			,Translated_Text = m.Translated_Text

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_Traduction_ProcessModel varSpartan_Traduction_Process)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_Traduction_ProcessApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Spartan_Traduction_ProcessInfo = new Spartan_Traduction_Process
                    {
                        IdTraduction = varSpartan_Traduction_Process.IdTraduction
                        ,LanguageT = varSpartan_Traduction_Process.LanguageT
                        ,Object_Type = varSpartan_Traduction_Process.Object_Type
                        ,ObjectT = varSpartan_Traduction_Process.ObjectT

                    };

                    result = !IsNew ?
                        _ISpartan_Traduction_ProcessApiConsumer.Update(Spartan_Traduction_ProcessInfo, null, null).Resource.ToString() :
                         _ISpartan_Traduction_ProcessApiConsumer.Insert(Spartan_Traduction_ProcessInfo, null, null).Resource.ToString();
					Session["KeyValueInserted"] = result;
                    return Json(result, JsonRequestBehavior.AllowGet);
				//}
				//return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult PostSpartan_Traduction_Process_Data(List<Spartan_Traduction_Process_DataGridModelPost> Spartan_Traduction_Process_DataItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_Traduction_Process_Data(MasterId, referenceId, Spartan_Traduction_Process_DataItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_Traduction_Process_DataItems != null && Spartan_Traduction_Process_DataItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_Traduction_Process_DataApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_Traduction_Process_DataItem in Spartan_Traduction_Process_DataItems)
                    {

                        //Removal Request
                        if (Spartan_Traduction_Process_DataItem.Removed)
                        {
                            result = result && _ISpartan_Traduction_Process_DataApiConsumer.Delete(Spartan_Traduction_Process_DataItem.Clave, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Spartan_Traduction_Process_DataItem.Clave = 0;

                        var Spartan_Traduction_Process_DataData = new Spartan_Traduction_Process_Data
                        {
                            Spartan_Traduction_Process = MasterId
                            ,Clave = Spartan_Traduction_Process_DataItem.Clave
                            ,Concept = (Convert.ToInt32(Spartan_Traduction_Process_DataItem.Concept) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_Traduction_Process_DataItem.Concept))
                            ,Name_of_Control = Spartan_Traduction_Process_DataItem.Name_of_Control
                            ,Original_Text = Spartan_Traduction_Process_DataItem.Original_Text
                            ,Translated_Text = Spartan_Traduction_Process_DataItem.Translated_Text

                        };

                        var resultId = Spartan_Traduction_Process_DataItem.Clave > 0
                           ? _ISpartan_Traduction_Process_DataApiConsumer.Update(Spartan_Traduction_Process_DataData,null,null).Resource
                           : _ISpartan_Traduction_Process_DataApiConsumer.Insert(Spartan_Traduction_Process_DataData,null,null).Resource;

                        result = result && resultId != -1;
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_Traduction_Process_Data_Spartan_Traduction_Concept_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Traduction_Concept_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Traduction_Concept_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_Traduction_Detail(int MasterId, int referenceId, List<Spartan_Traduction_DetailGridModelPost> Spartan_Traduction_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_Traduction_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_Traduction_DetailData = _ISpartan_Traduction_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_Traduction_Detail.Spartan_Traduction_Process=" + referenceId,"").Resource;
                if (Spartan_Traduction_DetailData == null || Spartan_Traduction_DetailData.Spartan_Traduction_Details.Count == 0)
                    return true;

                var result = true;

                Spartan_Traduction_DetailGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varSpartan_Traduction_Detail in Spartan_Traduction_DetailData.Spartan_Traduction_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Spartan_Traduction_Detail Spartan_Traduction_Detail1 = varSpartan_Traduction_Detail;

                    if (Spartan_Traduction_DetailItems != null && Spartan_Traduction_DetailItems.Any(m => m.IdTraductionDetail == Spartan_Traduction_Detail1.IdTraductionDetail))
                    {
                        modelDataToChange = Spartan_Traduction_DetailItems.FirstOrDefault(m => m.IdTraductionDetail == Spartan_Traduction_Detail1.IdTraductionDetail);
                    }
                    //Chaning Id Value
                    varSpartan_Traduction_Detail.Spartan_Traduction_Process = MasterId;
                    var insertId = _ISpartan_Traduction_DetailApiConsumer.Insert(varSpartan_Traduction_Detail,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.IdTraductionDetail = insertId;

                    result = insertId > 0;
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult PostSpartan_Traduction_Detail(List<Spartan_Traduction_DetailGridModelPost> Spartan_Traduction_DetailItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_Traduction_Detail(MasterId, referenceId, Spartan_Traduction_DetailItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_Traduction_DetailItems != null && Spartan_Traduction_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_Traduction_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_Traduction_DetailItem in Spartan_Traduction_DetailItems)
                    {

                        //Removal Request
                        if (Spartan_Traduction_DetailItem.Removed)
                        {
                            result = result && _ISpartan_Traduction_DetailApiConsumer.Delete(Spartan_Traduction_DetailItem.IdTraductionDetail, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Spartan_Traduction_DetailItem.IdTraductionDetail = 0;

                        var Spartan_Traduction_DetailData = new Spartan_Traduction_Detail
                        {
                            Spartan_Traduction_Process = MasterId
                            ,IdTraductionDetail = Spartan_Traduction_DetailItem.IdTraductionDetail
                            ,Concept = (Convert.ToInt32(Spartan_Traduction_DetailItem.Concept) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_Traduction_DetailItem.Concept))
                            ,IdConcept = Spartan_Traduction_DetailItem.IdConcept
                            ,Original_Text = Spartan_Traduction_DetailItem.Original_Text
                            ,Translated_Text = Spartan_Traduction_DetailItem.Translated_Text

                        };

                        var resultId = Spartan_Traduction_DetailItem.IdTraductionDetail > 0
                           ? _ISpartan_Traduction_DetailApiConsumer.Update(Spartan_Traduction_DetailData,null,null).Resource
                           : _ISpartan_Traduction_DetailApiConsumer.Insert(Spartan_Traduction_DetailData,null,null).Resource;

                        result = result && resultId != -1;
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_Traduction_Detail_Spartan_Traduction_Concept_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Traduction_Concept_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Traduction_Concept_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        /*
        [NonAction]
        public bool CopySpartan_Traduction_Process_Workflow(int MasterId, int referenceId, List<Spartan_Traduction_Process_WorkflowGridModelPost> Spartan_Traduction_Process_WorkflowItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_Traduction_Process_WorkflowApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_Traduction_Process_WorkflowData = _ISpartan_Traduction_Process_WorkflowApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_Traduction_Process_Workflow.Process=" + referenceId,"").Resource;
                if (Spartan_Traduction_Process_WorkflowData == null || Spartan_Traduction_Process_WorkflowData.Spartan_Traduction_Process_Workflows.Count == 0)
                    return true;

                var result = true;

                Spartan_Traduction_Process_WorkflowGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varSpartan_Traduction_Process_Workflow in Spartan_Traduction_Process_WorkflowData.Spartan_Traduction_Process_Workflows)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Spartan_Traduction_Process_Workflow Spartan_Traduction_Process_Workflow1 = varSpartan_Traduction_Process_Workflow;

                    if (Spartan_Traduction_Process_WorkflowItems != null && Spartan_Traduction_Process_WorkflowItems.Any(m => m.Clave == Spartan_Traduction_Process_Workflow1.Clave))
                    {
                        modelDataToChange = Spartan_Traduction_Process_WorkflowItems.FirstOrDefault(m => m.Clave == Spartan_Traduction_Process_Workflow1.Clave);
                    }
                    //Chaning Id Value
                    varSpartan_Traduction_Process_Workflow.Process = MasterId;
                    var insertId = _ISpartan_Traduction_Process_WorkflowApiConsumer.Insert(varSpartan_Traduction_Process_Workflow,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.Clave = insertId;

                    result = insertId > 0;
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        */
        [HttpPost]
        public ActionResult PostSpartan_Traduction_Process_Workflow(List<Spartan_Traduction_Process_WorkflowGridModelPost> Spartan_Traduction_Process_WorkflowItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_Traduction_Process_Workflow(MasterId, referenceId, Spartan_Traduction_Process_WorkflowItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_Traduction_Process_WorkflowItems != null && Spartan_Traduction_Process_WorkflowItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_Traduction_Process_WorkflowApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_Traduction_Process_WorkflowItem in Spartan_Traduction_Process_WorkflowItems)
                    {

                        //Removal Request
                        if (Spartan_Traduction_Process_WorkflowItem.Removed)
                        {
                            result = result && _ISpartan_Traduction_Process_WorkflowApiConsumer.Delete(Spartan_Traduction_Process_WorkflowItem.Clave, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Spartan_Traduction_Process_WorkflowItem.Clave = 0;

                        var Spartan_Traduction_Process_WorkflowData = new Spartan_Traduction_Process_Workflow
                        {
                            Process = MasterId
                            ,Clave = Spartan_Traduction_Process_WorkflowItem.Clave
                            ,Concept = (Convert.ToInt32(Spartan_Traduction_Process_WorkflowItem.Concept) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_Traduction_Process_WorkflowItem.Concept))
                            ,ID_of_Step = Spartan_Traduction_Process_WorkflowItem.ID_of_Step
                            ,Original_Text = Spartan_Traduction_Process_WorkflowItem.Original_Text
                            ,Translated_Text = Spartan_Traduction_Process_WorkflowItem.Translated_Text

                        };

                        var resultId = Spartan_Traduction_Process_WorkflowItem.Clave > 0
                           ? _ISpartan_Traduction_Process_WorkflowApiConsumer.Update(Spartan_Traduction_Process_WorkflowData,null,null).Resource
                           : _ISpartan_Traduction_Process_WorkflowApiConsumer.Insert(Spartan_Traduction_Process_WorkflowData,null,null).Resource;

                        result = result && resultId != -1;
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_Traduction_Process_Workflow_Spartan_Traduction_Concept_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Traduction_Concept_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Traduction_Concept_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Spartan_Traduction_Process script
        /// </summary>
        /// <param name="oSpartan_Traduction_ProcessElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Spartan_Traduction_ProcessModuleAttributeList)
        {
            for (int i = 0; i < Spartan_Traduction_ProcessModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_Traduction_ProcessModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_Traduction_ProcessModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_Traduction_ProcessModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_Traduction_ProcessModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_Traduction_ProcessModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_Traduction_ProcessModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Spartan_Traduction_ProcessModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Spartan_Traduction_ProcessModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Spartan_Traduction_ProcessModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Spartan_Traduction_ProcessModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Spartan_Traduction_ProcessModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strSpartan_Traduction_ProcessScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Traduction_Process.js")))
            {
                strSpartan_Traduction_ProcessScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_Traduction_Process element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_Traduction_ProcessModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_Traduction_ProcessScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_Traduction_ProcessScript.Substring(indexOfArray, strSpartan_Traduction_ProcessScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_Traduction_ProcessModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_Traduction_ProcessModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_Traduction_ProcessScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strSpartan_Traduction_ProcessScript.Substring(indexOfArrayHistory, strSpartan_Traduction_ProcessScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strSpartan_Traduction_ProcessScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_Traduction_ProcessScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_Traduction_ProcessScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Spartan_Traduction_ProcessModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Spartan_Traduction_ProcessModuleAttributeList.ChildModuleAttributeList)
                {
				if (item!= null && item.elements != null  && item.elements.Count>0)
                    ResponseChild += "\r\n  \n\r function set" + item.table + "Validation() { " +
                                    " \r\n var inpuElementChildArray =" + jsSerialize.Serialize(item.elements) + ";" +
                                    "  \r\n setInputEntityAttributes(inpuElementChildArray, \".\", 0);" +
                                    "  \r\n setDynamicRenderElement(); \n\r } ";

                }
            }
            finalResponse = finalResponse.Substring(0, finalResponse.IndexOf("});") + 4) +  "\n\r";
            finalResponse += ResponseChild;
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_Traduction_Process.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_Traduction_Process.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Traduction_Process.js")))
                {
                    strCustomScript = r.ReadToEnd();
                
                }

                int indexOfArray = strCustomScript.IndexOf("inpuElementArray");
                string splittedString = strCustomScript.Substring(indexOfArray, strCustomScript.Length - indexOfArray);                
                int indexOfMainElement = splittedString.IndexOf('[');                
                int endIndexOfMainElement = splittedString.IndexOf(']') + 1;                
                string mainJsonArray = splittedString.Substring(indexOfMainElement, endIndexOfMainElement - indexOfMainElement);

                int indexOfChildArray = strCustomScript.IndexOf("function set");
                string childJsonArray = "[";
                if (indexOfChildArray != -1)
                {
                    string splittedChildString = strCustomScript.Substring(indexOfChildArray, strCustomScript.Length - indexOfChildArray);

                    var funcionsValidations = splittedChildString.Split(new string[] { "function" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var str in funcionsValidations)
                    {
                        var tabla = str.Substring(0, str.IndexOf('('));
                        tabla = tabla.Trim().Replace("set", string.Empty).Replace("Validation", string.Empty);
                        childJsonArray += "{ \"table\": \"" + tabla + "\", \"elements\":";
                        int indexOfChildElement = str.IndexOf('[');
                        int endIndexOfChildElement = str.IndexOf(']') + 1;
                        childJsonArray += str.Substring(indexOfChildElement, endIndexOfChildElement - indexOfChildElement) + "},";
                    }
                }
                childJsonArray = childJsonArray.TrimEnd(',') + "]";
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
        public ActionResult Spartan_Traduction_ProcessPropertyBag()
        {
            return PartialView("Spartan_Traduction_ProcessPropertyBag", "Spartan_Traduction_Process");
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

        [HttpGet]
        public ActionResult AddSpartan_Traduction_Process_Data(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_Traduction_Process_Data/AddSpartan_Traduction_Process_Data");
        }

        [HttpGet]
        public ActionResult AddSpartan_Traduction_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_Traduction_Detail/AddSpartan_Traduction_Detail");
        }

        [HttpGet]
        public ActionResult AddSpartan_Traduction_Process_Workflow(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_Traduction_Process_Workflow/AddSpartan_Traduction_Process_Workflow");
        }

        [HttpGet]
        public ActionResult Regenerate(int object_id, int languageId)
        {
            CultureHelper.ProcessResources(object_id, languageId);
            if (object_id == 2 || object_id ==8)
                MenuHelper.GetLatestMenu();
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        #endregion "Controller Methods"

        #region "Custom methods"
		
		[HttpGet]
        public FileStreamResult PrintFormats(int idFormat, string RecordId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _IGeneratePDFApiConsumer.SetAuthHeader(_tokenManager.Token);
            var bytePdf= _IGeneratePDFApiConsumer.GeneratePDF(idFormat, RecordId);

            MemoryStream ms = new MemoryStream();
            ms.Write(bytePdf.Resource, 0, bytePdf.Resource.Length);
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Formatos.pdf");
            Response.Buffer = true;
            Response.Clear();
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.End();

            return new FileStreamResult(Response.OutputStream, "application/pdf");
        }

        [HttpGet]
        public void Export(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return;

            _ISpartan_Traduction_ProcessApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_Traduction_ProcessPropertyMapper());
			
            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True")
            {
                var advanceFilter =
                    (Spartan_Traduction_ProcessAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Traduction_ProcessApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Traduction_Processs == null)
                result.Spartan_Traduction_Processs = new List<Spartan_Traduction_Process>();

            var data = result.Spartan_Traduction_Processs.Select(m => new Spartan_Traduction_ProcessGridModel
            {
                IdTraduction = m.IdTraduction
                        ,LanguageTLanguageT = (string)m.LanguageT_Spartan_Traduction_Language.LanguageT
                        ,Object_TypeObject_Type_Description = (string)m.Object_Type_Spartan_Traduction_Object_Type.Object_Type_Description
                        ,ObjectTName = (string)m.ObjectT_SpartanObject.Name

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_Traduction_ProcessList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_Traduction_ProcessList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "Spartan_Traduction_ProcessList_" + DateTime.Now.ToString());
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

            _ISpartan_Traduction_ProcessApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_Traduction_ProcessPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Traduction_ProcessApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Traduction_Processs == null)
                result.Spartan_Traduction_Processs = new List<Spartan_Traduction_Process>();

            var data = result.Spartan_Traduction_Processs.Select(m => new Spartan_Traduction_ProcessGridModel
            {
                IdTraduction = m.IdTraduction
                        ,LanguageTLanguageT = (string)m.LanguageT_Spartan_Traduction_Language.LanguageT
                        ,Object_TypeObject_Type_Description = (string)m.Object_Type_Spartan_Traduction_Object_Type.Object_Type_Description
                        ,ObjectTName = (string)m.ObjectT_SpartanObject.Name

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
