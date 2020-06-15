using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Proveedores;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Tipo_de_proveedor;
using Spartane.Core.Domain.Detalle_Sucursales_Proveedores;

using Spartane.Core.Domain.Tipo_de_Sucursal;











using Spartane.Core.Domain.Estatus;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Pais;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Sexo;
using Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores;

using Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores;





using Spartane.Core.Domain.Estatus_de_Suscripcion;

using Spartane.Core.Domain.Regimenes_Fiscales;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Pais;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Proveedores;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Proveedores;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_proveedor;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Sucursales_Proveedores;

using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Sucursal;

using Spartane.Web.Areas.WebApiConsumer.Estatus;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Pais;
using Spartane.Web.Areas.WebApiConsumer.Estado;
using Spartane.Web.Areas.WebApiConsumer.Sexo;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Suscripcion_Red_de_Especialistas_Proveedores;

using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion_Proveedores;





using Spartane.Web.Areas.WebApiConsumer.Estatus_de_Suscripcion;

using Spartane.Web.Areas.WebApiConsumer.Regimenes_Fiscales;
using Spartane.Web.Areas.WebApiConsumer.Estado;
using Spartane.Web.Areas.WebApiConsumer.Pais;

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
    public class ProveedoresController : Controller
    {
        #region "variable declaration"

        private IProveedoresService service = null;
        private IProveedoresApiConsumer _IProveedoresApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private ITipo_de_proveedorApiConsumer _ITipo_de_proveedorApiConsumer;
        private IDetalle_Sucursales_ProveedoresApiConsumer _IDetalle_Sucursales_ProveedoresApiConsumer;

        private ITipo_de_SucursalApiConsumer _ITipo_de_SucursalApiConsumer;

        private IEstatusApiConsumer _IEstatusApiConsumer;
        private IPaisApiConsumer _IPaisApiConsumer;
        private IEstadoApiConsumer _IEstadoApiConsumer;
        private ISexoApiConsumer _ISexoApiConsumer;
        private IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer;

        private IPlanes_de_Suscripcion_ProveedoresApiConsumer _IPlanes_de_Suscripcion_ProveedoresApiConsumer;





        private IEstatus_de_SuscripcionApiConsumer _IEstatus_de_SuscripcionApiConsumer;

        private IRegimenes_FiscalesApiConsumer _IRegimenes_FiscalesApiConsumer;

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

        
        public ProveedoresController(IProveedoresService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IProveedoresApiConsumer ProveedoresApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , ITipo_de_proveedorApiConsumer Tipo_de_proveedorApiConsumer , IDetalle_Sucursales_ProveedoresApiConsumer Detalle_Sucursales_ProveedoresApiConsumer , ITipo_de_SucursalApiConsumer Tipo_de_SucursalApiConsumer  , IEstatusApiConsumer EstatusApiConsumer , IPaisApiConsumer PaisApiConsumer , IEstadoApiConsumer EstadoApiConsumer , ISexoApiConsumer SexoApiConsumer , IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer Detalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer , IPlanes_de_Suscripcion_ProveedoresApiConsumer Planes_de_Suscripcion_ProveedoresApiConsumer , IEstatus_de_SuscripcionApiConsumer Estatus_de_SuscripcionApiConsumer  , IRegimenes_FiscalesApiConsumer Regimenes_FiscalesApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IProveedoresApiConsumer = ProveedoresApiConsumer;
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
            this._ITipo_de_proveedorApiConsumer = Tipo_de_proveedorApiConsumer;
            this._IDetalle_Sucursales_ProveedoresApiConsumer = Detalle_Sucursales_ProveedoresApiConsumer;

            this._ITipo_de_SucursalApiConsumer = Tipo_de_SucursalApiConsumer;

            this._IEstatusApiConsumer = EstatusApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._IPaisApiConsumer = PaisApiConsumer;
            this._IEstadoApiConsumer = EstadoApiConsumer;
            this._ISexoApiConsumer = SexoApiConsumer;
            this._IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer;

            this._IPlanes_de_Suscripcion_ProveedoresApiConsumer = Planes_de_Suscripcion_ProveedoresApiConsumer;





            this._IEstatus_de_SuscripcionApiConsumer = Estatus_de_SuscripcionApiConsumer;

            this._IRegimenes_FiscalesApiConsumer = Regimenes_FiscalesApiConsumer;
            this._IEstadoApiConsumer = EstadoApiConsumer;
            this._IPaisApiConsumer = PaisApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Proveedores
        [ObjectAuth(ObjectId = (ModuleObjectId)44591, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44591, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Proveedores/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44591, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44591, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varProveedores = new ProveedoresModel();
			varProveedores.Folio = Id;
			
            ViewBag.ObjectId = "44591";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionDetalle_Sucursales_Proveedores = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44593, ModuleId);
            ViewBag.PermissionDetalle_Sucursales_Proveedores = permissionDetalle_Sucursales_Proveedores;
            var permissionDetalle_Suscripcion_Red_de_Especialistas_Proveedores = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44595, ModuleId);
            ViewBag.PermissionDetalle_Suscripcion_Red_de_Especialistas_Proveedores = permissionDetalle_Suscripcion_Red_de_Especialistas_Proveedores;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var ProveedoressData = _IProveedoresApiConsumer.ListaSelAll(0, 1000, "Proveedores.Folio=" + Id, "").Resource.Proveedoress;
				
				if (ProveedoressData != null && ProveedoressData.Count > 0)
                {
					var ProveedoresData = ProveedoressData.First();
					varProveedores= new ProveedoresModel
					{
						Folio  = ProveedoresData.Folio 
	                    ,Fecha_de_Registro = (ProveedoresData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(ProveedoresData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = ProveedoresData.Hora_de_Registro
                    ,Usuario_que_Registra = ProveedoresData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Usuario_que_Registra), "Spartan_User") ??  (string)ProveedoresData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre_del_Proveedor = ProveedoresData.Nombre_del_Proveedor
                    ,Tipo_de_Proveedor = ProveedoresData.Tipo_de_Proveedor
                    ,Tipo_de_ProveedorDescripcion = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Tipo_de_Proveedor), "Tipo_de_proveedor") ??  (string)ProveedoresData.Tipo_de_Proveedor_Tipo_de_proveedor.Descripcion
                    ,Estatus = ProveedoresData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Estatus), "Estatus") ??  (string)ProveedoresData.Estatus_Estatus.Descripcion
                    ,Nombres = ProveedoresData.Nombres
                    ,Apellido_Paterno = ProveedoresData.Apellido_Paterno
                    ,Apellido_Materno = ProveedoresData.Apellido_Materno
                    ,Nombre_Completo = ProveedoresData.Nombre_Completo
                    ,Nombre_de_Usuario = ProveedoresData.Nombre_de_Usuario
                    ,Usuario_Registrado = ProveedoresData.Usuario_Registrado
                    ,Usuario_RegistradoName = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Usuario_Registrado), "Spartan_User") ??  (string)ProveedoresData.Usuario_Registrado_Spartan_User.Name
                    ,Email = ProveedoresData.Email
                    ,Celular = ProveedoresData.Celular
                    ,Fecha_de_Nacimiento = (ProveedoresData.Fecha_de_Nacimiento == null ? string.Empty : Convert.ToDateTime(ProveedoresData.Fecha_de_Nacimiento).ToString(ConfigurationProperty.DateFormat))
                    ,Pais_de_nacimiento = ProveedoresData.Pais_de_nacimiento
                    ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Pais_de_nacimiento), "Pais") ??  (string)ProveedoresData.Pais_de_nacimiento_Pais.Nombre_del_Pais
                    ,Entidad_de_nacimiento = ProveedoresData.Entidad_de_nacimiento
                    ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Entidad_de_nacimiento), "Estado") ??  (string)ProveedoresData.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                    ,Sexo = ProveedoresData.Sexo
                    ,SexoDescripcion = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Sexo), "Sexo") ??  (string)ProveedoresData.Sexo_Sexo.Descripcion
                    ,Regimen_Fiscal = ProveedoresData.Regimen_Fiscal
                    ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Regimen_Fiscal), "Regimenes_Fiscales") ??  (string)ProveedoresData.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
                    ,Nombre_o_Razon_Social = ProveedoresData.Nombre_o_Razon_Social
                    ,RFC = ProveedoresData.RFC
                    ,Calle_Fiscal = ProveedoresData.Calle_Fiscal
                    ,Numero_exterior_Fiscal = ProveedoresData.Numero_exterior_Fiscal
                    ,Numero_interior_Fiscal = ProveedoresData.Numero_interior_Fiscal
                    ,Colonia_Fiscal = ProveedoresData.Colonia_Fiscal
                    ,C_P__Fiscal = ProveedoresData.C_P__Fiscal
                    ,Ciudad_Fiscal = ProveedoresData.Ciudad_Fiscal
                    ,Estado_Fiscal = ProveedoresData.Estado_Fiscal
                    ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Estado_Fiscal), "Estado") ??  (string)ProveedoresData.Estado_Fiscal_Estado.Nombre_del_Estado
                    ,Pais_Fiscal = ProveedoresData.Pais_Fiscal
                    ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Pais_Fiscal), "Pais") ??  (string)ProveedoresData.Pais_Fiscal_Pais.Nombre_del_Pais
                    ,Telefono = ProveedoresData.Telefono
                    ,Fax = ProveedoresData.Fax

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
            _ITipo_de_proveedorApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_proveedors_Tipo_de_Proveedor = _ITipo_de_proveedorApiConsumer.SelAll(true);
            if (Tipo_de_proveedors_Tipo_de_Proveedor != null && Tipo_de_proveedors_Tipo_de_Proveedor.Resource != null)
                ViewBag.Tipo_de_proveedors_Tipo_de_Proveedor = Tipo_de_proveedors_Tipo_de_Proveedor.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_proveedor", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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
            _IRegimenes_FiscalesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Regimenes_Fiscaless_Regimen_Fiscal = _IRegimenes_FiscalesApiConsumer.SelAll(true);
            if (Regimenes_Fiscaless_Regimen_Fiscal != null && Regimenes_Fiscaless_Regimen_Fiscal.Resource != null)
                ViewBag.Regimenes_Fiscaless_Regimen_Fiscal = Regimenes_Fiscaless_Regimen_Fiscal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Regimenes_Fiscales", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado_Fiscal = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado_Fiscal != null && Estados_Estado_Fiscal.Resource != null)
                ViewBag.Estados_Estado_Fiscal = Estados_Estado_Fiscal.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_Fiscal = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_Fiscal != null && Paiss_Pais_Fiscal.Resource != null)
                ViewBag.Paiss_Pais_Fiscal = Paiss_Pais_Fiscal.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
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

				
            return View(varProveedores);
        }
		
	[HttpGet]
        public ActionResult AddProveedores(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44591);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
			ProveedoresModel varProveedores= new ProveedoresModel();
            var permissionDetalle_Sucursales_Proveedores = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44593, ModuleId);
            ViewBag.PermissionDetalle_Sucursales_Proveedores = permissionDetalle_Sucursales_Proveedores;
            var permissionDetalle_Suscripcion_Red_de_Especialistas_Proveedores = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44595, ModuleId);
            ViewBag.PermissionDetalle_Suscripcion_Red_de_Especialistas_Proveedores = permissionDetalle_Suscripcion_Red_de_Especialistas_Proveedores;


            if (id.ToString() != "0")
            {
                var ProveedoressData = _IProveedoresApiConsumer.ListaSelAll(0, 1000, "Proveedores.Folio=" + id, "").Resource.Proveedoress;
				
				if (ProveedoressData != null && ProveedoressData.Count > 0)
                {
					var ProveedoresData = ProveedoressData.First();
					varProveedores= new ProveedoresModel
					{
						Folio  = ProveedoresData.Folio 
	                    ,Fecha_de_Registro = (ProveedoresData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(ProveedoresData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = ProveedoresData.Hora_de_Registro
                    ,Usuario_que_Registra = ProveedoresData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Usuario_que_Registra), "Spartan_User") ??  (string)ProveedoresData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre_del_Proveedor = ProveedoresData.Nombre_del_Proveedor
                    ,Tipo_de_Proveedor = ProveedoresData.Tipo_de_Proveedor
                    ,Tipo_de_ProveedorDescripcion = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Tipo_de_Proveedor), "Tipo_de_proveedor") ??  (string)ProveedoresData.Tipo_de_Proveedor_Tipo_de_proveedor.Descripcion
                    ,Estatus = ProveedoresData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Estatus), "Estatus") ??  (string)ProveedoresData.Estatus_Estatus.Descripcion
                    ,Nombres = ProveedoresData.Nombres
                    ,Apellido_Paterno = ProveedoresData.Apellido_Paterno
                    ,Apellido_Materno = ProveedoresData.Apellido_Materno
                    ,Nombre_Completo = ProveedoresData.Nombre_Completo
                    ,Nombre_de_Usuario = ProveedoresData.Nombre_de_Usuario
                    ,Usuario_Registrado = ProveedoresData.Usuario_Registrado
                    ,Usuario_RegistradoName = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Usuario_Registrado), "Spartan_User") ??  (string)ProveedoresData.Usuario_Registrado_Spartan_User.Name
                    ,Email = ProveedoresData.Email
                    ,Celular = ProveedoresData.Celular
                    ,Fecha_de_Nacimiento = (ProveedoresData.Fecha_de_Nacimiento == null ? string.Empty : Convert.ToDateTime(ProveedoresData.Fecha_de_Nacimiento).ToString(ConfigurationProperty.DateFormat))
                    ,Pais_de_nacimiento = ProveedoresData.Pais_de_nacimiento
                    ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Pais_de_nacimiento), "Pais") ??  (string)ProveedoresData.Pais_de_nacimiento_Pais.Nombre_del_Pais
                    ,Entidad_de_nacimiento = ProveedoresData.Entidad_de_nacimiento
                    ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Entidad_de_nacimiento), "Estado") ??  (string)ProveedoresData.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                    ,Sexo = ProveedoresData.Sexo
                    ,SexoDescripcion = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Sexo), "Sexo") ??  (string)ProveedoresData.Sexo_Sexo.Descripcion
                    ,Regimen_Fiscal = ProveedoresData.Regimen_Fiscal
                    ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Regimen_Fiscal), "Regimenes_Fiscales") ??  (string)ProveedoresData.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
                    ,Nombre_o_Razon_Social = ProveedoresData.Nombre_o_Razon_Social
                    ,RFC = ProveedoresData.RFC
                    ,Calle_Fiscal = ProveedoresData.Calle_Fiscal
                    ,Numero_exterior_Fiscal = ProveedoresData.Numero_exterior_Fiscal
                    ,Numero_interior_Fiscal = ProveedoresData.Numero_interior_Fiscal
                    ,Colonia_Fiscal = ProveedoresData.Colonia_Fiscal
                    ,C_P__Fiscal = ProveedoresData.C_P__Fiscal
                    ,Ciudad_Fiscal = ProveedoresData.Ciudad_Fiscal
                    ,Estado_Fiscal = ProveedoresData.Estado_Fiscal
                    ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Estado_Fiscal), "Estado") ??  (string)ProveedoresData.Estado_Fiscal_Estado.Nombre_del_Estado
                    ,Pais_Fiscal = ProveedoresData.Pais_Fiscal
                    ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(ProveedoresData.Pais_Fiscal), "Pais") ??  (string)ProveedoresData.Pais_Fiscal_Pais.Nombre_del_Pais
                    ,Telefono = ProveedoresData.Telefono
                    ,Fax = ProveedoresData.Fax

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
            _ITipo_de_proveedorApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_proveedors_Tipo_de_Proveedor = _ITipo_de_proveedorApiConsumer.SelAll(true);
            if (Tipo_de_proveedors_Tipo_de_Proveedor != null && Tipo_de_proveedors_Tipo_de_Proveedor.Resource != null)
                ViewBag.Tipo_de_proveedors_Tipo_de_Proveedor = Tipo_de_proveedors_Tipo_de_Proveedor.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_proveedor", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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
            _IRegimenes_FiscalesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Regimenes_Fiscaless_Regimen_Fiscal = _IRegimenes_FiscalesApiConsumer.SelAll(true);
            if (Regimenes_Fiscaless_Regimen_Fiscal != null && Regimenes_Fiscaless_Regimen_Fiscal.Resource != null)
                ViewBag.Regimenes_Fiscaless_Regimen_Fiscal = Regimenes_Fiscaless_Regimen_Fiscal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Regimenes_Fiscales", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado_Fiscal = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado_Fiscal != null && Estados_Estado_Fiscal.Resource != null)
                ViewBag.Estados_Estado_Fiscal = Estados_Estado_Fiscal.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_Fiscal = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_Fiscal != null && Paiss_Pais_Fiscal.Resource != null)
                ViewBag.Paiss_Pais_Fiscal = Paiss_Pais_Fiscal.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddProveedores", varProveedores);
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
        public ActionResult GetTipo_de_proveedorAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_proveedorApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_de_proveedorApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_proveedor", "Descripcion")?? m.Descripcion,
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
        public ActionResult GetRegimenes_FiscalesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRegimenes_FiscalesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRegimenes_FiscalesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Regimenes_Fiscales", "Descripcion")?? m.Descripcion,
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
        public ActionResult ShowAdvanceFilter(ProveedoresAdvanceSearchModel model, int idFilter = -1)
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
            _ITipo_de_proveedorApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_proveedors_Tipo_de_Proveedor = _ITipo_de_proveedorApiConsumer.SelAll(true);
            if (Tipo_de_proveedors_Tipo_de_Proveedor != null && Tipo_de_proveedors_Tipo_de_Proveedor.Resource != null)
                ViewBag.Tipo_de_proveedors_Tipo_de_Proveedor = Tipo_de_proveedors_Tipo_de_Proveedor.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_proveedor", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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
            _IRegimenes_FiscalesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Regimenes_Fiscaless_Regimen_Fiscal = _IRegimenes_FiscalesApiConsumer.SelAll(true);
            if (Regimenes_Fiscaless_Regimen_Fiscal != null && Regimenes_Fiscaless_Regimen_Fiscal.Resource != null)
                ViewBag.Regimenes_Fiscaless_Regimen_Fiscal = Regimenes_Fiscaless_Regimen_Fiscal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Regimenes_Fiscales", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado_Fiscal = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado_Fiscal != null && Estados_Estado_Fiscal.Resource != null)
                ViewBag.Estados_Estado_Fiscal = Estados_Estado_Fiscal.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_Fiscal = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_Fiscal != null && Paiss_Pais_Fiscal.Resource != null)
                ViewBag.Paiss_Pais_Fiscal = Paiss_Pais_Fiscal.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
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
            _ITipo_de_proveedorApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_proveedors_Tipo_de_Proveedor = _ITipo_de_proveedorApiConsumer.SelAll(true);
            if (Tipo_de_proveedors_Tipo_de_Proveedor != null && Tipo_de_proveedors_Tipo_de_Proveedor.Resource != null)
                ViewBag.Tipo_de_proveedors_Tipo_de_Proveedor = Tipo_de_proveedors_Tipo_de_Proveedor.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_proveedor", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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
            _IRegimenes_FiscalesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Regimenes_Fiscaless_Regimen_Fiscal = _IRegimenes_FiscalesApiConsumer.SelAll(true);
            if (Regimenes_Fiscaless_Regimen_Fiscal != null && Regimenes_Fiscaless_Regimen_Fiscal.Resource != null)
                ViewBag.Regimenes_Fiscaless_Regimen_Fiscal = Regimenes_Fiscaless_Regimen_Fiscal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Regimenes_Fiscales", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado_Fiscal = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado_Fiscal != null && Estados_Estado_Fiscal.Resource != null)
                ViewBag.Estados_Estado_Fiscal = Estados_Estado_Fiscal.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais_Fiscal = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais_Fiscal != null && Paiss_Pais_Fiscal.Resource != null)
                ViewBag.Paiss_Pais_Fiscal = Paiss_Pais_Fiscal.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            var previousFiltersObj = new ProveedoresAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (ProveedoresAdvanceSearchModel)(Session["AdvanceSearch"] ?? new ProveedoresAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new ProveedoresPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IProveedoresApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Proveedoress == null)
                result.Proveedoress = new List<Proveedores>();

            return Json(new
            {
                data = result.Proveedoress.Select(m => new ProveedoresGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_del_Proveedor = m.Nombre_del_Proveedor
                        ,Tipo_de_ProveedorDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Proveedor_Tipo_de_proveedor.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Proveedor_Tipo_de_proveedor.Descripcion
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
			,Nombre_de_Usuario = m.Nombre_de_Usuario
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Email = m.Email
			,Celular = m.Celular
                        ,Fecha_de_Nacimiento = (m.Fecha_de_Nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Nacimiento).ToString(ConfigurationProperty.DateFormat))
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Entidad_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
                        ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(m.Regimen_Fiscal_Regimenes_Fiscales.Clave.ToString(), "Descripcion") ?? (string)m.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
			,Nombre_o_Razon_Social = m.Nombre_o_Razon_Social
			,RFC = m.RFC
			,Calle_Fiscal = m.Calle_Fiscal
			,Numero_exterior_Fiscal = m.Numero_exterior_Fiscal
			,Numero_interior_Fiscal = m.Numero_interior_Fiscal
			,Colonia_Fiscal = m.Colonia_Fiscal
			,C_P__Fiscal = m.C_P__Fiscal
			,Ciudad_Fiscal = m.Ciudad_Fiscal
                        ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Fiscal_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Fiscal_Estado.Nombre_del_Estado
                        ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Fiscal_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Fiscal_Pais.Nombre_del_Pais
			,Telefono = m.Telefono
			,Fax = m.Fax

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetProveedoresAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IProveedoresApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Proveedores", m.),
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
        /// Get List of Proveedores from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Proveedores Entity</returns>
        public ActionResult GetProveedoresList(UrlParametersModel param)
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
            _IProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new ProveedoresPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(ProveedoresAdvanceSearchModel))
                {
					var advanceFilter =
                    (ProveedoresAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            ProveedoresPropertyMapper oProveedoresPropertyMapper = new ProveedoresPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oProveedoresPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IProveedoresApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Proveedoress == null)
                result.Proveedoress = new List<Proveedores>();

            return Json(new
            {
                aaData = result.Proveedoress.Select(m => new ProveedoresGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_del_Proveedor = m.Nombre_del_Proveedor
                        ,Tipo_de_ProveedorDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Proveedor_Tipo_de_proveedor.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Proveedor_Tipo_de_proveedor.Descripcion
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
			,Nombre_de_Usuario = m.Nombre_de_Usuario
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Email = m.Email
			,Celular = m.Celular
                        ,Fecha_de_Nacimiento = (m.Fecha_de_Nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Nacimiento).ToString(ConfigurationProperty.DateFormat))
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Entidad_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
                        ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(m.Regimen_Fiscal_Regimenes_Fiscales.Clave.ToString(), "Descripcion") ?? (string)m.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
			,Nombre_o_Razon_Social = m.Nombre_o_Razon_Social
			,RFC = m.RFC
			,Calle_Fiscal = m.Calle_Fiscal
			,Numero_exterior_Fiscal = m.Numero_exterior_Fiscal
			,Numero_interior_Fiscal = m.Numero_interior_Fiscal
			,Colonia_Fiscal = m.Colonia_Fiscal
			,C_P__Fiscal = m.C_P__Fiscal
			,Ciudad_Fiscal = m.Ciudad_Fiscal
                        ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Fiscal_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Fiscal_Estado.Nombre_del_Estado
                        ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Fiscal_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Fiscal_Pais.Nombre_del_Pais
			,Telefono = m.Telefono
			,Fax = m.Fax

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete
        [HttpGet]
        public JsonResult GetDetalle_Sucursales_Proveedores_Tipo_de_Sucursal_Tipo_de_Sucursal(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_SucursalApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Tipo_de_Sucursal.Clave as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Tipo_de_Sucursal.Descripcion as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _ITipo_de_SucursalApiConsumer.ListaSelAll(1, 20,elWhere , " Tipo_de_Sucursal.Descripcion ASC ").Resource;
               
                foreach (var item in result.Tipo_de_Sucursals)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Tipo_de_Sucursal", "Descripcion");
                    item.Descripcion =trans ??item.Descripcion;
                }
                return Json(result.Tipo_de_Sucursals.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(ProveedoresAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Proveedores.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Proveedores.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Proveedores.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Proveedores.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Proveedores.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Proveedores.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
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

                where += " AND Proveedores.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombre_del_Proveedor))
            {
                switch (filter.Nombre_del_ProveedorFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Proveedores.Nombre_del_Proveedor LIKE '" + filter.Nombre_del_Proveedor + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Proveedores.Nombre_del_Proveedor LIKE '%" + filter.Nombre_del_Proveedor + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Proveedores.Nombre_del_Proveedor = '" + filter.Nombre_del_Proveedor + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Proveedores.Nombre_del_Proveedor LIKE '%" + filter.Nombre_del_Proveedor + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTipo_de_Proveedor))
            {
                switch (filter.Tipo_de_ProveedorFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tipo_de_proveedor.Descripcion LIKE '" + filter.AdvanceTipo_de_Proveedor + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tipo_de_proveedor.Descripcion LIKE '%" + filter.AdvanceTipo_de_Proveedor + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tipo_de_proveedor.Descripcion = '" + filter.AdvanceTipo_de_Proveedor + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tipo_de_proveedor.Descripcion LIKE '%" + filter.AdvanceTipo_de_Proveedor + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTipo_de_ProveedorMultiple != null && filter.AdvanceTipo_de_ProveedorMultiple.Count() > 0)
            {
                var Tipo_de_ProveedorIds = string.Join(",", filter.AdvanceTipo_de_ProveedorMultiple);

                where += " AND Proveedores.Tipo_de_Proveedor In (" + Tipo_de_ProveedorIds + ")";
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

                where += " AND Proveedores.Estatus In (" + EstatusIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombres))
            {
                switch (filter.NombresFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Proveedores.Nombres LIKE '" + filter.Nombres + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Proveedores.Nombres LIKE '%" + filter.Nombres + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Proveedores.Nombres = '" + filter.Nombres + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Proveedores.Nombres LIKE '%" + filter.Nombres + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Apellido_Paterno))
            {
                switch (filter.Apellido_PaternoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Proveedores.Apellido_Paterno LIKE '" + filter.Apellido_Paterno + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Proveedores.Apellido_Paterno LIKE '%" + filter.Apellido_Paterno + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Proveedores.Apellido_Paterno = '" + filter.Apellido_Paterno + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Proveedores.Apellido_Paterno LIKE '%" + filter.Apellido_Paterno + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Apellido_Materno))
            {
                switch (filter.Apellido_MaternoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Proveedores.Apellido_Materno LIKE '" + filter.Apellido_Materno + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Proveedores.Apellido_Materno LIKE '%" + filter.Apellido_Materno + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Proveedores.Apellido_Materno = '" + filter.Apellido_Materno + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Proveedores.Apellido_Materno LIKE '%" + filter.Apellido_Materno + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Nombre_Completo))
            {
                switch (filter.Nombre_CompletoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Proveedores.Nombre_Completo LIKE '" + filter.Nombre_Completo + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Proveedores.Nombre_Completo LIKE '%" + filter.Nombre_Completo + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Proveedores.Nombre_Completo = '" + filter.Nombre_Completo + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Proveedores.Nombre_Completo LIKE '%" + filter.Nombre_Completo + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Nombre_de_Usuario))
            {
                switch (filter.Nombre_de_UsuarioFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Proveedores.Nombre_de_Usuario LIKE '" + filter.Nombre_de_Usuario + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Proveedores.Nombre_de_Usuario LIKE '%" + filter.Nombre_de_Usuario + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Proveedores.Nombre_de_Usuario = '" + filter.Nombre_de_Usuario + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Proveedores.Nombre_de_Usuario LIKE '%" + filter.Nombre_de_Usuario + "%'";
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

                where += " AND Proveedores.Usuario_Registrado In (" + Usuario_RegistradoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Email))
            {
                switch (filter.EmailFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Proveedores.Email LIKE '" + filter.Email + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Proveedores.Email LIKE '%" + filter.Email + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Proveedores.Email = '" + filter.Email + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Proveedores.Email LIKE '%" + filter.Email + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Celular))
            {
                switch (filter.CelularFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Proveedores.Celular LIKE '" + filter.Celular + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Proveedores.Celular LIKE '%" + filter.Celular + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Proveedores.Celular = '" + filter.Celular + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Proveedores.Celular LIKE '%" + filter.Celular + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Nacimiento) || !string.IsNullOrEmpty(filter.ToFecha_de_Nacimiento))
            {
                var Fecha_de_NacimientoFrom = DateTime.ParseExact(filter.FromFecha_de_Nacimiento, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_NacimientoTo = DateTime.ParseExact(filter.ToFecha_de_Nacimiento, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Nacimiento))
                    where += " AND Proveedores.Fecha_de_Nacimiento >= '" + Fecha_de_NacimientoFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Nacimiento))
                    where += " AND Proveedores.Fecha_de_Nacimiento <= '" + Fecha_de_NacimientoTo.ToString("MM-dd-yyyy") + "'";
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

                where += " AND Proveedores.Pais_de_nacimiento In (" + Pais_de_nacimientoIds + ")";
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

                where += " AND Proveedores.Entidad_de_nacimiento In (" + Entidad_de_nacimientoIds + ")";
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

                where += " AND Proveedores.Sexo In (" + SexoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceRegimen_Fiscal))
            {
                switch (filter.Regimen_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Regimenes_Fiscales.Descripcion LIKE '" + filter.AdvanceRegimen_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Regimenes_Fiscales.Descripcion LIKE '%" + filter.AdvanceRegimen_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Regimenes_Fiscales.Descripcion = '" + filter.AdvanceRegimen_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Regimenes_Fiscales.Descripcion LIKE '%" + filter.AdvanceRegimen_Fiscal + "%'";
                        break;
                }
            }
            else if (filter.AdvanceRegimen_FiscalMultiple != null && filter.AdvanceRegimen_FiscalMultiple.Count() > 0)
            {
                var Regimen_FiscalIds = string.Join(",", filter.AdvanceRegimen_FiscalMultiple);

                where += " AND Proveedores.Regimen_Fiscal In (" + Regimen_FiscalIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombre_o_Razon_Social))
            {
                switch (filter.Nombre_o_Razon_SocialFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Proveedores.Nombre_o_Razon_Social LIKE '" + filter.Nombre_o_Razon_Social + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Proveedores.Nombre_o_Razon_Social LIKE '%" + filter.Nombre_o_Razon_Social + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Proveedores.Nombre_o_Razon_Social = '" + filter.Nombre_o_Razon_Social + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Proveedores.Nombre_o_Razon_Social LIKE '%" + filter.Nombre_o_Razon_Social + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.RFC))
            {
                switch (filter.RFCFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Proveedores.RFC LIKE '" + filter.RFC + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Proveedores.RFC LIKE '%" + filter.RFC + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Proveedores.RFC = '" + filter.RFC + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Proveedores.RFC LIKE '%" + filter.RFC + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Calle_Fiscal))
            {
                switch (filter.Calle_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Proveedores.Calle_Fiscal LIKE '" + filter.Calle_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Proveedores.Calle_Fiscal LIKE '%" + filter.Calle_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Proveedores.Calle_Fiscal = '" + filter.Calle_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Proveedores.Calle_Fiscal LIKE '%" + filter.Calle_Fiscal + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromNumero_exterior_Fiscal) || !string.IsNullOrEmpty(filter.ToNumero_exterior_Fiscal))
            {
                if (!string.IsNullOrEmpty(filter.FromNumero_exterior_Fiscal))
                    where += " AND Proveedores.Numero_exterior_Fiscal >= " + filter.FromNumero_exterior_Fiscal;
                if (!string.IsNullOrEmpty(filter.ToNumero_exterior_Fiscal))
                    where += " AND Proveedores.Numero_exterior_Fiscal <= " + filter.ToNumero_exterior_Fiscal;
            }

            if (!string.IsNullOrEmpty(filter.FromNumero_interior_Fiscal) || !string.IsNullOrEmpty(filter.ToNumero_interior_Fiscal))
            {
                if (!string.IsNullOrEmpty(filter.FromNumero_interior_Fiscal))
                    where += " AND Proveedores.Numero_interior_Fiscal >= " + filter.FromNumero_interior_Fiscal;
                if (!string.IsNullOrEmpty(filter.ToNumero_interior_Fiscal))
                    where += " AND Proveedores.Numero_interior_Fiscal <= " + filter.ToNumero_interior_Fiscal;
            }

            if (!string.IsNullOrEmpty(filter.Colonia_Fiscal))
            {
                switch (filter.Colonia_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Proveedores.Colonia_Fiscal LIKE '" + filter.Colonia_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Proveedores.Colonia_Fiscal LIKE '%" + filter.Colonia_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Proveedores.Colonia_Fiscal = '" + filter.Colonia_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Proveedores.Colonia_Fiscal LIKE '%" + filter.Colonia_Fiscal + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromC_P__Fiscal) || !string.IsNullOrEmpty(filter.ToC_P__Fiscal))
            {
                if (!string.IsNullOrEmpty(filter.FromC_P__Fiscal))
                    where += " AND Proveedores.C_P__Fiscal >= " + filter.FromC_P__Fiscal;
                if (!string.IsNullOrEmpty(filter.ToC_P__Fiscal))
                    where += " AND Proveedores.C_P__Fiscal <= " + filter.ToC_P__Fiscal;
            }

            if (!string.IsNullOrEmpty(filter.Ciudad_Fiscal))
            {
                switch (filter.Ciudad_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Proveedores.Ciudad_Fiscal LIKE '" + filter.Ciudad_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Proveedores.Ciudad_Fiscal LIKE '%" + filter.Ciudad_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Proveedores.Ciudad_Fiscal = '" + filter.Ciudad_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Proveedores.Ciudad_Fiscal LIKE '%" + filter.Ciudad_Fiscal + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEstado_Fiscal))
            {
                switch (filter.Estado_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estado.Nombre_del_Estado LIKE '" + filter.AdvanceEstado_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estado.Nombre_del_Estado LIKE '%" + filter.AdvanceEstado_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estado.Nombre_del_Estado = '" + filter.AdvanceEstado_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estado.Nombre_del_Estado LIKE '%" + filter.AdvanceEstado_Fiscal + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEstado_FiscalMultiple != null && filter.AdvanceEstado_FiscalMultiple.Count() > 0)
            {
                var Estado_FiscalIds = string.Join(",", filter.AdvanceEstado_FiscalMultiple);

                where += " AND Proveedores.Estado_Fiscal In (" + Estado_FiscalIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvancePais_Fiscal))
            {
                switch (filter.Pais_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pais.Nombre_del_Pais LIKE '" + filter.AdvancePais_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pais.Nombre_del_Pais LIKE '%" + filter.AdvancePais_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pais.Nombre_del_Pais = '" + filter.AdvancePais_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pais.Nombre_del_Pais LIKE '%" + filter.AdvancePais_Fiscal + "%'";
                        break;
                }
            }
            else if (filter.AdvancePais_FiscalMultiple != null && filter.AdvancePais_FiscalMultiple.Count() > 0)
            {
                var Pais_FiscalIds = string.Join(",", filter.AdvancePais_FiscalMultiple);

                where += " AND Proveedores.Pais_Fiscal In (" + Pais_FiscalIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Telefono))
            {
                switch (filter.TelefonoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Proveedores.Telefono LIKE '" + filter.Telefono + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Proveedores.Telefono LIKE '%" + filter.Telefono + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Proveedores.Telefono = '" + filter.Telefono + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Proveedores.Telefono LIKE '%" + filter.Telefono + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Fax))
            {
                switch (filter.FaxFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Proveedores.Fax LIKE '" + filter.Fax + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Proveedores.Fax LIKE '%" + filter.Fax + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Proveedores.Fax = '" + filter.Fax + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Proveedores.Fax LIKE '%" + filter.Fax + "%'";
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

        public ActionResult GetDetalle_Sucursales_Proveedores(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Sucursales_ProveedoresGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Sucursales_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Sucursales_Proveedores.FolioProveedores=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Sucursales_Proveedores.FolioProveedores='" + RelationId + "'";
            }
            var result = _IDetalle_Sucursales_ProveedoresApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Sucursales_Proveedoress == null)
                result.Detalle_Sucursales_Proveedoress = new List<Detalle_Sucursales_Proveedores>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Sucursales_Proveedoress.Select(m => new Detalle_Sucursales_ProveedoresGridModel
                {
                    Folio = m.Folio

                        ,Tipo_de_Sucursal = m.Tipo_de_Sucursal
                        ,Tipo_de_SucursalDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Sucursal_Tipo_de_Sucursal.Clave.ToString(), "Descripcion") ??(string)m.Tipo_de_Sucursal_Tipo_de_Sucursal.Descripcion
			,Email = m.Email
			,Telefono = m.Telefono
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,C_P_ = m.C_P_
			,Ciudad = m.Ciudad
			,Estado = m.Estado
			,Pais = m.Pais

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Sucursales_ProveedoresGridModel> GetDetalle_Sucursales_ProveedoresData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Sucursales_ProveedoresGridModel> resultData = new List<Detalle_Sucursales_ProveedoresGridModel>();
            string where = "Detalle_Sucursales_Proveedores.FolioProveedores=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Sucursales_Proveedores.FolioProveedores='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Sucursales_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Sucursales_ProveedoresApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Sucursales_Proveedoress != null)
            {
                resultData = result.Detalle_Sucursales_Proveedoress.Select(m => new Detalle_Sucursales_ProveedoresGridModel
                    {
                        Folio = m.Folio

                        ,Tipo_de_Sucursal = m.Tipo_de_Sucursal
                        ,Tipo_de_SucursalDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Sucursal_Tipo_de_Sucursal.Clave.ToString(), "Descripcion") ??(string)m.Tipo_de_Sucursal_Tipo_de_Sucursal.Descripcion
			,Email = m.Email
			,Telefono = m.Telefono
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,C_P_ = m.C_P_
			,Ciudad = m.Ciudad
			,Estado = m.Estado
			,Pais = m.Pais


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Suscripcion_Red_de_Especialistas_Proveedores(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Folio_Proveedores=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Folio_Proveedores='" + RelationId + "'";
            }
            var result = _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress == null)
                result.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress = new List<Detalle_Suscripcion_Red_de_Especialistas_Proveedores>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress.Select(m => new Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGridModel
                {
                    Folio = m.Folio

                        ,Plan_de_Suscripcion = m.Plan_de_Suscripcion
                        ,Plan_de_SuscripcionDescripcion = CultureHelper.GetTraduction(m.Plan_de_Suscripcion_Planes_de_Suscripcion_Proveedores.Clave.ToString(), "Descripcion") ??(string)m.Plan_de_Suscripcion_Planes_de_Suscripcion_Proveedores.Descripcion
			,Fecha_inicio = (m.Fecha_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio).ToString(ConfigurationProperty.DateFormat))
			,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
			,Costo = m.Costo
			,ContratoFileInfo = m.Contrato > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Contrato).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }
			,Firmo_Contrato = m.Firmo_Contrato
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_de_Suscripcion.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus_de_Suscripcion.Descripcion

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGridModel> GetDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGridModel> resultData = new List<Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGridModel>();
            string where = "Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Folio_Proveedores=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Folio_Proveedores='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress != null)
            {
                resultData = result.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress.Select(m => new Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGridModel
                    {
                        Folio = m.Folio

                        ,Plan_de_Suscripcion = m.Plan_de_Suscripcion
                        ,Plan_de_SuscripcionDescripcion = CultureHelper.GetTraduction(m.Plan_de_Suscripcion_Planes_de_Suscripcion_Proveedores.Clave.ToString(), "Descripcion") ??(string)m.Plan_de_Suscripcion_Planes_de_Suscripcion_Proveedores.Descripcion
			,Fecha_inicio = (m.Fecha_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio).ToString(ConfigurationProperty.DateFormat))
			,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
			,Costo = m.Costo
			,ContratoFileInfo = m.Contrato > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Contrato).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }
			,Firmo_Contrato = m.Firmo_Contrato
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_de_Suscripcion.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus_de_Suscripcion.Descripcion


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
                _IProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

                Proveedores varProveedores = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IDetalle_Sucursales_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Sucursales_Proveedores.FolioProveedores=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Sucursales_Proveedores.FolioProveedores='" + id + "'";
                    }
                    var Detalle_Sucursales_ProveedoresInfo =
                        _IDetalle_Sucursales_ProveedoresApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Sucursales_ProveedoresInfo.Detalle_Sucursales_Proveedoress.Count > 0)
                    {
                        var resultDetalle_Sucursales_Proveedores = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Sucursales_ProveedoresItem in Detalle_Sucursales_ProveedoresInfo.Detalle_Sucursales_Proveedoress)
                            resultDetalle_Sucursales_Proveedores = resultDetalle_Sucursales_Proveedores
                                              && _IDetalle_Sucursales_ProveedoresApiConsumer.Delete(Detalle_Sucursales_ProveedoresItem.Folio, null,null).Resource;

                        if (!resultDetalle_Sucursales_Proveedores)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Folio_Proveedores=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Folio_Proveedores='" + id + "'";
                    }
                    var Detalle_Suscripcion_Red_de_Especialistas_ProveedoresInfo =
                        _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresInfo.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress.Count > 0)
                    {
                        var resultDetalle_Suscripcion_Red_de_Especialistas_Proveedores = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem in Detalle_Suscripcion_Red_de_Especialistas_ProveedoresInfo.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress)
                            resultDetalle_Suscripcion_Red_de_Especialistas_Proveedores = resultDetalle_Suscripcion_Red_de_Especialistas_Proveedores
                                              && _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.Delete(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.Folio, null,null).Resource;

                        if (!resultDetalle_Suscripcion_Red_de_Especialistas_Proveedores)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IProveedoresApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, ProveedoresModel varProveedores)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var ProveedoresInfo = new Proveedores
                    {
                        Folio = varProveedores.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varProveedores.Fecha_de_Registro)) ? DateTime.ParseExact(varProveedores.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varProveedores.Hora_de_Registro
                        ,Usuario_que_Registra = varProveedores.Usuario_que_Registra
                        ,Nombre_del_Proveedor = varProveedores.Nombre_del_Proveedor
                        ,Tipo_de_Proveedor = varProveedores.Tipo_de_Proveedor
                        ,Estatus = varProveedores.Estatus
                        ,Nombres = varProveedores.Nombres
                        ,Apellido_Paterno = varProveedores.Apellido_Paterno
                        ,Apellido_Materno = varProveedores.Apellido_Materno
                        ,Nombre_Completo = varProveedores.Nombre_Completo
                        ,Nombre_de_Usuario = varProveedores.Nombre_de_Usuario
                        ,Usuario_Registrado = varProveedores.Usuario_Registrado
                        ,Email = varProveedores.Email
                        ,Celular = varProveedores.Celular
                        ,Fecha_de_Nacimiento = (!String.IsNullOrEmpty(varProveedores.Fecha_de_Nacimiento)) ? DateTime.ParseExact(varProveedores.Fecha_de_Nacimiento, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Pais_de_nacimiento = varProveedores.Pais_de_nacimiento
                        ,Entidad_de_nacimiento = varProveedores.Entidad_de_nacimiento
                        ,Sexo = varProveedores.Sexo
                        ,Regimen_Fiscal = varProveedores.Regimen_Fiscal
                        ,Nombre_o_Razon_Social = varProveedores.Nombre_o_Razon_Social
                        ,RFC = varProveedores.RFC
                        ,Calle_Fiscal = varProveedores.Calle_Fiscal
                        ,Numero_exterior_Fiscal = varProveedores.Numero_exterior_Fiscal
                        ,Numero_interior_Fiscal = varProveedores.Numero_interior_Fiscal
                        ,Colonia_Fiscal = varProveedores.Colonia_Fiscal
                        ,C_P__Fiscal = varProveedores.C_P__Fiscal
                        ,Ciudad_Fiscal = varProveedores.Ciudad_Fiscal
                        ,Estado_Fiscal = varProveedores.Estado_Fiscal
                        ,Pais_Fiscal = varProveedores.Pais_Fiscal
                        ,Telefono = varProveedores.Telefono
                        ,Fax = varProveedores.Fax

                    };

                    result = !IsNew ?
                        _IProveedoresApiConsumer.Update(ProveedoresInfo, null, null).Resource.ToString() :
                         _IProveedoresApiConsumer.Insert(ProveedoresInfo, null, null).Resource.ToString();
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
        public bool CopyDetalle_Sucursales_Proveedores(int MasterId, int referenceId, List<Detalle_Sucursales_ProveedoresGridModelPost> Detalle_Sucursales_ProveedoresItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Sucursales_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Sucursales_ProveedoresData = _IDetalle_Sucursales_ProveedoresApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Sucursales_Proveedores.FolioProveedores=" + referenceId,"").Resource;
                if (Detalle_Sucursales_ProveedoresData == null || Detalle_Sucursales_ProveedoresData.Detalle_Sucursales_Proveedoress.Count == 0)
                    return true;

                var result = true;

                Detalle_Sucursales_ProveedoresGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Sucursales_Proveedores in Detalle_Sucursales_ProveedoresData.Detalle_Sucursales_Proveedoress)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Sucursales_Proveedores Detalle_Sucursales_Proveedores1 = varDetalle_Sucursales_Proveedores;

                    if (Detalle_Sucursales_ProveedoresItems != null && Detalle_Sucursales_ProveedoresItems.Any(m => m.Folio == Detalle_Sucursales_Proveedores1.Folio))
                    {
                        modelDataToChange = Detalle_Sucursales_ProveedoresItems.FirstOrDefault(m => m.Folio == Detalle_Sucursales_Proveedores1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Sucursales_Proveedores.FolioProveedores = MasterId;
                    var insertId = _IDetalle_Sucursales_ProveedoresApiConsumer.Insert(varDetalle_Sucursales_Proveedores,null,null).Resource;
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
        public ActionResult PostDetalle_Sucursales_Proveedores(List<Detalle_Sucursales_ProveedoresGridModelPost> Detalle_Sucursales_ProveedoresItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Sucursales_Proveedores(MasterId, referenceId, Detalle_Sucursales_ProveedoresItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Sucursales_ProveedoresItems != null && Detalle_Sucursales_ProveedoresItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Sucursales_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Sucursales_ProveedoresItem in Detalle_Sucursales_ProveedoresItems)
                    {













                        //Removal Request
                        if (Detalle_Sucursales_ProveedoresItem.Removed)
                        {
                            result = result && _IDetalle_Sucursales_ProveedoresApiConsumer.Delete(Detalle_Sucursales_ProveedoresItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Sucursales_ProveedoresItem.Folio = 0;

                        var Detalle_Sucursales_ProveedoresData = new Detalle_Sucursales_Proveedores
                        {
                            FolioProveedores = MasterId
                            ,Folio = Detalle_Sucursales_ProveedoresItem.Folio
                            ,Tipo_de_Sucursal = (Convert.ToInt32(Detalle_Sucursales_ProveedoresItem.Tipo_de_Sucursal) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Sucursales_ProveedoresItem.Tipo_de_Sucursal))
                            ,Email = Detalle_Sucursales_ProveedoresItem.Email
                            ,Telefono = Detalle_Sucursales_ProveedoresItem.Telefono
                            ,Calle = Detalle_Sucursales_ProveedoresItem.Calle
                            ,Numero_exterior = Detalle_Sucursales_ProveedoresItem.Numero_exterior
                            ,Numero_interior = Detalle_Sucursales_ProveedoresItem.Numero_interior
                            ,Colonia = Detalle_Sucursales_ProveedoresItem.Colonia
                            ,C_P_ = Detalle_Sucursales_ProveedoresItem.C_P_
                            ,Ciudad = Detalle_Sucursales_ProveedoresItem.Ciudad
                            ,Estado = Detalle_Sucursales_ProveedoresItem.Estado
                            ,Pais = Detalle_Sucursales_ProveedoresItem.Pais

                        };

                        var resultId = Detalle_Sucursales_ProveedoresItem.Folio > 0
                           ? _IDetalle_Sucursales_ProveedoresApiConsumer.Update(Detalle_Sucursales_ProveedoresData,null,null).Resource
                           : _IDetalle_Sucursales_ProveedoresApiConsumer.Insert(Detalle_Sucursales_ProveedoresData,null,null).Resource;

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
        public ActionResult GetDetalle_Sucursales_Proveedores_Tipo_de_SucursalAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_SucursalApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_de_SucursalApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
                    item.Descripcion= CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Tipo_de_Sucursal", "Descripcion");
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }











        [NonAction]
        public bool CopyDetalle_Suscripcion_Red_de_Especialistas_Proveedores(int MasterId, int referenceId, List<Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGridModelPost> Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData = _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Folio_Proveedores=" + referenceId,"").Resource;
                if (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData == null || Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress.Count == 0)
                    return true;

                var result = true;

                Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Suscripcion_Red_de_Especialistas_Proveedores in Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Suscripcion_Red_de_Especialistas_Proveedores Detalle_Suscripcion_Red_de_Especialistas_Proveedores1 = varDetalle_Suscripcion_Red_de_Especialistas_Proveedores;

                    if (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItems != null && Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItems.Any(m => m.Folio == Detalle_Suscripcion_Red_de_Especialistas_Proveedores1.Folio))
                    {
                        modelDataToChange = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItems.FirstOrDefault(m => m.Folio == Detalle_Suscripcion_Red_de_Especialistas_Proveedores1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.Folio_Proveedores = MasterId;
                    var insertId = _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.Insert(varDetalle_Suscripcion_Red_de_Especialistas_Proveedores,null,null).Resource;
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
        public ActionResult PostDetalle_Suscripcion_Red_de_Especialistas_Proveedores(List<Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGridModelPost> Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Suscripcion_Red_de_Especialistas_Proveedores(MasterId, referenceId, Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItems != null && Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem in Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItems)
                    {





                        #region ContratoInfo
                        //Checking if file exist if yes edit or add
                        if (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.ContratoInfo.Control != null && !Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.Removed)
                        {
                            var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.ContratoInfo.Control);
                            Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.ContratoInfo.FileId = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                            {
                                File = fileAsBytes,
                                Description = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.ContratoInfo.Control.FileName,
                                File_Size = fileAsBytes.Length
                            }).Resource;
                        }
                        else if (!Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.Removed && Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.ContratoInfo.RemoveFile)
                        {
                            Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.ContratoInfo.FileId = 0;
                        }
                        #endregion ContratoInfo



                        //Removal Request
                        if (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.Removed)
                        {
                            result = result && _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.Delete(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.Folio = 0;

                        var Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData = new Detalle_Suscripcion_Red_de_Especialistas_Proveedores
                        {
                            Folio_Proveedores = MasterId
                            ,Folio = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.Folio
                            ,Plan_de_Suscripcion = (Convert.ToInt32(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.Plan_de_Suscripcion) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.Plan_de_Suscripcion))
                            ,Fecha_inicio = (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.Fecha_inicio!= null) ? DateTime.ParseExact(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.Fecha_inicio, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Fecha_fin = (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.Fecha_fin!= null) ? DateTime.ParseExact(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.Fecha_fin, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Costo = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.Costo
                            ,Contrato = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.ContratoInfo.FileId
                            ,Firmo_Contrato = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.Firmo_Contrato
                            ,Estatus = (Convert.ToInt32(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.Estatus) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.Estatus))

                        };

                        var resultId = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresItem.Folio > 0
                           ? _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.Update(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData,null,null).Resource
                           : _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.Insert(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData,null,null).Resource;

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
        public ActionResult GetDetalle_Suscripcion_Red_de_Especialistas_Proveedores_Planes_de_Suscripcion_ProveedoresAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_Suscripcion_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlanes_de_Suscripcion_ProveedoresApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Planes_de_Suscripcion_Proveedores", "Descripcion");
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
        public ActionResult GetDetalle_Suscripcion_Red_de_Especialistas_Proveedores_Estatus_de_SuscripcionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_de_SuscripcionApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Estatus_de_Suscripcion", "Descripcion");
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
        /// Write Element Array of Proveedores script
        /// </summary>
        /// <param name="oProveedoresElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew ProveedoresModuleAttributeList)
        {
            for (int i = 0; i < ProveedoresModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(ProveedoresModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    ProveedoresModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(ProveedoresModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    ProveedoresModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (ProveedoresModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < ProveedoresModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < ProveedoresModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(ProveedoresModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							ProveedoresModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(ProveedoresModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							ProveedoresModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strProveedoresScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Proveedores.js")))
            {
                strProveedoresScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Proveedores element attributes
            string userChangeJson = jsSerialize.Serialize(ProveedoresModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strProveedoresScript.IndexOf("inpuElementArray");
            string splittedString = strProveedoresScript.Substring(indexOfArray, strProveedoresScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(ProveedoresModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (ProveedoresModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strProveedoresScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strProveedoresScript.Substring(indexOfArrayHistory, strProveedoresScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strProveedoresScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strProveedoresScript.Substring(endIndexOfMainElement + indexOfArray, strProveedoresScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (ProveedoresModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in ProveedoresModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Proveedores.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Proveedores.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Proveedores.js")))
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
        public ActionResult ProveedoresPropertyBag()
        {
            return PartialView("ProveedoresPropertyBag", "Proveedores");
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
        public ActionResult AddDetalle_Sucursales_Proveedores(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Sucursales_Proveedores/AddDetalle_Sucursales_Proveedores");
        }

        [HttpGet]
        public ActionResult AddDetalle_Suscripcion_Red_de_Especialistas_Proveedores(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Suscripcion_Red_de_Especialistas_Proveedores/AddDetalle_Suscripcion_Red_de_Especialistas_Proveedores");
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
                var whereClauseFormat = "Object = 44591 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Proveedores.Folio= " + RecordId;
                            var result = _IProveedoresApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new ProveedoresPropertyMapper());
			
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
                    (ProveedoresAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            ProveedoresPropertyMapper oProveedoresPropertyMapper = new ProveedoresPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oProveedoresPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IProveedoresApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Proveedoress == null)
                result.Proveedoress = new List<Proveedores>();

            var data = result.Proveedoress.Select(m => new ProveedoresGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_del_Proveedor = m.Nombre_del_Proveedor
                        ,Tipo_de_ProveedorDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Proveedor_Tipo_de_proveedor.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Proveedor_Tipo_de_proveedor.Descripcion
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
			,Nombre_de_Usuario = m.Nombre_de_Usuario
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Email = m.Email
			,Celular = m.Celular
                        ,Fecha_de_Nacimiento = (m.Fecha_de_Nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Nacimiento).ToString(ConfigurationProperty.DateFormat))
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Entidad_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
                        ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(m.Regimen_Fiscal_Regimenes_Fiscales.Clave.ToString(), "Descripcion") ?? (string)m.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
			,Nombre_o_Razon_Social = m.Nombre_o_Razon_Social
			,RFC = m.RFC
			,Calle_Fiscal = m.Calle_Fiscal
			,Numero_exterior_Fiscal = m.Numero_exterior_Fiscal
			,Numero_interior_Fiscal = m.Numero_interior_Fiscal
			,Colonia_Fiscal = m.Colonia_Fiscal
			,C_P__Fiscal = m.C_P__Fiscal
			,Ciudad_Fiscal = m.Ciudad_Fiscal
                        ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Fiscal_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Fiscal_Estado.Nombre_del_Estado
                        ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Fiscal_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Fiscal_Pais.Nombre_del_Pais
			,Telefono = m.Telefono
			,Fax = m.Fax

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44591, arrayColumnsVisible), "ProveedoresList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44591, arrayColumnsVisible), "ProveedoresList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44591, arrayColumnsVisible), "ProveedoresList_" + DateTime.Now.ToString());
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

            _IProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new ProveedoresPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (ProveedoresAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            ProveedoresPropertyMapper oProveedoresPropertyMapper = new ProveedoresPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oProveedoresPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IProveedoresApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Proveedoress == null)
                result.Proveedoress = new List<Proveedores>();

            var data = result.Proveedoress.Select(m => new ProveedoresGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_del_Proveedor = m.Nombre_del_Proveedor
                        ,Tipo_de_ProveedorDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Proveedor_Tipo_de_proveedor.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Proveedor_Tipo_de_proveedor.Descripcion
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
			,Nombre_de_Usuario = m.Nombre_de_Usuario
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Email = m.Email
			,Celular = m.Celular
                        ,Fecha_de_Nacimiento = (m.Fecha_de_Nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Nacimiento).ToString(ConfigurationProperty.DateFormat))
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Entidad_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion
                        ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(m.Regimen_Fiscal_Regimenes_Fiscales.Clave.ToString(), "Descripcion") ?? (string)m.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
			,Nombre_o_Razon_Social = m.Nombre_o_Razon_Social
			,RFC = m.RFC
			,Calle_Fiscal = m.Calle_Fiscal
			,Numero_exterior_Fiscal = m.Numero_exterior_Fiscal
			,Numero_interior_Fiscal = m.Numero_interior_Fiscal
			,Colonia_Fiscal = m.Colonia_Fiscal
			,C_P__Fiscal = m.C_P__Fiscal
			,Ciudad_Fiscal = m.Ciudad_Fiscal
                        ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Fiscal_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Fiscal_Estado.Nombre_del_Estado
                        ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Fiscal_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Fiscal_Pais.Nombre_del_Pais
			,Telefono = m.Telefono
			,Fax = m.Fax

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
                _IProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IProveedoresApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Proveedores_Datos_GeneralesModel varProveedores)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Proveedores_Datos_GeneralesInfo = new Proveedores_Datos_Generales
                {
                    Folio = varProveedores.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varProveedores.Fecha_de_Registro)) ? DateTime.ParseExact(varProveedores.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varProveedores.Hora_de_Registro
                        ,Usuario_que_Registra = varProveedores.Usuario_que_Registra
                        ,Nombre_del_Proveedor = varProveedores.Nombre_del_Proveedor
                        ,Tipo_de_Proveedor = varProveedores.Tipo_de_Proveedor
                        ,Estatus = varProveedores.Estatus
                    
                };

                result = _IProveedoresApiConsumer.Update_Datos_Generales(Proveedores_Datos_GeneralesInfo).Resource.ToString();
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
                _IProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IProveedoresApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Sucursales_Proveedores;
                var Detalle_Sucursales_ProveedoresData = GetDetalle_Sucursales_ProveedoresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Sucursales_Proveedores);
                int RowCount_Detalle_Suscripcion_Red_de_Especialistas_Proveedores;
                var Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData = GetDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Suscripcion_Red_de_Especialistas_Proveedores);

                var result = new Proveedores_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_del_Proveedor = m.Nombre_del_Proveedor
                        ,Tipo_de_Proveedor = m.Tipo_de_Proveedor
                        ,Tipo_de_ProveedorDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Proveedor_Tipo_de_proveedor.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Proveedor_Tipo_de_proveedor.Descripcion
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                    
                };
				var resultData = new
                {
                    data = result
                    ,Sucursales = Detalle_Sucursales_ProveedoresData
                    ,Suscripcion_Red_de_Especialistas = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Datos_de_Contacto(Proveedores_Datos_de_ContactoModel varProveedores)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Proveedores_Datos_de_ContactoInfo = new Proveedores_Datos_de_Contacto
                {
                    Folio = varProveedores.Folio
                                            ,Nombres = varProveedores.Nombres
                        ,Apellido_Paterno = varProveedores.Apellido_Paterno
                        ,Apellido_Materno = varProveedores.Apellido_Materno
                        ,Nombre_Completo = varProveedores.Nombre_Completo
                        ,Nombre_de_Usuario = varProveedores.Nombre_de_Usuario
                        ,Usuario_Registrado = varProveedores.Usuario_Registrado
                        ,Email = varProveedores.Email
                        ,Celular = varProveedores.Celular
                        ,Fecha_de_Nacimiento = (!String.IsNullOrEmpty(varProveedores.Fecha_de_Nacimiento)) ? DateTime.ParseExact(varProveedores.Fecha_de_Nacimiento, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Pais_de_nacimiento = varProveedores.Pais_de_nacimiento
                        ,Entidad_de_nacimiento = varProveedores.Entidad_de_nacimiento
                        ,Sexo = varProveedores.Sexo
                    
                };

                result = _IProveedoresApiConsumer.Update_Datos_de_Contacto(Proveedores_Datos_de_ContactoInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Datos_de_Contacto(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IProveedoresApiConsumer.Get_Datos_de_Contacto(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Sucursales_Proveedores;
                var Detalle_Sucursales_ProveedoresData = GetDetalle_Sucursales_ProveedoresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Sucursales_Proveedores);
                int RowCount_Detalle_Suscripcion_Red_de_Especialistas_Proveedores;
                var Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData = GetDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Suscripcion_Red_de_Especialistas_Proveedores);

                var result = new Proveedores_Datos_de_ContactoModel
                {
                    Folio = m.Folio
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
			,Nombre_de_Usuario = m.Nombre_de_Usuario
                        ,Usuario_Registrado = m.Usuario_Registrado
                        ,Usuario_RegistradoName = CultureHelper.GetTraduction(m.Usuario_Registrado_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Registrado_Spartan_User.Name
			,Email = m.Email
			,Celular = m.Celular
                        ,Fecha_de_Nacimiento = (m.Fecha_de_Nacimiento == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Nacimiento).ToString(ConfigurationProperty.DateFormat))
                        ,Pais_de_nacimiento = m.Pais_de_nacimiento
                        ,Pais_de_nacimientoNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_de_nacimiento_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_de_nacimiento_Pais.Nombre_del_Pais
                        ,Entidad_de_nacimiento = m.Entidad_de_nacimiento
                        ,Entidad_de_nacimientoNombre_del_Estado = CultureHelper.GetTraduction(m.Entidad_de_nacimiento_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Entidad_de_nacimiento_Estado.Nombre_del_Estado
                        ,Sexo = m.Sexo
                        ,SexoDescripcion = CultureHelper.GetTraduction(m.Sexo_Sexo.Clave.ToString(), "Descripcion") ?? (string)m.Sexo_Sexo.Descripcion

                    
                };
				var resultData = new
                {
                    data = result
                    ,Sucursales = Detalle_Sucursales_ProveedoresData
                    ,Suscripcion_Red_de_Especialistas = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Red_de_Proveedores(Proveedores_Red_de_ProveedoresModel varProveedores)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Proveedores_Red_de_ProveedoresInfo = new Proveedores_Red_de_Proveedores
                {
                    Folio = varProveedores.Folio
                                        
                };

                result = _IProveedoresApiConsumer.Update_Red_de_Proveedores(Proveedores_Red_de_ProveedoresInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Red_de_Proveedores(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IProveedoresApiConsumer.Get_Red_de_Proveedores(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Sucursales_Proveedores;
                var Detalle_Sucursales_ProveedoresData = GetDetalle_Sucursales_ProveedoresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Sucursales_Proveedores);
                int RowCount_Detalle_Suscripcion_Red_de_Especialistas_Proveedores;
                var Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData = GetDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Suscripcion_Red_de_Especialistas_Proveedores);

                var result = new Proveedores_Red_de_ProveedoresModel
                {
                    Folio = m.Folio

                    
                };
				var resultData = new
                {
                    data = result
                    ,Sucursales = Detalle_Sucursales_ProveedoresData
                    ,Suscripcion_Red_de_Especialistas = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Datos_Fiscales(Proveedores_Datos_FiscalesModel varProveedores)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Proveedores_Datos_FiscalesInfo = new Proveedores_Datos_Fiscales
                {
                    Folio = varProveedores.Folio
                                            ,Regimen_Fiscal = varProveedores.Regimen_Fiscal
                        ,Nombre_o_Razon_Social = varProveedores.Nombre_o_Razon_Social
                        ,RFC = varProveedores.RFC
                        ,Calle_Fiscal = varProveedores.Calle_Fiscal
                        ,Numero_exterior_Fiscal = varProveedores.Numero_exterior_Fiscal
                        ,Numero_interior_Fiscal = varProveedores.Numero_interior_Fiscal
                        ,Colonia_Fiscal = varProveedores.Colonia_Fiscal
                        ,C_P__Fiscal = varProveedores.C_P__Fiscal
                        ,Ciudad_Fiscal = varProveedores.Ciudad_Fiscal
                        ,Estado_Fiscal = varProveedores.Estado_Fiscal
                        ,Pais_Fiscal = varProveedores.Pais_Fiscal
                        ,Telefono = varProveedores.Telefono
                        ,Fax = varProveedores.Fax
                    
                };

                result = _IProveedoresApiConsumer.Update_Datos_Fiscales(Proveedores_Datos_FiscalesInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Datos_Fiscales(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IProveedoresApiConsumer.Get_Datos_Fiscales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Sucursales_Proveedores;
                var Detalle_Sucursales_ProveedoresData = GetDetalle_Sucursales_ProveedoresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Sucursales_Proveedores);
                int RowCount_Detalle_Suscripcion_Red_de_Especialistas_Proveedores;
                var Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData = GetDetalle_Suscripcion_Red_de_Especialistas_ProveedoresData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Suscripcion_Red_de_Especialistas_Proveedores);

                var result = new Proveedores_Datos_FiscalesModel
                {
                    Folio = m.Folio
                        ,Regimen_Fiscal = m.Regimen_Fiscal
                        ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(m.Regimen_Fiscal_Regimenes_Fiscales.Clave.ToString(), "Descripcion") ?? (string)m.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
			,Nombre_o_Razon_Social = m.Nombre_o_Razon_Social
			,RFC = m.RFC
			,Calle_Fiscal = m.Calle_Fiscal
			,Numero_exterior_Fiscal = m.Numero_exterior_Fiscal
			,Numero_interior_Fiscal = m.Numero_interior_Fiscal
			,Colonia_Fiscal = m.Colonia_Fiscal
			,C_P__Fiscal = m.C_P__Fiscal
			,Ciudad_Fiscal = m.Ciudad_Fiscal
                        ,Estado_Fiscal = m.Estado_Fiscal
                        ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Fiscal_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Fiscal_Estado.Nombre_del_Estado
                        ,Pais_Fiscal = m.Pais_Fiscal
                        ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Fiscal_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Fiscal_Pais.Nombre_del_Pais
			,Telefono = m.Telefono
			,Fax = m.Fax

                    
                };
				var resultData = new
                {
                    data = result
                    ,Sucursales = Detalle_Sucursales_ProveedoresData
                    ,Suscripcion_Red_de_Especialistas = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

