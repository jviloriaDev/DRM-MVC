using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_de_Padecimientos;
using Spartane.Core.Domain.Padecimientos;
using Spartane.Core.Domain.Tiempo_Padecimiento;
using Spartane.Core.Domain.Respuesta_Logica;
using Spartane.Core.Domain.Estatus_Padecimiento;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_de_Padecimientos;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_de_Padecimientos;
using Spartane.Web.Areas.WebApiConsumer.Padecimientos;
using Spartane.Web.Areas.WebApiConsumer.Tiempo_Padecimiento;
using Spartane.Web.Areas.WebApiConsumer.Respuesta_Logica;
using Spartane.Web.Areas.WebApiConsumer.Estatus_Padecimiento;

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
    public class Detalle_de_PadecimientosController : Controller
    {
        #region "variable declaration"

        private IDetalle_de_PadecimientosService service = null;
        private IDetalle_de_PadecimientosApiConsumer _IDetalle_de_PadecimientosApiConsumer;
        private IPadecimientosApiConsumer _IPadecimientosApiConsumer;
        private ITiempo_PadecimientoApiConsumer _ITiempo_PadecimientoApiConsumer;
        private IRespuesta_LogicaApiConsumer _IRespuesta_LogicaApiConsumer;
        private IEstatus_PadecimientoApiConsumer _IEstatus_PadecimientoApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_de_PadecimientosController(IDetalle_de_PadecimientosService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_de_PadecimientosApiConsumer Detalle_de_PadecimientosApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IPadecimientosApiConsumer PadecimientosApiConsumer , ITiempo_PadecimientoApiConsumer Tiempo_PadecimientoApiConsumer , IRespuesta_LogicaApiConsumer Respuesta_LogicaApiConsumer , IEstatus_PadecimientoApiConsumer Estatus_PadecimientoApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_de_PadecimientosApiConsumer = Detalle_de_PadecimientosApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IPadecimientosApiConsumer = PadecimientosApiConsumer;
            this._ITiempo_PadecimientoApiConsumer = Tiempo_PadecimientoApiConsumer;
            this._IRespuesta_LogicaApiConsumer = Respuesta_LogicaApiConsumer;
            this._IEstatus_PadecimientoApiConsumer = Estatus_PadecimientoApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_de_Padecimientos
        [ObjectAuth(ObjectId = (ModuleObjectId)44309, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44309);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_de_Padecimientos/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44309, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44309);
            ViewBag.Permission = permission;
            var varDetalle_de_Padecimientos = new Detalle_de_PadecimientosModel();
			
            ViewBag.ObjectId = "44309";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_de_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_de_PadecimientosData = _IDetalle_de_PadecimientosApiConsumer.GetByKeyComplete(Id).Resource.Detalle_de_Padecimientoss[0];
                if (Detalle_de_PadecimientosData == null)
                    return HttpNotFound();

                varDetalle_de_Padecimientos = new Detalle_de_PadecimientosModel
                {
                    Folio = (int)Detalle_de_PadecimientosData.Folio
                    ,Padecimiento = Detalle_de_PadecimientosData.Padecimiento
                    ,PadecimientoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_PadecimientosData.Padecimiento), "Padecimientos") ??  (string)Detalle_de_PadecimientosData.Padecimiento_Padecimientos.Descripcion
                    ,Tiempo_con_el_diagnostico = Detalle_de_PadecimientosData.Tiempo_con_el_diagnostico
                    ,Tiempo_con_el_diagnosticoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_PadecimientosData.Tiempo_con_el_diagnostico), "Tiempo_Padecimiento") ??  (string)Detalle_de_PadecimientosData.Tiempo_con_el_diagnostico_Tiempo_Padecimiento.Descripcion
                    ,Intervencion_quirurgica = Detalle_de_PadecimientosData.Intervencion_quirurgica
                    ,Intervencion_quirurgicaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_PadecimientosData.Intervencion_quirurgica), "Respuesta_Logica") ??  (string)Detalle_de_PadecimientosData.Intervencion_quirurgica_Respuesta_Logica.Descripcion
                    ,Tratamiento = Detalle_de_PadecimientosData.Tratamiento
                    ,Estado_actual = Detalle_de_PadecimientosData.Estado_actual
                    ,Estado_actualDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_PadecimientosData.Estado_actual), "Estatus_Padecimiento") ??  (string)Detalle_de_PadecimientosData.Estado_actual_Estatus_Padecimiento.Descripcion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Padecimientoss_Padecimiento = _IPadecimientosApiConsumer.SelAll(true);
            if (Padecimientoss_Padecimiento != null && Padecimientoss_Padecimiento.Resource != null)
                ViewBag.Padecimientoss_Padecimiento = Padecimientoss_Padecimiento.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Padecimientos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITiempo_PadecimientoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tiempo_Padecimientos_Tiempo_con_el_diagnostico = _ITiempo_PadecimientoApiConsumer.SelAll(true);
            if (Tiempo_Padecimientos_Tiempo_con_el_diagnostico != null && Tiempo_Padecimientos_Tiempo_con_el_diagnostico.Resource != null)
                ViewBag.Tiempo_Padecimientos_Tiempo_con_el_diagnostico = Tiempo_Padecimientos_Tiempo_con_el_diagnostico.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tiempo_Padecimiento", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Intervencion_quirurgica = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Intervencion_quirurgica != null && Respuesta_Logicas_Intervencion_quirurgica.Resource != null)
                ViewBag.Respuesta_Logicas_Intervencion_quirurgica = Respuesta_Logicas_Intervencion_quirurgica.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_PadecimientoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Padecimientos_Estado_actual = _IEstatus_PadecimientoApiConsumer.SelAll(true);
            if (Estatus_Padecimientos_Estado_actual != null && Estatus_Padecimientos_Estado_actual.Resource != null)
                ViewBag.Estatus_Padecimientos_Estado_actual = Estatus_Padecimientos_Estado_actual.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Padecimiento", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_de_Padecimientos);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_de_Padecimientos(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44309);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_de_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_de_PadecimientosModel varDetalle_de_Padecimientos= new Detalle_de_PadecimientosModel();


            if (id.ToString() != "0")
            {
                var Detalle_de_PadecimientossData = _IDetalle_de_PadecimientosApiConsumer.ListaSelAll(0, 1000, "Detalle_de_Padecimientos.Folio=" + id, "").Resource.Detalle_de_Padecimientoss;
				
				if (Detalle_de_PadecimientossData != null && Detalle_de_PadecimientossData.Count > 0)
                {
					var Detalle_de_PadecimientosData = Detalle_de_PadecimientossData.First();
					varDetalle_de_Padecimientos= new Detalle_de_PadecimientosModel
					{
						Folio  = Detalle_de_PadecimientosData.Folio 
	                    ,Padecimiento = Detalle_de_PadecimientosData.Padecimiento
                    ,PadecimientoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_PadecimientosData.Padecimiento), "Padecimientos") ??  (string)Detalle_de_PadecimientosData.Padecimiento_Padecimientos.Descripcion
                    ,Tiempo_con_el_diagnostico = Detalle_de_PadecimientosData.Tiempo_con_el_diagnostico
                    ,Tiempo_con_el_diagnosticoDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_PadecimientosData.Tiempo_con_el_diagnostico), "Tiempo_Padecimiento") ??  (string)Detalle_de_PadecimientosData.Tiempo_con_el_diagnostico_Tiempo_Padecimiento.Descripcion
                    ,Intervencion_quirurgica = Detalle_de_PadecimientosData.Intervencion_quirurgica
                    ,Intervencion_quirurgicaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_PadecimientosData.Intervencion_quirurgica), "Respuesta_Logica") ??  (string)Detalle_de_PadecimientosData.Intervencion_quirurgica_Respuesta_Logica.Descripcion
                    ,Tratamiento = Detalle_de_PadecimientosData.Tratamiento
                    ,Estado_actual = Detalle_de_PadecimientosData.Estado_actual
                    ,Estado_actualDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_PadecimientosData.Estado_actual), "Estatus_Padecimiento") ??  (string)Detalle_de_PadecimientosData.Estado_actual_Estatus_Padecimiento.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Padecimientoss_Padecimiento = _IPadecimientosApiConsumer.SelAll(true);
            if (Padecimientoss_Padecimiento != null && Padecimientoss_Padecimiento.Resource != null)
                ViewBag.Padecimientoss_Padecimiento = Padecimientoss_Padecimiento.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Padecimientos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _ITiempo_PadecimientoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tiempo_Padecimientos_Tiempo_con_el_diagnostico = _ITiempo_PadecimientoApiConsumer.SelAll(true);
            if (Tiempo_Padecimientos_Tiempo_con_el_diagnostico != null && Tiempo_Padecimientos_Tiempo_con_el_diagnostico.Resource != null)
                ViewBag.Tiempo_Padecimientos_Tiempo_con_el_diagnostico = Tiempo_Padecimientos_Tiempo_con_el_diagnostico.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tiempo_Padecimiento", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Respuesta_Logicas_Intervencion_quirurgica = _IRespuesta_LogicaApiConsumer.SelAll(true);
            if (Respuesta_Logicas_Intervencion_quirurgica != null && Respuesta_Logicas_Intervencion_quirurgica.Resource != null)
                ViewBag.Respuesta_Logicas_Intervencion_quirurgica = Respuesta_Logicas_Intervencion_quirurgica.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatus_PadecimientoApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatus_Padecimientos_Estado_actual = _IEstatus_PadecimientoApiConsumer.SelAll(true);
            if (Estatus_Padecimientos_Estado_actual != null && Estatus_Padecimientos_Estado_actual.Resource != null)
                ViewBag.Estatus_Padecimientos_Estado_actual = Estatus_Padecimientos_Estado_actual.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Padecimiento", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_de_Padecimientos", varDetalle_de_Padecimientos);
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
        public ActionResult GetPadecimientosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPadecimientosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Padecimientos", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetTiempo_PadecimientoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITiempo_PadecimientoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITiempo_PadecimientoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tiempo_Padecimiento", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetRespuesta_LogicaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRespuesta_LogicaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRespuesta_LogicaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Respuesta_Logica", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstatus_PadecimientoAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatus_PadecimientoApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatus_PadecimientoApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus_Padecimiento", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_de_PadecimientosPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_de_PadecimientosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_de_Padecimientoss == null)
                result.Detalle_de_Padecimientoss = new List<Detalle_de_Padecimientos>();

            return Json(new
            {
                data = result.Detalle_de_Padecimientoss.Select(m => new Detalle_de_PadecimientosGridModel
                    {
                    Folio = m.Folio
                        ,PadecimientoDescripcion = CultureHelper.GetTraduction(m.Padecimiento_Padecimientos.Clave.ToString(), "Descripcion") ?? (string)m.Padecimiento_Padecimientos.Descripcion
                        ,Tiempo_con_el_diagnosticoDescripcion = CultureHelper.GetTraduction(m.Tiempo_con_el_diagnostico_Tiempo_Padecimiento.Clave.ToString(), "Descripcion") ?? (string)m.Tiempo_con_el_diagnostico_Tiempo_Padecimiento.Descripcion
                        ,Intervencion_quirurgicaDescripcion = CultureHelper.GetTraduction(m.Intervencion_quirurgica_Respuesta_Logica.Clave.ToString(), "Descripcion") ?? (string)m.Intervencion_quirurgica_Respuesta_Logica.Descripcion
			,Tratamiento = m.Tratamiento
                        ,Estado_actualDescripcion = CultureHelper.GetTraduction(m.Estado_actual_Estatus_Padecimiento.Clave.ToString(), "Descripcion") ?? (string)m.Estado_actual_Estatus_Padecimiento.Descripcion

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
                _IDetalle_de_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_de_Padecimientos varDetalle_de_Padecimientos = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_de_PadecimientosApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_de_PadecimientosModel varDetalle_de_Padecimientos)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_de_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_de_PadecimientosInfo = new Detalle_de_Padecimientos
                    {
                        Folio = varDetalle_de_Padecimientos.Folio
                        ,Padecimiento = varDetalle_de_Padecimientos.Padecimiento
                        ,Tiempo_con_el_diagnostico = varDetalle_de_Padecimientos.Tiempo_con_el_diagnostico
                        ,Intervencion_quirurgica = varDetalle_de_Padecimientos.Intervencion_quirurgica
                        ,Tratamiento = varDetalle_de_Padecimientos.Tratamiento
                        ,Estado_actual = varDetalle_de_Padecimientos.Estado_actual

                    };

                    result = !IsNew ?
                        _IDetalle_de_PadecimientosApiConsumer.Update(Detalle_de_PadecimientosInfo, null, null).Resource.ToString() :
                         _IDetalle_de_PadecimientosApiConsumer.Insert(Detalle_de_PadecimientosInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_de_Padecimientos script
        /// </summary>
        /// <param name="oDetalle_de_PadecimientosElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_de_PadecimientosModuleAttributeList)
        {
            for (int i = 0; i < Detalle_de_PadecimientosModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_de_PadecimientosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_de_PadecimientosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_de_PadecimientosModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_de_PadecimientosModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_de_PadecimientosModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_de_PadecimientosModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_de_PadecimientosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_de_PadecimientosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_de_PadecimientosModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_de_PadecimientosModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_de_PadecimientosScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_de_Padecimientos.js")))
            {
                strDetalle_de_PadecimientosScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_de_Padecimientos element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_de_PadecimientosModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_de_PadecimientosScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_de_PadecimientosScript.Substring(indexOfArray, strDetalle_de_PadecimientosScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_de_PadecimientosModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_de_PadecimientosModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_de_PadecimientosScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_de_PadecimientosScript.Substring(indexOfArrayHistory, strDetalle_de_PadecimientosScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_de_PadecimientosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_de_PadecimientosScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_de_PadecimientosScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_de_PadecimientosModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_de_PadecimientosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_de_PadecimientosScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_de_PadecimientosScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_de_PadecimientosScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_de_Padecimientos.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_de_Padecimientos.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_de_Padecimientos.js")))
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
        public ActionResult Detalle_de_PadecimientosPropertyBag()
        {
            return PartialView("Detalle_de_PadecimientosPropertyBag", "Detalle_de_Padecimientos");
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

            _IDetalle_de_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_de_PadecimientosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_de_PadecimientosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_de_Padecimientoss == null)
                result.Detalle_de_Padecimientoss = new List<Detalle_de_Padecimientos>();

            var data = result.Detalle_de_Padecimientoss.Select(m => new Detalle_de_PadecimientosGridModel
            {
                Folio = m.Folio
                ,PadecimientoDescripcion = (string)m.Padecimiento_Padecimientos.Descripcion
                ,Tiempo_con_el_diagnosticoDescripcion = (string)m.Tiempo_con_el_diagnostico_Tiempo_Padecimiento.Descripcion
                ,Intervencion_quirurgicaDescripcion = (string)m.Intervencion_quirurgica_Respuesta_Logica.Descripcion
                ,Tratamiento = m.Tratamiento
                ,Estado_actualDescripcion = (string)m.Estado_actual_Estatus_Padecimiento.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_de_PadecimientosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_de_PadecimientosList_" + DateTime.Now.ToString());
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

            _IDetalle_de_PadecimientosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_de_PadecimientosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_de_PadecimientosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_de_Padecimientoss == null)
                result.Detalle_de_Padecimientoss = new List<Detalle_de_Padecimientos>();

            var data = result.Detalle_de_Padecimientoss.Select(m => new Detalle_de_PadecimientosGridModel
            {
                Folio = m.Folio
                ,PadecimientoDescripcion = (string)m.Padecimiento_Padecimientos.Descripcion
                ,Tiempo_con_el_diagnosticoDescripcion = (string)m.Tiempo_con_el_diagnostico_Tiempo_Padecimiento.Descripcion
                ,Intervencion_quirurgicaDescripcion = (string)m.Intervencion_quirurgica_Respuesta_Logica.Descripcion
                ,Tratamiento = m.Tratamiento
                ,Estado_actualDescripcion = (string)m.Estado_actual_Estatus_Padecimiento.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
