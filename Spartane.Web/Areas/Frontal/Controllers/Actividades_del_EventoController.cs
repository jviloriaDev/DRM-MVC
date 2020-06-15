using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Actividades_del_Evento;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Eventos;
using Spartane.Core.Domain.Detalle_Actividades_Evento;
using Spartane.Core.Domain.Ubicaciones_Eventos_Empresa;
using Spartane.Core.Domain.Tipos_de_Actividades;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Especialidades;
using Spartane.Core.Domain.Estatus_Actividades_Evento;
using Spartane.Core.Domain.Detalle_Horarios_Actividad;






using Spartane.Core.Domain.Detalle_Registro_en_Actividad_Evento;



using Spartane.Core.Domain.Parentescos_Empleados;
using Spartane.Core.Domain.Sexo;

using Spartane.Core.Domain.Estatus_Reservaciones_Actividad;



using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Actividades_del_Evento;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Actividades_del_Evento;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Eventos;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Actividades_Evento;
using Spartane.Web.Areas.WebApiConsumer.Ubicaciones_Eventos_Empresa;
using Spartane.Web.Areas.WebApiConsumer.Tipos_de_Actividades;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Especialidades;
using Spartane.Web.Areas.WebApiConsumer.Estatus_Actividades_Evento;
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
    public class Actividades_del_EventoController : Controller
    {
        #region "variable declaration"

        private IActividades_del_EventoService service = null;
        private IActividades_del_EventoApiConsumer _IActividades_del_EventoApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IEventosApiConsumer _IEventosApiConsumer;
        private IDetalle_Actividades_EventoApiConsumer _IDetalle_Actividades_EventoApiConsumer;
        private IUbicaciones_Eventos_EmpresaApiConsumer _IUbicaciones_Eventos_EmpresaApiConsumer;
        private ITipos_de_ActividadesApiConsumer _ITipos_de_ActividadesApiConsumer;
        private IEspecialidadesApiConsumer _IEspecialidadesApiConsumer;
        private IEstatus_Actividades_EventoApiConsumer _IEstatus_Actividades_EventoApiConsumer;
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
        private IGeneratePDFApiConsumer _IGeneratePDFApiConsumer;
        private ISpartan_FormatApiConsumer _ISpartan_FormatApiConsumer;
        private ISpartan_Format_PermissionsApiConsumer _ISpartan_Format_PermissionsApiConsumer;
		private ISpartan_Format_RelatedApiConsumer _ISpartan_FormatRelatedApiConsumer;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Actividades_del_EventoController(IActividades_del_EventoService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IActividades_del_EventoApiConsumer Actividades_del_EventoApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IEventosApiConsumer EventosApiConsumer , IDetalle_Actividades_EventoApiConsumer Detalle_Actividades_EventoApiConsumer , IUbicaciones_Eventos_EmpresaApiConsumer Ubicaciones_Eventos_EmpresaApiConsumer , ITipos_de_ActividadesApiConsumer Tipos_de_ActividadesApiConsumer , IEspecialidadesApiConsumer EspecialidadesApiConsumer , IEstatus_Actividades_EventoApiConsumer Estatus_Actividades_EventoApiConsumer , IDetalle_Horarios_ActividadApiConsumer Detalle_Horarios_ActividadApiConsumer , IDetalle_Registro_en_Actividad_EventoApiConsumer Detalle_Registro_en_Actividad_EventoApiConsumer , IParentescos_EmpleadosApiConsumer Parentescos_EmpleadosApiConsumer , ISexoApiConsumer SexoApiConsumer , IEstatus_Reservaciones_ActividadApiConsumer Estatus_Reservaciones_ActividadApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IActividades_del_EventoApiConsumer = Actividades_del_EventoApiConsumer;
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
            this._IDetalle_Actividades_EventoApiConsumer = Detalle_Actividades_EventoApiConsumer;
            this._IUbicaciones_Eventos_EmpresaApiConsumer = Ubicaciones_Eventos_EmpresaApiConsumer;
            this._ITipos_de_ActividadesApiConsumer = Tipos_de_ActividadesApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._IEspecialidadesApiConsumer = EspecialidadesApiConsumer;
            this._IEstatus_Actividades_EventoApiConsumer = Estatus_Actividades_EventoApiConsumer;
            this._IDetalle_Horarios_ActividadApiConsumer = Detalle_Horarios_ActividadApiConsumer;




            this._IDetalle_Registro_en_Actividad_EventoApiConsumer = Detalle_Registro_en_Actividad_EventoApiConsumer;

            this._IParentescos_EmpleadosApiConsumer = Parentescos_EmpleadosApiConsumer;
            this._ISexoApiConsumer = SexoApiConsumer;
            this._IEstatus_Reservaciones_ActividadApiConsumer = Estatus_Reservaciones_ActividadApiConsumer;



        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Actividades_del_Evento
        [ObjectAuth(ObjectId = (ModuleObjectId)44436, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44436, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Actividades_del_Evento/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44436, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44436, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varActividades_del_Evento = new Actividades_del_EventoModel();
			varActividades_del_Evento.Folio = Id;
			
            ViewBag.ObjectId = "44436";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionDetalle_Horarios_Actividad = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44437, ModuleId);
            ViewBag.PermissionDetalle_Horarios_Actividad = permissionDetalle_Horarios_Actividad;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IActividades_del_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Actividades_del_EventosData = _IActividades_del_EventoApiConsumer.ListaSelAll(0, 1000, "Actividades_del_Evento.Folio=" + Id, "").Resource.Actividades_del_Eventos;
				
				if (Actividades_del_EventosData != null && Actividades_del_EventosData.Count > 0)
                {
					var Actividades_del_EventoData = Actividades_del_EventosData.First();
					varActividades_del_Evento= new Actividades_del_EventoModel
					{
						Folio  = Actividades_del_EventoData.Folio 
	                    ,Fecha_de_Registro = (Actividades_del_EventoData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Actividades_del_EventoData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Actividades_del_EventoData.Hora_de_Registro
                    ,Usuario_que_Registra = Actividades_del_EventoData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Actividades_del_EventoData.Usuario_que_Registra), "Spartan_User") ??  (string)Actividades_del_EventoData.Usuario_que_Registra_Spartan_User.Name
                    ,Evento = Actividades_del_EventoData.Evento
                    ,EventoNombre_del_Evento = CultureHelper.GetTraduction(Convert.ToString(Actividades_del_EventoData.Evento), "Eventos") ??  (string)Actividades_del_EventoData.Evento_Eventos.Nombre_del_Evento
                    ,Actividad = Actividades_del_EventoData.Actividad
                    ,ActividadNombre_de_la_Actividad = CultureHelper.GetTraduction(Convert.ToString(Actividades_del_EventoData.Actividad), "Detalle_Actividades_Evento") ??  (string)Actividades_del_EventoData.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
                    ,Descripcion = Actividades_del_EventoData.Descripcion
                    ,Dia = (Actividades_del_EventoData.Dia == null ? string.Empty : Convert.ToDateTime(Actividades_del_EventoData.Dia).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_inicio = Actividades_del_EventoData.Hora_inicio
                    ,Hora_fin = Actividades_del_EventoData.Hora_fin
                    ,Tiene_receso = Actividades_del_EventoData.Tiene_receso.GetValueOrDefault()
                    ,Hora_inicio_receso = Actividades_del_EventoData.Hora_inicio_receso
                    ,Hora_fin_receso = Actividades_del_EventoData.Hora_fin_receso
                    ,Ubicacion = Actividades_del_EventoData.Ubicacion
                    ,UbicacionNombre = CultureHelper.GetTraduction(Convert.ToString(Actividades_del_EventoData.Ubicacion), "Ubicaciones_Eventos_Empresa") ??  (string)Actividades_del_EventoData.Ubicacion_Ubicaciones_Eventos_Empresa.Nombre
                    ,Tipo_de_Actividad = Actividades_del_EventoData.Tipo_de_Actividad
                    ,Tipo_de_ActividadDescripcion = CultureHelper.GetTraduction(Convert.ToString(Actividades_del_EventoData.Tipo_de_Actividad), "Tipos_de_Actividades") ??  (string)Actividades_del_EventoData.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                    ,Quien_imparte = Actividades_del_EventoData.Quien_imparte
                    ,Quien_imparteName = CultureHelper.GetTraduction(Convert.ToString(Actividades_del_EventoData.Quien_imparte), "Spartan_User") ??  (string)Actividades_del_EventoData.Quien_imparte_Spartan_User.Name
                    ,Especialidad = Actividades_del_EventoData.Especialidad
                    ,EspecialidadEspecialidad = CultureHelper.GetTraduction(Convert.ToString(Actividades_del_EventoData.Especialidad), "Especialidades") ??  (string)Actividades_del_EventoData.Especialidad_Especialidades.Especialidad
                    ,Cupo_limitado = Actividades_del_EventoData.Cupo_limitado.GetValueOrDefault()
                    ,Cupo_maximo = Actividades_del_EventoData.Cupo_maximo
                    ,Duracion_maxima_por_Paciente_mins = Actividades_del_EventoData.Duracion_maxima_por_Paciente_mins
                    ,Estatus = Actividades_del_EventoData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Actividades_del_EventoData.Estatus), "Estatus_Actividades_Evento") ??  (string)Actividades_del_EventoData.Estatus_Estatus_Actividades_Evento.Descripcion

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
            _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Detalle_Actividades_Eventos_Actividad = _IDetalle_Actividades_EventoApiConsumer.SelAll(true);
            if (Detalle_Actividades_Eventos_Actividad != null && Detalle_Actividades_Eventos_Actividad.Resource != null)
                ViewBag.Detalle_Actividades_Eventos_Actividad = Detalle_Actividades_Eventos_Actividad.Resource.Where(m => m.Nombre_de_la_Actividad != null).OrderBy(m => m.Nombre_de_la_Actividad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Detalle_Actividades_Evento", "Nombre_de_la_Actividad") ?? m.Nombre_de_la_Actividad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Ubicaciones_Eventos_Empresas_Ubicacion = _IUbicaciones_Eventos_EmpresaApiConsumer.SelAll(true);
            if (Ubicaciones_Eventos_Empresas_Ubicacion != null && Ubicaciones_Eventos_Empresas_Ubicacion.Resource != null)
                ViewBag.Ubicaciones_Eventos_Empresas_Ubicacion = Ubicaciones_Eventos_Empresas_Ubicacion.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Ubicaciones_Eventos_Empresa", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ITipos_de_ActividadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipos_de_Actividadess_Tipo_de_Actividad = _ITipos_de_ActividadesApiConsumer.SelAll(true);
            if (Tipos_de_Actividadess_Tipo_de_Actividad != null && Tipos_de_Actividadess_Tipo_de_Actividad.Resource != null)
                ViewBag.Tipos_de_Actividadess_Tipo_de_Actividad = Tipos_de_Actividadess_Tipo_de_Actividad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipos_de_Actividades", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Quien_imparte = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Quien_imparte != null && Spartan_Users_Quien_imparte.Resource != null)
                ViewBag.Spartan_Users_Quien_imparte = Spartan_Users_Quien_imparte.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Especialidadess_Especialidad = _IEspecialidadesApiConsumer.SelAll(true);
            if (Especialidadess_Especialidad != null && Especialidadess_Especialidad.Resource != null)
                ViewBag.Especialidadess_Especialidad = Especialidadess_Especialidad.Resource.Where(m => m.Especialidad != null).OrderBy(m => m.Especialidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Especialidades", "Especialidad") ?? m.Especialidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Actividades_Eventos_Estatus = _IEstatus_Actividades_EventoApiConsumer.SelAll(true);
            if (Estatus_Actividades_Eventos_Estatus != null && Estatus_Actividades_Eventos_Estatus.Resource != null)
                ViewBag.Estatus_Actividades_Eventos_Estatus = Estatus_Actividades_Eventos_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_Actividades_Evento", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
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

				
            return View(varActividades_del_Evento);
        }
		
	[HttpGet]
        public ActionResult AddActividades_del_Evento(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44436);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IActividades_del_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
			Actividades_del_EventoModel varActividades_del_Evento= new Actividades_del_EventoModel();
            var permissionDetalle_Horarios_Actividad = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44437, ModuleId);
            ViewBag.PermissionDetalle_Horarios_Actividad = permissionDetalle_Horarios_Actividad;


            if (id.ToString() != "0")
            {
                var Actividades_del_EventosData = _IActividades_del_EventoApiConsumer.ListaSelAll(0, 1000, "Actividades_del_Evento.Folio=" + id, "").Resource.Actividades_del_Eventos;
				
				if (Actividades_del_EventosData != null && Actividades_del_EventosData.Count > 0)
                {
					var Actividades_del_EventoData = Actividades_del_EventosData.First();
					varActividades_del_Evento= new Actividades_del_EventoModel
					{
						Folio  = Actividades_del_EventoData.Folio 
	                    ,Fecha_de_Registro = (Actividades_del_EventoData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Actividades_del_EventoData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Actividades_del_EventoData.Hora_de_Registro
                    ,Usuario_que_Registra = Actividades_del_EventoData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Actividades_del_EventoData.Usuario_que_Registra), "Spartan_User") ??  (string)Actividades_del_EventoData.Usuario_que_Registra_Spartan_User.Name
                    ,Evento = Actividades_del_EventoData.Evento
                    ,EventoNombre_del_Evento = CultureHelper.GetTraduction(Convert.ToString(Actividades_del_EventoData.Evento), "Eventos") ??  (string)Actividades_del_EventoData.Evento_Eventos.Nombre_del_Evento
                    ,Actividad = Actividades_del_EventoData.Actividad
                    ,ActividadNombre_de_la_Actividad = CultureHelper.GetTraduction(Convert.ToString(Actividades_del_EventoData.Actividad), "Detalle_Actividades_Evento") ??  (string)Actividades_del_EventoData.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
                    ,Descripcion = Actividades_del_EventoData.Descripcion
                    ,Dia = (Actividades_del_EventoData.Dia == null ? string.Empty : Convert.ToDateTime(Actividades_del_EventoData.Dia).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_inicio = Actividades_del_EventoData.Hora_inicio
                    ,Hora_fin = Actividades_del_EventoData.Hora_fin
                    ,Tiene_receso = Actividades_del_EventoData.Tiene_receso.GetValueOrDefault()
                    ,Hora_inicio_receso = Actividades_del_EventoData.Hora_inicio_receso
                    ,Hora_fin_receso = Actividades_del_EventoData.Hora_fin_receso
                    ,Ubicacion = Actividades_del_EventoData.Ubicacion
                    ,UbicacionNombre = CultureHelper.GetTraduction(Convert.ToString(Actividades_del_EventoData.Ubicacion), "Ubicaciones_Eventos_Empresa") ??  (string)Actividades_del_EventoData.Ubicacion_Ubicaciones_Eventos_Empresa.Nombre
                    ,Tipo_de_Actividad = Actividades_del_EventoData.Tipo_de_Actividad
                    ,Tipo_de_ActividadDescripcion = CultureHelper.GetTraduction(Convert.ToString(Actividades_del_EventoData.Tipo_de_Actividad), "Tipos_de_Actividades") ??  (string)Actividades_del_EventoData.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                    ,Quien_imparte = Actividades_del_EventoData.Quien_imparte
                    ,Quien_imparteName = CultureHelper.GetTraduction(Convert.ToString(Actividades_del_EventoData.Quien_imparte), "Spartan_User") ??  (string)Actividades_del_EventoData.Quien_imparte_Spartan_User.Name
                    ,Especialidad = Actividades_del_EventoData.Especialidad
                    ,EspecialidadEspecialidad = CultureHelper.GetTraduction(Convert.ToString(Actividades_del_EventoData.Especialidad), "Especialidades") ??  (string)Actividades_del_EventoData.Especialidad_Especialidades.Especialidad
                    ,Cupo_limitado = Actividades_del_EventoData.Cupo_limitado.GetValueOrDefault()
                    ,Cupo_maximo = Actividades_del_EventoData.Cupo_maximo
                    ,Duracion_maxima_por_Paciente_mins = Actividades_del_EventoData.Duracion_maxima_por_Paciente_mins
                    ,Estatus = Actividades_del_EventoData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Actividades_del_EventoData.Estatus), "Estatus_Actividades_Evento") ??  (string)Actividades_del_EventoData.Estatus_Estatus_Actividades_Evento.Descripcion

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
            _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Detalle_Actividades_Eventos_Actividad = _IDetalle_Actividades_EventoApiConsumer.SelAll(true);
            if (Detalle_Actividades_Eventos_Actividad != null && Detalle_Actividades_Eventos_Actividad.Resource != null)
                ViewBag.Detalle_Actividades_Eventos_Actividad = Detalle_Actividades_Eventos_Actividad.Resource.Where(m => m.Nombre_de_la_Actividad != null).OrderBy(m => m.Nombre_de_la_Actividad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Detalle_Actividades_Evento", "Nombre_de_la_Actividad") ?? m.Nombre_de_la_Actividad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Ubicaciones_Eventos_Empresas_Ubicacion = _IUbicaciones_Eventos_EmpresaApiConsumer.SelAll(true);
            if (Ubicaciones_Eventos_Empresas_Ubicacion != null && Ubicaciones_Eventos_Empresas_Ubicacion.Resource != null)
                ViewBag.Ubicaciones_Eventos_Empresas_Ubicacion = Ubicaciones_Eventos_Empresas_Ubicacion.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Ubicaciones_Eventos_Empresa", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ITipos_de_ActividadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipos_de_Actividadess_Tipo_de_Actividad = _ITipos_de_ActividadesApiConsumer.SelAll(true);
            if (Tipos_de_Actividadess_Tipo_de_Actividad != null && Tipos_de_Actividadess_Tipo_de_Actividad.Resource != null)
                ViewBag.Tipos_de_Actividadess_Tipo_de_Actividad = Tipos_de_Actividadess_Tipo_de_Actividad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipos_de_Actividades", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Quien_imparte = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Quien_imparte != null && Spartan_Users_Quien_imparte.Resource != null)
                ViewBag.Spartan_Users_Quien_imparte = Spartan_Users_Quien_imparte.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Especialidadess_Especialidad = _IEspecialidadesApiConsumer.SelAll(true);
            if (Especialidadess_Especialidad != null && Especialidadess_Especialidad.Resource != null)
                ViewBag.Especialidadess_Especialidad = Especialidadess_Especialidad.Resource.Where(m => m.Especialidad != null).OrderBy(m => m.Especialidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Especialidades", "Especialidad") ?? m.Especialidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Actividades_Eventos_Estatus = _IEstatus_Actividades_EventoApiConsumer.SelAll(true);
            if (Estatus_Actividades_Eventos_Estatus != null && Estatus_Actividades_Eventos_Estatus.Resource != null)
                ViewBag.Estatus_Actividades_Eventos_Estatus = Estatus_Actividades_Eventos_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_Actividades_Evento", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddActividades_del_Evento", varActividades_del_Evento);
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



        [HttpPost]
        public JsonResult ClearAdvanceFilter()
        {
            Session["AdvanceSearch"] = null;
            return Json(new { result = Session["AdvanceSearch"] == null }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ShowAdvanceFilter(Actividades_del_EventoAdvanceSearchModel model, int idFilter = -1)
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
            _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Detalle_Actividades_Eventos_Actividad = _IDetalle_Actividades_EventoApiConsumer.SelAll(true);
            if (Detalle_Actividades_Eventos_Actividad != null && Detalle_Actividades_Eventos_Actividad.Resource != null)
                ViewBag.Detalle_Actividades_Eventos_Actividad = Detalle_Actividades_Eventos_Actividad.Resource.Where(m => m.Nombre_de_la_Actividad != null).OrderBy(m => m.Nombre_de_la_Actividad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Detalle_Actividades_Evento", "Nombre_de_la_Actividad") ?? m.Nombre_de_la_Actividad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Ubicaciones_Eventos_Empresas_Ubicacion = _IUbicaciones_Eventos_EmpresaApiConsumer.SelAll(true);
            if (Ubicaciones_Eventos_Empresas_Ubicacion != null && Ubicaciones_Eventos_Empresas_Ubicacion.Resource != null)
                ViewBag.Ubicaciones_Eventos_Empresas_Ubicacion = Ubicaciones_Eventos_Empresas_Ubicacion.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Ubicaciones_Eventos_Empresa", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ITipos_de_ActividadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipos_de_Actividadess_Tipo_de_Actividad = _ITipos_de_ActividadesApiConsumer.SelAll(true);
            if (Tipos_de_Actividadess_Tipo_de_Actividad != null && Tipos_de_Actividadess_Tipo_de_Actividad.Resource != null)
                ViewBag.Tipos_de_Actividadess_Tipo_de_Actividad = Tipos_de_Actividadess_Tipo_de_Actividad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipos_de_Actividades", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Quien_imparte = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Quien_imparte != null && Spartan_Users_Quien_imparte.Resource != null)
                ViewBag.Spartan_Users_Quien_imparte = Spartan_Users_Quien_imparte.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Especialidadess_Especialidad = _IEspecialidadesApiConsumer.SelAll(true);
            if (Especialidadess_Especialidad != null && Especialidadess_Especialidad.Resource != null)
                ViewBag.Especialidadess_Especialidad = Especialidadess_Especialidad.Resource.Where(m => m.Especialidad != null).OrderBy(m => m.Especialidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Especialidades", "Especialidad") ?? m.Especialidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Actividades_Eventos_Estatus = _IEstatus_Actividades_EventoApiConsumer.SelAll(true);
            if (Estatus_Actividades_Eventos_Estatus != null && Estatus_Actividades_Eventos_Estatus.Resource != null)
                ViewBag.Estatus_Actividades_Eventos_Estatus = Estatus_Actividades_Eventos_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_Actividades_Evento", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
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
            _IDetalle_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Detalle_Actividades_Eventos_Actividad = _IDetalle_Actividades_EventoApiConsumer.SelAll(true);
            if (Detalle_Actividades_Eventos_Actividad != null && Detalle_Actividades_Eventos_Actividad.Resource != null)
                ViewBag.Detalle_Actividades_Eventos_Actividad = Detalle_Actividades_Eventos_Actividad.Resource.Where(m => m.Nombre_de_la_Actividad != null).OrderBy(m => m.Nombre_de_la_Actividad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Detalle_Actividades_Evento", "Nombre_de_la_Actividad") ?? m.Nombre_de_la_Actividad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IUbicaciones_Eventos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Ubicaciones_Eventos_Empresas_Ubicacion = _IUbicaciones_Eventos_EmpresaApiConsumer.SelAll(true);
            if (Ubicaciones_Eventos_Empresas_Ubicacion != null && Ubicaciones_Eventos_Empresas_Ubicacion.Resource != null)
                ViewBag.Ubicaciones_Eventos_Empresas_Ubicacion = Ubicaciones_Eventos_Empresas_Ubicacion.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Ubicaciones_Eventos_Empresa", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ITipos_de_ActividadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipos_de_Actividadess_Tipo_de_Actividad = _ITipos_de_ActividadesApiConsumer.SelAll(true);
            if (Tipos_de_Actividadess_Tipo_de_Actividad != null && Tipos_de_Actividadess_Tipo_de_Actividad.Resource != null)
                ViewBag.Tipos_de_Actividadess_Tipo_de_Actividad = Tipos_de_Actividadess_Tipo_de_Actividad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Tipos_de_Actividades", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Quien_imparte = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Quien_imparte != null && Spartan_Users_Quien_imparte.Resource != null)
                ViewBag.Spartan_Users_Quien_imparte = Spartan_Users_Quien_imparte.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Especialidadess_Especialidad = _IEspecialidadesApiConsumer.SelAll(true);
            if (Especialidadess_Especialidad != null && Especialidadess_Especialidad.Resource != null)
                ViewBag.Especialidadess_Especialidad = Especialidadess_Especialidad.Resource.Where(m => m.Especialidad != null).OrderBy(m => m.Especialidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Especialidades", "Especialidad") ?? m.Especialidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_Actividades_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Actividades_Eventos_Estatus = _IEstatus_Actividades_EventoApiConsumer.SelAll(true);
            if (Estatus_Actividades_Eventos_Estatus != null && Estatus_Actividades_Eventos_Estatus.Resource != null)
                ViewBag.Estatus_Actividades_Eventos_Estatus = Estatus_Actividades_Eventos_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Estatus_Actividades_Evento", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            var previousFiltersObj = new Actividades_del_EventoAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Actividades_del_EventoAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Actividades_del_EventoAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Actividades_del_EventoPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IActividades_del_EventoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Actividades_del_Eventos == null)
                result.Actividades_del_Eventos = new List<Actividades_del_Evento>();

            return Json(new
            {
                data = result.Actividades_del_Eventos.Select(m => new Actividades_del_EventoGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,EventoNombre_del_Evento = CultureHelper.GetTraduction(m.Evento_Eventos.Folio.ToString(), "Nombre_del_Evento") ?? (string)m.Evento_Eventos.Nombre_del_Evento
                        ,ActividadNombre_de_la_Actividad = CultureHelper.GetTraduction(m.Actividad_Detalle_Actividades_Evento.Folio.ToString(), "Nombre_de_la_Actividad") ?? (string)m.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
			,Descripcion = m.Descripcion
                        ,Dia = (m.Dia == null ? string.Empty : Convert.ToDateTime(m.Dia).ToString(ConfigurationProperty.DateFormat))
			,Hora_inicio = m.Hora_inicio
			,Hora_fin = m.Hora_fin
			,Tiene_receso = m.Tiene_receso
			,Hora_inicio_receso = m.Hora_inicio_receso
			,Hora_fin_receso = m.Hora_fin_receso
                        ,UbicacionNombre = CultureHelper.GetTraduction(m.Ubicacion_Ubicaciones_Eventos_Empresa.Folio.ToString(), "Nombre") ?? (string)m.Ubicacion_Ubicaciones_Eventos_Empresa.Nombre
                        ,Tipo_de_ActividadDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Actividad_Tipos_de_Actividades.Folio.ToString(), "Descripcion") ?? (string)m.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                        ,Quien_imparteName = CultureHelper.GetTraduction(m.Quien_imparte_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Quien_imparte_Spartan_User.Name
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ?? (string)m.Especialidad_Especialidades.Especialidad
			,Cupo_limitado = m.Cupo_limitado
			,Cupo_maximo = m.Cupo_maximo
			,Duracion_maxima_por_Paciente_mins = m.Duracion_maxima_por_Paciente_mins
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Actividades_Evento.Folio.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Actividades_Evento.Descripcion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetActividades_del_EventoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IActividades_del_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IActividades_del_EventoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Actividades_del_Evento", m.),
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
        /// Get List of Actividades_del_Evento from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Actividades_del_Evento Entity</returns>
        public ActionResult GetActividades_del_EventoList(UrlParametersModel param)
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
            _IActividades_del_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Actividades_del_EventoPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(Actividades_del_EventoAdvanceSearchModel))
                {
					var advanceFilter =
                    (Actividades_del_EventoAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Actividades_del_EventoPropertyMapper oActividades_del_EventoPropertyMapper = new Actividades_del_EventoPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oActividades_del_EventoPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IActividades_del_EventoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Actividades_del_Eventos == null)
                result.Actividades_del_Eventos = new List<Actividades_del_Evento>();

            return Json(new
            {
                aaData = result.Actividades_del_Eventos.Select(m => new Actividades_del_EventoGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,EventoNombre_del_Evento = CultureHelper.GetTraduction(m.Evento_Eventos.Folio.ToString(), "Nombre_del_Evento") ?? (string)m.Evento_Eventos.Nombre_del_Evento
                        ,ActividadNombre_de_la_Actividad = CultureHelper.GetTraduction(m.Actividad_Detalle_Actividades_Evento.Folio.ToString(), "Nombre_de_la_Actividad") ?? (string)m.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
			,Descripcion = m.Descripcion
                        ,Dia = (m.Dia == null ? string.Empty : Convert.ToDateTime(m.Dia).ToString(ConfigurationProperty.DateFormat))
			,Hora_inicio = m.Hora_inicio
			,Hora_fin = m.Hora_fin
			,Tiene_receso = m.Tiene_receso
			,Hora_inicio_receso = m.Hora_inicio_receso
			,Hora_fin_receso = m.Hora_fin_receso
                        ,UbicacionNombre = CultureHelper.GetTraduction(m.Ubicacion_Ubicaciones_Eventos_Empresa.Folio.ToString(), "Nombre") ?? (string)m.Ubicacion_Ubicaciones_Eventos_Empresa.Nombre
                        ,Tipo_de_ActividadDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Actividad_Tipos_de_Actividades.Folio.ToString(), "Descripcion") ?? (string)m.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                        ,Quien_imparteName = CultureHelper.GetTraduction(m.Quien_imparte_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Quien_imparte_Spartan_User.Name
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ?? (string)m.Especialidad_Especialidades.Especialidad
			,Cupo_limitado = m.Cupo_limitado
			,Cupo_maximo = m.Cupo_maximo
			,Duracion_maxima_por_Paciente_mins = m.Duracion_maxima_por_Paciente_mins
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Actividades_Evento.Folio.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Actividades_Evento.Descripcion

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(Actividades_del_EventoAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Actividades_del_Evento.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Actividades_del_Evento.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Actividades_del_Evento.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Actividades_del_Evento.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Actividades_del_Evento.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Actividades_del_Evento.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
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

                where += " AND Actividades_del_Evento.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
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

                where += " AND Actividades_del_Evento.Evento In (" + EventoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceActividad))
            {
                switch (filter.ActividadFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Detalle_Actividades_Evento.Nombre_de_la_Actividad LIKE '" + filter.AdvanceActividad + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Detalle_Actividades_Evento.Nombre_de_la_Actividad LIKE '%" + filter.AdvanceActividad + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Detalle_Actividades_Evento.Nombre_de_la_Actividad = '" + filter.AdvanceActividad + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Detalle_Actividades_Evento.Nombre_de_la_Actividad LIKE '%" + filter.AdvanceActividad + "%'";
                        break;
                }
            }
            else if (filter.AdvanceActividadMultiple != null && filter.AdvanceActividadMultiple.Count() > 0)
            {
                var ActividadIds = string.Join(",", filter.AdvanceActividadMultiple);

                where += " AND Actividades_del_Evento.Actividad In (" + ActividadIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Descripcion))
            {
                switch (filter.DescripcionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Actividades_del_Evento.Descripcion LIKE '" + filter.Descripcion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Actividades_del_Evento.Descripcion LIKE '%" + filter.Descripcion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Actividades_del_Evento.Descripcion = '" + filter.Descripcion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Actividades_del_Evento.Descripcion LIKE '%" + filter.Descripcion + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromDia) || !string.IsNullOrEmpty(filter.ToDia))
            {
                var DiaFrom = DateTime.ParseExact(filter.FromDia, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var DiaTo = DateTime.ParseExact(filter.ToDia, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromDia))
                    where += " AND Actividades_del_Evento.Dia >= '" + DiaFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToDia))
                    where += " AND Actividades_del_Evento.Dia <= '" + DiaTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_inicio) || !string.IsNullOrEmpty(filter.ToHora_inicio))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_inicio))
                    where += " AND Convert(TIME,Actividades_del_Evento.Hora_inicio) >='" + filter.FromHora_inicio + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_inicio))
                    where += " AND Convert(TIME,Actividades_del_Evento.Hora_inicio) <='" + filter.ToHora_inicio + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_fin) || !string.IsNullOrEmpty(filter.ToHora_fin))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_fin))
                    where += " AND Convert(TIME,Actividades_del_Evento.Hora_fin) >='" + filter.FromHora_fin + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_fin))
                    where += " AND Convert(TIME,Actividades_del_Evento.Hora_fin) <='" + filter.ToHora_fin + "'";
            }

            if (filter.Tiene_receso != RadioOptions.NoApply)
                where += " AND Actividades_del_Evento.Tiene_receso = " + Convert.ToInt32(filter.Tiene_receso);

            if (!string.IsNullOrEmpty(filter.FromHora_inicio_receso) || !string.IsNullOrEmpty(filter.ToHora_inicio_receso))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_inicio_receso))
                    where += " AND Convert(TIME,Actividades_del_Evento.Hora_inicio_receso) >='" + filter.FromHora_inicio_receso + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_inicio_receso))
                    where += " AND Convert(TIME,Actividades_del_Evento.Hora_inicio_receso) <='" + filter.ToHora_inicio_receso + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_fin_receso) || !string.IsNullOrEmpty(filter.ToHora_fin_receso))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_fin_receso))
                    where += " AND Convert(TIME,Actividades_del_Evento.Hora_fin_receso) >='" + filter.FromHora_fin_receso + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_fin_receso))
                    where += " AND Convert(TIME,Actividades_del_Evento.Hora_fin_receso) <='" + filter.ToHora_fin_receso + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceUbicacion))
            {
                switch (filter.UbicacionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Ubicaciones_Eventos_Empresa.Nombre LIKE '" + filter.AdvanceUbicacion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Ubicaciones_Eventos_Empresa.Nombre LIKE '%" + filter.AdvanceUbicacion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Ubicaciones_Eventos_Empresa.Nombre = '" + filter.AdvanceUbicacion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Ubicaciones_Eventos_Empresa.Nombre LIKE '%" + filter.AdvanceUbicacion + "%'";
                        break;
                }
            }
            else if (filter.AdvanceUbicacionMultiple != null && filter.AdvanceUbicacionMultiple.Count() > 0)
            {
                var UbicacionIds = string.Join(",", filter.AdvanceUbicacionMultiple);

                where += " AND Actividades_del_Evento.Ubicacion In (" + UbicacionIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTipo_de_Actividad))
            {
                switch (filter.Tipo_de_ActividadFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tipos_de_Actividades.Descripcion LIKE '" + filter.AdvanceTipo_de_Actividad + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tipos_de_Actividades.Descripcion LIKE '%" + filter.AdvanceTipo_de_Actividad + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tipos_de_Actividades.Descripcion = '" + filter.AdvanceTipo_de_Actividad + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tipos_de_Actividades.Descripcion LIKE '%" + filter.AdvanceTipo_de_Actividad + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTipo_de_ActividadMultiple != null && filter.AdvanceTipo_de_ActividadMultiple.Count() > 0)
            {
                var Tipo_de_ActividadIds = string.Join(",", filter.AdvanceTipo_de_ActividadMultiple);

                where += " AND Actividades_del_Evento.Tipo_de_Actividad In (" + Tipo_de_ActividadIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceQuien_imparte))
            {
                switch (filter.Quien_imparteFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.AdvanceQuien_imparte + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceQuien_imparte + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.AdvanceQuien_imparte + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceQuien_imparte + "%'";
                        break;
                }
            }
            else if (filter.AdvanceQuien_imparteMultiple != null && filter.AdvanceQuien_imparteMultiple.Count() > 0)
            {
                var Quien_imparteIds = string.Join(",", filter.AdvanceQuien_imparteMultiple);

                where += " AND Actividades_del_Evento.Quien_imparte In (" + Quien_imparteIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEspecialidad))
            {
                switch (filter.EspecialidadFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Especialidades.Especialidad LIKE '" + filter.AdvanceEspecialidad + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Especialidades.Especialidad LIKE '%" + filter.AdvanceEspecialidad + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Especialidades.Especialidad = '" + filter.AdvanceEspecialidad + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Especialidades.Especialidad LIKE '%" + filter.AdvanceEspecialidad + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEspecialidadMultiple != null && filter.AdvanceEspecialidadMultiple.Count() > 0)
            {
                var EspecialidadIds = string.Join(",", filter.AdvanceEspecialidadMultiple);

                where += " AND Actividades_del_Evento.Especialidad In (" + EspecialidadIds + ")";
            }

            if (filter.Cupo_limitado != RadioOptions.NoApply)
                where += " AND Actividades_del_Evento.Cupo_limitado = " + Convert.ToInt32(filter.Cupo_limitado);

            if (!string.IsNullOrEmpty(filter.FromCupo_maximo) || !string.IsNullOrEmpty(filter.ToCupo_maximo))
            {
                if (!string.IsNullOrEmpty(filter.FromCupo_maximo))
                    where += " AND Actividades_del_Evento.Cupo_maximo >= " + filter.FromCupo_maximo;
                if (!string.IsNullOrEmpty(filter.ToCupo_maximo))
                    where += " AND Actividades_del_Evento.Cupo_maximo <= " + filter.ToCupo_maximo;
            }

            if (!string.IsNullOrEmpty(filter.FromDuracion_maxima_por_Paciente_mins) || !string.IsNullOrEmpty(filter.ToDuracion_maxima_por_Paciente_mins))
            {
                if (!string.IsNullOrEmpty(filter.FromDuracion_maxima_por_Paciente_mins))
                    where += " AND Actividades_del_Evento.Duracion_maxima_por_Paciente_mins >= " + filter.FromDuracion_maxima_por_Paciente_mins;
                if (!string.IsNullOrEmpty(filter.ToDuracion_maxima_por_Paciente_mins))
                    where += " AND Actividades_del_Evento.Duracion_maxima_por_Paciente_mins <= " + filter.ToDuracion_maxima_por_Paciente_mins;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEstatus))
            {
                switch (filter.EstatusFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estatus_Actividades_Evento.Descripcion LIKE '" + filter.AdvanceEstatus + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estatus_Actividades_Evento.Descripcion LIKE '%" + filter.AdvanceEstatus + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estatus_Actividades_Evento.Descripcion = '" + filter.AdvanceEstatus + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estatus_Actividades_Evento.Descripcion LIKE '%" + filter.AdvanceEstatus + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEstatusMultiple != null && filter.AdvanceEstatusMultiple.Count() > 0)
            {
                var EstatusIds = string.Join(",", filter.AdvanceEstatusMultiple);

                where += " AND Actividades_del_Evento.Estatus In (" + EstatusIds + ")";
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

        public ActionResult GetDetalle_Horarios_Actividad(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Horarios_ActividadGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Horarios_ActividadApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Horarios_Actividad.Folio_Actividades=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Horarios_Actividad.Folio_Actividades='" + RelationId + "'";
            }
            var result = _IDetalle_Horarios_ActividadApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Horarios_Actividads == null)
                result.Detalle_Horarios_Actividads = new List<Detalle_Horarios_Actividad>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Horarios_Actividads.Select(m => new Detalle_Horarios_ActividadGridModel
                {
                    Folio = m.Folio

			,Reservada = m.Reservada
			,Numero_de_Cita = m.Numero_de_Cita
			,Hora_inicio = m.Hora_inicio
			,Hora_fin = m.Hora_fin
			,Horario = m.Horario
                        ,Codigo_de_Reservacion = m.Codigo_de_Reservacion
                        ,Codigo_de_ReservacionCodigo_Reservacion = CultureHelper.GetTraduction(m.Codigo_de_Reservacion_Detalle_Registro_en_Actividad_Evento.Folio.ToString(), "Codigo_Reservacion") ??(string)m.Codigo_de_Reservacion_Detalle_Registro_en_Actividad_Evento.Codigo_Reservacion
			,Numero_de_Empleado = m.Numero_de_Empleado
			,Familiar_del_Empleado = m.Familiar_del_Empleado
			,Nombre_Completo = m.Nombre_Completo
                        ,Parentesco_con_el_Empleado = m.Parentesco_con_el_Empleado
                        ,Parentesco_con_el_EmpleadoDescripcion = CultureHelper.GetTraduction(m.Parentesco_con_el_Empleado_Parentescos_Empleados.Folio.ToString(), "Descripcion") ??(string)m.Parentesco_con_el_Empleado_Parentescos_Empleados.Descripcion
                        ,Sexo = m.Sexo
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ??(string)m.Sexo_Sexo.Descripcion
			,Edad = m.Edad
                        ,Estatus_de_la_Reservacion = m.Estatus_de_la_Reservacion
                        ,Estatus_de_la_ReservacionDescripcion = CultureHelper.GetTraduction(m.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Folio.ToString(), "Descripcion") ??(string)m.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Descripcion
			,Asistio = m.Asistio

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Horarios_ActividadGridModel> GetDetalle_Horarios_ActividadData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Horarios_ActividadGridModel> resultData = new List<Detalle_Horarios_ActividadGridModel>();
            string where = "Detalle_Horarios_Actividad.Folio_Actividades=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Horarios_Actividad.Folio_Actividades='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Horarios_ActividadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Horarios_ActividadApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Horarios_Actividads != null)
            {
                resultData = result.Detalle_Horarios_Actividads.Select(m => new Detalle_Horarios_ActividadGridModel
                    {
                        Folio = m.Folio

			,Reservada = m.Reservada
			,Numero_de_Cita = m.Numero_de_Cita
			,Hora_inicio = m.Hora_inicio
			,Hora_fin = m.Hora_fin
			,Horario = m.Horario
                        ,Codigo_de_Reservacion = m.Codigo_de_Reservacion
                        ,Codigo_de_ReservacionCodigo_Reservacion = CultureHelper.GetTraduction(m.Codigo_de_Reservacion_Detalle_Registro_en_Actividad_Evento.Folio.ToString(), "Codigo_Reservacion") ??(string)m.Codigo_de_Reservacion_Detalle_Registro_en_Actividad_Evento.Codigo_Reservacion
			,Numero_de_Empleado = m.Numero_de_Empleado
			,Familiar_del_Empleado = m.Familiar_del_Empleado
			,Nombre_Completo = m.Nombre_Completo
                        ,Parentesco_con_el_Empleado = m.Parentesco_con_el_Empleado
                        ,Parentesco_con_el_EmpleadoDescripcion = CultureHelper.GetTraduction(m.Parentesco_con_el_Empleado_Parentescos_Empleados.Folio.ToString(), "Descripcion") ??(string)m.Parentesco_con_el_Empleado_Parentescos_Empleados.Descripcion
                        ,Sexo = m.Sexo
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ??(string)m.Sexo_Sexo.Descripcion
			,Edad = m.Edad
                        ,Estatus_de_la_Reservacion = m.Estatus_de_la_Reservacion
                        ,Estatus_de_la_ReservacionDescripcion = CultureHelper.GetTraduction(m.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Folio.ToString(), "Descripcion") ??(string)m.Estatus_de_la_Reservacion_Estatus_Reservaciones_Actividad.Descripcion
			,Asistio = m.Asistio


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
                _IActividades_del_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

                Actividades_del_Evento varActividades_del_Evento = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IDetalle_Horarios_ActividadApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Horarios_Actividad.Folio_Actividades=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Horarios_Actividad.Folio_Actividades='" + id + "'";
                    }
                    var Detalle_Horarios_ActividadInfo =
                        _IDetalle_Horarios_ActividadApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Horarios_ActividadInfo.Detalle_Horarios_Actividads.Count > 0)
                    {
                        var resultDetalle_Horarios_Actividad = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Horarios_ActividadItem in Detalle_Horarios_ActividadInfo.Detalle_Horarios_Actividads)
                            resultDetalle_Horarios_Actividad = resultDetalle_Horarios_Actividad
                                              && _IDetalle_Horarios_ActividadApiConsumer.Delete(Detalle_Horarios_ActividadItem.Folio, null,null).Resource;

                        if (!resultDetalle_Horarios_Actividad)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IActividades_del_EventoApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Actividades_del_EventoModel varActividades_del_Evento)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IActividades_del_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Actividades_del_EventoInfo = new Actividades_del_Evento
                    {
                        Folio = varActividades_del_Evento.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varActividades_del_Evento.Fecha_de_Registro)) ? DateTime.ParseExact(varActividades_del_Evento.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varActividades_del_Evento.Hora_de_Registro
                        ,Usuario_que_Registra = varActividades_del_Evento.Usuario_que_Registra
                        ,Evento = varActividades_del_Evento.Evento
                        ,Actividad = varActividades_del_Evento.Actividad
                        ,Descripcion = varActividades_del_Evento.Descripcion
                        ,Dia = (!String.IsNullOrEmpty(varActividades_del_Evento.Dia)) ? DateTime.ParseExact(varActividades_del_Evento.Dia, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_inicio = varActividades_del_Evento.Hora_inicio
                        ,Hora_fin = varActividades_del_Evento.Hora_fin
                        ,Tiene_receso = varActividades_del_Evento.Tiene_receso
                        ,Hora_inicio_receso = varActividades_del_Evento.Hora_inicio_receso
                        ,Hora_fin_receso = varActividades_del_Evento.Hora_fin_receso
                        ,Ubicacion = varActividades_del_Evento.Ubicacion
                        ,Tipo_de_Actividad = varActividades_del_Evento.Tipo_de_Actividad
                        ,Quien_imparte = varActividades_del_Evento.Quien_imparte
                        ,Especialidad = varActividades_del_Evento.Especialidad
                        ,Cupo_limitado = varActividades_del_Evento.Cupo_limitado
                        ,Cupo_maximo = varActividades_del_Evento.Cupo_maximo
                        ,Duracion_maxima_por_Paciente_mins = varActividades_del_Evento.Duracion_maxima_por_Paciente_mins
                        ,Estatus = varActividades_del_Evento.Estatus

                    };

                    result = !IsNew ?
                        _IActividades_del_EventoApiConsumer.Update(Actividades_del_EventoInfo, null, null).Resource.ToString() :
                         _IActividades_del_EventoApiConsumer.Insert(Actividades_del_EventoInfo, null, null).Resource.ToString();
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
        public bool CopyDetalle_Horarios_Actividad(int MasterId, int referenceId, List<Detalle_Horarios_ActividadGridModelPost> Detalle_Horarios_ActividadItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Horarios_ActividadApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Horarios_ActividadData = _IDetalle_Horarios_ActividadApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Horarios_Actividad.Folio_Actividades=" + referenceId,"").Resource;
                if (Detalle_Horarios_ActividadData == null || Detalle_Horarios_ActividadData.Detalle_Horarios_Actividads.Count == 0)
                    return true;

                var result = true;

                Detalle_Horarios_ActividadGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Horarios_Actividad in Detalle_Horarios_ActividadData.Detalle_Horarios_Actividads)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Horarios_Actividad Detalle_Horarios_Actividad1 = varDetalle_Horarios_Actividad;

                    if (Detalle_Horarios_ActividadItems != null && Detalle_Horarios_ActividadItems.Any(m => m.Folio == Detalle_Horarios_Actividad1.Folio))
                    {
                        modelDataToChange = Detalle_Horarios_ActividadItems.FirstOrDefault(m => m.Folio == Detalle_Horarios_Actividad1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Horarios_Actividad.Folio_Actividades = MasterId;
                    var insertId = _IDetalle_Horarios_ActividadApiConsumer.Insert(varDetalle_Horarios_Actividad,null,null).Resource;
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
        public ActionResult PostDetalle_Horarios_Actividad(List<Detalle_Horarios_ActividadGridModelPost> Detalle_Horarios_ActividadItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Horarios_Actividad(MasterId, referenceId, Detalle_Horarios_ActividadItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Horarios_ActividadItems != null && Detalle_Horarios_ActividadItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Horarios_ActividadApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Horarios_ActividadItem in Detalle_Horarios_ActividadItems)
                    {
















                        //Removal Request
                        if (Detalle_Horarios_ActividadItem.Removed)
                        {
                            result = result && _IDetalle_Horarios_ActividadApiConsumer.Delete(Detalle_Horarios_ActividadItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Horarios_ActividadItem.Folio = 0;

                        var Detalle_Horarios_ActividadData = new Detalle_Horarios_Actividad
                        {
                            Folio_Actividades = MasterId
                            ,Folio = Detalle_Horarios_ActividadItem.Folio
                            ,Reservada = Detalle_Horarios_ActividadItem.Reservada
                            ,Numero_de_Cita = Detalle_Horarios_ActividadItem.Numero_de_Cita
                            ,Hora_inicio = Detalle_Horarios_ActividadItem.Hora_inicio
                            ,Hora_fin = Detalle_Horarios_ActividadItem.Hora_fin
                            ,Horario = Detalle_Horarios_ActividadItem.Horario
                            ,Codigo_de_Reservacion = (Convert.ToInt32(Detalle_Horarios_ActividadItem.Codigo_de_Reservacion) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Horarios_ActividadItem.Codigo_de_Reservacion))
                            ,Numero_de_Empleado = Detalle_Horarios_ActividadItem.Numero_de_Empleado
                            ,Familiar_del_Empleado = Detalle_Horarios_ActividadItem.Familiar_del_Empleado
                            ,Nombre_Completo = Detalle_Horarios_ActividadItem.Nombre_Completo
                            ,Parentesco_con_el_Empleado = (Convert.ToInt32(Detalle_Horarios_ActividadItem.Parentesco_con_el_Empleado) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Horarios_ActividadItem.Parentesco_con_el_Empleado))
                            ,Sexo = (Convert.ToInt32(Detalle_Horarios_ActividadItem.Sexo) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Horarios_ActividadItem.Sexo))
                            ,Edad = Detalle_Horarios_ActividadItem.Edad
                            ,Estatus_de_la_Reservacion = (Convert.ToInt32(Detalle_Horarios_ActividadItem.Estatus_de_la_Reservacion) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Horarios_ActividadItem.Estatus_de_la_Reservacion))
                            ,Asistio = Detalle_Horarios_ActividadItem.Asistio

                        };

                        var resultId = Detalle_Horarios_ActividadItem.Folio > 0
                           ? _IDetalle_Horarios_ActividadApiConsumer.Update(Detalle_Horarios_ActividadData,null,null).Resource
                           : _IDetalle_Horarios_ActividadApiConsumer.Insert(Detalle_Horarios_ActividadData,null,null).Resource;

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
        public ActionResult GetDetalle_Horarios_Actividad_Detalle_Registro_en_Actividad_EventoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Registro_en_Actividad_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDetalle_Registro_en_Actividad_EventoApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Detalle_Registro_en_Actividad_Evento", "Codigo_Reservacion");
                  item.Codigo_Reservacion= trans??item.Codigo_Reservacion;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpGet]
        public ActionResult GetDetalle_Horarios_Actividad_Parentescos_EmpleadosAll()
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
        public ActionResult GetDetalle_Horarios_Actividad_SexoAll()
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
        public ActionResult GetDetalle_Horarios_Actividad_Estatus_Reservaciones_ActividadAll()
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
        /// Write Element Array of Actividades_del_Evento script
        /// </summary>
        /// <param name="oActividades_del_EventoElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Actividades_del_EventoModuleAttributeList)
        {
            for (int i = 0; i < Actividades_del_EventoModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Actividades_del_EventoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Actividades_del_EventoModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Actividades_del_EventoModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Actividades_del_EventoModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Actividades_del_EventoModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Actividades_del_EventoModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Actividades_del_EventoModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Actividades_del_EventoModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Actividades_del_EventoModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Actividades_del_EventoModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Actividades_del_EventoModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strActividades_del_EventoScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Actividades_del_Evento.js")))
            {
                strActividades_del_EventoScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Actividades_del_Evento element attributes
            string userChangeJson = jsSerialize.Serialize(Actividades_del_EventoModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strActividades_del_EventoScript.IndexOf("inpuElementArray");
            string splittedString = strActividades_del_EventoScript.Substring(indexOfArray, strActividades_del_EventoScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Actividades_del_EventoModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Actividades_del_EventoModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strActividades_del_EventoScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strActividades_del_EventoScript.Substring(indexOfArrayHistory, strActividades_del_EventoScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strActividades_del_EventoScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strActividades_del_EventoScript.Substring(endIndexOfMainElement + indexOfArray, strActividades_del_EventoScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Actividades_del_EventoModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Actividades_del_EventoModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Actividades_del_Evento.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Actividades_del_Evento.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Actividades_del_Evento.js")))
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
        public ActionResult Actividades_del_EventoPropertyBag()
        {
            return PartialView("Actividades_del_EventoPropertyBag", "Actividades_del_Evento");
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
        public ActionResult AddDetalle_Horarios_Actividad(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Horarios_Actividad/AddDetalle_Horarios_Actividad");
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
                var whereClauseFormat = "Object = 44436 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IActividades_del_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Actividades_del_Evento.Folio= " + RecordId;
                            var result = _IActividades_del_EventoApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IActividades_del_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Actividades_del_EventoPropertyMapper());
			
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
                    (Actividades_del_EventoAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Actividades_del_EventoPropertyMapper oActividades_del_EventoPropertyMapper = new Actividades_del_EventoPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oActividades_del_EventoPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IActividades_del_EventoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Actividades_del_Eventos == null)
                result.Actividades_del_Eventos = new List<Actividades_del_Evento>();

            var data = result.Actividades_del_Eventos.Select(m => new Actividades_del_EventoGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,EventoNombre_del_Evento = CultureHelper.GetTraduction(m.Evento_Eventos.Folio.ToString(), "Nombre_del_Evento") ?? (string)m.Evento_Eventos.Nombre_del_Evento
                        ,ActividadNombre_de_la_Actividad = CultureHelper.GetTraduction(m.Actividad_Detalle_Actividades_Evento.Folio.ToString(), "Nombre_de_la_Actividad") ?? (string)m.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
			,Descripcion = m.Descripcion
                        ,Dia = (m.Dia == null ? string.Empty : Convert.ToDateTime(m.Dia).ToString(ConfigurationProperty.DateFormat))
			,Hora_inicio = m.Hora_inicio
			,Hora_fin = m.Hora_fin
			,Tiene_receso = m.Tiene_receso
			,Hora_inicio_receso = m.Hora_inicio_receso
			,Hora_fin_receso = m.Hora_fin_receso
                        ,UbicacionNombre = CultureHelper.GetTraduction(m.Ubicacion_Ubicaciones_Eventos_Empresa.Folio.ToString(), "Nombre") ?? (string)m.Ubicacion_Ubicaciones_Eventos_Empresa.Nombre
                        ,Tipo_de_ActividadDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Actividad_Tipos_de_Actividades.Folio.ToString(), "Descripcion") ?? (string)m.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                        ,Quien_imparteName = CultureHelper.GetTraduction(m.Quien_imparte_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Quien_imparte_Spartan_User.Name
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ?? (string)m.Especialidad_Especialidades.Especialidad
			,Cupo_limitado = m.Cupo_limitado
			,Cupo_maximo = m.Cupo_maximo
			,Duracion_maxima_por_Paciente_mins = m.Duracion_maxima_por_Paciente_mins
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Actividades_Evento.Folio.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Actividades_Evento.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44436, arrayColumnsVisible), "Actividades_del_EventoList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44436, arrayColumnsVisible), "Actividades_del_EventoList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44436, arrayColumnsVisible), "Actividades_del_EventoList_" + DateTime.Now.ToString());
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

            _IActividades_del_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Actividades_del_EventoPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Actividades_del_EventoAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Actividades_del_EventoPropertyMapper oActividades_del_EventoPropertyMapper = new Actividades_del_EventoPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oActividades_del_EventoPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IActividades_del_EventoApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Actividades_del_Eventos == null)
                result.Actividades_del_Eventos = new List<Actividades_del_Evento>();

            var data = result.Actividades_del_Eventos.Select(m => new Actividades_del_EventoGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,EventoNombre_del_Evento = CultureHelper.GetTraduction(m.Evento_Eventos.Folio.ToString(), "Nombre_del_Evento") ?? (string)m.Evento_Eventos.Nombre_del_Evento
                        ,ActividadNombre_de_la_Actividad = CultureHelper.GetTraduction(m.Actividad_Detalle_Actividades_Evento.Folio.ToString(), "Nombre_de_la_Actividad") ?? (string)m.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
			,Descripcion = m.Descripcion
                        ,Dia = (m.Dia == null ? string.Empty : Convert.ToDateTime(m.Dia).ToString(ConfigurationProperty.DateFormat))
			,Hora_inicio = m.Hora_inicio
			,Hora_fin = m.Hora_fin
			,Tiene_receso = m.Tiene_receso
			,Hora_inicio_receso = m.Hora_inicio_receso
			,Hora_fin_receso = m.Hora_fin_receso
                        ,UbicacionNombre = CultureHelper.GetTraduction(m.Ubicacion_Ubicaciones_Eventos_Empresa.Folio.ToString(), "Nombre") ?? (string)m.Ubicacion_Ubicaciones_Eventos_Empresa.Nombre
                        ,Tipo_de_ActividadDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Actividad_Tipos_de_Actividades.Folio.ToString(), "Descripcion") ?? (string)m.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                        ,Quien_imparteName = CultureHelper.GetTraduction(m.Quien_imparte_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Quien_imparte_Spartan_User.Name
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ?? (string)m.Especialidad_Especialidades.Especialidad
			,Cupo_limitado = m.Cupo_limitado
			,Cupo_maximo = m.Cupo_maximo
			,Duracion_maxima_por_Paciente_mins = m.Duracion_maxima_por_Paciente_mins
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Actividades_Evento.Folio.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Actividades_Evento.Descripcion

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
                _IActividades_del_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IActividades_del_EventoApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Actividades_del_Evento_Datos_GeneralesModel varActividades_del_Evento)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IActividades_del_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Actividades_del_Evento_Datos_GeneralesInfo = new Actividades_del_Evento_Datos_Generales
                {
                    Folio = varActividades_del_Evento.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varActividades_del_Evento.Fecha_de_Registro)) ? DateTime.ParseExact(varActividades_del_Evento.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varActividades_del_Evento.Hora_de_Registro
                        ,Usuario_que_Registra = varActividades_del_Evento.Usuario_que_Registra
                        ,Evento = varActividades_del_Evento.Evento
                        ,Actividad = varActividades_del_Evento.Actividad
                        ,Descripcion = varActividades_del_Evento.Descripcion
                        ,Dia = (!String.IsNullOrEmpty(varActividades_del_Evento.Dia)) ? DateTime.ParseExact(varActividades_del_Evento.Dia, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_inicio = varActividades_del_Evento.Hora_inicio
                        ,Hora_fin = varActividades_del_Evento.Hora_fin
                        ,Tiene_receso = varActividades_del_Evento.Tiene_receso
                        ,Hora_inicio_receso = varActividades_del_Evento.Hora_inicio_receso
                        ,Hora_fin_receso = varActividades_del_Evento.Hora_fin_receso
                        ,Ubicacion = varActividades_del_Evento.Ubicacion
                        ,Tipo_de_Actividad = varActividades_del_Evento.Tipo_de_Actividad
                        ,Quien_imparte = varActividades_del_Evento.Quien_imparte
                        ,Especialidad = varActividades_del_Evento.Especialidad
                        ,Cupo_limitado = varActividades_del_Evento.Cupo_limitado
                        ,Cupo_maximo = varActividades_del_Evento.Cupo_maximo
                        ,Duracion_maxima_por_Paciente_mins = varActividades_del_Evento.Duracion_maxima_por_Paciente_mins
                        ,Estatus = varActividades_del_Evento.Estatus
                    
                };

                result = _IActividades_del_EventoApiConsumer.Update_Datos_Generales(Actividades_del_Evento_Datos_GeneralesInfo).Resource.ToString();
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
                _IActividades_del_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IActividades_del_EventoApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Horarios_Actividad;
                var Detalle_Horarios_ActividadData = GetDetalle_Horarios_ActividadData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Horarios_Actividad);

                var result = new Actividades_del_Evento_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Evento = m.Evento
                        ,EventoNombre_del_Evento = CultureHelper.GetTraduction(m.Evento_Eventos.Folio.ToString(), "Nombre_del_Evento") ?? (string)m.Evento_Eventos.Nombre_del_Evento
                        ,Actividad = m.Actividad
                        ,ActividadNombre_de_la_Actividad = CultureHelper.GetTraduction(m.Actividad_Detalle_Actividades_Evento.Folio.ToString(), "Nombre_de_la_Actividad") ?? (string)m.Actividad_Detalle_Actividades_Evento.Nombre_de_la_Actividad
			,Descripcion = m.Descripcion
                        ,Dia = (m.Dia == null ? string.Empty : Convert.ToDateTime(m.Dia).ToString(ConfigurationProperty.DateFormat))
			,Hora_inicio = m.Hora_inicio
			,Hora_fin = m.Hora_fin
			,Tiene_receso = m.Tiene_receso
			,Hora_inicio_receso = m.Hora_inicio_receso
			,Hora_fin_receso = m.Hora_fin_receso
                        ,Ubicacion = m.Ubicacion
                        ,UbicacionNombre = CultureHelper.GetTraduction(m.Ubicacion_Ubicaciones_Eventos_Empresa.Folio.ToString(), "Nombre") ?? (string)m.Ubicacion_Ubicaciones_Eventos_Empresa.Nombre
                        ,Tipo_de_Actividad = m.Tipo_de_Actividad
                        ,Tipo_de_ActividadDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Actividad_Tipos_de_Actividades.Folio.ToString(), "Descripcion") ?? (string)m.Tipo_de_Actividad_Tipos_de_Actividades.Descripcion
                        ,Quien_imparte = m.Quien_imparte
                        ,Quien_imparteName = CultureHelper.GetTraduction(m.Quien_imparte_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Quien_imparte_Spartan_User.Name
                        ,Especialidad = m.Especialidad
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ?? (string)m.Especialidad_Especialidades.Especialidad
			,Cupo_limitado = m.Cupo_limitado
			,Cupo_maximo = m.Cupo_maximo
			,Duracion_maxima_por_Paciente_mins = m.Duracion_maxima_por_Paciente_mins
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Actividades_Evento.Folio.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Actividades_Evento.Descripcion

                    
                };
				var resultData = new
                {
                    data = result
                    ,Horarios = Detalle_Horarios_ActividadData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Agenda(Actividades_del_Evento_AgendaModel varActividades_del_Evento)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IActividades_del_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Actividades_del_Evento_AgendaInfo = new Actividades_del_Evento_Agenda
                {
                    Folio = varActividades_del_Evento.Folio
                                        
                };

                result = _IActividades_del_EventoApiConsumer.Update_Agenda(Actividades_del_Evento_AgendaInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Agenda(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IActividades_del_EventoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IActividades_del_EventoApiConsumer.Get_Agenda(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Horarios_Actividad;
                var Detalle_Horarios_ActividadData = GetDetalle_Horarios_ActividadData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Horarios_Actividad);

                var result = new Actividades_del_Evento_AgendaModel
                {
                    Folio = m.Folio

                    
                };
				var resultData = new
                {
                    data = result
                    ,Horarios = Detalle_Horarios_ActividadData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

