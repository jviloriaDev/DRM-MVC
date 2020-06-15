using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Codigos_Referidos;
using Spartane.Core.Domain.Planes_de_Suscripcion;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Estatus;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Codigos_Referidos;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Codigos_Referidos;
using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion;
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

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Detalle_Codigos_ReferidosController : Controller
    {
        #region "variable declaration"

        private IDetalle_Codigos_ReferidosService service = null;
        private IDetalle_Codigos_ReferidosApiConsumer _IDetalle_Codigos_ReferidosApiConsumer;
        private IPlanes_de_SuscripcionApiConsumer _IPlanes_de_SuscripcionApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IEstatusApiConsumer _IEstatusApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Codigos_ReferidosController(IDetalle_Codigos_ReferidosService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Codigos_ReferidosApiConsumer Detalle_Codigos_ReferidosApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IPlanes_de_SuscripcionApiConsumer Planes_de_SuscripcionApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IEstatusApiConsumer EstatusApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Codigos_ReferidosApiConsumer = Detalle_Codigos_ReferidosApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IPlanes_de_SuscripcionApiConsumer = Planes_de_SuscripcionApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._IEstatusApiConsumer = EstatusApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Codigos_Referidos
        [ObjectAuth(ObjectId = (ModuleObjectId)44420, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44420);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Codigos_Referidos/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44420, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44420);
            ViewBag.Permission = permission;
            var varDetalle_Codigos_Referidos = new Detalle_Codigos_ReferidosModel();
			
            ViewBag.ObjectId = "44420";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Codigos_ReferidosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Codigos_ReferidosData = _IDetalle_Codigos_ReferidosApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Codigos_Referidoss[0];
                if (Detalle_Codigos_ReferidosData == null)
                    return HttpNotFound();

                varDetalle_Codigos_Referidos = new Detalle_Codigos_ReferidosModel
                {
                    Folio = (int)Detalle_Codigos_ReferidosData.Folio
                    ,Suscripcion = Detalle_Codigos_ReferidosData.Suscripcion
                    ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(Convert.ToString(Detalle_Codigos_ReferidosData.Suscripcion), "Planes_de_Suscripcion") ??  (string)Detalle_Codigos_ReferidosData.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                    ,Porcentaje_de_descuento = Detalle_Codigos_ReferidosData.Porcentaje_de_descuento
                    ,Fecha_inicio_vigencia = (Detalle_Codigos_ReferidosData.Fecha_inicio_vigencia == null ? string.Empty : Convert.ToDateTime(Detalle_Codigos_ReferidosData.Fecha_inicio_vigencia).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin_vigencia = (Detalle_Codigos_ReferidosData.Fecha_fin_vigencia == null ? string.Empty : Convert.ToDateTime(Detalle_Codigos_ReferidosData.Fecha_fin_vigencia).ToString(ConfigurationProperty.DateFormat))
                    ,Cantidad_maxima_de_referenciados = Detalle_Codigos_ReferidosData.Cantidad_maxima_de_referenciados
                    ,Codigo_para_Referenciados = Detalle_Codigos_ReferidosData.Codigo_para_Referenciados
                    ,Autorizado = Detalle_Codigos_ReferidosData.Autorizado.GetValueOrDefault()
                    ,Usuario_que_autoriza = Detalle_Codigos_ReferidosData.Usuario_que_autoriza
                    ,Usuario_que_autorizaName = CultureHelper.GetTraduction(Convert.ToString(Detalle_Codigos_ReferidosData.Usuario_que_autoriza), "Spartan_User") ??  (string)Detalle_Codigos_ReferidosData.Usuario_que_autoriza_Spartan_User.Name
                    ,Fecha_de_autorizacion = (Detalle_Codigos_ReferidosData.Fecha_de_autorizacion == null ? string.Empty : Convert.ToDateTime(Detalle_Codigos_ReferidosData.Fecha_de_autorizacion).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_autorizacion = Detalle_Codigos_ReferidosData.Hora_de_autorizacion
                    ,Estatus = Detalle_Codigos_ReferidosData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Codigos_ReferidosData.Estatus), "Estatus") ??  (string)Detalle_Codigos_ReferidosData.Estatus_Estatus.Descripcion

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
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_autoriza = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_autoriza != null && Spartan_Users_Usuario_que_autoriza.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_autoriza = Spartan_Users_Usuario_que_autoriza.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
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
            return View(varDetalle_Codigos_Referidos);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Codigos_Referidos(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44420);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Codigos_ReferidosApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Codigos_ReferidosModel varDetalle_Codigos_Referidos= new Detalle_Codigos_ReferidosModel();


            if (id.ToString() != "0")
            {
                var Detalle_Codigos_ReferidossData = _IDetalle_Codigos_ReferidosApiConsumer.ListaSelAll(0, 1000, "Detalle_Codigos_Referidos.Folio=" + id, "").Resource.Detalle_Codigos_Referidoss;
				
				if (Detalle_Codigos_ReferidossData != null && Detalle_Codigos_ReferidossData.Count > 0)
                {
					var Detalle_Codigos_ReferidosData = Detalle_Codigos_ReferidossData.First();
					varDetalle_Codigos_Referidos= new Detalle_Codigos_ReferidosModel
					{
						Folio  = Detalle_Codigos_ReferidosData.Folio 
	                    ,Suscripcion = Detalle_Codigos_ReferidosData.Suscripcion
                    ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(Convert.ToString(Detalle_Codigos_ReferidosData.Suscripcion), "Planes_de_Suscripcion") ??  (string)Detalle_Codigos_ReferidosData.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                    ,Porcentaje_de_descuento = Detalle_Codigos_ReferidosData.Porcentaje_de_descuento
                    ,Fecha_inicio_vigencia = (Detalle_Codigos_ReferidosData.Fecha_inicio_vigencia == null ? string.Empty : Convert.ToDateTime(Detalle_Codigos_ReferidosData.Fecha_inicio_vigencia).ToString(ConfigurationProperty.DateFormat))
                    ,Fecha_fin_vigencia = (Detalle_Codigos_ReferidosData.Fecha_fin_vigencia == null ? string.Empty : Convert.ToDateTime(Detalle_Codigos_ReferidosData.Fecha_fin_vigencia).ToString(ConfigurationProperty.DateFormat))
                    ,Cantidad_maxima_de_referenciados = Detalle_Codigos_ReferidosData.Cantidad_maxima_de_referenciados
                    ,Codigo_para_Referenciados = Detalle_Codigos_ReferidosData.Codigo_para_Referenciados
                    ,Autorizado = Detalle_Codigos_ReferidosData.Autorizado.GetValueOrDefault()
                    ,Usuario_que_autoriza = Detalle_Codigos_ReferidosData.Usuario_que_autoriza
                    ,Usuario_que_autorizaName = CultureHelper.GetTraduction(Convert.ToString(Detalle_Codigos_ReferidosData.Usuario_que_autoriza), "Spartan_User") ??  (string)Detalle_Codigos_ReferidosData.Usuario_que_autoriza_Spartan_User.Name
                    ,Fecha_de_autorizacion = (Detalle_Codigos_ReferidosData.Fecha_de_autorizacion == null ? string.Empty : Convert.ToDateTime(Detalle_Codigos_ReferidosData.Fecha_de_autorizacion).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_autorizacion = Detalle_Codigos_ReferidosData.Hora_de_autorizacion
                    ,Estatus = Detalle_Codigos_ReferidosData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Codigos_ReferidosData.Estatus), "Estatus") ??  (string)Detalle_Codigos_ReferidosData.Estatus_Estatus.Descripcion

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
            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario_que_autoriza = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario_que_autoriza != null && Spartan_Users_Usuario_que_autoriza.Resource != null)
                ViewBag.Spartan_Users_Usuario_que_autoriza = Spartan_Users_Usuario_que_autoriza.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
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


            return PartialView("AddDetalle_Codigos_Referidos", varDetalle_Codigos_Referidos);
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



        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Codigos_ReferidosPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Codigos_ReferidosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Codigos_Referidoss == null)
                result.Detalle_Codigos_Referidoss = new List<Detalle_Codigos_Referidos>();

            return Json(new
            {
                data = result.Detalle_Codigos_Referidoss.Select(m => new Detalle_Codigos_ReferidosGridModel
                    {
                    Folio = m.Folio
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Nombre_del_Plan") ?? (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
			,Porcentaje_de_descuento = m.Porcentaje_de_descuento
                        ,Fecha_inicio_vigencia = (m.Fecha_inicio_vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_vigencia).ToString(ConfigurationProperty.DateFormat))
                        ,Fecha_fin_vigencia = (m.Fecha_fin_vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_vigencia).ToString(ConfigurationProperty.DateFormat))
			,Cantidad_maxima_de_referenciados = m.Cantidad_maxima_de_referenciados
			,Codigo_para_Referenciados = m.Codigo_para_Referenciados
			,Autorizado = m.Autorizado
                        ,Usuario_que_autorizaName = CultureHelper.GetTraduction(m.Usuario_que_autoriza_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_que_autoriza_Spartan_User.Name
                        ,Fecha_de_autorizacion = (m.Fecha_de_autorizacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_autorizacion).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_autorizacion = m.Hora_de_autorizacion
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion

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
                _IDetalle_Codigos_ReferidosApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Codigos_Referidos varDetalle_Codigos_Referidos = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Codigos_ReferidosApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Codigos_ReferidosModel varDetalle_Codigos_Referidos)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Codigos_ReferidosApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Codigos_ReferidosInfo = new Detalle_Codigos_Referidos
                    {
                        Folio = varDetalle_Codigos_Referidos.Folio
                        ,Suscripcion = varDetalle_Codigos_Referidos.Suscripcion
                        ,Porcentaje_de_descuento = varDetalle_Codigos_Referidos.Porcentaje_de_descuento
                        ,Fecha_inicio_vigencia = (!String.IsNullOrEmpty(varDetalle_Codigos_Referidos.Fecha_inicio_vigencia)) ? DateTime.ParseExact(varDetalle_Codigos_Referidos.Fecha_inicio_vigencia, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Fecha_fin_vigencia = (!String.IsNullOrEmpty(varDetalle_Codigos_Referidos.Fecha_fin_vigencia)) ? DateTime.ParseExact(varDetalle_Codigos_Referidos.Fecha_fin_vigencia, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Cantidad_maxima_de_referenciados = varDetalle_Codigos_Referidos.Cantidad_maxima_de_referenciados
                        ,Codigo_para_Referenciados = varDetalle_Codigos_Referidos.Codigo_para_Referenciados
                        ,Autorizado = varDetalle_Codigos_Referidos.Autorizado
                        ,Usuario_que_autoriza = varDetalle_Codigos_Referidos.Usuario_que_autoriza
                        ,Fecha_de_autorizacion = (!String.IsNullOrEmpty(varDetalle_Codigos_Referidos.Fecha_de_autorizacion)) ? DateTime.ParseExact(varDetalle_Codigos_Referidos.Fecha_de_autorizacion, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_autorizacion = varDetalle_Codigos_Referidos.Hora_de_autorizacion
                        ,Estatus = varDetalle_Codigos_Referidos.Estatus

                    };

                    result = !IsNew ?
                        _IDetalle_Codigos_ReferidosApiConsumer.Update(Detalle_Codigos_ReferidosInfo, null, null).Resource.ToString() :
                         _IDetalle_Codigos_ReferidosApiConsumer.Insert(Detalle_Codigos_ReferidosInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Codigos_Referidos script
        /// </summary>
        /// <param name="oDetalle_Codigos_ReferidosElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Codigos_ReferidosModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Codigos_ReferidosModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Codigos_ReferidosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Codigos_ReferidosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Codigos_ReferidosModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Codigos_ReferidosModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Codigos_ReferidosModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Codigos_ReferidosModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Codigos_ReferidosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Codigos_ReferidosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Codigos_ReferidosModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Codigos_ReferidosModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Codigos_ReferidosScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Codigos_Referidos.js")))
            {
                strDetalle_Codigos_ReferidosScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Codigos_Referidos element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Codigos_ReferidosModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Codigos_ReferidosScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Codigos_ReferidosScript.Substring(indexOfArray, strDetalle_Codigos_ReferidosScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Codigos_ReferidosModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Codigos_ReferidosModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Codigos_ReferidosScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Codigos_ReferidosScript.Substring(indexOfArrayHistory, strDetalle_Codigos_ReferidosScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Codigos_ReferidosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Codigos_ReferidosScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Codigos_ReferidosScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Codigos_ReferidosModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Codigos_ReferidosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Codigos_ReferidosScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Codigos_ReferidosScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Codigos_ReferidosScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Codigos_Referidos.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Codigos_Referidos.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Codigos_Referidos.js")))
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
        public ActionResult Detalle_Codigos_ReferidosPropertyBag()
        {
            return PartialView("Detalle_Codigos_ReferidosPropertyBag", "Detalle_Codigos_Referidos");
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

            _IDetalle_Codigos_ReferidosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Codigos_ReferidosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Codigos_ReferidosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Codigos_Referidoss == null)
                result.Detalle_Codigos_Referidoss = new List<Detalle_Codigos_Referidos>();

            var data = result.Detalle_Codigos_Referidoss.Select(m => new Detalle_Codigos_ReferidosGridModel
            {
                Folio = m.Folio
                ,SuscripcionNombre_del_Plan = (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                ,Porcentaje_de_descuento = m.Porcentaje_de_descuento
                ,Fecha_inicio_vigencia = (m.Fecha_inicio_vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_vigencia).ToString(ConfigurationProperty.DateFormat))
                ,Fecha_fin_vigencia = (m.Fecha_fin_vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_vigencia).ToString(ConfigurationProperty.DateFormat))
                ,Cantidad_maxima_de_referenciados = m.Cantidad_maxima_de_referenciados
                ,Codigo_para_Referenciados = m.Codigo_para_Referenciados
                ,Autorizado = m.Autorizado
                ,Usuario_que_autorizaName = (string)m.Usuario_que_autoriza_Spartan_User.Name
                ,Fecha_de_autorizacion = (m.Fecha_de_autorizacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_autorizacion).ToString(ConfigurationProperty.DateFormat))
                ,Hora_de_autorizacion = m.Hora_de_autorizacion
                ,EstatusDescripcion = (string)m.Estatus_Estatus.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Codigos_ReferidosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Codigos_ReferidosList_" + DateTime.Now.ToString());
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

            _IDetalle_Codigos_ReferidosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Codigos_ReferidosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Codigos_ReferidosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Codigos_Referidoss == null)
                result.Detalle_Codigos_Referidoss = new List<Detalle_Codigos_Referidos>();

            var data = result.Detalle_Codigos_Referidoss.Select(m => new Detalle_Codigos_ReferidosGridModel
            {
                Folio = m.Folio
                ,SuscripcionNombre_del_Plan = (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                ,Porcentaje_de_descuento = m.Porcentaje_de_descuento
                ,Fecha_inicio_vigencia = (m.Fecha_inicio_vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_inicio_vigencia).ToString(ConfigurationProperty.DateFormat))
                ,Fecha_fin_vigencia = (m.Fecha_fin_vigencia == null ? string.Empty : Convert.ToDateTime(m.Fecha_fin_vigencia).ToString(ConfigurationProperty.DateFormat))
                ,Cantidad_maxima_de_referenciados = m.Cantidad_maxima_de_referenciados
                ,Codigo_para_Referenciados = m.Codigo_para_Referenciados
                ,Autorizado = m.Autorizado
                ,Usuario_que_autorizaName = (string)m.Usuario_que_autoriza_Spartan_User.Name
                ,Fecha_de_autorizacion = (m.Fecha_de_autorizacion == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_autorizacion).ToString(ConfigurationProperty.DateFormat))
                ,Hora_de_autorizacion = m.Hora_de_autorizacion
                ,EstatusDescripcion = (string)m.Estatus_Estatus.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
