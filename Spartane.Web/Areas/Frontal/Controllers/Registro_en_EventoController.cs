using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Registro_en_Evento;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Eventos;
using Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento;

using Spartane.Core.Domain.Detalle_Actividades_Evento;
using Spartane.Core.Domain.Tipos_de_Actividades;
using Spartane.Core.Domain.Especialidades;
using Spartane.Core.Domain.Spartan_User;





using Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento;

using Spartane.Core.Domain.Detalle_Actividades_Evento;








using Spartane.Core.Domain.Parentescos_Empleados;
using Spartane.Core.Domain.Sexo;

using Spartane.Core.Domain.Estatus_Reservaciones_Actividad;



using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Registro_en_Evento;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Registro_en_Evento;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Eventos;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Consulta_Actividades_Registro_Evento;

using Spartane.Web.Areas.WebApiConsumer.Detalle_Actividades_Evento;
using Spartane.Web.Areas.WebApiConsumer.Tipos_de_Actividades;
using Spartane.Web.Areas.WebApiConsumer.Especialidades;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;


using Spartane.Web.Areas.WebApiConsumer.Detalle_Registro_en_Actividad_Evento;

using Spartane.Web.Areas.WebApiConsumer.Detalle_Actividades_Evento;


using Spartane.Web.Areas.WebApiConsumer.Parentescos_Empleados;
using Spartane.Web.Areas.WebApiConsumer.Sexo;

