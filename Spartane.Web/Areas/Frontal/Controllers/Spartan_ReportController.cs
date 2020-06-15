using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_Report;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Spartan_Object;
using Spartane.Core.Domain.Spartan_Report_Presentation_Type;
using Spartane.Core.Domain.Spartan_Report_Presentation_View;
using Spartane.Core.Domain.Spartan_Report_Status;
using Spartane.Core.Domain.Spartan_Report_Fields_Detail;
using Spartane.Core.Domain.Spartan_Report_Function;
using Spartane.Core.Domain.Spartan_Report_Format;
using Spartane.Core.Domain.Spartan_Report_Order_Type;
using Spartane.Core.Domain.Spartan_Report_Field_Type;
using Spartane.Core.Domain.Spartan_Metadata;

using Spartane.Core.Domain.Spartan_Report_Filter;
using Spartane.Core.Domain.Spartan_Metadata;


using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_Report;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Object;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Presentation_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Presentation_View;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Fields_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Function;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Order_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Field_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;

using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Filter;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;


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
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Permissions;
using Spartane.Web.Areas.WebApiConsumer.SpartaneQuery;
using Newtonsoft.Json.Linq;
using Spartane.Core.Domain.Spartan_Report_Advance_Filter;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Advance_Filter;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Spartan_ReportController : Controller
    {
        #region "variable declaration"

        private ISpartan_ReportService service = null;
        private ISpartan_ReportApiConsumer _ISpartan_ReportApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private ISpartan_ObjectApiConsumer _ISpartan_ObjectApiConsumer;
        private ISpartan_Report_Presentation_TypeApiConsumer _ISpartan_Report_Presentation_TypeApiConsumer;
        private ISpartan_Report_Presentation_ViewApiConsumer _ISpartan_Report_Presentation_ViewApiConsumer;
        private ISpartan_Report_StatusApiConsumer _ISpartan_Report_StatusApiConsumer;
        private ISpartan_Report_Fields_DetailApiConsumer _ISpartan_Report_Fields_DetailApiConsumer;
        private ISpartan_Report_FunctionApiConsumer _ISpartan_Report_FunctionApiConsumer;
        private ISpartan_Report_FormatApiConsumer _ISpartan_Report_FormatApiConsumer;
        private ISpartan_Report_Order_TypeApiConsumer _ISpartan_Report_Order_TypeApiConsumer;
        private ISpartan_Report_Field_TypeApiConsumer _ISpartan_Report_Field_TypeApiConsumer;
        private ISpartan_MetadataApiConsumer _ISpartan_MetadataApiConsumer;

        private ISpartan_Report_FilterApiConsumer _ISpartan_Report_FilterApiConsumer;
        private ISpartan_Report_Advance_FilterApiConsumer _ISpartan_Report_Advance_FilterApiConsumer;

        private ISpartan_Report_PermissionsApiConsumer _ISpartan_Report_PermissionsApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;
        private IGeneratePDFApiConsumer _IGeneratePDFApiConsumer;
        private ISpartan_FormatApiConsumer _ISpartan_FormatApiConsumer;
        private ISpartan_Format_PermissionsApiConsumer _ISpartan_Format_PermissionsApiConsumer;
        private ISpartan_MetadataApiConsumer _ISpartan_Metadata;
        private ISpartaneQueryApiConsumer _ISpartanQueryApiConsumer;

        #endregion "variable declaration"

        #region "Constructor Declaration"


        public Spartan_ReportController(ISpartan_ReportService service, ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_ReportApiConsumer Spartan_ReportApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_UserApiConsumer Spartan_UserApiConsumer, ISpartan_ObjectApiConsumer Spartan_ObjectApiConsumer, ISpartan_Report_Presentation_TypeApiConsumer Spartan_Report_Presentation_TypeApiConsumer, ISpartan_Report_Presentation_ViewApiConsumer Spartan_Report_Presentation_ViewApiConsumer, ISpartan_Report_StatusApiConsumer Spartan_Report_StatusApiConsumer, ISpartan_Report_Fields_DetailApiConsumer Spartan_Report_Fields_DetailApiConsumer, ISpartan_Report_FunctionApiConsumer Spartan_Report_FunctionApiConsumer, ISpartan_Report_FormatApiConsumer Spartan_Report_FormatApiConsumer, ISpartan_Report_Order_TypeApiConsumer Spartan_Report_Order_TypeApiConsumer, ISpartan_Report_Field_TypeApiConsumer Spartan_Report_Field_TypeApiConsumer, ISpartan_MetadataApiConsumer Spartan_MetadataApiConsumer, ISpartan_Report_FilterApiConsumer Spartan_Report_FilterApiConsumer, ISpartan_Report_PermissionsApiConsumer Spartan_Report_PermissionsApiConsumer, ISpartan_MetadataApiConsumer Spartan_Metadata, ISpartaneQueryApiConsumer SpartanQueryApiConsumer, ISpartan_Report_Advance_FilterApiConsumer Spartan_Report_Advance_FilterApiConsumer)
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_ReportApiConsumer = Spartan_ReportApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._ISpartan_ObjectApiConsumer = Spartan_ObjectApiConsumer;
            this._ISpartan_Report_Presentation_TypeApiConsumer = Spartan_Report_Presentation_TypeApiConsumer;
            this._ISpartan_Report_Presentation_ViewApiConsumer = Spartan_Report_Presentation_ViewApiConsumer;
            this._ISpartan_Report_StatusApiConsumer = Spartan_Report_StatusApiConsumer;
            this._ISpartan_Report_Fields_DetailApiConsumer = Spartan_Report_Fields_DetailApiConsumer;
            this._ISpartan_Report_FunctionApiConsumer = Spartan_Report_FunctionApiConsumer;
            this._ISpartan_Report_FormatApiConsumer = Spartan_Report_FormatApiConsumer;
            this._ISpartan_Report_Order_TypeApiConsumer = Spartan_Report_Order_TypeApiConsumer;
            this._ISpartan_Report_Field_TypeApiConsumer = Spartan_Report_Field_TypeApiConsumer;
            this._ISpartan_MetadataApiConsumer = Spartan_MetadataApiConsumer;

            this._ISpartan_Report_FilterApiConsumer = Spartan_Report_FilterApiConsumer;
            this._ISpartan_MetadataApiConsumer = Spartan_MetadataApiConsumer;

            this._ISpartan_Report_PermissionsApiConsumer = Spartan_Report_PermissionsApiConsumer;
            this._ISpartan_Metadata = Spartan_Metadata;
            this._ISpartanQueryApiConsumer = SpartanQueryApiConsumer;

            this._ISpartan_Report_Advance_FilterApiConsumer = Spartan_Report_Advance_FilterApiConsumer;
        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_Report
        [ObjectAuth(ObjectId = (ModuleObjectId)31953, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31953, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            //_ISpartan_Format_PermissionsApiConsumer.SetAuthHeader(_tokenManager.Token);
            //_ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);

            //var whereClause = " Spartan_Format_Permissions.Spartan_User_Role = " + SessionHelper.Role + " AND Spartan_Format_Permissions_Permission_Type = " + PermissionTypes.Consult + " AND Apply=1 ";
            //var formatsPermisions=_ISpartan_Format_PermissionsApiConsumer.SelAll(false, whereClause, string.Empty);
            //if (formatsPermisions != null && formatsPermisions.Resource != null)
            //{
            //    var formats = string.Join(",", formatsPermisions.Resource.Select(f => f.Format).ToArray());
            //    var whereClauseFormat = "Object = 31953 AND FormatId in (" + formats + ")";
            //    var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);
            //    if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats!= null)
            //    {
            //        ViewBag.Spartan_Formats = Spartan_Formats.Resource.Spartan_Formats.Select(m => new SelectListItem
            //        {
            //            Text = m.Format_Name.ToString(),
            //            Value = Convert.ToString(m.FormatId)
            //        }).ToList();

            //    }
            //}
            return View();
        }

        // GET: Frontal/Spartan_Report/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)31953, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31953, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varSpartan_Report = new Spartan_ReportModel();
			
            ViewBag.ObjectId = "31953";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionSpartan_Report_Fields_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 34553, ModuleId);
            ViewBag.PermissionSpartan_Report_Fields_Detail = permissionSpartan_Report_Fields_Detail;
            var permissionSpartan_Report_Filter = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 34558, ModuleId);
            ViewBag.PermissionSpartan_Report_Filter = permissionSpartan_Report_Filter;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_ReportData = _ISpartan_ReportApiConsumer.GetByKeyComplete(Id).Resource.Spartan_Reports[0];
                if (Spartan_ReportData == null)
                    return HttpNotFound();

                varSpartan_Report = new Spartan_ReportModel
                {
                    ReportId = (int)Spartan_ReportData.ReportId
                    ,Report_Name = Spartan_ReportData.Report_Name
                    ,Registration_Date = (Spartan_ReportData.Registration_Date == null ? string.Empty : Convert.ToDateTime(Spartan_ReportData.Registration_Date).ToString(ConfigurationProperty.DateFormat))
                    ,Registration_Hour = Spartan_ReportData.Registration_Hour
                    ,Registration_User = Spartan_ReportData.Registration_User
                    ,Registration_UserName =  Spartan_ReportData.User_Spartan_Report_User.Name
                    ,Object = Spartan_ReportData.Object
                    ,ObjectName =  (string)Spartan_ReportData.Spartan_Object_Spartan_Report_Object.Name
                    ,Presentation_Type = Spartan_ReportData.Presentation_Type
                    ,Presentation_TypeDescription =  (string)Spartan_ReportData.Presentation_Type_Spartan_Report_Presentation_Type.Description
                    ,Presentation_View = Spartan_ReportData.Presentation_View
                    ,Presentation_ViewDescription =  (string)Spartan_ReportData.Presentation_View_Spartan_Report_Presentation_View.Description
                    ,Status = Spartan_ReportData.Status
                    ,StatusDescription =  (string)Spartan_ReportData.Status_Spartan_Report_Status.Description
                    ,Query = Spartan_ReportData.Query
                    ,Header = Spartan_ReportData.Header
                    ,Footer = Spartan_ReportData.Footer
                    ,
                    TotalColumns = Spartan_ReportData.TotalColumns
                    ,
                    TotalRows = Spartan_ReportData.TotalRows
                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Registration_User = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Registration_User != null && Spartan_Users_Registration_User.Resource != null)
                ViewBag.Spartan_Users_Registration_User = Spartan_Users_Registration_User.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ISpartan_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Objects_Object = _ISpartan_ObjectApiConsumer.SelAll(true);
            if (Spartan_Objects_Object != null && Spartan_Objects_Object.Resource != null)
                ViewBag.Spartan_Objects_Object = Spartan_Objects_Object.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Object_Id)
                }).ToList();
            _ISpartan_Report_Presentation_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Types_Presentation_Type = _ISpartan_Report_Presentation_TypeApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Types_Presentation_Type != null && Spartan_Report_Presentation_Types_Presentation_Type.Resource != null)
                ViewBag.Spartan_Report_Presentation_Types_Presentation_Type = Spartan_Report_Presentation_Types_Presentation_Type.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationTypeId)
                }).ToList();
            _ISpartan_Report_Presentation_ViewApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Views_Presentation_View = _ISpartan_Report_Presentation_ViewApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Views_Presentation_View != null && Spartan_Report_Presentation_Views_Presentation_View.Resource != null)
                ViewBag.Spartan_Report_Presentation_Views_Presentation_View = Spartan_Report_Presentation_Views_Presentation_View.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationViewId)
                }).ToList();
            _ISpartan_Report_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Statuss_Status = _ISpartan_Report_StatusApiConsumer.SelAll(true);
            if (Spartan_Report_Statuss_Status != null && Spartan_Report_Statuss_Status.Resource != null)
                ViewBag.Spartan_Report_Statuss_Status = Spartan_Report_Statuss_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.StatusId)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_Report);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_Report(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31953);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_ReportModel varSpartan_Report= new Spartan_ReportModel();
            var permissionSpartan_Report_Fields_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 34553, ModuleId);
            ViewBag.PermissionSpartan_Report_Fields_Detail = permissionSpartan_Report_Fields_Detail;
            var permissionSpartan_Report_Filter = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 34558, ModuleId);
            ViewBag.PermissionSpartan_Report_Filter = permissionSpartan_Report_Filter;


            if (id.ToString() != "0")
            {
                var Spartan_ReportsData = _ISpartan_ReportApiConsumer.ListaSelAll(0, 1000, "ReportId=" + id, "").Resource.Spartan_Reports;
				
				if (Spartan_ReportsData != null && Spartan_ReportsData.Count > 0)
                {
					var Spartan_ReportData = Spartan_ReportsData.First();
					varSpartan_Report= new Spartan_ReportModel
					{
						ReportId  = Spartan_ReportData.ReportId 
	                    ,Report_Name = Spartan_ReportData.Report_Name
                    ,Registration_Date = (Spartan_ReportData.Registration_Date == null ? string.Empty : Convert.ToDateTime(Spartan_ReportData.Registration_Date).ToString(ConfigurationProperty.DateFormat))
                    ,Registration_Hour = Spartan_ReportData.Registration_Hour
                    ,Registration_User = Spartan_ReportData.Registration_User
                    ,Registration_UserName =  Spartan_ReportData.User_Spartan_Report_User.Name
                    ,Object = Spartan_ReportData.Object
                    ,ObjectName =  (string)Spartan_ReportData.Spartan_Object_Spartan_Report_Object.Name
                    ,Presentation_Type = Spartan_ReportData.Presentation_Type
                    ,Presentation_TypeDescription =  (string)Spartan_ReportData.Presentation_Type_Spartan_Report_Presentation_Type.Description
                    ,Presentation_View = Spartan_ReportData.Presentation_View
                    ,Presentation_ViewDescription =  (string)Spartan_ReportData.Presentation_View_Spartan_Report_Presentation_View.Description
                    ,Status = Spartan_ReportData.Status
                    ,StatusDescription =  (string)Spartan_ReportData.Status_Spartan_Report_Status.Description
                    ,Query = Spartan_ReportData.Query
                    ,Header = Spartan_ReportData.Header
                    ,Footer = Spartan_ReportData.Footer

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Registration_User = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Registration_User != null && Spartan_Users_Registration_User.Resource != null)
                ViewBag.Spartan_Users_Registration_User = Spartan_Users_Registration_User.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ISpartan_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Objects_Object = _ISpartan_ObjectApiConsumer.SelAll(true);
            if (Spartan_Objects_Object != null && Spartan_Objects_Object.Resource != null)
                ViewBag.Spartan_Objects_Object = Spartan_Objects_Object.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Object_Id)
                }).ToList();
            _ISpartan_Report_Presentation_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Types_Presentation_Type = _ISpartan_Report_Presentation_TypeApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Types_Presentation_Type != null && Spartan_Report_Presentation_Types_Presentation_Type.Resource != null)
                ViewBag.Spartan_Report_Presentation_Types_Presentation_Type = Spartan_Report_Presentation_Types_Presentation_Type.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationTypeId)
                }).ToList();
            _ISpartan_Report_Presentation_ViewApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Views_Presentation_View = _ISpartan_Report_Presentation_ViewApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Views_Presentation_View != null && Spartan_Report_Presentation_Views_Presentation_View.Resource != null)
                ViewBag.Spartan_Report_Presentation_Views_Presentation_View = Spartan_Report_Presentation_Views_Presentation_View.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationViewId)
                }).ToList();
            _ISpartan_Report_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Statuss_Status = _ISpartan_Report_StatusApiConsumer.SelAll(true);
            if (Spartan_Report_Statuss_Status != null && Spartan_Report_Statuss_Status.Resource != null)
                ViewBag.Spartan_Report_Statuss_Status = Spartan_Report_Statuss_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.StatusId)
                }).ToList();


            return PartialView("AddSpartan_Report", varSpartan_Report);
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
        public ActionResult GetSpartan_ObjectAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_ObjectApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_Report_Presentation_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_Presentation_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Report_Presentation_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_Report_Presentation_ViewAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_Presentation_ViewApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Report_Presentation_ViewApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_Report_StatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Report_StatusApiConsumer.SelAll(false).Resource;
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
        public ActionResult ShowAdvanceFilter(Spartan_ReportAdvanceSearchModel model, int idFilter = -1)
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

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Registration_User = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Registration_User != null && Spartan_Users_Registration_User.Resource != null)
                ViewBag.Spartan_Users_Registration_User = Spartan_Users_Registration_User.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ISpartan_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Objects_Object = _ISpartan_ObjectApiConsumer.SelAll(true);
            if (Spartan_Objects_Object != null && Spartan_Objects_Object.Resource != null)
                ViewBag.Spartan_Objects_Object = Spartan_Objects_Object.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Object_Id)
                }).ToList();
            _ISpartan_Report_Presentation_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Types_Presentation_Type = _ISpartan_Report_Presentation_TypeApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Types_Presentation_Type != null && Spartan_Report_Presentation_Types_Presentation_Type.Resource != null)
                ViewBag.Spartan_Report_Presentation_Types_Presentation_Type = Spartan_Report_Presentation_Types_Presentation_Type.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationTypeId)
                }).ToList();
            _ISpartan_Report_Presentation_ViewApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Views_Presentation_View = _ISpartan_Report_Presentation_ViewApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Views_Presentation_View != null && Spartan_Report_Presentation_Views_Presentation_View.Resource != null)
                ViewBag.Spartan_Report_Presentation_Views_Presentation_View = Spartan_Report_Presentation_Views_Presentation_View.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationViewId)
                }).ToList();
            _ISpartan_Report_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Statuss_Status = _ISpartan_Report_StatusApiConsumer.SelAll(true);
            if (Spartan_Report_Statuss_Status != null && Spartan_Report_Statuss_Status.Resource != null)
                ViewBag.Spartan_Report_Statuss_Status = Spartan_Report_Statuss_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.StatusId)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Registration_User = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Registration_User != null && Spartan_Users_Registration_User.Resource != null)
                ViewBag.Spartan_Users_Registration_User = Spartan_Users_Registration_User.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ISpartan_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Objects_Object = _ISpartan_ObjectApiConsumer.SelAll(true);
            if (Spartan_Objects_Object != null && Spartan_Objects_Object.Resource != null)
                ViewBag.Spartan_Objects_Object = Spartan_Objects_Object.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Object_Id)
                }).ToList();
            _ISpartan_Report_Presentation_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Types_Presentation_Type = _ISpartan_Report_Presentation_TypeApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Types_Presentation_Type != null && Spartan_Report_Presentation_Types_Presentation_Type.Resource != null)
                ViewBag.Spartan_Report_Presentation_Types_Presentation_Type = Spartan_Report_Presentation_Types_Presentation_Type.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationTypeId)
                }).ToList();
            _ISpartan_Report_Presentation_ViewApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Presentation_Views_Presentation_View = _ISpartan_Report_Presentation_ViewApiConsumer.SelAll(true);
            if (Spartan_Report_Presentation_Views_Presentation_View != null && Spartan_Report_Presentation_Views_Presentation_View.Resource != null)
                ViewBag.Spartan_Report_Presentation_Views_Presentation_View = Spartan_Report_Presentation_Views_Presentation_View.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationViewId)
                }).ToList();
            _ISpartan_Report_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Statuss_Status = _ISpartan_Report_StatusApiConsumer.SelAll(true);
            if (Spartan_Report_Statuss_Status != null && Spartan_Report_Statuss_Status.Resource != null)
                ViewBag.Spartan_Report_Statuss_Status = Spartan_Report_Statuss_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.StatusId)
                }).ToList();


            var previousFiltersObj = new Spartan_ReportAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Spartan_ReportAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Spartan_ReportAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_ReportPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_ReportApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Reports == null)
                result.Spartan_Reports = new List<Spartan_Report>();

            return Json(new
            {
                data = result.Spartan_Reports.Select(m => new Spartan_ReportGridModel
                    {
                    ReportId = m.ReportId
			,Report_Name = m.Report_Name
                        ,Registration_Date = (m.Registration_Date == null ? string.Empty : Convert.ToDateTime(m.Registration_Date).ToString(ConfigurationProperty.DateFormat))
			,Registration_Hour = m.Registration_Hour
                        ,Registration_UserName = m.User_Spartan_Report_User.Name
                        ,ObjectName = (string)m.Spartan_Object_Spartan_Report_Object.Name
                        ,Presentation_TypeDescription = (string)m.Presentation_Type_Spartan_Report_Presentation_Type.Description
                        ,Presentation_ViewDescription = (string)m.Presentation_View_Spartan_Report_Presentation_View.Description
                        ,StatusDescription = (string)m.Status_Spartan_Report_Status.Description
			,Query = m.Query
			,Header = m.Header
			,Footer = m.Footer

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_Report from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_Report Entity</returns>
        public ActionResult GetSpartan_ReportList(int sEcho, int iDisplayStart, int iDisplayLength, string where, string order)
        {
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
            _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_ReportPropertyMapper());
			if (!String.IsNullOrEmpty(where))
            {
                 configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True" && Session["AdvanceSearch"]!=null)
            {
				if (Session["AdvanceSearch"].GetType() == typeof(Spartan_ReportAdvanceSearchModel))
                {
					var advanceFilter =
                    (Spartan_ReportAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Spartan_ReportPropertyMapper oSpartan_ReportPropertyMapper = new Spartan_ReportPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = oSpartan_ReportPropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISpartan_ReportApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Reports == null)
                result.Spartan_Reports = new List<Spartan_Report>();

            return Json(new
            {
                aaData = result.Spartan_Reports.Select(m => new Spartan_ReportGridModel
            {
                    ReportId = m.ReportId
			,Report_Name = m.Report_Name
                        ,Registration_Date = (m.Registration_Date == null ? string.Empty : Convert.ToDateTime(m.Registration_Date).ToString(ConfigurationProperty.DateFormat))
			,Registration_Hour = m.Registration_Hour
                        ,Registration_UserName = m.User_Spartan_Report_User.Name
                        ,ObjectName = (string)m.Spartan_Object_Spartan_Report_Object.Name
                        ,Presentation_TypeDescription = (string)m.Presentation_Type_Spartan_Report_Presentation_Type.Description
                        ,Presentation_ViewDescription = (string)m.Presentation_View_Spartan_Report_Presentation_View.Description
                        ,StatusDescription = (string)m.Status_Spartan_Report_Status.Description
			,Query = m.Query
			,Header = m.Header
			,Footer = m.Footer
            , TotalColumns = m.TotalColumns
            , TotalRows = m.TotalRows

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete

//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(Spartan_ReportAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromReportId) || !string.IsNullOrEmpty(filter.ToReportId))
            {
                if (!string.IsNullOrEmpty(filter.FromReportId))
                    where += " AND Spartan_Report.ReportId >= " + filter.FromReportId;
                if (!string.IsNullOrEmpty(filter.ToReportId))
                    where += " AND Spartan_Report.ReportId <= " + filter.ToReportId;
            }

            if (!string.IsNullOrEmpty(filter.Report_Name))
            {
                switch (filter.Report_NameFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report.Report_Name LIKE '" + filter.Report_Name + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report.Report_Name LIKE '%" + filter.Report_Name + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report.Report_Name = '" + filter.Report_Name + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report.Report_Name LIKE '%" + filter.Report_Name + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromRegistration_Date) || !string.IsNullOrEmpty(filter.ToRegistration_Date))
            {
                var Registration_DateFrom = DateTime.ParseExact(filter.FromRegistration_Date, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Registration_DateTo = DateTime.ParseExact(filter.ToRegistration_Date, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromRegistration_Date))
                    where += " AND Spartan_Report.Registration_Date >= '" + Registration_DateFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToRegistration_Date))
                    where += " AND Spartan_Report.Registration_Date <= '" + Registration_DateTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromRegistration_Hour) || !string.IsNullOrEmpty(filter.ToRegistration_Hour))
            {
                if (!string.IsNullOrEmpty(filter.FromRegistration_Hour))
                    where += " AND Convert(TIME,Spartan_Report.Registration_Hour) >='" + filter.FromRegistration_Hour + "'";
                if (!string.IsNullOrEmpty(filter.ToRegistration_Hour))
                    where += " AND Convert(TIME,Spartan_Report.Registration_Hour) <='" + filter.ToRegistration_Hour + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceRegistration_User))
            {
                switch (filter.Registration_UserFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.AdvanceRegistration_User + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceRegistration_User + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.AdvanceRegistration_User + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceRegistration_User + "%'";
                        break;
                }
            }
            else if (filter.AdvanceRegistration_UserMultiple != null && filter.AdvanceRegistration_UserMultiple.Count() > 0)
            {
                var Registration_UserIds = string.Join(",", filter.AdvanceRegistration_UserMultiple);

                where += " AND Spartan_Report.Registration_User In (" + Registration_UserIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceObject))
            {
                switch (filter.ObjectFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Object.Name LIKE '" + filter.AdvanceObject + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Object.Name LIKE '%" + filter.AdvanceObject + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Object.Name = '" + filter.AdvanceObject + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Object.Name LIKE '%" + filter.AdvanceObject + "%'";
                        break;
                }
            }
            else if (filter.AdvanceObjectMultiple != null && filter.AdvanceObjectMultiple.Count() > 0)
            {
                var ObjectIds = string.Join(",", filter.AdvanceObjectMultiple);

                where += " AND Spartan_Report.Object In (" + ObjectIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvancePresentation_Type))
            {
                switch (filter.Presentation_TypeFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report_Presentation_Type.Description LIKE '" + filter.AdvancePresentation_Type + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report_Presentation_Type.Description LIKE '%" + filter.AdvancePresentation_Type + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report_Presentation_Type.Description = '" + filter.AdvancePresentation_Type + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report_Presentation_Type.Description LIKE '%" + filter.AdvancePresentation_Type + "%'";
                        break;
                }
            }
            else if (filter.AdvancePresentation_TypeMultiple != null && filter.AdvancePresentation_TypeMultiple.Count() > 0)
            {
                var Presentation_TypeIds = string.Join(",", filter.AdvancePresentation_TypeMultiple);

                where += " AND Spartan_Report.Presentation_Type In (" + Presentation_TypeIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvancePresentation_View))
            {
                switch (filter.Presentation_ViewFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report_Presentation_View.Description LIKE '" + filter.AdvancePresentation_View + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report_Presentation_View.Description LIKE '%" + filter.AdvancePresentation_View + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report_Presentation_View.Description = '" + filter.AdvancePresentation_View + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report_Presentation_View.Description LIKE '%" + filter.AdvancePresentation_View + "%'";
                        break;
                }
            }
            else if (filter.AdvancePresentation_ViewMultiple != null && filter.AdvancePresentation_ViewMultiple.Count() > 0)
            {
                var Presentation_ViewIds = string.Join(",", filter.AdvancePresentation_ViewMultiple);

                where += " AND Spartan_Report.Presentation_View In (" + Presentation_ViewIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceStatus))
            {
                switch (filter.StatusFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report_Status.Description LIKE '" + filter.AdvanceStatus + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report_Status.Description LIKE '%" + filter.AdvanceStatus + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report_Status.Description = '" + filter.AdvanceStatus + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report_Status.Description LIKE '%" + filter.AdvanceStatus + "%'";
                        break;
                }
            }
            else if (filter.AdvanceStatusMultiple != null && filter.AdvanceStatusMultiple.Count() > 0)
            {
                var StatusIds = string.Join(",", filter.AdvanceStatusMultiple);

                where += " AND Spartan_Report.Status In (" + StatusIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Query))
            {
                switch (filter.QueryFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report.Query LIKE '" + filter.Query + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report.Query LIKE '%" + filter.Query + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report.Query = '" + filter.Query + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report.Query LIKE '%" + filter.Query + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Header))
            {
                switch (filter.HeaderFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report.Header LIKE '" + filter.Header + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report.Header LIKE '%" + filter.Header + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report.Header = '" + filter.Header + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report.Header LIKE '%" + filter.Header + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Footer))
            {
                switch (filter.FooterFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report.Footer LIKE '" + filter.Footer + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report.Footer LIKE '%" + filter.Footer + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report.Footer = '" + filter.Footer + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report.Footer LIKE '%" + filter.Footer + "%'";
                        break;
                }
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

        public ActionResult GetSpartan_Report_Fields_Detail(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_Report_Fields_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_Report_Fields_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_Report_Fields_Detail.Report=" + RelationId;
            if("int" == "string")
            {
	           where = "Spartan_Report_Fields_Detail.Report='" + RelationId + "'";
            }
            var result = _ISpartan_Report_Fields_DetailApiConsumer.ListaSelAll(start, pageSize, where,"Spartan_Report_Fields_Detail.Order_Number ASC").Resource;
            if (result.Spartan_Report_Fields_Details == null)
                result.Spartan_Report_Fields_Details = new List<Spartan_Report_Fields_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_Report_Fields_Details.Select(m => new Spartan_Report_Fields_DetailGridModel
                {
                    DesignDetailId = m.DesignDetailId
			,PathField = m.PathField
			,Physical_Name = m.Physical_Name
			,Title = m.Title
                        ,Function = m.Function
                        ,FunctionDescription = (string)m.Function_Spartan_Report_Function.Description
                        ,Format = m.Format
                        ,FormatDescription = (string)m.Format_Spartan_Report_Format.Description
                        ,Order_Type = m.Order_Type
                        ,Order_TypeDescription = (string)m.Order_Type_Spartan_Report_Order_Type.Description
                        ,Field_Type = m.Field_Type
                        ,Field_TypeDescription = (string)m.Field_Type_Spartan_Report_Field_Type.Description
			,Order_Number = m.Order_Number
                        ,AttributeId = m.AttributeId
                        ,AttributeIdLogical_Name = (string)m.AttributeId_Spartan_Metadata.Logical_Name
                        , Subtotal = m.Subtotal
                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_Report_Filter(int object_id, int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0" && object_id == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_Report_FilterGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_Report_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_Report_Filter.Report=" + RelationId;
            if ("int" == "string")
            {
                where = "Spartan_Report_Filter.Report='" + RelationId + "'";
            }
            if (object_id == 0)
            {
                var result = _ISpartan_Report_FilterApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
                if (result.Spartan_Report_Filters == null)
                    result.Spartan_Report_Filters = new List<Spartan_Report_Filter>();

                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

                var jsonResult = Json(new
                {
                    data = result.Spartan_Report_Filters.Select(m => new Spartan_Report_FilterGridModel
                    {
                        ReportFilterId = m.ReportFilterId,
                        Field = m.Field,
                        FieldLogical_Name = (string)m.Field_Spartan_Metadata.Logical_Name,
                        QuickFilter = m.QuickFilter,
                        AdvanceFilter = m.AdvanceFilter
                    }).ToList(),
                    recordsTotal = result.RowCount,
                    recordsFiltered = result.RowCount,
                }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                where = "Spartan_Metadata.Object_Id=" + object_id;
                _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_MetadataApiConsumer.ListaSelAll(0, 9999, where, "Spartan_Metadata.Logical_Name").Resource;
                var jsonResult = Json(new
                {
                    data = result.Spartan_Metadatas.Select(m => new Spartan_Report_FilterGridModel
                    {
                        ReportFilterId = 0,
                        Field = m.AttributeId,
                        FieldLogical_Name = (string)m.Logical_Name,
                        QuickFilter = false,
                        AdvanceFilter = false
                    }).ToList(),
                    recordsTotal = result.RowCount,
                    recordsFiltered = result.RowCount,
                }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }

        }

        public ActionResult GetSpartan_Report_AdvanceFilter(string ReportId, int object_id)
        {
            if (ReportId == "0" && object_id == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_Report_FilterGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_Report_Advance_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            string where = "Spartan_Report_Advance_Filter.Report=" + ReportId;
            if (object_id == 0 || (object_id != 0 && !String.IsNullOrEmpty(ReportId)))
            {
                if (object_id != 0)
                {
                    where += " AND Spartan_Report_Advance_Filter.ObjectId=" + object_id;
                }
                var result = _ISpartan_Report_Advance_FilterApiConsumer.ListaSelAll(0, 9999, where, "").Resource;
                if (result.Spartan_Report_Advance_Filters == null)
                    result.Spartan_Report_Advance_Filters = new List<Spartan_Report_Advance_Filter>();


                var jsonResult = Json(new
                {
                    data = result.Spartan_Report_Advance_Filters.Select(m => new Spartan_Report_Advance_FilterGridModel
                    {
                        Clave = m.Clave,
                        AttributeId = m.AttributeId,
                        Defect_Value_From = m.Defect_Value_From,
                        Defect_Value_To = m.Defect_Value_To,
                        AttributeIdPhysical_Name = m.AttributeId_Spartan_Metadata.Physical_Name,
                        ObjectId = m.ObjectId,
                        PathField = m.PathField,
                        Visible = m.Visible
                    }).ToList(),
                    recordsTotal = result.RowCount,
                    recordsFiltered = result.RowCount,
                }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            else
            {
                where = "Spartan_Metadata.Object_Id=" + object_id;
                _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_MetadataApiConsumer.ListaSelAll(0, 9999, where, "Spartan_Metadata.Logical_Name").Resource;
                var jsonResult = Json(new
                {
                    data = result.Spartan_Metadatas.Select(m => new Spartan_Report_Advance_FilterGridModel
                    {
                        Clave = 0,
                        AttributeId = m.AttributeId,
                        ObjectId = m.Object_Id,
                        Defect_Value_From = "",
                        Defect_Value_To = "",
                        AttributeIdPhysical_Name = m.Physical_Name,
                        PathField = TreeView.Where(x => x.id == m.AttributeId.Value.ToString()).First().li_attr.fieldPath,
                        Visible = false
                    }).ToList(),
                    recordsTotal = result.RowCount,
                    recordsFiltered = result.RowCount,
                }, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }

        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);

                Spartan_Report varSpartan_Report = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    /*_ISpartan_Report_Fields_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Spartan_Report_Fields_Detail.Report=" + id;
                    if("int" == "string")
                    {
	                where = "Spartan_Report_Fields_Detail.Report='" + id + "'";
                    }
                    var Spartan_Report_Fields_DetailInfo =
                        _ISpartan_Report_Fields_DetailApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Spartan_Report_Fields_DetailInfo.Spartan_Report_Fields_Details.Count > 0)
                    {
                        var resultSpartan_Report_Fields_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_Report_Fields_DetailItem in Spartan_Report_Fields_DetailInfo.Spartan_Report_Fields_Details)
                            resultSpartan_Report_Fields_Detail = resultSpartan_Report_Fields_Detail
                                              && _ISpartan_Report_Fields_DetailApiConsumer.Delete(Spartan_Report_Fields_DetailItem.DesignDetailId, null,null).Resource;

                        if (!resultSpartan_Report_Fields_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                     * */
                    _ISpartan_Report_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Spartan_Report_Filter.Report=" + id;
                    if("int" == "string")
                    {
	                where = "Spartan_Report_Filter.Report='" + id + "'";
                    }
                    var Spartan_Report_FilterInfo =
                        _ISpartan_Report_FilterApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Spartan_Report_FilterInfo.Spartan_Report_Filters.Count > 0)
                    {
                        var resultSpartan_Report_Filter = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_Report_FilterItem in Spartan_Report_FilterInfo.Spartan_Report_Filters)
                            resultSpartan_Report_Filter = resultSpartan_Report_Filter
                                              && _ISpartan_Report_FilterApiConsumer.Delete(Spartan_Report_FilterItem.ReportFilterId, null,null).Resource;

                        if (!resultSpartan_Report_Filter)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                    //Spartan Report Permissions
                    _ISpartan_Report_PermissionsApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Spartan_Report_Permissions.Report=" + id;
                    if ("int" == "string")
                    {
                        where = "Spartan_Report_Permissions.Report='" + id + "'";
                    }
                    var Spartan_Report_PermissionsInfo =
                        _ISpartan_Report_PermissionsApiConsumer.ListaSelAll(1, int.MaxValue, where, "").Resource;

                    if (Spartan_Report_PermissionsInfo.Spartan_Report_Permissionss.Count > 0)
                    {
                        var resultSpartan_Report_Permissions = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_Report_PermissionsItem in Spartan_Report_PermissionsInfo.Spartan_Report_Permissionss)
                            resultSpartan_Report_Permissions = resultSpartan_Report_Permissions
                                              && _ISpartan_Report_PermissionsApiConsumer.Delete(Spartan_Report_PermissionsItem.ReportPermissionId, null, null).Resource;

                        if (!resultSpartan_Report_Permissions)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _ISpartan_ReportApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, bool TotalC, bool TotalR, Spartan_ReportModel varSpartan_Report)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);                    
                    var result = "";
                    var Spartan_ReportInfo = new Spartan_Report
                    {
                        ReportId = varSpartan_Report.ReportId
                        ,Report_Name = varSpartan_Report.Report_Name
                        ,
                        Registration_Date = DateTime.ParseExact(DateTime.Today.ToString("dd-MM-yyyy"), ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider)
                        ,Registration_Hour = varSpartan_Report.Registration_Hour
                        ,Registration_User = varSpartan_Report.Registration_User
                        ,Object = varSpartan_Report.Object
                        ,Presentation_Type = varSpartan_Report.Presentation_Type
                        ,Presentation_View = varSpartan_Report.Presentation_View
                        ,Status = varSpartan_Report.Status
                        ,Query = varSpartan_Report.Query
                        ,Header = varSpartan_Report.Header
                        ,Footer = varSpartan_Report.Footer
                        ,
                        TotalColumns = TotalC
                        ,
                        TotalRows = TotalR
                    };

                    result = !IsNew ?
                        _ISpartan_ReportApiConsumer.Update(Spartan_ReportInfo, null, null).Resource.ToString() :
                         _ISpartan_ReportApiConsumer.Insert(Spartan_ReportInfo, null, null).Resource.ToString();
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

        [NonAction]
        public bool CopySpartan_Report_Fields_Detail(int MasterId, int referenceId, List<Spartan_Report_Fields_DetailGridModelPost> Spartan_Report_Fields_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_Report_Fields_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_Report_Fields_DetailData = _ISpartan_Report_Fields_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_Report_Fields_Detail.Report=" + referenceId,"").Resource;
                if (Spartan_Report_Fields_DetailData == null || Spartan_Report_Fields_DetailData.Spartan_Report_Fields_Details.Count == 0)
                    return true;

                var result = true;

                Spartan_Report_Fields_DetailGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varSpartan_Report_Fields_Detail in Spartan_Report_Fields_DetailData.Spartan_Report_Fields_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Spartan_Report_Fields_Detail Spartan_Report_Fields_Detail1 = varSpartan_Report_Fields_Detail;

                    if (Spartan_Report_Fields_DetailItems != null && Spartan_Report_Fields_DetailItems.Any(m => m.DesignDetailId == Spartan_Report_Fields_Detail1.DesignDetailId))
                    {
                        modelDataToChange = Spartan_Report_Fields_DetailItems.FirstOrDefault(m => m.DesignDetailId == Spartan_Report_Fields_Detail1.DesignDetailId);
                    }
                    //Chaning Id Value
                    varSpartan_Report_Fields_Detail.Report = MasterId;
                    var insertId = _ISpartan_Report_Fields_DetailApiConsumer.Insert(varSpartan_Report_Fields_Detail,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.DesignDetailId = insertId;

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
        public ActionResult PostSpartan_Report_Fields_Detail(List<Spartan_Report_Fields_DetailGridModelPost> Spartan_Report_Fields_DetailItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);

                _ISpartanQueryApiConsumer.SetAuthHeader(_tokenManager.Token);
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _ISpartan_Report_Fields_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var delete = _ISpartanQueryApiConsumer.ExecuteQuery("DELETE FROM [dbo].[Spartan_Report_Fields_Detail] where Report=" + MasterId).Resource;


                if (Spartan_Report_Fields_DetailItems != null && Spartan_Report_Fields_DetailItems.Count > 0)
                {
                    //Generating token
                    
                    foreach (var Spartan_Report_Fields_DetailItem in Spartan_Report_Fields_DetailItems)
                    {
                        
                        //Removal Request
                        if (Spartan_Report_Fields_DetailItem.Removed)
                        {
                            result = result && _ISpartan_Report_Fields_DetailApiConsumer.Delete(Spartan_Report_Fields_DetailItem.DesignDetailId, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Spartan_Report_Fields_DetailItem.DesignDetailId = 0;

                        var Spartan_Report_Fields_DetailData = new Spartan_Report_Fields_Detail
                        {
                            Report = MasterId
                            ,DesignDetailId = 0
                            ,PathField = Spartan_Report_Fields_DetailItem.PathField
                            ,Physical_Name = Spartan_Report_Fields_DetailItem.Physical_Name
                            ,Title = Spartan_Report_Fields_DetailItem.Title
                            ,Function = (Convert.ToInt32(Spartan_Report_Fields_DetailItem.Function) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_Report_Fields_DetailItem.Function))
                            ,Format = (Convert.ToInt32(Spartan_Report_Fields_DetailItem.Format) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_Report_Fields_DetailItem.Format))
                            ,Order_Type = (Convert.ToInt32(Spartan_Report_Fields_DetailItem.Order_Type) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_Report_Fields_DetailItem.Order_Type))
                            ,Field_Type = (Convert.ToInt32(Spartan_Report_Fields_DetailItem.Field_Type) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_Report_Fields_DetailItem.Field_Type))
                            ,Order_Number = Spartan_Report_Fields_DetailItem.Order_Number
                            ,AttributeId = (Convert.ToInt32(Spartan_Report_Fields_DetailItem.AttributeId) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_Report_Fields_DetailItem.AttributeId))
                            ,
                            Subtotal = Spartan_Report_Fields_DetailItem.Subtotal
                        };

                        var resultId = _ISpartan_Report_Fields_DetailApiConsumer.Insert(Spartan_Report_Fields_DetailData,null,null).Resource;

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
        public ActionResult GetSpartan_Report_Fields_Detail_Spartan_Report_FunctionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_FunctionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Report_FunctionApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_Report_Fields_Detail_Spartan_Report_FormatAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Report_FormatApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_Report_Fields_Detail_Spartan_Report_Order_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_Order_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Report_Order_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_Report_Fields_Detail_Spartan_Report_Field_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_Field_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Report_Field_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_Report_Fields_Detail_Spartan_MetadataAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_MetadataApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_Report_Filter(int MasterId, int referenceId, List<Spartan_Report_FilterGridModelPost> Spartan_Report_FilterItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_Report_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_Report_FilterData = _ISpartan_Report_FilterApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_Report_Filter.Report=" + referenceId,"").Resource;
                if (Spartan_Report_FilterData == null || Spartan_Report_FilterData.Spartan_Report_Filters.Count == 0)
                    return true;

                var result = true;

                Spartan_Report_FilterGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varSpartan_Report_Filter in Spartan_Report_FilterData.Spartan_Report_Filters)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Spartan_Report_Filter Spartan_Report_Filter1 = varSpartan_Report_Filter;

                    if (Spartan_Report_FilterItems != null && Spartan_Report_FilterItems.Any(m => m.ReportFilterId == Spartan_Report_Filter1.ReportFilterId))
                    {
                        modelDataToChange = Spartan_Report_FilterItems.FirstOrDefault(m => m.ReportFilterId == Spartan_Report_Filter1.ReportFilterId);
                    }
                    //Chaning Id Value
                    varSpartan_Report_Filter.Report = MasterId;
                    var insertId = _ISpartan_Report_FilterApiConsumer.Insert(varSpartan_Report_Filter,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.ReportFilterId = insertId;

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
        public ActionResult PostSpartan_Report_Filter(List<Spartan_Report_FilterGridModelPost> Spartan_Report_FilterItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_Report_Filter(MasterId, referenceId, Spartan_Report_FilterItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_Report_FilterItems != null && Spartan_Report_FilterItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_Report_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);

                    var filters = _ISpartan_Report_FilterApiConsumer.ListaSelAll(0, 9999, "Spartan_Report_Filter.Report = " + MasterId, "").Resource;
                    if (filters.RowCount > 0)
                    {
                        foreach (var f in filters.Spartan_Report_Filters)
                        {
                            _ISpartan_Report_FilterApiConsumer.Delete(f.ReportFilterId, null, null);
                        }
                    }


                    foreach (var Spartan_Report_FilterItem in Spartan_Report_FilterItems)
                    {
                        var Spartan_Report_FilterData = new Spartan_Report_Filter
                        {
                            Report = MasterId
                            ,ReportFilterId = 0
                            ,Field = (Convert.ToInt32(Spartan_Report_FilterItem.Field) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_Report_FilterItem.Field))
                            ,QuickFilter = Spartan_Report_FilterItem.QuickFilter
                            ,AdvanceFilter = Spartan_Report_FilterItem.AdvanceFilter

                        };

                        var resultId = _ISpartan_Report_FilterApiConsumer.Insert(Spartan_Report_FilterData,null,null).Resource;

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

        [HttpPost]
        public ActionResult PostSpartan_Report_AdvanceFilter(List<Spartan_Report_AdvanceFilter> AdvanceFilters, int MasterId, bool changeQuery)
        {
            try
            {
                bool result = true;

                if (AdvanceFilters != null && AdvanceFilters.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_Report_Advance_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);
                    var filtersSaved = _ISpartan_Report_Advance_FilterApiConsumer.ListaSelAll(0, 9999, "Spartan_Report_Advance_Filter.Report=" + MasterId, "").Resource;
                    if (filtersSaved.RowCount > 0)
                    {
                        foreach (var filterSaved in filtersSaved.Spartan_Report_Advance_Filters)
                        {
                            _ISpartan_Report_Advance_FilterApiConsumer.Delete(filterSaved.Clave, null, null);
                        }
                    }

                    foreach (var Spartan_Report_FilterItem in AdvanceFilters)
                    {
                        if (Spartan_Report_FilterItem.from == "Select Value...")
                        {
                            Spartan_Report_FilterItem.from = "";
                        }
                        if(Spartan_Report_FilterItem.checke || (!String.IsNullOrEmpty(Spartan_Report_FilterItem.from) && !String.IsNullOrEmpty(Spartan_Report_FilterItem.to)))
                        {
                        var Spartan_Report_FilterData = new Spartan_Report_Advance_Filter();
                        Spartan_Report_FilterData.Visible = Spartan_Report_FilterItem.checke;
                        Spartan_Report_FilterData.Report = MasterId;
                        Spartan_Report_FilterData.Clave = 0;
                        Spartan_Report_FilterData.AttributeId = Spartan_Report_FilterItem.attributeId;
                        Spartan_Report_FilterData.Defect_Value_From = Spartan_Report_FilterItem.from;
                        Spartan_Report_FilterData.Defect_Value_To = Spartan_Report_FilterItem.to;
                        Spartan_Report_FilterData.ObjectId = Spartan_Report_FilterItem.objectId;
                        Spartan_Report_FilterData.PathField = Spartan_Report_FilterItem.pathField;

                        var resultId = _ISpartan_Report_Advance_FilterApiConsumer.Insert(Spartan_Report_FilterData, null, null).Resource;

                        result = result && resultId != -1;
                        }
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
        public JsonResult GenerateQueryReport(int id)
        {
            _ISpartanQueryApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartanQueryApiConsumer.ExecuteRawQuery("EXEC spGeneraQueryReporte " + id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetSpartan_Report_Filter_Spartan_MetadataAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_MetadataApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Spartan_Report script
        /// </summary>
        /// <param name="oSpartan_ReportElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Spartan_ReportModuleAttributeList)
        {
            for (int i = 0; i < Spartan_ReportModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_ReportModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_ReportModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_ReportModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_ReportModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_ReportModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_ReportModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Spartan_ReportModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Spartan_ReportModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Spartan_ReportModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Spartan_ReportModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Spartan_ReportModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strSpartan_ReportScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Report.js")))
            {
                strSpartan_ReportScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_Report element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_ReportModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_ReportScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_ReportScript.Substring(indexOfArray, strSpartan_ReportScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_ReportModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_ReportModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_ReportScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strSpartan_ReportScript.Substring(indexOfArrayHistory, strSpartan_ReportScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strSpartan_ReportScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_ReportScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_ReportScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Spartan_ReportModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Spartan_ReportModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_Report.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_Report.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Report.js")))
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
        public ActionResult GetAdvanceFilters(int objectId)
        {
            _tokenManager.GenerateToken();
            string token = _tokenManager.Token;
            List<Filter> quickFilters = GetQuickFilters(objectId, token);
            string htmlFilters = ConvertFiltersToHTML(quickFilters);
            return PartialView("_AdvanceFilters", htmlFilters);
        }

        [HttpGet]
        public ActionResult Spartan_ReportPropertyBag()
        {
            return PartialView("Spartan_ReportPropertyBag", "Spartan_Report");
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
        public ActionResult AddSpartan_Report_Fields_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_Report_Fields_Detail/AddSpartan_Report_Fields_Detail");
        }

        [HttpGet]
        public ActionResult AddSpartan_Report_Filter(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_Report_Filter/AddSpartan_Report_Filter");
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

            _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_ReportPropertyMapper());
			
            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True")
            {
                var advanceFilter =
                    (Spartan_ReportAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_ReportApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Reports == null)
                result.Spartan_Reports = new List<Spartan_Report>();

            var data = result.Spartan_Reports.Select(m => new Spartan_ReportGridModel
            {
                ReportId = m.ReportId
			,Report_Name = m.Report_Name
                        ,Registration_Date = (m.Registration_Date == null ? string.Empty : Convert.ToDateTime(m.Registration_Date).ToString(ConfigurationProperty.DateFormat))
			,Registration_Hour = m.Registration_Hour
                        ,Registration_UserName = m.User_Spartan_Report_User.Name
                        ,ObjectName = (string)m.Spartan_Object_Spartan_Report_Object.Name
                        ,Presentation_TypeDescription = (string)m.Presentation_Type_Spartan_Report_Presentation_Type.Description
                        ,Presentation_ViewDescription = (string)m.Presentation_View_Spartan_Report_Presentation_View.Description
                        ,StatusDescription = (string)m.Status_Spartan_Report_Status.Description
			,Query = m.Query
			,Header = m.Header
			,Footer = m.Footer

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_ReportList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_ReportList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "Spartan_ReportList_" + DateTime.Now.ToString());
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

            _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_ReportPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_ReportApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Reports == null)
                result.Spartan_Reports = new List<Spartan_Report>();

            var data = result.Spartan_Reports.Select(m => new Spartan_ReportGridModel
            {
                ReportId = m.ReportId
			,Report_Name = m.Report_Name
                        ,Registration_Date = (m.Registration_Date == null ? string.Empty : Convert.ToDateTime(m.Registration_Date).ToString(ConfigurationProperty.DateFormat))
			,Registration_Hour = m.Registration_Hour
                        ,Registration_UserName = m.User_Spartan_Report_User.Name
                        ,ObjectName = (string)m.Spartan_Object_Spartan_Report_Object.Name
                        ,Presentation_TypeDescription = (string)m.Presentation_Type_Spartan_Report_Presentation_Type.Description
                        ,Presentation_ViewDescription = (string)m.Presentation_View_Spartan_Report_Presentation_View.Description
                        ,StatusDescription = (string)m.Status_Spartan_Report_Status.Description
			,Query = m.Query
			,Header = m.Header
			,Footer = m.Footer

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
        #region jsTree

        public static List<JsTreeNodeModel> TreeView { get; set; }
        /// <summary>
        /// FillComponentsTree (Action que se ejecuta cuando se asigna un valor al objectId)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FillComponentsTree(int id, int reportId)
        {
            try
            {
                IList<Spartan_Metadata> components = GetSpantan_Metadata(id);
                if (!_tokenManager.GenerateToken())
                    return null;
                _ISpartan_Report_Fields_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                Spartan_Report_Fields_DetailPagingModel fields = new Spartan_Report_Fields_DetailPagingModel();
                if(reportId != 0) 
                     fields = _ISpartan_Report_Fields_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_Report_Fields_Detail.Report=" + reportId, "").Resource;
                TreeView = RenderTreeView(null, components, new List<JsTreeNodeModel>(), fields);
                var jsonResult = Json(TreeView, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
            }
            catch (Exception ex)
            {
                return Json(new { Saved = false, Message = ex.Message });

            }
        }


        /// <summary>
        ///  GetSpantan_Metadata (Este metodo busca los elementos de la tabla Spartan_Metadata para llenar el arbol)
        /// </summary>
        /// <param name="Object_Id">Id del objeto</param>
        /// <returns>Lista de elemntos Spartan_Metadata</returns>
        private IList<Spartan_Metadata> GetSpantan_Metadata(int Object_Id)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
            var whereClause = "Spartan_Metadata.Object_Id=" + Object_Id + " AND (Spartan_Metadata.Related_Object_Id IS NULL OR Spartan_Metadata.Identifier_Type IS NULL ) ";
            var orderClause = "Spartan_Metadata.ScreenOrder";
            var Spartan_Metadatas = _ISpartan_MetadataApiConsumer.SelAll(true, whereClause, orderClause);
            if (Spartan_Metadatas != null && Spartan_Metadatas.Resource != null)
                return Spartan_Metadatas.Resource.ToList();

            return null;
        }

        /// <summary>
        /// RenderTreeView (Esta es la funcion que arma el arbol con sus hijos)
        /// </summary>
        /// <param name="components"></param>
        /// <returns></returns>
        private List<JsTreeNodeModel> RenderTreeView(JsTreeNodeModel parent, IList<Spartan_Metadata> components, List<JsTreeNodeModel> nodes, Spartan_Report_Fields_DetailPagingModel fields)
        {
            Spartan_Report_Fields_Detail itemSaved = null; 
            foreach (Spartan_Metadata comp in components)
            {
                JsTreeNodeModel rootNode = new JsTreeNodeModel { objectId = Convert.ToInt32(comp.Object_Id), id = comp.AttributeId.ToString(), text = comp.Logical_Name.ToString(), children = new List<JsTreeNodeModel>(), li_attr = new JsTreeAttributeModel { /*draggable = true,*/ className = comp.Class_Name, physicalName = comp.Physical_Name, logicalName = comp.Logical_Name, objectName = comp.Spartan_Object.Name, atributteId = comp.AttributeId.ToString(), classId = comp.Class_Id.ToString() } };
                
                if(fields.RowCount != 0)
                    itemSaved = fields.Spartan_Report_Fields_Details.Where(x => x.AttributeId == comp.AttributeId).FirstOrDefault();
                if (parent != null)
                {
                    rootNode.li_attr.fieldPath = parent.li_attr.fieldPath + "." + rootNode.li_attr.atributteId;
                    if (itemSaved != null)
                        rootNode.li_attr.fieldId = itemSaved.DesignDetailId;
                    parent.children.Add(rootNode);
                }
                else
                    rootNode.li_attr.fieldPath = comp.Class_Id.ToString();

                rootNode.state = new JsTreeNodeStateModel { opened = false, selected = false, disabled = false };
                if (comp.Related_Object_Id != null && (comp.Object_Id != comp.Related_Object_Id && nodes.Where(nod => nod.objectId == comp.Related_Object_Id).Count() == 0))
                    RenderTreeView(rootNode, GetSpantan_Metadata(Convert.ToInt32(comp.Related_Object_Id)), nodes, fields);
                else
                    rootNode.li_attr.draggable = true;

                nodes.Add(rootNode);
            }
            return nodes;
        }

        public ActionResult Field(int id, string title, string physical_name, string path, int attributeId, string type)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_Report_Fields_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_Report_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_Report_FunctionApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_Report_Order_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_Report_Field_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);

            ModelField model = new ModelField();
            model.field = new Spartan_Report_Fields_Detail();
            if (id != 0)
            {
                model.field = _ISpartan_Report_Fields_DetailApiConsumer.GetByKey(id, false).Resource;
                model.metadata = _ISpartan_MetadataApiConsumer.GetByKey(model.field.AttributeId.Value, false).Resource;
                model.field.Title = title;
            }
            else
            {
                model.field.DesignDetailId = 0;
                model.field.Title = title;
                model.field.Physical_Name = physical_name;
                model.field.PathField = path;
                model.field.Order_Number = 1;
                model.field.Order_Type = 1;
                model.field.Function = 1;
                model.field.Field_Type = 2;
                if (type == "function")
                {
                    model.field.Function = 2;
                    model.field.Field_Type = 3;
                }
                if (type == "row")
                    model.field.Field_Type = 1;
                model.field.Format = 1;
                model.field.AttributeId = attributeId;
            }
            model.FieldTypes = _ISpartan_Report_Field_TypeApiConsumer.SelAll(true).Resource.ToList();
            model.Formats = _ISpartan_Report_FormatApiConsumer.SelAll(true).Resource.ToList();
            model.Functions = _ISpartan_Report_FunctionApiConsumer.SelAll(true).Resource.ToList();
            model.Orders = _ISpartan_Report_Order_TypeApiConsumer.SelAll(true).Resource.ToList();
            return PartialView("_Field", model);
        }
        #endregion

        private string ConvertFiltersToHTML(List<Filter> filters, string sufijo = "")
        {
            string ret = "";
            string label = "<label class=\"col-sm-2 col-form-label\">[VALUE]</label>";
            string input = "<input id=\"[ID]\" name=\"[NAME]\" class=\"form-control greaterThanZero control-value\" type=\"text\" />";
            string checkbox = "<input id=\"[ID]\" name=\"[NAME]\" class=\"form-control control-value\" type=\"checkbox\" />";
            string dataCombo = "";
            foreach (var filter in filters)
            {
                if (filter.ControlType != 13)
                {
                    ret += "<div class=\"form-group row filter-item" + sufijo + "\" data-pathfield=\"" + filter.PathField + "\" data-physicalname=\"" + filter.PhysicalName + "\" data-attributeid=\"" + filter.AttributeId + "\" data-objectid=\"" + filter.ObjectID + "\">";
                    if (filter.ControlType != 2 || (filter.ControlType == 2 && filter.RelatedID.Value.ToString() != filter.RelatedDescription.ToString()))
                    {
                        ret += "<input type=\"checkbox\" class=\"col-sm-1 col-form-label check-filter" + sufijo + "\">";
                    }
                    else
                    {
                        ret += "<label class=\"col-sm-1 col-form-label\"></label>";
                    }
                    ret += label.Replace("[VALUE]", filter.Label);
                    switch (filter.ControlType)
                    {
                        case 1://TextBox
                            if (filter.DataType == 1)
                            {
                                ret += "<div class=\"col-sm-6\">";
                                ret += "<div class=\"input-daterange input-group\" id=\"datepicker\">";
                                ret += "<span class=\"input-group-addon\">" + Resources.Resources.From.ToString() + "</span>";
                                ret += input.Replace("[ID]", "filter_" + filter.FilterId.ToString() + "_From").Replace("[NAME]", "filter_" + filter.FilterId.ToString() + "_From");
                                ret += "<span class=\"input-group-addon\">" + Resources.Resources.To.ToString() + "</span>";
                                ret += input.Replace("[ID]", "filter_" + filter.FilterId.ToString() + "_To").Replace("[NAME]", "filter_" + filter.FilterId.ToString() + "_To");
                                ret += "</div>";
                                ret += "</div>";
                            }
                            if (filter.DataType == 4)//Checkbox
                            {
                                ret += "<div class=\"col-sm-6\">";
                                ret += "<select class=\"form-control control-value\" id=\"filter_" + filter.FilterId.ToString() + "\" name=\"filter_" + filter.FilterId.ToString() + "\">";
                                ret += "<option value=\"\">All</option>";
                                ret += "<option value=\"1\">" + Resources.Resources.Yes + "</option>";
                                ret += "<option value=\"0\">" + Resources.Resources.No + "</option>";
                                ret += "</select>";
                                ret += "</div>";
                            }
                            if (filter.DataType == 5)//DatePicker
                            {
                                //ret += "<div class=\"col-sm-6\">";
                                //ret += "<div class=\"input-group date\">";
                                //ret += "<span class=\"input-group-addon\">";
                                //ret += "<i class=\"fa fa-calendar\"></i>From";
                                //ret += "</span>";
                                //ret += "<input id=\"filter_" + filter.FilterId.ToString() + "_From\" type=\"text\" class=\"datepicker filterData form-control control-value\">";

                                //ret += "<span class=\"input-group-addon\">";
                                //ret += "<i class=\"fa fa-calendar\"></i>To";
                                //ret += "</span>";
                                //ret += "<input id=\"filter_" + filter.FilterId.ToString() + "_To\" type=\"text\" class=\"datepicker filterData form-control control-value\">";
                                //ret += "</div>";
                                //ret += "</div>";
                                ret += "<div class=\"col-sm-6 form-inline input-group\">";
                                ret += "<span class=\"input-group-addon\">" + Resources.Resources.From + ":</span>";
                                ret += "<div class=\"input-group dateAdvance\">";
                                ret += "<input id=\"filter_" + filter.FilterId.ToString() + "_From\" type=\"text\" class=\"datepicker filterData form-control control-value\" />";
                                ret += "<span class=\"form-inline input-group-addon\">";
                                ret += "<span class=\"glyphicon glyphicon-calendar\"></span>";
                                ret += "</span>";
                                ret += "</div>";
                                ret += "<span class=\"input-group-addon\">" + Resources.Resources.To + ": </span>";
                                ret += "<div class=\"input-group dateAdvance\">";
                                ret += "<input id=\"filter_" + filter.FilterId.ToString() + "_To\" type=\"text\" class=\"datepicker filterData form-control control-value\" />";
                                ret += "<span class=\"form-inline input-group-addon\">";
                                ret += "<span class=\"glyphicon glyphicon-calendar\"></span>";
                                ret += "</span>";
                                ret += "</div>";
                                ret += "</div>";
                            }
                            if (filter.DataType == 6)//HourPicker
                            {
                                ret += "<div class=\"col-sm-6 form-inline input-group\">";
                                ret += "<span class=\"input-group-addon\">" + Resources.Resources.From + ":</span>";
                                ret += "<div class=\"input-group clock\" data-autoclose=\"true\">";
                                ret += "<input data-autoclose=\"true\" id=\"filter_" + filter.FilterId.ToString() + "_From\" type=\"text\" class=\"clockpicker filterData form-control control-value\" />";
                                ret += "<span class=\"form-inline input-group-addon\">";
                                ret += "<span class=\"glyphicon glyphicon-time\"></span>";
                                ret += "</span>";
                                ret += "</div>";
                                ret += "<span class=\"input-group-addon\">" + Resources.Resources.To + ": </span>";
                                ret += "<div class=\"input-group clock\" data-autoclose=\"true\">";
                                ret += "<input data-autoclose=\"true\" id=\"filter_" + filter.FilterId.ToString() + "_To\" type=\"text\" class=\"clockpicker filterData form-control control-value\" />";
                                ret += "<span class=\"form-inline input-group-addon\">";
                                ret += "<span class=\"glyphicon glyphicon-time\"></span>";
                                ret += "</span>";
                                ret += "</div>";
                                ret += "</div>";
                                //ret += "<div class=\"col-sm-6\">";
                                //ret += "<div class=\"input-group\">";
                                //ret += "<span class=\"input-group-addon\">";
                                //ret += "<i class=\"fa fa-clock-o\"></i>From";
                                //ret += "</span>";
                                //ret += "<input data-autoclose=\"true\" id=\"filter_" + filter.FilterId.ToString() + "_From\" type=\"text\" class=\"clockpicker filterData form-control control-value\">";

                                //ret += "<span class=\"input-group-addon\">";
                                //ret += "<i class=\"fa fa-clock-o\"></i>To";
                                //ret += "</span>";
                                //ret += "<input data-autoclose=\"true\" id=\"filter_" + filter.FilterId.ToString() + "_To\" type=\"text\" class=\"clockpicker filterData form-control control-value\">";
                                //ret += "</div>";
                                //ret += "</div>";
                            }
                            if (filter.DataType == 2)//TextBox
                            {
                                ret += "<div class=\"col-sm-6\">";
                                ret += input.Replace("[ID]", "filter_" + filter.FilterId.ToString()).Replace("[NAME]", "filter_" + filter.FilterId.ToString());
                                ret += "</div>";
                            }
                            break;
                        case 2: //Combobox
                            if (filter.RelatedID.Value.ToString() != filter.RelatedDescription.ToString())
                            {
                                dataCombo = GetDataCombo(filter.RelatedClassName, filter.RelatedID.Value, filter.RelatedDescription);
                                ret += "<div class=\"col-sm-6\">";
                                ret += "<select multiple=\"multiple\" class=\"form-control control-select2 control-value\" id=\"filter_" + filter.FilterId.ToString() + "\" name=\"filter_" + filter.FilterId.ToString() + "\">";
                                ret += dataCombo;
                                ret += "</select>";
                                ret += "</div>";
                            }
                            else
                            {
                                ret += "<div class=\"col-sm-6\">";
                                ret += "<a class=\"btn btn-default Detalles\" data-objectid=\"" + filter.RelatedObjectID + "\" data-toggle=\"modal\" data-target=\"#AdvanceFilter-form\">Detalles</a>";
                                ret += "</div>";
                            }
                            break;
                        case 3: //ListBox
                            ret += "<div class=\"col-sm-6\">";
                            ret += input.Replace("[ID]", "filter_" + filter.FilterId.ToString()).Replace("[NAME]", "filter_" + filter.FilterId.ToString());
                            ret += "</div>";
                            break;
                        case 5://Checkbox
                            ret += "<div class=\"col-sm-6\">";
                            ret += "<select class=\"form-control control-value\" id=\"filter_" + filter.FilterId.ToString() + "\" name=\"filter_" + filter.FilterId.ToString() + "\">";
                            ret += "<option value=\"\">All</option>";
                            ret += "<option value=\"1\">" + Resources.Resources.Yes + "</option>";
                            ret += "<option value=\"0\">" + Resources.Resources.No + "</option>";
                            ret += "</select>";
                            ret += "</div>";
                            break;
                        case 6://Autocomplete DropDownList
                            string dataiddesc = GetNameClaveAndDesc(filter.RelatedClassName, filter.RelatedID.Value, filter.RelatedDescription);

                            string urlData = "Frontal/" + filter.ClassName + "/Get" + filter.ClassName + "_" + filter.PhysicalName + "_" + filter.RelatedClassName;
                            ret += "<div class=\"col-sm-6\">";
                            ret += "<select data-val=\"true\" data-idfield=\"" + dataiddesc.Split(';')[0] + "\" data-descfield=\"" + dataiddesc.Split(';')[1] + "\" data-url=\"" + urlData + "\" class=\"fullWidth AutoComplete form-control control-value select2-dropdown\" id=\"filter_" + filter.FilterId.ToString() + "\" name=\"filter_" + filter.FilterId.ToString() + "\">";
                            ret += "</select>";
                            ret += "</div>";
                            break;
                        case 8://DatePicker
                            ret += "<div class=\"col-sm-6\">";
                            ret += "<div class=\"input-group date\">";
                            ret += "<span class=\"input-group-addon\">";
                            ret += "<i class=\"fa fa-calendar\"></i>";
                            ret += "</span>";
                            ret += "<input id=\"filter_" + filter.FilterId.ToString() + "_From\" type=\"text\" class=\"datepicker filterData form-control\">";
                            ret += "</div>";
                            ret += "<div class=\"input-group date\">";
                            ret += "<span class=\"input-group-addon\">";
                            ret += "<i class=\"fa fa-calendar\"></i>";
                            ret += "</span>";
                            ret += "<input id=\"filter_" + filter.FilterId.ToString() + "_To\" type=\"text\" class=\"datepicker filterData form-control\">";
                            ret += "</div>";
                            ret += "</div>";
                            break;
                        case 9://HourPicker
                            ret += "<div class=\"col-sm-6\">";
                            ret += "<div class=\"input-group\">";
                            ret += "<span class=\"input-group-addon\">";
                            ret += "<i class=\"fa fa-clock-o\"></i>";
                            ret += "</span>";
                            ret += "<input id=\"filter_" + filter.FilterId.ToString() + "_From\" type=\"text\" class=\"clockpicker filterData form-control\">";
                            ret += "</div>";
                            ret += "<div class=\"input-group\">";
                            ret += "<span class=\"input-group-addon\">";
                            ret += "<i class=\"fa fa-clock-o\"></i>";
                            ret += "</span>";
                            ret += "<input id=\"filter_" + filter.FilterId.ToString() + "_To\" type=\"text\" class=\"clockpicker filterData form-control\">";
                            ret += "</div>";
                            ret += "</div>";
                            break;
                        default:
                            break;
                    }
                    ret += "</div>";
                }
            }
            return ret;
        }

        private string GetDataCombo(string className, int id, string description)
        {
            string result = "<option>Select Value...</option>";
            if (!_tokenManager.GenerateToken()) return null;
            _ISpartan_Metadata.SetAuthHeader(_tokenManager.Token);
            var metadataId = _ISpartan_Metadata.GetByKey(id, false).Resource;
            var metadataDesc = _ISpartan_Metadata.GetByKey(Convert.ToInt32(description), false).Resource;
            string query = "";
            if (className == "TTUsuarios")
            {
                query = "Select Id_User, Name FROM Spartan_User";
            }
            else
            {
                query = "Select " + metadataId.Physical_Name + ", " + metadataDesc.Physical_Name + " FROM " + className;
            }
            var jsonData = _ISpartanQueryApiConsumer.ExecuteRawQuery(query).Resource;
            JArray v = JArray.Parse(jsonData);
            for (int i = 0; i < v.Count; i++)
            {
                string clave = "";
                string desc = "";
                if (className == "TTUsuarios")
                {
                    clave = (string)v[i]["Id_User"];
                    desc = (string)v[i]["Name"];
                }
                else
                {
                    clave = (string)v[i][metadataId.Physical_Name];
                    desc = (string)v[i][metadataDesc.Physical_Name];
                }
                result += "<option value=\"" + clave + "\">" + desc + "</option>";
            }
            return result;
        }

        private string GetNameClaveAndDesc(string className, int id, string description)
        {
            string result = "";
            if (!_tokenManager.GenerateToken()) return null;
            _ISpartan_Metadata.SetAuthHeader(_tokenManager.Token);
            var metadataId = _ISpartan_Metadata.GetByKey(id, false).Resource;
            var metadataDesc = _ISpartan_Metadata.GetByKey(Convert.ToInt32(description), false).Resource;
            result = metadataId.Physical_Name + ";" + metadataDesc.Physical_Name;
            return result;
        }

        public string GetPathField(int attrId, string token)
        {
            string result = "";

            _ISpartan_MetadataApiConsumer.SetAuthHeader(token);
            var whereClause = "Spartan_Metadata.AttributeId=" + attrId;
            var Spartan_Metadatas = _ISpartan_MetadataApiConsumer.ListaSelAll(0, 1, whereClause, "").Resource;
            if (Spartan_Metadatas.RowCount > 0)
            {
                whereClause = "Spartan_Metadata.Related_Class_Id=" + Spartan_Metadatas.Spartan_Metadatas.First().Class_Id + " AND Spartan_Metadata.Relation_Type = 2";
                var parent = _ISpartan_MetadataApiConsumer.ListaSelAll(0, 1, whereClause, "").Resource;
                if (parent.RowCount == 0 || Spartan_Metadatas.Spartan_Metadatas.First().Relation_Type.HasValue && Spartan_Metadatas.Spartan_Metadatas.First().Relation_Type.Value == 2)
                {
                    result = Spartan_Metadatas.Spartan_Metadatas.First().Class_Id + "." + Spartan_Metadatas.Spartan_Metadatas.First().AttributeId;
                }
                if (parent.RowCount > 0)
                {
                    result = GetPathField(parent.Spartan_Metadatas.First().AttributeId.Value, token) + "." + Spartan_Metadatas.Spartan_Metadatas.First().AttributeId;
                }
            }
            return result;
        }

        public List<Filter> GetQuickFilters(int objectId, string token)
        {
            IList<Spartan_Metadata> components = GetSpantan_Metadata(objectId);
            string pathField = "";
            _ISpartan_Report_FilterApiConsumer.SetAuthHeader(token);
            _ISpartan_Metadata.SetAuthHeader(token);
            List<Filter> result = new List<Filter>();
            if (components.Count > 0)
            {
                foreach (var metadata in components)
                {
                    pathField = GetPathField(metadata.AttributeId.Value, token);
                    //pathField = TreeView.Where(x => x.id == metadata.AttributeId.Value.ToString()).First().li_attr.fieldPath;
                    //if(pathField.Split('.').Length == 1)
                      //  pathField = pathField + "." + TreeView.Where(x => x.id == metadata.AttributeId.Value.ToString()).First().li_attr.atributteId;
                    result.Add(new Filter
                    {
                        DataType = metadata.Attribute_Type.Value,
                        ControlType = metadata.Control_Type,
                        Label = metadata.Logical_Name,
                        PhysicalName = metadata.Physical_Name,
                        RelationType = metadata.Relation_Type,
                        RelatedClassName = metadata.Related_Class_Name,
                        RelatedID = metadata.Related_Class_Identifier,
                        RelatedDescription = metadata.Related_Class_Description,
                        ClassName = metadata.Class_Name,
                        AttributeId = metadata.AttributeId.Value,
                        RelatedObjectID = metadata.Related_Object_Id,
                        ObjectID = metadata.Object_Id,
                        PathField = pathField,
                        FilterId = metadata.AttributeId.Value
                    });
                }
            }
            return result;
        }

        public ActionResult AdvanceFilterPopUp(int objectId)
        {
            _tokenManager.GenerateToken();
            string token = _tokenManager.Token;
            List<Filter> quickFilters = GetQuickFilters(objectId, token);
            string htmlFilters = ConvertFiltersToHTML(quickFilters, "popup");
            return PartialView("_AdvanceFiltersPopUp", htmlFilters);
        }
    }

    public class ModelField
    {
        public Spartan_Report_Fields_Detail field { get; set; }
        public Spartan_Metadata metadata { get; set; }
        public List<Spartan_Report_Function> Functions { get; set; }
        public List<Spartan_Report_Format> Formats { get; set; }
        public List<Spartan_Report_Order_Type> Orders { get; set; }
        public List<Spartan_Report_Field_Type> FieldTypes { get; set; }
    }

    public class Spartan_Report_AdvanceFilter
    {
        public bool checke { get; set; }
        public string pysicalName { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public int attributeId { get; set; }
        public int objectId { get; set; }
        public string pathField { get; set; }
    }
}
