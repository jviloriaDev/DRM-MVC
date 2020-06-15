using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Ubicaciones_Eventos_Empresa;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Empresas;
using Spartane.Core.Domain.Estatus;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Ubicaciones_Eventos_Empresa;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Ubicaciones_Eventos_Empresa;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Respuesta_Logica;
using Spartane.Web.Areas.WebApiConsumer.Empresas;
using Spartane.Web.Areas.WebApiConsumer.Estatus;

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
    public class Ubicaciones_Eventos_EmpresaController : Controller
    {
        #region "variable declaration"

        private IUbicaciones_Eventos_EmpresaService service = null;
        private IUbicaciones_Eventos_EmpresaApiConsumer _IUbicaciones_Eventos_EmpresaApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IRespuesta_LogicaApiConsumer _IRespuesta_LogicaApiConsumer;
        private IEmpresasApiConsumer _IEmpresasApiConsumer;
        private IEstatusApiConsumer _IEstatusApiConsumer;

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

        
        public Ubicaciones_Eventos_EmpresaController(IUbicaciones_Eventos_EmpresaService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IUbicaciones_Eventos_EmpresaApiConsumer Ubicaciones_Eventos_EmpresaApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IRespuesta_LogicaApiConsumer Respuesta_LogicaApiConsumer , IEmpresasApiConsumer EmpresasApiConsumer , IEstatusApiConsumer EstatusApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IUbicaciones_Eventos_EmpresaApiConsumer = Ubicaciones_Eventos_EmpresaApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
			this._ISpartan_FormatRelatedApiConsumer = Spartan_Format_RelatedApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._IRespuesta_LogicaApiConsumer = Respuesta_LogicaApiConsumer;
            this._IEmpresasApiConsumer = EmpresasApiConsumer;
            this._IEstatusApiConsumer = EstatusApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Ubicaciones_Eventos_Empresa
        [ObjectAuth(ObjectId = (ModuleObjectId)44435, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44435, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Ubicaciones_Eventos_Empresa/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44435, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44435, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varUbicaciones_Eventos_Empresa = new Ubicaciones_Eventos_EmpresaModel();
			varUbicaciones_Eventos_Empresa.Folio = Id;
			
            ViewBag.ObjectId = "44435";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Ubicaciones_Eventos_EmpresasData = _IUbicaciones_Eventos_EmpresaApiConsumer.ListaSelAll(0, 1000, "Ubicaciones_Eventos_Empresa.Folio=" + Id, "").Resource.Ubicaciones_Eventos_Empresas;
				
				if (Ubicaciones_Eventos_EmpresasData != null && Ubicaciones_Eventos_EmpresasData.Count > 0)
                {
					var Ubicaciones_Eventos_EmpresaData = Ubicaciones_Eventos_EmpresasData.First();
					varUbicaciones_Eventos_Empresa= new Ubicaciones_Eventos_EmpresaModel
					{
						Folio  = Ubicaciones_Eventos_EmpresaData.Folio 
	                    ,Fecha_de_Registro = (Ubicaciones_Eventos_EmpresaData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Ubicaciones_Eventos_EmpresaData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Ubicaciones_Eventos_EmpresaData.Hora_de_Registro
                    ,Usuario_que_Registra = Ubicaciones_Eventos_EmpresaData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Ubicaciones_Eventos_EmpresaData.Usuario_que_Registra), "Spartan_User") ??  (string)Ubicaciones_Eventos_EmpresaData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre = Ubicaciones_Eventos_EmpresaData.Nombre
                    ,Descripcion = Ubicaciones_Eventos_EmpresaData.Descripcion
                    ,Cupo = Ubicaciones_Eventos_EmpresaData.Cupo
                    ,Ubicacion_externa = Ubicaciones_Eventos_EmpresaData.Ubicacion_externa
                    ,Ubicacion_externaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Ubicaciones_Eventos_EmpresaData.Ubicacion_externa), "Respuesta_Logica") ??  (string)Ubicaciones_Eventos_EmpresaData.Ubicacion_externa_Respuesta_Logica.Descripcion
                    ,Nombre_del_Lugar = Ubicaciones_Eventos_EmpresaData.Nombre_del_Lugar
                    ,Empresa = Ubicaciones_Eventos_EmpresaData.Empresa
                    ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(Convert.ToString(Ubicaciones_Eventos_EmpresaData.Empresa), "Empresas") ??  (string)Ubicaciones_Eventos_EmpresaData.Empresa_Empresas.Nombre_de_la_Empresa
                    ,Estatus = Ubicaciones_Eventos_EmpresaData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Ubicaciones_Eventos_EmpresaData.Estatus), "Estatus") ??  (string)Ubicaciones_Eventos_EmpresaData.Estatus_Estatus.Descripcion

					};
				}
				
				
				
            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_Registra = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_Registra != null && Spartan_Users_Usuario_que_Registra.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_Registra = Spartan_Users_Usuario_que_Registra.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Ubicacion_externa = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Ubicacion_externa != null && Respuesta_Logicas_Ubicacion_externa.Resource != null)
                ViewBag.Respuesta_Logicas_Ubicacion_externa = Respuesta_Logicas_Ubicacion_externa.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Empresass_Empresa = _IEmpresasApiConsumer.SelAll(true);
            if (Empresass_Empresa != null && Empresass_Empresa.Resource != null)
                ViewBag.Empresass_Empresa = Empresass_Empresa.Resource.Where(m => m.Nombre_de_la_Empresa != null).OrderBy(m => m.Nombre_de_la_Empresa).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Empresas", "Nombre_de_la_Empresa") ?? m.Nombre_de_la_Empresa.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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

				
            return View(varUbicaciones_Eventos_Empresa);
        }
		
	[HttpGet]
        public ActionResult AddUbicaciones_Eventos_Empresa(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44435);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
			Ubicaciones_Eventos_EmpresaModel varUbicaciones_Eventos_Empresa= new Ubicaciones_Eventos_EmpresaModel();


            if (id.ToString() != "0")
            {
                var Ubicaciones_Eventos_EmpresasData = _IUbicaciones_Eventos_EmpresaApiConsumer.ListaSelAll(0, 1000, "Ubicaciones_Eventos_Empresa.Folio=" + id, "").Resource.Ubicaciones_Eventos_Empresas;
				
				if (Ubicaciones_Eventos_EmpresasData != null && Ubicaciones_Eventos_EmpresasData.Count > 0)
                {
					var Ubicaciones_Eventos_EmpresaData = Ubicaciones_Eventos_EmpresasData.First();
					varUbicaciones_Eventos_Empresa= new Ubicaciones_Eventos_EmpresaModel
					{
						Folio  = Ubicaciones_Eventos_EmpresaData.Folio 
	                    ,Fecha_de_Registro = (Ubicaciones_Eventos_EmpresaData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Ubicaciones_Eventos_EmpresaData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Ubicaciones_Eventos_EmpresaData.Hora_de_Registro
                    ,Usuario_que_Registra = Ubicaciones_Eventos_EmpresaData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Ubicaciones_Eventos_EmpresaData.Usuario_que_Registra), "Spartan_User") ??  (string)Ubicaciones_Eventos_EmpresaData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre = Ubicaciones_Eventos_EmpresaData.Nombre
                    ,Descripcion = Ubicaciones_Eventos_EmpresaData.Descripcion
                    ,Cupo = Ubicaciones_Eventos_EmpresaData.Cupo
                    ,Ubicacion_externa = Ubicaciones_Eventos_EmpresaData.Ubicacion_externa
                    ,Ubicacion_externaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Ubicaciones_Eventos_EmpresaData.Ubicacion_externa), "Respuesta_Logica") ??  (string)Ubicaciones_Eventos_EmpresaData.Ubicacion_externa_Respuesta_Logica.Descripcion
                    ,Nombre_del_Lugar = Ubicaciones_Eventos_EmpresaData.Nombre_del_Lugar
                    ,Empresa = Ubicaciones_Eventos_EmpresaData.Empresa
                    ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(Convert.ToString(Ubicaciones_Eventos_EmpresaData.Empresa), "Empresas") ??  (string)Ubicaciones_Eventos_EmpresaData.Empresa_Empresas.Nombre_de_la_Empresa
                    ,Estatus = Ubicaciones_Eventos_EmpresaData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Ubicaciones_Eventos_EmpresaData.Estatus), "Estatus") ??  (string)Ubicaciones_Eventos_EmpresaData.Estatus_Estatus.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_Registra = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_Registra != null && Spartan_Users_Usuario_que_Registra.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_Registra = Spartan_Users_Usuario_que_Registra.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Ubicacion_externa = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Ubicacion_externa != null && Respuesta_Logicas_Ubicacion_externa.Resource != null)
                ViewBag.Respuesta_Logicas_Ubicacion_externa = Respuesta_Logicas_Ubicacion_externa.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Empresass_Empresa = _IEmpresasApiConsumer.SelAll(true);
            if (Empresass_Empresa != null && Empresass_Empresa.Resource != null)
                ViewBag.Empresass_Empresa = Empresass_Empresa.Resource.Where(m => m.Nombre_de_la_Empresa != null).OrderBy(m => m.Nombre_de_la_Empresa).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Empresas", "Nombre_de_la_Empresa") ?? m.Nombre_de_la_Empresa.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddUbicaciones_Eventos_Empresa", varUbicaciones_Eventos_Empresa);
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
                
                return Json(result.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name")?? m.Name,
                    Value = Convert.ToString(m.Id_User)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetRespuesta_LogicaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRespuesta_LogicaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEmpresasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEmpresasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_de_la_Empresa).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Empresas", "Nombre_de_la_Empresa")?? m.Nombre_de_la_Empresa,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatusApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion")?? m.Descripcion,
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
        public ActionResult ShowAdvanceFilter(Ubicaciones_Eventos_EmpresaAdvanceSearchModel model, int idFilter = -1)
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
            var Spartan_Users_Usuario_que_Registra = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_Registra != null && Spartan_Users_Usuario_que_Registra.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_Registra = Spartan_Users_Usuario_que_Registra.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Ubicacion_externa = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Ubicacion_externa != null && Respuesta_Logicas_Ubicacion_externa.Resource != null)
                ViewBag.Respuesta_Logicas_Ubicacion_externa = Respuesta_Logicas_Ubicacion_externa.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Empresass_Empresa = _IEmpresasApiConsumer.SelAll(true);
            if (Empresass_Empresa != null && Empresass_Empresa.Resource != null)
                ViewBag.Empresass_Empresa = Empresass_Empresa.Resource.Where(m => m.Nombre_de_la_Empresa != null).OrderBy(m => m.Nombre_de_la_Empresa).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Empresas", "Nombre_de_la_Empresa") ?? m.Nombre_de_la_Empresa.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_Registra = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_Registra != null && Spartan_Users_Usuario_que_Registra.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_Registra = Spartan_Users_Usuario_que_Registra.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Ubicacion_externa = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Ubicacion_externa != null && Respuesta_Logicas_Ubicacion_externa.Resource != null)
                ViewBag.Respuesta_Logicas_Ubicacion_externa = Respuesta_Logicas_Ubicacion_externa.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Empresass_Empresa = _IEmpresasApiConsumer.SelAll(true);
            if (Empresass_Empresa != null && Empresass_Empresa.Resource != null)
                ViewBag.Empresass_Empresa = Empresass_Empresa.Resource.Where(m => m.Nombre_de_la_Empresa != null).OrderBy(m => m.Nombre_de_la_Empresa).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Empresas", "Nombre_de_la_Empresa") ?? m.Nombre_de_la_Empresa.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            var previousFiltersObj = new Ubicaciones_Eventos_EmpresaAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Ubicaciones_Eventos_EmpresaAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Ubicaciones_Eventos_EmpresaAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Ubicaciones_Eventos_EmpresaPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IUbicaciones_Eventos_EmpresaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Ubicaciones_Eventos_Empresas == null)
                result.Ubicaciones_Eventos_Empresas = new List<Ubicaciones_Eventos_Empresa>();

            return Json(new
            {
                data = result.Ubicaciones_Eventos_Empresas.Select(m => new Ubicaciones_Eventos_EmpresaGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre = m.Nombre
			,Descripcion = m.Descripcion
			,Cupo = m.Cupo
                        ,Ubicacion_externaDescripcion = CultureHelper.GetTraduction(m.Ubicacion_externa_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Ubicacion_externa_Respuesta_Logica.Descripcion
			,Nombre_del_Lugar = m.Nombre_del_Lugar
                        ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(m.Empresa_Empresas.Folio.ToString(), "Nombre_de_la_Empresa") ?? (string)m.Empresa_Empresas.Nombre_de_la_Empresa
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetUbicaciones_Eventos_EmpresaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IUbicaciones_Eventos_EmpresaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Ubicaciones_Eventos_Empresa", m.),
                     Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
*/
        /// <summary>
        /// Get List of Ubicaciones_Eventos_Empresa from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Ubicaciones_Eventos_Empresa Entity</returns>
        public ActionResult GetUbicaciones_Eventos_EmpresaList(UrlParametersModel param)
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
            _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Ubicaciones_Eventos_EmpresaPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(Ubicaciones_Eventos_EmpresaAdvanceSearchModel))
                {
					var advanceFilter =
                    (Ubicaciones_Eventos_EmpresaAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Ubicaciones_Eventos_EmpresaPropertyMapper oUbicaciones_Eventos_EmpresaPropertyMapper = new Ubicaciones_Eventos_EmpresaPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oUbicaciones_Eventos_EmpresaPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IUbicaciones_Eventos_EmpresaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Ubicaciones_Eventos_Empresas == null)
                result.Ubicaciones_Eventos_Empresas = new List<Ubicaciones_Eventos_Empresa>();

            return Json(new
            {
                aaData = result.Ubicaciones_Eventos_Empresas.Select(m => new Ubicaciones_Eventos_EmpresaGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre = m.Nombre
			,Descripcion = m.Descripcion
			,Cupo = m.Cupo
                        ,Ubicacion_externaDescripcion = CultureHelper.GetTraduction(m.Ubicacion_externa_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Ubicacion_externa_Respuesta_Logica.Descripcion
			,Nombre_del_Lugar = m.Nombre_del_Lugar
                        ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(m.Empresa_Empresas.Folio.ToString(), "Nombre_de_la_Empresa") ?? (string)m.Empresa_Empresas.Nombre_de_la_Empresa
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(Ubicaciones_Eventos_EmpresaAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Ubicaciones_Eventos_Empresa.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Ubicaciones_Eventos_Empresa.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Ubicaciones_Eventos_Empresa.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Ubicaciones_Eventos_Empresa.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Ubicaciones_Eventos_Empresa.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Ubicaciones_Eventos_Empresa.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceUsuario_que_Registra))
            {
                switch (filter.Usuario_que_RegistraFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.AdvanceUsuario_que_Registra + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_que_Registra + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.AdvanceUsuario_que_Registra + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_que_Registra + "%'";
                        break;
                }
            }
            else if (filter.AdvanceUsuario_que_RegistraMultiple != null && filter.AdvanceUsuario_que_RegistraMultiple.Count() > 0)
            {
                var Usuario_que_RegistraIds = string.Join(",", filter.AdvanceUsuario_que_RegistraMultiple);

                where += " AND Ubicaciones_Eventos_Empresa.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombre))
            {
                switch (filter.NombreFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Ubicaciones_Eventos_Empresa.Nombre LIKE '" + filter.Nombre + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Ubicaciones_Eventos_Empresa.Nombre LIKE '%" + filter.Nombre + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Ubicaciones_Eventos_Empresa.Nombre = '" + filter.Nombre + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Ubicaciones_Eventos_Empresa.Nombre LIKE '%" + filter.Nombre + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Descripcion))
            {
                switch (filter.DescripcionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Ubicaciones_Eventos_Empresa.Descripcion LIKE '" + filter.Descripcion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Ubicaciones_Eventos_Empresa.Descripcion LIKE '%" + filter.Descripcion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Ubicaciones_Eventos_Empresa.Descripcion = '" + filter.Descripcion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Ubicaciones_Eventos_Empresa.Descripcion LIKE '%" + filter.Descripcion + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromCupo) || !string.IsNullOrEmpty(filter.ToCupo))
            {
                if (!string.IsNullOrEmpty(filter.FromCupo))
                    where += " AND Ubicaciones_Eventos_Empresa.Cupo >= " + filter.FromCupo;
                if (!string.IsNullOrEmpty(filter.ToCupo))
                    where += " AND Ubicaciones_Eventos_Empresa.Cupo <= " + filter.ToCupo;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceUbicacion_externa))
            {
                switch (filter.Ubicacion_externaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '" + filter.AdvanceUbicacion_externa + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceUbicacion_externa + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Respuesta_Logica.Descripcion = '" + filter.AdvanceUbicacion_externa + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceUbicacion_externa + "%'";
                        break;
                }
            }
            else if (filter.AdvanceUbicacion_externaMultiple != null && filter.AdvanceUbicacion_externaMultiple.Count() > 0)
            {
                var Ubicacion_externaIds = string.Join(",", filter.AdvanceUbicacion_externaMultiple);

                where += " AND Ubicaciones_Eventos_Empresa.Ubicacion_externa In (" + Ubicacion_externaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombre_del_Lugar))
            {
                switch (filter.Nombre_del_LugarFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Ubicaciones_Eventos_Empresa.Nombre_del_Lugar LIKE '" + filter.Nombre_del_Lugar + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Ubicaciones_Eventos_Empresa.Nombre_del_Lugar LIKE '%" + filter.Nombre_del_Lugar + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Ubicaciones_Eventos_Empresa.Nombre_del_Lugar = '" + filter.Nombre_del_Lugar + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Ubicaciones_Eventos_Empresa.Nombre_del_Lugar LIKE '%" + filter.Nombre_del_Lugar + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEmpresa))
            {
                switch (filter.EmpresaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Nombre_de_la_Empresa LIKE '" + filter.AdvanceEmpresa + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Nombre_de_la_Empresa LIKE '%" + filter.AdvanceEmpresa + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Nombre_de_la_Empresa = '" + filter.AdvanceEmpresa + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Nombre_de_la_Empresa LIKE '%" + filter.AdvanceEmpresa + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEmpresaMultiple != null && filter.AdvanceEmpresaMultiple.Count() > 0)
            {
                var EmpresaIds = string.Join(",", filter.AdvanceEmpresaMultiple);

                where += " AND Ubicaciones_Eventos_Empresa.Empresa In (" + EmpresaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEstatus))
            {
                switch (filter.EstatusFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estatus.Descripcion LIKE '" + filter.AdvanceEstatus + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estatus.Descripcion LIKE '%" + filter.AdvanceEstatus + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estatus.Descripcion = '" + filter.AdvanceEstatus + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estatus.Descripcion LIKE '%" + filter.AdvanceEstatus + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEstatusMultiple != null && filter.AdvanceEstatusMultiple.Count() > 0)
            {
                var EstatusIds = string.Join(",", filter.AdvanceEstatusMultiple);

                where += " AND Ubicaciones_Eventos_Empresa.Estatus In (" + EstatusIds + ")";
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
                _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

                Ubicaciones_Eventos_Empresa varUbicaciones_Eventos_Empresa = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IUbicaciones_Eventos_EmpresaApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Ubicaciones_Eventos_EmpresaModel varUbicaciones_Eventos_Empresa)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Ubicaciones_Eventos_EmpresaInfo = new Ubicaciones_Eventos_Empresa
                    {
                        Folio = varUbicaciones_Eventos_Empresa.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varUbicaciones_Eventos_Empresa.Fecha_de_Registro)) ? DateTime.ParseExact(varUbicaciones_Eventos_Empresa.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varUbicaciones_Eventos_Empresa.Hora_de_Registro
                        ,Usuario_que_Registra = varUbicaciones_Eventos_Empresa.Usuario_que_Registra
                        ,Nombre = varUbicaciones_Eventos_Empresa.Nombre
                        ,Descripcion = varUbicaciones_Eventos_Empresa.Descripcion
                        ,Cupo = varUbicaciones_Eventos_Empresa.Cupo
                        ,Ubicacion_externa = varUbicaciones_Eventos_Empresa.Ubicacion_externa
                        ,Nombre_del_Lugar = varUbicaciones_Eventos_Empresa.Nombre_del_Lugar
                        ,Empresa = varUbicaciones_Eventos_Empresa.Empresa
                        ,Estatus = varUbicaciones_Eventos_Empresa.Estatus

                    };

                    result = !IsNew ?
                        _IUbicaciones_Eventos_EmpresaApiConsumer.Update(Ubicaciones_Eventos_EmpresaInfo, null, null).Resource.ToString() :
                         _IUbicaciones_Eventos_EmpresaApiConsumer.Insert(Ubicaciones_Eventos_EmpresaInfo, null, null).Resource.ToString();
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
        /// Write Element Array of Ubicaciones_Eventos_Empresa script
        /// </summary>
        /// <param name="oUbicaciones_Eventos_EmpresaElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Ubicaciones_Eventos_EmpresaModuleAttributeList)
        {
            for (int i = 0; i < Ubicaciones_Eventos_EmpresaModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Ubicaciones_Eventos_EmpresaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Ubicaciones_Eventos_EmpresaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Ubicaciones_Eventos_EmpresaModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Ubicaciones_Eventos_EmpresaModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Ubicaciones_Eventos_EmpresaModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Ubicaciones_Eventos_EmpresaModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Ubicaciones_Eventos_EmpresaModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Ubicaciones_Eventos_EmpresaModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Ubicaciones_Eventos_EmpresaModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Ubicaciones_Eventos_EmpresaModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Ubicaciones_Eventos_EmpresaModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strUbicaciones_Eventos_EmpresaScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Ubicaciones_Eventos_Empresa.js")))
            {
                strUbicaciones_Eventos_EmpresaScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Ubicaciones_Eventos_Empresa element attributes
            string userChangeJson = jsSerialize.Serialize(Ubicaciones_Eventos_EmpresaModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strUbicaciones_Eventos_EmpresaScript.IndexOf("inpuElementArray");
            string splittedString = strUbicaciones_Eventos_EmpresaScript.Substring(indexOfArray, strUbicaciones_Eventos_EmpresaScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Ubicaciones_Eventos_EmpresaModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Ubicaciones_Eventos_EmpresaModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strUbicaciones_Eventos_EmpresaScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strUbicaciones_Eventos_EmpresaScript.Substring(indexOfArrayHistory, strUbicaciones_Eventos_EmpresaScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strUbicaciones_Eventos_EmpresaScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strUbicaciones_Eventos_EmpresaScript.Substring(endIndexOfMainElement + indexOfArray, strUbicaciones_Eventos_EmpresaScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Ubicaciones_Eventos_EmpresaModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Ubicaciones_Eventos_EmpresaModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Ubicaciones_Eventos_Empresa.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Ubicaciones_Eventos_Empresa.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Ubicaciones_Eventos_Empresa.js")))
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
        public ActionResult Ubicaciones_Eventos_EmpresaPropertyBag()
        {
            return PartialView("Ubicaciones_Eventos_EmpresaPropertyBag", "Ubicaciones_Eventos_Empresa");
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
                var whereClauseFormat = "Object = 44435 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Ubicaciones_Eventos_Empresa.Folio= " + RecordId;
                            var result = _IUbicaciones_Eventos_EmpresaApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Ubicaciones_Eventos_EmpresaPropertyMapper());
			
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
                    (Ubicaciones_Eventos_EmpresaAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Ubicaciones_Eventos_EmpresaPropertyMapper oUbicaciones_Eventos_EmpresaPropertyMapper = new Ubicaciones_Eventos_EmpresaPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oUbicaciones_Eventos_EmpresaPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IUbicaciones_Eventos_EmpresaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Ubicaciones_Eventos_Empresas == null)
                result.Ubicaciones_Eventos_Empresas = new List<Ubicaciones_Eventos_Empresa>();

            var data = result.Ubicaciones_Eventos_Empresas.Select(m => new Ubicaciones_Eventos_EmpresaGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre = m.Nombre
			,Descripcion = m.Descripcion
			,Cupo = m.Cupo
                        ,Ubicacion_externaDescripcion = CultureHelper.GetTraduction(m.Ubicacion_externa_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Ubicacion_externa_Respuesta_Logica.Descripcion
			,Nombre_del_Lugar = m.Nombre_del_Lugar
                        ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(m.Empresa_Empresas.Folio.ToString(), "Nombre_de_la_Empresa") ?? (string)m.Empresa_Empresas.Nombre_de_la_Empresa
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44435, arrayColumnsVisible), "Ubicaciones_Eventos_EmpresaList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44435, arrayColumnsVisible), "Ubicaciones_Eventos_EmpresaList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44435, arrayColumnsVisible), "Ubicaciones_Eventos_EmpresaList_" + DateTime.Now.ToString());
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

            _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Ubicaciones_Eventos_EmpresaPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Ubicaciones_Eventos_EmpresaAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Ubicaciones_Eventos_EmpresaPropertyMapper oUbicaciones_Eventos_EmpresaPropertyMapper = new Ubicaciones_Eventos_EmpresaPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oUbicaciones_Eventos_EmpresaPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IUbicaciones_Eventos_EmpresaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Ubicaciones_Eventos_Empresas == null)
                result.Ubicaciones_Eventos_Empresas = new List<Ubicaciones_Eventos_Empresa>();

            var data = result.Ubicaciones_Eventos_Empresas.Select(m => new Ubicaciones_Eventos_EmpresaGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre = m.Nombre
			,Descripcion = m.Descripcion
			,Cupo = m.Cupo
                        ,Ubicacion_externaDescripcion = CultureHelper.GetTraduction(m.Ubicacion_externa_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Ubicacion_externa_Respuesta_Logica.Descripcion
			,Nombre_del_Lugar = m.Nombre_del_Lugar
                        ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(m.Empresa_Empresas.Folio.ToString(), "Nombre_de_la_Empresa") ?? (string)m.Empresa_Empresas.Nombre_de_la_Empresa
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

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
                _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IUbicaciones_Eventos_EmpresaApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Ubicaciones_Eventos_Empresa_Datos_GeneralesModel varUbicaciones_Eventos_Empresa)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Ubicaciones_Eventos_Empresa_Datos_GeneralesInfo = new Ubicaciones_Eventos_Empresa_Datos_Generales
                {
                    Folio = varUbicaciones_Eventos_Empresa.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varUbicaciones_Eventos_Empresa.Fecha_de_Registro)) ? DateTime.ParseExact(varUbicaciones_Eventos_Empresa.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varUbicaciones_Eventos_Empresa.Hora_de_Registro
                        ,Usuario_que_Registra = varUbicaciones_Eventos_Empresa.Usuario_que_Registra
                        ,Nombre = varUbicaciones_Eventos_Empresa.Nombre
                        ,Descripcion = varUbicaciones_Eventos_Empresa.Descripcion
                        ,Cupo = varUbicaciones_Eventos_Empresa.Cupo
                        ,Ubicacion_externa = varUbicaciones_Eventos_Empresa.Ubicacion_externa
                        ,Nombre_del_Lugar = varUbicaciones_Eventos_Empresa.Nombre_del_Lugar
                        ,Empresa = varUbicaciones_Eventos_Empresa.Empresa
                        ,Estatus = varUbicaciones_Eventos_Empresa.Estatus
                    
                };

                result = _IUbicaciones_Eventos_EmpresaApiConsumer.Update_Datos_Generales(Ubicaciones_Eventos_Empresa_Datos_GeneralesInfo).Resource.ToString();
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
                _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IUbicaciones_Eventos_EmpresaApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				
                var result = new Ubicaciones_Eventos_Empresa_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre = m.Nombre
			,Descripcion = m.Descripcion
			,Cupo = m.Cupo
                        ,Ubicacion_externa = m.Ubicacion_externa
                        ,Ubicacion_externaDescripcion = CultureHelper.GetTraduction(m.Ubicacion_externa_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Ubicacion_externa_Respuesta_Logica.Descripcion
			,Nombre_del_Lugar = m.Nombre_del_Lugar
                        ,Empresa = m.Empresa
                        ,EmpresaNombre_de_la_Empresa = CultureHelper.GetTraduction(m.Empresa_Empresas.Folio.ToString(), "Nombre_de_la_Empresa") ?? (string)m.Empresa_Empresas.Nombre_de_la_Empresa
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                    
                };
				var resultData = new
                {
                    data = result

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

