using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.MS_Suscripciones_Codigos_Referidos_Especialista;
using Spartane.Core.Domain.Planes_de_Suscripcion;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.MS_Suscripciones_Codigos_Referidos_Especialista;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.MS_Suscripciones_Codigos_Referidos_Especialista;
using Spartane.Web.Areas.WebApiConsumer.Planes_de_Suscripcion;

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
    public class MS_Suscripciones_Codigos_Referidos_EspecialistaController : Controller
    {
        #region "variable declaration"

        private IMS_Suscripciones_Codigos_Referidos_EspecialistaService service = null;
        private IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer _IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer;
        private IPlanes_de_SuscripcionApiConsumer _IPlanes_de_SuscripcionApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public MS_Suscripciones_Codigos_Referidos_EspecialistaController(IMS_Suscripciones_Codigos_Referidos_EspecialistaService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer MS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IPlanes_de_SuscripcionApiConsumer Planes_de_SuscripcionApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer = MS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IPlanes_de_SuscripcionApiConsumer = Planes_de_SuscripcionApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/MS_Suscripciones_Codigos_Referidos_Especialista
        [ObjectAuth(ObjectId = (ModuleObjectId)44452, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44452);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/MS_Suscripciones_Codigos_Referidos_Especialista/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44452, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44452);
            ViewBag.Permission = permission;
            var varMS_Suscripciones_Codigos_Referidos_Especialista = new MS_Suscripciones_Codigos_Referidos_EspecialistaModel();
			
            ViewBag.ObjectId = "44452";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var MS_Suscripciones_Codigos_Referidos_EspecialistaData = _IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer.GetByKeyComplete(Id).Resource.MS_Suscripciones_Codigos_Referidos_Especialistas[0];
                if (MS_Suscripciones_Codigos_Referidos_EspecialistaData == null)
                    return HttpNotFound();

                varMS_Suscripciones_Codigos_Referidos_Especialista = new MS_Suscripciones_Codigos_Referidos_EspecialistaModel
                {
                    Folio = (int)MS_Suscripciones_Codigos_Referidos_EspecialistaData.Folio
                    ,Plan_de_Suscripcion = MS_Suscripciones_Codigos_Referidos_EspecialistaData.Plan_de_Suscripcion
                    ,Plan_de_SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(Convert.ToString(MS_Suscripciones_Codigos_Referidos_EspecialistaData.Plan_de_Suscripcion), "Planes_de_Suscripcion") ??  (string)MS_Suscripciones_Codigos_Referidos_EspecialistaData.Plan_de_Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Planes_de_Suscripcions_Plan_de_Suscripcion = _IPlanes_de_SuscripcionApiConsumer.SelAll(true);
            if (Planes_de_Suscripcions_Plan_de_Suscripcion != null && Planes_de_Suscripcions_Plan_de_Suscripcion.Resource != null)
                ViewBag.Planes_de_Suscripcions_Plan_de_Suscripcion = Planes_de_Suscripcions_Plan_de_Suscripcion.Resource.Where(m => m.Nombre_del_Plan != null).OrderBy(m => m.Nombre_del_Plan).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan") ?? m.Nombre_del_Plan.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varMS_Suscripciones_Codigos_Referidos_Especialista);
        }
		
	[HttpGet]
        public ActionResult AddMS_Suscripciones_Codigos_Referidos_Especialista(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44452);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);
			MS_Suscripciones_Codigos_Referidos_EspecialistaModel varMS_Suscripciones_Codigos_Referidos_Especialista= new MS_Suscripciones_Codigos_Referidos_EspecialistaModel();


            if (id.ToString() != "0")
            {
                var MS_Suscripciones_Codigos_Referidos_EspecialistasData = _IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer.ListaSelAll(0, 1000, "MS_Suscripciones_Codigos_Referidos_Especialista.Folio=" + id, "").Resource.MS_Suscripciones_Codigos_Referidos_Especialistas;
				
				if (MS_Suscripciones_Codigos_Referidos_EspecialistasData != null && MS_Suscripciones_Codigos_Referidos_EspecialistasData.Count > 0)
                {
					var MS_Suscripciones_Codigos_Referidos_EspecialistaData = MS_Suscripciones_Codigos_Referidos_EspecialistasData.First();
					varMS_Suscripciones_Codigos_Referidos_Especialista= new MS_Suscripciones_Codigos_Referidos_EspecialistaModel
					{
						Folio  = MS_Suscripciones_Codigos_Referidos_EspecialistaData.Folio 
	                    ,Plan_de_Suscripcion = MS_Suscripciones_Codigos_Referidos_EspecialistaData.Plan_de_Suscripcion
                    ,Plan_de_SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(Convert.ToString(MS_Suscripciones_Codigos_Referidos_EspecialistaData.Plan_de_Suscripcion), "Planes_de_Suscripcion") ??  (string)MS_Suscripciones_Codigos_Referidos_EspecialistaData.Plan_de_Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IPlanes_de_SuscripcionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Planes_de_Suscripcions_Plan_de_Suscripcion = _IPlanes_de_SuscripcionApiConsumer.SelAll(true);
            if (Planes_de_Suscripcions_Plan_de_Suscripcion != null && Planes_de_Suscripcions_Plan_de_Suscripcion.Resource != null)
                ViewBag.Planes_de_Suscripcions_Plan_de_Suscripcion = Planes_de_Suscripcions_Plan_de_Suscripcion.Resource.Where(m => m.Nombre_del_Plan != null).OrderBy(m => m.Nombre_del_Plan).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Planes_de_Suscripcion", "Nombre_del_Plan") ?? m.Nombre_del_Plan.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddMS_Suscripciones_Codigos_Referidos_Especialista", varMS_Suscripciones_Codigos_Referidos_Especialista);
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



        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Suscripciones_Codigos_Referidos_EspecialistaPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Suscripciones_Codigos_Referidos_Especialistas == null)
                result.MS_Suscripciones_Codigos_Referidos_Especialistas = new List<MS_Suscripciones_Codigos_Referidos_Especialista>();

            return Json(new
            {
                data = result.MS_Suscripciones_Codigos_Referidos_Especialistas.Select(m => new MS_Suscripciones_Codigos_Referidos_EspecialistaGridModel
                    {
                    Folio = m.Folio
                        ,Plan_de_SuscripcionNombre_del_Plan = CultureHelper.GetTraduction(m.Plan_de_Suscripcion_Planes_de_Suscripcion.Folio.ToString(), "Nombre_del_Plan") ?? (string)m.Plan_de_Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan

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
                _IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);

                MS_Suscripciones_Codigos_Referidos_Especialista varMS_Suscripciones_Codigos_Referidos_Especialista = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, MS_Suscripciones_Codigos_Referidos_EspecialistaModel varMS_Suscripciones_Codigos_Referidos_Especialista)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var MS_Suscripciones_Codigos_Referidos_EspecialistaInfo = new MS_Suscripciones_Codigos_Referidos_Especialista
                    {
                        Folio = varMS_Suscripciones_Codigos_Referidos_Especialista.Folio
                        ,Plan_de_Suscripcion = varMS_Suscripciones_Codigos_Referidos_Especialista.Plan_de_Suscripcion

                    };

                    result = !IsNew ?
                        _IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer.Update(MS_Suscripciones_Codigos_Referidos_EspecialistaInfo, null, null).Resource.ToString() :
                         _IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer.Insert(MS_Suscripciones_Codigos_Referidos_EspecialistaInfo, null, null).Resource.ToString();

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
        /// Write Element Array of MS_Suscripciones_Codigos_Referidos_Especialista script
        /// </summary>
        /// <param name="oMS_Suscripciones_Codigos_Referidos_EspecialistaElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements MS_Suscripciones_Codigos_Referidos_EspecialistaModuleAttributeList)
        {
            for (int i = 0; i < MS_Suscripciones_Codigos_Referidos_EspecialistaModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(MS_Suscripciones_Codigos_Referidos_EspecialistaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    MS_Suscripciones_Codigos_Referidos_EspecialistaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(MS_Suscripciones_Codigos_Referidos_EspecialistaModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    MS_Suscripciones_Codigos_Referidos_EspecialistaModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (MS_Suscripciones_Codigos_Referidos_EspecialistaModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < MS_Suscripciones_Codigos_Referidos_EspecialistaModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(MS_Suscripciones_Codigos_Referidos_EspecialistaModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						MS_Suscripciones_Codigos_Referidos_EspecialistaModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(MS_Suscripciones_Codigos_Referidos_EspecialistaModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						MS_Suscripciones_Codigos_Referidos_EspecialistaModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strMS_Suscripciones_Codigos_Referidos_EspecialistaScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Suscripciones_Codigos_Referidos_Especialista.js")))
            {
                strMS_Suscripciones_Codigos_Referidos_EspecialistaScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change MS_Suscripciones_Codigos_Referidos_Especialista element attributes
            string userChangeJson = jsSerialize.Serialize(MS_Suscripciones_Codigos_Referidos_EspecialistaModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strMS_Suscripciones_Codigos_Referidos_EspecialistaScript.IndexOf("inpuElementArray");
            string splittedString = strMS_Suscripciones_Codigos_Referidos_EspecialistaScript.Substring(indexOfArray, strMS_Suscripciones_Codigos_Referidos_EspecialistaScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(MS_Suscripciones_Codigos_Referidos_EspecialistaModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (MS_Suscripciones_Codigos_Referidos_EspecialistaModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strMS_Suscripciones_Codigos_Referidos_EspecialistaScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strMS_Suscripciones_Codigos_Referidos_EspecialistaScript.Substring(indexOfArrayHistory, strMS_Suscripciones_Codigos_Referidos_EspecialistaScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strMS_Suscripciones_Codigos_Referidos_EspecialistaScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strMS_Suscripciones_Codigos_Referidos_EspecialistaScript.Substring(endIndexOfMainElement + indexOfArray, strMS_Suscripciones_Codigos_Referidos_EspecialistaScript.Length - (endIndexOfMainElement + indexOfArray));
            if (MS_Suscripciones_Codigos_Referidos_EspecialistaModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strMS_Suscripciones_Codigos_Referidos_EspecialistaScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strMS_Suscripciones_Codigos_Referidos_EspecialistaScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strMS_Suscripciones_Codigos_Referidos_EspecialistaScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strMS_Suscripciones_Codigos_Referidos_EspecialistaScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/MS_Suscripciones_Codigos_Referidos_Especialista.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/MS_Suscripciones_Codigos_Referidos_Especialista.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Suscripciones_Codigos_Referidos_Especialista.js")))
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
        public ActionResult MS_Suscripciones_Codigos_Referidos_EspecialistaPropertyBag()
        {
            return PartialView("MS_Suscripciones_Codigos_Referidos_EspecialistaPropertyBag", "MS_Suscripciones_Codigos_Referidos_Especialista");
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

            _IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Suscripciones_Codigos_Referidos_EspecialistaPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Suscripciones_Codigos_Referidos_Especialistas == null)
                result.MS_Suscripciones_Codigos_Referidos_Especialistas = new List<MS_Suscripciones_Codigos_Referidos_Especialista>();

            var data = result.MS_Suscripciones_Codigos_Referidos_Especialistas.Select(m => new MS_Suscripciones_Codigos_Referidos_EspecialistaGridModel
            {
                Folio = m.Folio
                ,Plan_de_SuscripcionNombre_del_Plan = (string)m.Plan_de_Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "MS_Suscripciones_Codigos_Referidos_EspecialistaList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "MS_Suscripciones_Codigos_Referidos_EspecialistaList_" + DateTime.Now.ToString());
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

            _IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Suscripciones_Codigos_Referidos_EspecialistaPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Suscripciones_Codigos_Referidos_EspecialistaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Suscripciones_Codigos_Referidos_Especialistas == null)
                result.MS_Suscripciones_Codigos_Referidos_Especialistas = new List<MS_Suscripciones_Codigos_Referidos_Especialista>();

            var data = result.MS_Suscripciones_Codigos_Referidos_Especialistas.Select(m => new MS_Suscripciones_Codigos_Referidos_EspecialistaGridModel
            {
                Folio = m.Folio
                ,Plan_de_SuscripcionNombre_del_Plan = (string)m.Plan_de_Suscripcion_Planes_de_Suscripcion.Nombre_del_Plan

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
