using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Template_Dashboard_Editor;
using Spartane.Core.Domain.Template_Dashboard_Detail;


using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Template_Dashboard_Editor;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Template_Dashboard_Editor;
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

using Spartane.Web.Areas.WebApiConsumer.Spartan_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Permissions;
using Spartane.Web.Areas.WebApiConsumer.GeneratePDF;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;

using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Related;
using Spartane.Core.Domain.Spartan_Format;
using iTextSharp.text.pdf;


namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Template_Dashboard_EditorController : Controller
    {
        #region "variable declaration"

        private ITemplate_Dashboard_EditorService service = null;
        private ITemplate_Dashboard_EditorApiConsumer _ITemplate_Dashboard_EditorApiConsumer;
        private ITemplate_Dashboard_DetailApiConsumer _ITemplate_Dashboard_DetailApiConsumer;


        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;
        private IGeneratePDFApiConsumer _IGeneratePDFApiConsumer;
        private ISpartan_FormatApiConsumer _ISpartan_FormatApiConsumer;
        private ISpartan_Format_PermissionsApiConsumer _ISpartan_Format_PermissionsApiConsumer;
		private ISpartan_Format_RelatedApiConsumer _ISpartan_FormatRelatedApiConsumer;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Template_Dashboard_EditorController(ITemplate_Dashboard_EditorService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ITemplate_Dashboard_EditorApiConsumer Template_Dashboard_EditorApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , ITemplate_Dashboard_DetailApiConsumer Template_Dashboard_DetailApiConsumer  )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ITemplate_Dashboard_EditorApiConsumer = Template_Dashboard_EditorApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
			this._ISpartan_FormatRelatedApiConsumer = Spartan_Format_RelatedApiConsumer;
            this._ITemplate_Dashboard_DetailApiConsumer = Template_Dashboard_DetailApiConsumer;


        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Template_Dashboard_Editor
        [ObjectAuth(ObjectId = (ModuleObjectId)40143, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index(int ModuleId=0)
        {
			if (Session["AdvanceReportFilter"] != null)
            {
                Session["AdvanceReportFilter"] = null;
                Session["AdvanceSearch"] = null;
            }
			if (ModuleId == 0)
            {
                ModuleId = Convert.ToInt32(Session["CurrentModuleId"]);
                if (ModuleId == 0)
                {
                    Response.Redirect("~/");
                }
            }
            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40143, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Template_Dashboard_Editor/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)40143, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40143, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varTemplate_Dashboard_Editor = new Template_Dashboard_EditorModel();
			varTemplate_Dashboard_Editor.Template_Id = Id;
			
            ViewBag.ObjectId = "40143";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionTemplate_Dashboard_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40189, ModuleId);
            ViewBag.PermissionTemplate_Dashboard_Detail = permissionTemplate_Dashboard_Detail;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _ITemplate_Dashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Template_Dashboard_EditorsData = _ITemplate_Dashboard_EditorApiConsumer.ListaSelAll(0, 1000, "Template_Dashboard_Editor.Template_Id=" + Id, "").Resource.Template_Dashboard_Editors;
				
				if (Template_Dashboard_EditorsData != null && Template_Dashboard_EditorsData.Count > 0)
                {
					var Template_Dashboard_EditorData = Template_Dashboard_EditorsData.First();
					varTemplate_Dashboard_Editor= new Template_Dashboard_EditorModel
					{
						Template_Id  = Template_Dashboard_EditorData.Template_Id 
	                    ,Description = Template_Dashboard_EditorData.Description
                    ,Template_Image_Thumbnail = Template_Dashboard_EditorData.Template_Image_Thumbnail

					};
				}
				
				                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Template_Image_ThumbnailSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varTemplate_Dashboard_Editor.Template_Image_Thumbnail).Resource;

				
            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
				
			var isPartial = false;
            var isMR = false;
            var nameMR = string.Empty;
            var nameAttribute = string.Empty;

	        if (Request.QueryString["isPartial"]!= null)
                isPartial = Convert.ToBoolean(Request.QueryString["isPartial"]);

            if (Request.QueryString["isMR"] != null)
                isMR = Convert.ToBoolean(Request.QueryString["isMR"]);

            if (Request.QueryString["nameMR"] != null)
                nameMR = Request.QueryString["nameMR"].ToString();

            if (Request.QueryString["nameAttribute"] != null)
                nameAttribute = Request.QueryString["nameAttribute"].ToString();
				
			ViewBag.isPartial=isPartial;
			ViewBag.isMR=isMR;
			ViewBag.nameMR=nameMR;
			ViewBag.nameAttribute=nameAttribute;

				
            return View(varTemplate_Dashboard_Editor);
        }
		
	[HttpGet]
        public ActionResult AddTemplate_Dashboard_Editor(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40143);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ITemplate_Dashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
			Template_Dashboard_EditorModel varTemplate_Dashboard_Editor= new Template_Dashboard_EditorModel();
            var permissionTemplate_Dashboard_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40189, ModuleId);
            ViewBag.PermissionTemplate_Dashboard_Detail = permissionTemplate_Dashboard_Detail;


            if (id.ToString() != "0")
            {
                var Template_Dashboard_EditorsData = _ITemplate_Dashboard_EditorApiConsumer.ListaSelAll(0, 1000, "Template_Dashboard_Editor.Template_Id=" + id, "").Resource.Template_Dashboard_Editors;
				
				if (Template_Dashboard_EditorsData != null && Template_Dashboard_EditorsData.Count > 0)
                {
					var Template_Dashboard_EditorData = Template_Dashboard_EditorsData.First();
					varTemplate_Dashboard_Editor= new Template_Dashboard_EditorModel
					{
						Template_Id  = Template_Dashboard_EditorData.Template_Id 
	                    ,Description = Template_Dashboard_EditorData.Description
                    ,Template_Image_Thumbnail = Template_Dashboard_EditorData.Template_Image_Thumbnail

					};
				}
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.Template_Image_ThumbnailSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varTemplate_Dashboard_Editor.Template_Image_Thumbnail).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);



            return PartialView("AddTemplate_Dashboard_Editor", varTemplate_Dashboard_Editor);
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
        public ActionResult ShowAdvanceFilter(Template_Dashboard_EditorAdvanceSearchModel model, int idFilter = -1)
        {
            if (ModelState.IsValid)
            {
                Session["AdvanceSearch"] = model;
				if (idFilter != -1)
                {
                    Session["AdvanceReportFilter"] = GetAdvanceFilter(model);
                    return RedirectToAction("Index", "Report", new { id = idFilter });
                }
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



            var previousFiltersObj = new Template_Dashboard_EditorAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Template_Dashboard_EditorAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Template_Dashboard_EditorAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Template_Dashboard_EditorPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ITemplate_Dashboard_EditorApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Template_Dashboard_Editors == null)
                result.Template_Dashboard_Editors = new List<Template_Dashboard_Editor>();

            return Json(new
            {
                data = result.Template_Dashboard_Editors.Select(m => new Template_Dashboard_EditorGridModel
                    {
                    Template_Id = m.Template_Id
			,Description = m.Description
			,Template_Image_Thumbnail = m.Template_Image_Thumbnail

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Template_Dashboard_Editor from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Template_Dashboard_Editor Entity</returns>
        public ActionResult GetTemplate_Dashboard_EditorList(UrlParametersModel param)
        {
			 int sEcho = param.sEcho;
            int iDisplayStart = param.iDisplayStart;
            int iDisplayLength = param.iDisplayLength;
            string where = param.where;
            string order = param.order;

            where = HttpUtility.UrlEncode(where);
            int sortColumn = -1;
            string sortDirection = "asc";
            if (iDisplayLength == -1)
            {
                //length = TOTAL_ROWS;
                iDisplayLength = Int32.MaxValue;
            }
            // note: we only sort one column at a time
            if (param.sortColumn != null)
            {
                sortColumn = int.Parse(param.sortColumn);
            }
            if (param.sortDirection != null)
            {
                sortDirection = param.sortDirection;
            }


            if (!_tokenManager.GenerateToken())
                return null;
            _ITemplate_Dashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Template_Dashboard_EditorPropertyMapper());
				
			if (!String.IsNullOrEmpty(where))
            {
                 configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            //Adding Advance Search
            if (param.AdvanceSearch != null && param.AdvanceSearch == true && Session["AdvanceSearch"] != null)            
            {
				if (Session["AdvanceSearch"].GetType() == typeof(Template_Dashboard_EditorAdvanceSearchModel))
                {
					var advanceFilter =
                    (Template_Dashboard_EditorAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Template_Dashboard_EditorPropertyMapper oTemplate_Dashboard_EditorPropertyMapper = new Template_Dashboard_EditorPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oTemplate_Dashboard_EditorPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ITemplate_Dashboard_EditorApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Template_Dashboard_Editors == null)
                result.Template_Dashboard_Editors = new List<Template_Dashboard_Editor>();

            return Json(new
            {
                aaData = result.Template_Dashboard_Editors.Select(m => new Template_Dashboard_EditorGridModel
            {
                    Template_Id = m.Template_Id
			,Description = m.Description
			,Template_Image_Thumbnail = m.Template_Image_Thumbnail

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(Template_Dashboard_EditorAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromTemplate_Id) || !string.IsNullOrEmpty(filter.ToTemplate_Id))
            {
                if (!string.IsNullOrEmpty(filter.FromTemplate_Id))
                    where += " AND Template_Dashboard_Editor.Template_Id >= " + filter.FromTemplate_Id;
                if (!string.IsNullOrEmpty(filter.ToTemplate_Id))
                    where += " AND Template_Dashboard_Editor.Template_Id <= " + filter.ToTemplate_Id;
            }

            if (!string.IsNullOrEmpty(filter.Description))
            {
                switch (filter.DescriptionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Template_Dashboard_Editor.Description LIKE '" + filter.Description + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Template_Dashboard_Editor.Description LIKE '%" + filter.Description + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Template_Dashboard_Editor.Description = '" + filter.Description + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Template_Dashboard_Editor.Description LIKE '%" + filter.Description + "%'";
                        break;
                }
            }

            if (filter.Template_Image_Thumbnail != RadioOptions.NoApply)
                where += " AND Template_Dashboard_Editor.Template_Image_Thumbnail " + (filter.Template_Image_Thumbnail == RadioOptions.Yes ? ">" : "==") + " 0";


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

        public ActionResult GetTemplate_Dashboard_Detail(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Template_Dashboard_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ITemplate_Dashboard_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Template_Dashboard_Detail.Template=" + RelationId;
            if("int" == "string")
            {
	           where = "Template_Dashboard_Detail.Template='" + RelationId + "'";
            }
            var result = _ITemplate_Dashboard_DetailApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Template_Dashboard_Details == null)
                result.Template_Dashboard_Details = new List<Template_Dashboard_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Template_Dashboard_Details.Select(m => new Template_Dashboard_DetailGridModel
                {
                    Detail_Id = m.Detail_Id
			,Row_Number = m.Row_Number
			,Columns = m.Columns

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Template_Dashboard_DetailGridModel> GetTemplate_Dashboard_DetailData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Template_Dashboard_DetailGridModel> resultData = new List<Template_Dashboard_DetailGridModel>();
            string where = "Template_Dashboard_Detail.Template=" + Id;
            if("int" == "string")
            {
                where = "Template_Dashboard_Detail.Template='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _ITemplate_Dashboard_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _ITemplate_Dashboard_DetailApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Template_Dashboard_Details != null)
            {
                resultData = result.Template_Dashboard_Details.Select(m => new Template_Dashboard_DetailGridModel
                    {
                        Detail_Id = m.Detail_Id
			,Row_Number = m.Row_Number
			,Columns = m.Columns


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITemplate_Dashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);

                Template_Dashboard_Editor varTemplate_Dashboard_Editor = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _ITemplate_Dashboard_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Template_Dashboard_Detail.Template=" + id;
                    if("int" == "string")
                    {
	                where = "Template_Dashboard_Detail.Template='" + id + "'";
                    }
                    var Template_Dashboard_DetailInfo =
                        _ITemplate_Dashboard_DetailApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Template_Dashboard_DetailInfo.Template_Dashboard_Details.Count > 0)
                    {
                        var resultTemplate_Dashboard_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Template_Dashboard_DetailItem in Template_Dashboard_DetailInfo.Template_Dashboard_Details)
                            resultTemplate_Dashboard_Detail = resultTemplate_Dashboard_Detail
                                              && _ITemplate_Dashboard_DetailApiConsumer.Delete(Template_Dashboard_DetailItem.Detail_Id, null,null).Resource;

                        if (!resultTemplate_Dashboard_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _ITemplate_Dashboard_EditorApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Template_Dashboard_EditorModel varTemplate_Dashboard_Editor)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ITemplate_Dashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);


                    if (varTemplate_Dashboard_Editor.Template_Image_ThumbnailRemoveAttachment != 0 && varTemplate_Dashboard_Editor.Template_Image_ThumbnailFile == null)
                    {
                        varTemplate_Dashboard_Editor.Template_Image_Thumbnail = 0;
                    }

                    if (varTemplate_Dashboard_Editor.Template_Image_ThumbnailFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varTemplate_Dashboard_Editor.Template_Image_ThumbnailFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varTemplate_Dashboard_Editor.Template_Image_Thumbnail = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varTemplate_Dashboard_Editor.Template_Image_ThumbnailFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                    
                    var result = "";
                    var Template_Dashboard_EditorInfo = new Template_Dashboard_Editor
                    {
                        Template_Id = varTemplate_Dashboard_Editor.Template_Id
                        ,Description = varTemplate_Dashboard_Editor.Description
                        ,Template_Image_Thumbnail = (varTemplate_Dashboard_Editor.Template_Image_Thumbnail.HasValue && varTemplate_Dashboard_Editor.Template_Image_Thumbnail != 0) ? ((int?)Convert.ToInt32(varTemplate_Dashboard_Editor.Template_Image_Thumbnail.Value)) : null


                    };

                    result = !IsNew ?
                        _ITemplate_Dashboard_EditorApiConsumer.Update(Template_Dashboard_EditorInfo, null, null).Resource.ToString() :
                         _ITemplate_Dashboard_EditorApiConsumer.Insert(Template_Dashboard_EditorInfo, null, null).Resource.ToString();
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

        [NonAction]
        public bool CopyTemplate_Dashboard_Detail(int MasterId, int referenceId, List<Template_Dashboard_DetailGridModelPost> Template_Dashboard_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ITemplate_Dashboard_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Template_Dashboard_DetailData = _ITemplate_Dashboard_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Template_Dashboard_Detail.Template=" + referenceId,"").Resource;
                if (Template_Dashboard_DetailData == null || Template_Dashboard_DetailData.Template_Dashboard_Details.Count == 0)
                    return true;

                var result = true;

                Template_Dashboard_DetailGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varTemplate_Dashboard_Detail in Template_Dashboard_DetailData.Template_Dashboard_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Template_Dashboard_Detail Template_Dashboard_Detail1 = varTemplate_Dashboard_Detail;

                    if (Template_Dashboard_DetailItems != null && Template_Dashboard_DetailItems.Any(m => m.Detail_Id == Template_Dashboard_Detail1.Detail_Id))
                    {
                        modelDataToChange = Template_Dashboard_DetailItems.FirstOrDefault(m => m.Detail_Id == Template_Dashboard_Detail1.Detail_Id);
                    }
                    //Chaning Id Value
                    varTemplate_Dashboard_Detail.Template = MasterId;
                    var insertId = _ITemplate_Dashboard_DetailApiConsumer.Insert(varTemplate_Dashboard_Detail,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.Detail_Id = insertId;

                    result = insertId > 0;
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult PostTemplate_Dashboard_Detail(List<Template_Dashboard_DetailGridModelPost> Template_Dashboard_DetailItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyTemplate_Dashboard_Detail(MasterId, referenceId, Template_Dashboard_DetailItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Template_Dashboard_DetailItems != null && Template_Dashboard_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ITemplate_Dashboard_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Template_Dashboard_DetailItem in Template_Dashboard_DetailItems)
                    {

                        //Removal Request
                        if (Template_Dashboard_DetailItem.Removed)
                        {
                            result = result && _ITemplate_Dashboard_DetailApiConsumer.Delete(Template_Dashboard_DetailItem.Detail_Id, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Template_Dashboard_DetailItem.Detail_Id = 0;

                        var Template_Dashboard_DetailData = new Template_Dashboard_Detail
                        {
                            Template = MasterId
                            ,Detail_Id = Template_Dashboard_DetailItem.Detail_Id
                            ,Row_Number = Template_Dashboard_DetailItem.Row_Number
                            ,Columns = Template_Dashboard_DetailItem.Columns

                        };

                        var resultId = Template_Dashboard_DetailItem.Detail_Id > 0
                           ? _ITemplate_Dashboard_DetailApiConsumer.Update(Template_Dashboard_DetailData,null,null).Resource
                           : _ITemplate_Dashboard_DetailApiConsumer.Insert(Template_Dashboard_DetailData,null,null).Resource;

                        result = result && resultId != -1;
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }




        /// <summary>
        /// Write Element Array of Template_Dashboard_Editor script
        /// </summary>
        /// <param name="oTemplate_Dashboard_EditorElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Template_Dashboard_EditorModuleAttributeList)
        {
            for (int i = 0; i < Template_Dashboard_EditorModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Template_Dashboard_EditorModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Template_Dashboard_EditorModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Template_Dashboard_EditorModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Template_Dashboard_EditorModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Template_Dashboard_EditorModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Template_Dashboard_EditorModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Template_Dashboard_EditorModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Template_Dashboard_EditorModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Template_Dashboard_EditorModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Template_Dashboard_EditorModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Template_Dashboard_EditorModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strTemplate_Dashboard_EditorScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Template_Dashboard_Editor.js")))
            {
                strTemplate_Dashboard_EditorScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Template_Dashboard_Editor element attributes
            string userChangeJson = jsSerialize.Serialize(Template_Dashboard_EditorModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strTemplate_Dashboard_EditorScript.IndexOf("inpuElementArray");
            string splittedString = strTemplate_Dashboard_EditorScript.Substring(indexOfArray, strTemplate_Dashboard_EditorScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Template_Dashboard_EditorModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Template_Dashboard_EditorModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strTemplate_Dashboard_EditorScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strTemplate_Dashboard_EditorScript.Substring(indexOfArrayHistory, strTemplate_Dashboard_EditorScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strTemplate_Dashboard_EditorScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strTemplate_Dashboard_EditorScript.Substring(endIndexOfMainElement + indexOfArray, strTemplate_Dashboard_EditorScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Template_Dashboard_EditorModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Template_Dashboard_EditorModuleAttributeList.ChildModuleAttributeList)
                {
				if (item!= null && item.elements != null  && item.elements.Count>0)
                    ResponseChild += "\r\n  \n\r function set" + item.table + "Validation() { " +
                                    " \r\n var inpuElementChildArray =" + jsSerialize.Serialize(item.elements) + ";" +
                                    "  \r\n setInputEntityAttributes(inpuElementChildArray, \".\", 0);" +
                                    "  \r\n setDynamicRenderElement(); \n\r } ";

                }
            }
            finalResponse = finalResponse.Substring(0, finalResponse.IndexOf("});") + 4) +  "\n\r";
            finalResponse += ResponseChild;
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Template_Dashboard_Editor.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Template_Dashboard_Editor.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Template_Dashboard_Editor.js")))
                {
                    strCustomScript = r.ReadToEnd();
                
                }

                int indexOfArray = strCustomScript.IndexOf("inpuElementArray");
                string splittedString = strCustomScript.Substring(indexOfArray, strCustomScript.Length - indexOfArray);                
                int indexOfMainElement = splittedString.IndexOf('[');                
                int endIndexOfMainElement = splittedString.IndexOf(']') + 1;                
                string mainJsonArray = splittedString.Substring(indexOfMainElement, endIndexOfMainElement - indexOfMainElement);

                int indexOfChildArray = strCustomScript.IndexOf("function set");
                string childJsonArray = "[";
                if (indexOfChildArray != -1)
                {
                    string splittedChildString = strCustomScript.Substring(indexOfChildArray, strCustomScript.Length - indexOfChildArray);

                    var funcionsValidations = splittedChildString.Split(new string[] { "function" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var str in funcionsValidations)
                    {
                        var tabla = str.Substring(0, str.IndexOf('('));
                        tabla = tabla.Trim().Replace("set", string.Empty).Replace("Validation", string.Empty);
                        childJsonArray += "{ \"table\": \"" + tabla + "\", \"elements\":";
                        int indexOfChildElement = str.IndexOf('[');
                        int endIndexOfChildElement = str.IndexOf(']') + 1;
                        childJsonArray += str.Substring(indexOfChildElement, endIndexOfChildElement - indexOfChildElement) + "},";
                    }
                }
                childJsonArray = childJsonArray.TrimEnd(',') + "]";
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
        public ActionResult Template_Dashboard_EditorPropertyBag()
        {
            return PartialView("Template_Dashboard_EditorPropertyBag", "Template_Dashboard_Editor");
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

        [HttpGet]
        public ActionResult AddTemplate_Dashboard_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Template_Dashboard_Detail/AddTemplate_Dashboard_Detail");
        }



        #endregion "Controller Methods"

        #region "Custom methods"
		
		[HttpGet]
        public FileStreamResult PrintFormats(int idFormat, string RecordId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _IGeneratePDFApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_FormatRelatedApiConsumer.SetAuthHeader(_tokenManager.Token);

            MemoryStream ms = new MemoryStream();
           
            //Buscar los Formatos Relacionados
            var relacionados = _ISpartan_FormatRelatedApiConsumer.ListaSelAll(0, 5000, "Spartan_Format_Related.FormatId = " + idFormat, "").Resource.Spartan_Format_Relateds.OrderBy(r => r.Order).ToList();
            if (relacionados.Count > 0)
            {
                var outputDocument = new iTextSharp.text.Document();
                var writer = new PdfCopy(outputDocument, ms);
                outputDocument.Open();
                foreach (var spartan_Format_Related in relacionados)
                {
                    var bytePdf = _IGeneratePDFApiConsumer.GeneratePDF(Convert.ToInt32(spartan_Format_Related.FormatId_Related), RecordId).Resource;
                    var reader = new PdfReader(bytePdf);
                    for (var j = 1; j <= reader.NumberOfPages; j++)
                    {
                        writer.AddPage(writer.GetImportedPage(reader, j));
                    }
                    writer.FreeReader(reader);
                    reader.Close();
                }
                writer.Close();
                outputDocument.Close();
                var allPagesContent = ms.GetBuffer();
                ms.Flush();
            }
            else {
                var bytePdf = _IGeneratePDFApiConsumer.GeneratePDF(idFormat, RecordId);
                ms.Write(bytePdf.Resource, 0, bytePdf.Resource.Length);           
            }
                
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
        public ActionResult GetFormats(string RecordId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            var formatList = new List<SelectListItem>();

            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_Format_PermissionsApiConsumer.SetAuthHeader(_tokenManager.Token);
           _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);

            var whereClause = " Spartan_Format_Permissions.Spartan_User_Role = " + SessionHelper.Role + " AND Spartan_Format_Permissions.Permission_Type = 1 AND Apply=1 ";
            var formatsPermisions = _ISpartan_Format_PermissionsApiConsumer.ListaSelAll(0, 500, whereClause, string.Empty).Resource;
            if (formatsPermisions.RowCount > 0)
            {
                var formats = string.Join(",", formatsPermisions.Spartan_Format_Permissionss.Select(f => f.Format).ToArray());
                var whereClauseFormat = "Object = 40143 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _ITemplate_Dashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Template_Id= " + RecordId;
                            var result = _ITemplate_Dashboard_EditorApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
                            if (result != null && result.Resource != null && result.Resource.RowCount > 0)
                            {
                                formatList.Add(new SelectListItem
                                {
                                    Text =  CultureHelper.GetTraductionAdd(format.FormatId.ToString(), "Format", format.Format_Name),
                                    Value = Convert.ToString(format.FormatId)
                                });
                            }
                        }
                        else
                        {
                            formatList.Add(new SelectListItem
                            {
                                Text =  CultureHelper.GetTraductionAdd(format.FormatId.ToString(), "Format", format.Format_Name),
                                Value = Convert.ToString(format.FormatId)
                            });
                        }


                    }
                }
            }
            return Json(formatList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public void Export(string format, int pageIndex, int pageSize, string iSortCol, string sSortDir)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return;

            _ITemplate_Dashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Template_Dashboard_EditorPropertyMapper());
			
            //Adding Advance Search
            if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Template_Dashboard_EditorAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Template_Dashboard_EditorPropertyMapper oTemplate_Dashboard_EditorPropertyMapper = new Template_Dashboard_EditorPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oTemplate_Dashboard_EditorPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ITemplate_Dashboard_EditorApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Template_Dashboard_Editors == null)
                result.Template_Dashboard_Editors = new List<Template_Dashboard_Editor>();

            var data = result.Template_Dashboard_Editors.Select(m => new Template_Dashboard_EditorGridModel
            {
                Template_Id = m.Template_Id
			,Description = m.Description
			,Template_Image_Thumbnail = m.Template_Image_Thumbnail

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Template_Dashboard_EditorList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Template_Dashboard_EditorList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "Template_Dashboard_EditorList_" + DateTime.Now.ToString());
                    break;
            }
        }

        [HttpGet]
        //[ObjectAuth(ObjectId = ModuleObjectId.EMPLEADOS_OBJECT, PermissionType = PermissionTypes.Export)]
        public ActionResult Print(string format, int pageIndex, int pageSize, string iSortCol, string sSortDir)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return null;

            _ITemplate_Dashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Template_Dashboard_EditorPropertyMapper());
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Template_Dashboard_EditorAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Template_Dashboard_EditorPropertyMapper oTemplate_Dashboard_EditorPropertyMapper = new Template_Dashboard_EditorPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oTemplate_Dashboard_EditorPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ITemplate_Dashboard_EditorApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Template_Dashboard_Editors == null)
                result.Template_Dashboard_Editors = new List<Template_Dashboard_Editor>();

            var data = result.Template_Dashboard_Editors.Select(m => new Template_Dashboard_EditorGridModel
            {
                Template_Id = m.Template_Id
			,Description = m.Description
			,Template_Image_Thumbnail = m.Template_Image_Thumbnail

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
		
		[HttpGet]
        public JsonResult CreateID()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITemplate_Dashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ITemplate_Dashboard_EditorApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Template_Dashboard_Editor_Datos_GeneralesModel varTemplate_Dashboard_Editor)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITemplate_Dashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
				                    if (varTemplate_Dashboard_Editor.Template_Image_ThumbnailRemoveAttachment != 0 && varTemplate_Dashboard_Editor.Template_Image_ThumbnailFile == null)
                    {
                        varTemplate_Dashboard_Editor.Template_Image_Thumbnail = 0;
                    }

                    if (varTemplate_Dashboard_Editor.Template_Image_ThumbnailFile != null)
                    {
                        var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varTemplate_Dashboard_Editor.Template_Image_ThumbnailFile);
                        _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                        varTemplate_Dashboard_Editor.Template_Image_Thumbnail = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                        {
                            File = fileAsBytes,
                            Description = varTemplate_Dashboard_Editor.Template_Image_ThumbnailFile.FileName,
                            File_Size = fileAsBytes.Length
                        }).Resource;
                    }

                var result = "";
                var Template_Dashboard_Editor_Datos_GeneralesInfo = new Template_Dashboard_Editor_Datos_Generales
                {
                    Template_Id = varTemplate_Dashboard_Editor.Template_Id
                                            ,Description = varTemplate_Dashboard_Editor.Description
                        ,Template_Image_Thumbnail = (varTemplate_Dashboard_Editor.Template_Image_Thumbnail.HasValue && varTemplate_Dashboard_Editor.Template_Image_Thumbnail != 0) ? ((int?)Convert.ToInt32(varTemplate_Dashboard_Editor.Template_Image_Thumbnail.Value)) : null

                    
                };

                result = _ITemplate_Dashboard_EditorApiConsumer.Update_Datos_Generales(Template_Dashboard_Editor_Datos_GeneralesInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Datos_Generales(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ITemplate_Dashboard_EditorApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _ITemplate_Dashboard_EditorApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Template_Dashboard_Detail;
                var Template_Dashboard_DetailData = GetTemplate_Dashboard_DetailData(Id.ToString(), 0, 10, out RowCount_Template_Dashboard_Detail);

                var result = new Template_Dashboard_Editor_Datos_GeneralesModel
                {
                    Template_Id = m.Template_Id
			,Description = m.Description
			,Template_Image_Thumbnail = m.Template_Image_Thumbnail

                    
                };
				var resultData = new
                {
                    data = result
                    ,Detail = Template_Dashboard_DetailData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

