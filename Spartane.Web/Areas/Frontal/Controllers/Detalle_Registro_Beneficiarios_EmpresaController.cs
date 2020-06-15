using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Registro_Beneficiarios_Empresa;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Planes_de_Suscripcion;
using Spartane.Core.Domain.Estatus;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Registro_Beneficiarios_Empresa;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Registro_Beneficiarios_Empresa;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion;
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
    public class Detalle_Registro_Beneficiarios_EmpresaController : Controller
    {
        #region "variable declaration"

        private IDetalle_Registro_Beneficiarios_EmpresaService service = null;
        private IDetalle_Registro_Beneficiarios_EmpresaApiConsumer _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private IPlanes_de_SuscripcionApiConsumer _IPlanes_de_SuscripcionApiConsumer;
        private IEstatusApiConsumer _IEstatusApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Registro_Beneficiarios_EmpresaController(IDetalle_Registro_Beneficiarios_EmpresaService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Registro_Beneficiarios_EmpresaApiConsumer Detalle_Registro_Beneficiarios_EmpresaApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ISpartan_UserApiConsumer Spartan_UserApiConsumer , IPlanes_de_SuscripcionApiConsumer Planes_de_SuscripcionApiConsumer , IEstatusApiConsumer EstatusApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Registro_Beneficiarios_EmpresaApiConsumer = Detalle_Registro_Beneficiarios_EmpresaApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._IPlanes_de_SuscripcionApiConsumer = Planes_de_SuscripcionApiConsumer;
            this._IEstatusApiConsumer = EstatusApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Registro_Beneficiarios_Empresa
        [ObjectAuth(ObjectId = (ModuleObjectId)44459, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44459);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Registro_Beneficiarios_Empresa/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44459, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44459);
            ViewBag.Permission = permission;
            var varDetalle_Registro_Beneficiarios_Empresa = new Detalle_Registro_Beneficiarios_EmpresaModel();
			
            ViewBag.ObjectId = "44459";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Registro_Beneficiarios_EmpresaData = _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Registro_Beneficiarios_Empresas[0];
                if (Detalle_Registro_Beneficiarios_EmpresaData == null)
                    return HttpNotFound();

                varDetalle_Registro_Beneficiarios_Empresa = new Detalle_Registro_Beneficiarios_EmpresaModel
                {
                    Folio = (int)Detalle_Registro_Beneficiarios_EmpresaData.Folio
                    ,Numero_de_Empleado = Detalle_Registro_Beneficiarios_EmpresaData.Numero_de_Empleado
                    ,Usuario = Detalle_Registro_Beneficiarios_EmpresaData.Usuario
                    ,UsuarioName = CultureHelper.GetTraduction(Convert.ToString(Detalle_Registro_Beneficiarios_EmpresaData.Usuario), "Spartan_User") ??  (string)Detalle_Registro_Beneficiarios_EmpresaData.Usuario_Spartan_User.Name
                    ,Nombres = Detalle_Registro_Beneficiarios_EmpresaData.Nombres
                    ,Apellido_Paterno = Detalle_Registro_Beneficiarios_EmpresaData.Apellido_Paterno
                    ,Apellido_Materno = Detalle_Registro_Beneficiarios_EmpresaData.Apellido_Materno
                    ,Nombre_Completo = Detalle_Registro_Beneficiarios_EmpresaData.Nombre_Completo
                    ,Email = Detalle_Registro_Beneficiarios_EmpresaData.Email
                    ,Activo = Detalle_Registro_Beneficiarios_EmpresaData.Activo.GetValueOrDefault()
                    ,Suscripcion = Detalle_Registro_Beneficiarios_EmpresaData.Suscripcion
                    ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(Convert.ToString(Detalle_Registro_Beneficiarios_EmpresaData.Suscripcion), "Planes_de_Suscripcion") ??  (string)Detalle_Registro_Beneficiarios_EmpresaData.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                    ,Codigo_de_Referencia = Detalle_Registro_Beneficiarios_EmpresaData.Codigo_de_Referencia
                    ,Estatus = Detalle_Registro_Beneficiarios_EmpresaData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Registro_Beneficiarios_EmpresaData.Estatus), "Estatus") ??  (string)Detalle_Registro_Beneficiarios_EmpresaData.Estatus_Estatus.Descripcion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario != null && Spartan_Users_Usuario.Resource != null)
                ViewBag.Spartan_Users_Usuario = Spartan_Users_Usuario.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Planes_de_Suscripcions_Suscripcion = _IPlanes_de_SuscripcionApiConsumer.SelAll(true);
            if (Planes_de_Suscripcions_Suscripcion != null && Planes_de_Suscripcions_Suscripcion.Resource != null)
                ViewBag.Planes_de_Suscripcions_Suscripcion = Planes_de_Suscripcions_Suscripcion.Resource.Where(m => m.Nombre_del_Plan != null).OrderBy(m => m.Nombre_del_Plan).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan") ?? m.Nombre_del_Plan.ToString(), Value = Convert.ToString(m.Folio)
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
            return View(varDetalle_Registro_Beneficiarios_Empresa);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Registro_Beneficiarios_Empresa(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44459);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Registro_Beneficiarios_EmpresaModel varDetalle_Registro_Beneficiarios_Empresa= new Detalle_Registro_Beneficiarios_EmpresaModel();


            if (id.ToString() != "0")
            {
                var Detalle_Registro_Beneficiarios_EmpresasData = _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.ListaSelAll(0, 1000, "Detalle_Registro_Beneficiarios_Empresa.Folio=" + id, "").Resource.Detalle_Registro_Beneficiarios_Empresas;
				
				if (Detalle_Registro_Beneficiarios_EmpresasData != null && Detalle_Registro_Beneficiarios_EmpresasData.Count > 0)
                {
					var Detalle_Registro_Beneficiarios_EmpresaData = Detalle_Registro_Beneficiarios_EmpresasData.First();
					varDetalle_Registro_Beneficiarios_Empresa= new Detalle_Registro_Beneficiarios_EmpresaModel
					{
						Folio  = Detalle_Registro_Beneficiarios_EmpresaData.Folio 
	                    ,Numero_de_Empleado = Detalle_Registro_Beneficiarios_EmpresaData.Numero_de_Empleado
                    ,Usuario = Detalle_Registro_Beneficiarios_EmpresaData.Usuario
                    ,UsuarioName = CultureHelper.GetTraduction(Convert.ToString(Detalle_Registro_Beneficiarios_EmpresaData.Usuario), "Spartan_User") ??  (string)Detalle_Registro_Beneficiarios_EmpresaData.Usuario_Spartan_User.Name
                    ,Nombres = Detalle_Registro_Beneficiarios_EmpresaData.Nombres
                    ,Apellido_Paterno = Detalle_Registro_Beneficiarios_EmpresaData.Apellido_Paterno
                    ,Apellido_Materno = Detalle_Registro_Beneficiarios_EmpresaData.Apellido_Materno
                    ,Nombre_Completo = Detalle_Registro_Beneficiarios_EmpresaData.Nombre_Completo
                    ,Email = Detalle_Registro_Beneficiarios_EmpresaData.Email
                    ,Activo = Detalle_Registro_Beneficiarios_EmpresaData.Activo.GetValueOrDefault()
                    ,Suscripcion = Detalle_Registro_Beneficiarios_EmpresaData.Suscripcion
                    ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(Convert.ToString(Detalle_Registro_Beneficiarios_EmpresaData.Suscripcion), "Planes_de_Suscripcion") ??  (string)Detalle_Registro_Beneficiarios_EmpresaData.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                    ,Codigo_de_Referencia = Detalle_Registro_Beneficiarios_EmpresaData.Codigo_de_Referencia
                    ,Estatus = Detalle_Registro_Beneficiarios_EmpresaData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Registro_Beneficiarios_EmpresaData.Estatus), "Estatus") ??  (string)Detalle_Registro_Beneficiarios_EmpresaData.Estatus_Estatus.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_Usuario = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_Usuario != null && Spartan_Users_Usuario.Resource != null)
                ViewBag.Spartan_Users_Usuario = Spartan_Users_Usuario.Resource.Where(m => m.Name != null).OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Id_User), "Spartan_User", "Name") ?? m.Name.ToString(), Value = Convert.ToString(m.Id_User)
                }).ToList();
            _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Planes_de_Suscripcions_Suscripcion = _IPlanes_de_SuscripcionApiConsumer.SelAll(true);
            if (Planes_de_Suscripcions_Suscripcion != null && Planes_de_Suscripcions_Suscripcion.Resource != null)
                ViewBag.Planes_de_Suscripcions_Suscripcion = Planes_de_Suscripcions_Suscripcion.Resource.Where(m => m.Nombre_del_Plan != null).OrderBy(m => m.Nombre_del_Plan).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan") ?? m.Nombre_del_Plan.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_Registro_Beneficiarios_Empresa", varDetalle_Registro_Beneficiarios_Empresa);
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Registro_Beneficiarios_EmpresaPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Registro_Beneficiarios_Empresas == null)
                result.Detalle_Registro_Beneficiarios_Empresas = new List<Detalle_Registro_Beneficiarios_Empresa>();

            return Json(new
            {
                data = result.Detalle_Registro_Beneficiarios_Empresas.Select(m => new Detalle_Registro_Beneficiarios_EmpresaGridModel
                    {
                    Folio = m.Folio
			,Numero_de_Empleado = m.Numero_de_Empleado
                        ,UsuarioName = CultureHelper.GetTraduction(m.Usuario_Spartan_User.Id_User.ToString(), "Name") ?? (string)m.Usuario_Spartan_User.Name
			,Nombres = m.Nombres
			,Apellido_Paterno = m.Apellido_Paterno
			,Apellido_Materno = m.Apellido_Materno
			,Nombre_Completo = m.Nombre_Completo
			,Email = m.Email
			,Activo = m.Activo
                        ,SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Nombre_del_Plan") ?? (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
			,Codigo_de_Referencia = m.Codigo_de_Referencia
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
                _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Registro_Beneficiarios_Empresa varDetalle_Registro_Beneficiarios_Empresa = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Registro_Beneficiarios_EmpresaModel varDetalle_Registro_Beneficiarios_Empresa)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Registro_Beneficiarios_EmpresaInfo = new Detalle_Registro_Beneficiarios_Empresa
                    {
                        Folio = varDetalle_Registro_Beneficiarios_Empresa.Folio
                        ,Numero_de_Empleado = varDetalle_Registro_Beneficiarios_Empresa.Numero_de_Empleado
                        ,Usuario = varDetalle_Registro_Beneficiarios_Empresa.Usuario
                        ,Nombres = varDetalle_Registro_Beneficiarios_Empresa.Nombres
                        ,Apellido_Paterno = varDetalle_Registro_Beneficiarios_Empresa.Apellido_Paterno
                        ,Apellido_Materno = varDetalle_Registro_Beneficiarios_Empresa.Apellido_Materno
                        ,Nombre_Completo = varDetalle_Registro_Beneficiarios_Empresa.Nombre_Completo
                        ,Email = varDetalle_Registro_Beneficiarios_Empresa.Email
                        ,Activo = varDetalle_Registro_Beneficiarios_Empresa.Activo
                        ,Suscripcion = varDetalle_Registro_Beneficiarios_Empresa.Suscripcion
                        ,Codigo_de_Referencia = varDetalle_Registro_Beneficiarios_Empresa.Codigo_de_Referencia
                        ,Estatus = varDetalle_Registro_Beneficiarios_Empresa.Estatus

                    };

                    result = !IsNew ?
                        _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.Update(Detalle_Registro_Beneficiarios_EmpresaInfo, null, null).Resource.ToString() :
                         _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.Insert(Detalle_Registro_Beneficiarios_EmpresaInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Registro_Beneficiarios_Empresa script
        /// </summary>
        /// <param name="oDetalle_Registro_Beneficiarios_EmpresaElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Registro_Beneficiarios_EmpresaModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Registro_Beneficiarios_EmpresaModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Registro_Beneficiarios_EmpresaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Registro_Beneficiarios_EmpresaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Registro_Beneficiarios_EmpresaModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Registro_Beneficiarios_EmpresaModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Registro_Beneficiarios_EmpresaModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Registro_Beneficiarios_EmpresaModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Registro_Beneficiarios_EmpresaModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Registro_Beneficiarios_EmpresaModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Registro_Beneficiarios_EmpresaModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Registro_Beneficiarios_EmpresaModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Registro_Beneficiarios_EmpresaScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Registro_Beneficiarios_Empresa.js")))
            {
                strDetalle_Registro_Beneficiarios_EmpresaScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Registro_Beneficiarios_Empresa element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Registro_Beneficiarios_EmpresaModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Registro_Beneficiarios_EmpresaScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Registro_Beneficiarios_EmpresaScript.Substring(indexOfArray, strDetalle_Registro_Beneficiarios_EmpresaScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Registro_Beneficiarios_EmpresaModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Registro_Beneficiarios_EmpresaModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Registro_Beneficiarios_EmpresaScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Registro_Beneficiarios_EmpresaScript.Substring(indexOfArrayHistory, strDetalle_Registro_Beneficiarios_EmpresaScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Registro_Beneficiarios_EmpresaScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Registro_Beneficiarios_EmpresaScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Registro_Beneficiarios_EmpresaScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Registro_Beneficiarios_EmpresaModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Registro_Beneficiarios_EmpresaScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Registro_Beneficiarios_EmpresaScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Registro_Beneficiarios_EmpresaScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Registro_Beneficiarios_EmpresaScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Registro_Beneficiarios_Empresa.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Registro_Beneficiarios_Empresa.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Registro_Beneficiarios_Empresa.js")))
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
        public ActionResult Detalle_Registro_Beneficiarios_EmpresaPropertyBag()
        {
            return PartialView("Detalle_Registro_Beneficiarios_EmpresaPropertyBag", "Detalle_Registro_Beneficiarios_Empresa");
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

            _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Registro_Beneficiarios_EmpresaPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Registro_Beneficiarios_Empresas == null)
                result.Detalle_Registro_Beneficiarios_Empresas = new List<Detalle_Registro_Beneficiarios_Empresa>();

            var data = result.Detalle_Registro_Beneficiarios_Empresas.Select(m => new Detalle_Registro_Beneficiarios_EmpresaGridModel
            {
                Folio = m.Folio
                ,Numero_de_Empleado = m.Numero_de_Empleado
                ,UsuarioName = (string)m.Usuario_Spartan_User.Name
                ,Nombres = m.Nombres
                ,Apellido_Paterno = m.Apellido_Paterno
                ,Apellido_Materno = m.Apellido_Materno
                ,Nombre_Completo = m.Nombre_Completo
                ,Email = m.Email
                ,Activo = m.Activo
                ,SuscripcionNombre_del_Plan = (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                ,Codigo_de_Referencia = m.Codigo_de_Referencia
                ,EstatusDescripcion = (string)m.Estatus_Estatus.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Registro_Beneficiarios_EmpresaList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Registro_Beneficiarios_EmpresaList_" + DateTime.Now.ToString());
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

            _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Registro_Beneficiarios_EmpresaPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Registro_Beneficiarios_EmpresaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Registro_Beneficiarios_Empresas == null)
                result.Detalle_Registro_Beneficiarios_Empresas = new List<Detalle_Registro_Beneficiarios_Empresa>();

            var data = result.Detalle_Registro_Beneficiarios_Empresas.Select(m => new Detalle_Registro_Beneficiarios_EmpresaGridModel
            {
                Folio = m.Folio
                ,Numero_de_Empleado = m.Numero_de_Empleado
                ,UsuarioName = (string)m.Usuario_Spartan_User.Name
                ,Nombres = m.Nombres
                ,Apellido_Paterno = m.Apellido_Paterno
                ,Apellido_Materno = m.Apellido_Materno
                ,Nombre_Completo = m.Nombre_Completo
                ,Email = m.Email
                ,Activo = m.Activo
                ,SuscripcionNombre_del_Plan = (string)m.Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan
                ,Codigo_de_Referencia = m.Codigo_de_Referencia
                ,EstatusDescripcion = (string)m.Estatus_Estatus.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
