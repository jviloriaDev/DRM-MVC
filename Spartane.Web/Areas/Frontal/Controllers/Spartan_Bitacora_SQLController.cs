using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_Bitacora_SQL;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_Bitacora_SQL;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Bitacora_SQL;

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



namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Spartan_Bitacora_SQLController : Controller
    {
        #region "variable declaration"

        private ISpartan_Bitacora_SQLService service = null;
        private ISpartan_Bitacora_SQLApiConsumer _ISpartan_Bitacora_SQLApiConsumer;

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

        
        public Spartan_Bitacora_SQLController(ISpartan_Bitacora_SQLService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_Bitacora_SQLApiConsumer Spartan_Bitacora_SQLApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_Bitacora_SQLApiConsumer = Spartan_Bitacora_SQLApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_Bitacora_SQL
        [ObjectAuth(ObjectId = (ModuleObjectId)34957, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 34957, ModuleId);
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
                var whereClauseFormat = "Object = 34957 AND FormatId in (" + formats + ")";
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

        // GET: Frontal/Spartan_Bitacora_SQL/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)34957, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 34957, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varSpartan_Bitacora_SQL = new Spartan_Bitacora_SQLModel();
			
            ViewBag.ObjectId = "34957";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Bitacora_SQLApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_Bitacora_SQLData = _ISpartan_Bitacora_SQLApiConsumer.GetByKeyComplete(Id).Resource.Spartan_Bitacora_SQLs[0];
                if (Spartan_Bitacora_SQLData == null)
                    return HttpNotFound();

                varSpartan_Bitacora_SQL = new Spartan_Bitacora_SQLModel
                {
                    Folio = (int)Spartan_Bitacora_SQLData.Folio
                    ,Id_User = Spartan_Bitacora_SQLData.Id_User
                    ,Type_SQL = Spartan_Bitacora_SQLData.Type_SQL
                    ,Register_Date = (Spartan_Bitacora_SQLData.Register_Date == null ? string.Empty : Convert.ToDateTime(Spartan_Bitacora_SQLData.Register_Date).ToString(ConfigurationProperty.DateFormat))
                    ,Computer_Name = Spartan_Bitacora_SQLData.Computer_Name
                    ,Server_Name = Spartan_Bitacora_SQLData.Server_Name
                    ,Database_Name = Spartan_Bitacora_SQLData.Database_Name
                    ,System_Name = Spartan_Bitacora_SQLData.System_Name
                    ,System_Version = Spartan_Bitacora_SQLData.System_Version
                    ,Windows_Version = Spartan_Bitacora_SQLData.Windows_Version
                    ,Command_SQL = Spartan_Bitacora_SQLData.Command_SQL
                    ,Folio_SQL = Spartan_Bitacora_SQLData.Folio_SQL
                    ,Object_Id = Spartan_Bitacora_SQLData.Object_Id
                    ,IP = Spartan_Bitacora_SQLData.IP
                    ,Json = Spartan_Bitacora_SQLData.Json
                    ,Result = Spartan_Bitacora_SQLData.Result.GetValueOrDefault()
                    ,Error = Spartan_Bitacora_SQLData.Error

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_Bitacora_SQL);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_Bitacora_SQL(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 34957);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_Bitacora_SQLApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_Bitacora_SQLModel varSpartan_Bitacora_SQL= new Spartan_Bitacora_SQLModel();


            if (id.ToString() != "0")
            {
                var Spartan_Bitacora_SQLsData = _ISpartan_Bitacora_SQLApiConsumer.ListaSelAll(0, 1000, "Folio=" + id, "").Resource.Spartan_Bitacora_SQLs;
				
				if (Spartan_Bitacora_SQLsData != null && Spartan_Bitacora_SQLsData.Count > 0)
                {
					var Spartan_Bitacora_SQLData = Spartan_Bitacora_SQLsData.First();
					varSpartan_Bitacora_SQL= new Spartan_Bitacora_SQLModel
					{
						Folio  = Spartan_Bitacora_SQLData.Folio 
	                    ,Id_User = Spartan_Bitacora_SQLData.Id_User
                    ,Type_SQL = Spartan_Bitacora_SQLData.Type_SQL
                    ,Register_Date = (Spartan_Bitacora_SQLData.Register_Date == null ? string.Empty : Convert.ToDateTime(Spartan_Bitacora_SQLData.Register_Date).ToString(ConfigurationProperty.DateFormat))
                    ,Computer_Name = Spartan_Bitacora_SQLData.Computer_Name
                    ,Server_Name = Spartan_Bitacora_SQLData.Server_Name
                    ,Database_Name = Spartan_Bitacora_SQLData.Database_Name
                    ,System_Name = Spartan_Bitacora_SQLData.System_Name
                    ,System_Version = Spartan_Bitacora_SQLData.System_Version
                    ,Windows_Version = Spartan_Bitacora_SQLData.Windows_Version
                    ,Command_SQL = Spartan_Bitacora_SQLData.Command_SQL
                    ,Folio_SQL = Spartan_Bitacora_SQLData.Folio_SQL
                    ,Object_Id = Spartan_Bitacora_SQLData.Object_Id
                    ,IP = Spartan_Bitacora_SQLData.IP
                    ,Json = Spartan_Bitacora_SQLData.Json
                    ,Result = Spartan_Bitacora_SQLData.Result.GetValueOrDefault()
                    ,Error = Spartan_Bitacora_SQLData.Error

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            return PartialView("AddSpartan_Bitacora_SQL", varSpartan_Bitacora_SQL);
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
        public ActionResult ShowAdvanceFilter(Spartan_Bitacora_SQLAdvanceSearchModel model, int idFilter = -1)
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



            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            var previousFiltersObj = new Spartan_Bitacora_SQLAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Spartan_Bitacora_SQLAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Spartan_Bitacora_SQLAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Bitacora_SQLPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_Bitacora_SQLApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Bitacora_SQLs == null)
                result.Spartan_Bitacora_SQLs = new List<Spartan_Bitacora_SQL>();

            return Json(new
            {
                data = result.Spartan_Bitacora_SQLs.Select(m => new Spartan_Bitacora_SQLGridModel
                    {
                    Folio = m.Folio
			,Id_User = m.Id_User
			,Type_SQL = m.Type_SQL
                        ,Register_Date = (m.Register_Date == null ? string.Empty : Convert.ToDateTime(m.Register_Date).ToString(ConfigurationProperty.DateFormat))
			,Computer_Name = m.Computer_Name
			,Server_Name = m.Server_Name
			,Database_Name = m.Database_Name
			,System_Name = m.System_Name
			,System_Version = m.System_Version
			,Windows_Version = m.Windows_Version
			,Command_SQL = m.Command_SQL
			,Folio_SQL = m.Folio_SQL
			,Object_Id = m.Object_Id
			,IP = m.IP
			,Json = m.Json
			,Result = m.Result
			,Error = m.Error

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_Bitacora_SQL from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_Bitacora_SQL Entity</returns>
        public ActionResult GetSpartan_Bitacora_SQLList(int sEcho, int iDisplayStart, int iDisplayLength, string where, string order)
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
            _ISpartan_Bitacora_SQLApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_Bitacora_SQLPropertyMapper());
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
				if (Session["AdvanceSearch"].GetType() == typeof(Spartan_Bitacora_SQLAdvanceSearchModel))
                {
					var advanceFilter =
                    (Spartan_Bitacora_SQLAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Spartan_Bitacora_SQLPropertyMapper oSpartan_Bitacora_SQLPropertyMapper = new Spartan_Bitacora_SQLPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = oSpartan_Bitacora_SQLPropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISpartan_Bitacora_SQLApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Bitacora_SQLs == null)
                result.Spartan_Bitacora_SQLs = new List<Spartan_Bitacora_SQL>();

            return Json(new
            {
                aaData = result.Spartan_Bitacora_SQLs.Select(m => new Spartan_Bitacora_SQLGridModel
            {
                    Folio = m.Folio
			,Id_User = m.Id_User
			,Type_SQL = m.Type_SQL
                        ,Register_Date = (m.Register_Date == null ? string.Empty : Convert.ToDateTime(m.Register_Date).ToString(ConfigurationProperty.DateFormat))
			,Computer_Name = m.Computer_Name
			,Server_Name = m.Server_Name
			,Database_Name = m.Database_Name
			,System_Name = m.System_Name
			,System_Version = m.System_Version
			,Windows_Version = m.Windows_Version
			,Command_SQL = m.Command_SQL
			,Folio_SQL = m.Folio_SQL
			,Object_Id = m.Object_Id
			,IP = m.IP
			,Json = m.Json
			,Result = m.Result
			,Error = m.Error

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(Spartan_Bitacora_SQLAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Spartan_Bitacora_SQL.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Spartan_Bitacora_SQL.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromId_User) || !string.IsNullOrEmpty(filter.ToId_User))
            {
                if (!string.IsNullOrEmpty(filter.FromId_User))
                    where += " AND Spartan_Bitacora_SQL.Id_User >= " + filter.FromId_User;
                if (!string.IsNullOrEmpty(filter.ToId_User))
                    where += " AND Spartan_Bitacora_SQL.Id_User <= " + filter.ToId_User;
            }

            if (!string.IsNullOrEmpty(filter.Type_SQL))
            {
                switch (filter.Type_SQLFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Bitacora_SQL.Type_SQL LIKE '" + filter.Type_SQL + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Bitacora_SQL.Type_SQL LIKE '%" + filter.Type_SQL + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Bitacora_SQL.Type_SQL = '" + filter.Type_SQL + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Bitacora_SQL.Type_SQL LIKE '%" + filter.Type_SQL + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromRegister_Date) || !string.IsNullOrEmpty(filter.ToRegister_Date))
            {
                var Register_DateFrom = DateTime.ParseExact(filter.FromRegister_Date, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Register_DateTo = DateTime.ParseExact(filter.ToRegister_Date, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromRegister_Date))
                    where += " AND Spartan_Bitacora_SQL.Register_Date >= '" + Register_DateFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToRegister_Date))
                    where += " AND Spartan_Bitacora_SQL.Register_Date <= '" + Register_DateTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.Computer_Name))
            {
                switch (filter.Computer_NameFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Bitacora_SQL.Computer_Name LIKE '" + filter.Computer_Name + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Bitacora_SQL.Computer_Name LIKE '%" + filter.Computer_Name + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Bitacora_SQL.Computer_Name = '" + filter.Computer_Name + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Bitacora_SQL.Computer_Name LIKE '%" + filter.Computer_Name + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Server_Name))
            {
                switch (filter.Server_NameFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Bitacora_SQL.Server_Name LIKE '" + filter.Server_Name + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Bitacora_SQL.Server_Name LIKE '%" + filter.Server_Name + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Bitacora_SQL.Server_Name = '" + filter.Server_Name + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Bitacora_SQL.Server_Name LIKE '%" + filter.Server_Name + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Database_Name))
            {
                switch (filter.Database_NameFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Bitacora_SQL.Database_Name LIKE '" + filter.Database_Name + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Bitacora_SQL.Database_Name LIKE '%" + filter.Database_Name + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Bitacora_SQL.Database_Name = '" + filter.Database_Name + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Bitacora_SQL.Database_Name LIKE '%" + filter.Database_Name + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.System_Name))
            {
                switch (filter.System_NameFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Bitacora_SQL.System_Name LIKE '" + filter.System_Name + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Bitacora_SQL.System_Name LIKE '%" + filter.System_Name + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Bitacora_SQL.System_Name = '" + filter.System_Name + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Bitacora_SQL.System_Name LIKE '%" + filter.System_Name + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.System_Version))
            {
                switch (filter.System_VersionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Bitacora_SQL.System_Version LIKE '" + filter.System_Version + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Bitacora_SQL.System_Version LIKE '%" + filter.System_Version + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Bitacora_SQL.System_Version = '" + filter.System_Version + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Bitacora_SQL.System_Version LIKE '%" + filter.System_Version + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Windows_Version))
            {
                switch (filter.Windows_VersionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Bitacora_SQL.Windows_Version LIKE '" + filter.Windows_Version + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Bitacora_SQL.Windows_Version LIKE '%" + filter.Windows_Version + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Bitacora_SQL.Windows_Version = '" + filter.Windows_Version + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Bitacora_SQL.Windows_Version LIKE '%" + filter.Windows_Version + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Command_SQL))
            {
                switch (filter.Command_SQLFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Bitacora_SQL.Command_SQL LIKE '" + filter.Command_SQL + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Bitacora_SQL.Command_SQL LIKE '%" + filter.Command_SQL + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Bitacora_SQL.Command_SQL = '" + filter.Command_SQL + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Bitacora_SQL.Command_SQL LIKE '%" + filter.Command_SQL + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Folio_SQL))
            {
                switch (filter.Folio_SQLFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Bitacora_SQL.Folio_SQL LIKE '" + filter.Folio_SQL + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Bitacora_SQL.Folio_SQL LIKE '%" + filter.Folio_SQL + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Bitacora_SQL.Folio_SQL = '" + filter.Folio_SQL + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Bitacora_SQL.Folio_SQL LIKE '%" + filter.Folio_SQL + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromObject_Id) || !string.IsNullOrEmpty(filter.ToObject_Id))
            {
                if (!string.IsNullOrEmpty(filter.FromObject_Id))
                    where += " AND Spartan_Bitacora_SQL.Object_Id >= " + filter.FromObject_Id;
                if (!string.IsNullOrEmpty(filter.ToObject_Id))
                    where += " AND Spartan_Bitacora_SQL.Object_Id <= " + filter.ToObject_Id;
            }

            if (!string.IsNullOrEmpty(filter.IP))
            {
                switch (filter.IPFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Bitacora_SQL.IP LIKE '" + filter.IP + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Bitacora_SQL.IP LIKE '%" + filter.IP + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Bitacora_SQL.IP = '" + filter.IP + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Bitacora_SQL.IP LIKE '%" + filter.IP + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Json))
            {
                switch (filter.JsonFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Bitacora_SQL.Json LIKE '" + filter.Json + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Bitacora_SQL.Json LIKE '%" + filter.Json + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Bitacora_SQL.Json = '" + filter.Json + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Bitacora_SQL.Json LIKE '%" + filter.Json + "%'";
                        break;
                }
            }

            if (filter.Result != RadioOptions.NoApply)
                where += " AND Spartan_Bitacora_SQL.Result = " + Convert.ToInt32(filter.Result);

            if (!string.IsNullOrEmpty(filter.Error))
            {
                switch (filter.ErrorFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Bitacora_SQL.Error LIKE '" + filter.Error + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Bitacora_SQL.Error LIKE '%" + filter.Error + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Bitacora_SQL.Error = '" + filter.Error + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Bitacora_SQL.Error LIKE '%" + filter.Error + "%'";
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
                _ISpartan_Bitacora_SQLApiConsumer.SetAuthHeader(_tokenManager.Token);

                Spartan_Bitacora_SQL varSpartan_Bitacora_SQL = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _ISpartan_Bitacora_SQLApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_Bitacora_SQLModel varSpartan_Bitacora_SQL)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_Bitacora_SQLApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Spartan_Bitacora_SQLInfo = new Spartan_Bitacora_SQL
                    {
                        Folio = varSpartan_Bitacora_SQL.Folio
                        ,Id_User = varSpartan_Bitacora_SQL.Id_User
                        ,Type_SQL = varSpartan_Bitacora_SQL.Type_SQL
                        ,Register_Date = (!String.IsNullOrEmpty(varSpartan_Bitacora_SQL.Register_Date)) ? DateTime.ParseExact(varSpartan_Bitacora_SQL.Register_Date, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Computer_Name = varSpartan_Bitacora_SQL.Computer_Name
                        ,Server_Name = varSpartan_Bitacora_SQL.Server_Name
                        ,Database_Name = varSpartan_Bitacora_SQL.Database_Name
                        ,System_Name = varSpartan_Bitacora_SQL.System_Name
                        ,System_Version = varSpartan_Bitacora_SQL.System_Version
                        ,Windows_Version = varSpartan_Bitacora_SQL.Windows_Version
                        ,Command_SQL = varSpartan_Bitacora_SQL.Command_SQL
                        ,Folio_SQL = varSpartan_Bitacora_SQL.Folio_SQL
                        ,Object_Id = varSpartan_Bitacora_SQL.Object_Id
                        ,IP = varSpartan_Bitacora_SQL.IP
                        ,Json = varSpartan_Bitacora_SQL.Json
                        ,Result = varSpartan_Bitacora_SQL.Result
                        ,Error = varSpartan_Bitacora_SQL.Error

                    };

                    result = !IsNew ?
                        _ISpartan_Bitacora_SQLApiConsumer.Update(Spartan_Bitacora_SQLInfo, null, null).Resource.ToString() :
                         _ISpartan_Bitacora_SQLApiConsumer.Insert(Spartan_Bitacora_SQLInfo, null, null).Resource.ToString();
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
        /// Write Element Array of Spartan_Bitacora_SQL script
        /// </summary>
        /// <param name="oSpartan_Bitacora_SQLElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Spartan_Bitacora_SQLModuleAttributeList)
        {
            for (int i = 0; i < Spartan_Bitacora_SQLModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_Bitacora_SQLModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_Bitacora_SQLModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_Bitacora_SQLModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_Bitacora_SQLModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_Bitacora_SQLModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_Bitacora_SQLModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Spartan_Bitacora_SQLModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Spartan_Bitacora_SQLModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Spartan_Bitacora_SQLModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Spartan_Bitacora_SQLModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Spartan_Bitacora_SQLModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strSpartan_Bitacora_SQLScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Bitacora_SQL.js")))
            {
                strSpartan_Bitacora_SQLScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_Bitacora_SQL element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_Bitacora_SQLModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_Bitacora_SQLScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_Bitacora_SQLScript.Substring(indexOfArray, strSpartan_Bitacora_SQLScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_Bitacora_SQLModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_Bitacora_SQLModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_Bitacora_SQLScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strSpartan_Bitacora_SQLScript.Substring(indexOfArrayHistory, strSpartan_Bitacora_SQLScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strSpartan_Bitacora_SQLScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_Bitacora_SQLScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_Bitacora_SQLScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Spartan_Bitacora_SQLModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Spartan_Bitacora_SQLModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_Bitacora_SQL.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_Bitacora_SQL.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Bitacora_SQL.js")))
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
        public ActionResult Spartan_Bitacora_SQLPropertyBag()
        {
            return PartialView("Spartan_Bitacora_SQLPropertyBag", "Spartan_Bitacora_SQL");
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

            _ISpartan_Bitacora_SQLApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_Bitacora_SQLPropertyMapper());
				
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
                    (Spartan_Bitacora_SQLAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Bitacora_SQLApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Bitacora_SQLs == null)
                result.Spartan_Bitacora_SQLs = new List<Spartan_Bitacora_SQL>();

            var data = result.Spartan_Bitacora_SQLs.Select(m => new Spartan_Bitacora_SQLGridModel
            {
                Folio = m.Folio
			,Id_User = m.Id_User
			,Type_SQL = m.Type_SQL
                        ,Register_Date = (m.Register_Date == null ? string.Empty : Convert.ToDateTime(m.Register_Date).ToString(ConfigurationProperty.DateFormat))
			,Computer_Name = m.Computer_Name
			,Server_Name = m.Server_Name
			,Database_Name = m.Database_Name
			,System_Name = m.System_Name
			,System_Version = m.System_Version
			,Windows_Version = m.Windows_Version
			,Command_SQL = m.Command_SQL
			,Folio_SQL = m.Folio_SQL
			,Object_Id = m.Object_Id
			,IP = m.IP
			,Json = m.Json
			,Result = m.Result
			,Error = m.Error

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_Bitacora_SQLList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_Bitacora_SQLList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "Spartan_Bitacora_SQLList_" + DateTime.Now.ToString());
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

            _ISpartan_Bitacora_SQLApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_Bitacora_SQLPropertyMapper());

			if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
			
			
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Bitacora_SQLApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Bitacora_SQLs == null)
                result.Spartan_Bitacora_SQLs = new List<Spartan_Bitacora_SQL>();

            var data = result.Spartan_Bitacora_SQLs.Select(m => new Spartan_Bitacora_SQLGridModel
            {
                Folio = m.Folio
			,Id_User = m.Id_User
			,Type_SQL = m.Type_SQL
                        ,Register_Date = (m.Register_Date == null ? string.Empty : Convert.ToDateTime(m.Register_Date).ToString(ConfigurationProperty.DateFormat))
			,Computer_Name = m.Computer_Name
			,Server_Name = m.Server_Name
			,Database_Name = m.Database_Name
			,System_Name = m.System_Name
			,System_Version = m.System_Version
			,Windows_Version = m.Windows_Version
			,Command_SQL = m.Command_SQL
			,Folio_SQL = m.Folio_SQL
			,Object_Id = m.Object_Id
			,IP = m.IP
			,Json = m.Json
			,Result = m.Result
			,Error = m.Error

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
