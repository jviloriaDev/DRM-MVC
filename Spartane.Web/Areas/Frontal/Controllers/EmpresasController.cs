using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Empresas;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Tipos_de_Empresa;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Pais;
using Spartane.Core.Domain.Estatus;
using Spartane.Core.Domain.Detalle_Contactos_Empresa;





using Spartane.Core.Domain.areas_Empresas;



using Spartane.Core.Domain.Estatus;

using Spartane.Core.Domain.Regimenes_Fiscales;
using Spartane.Core.Domain.Estado;
using Spartane.Core.Domain.Pais;
using Spartane.Core.Domain.Detalle_Suscripciones_Empresa;


using Spartane.Core.Domain.Planes_de_Suscripcion;



using Spartane.Core.Domain.Frecuencia_de_pago_Empresas;

using Spartane.Core.Domain.Estatus_de_Suscripcion;

using Spartane.Core.Domain.Detalle_Pagos_Empresa;

using Spartane.Core.Domain.Planes_de_Suscripcion;






using Spartane.Core.Domain.Formas_de_Pago;

using Spartane.Core.Domain.Estatus_de_Pago;

using Spartane.Core.Domain.Detalle_Registro_Beneficiarios_Empresa;


using Spartane.Core.Domain.Spartan_User;






using Spartane.Core.Domain.Planes_de_Suscripcion;

using Spartane.Core.Domain.Estatus;

using Spartane.Core.Domain.Detalle_Contratos_Empresa;

using Spartane.Core.Domain.Planes_de_Suscripcion;
using Spartane.Core.Domain.Tipos_de_Contrato;




using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Empresas;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Empresas;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Tipos_de_Empresa;
using Spartane.Web.Areas.WebApiConsumer.Estado;
using Spartane.Web.Areas.WebApiConsumer.Pais;
using Spartane.Web.Areas.WebApiConsumer.Estatus;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Contactos_Empresa;


using Spartane.Web.Areas.WebApiConsumer.areas_Empresas;


using Spartane.Web.Areas.WebApiConsumer.Estatus;

using Spartane.Web.Areas.WebApiConsumer.Regimenes_Fiscales;
using Spartane.Web.Areas.WebApiConsumer.Estado;
using Spartane.Web.Areas.WebApiConsumer.Pais;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Suscripciones_Empresa;

using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion;


using Spartane.Web.Areas.WebApiConsumer.Frecuencia_de_pago_Empresas;

using Spartane.Web.Areas.WebApiConsumer.Estatus_de_Suscripcion;

using Spartane.Web.Areas.WebApiConsumer.Detalle_Pagos_Empresa;

using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion;


using Spartane.Web.Areas.WebApiConsumer.Formas_de_Pago;

using Spartane.Web.Areas.WebApiConsumer.Estatus_de_Pago;

using Spartane.Web.Areas.WebApiConsumer.Detalle_Registro_Beneficiarios_Empresa;

using Spartane.Web.Areas.WebApiConsumer.Spartan_User;

using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion;
using Spartane.Web.Areas.WebApiConsumer.Estatus;

using Spartane.Web.Areas.WebApiConsumer.Detalle_Contratos_Empresa;

