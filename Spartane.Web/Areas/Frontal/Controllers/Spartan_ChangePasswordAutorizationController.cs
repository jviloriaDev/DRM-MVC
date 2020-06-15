using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_ChangePasswordAutorization;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.SpartanChangePasswordAutorizationEstatus;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_ChangePasswordAutorization;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_ChangePasswordAutorization;
using Spartane.Web.Areas.WebApiConsumer.SpartanChangePasswordAutorizationEstatus;

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
    public class Spartan_ChangePasswordAutorizationController : Controller
    {
        #region "variable declaration"

        private ISpartan_ChangePasswordAutorizationService service = null;
        private ISpartan_ChangePasswordAutorizationApiConsumer _ISpartan_ChangePasswordAutorizationApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private ISpartanChangePasswordAutorizationEstatusApiConsumer _ISpartanChangePasswordAutorizationEstatusApiConsumer;

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

        
        public Spartan_ChangePasswordAutorizationController(ISpartan_ChangePasswordAutorizationService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_ChangePasswordAutorizationApiConsumer Spartan_ChangePasswordAutorizationApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , ISpartanChangePasswordAutorizationEstatusApiConsumer SpartanChangePasswordAutorizationEstatusApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_ChangePasswordAutorizationApiConsumer = Spartan_ChangePasswordAutorizationApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._ISpartanChangePasswordAutorizationEstatusApiConsumer = SpartanChangePasswordAutorizationEstatusApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_ChangePasswordAutorization
        [ObjectAuth(ObjectId = (ModuleObjectId)135, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 135, ModuleId);
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
                var whereClauseFormat = "Object = 135 AND FormatId in (" + formats + ")";
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

        // GET: Frontal/Spartan_ChangePasswordAutorization/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)135, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 135, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varSpartan_ChangePasswordAutorization = new Spartan_ChangePasswordAutorizationModel();
			
            ViewBag.ObjectId = "135";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_ChangePasswordAutorizationApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_ChangePasswordAutorizationData = _ISpartan_ChangePasswordAutorizationApiConsumer.GetByKeyComplete(Id).Resource.Spartan_ChangePasswordAutorizations[0];
                if (Spartan_ChangePasswordAutorizationData == null)
                    return HttpNotFound();

                varSpartan_ChangePasswordAutorization = new Spartan_ChangePasswordAutorizationModel
                {
                    Clave = (int)Spartan_ChangePasswordAutorizationData.Clave
                    ,Fecha_de_Registro = (Spartan_ChangePasswordAutorizationData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Spartan_ChangePasswordAutorizationData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Spartan_ChangePasswordAutorizationData.Hora_de_Registro
                    ,Usuario = Spartan_ChangePasswordAutorizationData.Usuario
                    ,UsuarioName =  (string)Spartan_ChangePasswordAutorizationData.Usuario_Spartan_User.Name
                    ,Estatus = Spartan_ChangePasswordAutorizationData.Estatus
                    ,EstatusDescripcion =  (string)Spartan_ChangePasswordAutorizationData.Estatus_SpartanChangePasswordAutorizationEstatus.Descripcion
                    ,Email = Spartan_ChangePasswordAutorizationData.Email

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario != null && Spartan_Users_Usuario.Resource != null)
                ViewBag.Spartan_Users_Usuario = Spartan_Users_Usuario.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ISpartanChangePasswordAutorizationEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var SpartanChangePasswordAutorizationEstatuss_Estatus = _ISpartanChangePasswordAutorizationEstatusApiConsumer.SelAll(true);
            if (SpartanChangePasswordAutorizationEstatuss_Estatus != null && SpartanChangePasswordAutorizationEstatuss_Estatus.Resource != null)
                ViewBag.SpartanChangePasswordAutorizationEstatuss_Estatus = SpartanChangePasswordAutorizationEstatuss_Estatus.Resource.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_ChangePasswordAutorization);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_ChangePasswordAutorization(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 135);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_ChangePasswordAutorizationApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_ChangePasswordAutorizationModel varSpartan_ChangePasswordAutorization= new Spartan_ChangePasswordAutorizationModel();


            if (id.ToString() != "0")
            {
                var Spartan_ChangePasswordAutorizationsData = _ISpartan_ChangePasswordAutorizationApiConsumer.ListaSelAll(0, 1000, "Clave=" + id, "").Resource.Spartan_ChangePasswordAutorizations;
				
				if (Spartan_ChangePasswordAutorizationsData != null && Spartan_ChangePasswordAutorizationsData.Count > 0)
                {
					var Spartan_ChangePasswordAutorizationData = Spartan_ChangePasswordAutorizationsData.First();
					varSpartan_ChangePasswordAutorization= new Spartan_ChangePasswordAutorizationModel
					{
						Clave  = Spartan_ChangePasswordAutorizationData.Clave 
	                    ,Fecha_de_Registro = (Spartan_ChangePasswordAutorizationData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Spartan_ChangePasswordAutorizationData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Spartan_ChangePasswordAutorizationData.Hora_de_Registro
                    ,Usuario = Spartan_ChangePasswordAutorizationData.Usuario
                    ,UsuarioName =  (string)Spartan_ChangePasswordAutorizationData.Usuario_Spartan_User.Name
                    ,Estatus = Spartan_ChangePasswordAutorizationData.Estatus
                    ,EstatusDescripcion =  (string)Spartan_ChangePasswordAutorizationData.Estatus_SpartanChangePasswordAutorizationEstatus.Descripcion
                    ,Email = Spartan_ChangePasswordAutorizationData.Email

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario != null && Spartan_Users_Usuario.Resource != null)
                ViewBag.Spartan_Users_Usuario = Spartan_Users_Usuario.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ISpartanChangePasswordAutorizationEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var SpartanChangePasswordAutorizationEstatuss_Estatus = _ISpartanChangePasswordAutorizationEstatusApiConsumer.SelAll(true);
            if (SpartanChangePasswordAutorizationEstatuss_Estatus != null && SpartanChangePasswordAutorizationEstatuss_Estatus.Resource != null)
                ViewBag.SpartanChangePasswordAutorizationEstatuss_Estatus = SpartanChangePasswordAutorizationEstatuss_Estatus.Resource.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddSpartan_ChangePasswordAutorization", varSpartan_ChangePasswordAutorization);
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
        public ActionResult GetSpartanChangePasswordAutorizationEstatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartanChangePasswordAutorizationEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartanChangePasswordAutorizationEstatusApiConsumer.SelAll(false).Resource;
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
        public ActionResult ShowAdvanceFilter(Spartan_ChangePasswordAutorizationAdvanceSearchModel model, int idFilter = -1)
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
            var Spartan_Users_Usuario = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario != null && Spartan_Users_Usuario.Resource != null)
                ViewBag.Spartan_Users_Usuario = Spartan_Users_Usuario.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ISpartanChangePasswordAutorizationEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var SpartanChangePasswordAutorizationEstatuss_Estatus = _ISpartanChangePasswordAutorizationEstatusApiConsumer.SelAll(true);
            if (SpartanChangePasswordAutorizationEstatuss_Estatus != null && SpartanChangePasswordAutorizationEstatuss_Estatus.Resource != null)
                ViewBag.SpartanChangePasswordAutorizationEstatuss_Estatus = SpartanChangePasswordAutorizationEstatuss_Estatus.Resource.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario != null && Spartan_Users_Usuario.Resource != null)
                ViewBag.Spartan_Users_Usuario = Spartan_Users_Usuario.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ISpartanChangePasswordAutorizationEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var SpartanChangePasswordAutorizationEstatuss_Estatus = _ISpartanChangePasswordAutorizationEstatusApiConsumer.SelAll(true);
            if (SpartanChangePasswordAutorizationEstatuss_Estatus != null && SpartanChangePasswordAutorizationEstatuss_Estatus.Resource != null)
                ViewBag.SpartanChangePasswordAutorizationEstatuss_Estatus = SpartanChangePasswordAutorizationEstatuss_Estatus.Resource.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            var previousFiltersObj = new Spartan_ChangePasswordAutorizationAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Spartan_ChangePasswordAutorizationAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Spartan_ChangePasswordAutorizationAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_ChangePasswordAutorizationPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_ChangePasswordAutorizationApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_ChangePasswordAutorizations == null)
                result.Spartan_ChangePasswordAutorizations = new List<Spartan_ChangePasswordAutorization>();

            return Json(new
            {
                data = result.Spartan_ChangePasswordAutorizations.Select(m => new Spartan_ChangePasswordAutorizationGridModel
                    {
                    Clave = m.Clave
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,UsuarioName = (string)m.Usuario_Spartan_User.Name
                        ,EstatusDescripcion = (string)m.Estatus_SpartanChangePasswordAutorizationEstatus.Descripcion
			,Email = m.Email

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_ChangePasswordAutorization from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_ChangePasswordAutorization Entity</returns>
        public ActionResult GetSpartan_ChangePasswordAutorizationList(int sEcho, int iDisplayStart, int iDisplayLength, string where, string order)
        {
            order = "Spartan_ChangePasswordAutorization.Clave DESC";
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
            _ISpartan_ChangePasswordAutorizationApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_ChangePasswordAutorizationPropertyMapper());
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
				if (Session["AdvanceSearch"].GetType() == typeof(Spartan_ChangePasswordAutorizationAdvanceSearchModel))
                {
					var advanceFilter =
                    (Spartan_ChangePasswordAutorizationAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Spartan_ChangePasswordAutorizationPropertyMapper oSpartan_ChangePasswordAutorizationPropertyMapper = new Spartan_ChangePasswordAutorizationPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = oSpartan_ChangePasswordAutorizationPropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISpartan_ChangePasswordAutorizationApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_ChangePasswordAutorizations == null)
                result.Spartan_ChangePasswordAutorizations = new List<Spartan_ChangePasswordAutorization>();

            return Json(new
            {
                aaData = result.Spartan_ChangePasswordAutorizations.Select(m => new Spartan_ChangePasswordAutorizationGridModel
            {
                    Clave = m.Clave
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,UsuarioName = (string)m.Usuario_Spartan_User.Name
                        ,EstatusDescripcion = (string)m.Estatus_SpartanChangePasswordAutorizationEstatus.Descripcion
			,Email = m.Email

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(Spartan_ChangePasswordAutorizationAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromClave) || !string.IsNullOrEmpty(filter.ToClave))
            {
                if (!string.IsNullOrEmpty(filter.FromClave))
                    where += " AND Spartan_ChangePasswordAutorization.Clave >= " + filter.FromClave;
                if (!string.IsNullOrEmpty(filter.ToClave))
                    where += " AND Spartan_ChangePasswordAutorization.Clave <= " + filter.ToClave;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Spartan_ChangePasswordAutorization.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Spartan_ChangePasswordAutorization.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Spartan_ChangePasswordAutorization.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Spartan_ChangePasswordAutorization.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceUsuario))
            {
                switch (filter.UsuarioFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.AdvanceUsuario + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.AdvanceUsuario + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario + "%'";
                        break;
                }
            }
            else if (filter.AdvanceUsuarioMultiple != null && filter.AdvanceUsuarioMultiple.Count() > 0)
            {
                var UsuarioIds = string.Join(",", filter.AdvanceUsuarioMultiple);

                where += " AND Spartan_ChangePasswordAutorization.Usuario In (" + UsuarioIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEstatus))
            {
                switch (filter.EstatusFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND SpartanChangePasswordAutorizationEstatus.Descripcion LIKE '" + filter.AdvanceEstatus + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND SpartanChangePasswordAutorizationEstatus.Descripcion LIKE '%" + filter.AdvanceEstatus + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND SpartanChangePasswordAutorizationEstatus.Descripcion = '" + filter.AdvanceEstatus + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND SpartanChangePasswordAutorizationEstatus.Descripcion LIKE '%" + filter.AdvanceEstatus + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEstatusMultiple != null && filter.AdvanceEstatusMultiple.Count() > 0)
            {
                var EstatusIds = string.Join(",", filter.AdvanceEstatusMultiple);

                where += " AND Spartan_ChangePasswordAutorization.Estatus In (" + EstatusIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Email))
            {
                switch (filter.EmailFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_ChangePasswordAutorization.Email LIKE '" + filter.Email + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_ChangePasswordAutorization.Email LIKE '%" + filter.Email + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_ChangePasswordAutorization.Email = '" + filter.Email + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_ChangePasswordAutorization.Email LIKE '%" + filter.Email + "%'";
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
                _ISpartan_ChangePasswordAutorizationApiConsumer.SetAuthHeader(_tokenManager.Token);

                Spartan_ChangePasswordAutorization varSpartan_ChangePasswordAutorization = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _ISpartan_ChangePasswordAutorizationApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_ChangePasswordAutorizationModel varSpartan_ChangePasswordAutorization)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_ChangePasswordAutorizationApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Spartan_ChangePasswordAutorizationInfo = new Spartan_ChangePasswordAutorization
                    {
                        Clave = varSpartan_ChangePasswordAutorization.Clave
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varSpartan_ChangePasswordAutorization.Fecha_de_Registro)) ? DateTime.ParseExact(varSpartan_ChangePasswordAutorization.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varSpartan_ChangePasswordAutorization.Hora_de_Registro
                        ,Usuario = varSpartan_ChangePasswordAutorization.Usuario
                        ,Estatus = varSpartan_ChangePasswordAutorization.Estatus
                        ,Email = varSpartan_ChangePasswordAutorization.Email

                    };

                    result = !IsNew ?
                        _ISpartan_ChangePasswordAutorizationApiConsumer.Update(Spartan_ChangePasswordAutorizationInfo, null, null).Resource.ToString() :
                         _ISpartan_ChangePasswordAutorizationApiConsumer.Insert(Spartan_ChangePasswordAutorizationInfo, null, null).Resource.ToString();
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
        /// Write Element Array of Spartan_ChangePasswordAutorization script
        /// </summary>
        /// <param name="oSpartan_ChangePasswordAutorizationElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Spartan_ChangePasswordAutorizationModuleAttributeList)
        {
            for (int i = 0; i < Spartan_ChangePasswordAutorizationModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_ChangePasswordAutorizationModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_ChangePasswordAutorizationModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_ChangePasswordAutorizationModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_ChangePasswordAutorizationModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_ChangePasswordAutorizationModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_ChangePasswordAutorizationModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Spartan_ChangePasswordAutorizationModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Spartan_ChangePasswordAutorizationModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Spartan_ChangePasswordAutorizationModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Spartan_ChangePasswordAutorizationModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Spartan_ChangePasswordAutorizationModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strSpartan_ChangePasswordAutorizationScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_ChangePasswordAutorization.js")))
            {
                strSpartan_ChangePasswordAutorizationScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_ChangePasswordAutorization element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_ChangePasswordAutorizationModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_ChangePasswordAutorizationScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_ChangePasswordAutorizationScript.Substring(indexOfArray, strSpartan_ChangePasswordAutorizationScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_ChangePasswordAutorizationModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_ChangePasswordAutorizationModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_ChangePasswordAutorizationScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strSpartan_ChangePasswordAutorizationScript.Substring(indexOfArrayHistory, strSpartan_ChangePasswordAutorizationScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strSpartan_ChangePasswordAutorizationScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_ChangePasswordAutorizationScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_ChangePasswordAutorizationScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Spartan_ChangePasswordAutorizationModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Spartan_ChangePasswordAutorizationModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_ChangePasswordAutorization.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_ChangePasswordAutorization.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_ChangePasswordAutorization.js")))
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
        public ActionResult Spartan_ChangePasswordAutorizationPropertyBag()
        {
            return PartialView("Spartan_ChangePasswordAutorizationPropertyBag", "Spartan_ChangePasswordAutorization");
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

            _ISpartan_ChangePasswordAutorizationApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_ChangePasswordAutorizationPropertyMapper());
				
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
                    (Spartan_ChangePasswordAutorizationAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_ChangePasswordAutorizationApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_ChangePasswordAutorizations == null)
                result.Spartan_ChangePasswordAutorizations = new List<Spartan_ChangePasswordAutorization>();

            var data = result.Spartan_ChangePasswordAutorizations.Select(m => new Spartan_ChangePasswordAutorizationGridModel
            {
                Clave = m.Clave
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,UsuarioName = (string)m.Usuario_Spartan_User.Name
                        ,EstatusDescripcion = (string)m.Estatus_SpartanChangePasswordAutorizationEstatus.Descripcion
			,Email = m.Email

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_ChangePasswordAutorizationList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_ChangePasswordAutorizationList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "Spartan_ChangePasswordAutorizationList_" + DateTime.Now.ToString());
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

            _ISpartan_ChangePasswordAutorizationApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_ChangePasswordAutorizationPropertyMapper());

			if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
			
			
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_ChangePasswordAutorizationApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_ChangePasswordAutorizations == null)
                result.Spartan_ChangePasswordAutorizations = new List<Spartan_ChangePasswordAutorization>();

            var data = result.Spartan_ChangePasswordAutorizations.Select(m => new Spartan_ChangePasswordAutorizationGridModel
            {
                Clave = m.Clave
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,UsuarioName = (string)m.Usuario_Spartan_User.Name
                        ,EstatusDescripcion = (string)m.Estatus_SpartanChangePasswordAutorizationEstatus.Descripcion
			,Email = m.Email

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
