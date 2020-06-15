using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.MS_Musculos;
using Spartane.Core.Domain.Musculos;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.MS_Musculos;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.MS_Musculos;
using Spartane.Web.Areas.WebApiConsumer.Musculos;

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
    public class MS_MusculosController : Controller
    {
        #region "variable declaration"

        private IMS_MusculosService service = null;
        private IMS_MusculosApiConsumer _IMS_MusculosApiConsumer;
        private IMusculosApiConsumer _IMusculosApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public MS_MusculosController(IMS_MusculosService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IMS_MusculosApiConsumer MS_MusculosApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IMusculosApiConsumer MusculosApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IMS_MusculosApiConsumer = MS_MusculosApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IMusculosApiConsumer = MusculosApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/MS_Musculos
        [ObjectAuth(ObjectId = (ModuleObjectId)44578, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44578);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/MS_Musculos/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44578, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44578);
            ViewBag.Permission = permission;
            var varMS_Musculos = new MS_MusculosModel();
			
            ViewBag.ObjectId = "44578";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMS_MusculosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var MS_MusculosData = _IMS_MusculosApiConsumer.GetByKeyComplete(Id).Resource.MS_Musculoss[0];
                if (MS_MusculosData == null)
                    return HttpNotFound();

                varMS_Musculos = new MS_MusculosModel
                {
                    Folio = (int)MS_MusculosData.Folio
                    ,Musculo = MS_MusculosData.Musculo
                    ,MusculoDescripcion = CultureHelper.GetTraduction(Convert.ToString(MS_MusculosData.Musculo), "Musculos") ??  (string)MS_MusculosData.Musculo_Musculos.Descripcion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

	    _IMusculosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Musculoss_Musculo = _IMusculosApiConsumer.SelAll(true);
            if (Musculoss_Musculo != null && Musculoss_Musculo.Resource != null)
                ViewBag.Musculoss_Musculo = Musculoss_Musculo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Musculos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varMS_Musculos);
        }
		
	[HttpGet]
        public ActionResult AddMS_Musculos(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44578);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IMS_MusculosApiConsumer.SetAuthHeader(_tokenManager.Token);
			MS_MusculosModel varMS_Musculos= new MS_MusculosModel();


            if (id.ToString() != "0")
            {
                var MS_MusculossData = _IMS_MusculosApiConsumer.ListaSelAll(0, 1000, "MS_Musculos.Folio=" + id, "").Resource.MS_Musculoss;
				
				if (MS_MusculossData != null && MS_MusculossData.Count > 0)
                {
					var MS_MusculosData = MS_MusculossData.First();
					varMS_Musculos= new MS_MusculosModel
					{
						Folio  = MS_MusculosData.Folio 
	                    ,Musculo = MS_MusculosData.Musculo
                    ,MusculoDescripcion = CultureHelper.GetTraduction(Convert.ToString(MS_MusculosData.Musculo), "Musculos") ??  (string)MS_MusculosData.Musculo_Musculos.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

	    _IMusculosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Musculoss_Musculo = _IMusculosApiConsumer.SelAll(true);
            if (Musculoss_Musculo != null && Musculoss_Musculo.Resource != null)
                ViewBag.Musculoss_Musculo = Musculoss_Musculo.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Musculos", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddMS_Musculos", varMS_Musculos);
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
        public ActionResult GetMusculosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMusculosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IMusculosApiConsumer.SelAll(false).Resource;
				
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Musculos", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_MusculosPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IMS_MusculosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Musculoss == null)
                result.MS_Musculoss = new List<MS_Musculos>();

            return Json(new
            {
                data = result.MS_Musculoss.Select(m => new MS_MusculosGridModel
                    {
                    Folio = m.Folio
                        ,MusculoDescripcion = CultureHelper.GetTraduction(m.Musculo_Musculos.Folio.ToString(), "Musculos") ?? (string)m.Musculo_Musculos.Descripcion

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetMS_Musculos_Musculo_Musculos(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMusculosApiConsumer.SetAuthHeader(_tokenManager.Token);

				var elWhere = " (cast(Musculos.Folio as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Musculos.Descripcion as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where;
				elWhere = HttpUtility.UrlEncode(elWhere);
				var result = _IMusculosApiConsumer.ListaSelAll(1, 20,elWhere , " Musculos.Descripcion ASC ").Resource;
               
                foreach (var item in result.Musculoss)
                {
                    var trans =  CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Musculos", "Descripcion");
                    item.Descripcion =trans ??item.Descripcion;
                }
                return Json(result.Musculoss.ToArray(), JsonRequestBehavior.AllowGet);
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
                _IMS_MusculosApiConsumer.SetAuthHeader(_tokenManager.Token);

                MS_Musculos varMS_Musculos = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IMS_MusculosApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, MS_MusculosModel varMS_Musculos)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IMS_MusculosApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var MS_MusculosInfo = new MS_Musculos
                    {
                        Folio = varMS_Musculos.Folio
                        ,Musculo = varMS_Musculos.Musculo

                    };

                    result = !IsNew ?
                        _IMS_MusculosApiConsumer.Update(MS_MusculosInfo, null, null).Resource.ToString() :
                         _IMS_MusculosApiConsumer.Insert(MS_MusculosInfo, null, null).Resource.ToString();

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
        /// Write Element Array of MS_Musculos script
        /// </summary>
        /// <param name="oMS_MusculosElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements MS_MusculosModuleAttributeList)
        {
            for (int i = 0; i < MS_MusculosModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(MS_MusculosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    MS_MusculosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(MS_MusculosModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    MS_MusculosModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (MS_MusculosModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < MS_MusculosModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(MS_MusculosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						MS_MusculosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(MS_MusculosModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						MS_MusculosModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strMS_MusculosScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Musculos.js")))
            {
                strMS_MusculosScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change MS_Musculos element attributes
            string userChangeJson = jsSerialize.Serialize(MS_MusculosModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strMS_MusculosScript.IndexOf("inpuElementArray");
            string splittedString = strMS_MusculosScript.Substring(indexOfArray, strMS_MusculosScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(MS_MusculosModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (MS_MusculosModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strMS_MusculosScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strMS_MusculosScript.Substring(indexOfArrayHistory, strMS_MusculosScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strMS_MusculosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strMS_MusculosScript.Substring(endIndexOfMainElement + indexOfArray, strMS_MusculosScript.Length - (endIndexOfMainElement + indexOfArray));
            if (MS_MusculosModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strMS_MusculosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strMS_MusculosScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strMS_MusculosScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strMS_MusculosScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/MS_Musculos.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/MS_Musculos.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Musculos.js")))
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
        public ActionResult MS_MusculosPropertyBag()
        {
            return PartialView("MS_MusculosPropertyBag", "MS_Musculos");
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

            _IMS_MusculosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_MusculosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_MusculosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Musculoss == null)
                result.MS_Musculoss = new List<MS_Musculos>();

            var data = result.MS_Musculoss.Select(m => new MS_MusculosGridModel
            {
                Folio = m.Folio
                ,MusculoDescripcion = (string)m.Musculo_Musculos.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "MS_MusculosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "MS_MusculosList_" + DateTime.Now.ToString());
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

            _IMS_MusculosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_MusculosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_MusculosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Musculoss == null)
                result.MS_Musculoss = new List<MS_Musculos>();

            var data = result.MS_Musculoss.Select(m => new MS_MusculosGridModel
            {
                Folio = m.Folio
                ,MusculoDescripcion = (string)m.Musculo_Musculos.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
