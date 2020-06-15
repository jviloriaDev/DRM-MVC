using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Horarios_Actividad;
using Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento;
using Spartane.Core.Domain.Parentescos_Empleados;
using Spartane.Core.Domain.Sexo;
using Spartane.Core.Domain.Estatus_Reservaciones_Actividad;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Horarios_Actividad;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Horarios_Actividad;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Registro_en_Actividad_Evento;
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

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Detalle_Horarios_ActividadController : Controller
    {
        #region "variable declaration"

        private IDetalle_Horarios_ActividadService service = null;
        private IDetalle_Horarios_ActividadApiConsumer _IDetalle_Horarios_ActividadApiConsumer;
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

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Horarios_ActividadController(IDetalle_Horarios_ActividadService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Horarios_ActividadApiConsumer Detalle_Horarios_ActividadApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IDetalle_Registro_en_Actividad_EventoApiConsumer Detalle_Registro_en_Actividad_EventoApiConsumer , IParentescos_EmpleadosApiConsumer Parentescos_EmpleadosApiConsumer , ISexoApiConsumer SexoApiConsumer , IEstatus_Reservaciones_ActividadApiConsumer Estatus_Reservaciones_ActividadApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Horarios_ActividadApiConsumer = Detalle_Horarios_ActividadApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IDetalle_Registro_en_Actividad_EventoApiConsumer = Detalle_Registro_en_Actividad_EventoApiConsumer;
            this._IParentescos_EmpleadosApiConsumer = Parentescos_EmpleadosApiConsumer;
            this._ISexoApiConsumer = SexoApiConsumer;
            this._IEstatus_Reservaciones_ActividadApiConsumer = Estatus_Reservaciones_ActividadApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Horarios_Actividad
        [ObjectAuth(ObjectId = (ModuleObjectId)44437, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44437);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Horarios_Actividad/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44437, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44437);
            ViewBag.Permission = permission;
            var varDetalle_Horarios_Actividad = new Detalle_Horarios_ActividadModel();
			
            ViewBag.ObjectId = "44437";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Horarios_ActividadApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Horarios_ActividadData = _IDetalle_Horarios_ActividadApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Horarios_Actividads[0];
                if (Detalle_Horarios_ActividadData == null)
                    return HttpNotFound();

                varDetalle_Horarios_Actividad = new Detalle_Horarios_ActividadModel
                {
                    Folio = (int)Detalle_Horarios_ActividadData.Folio
                    ,Reservada = Detalle_Horarios_ActividadData.Reservada.GetValueOrDefault()
                    ,Numero_de_Cita = Detalle_Horarios_ActividadData.Numero_de_Cita
                    ,Hora_inicio = Detalle_Horarios_ActividadData.Hora_inicio
                    ,Hora_fin = Detalle_Horarios_ActividadData.Hora_fin
                    ,Horario = Detalle_Horarios_ActividadData.Horario
                    ,Codigo_de_Reservacion = Detalle_Horarios_ActividadData.Codigo_de_Reservacion
                    ,Codigo_de_ReservacionCodigo_Reservacion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Horarios_ActividadData.Codigo_de_Reservacion), "Detalle_Registro_en_Actividad_Evento") ??  (string)Detalle_Horarios_ActividadData.Codigo_de_Reservacion_Detalle_Registro_en_Actividad_Evento.Codigo_Reservacion
                    ,Numero_de_Empleado = Detalle_Horarios_ActividadData.Numero_de_Empleado
                    ,Familiar_del_Empleado = Detalle_Horarios_ActividadData.Familiar_del_Empleado.GetValueOrDefault()
                    ,Nombre_Completo = Detalle_Horarios_ActividadData.Nombre_Completo
                    ,Parentesco_con_el_Empleado = Detalle_Horarios_ActividadData.Parentesco_con_el_Empleado
                    ,Parentesco_con_el_EmpleadoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Horarios_ActividadData.Parentesco_con_el_Empleado), "Parentescos_Empleados") ??  (string)Detalle_Horarios_ActividadData.Parentesco_con_el_Empleado_Parentescos_Empleados.Descripcion
                    ,Sexo = Detalle_Horarios_ActividadData.Sexo
                    ,SexoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Horarios_ActividadData.Sexo), "Sexo") ??  (string)Detalle_Horarios_ActividadData.Sexo_Sexo.Descripcion
                    ,Edad = Detalle_Horarios_ActividadData.Edad
                    ,Estatus_de_la_Reservacion = Detalle_Horarios_ActividadData.Estatus_de_la_Reservacion
                    ,Estatus_de_la_ReservacionDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Horarios_ActividadData.Estatus_de_la_Reservacion), "Estatus_Reservaciones_Actividad") ??  (string)Detalle_Horarios_ActividadData.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Descripcion
                    ,Asistio = Detalle_Horarios_ActividadData.Asistio.GetValueOrDefault()

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IDetalle_Registro_en_Actividad_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Detalle_Registro_en_Actividad_Eventos_Codigo_de_Reservacion = _IDetalle_Registro_en_Actividad_EventoApiConsumer.SelAll(true);
            if (Detalle_Registro_en_Actividad_Eventos_Codigo_de_Reservacion != null && Detalle_Registro_en_Actividad_Eventos_Codigo_de_Reservacion.Resource != null)
                ViewBag.Detalle_Registro_en_Actividad_Eventos_Codigo_de_Reservacion = Detalle_Registro_en_Actividad_Eventos_Codigo_de_Reservacion.Resource.Where(m => m.Codigo_Reservacion != null).OrderBy(m => m.Codigo_Reservacion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Detalle_Registro_en_Actividad_Evento", "Codigo_Reservacion") ?? m.Codigo_Reservacion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IParentescos_EmpleadosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Parentescos_Empleadoss_Parentesco_con_el_Empleado = _IParentescos_EmpleadosApiConsumer.SelAll(true);
            if (Parentescos_Empleadoss_Parentesco_con_el_Empleado != null && Parentescos_Empleadoss_Parentesco_con_el_Empleado.Resource != null)
                ViewBag.Parentescos_Empleadoss_Parentesco_con_el_Empleado = Parentescos_Empleadoss_Parentesco_con_el_Empleado.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Parentescos_Empleados", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Sexo = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Sexo != null && Sexos_Sexo.Resource != null)
                ViewBag.Sexos_Sexo = Sexos_Sexo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_Reservaciones_ActividadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Reservaciones_Actividads_Estatus_de_la_Reservacion = _IEstatus_Reservaciones_ActividadApiConsumer.SelAll(true);
            if (Estatus_Reservaciones_Actividads_Estatus_de_la_Reservacion != null && Estatus_Reservaciones_Actividads_Estatus_de_la_Reservacion.Resource != null)
                ViewBag.Estatus_Reservaciones_Actividads_Estatus_de_la_Reservacion = Estatus_Reservaciones_Actividads_Estatus_de_la_Reservacion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_Reservaciones_Actividad", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Horarios_Actividad);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Horarios_Actividad(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44437);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Horarios_ActividadApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Horarios_ActividadModel varDetalle_Horarios_Actividad= new Detalle_Horarios_ActividadModel();


            if (id.ToString() != "0")
            {
                var Detalle_Horarios_ActividadsData = _IDetalle_Horarios_ActividadApiConsumer.ListaSelAll(0, 1000, "Detalle_Horarios_Actividad.Folio=" + id, "").Resource.Detalle_Horarios_Actividads;
				
				if (Detalle_Horarios_ActividadsData != null && Detalle_Horarios_ActividadsData.Count > 0)
                {
					var Detalle_Horarios_ActividadData = Detalle_Horarios_ActividadsData.First();
					varDetalle_Horarios_Actividad= new Detalle_Horarios_ActividadModel
					{
						Folio  = Detalle_Horarios_ActividadData.Folio 
	                    ,Reservada = Detalle_Horarios_ActividadData.Reservada.GetValueOrDefault()
                    ,Numero_de_Cita = Detalle_Horarios_ActividadData.Numero_de_Cita
                    ,Hora_inicio = Detalle_Horarios_ActividadData.Hora_inicio
                    ,Hora_fin = Detalle_Horarios_ActividadData.Hora_fin
                    ,Horario = Detalle_Horarios_ActividadData.Horario
                    ,Codigo_de_Reservacion = Detalle_Horarios_ActividadData.Codigo_de_Reservacion
                    ,Codigo_de_ReservacionCodigo_Reservacion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Horarios_ActividadData.Codigo_de_Reservacion), "Detalle_Registro_en_Actividad_Evento") ??  (string)Detalle_Horarios_ActividadData.Codigo_de_Reservacion_Detalle_Registro_en_Actividad_Evento.Codigo_Reservacion
                    ,Numero_de_Empleado = Detalle_Horarios_ActividadData.Numero_de_Empleado
                    ,Familiar_del_Empleado = Detalle_Horarios_ActividadData.Familiar_del_Empleado.GetValueOrDefault()
                    ,Nombre_Completo = Detalle_Horarios_ActividadData.Nombre_Completo
                    ,Parentesco_con_el_Empleado = Detalle_Horarios_ActividadData.Parentesco_con_el_Empleado
                    ,Parentesco_con_el_EmpleadoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Horarios_ActividadData.Parentesco_con_el_Empleado), "Parentescos_Empleados") ??  (string)Detalle_Horarios_ActividadData.Parentesco_con_el_Empleado_Parentescos_Empleados.Descripcion
                    ,Sexo = Detalle_Horarios_ActividadData.Sexo
                    ,SexoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Horarios_ActividadData.Sexo), "Sexo") ??  (string)Detalle_Horarios_ActividadData.Sexo_Sexo.Descripcion
                    ,Edad = Detalle_Horarios_ActividadData.Edad
                    ,Estatus_de_la_Reservacion = Detalle_Horarios_ActividadData.Estatus_de_la_Reservacion
                    ,Estatus_de_la_ReservacionDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Horarios_ActividadData.Estatus_de_la_Reservacion), "Estatus_Reservaciones_Actividad") ??  (string)Detalle_Horarios_ActividadData.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Descripcion
                    ,Asistio = Detalle_Horarios_ActividadData.Asistio.GetValueOrDefault()

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IDetalle_Registro_en_Actividad_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Detalle_Registro_en_Actividad_Eventos_Codigo_de_Reservacion = _IDetalle_Registro_en_Actividad_EventoApiConsumer.SelAll(true);
            if (Detalle_Registro_en_Actividad_Eventos_Codigo_de_Reservacion != null && Detalle_Registro_en_Actividad_Eventos_Codigo_de_Reservacion.Resource != null)
                ViewBag.Detalle_Registro_en_Actividad_Eventos_Codigo_de_Reservacion = Detalle_Registro_en_Actividad_Eventos_Codigo_de_Reservacion.Resource.Where(m => m.Codigo_Reservacion != null).OrderBy(m => m.Codigo_Reservacion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Detalle_Registro_en_Actividad_Evento", "Codigo_Reservacion") ?? m.Codigo_Reservacion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IParentescos_EmpleadosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Parentescos_Empleadoss_Parentesco_con_el_Empleado = _IParentescos_EmpleadosApiConsumer.SelAll(true);
            if (Parentescos_Empleadoss_Parentesco_con_el_Empleado != null && Parentescos_Empleadoss_Parentesco_con_el_Empleado.Resource != null)
                ViewBag.Parentescos_Empleadoss_Parentesco_con_el_Empleado = Parentescos_Empleadoss_Parentesco_con_el_Empleado.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Parentescos_Empleados", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Sexo = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Sexo != null && Sexos_Sexo.Resource != null)
                ViewBag.Sexos_Sexo = Sexos_Sexo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_Reservaciones_ActividadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Reservaciones_Actividads_Estatus_de_la_Reservacion = _IEstatus_Reservaciones_ActividadApiConsumer.SelAll(true);
            if (Estatus_Reservaciones_Actividads_Estatus_de_la_Reservacion != null && Estatus_Reservaciones_Actividads_Estatus_de_la_Reservacion.Resource != null)
                ViewBag.Estatus_Reservaciones_Actividads_Estatus_de_la_Reservacion = Estatus_Reservaciones_Actividads_Estatus_de_la_Reservacion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_Reservaciones_Actividad", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddDetalle_Horarios_Actividad", varDetalle_Horarios_Actividad);
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
        public ActionResult GetDetalle_Registro_en_Actividad_EventoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Registro_en_Actividad_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDetalle_Registro_en_Actividad_EventoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Codigo_Reservacion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Detalle_Registro_en_Actividad_Evento", "Codigo_Reservacion")?? m.Codigo_Reservacion,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetParentescos_EmpleadosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IParentescos_EmpleadosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IParentescos_EmpleadosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Parentescos_Empleados", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSexoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISexoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstatus_Reservaciones_ActividadAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_Reservaciones_ActividadApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_Reservaciones_ActividadApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_Reservaciones_Actividad", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Horarios_ActividadPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Horarios_ActividadApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Horarios_Actividads == null)
                result.Detalle_Horarios_Actividads = new List<Detalle_Horarios_Actividad>();

            return Json(new
            {
                data = result.Detalle_Horarios_Actividads.Select(m => new Detalle_Horarios_ActividadGridModel
                    {
                    Folio = m.Folio
			,Reservada = m.Reservada
			,Numero_de_Cita = m.Numero_de_Cita
			,Hora_inicio = m.Hora_inicio
			,Hora_fin = m.Hora_fin
			,Horario = m.Horario
                        ,Codigo_de_ReservacionCodigo_Reservacion = CultureHelper.GetTraduction(m.Codigo_de_Reservacion_Detalle_Registro_en_Actividad_Evento.Folio.ToString(), "Codigo_Reservacion") ?? (string)m.Codigo_de_Reservacion_Detalle_Registro_en_Actividad_Evento.Codigo_Reservacion
			,Numero_de_Empleado = m.Numero_de_Empleado
			,Familiar_del_Empleado = m.Familiar_del_Empleado
			,Nombre_Completo = m.Nombre_Completo
                        ,Parentesco_con_el_EmpleadoDescripcion = CultureHelper.GetTraduction(m.Parentesco_con_el_Empleado_Parentescos_Empleados.Folio.ToString(), "Descripcion") ?? (string)m.Parentesco_con_el_Empleado_Parentescos_Empleados.Descripcion
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Edad = m.Edad
                        ,Estatus_de_la_ReservacionDescripcion = CultureHelper.GetTraduction(m.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Folio.ToString(), "Descripcion") ?? (string)m.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Descripcion
			,Asistio = m.Asistio

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
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
                _IDetalle_Horarios_ActividadApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Horarios_Actividad varDetalle_Horarios_Actividad = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Horarios_ActividadApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Horarios_ActividadModel varDetalle_Horarios_Actividad)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Horarios_ActividadApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Horarios_ActividadInfo = new Detalle_Horarios_Actividad
                    {
                        Folio = varDetalle_Horarios_Actividad.Folio
                        ,Reservada = varDetalle_Horarios_Actividad.Reservada
                        ,Numero_de_Cita = varDetalle_Horarios_Actividad.Numero_de_Cita
                        ,Hora_inicio = varDetalle_Horarios_Actividad.Hora_inicio
                        ,Hora_fin = varDetalle_Horarios_Actividad.Hora_fin
                        ,Horario = varDetalle_Horarios_Actividad.Horario
                        ,Codigo_de_Reservacion = varDetalle_Horarios_Actividad.Codigo_de_Reservacion
                        ,Numero_de_Empleado = varDetalle_Horarios_Actividad.Numero_de_Empleado
                        ,Familiar_del_Empleado = varDetalle_Horarios_Actividad.Familiar_del_Empleado
                        ,Nombre_Completo = varDetalle_Horarios_Actividad.Nombre_Completo
                        ,Parentesco_con_el_Empleado = varDetalle_Horarios_Actividad.Parentesco_con_el_Empleado
                        ,Sexo = varDetalle_Horarios_Actividad.Sexo
                        ,Edad = varDetalle_Horarios_Actividad.Edad
                        ,Estatus_de_la_Reservacion = varDetalle_Horarios_Actividad.Estatus_de_la_Reservacion
                        ,Asistio = varDetalle_Horarios_Actividad.Asistio

                    };

                    result = !IsNew ?
                        _IDetalle_Horarios_ActividadApiConsumer.Update(Detalle_Horarios_ActividadInfo, null, null).Resource.ToString() :
                         _IDetalle_Horarios_ActividadApiConsumer.Insert(Detalle_Horarios_ActividadInfo, null, null).Resource.ToString();

                    return Json(result, JsonRequestBehavior.AllowGet);
				}
				return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Detalle_Horarios_Actividad script
        /// </summary>
        /// <param name="oDetalle_Horarios_ActividadElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Horarios_ActividadModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Horarios_ActividadModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Horarios_ActividadModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Horarios_ActividadModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Horarios_ActividadModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Horarios_ActividadModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Horarios_ActividadModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Horarios_ActividadModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Horarios_ActividadModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Horarios_ActividadModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Horarios_ActividadModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Horarios_ActividadModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Horarios_ActividadScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Horarios_Actividad.js")))
            {
                strDetalle_Horarios_ActividadScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Horarios_Actividad element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Horarios_ActividadModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Horarios_ActividadScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Horarios_ActividadScript.Substring(indexOfArray, strDetalle_Horarios_ActividadScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Horarios_ActividadModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Horarios_ActividadModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Horarios_ActividadScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Horarios_ActividadScript.Substring(indexOfArrayHistory, strDetalle_Horarios_ActividadScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Horarios_ActividadScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Horarios_ActividadScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Horarios_ActividadScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Horarios_ActividadModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Horarios_ActividadScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Horarios_ActividadScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Horarios_ActividadScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Horarios_ActividadScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Horarios_Actividad.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Horarios_Actividad.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Horarios_Actividad.js")))
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
        public ActionResult Detalle_Horarios_ActividadPropertyBag()
        {
            return PartialView("Detalle_Horarios_ActividadPropertyBag", "Detalle_Horarios_Actividad");
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

            _IDetalle_Horarios_ActividadApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Horarios_ActividadPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Horarios_ActividadApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Horarios_Actividads == null)
                result.Detalle_Horarios_Actividads = new List<Detalle_Horarios_Actividad>();

            var data = result.Detalle_Horarios_Actividads.Select(m => new Detalle_Horarios_ActividadGridModel
            {
                Folio = m.Folio
                ,Reservada = m.Reservada
                ,Numero_de_Cita = m.Numero_de_Cita
                ,Hora_inicio = m.Hora_inicio
                ,Hora_fin = m.Hora_fin
                ,Horario = m.Horario
                ,Codigo_de_ReservacionCodigo_Reservacion = (string)m.Codigo_de_Reservacion_Detalle_Registro_en_Actividad_Evento.Codigo_Reservacion
                ,Numero_de_Empleado = m.Numero_de_Empleado
                ,Familiar_del_Empleado = m.Familiar_del_Empleado
                ,Nombre_Completo = m.Nombre_Completo
                ,Parentesco_con_el_EmpleadoDescripcion = (string)m.Parentesco_con_el_Empleado_Parentescos_Empleados.Descripcion
                ,SexoDescripcion = (string)m.Sexo_Sexo.Descripcion
                ,Edad = m.Edad
                ,Estatus_de_la_ReservacionDescripcion = (string)m.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Descripcion
                ,Asistio = m.Asistio

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Horarios_ActividadList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Horarios_ActividadList_" + DateTime.Now.ToString());
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

            _IDetalle_Horarios_ActividadApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Horarios_ActividadPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Horarios_ActividadApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Horarios_Actividads == null)
                result.Detalle_Horarios_Actividads = new List<Detalle_Horarios_Actividad>();

            var data = result.Detalle_Horarios_Actividads.Select(m => new Detalle_Horarios_ActividadGridModel
            {
                Folio = m.Folio
                ,Reservada = m.Reservada
                ,Numero_de_Cita = m.Numero_de_Cita
                ,Hora_inicio = m.Hora_inicio
                ,Hora_fin = m.Hora_fin
                ,Horario = m.Horario
                ,Codigo_de_ReservacionCodigo_Reservacion = (string)m.Codigo_de_Reservacion_Detalle_Registro_en_Actividad_Evento.Codigo_Reservacion
                ,Numero_de_Empleado = m.Numero_de_Empleado
                ,Familiar_del_Empleado = m.Familiar_del_Empleado
                ,Nombre_Completo = m.Nombre_Completo
                ,Parentesco_con_el_EmpleadoDescripcion = (string)m.Parentesco_con_el_Empleado_Parentescos_Empleados.Descripcion
                ,SexoDescripcion = (string)m.Sexo_Sexo.Descripcion
                ,Edad = m.Edad
                ,Estatus_de_la_ReservacionDescripcion = (string)m.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Descripcion
                ,Asistio = m.Asistio

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
