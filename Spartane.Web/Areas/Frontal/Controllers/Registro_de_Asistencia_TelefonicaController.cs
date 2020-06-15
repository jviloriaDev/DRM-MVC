using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Registro_de_Asistencia_Telefonica;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Pacientes;
using Spartane.Core.Domain.Planes_de_Suscripcion;
using Spartane.Core.Domain.Asuntos_Asistencia_Telefonica;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Estatus_Llamadas;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Registro_de_Asistencia_Telefonica;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Registro_de_Asistencia_Telefonica;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Pacientes;
using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion;
using Spartane.Web.Areas.WebApiConsumer.Asuntos_Asistencia_Telefonica;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Estatus_Llamadas;

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
    public class Registro_de_Asistencia_TelefonicaController : Controller
    {
        #region "variable declaration"

        private IRegistro_de_Asistencia_TelefonicaService service = null;
        private IRegistro_de_Asistencia_TelefonicaApiConsumer _IRegistro_de_Asistencia_TelefonicaApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IPacientesApiConsumer _IPacientesApiConsumer;
        private IPlanes_de_SuscripcionApiConsumer _IPlanes_de_SuscripcionApiConsumer;
        private IAsuntos_Asistencia_TelefonicaApiConsumer _IAsuntos_Asistencia_TelefonicaApiConsumer;
        private IEstatus_LlamadasApiConsumer _IEstatus_LlamadasApiConsumer;

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

        
        public Registro_de_Asistencia_TelefonicaController(IRegistro_de_Asistencia_TelefonicaService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IRegistro_de_Asistencia_TelefonicaApiConsumer Registro_de_Asistencia_TelefonicaApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IPacientesApiConsumer PacientesApiConsumer , IPlanes_de_SuscripcionApiConsumer Planes_de_SuscripcionApiConsumer , IAsuntos_Asistencia_TelefonicaApiConsumer Asuntos_Asistencia_TelefonicaApiConsumer , IEstatus_LlamadasApiConsumer Estatus_LlamadasApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IRegistro_de_Asistencia_TelefonicaApiConsumer = Registro_de_Asistencia_TelefonicaApiConsumer;
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
            this._IPacientesApiConsumer = PacientesApiConsumer;
            this._IPlanes_de_SuscripcionApiConsumer = Planes_de_SuscripcionApiConsumer;
            this._IAsuntos_Asistencia_TelefonicaApiConsumer = Asuntos_Asistencia_TelefonicaApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._IEstatus_LlamadasApiConsumer = Estatus_LlamadasApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Registro_de_Asistencia_Telefonica
        [ObjectAuth(ObjectId = (ModuleObjectId)44458, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44458, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Registro_de_Asistencia_Telefonica/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44458, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44458, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varRegistro_de_Asistencia_Telefonica = new Registro_de_Asistencia_TelefonicaModel();
			varRegistro_de_Asistencia_Telefonica.Folio = Id;
			
            ViewBag.ObjectId = "44458";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IRegistro_de_Asistencia_TelefonicaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Registro_de_Asistencia_TelefonicasData = _IRegistro_de_Asistencia_TelefonicaApiConsumer.ListaSelAll(0, 1000, "Registro_de_Asistencia_Telefonica.Folio=" + Id, "").Resource.Registro_de_Asistencia_Telefonicas;
				
				if (Registro_de_Asistencia_TelefonicasData != null && Registro_de_Asistencia_TelefonicasData.Count > 0)
                {
					var Registro_de_Asistencia_TelefonicaData = Registro_de_Asistencia_TelefonicasData.First();
					varRegistro_de_Asistencia_Telefonica= new Registro_de_Asistencia_TelefonicaModel
					{
						Folio  = Registro_de_Asistencia_TelefonicaData.Folio 
	                    ,Fecha_de_llamada = (Registro_de_Asistencia_TelefonicaData.Fecha_de_llamada == null ? string.Empty : Convert.ToDateTime(Registro_de_Asistencia_TelefonicaData.Fecha_de_llamada).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_llamada = Registro_de_Asistencia_TelefonicaData.Hora_de_llamada
                    ,Usuario_que_llama = Registro_de_Asistencia_TelefonicaData.Usuario_que_llama
                    ,Usuario_que_llamaName = CultureHelper.GetTraduction(Convert.ToString(Registro_de_Asistencia_TelefonicaData.Usuario_que_llama), "Spartan_User") ??  (string)Registro_de_Asistencia_TelefonicaData.Usuario_que_llama_Spartan_User.Name
                    ,Dispositivo = Registro_de_Asistencia_TelefonicaData.Dispositivo
                    ,Nombre_Paciente = Registro_de_Asistencia_TelefonicaData.Nombre_Paciente
                    ,Nombre_PacienteNombre_Completo = CultureHelper.GetTraduction(Convert.ToString(Registro_de_Asistencia_TelefonicaData.Nombre_Paciente), "Pacientes") ??  (string)Registro_de_Asistencia_TelefonicaData.Nombre_Paciente_Pacientes.Nombre_Completo
                    ,Suscripcion = Registro_de_Asistencia_TelefonicaData.Suscripcion
                    ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(Convert.ToString(Registro_de_Asistencia_TelefonicaData.Suscripcion), "Planes_de_Suscripcion") ??  (string)Registro_de_Asistencia_TelefonicaData.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                    ,Numero_telefonico_del_Paciente = Registro_de_Asistencia_TelefonicaData.Numero_telefonico_del_Paciente
                    ,Correo_del_Paciente = Registro_de_Asistencia_TelefonicaData.Correo_del_Paciente
                    ,Telefono_de_Asistencia_marcado = Registro_de_Asistencia_TelefonicaData.Telefono_de_Asistencia_marcado
                    ,Hora_inicio_de_la_Llamada = Registro_de_Asistencia_TelefonicaData.Hora_inicio_de_la_Llamada
                    ,Hora_fin_de_la_Llamada = Registro_de_Asistencia_TelefonicaData.Hora_fin_de_la_Llamada
                    ,Duracion_minutos = Registro_de_Asistencia_TelefonicaData.Duracion_minutos
                    ,Asunto_de_la_Llamada = Registro_de_Asistencia_TelefonicaData.Asunto_de_la_Llamada
                    ,Asunto_de_la_LlamadaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Registro_de_Asistencia_TelefonicaData.Asunto_de_la_Llamada), "Asuntos_Asistencia_Telefonica") ??  (string)Registro_de_Asistencia_TelefonicaData.Asunto_de_la_Llamada_Asuntos_Asistencia_Telefonica.Descripcion
                    ,Atendio = Registro_de_Asistencia_TelefonicaData.Atendio
                    ,AtendioName = CultureHelper.GetTraduction(Convert.ToString(Registro_de_Asistencia_TelefonicaData.Atendio), "Spartan_User") ??  (string)Registro_de_Asistencia_TelefonicaData.Atendio_Spartan_User.Name
                    ,Comentarios = Registro_de_Asistencia_TelefonicaData.Comentarios
                    ,Estatus = Registro_de_Asistencia_TelefonicaData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Registro_de_Asistencia_TelefonicaData.Estatus), "Estatus_Llamadas") ??  (string)Registro_de_Asistencia_TelefonicaData.Estatus_Estatus_Llamadas.Descripcion

					};
				}
				
				
				
            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_llama = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_llama != null && Spartan_Users_Usuario_que_llama.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_llama = Spartan_Users_Usuario_que_llama.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Pacientess_Nombre_Paciente = _IPacientesApiConsumer.SelAll(true);
            if (Pacientess_Nombre_Paciente != null && Pacientess_Nombre_Paciente.Resource != null)
                ViewBag.Pacientess_Nombre_Paciente = Pacientess_Nombre_Paciente.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Pacientes", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
	    _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Planes_de_Suscripcions_Suscripcion = _IPlanes_de_SuscripcionApiConsumer.SelAll(true);
            if (Planes_de_Suscripcions_Suscripcion != null && Planes_de_Suscripcions_Suscripcion.Resource != null)
                ViewBag.Planes_de_Suscripcions_Suscripcion = Planes_de_Suscripcions_Suscripcion.Resource.Where(m => m.Nombre_del_Plan != null).OrderBy(m => m.Nombre_del_Plan).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan") ?? m.Nombre_del_Plan.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IAsuntos_Asistencia_TelefonicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada = _IAsuntos_Asistencia_TelefonicaApiConsumer.SelAll(true);
            if (Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada != null && Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada.Resource != null)
                ViewBag.Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada = Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Asuntos_Asistencia_Telefonica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Atendio = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Atendio != null && Spartan_Users_Atendio.Resource != null)
                ViewBag.Spartan_Users_Atendio = Spartan_Users_Atendio.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEstatus_LlamadasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Llamadass_Estatus = _IEstatus_LlamadasApiConsumer.SelAll(true);
            if (Estatus_Llamadass_Estatus != null && Estatus_Llamadass_Estatus.Resource != null)
                ViewBag.Estatus_Llamadass_Estatus = Estatus_Llamadass_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Llamadas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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

				
            return View(varRegistro_de_Asistencia_Telefonica);
        }
		
	[HttpGet]
        public ActionResult AddRegistro_de_Asistencia_Telefonica(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44458);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IRegistro_de_Asistencia_TelefonicaApiConsumer.SetAuthHeader(_tokenManager.Token);
			Registro_de_Asistencia_TelefonicaModel varRegistro_de_Asistencia_Telefonica= new Registro_de_Asistencia_TelefonicaModel();


            if (id.ToString() != "0")
            {
                var Registro_de_Asistencia_TelefonicasData = _IRegistro_de_Asistencia_TelefonicaApiConsumer.ListaSelAll(0, 1000, "Registro_de_Asistencia_Telefonica.Folio=" + id, "").Resource.Registro_de_Asistencia_Telefonicas;
				
				if (Registro_de_Asistencia_TelefonicasData != null && Registro_de_Asistencia_TelefonicasData.Count > 0)
                {
					var Registro_de_Asistencia_TelefonicaData = Registro_de_Asistencia_TelefonicasData.First();
					varRegistro_de_Asistencia_Telefonica= new Registro_de_Asistencia_TelefonicaModel
					{
						Folio  = Registro_de_Asistencia_TelefonicaData.Folio 
	                    ,Fecha_de_llamada = (Registro_de_Asistencia_TelefonicaData.Fecha_de_llamada == null ? string.Empty : Convert.ToDateTime(Registro_de_Asistencia_TelefonicaData.Fecha_de_llamada).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_llamada = Registro_de_Asistencia_TelefonicaData.Hora_de_llamada
                    ,Usuario_que_llama = Registro_de_Asistencia_TelefonicaData.Usuario_que_llama
                    ,Usuario_que_llamaName = CultureHelper.GetTraduction(Convert.ToString(Registro_de_Asistencia_TelefonicaData.Usuario_que_llama), "Spartan_User") ??  (string)Registro_de_Asistencia_TelefonicaData.Usuario_que_llama_Spartan_User.Name
                    ,Dispositivo = Registro_de_Asistencia_TelefonicaData.Dispositivo
                    ,Nombre_Paciente = Registro_de_Asistencia_TelefonicaData.Nombre_Paciente
                    ,Nombre_PacienteNombre_Completo = CultureHelper.GetTraduction(Convert.ToString(Registro_de_Asistencia_TelefonicaData.Nombre_Paciente), "Pacientes") ??  (string)Registro_de_Asistencia_TelefonicaData.Nombre_Paciente_Pacientes.Nombre_Completo
                    ,Suscripcion = Registro_de_Asistencia_TelefonicaData.Suscripcion
                    ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(Convert.ToString(Registro_de_Asistencia_TelefonicaData.Suscripcion), "Planes_de_Suscripcion") ??  (string)Registro_de_Asistencia_TelefonicaData.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                    ,Numero_telefonico_del_Paciente = Registro_de_Asistencia_TelefonicaData.Numero_telefonico_del_Paciente
                    ,Correo_del_Paciente = Registro_de_Asistencia_TelefonicaData.Correo_del_Paciente
                    ,Telefono_de_Asistencia_marcado = Registro_de_Asistencia_TelefonicaData.Telefono_de_Asistencia_marcado
                    ,Hora_inicio_de_la_Llamada = Registro_de_Asistencia_TelefonicaData.Hora_inicio_de_la_Llamada
                    ,Hora_fin_de_la_Llamada = Registro_de_Asistencia_TelefonicaData.Hora_fin_de_la_Llamada
                    ,Duracion_minutos = Registro_de_Asistencia_TelefonicaData.Duracion_minutos
                    ,Asunto_de_la_Llamada = Registro_de_Asistencia_TelefonicaData.Asunto_de_la_Llamada
                    ,Asunto_de_la_LlamadaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Registro_de_Asistencia_TelefonicaData.Asunto_de_la_Llamada), "Asuntos_Asistencia_Telefonica") ??  (string)Registro_de_Asistencia_TelefonicaData.Asunto_de_la_Llamada_Asuntos_Asistencia_Telefonica.Descripcion
                    ,Atendio = Registro_de_Asistencia_TelefonicaData.Atendio
                    ,AtendioName = CultureHelper.GetTraduction(Convert.ToString(Registro_de_Asistencia_TelefonicaData.Atendio), "Spartan_User") ??  (string)Registro_de_Asistencia_TelefonicaData.Atendio_Spartan_User.Name
                    ,Comentarios = Registro_de_Asistencia_TelefonicaData.Comentarios
                    ,Estatus = Registro_de_Asistencia_TelefonicaData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Registro_de_Asistencia_TelefonicaData.Estatus), "Estatus_Llamadas") ??  (string)Registro_de_Asistencia_TelefonicaData.Estatus_Estatus_Llamadas.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_llama = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_llama != null && Spartan_Users_Usuario_que_llama.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_llama = Spartan_Users_Usuario_que_llama.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Pacientess_Nombre_Paciente = _IPacientesApiConsumer.SelAll(true);
            if (Pacientess_Nombre_Paciente != null && Pacientess_Nombre_Paciente.Resource != null)
                ViewBag.Pacientess_Nombre_Paciente = Pacientess_Nombre_Paciente.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Pacientes", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
	    _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Planes_de_Suscripcions_Suscripcion = _IPlanes_de_SuscripcionApiConsumer.SelAll(true);
            if (Planes_de_Suscripcions_Suscripcion != null && Planes_de_Suscripcions_Suscripcion.Resource != null)
                ViewBag.Planes_de_Suscripcions_Suscripcion = Planes_de_Suscripcions_Suscripcion.Resource.Where(m => m.Nombre_del_Plan != null).OrderBy(m => m.Nombre_del_Plan).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan") ?? m.Nombre_del_Plan.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IAsuntos_Asistencia_TelefonicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada = _IAsuntos_Asistencia_TelefonicaApiConsumer.SelAll(true);
            if (Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada != null && Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada.Resource != null)
                ViewBag.Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada = Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Asuntos_Asistencia_Telefonica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Atendio = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Atendio != null && Spartan_Users_Atendio.Resource != null)
                ViewBag.Spartan_Users_Atendio = Spartan_Users_Atendio.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEstatus_LlamadasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Llamadass_Estatus = _IEstatus_LlamadasApiConsumer.SelAll(true);
            if (Estatus_Llamadass_Estatus != null && Estatus_Llamadass_Estatus.Resource != null)
                ViewBag.Estatus_Llamadass_Estatus = Estatus_Llamadass_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Llamadas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddRegistro_de_Asistencia_Telefonica", varRegistro_de_Asistencia_Telefonica);
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
        public ActionResult GetPacientesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPacientesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Pacientes", "Nombre_Completo")?? m.Nombre_Completo,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
		[HttpGet]
        public ActionResult GetPlanes_de_SuscripcionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlanes_de_SuscripcionApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Nombre_del_Plan).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan")?? m.Nombre_del_Plan,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetAsuntos_Asistencia_TelefonicaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IAsuntos_Asistencia_TelefonicaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IAsuntos_Asistencia_TelefonicaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Asuntos_Asistencia_Telefonica", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstatus_LlamadasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_LlamadasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_LlamadasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Llamadas", "Descripcion")?? m.Descripcion,
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
        public ActionResult ShowAdvanceFilter(Registro_de_Asistencia_TelefonicaAdvanceSearchModel model, int idFilter = -1)
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
            var Spartan_Users_Usuario_que_llama = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_llama != null && Spartan_Users_Usuario_que_llama.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_llama = Spartan_Users_Usuario_que_llama.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Pacientess_Nombre_Paciente = _IPacientesApiConsumer.SelAll(true);
            if (Pacientess_Nombre_Paciente != null && Pacientess_Nombre_Paciente.Resource != null)
                ViewBag.Pacientess_Nombre_Paciente = Pacientess_Nombre_Paciente.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Pacientes", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
	    _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Planes_de_Suscripcions_Suscripcion = _IPlanes_de_SuscripcionApiConsumer.SelAll(true);
            if (Planes_de_Suscripcions_Suscripcion != null && Planes_de_Suscripcions_Suscripcion.Resource != null)
                ViewBag.Planes_de_Suscripcions_Suscripcion = Planes_de_Suscripcions_Suscripcion.Resource.Where(m => m.Nombre_del_Plan != null).OrderBy(m => m.Nombre_del_Plan).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan") ?? m.Nombre_del_Plan.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IAsuntos_Asistencia_TelefonicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada = _IAsuntos_Asistencia_TelefonicaApiConsumer.SelAll(true);
            if (Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada != null && Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada.Resource != null)
                ViewBag.Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada = Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Asuntos_Asistencia_Telefonica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Atendio = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Atendio != null && Spartan_Users_Atendio.Resource != null)
                ViewBag.Spartan_Users_Atendio = Spartan_Users_Atendio.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEstatus_LlamadasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Llamadass_Estatus = _IEstatus_LlamadasApiConsumer.SelAll(true);
            if (Estatus_Llamadass_Estatus != null && Estatus_Llamadass_Estatus.Resource != null)
                ViewBag.Estatus_Llamadass_Estatus = Estatus_Llamadass_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Llamadas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_llama = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_llama != null && Spartan_Users_Usuario_que_llama.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_llama = Spartan_Users_Usuario_que_llama.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Pacientess_Nombre_Paciente = _IPacientesApiConsumer.SelAll(true);
            if (Pacientess_Nombre_Paciente != null && Pacientess_Nombre_Paciente.Resource != null)
                ViewBag.Pacientess_Nombre_Paciente = Pacientess_Nombre_Paciente.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Pacientes", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
	    _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Planes_de_Suscripcions_Suscripcion = _IPlanes_de_SuscripcionApiConsumer.SelAll(true);
            if (Planes_de_Suscripcions_Suscripcion != null && Planes_de_Suscripcions_Suscripcion.Resource != null)
                ViewBag.Planes_de_Suscripcions_Suscripcion = Planes_de_Suscripcions_Suscripcion.Resource.Where(m => m.Nombre_del_Plan != null).OrderBy(m => m.Nombre_del_Plan).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan") ?? m.Nombre_del_Plan.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IAsuntos_Asistencia_TelefonicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada = _IAsuntos_Asistencia_TelefonicaApiConsumer.SelAll(true);
            if (Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada != null && Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada.Resource != null)
                ViewBag.Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada = Asuntos_Asistencia_Telefonicas_Asunto_de_la_Llamada.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Asuntos_Asistencia_Telefonica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Atendio = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Atendio != null && Spartan_Users_Atendio.Resource != null)
                ViewBag.Spartan_Users_Atendio = Spartan_Users_Atendio.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEstatus_LlamadasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Llamadass_Estatus = _IEstatus_LlamadasApiConsumer.SelAll(true);
            if (Estatus_Llamadass_Estatus != null && Estatus_Llamadass_Estatus.Resource != null)
                ViewBag.Estatus_Llamadass_Estatus = Estatus_Llamadass_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Llamadas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            var previousFiltersObj = new Registro_de_Asistencia_TelefonicaAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Registro_de_Asistencia_TelefonicaAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Registro_de_Asistencia_TelefonicaAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Registro_de_Asistencia_TelefonicaPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IRegistro_de_Asistencia_TelefonicaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Registro_de_Asistencia_Telefonicas == null)
                result.Registro_de_Asistencia_Telefonicas = new List<Registro_de_Asistencia_Telefonica>();

            return Json(new
            {
                data = result.Registro_de_Asistencia_Telefonicas.Select(m => new Registro_de_Asistencia_TelefonicaGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_llamada = (m.Fecha_de_llamada == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_llamada).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_llamada = m.Hora_de_llamada
                        ,Usuario_que_llamaName = CultureHelper.GetTraduction(m.Usuario_que_llama_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_llama_Spartan_User.Name
			,Dispositivo = m.Dispositivo
                        ,Nombre_PacienteNombre_Completo = CultureHelper.GetTraduction(m.Nombre_Paciente_Pacientes.Folio.ToString(), "Nombre_Completo") ?? (string)m.Nombre_Paciente_Pacientes.Nombre_Completo
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Planes_de_Suscripcion") ?? (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
			,Numero_telefonico_del_Paciente = m.Numero_telefonico_del_Paciente
			,Correo_del_Paciente = m.Correo_del_Paciente
			,Telefono_de_Asistencia_marcado = m.Telefono_de_Asistencia_marcado
			,Hora_inicio_de_la_Llamada = m.Hora_inicio_de_la_Llamada
			,Hora_fin_de_la_Llamada = m.Hora_fin_de_la_Llamada
			,Duracion_minutos = m.Duracion_minutos
                        ,Asunto_de_la_LlamadaDescripcion = CultureHelper.GetTraduction(m.Asunto_de_la_Llamada_Asuntos_Asistencia_Telefonica.Clave.ToString(), "Descripcion") ?? (string)m.Asunto_de_la_Llamada_Asuntos_Asistencia_Telefonica.Descripcion
                        ,AtendioName = CultureHelper.GetTraduction(m.Atendio_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Atendio_Spartan_User.Name
			,Comentarios = m.Comentarios
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Llamadas.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Llamadas.Descripcion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetRegistro_de_Asistencia_TelefonicaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRegistro_de_Asistencia_TelefonicaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRegistro_de_Asistencia_TelefonicaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Registro_de_Asistencia_Telefonica", m.),
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
        /// Get List of Registro_de_Asistencia_Telefonica from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Registro_de_Asistencia_Telefonica Entity</returns>
        public ActionResult GetRegistro_de_Asistencia_TelefonicaList(UrlParametersModel param)
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
            _IRegistro_de_Asistencia_TelefonicaApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Registro_de_Asistencia_TelefonicaPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(Registro_de_Asistencia_TelefonicaAdvanceSearchModel))
                {
					var advanceFilter =
                    (Registro_de_Asistencia_TelefonicaAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Registro_de_Asistencia_TelefonicaPropertyMapper oRegistro_de_Asistencia_TelefonicaPropertyMapper = new Registro_de_Asistencia_TelefonicaPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oRegistro_de_Asistencia_TelefonicaPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IRegistro_de_Asistencia_TelefonicaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Registro_de_Asistencia_Telefonicas == null)
                result.Registro_de_Asistencia_Telefonicas = new List<Registro_de_Asistencia_Telefonica>();

            return Json(new
            {
                aaData = result.Registro_de_Asistencia_Telefonicas.Select(m => new Registro_de_Asistencia_TelefonicaGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_llamada = (m.Fecha_de_llamada == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_llamada).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_llamada = m.Hora_de_llamada
                        ,Usuario_que_llamaName = CultureHelper.GetTraduction(m.Usuario_que_llama_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_llama_Spartan_User.Name
			,Dispositivo = m.Dispositivo
                        ,Nombre_PacienteNombre_Completo = CultureHelper.GetTraduction(m.Nombre_Paciente_Pacientes.Folio.ToString(), "Nombre_Completo") ?? (string)m.Nombre_Paciente_Pacientes.Nombre_Completo
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Planes_de_Suscripcion") ?? (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
			,Numero_telefonico_del_Paciente = m.Numero_telefonico_del_Paciente
			,Correo_del_Paciente = m.Correo_del_Paciente
			,Telefono_de_Asistencia_marcado = m.Telefono_de_Asistencia_marcado
			,Hora_inicio_de_la_Llamada = m.Hora_inicio_de_la_Llamada
			,Hora_fin_de_la_Llamada = m.Hora_fin_de_la_Llamada
			,Duracion_minutos = m.Duracion_minutos
                        ,Asunto_de_la_LlamadaDescripcion = CultureHelper.GetTraduction(m.Asunto_de_la_Llamada_Asuntos_Asistencia_Telefonica.Clave.ToString(), "Descripcion") ?? (string)m.Asunto_de_la_Llamada_Asuntos_Asistencia_Telefonica.Descripcion
                        ,AtendioName = CultureHelper.GetTraduction(m.Atendio_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Atendio_Spartan_User.Name
			,Comentarios = m.Comentarios
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Llamadas.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Llamadas.Descripcion

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetRegistro_de_Asistencia_Telefonica_Suscripcion_Planes_de_Suscripcion(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Planes_de_Suscripcion.Folio as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Planes_de_Suscripcion.Nombre_del_Plan as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _IPlanes_de_SuscripcionApiConsumer.ListaSelAll(1, 20,elWhere , " Planes_de_Suscripcion.Nombre_del_Plan ASC ").Resource;
               
                foreach (var item in result.Planes_de_Suscripcions)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan");
                    item.Nombre_del_Plan =trans ??item.Nombre_del_Plan;
                }
                return Json(result.Planes_de_Suscripcions.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }





        [NonAction]
        public string GetAdvanceFilter(Registro_de_Asistencia_TelefonicaAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Registro_de_Asistencia_Telefonica.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Registro_de_Asistencia_Telefonica.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_llamada) || !string.IsNullOrEmpty(filter.ToFecha_de_llamada))
            {
                var Fecha_de_llamadaFrom = DateTime.ParseExact(filter.FromFecha_de_llamada, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_llamadaTo = DateTime.ParseExact(filter.ToFecha_de_llamada, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_llamada))
                    where += " AND Registro_de_Asistencia_Telefonica.Fecha_de_llamada >= '" + Fecha_de_llamadaFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_llamada))
                    where += " AND Registro_de_Asistencia_Telefonica.Fecha_de_llamada <= '" + Fecha_de_llamadaTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_llamada) || !string.IsNullOrEmpty(filter.ToHora_de_llamada))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_llamada))
                    where += " AND Convert(TIME,Registro_de_Asistencia_Telefonica.Hora_de_llamada) >='" + filter.FromHora_de_llamada + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_llamada))
                    where += " AND Convert(TIME,Registro_de_Asistencia_Telefonica.Hora_de_llamada) <='" + filter.ToHora_de_llamada + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceUsuario_que_llama))
            {
                switch (filter.Usuario_que_llamaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.AdvanceUsuario_que_llama + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_que_llama + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.AdvanceUsuario_que_llama + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_que_llama + "%'";
                        break;
                }
            }
            else if (filter.AdvanceUsuario_que_llamaMultiple != null && filter.AdvanceUsuario_que_llamaMultiple.Count() > 0)
            {
                var Usuario_que_llamaIds = string.Join(",", filter.AdvanceUsuario_que_llamaMultiple);

                where += " AND Registro_de_Asistencia_Telefonica.Usuario_que_llama In (" + Usuario_que_llamaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Dispositivo))
            {
                switch (filter.DispositivoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Registro_de_Asistencia_Telefonica.Dispositivo LIKE '" + filter.Dispositivo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Registro_de_Asistencia_Telefonica.Dispositivo LIKE '%" + filter.Dispositivo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Registro_de_Asistencia_Telefonica.Dispositivo = '" + filter.Dispositivo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Registro_de_Asistencia_Telefonica.Dispositivo LIKE '%" + filter.Dispositivo + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceNombre_Paciente))
            {
                switch (filter.Nombre_PacienteFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Nombre_Completo LIKE '" + filter.AdvanceNombre_Paciente + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Nombre_Completo LIKE '%" + filter.AdvanceNombre_Paciente + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Nombre_Completo = '" + filter.AdvanceNombre_Paciente + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Nombre_Completo LIKE '%" + filter.AdvanceNombre_Paciente + "%'";
                        break;
                }
            }
            else if (filter.AdvanceNombre_PacienteMultiple != null && filter.AdvanceNombre_PacienteMultiple.Count() > 0)
            {
                var Nombre_PacienteIds = string.Join(",", filter.AdvanceNombre_PacienteMultiple);

                where += " AND Registro_de_Asistencia_Telefonica.Nombre_Paciente In (" + Nombre_PacienteIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceSuscripcion))
            {
                switch (filter.SuscripcionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Planes_de_Suscripcion.Nombre_del_Plan LIKE '" + filter.AdvanceSuscripcion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Planes_de_Suscripcion.Nombre_del_Plan LIKE '%" + filter.AdvanceSuscripcion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Planes_de_Suscripcion.Nombre_del_Plan = '" + filter.AdvanceSuscripcion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Planes_de_Suscripcion.Nombre_del_Plan LIKE '%" + filter.AdvanceSuscripcion + "%'";
                        break;
                }
            }
            else if (filter.AdvanceSuscripcionMultiple != null && filter.AdvanceSuscripcionMultiple.Count() > 0)
            {
                var SuscripcionIds = string.Join(",", filter.AdvanceSuscripcionMultiple);

                where += " AND Registro_de_Asistencia_Telefonica.Suscripcion In (" + SuscripcionIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Numero_telefonico_del_Paciente))
            {
                switch (filter.Numero_telefonico_del_PacienteFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Registro_de_Asistencia_Telefonica.Numero_telefonico_del_Paciente LIKE '" + filter.Numero_telefonico_del_Paciente + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Registro_de_Asistencia_Telefonica.Numero_telefonico_del_Paciente LIKE '%" + filter.Numero_telefonico_del_Paciente + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Registro_de_Asistencia_Telefonica.Numero_telefonico_del_Paciente = '" + filter.Numero_telefonico_del_Paciente + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Registro_de_Asistencia_Telefonica.Numero_telefonico_del_Paciente LIKE '%" + filter.Numero_telefonico_del_Paciente + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Correo_del_Paciente))
            {
                switch (filter.Correo_del_PacienteFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Registro_de_Asistencia_Telefonica.Correo_del_Paciente LIKE '" + filter.Correo_del_Paciente + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Registro_de_Asistencia_Telefonica.Correo_del_Paciente LIKE '%" + filter.Correo_del_Paciente + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Registro_de_Asistencia_Telefonica.Correo_del_Paciente = '" + filter.Correo_del_Paciente + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Registro_de_Asistencia_Telefonica.Correo_del_Paciente LIKE '%" + filter.Correo_del_Paciente + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Telefono_de_Asistencia_marcado))
            {
                switch (filter.Telefono_de_Asistencia_marcadoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Registro_de_Asistencia_Telefonica.Telefono_de_Asistencia_marcado LIKE '" + filter.Telefono_de_Asistencia_marcado + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Registro_de_Asistencia_Telefonica.Telefono_de_Asistencia_marcado LIKE '%" + filter.Telefono_de_Asistencia_marcado + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Registro_de_Asistencia_Telefonica.Telefono_de_Asistencia_marcado = '" + filter.Telefono_de_Asistencia_marcado + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Registro_de_Asistencia_Telefonica.Telefono_de_Asistencia_marcado LIKE '%" + filter.Telefono_de_Asistencia_marcado + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromHora_inicio_de_la_Llamada) || !string.IsNullOrEmpty(filter.ToHora_inicio_de_la_Llamada))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_inicio_de_la_Llamada))
                    where += " AND Convert(TIME,Registro_de_Asistencia_Telefonica.Hora_inicio_de_la_Llamada) >='" + filter.FromHora_inicio_de_la_Llamada + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_inicio_de_la_Llamada))
                    where += " AND Convert(TIME,Registro_de_Asistencia_Telefonica.Hora_inicio_de_la_Llamada) <='" + filter.ToHora_inicio_de_la_Llamada + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_fin_de_la_Llamada) || !string.IsNullOrEmpty(filter.ToHora_fin_de_la_Llamada))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_fin_de_la_Llamada))
                    where += " AND Convert(TIME,Registro_de_Asistencia_Telefonica.Hora_fin_de_la_Llamada) >='" + filter.FromHora_fin_de_la_Llamada + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_fin_de_la_Llamada))
                    where += " AND Convert(TIME,Registro_de_Asistencia_Telefonica.Hora_fin_de_la_Llamada) <='" + filter.ToHora_fin_de_la_Llamada + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromDuracion_minutos) || !string.IsNullOrEmpty(filter.ToDuracion_minutos))
            {
                if (!string.IsNullOrEmpty(filter.FromDuracion_minutos))
                    where += " AND Registro_de_Asistencia_Telefonica.Duracion_minutos >= " + filter.FromDuracion_minutos;
                if (!string.IsNullOrEmpty(filter.ToDuracion_minutos))
                    where += " AND Registro_de_Asistencia_Telefonica.Duracion_minutos <= " + filter.ToDuracion_minutos;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceAsunto_de_la_Llamada))
            {
                switch (filter.Asunto_de_la_LlamadaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Asuntos_Asistencia_Telefonica.Descripcion LIKE '" + filter.AdvanceAsunto_de_la_Llamada + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Asuntos_Asistencia_Telefonica.Descripcion LIKE '%" + filter.AdvanceAsunto_de_la_Llamada + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Asuntos_Asistencia_Telefonica.Descripcion = '" + filter.AdvanceAsunto_de_la_Llamada + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Asuntos_Asistencia_Telefonica.Descripcion LIKE '%" + filter.AdvanceAsunto_de_la_Llamada + "%'";
                        break;
                }
            }
            else if (filter.AdvanceAsunto_de_la_LlamadaMultiple != null && filter.AdvanceAsunto_de_la_LlamadaMultiple.Count() > 0)
            {
                var Asunto_de_la_LlamadaIds = string.Join(",", filter.AdvanceAsunto_de_la_LlamadaMultiple);

                where += " AND Registro_de_Asistencia_Telefonica.Asunto_de_la_Llamada In (" + Asunto_de_la_LlamadaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceAtendio))
            {
                switch (filter.AtendioFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.AdvanceAtendio + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceAtendio + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.AdvanceAtendio + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceAtendio + "%'";
                        break;
                }
            }
            else if (filter.AdvanceAtendioMultiple != null && filter.AdvanceAtendioMultiple.Count() > 0)
            {
                var AtendioIds = string.Join(",", filter.AdvanceAtendioMultiple);

                where += " AND Registro_de_Asistencia_Telefonica.Atendio In (" + AtendioIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Comentarios))
            {
                switch (filter.ComentariosFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Registro_de_Asistencia_Telefonica.Comentarios LIKE '" + filter.Comentarios + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Registro_de_Asistencia_Telefonica.Comentarios LIKE '%" + filter.Comentarios + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Registro_de_Asistencia_Telefonica.Comentarios = '" + filter.Comentarios + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Registro_de_Asistencia_Telefonica.Comentarios LIKE '%" + filter.Comentarios + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEstatus))
            {
                switch (filter.EstatusFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estatus_Llamadas.Descripcion LIKE '" + filter.AdvanceEstatus + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estatus_Llamadas.Descripcion LIKE '%" + filter.AdvanceEstatus + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estatus_Llamadas.Descripcion = '" + filter.AdvanceEstatus + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estatus_Llamadas.Descripcion LIKE '%" + filter.AdvanceEstatus + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEstatusMultiple != null && filter.AdvanceEstatusMultiple.Count() > 0)
            {
                var EstatusIds = string.Join(",", filter.AdvanceEstatusMultiple);

                where += " AND Registro_de_Asistencia_Telefonica.Estatus In (" + EstatusIds + ")";
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
                _IRegistro_de_Asistencia_TelefonicaApiConsumer.SetAuthHeader(_tokenManager.Token);

                Registro_de_Asistencia_Telefonica varRegistro_de_Asistencia_Telefonica = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IRegistro_de_Asistencia_TelefonicaApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Registro_de_Asistencia_TelefonicaModel varRegistro_de_Asistencia_Telefonica)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IRegistro_de_Asistencia_TelefonicaApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Registro_de_Asistencia_TelefonicaInfo = new Registro_de_Asistencia_Telefonica
                    {
                        Folio = varRegistro_de_Asistencia_Telefonica.Folio
                        ,Fecha_de_llamada = (!String.IsNullOrEmpty(varRegistro_de_Asistencia_Telefonica.Fecha_de_llamada)) ? DateTime.ParseExact(varRegistro_de_Asistencia_Telefonica.Fecha_de_llamada, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_llamada = varRegistro_de_Asistencia_Telefonica.Hora_de_llamada
                        ,Usuario_que_llama = varRegistro_de_Asistencia_Telefonica.Usuario_que_llama
                        ,Dispositivo = varRegistro_de_Asistencia_Telefonica.Dispositivo
                        ,Nombre_Paciente = varRegistro_de_Asistencia_Telefonica.Nombre_Paciente
                        ,Suscripcion = varRegistro_de_Asistencia_Telefonica.Suscripcion
                        ,Numero_telefonico_del_Paciente = varRegistro_de_Asistencia_Telefonica.Numero_telefonico_del_Paciente
                        ,Correo_del_Paciente = varRegistro_de_Asistencia_Telefonica.Correo_del_Paciente
                        ,Telefono_de_Asistencia_marcado = varRegistro_de_Asistencia_Telefonica.Telefono_de_Asistencia_marcado
                        ,Hora_inicio_de_la_Llamada = varRegistro_de_Asistencia_Telefonica.Hora_inicio_de_la_Llamada
                        ,Hora_fin_de_la_Llamada = varRegistro_de_Asistencia_Telefonica.Hora_fin_de_la_Llamada
                        ,Duracion_minutos = varRegistro_de_Asistencia_Telefonica.Duracion_minutos
                        ,Asunto_de_la_Llamada = varRegistro_de_Asistencia_Telefonica.Asunto_de_la_Llamada
                        ,Atendio = varRegistro_de_Asistencia_Telefonica.Atendio
                        ,Comentarios = varRegistro_de_Asistencia_Telefonica.Comentarios
                        ,Estatus = varRegistro_de_Asistencia_Telefonica.Estatus

                    };

                    result = !IsNew ?
                        _IRegistro_de_Asistencia_TelefonicaApiConsumer.Update(Registro_de_Asistencia_TelefonicaInfo, null, null).Resource.ToString() :
                         _IRegistro_de_Asistencia_TelefonicaApiConsumer.Insert(Registro_de_Asistencia_TelefonicaInfo, null, null).Resource.ToString();
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
        /// Write Element Array of Registro_de_Asistencia_Telefonica script
        /// </summary>
        /// <param name="oRegistro_de_Asistencia_TelefonicaElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Registro_de_Asistencia_TelefonicaModuleAttributeList)
        {
            for (int i = 0; i < Registro_de_Asistencia_TelefonicaModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Registro_de_Asistencia_TelefonicaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Registro_de_Asistencia_TelefonicaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Registro_de_Asistencia_TelefonicaModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Registro_de_Asistencia_TelefonicaModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Registro_de_Asistencia_TelefonicaModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Registro_de_Asistencia_TelefonicaModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Registro_de_Asistencia_TelefonicaModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Registro_de_Asistencia_TelefonicaModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Registro_de_Asistencia_TelefonicaModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Registro_de_Asistencia_TelefonicaModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Registro_de_Asistencia_TelefonicaModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strRegistro_de_Asistencia_TelefonicaScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Registro_de_Asistencia_Telefonica.js")))
            {
                strRegistro_de_Asistencia_TelefonicaScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Registro_de_Asistencia_Telefonica element attributes
            string userChangeJson = jsSerialize.Serialize(Registro_de_Asistencia_TelefonicaModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strRegistro_de_Asistencia_TelefonicaScript.IndexOf("inpuElementArray");
            string splittedString = strRegistro_de_Asistencia_TelefonicaScript.Substring(indexOfArray, strRegistro_de_Asistencia_TelefonicaScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Registro_de_Asistencia_TelefonicaModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Registro_de_Asistencia_TelefonicaModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strRegistro_de_Asistencia_TelefonicaScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strRegistro_de_Asistencia_TelefonicaScript.Substring(indexOfArrayHistory, strRegistro_de_Asistencia_TelefonicaScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strRegistro_de_Asistencia_TelefonicaScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strRegistro_de_Asistencia_TelefonicaScript.Substring(endIndexOfMainElement + indexOfArray, strRegistro_de_Asistencia_TelefonicaScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Registro_de_Asistencia_TelefonicaModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Registro_de_Asistencia_TelefonicaModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Registro_de_Asistencia_Telefonica.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Registro_de_Asistencia_Telefonica.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Registro_de_Asistencia_Telefonica.js")))
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
        public ActionResult Registro_de_Asistencia_TelefonicaPropertyBag()
        {
            return PartialView("Registro_de_Asistencia_TelefonicaPropertyBag", "Registro_de_Asistencia_Telefonica");
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
                var whereClauseFormat = "Object = 44458 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IRegistro_de_Asistencia_TelefonicaApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Registro_de_Asistencia_Telefonica.Folio= " + RecordId;
                            var result = _IRegistro_de_Asistencia_TelefonicaApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IRegistro_de_Asistencia_TelefonicaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Registro_de_Asistencia_TelefonicaPropertyMapper());
			
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
                    (Registro_de_Asistencia_TelefonicaAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Registro_de_Asistencia_TelefonicaPropertyMapper oRegistro_de_Asistencia_TelefonicaPropertyMapper = new Registro_de_Asistencia_TelefonicaPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oRegistro_de_Asistencia_TelefonicaPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IRegistro_de_Asistencia_TelefonicaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Registro_de_Asistencia_Telefonicas == null)
                result.Registro_de_Asistencia_Telefonicas = new List<Registro_de_Asistencia_Telefonica>();

            var data = result.Registro_de_Asistencia_Telefonicas.Select(m => new Registro_de_Asistencia_TelefonicaGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_llamada = (m.Fecha_de_llamada == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_llamada).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_llamada = m.Hora_de_llamada
                        ,Usuario_que_llamaName = CultureHelper.GetTraduction(m.Usuario_que_llama_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_llama_Spartan_User.Name
			,Dispositivo = m.Dispositivo
                        ,Nombre_PacienteNombre_Completo = CultureHelper.GetTraduction(m.Nombre_Paciente_Pacientes.Folio.ToString(), "Nombre_Completo") ?? (string)m.Nombre_Paciente_Pacientes.Nombre_Completo
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Planes_de_Suscripcion") ?? (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
			,Numero_telefonico_del_Paciente = m.Numero_telefonico_del_Paciente
			,Correo_del_Paciente = m.Correo_del_Paciente
			,Telefono_de_Asistencia_marcado = m.Telefono_de_Asistencia_marcado
			,Hora_inicio_de_la_Llamada = m.Hora_inicio_de_la_Llamada
			,Hora_fin_de_la_Llamada = m.Hora_fin_de_la_Llamada
			,Duracion_minutos = m.Duracion_minutos
                        ,Asunto_de_la_LlamadaDescripcion = CultureHelper.GetTraduction(m.Asunto_de_la_Llamada_Asuntos_Asistencia_Telefonica.Clave.ToString(), "Descripcion") ?? (string)m.Asunto_de_la_Llamada_Asuntos_Asistencia_Telefonica.Descripcion
                        ,AtendioName = CultureHelper.GetTraduction(m.Atendio_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Atendio_Spartan_User.Name
			,Comentarios = m.Comentarios
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Llamadas.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Llamadas.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44458, arrayColumnsVisible), "Registro_de_Asistencia_TelefonicaList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44458, arrayColumnsVisible), "Registro_de_Asistencia_TelefonicaList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44458, arrayColumnsVisible), "Registro_de_Asistencia_TelefonicaList_" + DateTime.Now.ToString());
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

            _IRegistro_de_Asistencia_TelefonicaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Registro_de_Asistencia_TelefonicaPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Registro_de_Asistencia_TelefonicaAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Registro_de_Asistencia_TelefonicaPropertyMapper oRegistro_de_Asistencia_TelefonicaPropertyMapper = new Registro_de_Asistencia_TelefonicaPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oRegistro_de_Asistencia_TelefonicaPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IRegistro_de_Asistencia_TelefonicaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Registro_de_Asistencia_Telefonicas == null)
                result.Registro_de_Asistencia_Telefonicas = new List<Registro_de_Asistencia_Telefonica>();

            var data = result.Registro_de_Asistencia_Telefonicas.Select(m => new Registro_de_Asistencia_TelefonicaGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_llamada = (m.Fecha_de_llamada == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_llamada).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_llamada = m.Hora_de_llamada
                        ,Usuario_que_llamaName = CultureHelper.GetTraduction(m.Usuario_que_llama_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_llama_Spartan_User.Name
			,Dispositivo = m.Dispositivo
                        ,Nombre_PacienteNombre_Completo = CultureHelper.GetTraduction(m.Nombre_Paciente_Pacientes.Folio.ToString(), "Nombre_Completo") ?? (string)m.Nombre_Paciente_Pacientes.Nombre_Completo
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Planes_de_Suscripcion") ?? (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
			,Numero_telefonico_del_Paciente = m.Numero_telefonico_del_Paciente
			,Correo_del_Paciente = m.Correo_del_Paciente
			,Telefono_de_Asistencia_marcado = m.Telefono_de_Asistencia_marcado
			,Hora_inicio_de_la_Llamada = m.Hora_inicio_de_la_Llamada
			,Hora_fin_de_la_Llamada = m.Hora_fin_de_la_Llamada
			,Duracion_minutos = m.Duracion_minutos
                        ,Asunto_de_la_LlamadaDescripcion = CultureHelper.GetTraduction(m.Asunto_de_la_Llamada_Asuntos_Asistencia_Telefonica.Clave.ToString(), "Descripcion") ?? (string)m.Asunto_de_la_Llamada_Asuntos_Asistencia_Telefonica.Descripcion
                        ,AtendioName = CultureHelper.GetTraduction(m.Atendio_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Atendio_Spartan_User.Name
			,Comentarios = m.Comentarios
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Llamadas.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Llamadas.Descripcion

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
                _IRegistro_de_Asistencia_TelefonicaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRegistro_de_Asistencia_TelefonicaApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Registro_de_Asistencia_Telefonica_Datos_GeneralesModel varRegistro_de_Asistencia_Telefonica)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRegistro_de_Asistencia_TelefonicaApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Registro_de_Asistencia_Telefonica_Datos_GeneralesInfo = new Registro_de_Asistencia_Telefonica_Datos_Generales
                {
                    Folio = varRegistro_de_Asistencia_Telefonica.Folio
                                            ,Fecha_de_llamada = (!String.IsNullOrEmpty(varRegistro_de_Asistencia_Telefonica.Fecha_de_llamada)) ? DateTime.ParseExact(varRegistro_de_Asistencia_Telefonica.Fecha_de_llamada, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_llamada = varRegistro_de_Asistencia_Telefonica.Hora_de_llamada
                        ,Usuario_que_llama = varRegistro_de_Asistencia_Telefonica.Usuario_que_llama
                        ,Dispositivo = varRegistro_de_Asistencia_Telefonica.Dispositivo
                        ,Nombre_Paciente = varRegistro_de_Asistencia_Telefonica.Nombre_Paciente
                        ,Suscripcion = varRegistro_de_Asistencia_Telefonica.Suscripcion
                        ,Numero_telefonico_del_Paciente = varRegistro_de_Asistencia_Telefonica.Numero_telefonico_del_Paciente
                        ,Correo_del_Paciente = varRegistro_de_Asistencia_Telefonica.Correo_del_Paciente
                        ,Telefono_de_Asistencia_marcado = varRegistro_de_Asistencia_Telefonica.Telefono_de_Asistencia_marcado
                        ,Hora_inicio_de_la_Llamada = varRegistro_de_Asistencia_Telefonica.Hora_inicio_de_la_Llamada
                        ,Hora_fin_de_la_Llamada = varRegistro_de_Asistencia_Telefonica.Hora_fin_de_la_Llamada
                        ,Duracion_minutos = varRegistro_de_Asistencia_Telefonica.Duracion_minutos
                        ,Asunto_de_la_Llamada = varRegistro_de_Asistencia_Telefonica.Asunto_de_la_Llamada
                        ,Atendio = varRegistro_de_Asistencia_Telefonica.Atendio
                        ,Comentarios = varRegistro_de_Asistencia_Telefonica.Comentarios
                        ,Estatus = varRegistro_de_Asistencia_Telefonica.Estatus
                    
                };

                result = _IRegistro_de_Asistencia_TelefonicaApiConsumer.Update_Datos_Generales(Registro_de_Asistencia_Telefonica_Datos_GeneralesInfo).Resource.ToString();
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
                _IRegistro_de_Asistencia_TelefonicaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IRegistro_de_Asistencia_TelefonicaApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				
                var result = new Registro_de_Asistencia_Telefonica_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_llamada = (m.Fecha_de_llamada == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_llamada).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_llamada = m.Hora_de_llamada
                        ,Usuario_que_llama = m.Usuario_que_llama
                        ,Usuario_que_llamaName = CultureHelper.GetTraduction(m.Usuario_que_llama_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_llama_Spartan_User.Name
			,Dispositivo = m.Dispositivo
                        ,Nombre_Paciente = m.Nombre_Paciente
                        ,Nombre_PacienteNombre_Completo = CultureHelper.GetTraduction(m.Nombre_Paciente_Pacientes.Folio.ToString(), "Nombre_Completo") ?? (string)m.Nombre_Paciente_Pacientes.Nombre_Completo
                        ,Suscripcion = m.Suscripcion
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Planes_de_Suscripcion") ?? (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
			,Numero_telefonico_del_Paciente = m.Numero_telefonico_del_Paciente
			,Correo_del_Paciente = m.Correo_del_Paciente
			,Telefono_de_Asistencia_marcado = m.Telefono_de_Asistencia_marcado
			,Hora_inicio_de_la_Llamada = m.Hora_inicio_de_la_Llamada
			,Hora_fin_de_la_Llamada = m.Hora_fin_de_la_Llamada
			,Duracion_minutos = m.Duracion_minutos
                        ,Asunto_de_la_Llamada = m.Asunto_de_la_Llamada
                        ,Asunto_de_la_LlamadaDescripcion = CultureHelper.GetTraduction(m.Asunto_de_la_Llamada_Asuntos_Asistencia_Telefonica.Clave.ToString(), "Descripcion") ?? (string)m.Asunto_de_la_Llamada_Asuntos_Asistencia_Telefonica.Descripcion
                        ,Atendio = m.Atendio
                        ,AtendioName = CultureHelper.GetTraduction(m.Atendio_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Atendio_Spartan_User.Name
			,Comentarios = m.Comentarios
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Llamadas.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_Llamadas.Descripcion

                    
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

