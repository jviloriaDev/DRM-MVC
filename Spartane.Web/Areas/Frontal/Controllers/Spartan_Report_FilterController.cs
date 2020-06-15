using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_Report_Filter;
using Spartane.Core.Domain.Spartan_Metadata;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Filter;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;

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
    public class Spartan_Report_FilterController : Controller
    {
        #region "variable declaration"

        private ISpartan_Report_FilterApiConsumer _ISpartan_Report_FilterApiConsumer;
        private ISpartan_MetadataApiConsumer _ISpartan_MetadataApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Spartan_Report_FilterController(ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_Report_FilterApiConsumer Spartan_Report_FilterApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ISpartan_MetadataApiConsumer Spartan_MetadataApiConsumer )
        {
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_Report_FilterApiConsumer = Spartan_Report_FilterApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_MetadataApiConsumer = Spartan_MetadataApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_Report_Filter
        [ObjectAuth(ObjectId = (ModuleObjectId)34558, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 34558);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Spartan_Report_Filter/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)34558, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 34558);
            ViewBag.Permission = permission;
            var varSpartan_Report_Filter = new Spartan_Report_FilterModel();
			
            ViewBag.ObjectId = "34558";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_Report_FilterData = _ISpartan_Report_FilterApiConsumer.GetByKeyComplete(Id).Resource.Spartan_Report_Filters[0];
                if (Spartan_Report_FilterData == null)
                    return HttpNotFound();

                varSpartan_Report_Filter = new Spartan_Report_FilterModel
                {
                    ReportFilterId = (int)Spartan_Report_FilterData.ReportFilterId
                    ,Field = Spartan_Report_FilterData.Field
                    ,FieldLogical_Name =  (string)Spartan_Report_FilterData.Field_Spartan_Metadata.Logical_Name
                    ,QuickFilter = Spartan_Report_FilterData.QuickFilter.GetValueOrDefault()
                    ,AdvanceFilter = Spartan_Report_FilterData.AdvanceFilter.GetValueOrDefault()

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Metadatas_Field = _ISpartan_MetadataApiConsumer.SelAll(true);
            if (Spartan_Metadatas_Field != null && Spartan_Metadatas_Field.Resource != null)
                ViewBag.Spartan_Metadatas_Field = Spartan_Metadatas_Field.Resource.OrderBy(m => m.Logical_Name).Select(m => new SelectListItem
                {
                    Text = m.Logical_Name.ToString(), Value = Convert.ToString(m.AttributeId)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_Report_Filter);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_Report_Filter(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 34558);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_Report_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_Report_FilterModel varSpartan_Report_Filter= new Spartan_Report_FilterModel();


            if (id.ToString() != "0")
            {
                var Spartan_Report_FiltersData = _ISpartan_Report_FilterApiConsumer.ListaSelAll(0, 1000, "Spartan_Report_Filter.ReportFilterId=" + id, "").Resource.Spartan_Report_Filters;
				
				if (Spartan_Report_FiltersData != null && Spartan_Report_FiltersData.Count > 0)
                {
					var Spartan_Report_FilterData = Spartan_Report_FiltersData.First();
					varSpartan_Report_Filter= new Spartan_Report_FilterModel
					{
						ReportFilterId  = Spartan_Report_FilterData.ReportFilterId 
	                    ,Field = Spartan_Report_FilterData.Field
                    ,FieldLogical_Name =  (string)Spartan_Report_FilterData.Field_Spartan_Metadata.Logical_Name
                    ,QuickFilter = Spartan_Report_FilterData.QuickFilter.GetValueOrDefault()
                    ,AdvanceFilter = Spartan_Report_FilterData.AdvanceFilter.GetValueOrDefault()

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Metadatas_Field = _ISpartan_MetadataApiConsumer.SelAll(true);
            if (Spartan_Metadatas_Field != null && Spartan_Metadatas_Field.Resource != null)
                ViewBag.Spartan_Metadatas_Field = Spartan_Metadatas_Field.Resource.OrderBy(m => m.Logical_Name).Select(m => new SelectListItem
                {
                    Text = m.Logical_Name.ToString(), Value = Convert.ToString(m.AttributeId)
                }).ToList();


            return PartialView("AddSpartan_Report_Filter", varSpartan_Report_Filter);
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
        public ActionResult GetSpartan_MetadataAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_MetadataApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Report_FilterPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_Report_FilterApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Report_Filters == null)
                result.Spartan_Report_Filters = new List<Spartan_Report_Filter>();

            return Json(new
            {
                data = result.Spartan_Report_Filters.Select(m => new Spartan_Report_FilterGridModel
                    {
                    ReportFilterId = m.ReportFilterId
                        ,FieldLogical_Name = (string)m.Field_Spartan_Metadata.Logical_Name
			,QuickFilter = m.QuickFilter
			,AdvanceFilter = m.AdvanceFilter

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
                _ISpartan_Report_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);

                Spartan_Report_Filter varSpartan_Report_Filter = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _ISpartan_Report_FilterApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_Report_FilterModel varSpartan_Report_Filter)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_Report_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Spartan_Report_FilterInfo = new Spartan_Report_Filter
                    {
                        ReportFilterId = varSpartan_Report_Filter.ReportFilterId
                        ,Field = varSpartan_Report_Filter.Field
                        ,QuickFilter = varSpartan_Report_Filter.QuickFilter
                        ,AdvanceFilter = varSpartan_Report_Filter.AdvanceFilter

                    };

                    result = !IsNew ?
                        _ISpartan_Report_FilterApiConsumer.Update(Spartan_Report_FilterInfo, null, null).Resource.ToString() :
                         _ISpartan_Report_FilterApiConsumer.Insert(Spartan_Report_FilterInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Spartan_Report_Filter script
        /// </summary>
        /// <param name="oSpartan_Report_FilterElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_Report_FilterModuleAttributeList)
        {
            for (int i = 0; i < Spartan_Report_FilterModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_Report_FilterModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_Report_FilterModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_Report_FilterModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_Report_FilterModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_Report_FilterModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_Report_FilterModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Spartan_Report_FilterModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Spartan_Report_FilterModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Spartan_Report_FilterModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Spartan_Report_FilterModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strSpartan_Report_FilterScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Report_Filter.js")))
            {
                strSpartan_Report_FilterScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_Report_Filter element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_Report_FilterModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_Report_FilterScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_Report_FilterScript.Substring(indexOfArray, strSpartan_Report_FilterScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_Report_FilterModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_Report_FilterModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_Report_FilterScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strSpartan_Report_FilterScript.Substring(indexOfArrayHistory, strSpartan_Report_FilterScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strSpartan_Report_FilterScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_Report_FilterScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_Report_FilterScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Spartan_Report_FilterModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strSpartan_Report_FilterScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_Report_FilterScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_Report_FilterScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_Report_FilterScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_Report_Filter.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_Report_Filter.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Report_Filter.js")))
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
        public ActionResult Spartan_Report_FilterPropertyBag()
        {
            return PartialView("Spartan_Report_FilterPropertyBag", "Spartan_Report_Filter");
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

            _ISpartan_Report_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Report_FilterPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Report_FilterApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Report_Filters == null)
                result.Spartan_Report_Filters = new List<Spartan_Report_Filter>();

            var data = result.Spartan_Report_Filters.Select(m => new Spartan_Report_FilterGridModel
            {
                ReportFilterId = m.ReportFilterId
                ,QuickFilter = m.QuickFilter
                ,AdvanceFilter = m.AdvanceFilter

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_Report_FilterList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_Report_FilterList_" + DateTime.Now.ToString());
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

            _ISpartan_Report_FilterApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Report_FilterPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Report_FilterApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Report_Filters == null)
                result.Spartan_Report_Filters = new List<Spartan_Report_Filter>();

            var data = result.Spartan_Report_Filters.Select(m => new Spartan_Report_FilterGridModel
            {
                ReportFilterId = m.ReportFilterId
                ,QuickFilter = m.QuickFilter
                ,AdvanceFilter = m.AdvanceFilter

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
