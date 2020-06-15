using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Spartan_User_Role;
using Spartane.Core.Domain.Spartan_User_Status;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_User;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Role;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Status;

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
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Historical_Password;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Spartan_UserController : Controller
    {
        #region "variable declaration"

        private ISpartan_UserService service = null;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private ISpartan_User_RoleApiConsumer _ISpartan_User_RoleApiConsumer;
        private ISpartan_User_StatusApiConsumer _ISpartan_User_StatusApiConsumer;

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

        
        public Spartan_UserController(ISpartan_UserService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_UserApiConsumer Spartan_UserApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer , ISpartan_User_RoleApiConsumer Spartan_User_RoleApiConsumer , ISpartan_User_StatusApiConsumer Spartan_User_StatusApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
            this._ISpartan_User_RoleApiConsumer = Spartan_User_RoleApiConsumer;
            this._ISpartan_User_StatusApiConsumer = Spartan_User_StatusApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_User
        [ObjectAuth(ObjectId = (ModuleObjectId)100, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 100);
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
                var whereClauseFormat = "Object = 100 AND FormatId in (" + formats + ")";
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

        // GET: Frontal/Spartan_User/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)100, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 100);
            ViewBag.Permission = permission;
            var varSpartan_User = new Spartan_UserModel();
			
            ViewBag.ObjectId = "100";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_UserData = _ISpartan_UserApiConsumer.GetByKeyComplete(Id).Resource.Spartan_Users[0];
                if (Spartan_UserData == null)
                    return HttpNotFound();

                varSpartan_User = new Spartan_UserModel
                {
                    Id_User = (int)Spartan_UserData.Id_User
                    ,Name = Spartan_UserData.Name
                    ,Role = Spartan_UserData.Role
                    ,RoleDescription =  (string)Spartan_UserData.Role_Spartan_User_Role.Description
                    ,Image = Spartan_UserData.Image
                    ,Email = Spartan_UserData.Email
                    ,Status = Spartan_UserData.Status
                    ,StatusDescription =  (string)Spartan_UserData.Status_Spartan_User_Status.Description
                    ,Username = Spartan_UserData.Username
                    ,Password = Spartan_UserData.Password

                };
                Session["PasswordActual"] = Spartan_UserData.Password;
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.ImageSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varSpartan_User.Image).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_User_RoleApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_User_Roles = _ISpartan_User_RoleApiConsumer.SelAll(true);
            if (Spartan_User_Roles != null && Spartan_User_Roles.Resource != null)
                ViewBag.Spartan_User_Roles = Spartan_User_Roles.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.User_Role_Id)
                }).ToList();
            _ISpartan_User_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_User_Statuss = _ISpartan_User_StatusApiConsumer.SelAll(true);
            if (Spartan_User_Statuss != null && Spartan_User_Statuss.Resource != null)
                ViewBag.Spartan_User_Statuss = Spartan_User_Statuss.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.User_Status_Id)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_User);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_User(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 100);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_UserModel varSpartan_User= new Spartan_UserModel();


            if (id.ToString() != "0")
            {
                var Spartan_UsersData = _ISpartan_UserApiConsumer.ListaSelAll(0, 1000, "Id_User=" + id, "").Resource.Spartan_Users;
				
				if (Spartan_UsersData != null && Spartan_UsersData.Count > 0)
                {
					var Spartan_UserData = Spartan_UsersData.First();
					varSpartan_User= new Spartan_UserModel
					{
						Id_User  = Spartan_UserData.Id_User 
	                    ,Name = Spartan_UserData.Name
                    ,Role = Spartan_UserData.Role
                    ,RoleDescription =  (string)Spartan_UserData.Role_Spartan_User_Role.Description
                    ,Image = Spartan_UserData.Image
                    ,Email = Spartan_UserData.Email
                    ,Status = Spartan_UserData.Status
                    ,StatusDescription =  (string)Spartan_UserData.Status_Spartan_User_Status.Description
                    ,Username = Spartan_UserData.Username
                    ,Password = Spartan_UserData.Password

					};
				}
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.ImageSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varSpartan_User.Image).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_User_RoleApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_User_Roles = _ISpartan_User_RoleApiConsumer.SelAll(true);
            if (Spartan_User_Roles != null && Spartan_User_Roles.Resource != null)
                ViewBag.Spartan_User_Roles = Spartan_User_Roles.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.User_Role_Id)
                }).ToList();
            _ISpartan_User_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_User_Statuss = _ISpartan_User_StatusApiConsumer.SelAll(true);
            if (Spartan_User_Statuss != null && Spartan_User_Statuss.Resource != null)
                ViewBag.Spartan_User_Statuss = Spartan_User_Statuss.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.User_Status_Id)
                }).ToList();


            return PartialView("AddSpartan_User", varSpartan_User);
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
        public ActionResult GetSpartan_User_RoleAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_User_RoleApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_User_RoleApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_User_StatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_User_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_User_StatusApiConsumer.SelAll(false).Resource;
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
        public ActionResult ShowAdvanceFilter(Spartan_UserAdvanceSearchModel model)
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

            _ISpartan_User_RoleApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_User_Roles = _ISpartan_User_RoleApiConsumer.SelAll(true);
            if (Spartan_User_Roles != null && Spartan_User_Roles.Resource != null)
                ViewBag.Spartan_User_Roles = Spartan_User_Roles.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.User_Role_Id)
                }).ToList();
            _ISpartan_User_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_User_Statuss = _ISpartan_User_StatusApiConsumer.SelAll(true);
            if (Spartan_User_Statuss != null && Spartan_User_Statuss.Resource != null)
                ViewBag.Spartan_User_Statuss = Spartan_User_Statuss.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.User_Status_Id)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_User_RoleApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_User_Roles = _ISpartan_User_RoleApiConsumer.SelAll(true);
            if (Spartan_User_Roles != null && Spartan_User_Roles.Resource != null)
                ViewBag.Spartan_User_Roles = Spartan_User_Roles.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.User_Role_Id)
                }).ToList();
            _ISpartan_User_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_User_Statuss = _ISpartan_User_StatusApiConsumer.SelAll(true);
            if (Spartan_User_Statuss != null && Spartan_User_Statuss.Resource != null)
                ViewBag.Spartan_User_Statuss = Spartan_User_Statuss.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.User_Status_Id)
                }).ToList();


            var previousFiltersObj = new Spartan_UserAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Spartan_UserAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Spartan_UserAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_UserPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_UserApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Users == null)
                result.Spartan_Users = new List<Spartane.Core.Domain.Spartan_User.Spartan_User>();

            return Json(new
            {
                data = result.Spartan_Users.Select(m => new Spartan_UserGridModel
                    {
                    Id_User = m.Id_User
			,Name = m.Name
                        ,RoleDescription = (string)m.Role_Spartan_User_Role.Description
			,Image = m.Image
			,Email = m.Email
                        ,StatusDescription = (string)m.Status_Spartan_User_Status.Description
			,Username = m.Username
			,Password = m.Password

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_User from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_User Entity</returns>
        public ActionResult GetSpartan_UserList(int sEcho, int iDisplayStart, int iDisplayLength, string where)
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
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_UserPropertyMapper());
			if (!String.IsNullOrEmpty(where))
            {
                 configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True")
            {
                var advanceFilter =
                    (Spartan_UserAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            Spartan_UserPropertyMapper oSpartan_UserPropertyMapper = new Spartan_UserPropertyMapper();

            configuration.OrderByClause = oSpartan_UserPropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISpartan_UserApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Users == null)
                result.Spartan_Users = new List<Spartane.Core.Domain.Spartan_User.Spartan_User>();

            return Json(new
            {
                aaData = result.Spartan_Users.Select(m => new Spartan_UserGridModel
            {
                    Id_User = m.Id_User
			,Name = m.Name
                        ,RoleDescription = (string)m.Role_Spartan_User_Role.Description
			,Image = m.Image
			,Email = m.Email
                        ,StatusDescription = (string)m.Status_Spartan_User_Status.Description
			,Username = m.Username
			,Password = m.Password

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(Spartan_UserAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromId_User) || !string.IsNullOrEmpty(filter.ToId_User))
            {
                if (!string.IsNullOrEmpty(filter.FromId_User))
                    where += " AND Spartan_User.Id_User >= " + filter.FromId_User;
                if (!string.IsNullOrEmpty(filter.ToId_User))
                    where += " AND Spartan_User.Id_User <= " + filter.ToId_User;
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                switch (filter.NameFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.Name + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.Name + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.Name + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.Name + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceRole))
            {
                switch (filter.RoleFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User_Role.Description LIKE '" + filter.AdvanceRole + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User_Role.Description LIKE '%" + filter.AdvanceRole + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User_Role.Description = '" + filter.AdvanceRole + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User_Role.Description LIKE '%" + filter.AdvanceRole + "%'";
                        break;
                }
            }
            else if (filter.AdvanceRoleMultiple != null && filter.AdvanceRoleMultiple.Count() > 0)
            {
                var RoleIds = string.Join(",", filter.AdvanceRoleMultiple);

                where += " AND Spartan_User.Role In (" + RoleIds + ")";
            }

            if (filter.Image != RadioOptions.NoApply)
                where += " AND Spartan_User.Image " + (filter.Image == RadioOptions.Yes ? ">" : "==") + " 0";

            if (!string.IsNullOrEmpty(filter.Email))
            {
                switch (filter.EmailFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Email LIKE '" + filter.Email + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Email LIKE '%" + filter.Email + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Email = '" + filter.Email + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Email LIKE '%" + filter.Email + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceStatus))
            {
                switch (filter.StatusFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User_Status.Description LIKE '" + filter.AdvanceStatus + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User_Status.Description LIKE '%" + filter.AdvanceStatus + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User_Status.Description = '" + filter.AdvanceStatus + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User_Status.Description LIKE '%" + filter.AdvanceStatus + "%'";
                        break;
                }
            }
            else if (filter.AdvanceStatusMultiple != null && filter.AdvanceStatusMultiple.Count() > 0)
            {
                var StatusIds = string.Join(",", filter.AdvanceStatusMultiple);

                where += " AND Spartan_User.Status In (" + StatusIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Username))
            {
                switch (filter.UsernameFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Username LIKE '" + filter.Username + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Username LIKE '%" + filter.Username + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Username = '" + filter.Username + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Username LIKE '%" + filter.Username + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Password))
            {
                switch (filter.PasswordFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Password LIKE '" + filter.Password + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Password LIKE '%" + filter.Password + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Password = '" + filter.Password + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Password LIKE '%" + filter.Password + "%'";
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
                _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);

                Spartane.Core.Domain.Spartan_User.Spartan_User varSpartan_User = null;
                if (id.ToString() != "0")
                {

                }
                var result = _ISpartan_UserApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_UserModel varSpartan_User)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);


                    if (varSpartan_User.ImageRemoveAttachment != 0 && varSpartan_User.ImageFile == null)
                    {
                        varSpartan_User.Image = 0;
                    }

                    if (varSpartan_User.ImageFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varSpartan_User.ImageFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varSpartan_User.Image = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varSpartan_User.ImageFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                    
                    
                    var result = "";
                    var Spartan_UserInfo = new Spartane.Core.Domain.Spartan_User.Spartan_User();
                    Spartan_UserInfo.Id_User = varSpartan_User.Id_User;
                    Spartan_UserInfo.Name = varSpartan_User.Name;
                    Spartan_UserInfo.Role = varSpartan_User.Role;
                    Spartan_UserInfo.Image = varSpartan_User.Image ?? varSpartan_User.Image;
                    Spartan_UserInfo.Email = varSpartan_User.Email;
                    Spartan_UserInfo.Status = varSpartan_User.Status;
                    Spartan_UserInfo.Username = varSpartan_User.Username;
                    bool changePasswordInUpdate = false;
                    if ((!IsNew && varSpartan_User.Password != Session["PasswordActual"].ToString()) || IsNew)
                    {
                        Spartan_UserInfo.Password = EncryptHelper.CalculateMD5Hash(varSpartan_User.Password);
                        changePasswordInUpdate = true;
                    }
                    else
                    {
                        Spartan_UserInfo.Password = varSpartan_User.Password;
                    }


                    result = !IsNew ?
                        _ISpartan_UserApiConsumer.Update(Spartan_UserInfo, null, null).Resource.ToString() :
                         _ISpartan_UserApiConsumer.Insert(Spartan_UserInfo, null, null).Resource.ToString();
					Session["KeyValueInserted"] = result;
                    if (changePasswordInUpdate || IsNew)
                    {
                        var userhistApi = new Spartan_User_Historical_PasswordApiConsumer();
                        userhistApi.SetAuthHeader(_tokenManager.Token);
                        var histUser = userhistApi.ListaSelAll(0, 9999, "Spartan_User.Id_User = " + varSpartan_User.Id_User, "").Resource;
                        if (histUser.RowCount > 0)
                        {
                            foreach (var item in histUser.Spartan_User_Historical_Passwords)
                            {
                                userhistApi.Delete(item.Clave, null, null);
                            }
                        }
                        var resultHist = "";
                        var Spartan_UserHistorical_Pwd = new Spartane.Core.Domain.Spartan_User_Historical_Password.Spartan_User_Historical_Password()
                        {
                            Usuario = Convert.ToInt32(result)
                            ,
                            Password = EncryptHelper.CalculateMD5Hash(varSpartan_User.Password)
                            ,
                            Fecha_de_Registro = DateTime.Now
                        };

                        
                        resultHist = userhistApi.Insert(Spartan_UserHistorical_Pwd, null, null).Resource.ToString();

                        Helper.SendEmail(new List<string>() { varSpartan_User.Email }, "Nuevo Password", "Su Password provisorio es: " + varSpartan_User.Password);
                    }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Spartan_User script
        /// </summary>
        /// <param name="oSpartan_UserElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_UserModuleAttributeList)
        {
            for (int i = 0; i < Spartan_UserModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_UserModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_UserModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_UserModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_UserModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_UserModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_UserModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Spartan_UserModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Spartan_UserModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Spartan_UserModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Spartan_UserModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strSpartan_UserScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_User.js")))
            {
                strSpartan_UserScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_User element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_UserModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_UserScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_UserScript.Substring(indexOfArray, strSpartan_UserScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_UserModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_UserModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_UserScript.IndexOf("inpuElementChildArray");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strSpartan_UserScript.Substring(indexOfArrayHistory, strSpartan_UserScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strSpartan_UserScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_UserScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_UserScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Spartan_UserModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
				finalResponse = strSpartan_UserScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_UserScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_UserScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_UserScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_User.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_User.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_User.js")))
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
        public ActionResult Spartan_UserPropertyBag()
        {
            return PartialView("Spartan_UserPropertyBag", "Spartan_User");
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

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_UserPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_UserApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Users == null)
                result.Spartan_Users = new List<Spartane.Core.Domain.Spartan_User.Spartan_User>();

            var data = result.Spartan_Users.Select(m => new Spartan_UserGridModel
            {
                Id_User = m.Id_User
			,Name = m.Name
                        ,RoleDescription = (string)m.Role_Spartan_User_Role.Description
			,Image = m.Image
			,Email = m.Email
                        ,StatusDescription = (string)m.Status_Spartan_User_Status.Description
			,Username = m.Username
			,Password = m.Password

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_UserList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_UserList_" + DateTime.Now.ToString());
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

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_UserPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_UserApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Users == null)
                result.Spartan_Users = new List<Spartane.Core.Domain.Spartan_User.Spartan_User>();

            var data = result.Spartan_Users.Select(m => new Spartan_UserGridModel
            {
                Id_User = m.Id_User
			,Name = m.Name
                        ,RoleDescription = (string)m.Role_Spartan_User_Role.Description
			,Image = m.Image
			,Email = m.Email
                        ,StatusDescription = (string)m.Status_Spartan_User_Status.Description
			,Username = m.Username
			,Password = m.Password

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
