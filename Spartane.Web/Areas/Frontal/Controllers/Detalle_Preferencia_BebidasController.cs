using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Preferencia_Bebidas;
using Spartane.Core.Domain.Bebidas;
using Spartane.Core.Domain.Rango_Consumo_Bebidas;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Preferencia_Bebidas;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Preferencia_Bebidas;
using Spartane.Web.Areas.WebApiConsumer.Bebidas;
using Spartane.Web.Areas.WebApiConsumer.Rango_Consumo_Bebidas;

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
    public class Detalle_Preferencia_BebidasController : Controller
    {
        #region "variable declaration"

        private IDetalle_Preferencia_BebidasService service = null;
        private IDetalle_Preferencia_BebidasApiConsumer _IDetalle_Preferencia_BebidasApiConsumer;
        private IBebidasApiConsumer _IBebidasApiConsumer;
        private IRango_Consumo_BebidasApiConsumer _IRango_Consumo_BebidasApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Preferencia_BebidasController(IDetalle_Preferencia_BebidasService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Preferencia_BebidasApiConsumer Detalle_Preferencia_BebidasApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IBebidasApiConsumer BebidasApiConsumer , IRango_Consumo_BebidasApiConsumer Rango_Consumo_BebidasApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Preferencia_BebidasApiConsumer = Detalle_Preferencia_BebidasApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IBebidasApiConsumer = BebidasApiConsumer;
            this._IRango_Consumo_BebidasApiConsumer = Rango_Consumo_BebidasApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Preferencia_Bebidas
        [ObjectAuth(ObjectId = (ModuleObjectId)44336, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44336);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Preferencia_Bebidas/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44336, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44336);
            ViewBag.Permission = permission;
            var varDetalle_Preferencia_Bebidas = new Detalle_Preferencia_BebidasModel();
			
            ViewBag.ObjectId = "44336";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Preferencia_BebidasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Preferencia_BebidasData = _IDetalle_Preferencia_BebidasApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Preferencia_Bebidass[0];
                if (Detalle_Preferencia_BebidasData == null)
                    return HttpNotFound();

                varDetalle_Preferencia_Bebidas = new Detalle_Preferencia_BebidasModel
                {
                    Folio = (int)Detalle_Preferencia_BebidasData.Folio
                    ,Bebida = Detalle_Preferencia_BebidasData.Bebida
                    ,BebidaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Preferencia_BebidasData.Bebida), "Bebidas") ??  (string)Detalle_Preferencia_BebidasData.Bebida_Bebidas.Descripcion
                    ,Cantidad = Detalle_Preferencia_BebidasData.Cantidad
                    ,CantidadDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Preferencia_BebidasData.Cantidad), "Rango_Consumo_Bebidas") ??  (string)Detalle_Preferencia_BebidasData.Cantidad_Rango_Consumo_Bebidas.Descripcion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IBebidasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Bebidass_Bebida = _IBebidasApiConsumer.SelAll(true);
            if (Bebidass_Bebida != null && Bebidass_Bebida.Resource != null)
                ViewBag.Bebidass_Bebida = Bebidass_Bebida.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Bebidas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRango_Consumo_BebidasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Rango_Consumo_Bebidass_Cantidad = _IRango_Consumo_BebidasApiConsumer.SelAll(true);
            if (Rango_Consumo_Bebidass_Cantidad != null && Rango_Consumo_Bebidass_Cantidad.Resource != null)
                ViewBag.Rango_Consumo_Bebidass_Cantidad = Rango_Consumo_Bebidass_Cantidad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Rango_Consumo_Bebidas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Preferencia_Bebidas);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Preferencia_Bebidas(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44336);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Preferencia_BebidasApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Preferencia_BebidasModel varDetalle_Preferencia_Bebidas= new Detalle_Preferencia_BebidasModel();


            if (id.ToString() != "0")
            {
                var Detalle_Preferencia_BebidassData = _IDetalle_Preferencia_BebidasApiConsumer.ListaSelAll(0, 1000, "Detalle_Preferencia_Bebidas.Folio=" + id, "").Resource.Detalle_Preferencia_Bebidass;
				
				if (Detalle_Preferencia_BebidassData != null && Detalle_Preferencia_BebidassData.Count > 0)
                {
					var Detalle_Preferencia_BebidasData = Detalle_Preferencia_BebidassData.First();
					varDetalle_Preferencia_Bebidas= new Detalle_Preferencia_BebidasModel
					{
						Folio  = Detalle_Preferencia_BebidasData.Folio 
	                    ,Bebida = Detalle_Preferencia_BebidasData.Bebida
                    ,BebidaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Preferencia_BebidasData.Bebida), "Bebidas") ??  (string)Detalle_Preferencia_BebidasData.Bebida_Bebidas.Descripcion
                    ,Cantidad = Detalle_Preferencia_BebidasData.Cantidad
                    ,CantidadDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Preferencia_BebidasData.Cantidad), "Rango_Consumo_Bebidas") ??  (string)Detalle_Preferencia_BebidasData.Cantidad_Rango_Consumo_Bebidas.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IBebidasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Bebidass_Bebida = _IBebidasApiConsumer.SelAll(true);
            if (Bebidass_Bebida != null && Bebidass_Bebida.Resource != null)
                ViewBag.Bebidass_Bebida = Bebidass_Bebida.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Bebidas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IRango_Consumo_BebidasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Rango_Consumo_Bebidass_Cantidad = _IRango_Consumo_BebidasApiConsumer.SelAll(true);
            if (Rango_Consumo_Bebidass_Cantidad != null && Rango_Consumo_Bebidass_Cantidad.Resource != null)
                ViewBag.Rango_Consumo_Bebidass_Cantidad = Rango_Consumo_Bebidass_Cantidad.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Rango_Consumo_Bebidas", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_Preferencia_Bebidas", varDetalle_Preferencia_Bebidas);
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
        public ActionResult GetBebidasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IBebidasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IBebidasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Bebidas", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetRango_Consumo_BebidasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRango_Consumo_BebidasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRango_Consumo_BebidasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Rango_Consumo_Bebidas", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Preferencia_BebidasPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Preferencia_BebidasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Preferencia_Bebidass == null)
                result.Detalle_Preferencia_Bebidass = new List<Detalle_Preferencia_Bebidas>();

            return Json(new
            {
                data = result.Detalle_Preferencia_Bebidass.Select(m => new Detalle_Preferencia_BebidasGridModel
                    {
                    Folio = m.Folio
                        ,BebidaDescripcion = CultureHelper.GetTraduction(m.Bebida_Bebidas.Clave.ToString(), "Descripcion") ?? (string)m.Bebida_Bebidas.Descripcion
                        ,CantidadDescripcion = CultureHelper.GetTraduction(m.Cantidad_Rango_Consumo_Bebidas.Clave.ToString(), "Descripcion") ?? (string)m.Cantidad_Rango_Consumo_Bebidas.Descripcion

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
                _IDetalle_Preferencia_BebidasApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Preferencia_Bebidas varDetalle_Preferencia_Bebidas = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Preferencia_BebidasApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Preferencia_BebidasModel varDetalle_Preferencia_Bebidas)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Preferencia_BebidasApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Preferencia_BebidasInfo = new Detalle_Preferencia_Bebidas
                    {
                        Folio = varDetalle_Preferencia_Bebidas.Folio
                        ,Bebida = varDetalle_Preferencia_Bebidas.Bebida
                        ,Cantidad = varDetalle_Preferencia_Bebidas.Cantidad

                    };

                    result = !IsNew ?
                        _IDetalle_Preferencia_BebidasApiConsumer.Update(Detalle_Preferencia_BebidasInfo, null, null).Resource.ToString() :
                         _IDetalle_Preferencia_BebidasApiConsumer.Insert(Detalle_Preferencia_BebidasInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Preferencia_Bebidas script
        /// </summary>
        /// <param name="oDetalle_Preferencia_BebidasElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Preferencia_BebidasModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Preferencia_BebidasModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Preferencia_BebidasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Preferencia_BebidasModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Preferencia_BebidasModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Preferencia_BebidasModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Preferencia_BebidasModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Preferencia_BebidasModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Preferencia_BebidasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Preferencia_BebidasModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Preferencia_BebidasModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Preferencia_BebidasModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Preferencia_BebidasScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Preferencia_Bebidas.js")))
            {
                strDetalle_Preferencia_BebidasScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Preferencia_Bebidas element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Preferencia_BebidasModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Preferencia_BebidasScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Preferencia_BebidasScript.Substring(indexOfArray, strDetalle_Preferencia_BebidasScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Preferencia_BebidasModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Preferencia_BebidasModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Preferencia_BebidasScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Preferencia_BebidasScript.Substring(indexOfArrayHistory, strDetalle_Preferencia_BebidasScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Preferencia_BebidasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Preferencia_BebidasScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Preferencia_BebidasScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Preferencia_BebidasModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Preferencia_BebidasScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Preferencia_BebidasScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Preferencia_BebidasScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Preferencia_BebidasScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Preferencia_Bebidas.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Preferencia_Bebidas.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Preferencia_Bebidas.js")))
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
        public ActionResult Detalle_Preferencia_BebidasPropertyBag()
        {
            return PartialView("Detalle_Preferencia_BebidasPropertyBag", "Detalle_Preferencia_Bebidas");
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

            _IDetalle_Preferencia_BebidasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Preferencia_BebidasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Preferencia_BebidasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Preferencia_Bebidass == null)
                result.Detalle_Preferencia_Bebidass = new List<Detalle_Preferencia_Bebidas>();

            var data = result.Detalle_Preferencia_Bebidass.Select(m => new Detalle_Preferencia_BebidasGridModel
            {
                Folio = m.Folio
                ,BebidaDescripcion = (string)m.Bebida_Bebidas.Descripcion
                ,CantidadDescripcion = (string)m.Cantidad_Rango_Consumo_Bebidas.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Preferencia_BebidasList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Preferencia_BebidasList_" + DateTime.Now.ToString());
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

            _IDetalle_Preferencia_BebidasApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Preferencia_BebidasPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Preferencia_BebidasApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Preferencia_Bebidass == null)
                result.Detalle_Preferencia_Bebidass = new List<Detalle_Preferencia_Bebidas>();

            var data = result.Detalle_Preferencia_Bebidass.Select(m => new Detalle_Preferencia_BebidasGridModel
            {
                Folio = m.Folio
                ,BebidaDescripcion = (string)m.Bebida_Bebidas.Descripcion
                ,CantidadDescripcion = (string)m.Cantidad_Rango_Consumo_Bebidas.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