using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion;
using Spartane.Web.Areas.WebApiConsumer.Tipos_de_Contrato;




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
    public class EmpresasController : Controller
    {
        #region "variable declaration"

        private IEmpresasService service = null;
        private IEmpresasApiConsumer _IEmpresasApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private ITipos_de_EmpresaApiConsumer _ITipos_de_EmpresaApiConsumer;
        private IEstadoApiConsumer _IEstadoApiConsumer;
        private IPaisApiConsumer _IPaisApiConsumer;
        private IEstatusApiConsumer _IEstatusApiConsumer;
        private IDetalle_Contactos_EmpresaApiConsumer _IDetalle_Contactos_EmpresaApiConsumer;


        private Iareas_EmpresasApiConsumer _Iareas_EmpresasApiConsumer;



        private IRegimenes_FiscalesApiConsumer _IRegimenes_FiscalesApiConsumer;
        private IDetalle_Suscripciones_EmpresaApiConsumer _IDetalle_Suscripciones_EmpresaApiConsumer;

        private IPlanes_de_SuscripcionApiConsumer _IPlanes_de_SuscripcionApiConsumer;


        private IFrecuencia_de_pago_EmpresasApiConsumer _IFrecuencia_de_pago_EmpresasApiConsumer;

        private IEstatus_de_SuscripcionApiConsumer _IEstatus_de_SuscripcionApiConsumer;

        private IDetalle_Pagos_EmpresaApiConsumer _IDetalle_Pagos_EmpresaApiConsumer;



        private IFormas_de_PagoApiConsumer _IFormas_de_PagoApiConsumer;

        private IEstatus_de_PagoApiConsumer _IEstatus_de_PagoApiConsumer;

        private IDetalle_Registro_Beneficiarios_EmpresaApiConsumer _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer;



        private IDetalle_Contratos_EmpresaApiConsumer _IDetalle_Contratos_EmpresaApiConsumer;

        private ITipos_de_ContratoApiConsumer _ITipos_de_ContratoApiConsumer;




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

        
        public EmpresasController(IEmpresasService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IEmpresasApiConsumer EmpresasApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , ITipos_de_EmpresaApiConsumer Tipos_de_EmpresaApiConsumer , IEstadoApiConsumer EstadoApiConsumer , IPaisApiConsumer PaisApiConsumer , IEstatusApiConsumer EstatusApiConsumer , IDetalle_Contactos_EmpresaApiConsumer Detalle_Contactos_EmpresaApiConsumer , Iareas_EmpresasApiConsumer areas_EmpresasApiConsumer  , IRegimenes_FiscalesApiConsumer Regimenes_FiscalesApiConsumer , IDetalle_Suscripciones_EmpresaApiConsumer Detalle_Suscripciones_EmpresaApiConsumer , IPlanes_de_SuscripcionApiConsumer Planes_de_SuscripcionApiConsumer , IFrecuencia_de_pago_EmpresasApiConsumer Frecuencia_de_pago_EmpresasApiConsumer , IEstatus_de_SuscripcionApiConsumer Estatus_de_SuscripcionApiConsumer  , IDetalle_Pagos_EmpresaApiConsumer Detalle_Pagos_EmpresaApiConsumer , IFormas_de_PagoApiConsumer Formas_de_PagoApiConsumer , IEstatus_de_PagoApiConsumer Estatus_de_PagoApiConsumer  , IDetalle_Registro_Beneficiarios_EmpresaApiConsumer Detalle_Registro_Beneficiarios_EmpresaApiConsumer  , IDetalle_Contratos_EmpresaApiConsumer Detalle_Contratos_EmpresaApiConsumer , ITipos_de_ContratoApiConsumer Tipos_de_ContratoApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IEmpresasApiConsumer = EmpresasApiConsumer;
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
            this._ITipos_de_EmpresaApiConsumer = Tipos_de_EmpresaApiConsumer;
            this._IEstadoApiConsumer = EstadoApiConsumer;
            this._IPaisApiConsumer = PaisApiConsumer;
            this._IEstatusApiConsumer = EstatusApiConsumer;
            this._IDetalle_Contactos_EmpresaApiConsumer = Detalle_Contactos_EmpresaApiConsumer;


            this._Iareas_EmpresasApiConsumer = areas_EmpresasApiConsumer;


            this._IEstatusApiConsumer = EstatusApiConsumer;

            this._IRegimenes_FiscalesApiConsumer = Regimenes_FiscalesApiConsumer;
            this._IEstadoApiConsumer = EstadoApiConsumer;
            this._IPaisApiConsumer = PaisApiConsumer;
            this._IDetalle_Suscripciones_EmpresaApiConsumer = Detalle_Suscripciones_EmpresaApiConsumer;

            this._IPlanes_de_SuscripcionApiConsumer = Planes_de_SuscripcionApiConsumer;


            this._IFrecuencia_de_pago_EmpresasApiConsumer = Frecuencia_de_pago_EmpresasApiConsumer;

            this._IEstatus_de_SuscripcionApiConsumer = Estatus_de_SuscripcionApiConsumer;

            this._IDetalle_Pagos_EmpresaApiConsumer = Detalle_Pagos_EmpresaApiConsumer;

            this._IPlanes_de_SuscripcionApiConsumer = Planes_de_SuscripcionApiConsumer;


            this._IFormas_de_PagoApiConsumer = Formas_de_PagoApiConsumer;

            this._IEstatus_de_PagoApiConsumer = Estatus_de_PagoApiConsumer;

            this._IDetalle_Registro_Beneficiarios_EmpresaApiConsumer = Detalle_Registro_Beneficiarios_EmpresaApiConsumer;

            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;

            this._IPlanes_de_SuscripcionApiConsumer = Planes_de_SuscripcionApiConsumer;
            this._IEstatusApiConsumer = EstatusApiConsumer;

            this._IDetalle_Contratos_EmpresaApiConsumer = Detalle_Contratos_EmpresaApiConsumer;

            this._IPlanes_de_SuscripcionApiConsumer = Planes_de_SuscripcionApiConsumer;
            this._ITipos_de_ContratoApiConsumer = Tipos_de_ContratoApiConsumer;




        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Empresas
        [ObjectAuth(ObjectId = (ModuleObjectId)44282, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44282, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Empresas/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)44282, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44282, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varEmpresas = new EmpresasModel();
			varEmpresas.Folio = Id;
			
            ViewBag.ObjectId = "44282";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionDetalle_Contactos_Empresa = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44412, ModuleId);
            ViewBag.PermissionDetalle_Contactos_Empresa = permissionDetalle_Contactos_Empresa;
            var permissionDetalle_Suscripciones_Empresa = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44410, ModuleId);
            ViewBag.PermissionDetalle_Suscripciones_Empresa = permissionDetalle_Suscripciones_Empresa;
            var permissionDetalle_Pagos_Empresa = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44411, ModuleId);
            ViewBag.PermissionDetalle_Pagos_Empresa = permissionDetalle_Pagos_Empresa;
            var permissionDetalle_Registro_Beneficiarios_Empresa = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44459, ModuleId);
            ViewBag.PermissionDetalle_Registro_Beneficiarios_Empresa = permissionDetalle_Registro_Beneficiarios_Empresa;
            var permissionDetalle_Contratos_Empresa = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44413, ModuleId);
            ViewBag.PermissionDetalle_Contratos_Empresa = permissionDetalle_Contratos_Empresa;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var EmpresassData = _IEmpresasApiConsumer.ListaSelAll(0, 1000, "Empresas.Folio=" + Id, "").Resource.Empresass;
				
				if (EmpresassData != null && EmpresassData.Count > 0)
                {
					var EmpresasData = EmpresassData.First();
					varEmpresas= new EmpresasModel
					{
						Folio  = EmpresasData.Folio 
	                    ,Fecha_de_Registro = (EmpresasData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(EmpresasData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = EmpresasData.Hora_de_Registro
                    ,Usuario_que_Registra = EmpresasData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(EmpresasData.Usuario_que_Registra), "Spartan_User") ??  (string)EmpresasData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre_de_la_Empresa = EmpresasData.Nombre_de_la_Empresa
                    ,Tipo_de_Empresa = EmpresasData.Tipo_de_Empresa
                    ,Tipo_de_EmpresaDescripcion = CultureHelper.GetTraduction(Convert.ToString(EmpresasData.Tipo_de_Empresa), "Tipos_de_Empresa") ??  (string)EmpresasData.Tipo_de_Empresa_Tipos_de_Empresa.Descripcion
                    ,Email = EmpresasData.Email
                    ,Telefono = EmpresasData.Telefono
                    ,Calle = EmpresasData.Calle
                    ,Numero_exterior = EmpresasData.Numero_exterior
                    ,Numero_interior = EmpresasData.Numero_interior
                    ,Colonia = EmpresasData.Colonia
                    ,CP = EmpresasData.CP
                    ,Ciudad = EmpresasData.Ciudad
                    ,Estado = EmpresasData.Estado
                    ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(EmpresasData.Estado), "Estado") ??  (string)EmpresasData.Estado_Estado.Nombre_del_Estado
                    ,Pais = EmpresasData.Pais
                    ,PaisNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(EmpresasData.Pais), "Pais") ??  (string)EmpresasData.Pais_Pais.Nombre_del_Pais
                    ,Estatus = EmpresasData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(EmpresasData.Estatus), "Estatus") ??  (string)EmpresasData.Estatus_Estatus.Descripcion
                    ,Regimen_Fiscal = EmpresasData.Regimen_Fiscal
                    ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(Convert.ToString(EmpresasData.Regimen_Fiscal), "Regimenes_Fiscales") ??  (string)EmpresasData.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
                    ,Nombre_o_Razon_Social = EmpresasData.Nombre_o_Razon_Social
                    ,RFC = EmpresasData.RFC
                    ,Calle_Fiscal = EmpresasData.Calle_Fiscal
                    ,Numero_exterior_Fiscal = EmpresasData.Numero_exterior_Fiscal
                    ,Numero_interior_Fiscal = EmpresasData.Numero_interior_Fiscal
                    ,Colonia_Fiscal = EmpresasData.Colonia_Fiscal
                    ,CP_Fiscal = EmpresasData.CP_Fiscal
                    ,Ciudad_Fiscal = EmpresasData.Ciudad_Fiscal
                    ,Estado_Fiscal = EmpresasData.Estado_Fiscal
                    ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(EmpresasData.Estado_Fiscal), "Estado") ??  (string)EmpresasData.Estado_Fiscal_Estado.Nombre_del_Estado
                    ,Pais_Fiscal = EmpresasData.Pais_Fiscal
                    ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(EmpresasData.Pais_Fiscal), "Pais") ??  (string)EmpresasData.Pais_Fiscal_Pais.Nombre_del_Pais
                    ,Telefono_Fiscal = EmpresasData.Telefono_Fiscal
                    ,Fax = EmpresasData.Fax
                    ,Nombres_del_Representante_Legal = EmpresasData.Nombres_del_Representante_Legal
                    ,Apellido_Paterno_del_Representante_Legal = EmpresasData.Apellido_Paterno_del_Representante_Legal
                    ,Apellido_Materno_del_Representante_Legal = EmpresasData.Apellido_Materno_del_Representante_Legal
                    ,Nombre_Completo_del_Representante_Legal = EmpresasData.Nombre_Completo_del_Representante_Legal
                    ,Cedula_Fiscal = EmpresasData.Cedula_Fiscal

					};
				}
				
				                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Cedula_FiscalSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varEmpresas.Cedula_Fiscal).Resource;

				
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
            _ITipos_de_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipos_de_Empresas_Tipo_de_Empresa = _ITipos_de_EmpresaApiConsumer.SelAll(true);
            if (Tipos_de_Empresas_Tipo_de_Empresa != null && Tipos_de_Empresas_Tipo_de_Empresa.Resource != null)
                ViewBag.Tipos_de_Empresas_Tipo_de_Empresa = Tipos_de_Empresas_Tipo_de_Empresa.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipos_de_Empresa", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado != null && Estados_Estado.Resource != null)
                ViewBag.Estados_Estado = Estados_Estado.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais != null && Paiss_Pais.Resource != null)
                ViewBag.Paiss_Pais = Paiss_Pais.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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

				
            return View(varEmpresas);
        }
		
	[HttpGet]
        public ActionResult AddEmpresas(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44282);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
			EmpresasModel varEmpresas= new EmpresasModel();
            var permissionDetalle_Contactos_Empresa = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44412, ModuleId);
            ViewBag.PermissionDetalle_Contactos_Empresa = permissionDetalle_Contactos_Empresa;
            var permissionDetalle_Suscripciones_Empresa = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44410, ModuleId);
            ViewBag.PermissionDetalle_Suscripciones_Empresa = permissionDetalle_Suscripciones_Empresa;
            var permissionDetalle_Pagos_Empresa = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44411, ModuleId);
            ViewBag.PermissionDetalle_Pagos_Empresa = permissionDetalle_Pagos_Empresa;
            var permissionDetalle_Registro_Beneficiarios_Empresa = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44459, ModuleId);
            ViewBag.PermissionDetalle_Registro_Beneficiarios_Empresa = permissionDetalle_Registro_Beneficiarios_Empresa;
            var permissionDetalle_Contratos_Empresa = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44413, ModuleId);
            ViewBag.PermissionDetalle_Contratos_Empresa = permissionDetalle_Contratos_Empresa;


            if (id.ToString() != "0")
            {
                var EmpresassData = _IEmpresasApiConsumer.ListaSelAll(0, 1000, "Empresas.Folio=" + id, "").Resource.Empresass;
				
				if (EmpresassData != null && EmpresassData.Count > 0)
                {
					var EmpresasData = EmpresassData.First();
					varEmpresas= new EmpresasModel
					{
						Folio  = EmpresasData.Folio 
	                    ,Fecha_de_Registro = (EmpresasData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(EmpresasData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = EmpresasData.Hora_de_Registro
                    ,Usuario_que_Registra = EmpresasData.Usuario_que_Registra
                    ,Usuario_que_RegistraName = CultureHelper.GetTraduction(Convert.ToString(EmpresasData.Usuario_que_Registra), "Spartan_User") ??  (string)EmpresasData.Usuario_que_Registra_Spartan_User.Name
                    ,Nombre_de_la_Empresa = EmpresasData.Nombre_de_la_Empresa
                    ,Tipo_de_Empresa = EmpresasData.Tipo_de_Empresa
                    ,Tipo_de_EmpresaDescripcion = CultureHelper.GetTraduction(Convert.ToString(EmpresasData.Tipo_de_Empresa), "Tipos_de_Empresa") ??  (string)EmpresasData.Tipo_de_Empresa_Tipos_de_Empresa.Descripcion
                    ,Email = EmpresasData.Email
                    ,Telefono = EmpresasData.Telefono
                    ,Calle = EmpresasData.Calle
                    ,Numero_exterior = EmpresasData.Numero_exterior
                    ,Numero_interior = EmpresasData.Numero_interior
                    ,Colonia = EmpresasData.Colonia
                    ,CP = EmpresasData.CP
                    ,Ciudad = EmpresasData.Ciudad
                    ,Estado = EmpresasData.Estado
                    ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(EmpresasData.Estado), "Estado") ??  (string)EmpresasData.Estado_Estado.Nombre_del_Estado
                    ,Pais = EmpresasData.Pais
                    ,PaisNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(EmpresasData.Pais), "Pais") ??  (string)EmpresasData.Pais_Pais.Nombre_del_Pais
                    ,Estatus = EmpresasData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(EmpresasData.Estatus), "Estatus") ??  (string)EmpresasData.Estatus_Estatus.Descripcion
                    ,Regimen_Fiscal = EmpresasData.Regimen_Fiscal
                    ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(Convert.ToString(EmpresasData.Regimen_Fiscal), "Regimenes_Fiscales") ??  (string)EmpresasData.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
                    ,Nombre_o_Razon_Social = EmpresasData.Nombre_o_Razon_Social
                    ,RFC = EmpresasData.RFC
                    ,Calle_Fiscal = EmpresasData.Calle_Fiscal
                    ,Numero_exterior_Fiscal = EmpresasData.Numero_exterior_Fiscal
                    ,Numero_interior_Fiscal = EmpresasData.Numero_interior_Fiscal
                    ,Colonia_Fiscal = EmpresasData.Colonia_Fiscal
                    ,CP_Fiscal = EmpresasData.CP_Fiscal
                    ,Ciudad_Fiscal = EmpresasData.Ciudad_Fiscal
                    ,Estado_Fiscal = EmpresasData.Estado_Fiscal
                    ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(Convert.ToString(EmpresasData.Estado_Fiscal), "Estado") ??  (string)EmpresasData.Estado_Fiscal_Estado.Nombre_del_Estado
                    ,Pais_Fiscal = EmpresasData.Pais_Fiscal
                    ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(Convert.ToString(EmpresasData.Pais_Fiscal), "Pais") ??  (string)EmpresasData.Pais_Fiscal_Pais.Nombre_del_Pais
                    ,Telefono_Fiscal = EmpresasData.Telefono_Fiscal
                    ,Fax = EmpresasData.Fax
                    ,Nombres_del_Representante_Legal = EmpresasData.Nombres_del_Representante_Legal
                    ,Apellido_Paterno_del_Representante_Legal = EmpresasData.Apellido_Paterno_del_Representante_Legal
                    ,Apellido_Materno_del_Representante_Legal = EmpresasData.Apellido_Materno_del_Representante_Legal
                    ,Nombre_Completo_del_Representante_Legal = EmpresasData.Nombre_Completo_del_Representante_Legal
                    ,Cedula_Fiscal = EmpresasData.Cedula_Fiscal

					};
				}
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Cedula_FiscalSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varEmpresas.Cedula_Fiscal).Resource;

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
            _ITipos_de_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipos_de_Empresas_Tipo_de_Empresa = _ITipos_de_EmpresaApiConsumer.SelAll(true);
            if (Tipos_de_Empresas_Tipo_de_Empresa != null && Tipos_de_Empresas_Tipo_de_Empresa.Resource != null)
                ViewBag.Tipos_de_Empresas_Tipo_de_Empresa = Tipos_de_Empresas_Tipo_de_Empresa.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipos_de_Empresa", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado != null && Estados_Estado.Resource != null)
                ViewBag.Estados_Estado = Estados_Estado.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais != null && Paiss_Pais.Resource != null)
                ViewBag.Paiss_Pais = Paiss_Pais.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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


            return PartialView("AddEmpresas", varEmpresas);
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
        public ActionResult GetTipos_de_EmpresaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipos_de_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipos_de_EmpresaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipos_de_Empresa", "Descripcion")?? m.Descripcion,
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
        public ActionResult ShowAdvanceFilter(EmpresasAdvanceSearchModel model, int idFilter = -1)
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
            _ITipos_de_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipos_de_Empresas_Tipo_de_Empresa = _ITipos_de_EmpresaApiConsumer.SelAll(true);
            if (Tipos_de_Empresas_Tipo_de_Empresa != null && Tipos_de_Empresas_Tipo_de_Empresa.Resource != null)
                ViewBag.Tipos_de_Empresas_Tipo_de_Empresa = Tipos_de_Empresas_Tipo_de_Empresa.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipos_de_Empresa", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado != null && Estados_Estado.Resource != null)
                ViewBag.Estados_Estado = Estados_Estado.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais != null && Paiss_Pais.Resource != null)
                ViewBag.Paiss_Pais = Paiss_Pais.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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
            _ITipos_de_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipos_de_Empresas_Tipo_de_Empresa = _ITipos_de_EmpresaApiConsumer.SelAll(true);
            if (Tipos_de_Empresas_Tipo_de_Empresa != null && Tipos_de_Empresas_Tipo_de_Empresa.Resource != null)
                ViewBag.Tipos_de_Empresas_Tipo_de_Empresa = Tipos_de_Empresas_Tipo_de_Empresa.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipos_de_Empresa", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstadoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estados_Estado = _IEstadoApiConsumer.SelAll(true);
            if (Estados_Estado != null && Estados_Estado.Resource != null)
                ViewBag.Estados_Estado = Estados_Estado.Resource.Where(m => m.Nombre_del_Estado != null).OrderBy(m => m.Nombre_del_Estado).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estado", "Nombre_del_Estado") ?? m.Nombre_del_Estado.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPaisApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Paiss_Pais = _IPaisApiConsumer.SelAll(true);
            if (Paiss_Pais != null && Paiss_Pais.Resource != null)
                ViewBag.Paiss_Pais = Paiss_Pais.Resource.Where(m => m.Nombre_del_Pais != null).OrderBy(m => m.Nombre_del_Pais).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Pais", "Nombre_del_Pais") ?? m.Nombre_del_Pais.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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


            var previousFiltersObj = new EmpresasAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (EmpresasAdvanceSearchModel)(Session["AdvanceSearch"] ?? new EmpresasAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new EmpresasPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IEmpresasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Empresass == null)
                result.Empresass = new List<Empresas>();

            return Json(new
            {
                data = result.Empresass.Select(m => new EmpresasGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_la_Empresa = m.Nombre_de_la_Empresa
                        ,Tipo_de_EmpresaDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Empresa_Tipos_de_Empresa.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Empresa_Tipos_de_Empresa.Descripcion
			,Email = m.Email
			,Telefono = m.Telefono
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
                        ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(m.Regimen_Fiscal_Regimenes_Fiscales.Clave.ToString(), "Descripcion") ?? (string)m.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
			,Nombre_o_Razon_Social = m.Nombre_o_Razon_Social
			,RFC = m.RFC
			,Calle_Fiscal = m.Calle_Fiscal
			,Numero_exterior_Fiscal = m.Numero_exterior_Fiscal
			,Numero_interior_Fiscal = m.Numero_interior_Fiscal
			,Colonia_Fiscal = m.Colonia_Fiscal
			,CP_Fiscal = m.CP_Fiscal
			,Ciudad_Fiscal = m.Ciudad_Fiscal
                        ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Fiscal_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Fiscal_Estado.Nombre_del_Estado
                        ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Fiscal_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Fiscal_Pais.Nombre_del_Pais
			,Telefono_Fiscal = m.Telefono_Fiscal
			,Fax = m.Fax
			,Nombres_del_Representante_Legal = m.Nombres_del_Representante_Legal
			,Apellido_Paterno_del_Representante_Legal = m.Apellido_Paterno_del_Representante_Legal
			,Apellido_Materno_del_Representante_Legal = m.Apellido_Materno_del_Representante_Legal
			,Nombre_Completo_del_Representante_Legal = m.Nombre_Completo_del_Representante_Legal
			,Cedula_Fiscal = m.Cedula_Fiscal

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }
		/*
		 [HttpGet]
        public ActionResult GetEmpresasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEmpresasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraductionNew(Convert.ToString(m.Folio), "Empresas", m.),
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
        /// Get List of Empresas from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Empresas Entity</returns>
        public ActionResult GetEmpresasList(UrlParametersModel param)
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
            _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new EmpresasPropertyMapper());
				
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
				if (Session["AdvanceSearch"].GetType() == typeof(EmpresasAdvanceSearchModel))
                {
					var advanceFilter =
                    (EmpresasAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            EmpresasPropertyMapper oEmpresasPropertyMapper = new EmpresasPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oEmpresasPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IEmpresasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Empresass == null)
                result.Empresass = new List<Empresas>();

            return Json(new
            {
                aaData = result.Empresass.Select(m => new EmpresasGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_la_Empresa = m.Nombre_de_la_Empresa
                        ,Tipo_de_EmpresaDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Empresa_Tipos_de_Empresa.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Empresa_Tipos_de_Empresa.Descripcion
			,Email = m.Email
			,Telefono = m.Telefono
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
                        ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(m.Regimen_Fiscal_Regimenes_Fiscales.Clave.ToString(), "Descripcion") ?? (string)m.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
			,Nombre_o_Razon_Social = m.Nombre_o_Razon_Social
			,RFC = m.RFC
			,Calle_Fiscal = m.Calle_Fiscal
			,Numero_exterior_Fiscal = m.Numero_exterior_Fiscal
			,Numero_interior_Fiscal = m.Numero_interior_Fiscal
			,Colonia_Fiscal = m.Colonia_Fiscal
			,CP_Fiscal = m.CP_Fiscal
			,Ciudad_Fiscal = m.Ciudad_Fiscal
                        ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Fiscal_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Fiscal_Estado.Nombre_del_Estado
                        ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Fiscal_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Fiscal_Pais.Nombre_del_Pais
			,Telefono_Fiscal = m.Telefono_Fiscal
			,Fax = m.Fax
			,Nombres_del_Representante_Legal = m.Nombres_del_Representante_Legal
			,Apellido_Paterno_del_Representante_Legal = m.Apellido_Paterno_del_Representante_Legal
			,Apellido_Materno_del_Representante_Legal = m.Apellido_Materno_del_Representante_Legal
			,Nombre_Completo_del_Representante_Legal = m.Nombre_Completo_del_Representante_Legal
			,Cedula_Fiscal = m.Cedula_Fiscal

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete

//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(EmpresasAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Empresas.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Empresas.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Empresas.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Empresas.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Empresas.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Empresas.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
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

                where += " AND Empresas.Usuario_que_Registra In (" + Usuario_que_RegistraIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombre_de_la_Empresa))
            {
                switch (filter.Nombre_de_la_EmpresaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Nombre_de_la_Empresa LIKE '" + filter.Nombre_de_la_Empresa + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Nombre_de_la_Empresa LIKE '%" + filter.Nombre_de_la_Empresa + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Nombre_de_la_Empresa = '" + filter.Nombre_de_la_Empresa + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Nombre_de_la_Empresa LIKE '%" + filter.Nombre_de_la_Empresa + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceTipo_de_Empresa))
            {
                switch (filter.Tipo_de_EmpresaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Tipos_de_Empresa.Descripcion LIKE '" + filter.AdvanceTipo_de_Empresa + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Tipos_de_Empresa.Descripcion LIKE '%" + filter.AdvanceTipo_de_Empresa + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Tipos_de_Empresa.Descripcion = '" + filter.AdvanceTipo_de_Empresa + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Tipos_de_Empresa.Descripcion LIKE '%" + filter.AdvanceTipo_de_Empresa + "%'";
                        break;
                }
            }
            else if (filter.AdvanceTipo_de_EmpresaMultiple != null && filter.AdvanceTipo_de_EmpresaMultiple.Count() > 0)
            {
                var Tipo_de_EmpresaIds = string.Join(",", filter.AdvanceTipo_de_EmpresaMultiple);

                where += " AND Empresas.Tipo_de_Empresa In (" + Tipo_de_EmpresaIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Email))
            {
                switch (filter.EmailFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Email LIKE '" + filter.Email + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Email LIKE '%" + filter.Email + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Email = '" + filter.Email + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Email LIKE '%" + filter.Email + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Telefono))
            {
                switch (filter.TelefonoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Telefono LIKE '" + filter.Telefono + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Telefono LIKE '%" + filter.Telefono + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Telefono = '" + filter.Telefono + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Telefono LIKE '%" + filter.Telefono + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Calle))
            {
                switch (filter.CalleFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Calle LIKE '" + filter.Calle + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Calle LIKE '%" + filter.Calle + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Calle = '" + filter.Calle + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Calle LIKE '%" + filter.Calle + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Numero_exterior))
            {
                switch (filter.Numero_exteriorFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Numero_exterior LIKE '" + filter.Numero_exterior + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Numero_exterior LIKE '%" + filter.Numero_exterior + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Numero_exterior = '" + filter.Numero_exterior + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Numero_exterior LIKE '%" + filter.Numero_exterior + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Numero_interior))
            {
                switch (filter.Numero_interiorFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Numero_interior LIKE '" + filter.Numero_interior + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Numero_interior LIKE '%" + filter.Numero_interior + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Numero_interior = '" + filter.Numero_interior + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Numero_interior LIKE '%" + filter.Numero_interior + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Colonia))
            {
                switch (filter.ColoniaFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Colonia LIKE '" + filter.Colonia + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Colonia LIKE '%" + filter.Colonia + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Colonia = '" + filter.Colonia + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Colonia LIKE '%" + filter.Colonia + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromCP) || !string.IsNullOrEmpty(filter.ToCP))
            {
                if (!string.IsNullOrEmpty(filter.FromCP))
                    where += " AND Empresas.CP >= " + filter.FromCP;
                if (!string.IsNullOrEmpty(filter.ToCP))
                    where += " AND Empresas.CP <= " + filter.ToCP;
            }

            if (!string.IsNullOrEmpty(filter.Ciudad))
            {
                switch (filter.CiudadFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Ciudad LIKE '" + filter.Ciudad + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Ciudad LIKE '%" + filter.Ciudad + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Ciudad = '" + filter.Ciudad + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Ciudad LIKE '%" + filter.Ciudad + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEstado))
            {
                switch (filter.EstadoFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estado.Nombre_del_Estado LIKE '" + filter.AdvanceEstado + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estado.Nombre_del_Estado LIKE '%" + filter.AdvanceEstado + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estado.Nombre_del_Estado = '" + filter.AdvanceEstado + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estado.Nombre_del_Estado LIKE '%" + filter.AdvanceEstado + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEstadoMultiple != null && filter.AdvanceEstadoMultiple.Count() > 0)
            {
                var EstadoIds = string.Join(",", filter.AdvanceEstadoMultiple);

                where += " AND Empresas.Estado In (" + EstadoIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvancePais))
            {
                switch (filter.PaisFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Pais.Nombre_del_Pais LIKE '" + filter.AdvancePais + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Pais.Nombre_del_Pais LIKE '%" + filter.AdvancePais + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Pais.Nombre_del_Pais = '" + filter.AdvancePais + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Pais.Nombre_del_Pais LIKE '%" + filter.AdvancePais + "%'";
                        break;
                }
            }
            else if (filter.AdvancePaisMultiple != null && filter.AdvancePaisMultiple.Count() > 0)
            {
                var PaisIds = string.Join(",", filter.AdvancePaisMultiple);

                where += " AND Empresas.Pais In (" + PaisIds + ")";
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

                where += " AND Empresas.Estatus In (" + EstatusIds + ")";
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

                where += " AND Empresas.Regimen_Fiscal In (" + Regimen_FiscalIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Nombre_o_Razon_Social))
            {
                switch (filter.Nombre_o_Razon_SocialFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Nombre_o_Razon_Social LIKE '" + filter.Nombre_o_Razon_Social + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Nombre_o_Razon_Social LIKE '%" + filter.Nombre_o_Razon_Social + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Nombre_o_Razon_Social = '" + filter.Nombre_o_Razon_Social + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Nombre_o_Razon_Social LIKE '%" + filter.Nombre_o_Razon_Social + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.RFC))
            {
                switch (filter.RFCFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.RFC LIKE '" + filter.RFC + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.RFC LIKE '%" + filter.RFC + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.RFC = '" + filter.RFC + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.RFC LIKE '%" + filter.RFC + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Calle_Fiscal))
            {
                switch (filter.Calle_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Calle_Fiscal LIKE '" + filter.Calle_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Calle_Fiscal LIKE '%" + filter.Calle_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Calle_Fiscal = '" + filter.Calle_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Calle_Fiscal LIKE '%" + filter.Calle_Fiscal + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Numero_exterior_Fiscal))
            {
                switch (filter.Numero_exterior_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Numero_exterior_Fiscal LIKE '" + filter.Numero_exterior_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Numero_exterior_Fiscal LIKE '%" + filter.Numero_exterior_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Numero_exterior_Fiscal = '" + filter.Numero_exterior_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Numero_exterior_Fiscal LIKE '%" + filter.Numero_exterior_Fiscal + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Numero_interior_Fiscal))
            {
                switch (filter.Numero_interior_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Numero_interior_Fiscal LIKE '" + filter.Numero_interior_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Numero_interior_Fiscal LIKE '%" + filter.Numero_interior_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Numero_interior_Fiscal = '" + filter.Numero_interior_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Numero_interior_Fiscal LIKE '%" + filter.Numero_interior_Fiscal + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Colonia_Fiscal))
            {
                switch (filter.Colonia_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Colonia_Fiscal LIKE '" + filter.Colonia_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Colonia_Fiscal LIKE '%" + filter.Colonia_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Colonia_Fiscal = '" + filter.Colonia_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Colonia_Fiscal LIKE '%" + filter.Colonia_Fiscal + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.FromCP_Fiscal) || !string.IsNullOrEmpty(filter.ToCP_Fiscal))
            {
                if (!string.IsNullOrEmpty(filter.FromCP_Fiscal))
                    where += " AND Empresas.CP_Fiscal >= " + filter.FromCP_Fiscal;
                if (!string.IsNullOrEmpty(filter.ToCP_Fiscal))
                    where += " AND Empresas.CP_Fiscal <= " + filter.ToCP_Fiscal;
            }

            if (!string.IsNullOrEmpty(filter.Ciudad_Fiscal))
            {
                switch (filter.Ciudad_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Ciudad_Fiscal LIKE '" + filter.Ciudad_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Ciudad_Fiscal LIKE '%" + filter.Ciudad_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Ciudad_Fiscal = '" + filter.Ciudad_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Ciudad_Fiscal LIKE '%" + filter.Ciudad_Fiscal + "%'";
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

                where += " AND Empresas.Estado_Fiscal In (" + Estado_FiscalIds + ")";
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

                where += " AND Empresas.Pais_Fiscal In (" + Pais_FiscalIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Telefono_Fiscal))
            {
                switch (filter.Telefono_FiscalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Telefono_Fiscal LIKE '" + filter.Telefono_Fiscal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Telefono_Fiscal LIKE '%" + filter.Telefono_Fiscal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Telefono_Fiscal = '" + filter.Telefono_Fiscal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Telefono_Fiscal LIKE '%" + filter.Telefono_Fiscal + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Fax))
            {
                switch (filter.FaxFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Fax LIKE '" + filter.Fax + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Fax LIKE '%" + filter.Fax + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Fax = '" + filter.Fax + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Fax LIKE '%" + filter.Fax + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Nombres_del_Representante_Legal))
            {
                switch (filter.Nombres_del_Representante_LegalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Nombres_del_Representante_Legal LIKE '" + filter.Nombres_del_Representante_Legal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Nombres_del_Representante_Legal LIKE '%" + filter.Nombres_del_Representante_Legal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Nombres_del_Representante_Legal = '" + filter.Nombres_del_Representante_Legal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Nombres_del_Representante_Legal LIKE '%" + filter.Nombres_del_Representante_Legal + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Apellido_Paterno_del_Representante_Legal))
            {
                switch (filter.Apellido_Paterno_del_Representante_LegalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Apellido_Paterno_del_Representante_Legal LIKE '" + filter.Apellido_Paterno_del_Representante_Legal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Apellido_Paterno_del_Representante_Legal LIKE '%" + filter.Apellido_Paterno_del_Representante_Legal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Apellido_Paterno_del_Representante_Legal = '" + filter.Apellido_Paterno_del_Representante_Legal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Apellido_Paterno_del_Representante_Legal LIKE '%" + filter.Apellido_Paterno_del_Representante_Legal + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Apellido_Materno_del_Representante_Legal))
            {
                switch (filter.Apellido_Materno_del_Representante_LegalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Apellido_Materno_del_Representante_Legal LIKE '" + filter.Apellido_Materno_del_Representante_Legal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Apellido_Materno_del_Representante_Legal LIKE '%" + filter.Apellido_Materno_del_Representante_Legal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Apellido_Materno_del_Representante_Legal = '" + filter.Apellido_Materno_del_Representante_Legal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Apellido_Materno_del_Representante_Legal LIKE '%" + filter.Apellido_Materno_del_Representante_Legal + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Nombre_Completo_del_Representante_Legal))
            {
                switch (filter.Nombre_Completo_del_Representante_LegalFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Empresas.Nombre_Completo_del_Representante_Legal LIKE '" + filter.Nombre_Completo_del_Representante_Legal + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Empresas.Nombre_Completo_del_Representante_Legal LIKE '%" + filter.Nombre_Completo_del_Representante_Legal + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Empresas.Nombre_Completo_del_Representante_Legal = '" + filter.Nombre_Completo_del_Representante_Legal + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Empresas.Nombre_Completo_del_Representante_Legal LIKE '%" + filter.Nombre_Completo_del_Representante_Legal + "%'";
                        break;
                }
            }

            if (filter.Cedula_Fiscal != RadioOptions.NoApply)
                where += " AND Empresas.Cedula_Fiscal " + (filter.Cedula_Fiscal == RadioOptions.Yes ? ">" : "==") + " 0";


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

        public ActionResult GetDetalle_Contactos_Empresa(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Contactos_EmpresaGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Contactos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Contactos_Empresa.Folio_Empresas=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Contactos_Empresa.Folio_Empresas='" + RelationId + "'";
            }
            var result = _IDetalle_Contactos_EmpresaApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Contactos_Empresas == null)
                result.Detalle_Contactos_Empresas = new List<Detalle_Contactos_Empresa>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Contactos_Empresas.Select(m => new Detalle_Contactos_EmpresaGridModel
                {
                    Folio = m.Folio

			,Nombre_completo = m.Nombre_completo
			,Correo = m.Correo
			,Telefono = m.Telefono
			,Contacto_Principal = m.Contacto_Principal
                        ,Area = m.Area
                        ,AreaNombre = CultureHelper.GetTraduction(m.Area_areas_Empresas.Clave.ToString(), "Nombre") ??(string)m.Area_areas_Empresas.Nombre
			,Acceso_al_Sistema = m.Acceso_al_Sistema
			,Nombre_de_usuario = m.Nombre_de_usuario
			,Recibe_Alertas = m.Recibe_Alertas
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus.Descripcion

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Contactos_EmpresaGridModel> GetDetalle_Contactos_EmpresaData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Contactos_EmpresaGridModel> resultData = new List<Detalle_Contactos_EmpresaGridModel>();
            string where = "Detalle_Contactos_Empresa.Folio_Empresas=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Contactos_Empresa.Folio_Empresas='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Contactos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Contactos_EmpresaApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Contactos_Empresas != null)
            {
                resultData = result.Detalle_Contactos_Empresas.Select(m => new Detalle_Contactos_EmpresaGridModel
                    {
                        Folio = m.Folio

			,Nombre_completo = m.Nombre_completo
			,Correo = m.Correo
			,Telefono = m.Telefono
			,Contacto_Principal = m.Contacto_Principal
                        ,Area = m.Area
                        ,AreaNombre = CultureHelper.GetTraduction(m.Area_areas_Empresas.Clave.ToString(), "Nombre") ??(string)m.Area_areas_Empresas.Nombre
			,Acceso_al_Sistema = m.Acceso_al_Sistema
			,Nombre_de_usuario = m.Nombre_de_usuario
			,Recibe_Alertas = m.Recibe_Alertas
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus.Descripcion


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Suscripciones_Empresa(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Suscripciones_EmpresaGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Suscripciones_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Suscripciones_Empresa.Folio_Empresas=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Suscripciones_Empresa.Folio_Empresas='" + RelationId + "'";
            }
            var result = _IDetalle_Suscripciones_EmpresaApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Suscripciones_Empresas == null)
                result.Detalle_Suscripciones_Empresas = new List<Detalle_Suscripciones_Empresa>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Suscripciones_Empresas.Select(m => new Detalle_Suscripciones_EmpresaGridModel
                {
                    Folio = m.Folio

			,Cantidad_de_Beneficiarios = m.Cantidad_de_Beneficiarios
                        ,Suscripcion = m.Suscripcion
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Nombre_del_Plan") ??(string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
			,Fecha_de_inicio = (m.Fecha_de_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_inicio).ToString(ConfigurationProperty.DateFormat))
			,Fecha_Fin = (m.Fecha_Fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_Fin).ToString(ConfigurationProperty.DateFormat))
			,Nombre_de_la_Suscripcion = m.Nombre_de_la_Suscripcion
                        ,Frecuencia_de_Pago = m.Frecuencia_de_Pago
                        ,Frecuencia_de_PagoNombre = CultureHelper.GetTraduction(m.Frecuencia_de_Pago_Frecuencia_de_pago_Empresas.Clave.ToString(), "Nombre") ??(string)m.Frecuencia_de_Pago_Frecuencia_de_pago_Empresas.Nombre
			,Costo = m.Costo
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_de_Suscripcion.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus_de_Suscripcion.Descripcion

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Suscripciones_EmpresaGridModel> GetDetalle_Suscripciones_EmpresaData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Suscripciones_EmpresaGridModel> resultData = new List<Detalle_Suscripciones_EmpresaGridModel>();
            string where = "Detalle_Suscripciones_Empresa.Folio_Empresas=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Suscripciones_Empresa.Folio_Empresas='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Suscripciones_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Suscripciones_EmpresaApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Suscripciones_Empresas != null)
            {
                resultData = result.Detalle_Suscripciones_Empresas.Select(m => new Detalle_Suscripciones_EmpresaGridModel
                    {
                        Folio = m.Folio

			,Cantidad_de_Beneficiarios = m.Cantidad_de_Beneficiarios
                        ,Suscripcion = m.Suscripcion
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Nombre_del_Plan") ??(string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
			,Fecha_de_inicio = (m.Fecha_de_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_inicio).ToString(ConfigurationProperty.DateFormat))
			,Fecha_Fin = (m.Fecha_Fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_Fin).ToString(ConfigurationProperty.DateFormat))
			,Nombre_de_la_Suscripcion = m.Nombre_de_la_Suscripcion
                        ,Frecuencia_de_Pago = m.Frecuencia_de_Pago
                        ,Frecuencia_de_PagoNombre = CultureHelper.GetTraduction(m.Frecuencia_de_Pago_Frecuencia_de_pago_Empresas.Clave.ToString(), "Nombre") ??(string)m.Frecuencia_de_Pago_Frecuencia_de_pago_Empresas.Nombre
			,Costo = m.Costo
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_de_Suscripcion.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus_de_Suscripcion.Descripcion


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Pagos_Empresa(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Pagos_EmpresaGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Pagos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Pagos_Empresa.Folio_Empresas=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Pagos_Empresa.Folio_Empresas='" + RelationId + "'";
            }
            var result = _IDetalle_Pagos_EmpresaApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Pagos_Empresas == null)
                result.Detalle_Pagos_Empresas = new List<Detalle_Pagos_Empresa>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Pagos_Empresas.Select(m => new Detalle_Pagos_EmpresaGridModel
                {
                    Folio = m.Folio

                        ,Suscripcion = m.Suscripcion
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Nombre_del_Plan") ??(string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
			,Concepto_de_Pago = m.Concepto_de_Pago
			,Fecha_de_Suscripcion = (m.Fecha_de_Suscripcion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Suscripcion).ToString(ConfigurationProperty.DateFormat))
			,Numero_de_Pago = m.Numero_de_Pago
			,De_Total_de_Pagos = m.De_Total_de_Pagos
			,Fecha_Limite_de_Pago = (m.Fecha_Limite_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_Limite_de_Pago).ToString(ConfigurationProperty.DateFormat))
			,Recordatorio_dias = m.Recordatorio_dias
                        ,Forma_de_Pago = m.Forma_de_Pago
                        ,Forma_de_PagoNombre = CultureHelper.GetTraduction(m.Forma_de_Pago_Formas_de_Pago.Clave.ToString(), "Nombre") ??(string)m.Forma_de_Pago_Formas_de_Pago.Nombre
			,Fecha_de_Pago = (m.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_de_Pago.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus_de_Pago.Descripcion

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Pagos_EmpresaGridModel> GetDetalle_Pagos_EmpresaData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Pagos_EmpresaGridModel> resultData = new List<Detalle_Pagos_EmpresaGridModel>();
            string where = "Detalle_Pagos_Empresa.Folio_Empresas=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Pagos_Empresa.Folio_Empresas='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Pagos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Pagos_EmpresaApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Pagos_Empresas != null)
            {
                resultData = result.Detalle_Pagos_Empresas.Select(m => new Detalle_Pagos_EmpresaGridModel
                    {
                        Folio = m.Folio

                        ,Suscripcion = m.Suscripcion
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Nombre_del_Plan") ??(string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
			,Concepto_de_Pago = m.Concepto_de_Pago
			,Fecha_de_Suscripcion = (m.Fecha_de_Suscripcion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Suscripcion).ToString(ConfigurationProperty.DateFormat))
			,Numero_de_Pago = m.Numero_de_Pago
			,De_Total_de_Pagos = m.De_Total_de_Pagos
			,Fecha_Limite_de_Pago = (m.Fecha_Limite_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_Limite_de_Pago).ToString(ConfigurationProperty.DateFormat))
			,Recordatorio_dias = m.Recordatorio_dias
                        ,Forma_de_Pago = m.Forma_de_Pago
                        ,Forma_de_PagoNombre = CultureHelper.GetTraduction(m.Forma_de_Pago_Formas_de_Pago.Clave.ToString(), "Nombre") ??(string)m.Forma_de_Pago_Formas_de_Pago.Nombre
			,Fecha_de_Pago = (m.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_de_Pago.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus_de_Pago.Descripcion


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Registro_Beneficiarios_Empresa(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Registro_Beneficiarios_EmpresaGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Registro_Beneficiarios_Empresa.Folio_Empresa=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Registro_Beneficiarios_Empresa.Folio_Empresa='" + RelationId + "'";
            }
            var result = _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Registro_Beneficiarios_Empresas == null)
                result.Detalle_Registro_Beneficiarios_Empresas = new List<Detalle_Registro_Beneficiarios_Empresa>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Registro_Beneficiarios_Empresas.Select(m => new Detalle_Registro_Beneficiarios_EmpresaGridModel
                {
                    Folio = m.Folio

			,Numero_de_Empleado = m.Numero_de_Empleado
                        ,Usuario = m.Usuario
                        ,UsuarioName = CultureHelper.GetTraduction(m.Usuario_Spartan_User.Id_User.ToString(), "Name") ??(string)m.Usuario_Spartan_User.Name
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
			,Email = m.Email
			,Activo = m.Activo
                        ,Suscripcion = m.Suscripcion
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Nombre_del_Plan") ??(string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
			,Codigo_de_Referencia = m.Codigo_de_Referencia
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus.Descripcion

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Registro_Beneficiarios_EmpresaGridModel> GetDetalle_Registro_Beneficiarios_EmpresaData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Registro_Beneficiarios_EmpresaGridModel> resultData = new List<Detalle_Registro_Beneficiarios_EmpresaGridModel>();
            string where = "Detalle_Registro_Beneficiarios_Empresa.Folio_Empresa=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Registro_Beneficiarios_Empresa.Folio_Empresa='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Registro_Beneficiarios_Empresas != null)
            {
                resultData = result.Detalle_Registro_Beneficiarios_Empresas.Select(m => new Detalle_Registro_Beneficiarios_EmpresaGridModel
                    {
                        Folio = m.Folio

			,Numero_de_Empleado = m.Numero_de_Empleado
                        ,Usuario = m.Usuario
                        ,UsuarioName = CultureHelper.GetTraduction(m.Usuario_Spartan_User.Id_User.ToString(), "Name") ??(string)m.Usuario_Spartan_User.Name
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
			,Email = m.Email
			,Activo = m.Activo
                        ,Suscripcion = m.Suscripcion
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Nombre_del_Plan") ??(string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
			,Codigo_de_Referencia = m.Codigo_de_Referencia
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ??(string)m.Estatus_Estatus.Descripcion


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }
        public ActionResult GetDetalle_Contratos_Empresa(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Contratos_EmpresaGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Contratos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Contratos_Empresa.Folio_Empresas=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Contratos_Empresa.Folio_Empresas='" + RelationId + "'";
            }
            var result = _IDetalle_Contratos_EmpresaApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Contratos_Empresas == null)
                result.Detalle_Contratos_Empresas = new List<Detalle_Contratos_Empresa>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Contratos_Empresas.Select(m => new Detalle_Contratos_EmpresaGridModel
                {
                    Folio = m.Folio

                        ,Suscripcion = m.Suscripcion
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Nombre_del_Plan") ??(string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                        ,Tipo_de_Contrato = m.Tipo_de_Contrato
                        ,Tipo_de_ContratoDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Contrato_Tipos_de_Contrato.Clave.ToString(), "Descripcion") ??(string)m.Tipo_de_Contrato_Tipos_de_Contrato.Descripcion
			,DocumentoFileInfo = m.Documento > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Documento).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }
			,Fecha_de_Firma_de_Contrato = (m.Fecha_de_Firma_de_Contrato == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Firma_de_Contrato).ToString(ConfigurationProperty.DateFormat))

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Contratos_EmpresaGridModel> GetDetalle_Contratos_EmpresaData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Contratos_EmpresaGridModel> resultData = new List<Detalle_Contratos_EmpresaGridModel>();
            string where = "Detalle_Contratos_Empresa.Folio_Empresas=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Contratos_Empresa.Folio_Empresas='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Contratos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Contratos_EmpresaApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Contratos_Empresas != null)
            {
                resultData = result.Detalle_Contratos_Empresas.Select(m => new Detalle_Contratos_EmpresaGridModel
                    {
                        Folio = m.Folio

                        ,Suscripcion = m.Suscripcion
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Nombre_del_Plan") ??(string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                        ,Tipo_de_Contrato = m.Tipo_de_Contrato
                        ,Tipo_de_ContratoDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Contrato_Tipos_de_Contrato.Clave.ToString(), "Descripcion") ??(string)m.Tipo_de_Contrato_Tipos_de_Contrato.Descripcion
			,DocumentoFileInfo = m.Documento > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Documento).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }
			,Fecha_de_Firma_de_Contrato = (m.Fecha_de_Firma_de_Contrato == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Firma_de_Contrato).ToString(ConfigurationProperty.DateFormat))


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
                _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);

                Empresas varEmpresas = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IDetalle_Contactos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Contactos_Empresa.Folio_Empresas=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Contactos_Empresa.Folio_Empresas='" + id + "'";
                    }
                    var Detalle_Contactos_EmpresaInfo =
                        _IDetalle_Contactos_EmpresaApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Contactos_EmpresaInfo.Detalle_Contactos_Empresas.Count > 0)
                    {
                        var resultDetalle_Contactos_Empresa = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Contactos_EmpresaItem in Detalle_Contactos_EmpresaInfo.Detalle_Contactos_Empresas)
                            resultDetalle_Contactos_Empresa = resultDetalle_Contactos_Empresa
                                              && _IDetalle_Contactos_EmpresaApiConsumer.Delete(Detalle_Contactos_EmpresaItem.Folio, null,null).Resource;

                        if (!resultDetalle_Contactos_Empresa)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Suscripciones_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Suscripciones_Empresa.Folio_Empresas=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Suscripciones_Empresa.Folio_Empresas='" + id + "'";
                    }
                    var Detalle_Suscripciones_EmpresaInfo =
                        _IDetalle_Suscripciones_EmpresaApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Suscripciones_EmpresaInfo.Detalle_Suscripciones_Empresas.Count > 0)
                    {
                        var resultDetalle_Suscripciones_Empresa = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Suscripciones_EmpresaItem in Detalle_Suscripciones_EmpresaInfo.Detalle_Suscripciones_Empresas)
                            resultDetalle_Suscripciones_Empresa = resultDetalle_Suscripciones_Empresa
                                              && _IDetalle_Suscripciones_EmpresaApiConsumer.Delete(Detalle_Suscripciones_EmpresaItem.Folio, null,null).Resource;

                        if (!resultDetalle_Suscripciones_Empresa)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Pagos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Pagos_Empresa.Folio_Empresas=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Pagos_Empresa.Folio_Empresas='" + id + "'";
                    }
                    var Detalle_Pagos_EmpresaInfo =
                        _IDetalle_Pagos_EmpresaApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Pagos_EmpresaInfo.Detalle_Pagos_Empresas.Count > 0)
                    {
                        var resultDetalle_Pagos_Empresa = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Pagos_EmpresaItem in Detalle_Pagos_EmpresaInfo.Detalle_Pagos_Empresas)
                            resultDetalle_Pagos_Empresa = resultDetalle_Pagos_Empresa
                                              && _IDetalle_Pagos_EmpresaApiConsumer.Delete(Detalle_Pagos_EmpresaItem.Folio, null,null).Resource;

                        if (!resultDetalle_Pagos_Empresa)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Registro_Beneficiarios_Empresa.Folio_Empresa=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Registro_Beneficiarios_Empresa.Folio_Empresa='" + id + "'";
                    }
                    var Detalle_Registro_Beneficiarios_EmpresaInfo =
                        _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Registro_Beneficiarios_EmpresaInfo.Detalle_Registro_Beneficiarios_Empresas.Count > 0)
                    {
                        var resultDetalle_Registro_Beneficiarios_Empresa = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Registro_Beneficiarios_EmpresaItem in Detalle_Registro_Beneficiarios_EmpresaInfo.Detalle_Registro_Beneficiarios_Empresas)
                            resultDetalle_Registro_Beneficiarios_Empresa = resultDetalle_Registro_Beneficiarios_Empresa
                                              && _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.Delete(Detalle_Registro_Beneficiarios_EmpresaItem.Folio, null,null).Resource;

                        if (!resultDetalle_Registro_Beneficiarios_Empresa)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _IDetalle_Contratos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Contratos_Empresa.Folio_Empresas=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Contratos_Empresa.Folio_Empresas='" + id + "'";
                    }
                    var Detalle_Contratos_EmpresaInfo =
                        _IDetalle_Contratos_EmpresaApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Contratos_EmpresaInfo.Detalle_Contratos_Empresas.Count > 0)
                    {
                        var resultDetalle_Contratos_Empresa = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Contratos_EmpresaItem in Detalle_Contratos_EmpresaInfo.Detalle_Contratos_Empresas)
                            resultDetalle_Contratos_Empresa = resultDetalle_Contratos_Empresa
                                              && _IDetalle_Contratos_EmpresaApiConsumer.Delete(Detalle_Contratos_EmpresaItem.Folio, null,null).Resource;

                        if (!resultDetalle_Contratos_Empresa)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IEmpresasApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, EmpresasModel varEmpresas)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);


                    if (varEmpresas.Cedula_FiscalRemoveAttachment != 0 && varEmpresas.Cedula_FiscalFile == null)
                    {
                        varEmpresas.Cedula_Fiscal = 0;
                    }

                    if (varEmpresas.Cedula_FiscalFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varEmpresas.Cedula_FiscalFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varEmpresas.Cedula_Fiscal = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varEmpresas.Cedula_FiscalFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                    
                    var result = "";
                    var EmpresasInfo = new Empresas
                    {
                        Folio = varEmpresas.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varEmpresas.Fecha_de_Registro)) ? DateTime.ParseExact(varEmpresas.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varEmpresas.Hora_de_Registro
                        ,Usuario_que_Registra = varEmpresas.Usuario_que_Registra
                        ,Nombre_de_la_Empresa = varEmpresas.Nombre_de_la_Empresa
                        ,Tipo_de_Empresa = varEmpresas.Tipo_de_Empresa
                        ,Email = varEmpresas.Email
                        ,Telefono = varEmpresas.Telefono
                        ,Calle = varEmpresas.Calle
                        ,Numero_exterior = varEmpresas.Numero_exterior
                        ,Numero_interior = varEmpresas.Numero_interior
                        ,Colonia = varEmpresas.Colonia
                        ,CP = varEmpresas.CP
                        ,Ciudad = varEmpresas.Ciudad
                        ,Estado = varEmpresas.Estado
                        ,Pais = varEmpresas.Pais
                        ,Estatus = varEmpresas.Estatus
                        ,Regimen_Fiscal = varEmpresas.Regimen_Fiscal
                        ,Nombre_o_Razon_Social = varEmpresas.Nombre_o_Razon_Social
                        ,RFC = varEmpresas.RFC
                        ,Calle_Fiscal = varEmpresas.Calle_Fiscal
                        ,Numero_exterior_Fiscal = varEmpresas.Numero_exterior_Fiscal
                        ,Numero_interior_Fiscal = varEmpresas.Numero_interior_Fiscal
                        ,Colonia_Fiscal = varEmpresas.Colonia_Fiscal
                        ,CP_Fiscal = varEmpresas.CP_Fiscal
                        ,Ciudad_Fiscal = varEmpresas.Ciudad_Fiscal
                        ,Estado_Fiscal = varEmpresas.Estado_Fiscal
                        ,Pais_Fiscal = varEmpresas.Pais_Fiscal
                        ,Telefono_Fiscal = varEmpresas.Telefono_Fiscal
                        ,Fax = varEmpresas.Fax
                        ,Nombres_del_Representante_Legal = varEmpresas.Nombres_del_Representante_Legal
                        ,Apellido_Paterno_del_Representante_Legal = varEmpresas.Apellido_Paterno_del_Representante_Legal
                        ,Apellido_Materno_del_Representante_Legal = varEmpresas.Apellido_Materno_del_Representante_Legal
                        ,Nombre_Completo_del_Representante_Legal = varEmpresas.Nombre_Completo_del_Representante_Legal
                        ,Cedula_Fiscal = (varEmpresas.Cedula_Fiscal.HasValue && varEmpresas.Cedula_Fiscal != 0) ? ((int?)Convert.ToInt32(varEmpresas.Cedula_Fiscal.Value)) : null


                    };

                    result = !IsNew ?
                        _IEmpresasApiConsumer.Update(EmpresasInfo, null, null).Resource.ToString() :
                         _IEmpresasApiConsumer.Insert(EmpresasInfo, null, null).Resource.ToString();
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
        public bool CopyDetalle_Contactos_Empresa(int MasterId, int referenceId, List<Detalle_Contactos_EmpresaGridModelPost> Detalle_Contactos_EmpresaItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Contactos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Contactos_EmpresaData = _IDetalle_Contactos_EmpresaApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Contactos_Empresa.Folio_Empresas=" + referenceId,"").Resource;
                if (Detalle_Contactos_EmpresaData == null || Detalle_Contactos_EmpresaData.Detalle_Contactos_Empresas.Count == 0)
                    return true;

                var result = true;

                Detalle_Contactos_EmpresaGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Contactos_Empresa in Detalle_Contactos_EmpresaData.Detalle_Contactos_Empresas)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Contactos_Empresa Detalle_Contactos_Empresa1 = varDetalle_Contactos_Empresa;

                    if (Detalle_Contactos_EmpresaItems != null && Detalle_Contactos_EmpresaItems.Any(m => m.Folio == Detalle_Contactos_Empresa1.Folio))
                    {
                        modelDataToChange = Detalle_Contactos_EmpresaItems.FirstOrDefault(m => m.Folio == Detalle_Contactos_Empresa1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Contactos_Empresa.Folio_Empresas = MasterId;
                    var insertId = _IDetalle_Contactos_EmpresaApiConsumer.Insert(varDetalle_Contactos_Empresa,null,null).Resource;
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
        public ActionResult PostDetalle_Contactos_Empresa(List<Detalle_Contactos_EmpresaGridModelPost> Detalle_Contactos_EmpresaItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Contactos_Empresa(MasterId, referenceId, Detalle_Contactos_EmpresaItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Contactos_EmpresaItems != null && Detalle_Contactos_EmpresaItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Contactos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Contactos_EmpresaItem in Detalle_Contactos_EmpresaItems)
                    {











                        //Removal Request
                        if (Detalle_Contactos_EmpresaItem.Removed)
                        {
                            result = result && _IDetalle_Contactos_EmpresaApiConsumer.Delete(Detalle_Contactos_EmpresaItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Contactos_EmpresaItem.Folio = 0;

                        var Detalle_Contactos_EmpresaData = new Detalle_Contactos_Empresa
                        {
                            Folio_Empresas = MasterId
                            ,Folio = Detalle_Contactos_EmpresaItem.Folio
                            ,Nombre_completo = Detalle_Contactos_EmpresaItem.Nombre_completo
                            ,Correo = Detalle_Contactos_EmpresaItem.Correo
                            ,Telefono = Detalle_Contactos_EmpresaItem.Telefono
                            ,Contacto_Principal = Detalle_Contactos_EmpresaItem.Contacto_Principal
                            ,Area = (Convert.ToInt32(Detalle_Contactos_EmpresaItem.Area) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Contactos_EmpresaItem.Area))
                            ,Acceso_al_Sistema = Detalle_Contactos_EmpresaItem.Acceso_al_Sistema
                            ,Nombre_de_usuario = Detalle_Contactos_EmpresaItem.Nombre_de_usuario
                            ,Recibe_Alertas = Detalle_Contactos_EmpresaItem.Recibe_Alertas
                            ,Estatus = (Convert.ToInt32(Detalle_Contactos_EmpresaItem.Estatus) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Contactos_EmpresaItem.Estatus))

                        };

                        var resultId = Detalle_Contactos_EmpresaItem.Folio > 0
                           ? _IDetalle_Contactos_EmpresaApiConsumer.Update(Detalle_Contactos_EmpresaData,null,null).Resource
                           : _IDetalle_Contactos_EmpresaApiConsumer.Insert(Detalle_Contactos_EmpresaData,null,null).Resource;

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
        public ActionResult GetDetalle_Contactos_Empresa_areas_EmpresasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _Iareas_EmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _Iareas_EmpresasApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "areas_Empresas", "Nombre");
                  item.Nombre= trans??item.Nombre;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpGet]
        public ActionResult GetDetalle_Contactos_Empresa_EstatusAll()
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
        public bool CopyDetalle_Suscripciones_Empresa(int MasterId, int referenceId, List<Detalle_Suscripciones_EmpresaGridModelPost> Detalle_Suscripciones_EmpresaItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Suscripciones_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Suscripciones_EmpresaData = _IDetalle_Suscripciones_EmpresaApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Suscripciones_Empresa.Folio_Empresas=" + referenceId,"").Resource;
                if (Detalle_Suscripciones_EmpresaData == null || Detalle_Suscripciones_EmpresaData.Detalle_Suscripciones_Empresas.Count == 0)
                    return true;

                var result = true;

                Detalle_Suscripciones_EmpresaGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Suscripciones_Empresa in Detalle_Suscripciones_EmpresaData.Detalle_Suscripciones_Empresas)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Suscripciones_Empresa Detalle_Suscripciones_Empresa1 = varDetalle_Suscripciones_Empresa;

                    if (Detalle_Suscripciones_EmpresaItems != null && Detalle_Suscripciones_EmpresaItems.Any(m => m.Folio == Detalle_Suscripciones_Empresa1.Folio))
                    {
                        modelDataToChange = Detalle_Suscripciones_EmpresaItems.FirstOrDefault(m => m.Folio == Detalle_Suscripciones_Empresa1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Suscripciones_Empresa.Folio_Empresas = MasterId;
                    var insertId = _IDetalle_Suscripciones_EmpresaApiConsumer.Insert(varDetalle_Suscripciones_Empresa,null,null).Resource;
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
        public ActionResult PostDetalle_Suscripciones_Empresa(List<Detalle_Suscripciones_EmpresaGridModelPost> Detalle_Suscripciones_EmpresaItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Suscripciones_Empresa(MasterId, referenceId, Detalle_Suscripciones_EmpresaItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Suscripciones_EmpresaItems != null && Detalle_Suscripciones_EmpresaItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Suscripciones_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Suscripciones_EmpresaItem in Detalle_Suscripciones_EmpresaItems)
                    {










                        //Removal Request
                        if (Detalle_Suscripciones_EmpresaItem.Removed)
                        {
                            result = result && _IDetalle_Suscripciones_EmpresaApiConsumer.Delete(Detalle_Suscripciones_EmpresaItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Suscripciones_EmpresaItem.Folio = 0;

                        var Detalle_Suscripciones_EmpresaData = new Detalle_Suscripciones_Empresa
                        {
                            Folio_Empresas = MasterId
                            ,Folio = Detalle_Suscripciones_EmpresaItem.Folio
                            ,Cantidad_de_Beneficiarios = Detalle_Suscripciones_EmpresaItem.Cantidad_de_Beneficiarios
                            ,Suscripcion = (Convert.ToInt32(Detalle_Suscripciones_EmpresaItem.Suscripcion) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Suscripciones_EmpresaItem.Suscripcion))
                            ,Fecha_de_inicio = (Detalle_Suscripciones_EmpresaItem.Fecha_de_inicio!= null) ? DateTime.ParseExact(Detalle_Suscripciones_EmpresaItem.Fecha_de_inicio, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Fecha_Fin = (Detalle_Suscripciones_EmpresaItem.Fecha_Fin!= null) ? DateTime.ParseExact(Detalle_Suscripciones_EmpresaItem.Fecha_Fin, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Nombre_de_la_Suscripcion = Detalle_Suscripciones_EmpresaItem.Nombre_de_la_Suscripcion
                            ,Frecuencia_de_Pago = (Convert.ToInt32(Detalle_Suscripciones_EmpresaItem.Frecuencia_de_Pago) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Suscripciones_EmpresaItem.Frecuencia_de_Pago))
                            ,Costo = Detalle_Suscripciones_EmpresaItem.Costo
                            ,Estatus = (Convert.ToInt32(Detalle_Suscripciones_EmpresaItem.Estatus) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Suscripciones_EmpresaItem.Estatus))

                        };

                        var resultId = Detalle_Suscripciones_EmpresaItem.Folio > 0
                           ? _IDetalle_Suscripciones_EmpresaApiConsumer.Update(Detalle_Suscripciones_EmpresaData,null,null).Resource
                           : _IDetalle_Suscripciones_EmpresaApiConsumer.Insert(Detalle_Suscripciones_EmpresaData,null,null).Resource;

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
        public ActionResult GetDetalle_Suscripciones_Empresa_Planes_de_SuscripcionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlanes_de_SuscripcionApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan");
                  item.Nombre_del_Plan= trans??item.Nombre_del_Plan;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpGet]
        public ActionResult GetDetalle_Suscripciones_Empresa_Frecuencia_de_pago_EmpresasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IFrecuencia_de_pago_EmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IFrecuencia_de_pago_EmpresasApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Frecuencia_de_pago_Empresas", "Nombre");
                  item.Nombre= trans??item.Nombre;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetDetalle_Suscripciones_Empresa_Estatus_de_SuscripcionAll()
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

        [NonAction]
        public bool CopyDetalle_Pagos_Empresa(int MasterId, int referenceId, List<Detalle_Pagos_EmpresaGridModelPost> Detalle_Pagos_EmpresaItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Pagos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Pagos_EmpresaData = _IDetalle_Pagos_EmpresaApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Pagos_Empresa.Folio_Empresas=" + referenceId,"").Resource;
                if (Detalle_Pagos_EmpresaData == null || Detalle_Pagos_EmpresaData.Detalle_Pagos_Empresas.Count == 0)
                    return true;

                var result = true;

                Detalle_Pagos_EmpresaGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Pagos_Empresa in Detalle_Pagos_EmpresaData.Detalle_Pagos_Empresas)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Pagos_Empresa Detalle_Pagos_Empresa1 = varDetalle_Pagos_Empresa;

                    if (Detalle_Pagos_EmpresaItems != null && Detalle_Pagos_EmpresaItems.Any(m => m.Folio == Detalle_Pagos_Empresa1.Folio))
                    {
                        modelDataToChange = Detalle_Pagos_EmpresaItems.FirstOrDefault(m => m.Folio == Detalle_Pagos_Empresa1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Pagos_Empresa.Folio_Empresas = MasterId;
                    var insertId = _IDetalle_Pagos_EmpresaApiConsumer.Insert(varDetalle_Pagos_Empresa,null,null).Resource;
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
        public ActionResult PostDetalle_Pagos_Empresa(List<Detalle_Pagos_EmpresaGridModelPost> Detalle_Pagos_EmpresaItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Pagos_Empresa(MasterId, referenceId, Detalle_Pagos_EmpresaItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Pagos_EmpresaItems != null && Detalle_Pagos_EmpresaItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Pagos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Pagos_EmpresaItem in Detalle_Pagos_EmpresaItems)
                    {












                        //Removal Request
                        if (Detalle_Pagos_EmpresaItem.Removed)
                        {
                            result = result && _IDetalle_Pagos_EmpresaApiConsumer.Delete(Detalle_Pagos_EmpresaItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Pagos_EmpresaItem.Folio = 0;

                        var Detalle_Pagos_EmpresaData = new Detalle_Pagos_Empresa
                        {
                            Folio_Empresas = MasterId
                            ,Folio = Detalle_Pagos_EmpresaItem.Folio
                            ,Suscripcion = (Convert.ToInt32(Detalle_Pagos_EmpresaItem.Suscripcion) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Pagos_EmpresaItem.Suscripcion))
                            ,Concepto_de_Pago = Detalle_Pagos_EmpresaItem.Concepto_de_Pago
                            ,Fecha_de_Suscripcion = (Detalle_Pagos_EmpresaItem.Fecha_de_Suscripcion!= null) ? DateTime.ParseExact(Detalle_Pagos_EmpresaItem.Fecha_de_Suscripcion, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Numero_de_Pago = Detalle_Pagos_EmpresaItem.Numero_de_Pago
                            ,De_Total_de_Pagos = Detalle_Pagos_EmpresaItem.De_Total_de_Pagos
                            ,Fecha_Limite_de_Pago = (Detalle_Pagos_EmpresaItem.Fecha_Limite_de_Pago!= null) ? DateTime.ParseExact(Detalle_Pagos_EmpresaItem.Fecha_Limite_de_Pago, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Recordatorio_dias = Detalle_Pagos_EmpresaItem.Recordatorio_dias
                            ,Forma_de_Pago = (Convert.ToInt32(Detalle_Pagos_EmpresaItem.Forma_de_Pago) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Pagos_EmpresaItem.Forma_de_Pago))
                            ,Fecha_de_Pago = (Detalle_Pagos_EmpresaItem.Fecha_de_Pago!= null) ? DateTime.ParseExact(Detalle_Pagos_EmpresaItem.Fecha_de_Pago, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                            ,Estatus = (Convert.ToInt32(Detalle_Pagos_EmpresaItem.Estatus) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Pagos_EmpresaItem.Estatus))

                        };

                        var resultId = Detalle_Pagos_EmpresaItem.Folio > 0
                           ? _IDetalle_Pagos_EmpresaApiConsumer.Update(Detalle_Pagos_EmpresaData,null,null).Resource
                           : _IDetalle_Pagos_EmpresaApiConsumer.Insert(Detalle_Pagos_EmpresaData,null,null).Resource;

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
        public ActionResult GetDetalle_Pagos_Empresa_Planes_de_SuscripcionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlanes_de_SuscripcionApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan");
                  item.Nombre_del_Plan= trans??item.Nombre_del_Plan;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }






        [HttpGet]
        public ActionResult GetDetalle_Pagos_Empresa_Formas_de_PagoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IFormas_de_PagoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IFormas_de_PagoApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Formas_de_Pago", "Nombre");
                  item.Nombre= trans??item.Nombre;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetDetalle_Pagos_Empresa_Estatus_de_PagoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_de_PagoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_de_PagoApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Estatus_de_Pago", "Descripcion");
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
        public bool CopyDetalle_Registro_Beneficiarios_Empresa(int MasterId, int referenceId, List<Detalle_Registro_Beneficiarios_EmpresaGridModelPost> Detalle_Registro_Beneficiarios_EmpresaItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Registro_Beneficiarios_EmpresaData = _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Registro_Beneficiarios_Empresa.Folio_Empresa=" + referenceId,"").Resource;
                if (Detalle_Registro_Beneficiarios_EmpresaData == null || Detalle_Registro_Beneficiarios_EmpresaData.Detalle_Registro_Beneficiarios_Empresas.Count == 0)
                    return true;

                var result = true;

                Detalle_Registro_Beneficiarios_EmpresaGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Registro_Beneficiarios_Empresa in Detalle_Registro_Beneficiarios_EmpresaData.Detalle_Registro_Beneficiarios_Empresas)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Registro_Beneficiarios_Empresa Detalle_Registro_Beneficiarios_Empresa1 = varDetalle_Registro_Beneficiarios_Empresa;

                    if (Detalle_Registro_Beneficiarios_EmpresaItems != null && Detalle_Registro_Beneficiarios_EmpresaItems.Any(m => m.Folio == Detalle_Registro_Beneficiarios_Empresa1.Folio))
                    {
                        modelDataToChange = Detalle_Registro_Beneficiarios_EmpresaItems.FirstOrDefault(m => m.Folio == Detalle_Registro_Beneficiarios_Empresa1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Registro_Beneficiarios_Empresa.Folio_Empresa = MasterId;
                    var insertId = _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.Insert(varDetalle_Registro_Beneficiarios_Empresa,null,null).Resource;
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
        public ActionResult PostDetalle_Registro_Beneficiarios_Empresa(List<Detalle_Registro_Beneficiarios_EmpresaGridModelPost> Detalle_Registro_Beneficiarios_EmpresaItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Registro_Beneficiarios_Empresa(MasterId, referenceId, Detalle_Registro_Beneficiarios_EmpresaItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Registro_Beneficiarios_EmpresaItems != null && Detalle_Registro_Beneficiarios_EmpresaItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Registro_Beneficiarios_EmpresaItem in Detalle_Registro_Beneficiarios_EmpresaItems)
                    {













                        //Removal Request
                        if (Detalle_Registro_Beneficiarios_EmpresaItem.Removed)
                        {
                            result = result && _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.Delete(Detalle_Registro_Beneficiarios_EmpresaItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Registro_Beneficiarios_EmpresaItem.Folio = 0;

                        var Detalle_Registro_Beneficiarios_EmpresaData = new Detalle_Registro_Beneficiarios_Empresa
                        {
                            Folio_Empresa = MasterId
                            ,Folio = Detalle_Registro_Beneficiarios_EmpresaItem.Folio
                            ,Numero_de_Empleado = Detalle_Registro_Beneficiarios_EmpresaItem.Numero_de_Empleado
                            ,Usuario = (Convert.ToInt32(Detalle_Registro_Beneficiarios_EmpresaItem.Usuario) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Registro_Beneficiarios_EmpresaItem.Usuario))
                            ,Nombres = Detalle_Registro_Beneficiarios_EmpresaItem.Nombres
                            ,Apellido_Paterno = Detalle_Registro_Beneficiarios_EmpresaItem.Apellido_Paterno
                            ,Apellido_Materno = Detalle_Registro_Beneficiarios_EmpresaItem.Apellido_Materno
                            ,Nombre_Completo = Detalle_Registro_Beneficiarios_EmpresaItem.Nombre_Completo
                            ,Email = Detalle_Registro_Beneficiarios_EmpresaItem.Email
                            ,Activo = Detalle_Registro_Beneficiarios_EmpresaItem.Activo
                            ,Suscripcion = (Convert.ToInt32(Detalle_Registro_Beneficiarios_EmpresaItem.Suscripcion) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Registro_Beneficiarios_EmpresaItem.Suscripcion))
                            ,Codigo_de_Referencia = Detalle_Registro_Beneficiarios_EmpresaItem.Codigo_de_Referencia
                            ,Estatus = (Convert.ToInt32(Detalle_Registro_Beneficiarios_EmpresaItem.Estatus) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Registro_Beneficiarios_EmpresaItem.Estatus))

                        };

                        var resultId = Detalle_Registro_Beneficiarios_EmpresaItem.Folio > 0
                           ? _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.Update(Detalle_Registro_Beneficiarios_EmpresaData,null,null).Resource
                           : _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.Insert(Detalle_Registro_Beneficiarios_EmpresaData,null,null).Resource;

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
        public ActionResult GetDetalle_Registro_Beneficiarios_Empresa_Spartan_UserAll()
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
        public ActionResult GetDetalle_Registro_Beneficiarios_Empresa_Planes_de_SuscripcionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlanes_de_SuscripcionApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan");
                  item.Nombre_del_Plan= trans??item.Nombre_del_Plan;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetDetalle_Registro_Beneficiarios_Empresa_EstatusAll()
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
        public bool CopyDetalle_Contratos_Empresa(int MasterId, int referenceId, List<Detalle_Contratos_EmpresaGridModelPost> Detalle_Contratos_EmpresaItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Contratos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Contratos_EmpresaData = _IDetalle_Contratos_EmpresaApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Contratos_Empresa.Folio_Empresas=" + referenceId,"").Resource;
                if (Detalle_Contratos_EmpresaData == null || Detalle_Contratos_EmpresaData.Detalle_Contratos_Empresas.Count == 0)
                    return true;

                var result = true;

                Detalle_Contratos_EmpresaGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Contratos_Empresa in Detalle_Contratos_EmpresaData.Detalle_Contratos_Empresas)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Contratos_Empresa Detalle_Contratos_Empresa1 = varDetalle_Contratos_Empresa;

                    if (Detalle_Contratos_EmpresaItems != null && Detalle_Contratos_EmpresaItems.Any(m => m.Folio == Detalle_Contratos_Empresa1.Folio))
                    {
                        modelDataToChange = Detalle_Contratos_EmpresaItems.FirstOrDefault(m => m.Folio == Detalle_Contratos_Empresa1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Contratos_Empresa.Folio_Empresas = MasterId;
                    var insertId = _IDetalle_Contratos_EmpresaApiConsumer.Insert(varDetalle_Contratos_Empresa,null,null).Resource;
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
        public ActionResult PostDetalle_Contratos_Empresa(List<Detalle_Contratos_EmpresaGridModelPost> Detalle_Contratos_EmpresaItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Contratos_Empresa(MasterId, referenceId, Detalle_Contratos_EmpresaItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Contratos_EmpresaItems != null && Detalle_Contratos_EmpresaItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Contratos_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Contratos_EmpresaItem in Detalle_Contratos_EmpresaItems)
                    {



                        #region DocumentoInfo
                        //Checking if file exist if yes edit or add
                        if (Detalle_Contratos_EmpresaItem.DocumentoInfo.Control != null && !Detalle_Contratos_EmpresaItem.Removed)
                        {
                            var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(Detalle_Contratos_EmpresaItem.DocumentoInfo.Control);
                            Detalle_Contratos_EmpresaItem.DocumentoInfo.FileId = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                            {
                                File = fileAsBytes,
                                Description = Detalle_Contratos_EmpresaItem.DocumentoInfo.Control.FileName,
                                File_Size = fileAsBytes.Length
                            }).Resource;
                        }
                        else if (!Detalle_Contratos_EmpresaItem.Removed && Detalle_Contratos_EmpresaItem.DocumentoInfo.RemoveFile)
                        {
                            Detalle_Contratos_EmpresaItem.DocumentoInfo.FileId = 0;
                        }
                        #endregion DocumentoInfo


                        //Removal Request
                        if (Detalle_Contratos_EmpresaItem.Removed)
                        {
                            result = result && _IDetalle_Contratos_EmpresaApiConsumer.Delete(Detalle_Contratos_EmpresaItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Contratos_EmpresaItem.Folio = 0;

                        var Detalle_Contratos_EmpresaData = new Detalle_Contratos_Empresa
                        {
                            Folio_Empresas = MasterId
                            ,Folio = Detalle_Contratos_EmpresaItem.Folio
                            ,Suscripcion = (Convert.ToInt32(Detalle_Contratos_EmpresaItem.Suscripcion) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Contratos_EmpresaItem.Suscripcion))
                            ,Tipo_de_Contrato = (Convert.ToInt32(Detalle_Contratos_EmpresaItem.Tipo_de_Contrato) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Contratos_EmpresaItem.Tipo_de_Contrato))
                            ,Documento = Detalle_Contratos_EmpresaItem.DocumentoInfo.FileId
                            ,Fecha_de_Firma_de_Contrato = (Detalle_Contratos_EmpresaItem.Fecha_de_Firma_de_Contrato!= null) ? DateTime.ParseExact(Detalle_Contratos_EmpresaItem.Fecha_de_Firma_de_Contrato, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null

                        };

                        var resultId = Detalle_Contratos_EmpresaItem.Folio > 0
                           ? _IDetalle_Contratos_EmpresaApiConsumer.Update(Detalle_Contratos_EmpresaData,null,null).Resource
                           : _IDetalle_Contratos_EmpresaApiConsumer.Insert(Detalle_Contratos_EmpresaData,null,null).Resource;

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
        public ActionResult GetDetalle_Contratos_Empresa_Planes_de_SuscripcionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlanes_de_SuscripcionApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan");
                  item.Nombre_del_Plan= trans??item.Nombre_del_Plan;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetDetalle_Contratos_Empresa_Tipos_de_ContratoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipos_de_ContratoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipos_de_ContratoApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Tipos_de_Contrato", "Descripcion");
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
        /// Write Element Array of Empresas script
        /// </summary>
        /// <param name="oEmpresasElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew EmpresasModuleAttributeList)
        {
            for (int i = 0; i < EmpresasModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(EmpresasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    EmpresasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(EmpresasModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    EmpresasModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (EmpresasModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < EmpresasModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < EmpresasModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(EmpresasModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							EmpresasModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(EmpresasModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							EmpresasModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strEmpresasScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Empresas.js")))
            {
                strEmpresasScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Empresas element attributes
            string userChangeJson = jsSerialize.Serialize(EmpresasModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strEmpresasScript.IndexOf("inpuElementArray");
            string splittedString = strEmpresasScript.Substring(indexOfArray, strEmpresasScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(EmpresasModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (EmpresasModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strEmpresasScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strEmpresasScript.Substring(indexOfArrayHistory, strEmpresasScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strEmpresasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strEmpresasScript.Substring(endIndexOfMainElement + indexOfArray, strEmpresasScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (EmpresasModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in EmpresasModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Empresas.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Empresas.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Empresas.js")))
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
        public ActionResult EmpresasPropertyBag()
        {
            return PartialView("EmpresasPropertyBag", "Empresas");
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
        public ActionResult AddDetalle_Contactos_Empresa(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Contactos_Empresa/AddDetalle_Contactos_Empresa");
        }

        [HttpGet]
        public ActionResult AddDetalle_Suscripciones_Empresa(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Suscripciones_Empresa/AddDetalle_Suscripciones_Empresa");
        }

        [HttpGet]
        public ActionResult AddDetalle_Pagos_Empresa(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Pagos_Empresa/AddDetalle_Pagos_Empresa");
        }

        [HttpGet]
        public ActionResult AddDetalle_Registro_Beneficiarios_Empresa(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Registro_Beneficiarios_Empresa/AddDetalle_Registro_Beneficiarios_Empresa");
        }

        [HttpGet]
        public ActionResult AddDetalle_Contratos_Empresa(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Contratos_Empresa/AddDetalle_Contratos_Empresa");
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
                var whereClauseFormat = "Object = 44282 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Empresas.Folio= " + RecordId;
                            var result = _IEmpresasApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
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

            _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new EmpresasPropertyMapper());
			
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
                    (EmpresasAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            EmpresasPropertyMapper oEmpresasPropertyMapper = new EmpresasPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oEmpresasPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IEmpresasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Empresass == null)
                result.Empresass = new List<Empresas>();

            var data = result.Empresass.Select(m => new EmpresasGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_la_Empresa = m.Nombre_de_la_Empresa
                        ,Tipo_de_EmpresaDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Empresa_Tipos_de_Empresa.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Empresa_Tipos_de_Empresa.Descripcion
			,Email = m.Email
			,Telefono = m.Telefono
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
                        ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(m.Regimen_Fiscal_Regimenes_Fiscales.Clave.ToString(), "Descripcion") ?? (string)m.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
			,Nombre_o_Razon_Social = m.Nombre_o_Razon_Social
			,RFC = m.RFC
			,Calle_Fiscal = m.Calle_Fiscal
			,Numero_exterior_Fiscal = m.Numero_exterior_Fiscal
			,Numero_interior_Fiscal = m.Numero_interior_Fiscal
			,Colonia_Fiscal = m.Colonia_Fiscal
			,CP_Fiscal = m.CP_Fiscal
			,Ciudad_Fiscal = m.Ciudad_Fiscal
                        ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Fiscal_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Fiscal_Estado.Nombre_del_Estado
                        ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Fiscal_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Fiscal_Pais.Nombre_del_Pais
			,Telefono_Fiscal = m.Telefono_Fiscal
			,Fax = m.Fax
			,Nombres_del_Representante_Legal = m.Nombres_del_Representante_Legal
			,Apellido_Paterno_del_Representante_Legal = m.Apellido_Paterno_del_Representante_Legal
			,Apellido_Materno_del_Representante_Legal = m.Apellido_Materno_del_Representante_Legal
			,Nombre_Completo_del_Representante_Legal = m.Nombre_Completo_del_Representante_Legal
			,Cedula_Fiscal = m.Cedula_Fiscal

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(44282, arrayColumnsVisible), "EmpresasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(44282, arrayColumnsVisible), "EmpresasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(44282, arrayColumnsVisible), "EmpresasList_" + DateTime.Now.ToString());
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

            _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new EmpresasPropertyMapper());
				
				
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (EmpresasAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            EmpresasPropertyMapper oEmpresasPropertyMapper = new EmpresasPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oEmpresasPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
			
			if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IEmpresasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Empresass == null)
                result.Empresass = new List<Empresas>();

            var data = result.Empresass.Select(m => new EmpresasGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_la_Empresa = m.Nombre_de_la_Empresa
                        ,Tipo_de_EmpresaDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Empresa_Tipos_de_Empresa.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Empresa_Tipos_de_Empresa.Descripcion
			,Email = m.Email
			,Telefono = m.Telefono
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
                        ,Regimen_FiscalDescripcion = CultureHelper.GetTraduction(m.Regimen_Fiscal_Regimenes_Fiscales.Clave.ToString(), "Descripcion") ?? (string)m.Regimen_Fiscal_Regimenes_Fiscales.Descripcion
			,Nombre_o_Razon_Social = m.Nombre_o_Razon_Social
			,RFC = m.RFC
			,Calle_Fiscal = m.Calle_Fiscal
			,Numero_exterior_Fiscal = m.Numero_exterior_Fiscal
			,Numero_interior_Fiscal = m.Numero_interior_Fiscal
			,Colonia_Fiscal = m.Colonia_Fiscal
			,CP_Fiscal = m.CP_Fiscal
			,Ciudad_Fiscal = m.Ciudad_Fiscal
                        ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Fiscal_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Fiscal_Estado.Nombre_del_Estado
                        ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Fiscal_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Fiscal_Pais.Nombre_del_Pais
			,Telefono_Fiscal = m.Telefono_Fiscal
			,Fax = m.Fax
			,Nombres_del_Representante_Legal = m.Nombres_del_Representante_Legal
			,Apellido_Paterno_del_Representante_Legal = m.Apellido_Paterno_del_Representante_Legal
			,Apellido_Materno_del_Representante_Legal = m.Apellido_Materno_del_Representante_Legal
			,Nombre_Completo_del_Representante_Legal = m.Nombre_Completo_del_Representante_Legal
			,Cedula_Fiscal = m.Cedula_Fiscal

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
                _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEmpresasApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Empresas_Datos_GeneralesModel varEmpresas)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Empresas_Datos_GeneralesInfo = new Empresas_Datos_Generales
                {
                    Folio = varEmpresas.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varEmpresas.Fecha_de_Registro)) ? DateTime.ParseExact(varEmpresas.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varEmpresas.Hora_de_Registro
                        ,Usuario_que_Registra = varEmpresas.Usuario_que_Registra
                        ,Nombre_de_la_Empresa = varEmpresas.Nombre_de_la_Empresa
                        ,Tipo_de_Empresa = varEmpresas.Tipo_de_Empresa
                        ,Email = varEmpresas.Email
                        ,Telefono = varEmpresas.Telefono
                        ,Calle = varEmpresas.Calle
                        ,Numero_exterior = varEmpresas.Numero_exterior
                        ,Numero_interior = varEmpresas.Numero_interior
                        ,Colonia = varEmpresas.Colonia
                        ,CP = varEmpresas.CP
                        ,Ciudad = varEmpresas.Ciudad
                        ,Estado = varEmpresas.Estado
                        ,Pais = varEmpresas.Pais
                        ,Estatus = varEmpresas.Estatus
                    
                };

                result = _IEmpresasApiConsumer.Update_Datos_Generales(Empresas_Datos_GeneralesInfo).Resource.ToString();
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
                _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IEmpresasApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Contactos_Empresa;
                var Detalle_Contactos_EmpresaData = GetDetalle_Contactos_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Contactos_Empresa);
                int RowCount_Detalle_Suscripciones_Empresa;
                var Detalle_Suscripciones_EmpresaData = GetDetalle_Suscripciones_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Suscripciones_Empresa);
                int RowCount_Detalle_Pagos_Empresa;
                var Detalle_Pagos_EmpresaData = GetDetalle_Pagos_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Pagos_Empresa);
                int RowCount_Detalle_Registro_Beneficiarios_Empresa;
                var Detalle_Registro_Beneficiarios_EmpresaData = GetDetalle_Registro_Beneficiarios_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Registro_Beneficiarios_Empresa);
                int RowCount_Detalle_Contratos_Empresa;
                var Detalle_Contratos_EmpresaData = GetDetalle_Contratos_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Contratos_Empresa);

                var result = new Empresas_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Usuario_que_Registra = m.Usuario_que_Registra
                        ,Usuario_que_RegistraName = CultureHelper.GetTraduction(m.Usuario_que_Registra_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_Registra_Spartan_User.Name
			,Nombre_de_la_Empresa = m.Nombre_de_la_Empresa
                        ,Tipo_de_Empresa = m.Tipo_de_Empresa
                        ,Tipo_de_EmpresaDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Empresa_Tipos_de_Empresa.Clave.ToString(), "Descripcion") ?? (string)m.Tipo_de_Empresa_Tipos_de_Empresa.Descripcion
			,Email = m.Email
			,Telefono = m.Telefono
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,CP = m.CP
			,Ciudad = m.Ciudad
                        ,Estado = m.Estado
                        ,EstadoNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Estado.Nombre_del_Estado
                        ,Pais = m.Pais
                        ,PaisNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Pais.Nombre_del_Pais
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

                    
                };
				var resultData = new
                {
                    data = result
                    ,Contactos = Detalle_Contactos_EmpresaData
                    ,Suscripciones = Detalle_Suscripciones_EmpresaData
                    ,Pagos = Detalle_Pagos_EmpresaData
                    ,Beneficiarios = Detalle_Registro_Beneficiarios_EmpresaData
                    ,Contratos = Detalle_Contratos_EmpresaData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Datos_de_Contacto(Empresas_Datos_de_ContactoModel varEmpresas)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Empresas_Datos_de_ContactoInfo = new Empresas_Datos_de_Contacto
                {
                    Folio = varEmpresas.Folio
                                        
                };

                result = _IEmpresasApiConsumer.Update_Datos_de_Contacto(Empresas_Datos_de_ContactoInfo).Resource.ToString();
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
                _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IEmpresasApiConsumer.Get_Datos_de_Contacto(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Contactos_Empresa;
                var Detalle_Contactos_EmpresaData = GetDetalle_Contactos_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Contactos_Empresa);
                int RowCount_Detalle_Suscripciones_Empresa;
                var Detalle_Suscripciones_EmpresaData = GetDetalle_Suscripciones_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Suscripciones_Empresa);
                int RowCount_Detalle_Pagos_Empresa;
                var Detalle_Pagos_EmpresaData = GetDetalle_Pagos_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Pagos_Empresa);
                int RowCount_Detalle_Registro_Beneficiarios_Empresa;
                var Detalle_Registro_Beneficiarios_EmpresaData = GetDetalle_Registro_Beneficiarios_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Registro_Beneficiarios_Empresa);
                int RowCount_Detalle_Contratos_Empresa;
                var Detalle_Contratos_EmpresaData = GetDetalle_Contratos_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Contratos_Empresa);

                var result = new Empresas_Datos_de_ContactoModel
                {
                    Folio = m.Folio

                    
                };
				var resultData = new
                {
                    data = result
                    ,Contactos = Detalle_Contactos_EmpresaData
                    ,Suscripciones = Detalle_Suscripciones_EmpresaData
                    ,Pagos = Detalle_Pagos_EmpresaData
                    ,Beneficiarios = Detalle_Registro_Beneficiarios_EmpresaData
                    ,Contratos = Detalle_Contratos_EmpresaData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Datos_Fiscales(Empresas_Datos_FiscalesModel varEmpresas)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Empresas_Datos_FiscalesInfo = new Empresas_Datos_Fiscales
                {
                    Folio = varEmpresas.Folio
                                            ,Regimen_Fiscal = varEmpresas.Regimen_Fiscal
                        ,Nombre_o_Razon_Social = varEmpresas.Nombre_o_Razon_Social
                        ,RFC = varEmpresas.RFC
                        ,Calle_Fiscal = varEmpresas.Calle_Fiscal
                        ,Numero_exterior_Fiscal = varEmpresas.Numero_exterior_Fiscal
                        ,Numero_interior_Fiscal = varEmpresas.Numero_interior_Fiscal
                        ,Colonia_Fiscal = varEmpresas.Colonia_Fiscal
                        ,CP_Fiscal = varEmpresas.CP_Fiscal
                        ,Ciudad_Fiscal = varEmpresas.Ciudad_Fiscal
                        ,Estado_Fiscal = varEmpresas.Estado_Fiscal
                        ,Pais_Fiscal = varEmpresas.Pais_Fiscal
                        ,Telefono_Fiscal = varEmpresas.Telefono_Fiscal
                        ,Fax = varEmpresas.Fax
                        ,Nombres_del_Representante_Legal = varEmpresas.Nombres_del_Representante_Legal
                        ,Apellido_Paterno_del_Representante_Legal = varEmpresas.Apellido_Paterno_del_Representante_Legal
                        ,Apellido_Materno_del_Representante_Legal = varEmpresas.Apellido_Materno_del_Representante_Legal
                        ,Nombre_Completo_del_Representante_Legal = varEmpresas.Nombre_Completo_del_Representante_Legal
                    
                };

                result = _IEmpresasApiConsumer.Update_Datos_Fiscales(Empresas_Datos_FiscalesInfo).Resource.ToString();
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
                _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IEmpresasApiConsumer.Get_Datos_Fiscales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Contactos_Empresa;
                var Detalle_Contactos_EmpresaData = GetDetalle_Contactos_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Contactos_Empresa);
                int RowCount_Detalle_Suscripciones_Empresa;
                var Detalle_Suscripciones_EmpresaData = GetDetalle_Suscripciones_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Suscripciones_Empresa);
                int RowCount_Detalle_Pagos_Empresa;
                var Detalle_Pagos_EmpresaData = GetDetalle_Pagos_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Pagos_Empresa);
                int RowCount_Detalle_Registro_Beneficiarios_Empresa;
                var Detalle_Registro_Beneficiarios_EmpresaData = GetDetalle_Registro_Beneficiarios_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Registro_Beneficiarios_Empresa);
                int RowCount_Detalle_Contratos_Empresa;
                var Detalle_Contratos_EmpresaData = GetDetalle_Contratos_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Contratos_Empresa);

                var result = new Empresas_Datos_FiscalesModel
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
			,CP_Fiscal = m.CP_Fiscal
			,Ciudad_Fiscal = m.Ciudad_Fiscal
                        ,Estado_Fiscal = m.Estado_Fiscal
                        ,Estado_FiscalNombre_del_Estado = CultureHelper.GetTraduction(m.Estado_Fiscal_Estado.Clave.ToString(), "Nombre_del_Estado") ?? (string)m.Estado_Fiscal_Estado.Nombre_del_Estado
                        ,Pais_Fiscal = m.Pais_Fiscal
                        ,Pais_FiscalNombre_del_Pais = CultureHelper.GetTraduction(m.Pais_Fiscal_Pais.Clave.ToString(), "Nombre_del_Pais") ?? (string)m.Pais_Fiscal_Pais.Nombre_del_Pais
			,Telefono_Fiscal = m.Telefono_Fiscal
			,Fax = m.Fax
			,Nombres_del_Representante_Legal = m.Nombres_del_Representante_Legal
			,Apellido_Paterno_del_Representante_Legal = m.Apellido_Paterno_del_Representante_Legal
			,Apellido_Materno_del_Representante_Legal = m.Apellido_Materno_del_Representante_Legal
			,Nombre_Completo_del_Representante_Legal = m.Nombre_Completo_del_Representante_Legal

                    
                };
				var resultData = new
                {
                    data = result
                    ,Contactos = Detalle_Contactos_EmpresaData
                    ,Suscripciones = Detalle_Suscripciones_EmpresaData
                    ,Pagos = Detalle_Pagos_EmpresaData
                    ,Beneficiarios = Detalle_Registro_Beneficiarios_EmpresaData
                    ,Contratos = Detalle_Contratos_EmpresaData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Suscripcion(Empresas_SuscripcionModel varEmpresas)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Empresas_SuscripcionInfo = new Empresas_Suscripcion
                {
                    Folio = varEmpresas.Folio
                                        
                };

                result = _IEmpresasApiConsumer.Update_Suscripcion(Empresas_SuscripcionInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Suscripcion(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IEmpresasApiConsumer.Get_Suscripcion(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Contactos_Empresa;
                var Detalle_Contactos_EmpresaData = GetDetalle_Contactos_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Contactos_Empresa);
                int RowCount_Detalle_Suscripciones_Empresa;
                var Detalle_Suscripciones_EmpresaData = GetDetalle_Suscripciones_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Suscripciones_Empresa);
                int RowCount_Detalle_Pagos_Empresa;
                var Detalle_Pagos_EmpresaData = GetDetalle_Pagos_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Pagos_Empresa);
                int RowCount_Detalle_Registro_Beneficiarios_Empresa;
                var Detalle_Registro_Beneficiarios_EmpresaData = GetDetalle_Registro_Beneficiarios_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Registro_Beneficiarios_Empresa);
                int RowCount_Detalle_Contratos_Empresa;
                var Detalle_Contratos_EmpresaData = GetDetalle_Contratos_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Contratos_Empresa);

                var result = new Empresas_SuscripcionModel
                {
                    Folio = m.Folio

                    
                };
				var resultData = new
                {
                    data = result
                    ,Contactos = Detalle_Contactos_EmpresaData
                    ,Suscripciones = Detalle_Suscripciones_EmpresaData
                    ,Pagos = Detalle_Pagos_EmpresaData
                    ,Beneficiarios = Detalle_Registro_Beneficiarios_EmpresaData
                    ,Contratos = Detalle_Contratos_EmpresaData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }

		[HttpPost]
        public ActionResult Post_Documentacion(Empresas_DocumentacionModel varEmpresas)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
				                    if (varEmpresas.Cedula_FiscalRemoveAttachment != 0 && varEmpresas.Cedula_FiscalFile == null)
                    {
                        varEmpresas.Cedula_Fiscal = 0;
                    }

                    if (varEmpresas.Cedula_FiscalFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varEmpresas.Cedula_FiscalFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varEmpresas.Cedula_Fiscal = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varEmpresas.Cedula_FiscalFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                var result = "";
                var Empresas_DocumentacionInfo = new Empresas_Documentacion
                {
                    Folio = varEmpresas.Folio
                                            ,Cedula_Fiscal = (varEmpresas.Cedula_Fiscal.HasValue && varEmpresas.Cedula_Fiscal != 0) ? ((int?)Convert.ToInt32(varEmpresas.Cedula_Fiscal.Value)) : null

                    
                };

                result = _IEmpresasApiConsumer.Update_Documentacion(Empresas_DocumentacionInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Documentacion(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEmpresasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IEmpresasApiConsumer.Get_Documentacion(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Contactos_Empresa;
                var Detalle_Contactos_EmpresaData = GetDetalle_Contactos_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Contactos_Empresa);
                int RowCount_Detalle_Suscripciones_Empresa;
                var Detalle_Suscripciones_EmpresaData = GetDetalle_Suscripciones_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Suscripciones_Empresa);
                int RowCount_Detalle_Pagos_Empresa;
                var Detalle_Pagos_EmpresaData = GetDetalle_Pagos_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Pagos_Empresa);
                int RowCount_Detalle_Registro_Beneficiarios_Empresa;
                var Detalle_Registro_Beneficiarios_EmpresaData = GetDetalle_Registro_Beneficiarios_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Registro_Beneficiarios_Empresa);
                int RowCount_Detalle_Contratos_Empresa;
                var Detalle_Contratos_EmpresaData = GetDetalle_Contratos_EmpresaData(Id.ToString(), 0, Int16.MaxValue, out RowCount_Detalle_Contratos_Empresa);

                var result = new Empresas_DocumentacionModel
                {
                    Folio = m.Folio
			,Cedula_Fiscal = m.Cedula_Fiscal

                    
                };
				var resultData = new
                {
                    data = result
                    ,Contactos = Detalle_Contactos_EmpresaData
                    ,Suscripciones = Detalle_Suscripciones_EmpresaData
                    ,Pagos = Detalle_Pagos_EmpresaData
                    ,Beneficiarios = Detalle_Registro_Beneficiarios_EmpresaData
                    ,Contratos = Detalle_Contratos_EmpresaData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

