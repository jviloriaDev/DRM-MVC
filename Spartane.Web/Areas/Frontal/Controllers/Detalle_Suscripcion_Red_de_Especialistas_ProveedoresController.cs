using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Suscripcion_Red_de_Especialistas_Proveedores;
using Spartane.Core.Domain.Planes_de_Suscripcion_Proveedores;
using Spartane.Core.Domain.Estatus_de_Suscripcion;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Suscripcion_Red_de_Especialistas_Proveedores;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Suscripcion_Red_de_Especialistas_Proveedores;
using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion_Proveedores;
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
    public class Detalle_Suscripcion_Red_de_Especialistas_ProveedoresController : Controller
    {
        #region "variable declaration"

        private IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresService service = null;
        private IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer;
        private IPlanes_de_Suscripcion_ProveedoresApiConsumer _IPlanes_de_Suscripcion_ProveedoresApiConsumer;
        private IEstatus_de_SuscripcionApiConsumer _IEstatus_de_SuscripcionApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Suscripcion_Red_de_Especialistas_ProveedoresController(IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer Detalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IPlanes_de_Suscripcion_ProveedoresApiConsumer Planes_de_Suscripcion_ProveedoresApiConsumer , IEstatus_de_SuscripcionApiConsumer Estatus_de_SuscripcionApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IPlanes_de_Suscripcion_ProveedoresApiConsumer = Planes_de_Suscripcion_ProveedoresApiConsumer;
            this._IEstatus_de_SuscripcionApiConsumer = Estatus_de_SuscripcionApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Suscripcion_Red_de_Especialistas_Proveedores
        [ObjectAuth(ObjectId = (ModuleObjectId)44595, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44595);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Suscripcion_Red_de_Especialistas_Proveedores/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44595, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44595);
            ViewBag.Permission = permission;
            var varDetalle_Suscripcion_Red_de_Especialistas_Proveedores = new Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModel();
			
            ViewBag.ObjectId = "44595";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData = _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress[0];
                if (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData == null)
                    return HttpNotFound();

                varDetalle_Suscripcion_Red_de_Especialistas_Proveedores = new Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModel
                {
                    Folio = (int)Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Folio
                    ,Plan_de_Suscripcion = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Plan_de_Suscripcion
                    ,Plan_de_SuscripcionDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Plan_de_Suscripcion), "Planes_de_Suscripcion_Proveedores") ??  (string)Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Plan_de_Suscripcion_Planes_de_Suscripcion_Proveedores.Descripcion
                    ,Fecha_inicio = (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Fecha_inicio == null ? string.Empty : Convert.ToDateTime(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Fecha_inicio).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin = (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Fecha_fin == null ? string.Empty : Convert.ToDateTime(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                    ,Costo = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Costo
                    ,Contrato = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Contrato
                    ,Firmo_Contrato = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Firmo_Contrato.GetValueOrDefault()
                    ,Estatus = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Estatus), "Estatus_de_Suscripcion") ??  (string)Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Estatus_Estatus_de_Suscripcion.Descripcion

                };
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.ContratoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.Contrato).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPlanes_de_Suscripcion_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Planes_de_Suscripcion_Proveedoress_Plan_de_Suscripcion = _IPlanes_de_Suscripcion_ProveedoresApiConsumer.SelAll(true);
            if (Planes_de_Suscripcion_Proveedoress_Plan_de_Suscripcion != null && Planes_de_Suscripcion_Proveedoress_Plan_de_Suscripcion.Resource != null)
                ViewBag.Planes_de_Suscripcion_Proveedoress_Plan_de_Suscripcion = Planes_de_Suscripcion_Proveedoress_Plan_de_Suscripcion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Planes_de_Suscripcion_Proveedores", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
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
            return View(varDetalle_Suscripcion_Red_de_Especialistas_Proveedores);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Suscripcion_Red_de_Especialistas_Proveedores(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44595);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModel varDetalle_Suscripcion_Red_de_Especialistas_Proveedores= new Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModel();


            if (id.ToString() != "0")
            {
                var Detalle_Suscripcion_Red_de_Especialistas_ProveedoressData = _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.ListaSelAll(0, 1000, "Detalle_Suscripcion_Red_de_Especialistas_Proveedores.Folio=" + id, "").Resource.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress;
				
				if (Detalle_Suscripcion_Red_de_Especialistas_ProveedoressData != null && Detalle_Suscripcion_Red_de_Especialistas_ProveedoressData.Count > 0)
                {
					var Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData = Detalle_Suscripcion_Red_de_Especialistas_ProveedoressData.First();
					varDetalle_Suscripcion_Red_de_Especialistas_Proveedores= new Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModel
					{
						Folio  = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Folio 
	                    ,Plan_de_Suscripcion = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Plan_de_Suscripcion
                    ,Plan_de_SuscripcionDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Plan_de_Suscripcion), "Planes_de_Suscripcion_Proveedores") ??  (string)Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Plan_de_Suscripcion_Planes_de_Suscripcion_Proveedores.Descripcion
                    ,Fecha_inicio = (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Fecha_inicio == null ? string.Empty : Convert.ToDateTime(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Fecha_inicio).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin = (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Fecha_fin == null ? string.Empty : Convert.ToDateTime(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                    ,Costo = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Costo
                    ,Contrato = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Contrato
                    ,Firmo_Contrato = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Firmo_Contrato.GetValueOrDefault()
                    ,Estatus = Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Estatus), "Estatus_de_Suscripcion") ??  (string)Detalle_Suscripcion_Red_de_Especialistas_ProveedoresData.Estatus_Estatus_de_Suscripcion.Descripcion

					};
				}
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.ContratoSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.Contrato).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPlanes_de_Suscripcion_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Planes_de_Suscripcion_Proveedoress_Plan_de_Suscripcion = _IPlanes_de_Suscripcion_ProveedoresApiConsumer.SelAll(true);
            if (Planes_de_Suscripcion_Proveedoress_Plan_de_Suscripcion != null && Planes_de_Suscripcion_Proveedoress_Plan_de_Suscripcion.Resource != null)
                ViewBag.Planes_de_Suscripcion_Proveedoress_Plan_de_Suscripcion = Planes_de_Suscripcion_Proveedoress_Plan_de_Suscripcion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Planes_de_Suscripcion_Proveedores", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_de_Suscripcions_Estatus = _IEstatus_de_SuscripcionApiConsumer.SelAll(true);
            if (Estatus_de_Suscripcions_Estatus != null && Estatus_de_Suscripcions_Estatus.Resource != null)
                ViewBag.Estatus_de_Suscripcions_Estatus = Estatus_de_Suscripcions_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_de_Suscripcion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_Suscripcion_Red_de_Especialistas_Proveedores", varDetalle_Suscripcion_Red_de_Especialistas_Proveedores);
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
        public ActionResult GetPlanes_de_Suscripcion_ProveedoresAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPlanes_de_Suscripcion_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPlanes_de_Suscripcion_ProveedoresApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Planes_de_Suscripcion_Proveedores", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Suscripcion_Red_de_Especialistas_ProveedoresPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress == null)
                result.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress = new List<Detalle_Suscripcion_Red_de_Especialistas_Proveedores>();

            return Json(new
            {
                data = result.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress.Select(m => new Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGridModel
                    {
                    Folio = m.Folio
                        ,Plan_de_SuscripcionDescripcion = CultureHelper.GetTraduction(m.Plan_de_Suscripcion_Planes_de_Suscripcion_Proveedores.Clave.ToString(), "Descripcion") ?? (string)m.Plan_de_Suscripcion_Planes_de_Suscripcion_Proveedores.Descripcion
                        ,Fecha_inicio = (m.Fecha_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
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
                _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Suscripcion_Red_de_Especialistas_Proveedores varDetalle_Suscripcion_Red_de_Especialistas_Proveedores = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModel varDetalle_Suscripcion_Red_de_Especialistas_Proveedores)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);


                    if (varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.ContratoRemoveAttachment != 0 && varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.ContratoFile == null)
                    {
                        varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.Contrato = 0;
                    }

                    if (varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.ContratoFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.ContratoFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.Contrato = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.ContratoFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                    
                    var result = "";
                    var Detalle_Suscripcion_Red_de_Especialistas_ProveedoresInfo = new Detalle_Suscripcion_Red_de_Especialistas_Proveedores
                    {
                        Folio = varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.Folio
                        ,Plan_de_Suscripcion = varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.Plan_de_Suscripcion
                        ,Fecha_inicio = (!String.IsNullOrEmpty(varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.Fecha_inicio)) ? DateTime.ParseExact(varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.Fecha_inicio, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Fecha_fin = (!String.IsNullOrEmpty(varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.Fecha_fin)) ? DateTime.ParseExact(varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.Fecha_fin, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Costo = varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.Costo
                        ,Contrato = (varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.Contrato.HasValue && varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.Contrato != 0) ? ((int?)Convert.ToInt32(varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.Contrato.Value)) : null

                        ,Firmo_Contrato = varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.Firmo_Contrato
                        ,Estatus = varDetalle_Suscripcion_Red_de_Especialistas_Proveedores.Estatus

                    };

                    result = !IsNew ?
                        _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.Update(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresInfo, null, null).Resource.ToString() :
                         _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.Insert(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Suscripcion_Red_de_Especialistas_Proveedores script
        /// </summary>
        /// <param name="oDetalle_Suscripcion_Red_de_Especialistas_ProveedoresElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Suscripcion_Red_de_Especialistas_ProveedoresScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Suscripcion_Red_de_Especialistas_Proveedores.js")))
            {
                strDetalle_Suscripcion_Red_de_Especialistas_ProveedoresScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Suscripcion_Red_de_Especialistas_Proveedores element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Suscripcion_Red_de_Especialistas_ProveedoresScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Suscripcion_Red_de_Especialistas_ProveedoresScript.Substring(indexOfArray, strDetalle_Suscripcion_Red_de_Especialistas_ProveedoresScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Suscripcion_Red_de_Especialistas_ProveedoresScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Suscripcion_Red_de_Especialistas_ProveedoresScript.Substring(indexOfArrayHistory, strDetalle_Suscripcion_Red_de_Especialistas_ProveedoresScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Suscripcion_Red_de_Especialistas_ProveedoresScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Suscripcion_Red_de_Especialistas_ProveedoresScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Suscripcion_Red_de_Especialistas_ProveedoresScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Suscripcion_Red_de_Especialistas_ProveedoresModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Suscripcion_Red_de_Especialistas_ProveedoresScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Suscripcion_Red_de_Especialistas_ProveedoresScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Suscripcion_Red_de_Especialistas_ProveedoresScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Suscripcion_Red_de_Especialistas_ProveedoresScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Suscripcion_Red_de_Especialistas_Proveedores.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Suscripcion_Red_de_Especialistas_Proveedores.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Suscripcion_Red_de_Especialistas_Proveedores.js")))
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
        public ActionResult Detalle_Suscripcion_Red_de_Especialistas_ProveedoresPropertyBag()
        {
            return PartialView("Detalle_Suscripcion_Red_de_Especialistas_ProveedoresPropertyBag", "Detalle_Suscripcion_Red_de_Especialistas_Proveedores");
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

            _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Suscripcion_Red_de_Especialistas_ProveedoresPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress == null)
                result.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress = new List<Detalle_Suscripcion_Red_de_Especialistas_Proveedores>();

            var data = result.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress.Select(m => new Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGridModel
            {
                Folio = m.Folio
                ,Plan_de_SuscripcionDescripcion = (string)m.Plan_de_Suscripcion_Planes_de_Suscripcion_Proveedores.Descripcion
                ,Fecha_inicio = (m.Fecha_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio).ToString(ConfigurationProperty.DateFormat))
                ,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                ,Costo = m.Costo
                ,Firmo_Contrato = m.Firmo_Contrato
                ,EstatusDescripcion = (string)m.Estatus_Estatus_de_Suscripcion.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Suscripcion_Red_de_Especialistas_ProveedoresList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Suscripcion_Red_de_Especialistas_ProveedoresList_" + DateTime.Now.ToString());
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

            _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Suscripcion_Red_de_Especialistas_ProveedoresPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Suscripcion_Red_de_Especialistas_ProveedoresApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress == null)
                result.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress = new List<Detalle_Suscripcion_Red_de_Especialistas_Proveedores>();

            var data = result.Detalle_Suscripcion_Red_de_Especialistas_Proveedoress.Select(m => new Detalle_Suscripcion_Red_de_Especialistas_ProveedoresGridModel
            {
                Folio = m.Folio
                ,Plan_de_SuscripcionDescripcion = (string)m.Plan_de_Suscripcion_Planes_de_Suscripcion_Proveedores.Descripcion
                ,Fecha_inicio = (m.Fecha_inicio == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio).ToString(ConfigurationProperty.DateFormat))
                ,Fecha_fin = (m.Fecha_fin == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin).ToString(ConfigurationProperty.DateFormat))
                ,Costo = m.Costo
                ,Firmo_Contrato = m.Firmo_Contrato
                ,EstatusDescripcion = (string)m.Estatus_Estatus_de_Suscripcion.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
