using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_Report_Advance_Filter;
using Spartane.Core.Domain.Spartan_Report;
using Spartane.Core.Domain.Spartan_Metadata;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Advance_Filter;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report;
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
using Spartane.Services.Spartan_Report_Advance_Filter;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Spartan_Report_Advance_FilterController : Controller
    {
        #region "variable declaration"

        private ISpartan_Report_Advance_FilterService service = null;
        private ISpartan_Report_Advance_FilterApiConsumer _ISpartan_Report_Advance_FilterApiConsumer;
        private ISpartan_ReportApiConsumer _ISpartan_ReportApiConsumer;
        private ISpartan_MetadataApiConsumer _ISpartan_MetadataApiConsumer;

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

        
        public Spartan_Report_Advance_FilterController(ISpartan_Report_Advance_FilterService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_Report_Advance_FilterApiConsumer Spartan_Report_Advance_FilterApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer , ISpartan_ReportApiConsumer Spartan_ReportApiConsumer , ISpartan_MetadataApiConsumer Spartan_MetadataApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_Report_Advance_FilterApiConsumer = Spartan_Report_Advance_FilterApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
            this._ISpartan_ReportApiConsumer = Spartan_ReportApiConsumer;
            this._ISpartan_MetadataApiConsumer = Spartan_MetadataApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_Report_Advance_Filter
        [ObjectAuth(ObjectId = (ModuleObjectId)34982, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 34982, ModuleId);
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
                var whereClauseFormat = "Object = 34982 AND FormatId in (" + formats + ")";
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

        // GET: Frontal/Spartan_Report_Advance_Filter/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)34982, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 34982, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varSpartan_Report_Advance_Filter = new Spartan_Report_Advance_FilterModel();
			
            ViewBag.ObjectId = "34982";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_Advance_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_Report_Advance_FilterData = _ISpartan_Report_Advance_FilterApiConsumer.GetByKeyComplete(Id).Resource.Spartan_Report_Advance_Filters[0];
                if (Spartan_Report_Advance_FilterData == null)
                    return HttpNotFound();

                varSpartan_Report_Advance_Filter = new Spartan_Report_Advance_FilterModel
                {
                    Clave = (int)Spartan_Report_Advance_FilterData.Clave
                    ,Report = Spartan_Report_Advance_FilterData.Report
                    ,ReportReport_Name = Spartan_Report_Advance_FilterData.Report_Spartan_Report.Report_Name?? Spartan_Report_Advance_FilterData.Report_Spartan_Report.Report_Name
                    ,AttributeId = Spartan_Report_Advance_FilterData.AttributeId
                    ,AttributeIdPhysical_Name = Spartan_Report_Advance_FilterData.AttributeId_Spartan_Metadata.Physical_Name?? Spartan_Report_Advance_FilterData.AttributeId_Spartan_Metadata.Physical_Name
                    ,Defect_Value_From = Spartan_Report_Advance_FilterData.Defect_Value_From
                    ,Defect_Value_To = Spartan_Report_Advance_FilterData.Defect_Value_To

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Reports_Report = _ISpartan_ReportApiConsumer.SelAll(true);
            if (Spartan_Reports_Report != null && Spartan_Reports_Report.Resource != null)
                ViewBag.Spartan_Reports_Report = Spartan_Reports_Report.Resource.OrderBy(m => m.Report_Name).Select(m => new SelectListItem
                {
                    Text = m.Report_Name.ToString(), Value = Convert.ToString(m.ReportId)
                }).ToList();
            _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Metadatas_AttributeId = _ISpartan_MetadataApiConsumer.SelAll(true);
            if (Spartan_Metadatas_AttributeId != null && Spartan_Metadatas_AttributeId.Resource != null)
                ViewBag.Spartan_Metadatas_AttributeId = Spartan_Metadatas_AttributeId.Resource.OrderBy(m => m.Physical_Name).Select(m => new SelectListItem
                {
                    Text = m.Physical_Name.ToString(), Value = Convert.ToString(m.AttributeId)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_Report_Advance_Filter);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_Report_Advance_Filter(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 34982);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_Report_Advance_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_Report_Advance_FilterModel varSpartan_Report_Advance_Filter= new Spartan_Report_Advance_FilterModel();


            if (id.ToString() != "0")
            {
                var Spartan_Report_Advance_FiltersData = _ISpartan_Report_Advance_FilterApiConsumer.ListaSelAll(0, 1000, "Clave=" + id, "").Resource.Spartan_Report_Advance_Filters;
				
				if (Spartan_Report_Advance_FiltersData != null && Spartan_Report_Advance_FiltersData.Count > 0)
                {
					var Spartan_Report_Advance_FilterData = Spartan_Report_Advance_FiltersData.First();
					varSpartan_Report_Advance_Filter= new Spartan_Report_Advance_FilterModel
					{
						Clave  = Spartan_Report_Advance_FilterData.Clave 
	                    ,Report = Spartan_Report_Advance_FilterData.Report
                    ,ReportReport_Name = Spartan_Report_Advance_FilterData.Report_Spartan_Report.Report_Name?? Spartan_Report_Advance_FilterData.Report_Spartan_Report.Report_Name
                    ,AttributeId = Spartan_Report_Advance_FilterData.AttributeId
                    ,AttributeIdPhysical_Name = Spartan_Report_Advance_FilterData.AttributeId_Spartan_Metadata.Physical_Name?? Spartan_Report_Advance_FilterData.AttributeId_Spartan_Metadata.Physical_Name
                    ,Defect_Value_From = Spartan_Report_Advance_FilterData.Defect_Value_From
                    ,Defect_Value_To = Spartan_Report_Advance_FilterData.Defect_Value_To

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Reports_Report = _ISpartan_ReportApiConsumer.SelAll(true);
            if (Spartan_Reports_Report != null && Spartan_Reports_Report.Resource != null)
                ViewBag.Spartan_Reports_Report = Spartan_Reports_Report.Resource.OrderBy(m => m.Report_Name).Select(m => new SelectListItem
                {
                    Text = m.Report_Name.ToString(), Value = Convert.ToString(m.ReportId)
                }).ToList();
            _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Metadatas_AttributeId = _ISpartan_MetadataApiConsumer.SelAll(true);
            if (Spartan_Metadatas_AttributeId != null && Spartan_Metadatas_AttributeId.Resource != null)
                ViewBag.Spartan_Metadatas_AttributeId = Spartan_Metadatas_AttributeId.Resource.OrderBy(m => m.Physical_Name).Select(m => new SelectListItem
                {
                    Text = m.Physical_Name.ToString(), Value = Convert.ToString(m.AttributeId)
                }).ToList();


            return PartialView("AddSpartan_Report_Advance_Filter", varSpartan_Report_Advance_Filter);
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
        public ActionResult GetSpartan_ReportAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_ReportApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_MetadataAll()
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




        [HttpPost]
        public JsonResult ClearAdvanceFilter()
        {
            Session["AdvanceSearch"] = null;
            return Json(new { result = Session["AdvanceSearch"] == null }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ShowAdvanceFilter(Spartan_Report_Advance_FilterAdvanceSearchModel model, int idFilter = -1)
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

            _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Reports_Report = _ISpartan_ReportApiConsumer.SelAll(true);
            if (Spartan_Reports_Report != null && Spartan_Reports_Report.Resource != null)
                ViewBag.Spartan_Reports_Report = Spartan_Reports_Report.Resource.OrderBy(m => m.Report_Name).Select(m => new SelectListItem
                {
                    Text = m.Report_Name.ToString(), Value = Convert.ToString(m.ReportId)
                }).ToList();
            _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Metadatas_AttributeId = _ISpartan_MetadataApiConsumer.SelAll(true);
            if (Spartan_Metadatas_AttributeId != null && Spartan_Metadatas_AttributeId.Resource != null)
                ViewBag.Spartan_Metadatas_AttributeId = Spartan_Metadatas_AttributeId.Resource.OrderBy(m => m.Physical_Name).Select(m => new SelectListItem
                {
                    Text = m.Physical_Name.ToString(), Value = Convert.ToString(m.AttributeId)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_ReportApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Reports_Report = _ISpartan_ReportApiConsumer.SelAll(true);
            if (Spartan_Reports_Report != null && Spartan_Reports_Report.Resource != null)
                ViewBag.Spartan_Reports_Report = Spartan_Reports_Report.Resource.OrderBy(m => m.Report_Name).Select(m => new SelectListItem
                {
                    Text = m.Report_Name.ToString(), Value = Convert.ToString(m.ReportId)
                }).ToList();
            _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Metadatas_AttributeId = _ISpartan_MetadataApiConsumer.SelAll(true);
            if (Spartan_Metadatas_AttributeId != null && Spartan_Metadatas_AttributeId.Resource != null)
                ViewBag.Spartan_Metadatas_AttributeId = Spartan_Metadatas_AttributeId.Resource.OrderBy(m => m.Physical_Name).Select(m => new SelectListItem
                {
                    Text = m.Physical_Name.ToString(), Value = Convert.ToString(m.AttributeId)
                }).ToList();


            var previousFiltersObj = new Spartan_Report_Advance_FilterAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Spartan_Report_Advance_FilterAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Spartan_Report_Advance_FilterAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Report_Advance_FilterPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_Report_Advance_FilterApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Report_Advance_Filters == null)
                result.Spartan_Report_Advance_Filters = new List<Spartan_Report_Advance_Filter>();

            return Json(new
            {
                data = result.Spartan_Report_Advance_Filters.Select(m => new Spartan_Report_Advance_FilterGridModel
                    {
                    Clave = m.Clave
                        ,ReportReport_Name =m.Report_Spartan_Report.Report_Name?? m.Report_Spartan_Report.Report_Name
                        ,AttributeIdPhysical_Name =m.AttributeId_Spartan_Metadata.Physical_Name?? m.AttributeId_Spartan_Metadata.Physical_Name
			,Defect_Value_From = m.Defect_Value_From
			,Defect_Value_To = m.Defect_Value_To

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_Report_Advance_Filter from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_Report_Advance_Filter Entity</returns>
        public ActionResult GetSpartan_Report_Advance_FilterList(int sEcho, int iDisplayStart, int iDisplayLength, string where, string order)
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
            _ISpartan_Report_Advance_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_Report_Advance_FilterPropertyMapper());
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
				if (Session["AdvanceSearch"].GetType() == typeof(Spartan_Report_Advance_FilterAdvanceSearchModel))
                {
					var advanceFilter =
                    (Spartan_Report_Advance_FilterAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Spartan_Report_Advance_FilterPropertyMapper oSpartan_Report_Advance_FilterPropertyMapper = new Spartan_Report_Advance_FilterPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = oSpartan_Report_Advance_FilterPropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISpartan_Report_Advance_FilterApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Report_Advance_Filters == null)
                result.Spartan_Report_Advance_Filters = new List<Spartan_Report_Advance_Filter>();

            return Json(new
            {
                aaData = result.Spartan_Report_Advance_Filters.Select(m => new Spartan_Report_Advance_FilterGridModel
            {
                    Clave = m.Clave
                        ,ReportReport_Name =m.Report_Spartan_Report.Report_Name?? m.Report_Spartan_Report.Report_Name
                        ,AttributeIdPhysical_Name =m.AttributeId_Spartan_Metadata.Physical_Name?? m.AttributeId_Spartan_Metadata.Physical_Name
			,Defect_Value_From = m.Defect_Value_From
			,Defect_Value_To = m.Defect_Value_To

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(Spartan_Report_Advance_FilterAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromClave) || !string.IsNullOrEmpty(filter.ToClave))
            {
                if (!string.IsNullOrEmpty(filter.FromClave))
                    where += " AND Spartan_Report_Advance_Filter.Clave >= " + filter.FromClave;
                if (!string.IsNullOrEmpty(filter.ToClave))
                    where += " AND Spartan_Report_Advance_Filter.Clave <= " + filter.ToClave;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceReport))
            {
                switch (filter.ReportFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report.Report_Name LIKE '" + filter.AdvanceReport + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report.Report_Name LIKE '%" + filter.AdvanceReport + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report.Report_Name = '" + filter.AdvanceReport + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report.Report_Name LIKE '%" + filter.AdvanceReport + "%'";
                        break;
                }
            }
            else if (filter.AdvanceReportMultiple != null && filter.AdvanceReportMultiple.Count() > 0)
            {
                var ReportIds = string.Join(",", filter.AdvanceReportMultiple);

                where += " AND Spartan_Report_Advance_Filter.Report In (" + ReportIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceAttributeId))
            {
                switch (filter.AttributeIdFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Metadata.Physical_Name LIKE '" + filter.AdvanceAttributeId + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Metadata.Physical_Name LIKE '%" + filter.AdvanceAttributeId + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Metadata.Physical_Name = '" + filter.AdvanceAttributeId + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Metadata.Physical_Name LIKE '%" + filter.AdvanceAttributeId + "%'";
                        break;
                }
            }
            else if (filter.AdvanceAttributeIdMultiple != null && filter.AdvanceAttributeIdMultiple.Count() > 0)
            {
                var AttributeIdIds = string.Join(",", filter.AdvanceAttributeIdMultiple);

                where += " AND Spartan_Report_Advance_Filter.AttributeId In (" + AttributeIdIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Defect_Value_From))
            {
                switch (filter.Defect_Value_FromFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report_Advance_Filter.Defect_Value_From LIKE '" + filter.Defect_Value_From + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report_Advance_Filter.Defect_Value_From LIKE '%" + filter.Defect_Value_From + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report_Advance_Filter.Defect_Value_From = '" + filter.Defect_Value_From + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report_Advance_Filter.Defect_Value_From LIKE '%" + filter.Defect_Value_From + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Defect_Value_To))
            {
                switch (filter.Defect_Value_ToFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Report_Advance_Filter.Defect_Value_To LIKE '" + filter.Defect_Value_To + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Report_Advance_Filter.Defect_Value_To LIKE '%" + filter.Defect_Value_To + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Report_Advance_Filter.Defect_Value_To = '" + filter.Defect_Value_To + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Report_Advance_Filter.Defect_Value_To LIKE '%" + filter.Defect_Value_To + "%'";
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
                _ISpartan_Report_Advance_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);

                Spartan_Report_Advance_Filter varSpartan_Report_Advance_Filter = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _ISpartan_Report_Advance_FilterApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_Report_Advance_FilterModel varSpartan_Report_Advance_Filter)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_Report_Advance_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Spartan_Report_Advance_FilterInfo = new Spartan_Report_Advance_Filter
                    {
                        Clave = varSpartan_Report_Advance_Filter.Clave
                        ,Report = varSpartan_Report_Advance_Filter.Report
                        ,AttributeId = varSpartan_Report_Advance_Filter.AttributeId
                        ,Defect_Value_From = varSpartan_Report_Advance_Filter.Defect_Value_From
                        ,Defect_Value_To = varSpartan_Report_Advance_Filter.Defect_Value_To

                    };

                    result = !IsNew ?
                        _ISpartan_Report_Advance_FilterApiConsumer.Update(Spartan_Report_Advance_FilterInfo, null, null).Resource.ToString() :
                         _ISpartan_Report_Advance_FilterApiConsumer.Insert(Spartan_Report_Advance_FilterInfo, null, null).Resource.ToString();
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



        /// <summary>
        /// Write Element Array of Spartan_Report_Advance_Filter script
        /// </summary>
        /// <param name="oSpartan_Report_Advance_FilterElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Spartan_Report_Advance_FilterModuleAttributeList)
        {
            for (int i = 0; i < Spartan_Report_Advance_FilterModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_Report_Advance_FilterModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_Report_Advance_FilterModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_Report_Advance_FilterModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_Report_Advance_FilterModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_Report_Advance_FilterModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_Report_Advance_FilterModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Spartan_Report_Advance_FilterModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Spartan_Report_Advance_FilterModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Spartan_Report_Advance_FilterModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Spartan_Report_Advance_FilterModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Spartan_Report_Advance_FilterModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strSpartan_Report_Advance_FilterScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Report_Advance_Filter.js")))
            {
                strSpartan_Report_Advance_FilterScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_Report_Advance_Filter element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_Report_Advance_FilterModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_Report_Advance_FilterScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_Report_Advance_FilterScript.Substring(indexOfArray, strSpartan_Report_Advance_FilterScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_Report_Advance_FilterModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_Report_Advance_FilterModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_Report_Advance_FilterScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strSpartan_Report_Advance_FilterScript.Substring(indexOfArrayHistory, strSpartan_Report_Advance_FilterScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strSpartan_Report_Advance_FilterScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_Report_Advance_FilterScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_Report_Advance_FilterScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Spartan_Report_Advance_FilterModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Spartan_Report_Advance_FilterModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_Report_Advance_Filter.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_Report_Advance_Filter.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Report_Advance_Filter.js")))
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
        public ActionResult Spartan_Report_Advance_FilterPropertyBag()
        {
            return PartialView("Spartan_Report_Advance_FilterPropertyBag", "Spartan_Report_Advance_Filter");
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
        public void Export(string format, int pageIndex, int pageSize, string where, string order)
        {
			where = HttpUtility.UrlEncode(where);
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return;

            _ISpartan_Report_Advance_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_Report_Advance_FilterPropertyMapper());
				
			if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
			
            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True")
            {
                var advanceFilter =
                    (Spartan_Report_Advance_FilterAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Report_Advance_FilterApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Report_Advance_Filters == null)
                result.Spartan_Report_Advance_Filters = new List<Spartan_Report_Advance_Filter>();

            var data = result.Spartan_Report_Advance_Filters.Select(m => new Spartan_Report_Advance_FilterGridModel
            {
                Clave = m.Clave
                        ,ReportReport_Name =m.Report_Spartan_Report.Report_Name?? m.Report_Spartan_Report.Report_Name
                        ,AttributeIdPhysical_Name =m.AttributeId_Spartan_Metadata.Physical_Name?? m.AttributeId_Spartan_Metadata.Physical_Name
			,Defect_Value_From = m.Defect_Value_From
			,Defect_Value_To = m.Defect_Value_To

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_Report_Advance_FilterList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_Report_Advance_FilterList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "Spartan_Report_Advance_FilterList_" + DateTime.Now.ToString());
                    break;
            }
        }

        [HttpGet]
        //[ObjectAuth(ObjectId = ModuleObjectId.EMPLEADOS_OBJECT, PermissionType = PermissionTypes.Export)]
        public ActionResult Print(string format, int pageIndex, int pageSize, string where, string order)
        {
			where = HttpUtility.UrlEncode(where);
		
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return null;

            _ISpartan_Report_Advance_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_Report_Advance_FilterPropertyMapper());

			if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
			
			
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Report_Advance_FilterApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Report_Advance_Filters == null)
                result.Spartan_Report_Advance_Filters = new List<Spartan_Report_Advance_Filter>();

            var data = result.Spartan_Report_Advance_Filters.Select(m => new Spartan_Report_Advance_FilterGridModel
            {
                Clave = m.Clave
                        ,ReportReport_Name =m.Report_Spartan_Report.Report_Name?? m.Report_Spartan_Report.Report_Name
                        ,AttributeIdPhysical_Name =m.AttributeId_Spartan_Metadata.Physical_Name?? m.AttributeId_Spartan_Metadata.Physical_Name
			,Defect_Value_From = m.Defect_Value_From
			,Defect_Value_To = m.Defect_Value_To

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
