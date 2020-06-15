using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Template_Dashboard_Detail;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Template_Dashboard_Detail;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Template_Dashboard_Detail;

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
    public class Template_Dashboard_DetailController : Controller
    {
        #region "variable declaration"

        private ITemplate_Dashboard_DetailService service = null;
        private ITemplate_Dashboard_DetailApiConsumer _ITemplate_Dashboard_DetailApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Template_Dashboard_DetailController(ITemplate_Dashboard_DetailService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ITemplate_Dashboard_DetailApiConsumer Template_Dashboard_DetailApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ITemplate_Dashboard_DetailApiConsumer = Template_Dashboard_DetailApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Template_Dashboard_Detail
        [ObjectAuth(ObjectId = (ModuleObjectId)40189, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40189);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Template_Dashboard_Detail/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)40189, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40189);
            ViewBag.Permission = permission;
            var varTemplate_Dashboard_Detail = new Template_Dashboard_DetailModel();
			
            ViewBag.ObjectId = "40189";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITemplate_Dashboard_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Template_Dashboard_DetailData = _ITemplate_Dashboard_DetailApiConsumer.GetByKeyComplete(Id).Resource.Template_Dashboard_Details[0];
                if (Template_Dashboard_DetailData == null)
                    return HttpNotFound();

                varTemplate_Dashboard_Detail = new Template_Dashboard_DetailModel
                {
                    Detail_Id = (int)Template_Dashboard_DetailData.Detail_Id
                    ,Row_Number = Template_Dashboard_DetailData.Row_Number
                    ,Columns = Template_Dashboard_DetailData.Columns

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varTemplate_Dashboard_Detail);
        }
		
	[HttpGet]
        public ActionResult AddTemplate_Dashboard_Detail(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40189);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ITemplate_Dashboard_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
			Template_Dashboard_DetailModel varTemplate_Dashboard_Detail= new Template_Dashboard_DetailModel();


            if (id.ToString() != "0")
            {
                var Template_Dashboard_DetailsData = _ITemplate_Dashboard_DetailApiConsumer.ListaSelAll(0, 1000, "Template_Dashboard_Detail.Detail_Id=" + id, "").Resource.Template_Dashboard_Details;
				
				if (Template_Dashboard_DetailsData != null && Template_Dashboard_DetailsData.Count > 0)
                {
					var Template_Dashboard_DetailData = Template_Dashboard_DetailsData.First();
					varTemplate_Dashboard_Detail= new Template_Dashboard_DetailModel
					{
						Detail_Id  = Template_Dashboard_DetailData.Detail_Id 
	                    ,Row_Number = Template_Dashboard_DetailData.Row_Number
                    ,Columns = Template_Dashboard_DetailData.Columns

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            return PartialView("AddTemplate_Dashboard_Detail", varTemplate_Dashboard_Detail);
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




        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Template_Dashboard_DetailPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ITemplate_Dashboard_DetailApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Template_Dashboard_Details == null)
                result.Template_Dashboard_Details = new List<Template_Dashboard_Detail>();

            return Json(new
            {
                data = result.Template_Dashboard_Details.Select(m => new Template_Dashboard_DetailGridModel
                    {
                    Detail_Id = m.Detail_Id
			,Row_Number = m.Row_Number
			,Columns = m.Columns

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
                _ITemplate_Dashboard_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                Template_Dashboard_Detail varTemplate_Dashboard_Detail = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _ITemplate_Dashboard_DetailApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Template_Dashboard_DetailModel varTemplate_Dashboard_Detail)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ITemplate_Dashboard_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Template_Dashboard_DetailInfo = new Template_Dashboard_Detail
                    {
                        Detail_Id = varTemplate_Dashboard_Detail.Detail_Id
                        ,Row_Number = varTemplate_Dashboard_Detail.Row_Number
                        ,Columns = varTemplate_Dashboard_Detail.Columns

                    };

                    result = !IsNew ?
                        _ITemplate_Dashboard_DetailApiConsumer.Update(Template_Dashboard_DetailInfo, null, null).Resource.ToString() :
                         _ITemplate_Dashboard_DetailApiConsumer.Insert(Template_Dashboard_DetailInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Template_Dashboard_Detail script
        /// </summary>
        /// <param name="oTemplate_Dashboard_DetailElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Template_Dashboard_DetailModuleAttributeList)
        {
            for (int i = 0; i < Template_Dashboard_DetailModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Template_Dashboard_DetailModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Template_Dashboard_DetailModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Template_Dashboard_DetailModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Template_Dashboard_DetailModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Template_Dashboard_DetailModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Template_Dashboard_DetailModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Template_Dashboard_DetailModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Template_Dashboard_DetailModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Template_Dashboard_DetailModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Template_Dashboard_DetailModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strTemplate_Dashboard_DetailScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Template_Dashboard_Detail.js")))
            {
                strTemplate_Dashboard_DetailScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Template_Dashboard_Detail element attributes
            string userChangeJson = jsSerialize.Serialize(Template_Dashboard_DetailModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strTemplate_Dashboard_DetailScript.IndexOf("inpuElementArray");
            string splittedString = strTemplate_Dashboard_DetailScript.Substring(indexOfArray, strTemplate_Dashboard_DetailScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Template_Dashboard_DetailModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Template_Dashboard_DetailModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strTemplate_Dashboard_DetailScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strTemplate_Dashboard_DetailScript.Substring(indexOfArrayHistory, strTemplate_Dashboard_DetailScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strTemplate_Dashboard_DetailScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strTemplate_Dashboard_DetailScript.Substring(endIndexOfMainElement + indexOfArray, strTemplate_Dashboard_DetailScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Template_Dashboard_DetailModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strTemplate_Dashboard_DetailScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strTemplate_Dashboard_DetailScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strTemplate_Dashboard_DetailScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strTemplate_Dashboard_DetailScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Template_Dashboard_Detail.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Template_Dashboard_Detail.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Template_Dashboard_Detail.js")))
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
        public ActionResult Template_Dashboard_DetailPropertyBag()
        {
            return PartialView("Template_Dashboard_DetailPropertyBag", "Template_Dashboard_Detail");
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

            _ITemplate_Dashboard_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Template_Dashboard_DetailPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ITemplate_Dashboard_DetailApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Template_Dashboard_Details == null)
                result.Template_Dashboard_Details = new List<Template_Dashboard_Detail>();

            var data = result.Template_Dashboard_Details.Select(m => new Template_Dashboard_DetailGridModel
            {
                Detail_Id = m.Detail_Id
                ,Row_Number = m.Row_Number
                ,Columns = m.Columns

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Template_Dashboard_DetailList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Template_Dashboard_DetailList_" + DateTime.Now.ToString());
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

            _ITemplate_Dashboard_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Template_Dashboard_DetailPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ITemplate_Dashboard_DetailApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Template_Dashboard_Details == null)
                result.Template_Dashboard_Details = new List<Template_Dashboard_Detail>();

            var data = result.Template_Dashboard_Details.Select(m => new Template_Dashboard_DetailGridModel
            {
                Detail_Id = m.Detail_Id
                ,Row_Number = m.Row_Number
                ,Columns = m.Columns

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
