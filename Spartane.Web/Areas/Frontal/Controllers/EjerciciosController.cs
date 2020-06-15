using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Ejercicios;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Tipo_Ejercicio;
using Spartane.Core.Domain.Nivel_de_dificultad;
using Spartane.Core.Domain.Sexo;
using Spartane.Core.Domain.MS_Equipamiento_para_Ejercicios;

using Spartane.Core.Domain.Equipamiento_para_Ejercicios;

using Spartane.Core.Domain.Estatus;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Ejercicios;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Ejercicios;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Tipo_Ejercicio;
using Spartane.Web.Areas.WebApiConsumer.Nivel_de_dificultad;
using Spartane.Web.Areas.WebApiConsumer.Sexo;
using Spartane.Web.Areas.WebApiConsumer.MS_Equipamiento_para_Ejercicios;

using Spartane.Web.Areas.WebApiConsumer.Equipamiento_para_Ejercicios;

using Spartane.Web.Areas.WebApiConsumer.Estatus;

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
    public class EjerciciosController : Controller
    {
        #region "variable declaration"

        private IEjerciciosService service = null;
        private IEjerciciosApiConsumer _IEjerciciosApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private ITipo_EjercicioApiConsumer _ITipo_EjercicioApiConsumer;
        private INivel_de_dificultadApiConsumer _INivel_de_dificultadApiConsumer;
        private ISexoApiConsumer _ISexoApiConsumer;
        private IMS_Equipamiento_para_EjerciciosApiConsumer _IMS_Equipamiento_para_EjerciciosApiConsumer;

        private IEquipamiento_para_EjerciciosApiConsumer _IEquipamiento_para_EjerciciosApiConsumer;

        private IEstatusApiConsumer _IEstatusApiConsumer;

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

        
        public EjerciciosController(IEjerciciosService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IEjerciciosApiConsumer EjerciciosApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , ITipo_EjercicioApiConsumer Tipo_EjercicioApiConsumer , INivel_de_dificultadApiConsumer Nivel_de_dificultadApiConsumer , ISexoApiConsumer SexoApiConsumer , IMS_Equipamiento_para_EjerciciosApiConsumer MS_Equipamiento_para_EjerciciosApiConsumer , IEquipamiento_para_EjerciciosApiConsumer Equipamiento_para_EjerciciosApiConsumer  , IEstatusApiConsumer EstatusApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IEjerciciosApiConsumer = EjerciciosApiConsumer;
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
            this._ITipo_EjercicioApiConsumer = Tipo_EjercicioApiConsumer;
            this._INivel_de_dificultadApiConsumer = Nivel_de_dificultadApiConsumer;
            this._ISexoApiConsumer = SexoApiConsumer;
            this._IMS_Equipamiento_para_EjerciciosApiConsumer = MS_Equipamiento_para_EjerciciosApiConsumer;

            this._IEquipamiento_para_EjerciciosApiConsumer = Equipamiento_para_EjerciciosApiConsumer;

            this._IEstatusApiConsumer = EstatusApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Ejercicios
        [ObjectAuth(ObjectId = (ModuleObjectId)44289, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44289, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Ejercicios/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44289, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44289, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varEjercicios = new EjerciciosModel();
			varEjercicios.Clave = Id;
			
            ViewBag.ObjectId = "44289";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionMS_Equipamiento_para_Ejercicios = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44579, ModuleId);
            ViewBag.PermissionMS_Equipamiento_para_Ejercicios = permissionMS_Equipamiento_para_Ejercicios;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IEjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var EjerciciossData = _IEjerciciosApiConsumer.ListaSelAll(0, 1000, "Ejercicios.Clave=" + Id, "").Resource.Ejercicioss;
				
				if (EjerciciossData != null && EjerciciossData.Count > 0)
                {
					var EjerciciosData = EjerciciossData.First();
					varEjercicios= new EjerciciosModel
					{
						Clave  = EjerciciosData.Clave 
	                    ,Fecha_de_Registro = (EjerciciosData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(EjerciciosData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = EjerciciosData.Hora_de_Registro
                    ,Usuario_que_Registra = EjerciciosData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(EjerciciosData.Usuario_que_Registra), "Spartan_User") ??  (string)EjerciciosData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre_del_Ejercicio = EjerciciosData.Nombre_del_Ejercicio
                    ,Descripcion_del_Ejercicio = EjerciciosData.Descripcion_del_Ejercicio
                    ,Tipo_de_Ejercicio = EjerciciosData.Tipo_de_Ejercicio
                    ,Tipo_de_EjercicioDescripcion = CultureHelper.GetTraduction(Convert.ToString(EjerciciosData.Tipo_de_Ejercicio), "Tipo_Ejercicio") ??  (string)EjerciciosData.Tipo_de_Ejercicio_Tipo_Ejercicio.Descripcion
                    ,Nivel_de_dificultad = EjerciciosData.Nivel_de_dificultad
                    ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(Convert.ToString(EjerciciosData.Nivel_de_dificultad), "Nivel_de_dificultad") ??  (string)EjerciciosData.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                    ,Sexo = EjerciciosData.Sexo
                    ,SexoDescripcion = CultureHelper.GetTraduction(Convert.ToString(EjerciciosData.Sexo), "Sexo") ??  (string)EjerciciosData.Sexo_Sexo.Descripcion
                    ,Musculos_trabajados = EjerciciosData.Musculos_trabajados
                    ,Imagen = EjerciciosData.Imagen
                    ,Video = EjerciciosData.Video
                    ,Estatus = EjerciciosData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(EjerciciosData.Estatus), "Estatus") ??  (string)EjerciciosData.Estatus_Estatus.Descripcion

					};
				}
				
				                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.ImagenSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varEjercicios.Imagen).Resource;
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.VideoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varEjercicios.Video).Resource;

				
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
            _ITipo_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Ejercicios_Tipo_de_Ejercicio = _ITipo_EjercicioApiConsumer.SelAll(true);
            if (Tipo_Ejercicios_Tipo_de_Ejercicio != null && Tipo_Ejercicios_Tipo_de_Ejercicio.Resource != null)
                ViewBag.Tipo_Ejercicios_Tipo_de_Ejercicio = Tipo_Ejercicios_Tipo_de_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Ejercicio", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_dificultads_Nivel_de_dificultad = _INivel_de_dificultadApiConsumer.SelAll(true);
            if (Nivel_de_dificultads_Nivel_de_dificultad != null && Nivel_de_dificultads_Nivel_de_dificultad.Resource != null)
                ViewBag.Nivel_de_dificultads_Nivel_de_dificultad = Nivel_de_dificultads_Nivel_de_dificultad.Resource.Where(m => m.Dificultad != null).OrderBy(m => m.Dificultad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_dificultad", "Dificultad") ?? m.Dificultad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Sexo = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Sexo != null && Sexos_Sexo.Resource != null)
                ViewBag.Sexos_Sexo = Sexos_Sexo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
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

				
            return View(varEjercicios);
        }
		
	[HttpGet]
        public ActionResult AddEjercicios(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44289);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IEjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
			EjerciciosModel varEjercicios= new EjerciciosModel();
            var permissionMS_Equipamiento_para_Ejercicios = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44579, ModuleId);
            ViewBag.PermissionMS_Equipamiento_para_Ejercicios = permissionMS_Equipamiento_para_Ejercicios;


            if (id.ToString() != "0")
            {
                var EjerciciossData = _IEjerciciosApiConsumer.ListaSelAll(0, 1000, "Ejercicios.Clave=" + id, "").Resource.Ejercicioss;
				
				if (EjerciciossData != null && EjerciciossData.Count > 0)
                {
					var EjerciciosData = EjerciciossData.First();
					varEjercicios= new EjerciciosModel
					{
						Clave  = EjerciciosData.Clave 
	                    ,Fecha_de_Registro = (EjerciciosData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(EjerciciosData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = EjerciciosData.Hora_de_Registro
                    ,Usuario_que_Registra = EjerciciosData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(EjerciciosData.Usuario_que_Registra), "Spartan_User") ??  (string)EjerciciosData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre_del_Ejercicio = EjerciciosData.Nombre_del_Ejercicio
                    ,Descripcion_del_Ejercicio = EjerciciosData.Descripcion_del_Ejercicio
                    ,Tipo_de_Ejercicio = EjerciciosData.Tipo_de_Ejercicio
                    ,Tipo_de_EjercicioDescripcion = CultureHelper.GetTraduction(Convert.ToString(EjerciciosData.Tipo_de_Ejercicio), "Tipo_Ejercicio") ??  (string)EjerciciosData.Tipo_de_Ejercicio_Tipo_Ejercicio.Descripcion
                    ,Nivel_de_dificultad = EjerciciosData.Nivel_de_dificultad
                    ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(Convert.ToString(EjerciciosData.Nivel_de_dificultad), "Nivel_de_dificultad") ??  (string)EjerciciosData.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                    ,Sexo = EjerciciosData.Sexo
                    ,SexoDescripcion = CultureHelper.GetTraduction(Convert.ToString(EjerciciosData.Sexo), "Sexo") ??  (string)EjerciciosData.Sexo_Sexo.Descripcion
                    ,Musculos_trabajados = EjerciciosData.Musculos_trabajados
                    ,Imagen = EjerciciosData.Imagen
                    ,Video = EjerciciosData.Video
                    ,Estatus = EjerciciosData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(EjerciciosData.Estatus), "Estatus") ??  (string)EjerciciosData.Estatus_Estatus.Descripcion

					};
				}
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.ImagenSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varEjercicios.Imagen).Resource;
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.VideoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varEjercicios.Video).Resource;

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
            _ITipo_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Ejercicios_Tipo_de_Ejercicio = _ITipo_EjercicioApiConsumer.SelAll(true);
            if (Tipo_Ejercicios_Tipo_de_Ejercicio != null && Tipo_Ejercicios_Tipo_de_Ejercicio.Resource != null)
                ViewBag.Tipo_Ejercicios_Tipo_de_Ejercicio = Tipo_Ejercicios_Tipo_de_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Ejercicio", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_dificultads_Nivel_de_dificultad = _INivel_de_dificultadApiConsumer.SelAll(true);
            if (Nivel_de_dificultads_Nivel_de_dificultad != null && Nivel_de_dificultads_Nivel_de_dificultad.Resource != null)
                ViewBag.Nivel_de_dificultads_Nivel_de_dificultad = Nivel_de_dificultads_Nivel_de_dificultad.Resource.Where(m => m.Dificultad != null).OrderBy(m => m.Dificultad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_dificultad", "Dificultad") ?? m.Dificultad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Sexo = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Sexo != null && Sexos_Sexo.Resource != null)
                ViewBag.Sexos_Sexo = Sexos_Sexo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
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


            return PartialView("AddEjercicios", varEjercicios);
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
        public ActionResult GetTipo_EjercicioAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_EjercicioApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Ejercicio", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
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
        public ActionResult ShowAdvanceFilter(EjerciciosAdvanceSearchModel model, int idFilter = -1)
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
            _ITipo_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Ejercicios_Tipo_de_Ejercicio = _ITipo_EjercicioApiConsumer.SelAll(true);
            if (Tipo_Ejercicios_Tipo_de_Ejercicio != null && Tipo_Ejercicios_Tipo_de_Ejercicio.Resource != null)
                ViewBag.Tipo_Ejercicios_Tipo_de_Ejercicio = Tipo_Ejercicios_Tipo_de_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Ejercicio", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_dificultads_Nivel_de_dificultad = _INivel_de_dificultadApiConsumer.SelAll(true);
            if (Nivel_de_dificultads_Nivel_de_dificultad != null && Nivel_de_dificultads_Nivel_de_dificultad.Resource != null)
                ViewBag.Nivel_de_dificultads_Nivel_de_dificultad = Nivel_de_dificultads_Nivel_de_dificultad.Resource.Where(m => m.Dificultad != null).OrderBy(m => m.Dificultad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_dificultad", "Dificultad") ?? m.Dificultad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Sexo = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Sexo != null && Sexos_Sexo.Resource != null)
                ViewBag.Sexos_Sexo = Sexos_Sexo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
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
            _ITipo_EjercicioApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_Ejercicios_Tipo_de_Ejercicio = _ITipo_EjercicioApiConsumer.SelAll(true);
            if (Tipo_Ejercicios_Tipo_de_Ejercicio != null && Tipo_Ejercicios_Tipo_de_Ejercicio.Resource != null)
                ViewBag.Tipo_Ejercicios_Tipo_de_Ejercicio = Tipo_Ejercicios_Tipo_de_Ejercicio.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_Ejercicio", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _INivel_de_dificultadApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Nivel_de_dificultads_Nivel_de_dificultad = _INivel_de_dificultadApiConsumer.SelAll(true);
            if (Nivel_de_dificultads_Nivel_de_dificultad != null && Nivel_de_dificultads_Nivel_de_dificultad.Resource != null)
                ViewBag.Nivel_de_dificultads_Nivel_de_dificultad = Nivel_de_dificultads_Nivel_de_dificultad.Resource.Where(m => m.Dificultad != null).OrderBy(m => m.Dificultad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Nivel_de_dificultad", "Dificultad") ?? m.Dificultad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISexoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sexos_Sexo = _ISexoApiConsumer.SelAll(true);
            if (Sexos_Sexo != null && Sexos_Sexo.Resource != null)
                ViewBag.Sexos_Sexo = Sexos_Sexo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
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


            var previousFiltersObj = new EjerciciosAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (EjerciciosAdvanceSearchModel)(Session["AdvanceSearch"] ?? new EjerciciosAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new EjerciciosPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IEjerciciosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Ejercicioss == null)
                result.Ejercicioss = new List<Ejercicios>();

            return Json(new
            {
                data = result.Ejercicioss.Select(m => new EjerciciosGridModel
                    {
                    Clave = m.Clave
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_del_Ejercicio = m.Nombre_del_Ejercicio
			,Descripcion_del_Ejercicio = m.Descripcion_del_Ejercicio
                        ,Tipo_de_EjercicioDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Ejercicio_Tipo_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Ejercicio_Tipo_Ejercicio.Descripcion
                        ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_dificultad_Nivel_de_dificultad.Folio.ToString(), "Dificultad") ?? (string)m.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Musculos_trabajados = m.Musculos_trabajados
			,Imagen = m.Imagen
			,Video = m.Video
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetEjerciciosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEjerciciosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Clave), "Ejercicios", m.),
                     Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
*/
        /// <summary>
        /// Get List of Ejercicios from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Ejercicios Entity</returns>
        public ActionResult GetEjerciciosList(UrlParametersModel param)
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
            _IEjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new EjerciciosPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(EjerciciosAdvanceSearchModel))
                {
					var advanceFilter =
                    (EjerciciosAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            EjerciciosPropertyMapper oEjerciciosPropertyMapper = new EjerciciosPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oEjerciciosPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IEjerciciosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Ejercicioss == null)
                result.Ejercicioss = new List<Ejercicios>();

            return Json(new
            {
                aaData = result.Ejercicioss.Select(m => new EjerciciosGridModel
            {
                    Clave = m.Clave
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_del_Ejercicio = m.Nombre_del_Ejercicio
			,Descripcion_del_Ejercicio = m.Descripcion_del_Ejercicio
                        ,Tipo_de_EjercicioDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Ejercicio_Tipo_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Ejercicio_Tipo_Ejercicio.Descripcion
                        ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_dificultad_Nivel_de_dificultad.Folio.ToString(), "Dificultad") ?? (string)m.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Musculos_trabajados = m.Musculos_trabajados
			,Imagen = m.Imagen
			,Video = m.Video
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(EjerciciosAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromClave) || !string.IsNullOrEmpty(filter.ToClave))
            {
                if (!string.IsNullOrEmpty(filter.FromClave))
                    where += " AND Ejercicios.Clave >= " + filter.FromClave;
                if (!string.IsNullOrEmpty(filter.ToClave))
                    where += " AND Ejercicios.Clave <= " + filter.ToClave;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Ejercicios.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Ejercicios.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Ejercicios.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Ejercicios.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
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

                where += " AND Ejercicios.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombre_del_Ejercicio))
            {
                switch (filter.Nombre_del_EjercicioFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Ejercicios.Nombre_del_Ejercicio LIKE '" + filter.Nombre_del_Ejercicio + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Ejercicios.Nombre_del_Ejercicio LIKE '%" + filter.Nombre_del_Ejercicio + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Ejercicios.Nombre_del_Ejercicio = '" + filter.Nombre_del_Ejercicio + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Ejercicios.Nombre_del_Ejercicio LIKE '%" + filter.Nombre_del_Ejercicio + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Descripcion_del_Ejercicio))
            {
                switch (filter.Descripcion_del_EjercicioFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Ejercicios.Descripcion_del_Ejercicio LIKE '" + filter.Descripcion_del_Ejercicio + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Ejercicios.Descripcion_del_Ejercicio LIKE '%" + filter.Descripcion_del_Ejercicio + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Ejercicios.Descripcion_del_Ejercicio = '" + filter.Descripcion_del_Ejercicio + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Ejercicios.Descripcion_del_Ejercicio LIKE '%" + filter.Descripcion_del_Ejercicio + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTipo_de_Ejercicio))
            {
                switch (filter.Tipo_de_EjercicioFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tipo_Ejercicio.Descripcion LIKE '" + filter.AdvanceTipo_de_Ejercicio + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tipo_Ejercicio.Descripcion LIKE '%" + filter.AdvanceTipo_de_Ejercicio + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tipo_Ejercicio.Descripcion = '" + filter.AdvanceTipo_de_Ejercicio + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tipo_Ejercicio.Descripcion LIKE '%" + filter.AdvanceTipo_de_Ejercicio + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTipo_de_EjercicioMultiple != null && filter.AdvanceTipo_de_EjercicioMultiple.Count() > 0)
            {
                var Tipo_de_EjercicioIds = string.Join(",", filter.AdvanceTipo_de_EjercicioMultiple);

                where += " AND Ejercicios.Tipo_de_Ejercicio In (" + Tipo_de_EjercicioIds + ")";
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

                where += " AND Ejercicios.Nivel_de_dificultad In (" + Nivel_de_dificultadIds + ")";
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

                where += " AND Ejercicios.Sexo In (" + SexoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromMusculos_trabajados) || !string.IsNullOrEmpty(filter.ToMusculos_trabajados))
            {
                if (!string.IsNullOrEmpty(filter.FromMusculos_trabajados))
                    where += " AND Ejercicios.Musculos_trabajados >= " + filter.FromMusculos_trabajados;
                if (!string.IsNullOrEmpty(filter.ToMusculos_trabajados))
                    where += " AND Ejercicios.Musculos_trabajados <= " + filter.ToMusculos_trabajados;
            }

            if (filter.Imagen != RadioOptions.NoApply)
                where += " AND Ejercicios.Imagen " + (filter.Imagen == RadioOptions.Yes ? ">" : "==") + " 0";

            if (filter.Video != RadioOptions.NoApply)
                where += " AND Ejercicios.Video " + (filter.Video == RadioOptions.Yes ? ">" : "==") + " 0";

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

                where += " AND Ejercicios.Estatus In (" + EstatusIds + ")";
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

[HttpGet]
        public ActionResult GetEquipamento_MS_Equipamiento_para_EjerciciosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                
                _IEquipamiento_para_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEquipamiento_para_EjerciciosApiConsumer.SelAll(false).Resource;

                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetMS_Equipamiento_para_Ejercicios(int draw, int start, int length, int RelationId = 0)
        {
            if (RelationId == 0)
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<MS_Equipamiento_para_EjerciciosGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IMS_Equipamiento_para_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
			
var result = _IMS_Equipamiento_para_EjerciciosApiConsumer.ListaSelAll(start, pageSize, "MS_Equipamiento_para_Ejercicios.Folio_Ejercicios=" + RelationId,"").Resource;

            if (result.MS_Equipamiento_para_Ejercicioss == null)
                result.MS_Equipamiento_para_Ejercicioss = new List<MS_Equipamiento_para_Ejercicios>();

            var jsonResult = Json(new
            {
                data = result.MS_Equipamiento_para_Ejercicioss.Select(m => new MS_Equipamiento_para_EjerciciosGridModel
                {
                    Folio = m.Folio
					
                ,Equipamento = m.Equipamento
		,EquipamentoDescripcion = m.Equipamento_Equipamiento_para_Ejercicios.Descripcion


                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);

                Ejercicios varEjercicios = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IMS_Equipamiento_para_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "MS_Equipamiento_para_Ejercicios.Folio_Ejercicios=" + id;
                    if("int" == "string")
                    {
	                where = "MS_Equipamiento_para_Ejercicios.Folio_Ejercicios='" + id + "'";
                    }
                    var MS_Equipamiento_para_EjerciciosInfo =
                        _IMS_Equipamiento_para_EjerciciosApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (MS_Equipamiento_para_EjerciciosInfo.MS_Equipamiento_para_Ejercicioss.Count > 0)
                    {
                        var resultMS_Equipamiento_para_Ejercicios = true;
                        //Removing associated job history with attachment
                        foreach (var MS_Equipamiento_para_EjerciciosItem in MS_Equipamiento_para_EjerciciosInfo.MS_Equipamiento_para_Ejercicioss)
                            resultMS_Equipamiento_para_Ejercicios = resultMS_Equipamiento_para_Ejercicios
                                              && _IMS_Equipamiento_para_EjerciciosApiConsumer.Delete(MS_Equipamiento_para_EjerciciosItem.Folio, null,null).Resource;

                        if (!resultMS_Equipamiento_para_Ejercicios)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IEjerciciosApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, EjerciciosModel varEjercicios)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IEjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);


                    if (varEjercicios.ImagenRemoveAttachment != 0 && varEjercicios.ImagenFile == null)
                    {
                        varEjercicios.Imagen = 0;
                    }

                    if (varEjercicios.ImagenFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varEjercicios.ImagenFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varEjercicios.Imagen = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varEjercicios.ImagenFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }
                    if (varEjercicios.VideoRemoveAttachment != 0 && varEjercicios.VideoFile == null)
                    {
                        varEjercicios.Video = 0;
                    }

                    if (varEjercicios.VideoFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varEjercicios.VideoFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varEjercicios.Video = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varEjercicios.VideoFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                    
                    var result = "";
                    var EjerciciosInfo = new Ejercicios
                    {
                        Clave = varEjercicios.Clave
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varEjercicios.Fecha_de_Registro)) ? DateTime.ParseExact(varEjercicios.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varEjercicios.Hora_de_Registro
                        ,Usuario_que_Registra = varEjercicios.Usuario_que_Registra
                        ,Nombre_del_Ejercicio = varEjercicios.Nombre_del_Ejercicio
                        ,Descripcion_del_Ejercicio = varEjercicios.Descripcion_del_Ejercicio
                        ,Tipo_de_Ejercicio = varEjercicios.Tipo_de_Ejercicio
                        ,Nivel_de_dificultad = varEjercicios.Nivel_de_dificultad
                        ,Sexo = varEjercicios.Sexo
                        ,Musculos_trabajados = varEjercicios.Musculos_trabajados
                        ,Imagen = (varEjercicios.Imagen.HasValue && varEjercicios.Imagen != 0) ? ((int?)Convert.ToInt32(varEjercicios.Imagen.Value)) : null

                        ,Video = (varEjercicios.Video.HasValue && varEjercicios.Video != 0) ? ((int?)Convert.ToInt32(varEjercicios.Video.Value)) : null

                        ,Estatus = varEjercicios.Estatus

                    };

                    result = !IsNew ?
                        _IEjerciciosApiConsumer.Update(EjerciciosInfo, null, null).Resource.ToString() :
                         _IEjerciciosApiConsumer.Insert(EjerciciosInfo, null, null).Resource.ToString();
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
        public bool CopyMS_Equipamiento_para_Ejercicios(int MasterId, int referenceId, List<MS_Equipamiento_para_EjerciciosGridModelPost> MS_Equipamiento_para_EjerciciosItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IMS_Equipamiento_para_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);

                var MS_Equipamiento_para_EjerciciosData = _IMS_Equipamiento_para_EjerciciosApiConsumer.ListaSelAll(1, int.MaxValue, "MS_Equipamiento_para_Ejercicios.Folio_Ejercicios=" + referenceId,"").Resource;
                if (MS_Equipamiento_para_EjerciciosData == null || MS_Equipamiento_para_EjerciciosData.MS_Equipamiento_para_Ejercicioss.Count == 0)
                    return true;

                var result = true;

                MS_Equipamiento_para_EjerciciosGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varMS_Equipamiento_para_Ejercicios in MS_Equipamiento_para_EjerciciosData.MS_Equipamiento_para_Ejercicioss)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    MS_Equipamiento_para_Ejercicios MS_Equipamiento_para_Ejercicios1 = varMS_Equipamiento_para_Ejercicios;

                    if (MS_Equipamiento_para_EjerciciosItems != null && MS_Equipamiento_para_EjerciciosItems.Any(m => m.Folio == MS_Equipamiento_para_Ejercicios1.Folio))
                    {
                        modelDataToChange = MS_Equipamiento_para_EjerciciosItems.FirstOrDefault(m => m.Folio == MS_Equipamiento_para_Ejercicios1.Folio);
                    }
                    //Chaning Id Value
                    varMS_Equipamiento_para_Ejercicios.Folio_Ejercicios = MasterId;
                    var insertId = _IMS_Equipamiento_para_EjerciciosApiConsumer.Insert(varMS_Equipamiento_para_Ejercicios,null,null).Resource;
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
        public ActionResult PostMS_Equipamiento_para_Ejercicios(List<MS_Equipamiento_para_EjerciciosGridModelPost> MS_Equipamiento_para_EjerciciosItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyMS_Equipamiento_para_Ejercicios(MasterId, referenceId, MS_Equipamiento_para_EjerciciosItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (MS_Equipamiento_para_EjerciciosItems != null && MS_Equipamiento_para_EjerciciosItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IMS_Equipamiento_para_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var MS_Equipamiento_para_EjerciciosItem in MS_Equipamiento_para_EjerciciosItems)
                    {



                        //Removal Request
                        if (MS_Equipamiento_para_EjerciciosItem.Removed)
                        {
                            result = result && _IMS_Equipamiento_para_EjerciciosApiConsumer.Delete(MS_Equipamiento_para_EjerciciosItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							MS_Equipamiento_para_EjerciciosItem.Folio = 0;

                        var MS_Equipamiento_para_EjerciciosData = new MS_Equipamiento_para_Ejercicios
                        {
                            Folio_Ejercicios = MasterId
                            ,Folio = MS_Equipamiento_para_EjerciciosItem.Folio
                            ,Equipamento = (Convert.ToInt32(MS_Equipamiento_para_EjerciciosItem.Equipamento) == 0 ? (Int32?)null : Convert.ToInt32(MS_Equipamiento_para_EjerciciosItem.Equipamento))

                        };

                        var resultId = MS_Equipamiento_para_EjerciciosItem.Folio > 0
                           ? _IMS_Equipamiento_para_EjerciciosApiConsumer.Update(MS_Equipamiento_para_EjerciciosData,null,null).Resource
                           : _IMS_Equipamiento_para_EjerciciosApiConsumer.Insert(MS_Equipamiento_para_EjerciciosData,null,null).Resource;

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
        public ActionResult GetMS_Equipamiento_para_Ejercicios_Equipamiento_para_EjerciciosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEquipamiento_para_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEquipamiento_para_EjerciciosApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Equipamiento_para_Ejercicios", "Descripcion");
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
        /// Write Element Array of Ejercicios script
        /// </summary>
        /// <param name="oEjerciciosElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew EjerciciosModuleAttributeList)
        {
            for (int i = 0; i < EjerciciosModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(EjerciciosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    EjerciciosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(EjerciciosModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    EjerciciosModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (EjerciciosModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < EjerciciosModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < EjerciciosModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(EjerciciosModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							EjerciciosModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(EjerciciosModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							EjerciciosModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strEjerciciosScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Ejercicios.js")))
            {
                strEjerciciosScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Ejercicios element attributes
            string userChangeJson = jsSerialize.Serialize(EjerciciosModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strEjerciciosScript.IndexOf("inpuElementArray");
            string splittedString = strEjerciciosScript.Substring(indexOfArray, strEjerciciosScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(EjerciciosModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (EjerciciosModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strEjerciciosScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strEjerciciosScript.Substring(indexOfArrayHistory, strEjerciciosScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strEjerciciosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strEjerciciosScript.Substring(endIndexOfMainElement + indexOfArray, strEjerciciosScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (EjerciciosModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in EjerciciosModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Ejercicios.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Ejercicios.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Ejercicios.js")))
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
        public ActionResult EjerciciosPropertyBag()
        {
            return PartialView("EjerciciosPropertyBag", "Ejercicios");
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
        public ActionResult AddMS_Equipamiento_para_Ejercicios(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../MS_Equipamiento_para_Ejercicios/AddMS_Equipamiento_para_Ejercicios");
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
                var whereClauseFormat = "Object = 44289 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IEjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Ejercicios.Clave= " + RecordId;
                            var result = _IEjerciciosApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IEjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new EjerciciosPropertyMapper());
			
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
                    (EjerciciosAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            EjerciciosPropertyMapper oEjerciciosPropertyMapper = new EjerciciosPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oEjerciciosPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IEjerciciosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Ejercicioss == null)
                result.Ejercicioss = new List<Ejercicios>();

            var data = result.Ejercicioss.Select(m => new EjerciciosGridModel
            {
                Clave = m.Clave
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_del_Ejercicio = m.Nombre_del_Ejercicio
			,Descripcion_del_Ejercicio = m.Descripcion_del_Ejercicio
                        ,Tipo_de_EjercicioDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Ejercicio_Tipo_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Ejercicio_Tipo_Ejercicio.Descripcion
                        ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_dificultad_Nivel_de_dificultad.Folio.ToString(), "Dificultad") ?? (string)m.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Musculos_trabajados = m.Musculos_trabajados
			,Imagen = m.Imagen
			,Video = m.Video
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44289, arrayColumnsVisible), "EjerciciosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44289, arrayColumnsVisible), "EjerciciosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44289, arrayColumnsVisible), "EjerciciosList_" + DateTime.Now.ToString());
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

            _IEjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new EjerciciosPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (EjerciciosAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            EjerciciosPropertyMapper oEjerciciosPropertyMapper = new EjerciciosPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oEjerciciosPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IEjerciciosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Ejercicioss == null)
                result.Ejercicioss = new List<Ejercicios>();

            var data = result.Ejercicioss.Select(m => new EjerciciosGridModel
            {
                Clave = m.Clave
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_del_Ejercicio = m.Nombre_del_Ejercicio
			,Descripcion_del_Ejercicio = m.Descripcion_del_Ejercicio
                        ,Tipo_de_EjercicioDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Ejercicio_Tipo_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Ejercicio_Tipo_Ejercicio.Descripcion
                        ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_dificultad_Nivel_de_dificultad.Folio.ToString(), "Dificultad") ?? (string)m.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Musculos_trabajados = m.Musculos_trabajados
			,Imagen = m.Imagen
			,Video = m.Video
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
                _IEjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEjerciciosApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Ejercicios_Datos_GeneralesModel varEjercicios)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
				                    if (varEjercicios.ImagenRemoveAttachment != 0 && varEjercicios.ImagenFile == null)
                    {
                        varEjercicios.Imagen = 0;
                    }

                    if (varEjercicios.ImagenFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varEjercicios.ImagenFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varEjercicios.Imagen = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varEjercicios.ImagenFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }
                    if (varEjercicios.VideoRemoveAttachment != 0 && varEjercicios.VideoFile == null)
                    {
                        varEjercicios.Video = 0;
                    }

                    if (varEjercicios.VideoFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varEjercicios.VideoFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varEjercicios.Video = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varEjercicios.VideoFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                var result = "";
                var Ejercicios_Datos_GeneralesInfo = new Ejercicios_Datos_Generales
                {
                    Clave = varEjercicios.Clave
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varEjercicios.Fecha_de_Registro)) ? DateTime.ParseExact(varEjercicios.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varEjercicios.Hora_de_Registro
                        ,Usuario_que_Registra = varEjercicios.Usuario_que_Registra
                        ,Nombre_del_Ejercicio = varEjercicios.Nombre_del_Ejercicio
                        ,Descripcion_del_Ejercicio = varEjercicios.Descripcion_del_Ejercicio
                        ,Tipo_de_Ejercicio = varEjercicios.Tipo_de_Ejercicio
                        ,Nivel_de_dificultad = varEjercicios.Nivel_de_dificultad
                        ,Sexo = varEjercicios.Sexo
                        ,Musculos_trabajados = varEjercicios.Musculos_trabajados
                        ,Imagen = (varEjercicios.Imagen.HasValue && varEjercicios.Imagen != 0) ? ((int?)Convert.ToInt32(varEjercicios.Imagen.Value)) : null

                        ,Video = (varEjercicios.Video.HasValue && varEjercicios.Video != 0) ? ((int?)Convert.ToInt32(varEjercicios.Video.Value)) : null

                        ,Estatus = varEjercicios.Estatus
                    
                };

                result = _IEjerciciosApiConsumer.Update_Datos_Generales(Ejercicios_Datos_GeneralesInfo).Resource.ToString();
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
                _IEjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IEjerciciosApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				
                var result = new Ejercicios_Datos_GeneralesModel
                {
                    Clave = m.Clave
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_del_Ejercicio = m.Nombre_del_Ejercicio
			,Descripcion_del_Ejercicio = m.Descripcion_del_Ejercicio
                        ,Tipo_de_Ejercicio = m.Tipo_de_Ejercicio
                        ,Tipo_de_EjercicioDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Ejercicio_Tipo_Ejercicio.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Ejercicio_Tipo_Ejercicio.Descripcion
                        ,Nivel_de_dificultad = m.Nivel_de_dificultad
                        ,Nivel_de_dificultadDificultad = CultureHelper.GetTraduction(m.Nivel_de_dificultad_Nivel_de_dificultad.Folio.ToString(), "Dificultad") ?? (string)m.Nivel_de_dificultad_Nivel_de_dificultad.Dificultad
                        ,Sexo = m.Sexo
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
			,Musculos_trabajados = m.Musculos_trabajados
			,Imagen = m.Imagen
			,Video = m.Video
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                    
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

