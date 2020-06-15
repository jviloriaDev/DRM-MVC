using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Consultas;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Pacientes;
using Spartane.Core.Domain.Sexo;
using Spartane.Core.Domain.Objetivos;
using Spartane.Core.Domain.Interpretacion_IMC;
using Spartane.Core.Domain.Interpretacion_IMC;
using Spartane.Core.Domain.Interpretacion_consumo_de_agua;
using Spartane.Core.Domain.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo;
using Spartane.Core.Domain.Interpretacion_indice_cintura__cadera;
using Spartane.Core.Domain.Interpretacion_Dificultad_de_Rutina_de_Ejercicios;
using Spartane.Core.Domain.Interpretacion_Calorias;
using Spartane.Core.Domain.Detalle_Resultados_Consultas;

using Spartane.Core.Domain.Pacientes;

using Spartane.Core.Domain.Indicadores_Consultas;






using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Consultas;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Consultas;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Pacientes;
using Spartane.Web.Areas.WebApiConsumer.Sexo;
using Spartane.Web.Areas.WebApiConsumer.Objetivos;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_IMC;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_IMC;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_consumo_de_agua;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_Frecuencia_cardiaca_en_Esfuerzo;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_indice_cintura__cadera;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_Dificultad_de_Rutina_de_Ejercicios;
using Spartane.Web.Areas.WebApiConsumer.Interpretacion_Calorias;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Resultados_Consultas;

using Spartane.Web.Areas.WebApiConsumer.Pacientes;

