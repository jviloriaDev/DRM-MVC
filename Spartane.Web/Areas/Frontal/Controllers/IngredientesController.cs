using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Ingredientes;
using Spartane.Core.Domain.Clasificacion_Ingredientes;
using Spartane.Core.Domain.Detalle_Caracteristicas_Ingrediente;





using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Ingredientes;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Ingredientes;
using Spartane.Web.Areas.WebApiConsumer.Clasificacion_Ingredientes;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Caracteristicas_Ingrediente;



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


namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class IngredientesController : Controller
    {
        #region "variable declaration"

        private IIngredientesService service = null;
        private IIngredientesApiConsumer _IIngredientesApiConsumer;
        private IClasificacion_IngredientesApiConsumer _IClasificacion_IngredientesApiConsumer;
        private IDetalle_Caracteristicas_IngredienteApiConsumer _IDetalle_Caracteristicas_IngredienteApiConsumer;



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

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public IngredientesController(IIngredientesService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IIngredientesApiConsumer IngredientesApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , IClasificacion_IngredientesApiConsumer Clasificacion_IngredientesApiConsumer , IDetalle_Caracteristicas_IngredienteApiConsumer Detalle_Caracteristicas_IngredienteApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IIngredientesApiConsumer = IngredientesApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
			this._ISpartan_FormatRelatedApiConsumer = Spartan_Format_RelatedApiConsumer;
            this._IClasificacion_IngredientesApiConsumer = Clasificacion_IngredientesApiConsumer;
            this._IDetalle_Caracteristicas_IngredienteApiConsumer = Detalle_Caracteristicas_IngredienteApiConsumer;



        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Ingredientes
        [ObjectAuth(ObjectId = (ModuleObjectId)43960, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 43960, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Ingredientes/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)43960, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 43960, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varIngredientes = new IngredientesModel();
			varIngredientes.Clave = Id;
			
            ViewBag.ObjectId = "43960";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionDetalle_Caracteristicas_Ingrediente = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44550, ModuleId);
            ViewBag.PermissionDetalle_Caracteristicas_Ingrediente = permissionDetalle_Caracteristicas_Ingrediente;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var IngredientessData = _IIngredientesApiConsumer.ListaSelAll(0, 1000, "Ingredientes.Clave=" + Id, "").Resource.Ingredientess;
				
				if (IngredientessData != null && IngredientessData.Count > 0)
                {
					var IngredientesData = IngredientessData.First();
					varIngredientes= new IngredientesModel
					{
						Clave  = IngredientesData.Clave 
	                    ,Nombre_Ingrediente = IngredientesData.Nombre_Ingrediente
                    ,Clasificacion = IngredientesData.Clasificacion
                    ,ClasificacionDescripcion = CultureHelper.GetTraduction(Convert.ToString(IngredientesData.Clasificacion), "Clasificacion_Ingredientes") ??  (string)IngredientesData.Clasificacion_Clasificacion_Ingredientes.Descripcion
                    ,Imagen = IngredientesData.Imagen
                    ,Subgrupo = IngredientesData.Subgrupo
                    ,Cantidad_sugerida = IngredientesData.Cantidad_sugerida
                    ,Unidad = IngredientesData.Unidad
                    ,Peso_bruto_redondeado_g = IngredientesData.Peso_bruto_redondeado_g
                    ,Peso_neto_g = IngredientesData.Peso_neto_g
                    ,Nombre_sistema_anterior = IngredientesData.Nombre_sistema_anterior

					};
				}
				
				                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.ImagenSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varIngredientes.Imagen).Resource;

				
            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

	    _IClasificacion_IngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Clasificacion_Ingredientess_Clasificacion = _IClasificacion_IngredientesApiConsumer.SelAll(true);
            if (Clasificacion_Ingredientess_Clasificacion != null && Clasificacion_Ingredientess_Clasificacion.Resource != null)
                ViewBag.Clasificacion_Ingredientess_Clasificacion = Clasificacion_Ingredientess_Clasificacion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Clasificacion_Ingredientes", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
				
			var isPartial = false;
            var isMR = false;
            var nameMR = string.Empty;
            var nameAttribute = string.Empty;

	        if (Request.QueryString["isPartial"]!= null)
                isPartial = Convert.ToBoolean(Request.QueryString["isPartial"]);

            if (Request.QueryString["isMR"] != null)
                isMR = Convert.ToBoolean(Request.QueryString["isMR"]);

            if (Request.QueryString["nameMR"] != null)
                nameMR = Request.QueryString["nameMR"].ToString();

            if (Request.QueryString["nameAttribute"] != null)
                nameAttribute = Request.QueryString["nameAttribute"].ToString();
				
			ViewBag.isPartial=isPartial;
			ViewBag.isMR=isMR;
			ViewBag.nameMR=nameMR;
			ViewBag.nameAttribute=nameAttribute;

				
            return View(varIngredientes);
        }
		
	[HttpGet]
        public ActionResult AddIngredientes(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 43960);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
			IngredientesModel varIngredientes= new IngredientesModel();
            var permissionDetalle_Caracteristicas_Ingrediente = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44550, ModuleId);
            ViewBag.PermissionDetalle_Caracteristicas_Ingrediente = permissionDetalle_Caracteristicas_Ingrediente;


            if (id.ToString() != "0")
            {
                var IngredientessData = _IIngredientesApiConsumer.ListaSelAll(0, 1000, "Ingredientes.Clave=" + id, "").Resource.Ingredientess;
				
				if (IngredientessData != null && IngredientessData.Count > 0)
                {
					var IngredientesData = IngredientessData.First();
					varIngredientes= new IngredientesModel
					{
						Clave  = IngredientesData.Clave 
	                    ,Nombre_Ingrediente = IngredientesData.Nombre_Ingrediente
                    ,Clasificacion = IngredientesData.Clasificacion
                    ,ClasificacionDescripcion = CultureHelper.GetTraduction(Convert.ToString(IngredientesData.Clasificacion), "Clasificacion_Ingredientes") ??  (string)IngredientesData.Clasificacion_Clasificacion_Ingredientes.Descripcion
                    ,Imagen = IngredientesData.Imagen
                    ,Subgrupo = IngredientesData.Subgrupo
                    ,Cantidad_sugerida = IngredientesData.Cantidad_sugerida
                    ,Unidad = IngredientesData.Unidad
                    ,Peso_bruto_redondeado_g = IngredientesData.Peso_bruto_redondeado_g
                    ,Peso_neto_g = IngredientesData.Peso_neto_g
                    ,Nombre_sistema_anterior = IngredientesData.Nombre_sistema_anterior

					};
				}
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.ImagenSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varIngredientes.Imagen).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

	    _IClasificacion_IngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Clasificacion_Ingredientess_Clasificacion = _IClasificacion_IngredientesApiConsumer.SelAll(true);
            if (Clasificacion_Ingredientess_Clasificacion != null && Clasificacion_Ingredientess_Clasificacion.Resource != null)
                ViewBag.Clasificacion_Ingredientess_Clasificacion = Clasificacion_Ingredientess_Clasificacion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Clasificacion_Ingredientes", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddIngredientes", varIngredientes);
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
        public ActionResult GetClasificacion_IngredientesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IClasificacion_IngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IClasificacion_IngredientesApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Clasificacion_Ingredientes", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
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
        public ActionResult ShowAdvanceFilter(IngredientesAdvanceSearchModel model, int idFilter = -1)
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

	    _IClasificacion_IngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Clasificacion_Ingredientess_Clasificacion = _IClasificacion_IngredientesApiConsumer.SelAll(true);
            if (Clasificacion_Ingredientess_Clasificacion != null && Clasificacion_Ingredientess_Clasificacion.Resource != null)
                ViewBag.Clasificacion_Ingredientess_Clasificacion = Clasificacion_Ingredientess_Clasificacion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Clasificacion_Ingredientes", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

	    _IClasificacion_IngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Clasificacion_Ingredientess_Clasificacion = _IClasificacion_IngredientesApiConsumer.SelAll(true);
            if (Clasificacion_Ingredientess_Clasificacion != null && Clasificacion_Ingredientess_Clasificacion.Resource != null)
                ViewBag.Clasificacion_Ingredientess_Clasificacion = Clasificacion_Ingredientess_Clasificacion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Clasificacion_Ingredientes", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            var previousFiltersObj = new IngredientesAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (IngredientesAdvanceSearchModel)(Session["AdvanceSearch"] ?? new IngredientesAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new IngredientesPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IIngredientesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Ingredientess == null)
                result.Ingredientess = new List<Ingredientes>();

            return Json(new
            {
                data = result.Ingredientess.Select(m => new IngredientesGridModel
                    {
                    Clave = m.Clave
			,Nombre_Ingrediente = m.Nombre_Ingrediente
                        ,ClasificacionDescripcion = CultureHelper.GetTraduction(m.Clasificacion_Clasificacion_Ingredientes.Clave.ToString(), "Clasificacion_Ingredientes") ?? (string)m.Clasificacion_Clasificacion_Ingredientes.Descripcion
			,Imagen = m.Imagen
			,Subgrupo = m.Subgrupo
			,Cantidad_sugerida = m.Cantidad_sugerida
			,Unidad = m.Unidad
			,Peso_bruto_redondeado_g = m.Peso_bruto_redondeado_g
			,Peso_neto_g = m.Peso_neto_g
			,Nombre_sistema_anterior = m.Nombre_sistema_anterior

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetIngredientesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IIngredientesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Clave), "Ingredientes", m.),
                     Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
*/
        /// <summary>
        /// Get List of Ingredientes from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Ingredientes Entity</returns>
        public ActionResult GetIngredientesList(UrlParametersModel param)
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
            _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new IngredientesPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(IngredientesAdvanceSearchModel))
                {
					var advanceFilter =
                    (IngredientesAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            IngredientesPropertyMapper oIngredientesPropertyMapper = new IngredientesPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oIngredientesPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IIngredientesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Ingredientess == null)
                result.Ingredientess = new List<Ingredientes>();

            return Json(new
            {
                aaData = result.Ingredientess.Select(m => new IngredientesGridModel
            {
                    Clave = m.Clave
			,Nombre_Ingrediente = m.Nombre_Ingrediente
                        ,ClasificacionDescripcion = CultureHelper.GetTraduction(m.Clasificacion_Clasificacion_Ingredientes.Clave.ToString(), "Clasificacion_Ingredientes") ?? (string)m.Clasificacion_Clasificacion_Ingredientes.Descripcion
			,Imagen = m.Imagen
			,Subgrupo = m.Subgrupo
			,Cantidad_sugerida = m.Cantidad_sugerida
			,Unidad = m.Unidad
			,Peso_bruto_redondeado_g = m.Peso_bruto_redondeado_g
			,Peso_neto_g = m.Peso_neto_g
			,Nombre_sistema_anterior = m.Nombre_sistema_anterior

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetIngredientes_Clasificacion_Clasificacion_Ingredientes(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IClasificacion_IngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Clasificacion_Ingredientes.Clave as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Clasificacion_Ingredientes.Descripcion as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _IClasificacion_IngredientesApiConsumer.ListaSelAll(1, 20,elWhere , " Clasificacion_Ingredientes.Descripcion ASC ").Resource;
               
                foreach (var item in result.Clasificacion_Ingredientess)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Clasificacion_Ingredientes", "Descripcion");
                    item.Descripcion =trans ??item.Descripcion;
                }
                return Json(result.Clasificacion_Ingredientess.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(IngredientesAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromClave) || !string.IsNullOrEmpty(filter.ToClave))
            {
                if (!string.IsNullOrEmpty(filter.FromClave))
                    where += " AND Ingredientes.Clave >= " + filter.FromClave;
                if (!string.IsNullOrEmpty(filter.ToClave))
                    where += " AND Ingredientes.Clave <= " + filter.ToClave;
            }

            if (!string.IsNullOrEmpty(filter.Nombre_Ingrediente))
            {
                switch (filter.Nombre_IngredienteFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Ingredientes.Nombre_Ingrediente LIKE '" + filter.Nombre_Ingrediente + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Ingredientes.Nombre_Ingrediente LIKE '%" + filter.Nombre_Ingrediente + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Ingredientes.Nombre_Ingrediente = '" + filter.Nombre_Ingrediente + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Ingredientes.Nombre_Ingrediente LIKE '%" + filter.Nombre_Ingrediente + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceClasificacion))
            {
                switch (filter.ClasificacionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Clasificacion_Ingredientes.Descripcion LIKE '" + filter.AdvanceClasificacion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Clasificacion_Ingredientes.Descripcion LIKE '%" + filter.AdvanceClasificacion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Clasificacion_Ingredientes.Descripcion = '" + filter.AdvanceClasificacion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Clasificacion_Ingredientes.Descripcion LIKE '%" + filter.AdvanceClasificacion + "%'";
                        break;
                }
            }
            else if (filter.AdvanceClasificacionMultiple != null && filter.AdvanceClasificacionMultiple.Count() > 0)
            {
                var ClasificacionIds = string.Join(",", filter.AdvanceClasificacionMultiple);

                where += " AND Ingredientes.Clasificacion In (" + ClasificacionIds + ")";
            }

            if (filter.Imagen != RadioOptions.NoApply)
                where += " AND Ingredientes.Imagen " + (filter.Imagen == RadioOptions.Yes ? ">" : "==") + " 0";

            if (!string.IsNullOrEmpty(filter.Subgrupo))
            {
                switch (filter.SubgrupoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Ingredientes.Subgrupo LIKE '" + filter.Subgrupo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Ingredientes.Subgrupo LIKE '%" + filter.Subgrupo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Ingredientes.Subgrupo = '" + filter.Subgrupo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Ingredientes.Subgrupo LIKE '%" + filter.Subgrupo + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromCantidad_sugerida) || !string.IsNullOrEmpty(filter.ToCantidad_sugerida))
            {
                if (!string.IsNullOrEmpty(filter.FromCantidad_sugerida))
                    where += " AND Ingredientes.Cantidad_sugerida >= " + filter.FromCantidad_sugerida;
                if (!string.IsNullOrEmpty(filter.ToCantidad_sugerida))
                    where += " AND Ingredientes.Cantidad_sugerida <= " + filter.ToCantidad_sugerida;
            }

            if (!string.IsNullOrEmpty(filter.Unidad))
            {
                switch (filter.UnidadFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Ingredientes.Unidad LIKE '" + filter.Unidad + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Ingredientes.Unidad LIKE '%" + filter.Unidad + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Ingredientes.Unidad = '" + filter.Unidad + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Ingredientes.Unidad LIKE '%" + filter.Unidad + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromPeso_bruto_redondeado_g) || !string.IsNullOrEmpty(filter.ToPeso_bruto_redondeado_g))
            {
                if (!string.IsNullOrEmpty(filter.FromPeso_bruto_redondeado_g))
                    where += " AND Ingredientes.Peso_bruto_redondeado_g >= " + filter.FromPeso_bruto_redondeado_g;
                if (!string.IsNullOrEmpty(filter.ToPeso_bruto_redondeado_g))
                    where += " AND Ingredientes.Peso_bruto_redondeado_g <= " + filter.ToPeso_bruto_redondeado_g;
            }

            if (!string.IsNullOrEmpty(filter.FromPeso_neto_g) || !string.IsNullOrEmpty(filter.ToPeso_neto_g))
            {
                if (!string.IsNullOrEmpty(filter.FromPeso_neto_g))
                    where += " AND Ingredientes.Peso_neto_g >= " + filter.FromPeso_neto_g;
                if (!string.IsNullOrEmpty(filter.ToPeso_neto_g))
                    where += " AND Ingredientes.Peso_neto_g <= " + filter.ToPeso_neto_g;
            }

            if (!string.IsNullOrEmpty(filter.Nombre_sistema_anterior))
            {
                switch (filter.Nombre_sistema_anteriorFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Ingredientes.Nombre_sistema_anterior LIKE '" + filter.Nombre_sistema_anterior + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Ingredientes.Nombre_sistema_anterior LIKE '%" + filter.Nombre_sistema_anterior + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Ingredientes.Nombre_sistema_anterior = '" + filter.Nombre_sistema_anterior + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Ingredientes.Nombre_sistema_anterior LIKE '%" + filter.Nombre_sistema_anterior + "%'";
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

        public ActionResult GetDetalle_Caracteristicas_Ingrediente(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Caracteristicas_IngredienteGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Caracteristicas_IngredienteApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Caracteristicas_Ingrediente.Folio_Ingrediente=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Caracteristicas_Ingrediente.Folio_Ingrediente='" + RelationId + "'";
            }
            var result = _IDetalle_Caracteristicas_IngredienteApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Caracteristicas_Ingredientes == null)
                result.Detalle_Caracteristicas_Ingredientes = new List<Detalle_Caracteristicas_Ingrediente>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Caracteristicas_Ingredientes.Select(m => new Detalle_Caracteristicas_IngredienteGridModel
                {
                    Folio = m.Folio

			,Caracteristica_combo = m.Caracteristica_combo
			,Descripcion_texto = m.Descripcion_texto

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Caracteristicas_IngredienteGridModel> GetDetalle_Caracteristicas_IngredienteData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Caracteristicas_IngredienteGridModel> resultData = new List<Detalle_Caracteristicas_IngredienteGridModel>();
            string where = "Detalle_Caracteristicas_Ingrediente.Folio_Ingrediente=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Caracteristicas_Ingrediente.Folio_Ingrediente='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Caracteristicas_IngredienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Caracteristicas_IngredienteApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Caracteristicas_Ingredientes != null)
            {
                resultData = result.Detalle_Caracteristicas_Ingredientes.Select(m => new Detalle_Caracteristicas_IngredienteGridModel
                    {
                        Folio = m.Folio

			,Caracteristica_combo = m.Caracteristica_combo
			,Descripcion_texto = m.Descripcion_texto


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);

                Ingredientes varIngredientes = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IDetalle_Caracteristicas_IngredienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Caracteristicas_Ingrediente.Folio_Ingrediente=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Caracteristicas_Ingrediente.Folio_Ingrediente='" + id + "'";
                    }
                    var Detalle_Caracteristicas_IngredienteInfo =
                        _IDetalle_Caracteristicas_IngredienteApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Caracteristicas_IngredienteInfo.Detalle_Caracteristicas_Ingredientes.Count > 0)
                    {
                        var resultDetalle_Caracteristicas_Ingrediente = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Caracteristicas_IngredienteItem in Detalle_Caracteristicas_IngredienteInfo.Detalle_Caracteristicas_Ingredientes)
                            resultDetalle_Caracteristicas_Ingrediente = resultDetalle_Caracteristicas_Ingrediente
                                              && _IDetalle_Caracteristicas_IngredienteApiConsumer.Delete(Detalle_Caracteristicas_IngredienteItem.Folio, null,null).Resource;

                        if (!resultDetalle_Caracteristicas_Ingrediente)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IIngredientesApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, IngredientesModel varIngredientes)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);


                    if (varIngredientes.ImagenRemoveAttachment != 0 && varIngredientes.ImagenFile == null)
                    {
                        varIngredientes.Imagen = 0;
                    }

                    if (varIngredientes.ImagenFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varIngredientes.ImagenFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varIngredientes.Imagen = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varIngredientes.ImagenFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                    
                    var result = "";
                    var IngredientesInfo = new Ingredientes
                    {
                        Clave = varIngredientes.Clave
                        ,Nombre_Ingrediente = varIngredientes.Nombre_Ingrediente
                        ,Clasificacion = varIngredientes.Clasificacion
                        ,Imagen = (varIngredientes.Imagen.HasValue && varIngredientes.Imagen != 0) ? ((int?)Convert.ToInt32(varIngredientes.Imagen.Value)) : null

                        ,Subgrupo = varIngredientes.Subgrupo
                        ,Cantidad_sugerida = varIngredientes.Cantidad_sugerida
                        ,Unidad = varIngredientes.Unidad
                        ,Peso_bruto_redondeado_g = varIngredientes.Peso_bruto_redondeado_g
                        ,Peso_neto_g = varIngredientes.Peso_neto_g
                        ,Nombre_sistema_anterior = varIngredientes.Nombre_sistema_anterior

                    };

                    result = !IsNew ?
                        _IIngredientesApiConsumer.Update(IngredientesInfo, null, null).Resource.ToString() :
                         _IIngredientesApiConsumer.Insert(IngredientesInfo, null, null).Resource.ToString();
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
        public bool CopyDetalle_Caracteristicas_Ingrediente(int MasterId, int referenceId, List<Detalle_Caracteristicas_IngredienteGridModelPost> Detalle_Caracteristicas_IngredienteItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Caracteristicas_IngredienteApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Caracteristicas_IngredienteData = _IDetalle_Caracteristicas_IngredienteApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Caracteristicas_Ingrediente.Folio_Ingrediente=" + referenceId,"").Resource;
                if (Detalle_Caracteristicas_IngredienteData == null || Detalle_Caracteristicas_IngredienteData.Detalle_Caracteristicas_Ingredientes.Count == 0)
                    return true;

                var result = true;

                Detalle_Caracteristicas_IngredienteGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Caracteristicas_Ingrediente in Detalle_Caracteristicas_IngredienteData.Detalle_Caracteristicas_Ingredientes)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Caracteristicas_Ingrediente Detalle_Caracteristicas_Ingrediente1 = varDetalle_Caracteristicas_Ingrediente;

                    if (Detalle_Caracteristicas_IngredienteItems != null && Detalle_Caracteristicas_IngredienteItems.Any(m => m.Folio == Detalle_Caracteristicas_Ingrediente1.Folio))
                    {
                        modelDataToChange = Detalle_Caracteristicas_IngredienteItems.FirstOrDefault(m => m.Folio == Detalle_Caracteristicas_Ingrediente1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Caracteristicas_Ingrediente.Folio_Ingrediente = MasterId;
                    var insertId = _IDetalle_Caracteristicas_IngredienteApiConsumer.Insert(varDetalle_Caracteristicas_Ingrediente,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.Folio = insertId;

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
        public ActionResult PostDetalle_Caracteristicas_Ingrediente(List<Detalle_Caracteristicas_IngredienteGridModelPost> Detalle_Caracteristicas_IngredienteItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Caracteristicas_Ingrediente(MasterId, referenceId, Detalle_Caracteristicas_IngredienteItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Caracteristicas_IngredienteItems != null && Detalle_Caracteristicas_IngredienteItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Caracteristicas_IngredienteApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Caracteristicas_IngredienteItem in Detalle_Caracteristicas_IngredienteItems)
                    {




                        //Removal Request
                        if (Detalle_Caracteristicas_IngredienteItem.Removed)
                        {
                            result = result && _IDetalle_Caracteristicas_IngredienteApiConsumer.Delete(Detalle_Caracteristicas_IngredienteItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Caracteristicas_IngredienteItem.Folio = 0;

                        var Detalle_Caracteristicas_IngredienteData = new Detalle_Caracteristicas_Ingrediente
                        {
                            Folio_Ingrediente = MasterId
                            ,Folio = Detalle_Caracteristicas_IngredienteItem.Folio
                            ,Caracteristica_combo = Detalle_Caracteristicas_IngredienteItem.Caracteristica_combo
                            ,Descripcion_texto = Detalle_Caracteristicas_IngredienteItem.Descripcion_texto

                        };

                        var resultId = Detalle_Caracteristicas_IngredienteItem.Folio > 0
                           ? _IDetalle_Caracteristicas_IngredienteApiConsumer.Update(Detalle_Caracteristicas_IngredienteData,null,null).Resource
                           : _IDetalle_Caracteristicas_IngredienteApiConsumer.Insert(Detalle_Caracteristicas_IngredienteData,null,null).Resource;

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
        /// Write Element Array of Ingredientes script
        /// </summary>
        /// <param name="oIngredientesElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew IngredientesModuleAttributeList)
        {
            for (int i = 0; i < IngredientesModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(IngredientesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    IngredientesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(IngredientesModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    IngredientesModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (IngredientesModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < IngredientesModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < IngredientesModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(IngredientesModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							IngredientesModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(IngredientesModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							IngredientesModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strIngredientesScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Ingredientes.js")))
            {
                strIngredientesScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Ingredientes element attributes
            string userChangeJson = jsSerialize.Serialize(IngredientesModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strIngredientesScript.IndexOf("inpuElementArray");
            string splittedString = strIngredientesScript.Substring(indexOfArray, strIngredientesScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(IngredientesModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (IngredientesModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strIngredientesScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strIngredientesScript.Substring(indexOfArrayHistory, strIngredientesScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strIngredientesScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strIngredientesScript.Substring(endIndexOfMainElement + indexOfArray, strIngredientesScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (IngredientesModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in IngredientesModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Ingredientes.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Ingredientes.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Ingredientes.js")))
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
        public ActionResult IngredientesPropertyBag()
        {
            return PartialView("IngredientesPropertyBag", "Ingredientes");
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
        public ActionResult AddDetalle_Caracteristicas_Ingrediente(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Caracteristicas_Ingrediente/AddDetalle_Caracteristicas_Ingrediente");
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
            else {
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
                var whereClauseFormat = "Object = 43960 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Ingredientes.Clave= " + RecordId;
                            var result = _IIngredientesApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
                            if (result != null && result.Resource != null && result.Resource.RowCount > 0)
                            {
                                formatList.Add(new SelectListItem
                                {
                                    Text =  CultureHelper.GetTraductionAdd(format.FormatId.ToString(), "Format", format.Format_Name),
                                    Value = Convert.ToString(format.FormatId)
                                });
                            }
                        }
                        else
                        {
                            formatList.Add(new SelectListItem
                            {
                                Text =  CultureHelper.GetTraductionAdd(format.FormatId.ToString(), "Format", format.Format_Name),
                                Value = Convert.ToString(format.FormatId)
                            });
                        }


                    }
                }
            }
            return Json(formatList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public void Export(string format, int pageIndex, int pageSize, string iSortCol, string sSortDir, string where, string order, dynamic columnsVisible)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);
										  
			string[] arrayColumnsVisible = ((string[])columnsVisible)[0].ToString().Split(',');

			 where = HttpUtility.UrlEncode(where);
            if (!_tokenManager.GenerateToken())
                return;

            _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new IngredientesPropertyMapper());
			
			 if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            //Adding Advance Search
            if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (IngredientesAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            IngredientesPropertyMapper oIngredientesPropertyMapper = new IngredientesPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oIngredientesPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IIngredientesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Ingredientess == null)
                result.Ingredientess = new List<Ingredientes>();

            var data = result.Ingredientess.Select(m => new IngredientesGridModel
            {
                Clave = m.Clave
			,Nombre_Ingrediente = m.Nombre_Ingrediente
                        ,ClasificacionDescripcion = CultureHelper.GetTraduction(m.Clasificacion_Clasificacion_Ingredientes.Clave.ToString(), "Clasificacion_Ingredientes") ?? (string)m.Clasificacion_Clasificacion_Ingredientes.Descripcion
			,Imagen = m.Imagen
			,Subgrupo = m.Subgrupo
			,Cantidad_sugerida = m.Cantidad_sugerida
			,Unidad = m.Unidad
			,Peso_bruto_redondeado_g = m.Peso_bruto_redondeado_g
			,Peso_neto_g = m.Peso_neto_g
			,Nombre_sistema_anterior = m.Nombre_sistema_anterior

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(43960, arrayColumnsVisible), "IngredientesList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(43960, arrayColumnsVisible), "IngredientesList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(43960, arrayColumnsVisible), "IngredientesList_" + DateTime.Now.ToString());
                    break;
            }
        }

        [HttpGet]
        //[ObjectAuth(ObjectId = ModuleObjectId.EMPLEADOS_OBJECT, PermissionType = PermissionTypes.Export)]
        public ActionResult Print(string format, int pageIndex, int pageSize, string iSortCol, string sSortDir,string where, string order)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

			where = HttpUtility.UrlEncode(where);
										   
            if (!_tokenManager.GenerateToken())
                return null;

            _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new IngredientesPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (IngredientesAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            IngredientesPropertyMapper oIngredientesPropertyMapper = new IngredientesPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oIngredientesPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IIngredientesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Ingredientess == null)
                result.Ingredientess = new List<Ingredientes>();

            var data = result.Ingredientess.Select(m => new IngredientesGridModel
            {
                Clave = m.Clave
			,Nombre_Ingrediente = m.Nombre_Ingrediente
                        ,ClasificacionDescripcion = CultureHelper.GetTraduction(m.Clasificacion_Clasificacion_Ingredientes.Clave.ToString(), "Clasificacion_Ingredientes") ?? (string)m.Clasificacion_Clasificacion_Ingredientes.Descripcion
			,Imagen = m.Imagen
			,Subgrupo = m.Subgrupo
			,Cantidad_sugerida = m.Cantidad_sugerida
			,Unidad = m.Unidad
			,Peso_bruto_redondeado_g = m.Peso_bruto_redondeado_g
			,Peso_neto_g = m.Peso_neto_g
			,Nombre_sistema_anterior = m.Nombre_sistema_anterior

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
                _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IIngredientesApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Ingredientes_Datos_GeneralesModel varIngredientes)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
				                    if (varIngredientes.ImagenRemoveAttachment != 0 && varIngredientes.ImagenFile == null)
                    {
                        varIngredientes.Imagen = 0;
                    }

                    if (varIngredientes.ImagenFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varIngredientes.ImagenFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varIngredientes.Imagen = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varIngredientes.ImagenFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                var result = "";
                var Ingredientes_Datos_GeneralesInfo = new Ingredientes_Datos_Generales
                {
                    Clave = varIngredientes.Clave
                                            ,Nombre_Ingrediente = varIngredientes.Nombre_Ingrediente
                        ,Clasificacion = varIngredientes.Clasificacion
                        ,Imagen = (varIngredientes.Imagen.HasValue && varIngredientes.Imagen != 0) ? ((int?)Convert.ToInt32(varIngredientes.Imagen.Value)) : null

                        ,Subgrupo = varIngredientes.Subgrupo
                        ,Cantidad_sugerida = varIngredientes.Cantidad_sugerida
                        ,Unidad = varIngredientes.Unidad
                        ,Peso_bruto_redondeado_g = varIngredientes.Peso_bruto_redondeado_g
                        ,Peso_neto_g = varIngredientes.Peso_neto_g
                        ,Nombre_sistema_anterior = varIngredientes.Nombre_sistema_anterior
                    
                };

                result = _IIngredientesApiConsumer.Update_Datos_Generales(Ingredientes_Datos_GeneralesInfo).Resource.ToString();
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
                _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IIngredientesApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Caracteristicas_Ingrediente;
                var Detalle_Caracteristicas_IngredienteData = GetDetalle_Caracteristicas_IngredienteData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Caracteristicas_Ingrediente);

                var result = new Ingredientes_Datos_GeneralesModel
                {
                    Clave = m.Clave
			,Nombre_Ingrediente = m.Nombre_Ingrediente
                        ,Clasificacion = m.Clasificacion
                        ,ClasificacionDescripcion = CultureHelper.GetTraduction(m.Clasificacion_Clasificacion_Ingredientes.Clave.ToString(), "Clasificacion_Ingredientes") ?? (string)m.Clasificacion_Clasificacion_Ingredientes.Descripcion
			,Imagen = m.Imagen
			,Subgrupo = m.Subgrupo
			,Cantidad_sugerida = m.Cantidad_sugerida
			,Unidad = m.Unidad
			,Peso_bruto_redondeado_g = m.Peso_bruto_redondeado_g
			,Peso_neto_g = m.Peso_neto_g
			,Nombre_sistema_anterior = m.Nombre_sistema_anterior

                    
                };
				var resultData = new
                {
                    data = result
                    ,Caracteristicas_Ingrediente = Detalle_Caracteristicas_IngredienteData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

