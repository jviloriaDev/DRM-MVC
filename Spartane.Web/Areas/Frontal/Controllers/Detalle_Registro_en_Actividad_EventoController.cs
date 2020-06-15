using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento;
using Spartane.Core.Domain.Detalle_Actividades_Evento;
using Spartane.Core.Domain.Parentescos_Empleados;
using Spartane.Core.Domain.Sexo;
using Spartane.Core.Domain.Estatus_Reservaciones_Actividad;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Registro_en_Actividad_Evento;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
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

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Detalle_Registro_en_Actividad_EventoController : Controller
    {
        #region "variable declaration"

        private IDetalle_Registro_en_Actividad_EventoService service = null;
        private IDetalle_Registro_en_Actividad_EventoApiConsumer _IDetalle_Registro_en_Actividad_EventoApiConsumer;
        private IDetalle_Actividades_EventoApiConsumer _IDetalle_Actividades_EventoApiConsumer;
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

        
        public Detalle_Registro_en_Actividad_EventoController(IDetalle_Registro_en_Actividad_EventoService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Registro_en_Actividad_EventoApiConsumer Detalle_Registro_en_Actividad_EventoApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IDetalle_Actividades_EventoApiConsumer Detalle_Actividades_EventoApiConsumer , IParentescos_EmpleadosApiConsumer Parentescos_EmpleadosApiConsumer , ISexoApiConsumer SexoApiConsumer , IEstatus_Reservaciones_ActividadApiConsumer Estatus_Reservaciones_ActividadApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Registro_en_Actividad_EventoApiConsumer = Detalle_Registro_en_Actividad_EventoApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IDetalle_Actividades_EventoApiConsumer = Detalle_Actividades_EventoApiConsumer;
            this._IParentescos_EmpleadosApiConsumer = Parentescos_EmpleadosApiConsumer;
            this._ISexoApiConsumer = SexoApiConsumer;
            this._IEstatus_Reservaciones_ActividadApiConsumer = Estatus_Reservaciones_ActividadApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Registro_en_Actividad_Evento
        [ObjectAuth(ObjectId = (ModuleObjectId)44441, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44441);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Registro_en_Actividad_Evento/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44441, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44441);
            ViewBag.Permission = permission;
            var varDetalle_Registro_en_Actividad_Evento = new Detalle_Registro_en_Actividad_EventoModel();
			
            ViewBag.ObjectId = "44441";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Registro_en_Actividad_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Registro_en_Actividad_EventoData = _IDetalle_Registro_en_Actividad_EventoApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Registro_en_Actividad_Eventos[0];
                if (Detalle_Registro_en_Actividad_EventoData == null)
                    return HttpNotFound();

                varDetalle_Registro_en_Actividad_Evento = new Detalle_Registro_en_Actividad_EventoModel
                {
                    Folio = (int)Detalle_Registro_en_Actividad_EventoData.Folio
                    ,Actividad = Detalle_Registro_en_Actividad_EventoData.Actividad
                    ,ActividadNombre_de_la_Actividad = CultureHelper.GetTraduction(Convert.ToString(Detalle_Registro_en_Actividad_EventoData.Actividad), "Detalle_Actividades_Evento") ??  (string)Detalle_Registro_en_Actividad_EventoData.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
                    ,Fecha = (Detalle_Registro_en_Actividad_EventoData.Fecha == null ? string.Empty : Convert.ToDateTime(Detalle_Registro_en_Actividad_EventoData.Fecha).ToString(ConfigurationProperty.DateFormat))
                    ,Horario = Detalle_Registro_en_Actividad_EventoData.Horario
                    ,Es_para_un_familiar = Detalle_Registro_en_Actividad_EventoData.Es_para_un_familiar.GetValueOrDefault()
                    ,Numero_de_Empleado = Detalle_Registro_en_Actividad_EventoData.Numero_de_Empleado
                    ,Nombres = Detalle_Registro_en_Actividad_EventoData.Nombres
                    ,Apellido_Paterno = Detalle_Registro_en_Actividad_EventoData.Apellido_Paterno
                    ,Apellido_Materno = Detalle_Registro_en_Actividad_EventoData.Apellido_Materno
                    ,Nombre_Completo = Detalle_Registro_en_Actividad_EventoData.Nombre_Completo
                    ,Parentesco = Detalle_Registro_en_Actividad_EventoData.Parentesco
                    ,ParentescoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Registro_en_Actividad_EventoData.Parentesco), "Parentescos_Empleados") ??  (string)Detalle_Registro_en_Actividad_EventoData.Parentesco_Parentescos_Empleados.Descripcion
                    ,Sexo = Detalle_Registro_en_Actividad_EventoData.Sexo
                    ,SexoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Registro_en_Actividad_EventoData.Sexo), "Sexo") ??  (string)Detalle_Registro_en_Actividad_EventoData.Sexo_Sexo.Descripcion
                    ,Fecha_de_nacimiento = (Detalle_Registro_en_Actividad_EventoData.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(Detalle_Registro_en_Actividad_EventoData.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                    ,Estatus_de_la_Reservacion = Detalle_Registro_en_Actividad_EventoData.Estatus_de_la_Reservacion
                    ,Estatus_de_la_ReservacionDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Registro_en_Actividad_EventoData.Estatus_de_la_Reservacion), "Estatus_Reservaciones_Actividad") ??  (string)Detalle_Registro_en_Actividad_EventoData.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Descripcion
                    ,Codigo_Reservacion = Detalle_Registro_en_Actividad_EventoData.Codigo_Reservacion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Detalle_Actividades_Eventos_Actividad = _IDetalle_Actividades_EventoApiConsumer.SelAll(true);
            if (Detalle_Actividades_Eventos_Actividad != null && Detalle_Actividades_Eventos_Actividad.Resource != null)
                ViewBag.Detalle_Actividades_Eventos_Actividad = Detalle_Actividades_Eventos_Actividad.Resource.Where(m => m.Nombre_de_la_Actividad != null).OrderBy(m => m.Nombre_de_la_Actividad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Detalle_Actividades_Evento", "Nombre_de_la_Actividad") ?? m.Nombre_de_la_Actividad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IParentescos_EmpleadosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Parentescos_Empleadoss_Parentesco = _IParentescos_EmpleadosApiConsumer.SelAll(true);
            if (Parentescos_Empleadoss_Parentesco != null && Parentescos_Empleadoss_Parentesco.Resource != null)
                ViewBag.Parentescos_Empleadoss_Parentesco = Parentescos_Empleadoss_Parentesco.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
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
            return View(varDetalle_Registro_en_Actividad_Evento);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Registro_en_Actividad_Evento(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44441);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Registro_en_Actividad_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Registro_en_Actividad_EventoModel varDetalle_Registro_en_Actividad_Evento= new Detalle_Registro_en_Actividad_EventoModel();


            if (id.ToString() != "0")
            {
                var Detalle_Registro_en_Actividad_EventosData = _IDetalle_Registro_en_Actividad_EventoApiConsumer.ListaSelAll(0, 1000, "Detalle_Registro_en_Actividad_Evento.Folio=" + id, "").Resource.Detalle_Registro_en_Actividad_Eventos;
				
				if (Detalle_Registro_en_Actividad_EventosData != null && Detalle_Registro_en_Actividad_EventosData.Count > 0)
                {
					var Detalle_Registro_en_Actividad_EventoData = Detalle_Registro_en_Actividad_EventosData.First();
					varDetalle_Registro_en_Actividad_Evento= new Detalle_Registro_en_Actividad_EventoModel
					{
						Folio  = Detalle_Registro_en_Actividad_EventoData.Folio 
	                    ,Actividad = Detalle_Registro_en_Actividad_EventoData.Actividad
                    ,ActividadNombre_de_la_Actividad = CultureHelper.GetTraduction(Convert.ToString(Detalle_Registro_en_Actividad_EventoData.Actividad), "Detalle_Actividades_Evento") ??  (string)Detalle_Registro_en_Actividad_EventoData.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
                    ,Fecha = (Detalle_Registro_en_Actividad_EventoData.Fecha == null ? string.Empty : Convert.ToDateTime(Detalle_Registro_en_Actividad_EventoData.Fecha).ToString(ConfigurationProperty.DateFormat))
                    ,Horario = Detalle_Registro_en_Actividad_EventoData.Horario
                    ,Es_para_un_familiar = Detalle_Registro_en_Actividad_EventoData.Es_para_un_familiar.GetValueOrDefault()
                    ,Numero_de_Empleado = Detalle_Registro_en_Actividad_EventoData.Numero_de_Empleado
                    ,Nombres = Detalle_Registro_en_Actividad_EventoData.Nombres
                    ,Apellido_Paterno = Detalle_Registro_en_Actividad_EventoData.Apellido_Paterno
                    ,Apellido_Materno = Detalle_Registro_en_Actividad_EventoData.Apellido_Materno
                    ,Nombre_Completo = Detalle_Registro_en_Actividad_EventoData.Nombre_Completo
                    ,Parentesco = Detalle_Registro_en_Actividad_EventoData.Parentesco
                    ,ParentescoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Registro_en_Actividad_EventoData.Parentesco), "Parentescos_Empleados") ??  (string)Detalle_Registro_en_Actividad_EventoData.Parentesco_Parentescos_Empleados.Descripcion
                    ,Sexo = Detalle_Registro_en_Actividad_EventoData.Sexo
                    ,SexoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Registro_en_Actividad_EventoData.Sexo), "Sexo") ??  (string)Detalle_Registro_en_Actividad_EventoData.Sexo_Sexo.Descripcion
                    ,Fecha_de_nacimiento = (Detalle_Registro_en_Actividad_EventoData.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(Detalle_Registro_en_Actividad_EventoData.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                    ,Estatus_de_la_Reservacion = Detalle_Registro_en_Actividad_EventoData.Estatus_de_la_Reservacion
                    ,Estatus_de_la_ReservacionDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Registro_en_Actividad_EventoData.Estatus_de_la_Reservacion), "Estatus_Reservaciones_Actividad") ??  (string)Detalle_Registro_en_Actividad_EventoData.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Descripcion
                    ,Codigo_Reservacion = Detalle_Registro_en_Actividad_EventoData.Codigo_Reservacion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Detalle_Actividades_Eventos_Actividad = _IDetalle_Actividades_EventoApiConsumer.SelAll(true);
            if (Detalle_Actividades_Eventos_Actividad != null && Detalle_Actividades_Eventos_Actividad.Resource != null)
                ViewBag.Detalle_Actividades_Eventos_Actividad = Detalle_Actividades_Eventos_Actividad.Resource.Where(m => m.Nombre_de_la_Actividad != null).OrderBy(m => m.Nombre_de_la_Actividad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Detalle_Actividades_Evento", "Nombre_de_la_Actividad") ?? m.Nombre_de_la_Actividad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IParentescos_EmpleadosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Parentescos_Empleadoss_Parentesco = _IParentescos_EmpleadosApiConsumer.SelAll(true);
            if (Parentescos_Empleadoss_Parentesco != null && Parentescos_Empleadoss_Parentesco.Resource != null)
                ViewBag.Parentescos_Empleadoss_Parentesco = Parentescos_Empleadoss_Parentesco.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
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


            return PartialView("AddDetalle_Registro_en_Actividad_Evento", varDetalle_Registro_en_Actividad_Evento);
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
        public ActionResult GetDetalle_Actividades_EventoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDetalle_Actividades_EventoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_de_la_Actividad).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Detalle_Actividades_Evento", "Nombre_de_la_Actividad")?? m.Nombre_de_la_Actividad,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Registro_en_Actividad_EventoPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Registro_en_Actividad_EventoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Registro_en_Actividad_Eventos == null)
                result.Detalle_Registro_en_Actividad_Eventos = new List<Detalle_Registro_en_Actividad_Evento>();

            return Json(new
            {
                data = result.Detalle_Registro_en_Actividad_Eventos.Select(m => new Detalle_Registro_en_Actividad_EventoGridModel
                    {
                    Folio = m.Folio
                        ,ActividadNombre_de_la_Actividad = CultureHelper.GetTraduction(m.Actividad_Detalle_Actividades_Evento.Folio.ToString(), "Nombre_de_la_Actividad") ?? (string)m.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
                        ,Fecha = (m.Fecha == null ? string.Empty : Convert.ToDateTime(m.Fecha).ToString(ConfigurationProperty.DateFormat))
			,Horario = m.Horario
			,Es_para_un_familiar = m.Es_para_un_familiar
			,Numero_de_Empleado = m.Numero_de_Empleado
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
                        ,ParentescoDescripcion = CultureHelper.GetTraduction(m.Parentesco_Parentescos_Empleados.Folio.ToString(), "Descripcion") ?? (string)m.Parentesco_Parentescos_Empleados.Descripcion
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
                        ,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                        ,Estatus_de_la_ReservacionDescripcion = CultureHelper.GetTraduction(m.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Folio.ToString(), "Descripcion") ?? (string)m.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Descripcion
			,Codigo_Reservacion = m.Codigo_Reservacion

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
                _IDetalle_Registro_en_Actividad_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Registro_en_Actividad_Evento varDetalle_Registro_en_Actividad_Evento = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Registro_en_Actividad_EventoApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Registro_en_Actividad_EventoModel varDetalle_Registro_en_Actividad_Evento)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Registro_en_Actividad_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Registro_en_Actividad_EventoInfo = new Detalle_Registro_en_Actividad_Evento
                    {
                        Folio = varDetalle_Registro_en_Actividad_Evento.Folio
                        ,Actividad = varDetalle_Registro_en_Actividad_Evento.Actividad
                        ,Fecha = (!String.IsNullOrEmpty(varDetalle_Registro_en_Actividad_Evento.Fecha)) ? DateTime.ParseExact(varDetalle_Registro_en_Actividad_Evento.Fecha, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Horario = varDetalle_Registro_en_Actividad_Evento.Horario
                        ,Es_para_un_familiar = varDetalle_Registro_en_Actividad_Evento.Es_para_un_familiar
                        ,Numero_de_Empleado = varDetalle_Registro_en_Actividad_Evento.Numero_de_Empleado
                        ,Nombres = varDetalle_Registro_en_Actividad_Evento.Nombres
                        ,Apellido_Paterno = varDetalle_Registro_en_Actividad_Evento.Apellido_Paterno
                        ,Apellido_Materno = varDetalle_Registro_en_Actividad_Evento.Apellido_Materno
                        ,Nombre_Completo = varDetalle_Registro_en_Actividad_Evento.Nombre_Completo
                        ,Parentesco = varDetalle_Registro_en_Actividad_Evento.Parentesco
                        ,Sexo = varDetalle_Registro_en_Actividad_Evento.Sexo
                        ,Fecha_de_nacimiento = (!String.IsNullOrEmpty(varDetalle_Registro_en_Actividad_Evento.Fecha_de_nacimiento)) ? DateTime.ParseExact(varDetalle_Registro_en_Actividad_Evento.Fecha_de_nacimiento, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Estatus_de_la_Reservacion = varDetalle_Registro_en_Actividad_Evento.Estatus_de_la_Reservacion
                        ,Codigo_Reservacion = varDetalle_Registro_en_Actividad_Evento.Codigo_Reservacion

                    };

                    result = !IsNew ?
                        _IDetalle_Registro_en_Actividad_EventoApiConsumer.Update(Detalle_Registro_en_Actividad_EventoInfo, null, null).Resource.ToString() :
                         _IDetalle_Registro_en_Actividad_EventoApiConsumer.Insert(Detalle_Registro_en_Actividad_EventoInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Registro_en_Actividad_Evento script
        /// </summary>
        /// <param name="oDetalle_Registro_en_Actividad_EventoElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Registro_en_Actividad_EventoModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Registro_en_Actividad_EventoModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Registro_en_Actividad_EventoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Registro_en_Actividad_EventoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Registro_en_Actividad_EventoModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Registro_en_Actividad_EventoModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Registro_en_Actividad_EventoModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Registro_en_Actividad_EventoModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Registro_en_Actividad_EventoModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Registro_en_Actividad_EventoModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Registro_en_Actividad_EventoModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Registro_en_Actividad_EventoModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Registro_en_Actividad_EventoScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Registro_en_Actividad_Evento.js")))
            {
                strDetalle_Registro_en_Actividad_EventoScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Registro_en_Actividad_Evento element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Registro_en_Actividad_EventoModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Registro_en_Actividad_EventoScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Registro_en_Actividad_EventoScript.Substring(indexOfArray, strDetalle_Registro_en_Actividad_EventoScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Registro_en_Actividad_EventoModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Registro_en_Actividad_EventoModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Registro_en_Actividad_EventoScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Registro_en_Actividad_EventoScript.Substring(indexOfArrayHistory, strDetalle_Registro_en_Actividad_EventoScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Registro_en_Actividad_EventoScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Registro_en_Actividad_EventoScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Registro_en_Actividad_EventoScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Registro_en_Actividad_EventoModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Registro_en_Actividad_EventoScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Registro_en_Actividad_EventoScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Registro_en_Actividad_EventoScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Registro_en_Actividad_EventoScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Registro_en_Actividad_Evento.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Registro_en_Actividad_Evento.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Registro_en_Actividad_Evento.js")))
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
        public ActionResult Detalle_Registro_en_Actividad_EventoPropertyBag()
        {
            return PartialView("Detalle_Registro_en_Actividad_EventoPropertyBag", "Detalle_Registro_en_Actividad_Evento");
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

            _IDetalle_Registro_en_Actividad_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Registro_en_Actividad_EventoPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Registro_en_Actividad_EventoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Registro_en_Actividad_Eventos == null)
                result.Detalle_Registro_en_Actividad_Eventos = new List<Detalle_Registro_en_Actividad_Evento>();

            var data = result.Detalle_Registro_en_Actividad_Eventos.Select(m => new Detalle_Registro_en_Actividad_EventoGridModel
            {
                Folio = m.Folio
                ,ActividadNombre_de_la_Actividad = (string)m.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
                ,Fecha = (m.Fecha == null ? string.Empty : Convert.ToDateTime(m.Fecha).ToString(ConfigurationProperty.DateFormat))
                ,Horario = m.Horario
                ,Es_para_un_familiar = m.Es_para_un_familiar
                ,Numero_de_Empleado = m.Numero_de_Empleado
                ,Nombres = m.Nombres
                ,Apellido_Paterno = m.Apellido_Paterno
                ,Apellido_Materno = m.Apellido_Materno
                ,Nombre_Completo = m.Nombre_Completo
                ,ParentescoDescripcion = (string)m.Parentesco_Parentescos_Empleados.Descripcion
                ,SexoDescripcion = (string)m.Sexo_Sexo.Descripcion
                ,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                ,Estatus_de_la_ReservacionDescripcion = (string)m.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Descripcion
                ,Codigo_Reservacion = m.Codigo_Reservacion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Registro_en_Actividad_EventoList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Registro_en_Actividad_EventoList_" + DateTime.Now.ToString());
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

            _IDetalle_Registro_en_Actividad_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Registro_en_Actividad_EventoPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Registro_en_Actividad_EventoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Registro_en_Actividad_Eventos == null)
                result.Detalle_Registro_en_Actividad_Eventos = new List<Detalle_Registro_en_Actividad_Evento>();

            var data = result.Detalle_Registro_en_Actividad_Eventos.Select(m => new Detalle_Registro_en_Actividad_EventoGridModel
            {
                Folio = m.Folio
                ,ActividadNombre_de_la_Actividad = (string)m.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
                ,Fecha = (m.Fecha == null ? string.Empty : Convert.ToDateTime(m.Fecha).ToString(ConfigurationProperty.DateFormat))
                ,Horario = m.Horario
                ,Es_para_un_familiar = m.Es_para_un_familiar
                ,Numero_de_Empleado = m.Numero_de_Empleado
                ,Nombres = m.Nombres
                ,Apellido_Paterno = m.Apellido_Paterno
                ,Apellido_Materno = m.Apellido_Materno
                ,Nombre_Completo = m.Nombre_Completo
                ,ParentescoDescripcion = (string)m.Parentesco_Parentescos_Empleados.Descripcion
                ,SexoDescripcion = (string)m.Sexo_Sexo.Descripcion
                ,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                ,Estatus_de_la_ReservacionDescripcion = (string)m.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Descripcion
                ,Codigo_Reservacion = m.Codigo_Reservacion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
