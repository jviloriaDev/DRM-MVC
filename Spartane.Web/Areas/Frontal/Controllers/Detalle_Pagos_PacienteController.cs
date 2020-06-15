using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Pagos_Paciente;
using Spartane.Core.Domain.Planes_de_Suscripcion;
using Spartane.Core.Domain.Formas_de_Pago;
using Spartane.Core.Domain.Estatus_de_Pago;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Pagos_Paciente;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Pagos_Paciente;
using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion;
using Spartane.Web.Areas.WebApiConsumer.Formas_de_Pago;
using Spartane.Web.Areas.WebApiConsumer.Estatus_de_Pago;

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

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Detalle_Pagos_PacienteController : Controller
    {
        #region "variable declaration"

        private IDetalle_Pagos_PacienteService service = null;
        private IDetalle_Pagos_PacienteApiConsumer _IDetalle_Pagos_PacienteApiConsumer;
        private IPlanes_de_SuscripcionApiConsumer _IPlanes_de_SuscripcionApiConsumer;
        private IFormas_de_PagoApiConsumer _IFormas_de_PagoApiConsumer;
        private IEstatus_de_PagoApiConsumer _IEstatus_de_PagoApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Pagos_PacienteController(IDetalle_Pagos_PacienteService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Pagos_PacienteApiConsumer Detalle_Pagos_PacienteApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IPlanes_de_SuscripcionApiConsumer Planes_de_SuscripcionApiConsumer , IFormas_de_PagoApiConsumer Formas_de_PagoApiConsumer , IEstatus_de_PagoApiConsumer Estatus_de_PagoApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Pagos_PacienteApiConsumer = Detalle_Pagos_PacienteApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IPlanes_de_SuscripcionApiConsumer = Planes_de_SuscripcionApiConsumer;
            this._IFormas_de_PagoApiConsumer = Formas_de_PagoApiConsumer;
            this._IEstatus_de_PagoApiConsumer = Estatus_de_PagoApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Pagos_Paciente
        [ObjectAuth(ObjectId = (ModuleObjectId)44399, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44399);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Pagos_Paciente/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44399, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44399);
            ViewBag.Permission = permission;
            var varDetalle_Pagos_Paciente = new Detalle_Pagos_PacienteModel();
			
            ViewBag.ObjectId = "44399";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Pagos_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Pagos_PacienteData = _IDetalle_Pagos_PacienteApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Pagos_Pacientes[0];
                if (Detalle_Pagos_PacienteData == null)
                    return HttpNotFound();

                varDetalle_Pagos_Paciente = new Detalle_Pagos_PacienteModel
                {
                    Folio = (int)Detalle_Pagos_PacienteData.Folio
                    ,Suscripcion = Detalle_Pagos_PacienteData.Suscripcion
                    ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(Convert.ToString(Detalle_Pagos_PacienteData.Suscripcion), "Planes_de_Suscripcion") ??  (string)Detalle_Pagos_PacienteData.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                    ,Concepto_de_Pago = Detalle_Pagos_PacienteData.Concepto_de_Pago
                    ,Fecha_de_Suscripcion = (Detalle_Pagos_PacienteData.Fecha_de_Suscripcion == null ? string.Empty : Convert.ToDateTime(Detalle_Pagos_PacienteData.Fecha_de_Suscripcion).ToString(ConfigurationProperty.DateFormat))
                    ,Numero_de_Pago = Detalle_Pagos_PacienteData.Numero_de_Pago
                    ,De_Total_de_Pagos = Detalle_Pagos_PacienteData.De_Total_de_Pagos
                    ,Fecha_Limite_de_Pago = (Detalle_Pagos_PacienteData.Fecha_Limite_de_Pago == null ? string.Empty : Convert.ToDateTime(Detalle_Pagos_PacienteData.Fecha_Limite_de_Pago).ToString(ConfigurationProperty.DateFormat))
                    ,Recordatorio_dias = Detalle_Pagos_PacienteData.Recordatorio_dias
                    ,Forma_de_Pago = Detalle_Pagos_PacienteData.Forma_de_Pago
                    ,Forma_de_PagoNombre = CultureHelper.GetTraduction(Convert.ToString(Detalle_Pagos_PacienteData.Forma_de_Pago), "Formas_de_Pago") ??  (string)Detalle_Pagos_PacienteData.Forma_de_Pago_Formas_de_Pago.Nombre
                    ,Fecha_de_Pago = (Detalle_Pagos_PacienteData.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(Detalle_Pagos_PacienteData.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))
                    ,Estatus = Detalle_Pagos_PacienteData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Pagos_PacienteData.Estatus), "Estatus_de_Pago") ??  (string)Detalle_Pagos_PacienteData.Estatus_Estatus_de_Pago.Descripcion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Planes_de_Suscripcions_Suscripcion = _IPlanes_de_SuscripcionApiConsumer.SelAll(true);
            if (Planes_de_Suscripcions_Suscripcion != null && Planes_de_Suscripcions_Suscripcion.Resource != null)
                ViewBag.Planes_de_Suscripcions_Suscripcion = Planes_de_Suscripcions_Suscripcion.Resource.Where(m => m.Nombre_del_Plan != null).OrderBy(m => m.Nombre_del_Plan).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan") ?? m.Nombre_del_Plan.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
	    _IFormas_de_PagoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Formas_de_Pagos_Forma_de_Pago = _IFormas_de_PagoApiConsumer.SelAll(true);
            if (Formas_de_Pagos_Forma_de_Pago != null && Formas_de_Pagos_Forma_de_Pago.Resource != null)
                ViewBag.Formas_de_Pagos_Forma_de_Pago = Formas_de_Pagos_Forma_de_Pago.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Formas_de_Pago", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
	    _IEstatus_de_PagoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_de_Pagos_Estatus = _IEstatus_de_PagoApiConsumer.SelAll(true);
            if (Estatus_de_Pagos_Estatus != null && Estatus_de_Pagos_Estatus.Resource != null)
                ViewBag.Estatus_de_Pagos_Estatus = Estatus_de_Pagos_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_de_Pago", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Pagos_Paciente);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Pagos_Paciente(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44399);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Pagos_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Pagos_PacienteModel varDetalle_Pagos_Paciente= new Detalle_Pagos_PacienteModel();


            if (id.ToString() != "0")
            {
                var Detalle_Pagos_PacientesData = _IDetalle_Pagos_PacienteApiConsumer.ListaSelAll(0, 1000, "Detalle_Pagos_Paciente.Folio=" + id, "").Resource.Detalle_Pagos_Pacientes;
				
				if (Detalle_Pagos_PacientesData != null && Detalle_Pagos_PacientesData.Count > 0)
                {
					var Detalle_Pagos_PacienteData = Detalle_Pagos_PacientesData.First();
					varDetalle_Pagos_Paciente= new Detalle_Pagos_PacienteModel
					{
						Folio  = Detalle_Pagos_PacienteData.Folio 
	                    ,Suscripcion = Detalle_Pagos_PacienteData.Suscripcion
                    ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(Convert.ToString(Detalle_Pagos_PacienteData.Suscripcion), "Planes_de_Suscripcion") ??  (string)Detalle_Pagos_PacienteData.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                    ,Concepto_de_Pago = Detalle_Pagos_PacienteData.Concepto_de_Pago
                    ,Fecha_de_Suscripcion = (Detalle_Pagos_PacienteData.Fecha_de_Suscripcion == null ? string.Empty : Convert.ToDateTime(Detalle_Pagos_PacienteData.Fecha_de_Suscripcion).ToString(ConfigurationProperty.DateFormat))
                    ,Numero_de_Pago = Detalle_Pagos_PacienteData.Numero_de_Pago
                    ,De_Total_de_Pagos = Detalle_Pagos_PacienteData.De_Total_de_Pagos
                    ,Fecha_Limite_de_Pago = (Detalle_Pagos_PacienteData.Fecha_Limite_de_Pago == null ? string.Empty : Convert.ToDateTime(Detalle_Pagos_PacienteData.Fecha_Limite_de_Pago).ToString(ConfigurationProperty.DateFormat))
                    ,Recordatorio_dias = Detalle_Pagos_PacienteData.Recordatorio_dias
                    ,Forma_de_Pago = Detalle_Pagos_PacienteData.Forma_de_Pago
                    ,Forma_de_PagoNombre = CultureHelper.GetTraduction(Convert.ToString(Detalle_Pagos_PacienteData.Forma_de_Pago), "Formas_de_Pago") ??  (string)Detalle_Pagos_PacienteData.Forma_de_Pago_Formas_de_Pago.Nombre
                    ,Fecha_de_Pago = (Detalle_Pagos_PacienteData.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(Detalle_Pagos_PacienteData.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))
                    ,Estatus = Detalle_Pagos_PacienteData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Pagos_PacienteData.Estatus), "Estatus_de_Pago") ??  (string)Detalle_Pagos_PacienteData.Estatus_Estatus_de_Pago.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Planes_de_Suscripcions_Suscripcion = _IPlanes_de_SuscripcionApiConsumer.SelAll(true);
            if (Planes_de_Suscripcions_Suscripcion != null && Planes_de_Suscripcions_Suscripcion.Resource != null)
                ViewBag.Planes_de_Suscripcions_Suscripcion = Planes_de_Suscripcions_Suscripcion.Resource.Where(m => m.Nombre_del_Plan != null).OrderBy(m => m.Nombre_del_Plan).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan") ?? m.Nombre_del_Plan.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
	    _IFormas_de_PagoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Formas_de_Pagos_Forma_de_Pago = _IFormas_de_PagoApiConsumer.SelAll(true);
            if (Formas_de_Pagos_Forma_de_Pago != null && Formas_de_Pagos_Forma_de_Pago.Resource != null)
                ViewBag.Formas_de_Pagos_Forma_de_Pago = Formas_de_Pagos_Forma_de_Pago.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Formas_de_Pago", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
	    _IEstatus_de_PagoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_de_Pagos_Estatus = _IEstatus_de_PagoApiConsumer.SelAll(true);
            if (Estatus_de_Pagos_Estatus != null && Estatus_de_Pagos_Estatus.Resource != null)
                ViewBag.Estatus_de_Pagos_Estatus = Estatus_de_Pagos_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_de_Pago", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_Pagos_Paciente", varDetalle_Pagos_Paciente);
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
        public ActionResult GetFormas_de_PagoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IFormas_de_PagoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IFormas_de_PagoApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Formas_de_Pago", "Nombre")?? m.Nombre,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
		[HttpGet]
        public ActionResult GetEstatus_de_PagoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_de_PagoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_de_PagoApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_de_Pago", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Pagos_PacientePropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Pagos_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Pagos_Pacientes == null)
                result.Detalle_Pagos_Pacientes = new List<Detalle_Pagos_Paciente>();

            return Json(new
            {
                data = result.Detalle_Pagos_Pacientes.Select(m => new Detalle_Pagos_PacienteGridModel
                    {
                    Folio = m.Folio
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Nombre_del_Plan") ?? (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
			,Concepto_de_Pago = m.Concepto_de_Pago
                        ,Fecha_de_Suscripcion = (m.Fecha_de_Suscripcion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Suscripcion).ToString(ConfigurationProperty.DateFormat))
			,Numero_de_Pago = m.Numero_de_Pago
			,De_Total_de_Pagos = m.De_Total_de_Pagos
                        ,Fecha_Limite_de_Pago = (m.Fecha_Limite_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_Limite_de_Pago).ToString(ConfigurationProperty.DateFormat))
			,Recordatorio_dias = m.Recordatorio_dias
                        ,Forma_de_PagoNombre = CultureHelper.GetTraduction(m.Forma_de_Pago_Formas_de_Pago.Clave.ToString(), "Formas_de_Pago") ?? (string)m.Forma_de_Pago_Formas_de_Pago.Nombre
                        ,Fecha_de_Pago = (m.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_de_Pago.Clave.ToString(), "Estatus_de_Pago") ?? (string)m.Estatus_Estatus_de_Pago.Descripcion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetDetalle_Pagos_Paciente_Forma_de_Pago_Formas_de_Pago(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IFormas_de_PagoApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Formas_de_Pago.Clave as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Formas_de_Pago.Nombre as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _IFormas_de_PagoApiConsumer.ListaSelAll(1, 20,elWhere , " Formas_de_Pago.Nombre ASC ").Resource;
               
                foreach (var item in result.Formas_de_Pagos)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Formas_de_Pago", "Nombre");
                    item.Nombre =trans ??item.Nombre;
                }
                return Json(result.Formas_de_Pagos.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public JsonResult GetDetalle_Pagos_Paciente_Estatus_Estatus_de_Pago(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_de_PagoApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Estatus_de_Pago.Clave as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Estatus_de_Pago.Descripcion as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _IEstatus_de_PagoApiConsumer.ListaSelAll(1, 20,elWhere , " Estatus_de_Pago.Descripcion ASC ").Resource;
               
                foreach (var item in result.Estatus_de_Pagos)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Estatus_de_Pago", "Descripcion");
                    item.Descripcion =trans ??item.Descripcion;
                }
                return Json(result.Estatus_de_Pagos.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
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
                _IDetalle_Pagos_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Pagos_Paciente varDetalle_Pagos_Paciente = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Pagos_PacienteApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Pagos_PacienteModel varDetalle_Pagos_Paciente)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Pagos_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Pagos_PacienteInfo = new Detalle_Pagos_Paciente
                    {
                        Folio = varDetalle_Pagos_Paciente.Folio
                        ,Suscripcion = varDetalle_Pagos_Paciente.Suscripcion
                        ,Concepto_de_Pago = varDetalle_Pagos_Paciente.Concepto_de_Pago
                        ,Fecha_de_Suscripcion = (!String.IsNullOrEmpty(varDetalle_Pagos_Paciente.Fecha_de_Suscripcion)) ? DateTime.ParseExact(varDetalle_Pagos_Paciente.Fecha_de_Suscripcion, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Numero_de_Pago = varDetalle_Pagos_Paciente.Numero_de_Pago
                        ,De_Total_de_Pagos = varDetalle_Pagos_Paciente.De_Total_de_Pagos
                        ,Fecha_Limite_de_Pago = (!String.IsNullOrEmpty(varDetalle_Pagos_Paciente.Fecha_Limite_de_Pago)) ? DateTime.ParseExact(varDetalle_Pagos_Paciente.Fecha_Limite_de_Pago, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Recordatorio_dias = varDetalle_Pagos_Paciente.Recordatorio_dias
                        ,Forma_de_Pago = varDetalle_Pagos_Paciente.Forma_de_Pago
                        ,Fecha_de_Pago = (!String.IsNullOrEmpty(varDetalle_Pagos_Paciente.Fecha_de_Pago)) ? DateTime.ParseExact(varDetalle_Pagos_Paciente.Fecha_de_Pago, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Estatus = varDetalle_Pagos_Paciente.Estatus

                    };

                    result = !IsNew ?
                        _IDetalle_Pagos_PacienteApiConsumer.Update(Detalle_Pagos_PacienteInfo, null, null).Resource.ToString() :
                         _IDetalle_Pagos_PacienteApiConsumer.Insert(Detalle_Pagos_PacienteInfo, null, null).Resource.ToString();

                    return Json(result, JsonRequestBehavior.AllowGet);
				}
				return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Detalle_Pagos_Paciente script
        /// </summary>
        /// <param name="oDetalle_Pagos_PacienteElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Pagos_PacienteModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Pagos_PacienteModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Pagos_PacienteModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Pagos_PacienteModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Pagos_PacienteModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Pagos_PacienteModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Pagos_PacienteModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Pagos_PacienteModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Pagos_PacienteModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Pagos_PacienteModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Pagos_PacienteModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Pagos_PacienteModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Pagos_PacienteScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Pagos_Paciente.js")))
            {
                strDetalle_Pagos_PacienteScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Pagos_Paciente element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Pagos_PacienteModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Pagos_PacienteScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Pagos_PacienteScript.Substring(indexOfArray, strDetalle_Pagos_PacienteScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Pagos_PacienteModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Pagos_PacienteModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Pagos_PacienteScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Pagos_PacienteScript.Substring(indexOfArrayHistory, strDetalle_Pagos_PacienteScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Pagos_PacienteScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Pagos_PacienteScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Pagos_PacienteScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Pagos_PacienteModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Pagos_PacienteScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Pagos_PacienteScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Pagos_PacienteScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Pagos_PacienteScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Pagos_Paciente.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Pagos_Paciente.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Pagos_Paciente.js")))
                {
                    strCustomScript = r.ReadToEnd();
                
                }

                int indexOfArray = strCustomScript.IndexOf("inpuElementArray");
                string splittedString = strCustomScript.Substring(indexOfArray, strCustomScript.Length - indexOfArray);                
                int indexOfMainElement = splittedString.IndexOf('[');                
                int endIndexOfMainElement = splittedString.IndexOf(']') + 1;                
                string mainJsonArray = splittedString.Substring(indexOfMainElement, endIndexOfMainElement - indexOfMainElement);

                int indexOfChildArray = strCustomScript.IndexOf("inpuElementChildArray");
				string childJsonArray = "";
                if (indexOfChildArray != -1)
                {
					string splittedChildString = strCustomScript.Substring(indexOfChildArray, strCustomScript.Length - indexOfChildArray);
					int indexOfChildElement = splittedChildString.IndexOf('[');
					int endIndexOfChildElement = splittedChildString.IndexOf(']') + 1;
					childJsonArray = splittedChildString.Substring(indexOfChildElement, endIndexOfChildElement - indexOfChildElement);
				}
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
        public ActionResult Detalle_Pagos_PacientePropertyBag()
        {
            return PartialView("Detalle_Pagos_PacientePropertyBag", "Detalle_Pagos_Paciente");
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
        public void Export(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return;

            _IDetalle_Pagos_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Pagos_PacientePropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Pagos_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Pagos_Pacientes == null)
                result.Detalle_Pagos_Pacientes = new List<Detalle_Pagos_Paciente>();

            var data = result.Detalle_Pagos_Pacientes.Select(m => new Detalle_Pagos_PacienteGridModel
            {
                Folio = m.Folio
                ,SuscripcionNombre_del_Plan = (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                ,Concepto_de_Pago = m.Concepto_de_Pago
                ,Fecha_de_Suscripcion = (m.Fecha_de_Suscripcion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Suscripcion).ToString(ConfigurationProperty.DateFormat))
                ,Numero_de_Pago = m.Numero_de_Pago
                ,De_Total_de_Pagos = m.De_Total_de_Pagos
                ,Fecha_Limite_de_Pago = (m.Fecha_Limite_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_Limite_de_Pago).ToString(ConfigurationProperty.DateFormat))
                ,Recordatorio_dias = m.Recordatorio_dias
                ,Forma_de_PagoNombre = (string)m.Forma_de_Pago_Formas_de_Pago.Nombre
                ,Fecha_de_Pago = (m.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))
                ,EstatusDescripcion = (string)m.Estatus_Estatus_de_Pago.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Pagos_PacienteList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Pagos_PacienteList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "EmployeeList_" + DateTime.Now.ToString());
                    break;
            }
        }

        [HttpGet]
        //[ObjectAuth(ObjectId = ModuleObjectId.EMPLEADOS_OBJECT, PermissionType = PermissionTypes.Export)]
        public ActionResult Print(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return null;

            _IDetalle_Pagos_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Pagos_PacientePropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Pagos_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Pagos_Pacientes == null)
                result.Detalle_Pagos_Pacientes = new List<Detalle_Pagos_Paciente>();

            var data = result.Detalle_Pagos_Pacientes.Select(m => new Detalle_Pagos_PacienteGridModel
            {
                Folio = m.Folio
                ,SuscripcionNombre_del_Plan = (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                ,Concepto_de_Pago = m.Concepto_de_Pago
                ,Fecha_de_Suscripcion = (m.Fecha_de_Suscripcion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Suscripcion).ToString(ConfigurationProperty.DateFormat))
                ,Numero_de_Pago = m.Numero_de_Pago
                ,De_Total_de_Pagos = m.De_Total_de_Pagos
                ,Fecha_Limite_de_Pago = (m.Fecha_Limite_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_Limite_de_Pago).ToString(ConfigurationProperty.DateFormat))
                ,Recordatorio_dias = m.Recordatorio_dias
                ,Forma_de_PagoNombre = (string)m.Forma_de_Pago_Formas_de_Pago.Nombre
                ,Fecha_de_Pago = (m.Fecha_de_Pago == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Pago).ToString(ConfigurationProperty.DateFormat))
                ,EstatusDescripcion = (string)m.Estatus_Estatus_de_Pago.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
