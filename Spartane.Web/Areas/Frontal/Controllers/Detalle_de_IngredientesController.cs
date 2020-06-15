using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_de_Ingredientes;
using Spartane.Core.Domain.Unidades_de_Medida;
using Spartane.Core.Domain.Ingredientes;
using Spartane.Core.Domain.Presentacion;
using Spartane.Core.Domain.Marca;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_de_Ingredientes;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_de_Ingredientes;
using Spartane.Web.Areas.WebApiConsumer.Unidades_de_Medida;
using Spartane.Web.Areas.WebApiConsumer.Ingredientes;
using Spartane.Web.Areas.WebApiConsumer.Presentacion;
using Spartane.Web.Areas.WebApiConsumer.Marca;

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
    public class Detalle_de_IngredientesController : Controller
    {
        #region "variable declaration"

        private IDetalle_de_IngredientesService service = null;
        private IDetalle_de_IngredientesApiConsumer _IDetalle_de_IngredientesApiConsumer;
        private IUnidades_de_MedidaApiConsumer _IUnidades_de_MedidaApiConsumer;
        private IIngredientesApiConsumer _IIngredientesApiConsumer;
        private IPresentacionApiConsumer _IPresentacionApiConsumer;
        private IMarcaApiConsumer _IMarcaApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_de_IngredientesController(IDetalle_de_IngredientesService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_de_IngredientesApiConsumer Detalle_de_IngredientesApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IUnidades_de_MedidaApiConsumer Unidades_de_MedidaApiConsumer , IIngredientesApiConsumer IngredientesApiConsumer , IPresentacionApiConsumer PresentacionApiConsumer , IMarcaApiConsumer MarcaApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_de_IngredientesApiConsumer = Detalle_de_IngredientesApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IUnidades_de_MedidaApiConsumer = Unidades_de_MedidaApiConsumer;
            this._IIngredientesApiConsumer = IngredientesApiConsumer;
            this._IPresentacionApiConsumer = PresentacionApiConsumer;
            this._IMarcaApiConsumer = MarcaApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_de_Ingredientes
        [ObjectAuth(ObjectId = (ModuleObjectId)43968, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 43968);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_de_Ingredientes/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)43968, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 43968);
            ViewBag.Permission = permission;
            var varDetalle_de_Ingredientes = new Detalle_de_IngredientesModel();
			
            ViewBag.ObjectId = "43968";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_de_IngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_de_IngredientesData = _IDetalle_de_IngredientesApiConsumer.GetByKeyComplete(Id).Resource.Detalle_de_Ingredientess[0];
                if (Detalle_de_IngredientesData == null)
                    return HttpNotFound();

                varDetalle_de_Ingredientes = new Detalle_de_IngredientesModel
                {
                    Clave = (int)Detalle_de_IngredientesData.Clave
                    ,Cantidad = Detalle_de_IngredientesData.Cantidad
                    ,Unidad = Detalle_de_IngredientesData.Unidad
                    ,UnidadUnidad = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_IngredientesData.Unidad), "Unidades_de_Medida") ??  (string)Detalle_de_IngredientesData.Unidad_Unidades_de_Medida.Unidad
                    ,Nombre_del_Ingrediente = Detalle_de_IngredientesData.Nombre_del_Ingrediente
                    ,Nombre_del_IngredienteNombre_Ingrediente = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_IngredientesData.Nombre_del_Ingrediente), "Ingredientes") ??  (string)Detalle_de_IngredientesData.Nombre_del_Ingrediente_Ingredientes.Nombre_Ingrediente
                    ,Nombre_de_presentacion = Detalle_de_IngredientesData.Nombre_de_presentacion
                    ,Nombre_de_presentacionDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_IngredientesData.Nombre_de_presentacion), "Presentacion") ??  (string)Detalle_de_IngredientesData.Nombre_de_presentacion_Presentacion.Descripcion
                    ,Nombre_de_Marca = Detalle_de_IngredientesData.Nombre_de_Marca
                    ,Nombre_de_MarcaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_IngredientesData.Nombre_de_Marca), "Marca") ??  (string)Detalle_de_IngredientesData.Nombre_de_Marca_Marca.Descripcion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IUnidades_de_MedidaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Unidades_de_Medidas_Unidad = _IUnidades_de_MedidaApiConsumer.SelAll(true);
            if (Unidades_de_Medidas_Unidad != null && Unidades_de_Medidas_Unidad.Resource != null)
                ViewBag.Unidades_de_Medidas_Unidad = Unidades_de_Medidas_Unidad.Resource.Where(m => m.Unidad != null).OrderBy(m => m.Unidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Unidades_de_Medida", "Unidad") ?? m.Unidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Ingredientess_Nombre_del_Ingrediente = _IIngredientesApiConsumer.SelAll(true);
            if (Ingredientess_Nombre_del_Ingrediente != null && Ingredientess_Nombre_del_Ingrediente.Resource != null)
                ViewBag.Ingredientess_Nombre_del_Ingrediente = Ingredientess_Nombre_del_Ingrediente.Resource.Where(m => m.Nombre_Ingrediente != null).OrderBy(m => m.Nombre_Ingrediente).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Ingredientes", "Nombre_Ingrediente") ?? m.Nombre_Ingrediente.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPresentacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Presentacions_Nombre_de_presentacion = _IPresentacionApiConsumer.SelAll(true);
            if (Presentacions_Nombre_de_presentacion != null && Presentacions_Nombre_de_presentacion.Resource != null)
                ViewBag.Presentacions_Nombre_de_presentacion = Presentacions_Nombre_de_presentacion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Presentacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IMarcaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Marcas_Nombre_de_Marca = _IMarcaApiConsumer.SelAll(true);
            if (Marcas_Nombre_de_Marca != null && Marcas_Nombre_de_Marca.Resource != null)
                ViewBag.Marcas_Nombre_de_Marca = Marcas_Nombre_de_Marca.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Marca", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_de_Ingredientes);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_de_Ingredientes(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 43968);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_de_IngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_de_IngredientesModel varDetalle_de_Ingredientes= new Detalle_de_IngredientesModel();


            if (id.ToString() != "0")
            {
                var Detalle_de_IngredientessData = _IDetalle_de_IngredientesApiConsumer.ListaSelAll(0, 1000, "Detalle_de_Ingredientes.Clave=" + id, "").Resource.Detalle_de_Ingredientess;
				
				if (Detalle_de_IngredientessData != null && Detalle_de_IngredientessData.Count > 0)
                {
					var Detalle_de_IngredientesData = Detalle_de_IngredientessData.First();
					varDetalle_de_Ingredientes= new Detalle_de_IngredientesModel
					{
						Clave  = Detalle_de_IngredientesData.Clave 
	                    ,Cantidad = Detalle_de_IngredientesData.Cantidad
                    ,Unidad = Detalle_de_IngredientesData.Unidad
                    ,UnidadUnidad = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_IngredientesData.Unidad), "Unidades_de_Medida") ??  (string)Detalle_de_IngredientesData.Unidad_Unidades_de_Medida.Unidad
                    ,Nombre_del_Ingrediente = Detalle_de_IngredientesData.Nombre_del_Ingrediente
                    ,Nombre_del_IngredienteNombre_Ingrediente = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_IngredientesData.Nombre_del_Ingrediente), "Ingredientes") ??  (string)Detalle_de_IngredientesData.Nombre_del_Ingrediente_Ingredientes.Nombre_Ingrediente
                    ,Nombre_de_presentacion = Detalle_de_IngredientesData.Nombre_de_presentacion
                    ,Nombre_de_presentacionDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_IngredientesData.Nombre_de_presentacion), "Presentacion") ??  (string)Detalle_de_IngredientesData.Nombre_de_presentacion_Presentacion.Descripcion
                    ,Nombre_de_Marca = Detalle_de_IngredientesData.Nombre_de_Marca
                    ,Nombre_de_MarcaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_de_IngredientesData.Nombre_de_Marca), "Marca") ??  (string)Detalle_de_IngredientesData.Nombre_de_Marca_Marca.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IUnidades_de_MedidaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Unidades_de_Medidas_Unidad = _IUnidades_de_MedidaApiConsumer.SelAll(true);
            if (Unidades_de_Medidas_Unidad != null && Unidades_de_Medidas_Unidad.Resource != null)
                ViewBag.Unidades_de_Medidas_Unidad = Unidades_de_Medidas_Unidad.Resource.Where(m => m.Unidad != null).OrderBy(m => m.Unidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Unidades_de_Medida", "Unidad") ?? m.Unidad.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Ingredientess_Nombre_del_Ingrediente = _IIngredientesApiConsumer.SelAll(true);
            if (Ingredientess_Nombre_del_Ingrediente != null && Ingredientess_Nombre_del_Ingrediente.Resource != null)
                ViewBag.Ingredientess_Nombre_del_Ingrediente = Ingredientess_Nombre_del_Ingrediente.Resource.Where(m => m.Nombre_Ingrediente != null).OrderBy(m => m.Nombre_Ingrediente).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Ingredientes", "Nombre_Ingrediente") ?? m.Nombre_Ingrediente.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IPresentacionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Presentacions_Nombre_de_presentacion = _IPresentacionApiConsumer.SelAll(true);
            if (Presentacions_Nombre_de_presentacion != null && Presentacions_Nombre_de_presentacion.Resource != null)
                ViewBag.Presentacions_Nombre_de_presentacion = Presentacions_Nombre_de_presentacion.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Presentacion", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IMarcaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Marcas_Nombre_de_Marca = _IMarcaApiConsumer.SelAll(true);
            if (Marcas_Nombre_de_Marca != null && Marcas_Nombre_de_Marca.Resource != null)
                ViewBag.Marcas_Nombre_de_Marca = Marcas_Nombre_de_Marca.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Marca", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_de_Ingredientes", varDetalle_de_Ingredientes);
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
        public ActionResult GetUnidades_de_MedidaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IUnidades_de_MedidaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IUnidades_de_MedidaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Unidad).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Unidades_de_Medida", "Unidad")?? m.Unidad,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetIngredientesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IIngredientesApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_Ingrediente).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Ingredientes", "Nombre_Ingrediente")?? m.Nombre_Ingrediente,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetPresentacionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IPresentacionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IPresentacionApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Presentacion", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetMarcaAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMarcaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IMarcaApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Marca", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_de_IngredientesPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_de_IngredientesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_de_Ingredientess == null)
                result.Detalle_de_Ingredientess = new List<Detalle_de_Ingredientes>();

            return Json(new
            {
                data = result.Detalle_de_Ingredientess.Select(m => new Detalle_de_IngredientesGridModel
                    {
                    Clave = m.Clave
			,Cantidad = m.Cantidad
                        ,UnidadUnidad = CultureHelper.GetTraduction(m.Unidad_Unidades_de_Medida.Clave.ToString(), "Unidad") ?? (string)m.Unidad_Unidades_de_Medida.Unidad
                        ,Nombre_del_IngredienteNombre_Ingrediente = CultureHelper.GetTraduction(m.Nombre_del_Ingrediente_Ingredientes.Clave.ToString(), "Nombre_Ingrediente") ?? (string)m.Nombre_del_Ingrediente_Ingredientes.Nombre_Ingrediente
                        ,Nombre_de_presentacionDescripcion = CultureHelper.GetTraduction(m.Nombre_de_presentacion_Presentacion.Clave.ToString(), "Descripcion") ?? (string)m.Nombre_de_presentacion_Presentacion.Descripcion
                        ,Nombre_de_MarcaDescripcion = CultureHelper.GetTraduction(m.Nombre_de_Marca_Marca.Clave.ToString(), "Descripcion") ?? (string)m.Nombre_de_Marca_Marca.Descripcion

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
                _IDetalle_de_IngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_de_Ingredientes varDetalle_de_Ingredientes = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_de_IngredientesApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_de_IngredientesModel varDetalle_de_Ingredientes)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_de_IngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_de_IngredientesInfo = new Detalle_de_Ingredientes
                    {
                        Clave = varDetalle_de_Ingredientes.Clave
                        ,Cantidad = varDetalle_de_Ingredientes.Cantidad
                        ,Unidad = varDetalle_de_Ingredientes.Unidad
                        ,Nombre_del_Ingrediente = varDetalle_de_Ingredientes.Nombre_del_Ingrediente
                        ,Nombre_de_presentacion = varDetalle_de_Ingredientes.Nombre_de_presentacion
                        ,Nombre_de_Marca = varDetalle_de_Ingredientes.Nombre_de_Marca

                    };

                    result = !IsNew ?
                        _IDetalle_de_IngredientesApiConsumer.Update(Detalle_de_IngredientesInfo, null, null).Resource.ToString() :
                         _IDetalle_de_IngredientesApiConsumer.Insert(Detalle_de_IngredientesInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_de_Ingredientes script
        /// </summary>
        /// <param name="oDetalle_de_IngredientesElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_de_IngredientesModuleAttributeList)
        {
            for (int i = 0; i < Detalle_de_IngredientesModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_de_IngredientesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_de_IngredientesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_de_IngredientesModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_de_IngredientesModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_de_IngredientesModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_de_IngredientesModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_de_IngredientesModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_de_IngredientesModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_de_IngredientesModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_de_IngredientesModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_de_IngredientesScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_de_Ingredientes.js")))
            {
                strDetalle_de_IngredientesScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_de_Ingredientes element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_de_IngredientesModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_de_IngredientesScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_de_IngredientesScript.Substring(indexOfArray, strDetalle_de_IngredientesScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_de_IngredientesModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_de_IngredientesModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_de_IngredientesScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_de_IngredientesScript.Substring(indexOfArrayHistory, strDetalle_de_IngredientesScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_de_IngredientesScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_de_IngredientesScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_de_IngredientesScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_de_IngredientesModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_de_IngredientesScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_de_IngredientesScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_de_IngredientesScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_de_IngredientesScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_de_Ingredientes.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_de_Ingredientes.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_de_Ingredientes.js")))
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
        public ActionResult Detalle_de_IngredientesPropertyBag()
        {
            return PartialView("Detalle_de_IngredientesPropertyBag", "Detalle_de_Ingredientes");
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

            _IDetalle_de_IngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_de_IngredientesPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_de_IngredientesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_de_Ingredientess == null)
                result.Detalle_de_Ingredientess = new List<Detalle_de_Ingredientes>();

            var data = result.Detalle_de_Ingredientess.Select(m => new Detalle_de_IngredientesGridModel
            {
                Clave = m.Clave
                ,Cantidad = m.Cantidad
                ,UnidadUnidad = (string)m.Unidad_Unidades_de_Medida.Unidad
                ,Nombre_del_IngredienteNombre_Ingrediente = (string)m.Nombre_del_Ingrediente_Ingredientes.Nombre_Ingrediente
                ,Nombre_de_presentacionDescripcion = (string)m.Nombre_de_presentacion_Presentacion.Descripcion
                ,Nombre_de_MarcaDescripcion = (string)m.Nombre_de_Marca_Marca.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_de_IngredientesList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_de_IngredientesList_" + DateTime.Now.ToString());
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

            _IDetalle_de_IngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_de_IngredientesPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_de_IngredientesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_de_Ingredientess == null)
                result.Detalle_de_Ingredientess = new List<Detalle_de_Ingredientes>();

            var data = result.Detalle_de_Ingredientess.Select(m => new Detalle_de_IngredientesGridModel
            {
                Clave = m.Clave
                ,Cantidad = m.Cantidad
                ,UnidadUnidad = (string)m.Unidad_Unidades_de_Medida.Unidad
                ,Nombre_del_IngredienteNombre_Ingrediente = (string)m.Nombre_del_Ingrediente_Ingredientes.Nombre_Ingrediente
                ,Nombre_de_presentacionDescripcion = (string)m.Nombre_de_presentacion_Presentacion.Descripcion
                ,Nombre_de_MarcaDescripcion = (string)m.Nombre_de_Marca_Marca.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
