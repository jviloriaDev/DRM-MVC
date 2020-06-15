using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.MS_Exclusion_Ingredientes_Paciente;
using Spartane.Core.Domain.Ingredientes;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.MS_Exclusion_Ingredientes_Paciente;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.MS_Exclusion_Ingredientes_Paciente;
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
    public class MS_Exclusion_Ingredientes_PacienteController : Controller
    {
        #region "variable declaration"

        private IMS_Exclusion_Ingredientes_PacienteService service = null;
        private IMS_Exclusion_Ingredientes_PacienteApiConsumer _IMS_Exclusion_Ingredientes_PacienteApiConsumer;
        private IIngredientesApiConsumer _IIngredientesApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public MS_Exclusion_Ingredientes_PacienteController(IMS_Exclusion_Ingredientes_PacienteService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IMS_Exclusion_Ingredientes_PacienteApiConsumer MS_Exclusion_Ingredientes_PacienteApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IIngredientesApiConsumer IngredientesApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IMS_Exclusion_Ingredientes_PacienteApiConsumer = MS_Exclusion_Ingredientes_PacienteApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IIngredientesApiConsumer = IngredientesApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/MS_Exclusion_Ingredientes_Paciente
        [ObjectAuth(ObjectId = (ModuleObjectId)44445, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44445);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/MS_Exclusion_Ingredientes_Paciente/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)44445, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44445);
            ViewBag.Permission = permission;
            var varMS_Exclusion_Ingredientes_Paciente = new MS_Exclusion_Ingredientes_PacienteModel();
			
            ViewBag.ObjectId = "44445";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IMS_Exclusion_Ingredientes_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var MS_Exclusion_Ingredientes_PacienteData = _IMS_Exclusion_Ingredientes_PacienteApiConsumer.GetByKeyComplete(Id).Resource.MS_Exclusion_Ingredientes_Pacientes[0];
                if (MS_Exclusion_Ingredientes_PacienteData == null)
                    return HttpNotFound();

                varMS_Exclusion_Ingredientes_Paciente = new MS_Exclusion_Ingredientes_PacienteModel
                {
                    Folio = (int)MS_Exclusion_Ingredientes_PacienteData.Folio
                    ,Ingrediente = MS_Exclusion_Ingredientes_PacienteData.Ingrediente
                    ,IngredienteNombre_Ingrediente = CultureHelper.GetTraduction(Convert.ToString(MS_Exclusion_Ingredientes_PacienteData.Ingrediente), "Ingredientes") ??  (string)MS_Exclusion_Ingredientes_PacienteData.Ingrediente_Ingredientes.Nombre_Ingrediente

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

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
            return View(varMS_Exclusion_Ingredientes_Paciente);
        }
		
	[HttpGet]
        public ActionResult AddMS_Exclusion_Ingredientes_Paciente(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 44445);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IMS_Exclusion_Ingredientes_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);
			MS_Exclusion_Ingredientes_PacienteModel varMS_Exclusion_Ingredientes_Paciente= new MS_Exclusion_Ingredientes_PacienteModel();


            if (id.ToString() != "0")
            {
                var MS_Exclusion_Ingredientes_PacientesData = _IMS_Exclusion_Ingredientes_PacienteApiConsumer.ListaSelAll(0, 1000, "MS_Exclusion_Ingredientes_Paciente.Folio=" + id, "").Resource.MS_Exclusion_Ingredientes_Pacientes;
				
				if (MS_Exclusion_Ingredientes_PacientesData != null && MS_Exclusion_Ingredientes_PacientesData.Count > 0)
                {
					var MS_Exclusion_Ingredientes_PacienteData = MS_Exclusion_Ingredientes_PacientesData.First();
					varMS_Exclusion_Ingredientes_Paciente= new MS_Exclusion_Ingredientes_PacienteModel
					{
						Folio  = MS_Exclusion_Ingredientes_PacienteData.Folio 
	                    ,Ingrediente = MS_Exclusion_Ingredientes_PacienteData.Ingrediente
                    ,IngredienteNombre_Ingrediente = CultureHelper.GetTraduction(Convert.ToString(MS_Exclusion_Ingredientes_PacienteData.Ingrediente), "Ingredientes") ??  (string)MS_Exclusion_Ingredientes_PacienteData.Ingrediente_Ingredientes.Nombre_Ingrediente

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IIngredientesApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Ingredientess_Ingrediente = _IIngredientesApiConsumer.SelAll(true);
            if (Ingredientess_Ingrediente != null && Ingredientess_Ingrediente.Resource != null)
                ViewBag.Ingredientess_Ingrediente = Ingredientess_Ingrediente.Resource.Where(m => m.Nombre_Ingrediente != null).OrderBy(m => m.Nombre_Ingrediente).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Ingredientes", "Nombre_Ingrediente") ?? m.Nombre_Ingrediente.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddMS_Exclusion_Ingredientes_Paciente", varMS_Exclusion_Ingredientes_Paciente);
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
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Exclusion_Ingredientes_PacientePropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IMS_Exclusion_Ingredientes_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Exclusion_Ingredientes_Pacientes == null)
                result.MS_Exclusion_Ingredientes_Pacientes = new List<MS_Exclusion_Ingredientes_Paciente>();

            return Json(new
            {
                data = result.MS_Exclusion_Ingredientes_Pacientes.Select(m => new MS_Exclusion_Ingredientes_PacienteGridModel
                    {
                    Folio = m.Folio
                        ,IngredienteNombre_Ingrediente = CultureHelper.GetTraduction(m.Ingrediente_Ingredientes.Clave.ToString(), "Nombre_Ingrediente") ?? (string)m.Ingrediente_Ingredientes.Nombre_Ingrediente

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
                _IMS_Exclusion_Ingredientes_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

                MS_Exclusion_Ingredientes_Paciente varMS_Exclusion_Ingredientes_Paciente = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IMS_Exclusion_Ingredientes_PacienteApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, MS_Exclusion_Ingredientes_PacienteModel varMS_Exclusion_Ingredientes_Paciente)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IMS_Exclusion_Ingredientes_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var MS_Exclusion_Ingredientes_PacienteInfo = new MS_Exclusion_Ingredientes_Paciente
                    {
                        Folio = varMS_Exclusion_Ingredientes_Paciente.Folio
                        ,Ingrediente = varMS_Exclusion_Ingredientes_Paciente.Ingrediente

                    };

                    result = !IsNew ?
                        _IMS_Exclusion_Ingredientes_PacienteApiConsumer.Update(MS_Exclusion_Ingredientes_PacienteInfo, null, null).Resource.ToString() :
                         _IMS_Exclusion_Ingredientes_PacienteApiConsumer.Insert(MS_Exclusion_Ingredientes_PacienteInfo, null, null).Resource.ToString();

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
        /// Write Element Array of MS_Exclusion_Ingredientes_Paciente script
        /// </summary>
        /// <param name="oMS_Exclusion_Ingredientes_PacienteElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements MS_Exclusion_Ingredientes_PacienteModuleAttributeList)
        {
            for (int i = 0; i < MS_Exclusion_Ingredientes_PacienteModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(MS_Exclusion_Ingredientes_PacienteModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    MS_Exclusion_Ingredientes_PacienteModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(MS_Exclusion_Ingredientes_PacienteModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    MS_Exclusion_Ingredientes_PacienteModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (MS_Exclusion_Ingredientes_PacienteModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < MS_Exclusion_Ingredientes_PacienteModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(MS_Exclusion_Ingredientes_PacienteModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						MS_Exclusion_Ingredientes_PacienteModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(MS_Exclusion_Ingredientes_PacienteModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						MS_Exclusion_Ingredientes_PacienteModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strMS_Exclusion_Ingredientes_PacienteScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Exclusion_Ingredientes_Paciente.js")))
            {
                strMS_Exclusion_Ingredientes_PacienteScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change MS_Exclusion_Ingredientes_Paciente element attributes
            string userChangeJson = jsSerialize.Serialize(MS_Exclusion_Ingredientes_PacienteModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strMS_Exclusion_Ingredientes_PacienteScript.IndexOf("inpuElementArray");
            string splittedString = strMS_Exclusion_Ingredientes_PacienteScript.Substring(indexOfArray, strMS_Exclusion_Ingredientes_PacienteScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(MS_Exclusion_Ingredientes_PacienteModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (MS_Exclusion_Ingredientes_PacienteModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strMS_Exclusion_Ingredientes_PacienteScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strMS_Exclusion_Ingredientes_PacienteScript.Substring(indexOfArrayHistory, strMS_Exclusion_Ingredientes_PacienteScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strMS_Exclusion_Ingredientes_PacienteScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strMS_Exclusion_Ingredientes_PacienteScript.Substring(endIndexOfMainElement + indexOfArray, strMS_Exclusion_Ingredientes_PacienteScript.Length - (endIndexOfMainElement + indexOfArray));
            if (MS_Exclusion_Ingredientes_PacienteModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strMS_Exclusion_Ingredientes_PacienteScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strMS_Exclusion_Ingredientes_PacienteScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strMS_Exclusion_Ingredientes_PacienteScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strMS_Exclusion_Ingredientes_PacienteScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/MS_Exclusion_Ingredientes_Paciente.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/MS_Exclusion_Ingredientes_Paciente.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/MS_Exclusion_Ingredientes_Paciente.js")))
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
        public ActionResult MS_Exclusion_Ingredientes_PacientePropertyBag()
        {
            return PartialView("MS_Exclusion_Ingredientes_PacientePropertyBag", "MS_Exclusion_Ingredientes_Paciente");
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

            _IMS_Exclusion_Ingredientes_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Exclusion_Ingredientes_PacientePropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Exclusion_Ingredientes_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Exclusion_Ingredientes_Pacientes == null)
                result.MS_Exclusion_Ingredientes_Pacientes = new List<MS_Exclusion_Ingredientes_Paciente>();

            var data = result.MS_Exclusion_Ingredientes_Pacientes.Select(m => new MS_Exclusion_Ingredientes_PacienteGridModel
            {
                Folio = m.Folio
                ,IngredienteNombre_Ingrediente = (string)m.Ingrediente_Ingredientes.Nombre_Ingrediente

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "MS_Exclusion_Ingredientes_PacienteList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "MS_Exclusion_Ingredientes_PacienteList_" + DateTime.Now.ToString());
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

            _IMS_Exclusion_Ingredientes_PacienteApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new MS_Exclusion_Ingredientes_PacientePropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IMS_Exclusion_Ingredientes_PacienteApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.MS_Exclusion_Ingredientes_Pacientes == null)
                result.MS_Exclusion_Ingredientes_Pacientes = new List<MS_Exclusion_Ingredientes_Paciente>();

            var data = result.MS_Exclusion_Ingredientes_Pacientes.Select(m => new MS_Exclusion_Ingredientes_PacienteGridModel
            {
                Folio = m.Folio
                ,IngredienteNombre_Ingrediente = (string)m.Ingrediente_Ingredientes.Nombre_Ingrediente

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
