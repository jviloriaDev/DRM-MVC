using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Dashboard_Editor;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Template_Dashboard_Editor;
using Spartane.Core.Domain.Dashboard_Status;
using Spartane.Core.Domain.Dashboard_Config_Detail;


using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Dashboard_Editor;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Dashboard_Editor;
using Spartane.Web.Areas.WebApiConsumer.Template_Dashboard_Editor;
using Spartane.Web.Areas.WebApiConsumer.Dashboard_Status;
using Spartane.Web.Areas.WebApiConsumer.Dashboard_Config_Detail;


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

using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Related;
using Spartane.Core.Domain.Spartan_Format;
using iTextSharp.text.pdf;
using Spartane.Core.Domain.Template_Dashboard_Detail;
using Spartane.Services.Template_Dashboard_Detail;
using Spartane.Web.Areas.WebApiConsumer.Template_Dashboard_Detail;


namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Dashboard_EditorController : Controller
    {
        #region "variable declaration"

        private IDashboard_EditorService service = null;
        private IDashboard_EditorApiConsumer _IDashboard_EditorApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private ITemplate_Dashboard_EditorApiConsumer _ITemplate_Dashboard_EditorApiConsumer;
        private IDashboard_StatusApiConsumer _IDashboard_StatusApiConsumer;
        private IDashboard_Config_DetailApiConsumer _IDashboard_Config_DetailApiConsumer;
        private ITemplate_Dashboard_DetailService _ITemplate_Dashboard_DetailService;


        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;
        private IGeneratePDFApiConsumer _IGeneratePDFApiConsumer;
        private ISpartan_FormatApiConsumer _ISpartan_FormatApiConsumer;
        private ISpartan_Format_PermissionsApiConsumer _ISpartan_Format_PermissionsApiConsumer;
        private ISpartan_Format_RelatedApiConsumer _ISpartan_FormatRelatedApiConsumer;
        private ITemplate_Dashboard_DetailApiConsumer _ITemplate_Dashboard_DetailApiConsumer;

        #endregion "variable declaration"

        #region "Constructor Declaration"


        public Dashboard_EditorController(IDashboard_EditorService service, ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDashboard_EditorApiConsumer Dashboard_EditorApiConsumer,
            ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer,
            ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer,
            ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer, ISpartan_UserApiConsumer Spartan_UserApiConsumer, ITemplate_Dashboard_EditorApiConsumer Template_Dashboard_EditorApiConsumer,
            IDashboard_StatusApiConsumer Dashboard_StatusApiConsumer, IDashboard_Config_DetailApiConsumer Dashboard_Config_DetailApiConsumer, ITemplate_Dashboard_DetailApiConsumer ITemplate_Dashboard_DetailApiConsumer)
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDashboard_EditorApiConsumer = Dashboard_EditorApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
            this._ISpartan_FormatRelatedApiConsumer = Spartan_Format_RelatedApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._ITemplate_Dashboard_EditorApiConsumer = Template_Dashboard_EditorApiConsumer;
            this._IDashboard_StatusApiConsumer = Dashboard_StatusApiConsumer;
            this._IDashboard_Config_DetailApiConsumer = Dashboard_Config_DetailApiConsumer;
            this._ITemplate_Dashboard_DetailApiConsumer = ITemplate_Dashboard_DetailApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Dashboard_Editor
        [ObjectAuth(ObjectId = (ModuleObjectId)40176, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index(int ModuleId = 0)
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40176, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;

            return View();
        }

        // GET: Frontal/Dashboard_Editor/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)40176, PermissionType = PermissionTypes.New,
          OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0, int consult = 0, int ModuleId = 0)
        {
            if (ModuleId == 0)
            {
                ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            }
            else
                Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40176, ModuleId);
            if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varDashboard_Editor = new Dashboard_EditorModel();
            varDashboard_Editor.Dashboard_Id = Id;

            ViewBag.ObjectId = "40176";
            ViewBag.Operation = "New";

            ViewBag.IsNew = true;

            var permissionDashboard_Config_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40190, ModuleId);
            ViewBag.PermissionDashboard_Config_Detail = permissionDashboard_Config_Detail;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {
                ViewBag.IsNew = false;
                ViewBag.Operation = "Update";

                _tokenManager.GenerateToken();
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IDashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Dashboard_EditorsData = _IDashboard_EditorApiConsumer.ListaSelAll(0, 1000, "Dashboard_Editor.Dashboard_Id=" + Id, "").Resource.Dashboard_Editors;

                if (Dashboard_EditorsData != null && Dashboard_EditorsData.Count > 0)
                {
                    var Dashboard_EditorData = Dashboard_EditorsData.First();
                    varDashboard_Editor = new Dashboard_EditorModel
                    {
                        Dashboard_Id = Dashboard_EditorData.Dashboard_Id
                        ,
                        Registration_Date = (Dashboard_EditorData.Registration_Date == null ? string.Empty : Convert.ToDateTime(Dashboard_EditorData.Registration_Date).ToString(ConfigurationProperty.DateFormat))
                    ,
                        Registration_User = Dashboard_EditorData.Registration_User
                    ,
                        Registration_UserName = Dashboard_EditorData.Registration_User_Spartan_User.Name
                    ,
                        Name = Dashboard_EditorData.Name
                    ,
                        Dashboard_Template = Dashboard_EditorData.Dashboard_Template
                    ,
                        Dashboard_TemplateDescription = CultureHelper.GetTraductionstring(Convert.ToString(Dashboard_EditorData.Dashboard_Template), "Template_Dashboard_Editor", (string)Dashboard_EditorData.Dashboard_Template_Template_Dashboard_Editor.Description)
                    ,
                        Show_in_Home = Dashboard_EditorData.Show_in_Home.GetValueOrDefault()
                    ,
                        Status = Dashboard_EditorData.Status
                    ,
                        StatusDescription = CultureHelper.GetTraductionstring(Convert.ToString(Dashboard_EditorData.Status), "Dashboard_Status", (string)Dashboard_EditorData.Status_Dashboard_Status.Description)
                    ,
                        Spartan_Object = Dashboard_EditorData.Spartan_Object

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
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(),
                    Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ITemplate_Dashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Template_Dashboard_Editors_Dashboard_Template = _ITemplate_Dashboard_EditorApiConsumer.SelAll(true);
            if (Template_Dashboard_Editors_Dashboard_Template != null && Template_Dashboard_Editors_Dashboard_Template.Resource != null)
                ViewBag.Template_Dashboard_Editors_Dashboard_Template = Template_Dashboard_Editors_Dashboard_Template.Resource;
            //ViewBag.Template_Dashboard_Editors_Dashboard_Template = Template_Dashboard_Editors_Dashboard_Template.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
            //{
            //    Text = CultureHelper.GetTraduction(Convert.ToString(m.Template_Id), "Template_Dashboard_Editor", "Description") ?? m.Description.ToString(), Value = Convert.ToString(m.Template_Id)
            //}).ToList();
            _IDashboard_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Dashboard_Statuss_Status = _IDashboard_StatusApiConsumer.SelAll(true);
            if (Dashboard_Statuss_Status != null && Dashboard_Statuss_Status.Resource != null)
                ViewBag.Dashboard_Statuss_Status = Dashboard_Statuss_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Status_Id), "Dashboard_Status", "Description") ?? m.Description.ToString(),
                    Value = Convert.ToString(m.Status_Id)
                }).ToList();


            ViewBag.Consult = consult == 1;
            if (consult == 1)
                ViewBag.Operation = "Consult";

            var isPartial = false;
            var isMR = false;
            var nameMR = string.Empty;
            var nameAttribute = string.Empty;

            if (Request.QueryString["isPartial"] != null)
                isPartial = Convert.ToBoolean(Request.QueryString["isPartial"]);

            if (Request.QueryString["isMR"] != null)
                isMR = Convert.ToBoolean(Request.QueryString["isMR"]);

            if (Request.QueryString["nameMR"] != null)
                nameMR = Request.QueryString["nameMR"].ToString();

            if (Request.QueryString["nameAttribute"] != null)
                nameAttribute = Request.QueryString["nameAttribute"].ToString();

            ViewBag.isPartial = isPartial;
            ViewBag.isMR = isMR;
            ViewBag.nameMR = nameMR;
            ViewBag.nameAttribute = nameAttribute;


            return View(varDashboard_Editor);
        }

        [HttpGet]
        public ActionResult AddDashboard_Editor(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40176);
            ViewBag.Permission = permission;
            if (!_tokenManager.GenerateToken())
                return null;
            _IDashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
            Dashboard_EditorModel varDashboard_Editor = new Dashboard_EditorModel();
            var permissionDashboard_Config_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40190, ModuleId);
            ViewBag.PermissionDashboard_Config_Detail = permissionDashboard_Config_Detail;


            if (id.ToString() != "0")
            {
                var Dashboard_EditorsData = _IDashboard_EditorApiConsumer.ListaSelAll(0, 1000, "Dashboard_Editor.Dashboard_Id=" + id, "").Resource.Dashboard_Editors;

                if (Dashboard_EditorsData != null && Dashboard_EditorsData.Count > 0)
                {
                    var Dashboard_EditorData = Dashboard_EditorsData.First();
                    varDashboard_Editor = new Dashboard_EditorModel
                    {
                        Dashboard_Id = Dashboard_EditorData.Dashboard_Id
                        ,
                        Registration_Date = (Dashboard_EditorData.Registration_Date == null ? string.Empty : Convert.ToDateTime(Dashboard_EditorData.Registration_Date).ToString(ConfigurationProperty.DateFormat))
                    ,
                        Registration_User = Dashboard_EditorData.Registration_User
                    ,
                        Registration_UserName = Dashboard_EditorData.Registration_User_Spartan_User.Name
                    ,
                        Name = Dashboard_EditorData.Name
                    ,
                        Dashboard_Template = Dashboard_EditorData.Dashboard_Template
                    ,
                        Dashboard_TemplateDescription = CultureHelper.GetTraductionstring(Convert.ToString(Dashboard_EditorData.Dashboard_Template), "Template_Dashboard_Editor", Dashboard_EditorData.Dashboard_Template_Template_Dashboard_Editor.Description)
                    ,
                        Show_in_Home = Dashboard_EditorData.Show_in_Home.GetValueOrDefault()
                    ,
                        Status = Dashboard_EditorData.Status
                    ,
                        StatusDescription = CultureHelper.GetTraductionstring(Convert.ToString(Dashboard_EditorData.Status), "Dashboard_Status", Dashboard_EditorData.Status_Dashboard_Status.Description)
                    ,
                        Spartan_Object = Dashboard_EditorData.Spartan_Object

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
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(),
                    Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ITemplate_Dashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Template_Dashboard_Editors_Dashboard_Template = _ITemplate_Dashboard_EditorApiConsumer.SelAll(true);
            if (Template_Dashboard_Editors_Dashboard_Template != null && Template_Dashboard_Editors_Dashboard_Template.Resource != null)
                ViewBag.Template_Dashboard_Editors_Dashboard_Template = Template_Dashboard_Editors_Dashboard_Template.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Template_Id), "Template_Dashboard_Editor", "Description") ?? m.Description.ToString(),
                    Value = Convert.ToString(m.Template_Id)
                }).ToList();
            _IDashboard_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Dashboard_Statuss_Status = _IDashboard_StatusApiConsumer.SelAll(true);
            if (Dashboard_Statuss_Status != null && Dashboard_Statuss_Status.Resource != null)
                ViewBag.Dashboard_Statuss_Status = Dashboard_Statuss_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Status_Id), "Dashboard_Status", "Description") ?? m.Description.ToString(),
                    Value = Convert.ToString(m.Status_Id)
                }).ToList();


            return PartialView("AddDashboard_Editor", varDashboard_Editor);
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

                return Json(result.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name,
                    Value = Convert.ToString(m.Id_User)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetTemplate_Dashboard_EditorAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITemplate_Dashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITemplate_Dashboard_EditorApiConsumer.SelAll(false).Resource;

                return Json(result.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Template_Id), "Template_Dashboard_Editor", "Description") ?? m.Description,
                    Value = Convert.ToString(m.Template_Id)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetDashboard_StatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDashboard_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDashboard_StatusApiConsumer.SelAll(false).Resource;

                return Json(result.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Status_Id), "Dashboard_Status", "Description") ?? m.Description,
                    Value = Convert.ToString(m.Status_Id)
                }).ToArray(), JsonRequestBehavior.AllowGet);
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
        public ActionResult ShowAdvanceFilter(Dashboard_EditorAdvanceSearchModel model, int idFilter = -1)
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
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(),
                    Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ITemplate_Dashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Template_Dashboard_Editors_Dashboard_Template = _ITemplate_Dashboard_EditorApiConsumer.SelAll(true);
            if (Template_Dashboard_Editors_Dashboard_Template != null && Template_Dashboard_Editors_Dashboard_Template.Resource != null)
                ViewBag.Template_Dashboard_Editors_Dashboard_Template = Template_Dashboard_Editors_Dashboard_Template.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Template_Id), "Template_Dashboard_Editor", "Description") ?? m.Description.ToString(),
                    Value = Convert.ToString(m.Template_Id)
                }).ToList();
            _IDashboard_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Dashboard_Statuss_Status = _IDashboard_StatusApiConsumer.SelAll(true);
            if (Dashboard_Statuss_Status != null && Dashboard_Statuss_Status.Resource != null)
                ViewBag.Dashboard_Statuss_Status = Dashboard_Statuss_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Status_Id), "Dashboard_Status", "Description") ?? m.Description.ToString(),
                    Value = Convert.ToString(m.Status_Id)
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
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(),
                    Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ITemplate_Dashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Template_Dashboard_Editors_Dashboard_Template = _ITemplate_Dashboard_EditorApiConsumer.SelAll(true);
            if (Template_Dashboard_Editors_Dashboard_Template != null && Template_Dashboard_Editors_Dashboard_Template.Resource != null)
                ViewBag.Template_Dashboard_Editors_Dashboard_Template = Template_Dashboard_Editors_Dashboard_Template.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Template_Id), "Template_Dashboard_Editor", "Description") ?? m.Description.ToString(),
                    Value = Convert.ToString(m.Template_Id)
                }).ToList();
            _IDashboard_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Dashboard_Statuss_Status = _IDashboard_StatusApiConsumer.SelAll(true);
            if (Dashboard_Statuss_Status != null && Dashboard_Statuss_Status.Resource != null)
                ViewBag.Dashboard_Statuss_Status = Dashboard_Statuss_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Status_Id), "Dashboard_Status", "Description") ?? m.Description.ToString(),
                    Value = Convert.ToString(m.Status_Id)
                }).ToList();


            var previousFiltersObj = new Dashboard_EditorAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Dashboard_EditorAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Dashboard_EditorAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Dashboard_EditorPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDashboard_EditorApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Dashboard_Editors == null)
                result.Dashboard_Editors = new List<Dashboard_Editor>();

            return Json(new
            {
                data = result.Dashboard_Editors.Select(m => new Dashboard_EditorGridModel
                {
                    Dashboard_Id = m.Dashboard_Id
                    ,
                    Registration_Date = (m.Registration_Date == null ? string.Empty : Convert.ToDateTime(m.Registration_Date).ToString(ConfigurationProperty.DateFormat))
                    ,
                    Registration_UserName = m.Registration_User_Spartan_User.Name
        ,
                    Name = m.Name
                    ,
                    Dashboard_TemplateDescription = CultureHelper.GetTraductionstring(m.Dashboard_Template_Template_Dashboard_Editor.Template_Id.ToString(), "Description", m.Dashboard_Template_Template_Dashboard_Editor.Description)
        ,
                    Show_in_Home = m.Show_in_Home
                    ,
                    StatusDescription = CultureHelper.GetTraductionstring(m.Status_Dashboard_Status.Status_Id.ToString(), "Description", m.Status_Dashboard_Status.Description)
        ,
                    Spartan_Object = m.Spartan_Object

                }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Dashboard_Editor from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Dashboard_Editor Entity</returns>
        public ActionResult GetDashboard_EditorList(UrlParametersModel param)
        {
            int sEcho = param.sEcho;
            int iDisplayStart = param.iDisplayStart;
            int iDisplayLength = param.iDisplayLength;
            string where = param.where;
            string order = param.order;

            where = HttpUtility.UrlEncode(where);
            int sortColumn = -1;
            string sortDirection = "asc";
            if (iDisplayLength == -1)
            {
                //length = TOTAL_ROWS;
                iDisplayLength = Int32.MaxValue;
            }
            // note: we only sort one column at a time
            if (param.sortColumn != null)
            {
                sortColumn = int.Parse(param.sortColumn);
            }
            if (param.sortDirection != null)
            {
                sortDirection = param.sortDirection;
            }


            if (!_tokenManager.GenerateToken())
                return null;
            _IDashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);


            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Dashboard_EditorPropertyMapper());

            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            //Adding Advance Search
            if (param.AdvanceSearch != null && param.AdvanceSearch == true && Session["AdvanceSearch"] != null)
            {
                if (Session["AdvanceSearch"].GetType() == typeof(Dashboard_EditorAdvanceSearchModel))
                {
                    var advanceFilter =
                    (Dashboard_EditorAdvanceSearchModel)Session["AdvanceSearch"];
                    configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
                }
                else
                {
                    Session.Remove("AdvanceSearch");
                }
            }

            Dashboard_EditorPropertyMapper oDashboard_EditorPropertyMapper = new Dashboard_EditorPropertyMapper();
            if (String.IsNullOrEmpty(order))
            {
                if (sortColumn != -1)
                    configuration.OrderByClause = oDashboard_EditorPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IDashboard_EditorApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Dashboard_Editors == null)
                result.Dashboard_Editors = new List<Dashboard_Editor>();

            return Json(new
            {
                aaData = result.Dashboard_Editors.Select(m => new Dashboard_EditorGridModel
                {
                    Dashboard_Id = m.Dashboard_Id
                            ,
                    Registration_Date = (m.Registration_Date == null ? string.Empty : Convert.ToDateTime(m.Registration_Date).ToString(ConfigurationProperty.DateFormat))
                            ,
                    Registration_UserName = m.Registration_User_Spartan_User.Name
                ,
                    Name = m.Name
                            ,
                    Dashboard_TemplateDescription = CultureHelper.GetTraductionstring(m.Dashboard_Template_Template_Dashboard_Editor.Template_Id.ToString(), "Description", m.Dashboard_Template_Template_Dashboard_Editor.Description)
                ,
                    Show_in_Home = m.Show_in_Home
                            ,
                    StatusDescription = CultureHelper.GetTraductionstring(m.Status_Dashboard_Status.Status_Id.ToString(), "Description", m.Status_Dashboard_Status.Description)
                ,
                    Spartan_Object = m.Spartan_Object

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


        //Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(Dashboard_EditorAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromDashboard_Id) || !string.IsNullOrEmpty(filter.ToDashboard_Id))
            {
                if (!string.IsNullOrEmpty(filter.FromDashboard_Id))
                    where += " AND Dashboard_Editor.Dashboard_Id >= " + filter.FromDashboard_Id;
                if (!string.IsNullOrEmpty(filter.ToDashboard_Id))
                    where += " AND Dashboard_Editor.Dashboard_Id <= " + filter.ToDashboard_Id;
            }

            if (!string.IsNullOrEmpty(filter.FromRegistration_Date) || !string.IsNullOrEmpty(filter.ToRegistration_Date))
            {
                var Registration_DateFrom = DateTime.ParseExact(filter.FromRegistration_Date, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Registration_DateTo = DateTime.ParseExact(filter.ToRegistration_Date, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromRegistration_Date))
                    where += " AND Dashboard_Editor.Registration_Date >= '" + Registration_DateFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToRegistration_Date))
                    where += " AND Dashboard_Editor.Registration_Date <= '" + Registration_DateTo.ToString("MM-dd-yyyy") + "'";
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

                where += " AND Dashboard_Editor.Registration_User In (" + Registration_UserIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                switch (filter.NameFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Dashboard_Editor.Name LIKE '" + filter.Name + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Dashboard_Editor.Name LIKE '%" + filter.Name + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Dashboard_Editor.Name = '" + filter.Name + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Dashboard_Editor.Name LIKE '%" + filter.Name + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceDashboard_Template))
            {
                switch (filter.Dashboard_TemplateFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Template_Dashboard_Editor.Description LIKE '" + filter.AdvanceDashboard_Template + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Template_Dashboard_Editor.Description LIKE '%" + filter.AdvanceDashboard_Template + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Template_Dashboard_Editor.Description = '" + filter.AdvanceDashboard_Template + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Template_Dashboard_Editor.Description LIKE '%" + filter.AdvanceDashboard_Template + "%'";
                        break;
                }
            }
            else if (filter.AdvanceDashboard_TemplateMultiple != null && filter.AdvanceDashboard_TemplateMultiple.Count() > 0)
            {
                var Dashboard_TemplateIds = string.Join(",", filter.AdvanceDashboard_TemplateMultiple);

                where += " AND Dashboard_Editor.Dashboard_Template In (" + Dashboard_TemplateIds + ")";
            }

            if (filter.Show_in_Home != RadioOptions.NoApply)
                where += " AND Dashboard_Editor.Show_in_Home = " + Convert.ToInt32(filter.Show_in_Home);

            if (!string.IsNullOrEmpty(filter.AdvanceStatus))
            {
                switch (filter.StatusFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Dashboard_Status.Description LIKE '" + filter.AdvanceStatus + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Dashboard_Status.Description LIKE '%" + filter.AdvanceStatus + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Dashboard_Status.Description = '" + filter.AdvanceStatus + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Dashboard_Status.Description LIKE '%" + filter.AdvanceStatus + "%'";
                        break;
                }
            }
            else if (filter.AdvanceStatusMultiple != null && filter.AdvanceStatusMultiple.Count() > 0)
            {
                var StatusIds = string.Join(",", filter.AdvanceStatusMultiple);

                where += " AND Dashboard_Editor.Status In (" + StatusIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromSpartan_Object) || !string.IsNullOrEmpty(filter.ToSpartan_Object))
            {
                if (!string.IsNullOrEmpty(filter.FromSpartan_Object))
                    where += " AND Dashboard_Editor.Spartan_Object >= " + filter.FromSpartan_Object;
                if (!string.IsNullOrEmpty(filter.ToSpartan_Object))
                    where += " AND Dashboard_Editor.Spartan_Object <= " + filter.ToSpartan_Object;
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

        public ActionResult GetDashboard_Config_Detail(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Dashboard_Config_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDashboard_Config_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Dashboard_Config_Detail.Dashboard=" + RelationId;
            if ("int" == "string")
            {
                where = "Dashboard_Config_Detail.Dashboard='" + RelationId + "'";
            }
            var result = _IDashboard_Config_DetailApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            if (result.Dashboard_Config_Details == null)
                result.Dashboard_Config_Details = new List<Dashboard_Config_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Dashboard_Config_Details.Select(m => new Dashboard_Config_DetailGridModel
                {
                    Detail_Id = m.Detail_Id
            ,
                    Report_Id = m.Report_Id
            ,
                    Report_Name = m.Report_Name
            ,
                    ConfigRow = m.ConfigRow
            ,
                    ConfigColumn = m.ConfigColumn

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Dashboard_Config_DetailGridModel> GetDashboard_Config_DetailData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Dashboard_Config_DetailGridModel> resultData = new List<Dashboard_Config_DetailGridModel>();
            string where = "Dashboard_Config_Detail.Dashboard=" + Id;
            if ("int" == "string")
            {
                where = "Dashboard_Config_Detail.Dashboard='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDashboard_Config_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDashboard_Config_DetailApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Dashboard_Config_Details != null)
            {
                resultData = result.Dashboard_Config_Details.Select(m => new Dashboard_Config_DetailGridModel
                {
                    Detail_Id = m.Detail_Id
        ,
                    Report_Id = m.Report_Id
        ,
                    Report_Name = m.Report_Name
        ,
                    ConfigRow = m.ConfigRow
        ,
                    ConfigColumn = m.ConfigColumn


                }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }

        public JsonResult GetLayout(string templateId)
        {
            string where = "Template = " + templateId;
            string order = "Template";
            if (!_tokenManager.GenerateToken())
                return null;

            _ITemplate_Dashboard_DetailApiConsumer.SetAuthHeader((_tokenManager.Token));
            var result = _ITemplate_Dashboard_DetailApiConsumer.ListaSelAll(false, where, order).Resource.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);

                Dashboard_Editor varDashboard_Editor = null;
                if (id.ToString() != "0")
                {
                    string where = "";
                    _IDashboard_Config_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Dashboard_Config_Detail.Dashboard=" + id;
                    if ("int" == "string")
                    {
                        where = "Dashboard_Config_Detail.Dashboard='" + id + "'";
                    }
                    var Dashboard_Config_DetailInfo =
                        _IDashboard_Config_DetailApiConsumer.ListaSelAll(1, int.MaxValue, where, "").Resource;

                    if (Dashboard_Config_DetailInfo.Dashboard_Config_Details.Count > 0)
                    {
                        var resultDashboard_Config_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Dashboard_Config_DetailItem in Dashboard_Config_DetailInfo.Dashboard_Config_Details)
                            resultDashboard_Config_Detail = resultDashboard_Config_Detail
                                              && _IDashboard_Config_DetailApiConsumer.Delete(Dashboard_Config_DetailItem.Detail_Id, null, null).Resource;

                        if (!resultDashboard_Config_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IDashboard_EditorApiConsumer.Delete(id, null, null).Resource;
                //TODO: Eliminar de Spartan Object
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Dashboard_EditorModel varDashboard_Editor)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);




                var result = "";
                var Dashboard_EditorInfo = new Dashboard_Editor
                {
                    Dashboard_Id = varDashboard_Editor.Dashboard_Id
                    ,
                    Registration_Date = (!String.IsNullOrEmpty(varDashboard_Editor.Registration_Date)) ? DateTime.ParseExact(varDashboard_Editor.Registration_Date, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                    ,
                    Registration_User = varDashboard_Editor.Registration_User
                    ,
                    Name = varDashboard_Editor.Name
                    ,
                    Dashboard_Template = varDashboard_Editor.Dashboard_Template
                    ,
                    Show_in_Home = varDashboard_Editor.Show_in_Home
                    ,
                    Status = varDashboard_Editor.Status
                    ,
                    Spartan_Object = varDashboard_Editor.Spartan_Object

                };

                result = !IsNew ?
                    _IDashboard_EditorApiConsumer.Update(Dashboard_EditorInfo, null, null).Resource.ToString() :
                     _IDashboard_EditorApiConsumer.Insert(Dashboard_EditorInfo, null, null).Resource.ToString();
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
        public bool CopyDashboard_Config_Detail(int MasterId, int referenceId, List<Dashboard_Config_DetailGridModelPost> Dashboard_Config_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDashboard_Config_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Dashboard_Config_DetailData = _IDashboard_Config_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Dashboard_Config_Detail.Dashboard=" + referenceId, "").Resource;
                if (Dashboard_Config_DetailData == null || Dashboard_Config_DetailData.Dashboard_Config_Details.Count == 0)
                    return true;

                var result = true;

                Dashboard_Config_DetailGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDashboard_Config_Detail in Dashboard_Config_DetailData.Dashboard_Config_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Dashboard_Config_Detail Dashboard_Config_Detail1 = varDashboard_Config_Detail;

                    if (Dashboard_Config_DetailItems != null && Dashboard_Config_DetailItems.Any(m => m.Detail_Id == Dashboard_Config_Detail1.Detail_Id))
                    {
                        modelDataToChange = Dashboard_Config_DetailItems.FirstOrDefault(m => m.Detail_Id == Dashboard_Config_Detail1.Detail_Id);
                    }
                    //Chaning Id Value
                    varDashboard_Config_Detail.Dashboard = MasterId;
                    var insertId = _IDashboard_Config_DetailApiConsumer.Insert(varDashboard_Config_Detail, null, null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.Detail_Id = insertId;

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
        public ActionResult PostDashboard_Config_Detail(List<Dashboard_Config_DetailGridModelPost> Dashboard_Config_DetailItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDashboard_Config_Detail(MasterId, referenceId, Dashboard_Config_DetailItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Dashboard_Config_DetailItems != null && Dashboard_Config_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDashboard_Config_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Dashboard_Config_DetailItem in Dashboard_Config_DetailItems)
                    {

                        //Removal Request
                        if (Dashboard_Config_DetailItem.Removed)
                        {
                            result = result && _IDashboard_Config_DetailApiConsumer.Delete(Dashboard_Config_DetailItem.Detail_Id, null, null).Resource;
                            continue;
                        }
                        if (referenceId.ToString() != MasterId.ToString())
                            Dashboard_Config_DetailItem.Detail_Id = 0;

                        var Dashboard_Config_DetailData = new Dashboard_Config_Detail
                        {
                            Dashboard = MasterId
                            ,
                            Detail_Id = Dashboard_Config_DetailItem.Detail_Id
                            ,
                            Report_Id = Dashboard_Config_DetailItem.Report_Id
                            ,
                            Report_Name = Dashboard_Config_DetailItem.Report_Name
                            ,
                            ConfigRow = Dashboard_Config_DetailItem.ConfigRow
                            ,
                            ConfigColumn = Dashboard_Config_DetailItem.ConfigColumn

                        };

                        var resultId = Dashboard_Config_DetailItem.Detail_Id > 0
                           ? _IDashboard_Config_DetailApiConsumer.Update(Dashboard_Config_DetailData, null, null).Resource
                           : _IDashboard_Config_DetailApiConsumer.Insert(Dashboard_Config_DetailData, null, null).Resource;

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




        /// <summary>
        /// Write Element Array of Dashboard_Editor script
        /// </summary>
        /// <param name="oDashboard_EditorElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Dashboard_EditorModuleAttributeList)
        {
            for (int i = 0; i < Dashboard_EditorModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Dashboard_EditorModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Dashboard_EditorModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Dashboard_EditorModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Dashboard_EditorModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
            if (Dashboard_EditorModuleAttributeList.ChildModuleAttributeList != null)
            {
                for (int i = 0; i < Dashboard_EditorModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
                {
                    for (int j = 0; j < Dashboard_EditorModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
                    {
                        if (string.IsNullOrEmpty(Dashboard_EditorModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
                        {
                            Dashboard_EditorModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
                        }
                        if (string.IsNullOrEmpty(Dashboard_EditorModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
                        {
                            Dashboard_EditorModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
                        }
                    }
                }
            }
            string strDashboard_EditorScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Dashboard_Editor.js")))
            {
                strDashboard_EditorScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Dashboard_Editor element attributes
            string userChangeJson = jsSerialize.Serialize(Dashboard_EditorModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDashboard_EditorScript.IndexOf("inpuElementArray");
            string splittedString = strDashboard_EditorScript.Substring(indexOfArray, strDashboard_EditorScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Dashboard_EditorModuleAttributeList.ChildModuleAttributeList);
            int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
            if (Dashboard_EditorModuleAttributeList.ChildModuleAttributeList != null)
            {
                indexOfArrayHistory = strDashboard_EditorScript.IndexOf("});");
                if (indexOfArrayHistory != -1)
                {
                    splittedStringHistory = strDashboard_EditorScript.Substring(indexOfArrayHistory, strDashboard_EditorScript.Length - indexOfArrayHistory);
                    indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
                    endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
                }
            }
            string finalResponse = strDashboard_EditorScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDashboard_EditorScript.Substring(endIndexOfMainElement + indexOfArray, strDashboard_EditorScript.Length - (endIndexOfMainElement + indexOfArray));

            var ResponseChild = string.Empty;
            if (Dashboard_EditorModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Dashboard_EditorModuleAttributeList.ChildModuleAttributeList)
                {
                    if (item != null && item.elements != null && item.elements.Count > 0)
                        ResponseChild += "\r\n  \n\r function set" + item.table + "Validation() { " +
                                        " \r\n var inpuElementChildArray =" + jsSerialize.Serialize(item.elements) + ";" +
                                        "  \r\n setInputEntityAttributes(inpuElementChildArray, \".\", 0);" +
                                        "  \r\n setDynamicRenderElement(); \n\r } ";

                }
            }
            finalResponse = finalResponse.Substring(0, finalResponse.IndexOf("});") + 4) + "\n\r";
            finalResponse += ResponseChild;


            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Dashboard_Editor.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Dashboard_Editor.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Dashboard_Editor.js")))
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
        public ActionResult Dashboard_EditorPropertyBag()
        {
            return PartialView("Dashboard_EditorPropertyBag", "Dashboard_Editor");
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
        public ActionResult AddDashboard_Config_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Dashboard_Config_Detail/AddDashboard_Config_Detail");
        }



        #endregion "Controller Methods"

        #region "Custom methods"

        [HttpGet]
        public FileStreamResult PrintFormats(int idFormat, string RecordId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _IGeneratePDFApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_FormatRelatedApiConsumer.SetAuthHeader(_tokenManager.Token);

            MemoryStream ms = new MemoryStream();

            //Buscar los Formatos Relacionados
            var relacionados = _ISpartan_FormatRelatedApiConsumer.ListaSelAll(0, 5000, "Spartan_Format_Related.FormatId = " + idFormat, "").Resource.Spartan_Format_Relateds.OrderBy(r => r.Order).ToList();
            if (relacionados.Count > 0)
            {
                var outputDocument = new iTextSharp.text.Document();
                var writer = new PdfCopy(outputDocument, ms);
                outputDocument.Open();
                foreach (var spartan_Format_Related in relacionados)
                {
                    var bytePdf = _IGeneratePDFApiConsumer.GeneratePDF(Convert.ToInt32(spartan_Format_Related.FormatId_Related), RecordId).Resource;
                    var reader = new PdfReader(bytePdf);
                    for (var j = 1; j <= reader.NumberOfPages; j++)
                    {
                        writer.AddPage(writer.GetImportedPage(reader, j));
                    }
                    writer.FreeReader(reader);
                    reader.Close();
                }
                writer.Close();
                outputDocument.Close();
                var allPagesContent = ms.GetBuffer();
                ms.Flush();
            }
            else
            {
                var bytePdf = _IGeneratePDFApiConsumer.GeneratePDF(idFormat, RecordId);
                ms.Write(bytePdf.Resource, 0, bytePdf.Resource.Length);
            }

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
        public ActionResult GetFormats(string RecordId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            var formatList = new List<SelectListItem>();

            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_Format_PermissionsApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);

            var whereClause = " Spartan_Format_Permissions.Spartan_User_Role = " + SessionHelper.Role + " AND Spartan_Format_Permissions.Permission_Type = 1 AND Apply=1 ";
            var formatsPermisions = _ISpartan_Format_PermissionsApiConsumer.ListaSelAll(0, 500, whereClause, string.Empty).Resource;
            if (formatsPermisions.RowCount > 0)
            {
                var formats = string.Join(",", formatsPermisions.Spartan_Format_Permissionss.Select(f => f.Format).ToArray());
                var whereClauseFormat = "Object = 40176 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IDashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Dashboard_Id= " + RecordId;
                            var result = _IDashboard_EditorApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
                            if (result != null && result.Resource != null && result.Resource.RowCount > 0)
                            {
                                formatList.Add(new SelectListItem
                                {
                                    Text = CultureHelper.GetTraductionAdd(format.FormatId.ToString(), "Format", format.Format_Name),
                                    Value = Convert.ToString(format.FormatId)
                                });
                            }
                        }
                        else
                        {
                            formatList.Add(new SelectListItem
                            {
                                Text = CultureHelper.GetTraductionAdd(format.FormatId.ToString(), "Format", format.Format_Name),
                                Value = Convert.ToString(format.FormatId)
                            });
                        }


                    }
                }
            }
            return Json(formatList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public void Export(string format, int pageIndex, int pageSize, string iSortCol, string sSortDir)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return;

            _IDashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Dashboard_EditorPropertyMapper());

            //Adding Advance Search
            if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Dashboard_EditorAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
            string sortDirection = "asc";

            Dashboard_EditorPropertyMapper oDashboard_EditorPropertyMapper = new Dashboard_EditorPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause = oDashboard_EditorPropertyMapper.GetPropertyName(iSortCol) + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDashboard_EditorApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Dashboard_Editors == null)
                result.Dashboard_Editors = new List<Dashboard_Editor>();

            var data = result.Dashboard_Editors.Select(m => new Dashboard_EditorGridModel
            {
                Dashboard_Id = m.Dashboard_Id
                        ,
                Registration_Date = (m.Registration_Date == null ? string.Empty : Convert.ToDateTime(m.Registration_Date).ToString(ConfigurationProperty.DateFormat))
                        ,
                Registration_UserName = m.Registration_User_Spartan_User.Name
            ,
                Name = m.Name
                        ,
                Dashboard_TemplateDescription = CultureHelper.GetTraductionstring(m.Dashboard_Template_Template_Dashboard_Editor.Template_Id.ToString(), "Description", m.Dashboard_Template_Template_Dashboard_Editor.Description)
            ,
                Show_in_Home = m.Show_in_Home
                        ,
                StatusDescription = CultureHelper.GetTraductionstring(m.Status_Dashboard_Status.Status_Id.ToString(), "Description", m.Status_Dashboard_Status.Description)
            ,
                Spartan_Object = m.Spartan_Object

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Dashboard_EditorList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Dashboard_EditorList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "Dashboard_EditorList_" + DateTime.Now.ToString());
                    break;
            }
        }

        [HttpGet]
        //[ObjectAuth(ObjectId = ModuleObjectId.EMPLEADOS_OBJECT, PermissionType = PermissionTypes.Export)]
        public ActionResult Print(string format, int pageIndex, int pageSize, string iSortCol, string sSortDir)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return null;

            _IDashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Dashboard_EditorPropertyMapper());
            if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Dashboard_EditorAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Dashboard_EditorPropertyMapper oDashboard_EditorPropertyMapper = new Dashboard_EditorPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause = oDashboard_EditorPropertyMapper.GetPropertyName(iSortCol) + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDashboard_EditorApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Dashboard_Editors == null)
                result.Dashboard_Editors = new List<Dashboard_Editor>();

            var data = result.Dashboard_Editors.Select(m => new Dashboard_EditorGridModel
            {
                Dashboard_Id = m.Dashboard_Id
                        ,
                Registration_Date = (m.Registration_Date == null ? string.Empty : Convert.ToDateTime(m.Registration_Date).ToString(ConfigurationProperty.DateFormat))
                        ,
                Registration_UserName = m.Registration_User_Spartan_User.Name
            ,
                Name = m.Name
                        ,
                Dashboard_TemplateDescription = CultureHelper.GetTraductionstring(m.Dashboard_Template_Template_Dashboard_Editor.Template_Id.ToString(), "Description", m.Dashboard_Template_Template_Dashboard_Editor.Description)
            ,
                Show_in_Home = m.Show_in_Home
                        ,
                StatusDescription = CultureHelper.GetTraductionstring(m.Status_Dashboard_Status.Status_Id.ToString(), "Description", m.Status_Dashboard_Status.Description)
            ,
                Spartan_Object = m.Spartan_Object

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"

        [HttpGet]
        public JsonResult CreateID()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDashboard_EditorApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post_Datos_Generales(Dashboard_Editor_Datos_GeneralesModel varDashboard_Editor)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);

                var result = "";
                var Dashboard_Editor_Datos_GeneralesInfo = new Dashboard_Editor_Datos_Generales
                {
                    Dashboard_Id = varDashboard_Editor.Dashboard_Id
                                            ,
                    Registration_Date = (!String.IsNullOrEmpty(varDashboard_Editor.Registration_Date)) ? DateTime.ParseExact(varDashboard_Editor.Registration_Date, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,
                    Registration_User = varDashboard_Editor.Registration_User
                        ,
                    Name = varDashboard_Editor.Name
                        ,
                    Dashboard_Template = varDashboard_Editor.Dashboard_Template
                        ,
                    Show_in_Home = varDashboard_Editor.Show_in_Home
                        ,
                    Status = varDashboard_Editor.Status
                        ,
                    Spartan_Object = varDashboard_Editor.Spartan_Object

                };

                result = _IDashboard_EditorApiConsumer.Update_Datos_Generales(Dashboard_Editor_Datos_GeneralesInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult Get_Datos_Generales(string Id)
        {
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IDashboard_EditorApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
                int RowCount_Dashboard_Config_Detail;
                var Dashboard_Config_DetailData = GetDashboard_Config_DetailData(Id.ToString(), 0, 10, out RowCount_Dashboard_Config_Detail);

                var result = new Dashboard_Editor_Datos_GeneralesModel
                {
                    Dashboard_Id = m.Dashboard_Id
                        ,
                    Registration_Date = (m.Registration_Date == null ? string.Empty : Convert.ToDateTime(m.Registration_Date).ToString(ConfigurationProperty.DateFormat))
                        ,
                    Registration_User = m.Registration_User
                        ,
                    Registration_UserName = m.Registration_User_Spartan_User.Name
            ,
                    Name = m.Name
                        ,
                    Dashboard_Template = m.Dashboard_Template
                        ,
                    Dashboard_TemplateDescription = CultureHelper.GetTraductionstring(m.Dashboard_Template_Template_Dashboard_Editor.Template_Id.ToString(), "Description", m.Dashboard_Template_Template_Dashboard_Editor.Description)
            ,
                    Show_in_Home = m.Show_in_Home
                        ,
                    Status = m.Status
                        ,
                    StatusDescription = CultureHelper.GetTraductionstring(m.Status_Dashboard_Status.Status_Id.ToString(), "Description", m.Status_Dashboard_Status.Description)
            ,
                    Spartan_Object = m.Spartan_Object


                };
                var resultData = new
                {
                    data = result
                    ,
                    Detail = Dashboard_Config_DetailData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Post_Configuracion(Dashboard_Editor_ConfiguracionModel varDashboard_Editor)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);

                var result = "";
                var Dashboard_Editor_ConfiguracionInfo = new Dashboard_Editor_Configuracion
                {
                    Dashboard_Id = varDashboard_Editor.Dashboard_Id

                };

                result = _IDashboard_EditorApiConsumer.Update_Configuracion(Dashboard_Editor_ConfiguracionInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult Get_Configuracion(string Id)
        {
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IDashboard_EditorApiConsumer.Get_Configuracion(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
                int RowCount_Dashboard_Config_Detail;
                var Dashboard_Config_DetailData = GetDashboard_Config_DetailData(Id.ToString(), 0, 10, out RowCount_Dashboard_Config_Detail);

                var result = new Dashboard_Editor_ConfiguracionModel
                {
                    Dashboard_Id = m.Dashboard_Id


                };
                var resultData = new
                {
                    data = result
                    ,
                    Detail = Dashboard_Config_DetailData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }


    }
}

