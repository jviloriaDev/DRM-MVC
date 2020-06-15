using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_WorkFlow_Phase_Type;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_WorkFlow_Phase_Type;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phase_Type;

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

using Spartane.Web.Areas.WebApiConsumer.Spartan_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Permissions;
using Spartane.Web.Areas.WebApiConsumer.GeneratePDF;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Spartan_WorkFlow_Phase_TypeController : Controller
    {
        #region "variable declaration"

        private ISpartan_WorkFlow_Phase_TypeService service = null;
        private ISpartan_WorkFlow_Phase_TypeApiConsumer _ISpartan_WorkFlow_Phase_TypeApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;
        private IGeneratePDFApiConsumer _IGeneratePDFApiConsumer;
        private ISpartan_FormatApiConsumer _ISpartan_FormatApiConsumer;
        private ISpartan_Format_PermissionsApiConsumer _ISpartan_Format_PermissionsApiConsumer;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Spartan_WorkFlow_Phase_TypeController(ISpartan_WorkFlow_Phase_TypeService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_WorkFlow_Phase_TypeApiConsumer Spartan_WorkFlow_Phase_TypeApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_WorkFlow_Phase_TypeApiConsumer = Spartan_WorkFlow_Phase_TypeApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_WorkFlow_Phase_Type
        [ObjectAuth(ObjectId = (ModuleObjectId)124, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 124);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_Format_PermissionsApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);

            var whereClause = " Spartan_Format_Permissions.Spartan_User_Role = " + SessionHelper.Role + " AND Spartan_Format_Permissions_Permission_Type = " + PermissionTypes.Consult + " AND Apply=1 ";
            var formatsPermisions=_ISpartan_Format_PermissionsApiConsumer.SelAll(false, whereClause, string.Empty);
            if (formatsPermisions != null && formatsPermisions.Resource != null)
            {
                var formats = string.Join(",", formatsPermisions.Resource.Select(f => f.Format).ToArray());
                var whereClauseFormat = "Object = 124 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);
                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats!= null)
                {
                    ViewBag.Spartan_Formats = Spartan_Formats.Resource.Spartan_Formats.Select(m => new SelectListItem
                    {
                        Text = m.Format_Name.ToString(),
                        Value = Convert.ToString(m.FormatId)
                    }).ToList();

                }
            }
            return View();
        }

        // GET: Frontal/Spartan_WorkFlow_Phase_Type/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)124, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(short Id = 0,  int consult = 0)
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 124);
            ViewBag.Permission = permission;
            var varSpartan_WorkFlow_Phase_Type = new Spartan_WorkFlow_Phase_TypeModel();
			
            ViewBag.ObjectId = "124";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_Phase_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_WorkFlow_Phase_TypeData = _ISpartan_WorkFlow_Phase_TypeApiConsumer.GetByKeyComplete(Id).Resource.Spartan_WorkFlow_Phase_Types[0];
                if (Spartan_WorkFlow_Phase_TypeData == null)
                    return HttpNotFound();

                varSpartan_WorkFlow_Phase_Type = new Spartan_WorkFlow_Phase_TypeModel
                {
                    Phase_TypeId = (short)Spartan_WorkFlow_Phase_TypeData.Phase_TypeId
                    ,Description = Spartan_WorkFlow_Phase_TypeData.Description

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_WorkFlow_Phase_Type);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_WorkFlow_Phase_Type(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 124);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_WorkFlow_Phase_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_WorkFlow_Phase_TypeModel varSpartan_WorkFlow_Phase_Type= new Spartan_WorkFlow_Phase_TypeModel();


            if (id.ToString() != "0")
            {
                var Spartan_WorkFlow_Phase_TypesData = _ISpartan_WorkFlow_Phase_TypeApiConsumer.ListaSelAll(0, 1000, "Phase_TypeId=" + id, "").Resource.Spartan_WorkFlow_Phase_Types;
				
				if (Spartan_WorkFlow_Phase_TypesData != null && Spartan_WorkFlow_Phase_TypesData.Count > 0)
                {
					var Spartan_WorkFlow_Phase_TypeData = Spartan_WorkFlow_Phase_TypesData.First();
					varSpartan_WorkFlow_Phase_Type= new Spartan_WorkFlow_Phase_TypeModel
					{
						Phase_TypeId  = Spartan_WorkFlow_Phase_TypeData.Phase_TypeId 
	                    ,Description = Spartan_WorkFlow_Phase_TypeData.Description

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            return PartialView("AddSpartan_WorkFlow_Phase_Type", varSpartan_WorkFlow_Phase_Type);
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
        public ActionResult ShowAdvanceFilter(Spartan_WorkFlow_Phase_TypeAdvanceSearchModel model)
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



            var previousFiltersObj = new Spartan_WorkFlow_Phase_TypeAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Spartan_WorkFlow_Phase_TypeAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Spartan_WorkFlow_Phase_TypeAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_WorkFlow_Phase_TypePropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_WorkFlow_Phase_TypeApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_WorkFlow_Phase_Types == null)
                result.Spartan_WorkFlow_Phase_Types = new List<Spartan_WorkFlow_Phase_Type>();

            return Json(new
            {
                data = result.Spartan_WorkFlow_Phase_Types.Select(m => new Spartan_WorkFlow_Phase_TypeGridModel
                    {
                    Phase_TypeId = m.Phase_TypeId
			,Description = m.Description

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_WorkFlow_Phase_Type from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_WorkFlow_Phase_Type Entity</returns>
        public ActionResult GetSpartan_WorkFlow_Phase_TypeList(int sEcho, int iDisplayStart, int iDisplayLength, string where)
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
            _ISpartan_WorkFlow_Phase_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_WorkFlow_Phase_TypePropertyMapper());
			if (!String.IsNullOrEmpty(where))
            {
                 configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True")
            {
                var advanceFilter =
                    (Spartan_WorkFlow_Phase_TypeAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            Spartan_WorkFlow_Phase_TypePropertyMapper oSpartan_WorkFlow_Phase_TypePropertyMapper = new Spartan_WorkFlow_Phase_TypePropertyMapper();

            configuration.OrderByClause = oSpartan_WorkFlow_Phase_TypePropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISpartan_WorkFlow_Phase_TypeApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_WorkFlow_Phase_Types == null)
                result.Spartan_WorkFlow_Phase_Types = new List<Spartan_WorkFlow_Phase_Type>();

            return Json(new
            {
                aaData = result.Spartan_WorkFlow_Phase_Types.Select(m => new Spartan_WorkFlow_Phase_TypeGridModel
            {
                    Phase_TypeId = m.Phase_TypeId
			,Description = m.Description

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }







        [NonAction]
        public string GetAdvanceFilter(Spartan_WorkFlow_Phase_TypeAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromPhase_TypeId) || !string.IsNullOrEmpty(filter.ToPhase_TypeId))
            {
                if (!string.IsNullOrEmpty(filter.FromPhase_TypeId))
                    where += " AND Spartan_WorkFlow_Phase_Type.Phase_TypeId >= " + filter.FromPhase_TypeId;
                if (!string.IsNullOrEmpty(filter.ToPhase_TypeId))
                    where += " AND Spartan_WorkFlow_Phase_Type.Phase_TypeId <= " + filter.ToPhase_TypeId;
            }

            if (!string.IsNullOrEmpty(filter.Description))
            {
                switch (filter.DescriptionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_WorkFlow_Phase_Type.Description LIKE '" + filter.Description + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_WorkFlow_Phase_Type.Description LIKE '%" + filter.Description + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_WorkFlow_Phase_Type.Description = '" + filter.Description + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_WorkFlow_Phase_Type.Description LIKE '%" + filter.Description + "%'";
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
                _ISpartan_WorkFlow_Phase_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);

                Spartan_WorkFlow_Phase_Type varSpartan_WorkFlow_Phase_Type = null;
                if (id.ToString() != "0")
                {

                }
                var result = _ISpartan_WorkFlow_Phase_TypeApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_WorkFlow_Phase_TypeModel varSpartan_WorkFlow_Phase_Type)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_WorkFlow_Phase_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Spartan_WorkFlow_Phase_TypeInfo = new Spartan_WorkFlow_Phase_Type
                    {
                        Phase_TypeId = varSpartan_WorkFlow_Phase_Type.Phase_TypeId
                        ,Description = varSpartan_WorkFlow_Phase_Type.Description

                    };

                    result = !IsNew ?
                        _ISpartan_WorkFlow_Phase_TypeApiConsumer.Update(Spartan_WorkFlow_Phase_TypeInfo, null, null).Resource.ToString() :
                         _ISpartan_WorkFlow_Phase_TypeApiConsumer.Insert(Spartan_WorkFlow_Phase_TypeInfo, null, null).Resource.ToString();
					Session["KeyValueInserted"] = result;
                    return Json(result, JsonRequestBehavior.AllowGet);
				//}
				//return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Spartan_WorkFlow_Phase_Type script
        /// </summary>
        /// <param name="oSpartan_WorkFlow_Phase_TypeElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_WorkFlow_Phase_TypeModuleAttributeList)
        {
            for (int i = 0; i < Spartan_WorkFlow_Phase_TypeModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_WorkFlow_Phase_TypeModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_WorkFlow_Phase_TypeModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_WorkFlow_Phase_TypeModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_WorkFlow_Phase_TypeModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_WorkFlow_Phase_TypeModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_WorkFlow_Phase_TypeModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Spartan_WorkFlow_Phase_TypeModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Spartan_WorkFlow_Phase_TypeModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Spartan_WorkFlow_Phase_TypeModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Spartan_WorkFlow_Phase_TypeModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strSpartan_WorkFlow_Phase_TypeScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_WorkFlow_Phase_Type.js")))
            {
                strSpartan_WorkFlow_Phase_TypeScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_WorkFlow_Phase_Type element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_WorkFlow_Phase_TypeModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_WorkFlow_Phase_TypeScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_WorkFlow_Phase_TypeScript.Substring(indexOfArray, strSpartan_WorkFlow_Phase_TypeScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_WorkFlow_Phase_TypeModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_WorkFlow_Phase_TypeModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_WorkFlow_Phase_TypeScript.IndexOf("inpuElementChildArray");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strSpartan_WorkFlow_Phase_TypeScript.Substring(indexOfArrayHistory, strSpartan_WorkFlow_Phase_TypeScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strSpartan_WorkFlow_Phase_TypeScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_WorkFlow_Phase_TypeScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_WorkFlow_Phase_TypeScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Spartan_WorkFlow_Phase_TypeModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
				finalResponse = strSpartan_WorkFlow_Phase_TypeScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_WorkFlow_Phase_TypeScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_WorkFlow_Phase_TypeScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_WorkFlow_Phase_TypeScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_WorkFlow_Phase_Type.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_WorkFlow_Phase_Type.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_WorkFlow_Phase_Type.js")))
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
        public ActionResult Spartan_WorkFlow_Phase_TypePropertyBag()
        {
            return PartialView("Spartan_WorkFlow_Phase_TypePropertyBag", "Spartan_WorkFlow_Phase_Type");
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
        public FileStreamResult PrintFormats(int idFormat, string RecordId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _IGeneratePDFApiConsumer.SetAuthHeader(_tokenManager.Token);
            var bytePdf= _IGeneratePDFApiConsumer.GeneratePDF(idFormat, RecordId);

            MemoryStream ms = new MemoryStream();
            ms.Write(bytePdf.Resource, 0, bytePdf.Resource.Length);
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Formatos.pdf");
            Response.Buffer = true;
            Response.Clear();
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.End();

            return new FileStreamResult(Response.OutputStream, "application/pdf");
        }

        [HttpGet]
        public void Export(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return;

            _ISpartan_WorkFlow_Phase_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_WorkFlow_Phase_TypePropertyMapper());
			
            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True")
            {
                var advanceFilter =
                    (Spartan_WorkFlow_Phase_TypeAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_WorkFlow_Phase_TypeApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_WorkFlow_Phase_Types == null)
                result.Spartan_WorkFlow_Phase_Types = new List<Spartan_WorkFlow_Phase_Type>();

            var data = result.Spartan_WorkFlow_Phase_Types.Select(m => new Spartan_WorkFlow_Phase_TypeGridModel
            {
                Phase_TypeId = m.Phase_TypeId
			,Description = m.Description

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_WorkFlow_Phase_TypeList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_WorkFlow_Phase_TypeList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "Spartan_WorkFlow_Phase_TypeList_" + DateTime.Now.ToString());
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

            _ISpartan_WorkFlow_Phase_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_WorkFlow_Phase_TypePropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_WorkFlow_Phase_TypeApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_WorkFlow_Phase_Types == null)
                result.Spartan_WorkFlow_Phase_Types = new List<Spartan_WorkFlow_Phase_Type>();

            var data = result.Spartan_WorkFlow_Phase_Types.Select(m => new Spartan_WorkFlow_Phase_TypeGridModel
            {
                Phase_TypeId = m.Phase_TypeId
			,Description = m.Description

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
