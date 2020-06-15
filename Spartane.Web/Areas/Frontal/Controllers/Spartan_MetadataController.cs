using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_Metadata;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_Metadata;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
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

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Spartan_MetadataController : Controller
    {
        #region "variable declaration"

        private ISpartan_MetadataService service = null;
        private ISpartan_MetadataApiConsumer _ISpartan_MetadataApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Spartan_MetadataController(ISpartan_MetadataService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_MetadataApiConsumer Spartan_MetadataApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_MetadataApiConsumer = Spartan_MetadataApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_Metadata
        [ObjectAuth(ObjectId = (ModuleObjectId)31756, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31756);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Spartan_Metadata/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)31756, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31756);
            ViewBag.Permission = permission;
            var varSpartan_Metadata = new Spartan_MetadataModel();
			
            ViewBag.ObjectId = "31756";
			ViewBag.Operation = "new";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || (Id.GetType() == typeof(int) && Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "edit";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_MetadataData = _ISpartan_MetadataApiConsumer.GetByKeyComplete(Id).Resource.Spartan_Metadatas[0];
                if (Spartan_MetadataData == null)
                    return HttpNotFound();

                varSpartan_Metadata = new Spartan_MetadataModel
                {
                    AttributeId = (int)Spartan_MetadataData.AttributeId
                    ,Class_Id = Spartan_MetadataData.Class_Id
                    ,Class_Name = Spartan_MetadataData.Class_Name
                    ,Object_Id = Spartan_MetadataData.Object_Id
                    ,Physical_Name = Spartan_MetadataData.Physical_Name
                    ,Logical_Name = Spartan_MetadataData.Logical_Name
                    ,Identifier_Type = Spartan_MetadataData.Identifier_Type
                    ,Attribute_Type = Spartan_MetadataData.Attribute_Type
                    ,Length = Spartan_MetadataData.Length
                    ,Decimals_Length = Spartan_MetadataData.Decimals_Length
                    ,Relation_Type = Spartan_MetadataData.Relation_Type
                    ,Related_Object_Id = Spartan_MetadataData.Related_Object_Id
                    ,Related_Class_Id = Spartan_MetadataData.Related_Class_Id
                    ,Related_Class_Name = Spartan_MetadataData.Related_Class_Name
                    ,Related_Class_Identifier = Spartan_MetadataData.Related_Class_Identifier
                    ,Related_Class_Description = Spartan_MetadataData.Related_Class_Description
                    ,Required = Spartan_MetadataData.Required.GetValueOrDefault()
                    ,DefaultValue = Spartan_MetadataData.DefaultValue
                    ,Visible = Spartan_MetadataData.Visible.GetValueOrDefault()
                    ,Help_Text = Spartan_MetadataData.Help_Text
                    ,Read_Only = Spartan_MetadataData.Read_Only.GetValueOrDefault()
                    ,ScreenOrder = Spartan_MetadataData.ScreenOrder
                    ,Control_Type = Spartan_MetadataData.Control_Type
                    ,Group_Name = Spartan_MetadataData.Group_Name

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "consult";
            return View(varSpartan_Metadata);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_Metadata(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 31756);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_MetadataModel varSpartan_Metadata= new Spartan_MetadataModel();


            if (id != 0)
            {
                var Spartan_MetadataData = _ISpartan_MetadataApiConsumer.GetByKey(id, true).Resource;

                varSpartan_Metadata= new Spartan_MetadataModel
                {
                    AttributeId  = (int)Spartan_MetadataData.AttributeId 
                    ,Class_Id = Spartan_MetadataData.Class_Id
                    ,Class_Name = Spartan_MetadataData.Class_Name
                    ,Object_Id = Spartan_MetadataData.Object_Id
                    ,Physical_Name = Spartan_MetadataData.Physical_Name
                    ,Logical_Name = Spartan_MetadataData.Logical_Name
                    ,Identifier_Type = Spartan_MetadataData.Identifier_Type
                    ,Attribute_Type = Spartan_MetadataData.Attribute_Type
                    ,Length = Spartan_MetadataData.Length
                    ,Decimals_Length = Spartan_MetadataData.Decimals_Length
                    ,Relation_Type = Spartan_MetadataData.Relation_Type
                    ,Related_Object_Id = Spartan_MetadataData.Related_Object_Id
                    ,Related_Class_Id = Spartan_MetadataData.Related_Class_Id
                    ,Related_Class_Name = Spartan_MetadataData.Related_Class_Name
                    ,Related_Class_Identifier = Spartan_MetadataData.Related_Class_Identifier
                    ,Related_Class_Description = Spartan_MetadataData.Related_Class_Description
                    ,Required = Spartan_MetadataData.Required.GetValueOrDefault()
                    ,DefaultValue = Spartan_MetadataData.DefaultValue
                    ,Visible = Spartan_MetadataData.Visible.GetValueOrDefault()
                    ,Help_Text = Spartan_MetadataData.Help_Text
                    ,Read_Only = Spartan_MetadataData.Read_Only.GetValueOrDefault()
                    ,ScreenOrder = Spartan_MetadataData.ScreenOrder
                    ,Control_Type = Spartan_MetadataData.Control_Type
                    ,Group_Name = Spartan_MetadataData.Group_Name

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            return PartialView("AddSpartan_Metadata", varSpartan_Metadata);
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
        public ActionResult ShowAdvanceFilter(Spartan_MetadataAdvanceSearchModel model)
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



            var previousFiltersObj = new Spartan_MetadataAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Spartan_MetadataAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Spartan_MetadataAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_MetadataPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_MetadataApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Metadatas == null)
                result.Spartan_Metadatas = new List<Spartan_Metadata>();

            return Json(new
            {
                data = result.Spartan_Metadatas.Select(m => new Spartan_MetadataGridModel
                    {
                    AttributeId = m.AttributeId
			,Class_Id = m.Class_Id
			,Class_Name = m.Class_Name
			,Object_Id = m.Object_Id
			,Physical_Name = m.Physical_Name
			,Logical_Name = m.Logical_Name
			,Identifier_Type = m.Identifier_Type
			,Attribute_Type = m.Attribute_Type
			,Length = m.Length
			,Decimals_Length = m.Decimals_Length
			,Relation_Type = m.Relation_Type
			,Related_Object_Id = m.Related_Object_Id
			,Related_Class_Id = m.Related_Class_Id
			,Related_Class_Name = m.Related_Class_Name
			,Related_Class_Identifier = m.Related_Class_Identifier
			,Related_Class_Description = m.Related_Class_Description
			,Required = m.Required
			,DefaultValue = m.DefaultValue
			,Visible = m.Visible
			,Help_Text = m.Help_Text
			,Read_Only = m.Read_Only
			,ScreenOrder = m.ScreenOrder
			,Control_Type = m.Control_Type
			,Group_Name = m.Group_Name

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_Metadata from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_Metadata Entity</returns>
        public ActionResult GetSpartan_MetadataList(int sEcho, int iDisplayStart, int iDisplayLength)
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
            _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_MetadataPropertyMapper());

            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True")
            {
                var advanceFilter =
                    (Spartan_MetadataAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            Spartan_MetadataPropertyMapper oSpartan_MetadataPropertyMapper = new Spartan_MetadataPropertyMapper();

            configuration.OrderByClause = oSpartan_MetadataPropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISpartan_MetadataApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Metadatas == null)
                result.Spartan_Metadatas = new List<Spartan_Metadata>();

            return Json(new
            {
                aaData = result.Spartan_Metadatas.Select(m => new Spartan_MetadataGridModel
            {
                    AttributeId = m.AttributeId
			,Class_Id = m.Class_Id
			,Class_Name = m.Class_Name
			,Object_Id = m.Object_Id
			,Physical_Name = m.Physical_Name
			,Logical_Name = m.Logical_Name
			,Identifier_Type = m.Identifier_Type
			,Attribute_Type = m.Attribute_Type
			,Length = m.Length
			,Decimals_Length = m.Decimals_Length
			,Relation_Type = m.Relation_Type
			,Related_Object_Id = m.Related_Object_Id
			,Related_Class_Id = m.Related_Class_Id
			,Related_Class_Name = m.Related_Class_Name
			,Related_Class_Identifier = m.Related_Class_Identifier
			,Related_Class_Description = m.Related_Class_Description
			,Required = m.Required
			,DefaultValue = m.DefaultValue
			,Visible = m.Visible
			,Help_Text = m.Help_Text
			,Read_Only = m.Read_Only
			,ScreenOrder = m.ScreenOrder
			,Control_Type = m.Control_Type
			,Group_Name = m.Group_Name

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(Spartan_MetadataAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromAttributeId) || !string.IsNullOrEmpty(filter.ToAttributeId))
            {
                if (!string.IsNullOrEmpty(filter.FromAttributeId))
                    where += " AND Spartan_Metadata.AttributeId >= " + filter.FromAttributeId;
                if (!string.IsNullOrEmpty(filter.ToAttributeId))
                    where += " AND Spartan_Metadata.AttributeId <= " + filter.ToAttributeId;
            }

            if (!string.IsNullOrEmpty(filter.FromClass_Id) || !string.IsNullOrEmpty(filter.ToClass_Id))
            {
                if (!string.IsNullOrEmpty(filter.FromClass_Id))
                    where += " AND Spartan_Metadata.Class_Id >= " + filter.FromClass_Id;
                if (!string.IsNullOrEmpty(filter.ToClass_Id))
                    where += " AND Spartan_Metadata.Class_Id <= " + filter.ToClass_Id;
            }

            if (!string.IsNullOrEmpty(filter.Class_Name))
            {
                switch (filter.Class_NameFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Metadata.Class_Name LIKE '" + filter.Class_Name + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Metadata.Class_Name LIKE '%" + filter.Class_Name + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Metadata.Class_Name = '" + filter.Class_Name + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Metadata.Class_Name LIKE '%" + filter.Class_Name + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromObject_Id) || !string.IsNullOrEmpty(filter.ToObject_Id))
            {
                if (!string.IsNullOrEmpty(filter.FromObject_Id))
                    where += " AND Spartan_Metadata.Object_Id >= " + filter.FromObject_Id;
                if (!string.IsNullOrEmpty(filter.ToObject_Id))
                    where += " AND Spartan_Metadata.Object_Id <= " + filter.ToObject_Id;
            }

            if (!string.IsNullOrEmpty(filter.Physical_Name))
            {
                switch (filter.Physical_NameFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Metadata.Physical_Name LIKE '" + filter.Physical_Name + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Metadata.Physical_Name LIKE '%" + filter.Physical_Name + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Metadata.Physical_Name = '" + filter.Physical_Name + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Metadata.Physical_Name LIKE '%" + filter.Physical_Name + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Logical_Name))
            {
                switch (filter.Logical_NameFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Metadata.Logical_Name LIKE '" + filter.Logical_Name + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Metadata.Logical_Name LIKE '%" + filter.Logical_Name + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Metadata.Logical_Name = '" + filter.Logical_Name + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Metadata.Logical_Name LIKE '%" + filter.Logical_Name + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromIdentifier_Type) || !string.IsNullOrEmpty(filter.ToIdentifier_Type))
            {
                if (!string.IsNullOrEmpty(filter.FromIdentifier_Type))
                    where += " AND Spartan_Metadata.Identifier_Type >= " + filter.FromIdentifier_Type;
                if (!string.IsNullOrEmpty(filter.ToIdentifier_Type))
                    where += " AND Spartan_Metadata.Identifier_Type <= " + filter.ToIdentifier_Type;
            }

            if (!string.IsNullOrEmpty(filter.FromAttribute_Type) || !string.IsNullOrEmpty(filter.ToAttribute_Type))
            {
                if (!string.IsNullOrEmpty(filter.FromAttribute_Type))
                    where += " AND Spartan_Metadata.Attribute_Type >= " + filter.FromAttribute_Type;
                if (!string.IsNullOrEmpty(filter.ToAttribute_Type))
                    where += " AND Spartan_Metadata.Attribute_Type <= " + filter.ToAttribute_Type;
            }

            if (!string.IsNullOrEmpty(filter.FromLength) || !string.IsNullOrEmpty(filter.ToLength))
            {
                if (!string.IsNullOrEmpty(filter.FromLength))
                    where += " AND Spartan_Metadata.Length >= " + filter.FromLength;
                if (!string.IsNullOrEmpty(filter.ToLength))
                    where += " AND Spartan_Metadata.Length <= " + filter.ToLength;
            }

            if (!string.IsNullOrEmpty(filter.FromDecimals_Length) || !string.IsNullOrEmpty(filter.ToDecimals_Length))
            {
                if (!string.IsNullOrEmpty(filter.FromDecimals_Length))
                    where += " AND Spartan_Metadata.Decimals_Length >= " + filter.FromDecimals_Length;
                if (!string.IsNullOrEmpty(filter.ToDecimals_Length))
                    where += " AND Spartan_Metadata.Decimals_Length <= " + filter.ToDecimals_Length;
            }

            if (!string.IsNullOrEmpty(filter.FromRelation_Type) || !string.IsNullOrEmpty(filter.ToRelation_Type))
            {
                if (!string.IsNullOrEmpty(filter.FromRelation_Type))
                    where += " AND Spartan_Metadata.Relation_Type >= " + filter.FromRelation_Type;
                if (!string.IsNullOrEmpty(filter.ToRelation_Type))
                    where += " AND Spartan_Metadata.Relation_Type <= " + filter.ToRelation_Type;
            }

            if (!string.IsNullOrEmpty(filter.FromRelated_Object_Id) || !string.IsNullOrEmpty(filter.ToRelated_Object_Id))
            {
                if (!string.IsNullOrEmpty(filter.FromRelated_Object_Id))
                    where += " AND Spartan_Metadata.Related_Object_Id >= " + filter.FromRelated_Object_Id;
                if (!string.IsNullOrEmpty(filter.ToRelated_Object_Id))
                    where += " AND Spartan_Metadata.Related_Object_Id <= " + filter.ToRelated_Object_Id;
            }

            if (!string.IsNullOrEmpty(filter.FromRelated_Class_Id) || !string.IsNullOrEmpty(filter.ToRelated_Class_Id))
            {
                if (!string.IsNullOrEmpty(filter.FromRelated_Class_Id))
                    where += " AND Spartan_Metadata.Related_Class_Id >= " + filter.FromRelated_Class_Id;
                if (!string.IsNullOrEmpty(filter.ToRelated_Class_Id))
                    where += " AND Spartan_Metadata.Related_Class_Id <= " + filter.ToRelated_Class_Id;
            }

            if (!string.IsNullOrEmpty(filter.Related_Class_Name))
            {
                switch (filter.Related_Class_NameFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Metadata.Related_Class_Name LIKE '" + filter.Related_Class_Name + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Metadata.Related_Class_Name LIKE '%" + filter.Related_Class_Name + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Metadata.Related_Class_Name = '" + filter.Related_Class_Name + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Metadata.Related_Class_Name LIKE '%" + filter.Related_Class_Name + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromRelated_Class_Identifier) || !string.IsNullOrEmpty(filter.ToRelated_Class_Identifier))
            {
                if (!string.IsNullOrEmpty(filter.FromRelated_Class_Identifier))
                    where += " AND Spartan_Metadata.Related_Class_Identifier >= " + filter.FromRelated_Class_Identifier;
                if (!string.IsNullOrEmpty(filter.ToRelated_Class_Identifier))
                    where += " AND Spartan_Metadata.Related_Class_Identifier <= " + filter.ToRelated_Class_Identifier;
            }

            if (!string.IsNullOrEmpty(filter.Related_Class_Description))
            {
                switch (filter.Related_Class_DescriptionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Metadata.Related_Class_Description LIKE '" + filter.Related_Class_Description + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Metadata.Related_Class_Description LIKE '%" + filter.Related_Class_Description + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Metadata.Related_Class_Description = '" + filter.Related_Class_Description + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Metadata.Related_Class_Description LIKE '%" + filter.Related_Class_Description + "%'";
                        break;
                }
            }

            if (filter.Required != RadioOptions.NoApply)
                where += " AND Spartan_Metadata.Required = " + Convert.ToInt32(filter.Required);

            if (!string.IsNullOrEmpty(filter.DefaultValue))
            {
                switch (filter.DefaultValueFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Metadata.DefaultValue LIKE '" + filter.DefaultValue + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Metadata.DefaultValue LIKE '%" + filter.DefaultValue + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Metadata.DefaultValue = '" + filter.DefaultValue + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Metadata.DefaultValue LIKE '%" + filter.DefaultValue + "%'";
                        break;
                }
            }

            if (filter.Visible != RadioOptions.NoApply)
                where += " AND Spartan_Metadata.Visible = " + Convert.ToInt32(filter.Visible);

            if (!string.IsNullOrEmpty(filter.Help_Text))
            {
                switch (filter.Help_TextFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Metadata.Help_Text LIKE '" + filter.Help_Text + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Metadata.Help_Text LIKE '%" + filter.Help_Text + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Metadata.Help_Text = '" + filter.Help_Text + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Metadata.Help_Text LIKE '%" + filter.Help_Text + "%'";
                        break;
                }
            }

            if (filter.Read_Only != RadioOptions.NoApply)
                where += " AND Spartan_Metadata.Read_Only = " + Convert.ToInt32(filter.Read_Only);

            if (!string.IsNullOrEmpty(filter.FromScreenOrder) || !string.IsNullOrEmpty(filter.ToScreenOrder))
            {
                if (!string.IsNullOrEmpty(filter.FromScreenOrder))
                    where += " AND Spartan_Metadata.ScreenOrder >= " + filter.FromScreenOrder;
                if (!string.IsNullOrEmpty(filter.ToScreenOrder))
                    where += " AND Spartan_Metadata.ScreenOrder <= " + filter.ToScreenOrder;
            }

            if (!string.IsNullOrEmpty(filter.FromControl_Type) || !string.IsNullOrEmpty(filter.ToControl_Type))
            {
                if (!string.IsNullOrEmpty(filter.FromControl_Type))
                    where += " AND Spartan_Metadata.Control_Type >= " + filter.FromControl_Type;
                if (!string.IsNullOrEmpty(filter.ToControl_Type))
                    where += " AND Spartan_Metadata.Control_Type <= " + filter.ToControl_Type;
            }

            if (!string.IsNullOrEmpty(filter.Group_Name))
            {
                switch (filter.Group_NameFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Metadata.Group_Name LIKE '" + filter.Group_Name + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Metadata.Group_Name LIKE '%" + filter.Group_Name + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Metadata.Group_Name = '" + filter.Group_Name + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Metadata.Group_Name LIKE '%" + filter.Group_Name + "%'";
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
                _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);

                //Spartan_Metadata varSpartan_Metadata = null;
                if (id.ToString() != "0")
                {

                }
                var result = _ISpartan_MetadataApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_MetadataModel varSpartan_Metadata)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Spartan_MetadataInfo = new Spartan_Metadata
                    {
                        AttributeId = varSpartan_Metadata.AttributeId
                        ,Class_Id = varSpartan_Metadata.Class_Id
                        ,Class_Name = varSpartan_Metadata.Class_Name
                        ,Object_Id = varSpartan_Metadata.Object_Id
                        ,Physical_Name = varSpartan_Metadata.Physical_Name
                        ,Logical_Name = varSpartan_Metadata.Logical_Name
                        ,Identifier_Type = varSpartan_Metadata.Identifier_Type
                        ,Attribute_Type = varSpartan_Metadata.Attribute_Type
                        ,Length = varSpartan_Metadata.Length
                        ,Decimals_Length = varSpartan_Metadata.Decimals_Length
                        ,Relation_Type = varSpartan_Metadata.Relation_Type
                        ,Related_Object_Id = varSpartan_Metadata.Related_Object_Id
                        ,Related_Class_Id = varSpartan_Metadata.Related_Class_Id
                        ,Related_Class_Name = varSpartan_Metadata.Related_Class_Name
                        ,Related_Class_Identifier = varSpartan_Metadata.Related_Class_Identifier
                        ,Related_Class_Description = varSpartan_Metadata.Related_Class_Description
                        ,Required = varSpartan_Metadata.Required
                        ,DefaultValue = varSpartan_Metadata.DefaultValue
                        ,Visible = varSpartan_Metadata.Visible
                        ,Help_Text = varSpartan_Metadata.Help_Text
                        ,Read_Only = varSpartan_Metadata.Read_Only
                        ,ScreenOrder = varSpartan_Metadata.ScreenOrder
                        ,Control_Type = varSpartan_Metadata.Control_Type
                        ,Group_Name = varSpartan_Metadata.Group_Name

                    };

                    result = !IsNew ?
                        _ISpartan_MetadataApiConsumer.Update(Spartan_MetadataInfo, null, null).Resource.ToString() :
                         _ISpartan_MetadataApiConsumer.Insert(Spartan_MetadataInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Spartan_Metadata script
        /// </summary>
        /// <param name="oSpartan_MetadataElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_MetadataModuleAttributeList)
        {
            for (int i = 0; i < Spartan_MetadataModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_MetadataModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_MetadataModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_MetadataModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_MetadataModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_MetadataModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_MetadataModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Spartan_MetadataModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Spartan_MetadataModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Spartan_MetadataModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Spartan_MetadataModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strSpartan_MetadataScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Metadata.js")))
            {
                strSpartan_MetadataScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_Metadata element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_MetadataModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_MetadataScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_MetadataScript.Substring(indexOfArray, strSpartan_MetadataScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_MetadataModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_MetadataModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_MetadataScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strSpartan_MetadataScript.Substring(indexOfArrayHistory, strSpartan_MetadataScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strSpartan_MetadataScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_MetadataScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_MetadataScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Spartan_MetadataModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strSpartan_MetadataScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_MetadataScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_MetadataScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_MetadataScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_Metadata.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_Metadata.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Metadata.js")))
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
        public ActionResult Spartan_MetadataPropertyBag()
        {
            return PartialView("Spartan_MetadataPropertyBag", "Spartan_Metadata");
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

            _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_MetadataPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_MetadataApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Metadatas == null)
                result.Spartan_Metadatas = new List<Spartan_Metadata>();

            var data = result.Spartan_Metadatas.Select(m => new Spartan_MetadataGridModel
            {
                AttributeId = m.AttributeId
                ,Class_Id = m.Class_Id
                ,Class_Name = m.Class_Name
                ,Object_Id = m.Object_Id
                ,Physical_Name = m.Physical_Name
                ,Logical_Name = m.Logical_Name
                ,Identifier_Type = m.Identifier_Type
                ,Attribute_Type = m.Attribute_Type
                ,Length = m.Length
                ,Decimals_Length = m.Decimals_Length
                ,Relation_Type = m.Relation_Type
                ,Related_Object_Id = m.Related_Object_Id
                ,Related_Class_Id = m.Related_Class_Id
                ,Related_Class_Name = m.Related_Class_Name
                ,Related_Class_Identifier = m.Related_Class_Identifier
                ,Related_Class_Description = m.Related_Class_Description
                ,Required = m.Required
                ,DefaultValue = m.DefaultValue
                ,Visible = m.Visible
                ,Help_Text = m.Help_Text
                ,Read_Only = m.Read_Only
                ,ScreenOrder = m.ScreenOrder
                ,Control_Type = m.Control_Type
                ,Group_Name = m.Group_Name

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_MetadataList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_MetadataList_" + DateTime.Now.ToString());
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

            _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_MetadataPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_MetadataApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Metadatas == null)
                result.Spartan_Metadatas = new List<Spartan_Metadata>();

            var data = result.Spartan_Metadatas.Select(m => new Spartan_MetadataGridModel
            {
                AttributeId = m.AttributeId
                ,Class_Id = m.Class_Id
                ,Class_Name = m.Class_Name
                ,Object_Id = m.Object_Id
                ,Physical_Name = m.Physical_Name
                ,Logical_Name = m.Logical_Name
                ,Identifier_Type = m.Identifier_Type
                ,Attribute_Type = m.Attribute_Type
                ,Length = m.Length
                ,Decimals_Length = m.Decimals_Length
                ,Relation_Type = m.Relation_Type
                ,Related_Object_Id = m.Related_Object_Id
                ,Related_Class_Id = m.Related_Class_Id
                ,Related_Class_Name = m.Related_Class_Name
                ,Related_Class_Identifier = m.Related_Class_Identifier
                ,Related_Class_Description = m.Related_Class_Description
                ,Required = m.Required
                ,DefaultValue = m.DefaultValue
                ,Visible = m.Visible
                ,Help_Text = m.Help_Text
                ,Read_Only = m.Read_Only
                ,ScreenOrder = m.ScreenOrder
                ,Control_Type = m.Control_Type
                ,Group_Name = m.Group_Name

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
