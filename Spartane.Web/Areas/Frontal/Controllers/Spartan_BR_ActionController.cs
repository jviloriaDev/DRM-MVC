using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_BR_Action;
using Spartane.Core.Domain.Spartan_BR_Action_Classification;
using Spartane.Core.Domain.Spartan_BR_Action_Configuration_Detail;
using Spartane.Core.Domain.Spartan_BR_Action_Param_Type;

using Spartane.Core.Domain.Spartan_BR_Attribute_Restrictions_Detail;
using Spartane.Core.Domain.Spartan_Attribute_Type;
using Spartane.Core.Domain.Spartan_Attribute_Control_Type;

using Spartane.Core.Domain.Spartan_BR_Operation_Restrictions_Detail;
using Spartane.Core.Domain.Spartan_BR_Operation;

using Spartane.Core.Domain.Spartan_BR_Event_Restrictions_Detail;
using Spartane.Core.Domain.Spartan_BR_Process_Event;


using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_BR_Action;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Classification;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Configuration_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Param_Type;

using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Attribute_Restrictions_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Attribute_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Attribute_Control_Type;

using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operation_Restrictions_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operation;

using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Event_Restrictions_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event;


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
    public class Spartan_BR_ActionController : Controller
    {
        #region "variable declaration"

        private ISpartan_BR_ActionService service = null;
        private ISpartan_BR_ActionApiConsumer _ISpartan_BR_ActionApiConsumer;
        private ISpartan_BR_Action_ClassificationApiConsumer _ISpartan_BR_Action_ClassificationApiConsumer;
        private ISpartan_BR_Action_Configuration_DetailApiConsumer _ISpartan_BR_Action_Configuration_DetailApiConsumer;
        private ISpartan_BR_Action_Param_TypeApiConsumer _ISpartan_BR_Action_Param_TypeApiConsumer;

        private ISpartan_BR_Attribute_Restrictions_DetailApiConsumer _ISpartan_BR_Attribute_Restrictions_DetailApiConsumer;
        private ISpartan_Attribute_TypeApiConsumer _ISpartan_Attribute_TypeApiConsumer;
        private ISpartan_Attribute_Control_TypeApiConsumer _ISpartan_Attribute_Control_TypeApiConsumer;

        private ISpartan_BR_Operation_Restrictions_DetailApiConsumer _ISpartan_BR_Operation_Restrictions_DetailApiConsumer;
        private ISpartan_BR_OperationApiConsumer _ISpartan_BR_OperationApiConsumer;

        private ISpartan_BR_Event_Restrictions_DetailApiConsumer _ISpartan_BR_Event_Restrictions_DetailApiConsumer;
        private ISpartan_BR_Process_EventApiConsumer _ISpartan_BR_Process_EventApiConsumer;


        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Spartan_BR_ActionController(ISpartan_BR_ActionService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_BR_ActionApiConsumer Spartan_BR_ActionApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer , ISpartan_BR_Action_ClassificationApiConsumer Spartan_BR_Action_ClassificationApiConsumer , ISpartan_BR_Action_Configuration_DetailApiConsumer Spartan_BR_Action_Configuration_DetailApiConsumer , ISpartan_BR_Action_Param_TypeApiConsumer Spartan_BR_Action_Param_TypeApiConsumer  , ISpartan_BR_Attribute_Restrictions_DetailApiConsumer Spartan_BR_Attribute_Restrictions_DetailApiConsumer , ISpartan_Attribute_TypeApiConsumer Spartan_Attribute_TypeApiConsumer , ISpartan_Attribute_Control_TypeApiConsumer Spartan_Attribute_Control_TypeApiConsumer  , ISpartan_BR_Operation_Restrictions_DetailApiConsumer Spartan_BR_Operation_Restrictions_DetailApiConsumer , ISpartan_BR_OperationApiConsumer Spartan_BR_OperationApiConsumer  , ISpartan_BR_Event_Restrictions_DetailApiConsumer Spartan_BR_Event_Restrictions_DetailApiConsumer , ISpartan_BR_Process_EventApiConsumer Spartan_BR_Process_EventApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_BR_ActionApiConsumer = Spartan_BR_ActionApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_BR_Action_ClassificationApiConsumer = Spartan_BR_Action_ClassificationApiConsumer;
            this._ISpartan_BR_Action_Configuration_DetailApiConsumer = Spartan_BR_Action_Configuration_DetailApiConsumer;
            this._ISpartan_BR_Action_Param_TypeApiConsumer = Spartan_BR_Action_Param_TypeApiConsumer;

            this._ISpartan_BR_Attribute_Restrictions_DetailApiConsumer = Spartan_BR_Attribute_Restrictions_DetailApiConsumer;
            this._ISpartan_Attribute_TypeApiConsumer = Spartan_Attribute_TypeApiConsumer;
            this._ISpartan_Attribute_Control_TypeApiConsumer = Spartan_Attribute_Control_TypeApiConsumer;

            this._ISpartan_BR_Operation_Restrictions_DetailApiConsumer = Spartan_BR_Operation_Restrictions_DetailApiConsumer;
            this._ISpartan_BR_OperationApiConsumer = Spartan_BR_OperationApiConsumer;

            this._ISpartan_BR_Event_Restrictions_DetailApiConsumer = Spartan_BR_Event_Restrictions_DetailApiConsumer;
            this._ISpartan_BR_Process_EventApiConsumer = Spartan_BR_Process_EventApiConsumer;


        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_BR_Action
        [ObjectAuth(ObjectId = (ModuleObjectId)140, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 140);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Spartan_BR_Action/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)140, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 140);
            ViewBag.Permission = permission;
            var varSpartan_BR_Action = new Spartan_BR_ActionModel();

            var permissionSpartan_BR_Action_Configuration_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 151);
            ViewBag.PermissionSpartan_BR_Action_Configuration_Detail = permissionSpartan_BR_Action_Configuration_Detail;
            var permissionSpartan_BR_Attribute_Restrictions_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 152);
            ViewBag.PermissionSpartan_BR_Attribute_Restrictions_Detail = permissionSpartan_BR_Attribute_Restrictions_Detail;
            var permissionSpartan_BR_Operation_Restrictions_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 153);
            ViewBag.PermissionSpartan_BR_Operation_Restrictions_Detail = permissionSpartan_BR_Operation_Restrictions_Detail;
            var permissionSpartan_BR_Event_Restrictions_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 154);
            ViewBag.PermissionSpartan_BR_Event_Restrictions_Detail = permissionSpartan_BR_Event_Restrictions_Detail;


            if (Convert.ToString(Id) != "0" && Convert.ToString(Id) != "-1")
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_ActionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_BR_ActionData = _ISpartan_BR_ActionApiConsumer.GetByKeyComplete(Id).Resource.Spartan_BR_Actions[0];
                if (Spartan_BR_ActionData == null)
                    return HttpNotFound();

                varSpartan_BR_Action = new Spartan_BR_ActionModel
                {
                    ActionId = Spartan_BR_ActionData.ActionId
                    ,Description = Spartan_BR_ActionData.Description
                    ,Classification = Spartan_BR_ActionData.Classification
                    ,ClassificationDescription =  Spartan_BR_ActionData.Classification_Spartan_BR_Action_Classification.Description
                    ,Implementation_Code = Spartan_BR_ActionData.Implementation_Code

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_BR_Action_ClassificationApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Action_Classifications = _ISpartan_BR_Action_ClassificationApiConsumer.SelAll(true);
            if (Spartan_BR_Action_Classifications != null && Spartan_BR_Action_Classifications.Resource != null)
                ViewBag.Spartan_BR_Action_Classifications = Spartan_BR_Action_Classifications.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.ClassificationId)
                }).ToList();


            ViewBag.Consult = consult == 1;
            return View(varSpartan_BR_Action);
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
        public ActionResult GetSpartan_BR_Action_ClassificationAll()
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




        [HttpPost]
        public JsonResult ClearAdvanceFilter()
        {
            Session["AdvanceSearch"] = null;
            return Json(new { result = Session["AdvanceSearch"] == null }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ShowAdvanceFilter(Spartan_BR_ActionAdvanceSearchModel model)
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

            _ISpartan_BR_Action_ClassificationApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Action_Classifications = _ISpartan_BR_Action_ClassificationApiConsumer.SelAll(true);
            if (Spartan_BR_Action_Classifications != null && Spartan_BR_Action_Classifications.Resource != null)
                ViewBag.Spartan_BR_Action_Classifications = Spartan_BR_Action_Classifications.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.ClassificationId)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_BR_Action_ClassificationApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Action_Classifications = _ISpartan_BR_Action_ClassificationApiConsumer.SelAll(true);
            if (Spartan_BR_Action_Classifications != null && Spartan_BR_Action_Classifications.Resource != null)
                ViewBag.Spartan_BR_Action_Classifications = Spartan_BR_Action_Classifications.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.ClassificationId)
                }).ToList();


            var previousFiltersObj = new Spartan_BR_ActionAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Spartan_BR_ActionAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Spartan_BR_ActionAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_BR_ActionPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_BR_ActionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Actions == null)
                result.Spartan_BR_Actions = new List<Spartan_BR_Action>();

            return Json(new
            {
                data = result.Spartan_BR_Actions.Select(m => new Spartan_BR_ActionGridModel
                    {
                    ActionId = m.ActionId
			,Description = m.Description
                        ,ClassificationDescription = m.Classification_Spartan_BR_Action_Classification.Description
			,Implementation_Code = m.Implementation_Code

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_BR_Action from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_BR_Action Entity</returns>
        public ActionResult GetSpartan_BR_ActionList(int sEcho, int iDisplayStart, int iDisplayLength)
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
            _ISpartan_BR_ActionApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_BR_ActionPropertyMapper());

            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True")
            {
                var advanceFilter =
                    (Spartan_BR_ActionAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            Spartan_BR_ActionPropertyMapper oSpartan_BR_ActionPropertyMapper = new Spartan_BR_ActionPropertyMapper();

            configuration.OrderByClause = oSpartan_BR_ActionPropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISpartan_BR_ActionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Actions == null)
                result.Spartan_BR_Actions = new List<Spartan_BR_Action>();

            return Json(new
            {
                aaData = result.Spartan_BR_Actions.Select(m => new Spartan_BR_ActionGridModel
            {
                    ActionId = m.ActionId
			,Description = m.Description
                        ,ClassificationDescription = m.Classification_Spartan_BR_Action_Classification.Description
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






        [NonAction]
        public string GetAdvanceFilter(Spartan_BR_ActionAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromActionId) || !string.IsNullOrEmpty(filter.ToActionId))
            {
                if (!string.IsNullOrEmpty(filter.FromActionId))
                    where += " AND Spartan_BR_Action.ActionId >= " + filter.FromActionId;
                if (!string.IsNullOrEmpty(filter.ToActionId))
                    where += " AND Spartan_BR_Action.ActionId <= " + filter.ToActionId;
            }

            if (!string.IsNullOrEmpty(filter.Description))
            {
                switch (filter.DescriptionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_BR_Action.Description LIKE '" + filter.Description + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_BR_Action.Description LIKE '%" + filter.Description + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_BR_Action.Description = '" + filter.Description + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_BR_Action.Description LIKE '%" + filter.Description + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceClassification))
            {
                switch (filter.ClassificationFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_BR_Action_Classification.Description LIKE '" + filter.AdvanceClassification + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_BR_Action_Classification.Description LIKE '%" + filter.AdvanceClassification + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_BR_Action_Classification.Description = '" + filter.AdvanceClassification + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_BR_Action_Classification.Description LIKE '%" + filter.AdvanceClassification + "%'";
                        break;
                }
            }
            else if (filter.AdvanceClassificationMultiple != null && filter.AdvanceClassificationMultiple.Count() > 0)
            {
                var ClassificationIds = string.Join(",", filter.AdvanceClassificationMultiple);

                where += " AND Spartan_BR_Action.Classification In (" + ClassificationIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Implementation_Code))
            {
                switch (filter.Implementation_CodeFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_BR_Action.Implementation_Code LIKE '" + filter.Implementation_Code + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_BR_Action.Implementation_Code LIKE '%" + filter.Implementation_Code + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_BR_Action.Implementation_Code = '" + filter.Implementation_Code + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_BR_Action.Implementation_Code LIKE '%" + filter.Implementation_Code + "%'";
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

        public ActionResult GetSpartan_BR_Action_Configuration_Detail(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_Action_Configuration_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Action_Configuration_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            var result = _ISpartan_BR_Action_Configuration_DetailApiConsumer.ListaSelAll(start, pageSize, "Spartan_BR_Action_Configuration_Detail.Action=" + RelationId,"").Resource;
            if (result.Spartan_BR_Action_Configuration_Details == null)
                result.Spartan_BR_Action_Configuration_Details = new List<Spartan_BR_Action_Configuration_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Action_Configuration_Details.Select(m => new Spartan_BR_Action_Configuration_DetailGridModel
                {
                    ActionConfigurationId = m.ActionConfigurationId
			,Parameter_Name = m.Parameter_Name
                        ,Parameter_Type = m.Parameter_Type
                        ,Parameter_TypeDescription = m.Parameter_Type_Spartan_BR_Action_Param_Type.Description

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_BR_Attribute_Restrictions_Detail(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_Attribute_Restrictions_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Attribute_Restrictions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            var result = _ISpartan_BR_Attribute_Restrictions_DetailApiConsumer.ListaSelAll(start, pageSize, "Spartan_BR_Attribute_Restrictions_Detail.Action=" + RelationId,"").Resource;
            if (result.Spartan_BR_Attribute_Restrictions_Details == null)
                result.Spartan_BR_Attribute_Restrictions_Details = new List<Spartan_BR_Attribute_Restrictions_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Attribute_Restrictions_Details.Select(m => new Spartan_BR_Attribute_Restrictions_DetailGridModel
                {
                    RestrictionId = m.RestrictionId
                        ,Attribute_Type = m.Attribute_Type
                        ,Attribute_TypeDescription = m.Attribute_Type_Spartan_Attribute_Type.Description
                        ,Control_Type = m.Control_Type
                        ,Control_TypeDescription = m.Control_Type_Spartan_Attribute_Control_Type.Description

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_BR_Operation_Restrictions_Detail(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_Operation_Restrictions_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Operation_Restrictions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            var result = _ISpartan_BR_Operation_Restrictions_DetailApiConsumer.ListaSelAll(start, pageSize, "Spartan_BR_Operation_Restrictions_Detail.Action=" + RelationId,"").Resource;
            if (result.Spartan_BR_Operation_Restrictions_Details == null)
                result.Spartan_BR_Operation_Restrictions_Details = new List<Spartan_BR_Operation_Restrictions_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Operation_Restrictions_Details.Select(m => new Spartan_BR_Operation_Restrictions_DetailGridModel
                {
                    RestrictionId = m.RestrictionId
                        ,Operation = m.Operation
                        ,OperationDescription = m.Operation_Spartan_BR_Operation.Description

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_BR_Event_Restrictions_Detail(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_Event_Restrictions_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Event_Restrictions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            var result = _ISpartan_BR_Event_Restrictions_DetailApiConsumer.ListaSelAll(start, pageSize, "Spartan_BR_Event_Restrictions_Detail.Action=" + RelationId,"").Resource;
            if (result.Spartan_BR_Event_Restrictions_Details == null)
                result.Spartan_BR_Event_Restrictions_Details = new List<Spartan_BR_Event_Restrictions_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Event_Restrictions_Details.Select(m => new Spartan_BR_Event_Restrictions_DetailGridModel
                {
                    RestrictionId = m.RestrictionId
                        ,Process_Event = m.Process_Event
                        ,Process_EventDescription = m.Process_Event_Spartan_BR_Process_Event.Description

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
                _ISpartan_BR_ActionApiConsumer.SetAuthHeader(_tokenManager.Token);

                //Spartan_BR_Action varSpartan_BR_Action = null;
                if (id.ToString() != "0")
                {
                    _ISpartan_BR_Action_Configuration_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    var Spartan_BR_Action_Configuration_DetailInfo =
                        _ISpartan_BR_Action_Configuration_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Action_Configuration_Detail.Action=" + id,"").Resource;

                    if (Spartan_BR_Action_Configuration_DetailInfo.Spartan_BR_Action_Configuration_Details.Count > 0)
                    {
                        var resultSpartan_BR_Action_Configuration_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_BR_Action_Configuration_DetailItem in Spartan_BR_Action_Configuration_DetailInfo.Spartan_BR_Action_Configuration_Details)
                            resultSpartan_BR_Action_Configuration_Detail = resultSpartan_BR_Action_Configuration_Detail
                                              && _ISpartan_BR_Action_Configuration_DetailApiConsumer.Delete(Spartan_BR_Action_Configuration_DetailItem.ActionConfigurationId, null,null).Resource;

                        if (!resultSpartan_BR_Action_Configuration_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_BR_Attribute_Restrictions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    var Spartan_BR_Attribute_Restrictions_DetailInfo =
                        _ISpartan_BR_Attribute_Restrictions_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Attribute_Restrictions_Detail.Action=" + id,"").Resource;

                    if (Spartan_BR_Attribute_Restrictions_DetailInfo.Spartan_BR_Attribute_Restrictions_Details.Count > 0)
                    {
                        var resultSpartan_BR_Attribute_Restrictions_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_BR_Attribute_Restrictions_DetailItem in Spartan_BR_Attribute_Restrictions_DetailInfo.Spartan_BR_Attribute_Restrictions_Details)
                            resultSpartan_BR_Attribute_Restrictions_Detail = resultSpartan_BR_Attribute_Restrictions_Detail
                                              && _ISpartan_BR_Attribute_Restrictions_DetailApiConsumer.Delete(Spartan_BR_Attribute_Restrictions_DetailItem.RestrictionId, null,null).Resource;

                        if (!resultSpartan_BR_Attribute_Restrictions_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_BR_Operation_Restrictions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    var Spartan_BR_Operation_Restrictions_DetailInfo =
                        _ISpartan_BR_Operation_Restrictions_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Operation_Restrictions_Detail.Action=" + id,"").Resource;

                    if (Spartan_BR_Operation_Restrictions_DetailInfo.Spartan_BR_Operation_Restrictions_Details.Count > 0)
                    {
                        var resultSpartan_BR_Operation_Restrictions_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_BR_Operation_Restrictions_DetailItem in Spartan_BR_Operation_Restrictions_DetailInfo.Spartan_BR_Operation_Restrictions_Details)
                            resultSpartan_BR_Operation_Restrictions_Detail = resultSpartan_BR_Operation_Restrictions_Detail
                                              && _ISpartan_BR_Operation_Restrictions_DetailApiConsumer.Delete(Spartan_BR_Operation_Restrictions_DetailItem.RestrictionId, null,null).Resource;

                        if (!resultSpartan_BR_Operation_Restrictions_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_BR_Event_Restrictions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    var Spartan_BR_Event_Restrictions_DetailInfo =
                        _ISpartan_BR_Event_Restrictions_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Event_Restrictions_Detail.Action=" + id,"").Resource;

                    if (Spartan_BR_Event_Restrictions_DetailInfo.Spartan_BR_Event_Restrictions_Details.Count > 0)
                    {
                        var resultSpartan_BR_Event_Restrictions_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_BR_Event_Restrictions_DetailItem in Spartan_BR_Event_Restrictions_DetailInfo.Spartan_BR_Event_Restrictions_Details)
                            resultSpartan_BR_Event_Restrictions_Detail = resultSpartan_BR_Event_Restrictions_Detail
                                              && _ISpartan_BR_Event_Restrictions_DetailApiConsumer.Delete(Spartan_BR_Event_Restrictions_DetailItem.RestrictionId, null,null).Resource;

                        if (!resultSpartan_BR_Event_Restrictions_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _ISpartan_BR_ActionApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(Spartan_BR_ActionModel varSpartan_BR_Action)
        {
            try
            {
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_BR_ActionApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "0";
                    var Spartan_BR_ActionInfo = new Spartan_BR_Action
                    {
                        ActionId = varSpartan_BR_Action.ActionId
                        ,Description = varSpartan_BR_Action.Description
                        ,Classification = varSpartan_BR_Action.Classification
                        ,Implementation_Code = varSpartan_BR_Action.Implementation_Code

                    };

                    result = varSpartan_BR_Action.ActionId.ToString() != "0" ?
                        _ISpartan_BR_ActionApiConsumer.Update(Spartan_BR_ActionInfo, null, null).Resource.ToString() :
                         _ISpartan_BR_ActionApiConsumer.Insert(Spartan_BR_ActionInfo, null, null).Resource.ToString();

                    if (varSpartan_BR_Action.ActionId.ToString() != "0")
                        result = varSpartan_BR_Action.ActionId.ToString();

                    return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_BR_Action_Configuration_Detail(int MasterId, int referenceId, List<Spartan_BR_Action_Configuration_DetailGridModelPost> Spartan_BR_Action_Configuration_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_BR_Action_Configuration_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_BR_Action_Configuration_DetailData = _ISpartan_BR_Action_Configuration_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Action_Configuration_Detail.Action=" + referenceId,"").Resource;
                if (Spartan_BR_Action_Configuration_DetailData == null || Spartan_BR_Action_Configuration_DetailData.Spartan_BR_Action_Configuration_Details.Count == 0)
                    return true;

                var result = true;

                Spartan_BR_Action_Configuration_DetailGridModelPost modelDataToChange = null;
                var insertId = 0;
                foreach (var varSpartan_BR_Action_Configuration_Detail in Spartan_BR_Action_Configuration_DetailData.Spartan_BR_Action_Configuration_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    insertId = 0;
                    modelDataToChange = null;
                    Spartan_BR_Action_Configuration_Detail Spartan_BR_Action_Configuration_Detail1 = varSpartan_BR_Action_Configuration_Detail;

                    if (Spartan_BR_Action_Configuration_DetailItems != null && Spartan_BR_Action_Configuration_DetailItems.Any(m => m.ActionConfigurationId == Spartan_BR_Action_Configuration_Detail1.ActionConfigurationId))
                    {
                        modelDataToChange = Spartan_BR_Action_Configuration_DetailItems.FirstOrDefault(m => m.ActionConfigurationId == Spartan_BR_Action_Configuration_Detail1.ActionConfigurationId);
                    }
                    //Chaning Id Value
                    varSpartan_BR_Action_Configuration_Detail.Action = MasterId;
                    insertId = _ISpartan_BR_Action_Configuration_DetailApiConsumer.Insert(varSpartan_BR_Action_Configuration_Detail,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.ActionConfigurationId = insertId;

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
        public ActionResult PostSpartan_BR_Action_Configuration_Detail(List<Spartan_BR_Action_Configuration_DetailGridModelPost> Spartan_BR_Action_Configuration_DetailItems, int MasterId, int referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_BR_Action_Configuration_Detail(MasterId, referenceId, Spartan_BR_Action_Configuration_DetailItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_BR_Action_Configuration_DetailItems != null && Spartan_BR_Action_Configuration_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Action_Configuration_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_BR_Action_Configuration_DetailItem in Spartan_BR_Action_Configuration_DetailItems)
                    {

                        //Removal Request
                        if (Spartan_BR_Action_Configuration_DetailItem.Removed)
                        {
                            result = result && _ISpartan_BR_Action_Configuration_DetailApiConsumer.Delete(Spartan_BR_Action_Configuration_DetailItem.ActionConfigurationId, null,null).Resource;
                            continue;
                        }

                        var Spartan_BR_Action_Configuration_DetailData = new Spartan_BR_Action_Configuration_Detail
                        {
                            Action = MasterId
                            ,ActionConfigurationId = Spartan_BR_Action_Configuration_DetailItem.ActionConfigurationId
                            ,Parameter_Name = Spartan_BR_Action_Configuration_DetailItem.Parameter_Name
                            ,Parameter_Type = (Convert.ToInt32(Spartan_BR_Action_Configuration_DetailItem.Parameter_Type) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_BR_Action_Configuration_DetailItem.Parameter_Type))

                        };

                        var resultId = Spartan_BR_Action_Configuration_DetailItem.ActionConfigurationId > 0
                           ? _ISpartan_BR_Action_Configuration_DetailApiConsumer.Update(Spartan_BR_Action_Configuration_DetailData,null,null).Resource
                           : _ISpartan_BR_Action_Configuration_DetailApiConsumer.Insert(Spartan_BR_Action_Configuration_DetailData,null,null).Resource;

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
        public ActionResult GetSpartan_BR_Action_Configuration_Detail_Spartan_BR_Action_Param_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Action_Param_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Action_Param_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_BR_Attribute_Restrictions_Detail(int MasterId, int referenceId, List<Spartan_BR_Attribute_Restrictions_DetailGridModelPost> Spartan_BR_Attribute_Restrictions_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_BR_Attribute_Restrictions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_BR_Attribute_Restrictions_DetailData = _ISpartan_BR_Attribute_Restrictions_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Attribute_Restrictions_Detail.Action=" + referenceId,"").Resource;
                if (Spartan_BR_Attribute_Restrictions_DetailData == null || Spartan_BR_Attribute_Restrictions_DetailData.Spartan_BR_Attribute_Restrictions_Details.Count == 0)
                    return true;

                var result = true;

                Spartan_BR_Attribute_Restrictions_DetailGridModelPost modelDataToChange = null;
                var insertId = 0;
                foreach (var varSpartan_BR_Attribute_Restrictions_Detail in Spartan_BR_Attribute_Restrictions_DetailData.Spartan_BR_Attribute_Restrictions_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    insertId = 0;
                    modelDataToChange = null;
                    Spartan_BR_Attribute_Restrictions_Detail Spartan_BR_Attribute_Restrictions_Detail1 = varSpartan_BR_Attribute_Restrictions_Detail;

                    if (Spartan_BR_Attribute_Restrictions_DetailItems != null && Spartan_BR_Attribute_Restrictions_DetailItems.Any(m => m.RestrictionId == Spartan_BR_Attribute_Restrictions_Detail1.RestrictionId))
                    {
                        modelDataToChange = Spartan_BR_Attribute_Restrictions_DetailItems.FirstOrDefault(m => m.RestrictionId == Spartan_BR_Attribute_Restrictions_Detail1.RestrictionId);
                    }
                    //Chaning Id Value
                    varSpartan_BR_Attribute_Restrictions_Detail.Action = MasterId;
                    insertId = _ISpartan_BR_Attribute_Restrictions_DetailApiConsumer.Insert(varSpartan_BR_Attribute_Restrictions_Detail,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.RestrictionId = insertId;

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
        public ActionResult PostSpartan_BR_Attribute_Restrictions_Detail(List<Spartan_BR_Attribute_Restrictions_DetailGridModelPost> Spartan_BR_Attribute_Restrictions_DetailItems, int MasterId, int referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_BR_Attribute_Restrictions_Detail(MasterId, referenceId, Spartan_BR_Attribute_Restrictions_DetailItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_BR_Attribute_Restrictions_DetailItems != null && Spartan_BR_Attribute_Restrictions_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Attribute_Restrictions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_BR_Attribute_Restrictions_DetailItem in Spartan_BR_Attribute_Restrictions_DetailItems)
                    {

                        //Removal Request
                        if (Spartan_BR_Attribute_Restrictions_DetailItem.Removed)
                        {
                            result = result && _ISpartan_BR_Attribute_Restrictions_DetailApiConsumer.Delete(Spartan_BR_Attribute_Restrictions_DetailItem.RestrictionId, null,null).Resource;
                            continue;
                        }

                        var Spartan_BR_Attribute_Restrictions_DetailData = new Spartan_BR_Attribute_Restrictions_Detail
                        {
                            Action = MasterId
                            ,RestrictionId = Spartan_BR_Attribute_Restrictions_DetailItem.RestrictionId
                            ,Attribute_Type = (Convert.ToInt32(Spartan_BR_Attribute_Restrictions_DetailItem.Attribute_Type) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_BR_Attribute_Restrictions_DetailItem.Attribute_Type))
                            ,Control_Type = (Convert.ToInt16(Spartan_BR_Attribute_Restrictions_DetailItem.Control_Type) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Attribute_Restrictions_DetailItem.Control_Type))

                        };

                        var resultId = Spartan_BR_Attribute_Restrictions_DetailItem.RestrictionId > 0
                           ? _ISpartan_BR_Attribute_Restrictions_DetailApiConsumer.Update(Spartan_BR_Attribute_Restrictions_DetailData,null,null).Resource
                           : _ISpartan_BR_Attribute_Restrictions_DetailApiConsumer.Insert(Spartan_BR_Attribute_Restrictions_DetailData,null,null).Resource;

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
        public ActionResult GetSpartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Attribute_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Attribute_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_BR_Attribute_Restrictions_Detail_Spartan_Attribute_Control_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Attribute_Control_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Attribute_Control_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_BR_Operation_Restrictions_Detail(int MasterId, int referenceId, List<Spartan_BR_Operation_Restrictions_DetailGridModelPost> Spartan_BR_Operation_Restrictions_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_BR_Operation_Restrictions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_BR_Operation_Restrictions_DetailData = _ISpartan_BR_Operation_Restrictions_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Operation_Restrictions_Detail.Action=" + referenceId,"").Resource;
                if (Spartan_BR_Operation_Restrictions_DetailData == null || Spartan_BR_Operation_Restrictions_DetailData.Spartan_BR_Operation_Restrictions_Details.Count == 0)
                    return true;

                var result = true;

                Spartan_BR_Operation_Restrictions_DetailGridModelPost modelDataToChange = null;
                var insertId = 0;
                foreach (var varSpartan_BR_Operation_Restrictions_Detail in Spartan_BR_Operation_Restrictions_DetailData.Spartan_BR_Operation_Restrictions_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    insertId = 0;
                    modelDataToChange = null;
                    Spartan_BR_Operation_Restrictions_Detail Spartan_BR_Operation_Restrictions_Detail1 = varSpartan_BR_Operation_Restrictions_Detail;

                    if (Spartan_BR_Operation_Restrictions_DetailItems != null && Spartan_BR_Operation_Restrictions_DetailItems.Any(m => m.RestrictionId == Spartan_BR_Operation_Restrictions_Detail1.RestrictionId))
                    {
                        modelDataToChange = Spartan_BR_Operation_Restrictions_DetailItems.FirstOrDefault(m => m.RestrictionId == Spartan_BR_Operation_Restrictions_Detail1.RestrictionId);
                    }
                    //Chaning Id Value
                    varSpartan_BR_Operation_Restrictions_Detail.Action = MasterId;
                    insertId = _ISpartan_BR_Operation_Restrictions_DetailApiConsumer.Insert(varSpartan_BR_Operation_Restrictions_Detail,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.RestrictionId = insertId;

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
        public ActionResult PostSpartan_BR_Operation_Restrictions_Detail(List<Spartan_BR_Operation_Restrictions_DetailGridModelPost> Spartan_BR_Operation_Restrictions_DetailItems, int MasterId, int referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_BR_Operation_Restrictions_Detail(MasterId, referenceId, Spartan_BR_Operation_Restrictions_DetailItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_BR_Operation_Restrictions_DetailItems != null && Spartan_BR_Operation_Restrictions_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Operation_Restrictions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_BR_Operation_Restrictions_DetailItem in Spartan_BR_Operation_Restrictions_DetailItems)
                    {

                        //Removal Request
                        if (Spartan_BR_Operation_Restrictions_DetailItem.Removed)
                        {
                            result = result && _ISpartan_BR_Operation_Restrictions_DetailApiConsumer.Delete(Spartan_BR_Operation_Restrictions_DetailItem.RestrictionId, null,null).Resource;
                            continue;
                        }

                        var Spartan_BR_Operation_Restrictions_DetailData = new Spartan_BR_Operation_Restrictions_Detail
                        {
                            Action = MasterId
                            ,RestrictionId = Spartan_BR_Operation_Restrictions_DetailItem.RestrictionId
                            ,Operation = (Convert.ToInt16(Spartan_BR_Operation_Restrictions_DetailItem.Operation) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Operation_Restrictions_DetailItem.Operation))

                        };

                        var resultId = Spartan_BR_Operation_Restrictions_DetailItem.RestrictionId > 0
                           ? _ISpartan_BR_Operation_Restrictions_DetailApiConsumer.Update(Spartan_BR_Operation_Restrictions_DetailData,null,null).Resource
                           : _ISpartan_BR_Operation_Restrictions_DetailApiConsumer.Insert(Spartan_BR_Operation_Restrictions_DetailData,null,null).Resource;

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
        public ActionResult GetSpartan_BR_Operation_Restrictions_Detail_Spartan_BR_OperationAll()
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
        public bool CopySpartan_BR_Event_Restrictions_Detail(int MasterId, int referenceId, List<Spartan_BR_Event_Restrictions_DetailGridModelPost> Spartan_BR_Event_Restrictions_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_BR_Event_Restrictions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_BR_Event_Restrictions_DetailData = _ISpartan_BR_Event_Restrictions_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Event_Restrictions_Detail.Action=" + referenceId,"").Resource;
                if (Spartan_BR_Event_Restrictions_DetailData == null || Spartan_BR_Event_Restrictions_DetailData.Spartan_BR_Event_Restrictions_Details.Count == 0)
                    return true;

                var result = true;

                Spartan_BR_Event_Restrictions_DetailGridModelPost modelDataToChange = null;
                var insertId = 0;
                foreach (var varSpartan_BR_Event_Restrictions_Detail in Spartan_BR_Event_Restrictions_DetailData.Spartan_BR_Event_Restrictions_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    insertId = 0;
                    modelDataToChange = null;
                    Spartan_BR_Event_Restrictions_Detail Spartan_BR_Event_Restrictions_Detail1 = varSpartan_BR_Event_Restrictions_Detail;

                    if (Spartan_BR_Event_Restrictions_DetailItems != null && Spartan_BR_Event_Restrictions_DetailItems.Any(m => m.RestrictionId == Spartan_BR_Event_Restrictions_Detail1.RestrictionId))
                    {
                        modelDataToChange = Spartan_BR_Event_Restrictions_DetailItems.FirstOrDefault(m => m.RestrictionId == Spartan_BR_Event_Restrictions_Detail1.RestrictionId);
                    }
                    //Chaning Id Value
                    varSpartan_BR_Event_Restrictions_Detail.Action = MasterId;
                    insertId = _ISpartan_BR_Event_Restrictions_DetailApiConsumer.Insert(varSpartan_BR_Event_Restrictions_Detail,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.RestrictionId = insertId;

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
        public ActionResult PostSpartan_BR_Event_Restrictions_Detail(List<Spartan_BR_Event_Restrictions_DetailGridModelPost> Spartan_BR_Event_Restrictions_DetailItems, int MasterId, int referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_BR_Event_Restrictions_Detail(MasterId, referenceId, Spartan_BR_Event_Restrictions_DetailItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_BR_Event_Restrictions_DetailItems != null && Spartan_BR_Event_Restrictions_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Event_Restrictions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_BR_Event_Restrictions_DetailItem in Spartan_BR_Event_Restrictions_DetailItems)
                    {

                        //Removal Request
                        if (Spartan_BR_Event_Restrictions_DetailItem.Removed)
                        {
                            result = result && _ISpartan_BR_Event_Restrictions_DetailApiConsumer.Delete(Spartan_BR_Event_Restrictions_DetailItem.RestrictionId, null,null).Resource;
                            continue;
                        }

                        var Spartan_BR_Event_Restrictions_DetailData = new Spartan_BR_Event_Restrictions_Detail
                        {
                            Action = MasterId
                            ,RestrictionId = Spartan_BR_Event_Restrictions_DetailItem.RestrictionId
                            ,Process_Event = (Convert.ToInt16(Spartan_BR_Event_Restrictions_DetailItem.Process_Event) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Event_Restrictions_DetailItem.Process_Event))

                        };

                        var resultId = Spartan_BR_Event_Restrictions_DetailItem.RestrictionId > 0
                           ? _ISpartan_BR_Event_Restrictions_DetailApiConsumer.Update(Spartan_BR_Event_Restrictions_DetailData,null,null).Resource
                           : _ISpartan_BR_Event_Restrictions_DetailApiConsumer.Insert(Spartan_BR_Event_Restrictions_DetailData,null,null).Resource;

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
        public ActionResult GetSpartan_BR_Event_Restrictions_Detail_Spartan_BR_Process_EventAll()
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



        /// <summary>
        /// Write Element Array of Spartan_BR_Action script
        /// </summary>
        /// <param name="oSpartan_BR_ActionElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_BR_ActionModuleAttributeList)
        {
            for (int i = 0; i < Spartan_BR_ActionModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_BR_ActionModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_BR_ActionModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_BR_ActionModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_BR_ActionModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }

            for (int i = 0; i < Spartan_BR_ActionModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_BR_ActionModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
                {
                    Spartan_BR_ActionModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_BR_ActionModuleAttributeList.ChildModuleAttributeList[i].HelpText))
                {
                    Spartan_BR_ActionModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
                }
            }

            string strSpartan_BR_ActionScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Action.js")))
            {
                strSpartan_BR_ActionScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_BR_Action element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_BR_ActionModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_BR_ActionScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_BR_ActionScript.Substring(indexOfArray, strSpartan_BR_ActionScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_BR_ActionModuleAttributeList.ChildModuleAttributeList);

            int indexOfArrayHistory = strSpartan_BR_ActionScript.IndexOf("inpuElementChildArray");
            string splittedStringHistory = strSpartan_BR_ActionScript.Substring(indexOfArrayHistory, strSpartan_BR_ActionScript.Length - indexOfArrayHistory);
            int indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
            int endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;

            
            //string finalResponse = strSpartan_BR_ActionScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_BR_ActionScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_BR_ActionScript.Length - (endIndexOfMainElement + indexOfArray));
            string finalResponse = strSpartan_BR_ActionScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_BR_ActionScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_BR_ActionScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_BR_ActionScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Action.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Action.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Action.js")))
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
        public ActionResult Spartan_BR_ActionPropertyBag()
        {
            return PartialView("Spartan_BR_ActionPropertyBag", "Spartan_BR_Action");
        }

        [HttpGet]
        public ActionResult Spartan_BR_ActionBusinessRule()
        {
            return PartialView("Spartan_BR_ActionBusinessRule", "Spartan_BR_Action");
        }

        [HttpGet]
        public ActionResult AddBusinessRule(int BusinessRuleId = 0)
        {
            Spartan_BR_ActionBusinessRuleModel oSpartan_BR_ActionBusinessRuleModel = new Spartan_BR_ActionBusinessRuleModel();
            if (BusinessRuleId > 0)
            {
                oSpartan_BR_ActionBusinessRuleModel.BusinessRuleId = BusinessRuleId;
            }
            return PartialView("AddBusinessRule", oSpartan_BR_ActionBusinessRuleModel);
        }

        [HttpGet]
        public ActionResult AddSpartan_BR_Action_Configuration_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("AddSpartan_BR_Action_Configuration_Detail");
        }

        [HttpGet]
        public ActionResult AddSpartan_BR_Attribute_Restrictions_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("AddSpartan_BR_Attribute_Restrictions_Detail");
        }

        [HttpGet]
        public ActionResult AddSpartan_BR_Operation_Restrictions_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("AddSpartan_BR_Operation_Restrictions_Detail");
        }

        [HttpGet]
        public ActionResult AddSpartan_BR_Event_Restrictions_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("AddSpartan_BR_Event_Restrictions_Detail");
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

            _ISpartan_BR_ActionApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_BR_ActionPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_BR_ActionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Actions == null)
                result.Spartan_BR_Actions = new List<Spartan_BR_Action>();

            var data = result.Spartan_BR_Actions.Select(m => new Spartan_BR_ActionGridModel
            {
                ActionId = m.ActionId
                ,Description = m.Description
                ,Implementation_Code = m.Implementation_Code

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_BR_ActionList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_BR_ActionList_" + DateTime.Now.ToString());
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

            _ISpartan_BR_ActionApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_BR_ActionPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_BR_ActionApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Actions == null)
                result.Spartan_BR_Actions = new List<Spartan_BR_Action>();

            var data = result.Spartan_BR_Actions.Select(m => new Spartan_BR_ActionGridModel
            {
                ActionId = m.ActionId
                ,Description = m.Description
                ,Implementation_Code = m.Implementation_Code

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
