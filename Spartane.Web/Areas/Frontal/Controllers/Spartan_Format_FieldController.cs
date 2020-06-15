using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_Format_Field;
using Spartane.Core.Domain.Spartan_Format;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_Format_Field;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Field;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format;

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
    public class Spartan_Format_FieldController : Controller
    {
        #region "variable declaration"

        private ISpartan_Format_FieldService service = null;
        private ISpartan_Format_FieldApiConsumer _ISpartan_Format_FieldApiConsumer;
        private ISpartan_FormatApiConsumer _ISpartan_FormatApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Spartan_Format_FieldController(ISpartan_Format_FieldService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_Format_FieldApiConsumer Spartan_Format_FieldApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ISpartan_FormatApiConsumer Spartan_FormatApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_Format_FieldApiConsumer = Spartan_Format_FieldApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_Format_Field
        [ObjectAuth(ObjectId = (ModuleObjectId)31867, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31867);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Spartan_Format_Field/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)31867, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31867);
            ViewBag.Permission = permission;
            var varSpartan_Format_Field = new Spartan_Format_FieldModel();
			
            ViewBag.ObjectId = "31867";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || (Id.GetType() == typeof(int) && Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Format_FieldApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_Format_FieldData = _ISpartan_Format_FieldApiConsumer.GetByKeyComplete(Id).Resource.Spartan_Format_Fields[0];
                if (Spartan_Format_FieldData == null)
                    return HttpNotFound();

                varSpartan_Format_Field = new Spartan_Format_FieldModel
                {
                    FormatFieldId = (int)Spartan_Format_FieldData.FormatFieldId
                    ,Format = Spartan_Format_FieldData.Format
                    ,FormatFormat_Name =  (string)Spartan_Format_FieldData.Format_Spartan_Format.Format_Name
                    ,Field_Path = Spartan_Format_FieldData.Field_Path
                    ,Physical_Field_Name = Spartan_Format_FieldData.Physical_Field_Name
                    ,Logical_Field_Name = Spartan_Format_FieldData.Logical_Field_Name
                    ,Creation_Date = (Spartan_Format_FieldData.Creation_Date == null ? string.Empty : Convert.ToDateTime(Spartan_Format_FieldData.Creation_Date).ToString(ConfigurationProperty.DateFormat))
                    ,Creation_Hour = Spartan_Format_FieldData.Creation_Hour
                    ,Creation_User = Spartan_Format_FieldData.Creation_User
                    ,Properties = Spartan_Format_FieldData.Properties

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Formats = _ISpartan_FormatApiConsumer.SelAll(true);
            if (Spartan_Formats != null && Spartan_Formats.Resource != null)
                ViewBag.Spartan_Formats = Spartan_Formats.Resource.Select(m => new SelectListItem
                {
                    Text = m.Format_Name.ToString(), Value = Convert.ToString(m.FormatId)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_Format_Field);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_Format_Field(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31867);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_Format_FieldApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_Format_FieldModel varSpartan_Format_Field= new Spartan_Format_FieldModel();


            if (id.ToString() != "0")
            {
                var Spartan_Format_FieldsData = _ISpartan_Format_FieldApiConsumer.ListaSelAll(0, 1000, "FormatFieldId=" + id, "").Resource.Spartan_Format_Fields;
				
				if (Spartan_Format_FieldsData != null && Spartan_Format_FieldsData.Count > 0)
                {
					var Spartan_Format_FieldData = Spartan_Format_FieldsData.First();
					varSpartan_Format_Field= new Spartan_Format_FieldModel
					{
						FormatFieldId  = Spartan_Format_FieldData.FormatFieldId 
	                    ,Format = Spartan_Format_FieldData.Format
                    ,FormatFormat_Name =  (string)Spartan_Format_FieldData.Format_Spartan_Format.Format_Name
                    ,Field_Path = Spartan_Format_FieldData.Field_Path
                    ,Physical_Field_Name = Spartan_Format_FieldData.Physical_Field_Name
                    ,Logical_Field_Name = Spartan_Format_FieldData.Logical_Field_Name
                    ,Creation_Date = (Spartan_Format_FieldData.Creation_Date == null ? string.Empty : Convert.ToDateTime(Spartan_Format_FieldData.Creation_Date).ToString(ConfigurationProperty.DateFormat))
                    ,Creation_Hour = Spartan_Format_FieldData.Creation_Hour
                    ,Creation_User = Spartan_Format_FieldData.Creation_User
                    ,Properties = Spartan_Format_FieldData.Properties

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Formats = _ISpartan_FormatApiConsumer.SelAll(true);
            if (Spartan_Formats != null && Spartan_Formats.Resource != null)
                ViewBag.Spartan_Formats = Spartan_Formats.Resource.Select(m => new SelectListItem
                {
                    Text = m.Format_Name.ToString(), Value = Convert.ToString(m.FormatId)
                }).ToList();


            return PartialView("AddSpartan_Format_Field", varSpartan_Format_Field);
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
        public ActionResult GetSpartan_FormatAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_FormatApiConsumer.SelAll(false).Resource;
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
        public ActionResult ShowAdvanceFilter(Spartan_Format_FieldAdvanceSearchModel model)
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

            _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Formats = _ISpartan_FormatApiConsumer.SelAll(true);
            if (Spartan_Formats != null && Spartan_Formats.Resource != null)
                ViewBag.Spartan_Formats = Spartan_Formats.Resource.Select(m => new SelectListItem
                {
                    Text = m.Format_Name.ToString(), Value = Convert.ToString(m.FormatId)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Formats = _ISpartan_FormatApiConsumer.SelAll(true);
            if (Spartan_Formats != null && Spartan_Formats.Resource != null)
                ViewBag.Spartan_Formats = Spartan_Formats.Resource.Select(m => new SelectListItem
                {
                    Text = m.Format_Name.ToString(), Value = Convert.ToString(m.FormatId)
                }).ToList();


            var previousFiltersObj = new Spartan_Format_FieldAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Spartan_Format_FieldAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Spartan_Format_FieldAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Format_FieldPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_Format_FieldApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Format_Fields == null)
                result.Spartan_Format_Fields = new List<Spartan_Format_Field>();

            return Json(new
            {
                data = result.Spartan_Format_Fields.Select(m => new Spartan_Format_FieldGridModel
                    {
                    FormatFieldId = m.FormatFieldId
                        ,FormatFormat_Name = (string)m.Format_Spartan_Format.Format_Name
			,Field_Path = m.Field_Path
			,Physical_Field_Name = m.Physical_Field_Name
			,Logical_Field_Name = m.Logical_Field_Name
                        ,Creation_Date = (m.Creation_Date == null ? string.Empty : Convert.ToDateTime(m.Creation_Date).ToString(ConfigurationProperty.DateFormat))
			,Creation_Hour = m.Creation_Hour
			,Creation_User = m.Creation_User
			,Properties = m.Properties

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_Format_Field from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_Format_Field Entity</returns>
        public ActionResult GetSpartan_Format_FieldList(int sEcho, int iDisplayStart, int iDisplayLength)
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
            _ISpartan_Format_FieldApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_Format_FieldPropertyMapper());

            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True")
            {
                var advanceFilter =
                    (Spartan_Format_FieldAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            Spartan_Format_FieldPropertyMapper oSpartan_Format_FieldPropertyMapper = new Spartan_Format_FieldPropertyMapper();

            configuration.OrderByClause = oSpartan_Format_FieldPropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISpartan_Format_FieldApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Format_Fields == null)
                result.Spartan_Format_Fields = new List<Spartan_Format_Field>();

            return Json(new
            {
                aaData = result.Spartan_Format_Fields.Select(m => new Spartan_Format_FieldGridModel
            {
                    FormatFieldId = m.FormatFieldId
                        ,FormatFormat_Name = (string)m.Format_Spartan_Format.Format_Name
			,Field_Path = m.Field_Path
			,Physical_Field_Name = m.Physical_Field_Name
			,Logical_Field_Name = m.Logical_Field_Name
                        ,Creation_Date = (m.Creation_Date == null ? string.Empty : Convert.ToDateTime(m.Creation_Date).ToString(ConfigurationProperty.DateFormat))
			,Creation_Hour = m.Creation_Hour
			,Creation_User = m.Creation_User
			,Properties = m.Properties

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(Spartan_Format_FieldAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFormatFieldId) || !string.IsNullOrEmpty(filter.ToFormatFieldId))
            {
                if (!string.IsNullOrEmpty(filter.FromFormatFieldId))
                    where += " AND Spartan_Format_Field.FormatFieldId >= " + filter.FromFormatFieldId;
                if (!string.IsNullOrEmpty(filter.ToFormatFieldId))
                    where += " AND Spartan_Format_Field.FormatFieldId <= " + filter.ToFormatFieldId;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceFormat))
            {
                switch (filter.FormatFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Format.Format_Name LIKE '" + filter.AdvanceFormat + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Format.Format_Name LIKE '%" + filter.AdvanceFormat + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Format.Format_Name = '" + filter.AdvanceFormat + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Format.Format_Name LIKE '%" + filter.AdvanceFormat + "%'";
                        break;
                }
            }
            else if (filter.AdvanceFormatMultiple != null && filter.AdvanceFormatMultiple.Count() > 0)
            {
                var FormatIds = string.Join(",", filter.AdvanceFormatMultiple);

                where += " AND Spartan_Format_Field.Format In (" + FormatIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Field_Path))
            {
                switch (filter.Field_PathFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Format_Field.Field_Path LIKE '" + filter.Field_Path + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Format_Field.Field_Path LIKE '%" + filter.Field_Path + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Format_Field.Field_Path = '" + filter.Field_Path + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Format_Field.Field_Path LIKE '%" + filter.Field_Path + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Physical_Field_Name))
            {
                switch (filter.Physical_Field_NameFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Format_Field.Physical_Field_Name LIKE '" + filter.Physical_Field_Name + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Format_Field.Physical_Field_Name LIKE '%" + filter.Physical_Field_Name + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Format_Field.Physical_Field_Name = '" + filter.Physical_Field_Name + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Format_Field.Physical_Field_Name LIKE '%" + filter.Physical_Field_Name + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Logical_Field_Name))
            {
                switch (filter.Logical_Field_NameFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Format_Field.Logical_Field_Name LIKE '" + filter.Logical_Field_Name + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Format_Field.Logical_Field_Name LIKE '%" + filter.Logical_Field_Name + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Format_Field.Logical_Field_Name = '" + filter.Logical_Field_Name + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Format_Field.Logical_Field_Name LIKE '%" + filter.Logical_Field_Name + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromCreation_Date) || !string.IsNullOrEmpty(filter.ToCreation_Date))
            {
                var Creation_DateFrom = DateTime.ParseExact(filter.FromCreation_Date, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Creation_DateTo = DateTime.ParseExact(filter.ToCreation_Date, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromCreation_Date))
                    where += " AND Spartan_Format_Field.Creation_Date >= '" + Creation_DateFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToCreation_Date))
                    where += " AND Spartan_Format_Field.Creation_Date <= '" + Creation_DateTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromCreation_Hour) || !string.IsNullOrEmpty(filter.ToCreation_Hour))
            {
                if (!string.IsNullOrEmpty(filter.FromCreation_Hour))
                    where += " AND Convert(TIME,Spartan_Format_Field.Creation_Hour) >='" + filter.FromCreation_Hour + "'";
                if (!string.IsNullOrEmpty(filter.ToCreation_Hour))
                    where += " AND Convert(TIME,Spartan_Format_Field.Creation_Hour) <='" + filter.ToCreation_Hour + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromCreation_User) || !string.IsNullOrEmpty(filter.ToCreation_User))
            {
                if (!string.IsNullOrEmpty(filter.FromCreation_User))
                    where += " AND Spartan_Format_Field.Creation_User >= " + filter.FromCreation_User;
                if (!string.IsNullOrEmpty(filter.ToCreation_User))
                    where += " AND Spartan_Format_Field.Creation_User <= " + filter.ToCreation_User;
            }

            if (!string.IsNullOrEmpty(filter.Properties))
            {
                switch (filter.PropertiesFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Format_Field.Properties LIKE '" + filter.Properties + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Format_Field.Properties LIKE '%" + filter.Properties + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Format_Field.Properties = '" + filter.Properties + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Format_Field.Properties LIKE '%" + filter.Properties + "%'";
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



        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Format_FieldApiConsumer.SetAuthHeader(_tokenManager.Token);

                //Spartan_Format_Field varSpartan_Format_Field = null;
                if (id.ToString() != "0")
                {

                }
                var result = _ISpartan_Format_FieldApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_Format_FieldModel varSpartan_Format_Field)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_Format_FieldApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Spartan_Format_FieldInfo = new Spartan_Format_Field
                    {
                        FormatFieldId = varSpartan_Format_Field.FormatFieldId
                        ,Format = varSpartan_Format_Field.Format
                        ,Field_Path = varSpartan_Format_Field.Field_Path
                        ,Physical_Field_Name = varSpartan_Format_Field.Physical_Field_Name
                        ,Logical_Field_Name = varSpartan_Format_Field.Logical_Field_Name
                        ,Creation_Date = DateTime.ParseExact(varSpartan_Format_Field.Creation_Date, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider)
                        ,Creation_Hour = varSpartan_Format_Field.Creation_Hour
                        ,Creation_User = varSpartan_Format_Field.Creation_User
                        ,Properties = varSpartan_Format_Field.Properties

                    };

                    result = !IsNew ?
                        _ISpartan_Format_FieldApiConsumer.Update(Spartan_Format_FieldInfo, null, null).Resource.ToString() :
                         _ISpartan_Format_FieldApiConsumer.Insert(Spartan_Format_FieldInfo, null, null).Resource.ToString();

                    return Json(result, JsonRequestBehavior.AllowGet);
				}
				return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Spartan_Format_Field script
        /// </summary>
        /// <param name="oSpartan_Format_FieldElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_Format_FieldModuleAttributeList)
        {
            for (int i = 0; i < Spartan_Format_FieldModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_Format_FieldModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_Format_FieldModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_Format_FieldModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_Format_FieldModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_Format_FieldModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_Format_FieldModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Spartan_Format_FieldModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Spartan_Format_FieldModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Spartan_Format_FieldModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Spartan_Format_FieldModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strSpartan_Format_FieldScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Format_Field.js")))
            {
                strSpartan_Format_FieldScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_Format_Field element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_Format_FieldModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_Format_FieldScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_Format_FieldScript.Substring(indexOfArray, strSpartan_Format_FieldScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_Format_FieldModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_Format_FieldModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_Format_FieldScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strSpartan_Format_FieldScript.Substring(indexOfArrayHistory, strSpartan_Format_FieldScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strSpartan_Format_FieldScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_Format_FieldScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_Format_FieldScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Spartan_Format_FieldModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strSpartan_Format_FieldScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_Format_FieldScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_Format_FieldScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_Format_FieldScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_Format_Field.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_Format_Field.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Format_Field.js")))
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
        public ActionResult Spartan_Format_FieldPropertyBag()
        {
            return PartialView("Spartan_Format_FieldPropertyBag", "Spartan_Format_Field");
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

            _ISpartan_Format_FieldApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Format_FieldPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Format_FieldApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Format_Fields == null)
                result.Spartan_Format_Fields = new List<Spartan_Format_Field>();

            var data = result.Spartan_Format_Fields.Select(m => new Spartan_Format_FieldGridModel
            {
                FormatFieldId = m.FormatFieldId
                ,Field_Path = m.Field_Path
                ,Physical_Field_Name = m.Physical_Field_Name
                ,Logical_Field_Name = m.Logical_Field_Name
                ,Creation_Hour = m.Creation_Hour
                ,Creation_User = m.Creation_User
                ,Properties = m.Properties

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_Format_FieldList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_Format_FieldList_" + DateTime.Now.ToString());
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

            _ISpartan_Format_FieldApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Format_FieldPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Format_FieldApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Format_Fields == null)
                result.Spartan_Format_Fields = new List<Spartan_Format_Field>();

            var data = result.Spartan_Format_Fields.Select(m => new Spartan_Format_FieldGridModel
            {
                FormatFieldId = m.FormatFieldId
                ,Field_Path = m.Field_Path
                ,Physical_Field_Name = m.Physical_Field_Name
                ,Logical_Field_Name = m.Logical_Field_Name
                ,Creation_Hour = m.Creation_Hour
                ,Creation_User = m.Creation_User
                ,Properties = m.Properties

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
