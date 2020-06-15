using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Platillos;
using Spartane.Core.Domain.Cantidad_fraccion_platillos;
using Spartane.Core.Domain.Ingredientes;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Platillos;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Platillos;
using Spartane.Web.Areas.WebApiConsumer.Cantidad_fraccion_platillos;
using Spartane.Web.Areas.WebApiConsumer.Ingredientes;

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
    public class Detalle_PlatillosController : Controller
    {
        #region "variable declaration"

        private IDetalle_PlatillosService service = null;
        private IDetalle_PlatillosApiConsumer _IDetalle_PlatillosApiConsumer;
        private ICantidad_fraccion_platillosApiConsumer _ICantidad_fraccion_platillosApiConsumer;
        private IIngredientesApiConsumer _IIngredientesApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_PlatillosController(IDetalle_PlatillosService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_PlatillosApiConsumer Detalle_PlatillosApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ICantidad_fraccion_platillosApiConsumer Cantidad_fraccion_platillosApiConsumer , IIngredientesApiConsumer IngredientesApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_PlatillosApiConsumer = Detalle_PlatillosApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ICantidad_fraccion_platillosApiConsumer = Cantidad_fraccion_platillosApiConsumer;
            this._IIngredientesApiConsumer = IngredientesApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Platillos
        [ObjectAuth(ObjectId = (ModuleObjectId)44553, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44553);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Platillos/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44553, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44553);
            ViewBag.Permission = permission;
            var varDetalle_Platillos = new Detalle_PlatillosModel();
			
            ViewBag.ObjectId = "44553";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_PlatillosData = _IDetalle_PlatillosApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Platilloss[0];
                if (Detalle_PlatillosData == null)
                    return HttpNotFound();

                varDetalle_Platillos = new Detalle_PlatillosModel
                {
                    Folio = (int)Detalle_PlatillosData.Folio
                    ,Lleva_fracciones = Detalle_PlatillosData.Lleva_fracciones.GetValueOrDefault()
                    ,Cantidad = Detalle_PlatillosData.Cantidad
                    ,Cantidad_fraccion = Detalle_PlatillosData.Cantidad_fraccion
                    ,Cantidad_fraccionCantidad = CultureHelper.GetTraduction(Convert.ToString(Detalle_PlatillosData.Cantidad_fraccion), "Cantidad_fraccion_platillos") ??  (string)Detalle_PlatillosData.Cantidad_fraccion_Cantidad_fraccion_platillos.Cantidad
                    ,Unidad = Detalle_PlatillosData.Unidad
                    ,Ingrediente = Detalle_PlatillosData.Ingrediente
                    ,IngredienteNombre_Ingrediente = CultureHelper.GetTraduction(Convert.ToString(Detalle_PlatillosData.Ingrediente), "Ingredientes") ??  (string)Detalle_PlatillosData.Ingrediente_Ingredientes.Nombre_Ingrediente
                    ,Caracteristica = Detalle_PlatillosData.Caracteristica
                    ,Unidad_SMAE = Detalle_PlatillosData.Unidad_SMAE
                    ,Equivalente_Unidad_SMAE = Detalle_PlatillosData.Equivalente_Unidad_SMAE
                    ,Porciones = Detalle_PlatillosData.Porciones
                    ,Detalle = Detalle_PlatillosData.Detalle
                    ,Detalle_Super = Detalle_PlatillosData.Detalle_Super

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

	    _ICantidad_fraccion_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Cantidad_fraccion_platilloss_Cantidad_fraccion = _ICantidad_fraccion_platillosApiConsumer.SelAll(true);
            if (Cantidad_fraccion_platilloss_Cantidad_fraccion != null && Cantidad_fraccion_platilloss_Cantidad_fraccion.Resource != null)
                ViewBag.Cantidad_fraccion_platilloss_Cantidad_fraccion = Cantidad_fraccion_platilloss_Cantidad_fraccion.Resource.Where(m => m.Cantidad != null).OrderBy(m => m.Cantidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Cantidad_fraccion_platillos", "Cantidad") ?? m.Cantidad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Ingredientess_Ingrediente = _IIngredientesApiConsumer.SelAll(true);
            if (Ingredientess_Ingrediente != null && Ingredientess_Ingrediente.Resource != null)
                ViewBag.Ingredientess_Ingrediente = Ingredientess_Ingrediente.Resource.Where(m => m.Nombre_Ingrediente != null).OrderBy(m => m.Nombre_Ingrediente).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Ingredientes", "Nombre_Ingrediente") ?? m.Nombre_Ingrediente.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Platillos);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Platillos(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44553);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_PlatillosModel varDetalle_Platillos= new Detalle_PlatillosModel();


            if (id.ToString() != "0")
            {
                var Detalle_PlatillossData = _IDetalle_PlatillosApiConsumer.ListaSelAll(0, 1000, "Detalle_Platillos.Folio=" + id, "").Resource.Detalle_Platilloss;
				
				if (Detalle_PlatillossData != null && Detalle_PlatillossData.Count > 0)
                {
					var Detalle_PlatillosData = Detalle_PlatillossData.First();
					varDetalle_Platillos= new Detalle_PlatillosModel
					{
						Folio  = Detalle_PlatillosData.Folio 
	                    ,Lleva_fracciones = Detalle_PlatillosData.Lleva_fracciones.GetValueOrDefault()
                    ,Cantidad = Detalle_PlatillosData.Cantidad
                    ,Cantidad_fraccion = Detalle_PlatillosData.Cantidad_fraccion
                    ,Cantidad_fraccionCantidad = CultureHelper.GetTraduction(Convert.ToString(Detalle_PlatillosData.Cantidad_fraccion), "Cantidad_fraccion_platillos") ??  (string)Detalle_PlatillosData.Cantidad_fraccion_Cantidad_fraccion_platillos.Cantidad
                    ,Unidad = Detalle_PlatillosData.Unidad
                    ,Ingrediente = Detalle_PlatillosData.Ingrediente
                    ,IngredienteNombre_Ingrediente = CultureHelper.GetTraduction(Convert.ToString(Detalle_PlatillosData.Ingrediente), "Ingredientes") ??  (string)Detalle_PlatillosData.Ingrediente_Ingredientes.Nombre_Ingrediente
                    ,Caracteristica = Detalle_PlatillosData.Caracteristica
                    ,Unidad_SMAE = Detalle_PlatillosData.Unidad_SMAE
                    ,Equivalente_Unidad_SMAE = Detalle_PlatillosData.Equivalente_Unidad_SMAE
                    ,Porciones = Detalle_PlatillosData.Porciones
                    ,Detalle = Detalle_PlatillosData.Detalle
                    ,Detalle_Super = Detalle_PlatillosData.Detalle_Super

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

	    _ICantidad_fraccion_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Cantidad_fraccion_platilloss_Cantidad_fraccion = _ICantidad_fraccion_platillosApiConsumer.SelAll(true);
            if (Cantidad_fraccion_platilloss_Cantidad_fraccion != null && Cantidad_fraccion_platilloss_Cantidad_fraccion.Resource != null)
                ViewBag.Cantidad_fraccion_platilloss_Cantidad_fraccion = Cantidad_fraccion_platilloss_Cantidad_fraccion.Resource.Where(m => m.Cantidad != null).OrderBy(m => m.Cantidad).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Cantidad_fraccion_platillos", "Cantidad") ?? m.Cantidad.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();
            _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Ingredientess_Ingrediente = _IIngredientesApiConsumer.SelAll(true);
            if (Ingredientess_Ingrediente != null && Ingredientess_Ingrediente.Resource != null)
                ViewBag.Ingredientess_Ingrediente = Ingredientess_Ingrediente.Resource.Where(m => m.Nombre_Ingrediente != null).OrderBy(m => m.Nombre_Ingrediente).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Ingredientes", "Nombre_Ingrediente") ?? m.Nombre_Ingrediente.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_Platillos", varDetalle_Platillos);
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
        public ActionResult GetCantidad_fraccion_platillosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ICantidad_fraccion_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ICantidad_fraccion_platillosApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Cantidad).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Cantidad_fraccion_platillos", "Cantidad")?? m.Cantidad,
                    Value = Convert.ToString(m.Folio)
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



        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_PlatillosPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_PlatillosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Platilloss == null)
                result.Detalle_Platilloss = new List<Detalle_Platillos>();

            return Json(new
            {
                data = result.Detalle_Platilloss.Select(m => new Detalle_PlatillosGridModel
                    {
                    Folio = m.Folio
			,Lleva_fracciones = m.Lleva_fracciones
			,Cantidad = m.Cantidad
                        ,Cantidad_fraccionCantidad = CultureHelper.GetTraduction(m.Cantidad_fraccion_Cantidad_fraccion_platillos.Folio.ToString(), "Cantidad_fraccion_platillos") ?? (string)m.Cantidad_fraccion_Cantidad_fraccion_platillos.Cantidad
			,Unidad = m.Unidad
                        ,IngredienteNombre_Ingrediente = CultureHelper.GetTraduction(m.Ingrediente_Ingredientes.Clave.ToString(), "Nombre_Ingrediente") ?? (string)m.Ingrediente_Ingredientes.Nombre_Ingrediente
			,Caracteristica = m.Caracteristica
			,Unidad_SMAE = m.Unidad_SMAE
			,Equivalente_Unidad_SMAE = m.Equivalente_Unidad_SMAE
			,Porciones = m.Porciones
			,Detalle = m.Detalle
			,Detalle_Super = m.Detalle_Super

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetDetalle_Platillos_Cantidad_fraccion_Cantidad_fraccion_platillos(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ICantidad_fraccion_platillosApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Cantidad_fraccion_platillos.Folio as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Cantidad_fraccion_platillos.Cantidad as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _ICantidad_fraccion_platillosApiConsumer.ListaSelAll(1, 20,elWhere , " Cantidad_fraccion_platillos.Cantidad ASC ").Resource;
               
                foreach (var item in result.Cantidad_fraccion_platilloss)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Cantidad_fraccion_platillos", "Cantidad");
                    item.Cantidad =trans ??item.Cantidad;
                }
                return Json(result.Cantidad_fraccion_platilloss.ToArray(), JsonRequestBehavior.AllowGet);
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
                _IDetalle_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Platillos varDetalle_Platillos = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_PlatillosApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_PlatillosModel varDetalle_Platillos)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_PlatillosInfo = new Detalle_Platillos
                    {
                        Folio = varDetalle_Platillos.Folio
                        ,Lleva_fracciones = varDetalle_Platillos.Lleva_fracciones
                        ,Cantidad = varDetalle_Platillos.Cantidad
                        ,Cantidad_fraccion = varDetalle_Platillos.Cantidad_fraccion
                        ,Unidad = varDetalle_Platillos.Unidad
                        ,Ingrediente = varDetalle_Platillos.Ingrediente
                        ,Caracteristica = varDetalle_Platillos.Caracteristica
                        ,Unidad_SMAE = varDetalle_Platillos.Unidad_SMAE
                        ,Equivalente_Unidad_SMAE = varDetalle_Platillos.Equivalente_Unidad_SMAE
                        ,Porciones = varDetalle_Platillos.Porciones
                        ,Detalle = varDetalle_Platillos.Detalle
                        ,Detalle_Super = varDetalle_Platillos.Detalle_Super

                    };

                    result = !IsNew ?
                        _IDetalle_PlatillosApiConsumer.Update(Detalle_PlatillosInfo, null, null).Resource.ToString() :
                         _IDetalle_PlatillosApiConsumer.Insert(Detalle_PlatillosInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Platillos script
        /// </summary>
        /// <param name="oDetalle_PlatillosElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_PlatillosModuleAttributeList)
        {
            for (int i = 0; i < Detalle_PlatillosModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_PlatillosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_PlatillosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_PlatillosModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_PlatillosModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_PlatillosModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_PlatillosModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_PlatillosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_PlatillosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_PlatillosModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_PlatillosModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_PlatillosScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Platillos.js")))
            {
                strDetalle_PlatillosScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Platillos element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_PlatillosModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_PlatillosScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_PlatillosScript.Substring(indexOfArray, strDetalle_PlatillosScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_PlatillosModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_PlatillosModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_PlatillosScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_PlatillosScript.Substring(indexOfArrayHistory, strDetalle_PlatillosScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_PlatillosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_PlatillosScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_PlatillosScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_PlatillosModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_PlatillosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_PlatillosScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_PlatillosScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_PlatillosScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Platillos.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Platillos.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Platillos.js")))
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
        public ActionResult Detalle_PlatillosPropertyBag()
        {
            return PartialView("Detalle_PlatillosPropertyBag", "Detalle_Platillos");
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

            _IDetalle_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_PlatillosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_PlatillosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Platilloss == null)
                result.Detalle_Platilloss = new List<Detalle_Platillos>();

            var data = result.Detalle_Platilloss.Select(m => new Detalle_PlatillosGridModel
            {
                Folio = m.Folio
                ,Lleva_fracciones = m.Lleva_fracciones
                ,Cantidad = m.Cantidad
                ,Cantidad_fraccionCantidad = (string)m.Cantidad_fraccion_Cantidad_fraccion_platillos.Cantidad
                ,Unidad = m.Unidad
                ,IngredienteNombre_Ingrediente = (string)m.Ingrediente_Ingredientes.Nombre_Ingrediente
                ,Caracteristica = m.Caracteristica
                ,Unidad_SMAE = m.Unidad_SMAE
                ,Equivalente_Unidad_SMAE = m.Equivalente_Unidad_SMAE
                ,Porciones = m.Porciones
                ,Detalle = m.Detalle
                ,Detalle_Super = m.Detalle_Super

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_PlatillosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_PlatillosList_" + DateTime.Now.ToString());
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

            _IDetalle_PlatillosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_PlatillosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_PlatillosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Platilloss == null)
                result.Detalle_Platilloss = new List<Detalle_Platillos>();

            var data = result.Detalle_Platilloss.Select(m => new Detalle_PlatillosGridModel
            {
                Folio = m.Folio
                ,Lleva_fracciones = m.Lleva_fracciones
                ,Cantidad = m.Cantidad
                ,Cantidad_fraccionCantidad = (string)m.Cantidad_fraccion_Cantidad_fraccion_platillos.Cantidad
                ,Unidad = m.Unidad
                ,IngredienteNombre_Ingrediente = (string)m.Ingrediente_Ingredientes.Nombre_Ingrediente
                ,Caracteristica = m.Caracteristica
                ,Unidad_SMAE = m.Unidad_SMAE
                ,Equivalente_Unidad_SMAE = m.Equivalente_Unidad_SMAE
                ,Porciones = m.Porciones
                ,Detalle = m.Detalle
                ,Detalle_Super = m.Detalle_Super

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
