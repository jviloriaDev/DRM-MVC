using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Solicitud_de_Cita_con_Especialista;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Medicos;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Calificacion;
using Spartane.Core.Domain.Motivos;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Solicitud_de_Cita_con_Especialista;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Solicitud_de_Cita_con_Especialista;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Medicos;
using Spartane.Web.Areas.WebApiConsumer.Respuesta_Logica;
using Spartane.Web.Areas.WebApiConsumer.Calificacion;
using Spartane.Web.Areas.WebApiConsumer.Motivos;

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
    public class Solicitud_de_Cita_con_EspecialistaController : Controller
    {
        #region "variable declaration"

        private ISolicitud_de_Cita_con_EspecialistaService service = null;
        private ISolicitud_de_Cita_con_EspecialistaApiConsumer _ISolicitud_de_Cita_con_EspecialistaApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IMedicosApiConsumer _IMedicosApiConsumer;
        private IRespuesta_LogicaApiConsumer _IRespuesta_LogicaApiConsumer;
        private ICalificacionApiConsumer _ICalificacionApiConsumer;
        private IMotivosApiConsumer _IMotivosApiConsumer;

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

        
        public Solicitud_de_Cita_con_EspecialistaController(ISolicitud_de_Cita_con_EspecialistaService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISolicitud_de_Cita_con_EspecialistaApiConsumer Solicitud_de_Cita_con_EspecialistaApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IMedicosApiConsumer MedicosApiConsumer , IRespuesta_LogicaApiConsumer Respuesta_LogicaApiConsumer , ICalificacionApiConsumer CalificacionApiConsumer , IMotivosApiConsumer MotivosApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISolicitud_de_Cita_con_EspecialistaApiConsumer = Solicitud_de_Cita_con_EspecialistaApiConsumer;
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
            this._IMedicosApiConsumer = MedicosApiConsumer;
            this._IRespuesta_LogicaApiConsumer = Respuesta_LogicaApiConsumer;
            this._ICalificacionApiConsumer = CalificacionApiConsumer;
            this._IMotivosApiConsumer = MotivosApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Solicitud_de_Cita_con_Especialista
        [ObjectAuth(ObjectId = (ModuleObjectId)44454, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44454, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Solicitud_de_Cita_con_Especialista/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44454, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44454, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varSolicitud_de_Cita_con_Especialista = new Solicitud_de_Cita_con_EspecialistaModel();
			varSolicitud_de_Cita_con_Especialista.Folio = Id;
			
            ViewBag.ObjectId = "44454";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _ISolicitud_de_Cita_con_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Solicitud_de_Cita_con_EspecialistasData = _ISolicitud_de_Cita_con_EspecialistaApiConsumer.ListaSelAll(0, 1000, "Solicitud_de_Cita_con_Especialista.Folio=" + Id, "").Resource.Solicitud_de_Cita_con_Especialistas;
				
				if (Solicitud_de_Cita_con_EspecialistasData != null && Solicitud_de_Cita_con_EspecialistasData.Count > 0)
                {
					var Solicitud_de_Cita_con_EspecialistaData = Solicitud_de_Cita_con_EspecialistasData.First();
					varSolicitud_de_Cita_con_Especialista= new Solicitud_de_Cita_con_EspecialistaModel
					{
						Folio  = Solicitud_de_Cita_con_EspecialistaData.Folio 
	                    ,Fecha_de_solicitud = (Solicitud_de_Cita_con_EspecialistaData.Fecha_de_solicitud == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Cita_con_EspecialistaData.Fecha_de_solicitud).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_solicitud = Solicitud_de_Cita_con_EspecialistaData.Hora_de_solicitud
                    ,Usuario_que_solicita = Solicitud_de_Cita_con_EspecialistaData.Usuario_que_solicita
                    ,Usuario_que_solicitaName = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Cita_con_EspecialistaData.Usuario_que_solicita), "Spartan_User") ??  (string)Solicitud_de_Cita_con_EspecialistaData.Usuario_que_solicita_Spartan_User.Name
                    ,Nombre_Completo = Solicitud_de_Cita_con_EspecialistaData.Nombre_Completo
                    ,Correo_del_Paciente = Solicitud_de_Cita_con_EspecialistaData.Correo_del_Paciente
                    ,Celular_del_Paciente = Solicitud_de_Cita_con_EspecialistaData.Celular_del_Paciente
                    ,Especialista = Solicitud_de_Cita_con_EspecialistaData.Especialista
                    ,EspecialistaNombre_Completo = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Cita_con_EspecialistaData.Especialista), "Medicos") ??  (string)Solicitud_de_Cita_con_EspecialistaData.Especialista_Medicos.Nombre_Completo
                    ,Correo_del_Especialista = Solicitud_de_Cita_con_EspecialistaData.Correo_del_Especialista
                    ,Correo_enviado = Solicitud_de_Cita_con_EspecialistaData.Correo_enviado.GetValueOrDefault()
                    ,Fecha_de_Retroalimentacion = (Solicitud_de_Cita_con_EspecialistaData.Fecha_de_Retroalimentacion == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Cita_con_EspecialistaData.Fecha_de_Retroalimentacion).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Retroalimentacion = Solicitud_de_Cita_con_EspecialistaData.Hora_de_Retroalimentacion
                    ,Asististe_a_tu_cita = Solicitud_de_Cita_con_EspecialistaData.Asististe_a_tu_cita
                    ,Asististe_a_tu_citaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Cita_con_EspecialistaData.Asististe_a_tu_cita), "Respuesta_Logica") ??  (string)Solicitud_de_Cita_con_EspecialistaData.Asististe_a_tu_cita_Respuesta_Logica.Descripcion
                    ,Calificacion_Especialista = Solicitud_de_Cita_con_EspecialistaData.Calificacion_Especialista
                    ,Calificacion_EspecialistaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Cita_con_EspecialistaData.Calificacion_Especialista), "Calificacion") ??  (string)Solicitud_de_Cita_con_EspecialistaData.Calificacion_Especialista_Calificacion.Descripcion
                    ,Motivo_no_concreto_cita = Solicitud_de_Cita_con_EspecialistaData.Motivo_no_concreto_cita
                    ,Motivo_no_concreto_citaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Cita_con_EspecialistaData.Motivo_no_concreto_cita), "Motivos") ??  (string)Solicitud_de_Cita_con_EspecialistaData.Motivo_no_concreto_cita_Motivos.Descripcion

					};
				}
				
				
				
            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_solicita = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_solicita != null && Spartan_Users_Usuario_que_solicita.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_solicita = Spartan_Users_Usuario_que_solicita.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Medicoss_Especialista = _IMedicosApiConsumer.SelAll(true);
            if (Medicoss_Especialista != null && Medicoss_Especialista.Resource != null)
                ViewBag.Medicoss_Especialista = Medicoss_Especialista.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Medicos", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Asististe_a_tu_cita = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Asististe_a_tu_cita != null && Respuesta_Logicas_Asististe_a_tu_cita.Resource != null)
                ViewBag.Respuesta_Logicas_Asististe_a_tu_cita = Respuesta_Logicas_Asististe_a_tu_cita.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ICalificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Calificacions_Calificacion_Especialista = _ICalificacionApiConsumer.SelAll(true);
            if (Calificacions_Calificacion_Especialista != null && Calificacions_Calificacion_Especialista.Resource != null)
                ViewBag.Calificacions_Calificacion_Especialista = Calificacions_Calificacion_Especialista.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Calificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IMotivosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Motivoss_Motivo_no_concreto_cita = _IMotivosApiConsumer.SelAll(true);
            if (Motivoss_Motivo_no_concreto_cita != null && Motivoss_Motivo_no_concreto_cita.Resource != null)
                ViewBag.Motivoss_Motivo_no_concreto_cita = Motivoss_Motivo_no_concreto_cita.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Motivos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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

				
            return View(varSolicitud_de_Cita_con_Especialista);
        }
		
	[HttpGet]
        public ActionResult AddSolicitud_de_Cita_con_Especialista(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44454);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISolicitud_de_Cita_con_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);
			Solicitud_de_Cita_con_EspecialistaModel varSolicitud_de_Cita_con_Especialista= new Solicitud_de_Cita_con_EspecialistaModel();


            if (id.ToString() != "0")
            {
                var Solicitud_de_Cita_con_EspecialistasData = _ISolicitud_de_Cita_con_EspecialistaApiConsumer.ListaSelAll(0, 1000, "Solicitud_de_Cita_con_Especialista.Folio=" + id, "").Resource.Solicitud_de_Cita_con_Especialistas;
				
				if (Solicitud_de_Cita_con_EspecialistasData != null && Solicitud_de_Cita_con_EspecialistasData.Count > 0)
                {
					var Solicitud_de_Cita_con_EspecialistaData = Solicitud_de_Cita_con_EspecialistasData.First();
					varSolicitud_de_Cita_con_Especialista= new Solicitud_de_Cita_con_EspecialistaModel
					{
						Folio  = Solicitud_de_Cita_con_EspecialistaData.Folio 
	                    ,Fecha_de_solicitud = (Solicitud_de_Cita_con_EspecialistaData.Fecha_de_solicitud == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Cita_con_EspecialistaData.Fecha_de_solicitud).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_solicitud = Solicitud_de_Cita_con_EspecialistaData.Hora_de_solicitud
                    ,Usuario_que_solicita = Solicitud_de_Cita_con_EspecialistaData.Usuario_que_solicita
                    ,Usuario_que_solicitaName = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Cita_con_EspecialistaData.Usuario_que_solicita), "Spartan_User") ??  (string)Solicitud_de_Cita_con_EspecialistaData.Usuario_que_solicita_Spartan_User.Name
                    ,Nombre_Completo = Solicitud_de_Cita_con_EspecialistaData.Nombre_Completo
                    ,Correo_del_Paciente = Solicitud_de_Cita_con_EspecialistaData.Correo_del_Paciente
                    ,Celular_del_Paciente = Solicitud_de_Cita_con_EspecialistaData.Celular_del_Paciente
                    ,Especialista = Solicitud_de_Cita_con_EspecialistaData.Especialista
                    ,EspecialistaNombre_Completo = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Cita_con_EspecialistaData.Especialista), "Medicos") ??  (string)Solicitud_de_Cita_con_EspecialistaData.Especialista_Medicos.Nombre_Completo
                    ,Correo_del_Especialista = Solicitud_de_Cita_con_EspecialistaData.Correo_del_Especialista
                    ,Correo_enviado = Solicitud_de_Cita_con_EspecialistaData.Correo_enviado.GetValueOrDefault()
                    ,Fecha_de_Retroalimentacion = (Solicitud_de_Cita_con_EspecialistaData.Fecha_de_Retroalimentacion == null ? string.Empty : Convert.ToDateTime(Solicitud_de_Cita_con_EspecialistaData.Fecha_de_Retroalimentacion).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Retroalimentacion = Solicitud_de_Cita_con_EspecialistaData.Hora_de_Retroalimentacion
                    ,Asististe_a_tu_cita = Solicitud_de_Cita_con_EspecialistaData.Asististe_a_tu_cita
                    ,Asististe_a_tu_citaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Cita_con_EspecialistaData.Asististe_a_tu_cita), "Respuesta_Logica") ??  (string)Solicitud_de_Cita_con_EspecialistaData.Asististe_a_tu_cita_Respuesta_Logica.Descripcion
                    ,Calificacion_Especialista = Solicitud_de_Cita_con_EspecialistaData.Calificacion_Especialista
                    ,Calificacion_EspecialistaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Cita_con_EspecialistaData.Calificacion_Especialista), "Calificacion") ??  (string)Solicitud_de_Cita_con_EspecialistaData.Calificacion_Especialista_Calificacion.Descripcion
                    ,Motivo_no_concreto_cita = Solicitud_de_Cita_con_EspecialistaData.Motivo_no_concreto_cita
                    ,Motivo_no_concreto_citaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Solicitud_de_Cita_con_EspecialistaData.Motivo_no_concreto_cita), "Motivos") ??  (string)Solicitud_de_Cita_con_EspecialistaData.Motivo_no_concreto_cita_Motivos.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_solicita = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_solicita != null && Spartan_Users_Usuario_que_solicita.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_solicita = Spartan_Users_Usuario_que_solicita.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Medicoss_Especialista = _IMedicosApiConsumer.SelAll(true);
            if (Medicoss_Especialista != null && Medicoss_Especialista.Resource != null)
                ViewBag.Medicoss_Especialista = Medicoss_Especialista.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Medicos", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Asististe_a_tu_cita = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Asististe_a_tu_cita != null && Respuesta_Logicas_Asististe_a_tu_cita.Resource != null)
                ViewBag.Respuesta_Logicas_Asististe_a_tu_cita = Respuesta_Logicas_Asististe_a_tu_cita.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ICalificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Calificacions_Calificacion_Especialista = _ICalificacionApiConsumer.SelAll(true);
            if (Calificacions_Calificacion_Especialista != null && Calificacions_Calificacion_Especialista.Resource != null)
                ViewBag.Calificacions_Calificacion_Especialista = Calificacions_Calificacion_Especialista.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Calificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IMotivosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Motivoss_Motivo_no_concreto_cita = _IMotivosApiConsumer.SelAll(true);
            if (Motivoss_Motivo_no_concreto_cita != null && Motivoss_Motivo_no_concreto_cita.Resource != null)
                ViewBag.Motivoss_Motivo_no_concreto_cita = Motivoss_Motivo_no_concreto_cita.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Motivos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddSolicitud_de_Cita_con_Especialista", varSolicitud_de_Cita_con_Especialista);
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
        public ActionResult GetMedicosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IMedicosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Medicos", "Nombre_Completo")?? m.Nombre_Completo,
                    Value = Convert.ToString(m.Folio)
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
        public ActionResult GetCalificacionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ICalificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ICalificacionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Calificacion", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetMotivosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMotivosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IMotivosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Motivos", "Descripcion")?? m.Descripcion,
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
        public ActionResult ShowAdvanceFilter(Solicitud_de_Cita_con_EspecialistaAdvanceSearchModel model, int idFilter = -1)
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
            var Spartan_Users_Usuario_que_solicita = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_solicita != null && Spartan_Users_Usuario_que_solicita.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_solicita = Spartan_Users_Usuario_que_solicita.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Medicoss_Especialista = _IMedicosApiConsumer.SelAll(true);
            if (Medicoss_Especialista != null && Medicoss_Especialista.Resource != null)
                ViewBag.Medicoss_Especialista = Medicoss_Especialista.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Medicos", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Asististe_a_tu_cita = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Asististe_a_tu_cita != null && Respuesta_Logicas_Asististe_a_tu_cita.Resource != null)
                ViewBag.Respuesta_Logicas_Asististe_a_tu_cita = Respuesta_Logicas_Asististe_a_tu_cita.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ICalificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Calificacions_Calificacion_Especialista = _ICalificacionApiConsumer.SelAll(true);
            if (Calificacions_Calificacion_Especialista != null && Calificacions_Calificacion_Especialista.Resource != null)
                ViewBag.Calificacions_Calificacion_Especialista = Calificacions_Calificacion_Especialista.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Calificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IMotivosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Motivoss_Motivo_no_concreto_cita = _IMotivosApiConsumer.SelAll(true);
            if (Motivoss_Motivo_no_concreto_cita != null && Motivoss_Motivo_no_concreto_cita.Resource != null)
                ViewBag.Motivoss_Motivo_no_concreto_cita = Motivoss_Motivo_no_concreto_cita.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Motivos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_solicita = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_solicita != null && Spartan_Users_Usuario_que_solicita.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_solicita = Spartan_Users_Usuario_que_solicita.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Medicoss_Especialista = _IMedicosApiConsumer.SelAll(true);
            if (Medicoss_Especialista != null && Medicoss_Especialista.Resource != null)
                ViewBag.Medicoss_Especialista = Medicoss_Especialista.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Medicos", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Asististe_a_tu_cita = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Asististe_a_tu_cita != null && Respuesta_Logicas_Asististe_a_tu_cita.Resource != null)
                ViewBag.Respuesta_Logicas_Asististe_a_tu_cita = Respuesta_Logicas_Asististe_a_tu_cita.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ICalificacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Calificacions_Calificacion_Especialista = _ICalificacionApiConsumer.SelAll(true);
            if (Calificacions_Calificacion_Especialista != null && Calificacions_Calificacion_Especialista.Resource != null)
                ViewBag.Calificacions_Calificacion_Especialista = Calificacions_Calificacion_Especialista.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Calificacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IMotivosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Motivoss_Motivo_no_concreto_cita = _IMotivosApiConsumer.SelAll(true);
            if (Motivoss_Motivo_no_concreto_cita != null && Motivoss_Motivo_no_concreto_cita.Resource != null)
                ViewBag.Motivoss_Motivo_no_concreto_cita = Motivoss_Motivo_no_concreto_cita.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Motivos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            var previousFiltersObj = new Solicitud_de_Cita_con_EspecialistaAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Solicitud_de_Cita_con_EspecialistaAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Solicitud_de_Cita_con_EspecialistaAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Solicitud_de_Cita_con_EspecialistaPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISolicitud_de_Cita_con_EspecialistaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Solicitud_de_Cita_con_Especialistas == null)
                result.Solicitud_de_Cita_con_Especialistas = new List<Solicitud_de_Cita_con_Especialista>();

            return Json(new
            {
                data = result.Solicitud_de_Cita_con_Especialistas.Select(m => new Solicitud_de_Cita_con_EspecialistaGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_solicitud = (m.Fecha_de_solicitud == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_solicitud).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_solicitud = m.Hora_de_solicitud
                        ,Usuario_que_solicitaName = CultureHelper.GetTraduction(m.Usuario_que_solicita_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_solicita_Spartan_User.Name
			,Nombre_Completo = m.Nombre_Completo
			,Correo_del_Paciente = m.Correo_del_Paciente
			,Celular_del_Paciente = m.Celular_del_Paciente
                        ,EspecialistaNombre_Completo = CultureHelper.GetTraduction(m.Especialista_Medicos.Folio.ToString(), "Nombre_Completo") ?? (string)m.Especialista_Medicos.Nombre_Completo
			,Correo_del_Especialista = m.Correo_del_Especialista
			,Correo_enviado = m.Correo_enviado
                        ,Fecha_de_Retroalimentacion = (m.Fecha_de_Retroalimentacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Retroalimentacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Retroalimentacion = m.Hora_de_Retroalimentacion
                        ,Asististe_a_tu_citaDescripcion = CultureHelper.GetTraduction(m.Asististe_a_tu_cita_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Asististe_a_tu_cita_Respuesta_Logica.Descripcion
                        ,Calificacion_EspecialistaDescripcion = CultureHelper.GetTraduction(m.Calificacion_Especialista_Calificacion.Clave.ToString(), "Descripcion") ?? (string)m.Calificacion_Especialista_Calificacion.Descripcion
                        ,Motivo_no_concreto_citaDescripcion = CultureHelper.GetTraduction(m.Motivo_no_concreto_cita_Motivos.Clave.ToString(), "Descripcion") ?? (string)m.Motivo_no_concreto_cita_Motivos.Descripcion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetSolicitud_de_Cita_con_EspecialistaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISolicitud_de_Cita_con_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISolicitud_de_Cita_con_EspecialistaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Solicitud_de_Cita_con_Especialista", m.),
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
        /// Get List of Solicitud_de_Cita_con_Especialista from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Solicitud_de_Cita_con_Especialista Entity</returns>
        public ActionResult GetSolicitud_de_Cita_con_EspecialistaList(UrlParametersModel param)
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
            _ISolicitud_de_Cita_con_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Solicitud_de_Cita_con_EspecialistaPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(Solicitud_de_Cita_con_EspecialistaAdvanceSearchModel))
                {
					var advanceFilter =
                    (Solicitud_de_Cita_con_EspecialistaAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Solicitud_de_Cita_con_EspecialistaPropertyMapper oSolicitud_de_Cita_con_EspecialistaPropertyMapper = new Solicitud_de_Cita_con_EspecialistaPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oSolicitud_de_Cita_con_EspecialistaPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISolicitud_de_Cita_con_EspecialistaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Solicitud_de_Cita_con_Especialistas == null)
                result.Solicitud_de_Cita_con_Especialistas = new List<Solicitud_de_Cita_con_Especialista>();

            return Json(new
            {
                aaData = result.Solicitud_de_Cita_con_Especialistas.Select(m => new Solicitud_de_Cita_con_EspecialistaGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_solicitud = (m.Fecha_de_solicitud == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_solicitud).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_solicitud = m.Hora_de_solicitud
                        ,Usuario_que_solicitaName = CultureHelper.GetTraduction(m.Usuario_que_solicita_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_solicita_Spartan_User.Name
			,Nombre_Completo = m.Nombre_Completo
			,Correo_del_Paciente = m.Correo_del_Paciente
			,Celular_del_Paciente = m.Celular_del_Paciente
                        ,EspecialistaNombre_Completo = CultureHelper.GetTraduction(m.Especialista_Medicos.Folio.ToString(), "Nombre_Completo") ?? (string)m.Especialista_Medicos.Nombre_Completo
			,Correo_del_Especialista = m.Correo_del_Especialista
			,Correo_enviado = m.Correo_enviado
                        ,Fecha_de_Retroalimentacion = (m.Fecha_de_Retroalimentacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Retroalimentacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Retroalimentacion = m.Hora_de_Retroalimentacion
                        ,Asististe_a_tu_citaDescripcion = CultureHelper.GetTraduction(m.Asististe_a_tu_cita_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Asististe_a_tu_cita_Respuesta_Logica.Descripcion
                        ,Calificacion_EspecialistaDescripcion = CultureHelper.GetTraduction(m.Calificacion_Especialista_Calificacion.Clave.ToString(), "Descripcion") ?? (string)m.Calificacion_Especialista_Calificacion.Descripcion
                        ,Motivo_no_concreto_citaDescripcion = CultureHelper.GetTraduction(m.Motivo_no_concreto_cita_Motivos.Clave.ToString(), "Descripcion") ?? (string)m.Motivo_no_concreto_cita_Motivos.Descripcion

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(Solicitud_de_Cita_con_EspecialistaAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Solicitud_de_Cita_con_Especialista.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Solicitud_de_Cita_con_Especialista.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_solicitud) || !string.IsNullOrEmpty(filter.ToFecha_de_solicitud))
            {
                var Fecha_de_solicitudFrom = DateTime.ParseExact(filter.FromFecha_de_solicitud, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_solicitudTo = DateTime.ParseExact(filter.ToFecha_de_solicitud, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_solicitud))
                    where += " AND Solicitud_de_Cita_con_Especialista.Fecha_de_solicitud >= '" + Fecha_de_solicitudFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_solicitud))
                    where += " AND Solicitud_de_Cita_con_Especialista.Fecha_de_solicitud <= '" + Fecha_de_solicitudTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_solicitud) || !string.IsNullOrEmpty(filter.ToHora_de_solicitud))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_solicitud))
                    where += " AND Convert(TIME,Solicitud_de_Cita_con_Especialista.Hora_de_solicitud) >='" + filter.FromHora_de_solicitud + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_solicitud))
                    where += " AND Convert(TIME,Solicitud_de_Cita_con_Especialista.Hora_de_solicitud) <='" + filter.ToHora_de_solicitud + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceUsuario_que_solicita))
            {
                switch (filter.Usuario_que_solicitaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.AdvanceUsuario_que_solicita + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_que_solicita + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.AdvanceUsuario_que_solicita + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_que_solicita + "%'";
                        break;
                }
            }
            else if (filter.AdvanceUsuario_que_solicitaMultiple != null && filter.AdvanceUsuario_que_solicitaMultiple.Count() > 0)
            {
                var Usuario_que_solicitaIds = string.Join(",", filter.AdvanceUsuario_que_solicitaMultiple);

                where += " AND Solicitud_de_Cita_con_Especialista.Usuario_que_solicita In (" + Usuario_que_solicitaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombre_Completo))
            {
                switch (filter.Nombre_CompletoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Solicitud_de_Cita_con_Especialista.Nombre_Completo LIKE '" + filter.Nombre_Completo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Solicitud_de_Cita_con_Especialista.Nombre_Completo LIKE '%" + filter.Nombre_Completo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Solicitud_de_Cita_con_Especialista.Nombre_Completo = '" + filter.Nombre_Completo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Solicitud_de_Cita_con_Especialista.Nombre_Completo LIKE '%" + filter.Nombre_Completo + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Correo_del_Paciente))
            {
                switch (filter.Correo_del_PacienteFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Solicitud_de_Cita_con_Especialista.Correo_del_Paciente LIKE '" + filter.Correo_del_Paciente + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Solicitud_de_Cita_con_Especialista.Correo_del_Paciente LIKE '%" + filter.Correo_del_Paciente + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Solicitud_de_Cita_con_Especialista.Correo_del_Paciente = '" + filter.Correo_del_Paciente + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Solicitud_de_Cita_con_Especialista.Correo_del_Paciente LIKE '%" + filter.Correo_del_Paciente + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Celular_del_Paciente))
            {
                switch (filter.Celular_del_PacienteFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Solicitud_de_Cita_con_Especialista.Celular_del_Paciente LIKE '" + filter.Celular_del_Paciente + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Solicitud_de_Cita_con_Especialista.Celular_del_Paciente LIKE '%" + filter.Celular_del_Paciente + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Solicitud_de_Cita_con_Especialista.Celular_del_Paciente = '" + filter.Celular_del_Paciente + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Solicitud_de_Cita_con_Especialista.Celular_del_Paciente LIKE '%" + filter.Celular_del_Paciente + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEspecialista))
            {
                switch (filter.EspecialistaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Medicos.Nombre_Completo LIKE '" + filter.AdvanceEspecialista + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Medicos.Nombre_Completo LIKE '%" + filter.AdvanceEspecialista + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Medicos.Nombre_Completo = '" + filter.AdvanceEspecialista + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Medicos.Nombre_Completo LIKE '%" + filter.AdvanceEspecialista + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEspecialistaMultiple != null && filter.AdvanceEspecialistaMultiple.Count() > 0)
            {
                var EspecialistaIds = string.Join(",", filter.AdvanceEspecialistaMultiple);

                where += " AND Solicitud_de_Cita_con_Especialista.Especialista In (" + EspecialistaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Correo_del_Especialista))
            {
                switch (filter.Correo_del_EspecialistaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Solicitud_de_Cita_con_Especialista.Correo_del_Especialista LIKE '" + filter.Correo_del_Especialista + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Solicitud_de_Cita_con_Especialista.Correo_del_Especialista LIKE '%" + filter.Correo_del_Especialista + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Solicitud_de_Cita_con_Especialista.Correo_del_Especialista = '" + filter.Correo_del_Especialista + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Solicitud_de_Cita_con_Especialista.Correo_del_Especialista LIKE '%" + filter.Correo_del_Especialista + "%'";
                        break;
                }
            }

            if (filter.Correo_enviado != RadioOptions.NoApply)
                where += " AND Solicitud_de_Cita_con_Especialista.Correo_enviado = " + Convert.ToInt32(filter.Correo_enviado);

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Retroalimentacion) || !string.IsNullOrEmpty(filter.ToFecha_de_Retroalimentacion))
            {
                var Fecha_de_RetroalimentacionFrom = DateTime.ParseExact(filter.FromFecha_de_Retroalimentacion, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RetroalimentacionTo = DateTime.ParseExact(filter.ToFecha_de_Retroalimentacion, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Retroalimentacion))
                    where += " AND Solicitud_de_Cita_con_Especialista.Fecha_de_Retroalimentacion >= '" + Fecha_de_RetroalimentacionFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Retroalimentacion))
                    where += " AND Solicitud_de_Cita_con_Especialista.Fecha_de_Retroalimentacion <= '" + Fecha_de_RetroalimentacionTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Retroalimentacion) || !string.IsNullOrEmpty(filter.ToHora_de_Retroalimentacion))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Retroalimentacion))
                    where += " AND Convert(TIME,Solicitud_de_Cita_con_Especialista.Hora_de_Retroalimentacion) >='" + filter.FromHora_de_Retroalimentacion + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Retroalimentacion))
                    where += " AND Convert(TIME,Solicitud_de_Cita_con_Especialista.Hora_de_Retroalimentacion) <='" + filter.ToHora_de_Retroalimentacion + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceAsististe_a_tu_cita))
            {
                switch (filter.Asististe_a_tu_citaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '" + filter.AdvanceAsististe_a_tu_cita + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceAsististe_a_tu_cita + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Respuesta_Logica.Descripcion = '" + filter.AdvanceAsististe_a_tu_cita + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Respuesta_Logica.Descripcion LIKE '%" + filter.AdvanceAsististe_a_tu_cita + "%'";
                        break;
                }
            }
            else if (filter.AdvanceAsististe_a_tu_citaMultiple != null && filter.AdvanceAsististe_a_tu_citaMultiple.Count() > 0)
            {
                var Asististe_a_tu_citaIds = string.Join(",", filter.AdvanceAsististe_a_tu_citaMultiple);

                where += " AND Solicitud_de_Cita_con_Especialista.Asististe_a_tu_cita In (" + Asististe_a_tu_citaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceCalificacion_Especialista))
            {
                switch (filter.Calificacion_EspecialistaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Calificacion.Descripcion LIKE '" + filter.AdvanceCalificacion_Especialista + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Calificacion.Descripcion LIKE '%" + filter.AdvanceCalificacion_Especialista + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Calificacion.Descripcion = '" + filter.AdvanceCalificacion_Especialista + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Calificacion.Descripcion LIKE '%" + filter.AdvanceCalificacion_Especialista + "%'";
                        break;
                }
            }
            else if (filter.AdvanceCalificacion_EspecialistaMultiple != null && filter.AdvanceCalificacion_EspecialistaMultiple.Count() > 0)
            {
                var Calificacion_EspecialistaIds = string.Join(",", filter.AdvanceCalificacion_EspecialistaMultiple);

                where += " AND Solicitud_de_Cita_con_Especialista.Calificacion_Especialista In (" + Calificacion_EspecialistaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceMotivo_no_concreto_cita))
            {
                switch (filter.Motivo_no_concreto_citaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Motivos.Descripcion LIKE '" + filter.AdvanceMotivo_no_concreto_cita + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Motivos.Descripcion LIKE '%" + filter.AdvanceMotivo_no_concreto_cita + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Motivos.Descripcion = '" + filter.AdvanceMotivo_no_concreto_cita + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Motivos.Descripcion LIKE '%" + filter.AdvanceMotivo_no_concreto_cita + "%'";
                        break;
                }
            }
            else if (filter.AdvanceMotivo_no_concreto_citaMultiple != null && filter.AdvanceMotivo_no_concreto_citaMultiple.Count() > 0)
            {
                var Motivo_no_concreto_citaIds = string.Join(",", filter.AdvanceMotivo_no_concreto_citaMultiple);

                where += " AND Solicitud_de_Cita_con_Especialista.Motivo_no_concreto_cita In (" + Motivo_no_concreto_citaIds + ")";
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
                _ISolicitud_de_Cita_con_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);

                Solicitud_de_Cita_con_Especialista varSolicitud_de_Cita_con_Especialista = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _ISolicitud_de_Cita_con_EspecialistaApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Solicitud_de_Cita_con_EspecialistaModel varSolicitud_de_Cita_con_Especialista)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISolicitud_de_Cita_con_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Solicitud_de_Cita_con_EspecialistaInfo = new Solicitud_de_Cita_con_Especialista
                    {
                        Folio = varSolicitud_de_Cita_con_Especialista.Folio
                        ,Fecha_de_solicitud = (!String.IsNullOrEmpty(varSolicitud_de_Cita_con_Especialista.Fecha_de_solicitud)) ? DateTime.ParseExact(varSolicitud_de_Cita_con_Especialista.Fecha_de_solicitud, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_solicitud = varSolicitud_de_Cita_con_Especialista.Hora_de_solicitud
                        ,Usuario_que_solicita = varSolicitud_de_Cita_con_Especialista.Usuario_que_solicita
                        ,Nombre_Completo = varSolicitud_de_Cita_con_Especialista.Nombre_Completo
                        ,Correo_del_Paciente = varSolicitud_de_Cita_con_Especialista.Correo_del_Paciente
                        ,Celular_del_Paciente = varSolicitud_de_Cita_con_Especialista.Celular_del_Paciente
                        ,Especialista = varSolicitud_de_Cita_con_Especialista.Especialista
                        ,Correo_del_Especialista = varSolicitud_de_Cita_con_Especialista.Correo_del_Especialista
                        ,Correo_enviado = varSolicitud_de_Cita_con_Especialista.Correo_enviado
                        ,Fecha_de_Retroalimentacion = (!String.IsNullOrEmpty(varSolicitud_de_Cita_con_Especialista.Fecha_de_Retroalimentacion)) ? DateTime.ParseExact(varSolicitud_de_Cita_con_Especialista.Fecha_de_Retroalimentacion, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Retroalimentacion = varSolicitud_de_Cita_con_Especialista.Hora_de_Retroalimentacion
                        ,Asististe_a_tu_cita = varSolicitud_de_Cita_con_Especialista.Asististe_a_tu_cita
                        ,Calificacion_Especialista = varSolicitud_de_Cita_con_Especialista.Calificacion_Especialista
                        ,Motivo_no_concreto_cita = varSolicitud_de_Cita_con_Especialista.Motivo_no_concreto_cita

                    };

                    result = !IsNew ?
                        _ISolicitud_de_Cita_con_EspecialistaApiConsumer.Update(Solicitud_de_Cita_con_EspecialistaInfo, null, null).Resource.ToString() :
                         _ISolicitud_de_Cita_con_EspecialistaApiConsumer.Insert(Solicitud_de_Cita_con_EspecialistaInfo, null, null).Resource.ToString();
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
        /// Write Element Array of Solicitud_de_Cita_con_Especialista script
        /// </summary>
        /// <param name="oSolicitud_de_Cita_con_EspecialistaElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Solicitud_de_Cita_con_EspecialistaModuleAttributeList)
        {
            for (int i = 0; i < Solicitud_de_Cita_con_EspecialistaModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Solicitud_de_Cita_con_EspecialistaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Solicitud_de_Cita_con_EspecialistaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Solicitud_de_Cita_con_EspecialistaModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Solicitud_de_Cita_con_EspecialistaModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Solicitud_de_Cita_con_EspecialistaModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Solicitud_de_Cita_con_EspecialistaModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Solicitud_de_Cita_con_EspecialistaModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Solicitud_de_Cita_con_EspecialistaModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Solicitud_de_Cita_con_EspecialistaModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Solicitud_de_Cita_con_EspecialistaModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Solicitud_de_Cita_con_EspecialistaModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strSolicitud_de_Cita_con_EspecialistaScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Solicitud_de_Cita_con_Especialista.js")))
            {
                strSolicitud_de_Cita_con_EspecialistaScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Solicitud_de_Cita_con_Especialista element attributes
            string userChangeJson = jsSerialize.Serialize(Solicitud_de_Cita_con_EspecialistaModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSolicitud_de_Cita_con_EspecialistaScript.IndexOf("inpuElementArray");
            string splittedString = strSolicitud_de_Cita_con_EspecialistaScript.Substring(indexOfArray, strSolicitud_de_Cita_con_EspecialistaScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Solicitud_de_Cita_con_EspecialistaModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Solicitud_de_Cita_con_EspecialistaModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSolicitud_de_Cita_con_EspecialistaScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strSolicitud_de_Cita_con_EspecialistaScript.Substring(indexOfArrayHistory, strSolicitud_de_Cita_con_EspecialistaScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strSolicitud_de_Cita_con_EspecialistaScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSolicitud_de_Cita_con_EspecialistaScript.Substring(endIndexOfMainElement + indexOfArray, strSolicitud_de_Cita_con_EspecialistaScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Solicitud_de_Cita_con_EspecialistaModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Solicitud_de_Cita_con_EspecialistaModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Solicitud_de_Cita_con_Especialista.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Solicitud_de_Cita_con_Especialista.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Solicitud_de_Cita_con_Especialista.js")))
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
        public ActionResult Solicitud_de_Cita_con_EspecialistaPropertyBag()
        {
            return PartialView("Solicitud_de_Cita_con_EspecialistaPropertyBag", "Solicitud_de_Cita_con_Especialista");
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
                var whereClauseFormat = "Object = 44454 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _ISolicitud_de_Cita_con_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Solicitud_de_Cita_con_Especialista.Folio= " + RecordId;
                            var result = _ISolicitud_de_Cita_con_EspecialistaApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _ISolicitud_de_Cita_con_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Solicitud_de_Cita_con_EspecialistaPropertyMapper());
			
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
                    (Solicitud_de_Cita_con_EspecialistaAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Solicitud_de_Cita_con_EspecialistaPropertyMapper oSolicitud_de_Cita_con_EspecialistaPropertyMapper = new Solicitud_de_Cita_con_EspecialistaPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oSolicitud_de_Cita_con_EspecialistaPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISolicitud_de_Cita_con_EspecialistaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Solicitud_de_Cita_con_Especialistas == null)
                result.Solicitud_de_Cita_con_Especialistas = new List<Solicitud_de_Cita_con_Especialista>();

            var data = result.Solicitud_de_Cita_con_Especialistas.Select(m => new Solicitud_de_Cita_con_EspecialistaGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_solicitud = (m.Fecha_de_solicitud == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_solicitud).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_solicitud = m.Hora_de_solicitud
                        ,Usuario_que_solicitaName = CultureHelper.GetTraduction(m.Usuario_que_solicita_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_solicita_Spartan_User.Name
			,Nombre_Completo = m.Nombre_Completo
			,Correo_del_Paciente = m.Correo_del_Paciente
			,Celular_del_Paciente = m.Celular_del_Paciente
                        ,EspecialistaNombre_Completo = CultureHelper.GetTraduction(m.Especialista_Medicos.Folio.ToString(), "Nombre_Completo") ?? (string)m.Especialista_Medicos.Nombre_Completo
			,Correo_del_Especialista = m.Correo_del_Especialista
			,Correo_enviado = m.Correo_enviado
                        ,Fecha_de_Retroalimentacion = (m.Fecha_de_Retroalimentacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Retroalimentacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Retroalimentacion = m.Hora_de_Retroalimentacion
                        ,Asististe_a_tu_citaDescripcion = CultureHelper.GetTraduction(m.Asististe_a_tu_cita_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Asististe_a_tu_cita_Respuesta_Logica.Descripcion
                        ,Calificacion_EspecialistaDescripcion = CultureHelper.GetTraduction(m.Calificacion_Especialista_Calificacion.Clave.ToString(), "Descripcion") ?? (string)m.Calificacion_Especialista_Calificacion.Descripcion
                        ,Motivo_no_concreto_citaDescripcion = CultureHelper.GetTraduction(m.Motivo_no_concreto_cita_Motivos.Clave.ToString(), "Descripcion") ?? (string)m.Motivo_no_concreto_cita_Motivos.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44454, arrayColumnsVisible), "Solicitud_de_Cita_con_EspecialistaList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44454, arrayColumnsVisible), "Solicitud_de_Cita_con_EspecialistaList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44454, arrayColumnsVisible), "Solicitud_de_Cita_con_EspecialistaList_" + DateTime.Now.ToString());
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

            _ISolicitud_de_Cita_con_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Solicitud_de_Cita_con_EspecialistaPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Solicitud_de_Cita_con_EspecialistaAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Solicitud_de_Cita_con_EspecialistaPropertyMapper oSolicitud_de_Cita_con_EspecialistaPropertyMapper = new Solicitud_de_Cita_con_EspecialistaPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oSolicitud_de_Cita_con_EspecialistaPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISolicitud_de_Cita_con_EspecialistaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Solicitud_de_Cita_con_Especialistas == null)
                result.Solicitud_de_Cita_con_Especialistas = new List<Solicitud_de_Cita_con_Especialista>();

            var data = result.Solicitud_de_Cita_con_Especialistas.Select(m => new Solicitud_de_Cita_con_EspecialistaGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_solicitud = (m.Fecha_de_solicitud == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_solicitud).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_solicitud = m.Hora_de_solicitud
                        ,Usuario_que_solicitaName = CultureHelper.GetTraduction(m.Usuario_que_solicita_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_solicita_Spartan_User.Name
			,Nombre_Completo = m.Nombre_Completo
			,Correo_del_Paciente = m.Correo_del_Paciente
			,Celular_del_Paciente = m.Celular_del_Paciente
                        ,EspecialistaNombre_Completo = CultureHelper.GetTraduction(m.Especialista_Medicos.Folio.ToString(), "Nombre_Completo") ?? (string)m.Especialista_Medicos.Nombre_Completo
			,Correo_del_Especialista = m.Correo_del_Especialista
			,Correo_enviado = m.Correo_enviado
                        ,Fecha_de_Retroalimentacion = (m.Fecha_de_Retroalimentacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Retroalimentacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Retroalimentacion = m.Hora_de_Retroalimentacion
                        ,Asististe_a_tu_citaDescripcion = CultureHelper.GetTraduction(m.Asististe_a_tu_cita_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Asististe_a_tu_cita_Respuesta_Logica.Descripcion
                        ,Calificacion_EspecialistaDescripcion = CultureHelper.GetTraduction(m.Calificacion_Especialista_Calificacion.Clave.ToString(), "Descripcion") ?? (string)m.Calificacion_Especialista_Calificacion.Descripcion
                        ,Motivo_no_concreto_citaDescripcion = CultureHelper.GetTraduction(m.Motivo_no_concreto_cita_Motivos.Clave.ToString(), "Descripcion") ?? (string)m.Motivo_no_concreto_cita_Motivos.Descripcion

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
                _ISolicitud_de_Cita_con_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISolicitud_de_Cita_con_EspecialistaApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Solicitud_de_Cita_con_Especialista_Datos_GeneralesModel varSolicitud_de_Cita_con_Especialista)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISolicitud_de_Cita_con_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Solicitud_de_Cita_con_Especialista_Datos_GeneralesInfo = new Solicitud_de_Cita_con_Especialista_Datos_Generales
                {
                    Folio = varSolicitud_de_Cita_con_Especialista.Folio
                                            ,Fecha_de_solicitud = (!String.IsNullOrEmpty(varSolicitud_de_Cita_con_Especialista.Fecha_de_solicitud)) ? DateTime.ParseExact(varSolicitud_de_Cita_con_Especialista.Fecha_de_solicitud, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_solicitud = varSolicitud_de_Cita_con_Especialista.Hora_de_solicitud
                        ,Usuario_que_solicita = varSolicitud_de_Cita_con_Especialista.Usuario_que_solicita
                        ,Nombre_Completo = varSolicitud_de_Cita_con_Especialista.Nombre_Completo
                        ,Correo_del_Paciente = varSolicitud_de_Cita_con_Especialista.Correo_del_Paciente
                        ,Celular_del_Paciente = varSolicitud_de_Cita_con_Especialista.Celular_del_Paciente
                        ,Especialista = varSolicitud_de_Cita_con_Especialista.Especialista
                        ,Correo_del_Especialista = varSolicitud_de_Cita_con_Especialista.Correo_del_Especialista
                        ,Correo_enviado = varSolicitud_de_Cita_con_Especialista.Correo_enviado
                    
                };

                result = _ISolicitud_de_Cita_con_EspecialistaApiConsumer.Update_Datos_Generales(Solicitud_de_Cita_con_Especialista_Datos_GeneralesInfo).Resource.ToString();
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
                _ISolicitud_de_Cita_con_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _ISolicitud_de_Cita_con_EspecialistaApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				
                var result = new Solicitud_de_Cita_con_Especialista_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_solicitud = (m.Fecha_de_solicitud == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_solicitud).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_solicitud = m.Hora_de_solicitud
                        ,Usuario_que_solicita = m.Usuario_que_solicita
                        ,Usuario_que_solicitaName = CultureHelper.GetTraduction(m.Usuario_que_solicita_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_solicita_Spartan_User.Name
			,Nombre_Completo = m.Nombre_Completo
			,Correo_del_Paciente = m.Correo_del_Paciente
			,Celular_del_Paciente = m.Celular_del_Paciente
                        ,Especialista = m.Especialista
                        ,EspecialistaNombre_Completo = CultureHelper.GetTraduction(m.Especialista_Medicos.Folio.ToString(), "Nombre_Completo") ?? (string)m.Especialista_Medicos.Nombre_Completo
			,Correo_del_Especialista = m.Correo_del_Especialista
			,Correo_enviado = m.Correo_enviado

                    
                };
				var resultData = new
                {
                    data = result

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Solicitud(Solicitud_de_Cita_con_Especialista_SolicitudModel varSolicitud_de_Cita_con_Especialista)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISolicitud_de_Cita_con_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Solicitud_de_Cita_con_Especialista_SolicitudInfo = new Solicitud_de_Cita_con_Especialista_Solicitud
                {
                    Folio = varSolicitud_de_Cita_con_Especialista.Folio
                                            ,Fecha_de_Retroalimentacion = (!String.IsNullOrEmpty(varSolicitud_de_Cita_con_Especialista.Fecha_de_Retroalimentacion)) ? DateTime.ParseExact(varSolicitud_de_Cita_con_Especialista.Fecha_de_Retroalimentacion, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Retroalimentacion = varSolicitud_de_Cita_con_Especialista.Hora_de_Retroalimentacion
                        ,Asististe_a_tu_cita = varSolicitud_de_Cita_con_Especialista.Asististe_a_tu_cita
                        ,Calificacion_Especialista = varSolicitud_de_Cita_con_Especialista.Calificacion_Especialista
                        ,Motivo_no_concreto_cita = varSolicitud_de_Cita_con_Especialista.Motivo_no_concreto_cita
                    
                };

                result = _ISolicitud_de_Cita_con_EspecialistaApiConsumer.Update_Solicitud(Solicitud_de_Cita_con_Especialista_SolicitudInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Solicitud(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISolicitud_de_Cita_con_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _ISolicitud_de_Cita_con_EspecialistaApiConsumer.Get_Solicitud(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				
                var result = new Solicitud_de_Cita_con_Especialista_SolicitudModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Retroalimentacion = (m.Fecha_de_Retroalimentacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Retroalimentacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Retroalimentacion = m.Hora_de_Retroalimentacion
                        ,Asististe_a_tu_cita = m.Asististe_a_tu_cita
                        ,Asististe_a_tu_citaDescripcion = CultureHelper.GetTraduction(m.Asististe_a_tu_cita_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Asististe_a_tu_cita_Respuesta_Logica.Descripcion
                        ,Calificacion_Especialista = m.Calificacion_Especialista
                        ,Calificacion_EspecialistaDescripcion = CultureHelper.GetTraduction(m.Calificacion_Especialista_Calificacion.Clave.ToString(), "Descripcion") ?? (string)m.Calificacion_Especialista_Calificacion.Descripcion
                        ,Motivo_no_concreto_cita = m.Motivo_no_concreto_cita
                        ,Motivo_no_concreto_citaDescripcion = CultureHelper.GetTraduction(m.Motivo_no_concreto_cita_Motivos.Clave.ToString(), "Descripcion") ?? (string)m.Motivo_no_concreto_cita_Motivos.Descripcion

                    
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

