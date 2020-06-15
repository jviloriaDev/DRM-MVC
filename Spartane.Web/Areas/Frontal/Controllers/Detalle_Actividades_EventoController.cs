using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Actividades_Evento;
using Spartane.Core.Domain.Tipos_de_Actividades;
using Spartane.Core.Domain.Especialidades;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Ubicaciones_Eventos_Empresa;
using Spartane.Core.Domain.Estatus_Actividades_Evento;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Actividades_Evento;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Actividades_Evento;
using Spartane.Web.Areas.WebApiConsumer.Tipos_de_Actividades;
using Spartane.Web.Areas.WebApiConsumer.Especialidades;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Ubicaciones_Eventos_Empresa;
using Spartane.Web.Areas.WebApiConsumer.Estatus_Actividades_Evento;

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
    public class Detalle_Actividades_EventoController : Controller
    {
        #region "variable declaration"

        private IDetalle_Actividades_EventoService service = null;
        private IDetalle_Actividades_EventoApiConsumer _IDetalle_Actividades_EventoApiConsumer;
        private ITipos_de_ActividadesApiConsumer _ITipos_de_ActividadesApiConsumer;
        private IEspecialidadesApiConsumer _IEspecialidadesApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IUbicaciones_Eventos_EmpresaApiConsumer _IUbicaciones_Eventos_EmpresaApiConsumer;
        private IEstatus_Actividades_EventoApiConsumer _IEstatus_Actividades_EventoApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Actividades_EventoController(IDetalle_Actividades_EventoService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Actividades_EventoApiConsumer Detalle_Actividades_EventoApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ITipos_de_ActividadesApiConsumer Tipos_de_ActividadesApiConsumer , IEspecialidadesApiConsumer EspecialidadesApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IUbicaciones_Eventos_EmpresaApiConsumer Ubicaciones_Eventos_EmpresaApiConsumer , IEstatus_Actividades_EventoApiConsumer Estatus_Actividades_EventoApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Actividades_EventoApiConsumer = Detalle_Actividades_EventoApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ITipos_de_ActividadesApiConsumer = Tipos_de_ActividadesApiConsumer;
            this._IEspecialidadesApiConsumer = EspecialidadesApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._IUbicaciones_Eventos_EmpresaApiConsumer = Ubicaciones_Eventos_EmpresaApiConsumer;
            this._IEstatus_Actividades_EventoApiConsumer = Estatus_Actividades_EventoApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Actividades_Evento
        [ObjectAuth(ObjectId = (ModuleObjectId)44431, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44431);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Actividades_Evento/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44431, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44431);
            ViewBag.Permission = permission;
            var varDetalle_Actividades_Evento = new Detalle_Actividades_EventoModel();
			
            ViewBag.ObjectId = "44431";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Actividades_EventoData = _IDetalle_Actividades_EventoApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Actividades_Eventos[0];
                if (Detalle_Actividades_EventoData == null)
                    return HttpNotFound();

                varDetalle_Actividades_Evento = new Detalle_Actividades_EventoModel
                {
                    Folio = (int)Detalle_Actividades_EventoData.Folio
                    ,Tipo_de_Actividad = Detalle_Actividades_EventoData.Tipo_de_Actividad
                    ,Tipo_de_ActividadDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Actividades_EventoData.Tipo_de_Actividad), "Tipos_de_Actividades") ??  (string)Detalle_Actividades_EventoData.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                    ,Especialidad = Detalle_Actividades_EventoData.Especialidad
                    ,EspecialidadEspecialidad = CultureHelper.GetTraduction(Convert.ToString(Detalle_Actividades_EventoData.Especialidad), "Especialidades") ??  (string)Detalle_Actividades_EventoData.Especialidad_Especialidades.Especialidad
                    ,Nombre_de_la_Actividad = Detalle_Actividades_EventoData.Nombre_de_la_Actividad
                    ,Descripcion = Detalle_Actividades_EventoData.Descripcion
                    ,Quien_imparte = Detalle_Actividades_EventoData.Quien_imparte
                    ,Quien_imparteName = CultureHelper.GetTraduction(Convert.ToString(Detalle_Actividades_EventoData.Quien_imparte), "Spartan_User") ??  (string)Detalle_Actividades_EventoData.Quien_imparte_Spartan_User.Name
                    ,Dia = (Detalle_Actividades_EventoData.Dia == null ? string.Empty : Convert.ToDateTime(Detalle_Actividades_EventoData.Dia).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_inicio = Detalle_Actividades_EventoData.Hora_inicio
                    ,Hora_fin = Detalle_Actividades_EventoData.Hora_fin
                    ,Tiene_receso = Detalle_Actividades_EventoData.Tiene_receso.GetValueOrDefault()
                    ,Hora_inicio_receso = Detalle_Actividades_EventoData.Hora_inicio_receso
                    ,Hora_fin_receso = Detalle_Actividades_EventoData.Hora_fin_receso
                    ,Duracion_maxima_por_paciente_mins = Detalle_Actividades_EventoData.Duracion_maxima_por_paciente_mins
                    ,Cupo_limitado = Detalle_Actividades_EventoData.Cupo_limitado.GetValueOrDefault()
                    ,Cupo_maximo = Detalle_Actividades_EventoData.Cupo_maximo
                    ,Ubicacion = Detalle_Actividades_EventoData.Ubicacion
                    ,UbicacionNombre = CultureHelper.GetTraduction(Convert.ToString(Detalle_Actividades_EventoData.Ubicacion), "Ubicaciones_Eventos_Empresa") ??  (string)Detalle_Actividades_EventoData.Ubicacion_Ubicaciones_Eventos_Empresa.Nombre
                    ,Estatus_de_la_Actividad = Detalle_Actividades_EventoData.Estatus_de_la_Actividad
                    ,Estatus_de_la_ActividadDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Actividades_EventoData.Estatus_de_la_Actividad), "Estatus_Actividades_Evento") ??  (string)Detalle_Actividades_EventoData.Estatus_de_la_Actividad_Estatus_Actividades_Evento.Descripcion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipos_de_ActividadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipos_de_Actividadess_Tipo_de_Actividad = _ITipos_de_ActividadesApiConsumer.SelAll(true);
            if (Tipos_de_Actividadess_Tipo_de_Actividad != null && Tipos_de_Actividadess_Tipo_de_Actividad.Resource != null)
                ViewBag.Tipos_de_Actividadess_Tipo_de_Actividad = Tipos_de_Actividadess_Tipo_de_Actividad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipos_de_Actividades", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Especialidadess_Especialidad = _IEspecialidadesApiConsumer.SelAll(true);
            if (Especialidadess_Especialidad != null && Especialidadess_Especialidad.Resource != null)
                ViewBag.Especialidadess_Especialidad = Especialidadess_Especialidad.Resource.Where(m => m.Especialidad != null).OrderBy(m => m.Especialidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Especialidades", "Especialidad") ?? m.Especialidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Quien_imparte = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Quien_imparte != null && Spartan_Users_Quien_imparte.Resource != null)
                ViewBag.Spartan_Users_Quien_imparte = Spartan_Users_Quien_imparte.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Ubicaciones_Eventos_Empresas_Ubicacion = _IUbicaciones_Eventos_EmpresaApiConsumer.SelAll(true);
            if (Ubicaciones_Eventos_Empresas_Ubicacion != null && Ubicaciones_Eventos_Empresas_Ubicacion.Resource != null)
                ViewBag.Ubicaciones_Eventos_Empresas_Ubicacion = Ubicaciones_Eventos_Empresas_Ubicacion.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Ubicaciones_Eventos_Empresa", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IEstatus_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Actividades_Eventos_Estatus_de_la_Actividad = _IEstatus_Actividades_EventoApiConsumer.SelAll(true);
            if (Estatus_Actividades_Eventos_Estatus_de_la_Actividad != null && Estatus_Actividades_Eventos_Estatus_de_la_Actividad.Resource != null)
                ViewBag.Estatus_Actividades_Eventos_Estatus_de_la_Actividad = Estatus_Actividades_Eventos_Estatus_de_la_Actividad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_Actividades_Evento", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Actividades_Evento);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Actividades_Evento(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44431);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Actividades_EventoModel varDetalle_Actividades_Evento= new Detalle_Actividades_EventoModel();


            if (id.ToString() != "0")
            {
                var Detalle_Actividades_EventosData = _IDetalle_Actividades_EventoApiConsumer.ListaSelAll(0, 1000, "Detalle_Actividades_Evento.Folio=" + id, "").Resource.Detalle_Actividades_Eventos;
				
				if (Detalle_Actividades_EventosData != null && Detalle_Actividades_EventosData.Count > 0)
                {
					var Detalle_Actividades_EventoData = Detalle_Actividades_EventosData.First();
					varDetalle_Actividades_Evento= new Detalle_Actividades_EventoModel
					{
						Folio  = Detalle_Actividades_EventoData.Folio 
	                    ,Tipo_de_Actividad = Detalle_Actividades_EventoData.Tipo_de_Actividad
                    ,Tipo_de_ActividadDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Actividades_EventoData.Tipo_de_Actividad), "Tipos_de_Actividades") ??  (string)Detalle_Actividades_EventoData.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                    ,Especialidad = Detalle_Actividades_EventoData.Especialidad
                    ,EspecialidadEspecialidad = CultureHelper.GetTraduction(Convert.ToString(Detalle_Actividades_EventoData.Especialidad), "Especialidades") ??  (string)Detalle_Actividades_EventoData.Especialidad_Especialidades.Especialidad
                    ,Nombre_de_la_Actividad = Detalle_Actividades_EventoData.Nombre_de_la_Actividad
                    ,Descripcion = Detalle_Actividades_EventoData.Descripcion
                    ,Quien_imparte = Detalle_Actividades_EventoData.Quien_imparte
                    ,Quien_imparteName = CultureHelper.GetTraduction(Convert.ToString(Detalle_Actividades_EventoData.Quien_imparte), "Spartan_User") ??  (string)Detalle_Actividades_EventoData.Quien_imparte_Spartan_User.Name
                    ,Dia = (Detalle_Actividades_EventoData.Dia == null ? string.Empty : Convert.ToDateTime(Detalle_Actividades_EventoData.Dia).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_inicio = Detalle_Actividades_EventoData.Hora_inicio
                    ,Hora_fin = Detalle_Actividades_EventoData.Hora_fin
                    ,Tiene_receso = Detalle_Actividades_EventoData.Tiene_receso.GetValueOrDefault()
                    ,Hora_inicio_receso = Detalle_Actividades_EventoData.Hora_inicio_receso
                    ,Hora_fin_receso = Detalle_Actividades_EventoData.Hora_fin_receso
                    ,Duracion_maxima_por_paciente_mins = Detalle_Actividades_EventoData.Duracion_maxima_por_paciente_mins
                    ,Cupo_limitado = Detalle_Actividades_EventoData.Cupo_limitado.GetValueOrDefault()
                    ,Cupo_maximo = Detalle_Actividades_EventoData.Cupo_maximo
                    ,Ubicacion = Detalle_Actividades_EventoData.Ubicacion
                    ,UbicacionNombre = CultureHelper.GetTraduction(Convert.ToString(Detalle_Actividades_EventoData.Ubicacion), "Ubicaciones_Eventos_Empresa") ??  (string)Detalle_Actividades_EventoData.Ubicacion_Ubicaciones_Eventos_Empresa.Nombre
                    ,Estatus_de_la_Actividad = Detalle_Actividades_EventoData.Estatus_de_la_Actividad
                    ,Estatus_de_la_ActividadDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Actividades_EventoData.Estatus_de_la_Actividad), "Estatus_Actividades_Evento") ??  (string)Detalle_Actividades_EventoData.Estatus_de_la_Actividad_Estatus_Actividades_Evento.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ITipos_de_ActividadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipos_de_Actividadess_Tipo_de_Actividad = _ITipos_de_ActividadesApiConsumer.SelAll(true);
            if (Tipos_de_Actividadess_Tipo_de_Actividad != null && Tipos_de_Actividadess_Tipo_de_Actividad.Resource != null)
                ViewBag.Tipos_de_Actividadess_Tipo_de_Actividad = Tipos_de_Actividadess_Tipo_de_Actividad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipos_de_Actividades", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Especialidadess_Especialidad = _IEspecialidadesApiConsumer.SelAll(true);
            if (Especialidadess_Especialidad != null && Especialidadess_Especialidad.Resource != null)
                ViewBag.Especialidadess_Especialidad = Especialidadess_Especialidad.Resource.Where(m => m.Especialidad != null).OrderBy(m => m.Especialidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Especialidades", "Especialidad") ?? m.Especialidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Quien_imparte = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Quien_imparte != null && Spartan_Users_Quien_imparte.Resource != null)
                ViewBag.Spartan_Users_Quien_imparte = Spartan_Users_Quien_imparte.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Ubicaciones_Eventos_Empresas_Ubicacion = _IUbicaciones_Eventos_EmpresaApiConsumer.SelAll(true);
            if (Ubicaciones_Eventos_Empresas_Ubicacion != null && Ubicaciones_Eventos_Empresas_Ubicacion.Resource != null)
                ViewBag.Ubicaciones_Eventos_Empresas_Ubicacion = Ubicaciones_Eventos_Empresas_Ubicacion.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Ubicaciones_Eventos_Empresa", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IEstatus_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Actividades_Eventos_Estatus_de_la_Actividad = _IEstatus_Actividades_EventoApiConsumer.SelAll(true);
            if (Estatus_Actividades_Eventos_Estatus_de_la_Actividad != null && Estatus_Actividades_Eventos_Estatus_de_la_Actividad.Resource != null)
                ViewBag.Estatus_Actividades_Eventos_Estatus_de_la_Actividad = Estatus_Actividades_Eventos_Estatus_de_la_Actividad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_Actividades_Evento", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddDetalle_Actividades_Evento", varDetalle_Actividades_Evento);
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
        public ActionResult GetTipos_de_ActividadesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipos_de_ActividadesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipos_de_ActividadesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipos_de_Actividades", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEspecialidadesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEspecialidadesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Especialidad).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Especialidades", "Especialidad")?? m.Especialidad,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
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
        public ActionResult GetUbicaciones_Eventos_EmpresaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IUbicaciones_Eventos_EmpresaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Ubicaciones_Eventos_Empresa", "Nombre")?? m.Nombre,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstatus_Actividades_EventoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_Actividades_EventoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_Actividades_Evento", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Actividades_EventoPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Actividades_EventoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Actividades_Eventos == null)
                result.Detalle_Actividades_Eventos = new List<Detalle_Actividades_Evento>();

            return Json(new
            {
                data = result.Detalle_Actividades_Eventos.Select(m => new Detalle_Actividades_EventoGridModel
                    {
                    Folio = m.Folio
                        ,Tipo_de_ActividadDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Actividad_Tipos_de_Actividades.Folio.ToString(), "Descripcion") ?? (string)m.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ?? (string)m.Especialidad_Especialidades.Especialidad
			,Nombre_de_la_Actividad = m.Nombre_de_la_Actividad
			,Descripcion = m.Descripcion
                        ,Quien_imparteName = CultureHelper.GetTraduction(m.Quien_imparte_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Quien_imparte_Spartan_User.Name
                        ,Dia = (m.Dia == null ? string.Empty : Convert.ToDateTime(m.Dia).ToString(ConfigurationProperty.DateFormat))
			,Hora_inicio = m.Hora_inicio
			,Hora_fin = m.Hora_fin
			,Tiene_receso = m.Tiene_receso
			,Hora_inicio_receso = m.Hora_inicio_receso
			,Hora_fin_receso = m.Hora_fin_receso
			,Duracion_maxima_por_paciente_mins = m.Duracion_maxima_por_paciente_mins
			,Cupo_limitado = m.Cupo_limitado
			,Cupo_maximo = m.Cupo_maximo
                        ,UbicacionNombre = CultureHelper.GetTraduction(m.Ubicacion_Ubicaciones_Eventos_Empresa.Folio.ToString(), "Nombre") ?? (string)m.Ubicacion_Ubicaciones_Eventos_Empresa.Nombre
                        ,Estatus_de_la_ActividadDescripcion = CultureHelper.GetTraduction(m.Estatus_de_la_Actividad_Estatus_Actividades_Evento.Folio.ToString(), "Descripcion") ?? (string)m.Estatus_de_la_Actividad_Estatus_Actividades_Evento.Descripcion

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
                _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Actividades_Evento varDetalle_Actividades_Evento = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Actividades_EventoApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Actividades_EventoModel varDetalle_Actividades_Evento)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Actividades_EventoInfo = new Detalle_Actividades_Evento
                    {
                        Folio = varDetalle_Actividades_Evento.Folio
                        ,Tipo_de_Actividad = varDetalle_Actividades_Evento.Tipo_de_Actividad
                        ,Especialidad = varDetalle_Actividades_Evento.Especialidad
                        ,Nombre_de_la_Actividad = varDetalle_Actividades_Evento.Nombre_de_la_Actividad
                        ,Descripcion = varDetalle_Actividades_Evento.Descripcion
                        ,Quien_imparte = varDetalle_Actividades_Evento.Quien_imparte
                        ,Dia = (!String.IsNullOrEmpty(varDetalle_Actividades_Evento.Dia)) ? DateTime.ParseExact(varDetalle_Actividades_Evento.Dia, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_inicio = varDetalle_Actividades_Evento.Hora_inicio
                        ,Hora_fin = varDetalle_Actividades_Evento.Hora_fin
                        ,Tiene_receso = varDetalle_Actividades_Evento.Tiene_receso
                        ,Hora_inicio_receso = varDetalle_Actividades_Evento.Hora_inicio_receso
                        ,Hora_fin_receso = varDetalle_Actividades_Evento.Hora_fin_receso
                        ,Duracion_maxima_por_paciente_mins = varDetalle_Actividades_Evento.Duracion_maxima_por_paciente_mins
                        ,Cupo_limitado = varDetalle_Actividades_Evento.Cupo_limitado
                        ,Cupo_maximo = varDetalle_Actividades_Evento.Cupo_maximo
                        ,Ubicacion = varDetalle_Actividades_Evento.Ubicacion
                        ,Estatus_de_la_Actividad = varDetalle_Actividades_Evento.Estatus_de_la_Actividad

                    };

                    result = !IsNew ?
                        _IDetalle_Actividades_EventoApiConsumer.Update(Detalle_Actividades_EventoInfo, null, null).Resource.ToString() :
                         _IDetalle_Actividades_EventoApiConsumer.Insert(Detalle_Actividades_EventoInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Actividades_Evento script
        /// </summary>
        /// <param name="oDetalle_Actividades_EventoElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Actividades_EventoModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Actividades_EventoModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Actividades_EventoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Actividades_EventoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Actividades_EventoModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Actividades_EventoModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Actividades_EventoModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Actividades_EventoModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Actividades_EventoModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Actividades_EventoModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Actividades_EventoModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Actividades_EventoModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Actividades_EventoScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Actividades_Evento.js")))
            {
                strDetalle_Actividades_EventoScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Actividades_Evento element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Actividades_EventoModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Actividades_EventoScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Actividades_EventoScript.Substring(indexOfArray, strDetalle_Actividades_EventoScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Actividades_EventoModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Actividades_EventoModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Actividades_EventoScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Actividades_EventoScript.Substring(indexOfArrayHistory, strDetalle_Actividades_EventoScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Actividades_EventoScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Actividades_EventoScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Actividades_EventoScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Actividades_EventoModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Actividades_EventoScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Actividades_EventoScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Actividades_EventoScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Actividades_EventoScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Actividades_Evento.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Actividades_Evento.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Actividades_Evento.js")))
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
        public ActionResult Detalle_Actividades_EventoPropertyBag()
        {
            return PartialView("Detalle_Actividades_EventoPropertyBag", "Detalle_Actividades_Evento");
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

            _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Actividades_EventoPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Actividades_EventoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Actividades_Eventos == null)
                result.Detalle_Actividades_Eventos = new List<Detalle_Actividades_Evento>();

            var data = result.Detalle_Actividades_Eventos.Select(m => new Detalle_Actividades_EventoGridModel
            {
                Folio = m.Folio
                ,Tipo_de_ActividadDescripcion = (string)m.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                ,EspecialidadEspecialidad = (string)m.Especialidad_Especialidades.Especialidad
                ,Nombre_de_la_Actividad = m.Nombre_de_la_Actividad
                ,Descripcion = m.Descripcion
                ,Quien_imparteName = (string)m.Quien_imparte_Spartan_User.Name
                ,Dia = (m.Dia == null ? string.Empty : Convert.ToDateTime(m.Dia).ToString(ConfigurationProperty.DateFormat))
                ,Hora_inicio = m.Hora_inicio
                ,Hora_fin = m.Hora_fin
                ,Tiene_receso = m.Tiene_receso
                ,Hora_inicio_receso = m.Hora_inicio_receso
                ,Hora_fin_receso = m.Hora_fin_receso
                ,Duracion_maxima_por_paciente_mins = m.Duracion_maxima_por_paciente_mins
                ,Cupo_limitado = m.Cupo_limitado
                ,Cupo_maximo = m.Cupo_maximo
                ,UbicacionNombre = (string)m.Ubicacion_Ubicaciones_Eventos_Empresa.Nombre
                ,Estatus_de_la_ActividadDescripcion = (string)m.Estatus_de_la_Actividad_Estatus_Actividades_Evento.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Actividades_EventoList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Actividades_EventoList_" + DateTime.Now.ToString());
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

            _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Actividades_EventoPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Actividades_EventoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Actividades_Eventos == null)
                result.Detalle_Actividades_Eventos = new List<Detalle_Actividades_Evento>();

            var data = result.Detalle_Actividades_Eventos.Select(m => new Detalle_Actividades_EventoGridModel
            {
                Folio = m.Folio
                ,Tipo_de_ActividadDescripcion = (string)m.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                ,EspecialidadEspecialidad = (string)m.Especialidad_Especialidades.Especialidad
                ,Nombre_de_la_Actividad = m.Nombre_de_la_Actividad
                ,Descripcion = m.Descripcion
                ,Quien_imparteName = (string)m.Quien_imparte_Spartan_User.Name
                ,Dia = (m.Dia == null ? string.Empty : Convert.ToDateTime(m.Dia).ToString(ConfigurationProperty.DateFormat))
                ,Hora_inicio = m.Hora_inicio
                ,Hora_fin = m.Hora_fin
                ,Tiene_receso = m.Tiene_receso
                ,Hora_inicio_receso = m.Hora_inicio_receso
                ,Hora_fin_receso = m.Hora_fin_receso
                ,Duracion_maxima_por_paciente_mins = m.Duracion_maxima_por_paciente_mins
                ,Cupo_limitado = m.Cupo_limitado
                ,Cupo_maximo = m.Cupo_maximo
                ,UbicacionNombre = (string)m.Ubicacion_Ubicaciones_Eventos_Empresa.Nombre
                ,Estatus_de_la_ActividadDescripcion = (string)m.Estatus_de_la_Actividad_Estatus_Actividades_Evento.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
