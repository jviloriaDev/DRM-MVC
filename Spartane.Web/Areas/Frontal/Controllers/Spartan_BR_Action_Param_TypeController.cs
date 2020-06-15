using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_BR_Action_Param_Type;
using Spartane.Core.Domain.Spartan_BR_Presentation_Control_Type;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_BR_Action_Param_Type;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Param_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Presentation_Control_Type;

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
    public class Spartan_BR_Action_Param_TypeController : Controller
    {
        #region "variable declaration"

        private ISpartan_BR_Action_Param_TypeService service = null;
        private ISpartan_BR_Action_Param_TypeApiConsumer _ISpartan_BR_Action_Param_TypeApiConsumer;
        private ISpartan_BR_Presentation_Control_TypeApiConsumer _ISpartan_BR_Presentation_Control_TypeApiConsumer;

        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Spartan_BR_Action_Param_TypeController(ISpartan_BR_Action_Param_TypeService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_BR_Action_Param_TypeApiConsumer Spartan_BR_Action_Param_TypeApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer , ISpartan_BR_Presentation_Control_TypeApiConsumer Spartan_BR_Presentation_Control_TypeApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_BR_Action_Param_TypeApiConsumer = Spartan_BR_Action_Param_TypeApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_BR_Presentation_Control_TypeApiConsumer = Spartan_BR_Presentation_Control_TypeApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_BR_Action_Param_Type
        [ObjectAuth(ObjectId = (ModuleObjectId)142, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 142);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Spartan_BR_Action_Param_Type/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)142, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 142);
            ViewBag.Permission = permission;
            var varSpartan_BR_Action_Param_Type = new Spartan_BR_Action_Param_TypeModel();



            if (Convert.ToString(Id) != "0" && Convert.ToString(Id) != "-1")
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Action_Param_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_BR_Action_Param_TypeData = _ISpartan_BR_Action_Param_TypeApiConsumer.GetByKeyComplete(Id).Resource.Spartan_BR_Action_Param_Types[0];
                if (Spartan_BR_Action_Param_TypeData == null)
                    return HttpNotFound();

                varSpartan_BR_Action_Param_Type = new Spartan_BR_Action_Param_TypeModel
                {
                    ParameterTypeId = Spartan_BR_Action_Param_TypeData.ParameterTypeId
                    ,Description = Spartan_BR_Action_Param_TypeData.Description
                    ,Presentation_Control_Type = Spartan_BR_Action_Param_TypeData.Presentation_Control_Type
                    ,Presentation_Control_TypeDescription =  Spartan_BR_Action_Param_TypeData.Presentation_Control_Type_Spartan_BR_Presentation_Control_Type.Description
                    ,Query_for_Fill_Condition = Spartan_BR_Action_Param_TypeData.Query_for_Fill_Condition
                    ,Code_for_Fill_Condition = Spartan_BR_Action_Param_TypeData.Code_for_Fill_Condition
                    ,Implementation_Code = Spartan_BR_Action_Param_TypeData.Implementation_Code

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_BR_Presentation_Control_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Presentation_Control_Types = _ISpartan_BR_Presentation_Control_TypeApiConsumer.SelAll(true);
            if (Spartan_BR_Presentation_Control_Types != null && Spartan_BR_Presentation_Control_Types.Resource != null)
                ViewBag.Spartan_BR_Presentation_Control_Types = Spartan_BR_Presentation_Control_Types.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationControlTypeId)
                }).ToList();


            ViewBag.Consult = consult == 1;
            return View(varSpartan_BR_Action_Param_Type);
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
        public ActionResult GetSpartan_BR_Presentation_Control_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Presentation_Control_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Presentation_Control_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }




        [HttpPost]
        public JsonResult ClearAdvanceFilter()
        {
            Session["AdvanceSearch"] = null;
            return Json(new { result = Session["AdvanceSearch"] == null }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ShowAdvanceFilter(Spartan_BR_Action_Param_TypeAdvanceSearchModel model)
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

            _ISpartan_BR_Presentation_Control_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Presentation_Control_Types = _ISpartan_BR_Presentation_Control_TypeApiConsumer.SelAll(true);
            if (Spartan_BR_Presentation_Control_Types != null && Spartan_BR_Presentation_Control_Types.Resource != null)
                ViewBag.Spartan_BR_Presentation_Control_Types = Spartan_BR_Presentation_Control_Types.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationControlTypeId)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_BR_Presentation_Control_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Presentation_Control_Types = _ISpartan_BR_Presentation_Control_TypeApiConsumer.SelAll(true);
            if (Spartan_BR_Presentation_Control_Types != null && Spartan_BR_Presentation_Control_Types.Resource != null)
                ViewBag.Spartan_BR_Presentation_Control_Types = Spartan_BR_Presentation_Control_Types.Resource.Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.PresentationControlTypeId)
                }).ToList();


            var previousFiltersObj = new Spartan_BR_Action_Param_TypeAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Spartan_BR_Action_Param_TypeAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Spartan_BR_Action_Param_TypeAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_BR_Action_Param_TypePropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_BR_Action_Param_TypeApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Action_Param_Types == null)
                result.Spartan_BR_Action_Param_Types = new List<Spartan_BR_Action_Param_Type>();

            return Json(new
            {
                data = result.Spartan_BR_Action_Param_Types.Select(m => new Spartan_BR_Action_Param_TypeGridModel
                    {
                    ParameterTypeId = m.ParameterTypeId
			,Description = m.Description
                        ,Presentation_Control_TypeDescription = m.Presentation_Control_Type_Spartan_BR_Presentation_Control_Type.Description
			,Query_for_Fill_Condition = m.Query_for_Fill_Condition
			,Code_for_Fill_Condition = m.Code_for_Fill_Condition
			,Implementation_Code = m.Implementation_Code

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_BR_Action_Param_Type from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_BR_Action_Param_Type Entity</returns>
        public ActionResult GetSpartan_BR_Action_Param_TypeList(int sEcho, int iDisplayStart, int iDisplayLength)
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
            _ISpartan_BR_Action_Param_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_BR_Action_Param_TypePropertyMapper());

            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True")
            {
                var advanceFilter =
                    (Spartan_BR_Action_Param_TypeAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            Spartan_BR_Action_Param_TypePropertyMapper oSpartan_BR_Action_Param_TypePropertyMapper = new Spartan_BR_Action_Param_TypePropertyMapper();

            configuration.OrderByClause = oSpartan_BR_Action_Param_TypePropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISpartan_BR_Action_Param_TypeApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Action_Param_Types == null)
                result.Spartan_BR_Action_Param_Types = new List<Spartan_BR_Action_Param_Type>();

            return Json(new
            {
                aaData = result.Spartan_BR_Action_Param_Types.Select(m => new Spartan_BR_Action_Param_TypeGridModel
            {
                    ParameterTypeId = m.ParameterTypeId
			,Description = m.Description
                        ,Presentation_Control_TypeDescription = m.Presentation_Control_Type_Spartan_BR_Presentation_Control_Type.Description
			,Query_for_Fill_Condition = m.Query_for_Fill_Condition
			,Code_for_Fill_Condition = m.Code_for_Fill_Condition
			,Implementation_Code = m.Implementation_Code

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(Spartan_BR_Action_Param_TypeAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromParameterTypeId) || !string.IsNullOrEmpty(filter.ToParameterTypeId))
            {
                if (!string.IsNullOrEmpty(filter.FromParameterTypeId))
                    where += " AND Spartan_BR_Action_Param_Type.ParameterTypeId >= " + filter.FromParameterTypeId;
                if (!string.IsNullOrEmpty(filter.ToParameterTypeId))
                    where += " AND Spartan_BR_Action_Param_Type.ParameterTypeId <= " + filter.ToParameterTypeId;
            }

            if (!string.IsNullOrEmpty(filter.Description))
            {
                switch (filter.DescriptionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_BR_Action_Param_Type.Description LIKE '" + filter.Description + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_BR_Action_Param_Type.Description LIKE '%" + filter.Description + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_BR_Action_Param_Type.Description = '" + filter.Description + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_BR_Action_Param_Type.Description LIKE '%" + filter.Description + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvancePresentation_Control_Type))
            {
                switch (filter.Presentation_Control_TypeFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_BR_Presentation_Control_Type.Description LIKE '" + filter.AdvancePresentation_Control_Type + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_BR_Presentation_Control_Type.Description LIKE '%" + filter.AdvancePresentation_Control_Type + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_BR_Presentation_Control_Type.Description = '" + filter.AdvancePresentation_Control_Type + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_BR_Presentation_Control_Type.Description LIKE '%" + filter.AdvancePresentation_Control_Type + "%'";
                        break;
                }
            }
            else if (filter.AdvancePresentation_Control_TypeMultiple != null && filter.AdvancePresentation_Control_TypeMultiple.Count() > 0)
            {
                var Presentation_Control_TypeIds = string.Join(",", filter.AdvancePresentation_Control_TypeMultiple);

                where += " AND Spartan_BR_Action_Param_Type.Presentation_Control_Type In (" + Presentation_Control_TypeIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Query_for_Fill_Condition))
            {
                switch (filter.Query_for_Fill_ConditionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_BR_Action_Param_Type.Query_for_Fill_Condition LIKE '" + filter.Query_for_Fill_Condition + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_BR_Action_Param_Type.Query_for_Fill_Condition LIKE '%" + filter.Query_for_Fill_Condition + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_BR_Action_Param_Type.Query_for_Fill_Condition = '" + filter.Query_for_Fill_Condition + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_BR_Action_Param_Type.Query_for_Fill_Condition LIKE '%" + filter.Query_for_Fill_Condition + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Code_for_Fill_Condition))
            {
                switch (filter.Code_for_Fill_ConditionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_BR_Action_Param_Type.Code_for_Fill_Condition LIKE '" + filter.Code_for_Fill_Condition + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_BR_Action_Param_Type.Code_for_Fill_Condition LIKE '%" + filter.Code_for_Fill_Condition + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_BR_Action_Param_Type.Code_for_Fill_Condition = '" + filter.Code_for_Fill_Condition + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_BR_Action_Param_Type.Code_for_Fill_Condition LIKE '%" + filter.Code_for_Fill_Condition + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Implementation_Code))
            {
                switch (filter.Implementation_CodeFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_BR_Action_Param_Type.Implementation_Code LIKE '" + filter.Implementation_Code + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_BR_Action_Param_Type.Implementation_Code LIKE '%" + filter.Implementation_Code + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_BR_Action_Param_Type.Implementation_Code = '" + filter.Implementation_Code + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_BR_Action_Param_Type.Implementation_Code LIKE '%" + filter.Implementation_Code + "%'";
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
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Action_Param_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);

                //Spartan_BR_Action_Param_Type varSpartan_BR_Action_Param_Type = null;
                if (id.ToString() != "0")
                {

                }
                var result = _ISpartan_BR_Action_Param_TypeApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(Spartan_BR_Action_Param_TypeModel varSpartan_BR_Action_Param_Type)
        {
            try
            {
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_BR_Action_Param_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "0";
                    var Spartan_BR_Action_Param_TypeInfo = new Spartan_BR_Action_Param_Type
                    {
                        ParameterTypeId = varSpartan_BR_Action_Param_Type.ParameterTypeId
                        ,Description = varSpartan_BR_Action_Param_Type.Description
                        ,Presentation_Control_Type = varSpartan_BR_Action_Param_Type.Presentation_Control_Type
                        ,Query_for_Fill_Condition = varSpartan_BR_Action_Param_Type.Query_for_Fill_Condition
                        ,Code_for_Fill_Condition = varSpartan_BR_Action_Param_Type.Code_for_Fill_Condition
                        ,Implementation_Code = varSpartan_BR_Action_Param_Type.Implementation_Code

                    };

                    result = varSpartan_BR_Action_Param_Type.ParameterTypeId.ToString() != "0" ?
                        _ISpartan_BR_Action_Param_TypeApiConsumer.Update(Spartan_BR_Action_Param_TypeInfo, null, null).Resource.ToString() :
                         _ISpartan_BR_Action_Param_TypeApiConsumer.Insert(Spartan_BR_Action_Param_TypeInfo, null, null).Resource.ToString();

                    if (varSpartan_BR_Action_Param_Type.ParameterTypeId.ToString() != "0")
                        result = varSpartan_BR_Action_Param_Type.ParameterTypeId.ToString();

                    return Json(result, JsonRequestBehavior.AllowGet);

            }
            catch (ServiceException)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Spartan_BR_Action_Param_Type script
        /// </summary>
        /// <param name="oSpartan_BR_Action_Param_TypeElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_BR_Action_Param_TypeModuleAttributeList)
        {
            for (int i = 0; i < Spartan_BR_Action_Param_TypeModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_BR_Action_Param_TypeModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_BR_Action_Param_TypeModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_BR_Action_Param_TypeModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_BR_Action_Param_TypeModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }

            for (int i = 0; i < Spartan_BR_Action_Param_TypeModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_BR_Action_Param_TypeModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
                {
                    Spartan_BR_Action_Param_TypeModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_BR_Action_Param_TypeModuleAttributeList.ChildModuleAttributeList[i].HelpText))
                {
                    Spartan_BR_Action_Param_TypeModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
                }
            }

            string strSpartan_BR_Action_Param_TypeScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Action_Param_Type.js")))
            {
                strSpartan_BR_Action_Param_TypeScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_BR_Action_Param_Type element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_BR_Action_Param_TypeModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_BR_Action_Param_TypeScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_BR_Action_Param_TypeScript.Substring(indexOfArray, strSpartan_BR_Action_Param_TypeScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_BR_Action_Param_TypeModuleAttributeList.ChildModuleAttributeList);

            int indexOfArrayHistory = strSpartan_BR_Action_Param_TypeScript.IndexOf("inpuElementChildArray");
            string splittedStringHistory = strSpartan_BR_Action_Param_TypeScript.Substring(indexOfArrayHistory, strSpartan_BR_Action_Param_TypeScript.Length - indexOfArrayHistory);
            int indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
            int endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;

            
            //string finalResponse = strSpartan_BR_Action_Param_TypeScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_BR_Action_Param_TypeScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_BR_Action_Param_TypeScript.Length - (endIndexOfMainElement + indexOfArray));
            string finalResponse = strSpartan_BR_Action_Param_TypeScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_BR_Action_Param_TypeScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_BR_Action_Param_TypeScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_BR_Action_Param_TypeScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Action_Param_Type.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Action_Param_Type.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_BR_Action_Param_Type.js")))
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
        public ActionResult Spartan_BR_Action_Param_TypePropertyBag()
        {
            return PartialView("Spartan_BR_Action_Param_TypePropertyBag", "Spartan_BR_Action_Param_Type");
        }

        [HttpGet]
        public ActionResult Spartan_BR_Action_Param_TypeBusinessRule()
        {
            return PartialView("Spartan_BR_Action_Param_TypeBusinessRule", "Spartan_BR_Action_Param_Type");
        }

        [HttpGet]
        public ActionResult AddBusinessRule(int BusinessRuleId = 0)
        {
            Spartan_BR_Action_Param_TypeBusinessRuleModel oSpartan_BR_Action_Param_TypeBusinessRuleModel = new Spartan_BR_Action_Param_TypeBusinessRuleModel();
            if (BusinessRuleId > 0)
            {
                oSpartan_BR_Action_Param_TypeBusinessRuleModel.BusinessRuleId = BusinessRuleId;
            }
            return PartialView("AddBusinessRule", oSpartan_BR_Action_Param_TypeBusinessRuleModel);
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

            _ISpartan_BR_Action_Param_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_BR_Action_Param_TypePropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_BR_Action_Param_TypeApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Action_Param_Types == null)
                result.Spartan_BR_Action_Param_Types = new List<Spartan_BR_Action_Param_Type>();

            var data = result.Spartan_BR_Action_Param_Types.Select(m => new Spartan_BR_Action_Param_TypeGridModel
            {
                ParameterTypeId = m.ParameterTypeId
                ,Description = m.Description
                ,Query_for_Fill_Condition = m.Query_for_Fill_Condition
                ,Code_for_Fill_Condition = m.Code_for_Fill_Condition
                ,Implementation_Code = m.Implementation_Code

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_BR_Action_Param_TypeList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_BR_Action_Param_TypeList_" + DateTime.Now.ToString());
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

            _ISpartan_BR_Action_Param_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_BR_Action_Param_TypePropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_BR_Action_Param_TypeApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_BR_Action_Param_Types == null)
                result.Spartan_BR_Action_Param_Types = new List<Spartan_BR_Action_Param_Type>();

            var data = result.Spartan_BR_Action_Param_Types.Select(m => new Spartan_BR_Action_Param_TypeGridModel
            {
                ParameterTypeId = m.ParameterTypeId
                ,Description = m.Description
                ,Query_for_Fill_Condition = m.Query_for_Fill_Condition
                ,Code_for_Fill_Condition = m.Code_for_Fill_Condition
                ,Implementation_Code = m.Implementation_Code

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
