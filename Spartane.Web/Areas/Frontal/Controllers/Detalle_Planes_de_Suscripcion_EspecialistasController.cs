using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Planes_de_Suscripcion_Especialistas;
using Spartane.Core.Domain.Planes_de_Suscripcion_Especialistas;
using Spartane.Core.Domain.Frecuencia_de_pago_Especialistas;
using Spartane.Core.Domain.Estatus_de_Suscripcion;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Planes_de_Suscripcion_Especialistas;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Planes_de_Suscripcion_Especialistas;
using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion_Especialistas;
using Spartane.Web.Areas.WebApiConsumer.Frecuencia_de_pago_Especialistas;
using Spartane.Web.Areas.WebApiConsumer.Estatus_de_Suscripcion;

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
    public class Detalle_Planes_de_Suscripcion_EspecialistasController : Controller
    {
        #region "variable declaration"

        private IDetalle_Planes_de_Suscripcion_EspecialistasService service = null;
        private IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer;
        private IPlanes_de_Suscripcion_EspecialistasApiConsumer _IPlanes_de_Suscripcion_EspecialistasApiConsumer;
        private IFrecuencia_de_pago_EspecialistasApiConsumer _IFrecuencia_de_pago_EspecialistasApiConsumer;
        private IEstatus_de_SuscripcionApiConsumer _IEstatus_de_SuscripcionApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Planes_de_Suscripcion_EspecialistasController(IDetalle_Planes_de_Suscripcion_EspecialistasService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer Detalle_Planes_de_Suscripcion_EspecialistasApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IPlanes_de_Suscripcion_EspecialistasApiConsumer Planes_de_Suscripcion_EspecialistasApiConsumer , IFrecuencia_de_pago_EspecialistasApiConsumer Frecuencia_de_pago_EspecialistasApiConsumer , IEstatus_de_SuscripcionApiConsumer Estatus_de_SuscripcionApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer = Detalle_Planes_de_Suscripcion_EspecialistasApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IPlanes_de_Suscripcion_EspecialistasApiConsumer = Planes_de_Suscripcion_EspecialistasApiConsumer;
            this._IFrecuencia_de_pago_EspecialistasApiConsumer = Frecuencia_de_pago_EspecialistasApiConsumer;
            this._IEstatus_de_SuscripcionApiConsumer = Estatus_de_SuscripcionApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Planes_de_Suscripcion_Especialistas
        [ObjectAuth(ObjectId = (ModuleObjectId)44423, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44423);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Planes_de_Suscripcion_Especialistas/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44423, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44423);
            ViewBag.Permission = permission;
            var varDetalle_Planes_de_Suscripcion_Especialistas = new Detalle_Planes_de_Suscripcion_EspecialistasModel();
			
            ViewBag.ObjectId = "44423";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Planes_de_Suscripcion_EspecialistasData = _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Planes_de_Suscripcion_Especialistass[0];
                if (Detalle_Planes_de_Suscripcion_EspecialistasData == null)
                    return HttpNotFound();

                varDetalle_Planes_de_Suscripcion_Especialistas = new Detalle_Planes_de_Suscripcion_EspecialistasModel
                {
                    Folio = (int)Detalle_Planes_de_Suscripcion_EspecialistasData.Folio
                    ,Plan_de_Suscripcion = Detalle_Planes_de_Suscripcion_EspecialistasData.Plan_de_Suscripcion
                    ,Plan_de_SuscripcionNombre = CultureHelper.GetTraduction(Convert.ToString(Detalle_Planes_de_Suscripcion_EspecialistasData.Plan_de_Suscripcion), "Planes_de_Suscripcion_Especialistas") ??  (string)Detalle_Planes_de_Suscripcion_EspecialistasData.Plan_de_Suscripcion_Planes_de_Suscripcion_Especialistas.Nombre
                    ,Fecha_de_inicio = (Detalle_Planes_de_Suscripcion_EspecialistasData.Fecha_de_inicio == null ? string.Empty : Convert.ToDateTime(Detalle_Planes_de_Suscripcion_EspecialistasData.Fecha_de_inicio).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin = (Detalle_Planes_de_Suscripcion_EspecialistasData.Fecha_fin == null ? string.Empty : Convert.ToDateTime(Detalle_Planes_de_Suscripcion_EspecialistasData.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                    ,Frecuencia_de_Pago = Detalle_Planes_de_Suscripcion_EspecialistasData.Frecuencia_de_Pago
                    ,Frecuencia_de_PagoNombre = CultureHelper.GetTraduction(Convert.ToString(Detalle_Planes_de_Suscripcion_EspecialistasData.Frecuencia_de_Pago), "Frecuencia_de_pago_Especialistas") ??  (string)Detalle_Planes_de_Suscripcion_EspecialistasData.Frecuencia_de_Pago_Frecuencia_de_pago_Especialistas.Nombre
                    ,Costo = Detalle_Planes_de_Suscripcion_EspecialistasData.Costo
                    ,Contrato = Detalle_Planes_de_Suscripcion_EspecialistasData.Contrato
                    ,Firmo_Contrato = Detalle_Planes_de_Suscripcion_EspecialistasData.Firmo_Contrato.GetValueOrDefault()
                    ,Estatus = Detalle_Planes_de_Suscripcion_EspecialistasData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Planes_de_Suscripcion_EspecialistasData.Estatus), "Estatus_de_Suscripcion") ??  (string)Detalle_Planes_de_Suscripcion_EspecialistasData.Estatus_Estatus_de_Suscripcion.Descripcion

                };
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.ContratoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_Planes_de_Suscripcion_Especialistas.Contrato).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPlanes_de_Suscripcion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Planes_de_Suscripcion_Especialistass_Plan_de_Suscripcion = _IPlanes_de_Suscripcion_EspecialistasApiConsumer.SelAll(true);
            if (Planes_de_Suscripcion_Especialistass_Plan_de_Suscripcion != null && Planes_de_Suscripcion_Especialistass_Plan_de_Suscripcion.Resource != null)
                ViewBag.Planes_de_Suscripcion_Especialistass_Plan_de_Suscripcion = Planes_de_Suscripcion_Especialistass_Plan_de_Suscripcion.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion_Especialistas", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IFrecuencia_de_pago_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Frecuencia_de_pago_Especialistass_Frecuencia_de_Pago = _IFrecuencia_de_pago_EspecialistasApiConsumer.SelAll(true);
            if (Frecuencia_de_pago_Especialistass_Frecuencia_de_Pago != null && Frecuencia_de_pago_Especialistass_Frecuencia_de_Pago.Resource != null)
                ViewBag.Frecuencia_de_pago_Especialistass_Frecuencia_de_Pago = Frecuencia_de_pago_Especialistass_Frecuencia_de_Pago.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Frecuencia_de_pago_Especialistas", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_de_Suscripcions_Estatus = _IEstatus_de_SuscripcionApiConsumer.SelAll(true);
            if (Estatus_de_Suscripcions_Estatus != null && Estatus_de_Suscripcions_Estatus.Resource != null)
                ViewBag.Estatus_de_Suscripcions_Estatus = Estatus_de_Suscripcions_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_de_Suscripcion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Planes_de_Suscripcion_Especialistas);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Planes_de_Suscripcion_Especialistas(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44423);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Planes_de_Suscripcion_EspecialistasModel varDetalle_Planes_de_Suscripcion_Especialistas= new Detalle_Planes_de_Suscripcion_EspecialistasModel();


            if (id.ToString() != "0")
            {
                var Detalle_Planes_de_Suscripcion_EspecialistassData = _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.ListaSelAll(0, 1000, "Detalle_Planes_de_Suscripcion_Especialistas.Folio=" + id, "").Resource.Detalle_Planes_de_Suscripcion_Especialistass;
				
				if (Detalle_Planes_de_Suscripcion_EspecialistassData != null && Detalle_Planes_de_Suscripcion_EspecialistassData.Count > 0)
                {
					var Detalle_Planes_de_Suscripcion_EspecialistasData = Detalle_Planes_de_Suscripcion_EspecialistassData.First();
					varDetalle_Planes_de_Suscripcion_Especialistas= new Detalle_Planes_de_Suscripcion_EspecialistasModel
					{
						Folio  = Detalle_Planes_de_Suscripcion_EspecialistasData.Folio 
	                    ,Plan_de_Suscripcion = Detalle_Planes_de_Suscripcion_EspecialistasData.Plan_de_Suscripcion
                    ,Plan_de_SuscripcionNombre = CultureHelper.GetTraduction(Convert.ToString(Detalle_Planes_de_Suscripcion_EspecialistasData.Plan_de_Suscripcion), "Planes_de_Suscripcion_Especialistas") ??  (string)Detalle_Planes_de_Suscripcion_EspecialistasData.Plan_de_Suscripcion_Planes_de_Suscripcion_Especialistas.Nombre
                    ,Fecha_de_inicio = (Detalle_Planes_de_Suscripcion_EspecialistasData.Fecha_de_inicio == null ? string.Empty : Convert.ToDateTime(Detalle_Planes_de_Suscripcion_EspecialistasData.Fecha_de_inicio).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin = (Detalle_Planes_de_Suscripcion_EspecialistasData.Fecha_fin == null ? string.Empty : Convert.ToDateTime(Detalle_Planes_de_Suscripcion_EspecialistasData.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                    ,Frecuencia_de_Pago = Detalle_Planes_de_Suscripcion_EspecialistasData.Frecuencia_de_Pago
                    ,Frecuencia_de_PagoNombre = CultureHelper.GetTraduction(Convert.ToString(Detalle_Planes_de_Suscripcion_EspecialistasData.Frecuencia_de_Pago), "Frecuencia_de_pago_Especialistas") ??  (string)Detalle_Planes_de_Suscripcion_EspecialistasData.Frecuencia_de_Pago_Frecuencia_de_pago_Especialistas.Nombre
                    ,Costo = Detalle_Planes_de_Suscripcion_EspecialistasData.Costo
                    ,Contrato = Detalle_Planes_de_Suscripcion_EspecialistasData.Contrato
                    ,Firmo_Contrato = Detalle_Planes_de_Suscripcion_EspecialistasData.Firmo_Contrato.GetValueOrDefault()
                    ,Estatus = Detalle_Planes_de_Suscripcion_EspecialistasData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Planes_de_Suscripcion_EspecialistasData.Estatus), "Estatus_de_Suscripcion") ??  (string)Detalle_Planes_de_Suscripcion_EspecialistasData.Estatus_Estatus_de_Suscripcion.Descripcion

					};
				}
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.ContratoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_Planes_de_Suscripcion_Especialistas.Contrato).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPlanes_de_Suscripcion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Planes_de_Suscripcion_Especialistass_Plan_de_Suscripcion = _IPlanes_de_Suscripcion_EspecialistasApiConsumer.SelAll(true);
            if (Planes_de_Suscripcion_Especialistass_Plan_de_Suscripcion != null && Planes_de_Suscripcion_Especialistass_Plan_de_Suscripcion.Resource != null)
                ViewBag.Planes_de_Suscripcion_Especialistass_Plan_de_Suscripcion = Planes_de_Suscripcion_Especialistass_Plan_de_Suscripcion.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion_Especialistas", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IFrecuencia_de_pago_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Frecuencia_de_pago_Especialistass_Frecuencia_de_Pago = _IFrecuencia_de_pago_EspecialistasApiConsumer.SelAll(true);
            if (Frecuencia_de_pago_Especialistass_Frecuencia_de_Pago != null && Frecuencia_de_pago_Especialistass_Frecuencia_de_Pago.Resource != null)
                ViewBag.Frecuencia_de_pago_Especialistass_Frecuencia_de_Pago = Frecuencia_de_pago_Especialistass_Frecuencia_de_Pago.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Frecuencia_de_pago_Especialistas", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_de_Suscripcions_Estatus = _IEstatus_de_SuscripcionApiConsumer.SelAll(true);
            if (Estatus_de_Suscripcions_Estatus != null && Estatus_de_Suscripcions_Estatus.Resource != null)
                ViewBag.Estatus_de_Suscripcions_Estatus = Estatus_de_Suscripcions_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_de_Suscripcion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_Planes_de_Suscripcion_Especialistas", varDetalle_Planes_de_Suscripcion_Especialistas);
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
        public ActionResult GetPlanes_de_Suscripcion_EspecialistasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_Suscripcion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlanes_de_Suscripcion_EspecialistasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion_Especialistas", "Nombre")?? m.Nombre,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetFrecuencia_de_pago_EspecialistasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IFrecuencia_de_pago_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IFrecuencia_de_pago_EspecialistasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Frecuencia_de_pago_Especialistas", "Nombre")?? m.Nombre,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstatus_de_SuscripcionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_de_SuscripcionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_de_Suscripcion", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Planes_de_Suscripcion_EspecialistasPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Planes_de_Suscripcion_Especialistass == null)
                result.Detalle_Planes_de_Suscripcion_Especialistass = new List<Detalle_Planes_de_Suscripcion_Especialistas>();

            return Json(new
            {
                data = result.Detalle_Planes_de_Suscripcion_Especialistass.Select(m => new Detalle_Planes_de_Suscripcion_EspecialistasGridModel
                    {
                    Folio = m.Folio
                        ,Plan_de_SuscripcionNombre = CultureHelper.GetTraduction(m.Plan_de_Suscripcion_Planes_de_Suscripcion_Especialistas.Folio.ToString(), "Nombre") ?? (string)m.Plan_de_Suscripcion_Planes_de_Suscripcion_Especialistas.Nombre
                        ,Fecha_de_inicio = (m.Fecha_de_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_inicio).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                        ,Frecuencia_de_PagoNombre = CultureHelper.GetTraduction(m.Frecuencia_de_Pago_Frecuencia_de_pago_Especialistas.Clave.ToString(), "Nombre") ?? (string)m.Frecuencia_de_Pago_Frecuencia_de_pago_Especialistas.Nombre
			,Costo = m.Costo
			,Contrato = m.Contrato
			,Firmo_Contrato = m.Firmo_Contrato
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_de_Suscripcion.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_de_Suscripcion.Descripcion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
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
                _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Planes_de_Suscripcion_Especialistas varDetalle_Planes_de_Suscripcion_Especialistas = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Planes_de_Suscripcion_EspecialistasModel varDetalle_Planes_de_Suscripcion_Especialistas)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);


                    if (varDetalle_Planes_de_Suscripcion_Especialistas.ContratoRemoveAttachment != 0 && varDetalle_Planes_de_Suscripcion_Especialistas.ContratoFile == null)
                    {
                        varDetalle_Planes_de_Suscripcion_Especialistas.Contrato = 0;
                    }

                    if (varDetalle_Planes_de_Suscripcion_Especialistas.ContratoFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varDetalle_Planes_de_Suscripcion_Especialistas.ContratoFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varDetalle_Planes_de_Suscripcion_Especialistas.Contrato = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varDetalle_Planes_de_Suscripcion_Especialistas.ContratoFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                    
                    var result = "";
                    var Detalle_Planes_de_Suscripcion_EspecialistasInfo = new Detalle_Planes_de_Suscripcion_Especialistas
                    {
                        Folio = varDetalle_Planes_de_Suscripcion_Especialistas.Folio
                        ,Plan_de_Suscripcion = varDetalle_Planes_de_Suscripcion_Especialistas.Plan_de_Suscripcion
                        ,Fecha_de_inicio = (!String.IsNullOrEmpty(varDetalle_Planes_de_Suscripcion_Especialistas.Fecha_de_inicio)) ? DateTime.ParseExact(varDetalle_Planes_de_Suscripcion_Especialistas.Fecha_de_inicio, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Fecha_fin = (!String.IsNullOrEmpty(varDetalle_Planes_de_Suscripcion_Especialistas.Fecha_fin)) ? DateTime.ParseExact(varDetalle_Planes_de_Suscripcion_Especialistas.Fecha_fin, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Frecuencia_de_Pago = varDetalle_Planes_de_Suscripcion_Especialistas.Frecuencia_de_Pago
                        ,Costo = varDetalle_Planes_de_Suscripcion_Especialistas.Costo
                        ,Contrato = (varDetalle_Planes_de_Suscripcion_Especialistas.Contrato.HasValue && varDetalle_Planes_de_Suscripcion_Especialistas.Contrato != 0) ? ((int?)Convert.ToInt32(varDetalle_Planes_de_Suscripcion_Especialistas.Contrato.Value)) : null

                        ,Firmo_Contrato = varDetalle_Planes_de_Suscripcion_Especialistas.Firmo_Contrato
                        ,Estatus = varDetalle_Planes_de_Suscripcion_Especialistas.Estatus

                    };

                    result = !IsNew ?
                        _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.Update(Detalle_Planes_de_Suscripcion_EspecialistasInfo, null, null).Resource.ToString() :
                         _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.Insert(Detalle_Planes_de_Suscripcion_EspecialistasInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Planes_de_Suscripcion_Especialistas script
        /// </summary>
        /// <param name="oDetalle_Planes_de_Suscripcion_EspecialistasElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Planes_de_Suscripcion_EspecialistasModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Planes_de_Suscripcion_EspecialistasModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Planes_de_Suscripcion_EspecialistasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Planes_de_Suscripcion_EspecialistasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Planes_de_Suscripcion_EspecialistasModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Planes_de_Suscripcion_EspecialistasModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Planes_de_Suscripcion_EspecialistasModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Planes_de_Suscripcion_EspecialistasModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Planes_de_Suscripcion_EspecialistasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Planes_de_Suscripcion_EspecialistasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Planes_de_Suscripcion_EspecialistasModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Planes_de_Suscripcion_EspecialistasModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Planes_de_Suscripcion_EspecialistasScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Planes_de_Suscripcion_Especialistas.js")))
            {
                strDetalle_Planes_de_Suscripcion_EspecialistasScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Planes_de_Suscripcion_Especialistas element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Planes_de_Suscripcion_EspecialistasModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Planes_de_Suscripcion_EspecialistasScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Planes_de_Suscripcion_EspecialistasScript.Substring(indexOfArray, strDetalle_Planes_de_Suscripcion_EspecialistasScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Planes_de_Suscripcion_EspecialistasModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Planes_de_Suscripcion_EspecialistasModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Planes_de_Suscripcion_EspecialistasScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Planes_de_Suscripcion_EspecialistasScript.Substring(indexOfArrayHistory, strDetalle_Planes_de_Suscripcion_EspecialistasScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Planes_de_Suscripcion_EspecialistasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Planes_de_Suscripcion_EspecialistasScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Planes_de_Suscripcion_EspecialistasScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Planes_de_Suscripcion_EspecialistasModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Planes_de_Suscripcion_EspecialistasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Planes_de_Suscripcion_EspecialistasScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Planes_de_Suscripcion_EspecialistasScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Planes_de_Suscripcion_EspecialistasScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Planes_de_Suscripcion_Especialistas.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Planes_de_Suscripcion_Especialistas.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Planes_de_Suscripcion_Especialistas.js")))
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
        public ActionResult Detalle_Planes_de_Suscripcion_EspecialistasPropertyBag()
        {
            return PartialView("Detalle_Planes_de_Suscripcion_EspecialistasPropertyBag", "Detalle_Planes_de_Suscripcion_Especialistas");
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

            _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Planes_de_Suscripcion_EspecialistasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Planes_de_Suscripcion_Especialistass == null)
                result.Detalle_Planes_de_Suscripcion_Especialistass = new List<Detalle_Planes_de_Suscripcion_Especialistas>();

            var data = result.Detalle_Planes_de_Suscripcion_Especialistass.Select(m => new Detalle_Planes_de_Suscripcion_EspecialistasGridModel
            {
                Folio = m.Folio
                ,Plan_de_SuscripcionNombre = (string)m.Plan_de_Suscripcion_Planes_de_Suscripcion_Especialistas.Nombre
                ,Fecha_de_inicio = (m.Fecha_de_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_inicio).ToString(ConfigurationProperty.DateFormat))
                ,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                ,Frecuencia_de_PagoNombre = (string)m.Frecuencia_de_Pago_Frecuencia_de_pago_Especialistas.Nombre
                ,Costo = m.Costo
                ,Firmo_Contrato = m.Firmo_Contrato
                ,EstatusDescripcion = (string)m.Estatus_Estatus_de_Suscripcion.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Planes_de_Suscripcion_EspecialistasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Planes_de_Suscripcion_EspecialistasList_" + DateTime.Now.ToString());
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

            _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Planes_de_Suscripcion_EspecialistasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Planes_de_Suscripcion_EspecialistasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Planes_de_Suscripcion_Especialistass == null)
                result.Detalle_Planes_de_Suscripcion_Especialistass = new List<Detalle_Planes_de_Suscripcion_Especialistas>();

            var data = result.Detalle_Planes_de_Suscripcion_Especialistass.Select(m => new Detalle_Planes_de_Suscripcion_EspecialistasGridModel
            {
                Folio = m.Folio
                ,Plan_de_SuscripcionNombre = (string)m.Plan_de_Suscripcion_Planes_de_Suscripcion_Especialistas.Nombre
                ,Fecha_de_inicio = (m.Fecha_de_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_inicio).ToString(ConfigurationProperty.DateFormat))
                ,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                ,Frecuencia_de_PagoNombre = (string)m.Frecuencia_de_Pago_Frecuencia_de_pago_Especialistas.Nombre
                ,Costo = m.Costo
                ,Firmo_Contrato = m.Firmo_Contrato
                ,EstatusDescripcion = (string)m.Estatus_Estatus_de_Suscripcion.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