using Spartane.Web.Areas.WebApiConsumer.Estatus_Reservaciones_Actividad;


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
    public class Registro_en_EventoController : Controller
    {
        #region "variable declaration"

        private IRegistro_en_EventoService service = null;
        private IRegistro_en_EventoApiConsumer _IRegistro_en_EventoApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IEventosApiConsumer _IEventosApiConsumer;
        private IDetalle_Consulta_Actividades_Registro_EventoApiConsumer _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer;

        private IDetalle_Actividades_EventoApiConsumer _IDetalle_Actividades_EventoApiConsumer;
        private ITipos_de_ActividadesApiConsumer _ITipos_de_ActividadesApiConsumer;
        private IEspecialidadesApiConsumer _IEspecialidadesApiConsumer;


        private IDetalle_Registro_en_Actividad_EventoApiConsumer _IDetalle_Registro_en_Actividad_EventoApiConsumer;



        private IParentescos_EmpleadosApiConsumer _IParentescos_EmpleadosApiConsumer;
        private ISexoApiConsumer _ISexoApiConsumer;

        private IEstatus_Reservaciones_ActividadApiConsumer _IEstatus_Reservaciones_ActividadApiConsumer;


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

        
        public Registro_en_EventoController(IRegistro_en_EventoService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IRegistro_en_EventoApiConsumer Registro_en_EventoApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IEventosApiConsumer EventosApiConsumer , IDetalle_Consulta_Actividades_Registro_EventoApiConsumer Detalle_Consulta_Actividades_Registro_EventoApiConsumer , IDetalle_Actividades_EventoApiConsumer Detalle_Actividades_EventoApiConsumer , ITipos_de_ActividadesApiConsumer Tipos_de_ActividadesApiConsumer , IEspecialidadesApiConsumer EspecialidadesApiConsumer  , IDetalle_Registro_en_Actividad_EventoApiConsumer Detalle_Registro_en_Actividad_EventoApiConsumer , IParentescos_EmpleadosApiConsumer Parentescos_EmpleadosApiConsumer , ISexoApiConsumer SexoApiConsumer , IEstatus_Reservaciones_ActividadApiConsumer Estatus_Reservaciones_ActividadApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IRegistro_en_EventoApiConsumer = Registro_en_EventoApiConsumer;
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
            this._IEventosApiConsumer = EventosApiConsumer;
            this._IDetalle_Consulta_Actividades_Registro_EventoApiConsumer = Detalle_Consulta_Actividades_Registro_EventoApiConsumer;

            this._IDetalle_Actividades_EventoApiConsumer = Detalle_Actividades_EventoApiConsumer;
            this._ITipos_de_ActividadesApiConsumer = Tipos_de_ActividadesApiConsumer;
            this._IEspecialidadesApiConsumer = EspecialidadesApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;


            this._IDetalle_Registro_en_Actividad_EventoApiConsumer = Detalle_Registro_en_Actividad_EventoApiConsumer;

            this._IDetalle_Actividades_EventoApiConsumer = Detalle_Actividades_EventoApiConsumer;


            this._IParentescos_EmpleadosApiConsumer = Parentescos_EmpleadosApiConsumer;
            this._ISexoApiConsumer = SexoApiConsumer;

            this._IEstatus_Reservaciones_ActividadApiConsumer = Estatus_Reservaciones_ActividadApiConsumer;


        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Registro_en_Evento
        [ObjectAuth(ObjectId = (ModuleObjectId)44439, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44439, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Registro_en_Evento/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44439, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44439, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varRegistro_en_Evento = new Registro_en_EventoModel();
			varRegistro_en_Evento.Folio = Id;
			
            ViewBag.ObjectId = "44439";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionDetalle_Consulta_Actividades_Registro_Evento = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44440, ModuleId);
            ViewBag.PermissionDetalle_Consulta_Actividades_Registro_Evento = permissionDetalle_Consulta_Actividades_Registro_Evento;
            var permissionDetalle_Registro_en_Actividad_Evento = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44441, ModuleId);
            ViewBag.PermissionDetalle_Registro_en_Actividad_Evento = permissionDetalle_Registro_en_Actividad_Evento;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IRegistro_en_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Registro_en_EventosData = _IRegistro_en_EventoApiConsumer.ListaSelAll(0, 1000, "Registro_en_Evento.Folio=" + Id, "").Resource.Registro_en_Eventos;
				
				if (Registro_en_EventosData != null && Registro_en_EventosData.Count > 0)
                {
					var Registro_en_EventoData = Registro_en_EventosData.First();
					varRegistro_en_Evento= new Registro_en_EventoModel
					{
						Folio  = Registro_en_EventoData.Folio 
	                    ,Fecha_de_Registro = (Registro_en_EventoData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Registro_en_EventoData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Registro_en_EventoData.Hora_de_Registro
                    ,Usuario_que_Registra = Registro_en_EventoData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Registro_en_EventoData.Usuario_que_Registra), "Spartan_User") ??  (string)Registro_en_EventoData.Usuario_que_Registra_Spartan_User.Name
                    ,Evento = Registro_en_EventoData.Evento
                    ,EventoNombre_del_Evento = CultureHelper.GetTraduction(Convert.ToString(Registro_en_EventoData.Evento), "Eventos") ??  (string)Registro_en_EventoData.Evento_Eventos.Nombre_del_Evento
                    ,Descripcion = Registro_en_EventoData.Descripcion
                    ,Fecha_inicio_del_Evento = (Registro_en_EventoData.Fecha_inicio_del_Evento == null ? string.Empty : Convert.ToDateTime(Registro_en_EventoData.Fecha_inicio_del_Evento).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin_del_Evento = (Registro_en_EventoData.Fecha_fin_del_Evento == null ? string.Empty : Convert.ToDateTime(Registro_en_EventoData.Fecha_fin_del_Evento).ToString(ConfigurationProperty.DateFormat))
                    ,Lugar = Registro_en_EventoData.Lugar

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
            _IEventosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Eventoss_Evento = _IEventosApiConsumer.SelAll(true);
            if (Eventoss_Evento != null && Eventoss_Evento.Resource != null)
                ViewBag.Eventoss_Evento = Eventoss_Evento.Resource.Where(m => m.Nombre_del_Evento != null).OrderBy(m => m.Nombre_del_Evento).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Eventos", "Nombre_del_Evento") ?? m.Nombre_del_Evento.ToString(), Value = Convert.ToString(m.Folio)
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

				
            return View(varRegistro_en_Evento);
        }
		
	[HttpGet]
        public ActionResult AddRegistro_en_Evento(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44439);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IRegistro_en_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
			Registro_en_EventoModel varRegistro_en_Evento= new Registro_en_EventoModel();
            var permissionDetalle_Consulta_Actividades_Registro_Evento = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44440, ModuleId);
            ViewBag.PermissionDetalle_Consulta_Actividades_Registro_Evento = permissionDetalle_Consulta_Actividades_Registro_Evento;
            var permissionDetalle_Registro_en_Actividad_Evento = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44441, ModuleId);
            ViewBag.PermissionDetalle_Registro_en_Actividad_Evento = permissionDetalle_Registro_en_Actividad_Evento;


            if (id.ToString() != "0")
            {
                var Registro_en_EventosData = _IRegistro_en_EventoApiConsumer.ListaSelAll(0, 1000, "Registro_en_Evento.Folio=" + id, "").Resource.Registro_en_Eventos;
				
				if (Registro_en_EventosData != null && Registro_en_EventosData.Count > 0)
                {
					var Registro_en_EventoData = Registro_en_EventosData.First();
					varRegistro_en_Evento= new Registro_en_EventoModel
					{
						Folio  = Registro_en_EventoData.Folio 
	                    ,Fecha_de_Registro = (Registro_en_EventoData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Registro_en_EventoData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Registro_en_EventoData.Hora_de_Registro
                    ,Usuario_que_Registra = Registro_en_EventoData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Registro_en_EventoData.Usuario_que_Registra), "Spartan_User") ??  (string)Registro_en_EventoData.Usuario_que_Registra_Spartan_User.Name
                    ,Evento = Registro_en_EventoData.Evento
                    ,EventoNombre_del_Evento = CultureHelper.GetTraduction(Convert.ToString(Registro_en_EventoData.Evento), "Eventos") ??  (string)Registro_en_EventoData.Evento_Eventos.Nombre_del_Evento
                    ,Descripcion = Registro_en_EventoData.Descripcion
                    ,Fecha_inicio_del_Evento = (Registro_en_EventoData.Fecha_inicio_del_Evento == null ? string.Empty : Convert.ToDateTime(Registro_en_EventoData.Fecha_inicio_del_Evento).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin_del_Evento = (Registro_en_EventoData.Fecha_fin_del_Evento == null ? string.Empty : Convert.ToDateTime(Registro_en_EventoData.Fecha_fin_del_Evento).ToString(ConfigurationProperty.DateFormat))
                    ,Lugar = Registro_en_EventoData.Lugar

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
            _IEventosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Eventoss_Evento = _IEventosApiConsumer.SelAll(true);
            if (Eventoss_Evento != null && Eventoss_Evento.Resource != null)
                ViewBag.Eventoss_Evento = Eventoss_Evento.Resource.Where(m => m.Nombre_del_Evento != null).OrderBy(m => m.Nombre_del_Evento).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Eventos", "Nombre_del_Evento") ?? m.Nombre_del_Evento.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddRegistro_en_Evento", varRegistro_en_Evento);
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
        public ActionResult GetEventosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEventosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEventosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_del_Evento).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Eventos", "Nombre_del_Evento")?? m.Nombre_del_Evento,
                    Value = Convert.ToString(m.Folio)
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
        public ActionResult ShowAdvanceFilter(Registro_en_EventoAdvanceSearchModel model, int idFilter = -1)
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
            _IEventosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Eventoss_Evento = _IEventosApiConsumer.SelAll(true);
            if (Eventoss_Evento != null && Eventoss_Evento.Resource != null)
                ViewBag.Eventoss_Evento = Eventoss_Evento.Resource.Where(m => m.Nombre_del_Evento != null).OrderBy(m => m.Nombre_del_Evento).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Eventos", "Nombre_del_Evento") ?? m.Nombre_del_Evento.ToString(), Value = Convert.ToString(m.Folio)
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
            _IEventosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Eventoss_Evento = _IEventosApiConsumer.SelAll(true);
            if (Eventoss_Evento != null && Eventoss_Evento.Resource != null)
                ViewBag.Eventoss_Evento = Eventoss_Evento.Resource.Where(m => m.Nombre_del_Evento != null).OrderBy(m => m.Nombre_del_Evento).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Eventos", "Nombre_del_Evento") ?? m.Nombre_del_Evento.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            var previousFiltersObj = new Registro_en_EventoAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Registro_en_EventoAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Registro_en_EventoAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Registro_en_EventoPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IRegistro_en_EventoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Registro_en_Eventos == null)
                result.Registro_en_Eventos = new List<Registro_en_Evento>();

            return Json(new
            {
                data = result.Registro_en_Eventos.Select(m => new Registro_en_EventoGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,EventoNombre_del_Evento = CultureHelper.GetTraduction(m.Evento_Eventos.Folio.ToString(), "Nombre_del_Evento") ?? (string)m.Evento_Eventos.Nombre_del_Evento
			,Descripcion = m.Descripcion
                        ,Fecha_inicio_del_Evento = (m.Fecha_inicio_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_Evento).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_Evento = (m.Fecha_fin_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_Evento).ToString(ConfigurationProperty.DateFormat))
			,Lugar = m.Lugar

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetRegistro_en_EventoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRegistro_en_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRegistro_en_EventoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Registro_en_Evento", m.),
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
        /// Get List of Registro_en_Evento from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Registro_en_Evento Entity</returns>
        public ActionResult GetRegistro_en_EventoList(UrlParametersModel param)
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
            _IRegistro_en_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Registro_en_EventoPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(Registro_en_EventoAdvanceSearchModel))
                {
					var advanceFilter =
                    (Registro_en_EventoAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Registro_en_EventoPropertyMapper oRegistro_en_EventoPropertyMapper = new Registro_en_EventoPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oRegistro_en_EventoPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IRegistro_en_EventoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Registro_en_Eventos == null)
                result.Registro_en_Eventos = new List<Registro_en_Evento>();

            return Json(new
            {
                aaData = result.Registro_en_Eventos.Select(m => new Registro_en_EventoGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,EventoNombre_del_Evento = CultureHelper.GetTraduction(m.Evento_Eventos.Folio.ToString(), "Nombre_del_Evento") ?? (string)m.Evento_Eventos.Nombre_del_Evento
			,Descripcion = m.Descripcion
                        ,Fecha_inicio_del_Evento = (m.Fecha_inicio_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_Evento).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_Evento = (m.Fecha_fin_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_Evento).ToString(ConfigurationProperty.DateFormat))
			,Lugar = m.Lugar

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete

//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(Registro_en_EventoAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Registro_en_Evento.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Registro_en_Evento.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Registro_en_Evento.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Registro_en_Evento.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Registro_en_Evento.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Registro_en_Evento.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
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

                where += " AND Registro_en_Evento.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEvento))
            {
                switch (filter.EventoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Eventos.Nombre_del_Evento LIKE '" + filter.AdvanceEvento + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Eventos.Nombre_del_Evento LIKE '%" + filter.AdvanceEvento + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Eventos.Nombre_del_Evento = '" + filter.AdvanceEvento + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Eventos.Nombre_del_Evento LIKE '%" + filter.AdvanceEvento + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEventoMultiple != null && filter.AdvanceEventoMultiple.Count() > 0)
            {
                var EventoIds = string.Join(",", filter.AdvanceEventoMultiple);

                where += " AND Registro_en_Evento.Evento In (" + EventoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Descripcion))
            {
                switch (filter.DescripcionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Registro_en_Evento.Descripcion LIKE '" + filter.Descripcion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Registro_en_Evento.Descripcion LIKE '%" + filter.Descripcion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Registro_en_Evento.Descripcion = '" + filter.Descripcion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Registro_en_Evento.Descripcion LIKE '%" + filter.Descripcion + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_inicio_del_Evento) || !string.IsNullOrEmpty(filter.ToFecha_inicio_del_Evento))
            {
                var Fecha_inicio_del_EventoFrom = DateTime.ParseExact(filter.FromFecha_inicio_del_Evento, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_inicio_del_EventoTo = DateTime.ParseExact(filter.ToFecha_inicio_del_Evento, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_inicio_del_Evento))
                    where += " AND Registro_en_Evento.Fecha_inicio_del_Evento >= '" + Fecha_inicio_del_EventoFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_inicio_del_Evento))
                    where += " AND Registro_en_Evento.Fecha_inicio_del_Evento <= '" + Fecha_inicio_del_EventoTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_fin_del_Evento) || !string.IsNullOrEmpty(filter.ToFecha_fin_del_Evento))
            {
                var Fecha_fin_del_EventoFrom = DateTime.ParseExact(filter.FromFecha_fin_del_Evento, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_fin_del_EventoTo = DateTime.ParseExact(filter.ToFecha_fin_del_Evento, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_fin_del_Evento))
                    where += " AND Registro_en_Evento.Fecha_fin_del_Evento >= '" + Fecha_fin_del_EventoFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_fin_del_Evento))
                    where += " AND Registro_en_Evento.Fecha_fin_del_Evento <= '" + Fecha_fin_del_EventoTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.Lugar))
            {
                switch (filter.LugarFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Registro_en_Evento.Lugar LIKE '" + filter.Lugar + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Registro_en_Evento.Lugar LIKE '%" + filter.Lugar + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Registro_en_Evento.Lugar = '" + filter.Lugar + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Registro_en_Evento.Lugar LIKE '%" + filter.Lugar + "%'";
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

        public ActionResult GetDetalle_Consulta_Actividades_Registro_Evento(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Consulta_Actividades_Registro_EventoGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Consulta_Actividades_Registro_Evento.Folio_Registro_Evento=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Consulta_Actividades_Registro_Evento.Folio_Registro_Evento='" + RelationId + "'";
            }
            var result = _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Consulta_Actividades_Registro_Eventos == null)
                result.Detalle_Consulta_Actividades_Registro_Eventos = new List<Detalle_Consulta_Actividades_Registro_Evento>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Consulta_Actividades_Registro_Eventos.Select(m => new Detalle_Consulta_Actividades_Registro_EventoGridModel
                {
                    Folio = m.Folio

                        ,Actividad = m.Actividad
                        ,ActividadNombre_de_la_Actividad = CultureHelper.GetTraduction(m.Actividad_Detalle_Actividades_Evento.Folio.ToString(), "Nombre_de_la_Actividad") ??(string)m.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
                        ,Tipo_de_Actividad = m.Tipo_de_Actividad
                        ,Tipo_de_ActividadDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Actividad_Tipos_de_Actividades.Folio.ToString(), "Descripcion") ??(string)m.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                        ,Especialidad = m.Especialidad
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ??(string)m.Especialidad_Especialidades.Especialidad
                        ,Imparte = m.Imparte
                        ,ImparteName = CultureHelper.GetTraduction(m.Imparte_Spartan_User.Id_User.ToString(), "Name") ??(string)m.Imparte_Spartan_User.Name
			,Fecha = (m.Fecha == null ? string.Empty : Convert.ToDateTime(m.Fecha).ToString(ConfigurationProperty.DateFormat))
			,Lugares_disponibles = m.Lugares_disponibles
			,Horarios_disponibles = m.Horarios_disponibles
			,Ubicacion = m.Ubicacion

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Consulta_Actividades_Registro_EventoGridModel> GetDetalle_Consulta_Actividades_Registro_EventoData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Consulta_Actividades_Registro_EventoGridModel> resultData = new List<Detalle_Consulta_Actividades_Registro_EventoGridModel>();
            string where = "Detalle_Consulta_Actividades_Registro_Evento.Folio_Registro_Evento=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Consulta_Actividades_Registro_Evento.Folio_Registro_Evento='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Consulta_Actividades_Registro_Eventos != null)
            {
                resultData = result.Detalle_Consulta_Actividades_Registro_Eventos.Select(m => new Detalle_Consulta_Actividades_Registro_EventoGridModel
                    {
                        Folio = m.Folio

                        ,Actividad = m.Actividad
                        ,ActividadNombre_de_la_Actividad = CultureHelper.GetTraduction(m.Actividad_Detalle_Actividades_Evento.Folio.ToString(), "Nombre_de_la_Actividad") ??(string)m.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
                        ,Tipo_de_Actividad = m.Tipo_de_Actividad
                        ,Tipo_de_ActividadDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Actividad_Tipos_de_Actividades.Folio.ToString(), "Descripcion") ??(string)m.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                        ,Especialidad = m.Especialidad
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ??(string)m.Especialidad_Especialidades.Especialidad
                        ,Imparte = m.Imparte
                        ,ImparteName = CultureHelper.GetTraduction(m.Imparte_Spartan_User.Id_User.ToString(), "Name") ??(string)m.Imparte_Spartan_User.Name
			,Fecha = (m.Fecha == null ? string.Empty : Convert.ToDateTime(m.Fecha).ToString(ConfigurationProperty.DateFormat))
			,Lugares_disponibles = m.Lugares_disponibles
			,Horarios_disponibles = m.Horarios_disponibles
			,Ubicacion = m.Ubicacion


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Registro_en_Actividad_Evento(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Registro_en_Actividad_EventoGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Registro_en_Actividad_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Registro_en_Actividad_Evento.Folio_Registro_Evento=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Registro_en_Actividad_Evento.Folio_Registro_Evento='" + RelationId + "'";
            }
            var result = _IDetalle_Registro_en_Actividad_EventoApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Registro_en_Actividad_Eventos == null)
                result.Detalle_Registro_en_Actividad_Eventos = new List<Detalle_Registro_en_Actividad_Evento>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Registro_en_Actividad_Eventos.Select(m => new Detalle_Registro_en_Actividad_EventoGridModel
                {
                    Folio = m.Folio

                        ,Actividad = m.Actividad
                        ,ActividadNombre_de_la_Actividad = CultureHelper.GetTraduction(m.Actividad_Detalle_Actividades_Evento.Folio.ToString(), "Nombre_de_la_Actividad") ??(string)m.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
			,Fecha = (m.Fecha == null ? string.Empty : Convert.ToDateTime(m.Fecha).ToString(ConfigurationProperty.DateFormat))
			,Horario = m.Horario
			,Es_para_un_familiar = m.Es_para_un_familiar
			,Numero_de_Empleado = m.Numero_de_Empleado
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
                        ,Parentesco = m.Parentesco
                        ,ParentescoDescripcion = CultureHelper.GetTraduction(m.Parentesco_Parentescos_Empleados.Folio.ToString(), "Descripcion") ??(string)m.Parentesco_Parentescos_Empleados.Descripcion
                        ,Sexo = m.Sexo
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ??(string)m.Sexo_Sexo.Descripcion
			,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                        ,Estatus_de_la_Reservacion = m.Estatus_de_la_Reservacion
                        ,Estatus_de_la_ReservacionDescripcion = CultureHelper.GetTraduction(m.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Folio.ToString(), "Descripcion") ??(string)m.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Descripcion
			,Codigo_Reservacion = m.Codigo_Reservacion

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Registro_en_Actividad_EventoGridModel> GetDetalle_Registro_en_Actividad_EventoData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Registro_en_Actividad_EventoGridModel> resultData = new List<Detalle_Registro_en_Actividad_EventoGridModel>();
            string where = "Detalle_Registro_en_Actividad_Evento.Folio_Registro_Evento=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Registro_en_Actividad_Evento.Folio_Registro_Evento='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Registro_en_Actividad_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Registro_en_Actividad_EventoApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Registro_en_Actividad_Eventos != null)
            {
                resultData = result.Detalle_Registro_en_Actividad_Eventos.Select(m => new Detalle_Registro_en_Actividad_EventoGridModel
                    {
                        Folio = m.Folio

                        ,Actividad = m.Actividad
                        ,ActividadNombre_de_la_Actividad = CultureHelper.GetTraduction(m.Actividad_Detalle_Actividades_Evento.Folio.ToString(), "Nombre_de_la_Actividad") ??(string)m.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
			,Fecha = (m.Fecha == null ? string.Empty : Convert.ToDateTime(m.Fecha).ToString(ConfigurationProperty.DateFormat))
			,Horario = m.Horario
			,Es_para_un_familiar = m.Es_para_un_familiar
			,Numero_de_Empleado = m.Numero_de_Empleado
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
                        ,Parentesco = m.Parentesco
                        ,ParentescoDescripcion = CultureHelper.GetTraduction(m.Parentesco_Parentescos_Empleados.Folio.ToString(), "Descripcion") ??(string)m.Parentesco_Parentescos_Empleados.Descripcion
                        ,Sexo = m.Sexo
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ??(string)m.Sexo_Sexo.Descripcion
			,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                        ,Estatus_de_la_Reservacion = m.Estatus_de_la_Reservacion
                        ,Estatus_de_la_ReservacionDescripcion = CultureHelper.GetTraduction(m.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Folio.ToString(), "Descripcion") ??(string)m.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Descripcion
			,Codigo_Reservacion = m.Codigo_Reservacion


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
                _IRegistro_en_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

                Registro_en_Evento varRegistro_en_Evento = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Consulta_Actividades_Registro_Evento.Folio_Registro_Evento=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Consulta_Actividades_Registro_Evento.Folio_Registro_Evento='" + id + "'";
                    }
                    var Detalle_Consulta_Actividades_Registro_EventoInfo =
                        _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Consulta_Actividades_Registro_EventoInfo.Detalle_Consulta_Actividades_Registro_Eventos.Count > 0)
                    {
                        var resultDetalle_Consulta_Actividades_Registro_Evento = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Consulta_Actividades_Registro_EventoItem in Detalle_Consulta_Actividades_Registro_EventoInfo.Detalle_Consulta_Actividades_Registro_Eventos)
                            resultDetalle_Consulta_Actividades_Registro_Evento = resultDetalle_Consulta_Actividades_Registro_Evento
                                              && _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.Delete(Detalle_Consulta_Actividades_Registro_EventoItem.Folio, null,null).Resource;

                        if (!resultDetalle_Consulta_Actividades_Registro_Evento)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Registro_en_Actividad_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Registro_en_Actividad_Evento.Folio_Registro_Evento=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Registro_en_Actividad_Evento.Folio_Registro_Evento='" + id + "'";
                    }
                    var Detalle_Registro_en_Actividad_EventoInfo =
                        _IDetalle_Registro_en_Actividad_EventoApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Registro_en_Actividad_EventoInfo.Detalle_Registro_en_Actividad_Eventos.Count > 0)
                    {
                        var resultDetalle_Registro_en_Actividad_Evento = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Registro_en_Actividad_EventoItem in Detalle_Registro_en_Actividad_EventoInfo.Detalle_Registro_en_Actividad_Eventos)
                            resultDetalle_Registro_en_Actividad_Evento = resultDetalle_Registro_en_Actividad_Evento
                                              && _IDetalle_Registro_en_Actividad_EventoApiConsumer.Delete(Detalle_Registro_en_Actividad_EventoItem.Folio, null,null).Resource;

                        if (!resultDetalle_Registro_en_Actividad_Evento)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IRegistro_en_EventoApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Registro_en_EventoModel varRegistro_en_Evento)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IRegistro_en_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Registro_en_EventoInfo = new Registro_en_Evento
                    {
                        Folio = varRegistro_en_Evento.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varRegistro_en_Evento.Fecha_de_Registro)) ? DateTime.ParseExact(varRegistro_en_Evento.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varRegistro_en_Evento.Hora_de_Registro
                        ,Usuario_que_Registra = varRegistro_en_Evento.Usuario_que_Registra
                        ,Evento = varRegistro_en_Evento.Evento
                        ,Descripcion = varRegistro_en_Evento.Descripcion
                        ,Fecha_inicio_del_Evento = (!String.IsNullOrEmpty(varRegistro_en_Evento.Fecha_inicio_del_Evento)) ? DateTime.ParseExact(varRegistro_en_Evento.Fecha_inicio_del_Evento, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Fecha_fin_del_Evento = (!String.IsNullOrEmpty(varRegistro_en_Evento.Fecha_fin_del_Evento)) ? DateTime.ParseExact(varRegistro_en_Evento.Fecha_fin_del_Evento, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Lugar = varRegistro_en_Evento.Lugar

                    };

                    result = !IsNew ?
                        _IRegistro_en_EventoApiConsumer.Update(Registro_en_EventoInfo, null, null).Resource.ToString() :
                         _IRegistro_en_EventoApiConsumer.Insert(Registro_en_EventoInfo, null, null).Resource.ToString();
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
        public bool CopyDetalle_Consulta_Actividades_Registro_Evento(int MasterId, int referenceId, List<Detalle_Consulta_Actividades_Registro_EventoGridModelPost> Detalle_Consulta_Actividades_Registro_EventoItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Consulta_Actividades_Registro_EventoData = _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Consulta_Actividades_Registro_Evento.Folio_Registro_Evento=" + referenceId,"").Resource;
                if (Detalle_Consulta_Actividades_Registro_EventoData == null || Detalle_Consulta_Actividades_Registro_EventoData.Detalle_Consulta_Actividades_Registro_Eventos.Count == 0)
                    return true;

                var result = true;

                Detalle_Consulta_Actividades_Registro_EventoGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Consulta_Actividades_Registro_Evento in Detalle_Consulta_Actividades_Registro_EventoData.Detalle_Consulta_Actividades_Registro_Eventos)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Consulta_Actividades_Registro_Evento Detalle_Consulta_Actividades_Registro_Evento1 = varDetalle_Consulta_Actividades_Registro_Evento;

                    if (Detalle_Consulta_Actividades_Registro_EventoItems != null && Detalle_Consulta_Actividades_Registro_EventoItems.Any(m => m.Folio == Detalle_Consulta_Actividades_Registro_Evento1.Folio))
                    {
                        modelDataToChange = Detalle_Consulta_Actividades_Registro_EventoItems.FirstOrDefault(m => m.Folio == Detalle_Consulta_Actividades_Registro_Evento1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Consulta_Actividades_Registro_Evento.Folio_Registro_Evento = MasterId;
                    var insertId = _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.Insert(varDetalle_Consulta_Actividades_Registro_Evento,null,null).Resource;
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
        public ActionResult PostDetalle_Consulta_Actividades_Registro_Evento(List<Detalle_Consulta_Actividades_Registro_EventoGridModelPost> Detalle_Consulta_Actividades_Registro_EventoItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Consulta_Actividades_Registro_Evento(MasterId, referenceId, Detalle_Consulta_Actividades_Registro_EventoItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Consulta_Actividades_Registro_EventoItems != null && Detalle_Consulta_Actividades_Registro_EventoItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Consulta_Actividades_Registro_EventoItem in Detalle_Consulta_Actividades_Registro_EventoItems)
                    {










                        //Removal Request
                        if (Detalle_Consulta_Actividades_Registro_EventoItem.Removed)
                        {
                            result = result && _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.Delete(Detalle_Consulta_Actividades_Registro_EventoItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Consulta_Actividades_Registro_EventoItem.Folio = 0;

                        var Detalle_Consulta_Actividades_Registro_EventoData = new Detalle_Consulta_Actividades_Registro_Evento
                        {
                            Folio_Registro_Evento = MasterId
                            ,Folio = Detalle_Consulta_Actividades_Registro_EventoItem.Folio
                            ,Actividad = (Convert.ToInt32(Detalle_Consulta_Actividades_Registro_EventoItem.Actividad) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Consulta_Actividades_Registro_EventoItem.Actividad))
                            ,Tipo_de_Actividad = (Convert.ToInt32(Detalle_Consulta_Actividades_Registro_EventoItem.Tipo_de_Actividad) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Consulta_Actividades_Registro_EventoItem.Tipo_de_Actividad))
                            ,Especialidad = (Convert.ToInt32(Detalle_Consulta_Actividades_Registro_EventoItem.Especialidad) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Consulta_Actividades_Registro_EventoItem.Especialidad))
                            ,Imparte = (Convert.ToInt32(Detalle_Consulta_Actividades_Registro_EventoItem.Imparte) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Consulta_Actividades_Registro_EventoItem.Imparte))
                            ,Fecha = (Detalle_Consulta_Actividades_Registro_EventoItem.Fecha!= null) ? DateTime.ParseExact(Detalle_Consulta_Actividades_Registro_EventoItem.Fecha, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Lugares_disponibles = Detalle_Consulta_Actividades_Registro_EventoItem.Lugares_disponibles
                            ,Horarios_disponibles = Detalle_Consulta_Actividades_Registro_EventoItem.Horarios_disponibles
                            ,Ubicacion = Detalle_Consulta_Actividades_Registro_EventoItem.Ubicacion

                        };

                        var resultId = Detalle_Consulta_Actividades_Registro_EventoItem.Folio > 0
                           ? _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.Update(Detalle_Consulta_Actividades_Registro_EventoData,null,null).Resource
                           : _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.Insert(Detalle_Consulta_Actividades_Registro_EventoData,null,null).Resource;

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


        [HttpGet]
        public ActionResult GetDetalle_Consulta_Actividades_Registro_Evento_Detalle_Actividades_EventoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDetalle_Actividades_EventoApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Detalle_Actividades_Evento", "Nombre_de_la_Actividad");
                  item.Nombre_de_la_Actividad= trans??item.Nombre_de_la_Actividad;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetDetalle_Consulta_Actividades_Registro_Evento_Tipos_de_ActividadesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipos_de_ActividadesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipos_de_ActividadesApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Tipos_de_Actividades", "Descripcion");
                  item.Descripcion= trans??item.Descripcion;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetDetalle_Consulta_Actividades_Registro_Evento_EspecialidadesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEspecialidadesApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Especialidades", "Especialidad");
                  item.Especialidad= trans??item.Especialidad;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetDetalle_Consulta_Actividades_Registro_Evento_Spartan_UserAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_UserApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Id_User), "Spartan_User", "Name");
                  item.Name= trans??item.Name;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }





        [NonAction]
        public bool CopyDetalle_Registro_en_Actividad_Evento(int MasterId, int referenceId, List<Detalle_Registro_en_Actividad_EventoGridModelPost> Detalle_Registro_en_Actividad_EventoItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Registro_en_Actividad_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Registro_en_Actividad_EventoData = _IDetalle_Registro_en_Actividad_EventoApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Registro_en_Actividad_Evento.Folio_Registro_Evento=" + referenceId,"").Resource;
                if (Detalle_Registro_en_Actividad_EventoData == null || Detalle_Registro_en_Actividad_EventoData.Detalle_Registro_en_Actividad_Eventos.Count == 0)
                    return true;

                var result = true;

                Detalle_Registro_en_Actividad_EventoGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Registro_en_Actividad_Evento in Detalle_Registro_en_Actividad_EventoData.Detalle_Registro_en_Actividad_Eventos)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Registro_en_Actividad_Evento Detalle_Registro_en_Actividad_Evento1 = varDetalle_Registro_en_Actividad_Evento;

                    if (Detalle_Registro_en_Actividad_EventoItems != null && Detalle_Registro_en_Actividad_EventoItems.Any(m => m.Folio == Detalle_Registro_en_Actividad_Evento1.Folio))
                    {
                        modelDataToChange = Detalle_Registro_en_Actividad_EventoItems.FirstOrDefault(m => m.Folio == Detalle_Registro_en_Actividad_Evento1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Registro_en_Actividad_Evento.Folio_Registro_Evento = MasterId;
                    var insertId = _IDetalle_Registro_en_Actividad_EventoApiConsumer.Insert(varDetalle_Registro_en_Actividad_Evento,null,null).Resource;
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
        public ActionResult PostDetalle_Registro_en_Actividad_Evento(List<Detalle_Registro_en_Actividad_EventoGridModelPost> Detalle_Registro_en_Actividad_EventoItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Registro_en_Actividad_Evento(MasterId, referenceId, Detalle_Registro_en_Actividad_EventoItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Registro_en_Actividad_EventoItems != null && Detalle_Registro_en_Actividad_EventoItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Registro_en_Actividad_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Registro_en_Actividad_EventoItem in Detalle_Registro_en_Actividad_EventoItems)
                    {
















                        //Removal Request
                        if (Detalle_Registro_en_Actividad_EventoItem.Removed)
                        {
                            result = result && _IDetalle_Registro_en_Actividad_EventoApiConsumer.Delete(Detalle_Registro_en_Actividad_EventoItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Registro_en_Actividad_EventoItem.Folio = 0;

                        var Detalle_Registro_en_Actividad_EventoData = new Detalle_Registro_en_Actividad_Evento
                        {
                            Folio_Registro_Evento = MasterId
                            ,Folio = Detalle_Registro_en_Actividad_EventoItem.Folio
                            ,Actividad = (Convert.ToInt32(Detalle_Registro_en_Actividad_EventoItem.Actividad) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Registro_en_Actividad_EventoItem.Actividad))
                            ,Fecha = (Detalle_Registro_en_Actividad_EventoItem.Fecha!= null) ? DateTime.ParseExact(Detalle_Registro_en_Actividad_EventoItem.Fecha, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Horario = Detalle_Registro_en_Actividad_EventoItem.Horario
                            ,Es_para_un_familiar = Detalle_Registro_en_Actividad_EventoItem.Es_para_un_familiar
                            ,Numero_de_Empleado = Detalle_Registro_en_Actividad_EventoItem.Numero_de_Empleado
                            ,Nombres = Detalle_Registro_en_Actividad_EventoItem.Nombres
                            ,Apellido_Paterno = Detalle_Registro_en_Actividad_EventoItem.Apellido_Paterno
                            ,Apellido_Materno = Detalle_Registro_en_Actividad_EventoItem.Apellido_Materno
                            ,Nombre_Completo = Detalle_Registro_en_Actividad_EventoItem.Nombre_Completo
                            ,Parentesco = (Convert.ToInt32(Detalle_Registro_en_Actividad_EventoItem.Parentesco) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Registro_en_Actividad_EventoItem.Parentesco))
                            ,Sexo = (Convert.ToInt32(Detalle_Registro_en_Actividad_EventoItem.Sexo) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Registro_en_Actividad_EventoItem.Sexo))
                            ,Fecha_de_nacimiento = (Detalle_Registro_en_Actividad_EventoItem.Fecha_de_nacimiento!= null) ? DateTime.ParseExact(Detalle_Registro_en_Actividad_EventoItem.Fecha_de_nacimiento, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Estatus_de_la_Reservacion = (Convert.ToInt32(Detalle_Registro_en_Actividad_EventoItem.Estatus_de_la_Reservacion) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Registro_en_Actividad_EventoItem.Estatus_de_la_Reservacion))
                            ,Codigo_Reservacion = Detalle_Registro_en_Actividad_EventoItem.Codigo_Reservacion

                        };

                        var resultId = Detalle_Registro_en_Actividad_EventoItem.Folio > 0
                           ? _IDetalle_Registro_en_Actividad_EventoApiConsumer.Update(Detalle_Registro_en_Actividad_EventoData,null,null).Resource
                           : _IDetalle_Registro_en_Actividad_EventoApiConsumer.Insert(Detalle_Registro_en_Actividad_EventoData,null,null).Resource;

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


        [HttpGet]
        public ActionResult GetDetalle_Registro_en_Actividad_Evento_Detalle_Actividades_EventoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDetalle_Actividades_EventoApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Detalle_Actividades_Evento", "Nombre_de_la_Actividad");
                  item.Nombre_de_la_Actividad= trans??item.Nombre_de_la_Actividad;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }








        [HttpGet]
        public ActionResult GetDetalle_Registro_en_Actividad_Evento_Parentescos_EmpleadosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IParentescos_EmpleadosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IParentescos_EmpleadosApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Parentescos_Empleados", "Descripcion");
                  item.Descripcion= trans??item.Descripcion;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetDetalle_Registro_en_Actividad_Evento_SexoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISexoApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Sexo", "Descripcion");
                  item.Descripcion= trans??item.Descripcion;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetDetalle_Registro_en_Actividad_Evento_Estatus_Reservaciones_ActividadAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_Reservaciones_ActividadApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_Reservaciones_ActividadApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Estatus_Reservaciones_Actividad", "Descripcion");
                  item.Descripcion= trans??item.Descripcion;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }




        /// <summary>
        /// Write Element Array of Registro_en_Evento script
        /// </summary>
        /// <param name="oRegistro_en_EventoElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Registro_en_EventoModuleAttributeList)
        {
            for (int i = 0; i < Registro_en_EventoModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Registro_en_EventoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Registro_en_EventoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Registro_en_EventoModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Registro_en_EventoModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Registro_en_EventoModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Registro_en_EventoModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Registro_en_EventoModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Registro_en_EventoModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Registro_en_EventoModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Registro_en_EventoModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Registro_en_EventoModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strRegistro_en_EventoScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Registro_en_Evento.js")))
            {
                strRegistro_en_EventoScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Registro_en_Evento element attributes
            string userChangeJson = jsSerialize.Serialize(Registro_en_EventoModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strRegistro_en_EventoScript.IndexOf("inpuElementArray");
            string splittedString = strRegistro_en_EventoScript.Substring(indexOfArray, strRegistro_en_EventoScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Registro_en_EventoModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Registro_en_EventoModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strRegistro_en_EventoScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strRegistro_en_EventoScript.Substring(indexOfArrayHistory, strRegistro_en_EventoScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strRegistro_en_EventoScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strRegistro_en_EventoScript.Substring(endIndexOfMainElement + indexOfArray, strRegistro_en_EventoScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Registro_en_EventoModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Registro_en_EventoModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Registro_en_Evento.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Registro_en_Evento.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Registro_en_Evento.js")))
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
        public ActionResult Registro_en_EventoPropertyBag()
        {
            return PartialView("Registro_en_EventoPropertyBag", "Registro_en_Evento");
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
        public ActionResult AddDetalle_Consulta_Actividades_Registro_Evento(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Consulta_Actividades_Registro_Evento/AddDetalle_Consulta_Actividades_Registro_Evento");
        }

        [HttpGet]
        public ActionResult AddDetalle_Registro_en_Actividad_Evento(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Registro_en_Actividad_Evento/AddDetalle_Registro_en_Actividad_Evento");
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
                var whereClauseFormat = "Object = 44439 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IRegistro_en_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Registro_en_Evento.Folio= " + RecordId;
                            var result = _IRegistro_en_EventoApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IRegistro_en_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Registro_en_EventoPropertyMapper());
			
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
                    (Registro_en_EventoAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Registro_en_EventoPropertyMapper oRegistro_en_EventoPropertyMapper = new Registro_en_EventoPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oRegistro_en_EventoPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IRegistro_en_EventoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Registro_en_Eventos == null)
                result.Registro_en_Eventos = new List<Registro_en_Evento>();

            var data = result.Registro_en_Eventos.Select(m => new Registro_en_EventoGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,EventoNombre_del_Evento = CultureHelper.GetTraduction(m.Evento_Eventos.Folio.ToString(), "Nombre_del_Evento") ?? (string)m.Evento_Eventos.Nombre_del_Evento
			,Descripcion = m.Descripcion
                        ,Fecha_inicio_del_Evento = (m.Fecha_inicio_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_Evento).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_Evento = (m.Fecha_fin_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_Evento).ToString(ConfigurationProperty.DateFormat))
			,Lugar = m.Lugar

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44439, arrayColumnsVisible), "Registro_en_EventoList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44439, arrayColumnsVisible), "Registro_en_EventoList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44439, arrayColumnsVisible), "Registro_en_EventoList_" + DateTime.Now.ToString());
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

            _IRegistro_en_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Registro_en_EventoPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Registro_en_EventoAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Registro_en_EventoPropertyMapper oRegistro_en_EventoPropertyMapper = new Registro_en_EventoPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oRegistro_en_EventoPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IRegistro_en_EventoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Registro_en_Eventos == null)
                result.Registro_en_Eventos = new List<Registro_en_Evento>();

            var data = result.Registro_en_Eventos.Select(m => new Registro_en_EventoGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,EventoNombre_del_Evento = CultureHelper.GetTraduction(m.Evento_Eventos.Folio.ToString(), "Nombre_del_Evento") ?? (string)m.Evento_Eventos.Nombre_del_Evento
			,Descripcion = m.Descripcion
                        ,Fecha_inicio_del_Evento = (m.Fecha_inicio_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_Evento).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_Evento = (m.Fecha_fin_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_Evento).ToString(ConfigurationProperty.DateFormat))
			,Lugar = m.Lugar

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
                _IRegistro_en_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRegistro_en_EventoApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Registro_en_Evento_Datos_GeneralesModel varRegistro_en_Evento)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRegistro_en_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Registro_en_Evento_Datos_GeneralesInfo = new Registro_en_Evento_Datos_Generales
                {
                    Folio = varRegistro_en_Evento.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varRegistro_en_Evento.Fecha_de_Registro)) ? DateTime.ParseExact(varRegistro_en_Evento.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varRegistro_en_Evento.Hora_de_Registro
                        ,Usuario_que_Registra = varRegistro_en_Evento.Usuario_que_Registra
                        ,Evento = varRegistro_en_Evento.Evento
                        ,Descripcion = varRegistro_en_Evento.Descripcion
                        ,Fecha_inicio_del_Evento = (!String.IsNullOrEmpty(varRegistro_en_Evento.Fecha_inicio_del_Evento)) ? DateTime.ParseExact(varRegistro_en_Evento.Fecha_inicio_del_Evento, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Fecha_fin_del_Evento = (!String.IsNullOrEmpty(varRegistro_en_Evento.Fecha_fin_del_Evento)) ? DateTime.ParseExact(varRegistro_en_Evento.Fecha_fin_del_Evento, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Lugar = varRegistro_en_Evento.Lugar
                    
                };

                result = _IRegistro_en_EventoApiConsumer.Update_Datos_Generales(Registro_en_Evento_Datos_GeneralesInfo).Resource.ToString();
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
                _IRegistro_en_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IRegistro_en_EventoApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Consulta_Actividades_Registro_Evento;
                var Detalle_Consulta_Actividades_Registro_EventoData = GetDetalle_Consulta_Actividades_Registro_EventoData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Consulta_Actividades_Registro_Evento);
                int RowCount_Detalle_Registro_en_Actividad_Evento;
                var Detalle_Registro_en_Actividad_EventoData = GetDetalle_Registro_en_Actividad_EventoData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Registro_en_Actividad_Evento);

                var result = new Registro_en_Evento_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Evento = m.Evento
                        ,EventoNombre_del_Evento = CultureHelper.GetTraduction(m.Evento_Eventos.Folio.ToString(), "Nombre_del_Evento") ?? (string)m.Evento_Eventos.Nombre_del_Evento
			,Descripcion = m.Descripcion
                        ,Fecha_inicio_del_Evento = (m.Fecha_inicio_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_del_Evento).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_del_Evento = (m.Fecha_fin_del_Evento == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_del_Evento).ToString(ConfigurationProperty.DateFormat))
			,Lugar = m.Lugar

                    
                };
				var resultData = new
                {
                    data = result
                    ,Actividades_del_Evento = Detalle_Consulta_Actividades_Registro_EventoData
                    ,Inscripcion_en_Actividades = Detalle_Registro_en_Actividad_EventoData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

