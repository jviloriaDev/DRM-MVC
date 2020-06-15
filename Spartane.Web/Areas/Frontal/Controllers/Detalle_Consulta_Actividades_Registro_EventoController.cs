using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Consulta_Actividades_Registro_Evento;
using Spartane.Core.Domain.Detalle_Actividades_Evento;
using Spartane.Core.Domain.Tipos_de_Actividades;
using Spartane.Core.Domain.Especialidades;
using Spartane.Core.Domain.Spartan_User;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Consulta_Actividades_Registro_Evento;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Consulta_Actividades_Registro_Evento;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Actividades_Evento;
using Spartane.Web.Areas.WebApiConsumer.Tipos_de_Actividades;
using Spartane.Web.Areas.WebApiConsumer.Especialidades;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;

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
    public class Detalle_Consulta_Actividades_Registro_EventoController : Controller
    {
        #region "variable declaration"

        private IDetalle_Consulta_Actividades_Registro_EventoService service = null;
        private IDetalle_Consulta_Actividades_Registro_EventoApiConsumer _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer;
        private IDetalle_Actividades_EventoApiConsumer _IDetalle_Actividades_EventoApiConsumer;
        private ITipos_de_ActividadesApiConsumer _ITipos_de_ActividadesApiConsumer;
        private IEspecialidadesApiConsumer _IEspecialidadesApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Consulta_Actividades_Registro_EventoController(IDetalle_Consulta_Actividades_Registro_EventoService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Consulta_Actividades_Registro_EventoApiConsumer Detalle_Consulta_Actividades_Registro_EventoApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IDetalle_Actividades_EventoApiConsumer Detalle_Actividades_EventoApiConsumer , ITipos_de_ActividadesApiConsumer Tipos_de_ActividadesApiConsumer , IEspecialidadesApiConsumer EspecialidadesApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Consulta_Actividades_Registro_EventoApiConsumer = Detalle_Consulta_Actividades_Registro_EventoApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IDetalle_Actividades_EventoApiConsumer = Detalle_Actividades_EventoApiConsumer;
            this._ITipos_de_ActividadesApiConsumer = Tipos_de_ActividadesApiConsumer;
            this._IEspecialidadesApiConsumer = EspecialidadesApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Consulta_Actividades_Registro_Evento
        [ObjectAuth(ObjectId = (ModuleObjectId)44440, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44440);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Consulta_Actividades_Registro_Evento/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44440, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44440);
            ViewBag.Permission = permission;
            var varDetalle_Consulta_Actividades_Registro_Evento = new Detalle_Consulta_Actividades_Registro_EventoModel();
			
            ViewBag.ObjectId = "44440";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Consulta_Actividades_Registro_EventoData = _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Consulta_Actividades_Registro_Eventos[0];
                if (Detalle_Consulta_Actividades_Registro_EventoData == null)
                    return HttpNotFound();

                varDetalle_Consulta_Actividades_Registro_Evento = new Detalle_Consulta_Actividades_Registro_EventoModel
                {
                    Folio = (int)Detalle_Consulta_Actividades_Registro_EventoData.Folio
                    ,Actividad = Detalle_Consulta_Actividades_Registro_EventoData.Actividad
                    ,ActividadNombre_de_la_Actividad = CultureHelper.GetTraduction(Convert.ToString(Detalle_Consulta_Actividades_Registro_EventoData.Actividad), "Detalle_Actividades_Evento") ??  (string)Detalle_Consulta_Actividades_Registro_EventoData.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
                    ,Tipo_de_Actividad = Detalle_Consulta_Actividades_Registro_EventoData.Tipo_de_Actividad
                    ,Tipo_de_ActividadDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Consulta_Actividades_Registro_EventoData.Tipo_de_Actividad), "Tipos_de_Actividades") ??  (string)Detalle_Consulta_Actividades_Registro_EventoData.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                    ,Especialidad = Detalle_Consulta_Actividades_Registro_EventoData.Especialidad
                    ,EspecialidadEspecialidad = CultureHelper.GetTraduction(Convert.ToString(Detalle_Consulta_Actividades_Registro_EventoData.Especialidad), "Especialidades") ??  (string)Detalle_Consulta_Actividades_Registro_EventoData.Especialidad_Especialidades.Especialidad
                    ,Imparte = Detalle_Consulta_Actividades_Registro_EventoData.Imparte
                    ,ImparteName = CultureHelper.GetTraduction(Convert.ToString(Detalle_Consulta_Actividades_Registro_EventoData.Imparte), "Spartan_User") ??  (string)Detalle_Consulta_Actividades_Registro_EventoData.Imparte_Spartan_User.Name
                    ,Fecha = (Detalle_Consulta_Actividades_Registro_EventoData.Fecha == null ? string.Empty : Convert.ToDateTime(Detalle_Consulta_Actividades_Registro_EventoData.Fecha).ToString(ConfigurationProperty.DateFormat))
                    ,Lugares_disponibles = Detalle_Consulta_Actividades_Registro_EventoData.Lugares_disponibles
                    ,Horarios_disponibles = Detalle_Consulta_Actividades_Registro_EventoData.Horarios_disponibles
                    ,Ubicacion = Detalle_Consulta_Actividades_Registro_EventoData.Ubicacion

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
            var Spartan_Users_Imparte = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Imparte != null && Spartan_Users_Imparte.Resource != null)
                ViewBag.Spartan_Users_Imparte = Spartan_Users_Imparte.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Consulta_Actividades_Registro_Evento);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Consulta_Actividades_Registro_Evento(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44440);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Consulta_Actividades_Registro_EventoModel varDetalle_Consulta_Actividades_Registro_Evento= new Detalle_Consulta_Actividades_Registro_EventoModel();


            if (id.ToString() != "0")
            {
                var Detalle_Consulta_Actividades_Registro_EventosData = _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.ListaSelAll(0, 1000, "Detalle_Consulta_Actividades_Registro_Evento.Folio=" + id, "").Resource.Detalle_Consulta_Actividades_Registro_Eventos;
				
				if (Detalle_Consulta_Actividades_Registro_EventosData != null && Detalle_Consulta_Actividades_Registro_EventosData.Count > 0)
                {
					var Detalle_Consulta_Actividades_Registro_EventoData = Detalle_Consulta_Actividades_Registro_EventosData.First();
					varDetalle_Consulta_Actividades_Registro_Evento= new Detalle_Consulta_Actividades_Registro_EventoModel
					{
						Folio  = Detalle_Consulta_Actividades_Registro_EventoData.Folio 
	                    ,Actividad = Detalle_Consulta_Actividades_Registro_EventoData.Actividad
                    ,ActividadNombre_de_la_Actividad = CultureHelper.GetTraduction(Convert.ToString(Detalle_Consulta_Actividades_Registro_EventoData.Actividad), "Detalle_Actividades_Evento") ??  (string)Detalle_Consulta_Actividades_Registro_EventoData.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
                    ,Tipo_de_Actividad = Detalle_Consulta_Actividades_Registro_EventoData.Tipo_de_Actividad
                    ,Tipo_de_ActividadDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Consulta_Actividades_Registro_EventoData.Tipo_de_Actividad), "Tipos_de_Actividades") ??  (string)Detalle_Consulta_Actividades_Registro_EventoData.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                    ,Especialidad = Detalle_Consulta_Actividades_Registro_EventoData.Especialidad
                    ,EspecialidadEspecialidad = CultureHelper.GetTraduction(Convert.ToString(Detalle_Consulta_Actividades_Registro_EventoData.Especialidad), "Especialidades") ??  (string)Detalle_Consulta_Actividades_Registro_EventoData.Especialidad_Especialidades.Especialidad
                    ,Imparte = Detalle_Consulta_Actividades_Registro_EventoData.Imparte
                    ,ImparteName = CultureHelper.GetTraduction(Convert.ToString(Detalle_Consulta_Actividades_Registro_EventoData.Imparte), "Spartan_User") ??  (string)Detalle_Consulta_Actividades_Registro_EventoData.Imparte_Spartan_User.Name
                    ,Fecha = (Detalle_Consulta_Actividades_Registro_EventoData.Fecha == null ? string.Empty : Convert.ToDateTime(Detalle_Consulta_Actividades_Registro_EventoData.Fecha).ToString(ConfigurationProperty.DateFormat))
                    ,Lugares_disponibles = Detalle_Consulta_Actividades_Registro_EventoData.Lugares_disponibles
                    ,Horarios_disponibles = Detalle_Consulta_Actividades_Registro_EventoData.Horarios_disponibles
                    ,Ubicacion = Detalle_Consulta_Actividades_Registro_EventoData.Ubicacion

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
            var Spartan_Users_Imparte = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Imparte != null && Spartan_Users_Imparte.Resource != null)
                ViewBag.Spartan_Users_Imparte = Spartan_Users_Imparte.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();


            return PartialView("AddDetalle_Consulta_Actividades_Registro_Evento", varDetalle_Consulta_Actividades_Registro_Evento);
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



        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Consulta_Actividades_Registro_EventoPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Consulta_Actividades_Registro_Eventos == null)
                result.Detalle_Consulta_Actividades_Registro_Eventos = new List<Detalle_Consulta_Actividades_Registro_Evento>();

            return Json(new
            {
                data = result.Detalle_Consulta_Actividades_Registro_Eventos.Select(m => new Detalle_Consulta_Actividades_Registro_EventoGridModel
                    {
                    Folio = m.Folio
                        ,ActividadNombre_de_la_Actividad = CultureHelper.GetTraduction(m.Actividad_Detalle_Actividades_Evento.Folio.ToString(), "Nombre_de_la_Actividad") ?? (string)m.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
                        ,Tipo_de_ActividadDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Actividad_Tipos_de_Actividades.Folio.ToString(), "Descripcion") ?? (string)m.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ?? (string)m.Especialidad_Especialidades.Especialidad
                        ,ImparteName = CultureHelper.GetTraduction(m.Imparte_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Imparte_Spartan_User.Name
                        ,Fecha = (m.Fecha == null ? string.Empty : Convert.ToDateTime(m.Fecha).ToString(ConfigurationProperty.DateFormat))
			,Lugares_disponibles = m.Lugares_disponibles
			,Horarios_disponibles = m.Horarios_disponibles
			,Ubicacion = m.Ubicacion

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
                _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Consulta_Actividades_Registro_Evento varDetalle_Consulta_Actividades_Registro_Evento = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Consulta_Actividades_Registro_EventoModel varDetalle_Consulta_Actividades_Registro_Evento)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Consulta_Actividades_Registro_EventoInfo = new Detalle_Consulta_Actividades_Registro_Evento
                    {
                        Folio = varDetalle_Consulta_Actividades_Registro_Evento.Folio
                        ,Actividad = varDetalle_Consulta_Actividades_Registro_Evento.Actividad
                        ,Tipo_de_Actividad = varDetalle_Consulta_Actividades_Registro_Evento.Tipo_de_Actividad
                        ,Especialidad = varDetalle_Consulta_Actividades_Registro_Evento.Especialidad
                        ,Imparte = varDetalle_Consulta_Actividades_Registro_Evento.Imparte
                        ,Fecha = (!String.IsNullOrEmpty(varDetalle_Consulta_Actividades_Registro_Evento.Fecha)) ? DateTime.ParseExact(varDetalle_Consulta_Actividades_Registro_Evento.Fecha, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Lugares_disponibles = varDetalle_Consulta_Actividades_Registro_Evento.Lugares_disponibles
                        ,Horarios_disponibles = varDetalle_Consulta_Actividades_Registro_Evento.Horarios_disponibles
                        ,Ubicacion = varDetalle_Consulta_Actividades_Registro_Evento.Ubicacion

                    };

                    result = !IsNew ?
                        _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.Update(Detalle_Consulta_Actividades_Registro_EventoInfo, null, null).Resource.ToString() :
                         _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.Insert(Detalle_Consulta_Actividades_Registro_EventoInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Consulta_Actividades_Registro_Evento script
        /// </summary>
        /// <param name="oDetalle_Consulta_Actividades_Registro_EventoElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Consulta_Actividades_Registro_EventoModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Consulta_Actividades_Registro_EventoModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Consulta_Actividades_Registro_EventoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Consulta_Actividades_Registro_EventoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Consulta_Actividades_Registro_EventoModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Consulta_Actividades_Registro_EventoModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Consulta_Actividades_Registro_EventoModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Consulta_Actividades_Registro_EventoModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Consulta_Actividades_Registro_EventoModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Consulta_Actividades_Registro_EventoModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Consulta_Actividades_Registro_EventoModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Consulta_Actividades_Registro_EventoModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Consulta_Actividades_Registro_EventoScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Consulta_Actividades_Registro_Evento.js")))
            {
                strDetalle_Consulta_Actividades_Registro_EventoScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Consulta_Actividades_Registro_Evento element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Consulta_Actividades_Registro_EventoModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Consulta_Actividades_Registro_EventoScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Consulta_Actividades_Registro_EventoScript.Substring(indexOfArray, strDetalle_Consulta_Actividades_Registro_EventoScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Consulta_Actividades_Registro_EventoModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Consulta_Actividades_Registro_EventoModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Consulta_Actividades_Registro_EventoScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Consulta_Actividades_Registro_EventoScript.Substring(indexOfArrayHistory, strDetalle_Consulta_Actividades_Registro_EventoScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Consulta_Actividades_Registro_EventoScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Consulta_Actividades_Registro_EventoScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Consulta_Actividades_Registro_EventoScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Consulta_Actividades_Registro_EventoModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Consulta_Actividades_Registro_EventoScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Consulta_Actividades_Registro_EventoScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Consulta_Actividades_Registro_EventoScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Consulta_Actividades_Registro_EventoScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Consulta_Actividades_Registro_Evento.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Consulta_Actividades_Registro_Evento.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Consulta_Actividades_Registro_Evento.js")))
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
        public ActionResult Detalle_Consulta_Actividades_Registro_EventoPropertyBag()
        {
            return PartialView("Detalle_Consulta_Actividades_Registro_EventoPropertyBag", "Detalle_Consulta_Actividades_Registro_Evento");
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

            _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Consulta_Actividades_Registro_EventoPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Consulta_Actividades_Registro_Eventos == null)
                result.Detalle_Consulta_Actividades_Registro_Eventos = new List<Detalle_Consulta_Actividades_Registro_Evento>();

            var data = result.Detalle_Consulta_Actividades_Registro_Eventos.Select(m => new Detalle_Consulta_Actividades_Registro_EventoGridModel
            {
                Folio = m.Folio
                ,ActividadNombre_de_la_Actividad = (string)m.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
                ,Tipo_de_ActividadDescripcion = (string)m.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                ,EspecialidadEspecialidad = (string)m.Especialidad_Especialidades.Especialidad
                ,ImparteName = (string)m.Imparte_Spartan_User.Name
                ,Fecha = (m.Fecha == null ? string.Empty : Convert.ToDateTime(m.Fecha).ToString(ConfigurationProperty.DateFormat))
                ,Lugares_disponibles = m.Lugares_disponibles
                ,Horarios_disponibles = m.Horarios_disponibles
                ,Ubicacion = m.Ubicacion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Consulta_Actividades_Registro_EventoList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Consulta_Actividades_Registro_EventoList_" + DateTime.Now.ToString());
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

            _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Consulta_Actividades_Registro_EventoPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Consulta_Actividades_Registro_EventoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Consulta_Actividades_Registro_Eventos == null)
                result.Detalle_Consulta_Actividades_Registro_Eventos = new List<Detalle_Consulta_Actividades_Registro_Evento>();

            var data = result.Detalle_Consulta_Actividades_Registro_Eventos.Select(m => new Detalle_Consulta_Actividades_Registro_EventoGridModel
            {
                Folio = m.Folio
                ,ActividadNombre_de_la_Actividad = (string)m.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
                ,Tipo_de_ActividadDescripcion = (string)m.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                ,EspecialidadEspecialidad = (string)m.Especialidad_Especialidades.Especialidad
                ,ImparteName = (string)m.Imparte_Spartan_User.Name
                ,Fecha = (m.Fecha == null ? string.Empty : Convert.ToDateTime(m.Fecha).ToString(ConfigurationProperty.DateFormat))
                ,Lugares_disponibles = m.Lugares_disponibles
                ,Horarios_disponibles = m.Horarios_disponibles
                ,Ubicacion = m.Ubicacion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
