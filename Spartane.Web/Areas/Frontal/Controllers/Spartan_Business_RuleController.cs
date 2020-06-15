using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_Business_Rule;
using Spartane.Core.Domain.Spartan_BR_Scope_Detail;
using Spartane.Core.Domain.Spartan_BR_Scope;

using Spartane.Core.Domain.Spartan_BR_Operation_Detail;
using Spartane.Core.Domain.Spartan_BR_Operation;

using Spartane.Core.Domain.Spartan_BR_Process_Event_Detail;
using Spartane.Core.Domain.Spartan_BR_Process_Event;

using Spartane.Core.Domain.Spartan_BR_Conditions_Detail;
using Spartane.Core.Domain.Spartan_BR_Condition_Operator;
using Spartane.Core.Domain.Spartan_BR_Operator_Type;
using Spartane.Core.Domain.Spartan_BR_Condition;

using Spartane.Core.Domain.Spartan_BR_Actions_True_Detail;
using Spartane.Core.Domain.Spartan_BR_Action_Classification;
using Spartane.Core.Domain.Spartan_BR_Action;
using Spartane.Core.Domain.Spartan_BR_Action_Result;

using Spartane.Core.Domain.Spartan_BR_Actions_False_Detail;
using Spartane.Core.Domain.Spartan_BR_Modifications_Log;


using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_Business_Rule;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Scope_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Scope;

using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operation_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operation;

using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event;

using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Conditions_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Condition_Operator;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operator_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Condition;

using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Actions_True_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Classification;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Result;

