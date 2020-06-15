using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Antecedentes_No_Patologicos;
using Spartane.Core.Domain.Sustancias;
using Spartane.Core.Domain.Frecuencia_Sustancias;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Antecedentes_No_Patologicos;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Antecedentes_No_Patologicos;
using Spartane.Web.Areas.WebApiConsumer.Sustancias;
using Spartane.Web.Areas.WebApiConsumer.Frecuencia_Sustancias;

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
    public class Detalle_Antecedentes_No_PatologicosController : Controller
    {
        #region "variable declaration"

        private IDetalle_Antecedentes_No_PatologicosService service = null;
        private IDetalle_Antecedentes_No_PatologicosApiConsumer _IDetalle_Antecedentes_No_PatologicosApiConsumer;
        private ISustanciasApiConsumer _ISustanciasApiConsumer;
        private IFrecuencia_SustanciasApiConsumer _IFrecuencia_SustanciasApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Antecedentes_No_PatologicosController(IDetalle_Antecedentes_No_PatologicosService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Antecedentes_No_PatologicosApiConsumer Detalle_Antecedentes_No_PatologicosApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ISustanciasApiConsumer SustanciasApiConsumer , IFrecuencia_SustanciasApiConsumer Frecuencia_SustanciasApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Antecedentes_No_PatologicosApiConsumer = Detalle_Antecedentes_No_PatologicosApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISustanciasApiConsumer = SustanciasApiConsumer;
            this._IFrecuencia_SustanciasApiConsumer = Frecuencia_SustanciasApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Antecedentes_No_Patologicos
        [ObjectAuth(ObjectId = (ModuleObjectId)44342, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44342);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Antecedentes_No_Patologicos/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44342, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44342);
            ViewBag.Permission = permission;
            var varDetalle_Antecedentes_No_Patologicos = new Detalle_Antecedentes_No_PatologicosModel();
			
            ViewBag.ObjectId = "44342";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Antecedentes_No_PatologicosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Antecedentes_No_PatologicosData = _IDetalle_Antecedentes_No_PatologicosApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Antecedentes_No_Patologicoss[0];
                if (Detalle_Antecedentes_No_PatologicosData == null)
                    return HttpNotFound();

                varDetalle_Antecedentes_No_Patologicos = new Detalle_Antecedentes_No_PatologicosModel
                {
                    Folio = (int)Detalle_Antecedentes_No_PatologicosData.Folio
                    ,Sustancia = Detalle_Antecedentes_No_PatologicosData.Sustancia
                    ,SustanciaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Antecedentes_No_PatologicosData.Sustancia), "Sustancias") ??  (string)Detalle_Antecedentes_No_PatologicosData.Sustancia_Sustancias.Descripcion
                    ,Frecuencia = Detalle_Antecedentes_No_PatologicosData.Frecuencia
                    ,FrecuenciaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Antecedentes_No_PatologicosData.Frecuencia), "Frecuencia_Sustancias") ??  (string)Detalle_Antecedentes_No_PatologicosData.Frecuencia_Frecuencia_Sustancias.Descripcion
                    ,Cantidad = Detalle_Antecedentes_No_PatologicosData.Cantidad

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISustanciasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sustanciass_Sustancia = _ISustanciasApiConsumer.SelAll(true);
            if (Sustanciass_Sustancia != null && Sustanciass_Sustancia.Resource != null)
                ViewBag.Sustanciass_Sustancia = Sustanciass_Sustancia.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sustancias", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IFrecuencia_SustanciasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Frecuencia_Sustanciass_Frecuencia = _IFrecuencia_SustanciasApiConsumer.SelAll(true);
            if (Frecuencia_Sustanciass_Frecuencia != null && Frecuencia_Sustanciass_Frecuencia.Resource != null)
                ViewBag.Frecuencia_Sustanciass_Frecuencia = Frecuencia_Sustanciass_Frecuencia.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Frecuencia_Sustancias", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Antecedentes_No_Patologicos);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Antecedentes_No_Patologicos(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44342);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Antecedentes_No_PatologicosApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Antecedentes_No_PatologicosModel varDetalle_Antecedentes_No_Patologicos= new Detalle_Antecedentes_No_PatologicosModel();


            if (id.ToString() != "0")
            {
                var Detalle_Antecedentes_No_PatologicossData = _IDetalle_Antecedentes_No_PatologicosApiConsumer.ListaSelAll(0, 1000, "Detalle_Antecedentes_No_Patologicos.Folio=" + id, "").Resource.Detalle_Antecedentes_No_Patologicoss;
				
				if (Detalle_Antecedentes_No_PatologicossData != null && Detalle_Antecedentes_No_PatologicossData.Count > 0)
                {
					var Detalle_Antecedentes_No_PatologicosData = Detalle_Antecedentes_No_PatologicossData.First();
					varDetalle_Antecedentes_No_Patologicos= new Detalle_Antecedentes_No_PatologicosModel
					{
						Folio  = Detalle_Antecedentes_No_PatologicosData.Folio 
	                    ,Sustancia = Detalle_Antecedentes_No_PatologicosData.Sustancia
                    ,SustanciaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Antecedentes_No_PatologicosData.Sustancia), "Sustancias") ??  (string)Detalle_Antecedentes_No_PatologicosData.Sustancia_Sustancias.Descripcion
                    ,Frecuencia = Detalle_Antecedentes_No_PatologicosData.Frecuencia
                    ,FrecuenciaDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Antecedentes_No_PatologicosData.Frecuencia), "Frecuencia_Sustancias") ??  (string)Detalle_Antecedentes_No_PatologicosData.Frecuencia_Frecuencia_Sustancias.Descripcion
                    ,Cantidad = Detalle_Antecedentes_No_PatologicosData.Cantidad

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISustanciasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Sustanciass_Sustancia = _ISustanciasApiConsumer.SelAll(true);
            if (Sustanciass_Sustancia != null && Sustanciass_Sustancia.Resource != null)
                ViewBag.Sustanciass_Sustancia = Sustanciass_Sustancia.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sustancias", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IFrecuencia_SustanciasApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Frecuencia_Sustanciass_Frecuencia = _IFrecuencia_SustanciasApiConsumer.SelAll(true);
            if (Frecuencia_Sustanciass_Frecuencia != null && Frecuencia_Sustanciass_Frecuencia.Resource != null)
                ViewBag.Frecuencia_Sustanciass_Frecuencia = Frecuencia_Sustanciass_Frecuencia.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Frecuencia_Sustancias", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddDetalle_Antecedentes_No_Patologicos", varDetalle_Antecedentes_No_Patologicos);
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
        public ActionResult GetSustanciasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISustanciasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISustanciasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Sustancias", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetFrecuencia_SustanciasAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IFrecuencia_SustanciasApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IFrecuencia_SustanciasApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Frecuencia_Sustancias", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Antecedentes_No_PatologicosPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Antecedentes_No_PatologicosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Antecedentes_No_Patologicoss == null)
                result.Detalle_Antecedentes_No_Patologicoss = new List<Detalle_Antecedentes_No_Patologicos>();

            return Json(new
            {
                data = result.Detalle_Antecedentes_No_Patologicoss.Select(m => new Detalle_Antecedentes_No_PatologicosGridModel
                    {
                    Folio = m.Folio
                        ,SustanciaDescripcion = CultureHelper.GetTraduction(m.Sustancia_Sustancias.Clave.ToString(), "Descripcion") ?? (string)m.Sustancia_Sustancias.Descripcion
                        ,FrecuenciaDescripcion = CultureHelper.GetTraduction(m.Frecuencia_Frecuencia_Sustancias.Clave.ToString(), "Descripcion") ?? (string)m.Frecuencia_Frecuencia_Sustancias.Descripcion
			,Cantidad = m.Cantidad

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
                _IDetalle_Antecedentes_No_PatologicosApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Antecedentes_No_Patologicos varDetalle_Antecedentes_No_Patologicos = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Antecedentes_No_PatologicosApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Antecedentes_No_PatologicosModel varDetalle_Antecedentes_No_Patologicos)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Antecedentes_No_PatologicosApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Antecedentes_No_PatologicosInfo = new Detalle_Antecedentes_No_Patologicos
                    {
                        Folio = varDetalle_Antecedentes_No_Patologicos.Folio
                        ,Sustancia = varDetalle_Antecedentes_No_Patologicos.Sustancia
                        ,Frecuencia = varDetalle_Antecedentes_No_Patologicos.Frecuencia
                        ,Cantidad = varDetalle_Antecedentes_No_Patologicos.Cantidad

                    };

                    result = !IsNew ?
                        _IDetalle_Antecedentes_No_PatologicosApiConsumer.Update(Detalle_Antecedentes_No_PatologicosInfo, null, null).Resource.ToString() :
                         _IDetalle_Antecedentes_No_PatologicosApiConsumer.Insert(Detalle_Antecedentes_No_PatologicosInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Detalle_Antecedentes_No_Patologicos script
        /// </summary>
        /// <param name="oDetalle_Antecedentes_No_PatologicosElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Antecedentes_No_PatologicosModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Antecedentes_No_PatologicosModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Antecedentes_No_PatologicosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Antecedentes_No_PatologicosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Antecedentes_No_PatologicosModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Antecedentes_No_PatologicosModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Antecedentes_No_PatologicosModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Antecedentes_No_PatologicosModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Antecedentes_No_PatologicosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Antecedentes_No_PatologicosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Antecedentes_No_PatologicosModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Antecedentes_No_PatologicosModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Antecedentes_No_PatologicosScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Antecedentes_No_Patologicos.js")))
            {
                strDetalle_Antecedentes_No_PatologicosScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Antecedentes_No_Patologicos element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Antecedentes_No_PatologicosModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Antecedentes_No_PatologicosScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Antecedentes_No_PatologicosScript.Substring(indexOfArray, strDetalle_Antecedentes_No_PatologicosScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Antecedentes_No_PatologicosModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Antecedentes_No_PatologicosModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Antecedentes_No_PatologicosScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Antecedentes_No_PatologicosScript.Substring(indexOfArrayHistory, strDetalle_Antecedentes_No_PatologicosScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Antecedentes_No_PatologicosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Antecedentes_No_PatologicosScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Antecedentes_No_PatologicosScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Antecedentes_No_PatologicosModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Antecedentes_No_PatologicosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Antecedentes_No_PatologicosScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Antecedentes_No_PatologicosScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Antecedentes_No_PatologicosScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Antecedentes_No_Patologicos.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Antecedentes_No_Patologicos.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Antecedentes_No_Patologicos.js")))
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
        public ActionResult Detalle_Antecedentes_No_PatologicosPropertyBag()
        {
            return PartialView("Detalle_Antecedentes_No_PatologicosPropertyBag", "Detalle_Antecedentes_No_Patologicos");
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

            _IDetalle_Antecedentes_No_PatologicosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Antecedentes_No_PatologicosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Antecedentes_No_PatologicosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Antecedentes_No_Patologicoss == null)
                result.Detalle_Antecedentes_No_Patologicoss = new List<Detalle_Antecedentes_No_Patologicos>();

            var data = result.Detalle_Antecedentes_No_Patologicoss.Select(m => new Detalle_Antecedentes_No_PatologicosGridModel
            {
                Folio = m.Folio
                ,SustanciaDescripcion = (string)m.Sustancia_Sustancias.Descripcion
                ,FrecuenciaDescripcion = (string)m.Frecuencia_Frecuencia_Sustancias.Descripcion
                ,Cantidad = m.Cantidad

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Antecedentes_No_PatologicosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Antecedentes_No_PatologicosList_" + DateTime.Now.ToString());
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

            _IDetalle_Antecedentes_No_PatologicosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Antecedentes_No_PatologicosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Antecedentes_No_PatologicosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Antecedentes_No_Patologicoss == null)
                result.Detalle_Antecedentes_No_Patologicoss = new List<Detalle_Antecedentes_No_Patologicos>();

            var data = result.Detalle_Antecedentes_No_Patologicoss.Select(m => new Detalle_Antecedentes_No_PatologicosGridModel
            {
                Folio = m.Folio
                ,SustanciaDescripcion = (string)m.Sustancia_Sustancias.Descripcion
                ,FrecuenciaDescripcion = (string)m.Frecuencia_Frecuencia_Sustancias.Descripcion
                ,Cantidad = m.Cantidad

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
