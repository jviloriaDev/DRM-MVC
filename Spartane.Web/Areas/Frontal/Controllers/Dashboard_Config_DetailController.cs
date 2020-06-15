using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Dashboard_Config_Detail;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Dashboard_Config_Detail;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Dashboard_Config_Detail;

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
    public class Dashboard_Config_DetailController : Controller
    {
        #region "variable declaration"

        private IDashboard_Config_DetailService service = null;
        private IDashboard_Config_DetailApiConsumer _IDashboard_Config_DetailApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Dashboard_Config_DetailController(IDashboard_Config_DetailService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDashboard_Config_DetailApiConsumer Dashboard_Config_DetailApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDashboard_Config_DetailApiConsumer = Dashboard_Config_DetailApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Dashboard_Config_Detail
        [ObjectAuth(ObjectId = (ModuleObjectId)40190, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40190);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Dashboard_Config_Detail/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)40190, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40190);
            ViewBag.Permission = permission;
            var varDashboard_Config_Detail = new Dashboard_Config_DetailModel();
			
            ViewBag.ObjectId = "40190";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDashboard_Config_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Dashboard_Config_DetailData = _IDashboard_Config_DetailApiConsumer.GetByKeyComplete(Id).Resource.Dashboard_Config_Details[0];
                if (Dashboard_Config_DetailData == null)
                    return HttpNotFound();

                varDashboard_Config_Detail = new Dashboard_Config_DetailModel
                {
                    Detail_Id = (int)Dashboard_Config_DetailData.Detail_Id
                    ,Report_Id = Dashboard_Config_DetailData.Report_Id
                    ,Report_Name = Dashboard_Config_DetailData.Report_Name
                    ,ConfigRow = Dashboard_Config_DetailData.ConfigRow
                    ,ConfigColumn = Dashboard_Config_DetailData.ConfigColumn

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDashboard_Config_Detail);
        }
		
	[HttpGet]
        public ActionResult AddDashboard_Config_Detail(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40190);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDashboard_Config_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
			Dashboard_Config_DetailModel varDashboard_Config_Detail= new Dashboard_Config_DetailModel();


            if (id.ToString() != "0")
            {
                var Dashboard_Config_DetailsData = _IDashboard_Config_DetailApiConsumer.ListaSelAll(0, 1000, "Dashboard_Config_Detail.Detail_Id=" + id, "").Resource.Dashboard_Config_Details;
				
				if (Dashboard_Config_DetailsData != null && Dashboard_Config_DetailsData.Count > 0)
                {
					var Dashboard_Config_DetailData = Dashboard_Config_DetailsData.First();
					varDashboard_Config_Detail= new Dashboard_Config_DetailModel
					{
						Detail_Id  = Dashboard_Config_DetailData.Detail_Id 
	                    ,Report_Id = Dashboard_Config_DetailData.Report_Id
                    ,Report_Name = Dashboard_Config_DetailData.Report_Name
                    ,ConfigRow = Dashboard_Config_DetailData.ConfigRow
                    ,ConfigColumn = Dashboard_Config_DetailData.ConfigColumn

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            return PartialView("AddDashboard_Config_Detail", varDashboard_Config_Detail);
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Dashboard_Config_DetailPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDashboard_Config_DetailApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Dashboard_Config_Details == null)
                result.Dashboard_Config_Details = new List<Dashboard_Config_Detail>();

            return Json(new
            {
                data = result.Dashboard_Config_Details.Select(m => new Dashboard_Config_DetailGridModel
                    {
                    Detail_Id = m.Detail_Id
			,Report_Id = m.Report_Id
			,Report_Name = m.Report_Name
			,ConfigRow = m.ConfigRow
			,ConfigColumn = m.ConfigColumn

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
                _IDashboard_Config_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                Dashboard_Config_Detail varDashboard_Config_Detail = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDashboard_Config_DetailApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Dashboard_Config_DetailModel varDashboard_Config_Detail)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDashboard_Config_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Dashboard_Config_DetailInfo = new Dashboard_Config_Detail
                    {
                        Detail_Id = varDashboard_Config_Detail.Detail_Id
                        ,Report_Id = varDashboard_Config_Detail.Report_Id
                        ,Report_Name = varDashboard_Config_Detail.Report_Name
                        ,ConfigRow = varDashboard_Config_Detail.ConfigRow
                        ,ConfigColumn = varDashboard_Config_Detail.ConfigColumn

                    };

                    result = !IsNew ?
                        _IDashboard_Config_DetailApiConsumer.Update(Dashboard_Config_DetailInfo, null, null).Resource.ToString() :
                         _IDashboard_Config_DetailApiConsumer.Insert(Dashboard_Config_DetailInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Dashboard_Config_Detail script
        /// </summary>
        /// <param name="oDashboard_Config_DetailElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Dashboard_Config_DetailModuleAttributeList)
        {
            for (int i = 0; i < Dashboard_Config_DetailModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Dashboard_Config_DetailModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Dashboard_Config_DetailModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Dashboard_Config_DetailModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Dashboard_Config_DetailModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Dashboard_Config_DetailModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Dashboard_Config_DetailModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Dashboard_Config_DetailModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Dashboard_Config_DetailModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Dashboard_Config_DetailModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Dashboard_Config_DetailModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDashboard_Config_DetailScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Dashboard_Config_Detail.js")))
            {
                strDashboard_Config_DetailScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Dashboard_Config_Detail element attributes
            string userChangeJson = jsSerialize.Serialize(Dashboard_Config_DetailModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDashboard_Config_DetailScript.IndexOf("inpuElementArray");
            string splittedString = strDashboard_Config_DetailScript.Substring(indexOfArray, strDashboard_Config_DetailScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Dashboard_Config_DetailModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Dashboard_Config_DetailModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDashboard_Config_DetailScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDashboard_Config_DetailScript.Substring(indexOfArrayHistory, strDashboard_Config_DetailScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDashboard_Config_DetailScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDashboard_Config_DetailScript.Substring(endIndexOfMainElement + indexOfArray, strDashboard_Config_DetailScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Dashboard_Config_DetailModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDashboard_Config_DetailScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDashboard_Config_DetailScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDashboard_Config_DetailScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDashboard_Config_DetailScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Dashboard_Config_Detail.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Dashboard_Config_Detail.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Dashboard_Config_Detail.js")))
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
        public ActionResult Dashboard_Config_DetailPropertyBag()
        {
            return PartialView("Dashboard_Config_DetailPropertyBag", "Dashboard_Config_Detail");
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

            _IDashboard_Config_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Dashboard_Config_DetailPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDashboard_Config_DetailApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Dashboard_Config_Details == null)
                result.Dashboard_Config_Details = new List<Dashboard_Config_Detail>();

            var data = result.Dashboard_Config_Details.Select(m => new Dashboard_Config_DetailGridModel
            {
                Detail_Id = m.Detail_Id
                ,Report_Id = m.Report_Id
                ,Report_Name = m.Report_Name
                ,ConfigRow = m.ConfigRow
                ,ConfigColumn = m.ConfigColumn

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Dashboard_Config_DetailList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Dashboard_Config_DetailList_" + DateTime.Now.ToString());
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

            _IDashboard_Config_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Dashboard_Config_DetailPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDashboard_Config_DetailApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Dashboard_Config_Details == null)
                result.Dashboard_Config_Details = new List<Dashboard_Config_Detail>();

            var data = result.Dashboard_Config_Details.Select(m => new Dashboard_Config_DetailGridModel
            {
                Detail_Id = m.Detail_Id
                ,Report_Id = m.Report_Id
                ,Report_Name = m.Report_Name
                ,ConfigRow = m.ConfigRow
                ,ConfigColumn = m.ConfigColumn

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