using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Actions_False_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Modifications_Log;


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

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Spartan_Business_RuleController : Controller
    {
        #region "variable declaration"

        private ISpartan_Business_RuleService service = null;
        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Scope_DetailApiConsumer _ISpartan_BR_Scope_DetailApiConsumer;
        private ISpartan_BR_ScopeApiConsumer _ISpartan_BR_ScopeApiConsumer;

        private ISpartan_BR_Operation_DetailApiConsumer _ISpartan_BR_Operation_DetailApiConsumer;
        private ISpartan_BR_OperationApiConsumer _ISpartan_BR_OperationApiConsumer;

        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartan_BR_Process_EventApiConsumer _ISpartan_BR_Process_EventApiConsumer;

        private ISpartan_BR_Conditions_DetailApiConsumer _ISpartan_BR_Conditions_DetailApiConsumer;
        private ISpartan_BR_Condition_OperatorApiConsumer _ISpartan_BR_Condition_OperatorApiConsumer;
        private ISpartan_BR_Operator_TypeApiConsumer _ISpartan_BR_Operator_TypeApiConsumer;
        private ISpartan_BR_ConditionApiConsumer _ISpartan_BR_ConditionApiConsumer;

        private ISpartan_BR_Actions_True_DetailApiConsumer _ISpartan_BR_Actions_True_DetailApiConsumer;
        private ISpartan_BR_Action_ClassificationApiConsumer _ISpartan_BR_Action_ClassificationApiConsumer;
        private ISpartan_BR_ActionApiConsumer _ISpartan_BR_ActionApiConsumer;
        private ISpartan_BR_Action_ResultApiConsumer _ISpartan_BR_Action_ResultApiConsumer;

        private ISpartan_BR_Actions_False_DetailApiConsumer _ISpartan_BR_Actions_False_DetailApiConsumer;

        private ISpartan_BR_Modifications_LogApiConsumer _ISpartan_BR_Modifications_LogApiConsumer;


        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Spartan_Business_RuleController(ISpartan_Business_RuleService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer , ISpartan_BR_Scope_DetailApiConsumer Spartan_BR_Scope_DetailApiConsumer , ISpartan_BR_ScopeApiConsumer Spartan_BR_ScopeApiConsumer  , ISpartan_BR_Operation_DetailApiConsumer Spartan_BR_Operation_DetailApiConsumer , ISpartan_BR_OperationApiConsumer Spartan_BR_OperationApiConsumer  , ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ISpartan_BR_Process_EventApiConsumer Spartan_BR_Process_EventApiConsumer  , ISpartan_BR_Conditions_DetailApiConsumer Spartan_BR_Conditions_DetailApiConsumer , ISpartan_BR_Condition_OperatorApiConsumer Spartan_BR_Condition_OperatorApiConsumer , ISpartan_BR_Operator_TypeApiConsumer Spartan_BR_Operator_TypeApiConsumer , ISpartan_BR_ConditionApiConsumer Spartan_BR_ConditionApiConsumer  , ISpartan_BR_Actions_True_DetailApiConsumer Spartan_BR_Actions_True_DetailApiConsumer , ISpartan_BR_Action_ClassificationApiConsumer Spartan_BR_Action_ClassificationApiConsumer , ISpartan_BR_ActionApiConsumer Spartan_BR_ActionApiConsumer , ISpartan_BR_Action_ResultApiConsumer Spartan_BR_Action_ResultApiConsumer  , ISpartan_BR_Actions_False_DetailApiConsumer Spartan_BR_Actions_False_DetailApiConsumer  , ISpartan_BR_Modifications_LogApiConsumer Spartan_BR_Modifications_LogApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_BR_Scope_DetailApiConsumer = Spartan_BR_Scope_DetailApiConsumer;
            this._ISpartan_BR_ScopeApiConsumer = Spartan_BR_ScopeApiConsumer;

            this._ISpartan_BR_Operation_DetailApiConsumer = Spartan_BR_Operation_DetailApiConsumer;
            this._ISpartan_BR_OperationApiConsumer = Spartan_BR_OperationApiConsumer;

            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_BR_Process_EventApiConsumer = Spartan_BR_Process_EventApiConsumer;

            this._ISpartan_BR_Conditions_DetailApiConsumer = Spartan_BR_Conditions_DetailApiConsumer;
            this._ISpartan_BR_Condition_OperatorApiConsumer = Spartan_BR_Condition_OperatorApiConsumer;
            this._ISpartan_BR_Operator_TypeApiConsumer = Spartan_BR_Operator_TypeApiConsumer;
            this._ISpartan_BR_ConditionApiConsumer = Spartan_BR_ConditionApiConsumer;

            this._ISpartan_BR_Actions_True_DetailApiConsumer = Spartan_BR_Actions_True_DetailApiConsumer;
            this._ISpartan_BR_Action_ClassificationApiConsumer = Spartan_BR_Action_ClassificationApiConsumer;
            this._ISpartan_BR_ActionApiConsumer = Spartan_BR_ActionApiConsumer;
            this._ISpartan_BR_Action_ResultApiConsumer = Spartan_BR_Action_ResultApiConsumer;

            this._ISpartan_BR_Actions_False_DetailApiConsumer = Spartan_BR_Actions_False_DetailApiConsumer;
            this._ISpartan_BR_Action_ClassificationApiConsumer = Spartan_BR_Action_ClassificationApiConsumer;
            this._ISpartan_BR_ActionApiConsumer = Spartan_BR_ActionApiConsumer;
            this._ISpartan_BR_Action_ResultApiConsumer = Spartan_BR_Action_ResultApiConsumer;

            this._ISpartan_BR_Modifications_LogApiConsumer = Spartan_BR_Modifications_LogApiConsumer;


        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_Business_Rule
        [ObjectAuth(ObjectId = (ModuleObjectId)50002, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 50002);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Spartan_Business_Rule/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)50002, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 50002);
            ViewBag.Permission = permission;
            var varSpartan_Business_Rule = new Spartan_Business_RuleModel();

            var permissionSpartan_BR_Scope_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 50023);
            ViewBag.PermissionSpartan_BR_Scope_Detail = permissionSpartan_BR_Scope_Detail;
            var permissionSpartan_BR_Operation_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 50017);
            ViewBag.PermissionSpartan_BR_Operation_Detail = permissionSpartan_BR_Operation_Detail;
            var permissionSpartan_BR_Process_Event_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 50021);
            ViewBag.PermissionSpartan_BR_Process_Event_Detail = permissionSpartan_BR_Process_Event_Detail;
            var permissionSpartan_BR_Conditions_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 50015);
            ViewBag.PermissionSpartan_BR_Conditions_Detail = permissionSpartan_BR_Conditions_Detail;
            var permissionSpartan_BR_Actions_True_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 50012);
            ViewBag.PermissionSpartan_BR_Actions_True_Detail = permissionSpartan_BR_Actions_True_Detail;
            var permissionSpartan_BR_Actions_False_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 50008);
            ViewBag.PermissionSpartan_BR_Actions_False_Detail = permissionSpartan_BR_Actions_False_Detail;
            var permissionSpartan_BR_Modifications_Log = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 50025);
            ViewBag.PermissionSpartan_BR_Modifications_Log = permissionSpartan_BR_Modifications_Log;


            if (Convert.ToString(Id) != "0" && Convert.ToString(Id) != "-1")
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_Business_RuleData = _ISpartan_Business_RuleApiConsumer.GetByKeyComplete(Id).Resource.Spartan_Business_Rules[0];
                if (Spartan_Business_RuleData == null)
                    return HttpNotFound();

                varSpartan_Business_Rule = new Spartan_Business_RuleModel
                {
                    BusinessRuleId = Spartan_Business_RuleData.BusinessRuleId
                    ,Registration_Date = (Spartan_Business_RuleData.Registration_Date == null ? string.Empty : Convert.ToDateTime(Spartan_Business_RuleData.Registration_Date).ToString(ConfigurationProperty.DateFormat))
                    ,Registration_Hour = Spartan_Business_RuleData.Registration_Hour
                    ,User_who_registers = Spartan_Business_RuleData.User_who_registers
                    ,Description = Spartan_Business_RuleData.Description
                    ,Object = Spartan_Business_RuleData.Object
                    ,Attribute = Spartan_Business_RuleData.Attribute
                    ,Implementation_Code = Spartan_Business_RuleData.Implementation_Code

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            ViewBag.Consult = consult == 1;
            return View(varSpartan_Business_Rule);
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




        [HttpPost]
        public JsonResult ClearAdvanceFilter()
        {
            Session["AdvanceSearch"] = null;
            return Json(new { result = Session["AdvanceSearch"] == null }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ShowAdvanceFilter(Spartan_Business_RuleAdvanceSearchModel model)
        {
            if (ModelState.IsValid)
            {
                Session["AdvanceSearch"] = model;
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



            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            var previousFiltersObj = new Spartan_Business_RuleAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Spartan_Business_RuleAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Spartan_Business_RuleAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Business_RulePropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_Business_RuleApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Business_Rules == null)
                result.Spartan_Business_Rules = new List<Spartan_Business_Rule>();

            return Json(new
            {
                data = result.Spartan_Business_Rules.Select(m => new Spartan_Business_RuleGridModel
                    {
                    BusinessRuleId = m.BusinessRuleId
                        ,Registration_Date = (m.Registration_Date == null ? string.Empty : Convert.ToDateTime(m.Registration_Date).ToString(ConfigurationProperty.DateFormat))
			,Registration_Hour = m.Registration_Hour
			,User_who_registers = m.User_who_registers
			,Description = m.Description
			,Object = m.Object
			,Attribute = m.Attribute
			,Implementation_Code = m.Implementation_Code

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_Business_Rule from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_Business_Rule Entity</returns>
        public ActionResult GetSpartan_Business_RuleList(int sEcho, int iDisplayStart, int iDisplayLength)
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
            _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_Business_RulePropertyMapper());

            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True")
            {
                var advanceFilter =
                    (Spartan_Business_RuleAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            Spartan_Business_RulePropertyMapper oSpartan_Business_RulePropertyMapper = new Spartan_Business_RulePropertyMapper();

            configuration.OrderByClause = oSpartan_Business_RulePropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISpartan_Business_RuleApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Business_Rules == null)
                result.Spartan_Business_Rules = new List<Spartan_Business_Rule>();

            return Json(new
            {
                aaData = result.Spartan_Business_Rules.Select(m => new Spartan_Business_RuleGridModel
            {
                    BusinessRuleId = m.BusinessRuleId
                        ,Registration_Date = (m.Registration_Date == null ? string.Empty : Convert.ToDateTime(m.Registration_Date).ToString(ConfigurationProperty.DateFormat))
			,Registration_Hour = m.Registration_Hour
			,User_who_registers = m.User_who_registers
			,Description = m.Description
			,Object = m.Object
			,Attribute = m.Attribute
			,Implementation_Code = m.Implementation_Code

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(Spartan_Business_RuleAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromBusinessRuleId) || !string.IsNullOrEmpty(filter.ToBusinessRuleId))
            {
                if (!string.IsNullOrEmpty(filter.FromBusinessRuleId))
                    where += " AND Spartan_Business_Rule.BusinessRuleId >= " + filter.FromBusinessRuleId;
                if (!string.IsNullOrEmpty(filter.ToBusinessRuleId))
                    where += " AND Spartan_Business_Rule.BusinessRuleId <= " + filter.ToBusinessRuleId;
            }

            if (!string.IsNullOrEmpty(filter.FromRegistration_Date) || !string.IsNullOrEmpty(filter.ToRegistration_Date))
            {
                var Registration_DateFrom = DateTime.ParseExact(filter.FromRegistration_Date, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Registration_DateTo = DateTime.ParseExact(filter.ToRegistration_Date, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromRegistration_Date))
                    where += " AND Spartan_Business_Rule.Registration_Date >= '" + Registration_DateFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToRegistration_Date))
                    where += " AND Spartan_Business_Rule.Registration_Date <= '" + Registration_DateTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromRegistration_Hour) || !string.IsNullOrEmpty(filter.ToRegistration_Hour))
            {
                if (!string.IsNullOrEmpty(filter.FromRegistration_Hour))
                    where += " AND Convert(TIME,Spartan_Business_Rule.Registration_Hour) >='" + filter.FromRegistration_Hour + "'";
                if (!string.IsNullOrEmpty(filter.ToRegistration_Hour))
                    where += " AND Convert(TIME,Spartan_Business_Rule.Registration_Hour) <='" + filter.ToRegistration_Hour + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromUser_who_registers) || !string.IsNullOrEmpty(filter.ToUser_who_registers))
            {
                if (!string.IsNullOrEmpty(filter.FromUser_who_registers))
                    where += " AND Spartan_Business_Rule.User_who_registers >= " + filter.FromUser_who_registers;
                if (!string.IsNullOrEmpty(filter.ToUser_who_registers))
                    where += " AND Spartan_Business_Rule.User_who_registers <= " + filter.ToUser_who_registers;
            }

            if (!string.IsNullOrEmpty(filter.Description))
            {
                switch (filter.DescriptionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Business_Rule.Description LIKE '" + filter.Description + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Business_Rule.Description LIKE '%" + filter.Description + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Business_Rule.Description = '" + filter.Description + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Business_Rule.Description LIKE '%" + filter.Description + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromObject) || !string.IsNullOrEmpty(filter.ToObject))
            {
                if (!string.IsNullOrEmpty(filter.FromObject))
                    where += " AND Spartan_Business_Rule.Object >= " + filter.FromObject;
                if (!string.IsNullOrEmpty(filter.ToObject))
                    where += " AND Spartan_Business_Rule.Object <= " + filter.ToObject;
            }

            if (!string.IsNullOrEmpty(filter.FromAttribute) || !string.IsNullOrEmpty(filter.ToAttribute))
            {
                if (!string.IsNullOrEmpty(filter.FromAttribute))
                    where += " AND Spartan_Business_Rule.Attribute >= " + filter.FromAttribute;
                if (!string.IsNullOrEmpty(filter.ToAttribute))
                    where += " AND Spartan_Business_Rule.Attribute <= " + filter.ToAttribute;
            }

            if (!string.IsNullOrEmpty(filter.Implementation_Code))
            {
                switch (filter.Implementation_CodeFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Business_Rule.Implementation_Code LIKE '" + filter.Implementation_Code + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Business_Rule.Implementation_Code LIKE '%" + filter.Implementation_Code + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Business_Rule.Implementation_Code = '" + filter.Implementation_Code + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Business_Rule.Implementation_Code LIKE '%" + filter.Implementation_Code + "%'";
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

        public ActionResult GetSpartan_BR_Scope_Detail(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_Scope_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Scope_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            var result = _ISpartan_BR_Scope_DetailApiConsumer.ListaSelAll(start, pageSize, "Spartan_BR_Scope_Detail.Business_Rule=" + RelationId,"").Resource;
            if (result.Spartan_BR_Scope_Details == null)
                result.Spartan_BR_Scope_Details = new List<Spartan_BR_Scope_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Scope_Details.Select(m => new Spartan_BR_Scope_DetailGridModel
                {
                    ScopeDetailId = m.ScopeDetailId
                        ,Scope = m.Scope
                        ,ScopeDescription = m.Scope_Spartan_BR_Scope.Description

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_BR_Operation_Detail(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_Operation_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Operation_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            var result = _ISpartan_BR_Operation_DetailApiConsumer.ListaSelAll(start, pageSize, "Spartan_BR_Operation_Detail.Business_Rule=" + RelationId,"").Resource;
            if (result.Spartan_BR_Operation_Details == null)
                result.Spartan_BR_Operation_Details = new List<Spartan_BR_Operation_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Operation_Details.Select(m => new Spartan_BR_Operation_DetailGridModel
                {
                    OperationDetailId = m.OperationDetailId
                        ,Operation = m.Operation
                        ,OperationDescription = m.Operation_Spartan_BR_Operation.Description

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_BR_Process_Event_Detail(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_Process_Event_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            var result = _ISpartan_BR_Process_Event_DetailApiConsumer.ListaSelAll(start, pageSize, "Spartan_BR_Process_Event_Detail.Business_Rule=" + RelationId,"").Resource;
            if (result.Spartan_BR_Process_Event_Details == null)
                result.Spartan_BR_Process_Event_Details = new List<Spartan_BR_Process_Event_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Process_Event_Details.Select(m => new Spartan_BR_Process_Event_DetailGridModel
                {
                    ProcessEventDetailId = m.ProcessEventDetailId
                        ,Process_Event = m.Process_Event
                        ,Process_EventDescription = m.Process_Event_Spartan_BR_Process_Event.Description

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_BR_Conditions_Detail(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_Conditions_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Conditions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            var result = _ISpartan_BR_Conditions_DetailApiConsumer.ListaSelAll(start, pageSize, "Spartan_BR_Conditions_Detail.Business_Rule=" + RelationId,"").Resource;
            if (result.Spartan_BR_Conditions_Details == null)
                result.Spartan_BR_Conditions_Details = new List<Spartan_BR_Conditions_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Conditions_Details.Select(m => new Spartan_BR_Conditions_DetailGridModel
                {
                    ConditionsDetailId = m.ConditionsDetailId
                        ,Condition_Operator = m.Condition_Operator
                        ,Condition_OperatorDescription = m.Condition_Operator_Spartan_BR_Condition_Operator.Description
                        ,First_Operator_Type = m.First_Operator_Type
                        ,First_Operator_TypeDescription = m.First_Operator_Type_Spartan_BR_Operator_Type.Description
			,First_Operator_Value = m.First_Operator_Value
                        ,Condition = m.Condition
                        ,ConditionDescription = m.Condition_Spartan_BR_Condition.Description
                        ,Second_Operator_Type = m.Second_Operator_Type
                        ,Second_Operator_TypeDescription = m.Second_Operator_Type_Spartan_BR_Operator_Type.Description
			,Second_Operator_Value = m.Second_Operator_Value

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_BR_Actions_True_Detail(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_Actions_True_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Actions_True_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            var result = _ISpartan_BR_Actions_True_DetailApiConsumer.ListaSelAll(start, pageSize, "Spartan_BR_Actions_True_Detail.Business_Rule=" + RelationId,"").Resource;
            if (result.Spartan_BR_Actions_True_Details == null)
                result.Spartan_BR_Actions_True_Details = new List<Spartan_BR_Actions_True_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Actions_True_Details.Select(m => new Spartan_BR_Actions_True_DetailGridModel
                {
                    ActionsTrueDetailId = m.ActionsTrueDetailId
                        ,Action_Classification = m.Action_Classification
                        ,Action_ClassificationDescription = m.Action_Classification_Spartan_BR_Action_Classification.Description
                        ,Action = m.Action
                        ,ActionDescription = m.Action_Spartan_BR_Action.Description
                        ,Action_Result = m.Action_Result
                        ,Action_ResultDescription = m.Action_Result_Spartan_BR_Action_Result.Description
			,Parameter_1 = m.Parameter_1
			,Parameter_2 = m.Parameter_2
			,Parameter_3 = m.Parameter_3
			,Parameter_4 = m.Parameter_4
			,Parameter_5 = m.Parameter_5

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_BR_Actions_False_Detail(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_Actions_False_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Actions_False_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            var result = _ISpartan_BR_Actions_False_DetailApiConsumer.ListaSelAll(start, pageSize, "Spartan_BR_Actions_False_Detail.Business_Rule=" + RelationId,"").Resource;
            if (result.Spartan_BR_Actions_False_Details == null)
                result.Spartan_BR_Actions_False_Details = new List<Spartan_BR_Actions_False_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Actions_False_Details.Select(m => new Spartan_BR_Actions_False_DetailGridModel
                {
                    ActionsFalseDetailId = m.ActionsFalseDetailId
                        ,Action_Classification = m.Action_Classification
                        ,Action_ClassificationDescription = m.Action_Classification_Spartan_BR_Action_Classification.Description
                        ,Action = m.Action
                        ,ActionDescription = m.Action_Spartan_BR_Action.Description
                        ,Action_Result = m.Action_Result
                        ,Action_ResultDescription = m.Action_Result_Spartan_BR_Action_Result.Description
			,Parameter_1 = m.Parameter_1
			,Parameter_2 = m.Parameter_2
			,Parameter_3 = m.Parameter_3
			,Parameter_4 = m.Parameter_4
			,Parameter_5 = m.Parameter_5

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_BR_Modifications_Log(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_Modifications_LogGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Modifications_LogApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            var result = _ISpartan_BR_Modifications_LogApiConsumer.ListaSelAll(start, pageSize, "Spartan_BR_Modifications_Log.Business_Rule=" + RelationId,"").Resource;
            if (result.Spartan_BR_Modifications_Logs == null)
                result.Spartan_BR_Modifications_Logs = new List<Spartan_BR_Modifications_Log>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Modifications_Logs.Select(m => new Spartan_BR_Modifications_LogGridModel
                {
                    ModificationId = m.ModificationId
			,Modification_Date = (m.Modification_Date == null ? string.Empty : Convert.ToDateTime(m.Modification_Date).ToString(ConfigurationProperty.DateFormat))
			,Modification_Hour = m.Modification_Hour
			,Modification_User = m.Modification_User
			,Comments = m.Comments
			,Implementation_Code = m.Implementation_Code

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);

                //Spartan_Business_Rule varSpartan_Business_Rule = null;
                if (id.ToString() != "0")
                {
                    _ISpartan_BR_Scope_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    var Spartan_BR_Scope_DetailInfo =
                        _ISpartan_BR_Scope_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Scope_Detail.Business_Rule=" + id,"").Resource;

                    if (Spartan_BR_Scope_DetailInfo.Spartan_BR_Scope_Details.Count > 0)
                    {
                        var resultSpartan_BR_Scope_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_BR_Scope_DetailItem in Spartan_BR_Scope_DetailInfo.Spartan_BR_Scope_Details)
                            resultSpartan_BR_Scope_Detail = resultSpartan_BR_Scope_Detail
                                              && _ISpartan_BR_Scope_DetailApiConsumer.Delete(Spartan_BR_Scope_DetailItem.ScopeDetailId, null,null).Resource;

                        if (!resultSpartan_BR_Scope_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_BR_Operation_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    var Spartan_BR_Operation_DetailInfo =
                        _ISpartan_BR_Operation_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Operation_Detail.Business_Rule=" + id,"").Resource;

                    if (Spartan_BR_Operation_DetailInfo.Spartan_BR_Operation_Details.Count > 0)
                    {
                        var resultSpartan_BR_Operation_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_BR_Operation_DetailItem in Spartan_BR_Operation_DetailInfo.Spartan_BR_Operation_Details)
                            resultSpartan_BR_Operation_Detail = resultSpartan_BR_Operation_Detail
                                              && _ISpartan_BR_Operation_DetailApiConsumer.Delete(Spartan_BR_Operation_DetailItem.OperationDetailId, null,null).Resource;

                        if (!resultSpartan_BR_Operation_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    var Spartan_BR_Process_Event_DetailInfo =
                        _ISpartan_BR_Process_Event_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Process_Event_Detail.Business_Rule=" + id,"").Resource;

                    if (Spartan_BR_Process_Event_DetailInfo.Spartan_BR_Process_Event_Details.Count > 0)
                    {
                        var resultSpartan_BR_Process_Event_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_BR_Process_Event_DetailItem in Spartan_BR_Process_Event_DetailInfo.Spartan_BR_Process_Event_Details)
                            resultSpartan_BR_Process_Event_Detail = resultSpartan_BR_Process_Event_Detail
                                              && _ISpartan_BR_Process_Event_DetailApiConsumer.Delete(Spartan_BR_Process_Event_DetailItem.ProcessEventDetailId, null,null).Resource;

                        if (!resultSpartan_BR_Process_Event_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_BR_Conditions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    var Spartan_BR_Conditions_DetailInfo =
                        _ISpartan_BR_Conditions_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Conditions_Detail.Business_Rule=" + id,"").Resource;

                    if (Spartan_BR_Conditions_DetailInfo.Spartan_BR_Conditions_Details.Count > 0)
                    {
                        var resultSpartan_BR_Conditions_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_BR_Conditions_DetailItem in Spartan_BR_Conditions_DetailInfo.Spartan_BR_Conditions_Details)
                            resultSpartan_BR_Conditions_Detail = resultSpartan_BR_Conditions_Detail
                                              && _ISpartan_BR_Conditions_DetailApiConsumer.Delete(Spartan_BR_Conditions_DetailItem.ConditionsDetailId, null,null).Resource;

                        if (!resultSpartan_BR_Conditions_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_BR_Actions_True_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    var Spartan_BR_Actions_True_DetailInfo =
                        _ISpartan_BR_Actions_True_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Actions_True_Detail.Business_Rule=" + id,"").Resource;

                    if (Spartan_BR_Actions_True_DetailInfo.Spartan_BR_Actions_True_Details.Count > 0)
                    {
                        var resultSpartan_BR_Actions_True_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_BR_Actions_True_DetailItem in Spartan_BR_Actions_True_DetailInfo.Spartan_BR_Actions_True_Details)
                            resultSpartan_BR_Actions_True_Detail = resultSpartan_BR_Actions_True_Detail
                                              && _ISpartan_BR_Actions_True_DetailApiConsumer.Delete(Spartan_BR_Actions_True_DetailItem.ActionsTrueDetailId, null,null).Resource;

                        if (!resultSpartan_BR_Actions_True_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_BR_Actions_False_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    var Spartan_BR_Actions_False_DetailInfo =
                        _ISpartan_BR_Actions_False_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Actions_False_Detail.Business_Rule=" + id,"").Resource;

                    if (Spartan_BR_Actions_False_DetailInfo.Spartan_BR_Actions_False_Details.Count > 0)
                    {
                        var resultSpartan_BR_Actions_False_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_BR_Actions_False_DetailItem in Spartan_BR_Actions_False_DetailInfo.Spartan_BR_Actions_False_Details)
                            resultSpartan_BR_Actions_False_Detail = resultSpartan_BR_Actions_False_Detail
                                              && _ISpartan_BR_Actions_False_DetailApiConsumer.Delete(Spartan_BR_Actions_False_DetailItem.ActionsFalseDetailId, null,null).Resource;

                        if (!resultSpartan_BR_Actions_False_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_BR_Modifications_LogApiConsumer.SetAuthHeader(_tokenManager.Token);

                    var Spartan_BR_Modifications_LogInfo =
                        _ISpartan_BR_Modifications_LogApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Modifications_Log.Business_Rule=" + id,"").Resource;

                    if (Spartan_BR_Modifications_LogInfo.Spartan_BR_Modifications_Logs.Count > 0)
                    {
                        var resultSpartan_BR_Modifications_Log = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_BR_Modifications_LogItem in Spartan_BR_Modifications_LogInfo.Spartan_BR_Modifications_Logs)
                            resultSpartan_BR_Modifications_Log = resultSpartan_BR_Modifications_Log
                                              && _ISpartan_BR_Modifications_LogApiConsumer.Delete(Spartan_BR_Modifications_LogItem.ModificationId, null,null).Resource;

                        if (!resultSpartan_BR_Modifications_Log)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _ISpartan_Business_RuleApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(Spartan_Business_RuleModel varSpartan_Business_Rule)
        {
            try
            {
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "0";
                    var Spartan_Business_RuleInfo = new Spartan_Business_Rule
                    {
                        BusinessRuleId = varSpartan_Business_Rule.BusinessRuleId
                        ,Registration_Date = DateTime.ParseExact(varSpartan_Business_Rule.Registration_Date, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider)
                        ,Registration_Hour = varSpartan_Business_Rule.Registration_Hour
                        ,User_who_registers = varSpartan_Business_Rule.User_who_registers
                        ,Description = varSpartan_Business_Rule.Description
                        ,Object = varSpartan_Business_Rule.Object
                        ,Attribute = varSpartan_Business_Rule.Attribute
                        ,Implementation_Code = varSpartan_Business_Rule.Implementation_Code

                    };

                    result = varSpartan_Business_Rule.BusinessRuleId.ToString() != "0" ?
                        _ISpartan_Business_RuleApiConsumer.Update(Spartan_Business_RuleInfo, null, null).Resource.ToString() :
                         _ISpartan_Business_RuleApiConsumer.Insert(Spartan_Business_RuleInfo, null, null).Resource.ToString();

                    if (varSpartan_Business_Rule.BusinessRuleId.ToString() != "0")
                        result = varSpartan_Business_Rule.BusinessRuleId.ToString();

                    return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_BR_Scope_Detail(int MasterId, int referenceId, List<Spartan_BR_Scope_DetailGridModelPost> Spartan_BR_Scope_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_BR_Scope_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_BR_Scope_DetailData = _ISpartan_BR_Scope_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Scope_Detail.Business_Rule=" + referenceId,"").Resource;
                if (Spartan_BR_Scope_DetailData == null || Spartan_BR_Scope_DetailData.Spartan_BR_Scope_Details.Count == 0)
                    return true;

                var result = true;

                Spartan_BR_Scope_DetailGridModelPost modelDataToChange = null;
                var insertId = 0;
                foreach (var varSpartan_BR_Scope_Detail in Spartan_BR_Scope_DetailData.Spartan_BR_Scope_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    insertId = 0;
                    modelDataToChange = null;
                    Spartan_BR_Scope_Detail Spartan_BR_Scope_Detail1 = varSpartan_BR_Scope_Detail;

                    if (Spartan_BR_Scope_DetailItems != null && Spartan_BR_Scope_DetailItems.Any(m => m.ScopeDetailId == Spartan_BR_Scope_Detail1.ScopeDetailId))
                    {
                        modelDataToChange = Spartan_BR_Scope_DetailItems.FirstOrDefault(m => m.ScopeDetailId == Spartan_BR_Scope_Detail1.ScopeDetailId);
                    }
                    //Chaning Id Value
                    varSpartan_BR_Scope_Detail.Business_Rule = MasterId;
                    insertId = _ISpartan_BR_Scope_DetailApiConsumer.Insert(varSpartan_BR_Scope_Detail,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.ScopeDetailId = insertId;

                    result = insertId > 0;
                }
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult PostSpartan_BR_Scope_Detail(List<Spartan_BR_Scope_DetailGridModelPost> Spartan_BR_Scope_DetailItems, int MasterId, int referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_BR_Scope_Detail(MasterId, referenceId, Spartan_BR_Scope_DetailItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_BR_Scope_DetailItems != null && Spartan_BR_Scope_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Scope_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_BR_Scope_DetailItem in Spartan_BR_Scope_DetailItems)
                    {

                        //Removal Request
                        if (Spartan_BR_Scope_DetailItem.Removed)
                        {
                            result = result && _ISpartan_BR_Scope_DetailApiConsumer.Delete(Spartan_BR_Scope_DetailItem.ScopeDetailId, null,null).Resource;
                            continue;
                        }

                        var Spartan_BR_Scope_DetailData = new Spartan_BR_Scope_Detail
                        {
                            Business_Rule = MasterId
                            ,ScopeDetailId = Spartan_BR_Scope_DetailItem.ScopeDetailId
                            ,Scope = (Convert.ToInt16(Spartan_BR_Scope_DetailItem.Scope) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Scope_DetailItem.Scope))

                        };

                        var resultId = Spartan_BR_Scope_DetailItem.ScopeDetailId > 0
                           ? _ISpartan_BR_Scope_DetailApiConsumer.Update(Spartan_BR_Scope_DetailData,null,null).Resource
                           : _ISpartan_BR_Scope_DetailApiConsumer.Insert(Spartan_BR_Scope_DetailData,null,null).Resource;

                        result = result && resultId != -1;
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_BR_Scope_Detail_Spartan_BR_ScopeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_ScopeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_ScopeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_BR_Operation_Detail(int MasterId, int referenceId, List<Spartan_BR_Operation_DetailGridModelPost> Spartan_BR_Operation_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_BR_Operation_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_BR_Operation_DetailData = _ISpartan_BR_Operation_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Operation_Detail.Business_Rule=" + referenceId,"").Resource;
                if (Spartan_BR_Operation_DetailData == null || Spartan_BR_Operation_DetailData.Spartan_BR_Operation_Details.Count == 0)
                    return true;

                var result = true;

                Spartan_BR_Operation_DetailGridModelPost modelDataToChange = null;
                var insertId = 0;
                foreach (var varSpartan_BR_Operation_Detail in Spartan_BR_Operation_DetailData.Spartan_BR_Operation_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    insertId = 0;
                    modelDataToChange = null;
                    Spartan_BR_Operation_Detail Spartan_BR_Operation_Detail1 = varSpartan_BR_Operation_Detail;

                    if (Spartan_BR_Operation_DetailItems != null && Spartan_BR_Operation_DetailItems.Any(m => m.OperationDetailId == Spartan_BR_Operation_Detail1.OperationDetailId))
                    {
                        modelDataToChange = Spartan_BR_Operation_DetailItems.FirstOrDefault(m => m.OperationDetailId == Spartan_BR_Operation_Detail1.OperationDetailId);
                    }
                    //Chaning Id Value
                    varSpartan_BR_Operation_Detail.Business_Rule = MasterId;
                    insertId = _ISpartan_BR_Operation_DetailApiConsumer.Insert(varSpartan_BR_Operation_Detail,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.OperationDetailId = insertId;

                    result = insertId > 0;
                }
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult PostSpartan_BR_Operation_Detail(List<Spartan_BR_Operation_DetailGridModelPost> Spartan_BR_Operation_DetailItems, int MasterId, int referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_BR_Operation_Detail(MasterId, referenceId, Spartan_BR_Operation_DetailItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_BR_Operation_DetailItems != null && Spartan_BR_Operation_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Operation_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_BR_Operation_DetailItem in Spartan_BR_Operation_DetailItems)
                    {

                        //Removal Request
                        if (Spartan_BR_Operation_DetailItem.Removed)
                        {
                            result = result && _ISpartan_BR_Operation_DetailApiConsumer.Delete(Spartan_BR_Operation_DetailItem.OperationDetailId, null,null).Resource;
                            continue;
                        }

                        var Spartan_BR_Operation_DetailData = new Spartan_BR_Operation_Detail
                        {
                            Business_Rule = MasterId
                            ,OperationDetailId = Spartan_BR_Operation_DetailItem.OperationDetailId
                            ,Operation = (Convert.ToInt16(Spartan_BR_Operation_DetailItem.Operation) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Operation_DetailItem.Operation))

                        };

                        var resultId = Spartan_BR_Operation_DetailItem.OperationDetailId > 0
                           ? _ISpartan_BR_Operation_DetailApiConsumer.Update(Spartan_BR_Operation_DetailData,null,null).Resource
                           : _ISpartan_BR_Operation_DetailApiConsumer.Insert(Spartan_BR_Operation_DetailData,null,null).Resource;

                        result = result && resultId != -1;
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_BR_Operation_Detail_Spartan_BR_OperationAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_OperationApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_OperationApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_BR_Process_Event_Detail(int MasterId, int referenceId, List<Spartan_BR_Process_Event_DetailGridModelPost> Spartan_BR_Process_Event_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_BR_Process_Event_DetailData = _ISpartan_BR_Process_Event_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Process_Event_Detail.Business_Rule=" + referenceId,"").Resource;
                if (Spartan_BR_Process_Event_DetailData == null || Spartan_BR_Process_Event_DetailData.Spartan_BR_Process_Event_Details.Count == 0)
                    return true;

                var result = true;

                Spartan_BR_Process_Event_DetailGridModelPost modelDataToChange = null;
                var insertId = 0;
                foreach (var varSpartan_BR_Process_Event_Detail in Spartan_BR_Process_Event_DetailData.Spartan_BR_Process_Event_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    insertId = 0;
                    modelDataToChange = null;
                    Spartan_BR_Process_Event_Detail Spartan_BR_Process_Event_Detail1 = varSpartan_BR_Process_Event_Detail;

                    if (Spartan_BR_Process_Event_DetailItems != null && Spartan_BR_Process_Event_DetailItems.Any(m => m.ProcessEventDetailId == Spartan_BR_Process_Event_Detail1.ProcessEventDetailId))
                    {
                        modelDataToChange = Spartan_BR_Process_Event_DetailItems.FirstOrDefault(m => m.ProcessEventDetailId == Spartan_BR_Process_Event_Detail1.ProcessEventDetailId);
                    }
                    //Chaning Id Value
                    varSpartan_BR_Process_Event_Detail.Business_Rule = MasterId;
                    insertId = _ISpartan_BR_Process_Event_DetailApiConsumer.Insert(varSpartan_BR_Process_Event_Detail,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.ProcessEventDetailId = insertId;

                    result = insertId > 0;
                }
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult PostSpartan_BR_Process_Event_Detail(List<Spartan_BR_Process_Event_DetailGridModelPost> Spartan_BR_Process_Event_DetailItems, int MasterId, int referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_BR_Process_Event_Detail(MasterId, referenceId, Spartan_BR_Process_Event_DetailItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_BR_Process_Event_DetailItems != null && Spartan_BR_Process_Event_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_BR_Process_Event_DetailItem in Spartan_BR_Process_Event_DetailItems)
                    {

                        //Removal Request
                        if (Spartan_BR_Process_Event_DetailItem.Removed)
                        {
                            result = result && _ISpartan_BR_Process_Event_DetailApiConsumer.Delete(Spartan_BR_Process_Event_DetailItem.ProcessEventDetailId, null,null).Resource;
                            continue;
                        }

                        var Spartan_BR_Process_Event_DetailData = new Spartan_BR_Process_Event_Detail
                        {
                            Business_Rule = MasterId
                            ,ProcessEventDetailId = Spartan_BR_Process_Event_DetailItem.ProcessEventDetailId
                            ,Process_Event = (Convert.ToInt16(Spartan_BR_Process_Event_DetailItem.Process_Event) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Process_Event_DetailItem.Process_Event))

                        };

                        var resultId = Spartan_BR_Process_Event_DetailItem.ProcessEventDetailId > 0
                           ? _ISpartan_BR_Process_Event_DetailApiConsumer.Update(Spartan_BR_Process_Event_DetailData,null,null).Resource
                           : _ISpartan_BR_Process_Event_DetailApiConsumer.Insert(Spartan_BR_Process_Event_DetailData,null,null).Resource;

                        result = result && resultId != -1;
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_BR_Process_Event_Detail_Spartan_BR_Process_EventAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Process_EventApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Process_EventApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_BR_Conditions_Detail(int MasterId, int referenceId, List<Spartan_BR_Conditions_DetailGridModelPost> Spartan_BR_Conditions_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_BR_Conditions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_BR_Conditions_DetailData = _ISpartan_BR_Conditions_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Conditions_Detail.Business_Rule=" + referenceId,"").Resource;
                if (Spartan_BR_Conditions_DetailData == null || Spartan_BR_Conditions_DetailData.Spartan_BR_Conditions_Details.Count == 0)
                    return true;

                var result = true;

                Spartan_BR_Conditions_DetailGridModelPost modelDataToChange = null;
                var insertId = 0;
                foreach (var varSpartan_BR_Conditions_Detail in Spartan_BR_Conditions_DetailData.Spartan_BR_Conditions_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    insertId = 0;
                    modelDataToChange = null;
                    Spartan_BR_Conditions_Detail Spartan_BR_Conditions_Detail1 = varSpartan_BR_Conditions_Detail;

                    if (Spartan_BR_Conditions_DetailItems != null && Spartan_BR_Conditions_DetailItems.Any(m => m.ConditionsDetailId == Spartan_BR_Conditions_Detail1.ConditionsDetailId))
                    {
                        modelDataToChange = Spartan_BR_Conditions_DetailItems.FirstOrDefault(m => m.ConditionsDetailId == Spartan_BR_Conditions_Detail1.ConditionsDetailId);
                    }
                    //Chaning Id Value
                    varSpartan_BR_Conditions_Detail.Business_Rule = MasterId;
                    insertId = _ISpartan_BR_Conditions_DetailApiConsumer.Insert(varSpartan_BR_Conditions_Detail,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.ConditionsDetailId = insertId;

                    result = insertId > 0;
                }
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult PostSpartan_BR_Conditions_Detail(List<Spartan_BR_Conditions_DetailGridModelPost> Spartan_BR_Conditions_DetailItems, int MasterId, int referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_BR_Conditions_Detail(MasterId, referenceId, Spartan_BR_Conditions_DetailItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_BR_Conditions_DetailItems != null && Spartan_BR_Conditions_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Conditions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_BR_Conditions_DetailItem in Spartan_BR_Conditions_DetailItems)
                    {

                        //Removal Request
                        if (Spartan_BR_Conditions_DetailItem.Removed)
                        {
                            result = result && _ISpartan_BR_Conditions_DetailApiConsumer.Delete(Spartan_BR_Conditions_DetailItem.ConditionsDetailId, null,null).Resource;
                            continue;
                        }

                        var Spartan_BR_Conditions_DetailData = new Spartan_BR_Conditions_Detail
                        {
                            Business_Rule = MasterId
                            ,ConditionsDetailId = Spartan_BR_Conditions_DetailItem.ConditionsDetailId
                            ,Condition_Operator = (Convert.ToInt16(Spartan_BR_Conditions_DetailItem.Condition_Operator) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Conditions_DetailItem.Condition_Operator))
                            ,First_Operator_Type = (Convert.ToInt32(Spartan_BR_Conditions_DetailItem.First_Operator_Type) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_BR_Conditions_DetailItem.First_Operator_Type))
                            ,First_Operator_Value = Spartan_BR_Conditions_DetailItem.First_Operator_Value
                            ,Condition = (Convert.ToInt16(Spartan_BR_Conditions_DetailItem.Condition) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Conditions_DetailItem.Condition))
                            ,Second_Operator_Type = (Convert.ToInt32(Spartan_BR_Conditions_DetailItem.Second_Operator_Type) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_BR_Conditions_DetailItem.Second_Operator_Type))
                            ,Second_Operator_Value = Spartan_BR_Conditions_DetailItem.Second_Operator_Value

                        };

                        var resultId = Spartan_BR_Conditions_DetailItem.ConditionsDetailId > 0
                           ? _ISpartan_BR_Conditions_DetailApiConsumer.Update(Spartan_BR_Conditions_DetailData,null,null).Resource
                           : _ISpartan_BR_Conditions_DetailApiConsumer.Insert(Spartan_BR_Conditions_DetailData,null,null).Resource;

                        result = result && resultId != -1;
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Condition_OperatorApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Condition_OperatorApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Operator_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Operator_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_BR_Conditions_Detail_Spartan_BR_ConditionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_ConditionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_ConditionApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_BR_Actions_True_Detail(int MasterId, int referenceId, List<Spartan_BR_Actions_True_DetailGridModelPost> Spartan_BR_Actions_True_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_BR_Actions_True_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_BR_Actions_True_DetailData = _ISpartan_BR_Actions_True_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Actions_True_Detail.Business_Rule=" + referenceId,"").Resource;
                if (Spartan_BR_Actions_True_DetailData == null || Spartan_BR_Actions_True_DetailData.Spartan_BR_Actions_True_Details.Count == 0)
                    return true;

                var result = true;

                Spartan_BR_Actions_True_DetailGridModelPost modelDataToChange = null;
                var insertId = 0;
                foreach (var varSpartan_BR_Actions_True_Detail in Spartan_BR_Actions_True_DetailData.Spartan_BR_Actions_True_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    insertId = 0;
                    modelDataToChange = null;
                    Spartan_BR_Actions_True_Detail Spartan_BR_Actions_True_Detail1 = varSpartan_BR_Actions_True_Detail;

                    if (Spartan_BR_Actions_True_DetailItems != null && Spartan_BR_Actions_True_DetailItems.Any(m => m.ActionsTrueDetailId == Spartan_BR_Actions_True_Detail1.ActionsTrueDetailId))
                    {
                        modelDataToChange = Spartan_BR_Actions_True_DetailItems.FirstOrDefault(m => m.ActionsTrueDetailId == Spartan_BR_Actions_True_Detail1.ActionsTrueDetailId);
                    }
                    //Chaning Id Value
                    varSpartan_BR_Actions_True_Detail.Business_Rule = MasterId;
                    insertId = _ISpartan_BR_Actions_True_DetailApiConsumer.Insert(varSpartan_BR_Actions_True_Detail,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.ActionsTrueDetailId = insertId;

                    result = insertId > 0;
                }
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult PostSpartan_BR_Actions_True_Detail(List<Spartan_BR_Actions_True_DetailGridModelPost> Spartan_BR_Actions_True_DetailItems, int MasterId, int referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_BR_Actions_True_Detail(MasterId, referenceId, Spartan_BR_Actions_True_DetailItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_BR_Actions_True_DetailItems != null && Spartan_BR_Actions_True_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Actions_True_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_BR_Actions_True_DetailItem in Spartan_BR_Actions_True_DetailItems)
                    {

                        //Removal Request
                        if (Spartan_BR_Actions_True_DetailItem.Removed)
                        {
                            result = result && _ISpartan_BR_Actions_True_DetailApiConsumer.Delete(Spartan_BR_Actions_True_DetailItem.ActionsTrueDetailId, null,null).Resource;
                            continue;
                        }

                        var Spartan_BR_Actions_True_DetailData = new Spartan_BR_Actions_True_Detail
                        {
                            Business_Rule = MasterId
                            ,ActionsTrueDetailId = Spartan_BR_Actions_True_DetailItem.ActionsTrueDetailId
                            ,Action_Classification = (Convert.ToInt16(Spartan_BR_Actions_True_DetailItem.Action_Classification) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Actions_True_DetailItem.Action_Classification))
                            ,Action = (Convert.ToInt32(Spartan_BR_Actions_True_DetailItem.Action) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_BR_Actions_True_DetailItem.Action))
                            ,Action_Result = (Convert.ToInt16(Spartan_BR_Actions_True_DetailItem.Action_Result) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Actions_True_DetailItem.Action_Result))
                            ,Parameter_1 = Spartan_BR_Actions_True_DetailItem.Parameter_1
                            ,Parameter_2 = Spartan_BR_Actions_True_DetailItem.Parameter_2
                            ,Parameter_3 = Spartan_BR_Actions_True_DetailItem.Parameter_3
                            ,Parameter_4 = Spartan_BR_Actions_True_DetailItem.Parameter_4
                            ,Parameter_5 = Spartan_BR_Actions_True_DetailItem.Parameter_5

                        };

                        var resultId = Spartan_BR_Actions_True_DetailItem.ActionsTrueDetailId > 0
                           ? _ISpartan_BR_Actions_True_DetailApiConsumer.Update(Spartan_BR_Actions_True_DetailData,null,null).Resource
                           : _ISpartan_BR_Actions_True_DetailApiConsumer.Insert(Spartan_BR_Actions_True_DetailData,null,null).Resource;

                        result = result && resultId != -1;
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Action_ClassificationApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Action_ClassificationApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_BR_Actions_True_Detail_Spartan_BR_ActionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_ActionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_ActionApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Action_ResultApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Action_ResultApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_BR_Actions_False_Detail(int MasterId, int referenceId, List<Spartan_BR_Actions_False_DetailGridModelPost> Spartan_BR_Actions_False_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_BR_Actions_False_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_BR_Actions_False_DetailData = _ISpartan_BR_Actions_False_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Actions_False_Detail.Business_Rule=" + referenceId,"").Resource;
                if (Spartan_BR_Actions_False_DetailData == null || Spartan_BR_Actions_False_DetailData.Spartan_BR_Actions_False_Details.Count == 0)
                    return true;

                var result = true;

                Spartan_BR_Actions_False_DetailGridModelPost modelDataToChange = null;
                var insertId = 0;
                foreach (var varSpartan_BR_Actions_False_Detail in Spartan_BR_Actions_False_DetailData.Spartan_BR_Actions_False_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    insertId = 0;
                    modelDataToChange = null;
                    Spartan_BR_Actions_False_Detail Spartan_BR_Actions_False_Detail1 = varSpartan_BR_Actions_False_Detail;

                    if (Spartan_BR_Actions_False_DetailItems != null && Spartan_BR_Actions_False_DetailItems.Any(m => m.ActionsFalseDetailId == Spartan_BR_Actions_False_Detail1.ActionsFalseDetailId))
                    {
                        modelDataToChange = Spartan_BR_Actions_False_DetailItems.FirstOrDefault(m => m.ActionsFalseDetailId == Spartan_BR_Actions_False_Detail1.ActionsFalseDetailId);
                    }
                    //Chaning Id Value
                    varSpartan_BR_Actions_False_Detail.Business_Rule = MasterId;
                    insertId = _ISpartan_BR_Actions_False_DetailApiConsumer.Insert(varSpartan_BR_Actions_False_Detail,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.ActionsFalseDetailId = insertId;

                    result = insertId > 0;
                }
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult PostSpartan_BR_Actions_False_Detail(List<Spartan_BR_Actions_False_DetailGridModelPost> Spartan_BR_Actions_False_DetailItems, int MasterId, int referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_BR_Actions_False_Detail(MasterId, referenceId, Spartan_BR_Actions_False_DetailItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_BR_Actions_False_DetailItems != null && Spartan_BR_Actions_False_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Actions_False_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_BR_Actions_False_DetailItem in Spartan_BR_Actions_False_DetailItems)
                    {

                        //Removal Request
                        if (Spartan_BR_Actions_False_DetailItem.Removed)
                        {
                            result = result && _ISpartan_BR_Actions_False_DetailApiConsumer.Delete(Spartan_BR_Actions_False_DetailItem.ActionsFalseDetailId, null,null).Resource;
                            continue;
                        }

                        var Spartan_BR_Actions_False_DetailData = new Spartan_BR_Actions_False_Detail
                        {
                            Business_Rule = MasterId
                            ,ActionsFalseDetailId = Spartan_BR_Actions_False_DetailItem.ActionsFalseDetailId
                            ,Action_Classification = (Convert.ToInt16(Spartan_BR_Actions_False_DetailItem.Action_Classification) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Actions_False_DetailItem.Action_Classification))
                            ,Action = (Convert.ToInt32(Spartan_BR_Actions_False_DetailItem.Action) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_BR_Actions_False_DetailItem.Action))
                            ,Action_Result = (Convert.ToInt16(Spartan_BR_Actions_False_DetailItem.Action_Result) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Actions_False_DetailItem.Action_Result))
                            ,Parameter_1 = Spartan_BR_Actions_False_DetailItem.Parameter_1
                            ,Parameter_2 = Spartan_BR_Actions_False_DetailItem.Parameter_2
                            ,Parameter_3 = Spartan_BR_Actions_False_DetailItem.Parameter_3
                            ,Parameter_4 = Spartan_BR_Actions_False_DetailItem.Parameter_4
                            ,Parameter_5 = Spartan_BR_Actions_False_DetailItem.Parameter_5

                        };

                        var resultId = Spartan_BR_Actions_False_DetailItem.ActionsFalseDetailId > 0
                           ? _ISpartan_BR_Actions_False_DetailApiConsumer.Update(Spartan_BR_Actions_False_DetailData,null,null).Resource
                           : _ISpartan_BR_Actions_False_DetailApiConsumer.Insert(Spartan_BR_Actions_False_DetailData,null,null).Resource;

                        result = result && resultId != -1;
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Action_ClassificationApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Action_ClassificationApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_BR_Actions_False_Detail_Spartan_BR_ActionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_ActionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_ActionApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Action_ResultApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Action_ResultApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_BR_Modifications_Log(int MasterId, int referenceId, List<Spartan_BR_Modifications_LogGridModelPost> Spartan_BR_Modifications_LogItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_BR_Modifications_LogApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_BR_Modifications_LogData = _ISpartan_BR_Modifications_LogApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Modifications_Log.Business_Rule=" + referenceId,"").Resource;
                if (Spartan_BR_Modifications_LogData == null || Spartan_BR_Modifications_LogData.Spartan_BR_Modifications_Logs.Count == 0)
                    return true;

                var result = true;

                Spartan_BR_Modifications_LogGridModelPost modelDataToChange = null;
                var insertId = 0;
                foreach (var varSpartan_BR_Modifications_Log in Spartan_BR_Modifications_LogData.Spartan_BR_Modifications_Logs)
                {
                    if (!result)
                        return result;

                    //Initialization
                    insertId = 0;
                    modelDataToChange = null;
                    Spartan_BR_Modifications_Log Spartan_BR_Modifications_Log1 = varSpartan_BR_Modifications_Log;

                    if (Spartan_BR_Modifications_LogItems != null && Spartan_BR_Modifications_LogItems.Any(m => m.ModificationId == Spartan_BR_Modifications_Log1.ModificationId))
                    {
                        modelDataToChange = Spartan_BR_Modifications_LogItems.FirstOrDefault(m => m.ModificationId == Spartan_BR_Modifications_Log1.ModificationId);
                    }
                    //Chaning Id Value
                    varSpartan_BR_Modifications_Log.Business_Rule = MasterId;
                    insertId = _ISpartan_BR_Modifications_LogApiConsumer.Insert(varSpartan_BR_Modifications_Log,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.ModificationId = insertId;

                    result = insertId > 0;
                }
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult PostSpartan_BR_Modifications_Log(List<Spartan_BR_Modifications_LogGridModelPost> Spartan_BR_Modifications_LogItems, int MasterId, int referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_BR_Modifications_Log(MasterId, referenceId, Spartan_BR_Modifications_LogItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_BR_Modifications_LogItems != null && Spartan_BR_Modifications_LogItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Modifications_LogApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_BR_Modifications_LogItem in Spartan_BR_Modifications_LogItems)
                    {

                        //Removal Request
                        if (Spartan_BR_Modifications_LogItem.Removed)
                        {
                            result = result && _ISpartan_BR_Modifications_LogApiConsumer.Delete(Spartan_BR_Modifications_LogItem.ModificationId, null,null).Resource;
                            continue;
                        }

                        var Spartan_BR_Modifications_LogData = new Spartan_BR_Modifications_Log
                        {
                            Business_Rule = MasterId
                            ,ModificationId = Spartan_BR_Modifications_LogItem.ModificationId
                            ,Modification_Date = DateTime.ParseExact(Spartan_BR_Modifications_LogItem.Modification_Date, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider)
                            ,Modification_Hour = Spartan_BR_Modifications_LogItem.Modification_Hour
                            ,Modification_User = Spartan_BR_Modifications_LogItem.Modification_User
                            ,Comments = Spartan_BR_Modifications_LogItem.Comments
                            ,Implementation_Code = Spartan_BR_Modifications_LogItem.Implementation_Code

                        };

                        var resultId = Spartan_BR_Modifications_LogItem.ModificationId > 0
                           ? _ISpartan_BR_Modifications_LogApiConsumer.Update(Spartan_BR_Modifications_LogData,null,null).Resource
                           : _ISpartan_BR_Modifications_LogApiConsumer.Insert(Spartan_BR_Modifications_LogData,null,null).Resource;

                        result = result && resultId != -1;
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }




        /// <summary>
        /// Write Element Array of Spartan_Business_Rule script
        /// </summary>
        /// <param name="oSpartan_Business_RuleElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_Business_RuleModuleAttributeList)
        {
            for (int i = 0; i < Spartan_Business_RuleModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_Business_RuleModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_Business_RuleModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_Business_RuleModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_Business_RuleModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }

            for (int i = 0; i < Spartan_Business_RuleModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_Business_RuleModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
                {
                    Spartan_Business_RuleModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_Business_RuleModuleAttributeList.ChildModuleAttributeList[i].HelpText))
                {
                    Spartan_Business_RuleModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
                }
            }

            string strSpartan_Business_RuleScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Business_Rule.js")))
            {
                strSpartan_Business_RuleScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_Business_Rule element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_Business_RuleModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_Business_RuleScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_Business_RuleScript.Substring(indexOfArray, strSpartan_Business_RuleScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_Business_RuleModuleAttributeList.ChildModuleAttributeList);

            int indexOfArrayHistory = strSpartan_Business_RuleScript.IndexOf("inpuElementChildArray");
            string splittedStringHistory = strSpartan_Business_RuleScript.Substring(indexOfArrayHistory, strSpartan_Business_RuleScript.Length - indexOfArrayHistory);
            int indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
            int endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;

            
            //string finalResponse = strSpartan_Business_RuleScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_Business_RuleScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_Business_RuleScript.Length - (endIndexOfMainElement + indexOfArray));
            string finalResponse = strSpartan_Business_RuleScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_Business_RuleScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_Business_RuleScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_Business_RuleScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_Business_Rule.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_Business_Rule.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Business_Rule.js")))
                {
                    strCustomScript = r.ReadToEnd();
                
                }

                int indexOfArray = strCustomScript.IndexOf("inpuElementArray");
                string splittedString = strCustomScript.Substring(indexOfArray, strCustomScript.Length - indexOfArray);                
                int indexOfMainElement = splittedString.IndexOf('[');                
                int endIndexOfMainElement = splittedString.IndexOf(']') + 1;                
                string mainJsonArray = splittedString.Substring(indexOfMainElement, endIndexOfMainElement - indexOfMainElement);

                int indexOfChildArray = strCustomScript.IndexOf("inpuElementChildArray");
                string splittedChildString = strCustomScript.Substring(indexOfChildArray, strCustomScript.Length - indexOfChildArray);
                int indexOfChildElement = splittedChildString.IndexOf('[');
                int endIndexOfChildElement = splittedChildString.IndexOf(']') + 1;
                string childJsonArray = splittedChildString.Substring(indexOfChildElement, endIndexOfChildElement - indexOfChildElement);

                var MainElementList = JsonConvert.DeserializeObject(mainJsonArray);
                var ChildElementList = JsonConvert.DeserializeObject(childJsonArray);

                oCustomElementAttribute.MainElement = MainElementList.ToString();
                oCustomElementAttribute.ChildElement = ChildElementList.ToString();
            }
            else
            {
                oCustomElementAttribute.MainElement = string.Empty;
                oCustomElementAttribute.ChildElement = string.Empty;
            }        
            return Json(oCustomElementAttribute, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Spartan_Business_RulePropertyBag()
        {
            return PartialView("Spartan_Business_RulePropertyBag", "Spartan_Business_Rule");
        }

        [HttpGet]
        public ActionResult Spartan_Business_RuleBusinessRule()
        {
            return PartialView("Spartan_Business_RuleBusinessRule", "Spartan_Business_Rule");
        }

        [HttpGet]
        public ActionResult AddBusinessRule(int BusinessRuleId = 0)
        {
            Spartan_Business_RuleBusinessRuleModel oSpartan_Business_RuleBusinessRuleModel = new Spartan_Business_RuleBusinessRuleModel();
            if (BusinessRuleId > 0)
            {
                oSpartan_Business_RuleBusinessRuleModel.BusinessRuleId = BusinessRuleId;
            }
            return PartialView("AddBusinessRule", oSpartan_Business_RuleBusinessRuleModel);
        }

        [HttpGet]
        public ActionResult AddSpartan_BR_Scope_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("AddSpartan_BR_Scope_Detail");
        }

        [HttpGet]
        public ActionResult AddSpartan_BR_Operation_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("AddSpartan_BR_Operation_Detail");
        }

        [HttpGet]
        public ActionResult AddSpartan_BR_Process_Event_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("AddSpartan_BR_Process_Event_Detail");
        }

        [HttpGet]
        public ActionResult AddSpartan_BR_Conditions_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("AddSpartan_BR_Conditions_Detail");
        }

        [HttpGet]
        public ActionResult AddSpartan_BR_Actions_True_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("AddSpartan_BR_Actions_True_Detail");
        }

        [HttpGet]
        public ActionResult AddSpartan_BR_Actions_False_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("AddSpartan_BR_Actions_False_Detail");
        }

        [HttpGet]
        public ActionResult AddSpartan_BR_Modifications_Log(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("AddSpartan_BR_Modifications_Log");
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

            _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Business_RulePropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Business_RuleApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Business_Rules == null)
                result.Spartan_Business_Rules = new List<Spartan_Business_Rule>();

            var data = result.Spartan_Business_Rules.Select(m => new Spartan_Business_RuleGridModel
            {
                BusinessRuleId = m.BusinessRuleId
                ,Registration_Hour = m.Registration_Hour
                ,User_who_registers = m.User_who_registers
                ,Description = m.Description
                ,Object = m.Object
                ,Attribute = m.Attribute
                ,Implementation_Code = m.Implementation_Code

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_Business_RuleList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_Business_RuleList_" + DateTime.Now.ToString());
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

            _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Business_RulePropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Business_RuleApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Business_Rules == null)
                result.Spartan_Business_Rules = new List<Spartan_Business_Rule>();

            var data = result.Spartan_Business_Rules.Select(m => new Spartan_Business_RuleGridModel
            {
                BusinessRuleId = m.BusinessRuleId
                ,Registration_Hour = m.Registration_Hour
                ,User_who_registers = m.User_who_registers
                ,Description = m.Description
                ,Object = m.Object
                ,Attribute = m.Attribute
                ,Implementation_Code = m.Implementation_Code

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
