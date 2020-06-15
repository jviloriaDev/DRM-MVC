using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Sucursales_Proveedores;
using Spartane.Core.Domain.Tipo_de_Sucursal;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Sucursales_Proveedores;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Sucursales_Proveedores;
using Spartane.Web.Areas.WebApiConsumer.Tipo_de_Sucursal;

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
    public class Detalle_Sucursales_ProveedoresController : Controller
    {
        #region "variable declaration"

        private IDetalle_Sucursales_ProveedoresService service = null;
        private IDetalle_Sucursales_ProveedoresApiConsumer _IDetalle_Sucursales_ProveedoresApiConsumer;
        private ITipo_de_SucursalApiConsumer _ITipo_de_SucursalApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Sucursales_ProveedoresController(IDetalle_Sucursales_ProveedoresService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Sucursales_ProveedoresApiConsumer Detalle_Sucursales_ProveedoresApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ITipo_de_SucursalApiConsumer Tipo_de_SucursalApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Sucursales_ProveedoresApiConsumer = Detalle_Sucursales_ProveedoresApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ITipo_de_SucursalApiConsumer = Tipo_de_SucursalApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Sucursales_Proveedores
        [ObjectAuth(ObjectId = (ModuleObjectId)44593, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44593);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Sucursales_Proveedores/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44593, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44593);
            ViewBag.Permission = permission;
            var varDetalle_Sucursales_Proveedores = new Detalle_Sucursales_ProveedoresModel();
			
            ViewBag.ObjectId = "44593";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Sucursales_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Sucursales_ProveedoresData = _IDetalle_Sucursales_ProveedoresApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Sucursales_Proveedoress[0];
                if (Detalle_Sucursales_ProveedoresData == null)
                    return HttpNotFound();

                varDetalle_Sucursales_Proveedores = new Detalle_Sucursales_ProveedoresModel
                {
                    Folio = (int)Detalle_Sucursales_ProveedoresData.Folio
                    ,Tipo_de_Sucursal = Detalle_Sucursales_ProveedoresData.Tipo_de_Sucursal
                    ,Tipo_de_SucursalDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Sucursales_ProveedoresData.Tipo_de_Sucursal), "Tipo_de_Sucursal") ??  (string)Detalle_Sucursales_ProveedoresData.Tipo_de_Sucursal_Tipo_de_Sucursal.Descripcion
                    ,Email = Detalle_Sucursales_ProveedoresData.Email
                    ,Telefono = Detalle_Sucursales_ProveedoresData.Telefono
                    ,Calle = Detalle_Sucursales_ProveedoresData.Calle
                    ,Numero_exterior = Detalle_Sucursales_ProveedoresData.Numero_exterior
                    ,Numero_interior = Detalle_Sucursales_ProveedoresData.Numero_interior
                    ,Colonia = Detalle_Sucursales_ProveedoresData.Colonia
                    ,C_P_ = Detalle_Sucursales_ProveedoresData.C_P_
                    ,Ciudad = Detalle_Sucursales_ProveedoresData.Ciudad
                    ,Estado = Detalle_Sucursales_ProveedoresData.Estado
                    ,Pais = Detalle_Sucursales_ProveedoresData.Pais

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

	    _ITipo_de_SucursalApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Sucursals_Tipo_de_Sucursal = _ITipo_de_SucursalApiConsumer.SelAll(true);
            if (Tipo_de_Sucursals_Tipo_de_Sucursal != null && Tipo_de_Sucursals_Tipo_de_Sucursal.Resource != null)
                ViewBag.Tipo_de_Sucursals_Tipo_de_Sucursal = Tipo_de_Sucursals_Tipo_de_Sucursal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Sucursal", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Sucursales_Proveedores);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Sucursales_Proveedores(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44593);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Sucursales_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Sucursales_ProveedoresModel varDetalle_Sucursales_Proveedores= new Detalle_Sucursales_ProveedoresModel();


            if (id.ToString() != "0")
            {
                var Detalle_Sucursales_ProveedoressData = _IDetalle_Sucursales_ProveedoresApiConsumer.ListaSelAll(0, 1000, "Detalle_Sucursales_Proveedores.Folio=" + id, "").Resource.Detalle_Sucursales_Proveedoress;
				
				if (Detalle_Sucursales_ProveedoressData != null && Detalle_Sucursales_ProveedoressData.Count > 0)
                {
					var Detalle_Sucursales_ProveedoresData = Detalle_Sucursales_ProveedoressData.First();
					varDetalle_Sucursales_Proveedores= new Detalle_Sucursales_ProveedoresModel
					{
						Folio  = Detalle_Sucursales_ProveedoresData.Folio 
	                    ,Tipo_de_Sucursal = Detalle_Sucursales_ProveedoresData.Tipo_de_Sucursal
                    ,Tipo_de_SucursalDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Sucursales_ProveedoresData.Tipo_de_Sucursal), "Tipo_de_Sucursal") ??  (string)Detalle_Sucursales_ProveedoresData.Tipo_de_Sucursal_Tipo_de_Sucursal.Descripcion
                    ,Email = Detalle_Sucursales_ProveedoresData.Email
                    ,Telefono = Detalle_Sucursales_ProveedoresData.Telefono
                    ,Calle = Detalle_Sucursales_ProveedoresData.Calle
                    ,Numero_exterior = Detalle_Sucursales_ProveedoresData.Numero_exterior
                    ,Numero_interior = Detalle_Sucursales_ProveedoresData.Numero_interior
                    ,Colonia = Detalle_Sucursales_ProveedoresData.Colonia
                    ,C_P_ = Detalle_Sucursales_ProveedoresData.C_P_
                    ,Ciudad = Detalle_Sucursales_ProveedoresData.Ciudad
                    ,Estado = Detalle_Sucursales_ProveedoresData.Estado
                    ,Pais = Detalle_Sucursales_ProveedoresData.Pais

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

	    _ITipo_de_SucursalApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Tipo_de_Sucursals_Tipo_de_Sucursal = _ITipo_de_SucursalApiConsumer.SelAll(true);
            if (Tipo_de_Sucursals_Tipo_de_Sucursal != null && Tipo_de_Sucursals_Tipo_de_Sucursal.Resource != null)
                ViewBag.Tipo_de_Sucursals_Tipo_de_Sucursal = Tipo_de_Sucursals_Tipo_de_Sucursal.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Sucursal", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_Sucursales_Proveedores", varDetalle_Sucursales_Proveedores);
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
        public ActionResult GetTipo_de_SucursalAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_SucursalApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITipo_de_SucursalApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Tipo_de_Sucursal", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Sucursales_ProveedoresPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Sucursales_ProveedoresApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Sucursales_Proveedoress == null)
                result.Detalle_Sucursales_Proveedoress = new List<Detalle_Sucursales_Proveedores>();

            return Json(new
            {
                data = result.Detalle_Sucursales_Proveedoress.Select(m => new Detalle_Sucursales_ProveedoresGridModel
                    {
                    Folio = m.Folio
                        ,Tipo_de_SucursalDescripcion = CultureHelper.GetTraduction(m.Tipo_de_Sucursal_Tipo_de_Sucursal.Clave.ToString(), "Tipo_de_Sucursal") ?? (string)m.Tipo_de_Sucursal_Tipo_de_Sucursal.Descripcion
			,Email = m.Email
			,Telefono = m.Telefono
			,Calle = m.Calle
			,Numero_exterior = m.Numero_exterior
			,Numero_interior = m.Numero_interior
			,Colonia = m.Colonia
			,C_P_ = m.C_P_
			,Ciudad = m.Ciudad
			,Estado = m.Estado
			,Pais = m.Pais

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetDetalle_Sucursales_Proveedores_Tipo_de_Sucursal_Tipo_de_Sucursal(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITipo_de_SucursalApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Tipo_de_Sucursal.Clave as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Tipo_de_Sucursal.Descripcion as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _ITipo_de_SucursalApiConsumer.ListaSelAll(1, 20,elWhere , " Tipo_de_Sucursal.Descripcion ASC ").Resource;
               
                foreach (var item in result.Tipo_de_Sucursals)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Tipo_de_Sucursal", "Descripcion");
                    item.Descripcion =trans ??item.Descripcion;
                }
                return Json(result.Tipo_de_Sucursals.ToArray(), JsonRequestBehavior.AllowGet);
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
                _IDetalle_Sucursales_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Sucursales_Proveedores varDetalle_Sucursales_Proveedores = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Sucursales_ProveedoresApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Sucursales_ProveedoresModel varDetalle_Sucursales_Proveedores)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Sucursales_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Sucursales_ProveedoresInfo = new Detalle_Sucursales_Proveedores
                    {
                        Folio = varDetalle_Sucursales_Proveedores.Folio
                        ,Tipo_de_Sucursal = varDetalle_Sucursales_Proveedores.Tipo_de_Sucursal
                        ,Email = varDetalle_Sucursales_Proveedores.Email
                        ,Telefono = varDetalle_Sucursales_Proveedores.Telefono
                        ,Calle = varDetalle_Sucursales_Proveedores.Calle
                        ,Numero_exterior = varDetalle_Sucursales_Proveedores.Numero_exterior
                        ,Numero_interior = varDetalle_Sucursales_Proveedores.Numero_interior
                        ,Colonia = varDetalle_Sucursales_Proveedores.Colonia
                        ,C_P_ = varDetalle_Sucursales_Proveedores.C_P_
                        ,Ciudad = varDetalle_Sucursales_Proveedores.Ciudad
                        ,Estado = varDetalle_Sucursales_Proveedores.Estado
                        ,Pais = varDetalle_Sucursales_Proveedores.Pais

                    };

                    result = !IsNew ?
                        _IDetalle_Sucursales_ProveedoresApiConsumer.Update(Detalle_Sucursales_ProveedoresInfo, null, null).Resource.ToString() :
                         _IDetalle_Sucursales_ProveedoresApiConsumer.Insert(Detalle_Sucursales_ProveedoresInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Sucursales_Proveedores script
        /// </summary>
        /// <param name="oDetalle_Sucursales_ProveedoresElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Sucursales_ProveedoresModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Sucursales_ProveedoresModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Sucursales_ProveedoresModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Sucursales_ProveedoresModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Sucursales_ProveedoresModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Sucursales_ProveedoresModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Sucursales_ProveedoresModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Sucursales_ProveedoresModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Sucursales_ProveedoresModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Sucursales_ProveedoresModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Sucursales_ProveedoresModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Sucursales_ProveedoresModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Sucursales_ProveedoresScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Sucursales_Proveedores.js")))
            {
                strDetalle_Sucursales_ProveedoresScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Sucursales_Proveedores element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Sucursales_ProveedoresModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Sucursales_ProveedoresScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Sucursales_ProveedoresScript.Substring(indexOfArray, strDetalle_Sucursales_ProveedoresScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Sucursales_ProveedoresModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Sucursales_ProveedoresModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Sucursales_ProveedoresScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Sucursales_ProveedoresScript.Substring(indexOfArrayHistory, strDetalle_Sucursales_ProveedoresScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Sucursales_ProveedoresScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Sucursales_ProveedoresScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Sucursales_ProveedoresScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Sucursales_ProveedoresModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Sucursales_ProveedoresScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Sucursales_ProveedoresScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Sucursales_ProveedoresScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Sucursales_ProveedoresScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Sucursales_Proveedores.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Sucursales_Proveedores.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Sucursales_Proveedores.js")))
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
        public ActionResult Detalle_Sucursales_ProveedoresPropertyBag()
        {
            return PartialView("Detalle_Sucursales_ProveedoresPropertyBag", "Detalle_Sucursales_Proveedores");
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

            _IDetalle_Sucursales_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Sucursales_ProveedoresPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Sucursales_ProveedoresApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Sucursales_Proveedoress == null)
                result.Detalle_Sucursales_Proveedoress = new List<Detalle_Sucursales_Proveedores>();

            var data = result.Detalle_Sucursales_Proveedoress.Select(m => new Detalle_Sucursales_ProveedoresGridModel
            {
                Folio = m.Folio
                ,Tipo_de_SucursalDescripcion = (string)m.Tipo_de_Sucursal_Tipo_de_Sucursal.Descripcion
                ,Email = m.Email
                ,Telefono = m.Telefono
                ,Calle = m.Calle
                ,Numero_exterior = m.Numero_exterior
                ,Numero_interior = m.Numero_interior
                ,Colonia = m.Colonia
                ,C_P_ = m.C_P_
                ,Ciudad = m.Ciudad
                ,Estado = m.Estado
                ,Pais = m.Pais

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Sucursales_ProveedoresList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Sucursales_ProveedoresList_" + DateTime.Now.ToString());
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

            _IDetalle_Sucursales_ProveedoresApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Sucursales_ProveedoresPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Sucursales_ProveedoresApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Sucursales_Proveedoress == null)
                result.Detalle_Sucursales_Proveedoress = new List<Detalle_Sucursales_Proveedores>();

            var data = result.Detalle_Sucursales_Proveedoress.Select(m => new Detalle_Sucursales_ProveedoresGridModel
            {
                Folio = m.Folio
                ,Tipo_de_SucursalDescripcion = (string)m.Tipo_de_Sucursal_Tipo_de_Sucursal.Descripcion
                ,Email = m.Email
                ,Telefono = m.Telefono
                ,Calle = m.Calle
                ,Numero_exterior = m.Numero_exterior
                ,Numero_interior = m.Numero_interior
                ,Colonia = m.Colonia
                ,C_P_ = m.C_P_
                ,Ciudad = m.Ciudad
                ,Estado = m.Estado
                ,Pais = m.Pais

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
