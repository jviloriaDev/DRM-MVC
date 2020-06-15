using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_Report_Fields_Detail;
using Spartane.Core.Domain.Spartan_Report_Function;
using Spartane.Core.Domain.Spartan_Report_Format;
using Spartane.Core.Domain.Spartan_Report_Order_Type;
using Spartane.Core.Domain.Spartan_Report_Field_Type;
using Spartane.Core.Domain.Spartan_Metadata;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_Report_Fields_Detail;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Fields_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Function;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Order_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Report_Field_Type;
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
    public class Spartan_Report_Fields_DetailController : Controller
    {
        #region "variable declaration"

        private ISpartan_Report_Fields_DetailService service = null;
        private ISpartan_Report_Fields_DetailApiConsumer _ISpartan_Report_Fields_DetailApiConsumer;
        private ISpartan_Report_FunctionApiConsumer _ISpartan_Report_FunctionApiConsumer;
        private ISpartan_Report_FormatApiConsumer _ISpartan_Report_FormatApiConsumer;
        private ISpartan_Report_Order_TypeApiConsumer _ISpartan_Report_Order_TypeApiConsumer;
        private ISpartan_Report_Field_TypeApiConsumer _ISpartan_Report_Field_TypeApiConsumer;
        private ISpartan_MetadataApiConsumer _ISpartan_MetadataApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Spartan_Report_Fields_DetailController(ISpartan_Report_Fields_DetailService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_Report_Fields_DetailApiConsumer Spartan_Report_Fields_DetailApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ISpartan_Report_FunctionApiConsumer Spartan_Report_FunctionApiConsumer , ISpartan_Report_FormatApiConsumer Spartan_Report_FormatApiConsumer , ISpartan_Report_Order_TypeApiConsumer Spartan_Report_Order_TypeApiConsumer , ISpartan_Report_Field_TypeApiConsumer Spartan_Report_Field_TypeApiConsumer , ISpartan_MetadataApiConsumer Spartan_MetadataApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_Report_Fields_DetailApiConsumer = Spartan_Report_Fields_DetailApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_Report_FunctionApiConsumer = Spartan_Report_FunctionApiConsumer;
            this._ISpartan_Report_FormatApiConsumer = Spartan_Report_FormatApiConsumer;
            this._ISpartan_Report_Order_TypeApiConsumer = Spartan_Report_Order_TypeApiConsumer;
            this._ISpartan_Report_Field_TypeApiConsumer = Spartan_Report_Field_TypeApiConsumer;
            this._ISpartan_MetadataApiConsumer = Spartan_MetadataApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_Report_Fields_Detail
        [ObjectAuth(ObjectId = (ModuleObjectId)34553, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 34553);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Spartan_Report_Fields_Detail/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)34553, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 34553);
            ViewBag.Permission = permission;
            var varSpartan_Report_Fields_Detail = new Spartan_Report_Fields_DetailModel();
			
            ViewBag.ObjectId = "34553";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_Fields_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_Report_Fields_DetailData = _ISpartan_Report_Fields_DetailApiConsumer.GetByKeyComplete(Id).Resource.Spartan_Report_Fields_Details[0];
                if (Spartan_Report_Fields_DetailData == null)
                    return HttpNotFound();

                varSpartan_Report_Fields_Detail = new Spartan_Report_Fields_DetailModel
                {
                    DesignDetailId = (int)Spartan_Report_Fields_DetailData.DesignDetailId
                    ,PathField = Spartan_Report_Fields_DetailData.PathField
                    ,Physical_Name = Spartan_Report_Fields_DetailData.Physical_Name
                    ,Title = Spartan_Report_Fields_DetailData.Title
                    ,Function = Spartan_Report_Fields_DetailData.Function
                    ,FunctionDescription =  (string)Spartan_Report_Fields_DetailData.Function_Spartan_Report_Function.Description
                    ,Format = Spartan_Report_Fields_DetailData.Format
                    ,FormatDescription =  (string)Spartan_Report_Fields_DetailData.Format_Spartan_Report_Format.Description
                    ,Order_Type = Spartan_Report_Fields_DetailData.Order_Type
                    ,Order_TypeDescription =  (string)Spartan_Report_Fields_DetailData.Order_Type_Spartan_Report_Order_Type.Description
                    ,Field_Type = Spartan_Report_Fields_DetailData.Field_Type
                    ,Field_TypeDescription =  (string)Spartan_Report_Fields_DetailData.Field_Type_Spartan_Report_Field_Type.Description
                    ,Order_Number = Spartan_Report_Fields_DetailData.Order_Number
                    ,AttributeId = Spartan_Report_Fields_DetailData.AttributeId
                    ,AttributeIdLogical_Name =  (string)Spartan_Report_Fields_DetailData.AttributeId_Spartan_Metadata.Logical_Name

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Report_FunctionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Functions_Function = _ISpartan_Report_FunctionApiConsumer.SelAll(true);
            if (Spartan_Report_Functions_Function != null && Spartan_Report_Functions_Function.Resource != null)
                ViewBag.Spartan_Report_Functions_Function = Spartan_Report_Functions_Function.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.FunctionId)
                }).ToList();
            _ISpartan_Report_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Formats_Format = _ISpartan_Report_FormatApiConsumer.SelAll(true);
            if (Spartan_Report_Formats_Format != null && Spartan_Report_Formats_Format.Resource != null)
                ViewBag.Spartan_Report_Formats_Format = Spartan_Report_Formats_Format.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.FormatId)
                }).ToList();
            _ISpartan_Report_Order_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Order_Types_Order_Type = _ISpartan_Report_Order_TypeApiConsumer.SelAll(true);
            if (Spartan_Report_Order_Types_Order_Type != null && Spartan_Report_Order_Types_Order_Type.Resource != null)
                ViewBag.Spartan_Report_Order_Types_Order_Type = Spartan_Report_Order_Types_Order_Type.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.OrderTypeId)
                }).ToList();
            _ISpartan_Report_Field_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Field_Types_Field_Type = _ISpartan_Report_Field_TypeApiConsumer.SelAll(true);
            if (Spartan_Report_Field_Types_Field_Type != null && Spartan_Report_Field_Types_Field_Type.Resource != null)
                ViewBag.Spartan_Report_Field_Types_Field_Type = Spartan_Report_Field_Types_Field_Type.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.FieldTypeId)
                }).ToList();
            _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Metadatas_AttributeId = _ISpartan_MetadataApiConsumer.SelAll(true);
            if (Spartan_Metadatas_AttributeId != null && Spartan_Metadatas_AttributeId.Resource != null)
                ViewBag.Spartan_Metadatas_AttributeId = Spartan_Metadatas_AttributeId.Resource.OrderBy(m => m.Logical_Name).Select(m => new SelectListItem
                {
                    Text = m.Logical_Name.ToString(), Value = Convert.ToString(m.AttributeId)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_Report_Fields_Detail);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_Report_Fields_Detail(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 34553);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_Report_Fields_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_Report_Fields_DetailModel varSpartan_Report_Fields_Detail= new Spartan_Report_Fields_DetailModel();


            if (id.ToString() != "0")
            {
                var Spartan_Report_Fields_DetailsData = _ISpartan_Report_Fields_DetailApiConsumer.ListaSelAll(0, 1000, "Spartan_Report_Fields_Detail.DesignDetailId=" + id, "").Resource.Spartan_Report_Fields_Details;
				
				if (Spartan_Report_Fields_DetailsData != null && Spartan_Report_Fields_DetailsData.Count > 0)
                {
					var Spartan_Report_Fields_DetailData = Spartan_Report_Fields_DetailsData.First();
					varSpartan_Report_Fields_Detail= new Spartan_Report_Fields_DetailModel
					{
						DesignDetailId  = Spartan_Report_Fields_DetailData.DesignDetailId 
	                    ,PathField = Spartan_Report_Fields_DetailData.PathField
                    ,Physical_Name = Spartan_Report_Fields_DetailData.Physical_Name
                    ,Title = Spartan_Report_Fields_DetailData.Title
                    ,Function = Spartan_Report_Fields_DetailData.Function
                    ,FunctionDescription =  (string)Spartan_Report_Fields_DetailData.Function_Spartan_Report_Function.Description
                    ,Format = Spartan_Report_Fields_DetailData.Format
                    ,FormatDescription =  (string)Spartan_Report_Fields_DetailData.Format_Spartan_Report_Format.Description
                    ,Order_Type = Spartan_Report_Fields_DetailData.Order_Type
                    ,Order_TypeDescription =  (string)Spartan_Report_Fields_DetailData.Order_Type_Spartan_Report_Order_Type.Description
                    ,Field_Type = Spartan_Report_Fields_DetailData.Field_Type
                    ,Field_TypeDescription =  (string)Spartan_Report_Fields_DetailData.Field_Type_Spartan_Report_Field_Type.Description
                    ,Order_Number = Spartan_Report_Fields_DetailData.Order_Number
                    ,AttributeId = Spartan_Report_Fields_DetailData.AttributeId
                    ,AttributeIdLogical_Name =  (string)Spartan_Report_Fields_DetailData.AttributeId_Spartan_Metadata.Logical_Name

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_Report_FunctionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Functions_Function = _ISpartan_Report_FunctionApiConsumer.SelAll(true);
            if (Spartan_Report_Functions_Function != null && Spartan_Report_Functions_Function.Resource != null)
                ViewBag.Spartan_Report_Functions_Function = Spartan_Report_Functions_Function.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.FunctionId)
                }).ToList();
            _ISpartan_Report_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Formats_Format = _ISpartan_Report_FormatApiConsumer.SelAll(true);
            if (Spartan_Report_Formats_Format != null && Spartan_Report_Formats_Format.Resource != null)
                ViewBag.Spartan_Report_Formats_Format = Spartan_Report_Formats_Format.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.FormatId)
                }).ToList();
            _ISpartan_Report_Order_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Order_Types_Order_Type = _ISpartan_Report_Order_TypeApiConsumer.SelAll(true);
            if (Spartan_Report_Order_Types_Order_Type != null && Spartan_Report_Order_Types_Order_Type.Resource != null)
                ViewBag.Spartan_Report_Order_Types_Order_Type = Spartan_Report_Order_Types_Order_Type.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.OrderTypeId)
                }).ToList();
            _ISpartan_Report_Field_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Report_Field_Types_Field_Type = _ISpartan_Report_Field_TypeApiConsumer.SelAll(true);
            if (Spartan_Report_Field_Types_Field_Type != null && Spartan_Report_Field_Types_Field_Type.Resource != null)
                ViewBag.Spartan_Report_Field_Types_Field_Type = Spartan_Report_Field_Types_Field_Type.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.FieldTypeId)
                }).ToList();
            _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Metadatas_AttributeId = _ISpartan_MetadataApiConsumer.SelAll(true);
            if (Spartan_Metadatas_AttributeId != null && Spartan_Metadatas_AttributeId.Resource != null)
                ViewBag.Spartan_Metadatas_AttributeId = Spartan_Metadatas_AttributeId.Resource.OrderBy(m => m.Logical_Name).Select(m => new SelectListItem
                {
                    Text = m.Logical_Name.ToString(), Value = Convert.ToString(m.AttributeId)
                }).ToList();


            return PartialView("AddSpartan_Report_Fields_Detail", varSpartan_Report_Fields_Detail);
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
        public ActionResult GetSpartan_Report_FunctionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_FunctionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Report_FunctionApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_Report_FormatAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Report_FormatApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_Report_Order_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_Order_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Report_Order_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_Report_Field_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Report_Field_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_Report_Field_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Report_Fields_DetailPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_Report_Fields_DetailApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Report_Fields_Details == null)
                result.Spartan_Report_Fields_Details = new List<Spartan_Report_Fields_Detail>();

            return Json(new
            {
                data = result.Spartan_Report_Fields_Details.Select(m => new Spartan_Report_Fields_DetailGridModel
                    {
                    DesignDetailId = m.DesignDetailId
			,PathField = m.PathField
			,Physical_Name = m.Physical_Name
			,Title = m.Title
                        ,FunctionDescription = (string)m.Function_Spartan_Report_Function.Description
                        ,FormatDescription = (string)m.Format_Spartan_Report_Format.Description
                        ,Order_TypeDescription = (string)m.Order_Type_Spartan_Report_Order_Type.Description
                        ,Field_TypeDescription = (string)m.Field_Type_Spartan_Report_Field_Type.Description
			,Order_Number = m.Order_Number
                        ,AttributeIdLogical_Name = (string)m.AttributeId_Spartan_Metadata.Logical_Name

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
                _ISpartan_Report_Fields_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                Spartan_Report_Fields_Detail varSpartan_Report_Fields_Detail = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _ISpartan_Report_Fields_DetailApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_Report_Fields_DetailModel varSpartan_Report_Fields_Detail)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_Report_Fields_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Spartan_Report_Fields_DetailInfo = new Spartan_Report_Fields_Detail
                    {
                        DesignDetailId = varSpartan_Report_Fields_Detail.DesignDetailId
                        ,PathField = varSpartan_Report_Fields_Detail.PathField
                        ,Physical_Name = varSpartan_Report_Fields_Detail.Physical_Name
                        ,Title = varSpartan_Report_Fields_Detail.Title
                        ,Function = varSpartan_Report_Fields_Detail.Function
                        ,Format = varSpartan_Report_Fields_Detail.Format
                        ,Order_Type = varSpartan_Report_Fields_Detail.Order_Type
                        ,Field_Type = varSpartan_Report_Fields_Detail.Field_Type
                        ,Order_Number = varSpartan_Report_Fields_Detail.Order_Number
                        ,AttributeId = varSpartan_Report_Fields_Detail.AttributeId

                    };

                    result = !IsNew ?
                        _ISpartan_Report_Fields_DetailApiConsumer.Update(Spartan_Report_Fields_DetailInfo, null, null).Resource.ToString() :
                         _ISpartan_Report_Fields_DetailApiConsumer.Insert(Spartan_Report_Fields_DetailInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Spartan_Report_Fields_Detail script
        /// </summary>
        /// <param name="oSpartan_Report_Fields_DetailElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_Report_Fields_DetailModuleAttributeList)
        {
            for (int i = 0; i < Spartan_Report_Fields_DetailModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_Report_Fields_DetailModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_Report_Fields_DetailModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_Report_Fields_DetailModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_Report_Fields_DetailModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_Report_Fields_DetailModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_Report_Fields_DetailModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Spartan_Report_Fields_DetailModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Spartan_Report_Fields_DetailModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Spartan_Report_Fields_DetailModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Spartan_Report_Fields_DetailModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strSpartan_Report_Fields_DetailScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Report_Fields_Detail.js")))
            {
                strSpartan_Report_Fields_DetailScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_Report_Fields_Detail element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_Report_Fields_DetailModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_Report_Fields_DetailScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_Report_Fields_DetailScript.Substring(indexOfArray, strSpartan_Report_Fields_DetailScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_Report_Fields_DetailModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_Report_Fields_DetailModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_Report_Fields_DetailScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strSpartan_Report_Fields_DetailScript.Substring(indexOfArrayHistory, strSpartan_Report_Fields_DetailScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strSpartan_Report_Fields_DetailScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_Report_Fields_DetailScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_Report_Fields_DetailScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Spartan_Report_Fields_DetailModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strSpartan_Report_Fields_DetailScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_Report_Fields_DetailScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_Report_Fields_DetailScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_Report_Fields_DetailScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_Report_Fields_Detail.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_Report_Fields_Detail.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_Report_Fields_Detail.js")))
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
        public ActionResult Spartan_Report_Fields_DetailPropertyBag()
        {
            return PartialView("Spartan_Report_Fields_DetailPropertyBag", "Spartan_Report_Fields_Detail");
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

            _ISpartan_Report_Fields_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Report_Fields_DetailPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Report_Fields_DetailApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Report_Fields_Details == null)
                result.Spartan_Report_Fields_Details = new List<Spartan_Report_Fields_Detail>();

            var data = result.Spartan_Report_Fields_Details.Select(m => new Spartan_Report_Fields_DetailGridModel
            {
                DesignDetailId = m.DesignDetailId
                ,PathField = m.PathField
                ,Physical_Name = m.Physical_Name
                ,Title = m.Title
                ,Order_Number = m.Order_Number

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_Report_Fields_DetailList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_Report_Fields_DetailList_" + DateTime.Now.ToString());
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

            _ISpartan_Report_Fields_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_Report_Fields_DetailPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_Report_Fields_DetailApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_Report_Fields_Details == null)
                result.Spartan_Report_Fields_Details = new List<Spartan_Report_Fields_Detail>();

            var data = result.Spartan_Report_Fields_Details.Select(m => new Spartan_Report_Fields_DetailGridModel
            {
                DesignDetailId = m.DesignDetailId
                ,PathField = m.PathField
                ,Physical_Name = m.Physical_Name
                ,Title = m.Title
                ,Order_Number = m.Order_Number

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