using Spartane.Web.Areas.WebApiConsumer.Indicadores_Consultas;


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
    public class ConsultasController : Controller
    {
        #region "variable declaration"

        private IConsultasService service = null;
        private IConsultasApiConsumer _IConsultasApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IPacientesApiConsumer _IPacientesApiConsumer;
        private ISexoApiConsumer _ISexoApiConsumer;
        private IObjetivosApiConsumer _IObjetivosApiConsumer;
        private IInterpretacion_IMCApiConsumer _IInterpretacion_IMCApiConsumer;
        private IInterpretacion_consumo_de_aguaApiConsumer _IInterpretacion_consumo_de_aguaApiConsumer;
        private IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer;
        private IInterpretacion_indice_cintura__caderaApiConsumer _IInterpretacion_indice_cintura__caderaApiConsumer;
        private IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer;
        private IInterpretacion_CaloriasApiConsumer _IInterpretacion_CaloriasApiConsumer;
        private IDetalle_Resultados_ConsultasApiConsumer _IDetalle_Resultados_ConsultasApiConsumer;


        private IIndicadores_ConsultasApiConsumer _IIndicadores_ConsultasApiConsumer;


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

        
        public ConsultasController(IConsultasService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IConsultasApiConsumer ConsultasApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IPacientesApiConsumer PacientesApiConsumer , ISexoApiConsumer SexoApiConsumer , IObjetivosApiConsumer ObjetivosApiConsumer , IInterpretacion_IMCApiConsumer Interpretacion_IMCApiConsumer , IInterpretacion_consumo_de_aguaApiConsumer Interpretacion_consumo_de_aguaApiConsumer , IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer Interpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer , IInterpretacion_indice_cintura__caderaApiConsumer Interpretacion_indice_cintura__caderaApiConsumer , IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer Interpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer , IInterpretacion_CaloriasApiConsumer Interpretacion_CaloriasApiConsumer , IDetalle_Resultados_ConsultasApiConsumer Detalle_Resultados_ConsultasApiConsumer , IIndicadores_ConsultasApiConsumer Indicadores_ConsultasApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IConsultasApiConsumer = ConsultasApiConsumer;
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
            this._ISexoApiConsumer = SexoApiConsumer;
            this._IObjetivosApiConsumer = ObjetivosApiConsumer;
            this._IInterpretacion_IMCApiConsumer = Interpretacion_IMCApiConsumer;
            this._IInterpretacion_IMCApiConsumer = Interpretacion_IMCApiConsumer;
            this._IInterpretacion_consumo_de_aguaApiConsumer = Interpretacion_consumo_de_aguaApiConsumer;
            this._IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer = Interpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer;
            this._IInterpretacion_indice_cintura__caderaApiConsumer = Interpretacion_indice_cintura__caderaApiConsumer;
            this._IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer = Interpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer;
            this._IInterpretacion_CaloriasApiConsumer = Interpretacion_CaloriasApiConsumer;
            this._IDetalle_Resultados_ConsultasApiConsumer = Detalle_Resultados_ConsultasApiConsumer;

            this._IPacientesApiConsumer = PacientesApiConsumer;

            this._IIndicadores_ConsultasApiConsumer = Indicadores_ConsultasApiConsumer;


        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Consultas
        [ObjectAuth(ObjectId = (ModuleObjectId)44352, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44352, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Consultas/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44352, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44352, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varConsultas = new ConsultasModel();
			varConsultas.Folio = Id;
			
            ViewBag.ObjectId = "44352";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionDetalle_Resultados_Consultas = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44405, ModuleId);
            ViewBag.PermissionDetalle_Resultados_Consultas = permissionDetalle_Resultados_Consultas;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var ConsultassData = _IConsultasApiConsumer.ListaSelAll(0, 1000, "Consultas.Folio=" + Id, "").Resource.Consultass;
				
				if (ConsultassData != null && ConsultassData.Count > 0)
                {
					var ConsultasData = ConsultassData.First();
					varConsultas= new ConsultasModel
					{
						Folio  = ConsultasData.Folio 
	                    ,Fecha_de_Registo = (ConsultasData.Fecha_de_Registo == null ? string.Empty : Convert.ToDateTime(ConsultasData.Fecha_de_Registo).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = ConsultasData.Hora_de_Registro
                    ,Usuario_que_Registra = ConsultasData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Usuario_que_Registra), "Spartan_User") ??  (string)ConsultasData.Usuario_que_Registra_Spartan_User.Name
                    ,Fecha_Programada = (ConsultasData.Fecha_Programada == null ? string.Empty : Convert.ToDateTime(ConsultasData.Fecha_Programada).ToString(ConfigurationProperty.DateFormat))
                    ,Paciente = ConsultasData.Paciente
                    ,PacienteNombre_Completo = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Paciente), "Pacientes") ??  (string)ConsultasData.Paciente_Pacientes.Nombre_Completo
                    ,Edad = ConsultasData.Edad
                    ,Nombre_del_padre = ConsultasData.Nombre_del_padre
                    ,Sexo = ConsultasData.Sexo
                    ,SexoDescripcion = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Sexo), "Sexo") ??  (string)ConsultasData.Sexo_Sexo.Descripcion
                    ,Email = ConsultasData.Email
                    ,Objetivo = ConsultasData.Objetivo
                    ,ObjetivoDescripcion = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Objetivo), "Objetivos") ??  (string)ConsultasData.Objetivo_Objetivos.Descripcion
                    ,Frecuencia_Cardiaca = ConsultasData.Frecuencia_Cardiaca
                    ,Presion_sistolica = ConsultasData.Presion_sistolica
                    ,Presion_diastolica = ConsultasData.Presion_diastolica
                    ,Peso_actual = ConsultasData.Peso_actual
                    ,Estatura = ConsultasData.Estatura
                    ,Circunferencia_de_cintura_cm = ConsultasData.Circunferencia_de_cintura_cm
                    ,Circunferencia_de_cadera_cm = ConsultasData.Circunferencia_de_cadera_cm
                    ,Edad_Metabolica = ConsultasData.Edad_Metabolica
                    ,Agua_corporal = ConsultasData.Agua_corporal
                    ,Grasa_Visceral = ConsultasData.Grasa_Visceral
                    ,Grasa_Corporal = ConsultasData.Grasa_Corporal
                    ,Grasa_Corporal_kg = ConsultasData.Grasa_Corporal_kg
                    ,Masa_Muscular_kg = ConsultasData.Masa_Muscular_kg
                    ,Semana_de_gestacion = ConsultasData.Semana_de_gestacion
                    ,IMC = ConsultasData.IMC
                    ,IMC_Pediatria = ConsultasData.IMC_Pediatria
                    ,IMC_PediatriaDescripcion = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.IMC_Pediatria), "Interpretacion_IMC") ??  (string)ConsultasData.IMC_Pediatria_Interpretacion_IMC.Descripcion
                    ,Interpretacion_IMC = ConsultasData.Interpretacion_IMC
                    ,Interpretacion_IMCDescripcion = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Interpretacion_IMC), "Interpretacion_IMC") ??  (string)ConsultasData.Interpretacion_IMC_Interpretacion_IMC.Descripcion
                    ,Consumo_de_agua_resultado = ConsultasData.Consumo_de_agua_resultado
                    ,Interpretacion_agua = ConsultasData.Interpretacion_agua
                    ,Interpretacion_aguaDescripcion = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Interpretacion_agua), "Interpretacion_consumo_de_agua") ??  (string)ConsultasData.Interpretacion_agua_Interpretacion_consumo_de_agua.Descripcion
                    ,Frecuencia_cardiaca_en_Esfuerzo = ConsultasData.Frecuencia_cardiaca_en_Esfuerzo
                    ,Interpretacion_frecuencia = ConsultasData.Interpretacion_frecuencia
                    ,Interpretacion_frecuenciaDescripcion = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Interpretacion_frecuencia), "Interpretacion_Frecuencia_cardiaca_en_Esfuerzo") ??  (string)ConsultasData.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion
                    ,Indice_cintura_cadera = ConsultasData.Indice_cintura_cadera
                    ,Interpretacion_indice = ConsultasData.Interpretacion_indice
                    ,Interpretacion_indiceDescripcion = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Interpretacion_indice), "Interpretacion_indice_cintura__cadera") ??  (string)ConsultasData.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Descripcion
                    ,Dificultad_de_Rutina_de_Ejercicios = ConsultasData.Dificultad_de_Rutina_de_Ejercicios
                    ,Interpretacion_dificultad = ConsultasData.Interpretacion_dificultad
                    ,Interpretacion_dificultadDescripcion = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Interpretacion_dificultad), "Interpretacion_Dificultad_de_Rutina_de_Ejercicios") ??  (string)ConsultasData.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion
                    ,Calorias = ConsultasData.Calorias
                    ,Interpretacion_calorias = ConsultasData.Interpretacion_calorias
                    ,Interpretacion_caloriasDescripcion = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Interpretacion_calorias), "Interpretacion_Calorias") ??  (string)ConsultasData.Interpretacion_calorias_Interpretacion_Calorias.Descripcion
                    ,Observaciones = ConsultasData.Observaciones
                    ,Fecha_siguiente_Consulta = (ConsultasData.Fecha_siguiente_Consulta == null ? string.Empty : Convert.ToDateTime(ConsultasData.Fecha_siguiente_Consulta).ToString(ConfigurationProperty.DateFormat))

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
	    _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Pacientess_Paciente = _IPacientesApiConsumer.SelAll(true);
            if (Pacientess_Paciente != null && Pacientess_Paciente.Resource != null)
                ViewBag.Pacientess_Paciente = Pacientess_Paciente.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Pacientes", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Sexo = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Sexo != null && Sexos_Sexo.Resource != null)
                ViewBag.Sexos_Sexo = Sexos_Sexo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IObjetivosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Objetivoss_Objetivo = _IObjetivosApiConsumer.SelAll(true);
            if (Objetivoss_Objetivo != null && Objetivoss_Objetivo.Resource != null)
                ViewBag.Objetivoss_Objetivo = Objetivoss_Objetivo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Objetivos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IInterpretacion_IMCApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_IMCs_IMC_Pediatria = _IInterpretacion_IMCApiConsumer.SelAll(true);
            if (Interpretacion_IMCs_IMC_Pediatria != null && Interpretacion_IMCs_IMC_Pediatria.Resource != null)
                ViewBag.Interpretacion_IMCs_IMC_Pediatria = Interpretacion_IMCs_IMC_Pediatria.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_IMC", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_IMCApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_IMCs_Interpretacion_IMC = _IInterpretacion_IMCApiConsumer.SelAll(true);
            if (Interpretacion_IMCs_Interpretacion_IMC != null && Interpretacion_IMCs_Interpretacion_IMC.Resource != null)
                ViewBag.Interpretacion_IMCs_Interpretacion_IMC = Interpretacion_IMCs_Interpretacion_IMC.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_IMC", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_consumo_de_aguaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_consumo_de_aguas_Interpretacion_agua = _IInterpretacion_consumo_de_aguaApiConsumer.SelAll(true);
            if (Interpretacion_consumo_de_aguas_Interpretacion_agua != null && Interpretacion_consumo_de_aguas_Interpretacion_agua.Resource != null)
                ViewBag.Interpretacion_consumo_de_aguas_Interpretacion_agua = Interpretacion_consumo_de_aguas_Interpretacion_agua.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_consumo_de_agua", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia = _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SelAll(true);
            if (Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia != null && Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia.Resource != null)
                ViewBag.Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia = Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Frecuencia_cardiaca_en_Esfuerzo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_indice_cintura__caderaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_indice_cintura__caderas_Interpretacion_indice = _IInterpretacion_indice_cintura__caderaApiConsumer.SelAll(true);
            if (Interpretacion_indice_cintura__caderas_Interpretacion_indice != null && Interpretacion_indice_cintura__caderas_Interpretacion_indice.Resource != null)
                ViewBag.Interpretacion_indice_cintura__caderas_Interpretacion_indice = Interpretacion_indice_cintura__caderas_Interpretacion_indice.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_indice_cintura__cadera", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad = _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SelAll(true);
            if (Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad != null && Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad.Resource != null)
                ViewBag.Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad = Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Dificultad_de_Rutina_de_Ejercicios", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Caloriass_Interpretacion_calorias = _IInterpretacion_CaloriasApiConsumer.SelAll(true);
            if (Interpretacion_Caloriass_Interpretacion_calorias != null && Interpretacion_Caloriass_Interpretacion_calorias.Resource != null)
                ViewBag.Interpretacion_Caloriass_Interpretacion_calorias = Interpretacion_Caloriass_Interpretacion_calorias.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Calorias", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
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

				
            return View(varConsultas);
        }
		
	[HttpGet]
        public ActionResult AddConsultas(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44352);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);
			ConsultasModel varConsultas= new ConsultasModel();
            var permissionDetalle_Resultados_Consultas = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44405, ModuleId);
            ViewBag.PermissionDetalle_Resultados_Consultas = permissionDetalle_Resultados_Consultas;


            if (id.ToString() != "0")
            {
                var ConsultassData = _IConsultasApiConsumer.ListaSelAll(0, 1000, "Consultas.Folio=" + id, "").Resource.Consultass;
				
				if (ConsultassData != null && ConsultassData.Count > 0)
                {
					var ConsultasData = ConsultassData.First();
					varConsultas= new ConsultasModel
					{
						Folio  = ConsultasData.Folio 
	                    ,Fecha_de_Registo = (ConsultasData.Fecha_de_Registo == null ? string.Empty : Convert.ToDateTime(ConsultasData.Fecha_de_Registo).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = ConsultasData.Hora_de_Registro
                    ,Usuario_que_Registra = ConsultasData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Usuario_que_Registra), "Spartan_User") ??  (string)ConsultasData.Usuario_que_Registra_Spartan_User.Name
                    ,Fecha_Programada = (ConsultasData.Fecha_Programada == null ? string.Empty : Convert.ToDateTime(ConsultasData.Fecha_Programada).ToString(ConfigurationProperty.DateFormat))
                    ,Paciente = ConsultasData.Paciente
                    ,PacienteNombre_Completo = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Paciente), "Pacientes") ??  (string)ConsultasData.Paciente_Pacientes.Nombre_Completo
                    ,Edad = ConsultasData.Edad
                    ,Nombre_del_padre = ConsultasData.Nombre_del_padre
                    ,Sexo = ConsultasData.Sexo
                    ,SexoDescripcion = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Sexo), "Sexo") ??  (string)ConsultasData.Sexo_Sexo.Descripcion
                    ,Email = ConsultasData.Email
                    ,Objetivo = ConsultasData.Objetivo
                    ,ObjetivoDescripcion = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Objetivo), "Objetivos") ??  (string)ConsultasData.Objetivo_Objetivos.Descripcion
                    ,Frecuencia_Cardiaca = ConsultasData.Frecuencia_Cardiaca
                    ,Presion_sistolica = ConsultasData.Presion_sistolica
                    ,Presion_diastolica = ConsultasData.Presion_diastolica
                    ,Peso_actual = ConsultasData.Peso_actual
                    ,Estatura = ConsultasData.Estatura
                    ,Circunferencia_de_cintura_cm = ConsultasData.Circunferencia_de_cintura_cm
                    ,Circunferencia_de_cadera_cm = ConsultasData.Circunferencia_de_cadera_cm
                    ,Edad_Metabolica = ConsultasData.Edad_Metabolica
                    ,Agua_corporal = ConsultasData.Agua_corporal
                    ,Grasa_Visceral = ConsultasData.Grasa_Visceral
                    ,Grasa_Corporal = ConsultasData.Grasa_Corporal
                    ,Grasa_Corporal_kg = ConsultasData.Grasa_Corporal_kg
                    ,Masa_Muscular_kg = ConsultasData.Masa_Muscular_kg
                    ,Semana_de_gestacion = ConsultasData.Semana_de_gestacion
                    ,IMC = ConsultasData.IMC
                    ,IMC_Pediatria = ConsultasData.IMC_Pediatria
                    ,IMC_PediatriaDescripcion = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.IMC_Pediatria), "Interpretacion_IMC") ??  (string)ConsultasData.IMC_Pediatria_Interpretacion_IMC.Descripcion
                    ,Interpretacion_IMC = ConsultasData.Interpretacion_IMC
                    ,Interpretacion_IMCDescripcion = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Interpretacion_IMC), "Interpretacion_IMC") ??  (string)ConsultasData.Interpretacion_IMC_Interpretacion_IMC.Descripcion
                    ,Consumo_de_agua_resultado = ConsultasData.Consumo_de_agua_resultado
                    ,Interpretacion_agua = ConsultasData.Interpretacion_agua
                    ,Interpretacion_aguaDescripcion = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Interpretacion_agua), "Interpretacion_consumo_de_agua") ??  (string)ConsultasData.Interpretacion_agua_Interpretacion_consumo_de_agua.Descripcion
                    ,Frecuencia_cardiaca_en_Esfuerzo = ConsultasData.Frecuencia_cardiaca_en_Esfuerzo
                    ,Interpretacion_frecuencia = ConsultasData.Interpretacion_frecuencia
                    ,Interpretacion_frecuenciaDescripcion = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Interpretacion_frecuencia), "Interpretacion_Frecuencia_cardiaca_en_Esfuerzo") ??  (string)ConsultasData.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion
                    ,Indice_cintura_cadera = ConsultasData.Indice_cintura_cadera
                    ,Interpretacion_indice = ConsultasData.Interpretacion_indice
                    ,Interpretacion_indiceDescripcion = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Interpretacion_indice), "Interpretacion_indice_cintura__cadera") ??  (string)ConsultasData.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Descripcion
                    ,Dificultad_de_Rutina_de_Ejercicios = ConsultasData.Dificultad_de_Rutina_de_Ejercicios
                    ,Interpretacion_dificultad = ConsultasData.Interpretacion_dificultad
                    ,Interpretacion_dificultadDescripcion = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Interpretacion_dificultad), "Interpretacion_Dificultad_de_Rutina_de_Ejercicios") ??  (string)ConsultasData.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion
                    ,Calorias = ConsultasData.Calorias
                    ,Interpretacion_calorias = ConsultasData.Interpretacion_calorias
                    ,Interpretacion_caloriasDescripcion = CultureHelper.GetTraduction(Convert.ToString(ConsultasData.Interpretacion_calorias), "Interpretacion_Calorias") ??  (string)ConsultasData.Interpretacion_calorias_Interpretacion_Calorias.Descripcion
                    ,Observaciones = ConsultasData.Observaciones
                    ,Fecha_siguiente_Consulta = (ConsultasData.Fecha_siguiente_Consulta == null ? string.Empty : Convert.ToDateTime(ConsultasData.Fecha_siguiente_Consulta).ToString(ConfigurationProperty.DateFormat))

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
	    _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Pacientess_Paciente = _IPacientesApiConsumer.SelAll(true);
            if (Pacientess_Paciente != null && Pacientess_Paciente.Resource != null)
                ViewBag.Pacientess_Paciente = Pacientess_Paciente.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Pacientes", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Sexo = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Sexo != null && Sexos_Sexo.Resource != null)
                ViewBag.Sexos_Sexo = Sexos_Sexo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IObjetivosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Objetivoss_Objetivo = _IObjetivosApiConsumer.SelAll(true);
            if (Objetivoss_Objetivo != null && Objetivoss_Objetivo.Resource != null)
                ViewBag.Objetivoss_Objetivo = Objetivoss_Objetivo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Objetivos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IInterpretacion_IMCApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_IMCs_IMC_Pediatria = _IInterpretacion_IMCApiConsumer.SelAll(true);
            if (Interpretacion_IMCs_IMC_Pediatria != null && Interpretacion_IMCs_IMC_Pediatria.Resource != null)
                ViewBag.Interpretacion_IMCs_IMC_Pediatria = Interpretacion_IMCs_IMC_Pediatria.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_IMC", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_IMCApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_IMCs_Interpretacion_IMC = _IInterpretacion_IMCApiConsumer.SelAll(true);
            if (Interpretacion_IMCs_Interpretacion_IMC != null && Interpretacion_IMCs_Interpretacion_IMC.Resource != null)
                ViewBag.Interpretacion_IMCs_Interpretacion_IMC = Interpretacion_IMCs_Interpretacion_IMC.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_IMC", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_consumo_de_aguaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_consumo_de_aguas_Interpretacion_agua = _IInterpretacion_consumo_de_aguaApiConsumer.SelAll(true);
            if (Interpretacion_consumo_de_aguas_Interpretacion_agua != null && Interpretacion_consumo_de_aguas_Interpretacion_agua.Resource != null)
                ViewBag.Interpretacion_consumo_de_aguas_Interpretacion_agua = Interpretacion_consumo_de_aguas_Interpretacion_agua.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_consumo_de_agua", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia = _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SelAll(true);
            if (Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia != null && Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia.Resource != null)
                ViewBag.Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia = Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Frecuencia_cardiaca_en_Esfuerzo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_indice_cintura__caderaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_indice_cintura__caderas_Interpretacion_indice = _IInterpretacion_indice_cintura__caderaApiConsumer.SelAll(true);
            if (Interpretacion_indice_cintura__caderas_Interpretacion_indice != null && Interpretacion_indice_cintura__caderas_Interpretacion_indice.Resource != null)
                ViewBag.Interpretacion_indice_cintura__caderas_Interpretacion_indice = Interpretacion_indice_cintura__caderas_Interpretacion_indice.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_indice_cintura__cadera", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad = _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SelAll(true);
            if (Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad != null && Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad.Resource != null)
                ViewBag.Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad = Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Dificultad_de_Rutina_de_Ejercicios", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Caloriass_Interpretacion_calorias = _IInterpretacion_CaloriasApiConsumer.SelAll(true);
            if (Interpretacion_Caloriass_Interpretacion_calorias != null && Interpretacion_Caloriass_Interpretacion_calorias.Resource != null)
                ViewBag.Interpretacion_Caloriass_Interpretacion_calorias = Interpretacion_Caloriass_Interpretacion_calorias.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Calorias", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddConsultas", varConsultas);
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
        public ActionResult GetObjetivosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IObjetivosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IObjetivosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Objetivos", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetInterpretacion_IMCAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IInterpretacion_IMCApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IInterpretacion_IMCApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_IMC", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetInterpretacion_consumo_de_aguaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IInterpretacion_consumo_de_aguaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IInterpretacion_consumo_de_aguaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_consumo_de_agua", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetInterpretacion_Frecuencia_cardiaca_en_EsfuerzoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Frecuencia_cardiaca_en_Esfuerzo", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetInterpretacion_indice_cintura__caderaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IInterpretacion_indice_cintura__caderaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IInterpretacion_indice_cintura__caderaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_indice_cintura__cadera", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetInterpretacion_Dificultad_de_Rutina_de_EjerciciosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Dificultad_de_Rutina_de_Ejercicios", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetInterpretacion_CaloriasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IInterpretacion_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IInterpretacion_CaloriasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Calorias", "Descripcion")?? m.Descripcion,
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
        public ActionResult ShowAdvanceFilter(ConsultasAdvanceSearchModel model, int idFilter = -1)
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
	    _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Pacientess_Paciente = _IPacientesApiConsumer.SelAll(true);
            if (Pacientess_Paciente != null && Pacientess_Paciente.Resource != null)
                ViewBag.Pacientess_Paciente = Pacientess_Paciente.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Pacientes", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Sexo = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Sexo != null && Sexos_Sexo.Resource != null)
                ViewBag.Sexos_Sexo = Sexos_Sexo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IObjetivosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Objetivoss_Objetivo = _IObjetivosApiConsumer.SelAll(true);
            if (Objetivoss_Objetivo != null && Objetivoss_Objetivo.Resource != null)
                ViewBag.Objetivoss_Objetivo = Objetivoss_Objetivo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Objetivos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IInterpretacion_IMCApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_IMCs_IMC_Pediatria = _IInterpretacion_IMCApiConsumer.SelAll(true);
            if (Interpretacion_IMCs_IMC_Pediatria != null && Interpretacion_IMCs_IMC_Pediatria.Resource != null)
                ViewBag.Interpretacion_IMCs_IMC_Pediatria = Interpretacion_IMCs_IMC_Pediatria.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_IMC", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_IMCApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_IMCs_Interpretacion_IMC = _IInterpretacion_IMCApiConsumer.SelAll(true);
            if (Interpretacion_IMCs_Interpretacion_IMC != null && Interpretacion_IMCs_Interpretacion_IMC.Resource != null)
                ViewBag.Interpretacion_IMCs_Interpretacion_IMC = Interpretacion_IMCs_Interpretacion_IMC.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_IMC", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_consumo_de_aguaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_consumo_de_aguas_Interpretacion_agua = _IInterpretacion_consumo_de_aguaApiConsumer.SelAll(true);
            if (Interpretacion_consumo_de_aguas_Interpretacion_agua != null && Interpretacion_consumo_de_aguas_Interpretacion_agua.Resource != null)
                ViewBag.Interpretacion_consumo_de_aguas_Interpretacion_agua = Interpretacion_consumo_de_aguas_Interpretacion_agua.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_consumo_de_agua", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia = _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SelAll(true);
            if (Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia != null && Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia.Resource != null)
                ViewBag.Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia = Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Frecuencia_cardiaca_en_Esfuerzo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_indice_cintura__caderaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_indice_cintura__caderas_Interpretacion_indice = _IInterpretacion_indice_cintura__caderaApiConsumer.SelAll(true);
            if (Interpretacion_indice_cintura__caderas_Interpretacion_indice != null && Interpretacion_indice_cintura__caderas_Interpretacion_indice.Resource != null)
                ViewBag.Interpretacion_indice_cintura__caderas_Interpretacion_indice = Interpretacion_indice_cintura__caderas_Interpretacion_indice.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_indice_cintura__cadera", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad = _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SelAll(true);
            if (Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad != null && Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad.Resource != null)
                ViewBag.Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad = Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Dificultad_de_Rutina_de_Ejercicios", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Caloriass_Interpretacion_calorias = _IInterpretacion_CaloriasApiConsumer.SelAll(true);
            if (Interpretacion_Caloriass_Interpretacion_calorias != null && Interpretacion_Caloriass_Interpretacion_calorias.Resource != null)
                ViewBag.Interpretacion_Caloriass_Interpretacion_calorias = Interpretacion_Caloriass_Interpretacion_calorias.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Calorias", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
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
	    _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Pacientess_Paciente = _IPacientesApiConsumer.SelAll(true);
            if (Pacientess_Paciente != null && Pacientess_Paciente.Resource != null)
                ViewBag.Pacientess_Paciente = Pacientess_Paciente.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Pacientes", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Sexo = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Sexo != null && Sexos_Sexo.Resource != null)
                ViewBag.Sexos_Sexo = Sexos_Sexo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IObjetivosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Objetivoss_Objetivo = _IObjetivosApiConsumer.SelAll(true);
            if (Objetivoss_Objetivo != null && Objetivoss_Objetivo.Resource != null)
                ViewBag.Objetivoss_Objetivo = Objetivoss_Objetivo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Objetivos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IInterpretacion_IMCApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_IMCs_IMC_Pediatria = _IInterpretacion_IMCApiConsumer.SelAll(true);
            if (Interpretacion_IMCs_IMC_Pediatria != null && Interpretacion_IMCs_IMC_Pediatria.Resource != null)
                ViewBag.Interpretacion_IMCs_IMC_Pediatria = Interpretacion_IMCs_IMC_Pediatria.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_IMC", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_IMCApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_IMCs_Interpretacion_IMC = _IInterpretacion_IMCApiConsumer.SelAll(true);
            if (Interpretacion_IMCs_Interpretacion_IMC != null && Interpretacion_IMCs_Interpretacion_IMC.Resource != null)
                ViewBag.Interpretacion_IMCs_Interpretacion_IMC = Interpretacion_IMCs_Interpretacion_IMC.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_IMC", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_consumo_de_aguaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_consumo_de_aguas_Interpretacion_agua = _IInterpretacion_consumo_de_aguaApiConsumer.SelAll(true);
            if (Interpretacion_consumo_de_aguas_Interpretacion_agua != null && Interpretacion_consumo_de_aguas_Interpretacion_agua.Resource != null)
                ViewBag.Interpretacion_consumo_de_aguas_Interpretacion_agua = Interpretacion_consumo_de_aguas_Interpretacion_agua.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_consumo_de_agua", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia = _IInterpretacion_Frecuencia_cardiaca_en_EsfuerzoApiConsumer.SelAll(true);
            if (Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia != null && Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia.Resource != null)
                ViewBag.Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia = Interpretacion_Frecuencia_cardiaca_en_Esfuerzos_Interpretacion_frecuencia.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Frecuencia_cardiaca_en_Esfuerzo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_indice_cintura__caderaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_indice_cintura__caderas_Interpretacion_indice = _IInterpretacion_indice_cintura__caderaApiConsumer.SelAll(true);
            if (Interpretacion_indice_cintura__caderas_Interpretacion_indice != null && Interpretacion_indice_cintura__caderas_Interpretacion_indice.Resource != null)
                ViewBag.Interpretacion_indice_cintura__caderas_Interpretacion_indice = Interpretacion_indice_cintura__caderas_Interpretacion_indice.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_indice_cintura__cadera", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad = _IInterpretacion_Dificultad_de_Rutina_de_EjerciciosApiConsumer.SelAll(true);
            if (Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad != null && Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad.Resource != null)
                ViewBag.Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad = Interpretacion_Dificultad_de_Rutina_de_Ejercicioss_Interpretacion_dificultad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Dificultad_de_Rutina_de_Ejercicios", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IInterpretacion_CaloriasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Interpretacion_Caloriass_Interpretacion_calorias = _IInterpretacion_CaloriasApiConsumer.SelAll(true);
            if (Interpretacion_Caloriass_Interpretacion_calorias != null && Interpretacion_Caloriass_Interpretacion_calorias.Resource != null)
                ViewBag.Interpretacion_Caloriass_Interpretacion_calorias = Interpretacion_Caloriass_Interpretacion_calorias.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Interpretacion_Calorias", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            var previousFiltersObj = new ConsultasAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (ConsultasAdvanceSearchModel)(Session["AdvanceSearch"] ?? new ConsultasAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new ConsultasPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IConsultasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Consultass == null)
                result.Consultass = new List<Consultas>();

            return Json(new
            {
                data = result.Consultass.Select(m => new ConsultasGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registo = (m.Fecha_de_Registo == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registo).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Fecha_Programada = (m.Fecha_Programada == null ? string.Empty : Convert.ToDateTime(m.Fecha_Programada).ToString(ConfigurationProperty.DateFormat))
                        ,PacienteNombre_Completo = CultureHelper.GetTraduction(m.Paciente_Pacientes.Folio.ToString(), "Pacientes") ?? (string)m.Paciente_Pacientes.Nombre_Completo
			,Edad = m.Edad
			,Nombre_del_padre = m.Nombre_del_padre
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Email = m.Email
                        ,ObjetivoDescripcion = CultureHelper.GetTraduction(m.Objetivo_Objetivos.Clave.ToString(), "Descripcion") ?? (string)m.Objetivo_Objetivos.Descripcion
			,Frecuencia_Cardiaca = m.Frecuencia_Cardiaca
			,Presion_sistolica = m.Presion_sistolica
			,Presion_diastolica = m.Presion_diastolica
			,Peso_actual = m.Peso_actual
			,Estatura = m.Estatura
			,Circunferencia_de_cintura_cm = m.Circunferencia_de_cintura_cm
			,Circunferencia_de_cadera_cm = m.Circunferencia_de_cadera_cm
			,Edad_Metabolica = m.Edad_Metabolica
			,Agua_corporal = m.Agua_corporal
			,Grasa_Visceral = m.Grasa_Visceral
			,Grasa_Corporal = m.Grasa_Corporal
			,Grasa_Corporal_kg = m.Grasa_Corporal_kg
			,Masa_Muscular_kg = m.Masa_Muscular_kg
			,Semana_de_gestacion = m.Semana_de_gestacion
			,IMC = m.IMC
                        ,IMC_PediatriaDescripcion = CultureHelper.GetTraduction(m.IMC_Pediatria_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.IMC_Pediatria_Interpretacion_IMC.Descripcion
                        ,Interpretacion_IMCDescripcion = CultureHelper.GetTraduction(m.Interpretacion_IMC_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_IMC_Interpretacion_IMC.Descripcion
			,Consumo_de_agua_resultado = m.Consumo_de_agua_resultado
                        ,Interpretacion_aguaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_agua_Interpretacion_consumo_de_agua.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_agua_Interpretacion_consumo_de_agua.Descripcion
			,Frecuencia_cardiaca_en_Esfuerzo = m.Frecuencia_cardiaca_en_Esfuerzo
                        ,Interpretacion_frecuenciaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion
			,Indice_cintura_cadera = m.Indice_cintura_cadera
                        ,Interpretacion_indiceDescripcion = CultureHelper.GetTraduction(m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Descripcion
			,Dificultad_de_Rutina_de_Ejercicios = m.Dificultad_de_Rutina_de_Ejercicios
                        ,Interpretacion_dificultadDescripcion = CultureHelper.GetTraduction(m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion
			,Calorias = m.Calorias
                        ,Interpretacion_caloriasDescripcion = CultureHelper.GetTraduction(m.Interpretacion_calorias_Interpretacion_Calorias.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_calorias_Interpretacion_Calorias.Descripcion
			,Observaciones = m.Observaciones
                        ,Fecha_siguiente_Consulta = (m.Fecha_siguiente_Consulta == null ? string.Empty : Convert.ToDateTime(m.Fecha_siguiente_Consulta).ToString(ConfigurationProperty.DateFormat))

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetConsultasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IConsultasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Consultas", m.),
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
        /// Get List of Consultas from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Consultas Entity</returns>
        public ActionResult GetConsultasList(UrlParametersModel param)
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
            _IConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new ConsultasPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(ConsultasAdvanceSearchModel))
                {
					var advanceFilter =
                    (ConsultasAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            ConsultasPropertyMapper oConsultasPropertyMapper = new ConsultasPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oConsultasPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IConsultasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Consultass == null)
                result.Consultass = new List<Consultas>();

            return Json(new
            {
                aaData = result.Consultass.Select(m => new ConsultasGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registo = (m.Fecha_de_Registo == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registo).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Fecha_Programada = (m.Fecha_Programada == null ? string.Empty : Convert.ToDateTime(m.Fecha_Programada).ToString(ConfigurationProperty.DateFormat))
                        ,PacienteNombre_Completo = CultureHelper.GetTraduction(m.Paciente_Pacientes.Folio.ToString(), "Pacientes") ?? (string)m.Paciente_Pacientes.Nombre_Completo
			,Edad = m.Edad
			,Nombre_del_padre = m.Nombre_del_padre
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Email = m.Email
                        ,ObjetivoDescripcion = CultureHelper.GetTraduction(m.Objetivo_Objetivos.Clave.ToString(), "Descripcion") ?? (string)m.Objetivo_Objetivos.Descripcion
			,Frecuencia_Cardiaca = m.Frecuencia_Cardiaca
			,Presion_sistolica = m.Presion_sistolica
			,Presion_diastolica = m.Presion_diastolica
			,Peso_actual = m.Peso_actual
			,Estatura = m.Estatura
			,Circunferencia_de_cintura_cm = m.Circunferencia_de_cintura_cm
			,Circunferencia_de_cadera_cm = m.Circunferencia_de_cadera_cm
			,Edad_Metabolica = m.Edad_Metabolica
			,Agua_corporal = m.Agua_corporal
			,Grasa_Visceral = m.Grasa_Visceral
			,Grasa_Corporal = m.Grasa_Corporal
			,Grasa_Corporal_kg = m.Grasa_Corporal_kg
			,Masa_Muscular_kg = m.Masa_Muscular_kg
			,Semana_de_gestacion = m.Semana_de_gestacion
			,IMC = m.IMC
                        ,IMC_PediatriaDescripcion = CultureHelper.GetTraduction(m.IMC_Pediatria_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.IMC_Pediatria_Interpretacion_IMC.Descripcion
                        ,Interpretacion_IMCDescripcion = CultureHelper.GetTraduction(m.Interpretacion_IMC_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_IMC_Interpretacion_IMC.Descripcion
			,Consumo_de_agua_resultado = m.Consumo_de_agua_resultado
                        ,Interpretacion_aguaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_agua_Interpretacion_consumo_de_agua.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_agua_Interpretacion_consumo_de_agua.Descripcion
			,Frecuencia_cardiaca_en_Esfuerzo = m.Frecuencia_cardiaca_en_Esfuerzo
                        ,Interpretacion_frecuenciaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion
			,Indice_cintura_cadera = m.Indice_cintura_cadera
                        ,Interpretacion_indiceDescripcion = CultureHelper.GetTraduction(m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Descripcion
			,Dificultad_de_Rutina_de_Ejercicios = m.Dificultad_de_Rutina_de_Ejercicios
                        ,Interpretacion_dificultadDescripcion = CultureHelper.GetTraduction(m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion
			,Calorias = m.Calorias
                        ,Interpretacion_caloriasDescripcion = CultureHelper.GetTraduction(m.Interpretacion_calorias_Interpretacion_Calorias.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_calorias_Interpretacion_Calorias.Descripcion
			,Observaciones = m.Observaciones
                        ,Fecha_siguiente_Consulta = (m.Fecha_siguiente_Consulta == null ? string.Empty : Convert.ToDateTime(m.Fecha_siguiente_Consulta).ToString(ConfigurationProperty.DateFormat))

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetConsultas_Paciente_Pacientes(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Pacientes.Folio as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Pacientes.Nombre_Completo as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _IPacientesApiConsumer.ListaSelAll(1, 20,elWhere , " Pacientes.Nombre_Completo ASC ").Resource;
               
                foreach (var item in result.Pacientess)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Pacientes", "Nombre_Completo");
                    item.Nombre_Completo =trans ??item.Nombre_Completo;
                }
                return Json(result.Pacientess.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(ConsultasAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Consultas.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Consultas.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registo) || !string.IsNullOrEmpty(filter.ToFecha_de_Registo))
            {
                var Fecha_de_RegistoFrom = DateTime.ParseExact(filter.FromFecha_de_Registo, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistoTo = DateTime.ParseExact(filter.ToFecha_de_Registo, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registo))
                    where += " AND Consultas.Fecha_de_Registo >= '" + Fecha_de_RegistoFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registo))
                    where += " AND Consultas.Fecha_de_Registo <= '" + Fecha_de_RegistoTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Consultas.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Consultas.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
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

                where += " AND Consultas.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_Programada) || !string.IsNullOrEmpty(filter.ToFecha_Programada))
            {
                var Fecha_ProgramadaFrom = DateTime.ParseExact(filter.FromFecha_Programada, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_ProgramadaTo = DateTime.ParseExact(filter.ToFecha_Programada, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_Programada))
                    where += " AND Consultas.Fecha_Programada >= '" + Fecha_ProgramadaFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_Programada))
                    where += " AND Consultas.Fecha_Programada <= '" + Fecha_ProgramadaTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvancePaciente))
            {
                switch (filter.PacienteFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pacientes.Nombre_Completo LIKE '" + filter.AdvancePaciente + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pacientes.Nombre_Completo LIKE '%" + filter.AdvancePaciente + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pacientes.Nombre_Completo = '" + filter.AdvancePaciente + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pacientes.Nombre_Completo LIKE '%" + filter.AdvancePaciente + "%'";
                        break;
                }
            }
            else if (filter.AdvancePacienteMultiple != null && filter.AdvancePacienteMultiple.Count() > 0)
            {
                var PacienteIds = string.Join(",", filter.AdvancePacienteMultiple);

                where += " AND Consultas.Paciente In (" + PacienteIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromEdad) || !string.IsNullOrEmpty(filter.ToEdad))
            {
                if (!string.IsNullOrEmpty(filter.FromEdad))
                    where += " AND Consultas.Edad >= " + filter.FromEdad;
                if (!string.IsNullOrEmpty(filter.ToEdad))
                    where += " AND Consultas.Edad <= " + filter.ToEdad;
            }

            if (!string.IsNullOrEmpty(filter.Nombre_del_padre))
            {
                switch (filter.Nombre_del_padreFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Consultas.Nombre_del_padre LIKE '" + filter.Nombre_del_padre + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Consultas.Nombre_del_padre LIKE '%" + filter.Nombre_del_padre + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Consultas.Nombre_del_padre = '" + filter.Nombre_del_padre + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Consultas.Nombre_del_padre LIKE '%" + filter.Nombre_del_padre + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceSexo))
            {
                switch (filter.SexoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Sexo.Descripcion LIKE '" + filter.AdvanceSexo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Sexo.Descripcion LIKE '%" + filter.AdvanceSexo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Sexo.Descripcion = '" + filter.AdvanceSexo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Sexo.Descripcion LIKE '%" + filter.AdvanceSexo + "%'";
                        break;
                }
            }
            else if (filter.AdvanceSexoMultiple != null && filter.AdvanceSexoMultiple.Count() > 0)
            {
                var SexoIds = string.Join(",", filter.AdvanceSexoMultiple);

                where += " AND Consultas.Sexo In (" + SexoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Email))
            {
                switch (filter.EmailFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Consultas.Email LIKE '" + filter.Email + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Consultas.Email LIKE '%" + filter.Email + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Consultas.Email = '" + filter.Email + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Consultas.Email LIKE '%" + filter.Email + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceObjetivo))
            {
                switch (filter.ObjetivoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Objetivos.Descripcion LIKE '" + filter.AdvanceObjetivo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Objetivos.Descripcion LIKE '%" + filter.AdvanceObjetivo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Objetivos.Descripcion = '" + filter.AdvanceObjetivo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Objetivos.Descripcion LIKE '%" + filter.AdvanceObjetivo + "%'";
                        break;
                }
            }
            else if (filter.AdvanceObjetivoMultiple != null && filter.AdvanceObjetivoMultiple.Count() > 0)
            {
                var ObjetivoIds = string.Join(",", filter.AdvanceObjetivoMultiple);

                where += " AND Consultas.Objetivo In (" + ObjetivoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromFrecuencia_Cardiaca) || !string.IsNullOrEmpty(filter.ToFrecuencia_Cardiaca))
            {
                if (!string.IsNullOrEmpty(filter.FromFrecuencia_Cardiaca))
                    where += " AND Consultas.Frecuencia_Cardiaca >= " + filter.FromFrecuencia_Cardiaca;
                if (!string.IsNullOrEmpty(filter.ToFrecuencia_Cardiaca))
                    where += " AND Consultas.Frecuencia_Cardiaca <= " + filter.ToFrecuencia_Cardiaca;
            }

            if (!string.IsNullOrEmpty(filter.FromPresion_sistolica) || !string.IsNullOrEmpty(filter.ToPresion_sistolica))
            {
                if (!string.IsNullOrEmpty(filter.FromPresion_sistolica))
                    where += " AND Consultas.Presion_sistolica >= " + filter.FromPresion_sistolica;
                if (!string.IsNullOrEmpty(filter.ToPresion_sistolica))
                    where += " AND Consultas.Presion_sistolica <= " + filter.ToPresion_sistolica;
            }

            if (!string.IsNullOrEmpty(filter.FromPresion_diastolica) || !string.IsNullOrEmpty(filter.ToPresion_diastolica))
            {
                if (!string.IsNullOrEmpty(filter.FromPresion_diastolica))
                    where += " AND Consultas.Presion_diastolica >= " + filter.FromPresion_diastolica;
                if (!string.IsNullOrEmpty(filter.ToPresion_diastolica))
                    where += " AND Consultas.Presion_diastolica <= " + filter.ToPresion_diastolica;
            }

            if (!string.IsNullOrEmpty(filter.FromPeso_actual) || !string.IsNullOrEmpty(filter.ToPeso_actual))
            {
                if (!string.IsNullOrEmpty(filter.FromPeso_actual))
                    where += " AND Consultas.Peso_actual >= " + filter.FromPeso_actual;
                if (!string.IsNullOrEmpty(filter.ToPeso_actual))
                    where += " AND Consultas.Peso_actual <= " + filter.ToPeso_actual;
            }

            if (!string.IsNullOrEmpty(filter.FromEstatura) || !string.IsNullOrEmpty(filter.ToEstatura))
            {
                if (!string.IsNullOrEmpty(filter.FromEstatura))
                    where += " AND Consultas.Estatura >= " + filter.FromEstatura;
                if (!string.IsNullOrEmpty(filter.ToEstatura))
                    where += " AND Consultas.Estatura <= " + filter.ToEstatura;
            }

            if (!string.IsNullOrEmpty(filter.FromCircunferencia_de_cintura_cm) || !string.IsNullOrEmpty(filter.ToCircunferencia_de_cintura_cm))
            {
                if (!string.IsNullOrEmpty(filter.FromCircunferencia_de_cintura_cm))
                    where += " AND Consultas.Circunferencia_de_cintura_cm >= " + filter.FromCircunferencia_de_cintura_cm;
                if (!string.IsNullOrEmpty(filter.ToCircunferencia_de_cintura_cm))
                    where += " AND Consultas.Circunferencia_de_cintura_cm <= " + filter.ToCircunferencia_de_cintura_cm;
            }

            if (!string.IsNullOrEmpty(filter.FromCircunferencia_de_cadera_cm) || !string.IsNullOrEmpty(filter.ToCircunferencia_de_cadera_cm))
            {
                if (!string.IsNullOrEmpty(filter.FromCircunferencia_de_cadera_cm))
                    where += " AND Consultas.Circunferencia_de_cadera_cm >= " + filter.FromCircunferencia_de_cadera_cm;
                if (!string.IsNullOrEmpty(filter.ToCircunferencia_de_cadera_cm))
                    where += " AND Consultas.Circunferencia_de_cadera_cm <= " + filter.ToCircunferencia_de_cadera_cm;
            }

            if (!string.IsNullOrEmpty(filter.FromEdad_Metabolica) || !string.IsNullOrEmpty(filter.ToEdad_Metabolica))
            {
                if (!string.IsNullOrEmpty(filter.FromEdad_Metabolica))
                    where += " AND Consultas.Edad_Metabolica >= " + filter.FromEdad_Metabolica;
                if (!string.IsNullOrEmpty(filter.ToEdad_Metabolica))
                    where += " AND Consultas.Edad_Metabolica <= " + filter.ToEdad_Metabolica;
            }

            if (!string.IsNullOrEmpty(filter.FromAgua_corporal) || !string.IsNullOrEmpty(filter.ToAgua_corporal))
            {
                if (!string.IsNullOrEmpty(filter.FromAgua_corporal))
                    where += " AND Consultas.Agua_corporal >= " + filter.FromAgua_corporal;
                if (!string.IsNullOrEmpty(filter.ToAgua_corporal))
                    where += " AND Consultas.Agua_corporal <= " + filter.ToAgua_corporal;
            }

            if (!string.IsNullOrEmpty(filter.FromGrasa_Visceral) || !string.IsNullOrEmpty(filter.ToGrasa_Visceral))
            {
                if (!string.IsNullOrEmpty(filter.FromGrasa_Visceral))
                    where += " AND Consultas.Grasa_Visceral >= " + filter.FromGrasa_Visceral;
                if (!string.IsNullOrEmpty(filter.ToGrasa_Visceral))
                    where += " AND Consultas.Grasa_Visceral <= " + filter.ToGrasa_Visceral;
            }

            if (!string.IsNullOrEmpty(filter.FromGrasa_Corporal) || !string.IsNullOrEmpty(filter.ToGrasa_Corporal))
            {
                if (!string.IsNullOrEmpty(filter.FromGrasa_Corporal))
                    where += " AND Consultas.Grasa_Corporal >= " + filter.FromGrasa_Corporal;
                if (!string.IsNullOrEmpty(filter.ToGrasa_Corporal))
                    where += " AND Consultas.Grasa_Corporal <= " + filter.ToGrasa_Corporal;
            }

            if (!string.IsNullOrEmpty(filter.FromGrasa_Corporal_kg) || !string.IsNullOrEmpty(filter.ToGrasa_Corporal_kg))
            {
                if (!string.IsNullOrEmpty(filter.FromGrasa_Corporal_kg))
                    where += " AND Consultas.Grasa_Corporal_kg >= " + filter.FromGrasa_Corporal_kg;
                if (!string.IsNullOrEmpty(filter.ToGrasa_Corporal_kg))
                    where += " AND Consultas.Grasa_Corporal_kg <= " + filter.ToGrasa_Corporal_kg;
            }

            if (!string.IsNullOrEmpty(filter.FromMasa_Muscular_kg) || !string.IsNullOrEmpty(filter.ToMasa_Muscular_kg))
            {
                if (!string.IsNullOrEmpty(filter.FromMasa_Muscular_kg))
                    where += " AND Consultas.Masa_Muscular_kg >= " + filter.FromMasa_Muscular_kg;
                if (!string.IsNullOrEmpty(filter.ToMasa_Muscular_kg))
                    where += " AND Consultas.Masa_Muscular_kg <= " + filter.ToMasa_Muscular_kg;
            }

            if (!string.IsNullOrEmpty(filter.FromSemana_de_gestacion) || !string.IsNullOrEmpty(filter.ToSemana_de_gestacion))
            {
                if (!string.IsNullOrEmpty(filter.FromSemana_de_gestacion))
                    where += " AND Consultas.Semana_de_gestacion >= " + filter.FromSemana_de_gestacion;
                if (!string.IsNullOrEmpty(filter.ToSemana_de_gestacion))
                    where += " AND Consultas.Semana_de_gestacion <= " + filter.ToSemana_de_gestacion;
            }

            if (!string.IsNullOrEmpty(filter.FromIMC) || !string.IsNullOrEmpty(filter.ToIMC))
            {
                if (!string.IsNullOrEmpty(filter.FromIMC))
                    where += " AND Consultas.IMC >= " + filter.FromIMC;
                if (!string.IsNullOrEmpty(filter.ToIMC))
                    where += " AND Consultas.IMC <= " + filter.ToIMC;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceIMC_Pediatria))
            {
                switch (filter.IMC_PediatriaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Interpretacion_IMC.Descripcion LIKE '" + filter.AdvanceIMC_Pediatria + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Interpretacion_IMC.Descripcion LIKE '%" + filter.AdvanceIMC_Pediatria + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Interpretacion_IMC.Descripcion = '" + filter.AdvanceIMC_Pediatria + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Interpretacion_IMC.Descripcion LIKE '%" + filter.AdvanceIMC_Pediatria + "%'";
                        break;
                }
            }
            else if (filter.AdvanceIMC_PediatriaMultiple != null && filter.AdvanceIMC_PediatriaMultiple.Count() > 0)
            {
                var IMC_PediatriaIds = string.Join(",", filter.AdvanceIMC_PediatriaMultiple);

                where += " AND Consultas.IMC_Pediatria In (" + IMC_PediatriaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceInterpretacion_IMC))
            {
                switch (filter.Interpretacion_IMCFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Interpretacion_IMC.Descripcion LIKE '" + filter.AdvanceInterpretacion_IMC + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Interpretacion_IMC.Descripcion LIKE '%" + filter.AdvanceInterpretacion_IMC + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Interpretacion_IMC.Descripcion = '" + filter.AdvanceInterpretacion_IMC + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Interpretacion_IMC.Descripcion LIKE '%" + filter.AdvanceInterpretacion_IMC + "%'";
                        break;
                }
            }
            else if (filter.AdvanceInterpretacion_IMCMultiple != null && filter.AdvanceInterpretacion_IMCMultiple.Count() > 0)
            {
                var Interpretacion_IMCIds = string.Join(",", filter.AdvanceInterpretacion_IMCMultiple);

                where += " AND Consultas.Interpretacion_IMC In (" + Interpretacion_IMCIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromConsumo_de_agua_resultado) || !string.IsNullOrEmpty(filter.ToConsumo_de_agua_resultado))
            {
                if (!string.IsNullOrEmpty(filter.FromConsumo_de_agua_resultado))
                    where += " AND Consultas.Consumo_de_agua_resultado >= " + filter.FromConsumo_de_agua_resultado;
                if (!string.IsNullOrEmpty(filter.ToConsumo_de_agua_resultado))
                    where += " AND Consultas.Consumo_de_agua_resultado <= " + filter.ToConsumo_de_agua_resultado;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceInterpretacion_agua))
            {
                switch (filter.Interpretacion_aguaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Interpretacion_consumo_de_agua.Descripcion LIKE '" + filter.AdvanceInterpretacion_agua + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Interpretacion_consumo_de_agua.Descripcion LIKE '%" + filter.AdvanceInterpretacion_agua + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Interpretacion_consumo_de_agua.Descripcion = '" + filter.AdvanceInterpretacion_agua + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Interpretacion_consumo_de_agua.Descripcion LIKE '%" + filter.AdvanceInterpretacion_agua + "%'";
                        break;
                }
            }
            else if (filter.AdvanceInterpretacion_aguaMultiple != null && filter.AdvanceInterpretacion_aguaMultiple.Count() > 0)
            {
                var Interpretacion_aguaIds = string.Join(",", filter.AdvanceInterpretacion_aguaMultiple);

                where += " AND Consultas.Interpretacion_agua In (" + Interpretacion_aguaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromFrecuencia_cardiaca_en_Esfuerzo) || !string.IsNullOrEmpty(filter.ToFrecuencia_cardiaca_en_Esfuerzo))
            {
                if (!string.IsNullOrEmpty(filter.FromFrecuencia_cardiaca_en_Esfuerzo))
                    where += " AND Consultas.Frecuencia_cardiaca_en_Esfuerzo >= " + filter.FromFrecuencia_cardiaca_en_Esfuerzo;
                if (!string.IsNullOrEmpty(filter.ToFrecuencia_cardiaca_en_Esfuerzo))
                    where += " AND Consultas.Frecuencia_cardiaca_en_Esfuerzo <= " + filter.ToFrecuencia_cardiaca_en_Esfuerzo;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceInterpretacion_frecuencia))
            {
                switch (filter.Interpretacion_frecuenciaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion LIKE '" + filter.AdvanceInterpretacion_frecuencia + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion LIKE '%" + filter.AdvanceInterpretacion_frecuencia + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion = '" + filter.AdvanceInterpretacion_frecuencia + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion LIKE '%" + filter.AdvanceInterpretacion_frecuencia + "%'";
                        break;
                }
            }
            else if (filter.AdvanceInterpretacion_frecuenciaMultiple != null && filter.AdvanceInterpretacion_frecuenciaMultiple.Count() > 0)
            {
                var Interpretacion_frecuenciaIds = string.Join(",", filter.AdvanceInterpretacion_frecuenciaMultiple);

                where += " AND Consultas.Interpretacion_frecuencia In (" + Interpretacion_frecuenciaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromIndice_cintura_cadera) || !string.IsNullOrEmpty(filter.ToIndice_cintura_cadera))
            {
                if (!string.IsNullOrEmpty(filter.FromIndice_cintura_cadera))
                    where += " AND Consultas.Indice_cintura_cadera >= " + filter.FromIndice_cintura_cadera;
                if (!string.IsNullOrEmpty(filter.ToIndice_cintura_cadera))
                    where += " AND Consultas.Indice_cintura_cadera <= " + filter.ToIndice_cintura_cadera;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceInterpretacion_indice))
            {
                switch (filter.Interpretacion_indiceFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Interpretacion_indice_cintura__cadera.Descripcion LIKE '" + filter.AdvanceInterpretacion_indice + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Interpretacion_indice_cintura__cadera.Descripcion LIKE '%" + filter.AdvanceInterpretacion_indice + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Interpretacion_indice_cintura__cadera.Descripcion = '" + filter.AdvanceInterpretacion_indice + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Interpretacion_indice_cintura__cadera.Descripcion LIKE '%" + filter.AdvanceInterpretacion_indice + "%'";
                        break;
                }
            }
            else if (filter.AdvanceInterpretacion_indiceMultiple != null && filter.AdvanceInterpretacion_indiceMultiple.Count() > 0)
            {
                var Interpretacion_indiceIds = string.Join(",", filter.AdvanceInterpretacion_indiceMultiple);

                where += " AND Consultas.Interpretacion_indice In (" + Interpretacion_indiceIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromDificultad_de_Rutina_de_Ejercicios) || !string.IsNullOrEmpty(filter.ToDificultad_de_Rutina_de_Ejercicios))
            {
                if (!string.IsNullOrEmpty(filter.FromDificultad_de_Rutina_de_Ejercicios))
                    where += " AND Consultas.Dificultad_de_Rutina_de_Ejercicios >= " + filter.FromDificultad_de_Rutina_de_Ejercicios;
                if (!string.IsNullOrEmpty(filter.ToDificultad_de_Rutina_de_Ejercicios))
                    where += " AND Consultas.Dificultad_de_Rutina_de_Ejercicios <= " + filter.ToDificultad_de_Rutina_de_Ejercicios;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceInterpretacion_dificultad))
            {
                switch (filter.Interpretacion_dificultadFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion LIKE '" + filter.AdvanceInterpretacion_dificultad + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion LIKE '%" + filter.AdvanceInterpretacion_dificultad + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion = '" + filter.AdvanceInterpretacion_dificultad + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion LIKE '%" + filter.AdvanceInterpretacion_dificultad + "%'";
                        break;
                }
            }
            else if (filter.AdvanceInterpretacion_dificultadMultiple != null && filter.AdvanceInterpretacion_dificultadMultiple.Count() > 0)
            {
                var Interpretacion_dificultadIds = string.Join(",", filter.AdvanceInterpretacion_dificultadMultiple);

                where += " AND Consultas.Interpretacion_dificultad In (" + Interpretacion_dificultadIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromCalorias) || !string.IsNullOrEmpty(filter.ToCalorias))
            {
                if (!string.IsNullOrEmpty(filter.FromCalorias))
                    where += " AND Consultas.Calorias >= " + filter.FromCalorias;
                if (!string.IsNullOrEmpty(filter.ToCalorias))
                    where += " AND Consultas.Calorias <= " + filter.ToCalorias;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceInterpretacion_calorias))
            {
                switch (filter.Interpretacion_caloriasFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Interpretacion_Calorias.Descripcion LIKE '" + filter.AdvanceInterpretacion_calorias + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Interpretacion_Calorias.Descripcion LIKE '%" + filter.AdvanceInterpretacion_calorias + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Interpretacion_Calorias.Descripcion = '" + filter.AdvanceInterpretacion_calorias + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Interpretacion_Calorias.Descripcion LIKE '%" + filter.AdvanceInterpretacion_calorias + "%'";
                        break;
                }
            }
            else if (filter.AdvanceInterpretacion_caloriasMultiple != null && filter.AdvanceInterpretacion_caloriasMultiple.Count() > 0)
            {
                var Interpretacion_caloriasIds = string.Join(",", filter.AdvanceInterpretacion_caloriasMultiple);

                where += " AND Consultas.Interpretacion_calorias In (" + Interpretacion_caloriasIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Observaciones))
            {
                switch (filter.ObservacionesFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Consultas.Observaciones LIKE '" + filter.Observaciones + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Consultas.Observaciones LIKE '%" + filter.Observaciones + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Consultas.Observaciones = '" + filter.Observaciones + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Consultas.Observaciones LIKE '%" + filter.Observaciones + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_siguiente_Consulta) || !string.IsNullOrEmpty(filter.ToFecha_siguiente_Consulta))
            {
                var Fecha_siguiente_ConsultaFrom = DateTime.ParseExact(filter.FromFecha_siguiente_Consulta, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_siguiente_ConsultaTo = DateTime.ParseExact(filter.ToFecha_siguiente_Consulta, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_siguiente_Consulta))
                    where += " AND Consultas.Fecha_siguiente_Consulta >= '" + Fecha_siguiente_ConsultaFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_siguiente_Consulta))
                    where += " AND Consultas.Fecha_siguiente_Consulta <= '" + Fecha_siguiente_ConsultaTo.ToString("MM-dd-yyyy") + "'";
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

        public ActionResult GetDetalle_Resultados_Consultas(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Resultados_ConsultasGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Resultados_ConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Resultados_Consultas.Folio_Consultas=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Resultados_Consultas.Folio_Consultas='" + RelationId + "'";
            }
            var result = _IDetalle_Resultados_ConsultasApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Resultados_Consultass == null)
                result.Detalle_Resultados_Consultass = new List<Detalle_Resultados_Consultas>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Resultados_Consultass.Select(m => new Detalle_Resultados_ConsultasGridModel
                {
                    Folio = m.Folio

                        ,Folio_Pacientes = m.Folio_Pacientes
                        ,Folio_PacientesNombre_Completo = CultureHelper.GetTraduction(m.Folio_Pacientes_Pacientes.Folio.ToString(), "Nombre_Completo") ??(string)m.Folio_Pacientes_Pacientes.Nombre_Completo
			,Fecha_de_Consulta = (m.Fecha_de_Consulta == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Consulta).ToString(ConfigurationProperty.DateFormat))
                        ,Indicador = m.Indicador
                        ,IndicadorNombre = CultureHelper.GetTraduction(m.Indicador_Indicadores_Consultas.Clave.ToString(), "Nombre") ??(string)m.Indicador_Indicadores_Consultas.Nombre
			,Resultado = m.Resultado
			,Interpretacion = m.Interpretacion
			,IMC = m.IMC
			,IMC_Pediatria = m.IMC_Pediatria

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Resultados_ConsultasGridModel> GetDetalle_Resultados_ConsultasData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Resultados_ConsultasGridModel> resultData = new List<Detalle_Resultados_ConsultasGridModel>();
            string where = "Detalle_Resultados_Consultas.Folio_Consultas=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Resultados_Consultas.Folio_Consultas='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Resultados_ConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Resultados_ConsultasApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Resultados_Consultass != null)
            {
                resultData = result.Detalle_Resultados_Consultass.Select(m => new Detalle_Resultados_ConsultasGridModel
                    {
                        Folio = m.Folio

                        ,Folio_Pacientes = m.Folio_Pacientes
                        ,Folio_PacientesNombre_Completo = CultureHelper.GetTraduction(m.Folio_Pacientes_Pacientes.Folio.ToString(), "Nombre_Completo") ??(string)m.Folio_Pacientes_Pacientes.Nombre_Completo
			,Fecha_de_Consulta = (m.Fecha_de_Consulta == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Consulta).ToString(ConfigurationProperty.DateFormat))
                        ,Indicador = m.Indicador
                        ,IndicadorNombre = CultureHelper.GetTraduction(m.Indicador_Indicadores_Consultas.Clave.ToString(), "Nombre") ??(string)m.Indicador_Indicadores_Consultas.Nombre
			,Resultado = m.Resultado
			,Interpretacion = m.Interpretacion
			,IMC = m.IMC
			,IMC_Pediatria = m.IMC_Pediatria


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
                _IConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);

                Consultas varConsultas = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IDetalle_Resultados_ConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Resultados_Consultas.Folio_Consultas=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Resultados_Consultas.Folio_Consultas='" + id + "'";
                    }
                    var Detalle_Resultados_ConsultasInfo =
                        _IDetalle_Resultados_ConsultasApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Resultados_ConsultasInfo.Detalle_Resultados_Consultass.Count > 0)
                    {
                        var resultDetalle_Resultados_Consultas = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Resultados_ConsultasItem in Detalle_Resultados_ConsultasInfo.Detalle_Resultados_Consultass)
                            resultDetalle_Resultados_Consultas = resultDetalle_Resultados_Consultas
                                              && _IDetalle_Resultados_ConsultasApiConsumer.Delete(Detalle_Resultados_ConsultasItem.Folio, null,null).Resource;

                        if (!resultDetalle_Resultados_Consultas)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IConsultasApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, ConsultasModel varConsultas)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var ConsultasInfo = new Consultas
                    {
                        Folio = varConsultas.Folio
                        ,Fecha_de_Registo = (!String.IsNullOrEmpty(varConsultas.Fecha_de_Registo)) ? DateTime.ParseExact(varConsultas.Fecha_de_Registo, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varConsultas.Hora_de_Registro
                        ,Usuario_que_Registra = varConsultas.Usuario_que_Registra
                        ,Fecha_Programada = (!String.IsNullOrEmpty(varConsultas.Fecha_Programada)) ? DateTime.ParseExact(varConsultas.Fecha_Programada, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Paciente = varConsultas.Paciente
                        ,Edad = varConsultas.Edad
                        ,Nombre_del_padre = varConsultas.Nombre_del_padre
                        ,Sexo = varConsultas.Sexo
                        ,Email = varConsultas.Email
                        ,Objetivo = varConsultas.Objetivo
                        ,Frecuencia_Cardiaca = varConsultas.Frecuencia_Cardiaca
                        ,Presion_sistolica = varConsultas.Presion_sistolica
                        ,Presion_diastolica = varConsultas.Presion_diastolica
                        ,Peso_actual = varConsultas.Peso_actual
                        ,Estatura = varConsultas.Estatura
                        ,Circunferencia_de_cintura_cm = varConsultas.Circunferencia_de_cintura_cm
                        ,Circunferencia_de_cadera_cm = varConsultas.Circunferencia_de_cadera_cm
                        ,Edad_Metabolica = varConsultas.Edad_Metabolica
                        ,Agua_corporal = varConsultas.Agua_corporal
                        ,Grasa_Visceral = varConsultas.Grasa_Visceral
                        ,Grasa_Corporal = varConsultas.Grasa_Corporal
                        ,Grasa_Corporal_kg = varConsultas.Grasa_Corporal_kg
                        ,Masa_Muscular_kg = varConsultas.Masa_Muscular_kg
                        ,Semana_de_gestacion = varConsultas.Semana_de_gestacion
                        ,IMC = varConsultas.IMC
                        ,IMC_Pediatria = varConsultas.IMC_Pediatria
                        ,Interpretacion_IMC = varConsultas.Interpretacion_IMC
                        ,Consumo_de_agua_resultado = varConsultas.Consumo_de_agua_resultado
                        ,Interpretacion_agua = varConsultas.Interpretacion_agua
                        ,Frecuencia_cardiaca_en_Esfuerzo = varConsultas.Frecuencia_cardiaca_en_Esfuerzo
                        ,Interpretacion_frecuencia = varConsultas.Interpretacion_frecuencia
                        ,Indice_cintura_cadera = varConsultas.Indice_cintura_cadera
                        ,Interpretacion_indice = varConsultas.Interpretacion_indice
                        ,Dificultad_de_Rutina_de_Ejercicios = varConsultas.Dificultad_de_Rutina_de_Ejercicios
                        ,Interpretacion_dificultad = varConsultas.Interpretacion_dificultad
                        ,Calorias = varConsultas.Calorias
                        ,Interpretacion_calorias = varConsultas.Interpretacion_calorias
                        ,Observaciones = varConsultas.Observaciones
                        ,Fecha_siguiente_Consulta = (!String.IsNullOrEmpty(varConsultas.Fecha_siguiente_Consulta)) ? DateTime.ParseExact(varConsultas.Fecha_siguiente_Consulta, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null

                    };

                    result = !IsNew ?
                        _IConsultasApiConsumer.Update(ConsultasInfo, null, null).Resource.ToString() :
                         _IConsultasApiConsumer.Insert(ConsultasInfo, null, null).Resource.ToString();
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
        public bool CopyDetalle_Resultados_Consultas(int MasterId, int referenceId, List<Detalle_Resultados_ConsultasGridModelPost> Detalle_Resultados_ConsultasItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Resultados_ConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Resultados_ConsultasData = _IDetalle_Resultados_ConsultasApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Resultados_Consultas.Folio_Consultas=" + referenceId,"").Resource;
                if (Detalle_Resultados_ConsultasData == null || Detalle_Resultados_ConsultasData.Detalle_Resultados_Consultass.Count == 0)
                    return true;

                var result = true;

                Detalle_Resultados_ConsultasGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Resultados_Consultas in Detalle_Resultados_ConsultasData.Detalle_Resultados_Consultass)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Resultados_Consultas Detalle_Resultados_Consultas1 = varDetalle_Resultados_Consultas;

                    if (Detalle_Resultados_ConsultasItems != null && Detalle_Resultados_ConsultasItems.Any(m => m.Folio == Detalle_Resultados_Consultas1.Folio))
                    {
                        modelDataToChange = Detalle_Resultados_ConsultasItems.FirstOrDefault(m => m.Folio == Detalle_Resultados_Consultas1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Resultados_Consultas.Folio_Consultas = MasterId;
                    var insertId = _IDetalle_Resultados_ConsultasApiConsumer.Insert(varDetalle_Resultados_Consultas,null,null).Resource;
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
        public ActionResult PostDetalle_Resultados_Consultas(List<Detalle_Resultados_ConsultasGridModelPost> Detalle_Resultados_ConsultasItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Resultados_Consultas(MasterId, referenceId, Detalle_Resultados_ConsultasItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Resultados_ConsultasItems != null && Detalle_Resultados_ConsultasItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Resultados_ConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Resultados_ConsultasItem in Detalle_Resultados_ConsultasItems)
                    {









                        //Removal Request
                        if (Detalle_Resultados_ConsultasItem.Removed)
                        {
                            result = result && _IDetalle_Resultados_ConsultasApiConsumer.Delete(Detalle_Resultados_ConsultasItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Resultados_ConsultasItem.Folio = 0;

                        var Detalle_Resultados_ConsultasData = new Detalle_Resultados_Consultas
                        {
                            Folio_Consultas = MasterId
                            ,Folio = Detalle_Resultados_ConsultasItem.Folio
                            ,Folio_Pacientes = (Convert.ToInt32(Detalle_Resultados_ConsultasItem.Folio_Pacientes) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Resultados_ConsultasItem.Folio_Pacientes))
                            ,Fecha_de_Consulta = (Detalle_Resultados_ConsultasItem.Fecha_de_Consulta!= null) ? DateTime.ParseExact(Detalle_Resultados_ConsultasItem.Fecha_de_Consulta, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Indicador = (Convert.ToInt32(Detalle_Resultados_ConsultasItem.Indicador) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Resultados_ConsultasItem.Indicador))
                            ,Resultado = Detalle_Resultados_ConsultasItem.Resultado
                            ,Interpretacion = Detalle_Resultados_ConsultasItem.Interpretacion
                            ,IMC = Detalle_Resultados_ConsultasItem.IMC
                            ,IMC_Pediatria = Detalle_Resultados_ConsultasItem.IMC_Pediatria

                        };

                        var resultId = Detalle_Resultados_ConsultasItem.Folio > 0
                           ? _IDetalle_Resultados_ConsultasApiConsumer.Update(Detalle_Resultados_ConsultasData,null,null).Resource
                           : _IDetalle_Resultados_ConsultasApiConsumer.Insert(Detalle_Resultados_ConsultasData,null,null).Resource;

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
        public ActionResult GetDetalle_Resultados_Consultas_PacientesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPacientesApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Pacientes", "Nombre_Completo");
                  item.Nombre_Completo= trans??item.Nombre_Completo;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetDetalle_Resultados_Consultas_Indicadores_ConsultasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IIndicadores_ConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IIndicadores_ConsultasApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Indicadores_Consultas", "Nombre");
                  item.Nombre= trans??item.Nombre;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }







        /// <summary>
        /// Write Element Array of Consultas script
        /// </summary>
        /// <param name="oConsultasElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew ConsultasModuleAttributeList)
        {
            for (int i = 0; i < ConsultasModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(ConsultasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    ConsultasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(ConsultasModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    ConsultasModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (ConsultasModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < ConsultasModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < ConsultasModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(ConsultasModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							ConsultasModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(ConsultasModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							ConsultasModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strConsultasScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Consultas.js")))
            {
                strConsultasScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Consultas element attributes
            string userChangeJson = jsSerialize.Serialize(ConsultasModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strConsultasScript.IndexOf("inpuElementArray");
            string splittedString = strConsultasScript.Substring(indexOfArray, strConsultasScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(ConsultasModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (ConsultasModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strConsultasScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strConsultasScript.Substring(indexOfArrayHistory, strConsultasScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strConsultasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strConsultasScript.Substring(endIndexOfMainElement + indexOfArray, strConsultasScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (ConsultasModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in ConsultasModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Consultas.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Consultas.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Consultas.js")))
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
        public ActionResult ConsultasPropertyBag()
        {
            return PartialView("ConsultasPropertyBag", "Consultas");
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
        public ActionResult AddDetalle_Resultados_Consultas(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Resultados_Consultas/AddDetalle_Resultados_Consultas");
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
                var whereClauseFormat = "Object = 44352 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Consultas.Folio= " + RecordId;
                            var result = _IConsultasApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new ConsultasPropertyMapper());
			
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
                    (ConsultasAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            ConsultasPropertyMapper oConsultasPropertyMapper = new ConsultasPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oConsultasPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IConsultasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Consultass == null)
                result.Consultass = new List<Consultas>();

            var data = result.Consultass.Select(m => new ConsultasGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registo = (m.Fecha_de_Registo == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registo).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Fecha_Programada = (m.Fecha_Programada == null ? string.Empty : Convert.ToDateTime(m.Fecha_Programada).ToString(ConfigurationProperty.DateFormat))
                        ,PacienteNombre_Completo = CultureHelper.GetTraduction(m.Paciente_Pacientes.Folio.ToString(), "Pacientes") ?? (string)m.Paciente_Pacientes.Nombre_Completo
			,Edad = m.Edad
			,Nombre_del_padre = m.Nombre_del_padre
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Email = m.Email
                        ,ObjetivoDescripcion = CultureHelper.GetTraduction(m.Objetivo_Objetivos.Clave.ToString(), "Descripcion") ?? (string)m.Objetivo_Objetivos.Descripcion
			,Frecuencia_Cardiaca = m.Frecuencia_Cardiaca
			,Presion_sistolica = m.Presion_sistolica
			,Presion_diastolica = m.Presion_diastolica
			,Peso_actual = m.Peso_actual
			,Estatura = m.Estatura
			,Circunferencia_de_cintura_cm = m.Circunferencia_de_cintura_cm
			,Circunferencia_de_cadera_cm = m.Circunferencia_de_cadera_cm
			,Edad_Metabolica = m.Edad_Metabolica
			,Agua_corporal = m.Agua_corporal
			,Grasa_Visceral = m.Grasa_Visceral
			,Grasa_Corporal = m.Grasa_Corporal
			,Grasa_Corporal_kg = m.Grasa_Corporal_kg
			,Masa_Muscular_kg = m.Masa_Muscular_kg
			,Semana_de_gestacion = m.Semana_de_gestacion
			,IMC = m.IMC
                        ,IMC_PediatriaDescripcion = CultureHelper.GetTraduction(m.IMC_Pediatria_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.IMC_Pediatria_Interpretacion_IMC.Descripcion
                        ,Interpretacion_IMCDescripcion = CultureHelper.GetTraduction(m.Interpretacion_IMC_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_IMC_Interpretacion_IMC.Descripcion
			,Consumo_de_agua_resultado = m.Consumo_de_agua_resultado
                        ,Interpretacion_aguaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_agua_Interpretacion_consumo_de_agua.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_agua_Interpretacion_consumo_de_agua.Descripcion
			,Frecuencia_cardiaca_en_Esfuerzo = m.Frecuencia_cardiaca_en_Esfuerzo
                        ,Interpretacion_frecuenciaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion
			,Indice_cintura_cadera = m.Indice_cintura_cadera
                        ,Interpretacion_indiceDescripcion = CultureHelper.GetTraduction(m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Descripcion
			,Dificultad_de_Rutina_de_Ejercicios = m.Dificultad_de_Rutina_de_Ejercicios
                        ,Interpretacion_dificultadDescripcion = CultureHelper.GetTraduction(m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion
			,Calorias = m.Calorias
                        ,Interpretacion_caloriasDescripcion = CultureHelper.GetTraduction(m.Interpretacion_calorias_Interpretacion_Calorias.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_calorias_Interpretacion_Calorias.Descripcion
			,Observaciones = m.Observaciones
                        ,Fecha_siguiente_Consulta = (m.Fecha_siguiente_Consulta == null ? string.Empty : Convert.ToDateTime(m.Fecha_siguiente_Consulta).ToString(ConfigurationProperty.DateFormat))

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44352, arrayColumnsVisible), "ConsultasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44352, arrayColumnsVisible), "ConsultasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44352, arrayColumnsVisible), "ConsultasList_" + DateTime.Now.ToString());
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

            _IConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new ConsultasPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (ConsultasAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            ConsultasPropertyMapper oConsultasPropertyMapper = new ConsultasPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oConsultasPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IConsultasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Consultass == null)
                result.Consultass = new List<Consultas>();

            var data = result.Consultass.Select(m => new ConsultasGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registo = (m.Fecha_de_Registo == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registo).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Fecha_Programada = (m.Fecha_Programada == null ? string.Empty : Convert.ToDateTime(m.Fecha_Programada).ToString(ConfigurationProperty.DateFormat))
                        ,PacienteNombre_Completo = CultureHelper.GetTraduction(m.Paciente_Pacientes.Folio.ToString(), "Pacientes") ?? (string)m.Paciente_Pacientes.Nombre_Completo
			,Edad = m.Edad
			,Nombre_del_padre = m.Nombre_del_padre
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Email = m.Email
                        ,ObjetivoDescripcion = CultureHelper.GetTraduction(m.Objetivo_Objetivos.Clave.ToString(), "Descripcion") ?? (string)m.Objetivo_Objetivos.Descripcion
			,Frecuencia_Cardiaca = m.Frecuencia_Cardiaca
			,Presion_sistolica = m.Presion_sistolica
			,Presion_diastolica = m.Presion_diastolica
			,Peso_actual = m.Peso_actual
			,Estatura = m.Estatura
			,Circunferencia_de_cintura_cm = m.Circunferencia_de_cintura_cm
			,Circunferencia_de_cadera_cm = m.Circunferencia_de_cadera_cm
			,Edad_Metabolica = m.Edad_Metabolica
			,Agua_corporal = m.Agua_corporal
			,Grasa_Visceral = m.Grasa_Visceral
			,Grasa_Corporal = m.Grasa_Corporal
			,Grasa_Corporal_kg = m.Grasa_Corporal_kg
			,Masa_Muscular_kg = m.Masa_Muscular_kg
			,Semana_de_gestacion = m.Semana_de_gestacion
			,IMC = m.IMC
                        ,IMC_PediatriaDescripcion = CultureHelper.GetTraduction(m.IMC_Pediatria_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.IMC_Pediatria_Interpretacion_IMC.Descripcion
                        ,Interpretacion_IMCDescripcion = CultureHelper.GetTraduction(m.Interpretacion_IMC_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_IMC_Interpretacion_IMC.Descripcion
			,Consumo_de_agua_resultado = m.Consumo_de_agua_resultado
                        ,Interpretacion_aguaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_agua_Interpretacion_consumo_de_agua.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_agua_Interpretacion_consumo_de_agua.Descripcion
			,Frecuencia_cardiaca_en_Esfuerzo = m.Frecuencia_cardiaca_en_Esfuerzo
                        ,Interpretacion_frecuenciaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion
			,Indice_cintura_cadera = m.Indice_cintura_cadera
                        ,Interpretacion_indiceDescripcion = CultureHelper.GetTraduction(m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Descripcion
			,Dificultad_de_Rutina_de_Ejercicios = m.Dificultad_de_Rutina_de_Ejercicios
                        ,Interpretacion_dificultadDescripcion = CultureHelper.GetTraduction(m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion
			,Calorias = m.Calorias
                        ,Interpretacion_caloriasDescripcion = CultureHelper.GetTraduction(m.Interpretacion_calorias_Interpretacion_Calorias.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_calorias_Interpretacion_Calorias.Descripcion
			,Observaciones = m.Observaciones
                        ,Fecha_siguiente_Consulta = (m.Fecha_siguiente_Consulta == null ? string.Empty : Convert.ToDateTime(m.Fecha_siguiente_Consulta).ToString(ConfigurationProperty.DateFormat))

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
                _IConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IConsultasApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Consultas_Datos_GeneralesModel varConsultas)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Consultas_Datos_GeneralesInfo = new Consultas_Datos_Generales
                {
                    Folio = varConsultas.Folio
                                            ,Fecha_de_Registo = (!String.IsNullOrEmpty(varConsultas.Fecha_de_Registo)) ? DateTime.ParseExact(varConsultas.Fecha_de_Registo, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varConsultas.Hora_de_Registro
                        ,Usuario_que_Registra = varConsultas.Usuario_que_Registra
                        ,Fecha_Programada = (!String.IsNullOrEmpty(varConsultas.Fecha_Programada)) ? DateTime.ParseExact(varConsultas.Fecha_Programada, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Paciente = varConsultas.Paciente
                        ,Edad = varConsultas.Edad
                        ,Nombre_del_padre = varConsultas.Nombre_del_padre
                        ,Sexo = varConsultas.Sexo
                        ,Email = varConsultas.Email
                        ,Objetivo = varConsultas.Objetivo
                    
                };

                result = _IConsultasApiConsumer.Update_Datos_Generales(Consultas_Datos_GeneralesInfo).Resource.ToString();
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
                _IConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IConsultasApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Resultados_Consultas;
                var Detalle_Resultados_ConsultasData = GetDetalle_Resultados_ConsultasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Resultados_Consultas);

                var result = new Consultas_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registo = (m.Fecha_de_Registo == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registo).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
                        ,Fecha_Programada = (m.Fecha_Programada == null ? string.Empty : Convert.ToDateTime(m.Fecha_Programada).ToString(ConfigurationProperty.DateFormat))
                        ,Paciente = m.Paciente
                        ,PacienteNombre_Completo = CultureHelper.GetTraduction(m.Paciente_Pacientes.Folio.ToString(), "Pacientes") ?? (string)m.Paciente_Pacientes.Nombre_Completo
			,Edad = m.Edad
			,Nombre_del_padre = m.Nombre_del_padre
                        ,Sexo = m.Sexo
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Email = m.Email
                        ,Objetivo = m.Objetivo
                        ,ObjetivoDescripcion = CultureHelper.GetTraduction(m.Objetivo_Objetivos.Clave.ToString(), "Descripcion") ?? (string)m.Objetivo_Objetivos.Descripcion

                    
                };
				var resultData = new
                {
                    data = result
                    ,Resultados = Detalle_Resultados_ConsultasData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Mediciones(Consultas_MedicionesModel varConsultas)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Consultas_MedicionesInfo = new Consultas_Mediciones
                {
                    Folio = varConsultas.Folio
                                            ,Frecuencia_Cardiaca = varConsultas.Frecuencia_Cardiaca
                        ,Presion_sistolica = varConsultas.Presion_sistolica
                        ,Presion_diastolica = varConsultas.Presion_diastolica
                        ,Peso_actual = varConsultas.Peso_actual
                        ,Estatura = varConsultas.Estatura
                        ,Circunferencia_de_cintura_cm = varConsultas.Circunferencia_de_cintura_cm
                        ,Circunferencia_de_cadera_cm = varConsultas.Circunferencia_de_cadera_cm
                        ,Edad_Metabolica = varConsultas.Edad_Metabolica
                        ,Agua_corporal = varConsultas.Agua_corporal
                        ,Grasa_Visceral = varConsultas.Grasa_Visceral
                        ,Grasa_Corporal = varConsultas.Grasa_Corporal
                        ,Grasa_Corporal_kg = varConsultas.Grasa_Corporal_kg
                        ,Masa_Muscular_kg = varConsultas.Masa_Muscular_kg
                        ,Semana_de_gestacion = varConsultas.Semana_de_gestacion
                    
                };

                result = _IConsultasApiConsumer.Update_Mediciones(Consultas_MedicionesInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Mediciones(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IConsultasApiConsumer.Get_Mediciones(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Resultados_Consultas;
                var Detalle_Resultados_ConsultasData = GetDetalle_Resultados_ConsultasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Resultados_Consultas);

                var result = new Consultas_MedicionesModel
                {
                    Folio = m.Folio
			,Frecuencia_Cardiaca = m.Frecuencia_Cardiaca
			,Presion_sistolica = m.Presion_sistolica
			,Presion_diastolica = m.Presion_diastolica
			,Peso_actual = m.Peso_actual
			,Estatura = m.Estatura
			,Circunferencia_de_cintura_cm = m.Circunferencia_de_cintura_cm
			,Circunferencia_de_cadera_cm = m.Circunferencia_de_cadera_cm
			,Edad_Metabolica = m.Edad_Metabolica
			,Agua_corporal = m.Agua_corporal
			,Grasa_Visceral = m.Grasa_Visceral
			,Grasa_Corporal = m.Grasa_Corporal
			,Grasa_Corporal_kg = m.Grasa_Corporal_kg
			,Masa_Muscular_kg = m.Masa_Muscular_kg
			,Semana_de_gestacion = m.Semana_de_gestacion

                    
                };
				var resultData = new
                {
                    data = result
                    ,Resultados = Detalle_Resultados_ConsultasData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Resultados(Consultas_ResultadosModel varConsultas)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Consultas_ResultadosInfo = new Consultas_Resultados
                {
                    Folio = varConsultas.Folio
                                            ,IMC = varConsultas.IMC
                        ,IMC_Pediatria = varConsultas.IMC_Pediatria
                        ,Interpretacion_IMC = varConsultas.Interpretacion_IMC
                        ,Consumo_de_agua_resultado = varConsultas.Consumo_de_agua_resultado
                        ,Interpretacion_agua = varConsultas.Interpretacion_agua
                        ,Frecuencia_cardiaca_en_Esfuerzo = varConsultas.Frecuencia_cardiaca_en_Esfuerzo
                        ,Interpretacion_frecuencia = varConsultas.Interpretacion_frecuencia
                        ,Indice_cintura_cadera = varConsultas.Indice_cintura_cadera
                        ,Interpretacion_indice = varConsultas.Interpretacion_indice
                        ,Dificultad_de_Rutina_de_Ejercicios = varConsultas.Dificultad_de_Rutina_de_Ejercicios
                        ,Interpretacion_dificultad = varConsultas.Interpretacion_dificultad
                        ,Calorias = varConsultas.Calorias
                        ,Interpretacion_calorias = varConsultas.Interpretacion_calorias
                        ,Observaciones = varConsultas.Observaciones
                        ,Fecha_siguiente_Consulta = (!String.IsNullOrEmpty(varConsultas.Fecha_siguiente_Consulta)) ? DateTime.ParseExact(varConsultas.Fecha_siguiente_Consulta, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                    
                };

                result = _IConsultasApiConsumer.Update_Resultados(Consultas_ResultadosInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Resultados(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IConsultasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IConsultasApiConsumer.Get_Resultados(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Resultados_Consultas;
                var Detalle_Resultados_ConsultasData = GetDetalle_Resultados_ConsultasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Resultados_Consultas);

                var result = new Consultas_ResultadosModel
                {
                    Folio = m.Folio
			,IMC = m.IMC
                        ,IMC_Pediatria = m.IMC_Pediatria
                        ,IMC_PediatriaDescripcion = CultureHelper.GetTraduction(m.IMC_Pediatria_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.IMC_Pediatria_Interpretacion_IMC.Descripcion
                        ,Interpretacion_IMC = m.Interpretacion_IMC
                        ,Interpretacion_IMCDescripcion = CultureHelper.GetTraduction(m.Interpretacion_IMC_Interpretacion_IMC.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_IMC_Interpretacion_IMC.Descripcion
			,Consumo_de_agua_resultado = m.Consumo_de_agua_resultado
                        ,Interpretacion_agua = m.Interpretacion_agua
                        ,Interpretacion_aguaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_agua_Interpretacion_consumo_de_agua.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_agua_Interpretacion_consumo_de_agua.Descripcion
			,Frecuencia_cardiaca_en_Esfuerzo = m.Frecuencia_cardiaca_en_Esfuerzo
                        ,Interpretacion_frecuencia = m.Interpretacion_frecuencia
                        ,Interpretacion_frecuenciaDescripcion = CultureHelper.GetTraduction(m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_frecuencia_Interpretacion_Frecuencia_cardiaca_en_Esfuerzo.Descripcion
			,Indice_cintura_cadera = m.Indice_cintura_cadera
                        ,Interpretacion_indice = m.Interpretacion_indice
                        ,Interpretacion_indiceDescripcion = CultureHelper.GetTraduction(m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_indice_Interpretacion_indice_cintura__cadera.Descripcion
			,Dificultad_de_Rutina_de_Ejercicios = m.Dificultad_de_Rutina_de_Ejercicios
                        ,Interpretacion_dificultad = m.Interpretacion_dificultad
                        ,Interpretacion_dificultadDescripcion = CultureHelper.GetTraduction(m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_dificultad_Interpretacion_Dificultad_de_Rutina_de_Ejercicios.Descripcion
			,Calorias = m.Calorias
                        ,Interpretacion_calorias = m.Interpretacion_calorias
                        ,Interpretacion_caloriasDescripcion = CultureHelper.GetTraduction(m.Interpretacion_calorias_Interpretacion_Calorias.Folio.ToString(), "Descripcion") ?? (string)m.Interpretacion_calorias_Interpretacion_Calorias.Descripcion
			,Observaciones = m.Observaciones
                        ,Fecha_siguiente_Consulta = (m.Fecha_siguiente_Consulta == null ? string.Empty : Convert.ToDateTime(m.Fecha_siguiente_Consulta).ToString(ConfigurationProperty.DateFormat))

                    
                };
				var resultData = new
                {
                    data = result
                    ,Resultados = Detalle_Resultados_ConsultasData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

