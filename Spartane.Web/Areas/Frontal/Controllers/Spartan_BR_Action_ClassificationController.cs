using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_BR_Action_Classification;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_BR_Action_Classification;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Classification;

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

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Spartan_BR_Action_ClassificationController : Controller
    {
        #region "variable declaration"

        private ISpartan_BR_Action_ClassificationService service = null;
        private ISpartan_BR_Action_ClassificationApiConsumer _ISpartan_BR_Action_ClassificationApiConsumer;

        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Spartan_BR_Action_ClassificationController(ISpartan_BR_Action_ClassificationService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_BR_Action_ClassificationApiConsumer Spartan_BR_Action_ClassificationApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_BR_Action_ClassificationApiConsumer = Spartan_BR_Action_ClassificationApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_BR_Action_Classification
        [ObjectAuth(ObjectId = (ModuleObjectId)141, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 141);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Spartan_BR_Action_Classification/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)141, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(short Id = 0,  int consult = 0)
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 141);
            ViewBag.Permission = permission;
            var varSpartan_BR_Action_Classification = new Spartan_BR_Action_ClassificationModel();



            if (Convert.ToString(Id) != "0" && Convert.ToString(Id) != "-1")
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Action_ClassificationApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_BR_Action_ClassificationData = _ISpartan_BR_Action_ClassificationApiConsumer.GetByKeyComplete(Id).Resource.Spartan_BR_Action_Classifications[0];
                if (Spartan_BR_Action_ClassificationData == null)
                    return HttpNotFound();

                varSpartan_BR_Action_Classification = new Spartan_BR_Action_ClassificationModel
                {
                    ClassificationId = Spartan_BR_Action_ClassificationData.ClassificationId
                    ,Description = Spartan_BR_Action_ClassificationData.Description

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            ViewBag.Consult = consult == 1;
            return View(varSpartan_BR_Action_Classification);
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




        [HttpPost]
        public JsonResult ClearAdvanceFilter()
        {
            Session["AdvanceSearch"] = null;
            return Json(new { result = Session["AdvanceSearch"] == null }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ShowAdvanceFilter(Spartan_BR_Action_ClassificationAdvanceSearchModel model)
        {
            if (ModelState.IsValid)
            {
                Session["AdvanceSearch"] = model;
                return RedirectToAction("Index");
            }
            ViewBag.Filter = new List<SelectListItem>
            {
                new SelectListItem() {Text = Resources.Resources.BeginWith, Value = "1"},
                new SelectListItem() {Text = Resources.Resources.EndWith, Value = "2"},
                new SelectListItem() {Text = Resources.Resources.Contains, Value = "4"},
                new SelectListItem() {Text = Resources.Resources.Exact, Value = "3"},
            };
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            var previousFiltersObj = new Spartan_BR_Action_ClassificationAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Spartan_BR_Action_ClassificationAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Spartan_BR_Action_ClassificationAdvanceSearchModel());
            }

            ViewBag.Filter = new List<SelectListItem>
            {
                new SelectListItem() {Text = Resources.Resources.BeginWith, Value = "1"},
                new SelectListItem() {Text = Resources.Resources.EndWith, Value = "2"},
                new SelectListItem() {Text = Resources.Resources.Contains, Value = "4"},
                new SelectListItem() {Text = Resources.Resources.Exact, Value = "3"},

            };

            return View(previousFiltersObj);
        }

        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_BR_Action_ClassificationPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_BR_Action_ClassificationApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Action_Classifications == null)
                result.Spartan_BR_Action_Classifications = new List<Spartan_BR_Action_Classification>();

            return Json(new
            {
                data = result.Spartan_BR_Action_Classifications.Select(m => new Spartan_BR_Action_ClassificationGridModel
                    {
                    ClassificationId = m.ClassificationId
			,Description = m.Description

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_BR_Action_Classification from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_BR_Action_Classification Entity</returns>
        public ActionResult GetSpartan_BR_Action_ClassificationList(int sEcho, int iDisplayStart, int iDisplayLength)
        {
            int sortColumn = -1;
            string sortDirection = "asc";
            if (iDisplayLength == -1)
            {
                //length = TOTAL_ROWS;
                iDisplayLength = Int32.MaxValue;
            }
            // note: we only sort one column at a time
            if (Request.QueryString["iSortCol_0"] != null)
            {
                sortColumn = int.Parse(Request.QueryString["iSortCol_0"]);
            }
            if (Request.QueryString["sSortDir_0"] != null)
            {
                sortDirection = Request.QueryString["sSortDir_0"];
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Action_ClassificationApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_BR_Action_ClassificationPropertyMapper());

            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True")
            {
                var advanceFilter =
                    (Spartan_BR_Action_ClassificationAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            Spartan_BR_Action_ClassificationPropertyMapper oSpartan_BR_Action_ClassificationPropertyMapper = new Spartan_BR_Action_ClassificationPropertyMapper();

            configuration.OrderByClause = oSpartan_BR_Action_ClassificationPropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISpartan_BR_Action_ClassificationApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Action_Classifications == null)
                result.Spartan_BR_Action_Classifications = new List<Spartan_BR_Action_Classification>();

            return Json(new
            {
                aaData = result.Spartan_BR_Action_Classifications.Select(m => new Spartan_BR_Action_ClassificationGridModel
            {
                    ClassificationId = m.ClassificationId
			,Description = m.Description

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(Spartan_BR_Action_ClassificationAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromClassificationId) || !string.IsNullOrEmpty(filter.ToClassificationId))
            {
                if (!string.IsNullOrEmpty(filter.FromClassificationId))
                    where += " AND Spartan_BR_Action_Classification.ClassificationId >= " + filter.FromClassificationId;
                if (!string.IsNullOrEmpty(filter.ToClassificationId))
                    where += " AND Spartan_BR_Action_Classification.ClassificationId <= " + filter.ToClassificationId;
            }

            if (!string.IsNullOrEmpty(filter.Description))
            {
                switch (filter.DescriptionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_BR_Action_Classification.Description LIKE '" + filter.Description + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_BR_Action_Classification.Description LIKE '%" + filter.Description + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_BR_Action_Classification.Description = '" + filter.Description + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_BR_Action_Classification.Description LIKE '%" + filter.Description + "%'";
                        break;
                }
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }



        [HttpDelete]
        public ActionResult Delete(short id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Action_ClassificationApiConsumer.SetAuthHeader(_tokenManager.Token);

                //Spartan_BR_Action_Classification varSpartan_BR_Action_Classification = null;
                if (id.ToString() != "0")
                {

                }
                var result = _ISpartan_BR_Action_ClassificationApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(Spartan_BR_Action_ClassificationModel varSpartan_BR_Action_Classification)
        {
            try
            {
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_BR_Action_ClassificationApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "0";
                    var Spartan_BR_Action_ClassificationInfo = new Spartan_BR_Action_Classification
                    {
                        ClassificationId = varSpartan_BR_Action_Classification.ClassificationId
                        ,Description = varSpartan_BR_Action_Classification.Description

                    };

                    result = varSpartan_BR_Action_Classification.ClassificationId.ToString() != "0" ?
                        _ISpartan_BR_Action_ClassificationApiConsumer.Update(Spartan_BR_Action_ClassificationInfo, null, null).Resource.ToString() :
                         _ISpartan_BR_Action_ClassificationApiConsumer.Insert(Spartan_BR_Action_ClassificationInfo, null, null).Resource.ToString();

                    if (varSpartan_BR_Action_Classification.ClassificationId.ToString() != "0")
                        result = varSpartan_BR_Action_Classification.ClassificationId.ToString();

                    return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Spartan_BR_Action_Classification script
        /// </summary>
        /// <param name="oSpartan_BR_Action_ClassificationElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_BR_Action_ClassificationModuleAttributeList)
        {
            for (int i = 0; i < Spartan_BR_Action_ClassificationModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_BR_Action_ClassificationModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_BR_Action_ClassificationModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_BR_Action_ClassificationModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_BR_Action_ClassificationModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }

            for (int i = 0; i < Spartan_BR_Action_ClassificationModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_BR_Action_ClassificationModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
                {
                    Spartan_BR_Action_ClassificationModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_BR_Action_ClassificationModuleAttributeList.ChildModuleAttributeList[i].HelpText))
                {
                    Spartan_BR_Action_ClassificationModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
                }
            }

            string strSpartan_BR_Action_ClassificationScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Action_Classification.js")))
            {
                strSpartan_BR_Action_ClassificationScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_BR_Action_Classification element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_BR_Action_ClassificationModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_BR_Action_ClassificationScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_BR_Action_ClassificationScript.Substring(indexOfArray, strSpartan_BR_Action_ClassificationScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_BR_Action_ClassificationModuleAttributeList.ChildModuleAttributeList);

            int indexOfArrayHistory = strSpartan_BR_Action_ClassificationScript.IndexOf("inpuElementChildArray");
            string splittedStringHistory = strSpartan_BR_Action_ClassificationScript.Substring(indexOfArrayHistory, strSpartan_BR_Action_ClassificationScript.Length - indexOfArrayHistory);
            int indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
            int endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;

            
            //string finalResponse = strSpartan_BR_Action_ClassificationScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_BR_Action_ClassificationScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_BR_Action_ClassificationScript.Length - (endIndexOfMainElement + indexOfArray));
            string finalResponse = strSpartan_BR_Action_ClassificationScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_BR_Action_ClassificationScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_BR_Action_ClassificationScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_BR_Action_ClassificationScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Action_Classification.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Action_Classification.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Action_Classification.js")))
                {
                    strCustomScript = r.ReadToEnd();
                
                }

                int indexOfArray = strCustomScript.IndexOf("inpuElementArray");
                string splittedString = strCustomScript.Substring(indexOfArray, strCustomScript.Length - indexOfArray);                
                int indexOfMainElement = splittedString.IndexOf('[');                
                int endIndexOfMainElement = splittedString.IndexOf(']') + 1;                
                string mainJsonArray = splittedString.Substring(indexOfMainElement, endIndexOfMainElement - indexOfMainElement);

                int indexOfChildArray = strCustomScript.IndexOf("inpuElementChildArray");
                string splittedChildString = strCustomScript.Substring(indexOfChildArray, strCustomScript.Length - indexOfChildArray);
                int indexOfChildElement = splittedChildString.IndexOf('[');
                int endIndexOfChildElement = splittedChildString.IndexOf(']') + 1;
                string childJsonArray = splittedChildString.Substring(indexOfChildElement, endIndexOfChildElement - indexOfChildElement);

                var MainElementList = JsonConvert.DeserializeObject(mainJsonArray);
                var ChildElementList = JsonConvert.DeserializeObject(childJsonArray);

                oCustomElementAttribute.MainElement = MainElementList.ToString();
                oCustomElementAttribute.ChildElement = ChildElementList.ToString();
            }
            else
            {
                oCustomElementAttribute.MainElement = string.Empty;
                oCustomElementAttribute.ChildElement = string.Empty;
            }        
            return Json(oCustomElementAttribute, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Spartan_BR_Action_ClassificationPropertyBag()
        {
            return PartialView("Spartan_BR_Action_ClassificationPropertyBag", "Spartan_BR_Action_Classification");
        }

        [HttpGet]
        public ActionResult Spartan_BR_Action_ClassificationBusinessRule()
        {
            return PartialView("Spartan_BR_Action_ClassificationBusinessRule", "Spartan_BR_Action_Classification");
        }

        [HttpGet]
        public ActionResult AddBusinessRule(int BusinessRuleId = 0)
        {
            Spartan_BR_Action_ClassificationBusinessRuleModel oSpartan_BR_Action_ClassificationBusinessRuleModel = new Spartan_BR_Action_ClassificationBusinessRuleModel();
            if (BusinessRuleId > 0)
            {
                oSpartan_BR_Action_ClassificationBusinessRuleModel.BusinessRuleId = BusinessRuleId;
            }
            return PartialView("AddBusinessRule", oSpartan_BR_Action_ClassificationBusinessRuleModel);
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

            _ISpartan_BR_Action_ClassificationApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_BR_Action_ClassificationPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_BR_Action_ClassificationApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Action_Classifications == null)
                result.Spartan_BR_Action_Classifications = new List<Spartan_BR_Action_Classification>();

            var data = result.Spartan_BR_Action_Classifications.Select(m => new Spartan_BR_Action_ClassificationGridModel
            {
                ClassificationId = m.ClassificationId
                ,Description = m.Description

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_BR_Action_ClassificationList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_BR_Action_ClassificationList_" + DateTime.Now.ToString());
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

            _ISpartan_BR_Action_ClassificationApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_BR_Action_ClassificationPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_BR_Action_ClassificationApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Action_Classifications == null)
                result.Spartan_BR_Action_Classifications = new List<Spartan_BR_Action_Classification>();

            var data = result.Spartan_BR_Action_Classifications.Select(m => new Spartan_BR_Action_ClassificationGridModel
            {
                ClassificationId = m.ClassificationId
                ,Description = m.Description

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
