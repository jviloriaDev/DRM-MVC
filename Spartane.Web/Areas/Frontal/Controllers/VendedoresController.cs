using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Vendedores;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Pais;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Sexo;
using Spartane.Core.Domain.Estatus;
using Spartane.Core.Domain.Detalle_Codigos_de_Referencia_Vendedores;







using Spartane.Core.Domain.Spartan_User;


using Spartane.Core.Domain.Estatus;

using Spartane.Core.Domain.Bancos;
using Spartane.Core.Domain.Detalle_Facturacion_Vendedores;







using Spartane.Core.Domain.Estatus_Facturas;





using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Vendedores;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Vendedores;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Pais;
using Spartane.Web.Areas.WebApiConsumer.Estado;
using Spartane.Web.Areas.WebApiConsumer.Sexo;
using Spartane.Web.Areas.WebApiConsumer.Estatus;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Codigos_de_Referencia_Vendedores;




using Spartane.Web.Areas.WebApiConsumer.Spartan_User;


using Spartane.Web.Areas.WebApiConsumer.Estatus;

using Spartane.Web.Areas.WebApiConsumer.Bancos;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Facturacion_Vendedores;





using Spartane.Web.Areas.WebApiConsumer.Estatus_Facturas;





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
    public class VendedoresController : Controller
    {
        #region "variable declaration"

        private IVendedoresService service = null;
        private IVendedoresApiConsumer _IVendedoresApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IPaisApiConsumer _IPaisApiConsumer;
        private IEstadoApiConsumer _IEstadoApiConsumer;
        private ISexoApiConsumer _ISexoApiConsumer;
        private IEstatusApiConsumer _IEstatusApiConsumer;
        private IDetalle_Codigos_de_Referencia_VendedoresApiConsumer _IDetalle_Codigos_de_Referencia_VendedoresApiConsumer;







        private IBancosApiConsumer _IBancosApiConsumer;
        private IDetalle_Facturacion_VendedoresApiConsumer _IDetalle_Facturacion_VendedoresApiConsumer;





        private IEstatus_FacturasApiConsumer _IEstatus_FacturasApiConsumer;





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

        
        public VendedoresController(IVendedoresService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IVendedoresApiConsumer VendedoresApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IPaisApiConsumer PaisApiConsumer , IEstadoApiConsumer EstadoApiConsumer , ISexoApiConsumer SexoApiConsumer , IEstatusApiConsumer EstatusApiConsumer , IDetalle_Codigos_de_Referencia_VendedoresApiConsumer Detalle_Codigos_de_Referencia_VendedoresApiConsumer  , IBancosApiConsumer BancosApiConsumer , IDetalle_Facturacion_VendedoresApiConsumer Detalle_Facturacion_VendedoresApiConsumer , IEstatus_FacturasApiConsumer Estatus_FacturasApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IVendedoresApiConsumer = VendedoresApiConsumer;
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
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._IPaisApiConsumer = PaisApiConsumer;
            this._IEstadoApiConsumer = EstadoApiConsumer;
            this._ISexoApiConsumer = SexoApiConsumer;
            this._IEstatusApiConsumer = EstatusApiConsumer;
            this._IDetalle_Codigos_de_Referencia_VendedoresApiConsumer = Detalle_Codigos_de_Referencia_VendedoresApiConsumer;




            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;


            this._IEstatusApiConsumer = EstatusApiConsumer;

            this._IBancosApiConsumer = BancosApiConsumer;
            this._IDetalle_Facturacion_VendedoresApiConsumer = Detalle_Facturacion_VendedoresApiConsumer;





            this._IEstatus_FacturasApiConsumer = Estatus_FacturasApiConsumer;





        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Vendedores
        [ObjectAuth(ObjectId = (ModuleObjectId)44586, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44586, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Vendedores/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44586, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44586, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varVendedores = new VendedoresModel();
			varVendedores.Folio = Id;
			
            ViewBag.ObjectId = "44586";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionDetalle_Codigos_de_Referencia_Vendedores = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44587, ModuleId);
            ViewBag.PermissionDetalle_Codigos_de_Referencia_Vendedores = permissionDetalle_Codigos_de_Referencia_Vendedores;
            var permissionDetalle_Facturacion_Vendedores = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44588, ModuleId);
            ViewBag.PermissionDetalle_Facturacion_Vendedores = permissionDetalle_Facturacion_Vendedores;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IVendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var VendedoressData = _IVendedoresApiConsumer.ListaSelAll(0, 1000, "Vendedores.Folio=" + Id, "").Resource.Vendedoress;
				
				if (VendedoressData != null && VendedoressData.Count > 0)
                {
					var VendedoresData = VendedoressData.First();
					varVendedores= new VendedoresModel
					{
						Folio  = VendedoresData.Folio 
	                    ,Fecha_de_Registro = (VendedoresData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(VendedoresData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = VendedoresData.Hora_de_Registro
                    ,Usuario_que_Registra = VendedoresData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(VendedoresData.Usuario_que_Registra), "Spartan_User") ??  (string)VendedoresData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombres = VendedoresData.Nombres
                    ,Apellido_Paterno = VendedoresData.Apellido_Paterno
                    ,Apellido_Materno = VendedoresData.Apellido_Materno
                    ,Nombre_Completo = VendedoresData.Nombre_Completo
                    ,Nombre_de_Usuario = VendedoresData.Nombre_de_Usuario
                    ,Usuario_Registrado = VendedoresData.Usuario_Registrado
                    ,Usuario_RegistradoName = CultureHelper.GetTraduction(Convert.ToString(VendedoresData.Usuario_Registrado), "Spartan_User") ??  (string)VendedoresData.Usuario_Registrado_Spartan_User.Name
                    ,Email = VendedoresData.Email
                    ,Celular = VendedoresData.Celular
                    ,Fecha_de_nacimiento = (VendedoresData.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(VendedoresData.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                    ,Pais_de_nacimiento = VendedoresData.Pais_de_nacimiento
                    ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(VendedoresData.Pais_de_nacimiento), "Pais") ??  (string)VendedoresData.Pais_de_nacimiento_Pais.Nombre_del_Pais
                    ,Entidad_de_nacimiento = VendedoresData.Entidad_de_nacimiento
                    ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(VendedoresData.Entidad_de_nacimiento), "Estado") ??  (string)VendedoresData.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                    ,Sexo = VendedoresData.Sexo
                    ,SexoDescripcion = CultureHelper.GetTraduction(Convert.ToString(VendedoresData.Sexo), "Sexo") ??  (string)VendedoresData.Sexo_Sexo.Descripcion
                    ,Estatus = VendedoresData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(VendedoresData.Estatus), "Estatus") ??  (string)VendedoresData.Estatus_Estatus.Descripcion
                    ,Banco = VendedoresData.Banco
                    ,BancoNombre = CultureHelper.GetTraduction(Convert.ToString(VendedoresData.Banco), "Bancos") ??  (string)VendedoresData.Banco_Bancos.Nombre
                    ,CLABE_Interbancaria = VendedoresData.CLABE_Interbancaria
                    ,Numero_de_Cuenta = VendedoresData.Numero_de_Cuenta
                    ,Nombre_del_Titular = VendedoresData.Nombre_del_Titular

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
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_Registrado = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_Registrado != null && Spartan_Users_Usuario_Registrado.Resource != null)
                ViewBag.Spartan_Users_Usuario_Registrado = Spartan_Users_Usuario_Registrado.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_de_nacimiento = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_de_nacimiento != null && Paiss_Pais_de_nacimiento.Resource != null)
                ViewBag.Paiss_Pais_de_nacimiento = Paiss_Pais_de_nacimiento.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Entidad_de_nacimiento = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Entidad_de_nacimiento != null && Estados_Entidad_de_nacimiento.Resource != null)
                ViewBag.Estados_Entidad_de_nacimiento = Estados_Entidad_de_nacimiento.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
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
            _IBancosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Bancoss_Banco = _IBancosApiConsumer.SelAll(true);
            if (Bancoss_Banco != null && Bancoss_Banco.Resource != null)
                ViewBag.Bancoss_Banco = Bancoss_Banco.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Bancos", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
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

				
            return View(varVendedores);
        }
		
	[HttpGet]
        public ActionResult AddVendedores(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44586);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IVendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
			VendedoresModel varVendedores= new VendedoresModel();
            var permissionDetalle_Codigos_de_Referencia_Vendedores = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44587, ModuleId);
            ViewBag.PermissionDetalle_Codigos_de_Referencia_Vendedores = permissionDetalle_Codigos_de_Referencia_Vendedores;
            var permissionDetalle_Facturacion_Vendedores = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44588, ModuleId);
            ViewBag.PermissionDetalle_Facturacion_Vendedores = permissionDetalle_Facturacion_Vendedores;


            if (id.ToString() != "0")
            {
                var VendedoressData = _IVendedoresApiConsumer.ListaSelAll(0, 1000, "Vendedores.Folio=" + id, "").Resource.Vendedoress;
				
				if (VendedoressData != null && VendedoressData.Count > 0)
                {
					var VendedoresData = VendedoressData.First();
					varVendedores= new VendedoresModel
					{
						Folio  = VendedoresData.Folio 
	                    ,Fecha_de_Registro = (VendedoresData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(VendedoresData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = VendedoresData.Hora_de_Registro
                    ,Usuario_que_Registra = VendedoresData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(VendedoresData.Usuario_que_Registra), "Spartan_User") ??  (string)VendedoresData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombres = VendedoresData.Nombres
                    ,Apellido_Paterno = VendedoresData.Apellido_Paterno
                    ,Apellido_Materno = VendedoresData.Apellido_Materno
                    ,Nombre_Completo = VendedoresData.Nombre_Completo
                    ,Nombre_de_Usuario = VendedoresData.Nombre_de_Usuario
                    ,Usuario_Registrado = VendedoresData.Usuario_Registrado
                    ,Usuario_RegistradoName = CultureHelper.GetTraduction(Convert.ToString(VendedoresData.Usuario_Registrado), "Spartan_User") ??  (string)VendedoresData.Usuario_Registrado_Spartan_User.Name
                    ,Email = VendedoresData.Email
                    ,Celular = VendedoresData.Celular
                    ,Fecha_de_nacimiento = (VendedoresData.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(VendedoresData.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                    ,Pais_de_nacimiento = VendedoresData.Pais_de_nacimiento
                    ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(VendedoresData.Pais_de_nacimiento), "Pais") ??  (string)VendedoresData.Pais_de_nacimiento_Pais.Nombre_del_Pais
                    ,Entidad_de_nacimiento = VendedoresData.Entidad_de_nacimiento
                    ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(VendedoresData.Entidad_de_nacimiento), "Estado") ??  (string)VendedoresData.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                    ,Sexo = VendedoresData.Sexo
                    ,SexoDescripcion = CultureHelper.GetTraduction(Convert.ToString(VendedoresData.Sexo), "Sexo") ??  (string)VendedoresData.Sexo_Sexo.Descripcion
                    ,Estatus = VendedoresData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(VendedoresData.Estatus), "Estatus") ??  (string)VendedoresData.Estatus_Estatus.Descripcion
                    ,Banco = VendedoresData.Banco
                    ,BancoNombre = CultureHelper.GetTraduction(Convert.ToString(VendedoresData.Banco), "Bancos") ??  (string)VendedoresData.Banco_Bancos.Nombre
                    ,CLABE_Interbancaria = VendedoresData.CLABE_Interbancaria
                    ,Numero_de_Cuenta = VendedoresData.Numero_de_Cuenta
                    ,Nombre_del_Titular = VendedoresData.Nombre_del_Titular

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
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_Registrado = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_Registrado != null && Spartan_Users_Usuario_Registrado.Resource != null)
                ViewBag.Spartan_Users_Usuario_Registrado = Spartan_Users_Usuario_Registrado.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_de_nacimiento = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_de_nacimiento != null && Paiss_Pais_de_nacimiento.Resource != null)
                ViewBag.Paiss_Pais_de_nacimiento = Paiss_Pais_de_nacimiento.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Entidad_de_nacimiento = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Entidad_de_nacimiento != null && Estados_Entidad_de_nacimiento.Resource != null)
                ViewBag.Estados_Entidad_de_nacimiento = Estados_Entidad_de_nacimiento.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
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
            _IBancosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Bancoss_Banco = _IBancosApiConsumer.SelAll(true);
            if (Bancoss_Banco != null && Bancoss_Banco.Resource != null)
                ViewBag.Bancoss_Banco = Bancoss_Banco.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Bancos", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddVendedores", varVendedores);
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
        public ActionResult GetPaisAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPaisApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais")?? m.Nombre_del_Pais,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstadoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstadoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado")?? m.Nombre_del_Estado,
                    Value = Convert.ToString(m.Clave)
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
        [HttpGet]
        public ActionResult GetBancosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IBancosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IBancosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Bancos", "Nombre")?? m.Nombre,
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
        public ActionResult ShowAdvanceFilter(VendedoresAdvanceSearchModel model, int idFilter = -1)
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
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_Registrado = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_Registrado != null && Spartan_Users_Usuario_Registrado.Resource != null)
                ViewBag.Spartan_Users_Usuario_Registrado = Spartan_Users_Usuario_Registrado.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_de_nacimiento = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_de_nacimiento != null && Paiss_Pais_de_nacimiento.Resource != null)
                ViewBag.Paiss_Pais_de_nacimiento = Paiss_Pais_de_nacimiento.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Entidad_de_nacimiento = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Entidad_de_nacimiento != null && Estados_Entidad_de_nacimiento.Resource != null)
                ViewBag.Estados_Entidad_de_nacimiento = Estados_Entidad_de_nacimiento.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
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
            _IBancosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Bancoss_Banco = _IBancosApiConsumer.SelAll(true);
            if (Bancoss_Banco != null && Bancoss_Banco.Resource != null)
                ViewBag.Bancoss_Banco = Bancoss_Banco.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Bancos", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
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
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_Registrado = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_Registrado != null && Spartan_Users_Usuario_Registrado.Resource != null)
                ViewBag.Spartan_Users_Usuario_Registrado = Spartan_Users_Usuario_Registrado.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_de_nacimiento = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_de_nacimiento != null && Paiss_Pais_de_nacimiento.Resource != null)
                ViewBag.Paiss_Pais_de_nacimiento = Paiss_Pais_de_nacimiento.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Entidad_de_nacimiento = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Entidad_de_nacimiento != null && Estados_Entidad_de_nacimiento.Resource != null)
                ViewBag.Estados_Entidad_de_nacimiento = Estados_Entidad_de_nacimiento.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
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
            _IBancosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Bancoss_Banco = _IBancosApiConsumer.SelAll(true);
            if (Bancoss_Banco != null && Bancoss_Banco.Resource != null)
                ViewBag.Bancoss_Banco = Bancoss_Banco.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Bancos", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            var previousFiltersObj = new VendedoresAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (VendedoresAdvanceSearchModel)(Session["AdvanceSearch"] ?? new VendedoresAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new VendedoresPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IVendedoresApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Vendedoress == null)
                result.Vendedoress = new List<Vendedores>();

            return Json(new
            {
                data = result.Vendedoress.Select(m => new VendedoresGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
			,Nombre_de_Usuario = m.Nombre_de_Usuario
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Email = m.Email
			,Celular = m.Celular
                        ,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Entidad_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
                        ,BancoNombre = CultureHelper.GetTraduction(m.Banco_Bancos.Clave.ToString(), "Nombre") ?? (string)m.Banco_Bancos.Nombre
			,CLABE_Interbancaria = m.CLABE_Interbancaria
			,Numero_de_Cuenta = m.Numero_de_Cuenta
			,Nombre_del_Titular = m.Nombre_del_Titular

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetVendedoresAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IVendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IVendedoresApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Vendedores", m.),
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
        /// Get List of Vendedores from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Vendedores Entity</returns>
        public ActionResult GetVendedoresList(UrlParametersModel param)
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
            _IVendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new VendedoresPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(VendedoresAdvanceSearchModel))
                {
					var advanceFilter =
                    (VendedoresAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            VendedoresPropertyMapper oVendedoresPropertyMapper = new VendedoresPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oVendedoresPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IVendedoresApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Vendedoress == null)
                result.Vendedoress = new List<Vendedores>();

            return Json(new
            {
                aaData = result.Vendedoress.Select(m => new VendedoresGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
			,Nombre_de_Usuario = m.Nombre_de_Usuario
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Email = m.Email
			,Celular = m.Celular
                        ,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Entidad_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
                        ,BancoNombre = CultureHelper.GetTraduction(m.Banco_Bancos.Clave.ToString(), "Nombre") ?? (string)m.Banco_Bancos.Nombre
			,CLABE_Interbancaria = m.CLABE_Interbancaria
			,Numero_de_Cuenta = m.Numero_de_Cuenta
			,Nombre_del_Titular = m.Nombre_del_Titular

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete

//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(VendedoresAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Vendedores.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Vendedores.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Vendedores.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Vendedores.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Vendedores.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Vendedores.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
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

                where += " AND Vendedores.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombres))
            {
                switch (filter.NombresFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Vendedores.Nombres LIKE '" + filter.Nombres + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Vendedores.Nombres LIKE '%" + filter.Nombres + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Vendedores.Nombres = '" + filter.Nombres + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Vendedores.Nombres LIKE '%" + filter.Nombres + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Apellido_Paterno))
            {
                switch (filter.Apellido_PaternoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Vendedores.Apellido_Paterno LIKE '" + filter.Apellido_Paterno + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Vendedores.Apellido_Paterno LIKE '%" + filter.Apellido_Paterno + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Vendedores.Apellido_Paterno = '" + filter.Apellido_Paterno + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Vendedores.Apellido_Paterno LIKE '%" + filter.Apellido_Paterno + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Apellido_Materno))
            {
                switch (filter.Apellido_MaternoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Vendedores.Apellido_Materno LIKE '" + filter.Apellido_Materno + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Vendedores.Apellido_Materno LIKE '%" + filter.Apellido_Materno + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Vendedores.Apellido_Materno = '" + filter.Apellido_Materno + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Vendedores.Apellido_Materno LIKE '%" + filter.Apellido_Materno + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Nombre_Completo))
            {
                switch (filter.Nombre_CompletoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Vendedores.Nombre_Completo LIKE '" + filter.Nombre_Completo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Vendedores.Nombre_Completo LIKE '%" + filter.Nombre_Completo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Vendedores.Nombre_Completo = '" + filter.Nombre_Completo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Vendedores.Nombre_Completo LIKE '%" + filter.Nombre_Completo + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Nombre_de_Usuario))
            {
                switch (filter.Nombre_de_UsuarioFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Vendedores.Nombre_de_Usuario LIKE '" + filter.Nombre_de_Usuario + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Vendedores.Nombre_de_Usuario LIKE '%" + filter.Nombre_de_Usuario + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Vendedores.Nombre_de_Usuario = '" + filter.Nombre_de_Usuario + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Vendedores.Nombre_de_Usuario LIKE '%" + filter.Nombre_de_Usuario + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceUsuario_Registrado))
            {
                switch (filter.Usuario_RegistradoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.AdvanceUsuario_Registrado + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_Registrado + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.AdvanceUsuario_Registrado + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUsuario_Registrado + "%'";
                        break;
                }
            }
            else if (filter.AdvanceUsuario_RegistradoMultiple != null && filter.AdvanceUsuario_RegistradoMultiple.Count() > 0)
            {
                var Usuario_RegistradoIds = string.Join(",", filter.AdvanceUsuario_RegistradoMultiple);

                where += " AND Vendedores.Usuario_Registrado In (" + Usuario_RegistradoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Email))
            {
                switch (filter.EmailFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Vendedores.Email LIKE '" + filter.Email + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Vendedores.Email LIKE '%" + filter.Email + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Vendedores.Email = '" + filter.Email + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Vendedores.Email LIKE '%" + filter.Email + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Celular))
            {
                switch (filter.CelularFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Vendedores.Celular LIKE '" + filter.Celular + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Vendedores.Celular LIKE '%" + filter.Celular + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Vendedores.Celular = '" + filter.Celular + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Vendedores.Celular LIKE '%" + filter.Celular + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_nacimiento) || !string.IsNullOrEmpty(filter.ToFecha_de_nacimiento))
            {
                var Fecha_de_nacimientoFrom = DateTime.ParseExact(filter.FromFecha_de_nacimiento, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_nacimientoTo = DateTime.ParseExact(filter.ToFecha_de_nacimiento, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_nacimiento))
                    where += " AND Vendedores.Fecha_de_nacimiento >= '" + Fecha_de_nacimientoFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_nacimiento))
                    where += " AND Vendedores.Fecha_de_nacimiento <= '" + Fecha_de_nacimientoTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvancePais_de_nacimiento))
            {
                switch (filter.Pais_de_nacimientoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pais.Nombre_del_Pais LIKE '" + filter.AdvancePais_de_nacimiento + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pais.Nombre_del_Pais LIKE '%" + filter.AdvancePais_de_nacimiento + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pais.Nombre_del_Pais = '" + filter.AdvancePais_de_nacimiento + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pais.Nombre_del_Pais LIKE '%" + filter.AdvancePais_de_nacimiento + "%'";
                        break;
                }
            }
            else if (filter.AdvancePais_de_nacimientoMultiple != null && filter.AdvancePais_de_nacimientoMultiple.Count() > 0)
            {
                var Pais_de_nacimientoIds = string.Join(",", filter.AdvancePais_de_nacimientoMultiple);

                where += " AND Vendedores.Pais_de_nacimiento In (" + Pais_de_nacimientoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEntidad_de_nacimiento))
            {
                switch (filter.Entidad_de_nacimientoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estado.Nombre_del_Estado LIKE '" + filter.AdvanceEntidad_de_nacimiento + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estado.Nombre_del_Estado LIKE '%" + filter.AdvanceEntidad_de_nacimiento + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estado.Nombre_del_Estado = '" + filter.AdvanceEntidad_de_nacimiento + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estado.Nombre_del_Estado LIKE '%" + filter.AdvanceEntidad_de_nacimiento + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEntidad_de_nacimientoMultiple != null && filter.AdvanceEntidad_de_nacimientoMultiple.Count() > 0)
            {
                var Entidad_de_nacimientoIds = string.Join(",", filter.AdvanceEntidad_de_nacimientoMultiple);

                where += " AND Vendedores.Entidad_de_nacimiento In (" + Entidad_de_nacimientoIds + ")";
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

                where += " AND Vendedores.Sexo In (" + SexoIds + ")";
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

                where += " AND Vendedores.Estatus In (" + EstatusIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceBanco))
            {
                switch (filter.BancoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Bancos.Nombre LIKE '" + filter.AdvanceBanco + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Bancos.Nombre LIKE '%" + filter.AdvanceBanco + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Bancos.Nombre = '" + filter.AdvanceBanco + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Bancos.Nombre LIKE '%" + filter.AdvanceBanco + "%'";
                        break;
                }
            }
            else if (filter.AdvanceBancoMultiple != null && filter.AdvanceBancoMultiple.Count() > 0)
            {
                var BancoIds = string.Join(",", filter.AdvanceBancoMultiple);

                where += " AND Vendedores.Banco In (" + BancoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.CLABE_Interbancaria))
            {
                switch (filter.CLABE_InterbancariaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Vendedores.CLABE_Interbancaria LIKE '" + filter.CLABE_Interbancaria + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Vendedores.CLABE_Interbancaria LIKE '%" + filter.CLABE_Interbancaria + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Vendedores.CLABE_Interbancaria = '" + filter.CLABE_Interbancaria + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Vendedores.CLABE_Interbancaria LIKE '%" + filter.CLABE_Interbancaria + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Numero_de_Cuenta))
            {
                switch (filter.Numero_de_CuentaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Vendedores.Numero_de_Cuenta LIKE '" + filter.Numero_de_Cuenta + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Vendedores.Numero_de_Cuenta LIKE '%" + filter.Numero_de_Cuenta + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Vendedores.Numero_de_Cuenta = '" + filter.Numero_de_Cuenta + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Vendedores.Numero_de_Cuenta LIKE '%" + filter.Numero_de_Cuenta + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Nombre_del_Titular))
            {
                switch (filter.Nombre_del_TitularFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Vendedores.Nombre_del_Titular LIKE '" + filter.Nombre_del_Titular + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Vendedores.Nombre_del_Titular LIKE '%" + filter.Nombre_del_Titular + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Vendedores.Nombre_del_Titular = '" + filter.Nombre_del_Titular + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Vendedores.Nombre_del_Titular LIKE '%" + filter.Nombre_del_Titular + "%'";
                        break;
                }
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

        public ActionResult GetDetalle_Codigos_de_Referencia_Vendedores(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Codigos_de_Referencia_VendedoresGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Codigos_de_Referencia_VendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Codigos_de_Referencia_Vendedores.FolioVendedores=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Codigos_de_Referencia_Vendedores.FolioVendedores='" + RelationId + "'";
            }
            var result = _IDetalle_Codigos_de_Referencia_VendedoresApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Codigos_de_Referencia_Vendedoress == null)
                result.Detalle_Codigos_de_Referencia_Vendedoress = new List<Detalle_Codigos_de_Referencia_Vendedores>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Codigos_de_Referencia_Vendedoress.Select(m => new Detalle_Codigos_de_Referencia_VendedoresGridModel
                {
                    Folio = m.Folio

			,Porcentaje_de_descuento = m.Porcentaje_de_descuento
			,Fecha_inicio_vigencia = (m.Fecha_inicio_vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_vigencia).ToString(ConfigurationProperty.DateFormat))
			,Fecha_fin_vigencia = (m.Fecha_fin_vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_vigencia).ToString(ConfigurationProperty.DateFormat))
			,Cantidad_maxima_de_referenciados = m.Cantidad_maxima_de_referenciados
			,Codigo_para_referenciados = m.Codigo_para_referenciados
			,Autorizado = m.Autorizado
                        ,Usuario_que_autoriza = m.Usuario_que_autoriza
                        ,Usuario_que_autorizaName = CultureHelper.GetTraduction(m.Usuario_que_autoriza_Spartan_User.Id_User.ToString(), "Name") ??(string)m.Usuario_que_autoriza_Spartan_User.Name
			,Fecha_de_autorizacion = (m.Fecha_de_autorizacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_autorizacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_autorizacion = m.Hora_de_autorizacion
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus.Descripcion

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Codigos_de_Referencia_VendedoresGridModel> GetDetalle_Codigos_de_Referencia_VendedoresData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Codigos_de_Referencia_VendedoresGridModel> resultData = new List<Detalle_Codigos_de_Referencia_VendedoresGridModel>();
            string where = "Detalle_Codigos_de_Referencia_Vendedores.FolioVendedores=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Codigos_de_Referencia_Vendedores.FolioVendedores='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Codigos_de_Referencia_VendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Codigos_de_Referencia_VendedoresApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Codigos_de_Referencia_Vendedoress != null)
            {
                resultData = result.Detalle_Codigos_de_Referencia_Vendedoress.Select(m => new Detalle_Codigos_de_Referencia_VendedoresGridModel
                    {
                        Folio = m.Folio

			,Porcentaje_de_descuento = m.Porcentaje_de_descuento
			,Fecha_inicio_vigencia = (m.Fecha_inicio_vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_vigencia).ToString(ConfigurationProperty.DateFormat))
			,Fecha_fin_vigencia = (m.Fecha_fin_vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_vigencia).ToString(ConfigurationProperty.DateFormat))
			,Cantidad_maxima_de_referenciados = m.Cantidad_maxima_de_referenciados
			,Codigo_para_referenciados = m.Codigo_para_referenciados
			,Autorizado = m.Autorizado
                        ,Usuario_que_autoriza = m.Usuario_que_autoriza
                        ,Usuario_que_autorizaName = CultureHelper.GetTraduction(m.Usuario_que_autoriza_Spartan_User.Id_User.ToString(), "Name") ??(string)m.Usuario_que_autoriza_Spartan_User.Name
			,Fecha_de_autorizacion = (m.Fecha_de_autorizacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_autorizacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_autorizacion = m.Hora_de_autorizacion
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus.Descripcion


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Facturacion_Vendedores(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Facturacion_VendedoresGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Facturacion_VendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Facturacion_Vendedores.FolioVendedores=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Facturacion_Vendedores.FolioVendedores='" + RelationId + "'";
            }
            var result = _IDetalle_Facturacion_VendedoresApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Facturacion_Vendedoress == null)
                result.Detalle_Facturacion_Vendedoress = new List<Detalle_Facturacion_Vendedores>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Facturacion_Vendedoress.Select(m => new Detalle_Facturacion_VendedoresGridModel
                {
                    Folio = m.Folio

			,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Folio_Factura = m.Folio_Factura
			,Periodo_Facturado = m.Periodo_Facturado
			,Cantidad = m.Cantidad
			,Archivo_XMLFileInfo = m.Archivo_XML > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Archivo_XML).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }
			,Archivo_PDFFileInfo = m.Archivo_PDF > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Archivo_PDF).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Facturas.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus_Facturas.Descripcion
			,Fecha_programada_de_Pago = (m.Fecha_programada_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_programada_de_Pago).ToString(ConfigurationProperty.DateFormat))
			,Pagada = m.Pagada
			,Fecha_de_Pago = (m.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Facturacion_VendedoresGridModel> GetDetalle_Facturacion_VendedoresData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Facturacion_VendedoresGridModel> resultData = new List<Detalle_Facturacion_VendedoresGridModel>();
            string where = "Detalle_Facturacion_Vendedores.FolioVendedores=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Facturacion_Vendedores.FolioVendedores='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Facturacion_VendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Facturacion_VendedoresApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Facturacion_Vendedoress != null)
            {
                resultData = result.Detalle_Facturacion_Vendedoress.Select(m => new Detalle_Facturacion_VendedoresGridModel
                    {
                        Folio = m.Folio

			,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Folio_Factura = m.Folio_Factura
			,Periodo_Facturado = m.Periodo_Facturado
			,Cantidad = m.Cantidad
			,Archivo_XMLFileInfo = m.Archivo_XML > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Archivo_XML).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }
			,Archivo_PDFFileInfo = m.Archivo_PDF > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Archivo_PDF).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_Facturas.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus_Facturas.Descripcion
			,Fecha_programada_de_Pago = (m.Fecha_programada_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_programada_de_Pago).ToString(ConfigurationProperty.DateFormat))
			,Pagada = m.Pagada
			,Fecha_de_Pago = (m.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))


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
                _IVendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

                Vendedores varVendedores = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IDetalle_Codigos_de_Referencia_VendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Codigos_de_Referencia_Vendedores.FolioVendedores=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Codigos_de_Referencia_Vendedores.FolioVendedores='" + id + "'";
                    }
                    var Detalle_Codigos_de_Referencia_VendedoresInfo =
                        _IDetalle_Codigos_de_Referencia_VendedoresApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Codigos_de_Referencia_VendedoresInfo.Detalle_Codigos_de_Referencia_Vendedoress.Count > 0)
                    {
                        var resultDetalle_Codigos_de_Referencia_Vendedores = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Codigos_de_Referencia_VendedoresItem in Detalle_Codigos_de_Referencia_VendedoresInfo.Detalle_Codigos_de_Referencia_Vendedoress)
                            resultDetalle_Codigos_de_Referencia_Vendedores = resultDetalle_Codigos_de_Referencia_Vendedores
                                              && _IDetalle_Codigos_de_Referencia_VendedoresApiConsumer.Delete(Detalle_Codigos_de_Referencia_VendedoresItem.Folio, null,null).Resource;

                        if (!resultDetalle_Codigos_de_Referencia_Vendedores)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Facturacion_VendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Facturacion_Vendedores.FolioVendedores=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Facturacion_Vendedores.FolioVendedores='" + id + "'";
                    }
                    var Detalle_Facturacion_VendedoresInfo =
                        _IDetalle_Facturacion_VendedoresApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Facturacion_VendedoresInfo.Detalle_Facturacion_Vendedoress.Count > 0)
                    {
                        var resultDetalle_Facturacion_Vendedores = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Facturacion_VendedoresItem in Detalle_Facturacion_VendedoresInfo.Detalle_Facturacion_Vendedoress)
                            resultDetalle_Facturacion_Vendedores = resultDetalle_Facturacion_Vendedores
                                              && _IDetalle_Facturacion_VendedoresApiConsumer.Delete(Detalle_Facturacion_VendedoresItem.Folio, null,null).Resource;

                        if (!resultDetalle_Facturacion_Vendedores)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IVendedoresApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, VendedoresModel varVendedores)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IVendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var VendedoresInfo = new Vendedores
                    {
                        Folio = varVendedores.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varVendedores.Fecha_de_Registro)) ? DateTime.ParseExact(varVendedores.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varVendedores.Hora_de_Registro
                        ,Usuario_que_Registra = varVendedores.Usuario_que_Registra
                        ,Nombres = varVendedores.Nombres
                        ,Apellido_Paterno = varVendedores.Apellido_Paterno
                        ,Apellido_Materno = varVendedores.Apellido_Materno
                        ,Nombre_Completo = varVendedores.Nombre_Completo
                        ,Nombre_de_Usuario = varVendedores.Nombre_de_Usuario
                        ,Usuario_Registrado = varVendedores.Usuario_Registrado
                        ,Email = varVendedores.Email
                        ,Celular = varVendedores.Celular
                        ,Fecha_de_nacimiento = (!String.IsNullOrEmpty(varVendedores.Fecha_de_nacimiento)) ? DateTime.ParseExact(varVendedores.Fecha_de_nacimiento, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Pais_de_nacimiento = varVendedores.Pais_de_nacimiento
                        ,Entidad_de_nacimiento = varVendedores.Entidad_de_nacimiento
                        ,Sexo = varVendedores.Sexo
                        ,Estatus = varVendedores.Estatus
                        ,Banco = varVendedores.Banco
                        ,CLABE_Interbancaria = varVendedores.CLABE_Interbancaria
                        ,Numero_de_Cuenta = varVendedores.Numero_de_Cuenta
                        ,Nombre_del_Titular = varVendedores.Nombre_del_Titular

                    };

                    result = !IsNew ?
                        _IVendedoresApiConsumer.Update(VendedoresInfo, null, null).Resource.ToString() :
                         _IVendedoresApiConsumer.Insert(VendedoresInfo, null, null).Resource.ToString();
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
        public bool CopyDetalle_Codigos_de_Referencia_Vendedores(int MasterId, int referenceId, List<Detalle_Codigos_de_Referencia_VendedoresGridModelPost> Detalle_Codigos_de_Referencia_VendedoresItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Codigos_de_Referencia_VendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Codigos_de_Referencia_VendedoresData = _IDetalle_Codigos_de_Referencia_VendedoresApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Codigos_de_Referencia_Vendedores.FolioVendedores=" + referenceId,"").Resource;
                if (Detalle_Codigos_de_Referencia_VendedoresData == null || Detalle_Codigos_de_Referencia_VendedoresData.Detalle_Codigos_de_Referencia_Vendedoress.Count == 0)
                    return true;

                var result = true;

                Detalle_Codigos_de_Referencia_VendedoresGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Codigos_de_Referencia_Vendedores in Detalle_Codigos_de_Referencia_VendedoresData.Detalle_Codigos_de_Referencia_Vendedoress)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Codigos_de_Referencia_Vendedores Detalle_Codigos_de_Referencia_Vendedores1 = varDetalle_Codigos_de_Referencia_Vendedores;

                    if (Detalle_Codigos_de_Referencia_VendedoresItems != null && Detalle_Codigos_de_Referencia_VendedoresItems.Any(m => m.Folio == Detalle_Codigos_de_Referencia_Vendedores1.Folio))
                    {
                        modelDataToChange = Detalle_Codigos_de_Referencia_VendedoresItems.FirstOrDefault(m => m.Folio == Detalle_Codigos_de_Referencia_Vendedores1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Codigos_de_Referencia_Vendedores.FolioVendedores = MasterId;
                    var insertId = _IDetalle_Codigos_de_Referencia_VendedoresApiConsumer.Insert(varDetalle_Codigos_de_Referencia_Vendedores,null,null).Resource;
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
        public ActionResult PostDetalle_Codigos_de_Referencia_Vendedores(List<Detalle_Codigos_de_Referencia_VendedoresGridModelPost> Detalle_Codigos_de_Referencia_VendedoresItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Codigos_de_Referencia_Vendedores(MasterId, referenceId, Detalle_Codigos_de_Referencia_VendedoresItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Codigos_de_Referencia_VendedoresItems != null && Detalle_Codigos_de_Referencia_VendedoresItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Codigos_de_Referencia_VendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Codigos_de_Referencia_VendedoresItem in Detalle_Codigos_de_Referencia_VendedoresItems)
                    {












                        //Removal Request
                        if (Detalle_Codigos_de_Referencia_VendedoresItem.Removed)
                        {
                            result = result && _IDetalle_Codigos_de_Referencia_VendedoresApiConsumer.Delete(Detalle_Codigos_de_Referencia_VendedoresItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Codigos_de_Referencia_VendedoresItem.Folio = 0;

                        var Detalle_Codigos_de_Referencia_VendedoresData = new Detalle_Codigos_de_Referencia_Vendedores
                        {
                            FolioVendedores = MasterId
                            ,Folio = Detalle_Codigos_de_Referencia_VendedoresItem.Folio
                            ,Porcentaje_de_descuento = Detalle_Codigos_de_Referencia_VendedoresItem.Porcentaje_de_descuento
                            ,Fecha_inicio_vigencia = (Detalle_Codigos_de_Referencia_VendedoresItem.Fecha_inicio_vigencia!= null) ? DateTime.ParseExact(Detalle_Codigos_de_Referencia_VendedoresItem.Fecha_inicio_vigencia, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Fecha_fin_vigencia = (Detalle_Codigos_de_Referencia_VendedoresItem.Fecha_fin_vigencia!= null) ? DateTime.ParseExact(Detalle_Codigos_de_Referencia_VendedoresItem.Fecha_fin_vigencia, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Cantidad_maxima_de_referenciados = Detalle_Codigos_de_Referencia_VendedoresItem.Cantidad_maxima_de_referenciados
                            ,Codigo_para_referenciados = Detalle_Codigos_de_Referencia_VendedoresItem.Codigo_para_referenciados
                            ,Autorizado = Detalle_Codigos_de_Referencia_VendedoresItem.Autorizado
                            ,Usuario_que_autoriza = (Convert.ToInt32(Detalle_Codigos_de_Referencia_VendedoresItem.Usuario_que_autoriza) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Codigos_de_Referencia_VendedoresItem.Usuario_que_autoriza))
                            ,Fecha_de_autorizacion = (Detalle_Codigos_de_Referencia_VendedoresItem.Fecha_de_autorizacion!= null) ? DateTime.ParseExact(Detalle_Codigos_de_Referencia_VendedoresItem.Fecha_de_autorizacion, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Hora_de_autorizacion = Detalle_Codigos_de_Referencia_VendedoresItem.Hora_de_autorizacion
                            ,Estatus = (Convert.ToInt32(Detalle_Codigos_de_Referencia_VendedoresItem.Estatus) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Codigos_de_Referencia_VendedoresItem.Estatus))

                        };

                        var resultId = Detalle_Codigos_de_Referencia_VendedoresItem.Folio > 0
                           ? _IDetalle_Codigos_de_Referencia_VendedoresApiConsumer.Update(Detalle_Codigos_de_Referencia_VendedoresData,null,null).Resource
                           : _IDetalle_Codigos_de_Referencia_VendedoresApiConsumer.Insert(Detalle_Codigos_de_Referencia_VendedoresData,null,null).Resource;

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
        public ActionResult GetDetalle_Codigos_de_Referencia_Vendedores_Spartan_UserAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_UserApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Id_User), "Spartan_User", "Name");
                  item.Name= trans??item.Name;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult GetDetalle_Codigos_de_Referencia_Vendedores_EstatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatusApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Estatus", "Descripcion");
                  item.Descripcion= trans??item.Descripcion;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopyDetalle_Facturacion_Vendedores(int MasterId, int referenceId, List<Detalle_Facturacion_VendedoresGridModelPost> Detalle_Facturacion_VendedoresItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Facturacion_VendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Facturacion_VendedoresData = _IDetalle_Facturacion_VendedoresApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Facturacion_Vendedores.FolioVendedores=" + referenceId,"").Resource;
                if (Detalle_Facturacion_VendedoresData == null || Detalle_Facturacion_VendedoresData.Detalle_Facturacion_Vendedoress.Count == 0)
                    return true;

                var result = true;

                Detalle_Facturacion_VendedoresGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Facturacion_Vendedores in Detalle_Facturacion_VendedoresData.Detalle_Facturacion_Vendedoress)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Facturacion_Vendedores Detalle_Facturacion_Vendedores1 = varDetalle_Facturacion_Vendedores;

                    if (Detalle_Facturacion_VendedoresItems != null && Detalle_Facturacion_VendedoresItems.Any(m => m.Folio == Detalle_Facturacion_Vendedores1.Folio))
                    {
                        modelDataToChange = Detalle_Facturacion_VendedoresItems.FirstOrDefault(m => m.Folio == Detalle_Facturacion_Vendedores1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Facturacion_Vendedores.FolioVendedores = MasterId;
                    var insertId = _IDetalle_Facturacion_VendedoresApiConsumer.Insert(varDetalle_Facturacion_Vendedores,null,null).Resource;
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
        public ActionResult PostDetalle_Facturacion_Vendedores(List<Detalle_Facturacion_VendedoresGridModelPost> Detalle_Facturacion_VendedoresItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Facturacion_Vendedores(MasterId, referenceId, Detalle_Facturacion_VendedoresItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Facturacion_VendedoresItems != null && Detalle_Facturacion_VendedoresItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Facturacion_VendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Facturacion_VendedoresItem in Detalle_Facturacion_VendedoresItems)
                    {





                        #region Archivo_XMLInfo
                        //Checking if file exist if yes edit or add
                        if (Detalle_Facturacion_VendedoresItem.Archivo_XMLInfo.Control != null && !Detalle_Facturacion_VendedoresItem.Removed)
                        {
                            var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(Detalle_Facturacion_VendedoresItem.Archivo_XMLInfo.Control);
                            Detalle_Facturacion_VendedoresItem.Archivo_XMLInfo.FileId = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                            {
                                File = fileAsBytes,
                                Description = Detalle_Facturacion_VendedoresItem.Archivo_XMLInfo.Control.FileName,
                                File_Size = fileAsBytes.Length
                            }).Resource;
                        }
                        else if (!Detalle_Facturacion_VendedoresItem.Removed && Detalle_Facturacion_VendedoresItem.Archivo_XMLInfo.RemoveFile)
                        {
                            Detalle_Facturacion_VendedoresItem.Archivo_XMLInfo.FileId = 0;
                        }
                        #endregion Archivo_XMLInfo
                        #region Archivo_PDFInfo
                        //Checking if file exist if yes edit or add
                        if (Detalle_Facturacion_VendedoresItem.Archivo_PDFInfo.Control != null && !Detalle_Facturacion_VendedoresItem.Removed)
                        {
                            var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(Detalle_Facturacion_VendedoresItem.Archivo_PDFInfo.Control);
                            Detalle_Facturacion_VendedoresItem.Archivo_PDFInfo.FileId = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                            {
                                File = fileAsBytes,
                                Description = Detalle_Facturacion_VendedoresItem.Archivo_PDFInfo.Control.FileName,
                                File_Size = fileAsBytes.Length
                            }).Resource;
                        }
                        else if (!Detalle_Facturacion_VendedoresItem.Removed && Detalle_Facturacion_VendedoresItem.Archivo_PDFInfo.RemoveFile)
                        {
                            Detalle_Facturacion_VendedoresItem.Archivo_PDFInfo.FileId = 0;
                        }
                        #endregion Archivo_PDFInfo





                        //Removal Request
                        if (Detalle_Facturacion_VendedoresItem.Removed)
                        {
                            result = result && _IDetalle_Facturacion_VendedoresApiConsumer.Delete(Detalle_Facturacion_VendedoresItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Facturacion_VendedoresItem.Folio = 0;

                        var Detalle_Facturacion_VendedoresData = new Detalle_Facturacion_Vendedores
                        {
                            FolioVendedores = MasterId
                            ,Folio = Detalle_Facturacion_VendedoresItem.Folio
                            ,Fecha_de_Registro = (Detalle_Facturacion_VendedoresItem.Fecha_de_Registro!= null) ? DateTime.ParseExact(Detalle_Facturacion_VendedoresItem.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Folio_Factura = Detalle_Facturacion_VendedoresItem.Folio_Factura
                            ,Periodo_Facturado = Detalle_Facturacion_VendedoresItem.Periodo_Facturado
                            ,Cantidad = Detalle_Facturacion_VendedoresItem.Cantidad
                            ,Archivo_XML = Detalle_Facturacion_VendedoresItem.Archivo_XMLInfo.FileId
                            ,Archivo_PDF = Detalle_Facturacion_VendedoresItem.Archivo_PDFInfo.FileId
                            ,Estatus = (Convert.ToInt32(Detalle_Facturacion_VendedoresItem.Estatus) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Facturacion_VendedoresItem.Estatus))
                            ,Fecha_programada_de_Pago = (Detalle_Facturacion_VendedoresItem.Fecha_programada_de_Pago!= null) ? DateTime.ParseExact(Detalle_Facturacion_VendedoresItem.Fecha_programada_de_Pago, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Pagada = Detalle_Facturacion_VendedoresItem.Pagada
                            ,Fecha_de_Pago = (Detalle_Facturacion_VendedoresItem.Fecha_de_Pago!= null) ? DateTime.ParseExact(Detalle_Facturacion_VendedoresItem.Fecha_de_Pago, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null

                        };

                        var resultId = Detalle_Facturacion_VendedoresItem.Folio > 0
                           ? _IDetalle_Facturacion_VendedoresApiConsumer.Update(Detalle_Facturacion_VendedoresData,null,null).Resource
                           : _IDetalle_Facturacion_VendedoresApiConsumer.Insert(Detalle_Facturacion_VendedoresData,null,null).Resource;

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
        public ActionResult GetDetalle_Facturacion_Vendedores_Estatus_FacturasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_FacturasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_FacturasApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Estatus_Facturas", "Descripcion");
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
        /// Write Element Array of Vendedores script
        /// </summary>
        /// <param name="oVendedoresElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew VendedoresModuleAttributeList)
        {
            for (int i = 0; i < VendedoresModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(VendedoresModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    VendedoresModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(VendedoresModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    VendedoresModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (VendedoresModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < VendedoresModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < VendedoresModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(VendedoresModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							VendedoresModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(VendedoresModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							VendedoresModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strVendedoresScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Vendedores.js")))
            {
                strVendedoresScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Vendedores element attributes
            string userChangeJson = jsSerialize.Serialize(VendedoresModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strVendedoresScript.IndexOf("inpuElementArray");
            string splittedString = strVendedoresScript.Substring(indexOfArray, strVendedoresScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(VendedoresModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (VendedoresModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strVendedoresScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strVendedoresScript.Substring(indexOfArrayHistory, strVendedoresScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strVendedoresScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strVendedoresScript.Substring(endIndexOfMainElement + indexOfArray, strVendedoresScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (VendedoresModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in VendedoresModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Vendedores.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Vendedores.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Vendedores.js")))
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
        public ActionResult VendedoresPropertyBag()
        {
            return PartialView("VendedoresPropertyBag", "Vendedores");
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
        public ActionResult AddDetalle_Codigos_de_Referencia_Vendedores(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Codigos_de_Referencia_Vendedores/AddDetalle_Codigos_de_Referencia_Vendedores");
        }

        [HttpGet]
        public ActionResult AddDetalle_Facturacion_Vendedores(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Facturacion_Vendedores/AddDetalle_Facturacion_Vendedores");
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
                var whereClauseFormat = "Object = 44586 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IVendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Vendedores.Folio= " + RecordId;
                            var result = _IVendedoresApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IVendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new VendedoresPropertyMapper());
			
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
                    (VendedoresAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            VendedoresPropertyMapper oVendedoresPropertyMapper = new VendedoresPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oVendedoresPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IVendedoresApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Vendedoress == null)
                result.Vendedoress = new List<Vendedores>();

            var data = result.Vendedoress.Select(m => new VendedoresGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
			,Nombre_de_Usuario = m.Nombre_de_Usuario
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Email = m.Email
			,Celular = m.Celular
                        ,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Entidad_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
                        ,BancoNombre = CultureHelper.GetTraduction(m.Banco_Bancos.Clave.ToString(), "Nombre") ?? (string)m.Banco_Bancos.Nombre
			,CLABE_Interbancaria = m.CLABE_Interbancaria
			,Numero_de_Cuenta = m.Numero_de_Cuenta
			,Nombre_del_Titular = m.Nombre_del_Titular

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44586, arrayColumnsVisible), "VendedoresList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44586, arrayColumnsVisible), "VendedoresList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44586, arrayColumnsVisible), "VendedoresList_" + DateTime.Now.ToString());
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

            _IVendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new VendedoresPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (VendedoresAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            VendedoresPropertyMapper oVendedoresPropertyMapper = new VendedoresPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oVendedoresPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IVendedoresApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Vendedoress == null)
                result.Vendedoress = new List<Vendedores>();

            var data = result.Vendedoress.Select(m => new VendedoresGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
			,Nombre_de_Usuario = m.Nombre_de_Usuario
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Email = m.Email
			,Celular = m.Celular
                        ,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Entidad_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
                        ,BancoNombre = CultureHelper.GetTraduction(m.Banco_Bancos.Clave.ToString(), "Nombre") ?? (string)m.Banco_Bancos.Nombre
			,CLABE_Interbancaria = m.CLABE_Interbancaria
			,Numero_de_Cuenta = m.Numero_de_Cuenta
			,Nombre_del_Titular = m.Nombre_del_Titular

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
                _IVendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IVendedoresApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Vendedores_Datos_GeneralesModel varVendedores)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IVendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Vendedores_Datos_GeneralesInfo = new Vendedores_Datos_Generales
                {
                    Folio = varVendedores.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varVendedores.Fecha_de_Registro)) ? DateTime.ParseExact(varVendedores.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varVendedores.Hora_de_Registro
                        ,Usuario_que_Registra = varVendedores.Usuario_que_Registra
                        ,Nombres = varVendedores.Nombres
                        ,Apellido_Paterno = varVendedores.Apellido_Paterno
                        ,Apellido_Materno = varVendedores.Apellido_Materno
                        ,Nombre_Completo = varVendedores.Nombre_Completo
                        ,Nombre_de_Usuario = varVendedores.Nombre_de_Usuario
                        ,Usuario_Registrado = varVendedores.Usuario_Registrado
                        ,Email = varVendedores.Email
                        ,Celular = varVendedores.Celular
                        ,Fecha_de_nacimiento = (!String.IsNullOrEmpty(varVendedores.Fecha_de_nacimiento)) ? DateTime.ParseExact(varVendedores.Fecha_de_nacimiento, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Pais_de_nacimiento = varVendedores.Pais_de_nacimiento
                        ,Entidad_de_nacimiento = varVendedores.Entidad_de_nacimiento
                        ,Sexo = varVendedores.Sexo
                        ,Estatus = varVendedores.Estatus
                    
                };

                result = _IVendedoresApiConsumer.Update_Datos_Generales(Vendedores_Datos_GeneralesInfo).Resource.ToString();
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
                _IVendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IVendedoresApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Codigos_de_Referencia_Vendedores;
                var Detalle_Codigos_de_Referencia_VendedoresData = GetDetalle_Codigos_de_Referencia_VendedoresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Codigos_de_Referencia_Vendedores);
                int RowCount_Detalle_Facturacion_Vendedores;
                var Detalle_Facturacion_VendedoresData = GetDetalle_Facturacion_VendedoresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Facturacion_Vendedores);

                var result = new Vendedores_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
			,Nombre_de_Usuario = m.Nombre_de_Usuario
                        ,Usuario_Registrado = m.Usuario_Registrado
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Email = m.Email
			,Celular = m.Celular
                        ,Fecha_de_nacimiento = (m.Fecha_de_nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_nacimiento).ToString(ConfigurationProperty.DateFormat))
                        ,Pais_de_nacimiento = m.Pais_de_nacimiento
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Entidad_de_nacimiento = m.Entidad_de_nacimiento
                        ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Entidad_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                        ,Sexo = m.Sexo
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                    
                };
				var resultData = new
                {
                    data = result
                    ,Codigos_para_Referenciar_Pacientes = Detalle_Codigos_de_Referencia_VendedoresData
                    ,Facturas = Detalle_Facturacion_VendedoresData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Codigos_de_Referencia(Vendedores_Codigos_de_ReferenciaModel varVendedores)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IVendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Vendedores_Codigos_de_ReferenciaInfo = new Vendedores_Codigos_de_Referencia
                {
                    Folio = varVendedores.Folio
                                        
                };

                result = _IVendedoresApiConsumer.Update_Codigos_de_Referencia(Vendedores_Codigos_de_ReferenciaInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Codigos_de_Referencia(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IVendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IVendedoresApiConsumer.Get_Codigos_de_Referencia(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Codigos_de_Referencia_Vendedores;
                var Detalle_Codigos_de_Referencia_VendedoresData = GetDetalle_Codigos_de_Referencia_VendedoresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Codigos_de_Referencia_Vendedores);
                int RowCount_Detalle_Facturacion_Vendedores;
                var Detalle_Facturacion_VendedoresData = GetDetalle_Facturacion_VendedoresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Facturacion_Vendedores);

                var result = new Vendedores_Codigos_de_ReferenciaModel
                {
                    Folio = m.Folio

                    
                };
				var resultData = new
                {
                    data = result
                    ,Codigos_para_Referenciar_Pacientes = Detalle_Codigos_de_Referencia_VendedoresData
                    ,Facturas = Detalle_Facturacion_VendedoresData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Datos_Bancarios(Vendedores_Datos_BancariosModel varVendedores)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IVendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Vendedores_Datos_BancariosInfo = new Vendedores_Datos_Bancarios
                {
                    Folio = varVendedores.Folio
                                            ,Banco = varVendedores.Banco
                        ,CLABE_Interbancaria = varVendedores.CLABE_Interbancaria
                        ,Numero_de_Cuenta = varVendedores.Numero_de_Cuenta
                        ,Nombre_del_Titular = varVendedores.Nombre_del_Titular
                    
                };

                result = _IVendedoresApiConsumer.Update_Datos_Bancarios(Vendedores_Datos_BancariosInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Datos_Bancarios(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IVendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IVendedoresApiConsumer.Get_Datos_Bancarios(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Codigos_de_Referencia_Vendedores;
                var Detalle_Codigos_de_Referencia_VendedoresData = GetDetalle_Codigos_de_Referencia_VendedoresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Codigos_de_Referencia_Vendedores);
                int RowCount_Detalle_Facturacion_Vendedores;
                var Detalle_Facturacion_VendedoresData = GetDetalle_Facturacion_VendedoresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Facturacion_Vendedores);

                var result = new Vendedores_Datos_BancariosModel
                {
                    Folio = m.Folio
                        ,Banco = m.Banco
                        ,BancoNombre = CultureHelper.GetTraduction(m.Banco_Bancos.Clave.ToString(), "Nombre") ?? (string)m.Banco_Bancos.Nombre
			,CLABE_Interbancaria = m.CLABE_Interbancaria
			,Numero_de_Cuenta = m.Numero_de_Cuenta
			,Nombre_del_Titular = m.Nombre_del_Titular

                    
                };
				var resultData = new
                {
                    data = result
                    ,Codigos_para_Referenciar_Pacientes = Detalle_Codigos_de_Referencia_VendedoresData
                    ,Facturas = Detalle_Facturacion_VendedoresData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Facturacion(Vendedores_FacturacionModel varVendedores)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IVendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Vendedores_FacturacionInfo = new Vendedores_Facturacion
                {
                    Folio = varVendedores.Folio
                                        
                };

                result = _IVendedoresApiConsumer.Update_Facturacion(Vendedores_FacturacionInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Facturacion(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IVendedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IVendedoresApiConsumer.Get_Facturacion(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Codigos_de_Referencia_Vendedores;
                var Detalle_Codigos_de_Referencia_VendedoresData = GetDetalle_Codigos_de_Referencia_VendedoresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Codigos_de_Referencia_Vendedores);
                int RowCount_Detalle_Facturacion_Vendedores;
                var Detalle_Facturacion_VendedoresData = GetDetalle_Facturacion_VendedoresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Facturacion_Vendedores);

                var result = new Vendedores_FacturacionModel
                {
                    Folio = m.Folio

                    
                };
				var resultData = new
                {
                    data = result
                    ,Codigos_para_Referenciar_Pacientes = Detalle_Codigos_de_Referencia_VendedoresData
                    ,Facturas = Detalle_Facturacion_VendedoresData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

