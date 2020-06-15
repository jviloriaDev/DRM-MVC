using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_User_Role;
using Spartane.Core.Domain.Spartan_User_Role_Status;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_User_Role;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Role;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Role_Status;

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
using Spartane.Web.Areas.WebApiConsumer.GeneratePDF;using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Resources;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Spartan_User_RoleController : Controller
    {
        #region "variable declaration"

        private ISpartan_User_RoleService service = null;
        private ISpartan_User_RoleApiConsumer _ISpartan_User_RoleApiConsumer;
        private ISpartan_User_Role_StatusApiConsumer _ISpartan_User_Role_StatusApiConsumer;

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

        
        public Spartan_User_RoleController(ISpartan_User_RoleService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_User_RoleApiConsumer Spartan_User_RoleApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer , ISpartan_User_Role_StatusApiConsumer Spartan_User_Role_StatusApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_User_RoleApiConsumer = Spartan_User_RoleApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
            this._ISpartan_User_Role_StatusApiConsumer = Spartan_User_Role_StatusApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_User_Role
        [ObjectAuth(ObjectId = (ModuleObjectId)101, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 101);
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
                var whereClauseFormat = "Object = 101 AND FormatId in (" + formats + ")";
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

        // GET: Frontal/Spartan_User_Role/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)101, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 101);
            ViewBag.Permission = permission;
            var varSpartan_User_Role = new Spartan_User_RoleModel();
			
            ViewBag.ObjectId = "101";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_User_RoleApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_User_RoleData = _ISpartan_User_RoleApiConsumer.GetByKeyComplete(Id).Resource.Spartan_User_Roles[0];
                if (Spartan_User_RoleData == null)
                    return HttpNotFound();

                varSpartan_User_Role = new Spartan_User_RoleModel
                {
                    User_Role_Id = (int)Spartan_User_RoleData.User_Role_Id
                    ,Description = Spartan_User_RoleData.Description
                    ,Status = Spartan_User_RoleData.Status
                    ,StatusDescription =  (string)Spartan_User_RoleData.Status_Spartan_User_Role_Status.Description

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_User_Role_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_User_Role_Statuss = _ISpartan_User_Role_StatusApiConsumer.SelAll(true);
            if (Spartan_User_Role_Statuss != null && Spartan_User_Role_Statuss.Resource != null)
                ViewBag.Spartan_User_Role_Statuss = Spartan_User_Role_Statuss.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.User_Role_Status_Id)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_User_Role);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_User_Role(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 101);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_User_RoleApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_User_RoleModel varSpartan_User_Role= new Spartan_User_RoleModel();


            if (id.ToString() != "0")
            {
                var Spartan_User_RolesData = _ISpartan_User_RoleApiConsumer.ListaSelAll(0, 1000, "User_Role_Id=" + id, "").Resource.Spartan_User_Roles;
				
				if (Spartan_User_RolesData != null && Spartan_User_RolesData.Count > 0)
                {
					var Spartan_User_RoleData = Spartan_User_RolesData.First();
					varSpartan_User_Role= new Spartan_User_RoleModel
					{
						User_Role_Id  = Spartan_User_RoleData.User_Role_Id 
	                    ,Description = Spartan_User_RoleData.Description
                    ,Status = Spartan_User_RoleData.Status
                    ,StatusDescription =  (string)Spartan_User_RoleData.Status_Spartan_User_Role_Status.Description

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_User_Role_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_User_Role_Statuss = _ISpartan_User_Role_StatusApiConsumer.SelAll(true);
            if (Spartan_User_Role_Statuss != null && Spartan_User_Role_Statuss.Resource != null)
                ViewBag.Spartan_User_Role_Statuss = Spartan_User_Role_Statuss.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.User_Role_Status_Id)
                }).ToList();


            return PartialView("AddSpartan_User_Role", varSpartan_User_Role);
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
        public ActionResult GetSpartan_User_Role_StatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_User_Role_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_User_Role_StatusApiConsumer.SelAll(false).Resource;
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
        public ActionResult ShowAdvanceFilter(Spartan_User_RoleAdvanceSearchModel model)
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

            _ISpartan_User_Role_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_User_Role_Statuss = _ISpartan_User_Role_StatusApiConsumer.SelAll(true);
            if (Spartan_User_Role_Statuss != null && Spartan_User_Role_Statuss.Resource != null)
                ViewBag.Spartan_User_Role_Statuss = Spartan_User_Role_Statuss.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.User_Role_Status_Id)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_User_Role_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_User_Role_Statuss = _ISpartan_User_Role_StatusApiConsumer.SelAll(true);
            if (Spartan_User_Role_Statuss != null && Spartan_User_Role_Statuss.Resource != null)
                ViewBag.Spartan_User_Role_Statuss = Spartan_User_Role_Statuss.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.User_Role_Status_Id)
                }).ToList();


            var previousFiltersObj = new Spartan_User_RoleAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Spartan_User_RoleAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Spartan_User_RoleAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_User_RolePropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_User_RoleApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_User_Roles == null)
                result.Spartan_User_Roles = new List<Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role>();

            return Json(new
            {
                data = result.Spartan_User_Roles.Select(m => new Spartan_User_RoleGridModel
                    {
                    User_Role_Id = m.User_Role_Id
			,Description = m.Description
                        ,StatusDescription = (string)m.Status_Spartan_User_Role_Status.Description

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_User_Role from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_User_Role Entity</returns>
        public ActionResult GetSpartan_User_RoleList(int sEcho, int iDisplayStart, int iDisplayLength, string where)
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
            _ISpartan_User_RoleApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_User_RolePropertyMapper());
			if (!String.IsNullOrEmpty(where))
            {
                 configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True")
            {
                var advanceFilter =
                    (Spartan_User_RoleAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            Spartan_User_RolePropertyMapper oSpartan_User_RolePropertyMapper = new Spartan_User_RolePropertyMapper();

            configuration.OrderByClause = oSpartan_User_RolePropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISpartan_User_RoleApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_User_Roles == null)
                result.Spartan_User_Roles = new List<Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role>();

            return Json(new
            {
                aaData = result.Spartan_User_Roles.Select(m => new Spartan_User_RoleGridModel
            {
                    User_Role_Id = m.User_Role_Id
			,Description = m.Description
                        ,StatusDescription = (string)m.Status_Spartan_User_Role_Status.Description

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(Spartan_User_RoleAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromUser_Role_Id) || !string.IsNullOrEmpty(filter.ToUser_Role_Id))
            {
                if (!string.IsNullOrEmpty(filter.FromUser_Role_Id))
                    where += " AND Spartan_User_Role.User_Role_Id >= " + filter.FromUser_Role_Id;
                if (!string.IsNullOrEmpty(filter.ToUser_Role_Id))
                    where += " AND Spartan_User_Role.User_Role_Id <= " + filter.ToUser_Role_Id;
            }

            if (!string.IsNullOrEmpty(filter.Description))
            {
                switch (filter.DescriptionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User_Role.Description LIKE '" + filter.Description + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User_Role.Description LIKE '%" + filter.Description + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User_Role.Description = '" + filter.Description + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User_Role.Description LIKE '%" + filter.Description + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceStatus))
            {
                switch (filter.StatusFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User_Role_Status.Description LIKE '" + filter.AdvanceStatus + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User_Role_Status.Description LIKE '%" + filter.AdvanceStatus + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User_Role_Status.Description = '" + filter.AdvanceStatus + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User_Role_Status.Description LIKE '%" + filter.AdvanceStatus + "%'";
                        break;
                }
            }
            else if (filter.AdvanceStatusMultiple != null && filter.AdvanceStatusMultiple.Count() > 0)
            {
                var StatusIds = string.Join(",", filter.AdvanceStatusMultiple);

                where += " AND Spartan_User_Role.Status In (" + StatusIds + ")";
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
                _ISpartan_User_RoleApiConsumer.SetAuthHeader(_tokenManager.Token);

                Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role varSpartan_User_Role = null;
                if (id.ToString() != "0")
                {

                }
                var result = _ISpartan_User_RoleApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_User_RoleModel varSpartan_User_Role)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_User_RoleApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Spartan_User_RoleInfo = new Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role
                    {
                        User_Role_Id = varSpartan_User_Role.User_Role_Id
                        ,Description = varSpartan_User_Role.Description
                        ,Status = varSpartan_User_Role.Status

                    };

                    result = !IsNew ?
                        _ISpartan_User_RoleApiConsumer.Update(Spartan_User_RoleInfo, null, null).Resource.ToString() :
                         _ISpartan_User_RoleApiConsumer.Insert(Spartan_User_RoleInfo, null, null).Resource.ToString();
					Session["KeyValueInserted"] = result;


                    if (result !="-1")
                    {
                        Roles.InsertUpdateObject(Convert.ToInt32(result), Spartan_User_RoleInfo.Description, "en-us");
                        Roles.InsertUpdateObject(Convert.ToInt32(result), Spartan_User_RoleInfo.Description, "es-es");
                    }

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
        /// Write Element Array of Spartan_User_Role script
        /// </summary>
        /// <param name="oSpartan_User_RoleElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_User_RoleModuleAttributeList)
        {
            for (int i = 0; i < Spartan_User_RoleModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_User_RoleModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_User_RoleModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_User_RoleModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_User_RoleModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_User_RoleModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_User_RoleModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Spartan_User_RoleModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Spartan_User_RoleModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Spartan_User_RoleModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Spartan_User_RoleModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strSpartan_User_RoleScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_User_Role.js")))
            {
                strSpartan_User_RoleScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_User_Role element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_User_RoleModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_User_RoleScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_User_RoleScript.Substring(indexOfArray, strSpartan_User_RoleScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_User_RoleModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_User_RoleModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_User_RoleScript.IndexOf("inpuElementChildArray");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strSpartan_User_RoleScript.Substring(indexOfArrayHistory, strSpartan_User_RoleScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strSpartan_User_RoleScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_User_RoleScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_User_RoleScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Spartan_User_RoleModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
				finalResponse = strSpartan_User_RoleScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_User_RoleScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_User_RoleScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_User_RoleScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_User_Role.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_User_Role.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_User_Role.js")))
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
        public ActionResult Spartan_User_RolePropertyBag()
        {
            return PartialView("Spartan_User_RolePropertyBag", "Spartan_User_Role");
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
        public void Export(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return;

            _ISpartan_User_RoleApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_User_RolePropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_User_RoleApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_User_Roles == null)
                result.Spartan_User_Roles = new List<Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role>();

            var data = result.Spartan_User_Roles.Select(m => new Spartan_User_RoleGridModel
            {
                User_Role_Id = m.User_Role_Id
			,Description = m.Description
                        ,StatusDescription = (string)m.Status_Spartan_User_Role_Status.Description

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_User_RoleList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_User_RoleList_" + DateTime.Now.ToString());
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

            _ISpartan_User_RoleApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_User_RolePropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_User_RoleApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_User_Roles == null)
                result.Spartan_User_Roles = new List<Spartane.Core.Domain.Spartan_User_Role.Spartan_User_Role>();

            var data = result.Spartan_User_Roles.Select(m => new Spartan_User_RoleGridModel
            {
                User_Role_Id = m.User_Role_Id
			,Description = m.Description
                        ,StatusDescription = (string)m.Status_Spartan_User_Role_Status.Description

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
