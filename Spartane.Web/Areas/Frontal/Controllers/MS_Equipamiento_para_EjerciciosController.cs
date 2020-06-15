using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.MS_Equipamiento_para_Ejercicios;
using Spartane.Core.Domain.Equipamiento_para_Ejercicios;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.MS_Equipamiento_para_Ejercicios;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.MS_Equipamiento_para_Ejercicios;
using Spartane.Web.Areas.WebApiConsumer.Equipamiento_para_Ejercicios;

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
    public class MS_Equipamiento_para_EjerciciosController : Controller
    {
        #region "variable declaration"

        private IMS_Equipamiento_para_EjerciciosService service = null;
        private IMS_Equipamiento_para_EjerciciosApiConsumer _IMS_Equipamiento_para_EjerciciosApiConsumer;
        private IEquipamiento_para_EjerciciosApiConsumer _IEquipamiento_para_EjerciciosApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public MS_Equipamiento_para_EjerciciosController(IMS_Equipamiento_para_EjerciciosService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IMS_Equipamiento_para_EjerciciosApiConsumer MS_Equipamiento_para_EjerciciosApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IEquipamiento_para_EjerciciosApiConsumer Equipamiento_para_EjerciciosApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IMS_Equipamiento_para_EjerciciosApiConsumer = MS_Equipamiento_para_EjerciciosApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IEquipamiento_para_EjerciciosApiConsumer = Equipamiento_para_EjerciciosApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/MS_Equipamiento_para_Ejercicios
        [ObjectAuth(ObjectId = (ModuleObjectId)44579, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44579);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/MS_Equipamiento_para_Ejercicios/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44579, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44579);
            ViewBag.Permission = permission;
            var varMS_Equipamiento_para_Ejercicios = new MS_Equipamiento_para_EjerciciosModel();
			
            ViewBag.ObjectId = "44579";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMS_Equipamiento_para_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var MS_Equipamiento_para_EjerciciosData = _IMS_Equipamiento_para_EjerciciosApiConsumer.GetByKeyComplete(Id).Resource.MS_Equipamiento_para_Ejercicioss[0];
                if (MS_Equipamiento_para_EjerciciosData == null)
                    return HttpNotFound();

                varMS_Equipamiento_para_Ejercicios = new MS_Equipamiento_para_EjerciciosModel
                {
                    Folio = (int)MS_Equipamiento_para_EjerciciosData.Folio
                    ,Equipamento = MS_Equipamiento_para_EjerciciosData.Equipamento
                    ,EquipamentoDescripcion = CultureHelper.GetTraduction(Convert.ToString(MS_Equipamiento_para_EjerciciosData.Equipamento), "Equipamiento_para_Ejercicios") ??  (string)MS_Equipamiento_para_EjerciciosData.Equipamento_Equipamiento_para_Ejercicios.Descripcion

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IEquipamiento_para_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Equipamiento_para_Ejercicioss_Equipamento = _IEquipamiento_para_EjerciciosApiConsumer.SelAll(true);
            if (Equipamiento_para_Ejercicioss_Equipamento != null && Equipamiento_para_Ejercicioss_Equipamento.Resource != null)
                ViewBag.Equipamiento_para_Ejercicioss_Equipamento = Equipamiento_para_Ejercicioss_Equipamento.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Equipamiento_para_Ejercicios", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varMS_Equipamiento_para_Ejercicios);
        }
		
	[HttpGet]
        public ActionResult AddMS_Equipamiento_para_Ejercicios(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44579);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IMS_Equipamiento_para_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
			MS_Equipamiento_para_EjerciciosModel varMS_Equipamiento_para_Ejercicios= new MS_Equipamiento_para_EjerciciosModel();


            if (id.ToString() != "0")
            {
                var MS_Equipamiento_para_EjerciciossData = _IMS_Equipamiento_para_EjerciciosApiConsumer.ListaSelAll(0, 1000, "MS_Equipamiento_para_Ejercicios.Folio=" + id, "").Resource.MS_Equipamiento_para_Ejercicioss;
				
				if (MS_Equipamiento_para_EjerciciossData != null && MS_Equipamiento_para_EjerciciossData.Count > 0)
                {
					var MS_Equipamiento_para_EjerciciosData = MS_Equipamiento_para_EjerciciossData.First();
					varMS_Equipamiento_para_Ejercicios= new MS_Equipamiento_para_EjerciciosModel
					{
						Folio  = MS_Equipamiento_para_EjerciciosData.Folio 
	                    ,Equipamento = MS_Equipamiento_para_EjerciciosData.Equipamento
                    ,EquipamentoDescripcion = CultureHelper.GetTraduction(Convert.ToString(MS_Equipamiento_para_EjerciciosData.Equipamento), "Equipamiento_para_Ejercicios") ??  (string)MS_Equipamiento_para_EjerciciosData.Equipamento_Equipamiento_para_Ejercicios.Descripcion

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IEquipamiento_para_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Equipamiento_para_Ejercicioss_Equipamento = _IEquipamiento_para_EjerciciosApiConsumer.SelAll(true);
            if (Equipamiento_para_Ejercicioss_Equipamento != null && Equipamiento_para_Ejercicioss_Equipamento.Resource != null)
                ViewBag.Equipamiento_para_Ejercicioss_Equipamento = Equipamiento_para_Ejercicioss_Equipamento.Resource.Where(m => m.Descripcion != null).OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Equipamiento_para_Ejercicios", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddMS_Equipamiento_para_Ejercicios", varMS_Equipamiento_para_Ejercicios);
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
        public ActionResult GetEquipamiento_para_EjerciciosAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEquipamiento_para_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEquipamiento_para_EjerciciosApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Equipamiento_para_Ejercicios", "Descripcion")?? m.Descripcion,
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
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Equipamiento_para_EjerciciosPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IMS_Equipamiento_para_EjerciciosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Equipamiento_para_Ejercicioss == null)
                result.MS_Equipamiento_para_Ejercicioss = new List<MS_Equipamiento_para_Ejercicios>();

            return Json(new
            {
                data = result.MS_Equipamiento_para_Ejercicioss.Select(m => new MS_Equipamiento_para_EjerciciosGridModel
                    {
                    Folio = m.Folio
                        ,EquipamentoDescripcion = CultureHelper.GetTraduction(m.Equipamento_Equipamiento_para_Ejercicios.Folio.ToString(), "Descripcion") ?? (string)m.Equipamento_Equipamiento_para_Ejercicios.Descripcion

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
                _IMS_Equipamiento_para_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);

                MS_Equipamiento_para_Ejercicios varMS_Equipamiento_para_Ejercicios = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IMS_Equipamiento_para_EjerciciosApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, MS_Equipamiento_para_EjerciciosModel varMS_Equipamiento_para_Ejercicios)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IMS_Equipamiento_para_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var MS_Equipamiento_para_EjerciciosInfo = new MS_Equipamiento_para_Ejercicios
                    {
                        Folio = varMS_Equipamiento_para_Ejercicios.Folio
                        ,Equipamento = varMS_Equipamiento_para_Ejercicios.Equipamento

                    };

                    result = !IsNew ?
                        _IMS_Equipamiento_para_EjerciciosApiConsumer.Update(MS_Equipamiento_para_EjerciciosInfo, null, null).Resource.ToString() :
                         _IMS_Equipamiento_para_EjerciciosApiConsumer.Insert(MS_Equipamiento_para_EjerciciosInfo, null, null).Resource.ToString();

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
        /// Write Element Array of MS_Equipamiento_para_Ejercicios script
        /// </summary>
        /// <param name="oMS_Equipamiento_para_EjerciciosElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements MS_Equipamiento_para_EjerciciosModuleAttributeList)
        {
            for (int i = 0; i < MS_Equipamiento_para_EjerciciosModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(MS_Equipamiento_para_EjerciciosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    MS_Equipamiento_para_EjerciciosModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(MS_Equipamiento_para_EjerciciosModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    MS_Equipamiento_para_EjerciciosModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (MS_Equipamiento_para_EjerciciosModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < MS_Equipamiento_para_EjerciciosModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(MS_Equipamiento_para_EjerciciosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						MS_Equipamiento_para_EjerciciosModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(MS_Equipamiento_para_EjerciciosModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						MS_Equipamiento_para_EjerciciosModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strMS_Equipamiento_para_EjerciciosScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Equipamiento_para_Ejercicios.js")))
            {
                strMS_Equipamiento_para_EjerciciosScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change MS_Equipamiento_para_Ejercicios element attributes
            string userChangeJson = jsSerialize.Serialize(MS_Equipamiento_para_EjerciciosModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strMS_Equipamiento_para_EjerciciosScript.IndexOf("inpuElementArray");
            string splittedString = strMS_Equipamiento_para_EjerciciosScript.Substring(indexOfArray, strMS_Equipamiento_para_EjerciciosScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(MS_Equipamiento_para_EjerciciosModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (MS_Equipamiento_para_EjerciciosModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strMS_Equipamiento_para_EjerciciosScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strMS_Equipamiento_para_EjerciciosScript.Substring(indexOfArrayHistory, strMS_Equipamiento_para_EjerciciosScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strMS_Equipamiento_para_EjerciciosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strMS_Equipamiento_para_EjerciciosScript.Substring(endIndexOfMainElement + indexOfArray, strMS_Equipamiento_para_EjerciciosScript.Length - (endIndexOfMainElement + indexOfArray));
            if (MS_Equipamiento_para_EjerciciosModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strMS_Equipamiento_para_EjerciciosScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strMS_Equipamiento_para_EjerciciosScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strMS_Equipamiento_para_EjerciciosScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strMS_Equipamiento_para_EjerciciosScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/MS_Equipamiento_para_Ejercicios.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/MS_Equipamiento_para_Ejercicios.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Equipamiento_para_Ejercicios.js")))
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
        public ActionResult MS_Equipamiento_para_EjerciciosPropertyBag()
        {
            return PartialView("MS_Equipamiento_para_EjerciciosPropertyBag", "MS_Equipamiento_para_Ejercicios");
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

            _IMS_Equipamiento_para_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Equipamiento_para_EjerciciosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Equipamiento_para_EjerciciosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Equipamiento_para_Ejercicioss == null)
                result.MS_Equipamiento_para_Ejercicioss = new List<MS_Equipamiento_para_Ejercicios>();

            var data = result.MS_Equipamiento_para_Ejercicioss.Select(m => new MS_Equipamiento_para_EjerciciosGridModel
            {
                Folio = m.Folio
                ,EquipamentoDescripcion = (string)m.Equipamento_Equipamiento_para_Ejercicios.Descripcion

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "MS_Equipamiento_para_EjerciciosList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "MS_Equipamiento_para_EjerciciosList_" + DateTime.Now.ToString());
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

            _IMS_Equipamiento_para_EjerciciosApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Equipamiento_para_EjerciciosPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Equipamiento_para_EjerciciosApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Equipamiento_para_Ejercicioss == null)
                result.MS_Equipamiento_para_Ejercicioss = new List<MS_Equipamiento_para_Ejercicios>();

            var data = result.MS_Equipamiento_para_Ejercicioss.Select(m => new MS_Equipamiento_para_EjerciciosGridModel
            {
                Folio = m.Folio
                ,EquipamentoDescripcion = (string)m.Equipamento_Equipamiento_para_Ejercicios.Descripcion

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
