using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Tips_y_Promociones;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Especialidades;
using Spartane.Core.Domain.Medicos;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Estatus;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Tips_y_Promociones;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Tips_y_Promociones;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Especialidades;
using Spartane.Web.Areas.WebApiConsumer.Medicos;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
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
    public class Tips_y_PromocionesController : Controller
    {
        #region "variable declaration"

        private ITips_y_PromocionesService service = null;
        private ITips_y_PromocionesApiConsumer _ITips_y_PromocionesApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IEspecialidadesApiConsumer _IEspecialidadesApiConsumer;
        private IMedicosApiConsumer _IMedicosApiConsumer;
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

        
        public Tips_y_PromocionesController(ITips_y_PromocionesService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ITips_y_PromocionesApiConsumer Tips_y_PromocionesApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IEspecialidadesApiConsumer EspecialidadesApiConsumer , IMedicosApiConsumer MedicosApiConsumer , IEstatusApiConsumer EstatusApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ITips_y_PromocionesApiConsumer = Tips_y_PromocionesApiConsumer;
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
            this._IEspecialidadesApiConsumer = EspecialidadesApiConsumer;
            this._IMedicosApiConsumer = MedicosApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._IEstatusApiConsumer = EstatusApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Tips_y_Promociones
        [ObjectAuth(ObjectId = (ModuleObjectId)44564, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44564, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Tips_y_Promociones/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44564, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44564, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varTips_y_Promociones = new Tips_y_PromocionesModel();
			varTips_y_Promociones.Folio = Id;
			
            ViewBag.ObjectId = "44564";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _ITips_y_PromocionesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Tips_y_PromocionessData = _ITips_y_PromocionesApiConsumer.ListaSelAll(0, 1000, "Tips_y_Promociones.Folio=" + Id, "").Resource.Tips_y_Promocioness;
				
				if (Tips_y_PromocionessData != null && Tips_y_PromocionessData.Count > 0)
                {
					var Tips_y_PromocionesData = Tips_y_PromocionessData.First();
					varTips_y_Promociones= new Tips_y_PromocionesModel
					{
						Folio  = Tips_y_PromocionesData.Folio 
	                    ,Fecha_de_registro = (Tips_y_PromocionesData.Fecha_de_registro == null ? string.Empty : Convert.ToDateTime(Tips_y_PromocionesData.Fecha_de_registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Tips_y_PromocionesData.Hora_de_Registro
                    ,Usuario_que_Registra = Tips_y_PromocionesData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Tips_y_PromocionesData.Usuario_que_Registra), "Spartan_User") ??  (string)Tips_y_PromocionesData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre = Tips_y_PromocionesData.Nombre
                    ,Descripcion_Corta = Tips_y_PromocionesData.Descripcion_Corta
                    ,Descripcion_Larga = Tips_y_PromocionesData.Descripcion_Larga
                    ,Imagen = Tips_y_PromocionesData.Imagen
                    ,Fecha_inicio_de_Vigencia = (Tips_y_PromocionesData.Fecha_inicio_de_Vigencia == null ? string.Empty : Convert.ToDateTime(Tips_y_PromocionesData.Fecha_inicio_de_Vigencia).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin_de_Vigencia = (Tips_y_PromocionesData.Fecha_fin_de_Vigencia == null ? string.Empty : Convert.ToDateTime(Tips_y_PromocionesData.Fecha_fin_de_Vigencia).ToString(ConfigurationProperty.DateFormat))
                    ,Especialidad = Tips_y_PromocionesData.Especialidad
                    ,EspecialidadEspecialidad = CultureHelper.GetTraduction(Convert.ToString(Tips_y_PromocionesData.Especialidad), "Especialidades") ??  (string)Tips_y_PromocionesData.Especialidad_Especialidades.Especialidad
                    ,Especialista = Tips_y_PromocionesData.Especialista
                    ,EspecialistaNombre_Completo = CultureHelper.GetTraduction(Convert.ToString(Tips_y_PromocionesData.Especialista), "Medicos") ??  (string)Tips_y_PromocionesData.Especialista_Medicos.Nombre_Completo
                    ,Vendedor = Tips_y_PromocionesData.Vendedor
                    ,VendedorName = CultureHelper.GetTraduction(Convert.ToString(Tips_y_PromocionesData.Vendedor), "Spartan_User") ??  (string)Tips_y_PromocionesData.Vendedor_Spartan_User.Name
                    ,Estatus = Tips_y_PromocionesData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Tips_y_PromocionesData.Estatus), "Estatus") ??  (string)Tips_y_PromocionesData.Estatus_Estatus.Descripcion

					};
				}
				
				                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.ImagenSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varTips_y_Promociones.Imagen).Resource;

				
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
            _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Especialidadess_Especialidad = _IEspecialidadesApiConsumer.SelAll(true);
            if (Especialidadess_Especialidad != null && Especialidadess_Especialidad.Resource != null)
                ViewBag.Especialidadess_Especialidad = Especialidadess_Especialidad.Resource.Where(m => m.Especialidad != null).OrderBy(m => m.Especialidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Especialidades", "Especialidad") ?? m.Especialidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Medicoss_Especialista = _IMedicosApiConsumer.SelAll(true);
            if (Medicoss_Especialista != null && Medicoss_Especialista.Resource != null)
                ViewBag.Medicoss_Especialista = Medicoss_Especialista.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Medicos", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Vendedor = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Vendedor != null && Spartan_Users_Vendedor.Resource != null)
                ViewBag.Spartan_Users_Vendedor = Spartan_Users_Vendedor.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
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

				
            return View(varTips_y_Promociones);
        }
		
	[HttpGet]
        public ActionResult AddTips_y_Promociones(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44564);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ITips_y_PromocionesApiConsumer.SetAuthHeader(_tokenManager.Token);
			Tips_y_PromocionesModel varTips_y_Promociones= new Tips_y_PromocionesModel();


            if (id.ToString() != "0")
            {
                var Tips_y_PromocionessData = _ITips_y_PromocionesApiConsumer.ListaSelAll(0, 1000, "Tips_y_Promociones.Folio=" + id, "").Resource.Tips_y_Promocioness;
				
				if (Tips_y_PromocionessData != null && Tips_y_PromocionessData.Count > 0)
                {
					var Tips_y_PromocionesData = Tips_y_PromocionessData.First();
					varTips_y_Promociones= new Tips_y_PromocionesModel
					{
						Folio  = Tips_y_PromocionesData.Folio 
	                    ,Fecha_de_registro = (Tips_y_PromocionesData.Fecha_de_registro == null ? string.Empty : Convert.ToDateTime(Tips_y_PromocionesData.Fecha_de_registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Tips_y_PromocionesData.Hora_de_Registro
                    ,Usuario_que_Registra = Tips_y_PromocionesData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(Tips_y_PromocionesData.Usuario_que_Registra), "Spartan_User") ??  (string)Tips_y_PromocionesData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre = Tips_y_PromocionesData.Nombre
                    ,Descripcion_Corta = Tips_y_PromocionesData.Descripcion_Corta
                    ,Descripcion_Larga = Tips_y_PromocionesData.Descripcion_Larga
                    ,Imagen = Tips_y_PromocionesData.Imagen
                    ,Fecha_inicio_de_Vigencia = (Tips_y_PromocionesData.Fecha_inicio_de_Vigencia == null ? string.Empty : Convert.ToDateTime(Tips_y_PromocionesData.Fecha_inicio_de_Vigencia).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin_de_Vigencia = (Tips_y_PromocionesData.Fecha_fin_de_Vigencia == null ? string.Empty : Convert.ToDateTime(Tips_y_PromocionesData.Fecha_fin_de_Vigencia).ToString(ConfigurationProperty.DateFormat))
                    ,Especialidad = Tips_y_PromocionesData.Especialidad
                    ,EspecialidadEspecialidad = CultureHelper.GetTraduction(Convert.ToString(Tips_y_PromocionesData.Especialidad), "Especialidades") ??  (string)Tips_y_PromocionesData.Especialidad_Especialidades.Especialidad
                    ,Especialista = Tips_y_PromocionesData.Especialista
                    ,EspecialistaNombre_Completo = CultureHelper.GetTraduction(Convert.ToString(Tips_y_PromocionesData.Especialista), "Medicos") ??  (string)Tips_y_PromocionesData.Especialista_Medicos.Nombre_Completo
                    ,Vendedor = Tips_y_PromocionesData.Vendedor
                    ,VendedorName = CultureHelper.GetTraduction(Convert.ToString(Tips_y_PromocionesData.Vendedor), "Spartan_User") ??  (string)Tips_y_PromocionesData.Vendedor_Spartan_User.Name
                    ,Estatus = Tips_y_PromocionesData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Tips_y_PromocionesData.Estatus), "Estatus") ??  (string)Tips_y_PromocionesData.Estatus_Estatus.Descripcion

					};
				}
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.ImagenSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varTips_y_Promociones.Imagen).Resource;

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
            _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Especialidadess_Especialidad = _IEspecialidadesApiConsumer.SelAll(true);
            if (Especialidadess_Especialidad != null && Especialidadess_Especialidad.Resource != null)
                ViewBag.Especialidadess_Especialidad = Especialidadess_Especialidad.Resource.Where(m => m.Especialidad != null).OrderBy(m => m.Especialidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Especialidades", "Especialidad") ?? m.Especialidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Medicoss_Especialista = _IMedicosApiConsumer.SelAll(true);
            if (Medicoss_Especialista != null && Medicoss_Especialista.Resource != null)
                ViewBag.Medicoss_Especialista = Medicoss_Especialista.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Medicos", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Vendedor = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Vendedor != null && Spartan_Users_Vendedor.Resource != null)
                ViewBag.Spartan_Users_Vendedor = Spartan_Users_Vendedor.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddTips_y_Promociones", varTips_y_Promociones);
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
        public ActionResult ShowAdvanceFilter(Tips_y_PromocionesAdvanceSearchModel model, int idFilter = -1)
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
            _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Especialidadess_Especialidad = _IEspecialidadesApiConsumer.SelAll(true);
            if (Especialidadess_Especialidad != null && Especialidadess_Especialidad.Resource != null)
                ViewBag.Especialidadess_Especialidad = Especialidadess_Especialidad.Resource.Where(m => m.Especialidad != null).OrderBy(m => m.Especialidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Especialidades", "Especialidad") ?? m.Especialidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Medicoss_Especialista = _IMedicosApiConsumer.SelAll(true);
            if (Medicoss_Especialista != null && Medicoss_Especialista.Resource != null)
                ViewBag.Medicoss_Especialista = Medicoss_Especialista.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Medicos", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Vendedor = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Vendedor != null && Spartan_Users_Vendedor.Resource != null)
                ViewBag.Spartan_Users_Vendedor = Spartan_Users_Vendedor.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
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
            _IEspecialidadesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Especialidadess_Especialidad = _IEspecialidadesApiConsumer.SelAll(true);
            if (Especialidadess_Especialidad != null && Especialidadess_Especialidad.Resource != null)
                ViewBag.Especialidadess_Especialidad = Especialidadess_Especialidad.Resource.Where(m => m.Especialidad != null).OrderBy(m => m.Especialidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Especialidades", "Especialidad") ?? m.Especialidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IMedicosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Medicoss_Especialista = _IMedicosApiConsumer.SelAll(true);
            if (Medicoss_Especialista != null && Medicoss_Especialista.Resource != null)
                ViewBag.Medicoss_Especialista = Medicoss_Especialista.Resource.Where(m => m.Nombre_Completo != null).OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Medicos", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Vendedor = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Vendedor != null && Spartan_Users_Vendedor.Resource != null)
                ViewBag.Spartan_Users_Vendedor = Spartan_Users_Vendedor.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            var previousFiltersObj = new Tips_y_PromocionesAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Tips_y_PromocionesAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Tips_y_PromocionesAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Tips_y_PromocionesPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ITips_y_PromocionesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Tips_y_Promocioness == null)
                result.Tips_y_Promocioness = new List<Tips_y_Promociones>();

            return Json(new
            {
                data = result.Tips_y_Promocioness.Select(m => new Tips_y_PromocionesGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_registro = (m.Fecha_de_registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre = m.Nombre
			,Descripcion_Corta = m.Descripcion_Corta
			,Descripcion_Larga = m.Descripcion_Larga
			,Imagen = m.Imagen
                        ,Fecha_inicio_de_Vigencia = (m.Fecha_inicio_de_Vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_de_Vigencia).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_de_Vigencia = (m.Fecha_fin_de_Vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_de_Vigencia).ToString(ConfigurationProperty.DateFormat))
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ?? (string)m.Especialidad_Especialidades.Especialidad
                        ,EspecialistaNombre_Completo = CultureHelper.GetTraduction(m.Especialista_Medicos.Folio.ToString(), "Nombre_Completo") ?? (string)m.Especialista_Medicos.Nombre_Completo
                        ,VendedorName = CultureHelper.GetTraduction(m.Vendedor_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Vendedor_Spartan_User.Name
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetTips_y_PromocionesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITips_y_PromocionesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITips_y_PromocionesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Tips_y_Promociones", m.),
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
        /// Get List of Tips_y_Promociones from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Tips_y_Promociones Entity</returns>
        public ActionResult GetTips_y_PromocionesList(UrlParametersModel param)
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
            _ITips_y_PromocionesApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Tips_y_PromocionesPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(Tips_y_PromocionesAdvanceSearchModel))
                {
					var advanceFilter =
                    (Tips_y_PromocionesAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Tips_y_PromocionesPropertyMapper oTips_y_PromocionesPropertyMapper = new Tips_y_PromocionesPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oTips_y_PromocionesPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ITips_y_PromocionesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Tips_y_Promocioness == null)
                result.Tips_y_Promocioness = new List<Tips_y_Promociones>();

            return Json(new
            {
                aaData = result.Tips_y_Promocioness.Select(m => new Tips_y_PromocionesGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_registro = (m.Fecha_de_registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre = m.Nombre
			,Descripcion_Corta = m.Descripcion_Corta
			,Descripcion_Larga = m.Descripcion_Larga
			,Imagen = m.Imagen
                        ,Fecha_inicio_de_Vigencia = (m.Fecha_inicio_de_Vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_de_Vigencia).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_de_Vigencia = (m.Fecha_fin_de_Vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_de_Vigencia).ToString(ConfigurationProperty.DateFormat))
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ?? (string)m.Especialidad_Especialidades.Especialidad
                        ,EspecialistaNombre_Completo = CultureHelper.GetTraduction(m.Especialista_Medicos.Folio.ToString(), "Nombre_Completo") ?? (string)m.Especialista_Medicos.Nombre_Completo
                        ,VendedorName = CultureHelper.GetTraduction(m.Vendedor_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Vendedor_Spartan_User.Name
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(Tips_y_PromocionesAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Tips_y_Promociones.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Tips_y_Promociones.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_registro) || !string.IsNullOrEmpty(filter.ToFecha_de_registro))
            {
                var Fecha_de_registroFrom = DateTime.ParseExact(filter.FromFecha_de_registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_registroTo = DateTime.ParseExact(filter.ToFecha_de_registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_registro))
                    where += " AND Tips_y_Promociones.Fecha_de_registro >= '" + Fecha_de_registroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_registro))
                    where += " AND Tips_y_Promociones.Fecha_de_registro <= '" + Fecha_de_registroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Tips_y_Promociones.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Tips_y_Promociones.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
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

                where += " AND Tips_y_Promociones.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombre))
            {
                switch (filter.NombreFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tips_y_Promociones.Nombre LIKE '" + filter.Nombre + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tips_y_Promociones.Nombre LIKE '%" + filter.Nombre + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tips_y_Promociones.Nombre = '" + filter.Nombre + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tips_y_Promociones.Nombre LIKE '%" + filter.Nombre + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Descripcion_Corta))
            {
                switch (filter.Descripcion_CortaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tips_y_Promociones.Descripcion_Corta LIKE '" + filter.Descripcion_Corta + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tips_y_Promociones.Descripcion_Corta LIKE '%" + filter.Descripcion_Corta + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tips_y_Promociones.Descripcion_Corta = '" + filter.Descripcion_Corta + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tips_y_Promociones.Descripcion_Corta LIKE '%" + filter.Descripcion_Corta + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Descripcion_Larga))
            {
                switch (filter.Descripcion_LargaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tips_y_Promociones.Descripcion_Larga LIKE '" + filter.Descripcion_Larga + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tips_y_Promociones.Descripcion_Larga LIKE '%" + filter.Descripcion_Larga + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tips_y_Promociones.Descripcion_Larga = '" + filter.Descripcion_Larga + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tips_y_Promociones.Descripcion_Larga LIKE '%" + filter.Descripcion_Larga + "%'";
                        break;
                }
            }

            if (filter.Imagen != RadioOptions.NoApply)
                where += " AND Tips_y_Promociones.Imagen " + (filter.Imagen == RadioOptions.Yes ? ">" : "==") + " 0";

            if (!string.IsNullOrEmpty(filter.FromFecha_inicio_de_Vigencia) || !string.IsNullOrEmpty(filter.ToFecha_inicio_de_Vigencia))
            {
                var Fecha_inicio_de_VigenciaFrom = DateTime.ParseExact(filter.FromFecha_inicio_de_Vigencia, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_inicio_de_VigenciaTo = DateTime.ParseExact(filter.ToFecha_inicio_de_Vigencia, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_inicio_de_Vigencia))
                    where += " AND Tips_y_Promociones.Fecha_inicio_de_Vigencia >= '" + Fecha_inicio_de_VigenciaFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_inicio_de_Vigencia))
                    where += " AND Tips_y_Promociones.Fecha_inicio_de_Vigencia <= '" + Fecha_inicio_de_VigenciaTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_fin_de_Vigencia) || !string.IsNullOrEmpty(filter.ToFecha_fin_de_Vigencia))
            {
                var Fecha_fin_de_VigenciaFrom = DateTime.ParseExact(filter.FromFecha_fin_de_Vigencia, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_fin_de_VigenciaTo = DateTime.ParseExact(filter.ToFecha_fin_de_Vigencia, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_fin_de_Vigencia))
                    where += " AND Tips_y_Promociones.Fecha_fin_de_Vigencia >= '" + Fecha_fin_de_VigenciaFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_fin_de_Vigencia))
                    where += " AND Tips_y_Promociones.Fecha_fin_de_Vigencia <= '" + Fecha_fin_de_VigenciaTo.ToString("MM-dd-yyyy") + "'";
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

                where += " AND Tips_y_Promociones.Especialidad In (" + EspecialidadIds + ")";
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

                where += " AND Tips_y_Promociones.Especialista In (" + EspecialistaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceVendedor))
            {
                switch (filter.VendedorFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.AdvanceVendedor + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceVendedor + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.AdvanceVendedor + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceVendedor + "%'";
                        break;
                }
            }
            else if (filter.AdvanceVendedorMultiple != null && filter.AdvanceVendedorMultiple.Count() > 0)
            {
                var VendedorIds = string.Join(",", filter.AdvanceVendedorMultiple);

                where += " AND Tips_y_Promociones.Vendedor In (" + VendedorIds + ")";
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

                where += " AND Tips_y_Promociones.Estatus In (" + EstatusIds + ")";
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
                _ITips_y_PromocionesApiConsumer.SetAuthHeader(_tokenManager.Token);

                Tips_y_Promociones varTips_y_Promociones = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _ITips_y_PromocionesApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Tips_y_PromocionesModel varTips_y_Promociones)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ITips_y_PromocionesApiConsumer.SetAuthHeader(_tokenManager.Token);


                    if (varTips_y_Promociones.ImagenRemoveAttachment != 0 && varTips_y_Promociones.ImagenFile == null)
                    {
                        varTips_y_Promociones.Imagen = 0;
                    }

                    if (varTips_y_Promociones.ImagenFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varTips_y_Promociones.ImagenFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varTips_y_Promociones.Imagen = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varTips_y_Promociones.ImagenFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                    
                    var result = "";
                    var Tips_y_PromocionesInfo = new Tips_y_Promociones
                    {
                        Folio = varTips_y_Promociones.Folio
                        ,Fecha_de_registro = (!String.IsNullOrEmpty(varTips_y_Promociones.Fecha_de_registro)) ? DateTime.ParseExact(varTips_y_Promociones.Fecha_de_registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varTips_y_Promociones.Hora_de_Registro
                        ,Usuario_que_Registra = varTips_y_Promociones.Usuario_que_Registra
                        ,Nombre = varTips_y_Promociones.Nombre
                        ,Descripcion_Corta = varTips_y_Promociones.Descripcion_Corta
                        ,Descripcion_Larga = varTips_y_Promociones.Descripcion_Larga
                        ,Imagen = (varTips_y_Promociones.Imagen.HasValue && varTips_y_Promociones.Imagen != 0) ? ((int?)Convert.ToInt32(varTips_y_Promociones.Imagen.Value)) : null

                        ,Fecha_inicio_de_Vigencia = (!String.IsNullOrEmpty(varTips_y_Promociones.Fecha_inicio_de_Vigencia)) ? DateTime.ParseExact(varTips_y_Promociones.Fecha_inicio_de_Vigencia, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Fecha_fin_de_Vigencia = (!String.IsNullOrEmpty(varTips_y_Promociones.Fecha_fin_de_Vigencia)) ? DateTime.ParseExact(varTips_y_Promociones.Fecha_fin_de_Vigencia, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Especialidad = varTips_y_Promociones.Especialidad
                        ,Especialista = varTips_y_Promociones.Especialista
                        ,Vendedor = varTips_y_Promociones.Vendedor
                        ,Estatus = varTips_y_Promociones.Estatus

                    };

                    result = !IsNew ?
                        _ITips_y_PromocionesApiConsumer.Update(Tips_y_PromocionesInfo, null, null).Resource.ToString() :
                         _ITips_y_PromocionesApiConsumer.Insert(Tips_y_PromocionesInfo, null, null).Resource.ToString();
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
        /// Write Element Array of Tips_y_Promociones script
        /// </summary>
        /// <param name="oTips_y_PromocionesElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Tips_y_PromocionesModuleAttributeList)
        {
            for (int i = 0; i < Tips_y_PromocionesModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Tips_y_PromocionesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Tips_y_PromocionesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Tips_y_PromocionesModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Tips_y_PromocionesModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Tips_y_PromocionesModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Tips_y_PromocionesModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Tips_y_PromocionesModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Tips_y_PromocionesModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Tips_y_PromocionesModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Tips_y_PromocionesModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Tips_y_PromocionesModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strTips_y_PromocionesScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Tips_y_Promociones.js")))
            {
                strTips_y_PromocionesScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Tips_y_Promociones element attributes
            string userChangeJson = jsSerialize.Serialize(Tips_y_PromocionesModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strTips_y_PromocionesScript.IndexOf("inpuElementArray");
            string splittedString = strTips_y_PromocionesScript.Substring(indexOfArray, strTips_y_PromocionesScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Tips_y_PromocionesModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Tips_y_PromocionesModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strTips_y_PromocionesScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strTips_y_PromocionesScript.Substring(indexOfArrayHistory, strTips_y_PromocionesScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strTips_y_PromocionesScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strTips_y_PromocionesScript.Substring(endIndexOfMainElement + indexOfArray, strTips_y_PromocionesScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Tips_y_PromocionesModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Tips_y_PromocionesModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Tips_y_Promociones.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Tips_y_Promociones.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Tips_y_Promociones.js")))
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
        public ActionResult Tips_y_PromocionesPropertyBag()
        {
            return PartialView("Tips_y_PromocionesPropertyBag", "Tips_y_Promociones");
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
                var whereClauseFormat = "Object = 44564 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _ITips_y_PromocionesApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Tips_y_Promociones.Folio= " + RecordId;
                            var result = _ITips_y_PromocionesApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _ITips_y_PromocionesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Tips_y_PromocionesPropertyMapper());
			
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
                    (Tips_y_PromocionesAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Tips_y_PromocionesPropertyMapper oTips_y_PromocionesPropertyMapper = new Tips_y_PromocionesPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oTips_y_PromocionesPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ITips_y_PromocionesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Tips_y_Promocioness == null)
                result.Tips_y_Promocioness = new List<Tips_y_Promociones>();

            var data = result.Tips_y_Promocioness.Select(m => new Tips_y_PromocionesGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_registro = (m.Fecha_de_registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre = m.Nombre
			,Descripcion_Corta = m.Descripcion_Corta
			,Descripcion_Larga = m.Descripcion_Larga
			,Imagen = m.Imagen
                        ,Fecha_inicio_de_Vigencia = (m.Fecha_inicio_de_Vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_de_Vigencia).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_de_Vigencia = (m.Fecha_fin_de_Vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_de_Vigencia).ToString(ConfigurationProperty.DateFormat))
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ?? (string)m.Especialidad_Especialidades.Especialidad
                        ,EspecialistaNombre_Completo = CultureHelper.GetTraduction(m.Especialista_Medicos.Folio.ToString(), "Nombre_Completo") ?? (string)m.Especialista_Medicos.Nombre_Completo
                        ,VendedorName = CultureHelper.GetTraduction(m.Vendedor_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Vendedor_Spartan_User.Name
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44564, arrayColumnsVisible), "Tips_y_PromocionesList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44564, arrayColumnsVisible), "Tips_y_PromocionesList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44564, arrayColumnsVisible), "Tips_y_PromocionesList_" + DateTime.Now.ToString());
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

            _ITips_y_PromocionesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Tips_y_PromocionesPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Tips_y_PromocionesAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Tips_y_PromocionesPropertyMapper oTips_y_PromocionesPropertyMapper = new Tips_y_PromocionesPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oTips_y_PromocionesPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ITips_y_PromocionesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Tips_y_Promocioness == null)
                result.Tips_y_Promocioness = new List<Tips_y_Promociones>();

            var data = result.Tips_y_Promocioness.Select(m => new Tips_y_PromocionesGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_registro = (m.Fecha_de_registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre = m.Nombre
			,Descripcion_Corta = m.Descripcion_Corta
			,Descripcion_Larga = m.Descripcion_Larga
			,Imagen = m.Imagen
                        ,Fecha_inicio_de_Vigencia = (m.Fecha_inicio_de_Vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_de_Vigencia).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_de_Vigencia = (m.Fecha_fin_de_Vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_de_Vigencia).ToString(ConfigurationProperty.DateFormat))
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ?? (string)m.Especialidad_Especialidades.Especialidad
                        ,EspecialistaNombre_Completo = CultureHelper.GetTraduction(m.Especialista_Medicos.Folio.ToString(), "Nombre_Completo") ?? (string)m.Especialista_Medicos.Nombre_Completo
                        ,VendedorName = CultureHelper.GetTraduction(m.Vendedor_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Vendedor_Spartan_User.Name
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
                _ITips_y_PromocionesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITips_y_PromocionesApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Tips_y_Promociones_Datos_GeneralesModel varTips_y_Promociones)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITips_y_PromocionesApiConsumer.SetAuthHeader(_tokenManager.Token);
				                    if (varTips_y_Promociones.ImagenRemoveAttachment != 0 && varTips_y_Promociones.ImagenFile == null)
                    {
                        varTips_y_Promociones.Imagen = 0;
                    }

                    if (varTips_y_Promociones.ImagenFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varTips_y_Promociones.ImagenFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varTips_y_Promociones.Imagen = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varTips_y_Promociones.ImagenFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                var result = "";
                var Tips_y_Promociones_Datos_GeneralesInfo = new Tips_y_Promociones_Datos_Generales
                {
                    Folio = varTips_y_Promociones.Folio
                                            ,Fecha_de_registro = (!String.IsNullOrEmpty(varTips_y_Promociones.Fecha_de_registro)) ? DateTime.ParseExact(varTips_y_Promociones.Fecha_de_registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varTips_y_Promociones.Hora_de_Registro
                        ,Usuario_que_Registra = varTips_y_Promociones.Usuario_que_Registra
                        ,Nombre = varTips_y_Promociones.Nombre
                        ,Descripcion_Corta = varTips_y_Promociones.Descripcion_Corta
                        ,Descripcion_Larga = varTips_y_Promociones.Descripcion_Larga
                        ,Imagen = (varTips_y_Promociones.Imagen.HasValue && varTips_y_Promociones.Imagen != 0) ? ((int?)Convert.ToInt32(varTips_y_Promociones.Imagen.Value)) : null

                        ,Fecha_inicio_de_Vigencia = (!String.IsNullOrEmpty(varTips_y_Promociones.Fecha_inicio_de_Vigencia)) ? DateTime.ParseExact(varTips_y_Promociones.Fecha_inicio_de_Vigencia, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Fecha_fin_de_Vigencia = (!String.IsNullOrEmpty(varTips_y_Promociones.Fecha_fin_de_Vigencia)) ? DateTime.ParseExact(varTips_y_Promociones.Fecha_fin_de_Vigencia, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Especialidad = varTips_y_Promociones.Especialidad
                        ,Especialista = varTips_y_Promociones.Especialista
                        ,Vendedor = varTips_y_Promociones.Vendedor
                        ,Estatus = varTips_y_Promociones.Estatus
                    
                };

                result = _ITips_y_PromocionesApiConsumer.Update_Datos_Generales(Tips_y_Promociones_Datos_GeneralesInfo).Resource.ToString();
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
                _ITips_y_PromocionesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _ITips_y_PromocionesApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				
                var result = new Tips_y_Promociones_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_registro = (m.Fecha_de_registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre = m.Nombre
			,Descripcion_Corta = m.Descripcion_Corta
			,Descripcion_Larga = m.Descripcion_Larga
			,Imagen = m.Imagen
                        ,Fecha_inicio_de_Vigencia = (m.Fecha_inicio_de_Vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_de_Vigencia).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_de_Vigencia = (m.Fecha_fin_de_Vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_de_Vigencia).ToString(ConfigurationProperty.DateFormat))
                        ,Especialidad = m.Especialidad
                        ,EspecialidadEspecialidad = CultureHelper.GetTraduction(m.Especialidad_Especialidades.Clave.ToString(), "Especialidad") ?? (string)m.Especialidad_Especialidades.Especialidad
                        ,Especialista = m.Especialista
                        ,EspecialistaNombre_Completo = CultureHelper.GetTraduction(m.Especialista_Medicos.Folio.ToString(), "Nombre_Completo") ?? (string)m.Especialista_Medicos.Nombre_Completo
                        ,Vendedor = m.Vendedor
                        ,VendedorName = CultureHelper.GetTraduction(m.Vendedor_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Vendedor_Spartan_User.Name
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

