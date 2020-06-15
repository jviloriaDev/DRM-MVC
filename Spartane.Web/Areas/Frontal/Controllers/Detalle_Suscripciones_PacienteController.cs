using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Suscripciones_Paciente;
using Spartane.Core.Domain.Planes_de_Suscripcion;
using Spartane.Core.Domain.Frecuencia_de_pago_Pacientes;
using Spartane.Core.Domain.Estatus_de_Suscripcion;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Suscripciones_Paciente;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Suscripciones_Paciente;
using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion;
using Spartane.Web.Areas.WebApiConsumer.Frecuencia_de_pago_Pacientes;
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
    public class Detalle_Suscripciones_PacienteController : Controller
    {
        #region "variable declaration"

        private IDetalle_Suscripciones_PacienteService service = null;
        private IDetalle_Suscripciones_PacienteApiConsumer _IDetalle_Suscripciones_PacienteApiConsumer;
        private IPlanes_de_SuscripcionApiConsumer _IPlanes_de_SuscripcionApiConsumer;
        private IFrecuencia_de_pago_PacientesApiConsumer _IFrecuencia_de_pago_PacientesApiConsumer;
        private IEstatus_de_SuscripcionApiConsumer _IEstatus_de_SuscripcionApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Suscripciones_PacienteController(IDetalle_Suscripciones_PacienteService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Suscripciones_PacienteApiConsumer Detalle_Suscripciones_PacienteApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IPlanes_de_SuscripcionApiConsumer Planes_de_SuscripcionApiConsumer , IFrecuencia_de_pago_PacientesApiConsumer Frecuencia_de_pago_PacientesApiConsumer , IEstatus_de_SuscripcionApiConsumer Estatus_de_SuscripcionApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Suscripciones_PacienteApiConsumer = Detalle_Suscripciones_PacienteApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IPlanes_de_SuscripcionApiConsumer = Planes_de_SuscripcionApiConsumer;
            this._IFrecuencia_de_pago_PacientesApiConsumer = Frecuencia_de_pago_PacientesApiConsumer;
            this._IEstatus_de_SuscripcionApiConsumer = Estatus_de_SuscripcionApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Suscripciones_Paciente
        [ObjectAuth(ObjectId = (ModuleObjectId)44398, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44398);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Suscripciones_Paciente/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44398, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44398);
            ViewBag.Permission = permission;
            var varDetalle_Suscripciones_Paciente = new Detalle_Suscripciones_PacienteModel();
			
            ViewBag.ObjectId = "44398";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Suscripciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Suscripciones_PacienteData = _IDetalle_Suscripciones_PacienteApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Suscripciones_Pacientes[0];
                if (Detalle_Suscripciones_PacienteData == null)
                    return HttpNotFound();

                varDetalle_Suscripciones_Paciente = new Detalle_Suscripciones_PacienteModel
                {
                    Folio = (int)Detalle_Suscripciones_PacienteData.Folio
                    ,Suscripcion = Detalle_Suscripciones_PacienteData.Suscripcion
                    ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(Convert.ToString(Detalle_Suscripciones_PacienteData.Suscripcion), "Planes_de_Suscripcion") ??  (string)Detalle_Suscripciones_PacienteData.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                    ,Fecha_de_inicio = (Detalle_Suscripciones_PacienteData.Fecha_de_inicio == null ? string.Empty : Convert.ToDateTime(Detalle_Suscripciones_PacienteData.Fecha_de_inicio).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin = (Detalle_Suscripciones_PacienteData.Fecha_fin == null ? string.Empty : Convert.ToDateTime(Detalle_Suscripciones_PacienteData.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                    ,Nombre_de_la_Suscripcion = Detalle_Suscripciones_PacienteData.Nombre_de_la_Suscripcion
                    ,Frecuencia_de_Pago = Detalle_Suscripciones_PacienteData.Frecuencia_de_Pago
                    ,Frecuencia_de_PagoNombre = CultureHelper.GetTraduction(Convert.ToString(Detalle_Suscripciones_PacienteData.Frecuencia_de_Pago), "Frecuencia_de_pago_Pacientes") ??  (string)Detalle_Suscripciones_PacienteData.Frecuencia_de_Pago_Frecuencia_de_pago_Pacientes.Nombre
                    ,Costo = Detalle_Suscripciones_PacienteData.Costo
                    ,Estatus = Detalle_Suscripciones_PacienteData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Suscripciones_PacienteData.Estatus), "Estatus_de_Suscripcion") ??  (string)Detalle_Suscripciones_PacienteData.Estatus_Estatus_de_Suscripcion.Descripcion

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
	    _IFrecuencia_de_pago_PacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Frecuencia_de_pago_Pacientess_Frecuencia_de_Pago = _IFrecuencia_de_pago_PacientesApiConsumer.SelAll(true);
            if (Frecuencia_de_pago_Pacientess_Frecuencia_de_Pago != null && Frecuencia_de_pago_Pacientess_Frecuencia_de_Pago.Resource != null)
                ViewBag.Frecuencia_de_pago_Pacientess_Frecuencia_de_Pago = Frecuencia_de_pago_Pacientess_Frecuencia_de_Pago.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Frecuencia_de_pago_Pacientes", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
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
            return View(varDetalle_Suscripciones_Paciente);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Suscripciones_Paciente(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44398);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Suscripciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Suscripciones_PacienteModel varDetalle_Suscripciones_Paciente= new Detalle_Suscripciones_PacienteModel();


            if (id.ToString() != "0")
            {
                var Detalle_Suscripciones_PacientesData = _IDetalle_Suscripciones_PacienteApiConsumer.ListaSelAll(0, 1000, "Detalle_Suscripciones_Paciente.Folio=" + id, "").Resource.Detalle_Suscripciones_Pacientes;
				
				if (Detalle_Suscripciones_PacientesData != null && Detalle_Suscripciones_PacientesData.Count > 0)
                {
					var Detalle_Suscripciones_PacienteData = Detalle_Suscripciones_PacientesData.First();
					varDetalle_Suscripciones_Paciente= new Detalle_Suscripciones_PacienteModel
					{
						Folio  = Detalle_Suscripciones_PacienteData.Folio 
	                    ,Suscripcion = Detalle_Suscripciones_PacienteData.Suscripcion
                    ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(Convert.ToString(Detalle_Suscripciones_PacienteData.Suscripcion), "Planes_de_Suscripcion") ??  (string)Detalle_Suscripciones_PacienteData.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                    ,Fecha_de_inicio = (Detalle_Suscripciones_PacienteData.Fecha_de_inicio == null ? string.Empty : Convert.ToDateTime(Detalle_Suscripciones_PacienteData.Fecha_de_inicio).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin = (Detalle_Suscripciones_PacienteData.Fecha_fin == null ? string.Empty : Convert.ToDateTime(Detalle_Suscripciones_PacienteData.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                    ,Nombre_de_la_Suscripcion = Detalle_Suscripciones_PacienteData.Nombre_de_la_Suscripcion
                    ,Frecuencia_de_Pago = Detalle_Suscripciones_PacienteData.Frecuencia_de_Pago
                    ,Frecuencia_de_PagoNombre = CultureHelper.GetTraduction(Convert.ToString(Detalle_Suscripciones_PacienteData.Frecuencia_de_Pago), "Frecuencia_de_pago_Pacientes") ??  (string)Detalle_Suscripciones_PacienteData.Frecuencia_de_Pago_Frecuencia_de_pago_Pacientes.Nombre
                    ,Costo = Detalle_Suscripciones_PacienteData.Costo
                    ,Estatus = Detalle_Suscripciones_PacienteData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Suscripciones_PacienteData.Estatus), "Estatus_de_Suscripcion") ??  (string)Detalle_Suscripciones_PacienteData.Estatus_Estatus_de_Suscripcion.Descripcion

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
	    _IFrecuencia_de_pago_PacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Frecuencia_de_pago_Pacientess_Frecuencia_de_Pago = _IFrecuencia_de_pago_PacientesApiConsumer.SelAll(true);
            if (Frecuencia_de_pago_Pacientess_Frecuencia_de_Pago != null && Frecuencia_de_pago_Pacientess_Frecuencia_de_Pago.Resource != null)
                ViewBag.Frecuencia_de_pago_Pacientess_Frecuencia_de_Pago = Frecuencia_de_pago_Pacientess_Frecuencia_de_Pago.Resource.Where(m => m.Nombre != null).OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Frecuencia_de_pago_Pacientes", "Nombre") ?? m.Nombre.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_de_Suscripcions_Estatus = _IEstatus_de_SuscripcionApiConsumer.SelAll(true);
            if (Estatus_de_Suscripcions_Estatus != null && Estatus_de_Suscripcions_Estatus.Resource != null)
                ViewBag.Estatus_de_Suscripcions_Estatus = Estatus_de_Suscripcions_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_de_Suscripcion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_Suscripciones_Paciente", varDetalle_Suscripciones_Paciente);
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
        public ActionResult GetFrecuencia_de_pago_PacientesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IFrecuencia_de_pago_PacientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IFrecuencia_de_pago_PacientesApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Nombre).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Frecuencia_de_pago_Pacientes", "Nombre")?? m.Nombre,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Suscripciones_PacientePropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Suscripciones_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Suscripciones_Pacientes == null)
                result.Detalle_Suscripciones_Pacientes = new List<Detalle_Suscripciones_Paciente>();

            return Json(new
            {
                data = result.Detalle_Suscripciones_Pacientes.Select(m => new Detalle_Suscripciones_PacienteGridModel
                    {
                    Folio = m.Folio
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Nombre_del_Plan") ?? (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                        ,Fecha_de_inicio = (m.Fecha_de_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_inicio).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
			,Nombre_de_la_Suscripcion = m.Nombre_de_la_Suscripcion
                        ,Frecuencia_de_PagoNombre = CultureHelper.GetTraduction(m.Frecuencia_de_Pago_Frecuencia_de_pago_Pacientes.Clave.ToString(), "Frecuencia_de_pago_Pacientes") ?? (string)m.Frecuencia_de_Pago_Frecuencia_de_pago_Pacientes.Nombre
			,Costo = m.Costo
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus_de_Suscripcion.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus_de_Suscripcion.Descripcion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetDetalle_Suscripciones_Paciente_Frecuencia_de_Pago_Frecuencia_de_pago_Pacientes(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IFrecuencia_de_pago_PacientesApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Frecuencia_de_pago_Pacientes.Clave as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Frecuencia_de_pago_Pacientes.Nombre as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _IFrecuencia_de_pago_PacientesApiConsumer.ListaSelAll(1, 20,elWhere , " Frecuencia_de_pago_Pacientes.Nombre ASC ").Resource;
               
                foreach (var item in result.Frecuencia_de_pago_Pacientess)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Frecuencia_de_pago_Pacientes", "Nombre");
                    item.Nombre =trans ??item.Nombre;
                }
                return Json(result.Frecuencia_de_pago_Pacientess.ToArray(), JsonRequestBehavior.AllowGet);
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
                _IDetalle_Suscripciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Suscripciones_Paciente varDetalle_Suscripciones_Paciente = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Suscripciones_PacienteApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Suscripciones_PacienteModel varDetalle_Suscripciones_Paciente)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Suscripciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Suscripciones_PacienteInfo = new Detalle_Suscripciones_Paciente
                    {
                        Folio = varDetalle_Suscripciones_Paciente.Folio
                        ,Suscripcion = varDetalle_Suscripciones_Paciente.Suscripcion
                        ,Fecha_de_inicio = (!String.IsNullOrEmpty(varDetalle_Suscripciones_Paciente.Fecha_de_inicio)) ? DateTime.ParseExact(varDetalle_Suscripciones_Paciente.Fecha_de_inicio, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Fecha_fin = (!String.IsNullOrEmpty(varDetalle_Suscripciones_Paciente.Fecha_fin)) ? DateTime.ParseExact(varDetalle_Suscripciones_Paciente.Fecha_fin, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Nombre_de_la_Suscripcion = varDetalle_Suscripciones_Paciente.Nombre_de_la_Suscripcion
                        ,Frecuencia_de_Pago = varDetalle_Suscripciones_Paciente.Frecuencia_de_Pago
                        ,Costo = varDetalle_Suscripciones_Paciente.Costo
                        ,Estatus = varDetalle_Suscripciones_Paciente.Estatus

                    };

                    result = !IsNew ?
                        _IDetalle_Suscripciones_PacienteApiConsumer.Update(Detalle_Suscripciones_PacienteInfo, null, null).Resource.ToString() :
                         _IDetalle_Suscripciones_PacienteApiConsumer.Insert(Detalle_Suscripciones_PacienteInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Suscripciones_Paciente script
        /// </summary>
        /// <param name="oDetalle_Suscripciones_PacienteElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Suscripciones_PacienteModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Suscripciones_PacienteModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Suscripciones_PacienteModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Suscripciones_PacienteModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Suscripciones_PacienteModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Suscripciones_PacienteModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Suscripciones_PacienteModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Suscripciones_PacienteModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Suscripciones_PacienteModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Suscripciones_PacienteModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Suscripciones_PacienteModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Suscripciones_PacienteModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Suscripciones_PacienteScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Suscripciones_Paciente.js")))
            {
                strDetalle_Suscripciones_PacienteScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Suscripciones_Paciente element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Suscripciones_PacienteModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Suscripciones_PacienteScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Suscripciones_PacienteScript.Substring(indexOfArray, strDetalle_Suscripciones_PacienteScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Suscripciones_PacienteModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Suscripciones_PacienteModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Suscripciones_PacienteScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Suscripciones_PacienteScript.Substring(indexOfArrayHistory, strDetalle_Suscripciones_PacienteScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Suscripciones_PacienteScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Suscripciones_PacienteScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Suscripciones_PacienteScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Suscripciones_PacienteModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Suscripciones_PacienteScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Suscripciones_PacienteScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Suscripciones_PacienteScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Suscripciones_PacienteScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Suscripciones_Paciente.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Suscripciones_Paciente.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Suscripciones_Paciente.js")))
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
        public ActionResult Detalle_Suscripciones_PacientePropertyBag()
        {
            return PartialView("Detalle_Suscripciones_PacientePropertyBag", "Detalle_Suscripciones_Paciente");
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

            _IDetalle_Suscripciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Suscripciones_PacientePropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Suscripciones_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Suscripciones_Pacientes == null)
                result.Detalle_Suscripciones_Pacientes = new List<Detalle_Suscripciones_Paciente>();

            var data = result.Detalle_Suscripciones_Pacientes.Select(m => new Detalle_Suscripciones_PacienteGridModel
            {
                Folio = m.Folio
                ,SuscripcionNombre_del_Plan = (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                ,Fecha_de_inicio = (m.Fecha_de_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_inicio).ToString(ConfigurationProperty.DateFormat))
                ,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                ,Nombre_de_la_Suscripcion = m.Nombre_de_la_Suscripcion
                ,Frecuencia_de_PagoNombre = (string)m.Frecuencia_de_Pago_Frecuencia_de_pago_Pacientes.Nombre
                ,Costo = m.Costo
                ,EstatusDescripcion = (string)m.Estatus_Estatus_de_Suscripcion.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Suscripciones_PacienteList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Suscripciones_PacienteList_" + DateTime.Now.ToString());
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

            _IDetalle_Suscripciones_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Suscripciones_PacientePropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Suscripciones_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Suscripciones_Pacientes == null)
                result.Detalle_Suscripciones_Pacientes = new List<Detalle_Suscripciones_Paciente>();

            var data = result.Detalle_Suscripciones_Pacientes.Select(m => new Detalle_Suscripciones_PacienteGridModel
            {
                Folio = m.Folio
                ,SuscripcionNombre_del_Plan = (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                ,Fecha_de_inicio = (m.Fecha_de_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_inicio).ToString(ConfigurationProperty.DateFormat))
                ,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                ,Nombre_de_la_Suscripcion = m.Nombre_de_la_Suscripcion
                ,Frecuencia_de_PagoNombre = (string)m.Frecuencia_de_Pago_Frecuencia_de_pago_Pacientes.Nombre
                ,Costo = m.Costo
                ,EstatusDescripcion = (string)m.Estatus_Estatus_de_Suscripcion.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
