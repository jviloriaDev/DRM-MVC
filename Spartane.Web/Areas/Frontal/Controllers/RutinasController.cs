using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Rutinas;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Nivel_de_dificultad;
using Spartane.Core.Domain.Nivel_de_Intensidad;
using Spartane.Core.Domain.Sexo;
using Spartane.Core.Domain.Estatus;
using Spartane.Core.Domain.Detalle_Ejercicios_Rutinas;



using Spartane.Core.Domain.Ejercicios;



using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Rutinas;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Rutinas;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Nivel_de_dificultad;
using Spartane.Web.Areas.WebApiConsumer.Nivel_de_Intensidad;
using Spartane.Web.Areas.WebApiConsumer.Sexo;
using Spartane.Web.Areas.WebApiConsumer.Estatus;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Ejercicios_Rutinas;

using Spartane.Web.Areas.WebApiConsumer.Ejercicios;


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
    public class RutinasController : Controller
    {
        #region "variable declaration"

        private IRutinasService service = null;
        private IRutinasApiConsumer _IRutinasApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private INivel_de_dificultadApiConsumer _INivel_de_dificultadApiConsumer;
        private INivel_de_IntensidadApiConsumer _INivel_de_IntensidadApiConsumer;
        private ISexoApiConsumer _ISexoApiConsumer;
        private IEstatusApiConsumer _IEstatusApiConsumer;
        private IDetalle_Ejercicios_RutinasApiConsumer _IDetalle_Ejercicios_RutinasApiConsumer;

        private IEjerciciosApiConsumer _IEjerciciosApiConsumer;


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

        
        public RutinasController(IRutinasService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IRutinasApiConsumer RutinasApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , INivel_de_dificultadApiConsumer Nivel_de_dificultadApiConsumer , INivel_de_IntensidadApiConsumer Nivel_de_IntensidadApiConsumer , ISexoApiConsumer SexoApiConsumer , IEstatusApiConsumer EstatusApiConsumer , IDetalle_Ejercicios_RutinasApiConsumer Detalle_Ejercicios_RutinasApiConsumer , IEjerciciosApiConsumer EjerciciosApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IRutinasApiConsumer = RutinasApiConsumer;
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
            this._INivel_de_dificultadApiConsumer = Nivel_de_dificultadApiConsumer;
            this._INivel_de_IntensidadApiConsumer = Nivel_de_IntensidadApiConsumer;
            this._ISexoApiConsumer = SexoApiConsumer;
            this._IEstatusApiConsumer = EstatusApiConsumer;
            this._IDetalle_Ejercicios_RutinasApiConsumer = Detalle_Ejercicios_RutinasApiConsumer;

            this._IEjerciciosApiConsumer = EjerciciosApiConsumer;


        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Rutinas
        [ObjectAuth(ObjectId = (ModuleObjectId)44572, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44572, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Rutinas/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44572, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44572, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varRutinas = new RutinasModel();
			varRutinas.Folio = Id;
			
            ViewBag.ObjectId = "44572";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionDetalle_Ejercicios_Rutinas = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44575, ModuleId);
            ViewBag.PermissionDetalle_Ejercicios_Rutinas = permissionDetalle_Ejercicios_Rutinas;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IRutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var RutinassData = _IRutinasApiConsumer.ListaSelAll(0, 1000, "Rutinas.Folio=" + Id, "").Resource.Rutinass;
				
				if (RutinassData != null && RutinassData.Count > 0)
                {
					var RutinasData = RutinassData.First();
					varRutinas= new RutinasModel
					{
						Folio  = RutinasData.Folio 
	                    ,Fecha_de_Registro = (RutinasData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(RutinasData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = RutinasData.Hora_de_Registro
                    ,Usuario_que_Registra = RutinasData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(RutinasData.Usuario_que_Registra), "Spartan_User") ??  (string)RutinasData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre_de_la_Rutina = RutinasData.Nombre_de_la_Rutina
                    ,Descripcion = RutinasData.Descripcion
                    ,Equipamento = RutinasData.Equipamento
                    ,Equipamento_alterno = RutinasData.Equipamento_alterno
                    ,Nivel_de_dificultad = RutinasData.Nivel_de_dificultad
                    ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(Convert.ToString(RutinasData.Nivel_de_dificultad), "Nivel_de_dificultad") ??  (string)RutinasData.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                    ,Intensidad = RutinasData.Intensidad
                    ,IntensidadIntensidad = CultureHelper.GetTraduction(Convert.ToString(RutinasData.Intensidad), "Nivel_de_Intensidad") ??  (string)RutinasData.Intensidad_Nivel_de_Intensidad.Intensidad
                    ,Duracion_aproximada_minutos = RutinasData.Duracion_aproximada_minutos
                    ,Genero = RutinasData.Genero
                    ,GeneroDescripcion = CultureHelper.GetTraduction(Convert.ToString(RutinasData.Genero), "Sexo") ??  (string)RutinasData.Genero_Sexo.Descripcion
                    ,Estatus = RutinasData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(RutinasData.Estatus), "Estatus") ??  (string)RutinasData.Estatus_Estatus.Descripcion

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
	    _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_dificultads_Nivel_de_dificultad = _INivel_de_dificultadApiConsumer.SelAll(true);
            if (Nivel_de_dificultads_Nivel_de_dificultad != null && Nivel_de_dificultads_Nivel_de_dificultad.Resource != null)
                ViewBag.Nivel_de_dificultads_Nivel_de_dificultad = Nivel_de_dificultads_Nivel_de_dificultad.Resource.Where(m => m.Dificultad != null).OrderBy(m => m.Dificultad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_dificultad", "Dificultad") ?? m.Dificultad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
	    _INivel_de_IntensidadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_Intensidads_Intensidad = _INivel_de_IntensidadApiConsumer.SelAll(true);
            if (Nivel_de_Intensidads_Intensidad != null && Nivel_de_Intensidads_Intensidad.Resource != null)
                ViewBag.Nivel_de_Intensidads_Intensidad = Nivel_de_Intensidads_Intensidad.Resource.Where(m => m.Intensidad != null).OrderBy(m => m.Intensidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_Intensidad", "Intensidad") ?? m.Intensidad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Genero = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Genero != null && Sexos_Genero.Resource != null)
                ViewBag.Sexos_Genero = Sexos_Genero.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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

				
            return View(varRutinas);
        }
		
	[HttpGet]
        public ActionResult AddRutinas(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44572);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IRutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
			RutinasModel varRutinas= new RutinasModel();
            var permissionDetalle_Ejercicios_Rutinas = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44575, ModuleId);
            ViewBag.PermissionDetalle_Ejercicios_Rutinas = permissionDetalle_Ejercicios_Rutinas;


            if (id.ToString() != "0")
            {
                var RutinassData = _IRutinasApiConsumer.ListaSelAll(0, 1000, "Rutinas.Folio=" + id, "").Resource.Rutinass;
				
				if (RutinassData != null && RutinassData.Count > 0)
                {
					var RutinasData = RutinassData.First();
					varRutinas= new RutinasModel
					{
						Folio  = RutinasData.Folio 
	                    ,Fecha_de_Registro = (RutinasData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(RutinasData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = RutinasData.Hora_de_Registro
                    ,Usuario_que_Registra = RutinasData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(RutinasData.Usuario_que_Registra), "Spartan_User") ??  (string)RutinasData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre_de_la_Rutina = RutinasData.Nombre_de_la_Rutina
                    ,Descripcion = RutinasData.Descripcion
                    ,Equipamento = RutinasData.Equipamento
                    ,Equipamento_alterno = RutinasData.Equipamento_alterno
                    ,Nivel_de_dificultad = RutinasData.Nivel_de_dificultad
                    ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(Convert.ToString(RutinasData.Nivel_de_dificultad), "Nivel_de_dificultad") ??  (string)RutinasData.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                    ,Intensidad = RutinasData.Intensidad
                    ,IntensidadIntensidad = CultureHelper.GetTraduction(Convert.ToString(RutinasData.Intensidad), "Nivel_de_Intensidad") ??  (string)RutinasData.Intensidad_Nivel_de_Intensidad.Intensidad
                    ,Duracion_aproximada_minutos = RutinasData.Duracion_aproximada_minutos
                    ,Genero = RutinasData.Genero
                    ,GeneroDescripcion = CultureHelper.GetTraduction(Convert.ToString(RutinasData.Genero), "Sexo") ??  (string)RutinasData.Genero_Sexo.Descripcion
                    ,Estatus = RutinasData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(RutinasData.Estatus), "Estatus") ??  (string)RutinasData.Estatus_Estatus.Descripcion

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
	    _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_dificultads_Nivel_de_dificultad = _INivel_de_dificultadApiConsumer.SelAll(true);
            if (Nivel_de_dificultads_Nivel_de_dificultad != null && Nivel_de_dificultads_Nivel_de_dificultad.Resource != null)
                ViewBag.Nivel_de_dificultads_Nivel_de_dificultad = Nivel_de_dificultads_Nivel_de_dificultad.Resource.Where(m => m.Dificultad != null).OrderBy(m => m.Dificultad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_dificultad", "Dificultad") ?? m.Dificultad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
	    _INivel_de_IntensidadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_Intensidads_Intensidad = _INivel_de_IntensidadApiConsumer.SelAll(true);
            if (Nivel_de_Intensidads_Intensidad != null && Nivel_de_Intensidads_Intensidad.Resource != null)
                ViewBag.Nivel_de_Intensidads_Intensidad = Nivel_de_Intensidads_Intensidad.Resource.Where(m => m.Intensidad != null).OrderBy(m => m.Intensidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_Intensidad", "Intensidad") ?? m.Intensidad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Genero = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Genero != null && Sexos_Genero.Resource != null)
                ViewBag.Sexos_Genero = Sexos_Genero.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddRutinas", varRutinas);
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
        public ActionResult GetNivel_de_dificultadAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _INivel_de_dificultadApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Dificultad).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_dificultad", "Dificultad")?? m.Dificultad,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
		[HttpGet]
        public ActionResult GetNivel_de_IntensidadAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _INivel_de_IntensidadApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _INivel_de_IntensidadApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Intensidad).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_Intensidad", "Intensidad")?? m.Intensidad,
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
        public ActionResult ShowAdvanceFilter(RutinasAdvanceSearchModel model, int idFilter = -1)
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
	    _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_dificultads_Nivel_de_dificultad = _INivel_de_dificultadApiConsumer.SelAll(true);
            if (Nivel_de_dificultads_Nivel_de_dificultad != null && Nivel_de_dificultads_Nivel_de_dificultad.Resource != null)
                ViewBag.Nivel_de_dificultads_Nivel_de_dificultad = Nivel_de_dificultads_Nivel_de_dificultad.Resource.Where(m => m.Dificultad != null).OrderBy(m => m.Dificultad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_dificultad", "Dificultad") ?? m.Dificultad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
	    _INivel_de_IntensidadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_Intensidads_Intensidad = _INivel_de_IntensidadApiConsumer.SelAll(true);
            if (Nivel_de_Intensidads_Intensidad != null && Nivel_de_Intensidads_Intensidad.Resource != null)
                ViewBag.Nivel_de_Intensidads_Intensidad = Nivel_de_Intensidads_Intensidad.Resource.Where(m => m.Intensidad != null).OrderBy(m => m.Intensidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_Intensidad", "Intensidad") ?? m.Intensidad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Genero = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Genero != null && Sexos_Genero.Resource != null)
                ViewBag.Sexos_Genero = Sexos_Genero.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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
	    _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_dificultads_Nivel_de_dificultad = _INivel_de_dificultadApiConsumer.SelAll(true);
            if (Nivel_de_dificultads_Nivel_de_dificultad != null && Nivel_de_dificultads_Nivel_de_dificultad.Resource != null)
                ViewBag.Nivel_de_dificultads_Nivel_de_dificultad = Nivel_de_dificultads_Nivel_de_dificultad.Resource.Where(m => m.Dificultad != null).OrderBy(m => m.Dificultad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_dificultad", "Dificultad") ?? m.Dificultad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
	    _INivel_de_IntensidadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_Intensidads_Intensidad = _INivel_de_IntensidadApiConsumer.SelAll(true);
            if (Nivel_de_Intensidads_Intensidad != null && Nivel_de_Intensidads_Intensidad.Resource != null)
                ViewBag.Nivel_de_Intensidads_Intensidad = Nivel_de_Intensidads_Intensidad.Resource.Where(m => m.Intensidad != null).OrderBy(m => m.Intensidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_Intensidad", "Intensidad") ?? m.Intensidad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Genero = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Genero != null && Sexos_Genero.Resource != null)
                ViewBag.Sexos_Genero = Sexos_Genero.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sexo", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            var previousFiltersObj = new RutinasAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (RutinasAdvanceSearchModel)(Session["AdvanceSearch"] ?? new RutinasAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new RutinasPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IRutinasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Rutinass == null)
                result.Rutinass = new List<Rutinas>();

            return Json(new
            {
                data = result.Rutinass.Select(m => new RutinasGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_la_Rutina = m.Nombre_de_la_Rutina
			,Descripcion = m.Descripcion
			,Equipamento = m.Equipamento
			,Equipamento_alterno = m.Equipamento_alterno
                        ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_dificultad_Nivel_de_dificultad.Folio.ToString(), "Nivel_de_dificultad") ?? (string)m.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                        ,IntensidadIntensidad = CultureHelper.GetTraduction(m.Intensidad_Nivel_de_Intensidad.Folio.ToString(), "Nivel_de_Intensidad") ?? (string)m.Intensidad_Nivel_de_Intensidad.Intensidad
			,Duracion_aproximada_minutos = m.Duracion_aproximada_minutos
                        ,GeneroDescripcion = CultureHelper.GetTraduction(m.Genero_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Genero_Sexo.Descripcion
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetRutinasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRutinasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Rutinas", m.),
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
        /// Get List of Rutinas from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Rutinas Entity</returns>
        public ActionResult GetRutinasList(UrlParametersModel param)
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
            _IRutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new RutinasPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(RutinasAdvanceSearchModel))
                {
					var advanceFilter =
                    (RutinasAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            RutinasPropertyMapper oRutinasPropertyMapper = new RutinasPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oRutinasPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IRutinasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Rutinass == null)
                result.Rutinass = new List<Rutinas>();

            return Json(new
            {
                aaData = result.Rutinass.Select(m => new RutinasGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_la_Rutina = m.Nombre_de_la_Rutina
			,Descripcion = m.Descripcion
			,Equipamento = m.Equipamento
			,Equipamento_alterno = m.Equipamento_alterno
                        ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_dificultad_Nivel_de_dificultad.Folio.ToString(), "Nivel_de_dificultad") ?? (string)m.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                        ,IntensidadIntensidad = CultureHelper.GetTraduction(m.Intensidad_Nivel_de_Intensidad.Folio.ToString(), "Nivel_de_Intensidad") ?? (string)m.Intensidad_Nivel_de_Intensidad.Intensidad
			,Duracion_aproximada_minutos = m.Duracion_aproximada_minutos
                        ,GeneroDescripcion = CultureHelper.GetTraduction(m.Genero_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Genero_Sexo.Descripcion
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetRutinas_Nivel_de_dificultad_Nivel_de_dificultad(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Nivel_de_dificultad.Folio as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Nivel_de_dificultad.Dificultad as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _INivel_de_dificultadApiConsumer.ListaSelAll(1, 20,elWhere , " Nivel_de_dificultad.Dificultad ASC ").Resource;
               
                foreach (var item in result.Nivel_de_dificultads)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Nivel_de_dificultad", "Dificultad");
                    item.Dificultad =trans ??item.Dificultad;
                }
                return Json(result.Nivel_de_dificultads.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetRutinas_Intensidad_Nivel_de_Intensidad(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _INivel_de_IntensidadApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Nivel_de_Intensidad.Folio as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Nivel_de_Intensidad.Intensidad as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _INivel_de_IntensidadApiConsumer.ListaSelAll(1, 20,elWhere , " Nivel_de_Intensidad.Intensidad ASC ").Resource;
               
                foreach (var item in result.Nivel_de_Intensidads)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Nivel_de_Intensidad", "Intensidad");
                    item.Intensidad =trans ??item.Intensidad;
                }
                return Json(result.Nivel_de_Intensidads.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(RutinasAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Rutinas.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Rutinas.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Rutinas.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Rutinas.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Rutinas.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Rutinas.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
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

                where += " AND Rutinas.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombre_de_la_Rutina))
            {
                switch (filter.Nombre_de_la_RutinaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Rutinas.Nombre_de_la_Rutina LIKE '" + filter.Nombre_de_la_Rutina + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Rutinas.Nombre_de_la_Rutina LIKE '%" + filter.Nombre_de_la_Rutina + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Rutinas.Nombre_de_la_Rutina = '" + filter.Nombre_de_la_Rutina + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Rutinas.Nombre_de_la_Rutina LIKE '%" + filter.Nombre_de_la_Rutina + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Descripcion))
            {
                switch (filter.DescripcionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Rutinas.Descripcion LIKE '" + filter.Descripcion + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Rutinas.Descripcion LIKE '%" + filter.Descripcion + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Rutinas.Descripcion = '" + filter.Descripcion + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Rutinas.Descripcion LIKE '%" + filter.Descripcion + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Equipamento))
            {
                switch (filter.EquipamentoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Rutinas.Equipamento LIKE '" + filter.Equipamento + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Rutinas.Equipamento LIKE '%" + filter.Equipamento + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Rutinas.Equipamento = '" + filter.Equipamento + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Rutinas.Equipamento LIKE '%" + filter.Equipamento + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Equipamento_alterno))
            {
                switch (filter.Equipamento_alternoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Rutinas.Equipamento_alterno LIKE '" + filter.Equipamento_alterno + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Rutinas.Equipamento_alterno LIKE '%" + filter.Equipamento_alterno + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Rutinas.Equipamento_alterno = '" + filter.Equipamento_alterno + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Rutinas.Equipamento_alterno LIKE '%" + filter.Equipamento_alterno + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceNivel_de_dificultad))
            {
                switch (filter.Nivel_de_dificultadFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Nivel_de_dificultad.Dificultad LIKE '" + filter.AdvanceNivel_de_dificultad + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Nivel_de_dificultad.Dificultad LIKE '%" + filter.AdvanceNivel_de_dificultad + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Nivel_de_dificultad.Dificultad = '" + filter.AdvanceNivel_de_dificultad + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Nivel_de_dificultad.Dificultad LIKE '%" + filter.AdvanceNivel_de_dificultad + "%'";
                        break;
                }
            }
            else if (filter.AdvanceNivel_de_dificultadMultiple != null && filter.AdvanceNivel_de_dificultadMultiple.Count() > 0)
            {
                var Nivel_de_dificultadIds = string.Join(",", filter.AdvanceNivel_de_dificultadMultiple);

                where += " AND Rutinas.Nivel_de_dificultad In (" + Nivel_de_dificultadIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceIntensidad))
            {
                switch (filter.IntensidadFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Nivel_de_Intensidad.Intensidad LIKE '" + filter.AdvanceIntensidad + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Nivel_de_Intensidad.Intensidad LIKE '%" + filter.AdvanceIntensidad + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Nivel_de_Intensidad.Intensidad = '" + filter.AdvanceIntensidad + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Nivel_de_Intensidad.Intensidad LIKE '%" + filter.AdvanceIntensidad + "%'";
                        break;
                }
            }
            else if (filter.AdvanceIntensidadMultiple != null && filter.AdvanceIntensidadMultiple.Count() > 0)
            {
                var IntensidadIds = string.Join(",", filter.AdvanceIntensidadMultiple);

                where += " AND Rutinas.Intensidad In (" + IntensidadIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromDuracion_aproximada_minutos) || !string.IsNullOrEmpty(filter.ToDuracion_aproximada_minutos))
            {
                if (!string.IsNullOrEmpty(filter.FromDuracion_aproximada_minutos))
                    where += " AND Rutinas.Duracion_aproximada_minutos >= " + filter.FromDuracion_aproximada_minutos;
                if (!string.IsNullOrEmpty(filter.ToDuracion_aproximada_minutos))
                    where += " AND Rutinas.Duracion_aproximada_minutos <= " + filter.ToDuracion_aproximada_minutos;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceGenero))
            {
                switch (filter.GeneroFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Sexo.Descripcion LIKE '" + filter.AdvanceGenero + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Sexo.Descripcion LIKE '%" + filter.AdvanceGenero + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Sexo.Descripcion = '" + filter.AdvanceGenero + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Sexo.Descripcion LIKE '%" + filter.AdvanceGenero + "%'";
                        break;
                }
            }
            else if (filter.AdvanceGeneroMultiple != null && filter.AdvanceGeneroMultiple.Count() > 0)
            {
                var GeneroIds = string.Join(",", filter.AdvanceGeneroMultiple);

                where += " AND Rutinas.Genero In (" + GeneroIds + ")";
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

                where += " AND Rutinas.Estatus In (" + EstatusIds + ")";
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

        public ActionResult GetDetalle_Ejercicios_Rutinas(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Ejercicios_RutinasGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Ejercicios_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Ejercicios_Rutinas.Folio_Rutinas=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Ejercicios_Rutinas.Folio_Rutinas='" + RelationId + "'";
            }
            var result = _IDetalle_Ejercicios_RutinasApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Ejercicios_Rutinass == null)
                result.Detalle_Ejercicios_Rutinass = new List<Detalle_Ejercicios_Rutinas>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Ejercicios_Rutinass.Select(m => new Detalle_Ejercicios_RutinasGridModel
                {
                    Folio = m.Folio

			,Orden_de_realizacion = m.Orden_de_realizacion
			,Numero_de_serie = m.Numero_de_serie
                        ,Ejercicio = m.Ejercicio
                        ,EjercicioNombre_del_Ejercicio = CultureHelper.GetTraduction(m.Ejercicio_Ejercicios.Clave.ToString(), "Nombre_del_Ejercicio") ??(string)m.Ejercicio_Ejercicios.Nombre_del_Ejercicio
			,Cantidad_de_Repeticiones = m.Cantidad_de_Repeticiones

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Ejercicios_RutinasGridModel> GetDetalle_Ejercicios_RutinasData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Ejercicios_RutinasGridModel> resultData = new List<Detalle_Ejercicios_RutinasGridModel>();
            string where = "Detalle_Ejercicios_Rutinas.Folio_Rutinas=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Ejercicios_Rutinas.Folio_Rutinas='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Ejercicios_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Ejercicios_RutinasApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Ejercicios_Rutinass != null)
            {
                resultData = result.Detalle_Ejercicios_Rutinass.Select(m => new Detalle_Ejercicios_RutinasGridModel
                    {
                        Folio = m.Folio

			,Orden_de_realizacion = m.Orden_de_realizacion
			,Numero_de_serie = m.Numero_de_serie
                        ,Ejercicio = m.Ejercicio
                        ,EjercicioNombre_del_Ejercicio = CultureHelper.GetTraduction(m.Ejercicio_Ejercicios.Clave.ToString(), "Nombre_del_Ejercicio") ??(string)m.Ejercicio_Ejercicios.Nombre_del_Ejercicio
			,Cantidad_de_Repeticiones = m.Cantidad_de_Repeticiones


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
                _IRutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

                Rutinas varRutinas = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IDetalle_Ejercicios_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Ejercicios_Rutinas.Folio_Rutinas=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Ejercicios_Rutinas.Folio_Rutinas='" + id + "'";
                    }
                    var Detalle_Ejercicios_RutinasInfo =
                        _IDetalle_Ejercicios_RutinasApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Ejercicios_RutinasInfo.Detalle_Ejercicios_Rutinass.Count > 0)
                    {
                        var resultDetalle_Ejercicios_Rutinas = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Ejercicios_RutinasItem in Detalle_Ejercicios_RutinasInfo.Detalle_Ejercicios_Rutinass)
                            resultDetalle_Ejercicios_Rutinas = resultDetalle_Ejercicios_Rutinas
                                              && _IDetalle_Ejercicios_RutinasApiConsumer.Delete(Detalle_Ejercicios_RutinasItem.Folio, null,null).Resource;

                        if (!resultDetalle_Ejercicios_Rutinas)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IRutinasApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, RutinasModel varRutinas)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IRutinasApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var RutinasInfo = new Rutinas
                    {
                        Folio = varRutinas.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varRutinas.Fecha_de_Registro)) ? DateTime.ParseExact(varRutinas.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varRutinas.Hora_de_Registro
                        ,Usuario_que_Registra = varRutinas.Usuario_que_Registra
                        ,Nombre_de_la_Rutina = varRutinas.Nombre_de_la_Rutina
                        ,Descripcion = varRutinas.Descripcion
                        ,Equipamento = varRutinas.Equipamento
                        ,Equipamento_alterno = varRutinas.Equipamento_alterno
                        ,Nivel_de_dificultad = varRutinas.Nivel_de_dificultad
                        ,Intensidad = varRutinas.Intensidad
                        ,Duracion_aproximada_minutos = varRutinas.Duracion_aproximada_minutos
                        ,Genero = varRutinas.Genero
                        ,Estatus = varRutinas.Estatus

                    };

                    result = !IsNew ?
                        _IRutinasApiConsumer.Update(RutinasInfo, null, null).Resource.ToString() :
                         _IRutinasApiConsumer.Insert(RutinasInfo, null, null).Resource.ToString();
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
        public bool CopyDetalle_Ejercicios_Rutinas(int MasterId, int referenceId, List<Detalle_Ejercicios_RutinasGridModelPost> Detalle_Ejercicios_RutinasItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Ejercicios_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Ejercicios_RutinasData = _IDetalle_Ejercicios_RutinasApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Ejercicios_Rutinas.Folio_Rutinas=" + referenceId,"").Resource;
                if (Detalle_Ejercicios_RutinasData == null || Detalle_Ejercicios_RutinasData.Detalle_Ejercicios_Rutinass.Count == 0)
                    return true;

                var result = true;

                Detalle_Ejercicios_RutinasGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Ejercicios_Rutinas in Detalle_Ejercicios_RutinasData.Detalle_Ejercicios_Rutinass)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Ejercicios_Rutinas Detalle_Ejercicios_Rutinas1 = varDetalle_Ejercicios_Rutinas;

                    if (Detalle_Ejercicios_RutinasItems != null && Detalle_Ejercicios_RutinasItems.Any(m => m.Folio == Detalle_Ejercicios_Rutinas1.Folio))
                    {
                        modelDataToChange = Detalle_Ejercicios_RutinasItems.FirstOrDefault(m => m.Folio == Detalle_Ejercicios_Rutinas1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Ejercicios_Rutinas.Folio_Rutinas = MasterId;
                    var insertId = _IDetalle_Ejercicios_RutinasApiConsumer.Insert(varDetalle_Ejercicios_Rutinas,null,null).Resource;
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
        public ActionResult PostDetalle_Ejercicios_Rutinas(List<Detalle_Ejercicios_RutinasGridModelPost> Detalle_Ejercicios_RutinasItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Ejercicios_Rutinas(MasterId, referenceId, Detalle_Ejercicios_RutinasItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Ejercicios_RutinasItems != null && Detalle_Ejercicios_RutinasItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Ejercicios_RutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Ejercicios_RutinasItem in Detalle_Ejercicios_RutinasItems)
                    {






                        //Removal Request
                        if (Detalle_Ejercicios_RutinasItem.Removed)
                        {
                            result = result && _IDetalle_Ejercicios_RutinasApiConsumer.Delete(Detalle_Ejercicios_RutinasItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Ejercicios_RutinasItem.Folio = 0;

                        var Detalle_Ejercicios_RutinasData = new Detalle_Ejercicios_Rutinas
                        {
                            Folio_Rutinas = MasterId
                            ,Folio = Detalle_Ejercicios_RutinasItem.Folio
                            ,Orden_de_realizacion = Detalle_Ejercicios_RutinasItem.Orden_de_realizacion
                            ,Numero_de_serie = Detalle_Ejercicios_RutinasItem.Numero_de_serie
                            ,Ejercicio = (Convert.ToInt32(Detalle_Ejercicios_RutinasItem.Ejercicio) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Ejercicios_RutinasItem.Ejercicio))
                            ,Cantidad_de_Repeticiones = Detalle_Ejercicios_RutinasItem.Cantidad_de_Repeticiones

                        };

                        var resultId = Detalle_Ejercicios_RutinasItem.Folio > 0
                           ? _IDetalle_Ejercicios_RutinasApiConsumer.Update(Detalle_Ejercicios_RutinasData,null,null).Resource
                           : _IDetalle_Ejercicios_RutinasApiConsumer.Insert(Detalle_Ejercicios_RutinasData,null,null).Resource;

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
        public ActionResult GetDetalle_Ejercicios_Rutinas_EjerciciosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEjerciciosApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Ejercicios", "Nombre_del_Ejercicio");
                  item.Nombre_del_Ejercicio= trans??item.Nombre_del_Ejercicio;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }




        /// <summary>
        /// Write Element Array of Rutinas script
        /// </summary>
        /// <param name="oRutinasElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew RutinasModuleAttributeList)
        {
            for (int i = 0; i < RutinasModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(RutinasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    RutinasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(RutinasModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    RutinasModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (RutinasModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < RutinasModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < RutinasModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(RutinasModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							RutinasModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(RutinasModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							RutinasModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strRutinasScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Rutinas.js")))
            {
                strRutinasScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Rutinas element attributes
            string userChangeJson = jsSerialize.Serialize(RutinasModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strRutinasScript.IndexOf("inpuElementArray");
            string splittedString = strRutinasScript.Substring(indexOfArray, strRutinasScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(RutinasModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (RutinasModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strRutinasScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strRutinasScript.Substring(indexOfArrayHistory, strRutinasScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strRutinasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strRutinasScript.Substring(endIndexOfMainElement + indexOfArray, strRutinasScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (RutinasModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in RutinasModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Rutinas.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Rutinas.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Rutinas.js")))
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
        public ActionResult RutinasPropertyBag()
        {
            return PartialView("RutinasPropertyBag", "Rutinas");
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
        public ActionResult AddDetalle_Ejercicios_Rutinas(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Ejercicios_Rutinas/AddDetalle_Ejercicios_Rutinas");
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
                var whereClauseFormat = "Object = 44572 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IRutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Rutinas.Folio= " + RecordId;
                            var result = _IRutinasApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IRutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new RutinasPropertyMapper());
			
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
                    (RutinasAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            RutinasPropertyMapper oRutinasPropertyMapper = new RutinasPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oRutinasPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IRutinasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Rutinass == null)
                result.Rutinass = new List<Rutinas>();

            var data = result.Rutinass.Select(m => new RutinasGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_la_Rutina = m.Nombre_de_la_Rutina
			,Descripcion = m.Descripcion
			,Equipamento = m.Equipamento
			,Equipamento_alterno = m.Equipamento_alterno
                        ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_dificultad_Nivel_de_dificultad.Folio.ToString(), "Nivel_de_dificultad") ?? (string)m.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                        ,IntensidadIntensidad = CultureHelper.GetTraduction(m.Intensidad_Nivel_de_Intensidad.Folio.ToString(), "Nivel_de_Intensidad") ?? (string)m.Intensidad_Nivel_de_Intensidad.Intensidad
			,Duracion_aproximada_minutos = m.Duracion_aproximada_minutos
                        ,GeneroDescripcion = CultureHelper.GetTraduction(m.Genero_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Genero_Sexo.Descripcion
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44572, arrayColumnsVisible), "RutinasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44572, arrayColumnsVisible), "RutinasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44572, arrayColumnsVisible), "RutinasList_" + DateTime.Now.ToString());
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

            _IRutinasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new RutinasPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (RutinasAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            RutinasPropertyMapper oRutinasPropertyMapper = new RutinasPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oRutinasPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IRutinasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Rutinass == null)
                result.Rutinass = new List<Rutinas>();

            var data = result.Rutinass.Select(m => new RutinasGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_la_Rutina = m.Nombre_de_la_Rutina
			,Descripcion = m.Descripcion
			,Equipamento = m.Equipamento
			,Equipamento_alterno = m.Equipamento_alterno
                        ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_dificultad_Nivel_de_dificultad.Folio.ToString(), "Nivel_de_dificultad") ?? (string)m.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                        ,IntensidadIntensidad = CultureHelper.GetTraduction(m.Intensidad_Nivel_de_Intensidad.Folio.ToString(), "Nivel_de_Intensidad") ?? (string)m.Intensidad_Nivel_de_Intensidad.Intensidad
			,Duracion_aproximada_minutos = m.Duracion_aproximada_minutos
                        ,GeneroDescripcion = CultureHelper.GetTraduction(m.Genero_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Genero_Sexo.Descripcion
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
                _IRutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRutinasApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Rutinas_Datos_GeneralesModel varRutinas)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Rutinas_Datos_GeneralesInfo = new Rutinas_Datos_Generales
                {
                    Folio = varRutinas.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varRutinas.Fecha_de_Registro)) ? DateTime.ParseExact(varRutinas.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varRutinas.Hora_de_Registro
                        ,Usuario_que_Registra = varRutinas.Usuario_que_Registra
                        ,Nombre_de_la_Rutina = varRutinas.Nombre_de_la_Rutina
                        ,Descripcion = varRutinas.Descripcion
                        ,Equipamento = varRutinas.Equipamento
                        ,Equipamento_alterno = varRutinas.Equipamento_alterno
                        ,Nivel_de_dificultad = varRutinas.Nivel_de_dificultad
                        ,Intensidad = varRutinas.Intensidad
                        ,Duracion_aproximada_minutos = varRutinas.Duracion_aproximada_minutos
                        ,Genero = varRutinas.Genero
                        ,Estatus = varRutinas.Estatus
                    
                };

                result = _IRutinasApiConsumer.Update_Datos_Generales(Rutinas_Datos_GeneralesInfo).Resource.ToString();
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
                _IRutinasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IRutinasApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Ejercicios_Rutinas;
                var Detalle_Ejercicios_RutinasData = GetDetalle_Ejercicios_RutinasData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Ejercicios_Rutinas);

                var result = new Rutinas_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_la_Rutina = m.Nombre_de_la_Rutina
			,Descripcion = m.Descripcion
			,Equipamento = m.Equipamento
			,Equipamento_alterno = m.Equipamento_alterno
                        ,Nivel_de_dificultad = m.Nivel_de_dificultad
                        ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_dificultad_Nivel_de_dificultad.Folio.ToString(), "Nivel_de_dificultad") ?? (string)m.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                        ,Intensidad = m.Intensidad
                        ,IntensidadIntensidad = CultureHelper.GetTraduction(m.Intensidad_Nivel_de_Intensidad.Folio.ToString(), "Nivel_de_Intensidad") ?? (string)m.Intensidad_Nivel_de_Intensidad.Intensidad
			,Duracion_aproximada_minutos = m.Duracion_aproximada_minutos
                        ,Genero = m.Genero
                        ,GeneroDescripcion = CultureHelper.GetTraduction(m.Genero_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Genero_Sexo.Descripcion
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                    
                };
				var resultData = new
                {
                    data = result
                    ,Ejercicios = Detalle_Ejercicios_RutinasData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

