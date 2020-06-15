using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_WorkFlow_Phases;
using Spartane.Core.Domain.Spartan_WorkFlow_Phase_Type;
using Spartane.Core.Domain.Spartan_WorkFlow_Type_Work_Distribution;
using Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control;
using Spartane.Core.Domain.Spartan_WorkFlow_Phase_Status;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_WorkFlow_Phases;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phases;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phase_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Type_Work_Distribution;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Type_Flow_Control;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phase_Status;

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
    public class Spartan_WorkFlow_PhasesController : Controller
    {
        #region "variable declaration"

        private ISpartan_WorkFlow_PhasesService service = null;
        private ISpartan_WorkFlow_PhasesApiConsumer _ISpartan_WorkFlow_PhasesApiConsumer;
        private ISpartan_WorkFlow_Phase_TypeApiConsumer _ISpartan_WorkFlow_Phase_TypeApiConsumer;
        private ISpartan_WorkFlow_Type_Work_DistributionApiConsumer _ISpartan_WorkFlow_Type_Work_DistributionApiConsumer;
        private ISpartan_WorkFlow_Type_Flow_ControlApiConsumer _ISpartan_WorkFlow_Type_Flow_ControlApiConsumer;
        private ISpartan_WorkFlow_Phase_StatusApiConsumer _ISpartan_WorkFlow_Phase_StatusApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Spartan_WorkFlow_PhasesController(ISpartan_WorkFlow_PhasesService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_WorkFlow_PhasesApiConsumer Spartan_WorkFlow_PhasesApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , ISpartan_WorkFlow_Phase_TypeApiConsumer Spartan_WorkFlow_Phase_TypeApiConsumer , ISpartan_WorkFlow_Type_Work_DistributionApiConsumer Spartan_WorkFlow_Type_Work_DistributionApiConsumer , ISpartan_WorkFlow_Type_Flow_ControlApiConsumer Spartan_WorkFlow_Type_Flow_ControlApiConsumer , ISpartan_WorkFlow_Phase_StatusApiConsumer Spartan_WorkFlow_Phase_StatusApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_WorkFlow_PhasesApiConsumer = Spartan_WorkFlow_PhasesApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_WorkFlow_Phase_TypeApiConsumer = Spartan_WorkFlow_Phase_TypeApiConsumer;
            this._ISpartan_WorkFlow_Type_Work_DistributionApiConsumer = Spartan_WorkFlow_Type_Work_DistributionApiConsumer;
            this._ISpartan_WorkFlow_Type_Flow_ControlApiConsumer = Spartan_WorkFlow_Type_Flow_ControlApiConsumer;
            this._ISpartan_WorkFlow_Phase_StatusApiConsumer = Spartan_WorkFlow_Phase_StatusApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_WorkFlow_Phases
        [ObjectAuth(ObjectId = (ModuleObjectId)122, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 122);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Spartan_WorkFlow_Phases/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)122, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 122);
            ViewBag.Permission = permission;
            var varSpartan_WorkFlow_Phases = new Spartan_WorkFlow_PhasesModel();
			
            ViewBag.ObjectId = "122";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_WorkFlow_PhasesData = _ISpartan_WorkFlow_PhasesApiConsumer.GetByKeyComplete(Id).Resource.Spartan_WorkFlow_Phasess[0];
                if (Spartan_WorkFlow_PhasesData == null)
                    return HttpNotFound();

                varSpartan_WorkFlow_Phases = new Spartan_WorkFlow_PhasesModel
                {
                    PhasesId = (int)Spartan_WorkFlow_PhasesData.PhasesId
                    ,Phase_Number = Spartan_WorkFlow_PhasesData.Phase_Number
                    ,Name = Spartan_WorkFlow_PhasesData.Name
                    ,Phase_Type = Spartan_WorkFlow_PhasesData.Phase_Type
                    ,Phase_TypeDescription =  (string)Spartan_WorkFlow_PhasesData.Phase_Type_Spartan_WorkFlow_Phase_Type.Description
                    ,Type_of_Work_Distribution = Spartan_WorkFlow_PhasesData.Type_of_Work_Distribution
                    ,Type_of_Work_DistributionDescription =  (string)Spartan_WorkFlow_PhasesData.Type_of_Work_Distribution_Spartan_WorkFlow_Type_Work_Distribution.Description
                    ,Type_Flow_Control = Spartan_WorkFlow_PhasesData.Type_Flow_Control
                    ,Type_Flow_ControlDescription =  (string)Spartan_WorkFlow_PhasesData.Type_Flow_Control_Spartan_WorkFlow_Type_Flow_Control.Description
                    ,Phase_Status = Spartan_WorkFlow_PhasesData.Phase_Status
                    ,Phase_StatusDescription =  (string)Spartan_WorkFlow_PhasesData.Phase_Status_Spartan_WorkFlow_Phase_Status.Description

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_WorkFlow_Phase_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_WorkFlow_Phase_Types_Phase_Type = _ISpartan_WorkFlow_Phase_TypeApiConsumer.SelAll(true);
            if (Spartan_WorkFlow_Phase_Types_Phase_Type != null && Spartan_WorkFlow_Phase_Types_Phase_Type.Resource != null)
                ViewBag.Spartan_WorkFlow_Phase_Types_Phase_Type = Spartan_WorkFlow_Phase_Types_Phase_Type.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.Phase_TypeId)
                }).ToList();
            _ISpartan_WorkFlow_Type_Work_DistributionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_WorkFlow_Type_Work_Distributions_Type_of_Work_Distribution = _ISpartan_WorkFlow_Type_Work_DistributionApiConsumer.SelAll(true);
            if (Spartan_WorkFlow_Type_Work_Distributions_Type_of_Work_Distribution != null && Spartan_WorkFlow_Type_Work_Distributions_Type_of_Work_Distribution.Resource != null)
                ViewBag.Spartan_WorkFlow_Type_Work_Distributions_Type_of_Work_Distribution = Spartan_WorkFlow_Type_Work_Distributions_Type_of_Work_Distribution.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.Type_of_Work_DistributionId)
                }).ToList();
            _ISpartan_WorkFlow_Type_Flow_ControlApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_WorkFlow_Type_Flow_Controls_Type_Flow_Control = _ISpartan_WorkFlow_Type_Flow_ControlApiConsumer.SelAll(true);
            if (Spartan_WorkFlow_Type_Flow_Controls_Type_Flow_Control != null && Spartan_WorkFlow_Type_Flow_Controls_Type_Flow_Control.Resource != null)
                ViewBag.Spartan_WorkFlow_Type_Flow_Controls_Type_Flow_Control = Spartan_WorkFlow_Type_Flow_Controls_Type_Flow_Control.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.Type_Flow_ControlId)
                }).ToList();
            _ISpartan_WorkFlow_Phase_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_WorkFlow_Phase_Statuss_Phase_Status = _ISpartan_WorkFlow_Phase_StatusApiConsumer.SelAll(true);
            if (Spartan_WorkFlow_Phase_Statuss_Phase_Status != null && Spartan_WorkFlow_Phase_Statuss_Phase_Status.Resource != null)
                ViewBag.Spartan_WorkFlow_Phase_Statuss_Phase_Status = Spartan_WorkFlow_Phase_Statuss_Phase_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.StatusId)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_WorkFlow_Phases);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_WorkFlow_Phases(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 122);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_WorkFlow_PhasesModel varSpartan_WorkFlow_Phases= new Spartan_WorkFlow_PhasesModel();


            if (id.ToString() != "0")
            {
                var Spartan_WorkFlow_PhasessData = _ISpartan_WorkFlow_PhasesApiConsumer.ListaSelAll(0, 1000, "PhasesId=" + id, "").Resource.Spartan_WorkFlow_Phasess;
				
				if (Spartan_WorkFlow_PhasessData != null && Spartan_WorkFlow_PhasessData.Count > 0)
                {
					var Spartan_WorkFlow_PhasesData = Spartan_WorkFlow_PhasessData.First();
					varSpartan_WorkFlow_Phases= new Spartan_WorkFlow_PhasesModel
					{
						PhasesId  = Spartan_WorkFlow_PhasesData.PhasesId 
	                    ,Phase_Number = Spartan_WorkFlow_PhasesData.Phase_Number
                    ,Name = Spartan_WorkFlow_PhasesData.Name
                    ,Phase_Type = Spartan_WorkFlow_PhasesData.Phase_Type
                    ,Phase_TypeDescription =  (string)Spartan_WorkFlow_PhasesData.Phase_Type_Spartan_WorkFlow_Phase_Type.Description
                    ,Type_of_Work_Distribution = Spartan_WorkFlow_PhasesData.Type_of_Work_Distribution
                    ,Type_of_Work_DistributionDescription =  (string)Spartan_WorkFlow_PhasesData.Type_of_Work_Distribution_Spartan_WorkFlow_Type_Work_Distribution.Description
                    ,Type_Flow_Control = Spartan_WorkFlow_PhasesData.Type_Flow_Control
                    ,Type_Flow_ControlDescription =  (string)Spartan_WorkFlow_PhasesData.Type_Flow_Control_Spartan_WorkFlow_Type_Flow_Control.Description
                    ,Phase_Status = Spartan_WorkFlow_PhasesData.Phase_Status
                    ,Phase_StatusDescription =  (string)Spartan_WorkFlow_PhasesData.Phase_Status_Spartan_WorkFlow_Phase_Status.Description

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_WorkFlow_Phase_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_WorkFlow_Phase_Types_Phase_Type = _ISpartan_WorkFlow_Phase_TypeApiConsumer.SelAll(true);
            if (Spartan_WorkFlow_Phase_Types_Phase_Type != null && Spartan_WorkFlow_Phase_Types_Phase_Type.Resource != null)
                ViewBag.Spartan_WorkFlow_Phase_Types_Phase_Type = Spartan_WorkFlow_Phase_Types_Phase_Type.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.Phase_TypeId)
                }).ToList();
            _ISpartan_WorkFlow_Type_Work_DistributionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_WorkFlow_Type_Work_Distributions_Type_of_Work_Distribution = _ISpartan_WorkFlow_Type_Work_DistributionApiConsumer.SelAll(true);
            if (Spartan_WorkFlow_Type_Work_Distributions_Type_of_Work_Distribution != null && Spartan_WorkFlow_Type_Work_Distributions_Type_of_Work_Distribution.Resource != null)
                ViewBag.Spartan_WorkFlow_Type_Work_Distributions_Type_of_Work_Distribution = Spartan_WorkFlow_Type_Work_Distributions_Type_of_Work_Distribution.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.Type_of_Work_DistributionId)
                }).ToList();
            _ISpartan_WorkFlow_Type_Flow_ControlApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_WorkFlow_Type_Flow_Controls_Type_Flow_Control = _ISpartan_WorkFlow_Type_Flow_ControlApiConsumer.SelAll(true);
            if (Spartan_WorkFlow_Type_Flow_Controls_Type_Flow_Control != null && Spartan_WorkFlow_Type_Flow_Controls_Type_Flow_Control.Resource != null)
                ViewBag.Spartan_WorkFlow_Type_Flow_Controls_Type_Flow_Control = Spartan_WorkFlow_Type_Flow_Controls_Type_Flow_Control.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.Type_Flow_ControlId)
                }).ToList();
            _ISpartan_WorkFlow_Phase_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_WorkFlow_Phase_Statuss_Phase_Status = _ISpartan_WorkFlow_Phase_StatusApiConsumer.SelAll(true);
            if (Spartan_WorkFlow_Phase_Statuss_Phase_Status != null && Spartan_WorkFlow_Phase_Statuss_Phase_Status.Resource != null)
                ViewBag.Spartan_WorkFlow_Phase_Statuss_Phase_Status = Spartan_WorkFlow_Phase_Statuss_Phase_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.StatusId)
                }).ToList();


            return PartialView("AddSpartan_WorkFlow_Phases", varSpartan_WorkFlow_Phases);
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
        public ActionResult GetSpartan_WorkFlow_Phase_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_Phase_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_WorkFlow_Phase_TypeApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_Type_Work_DistributionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_Type_Work_DistributionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_WorkFlow_Type_Work_DistributionApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_Type_Flow_ControlAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_Type_Flow_ControlApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_WorkFlow_Type_Flow_ControlApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_Phase_StatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_Phase_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_WorkFlow_Phase_StatusApiConsumer.SelAll(false).Resource;
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_WorkFlow_PhasesPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_WorkFlow_PhasesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_WorkFlow_Phasess == null)
                result.Spartan_WorkFlow_Phasess = new List<Spartan_WorkFlow_Phases>();

            return Json(new
            {
                data = result.Spartan_WorkFlow_Phasess.Select(m => new Spartan_WorkFlow_PhasesGridModel
                    {
                    PhasesId = m.PhasesId
			,Phase_Number = m.Phase_Number
			,Name = m.Name
                        ,Phase_TypeDescription = (string)m.Phase_Type_Spartan_WorkFlow_Phase_Type.Description
                        ,Type_of_Work_DistributionDescription = (string)m.Type_of_Work_Distribution_Spartan_WorkFlow_Type_Work_Distribution.Description
                        ,Type_Flow_ControlDescription = (string)m.Type_Flow_Control_Spartan_WorkFlow_Type_Flow_Control.Description
                        ,Phase_StatusDescription = (string)m.Phase_Status_Spartan_WorkFlow_Phase_Status.Description

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
                _ISpartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);

                Spartan_WorkFlow_Phases varSpartan_WorkFlow_Phases = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _ISpartan_WorkFlow_PhasesApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_WorkFlow_PhasesModel varSpartan_WorkFlow_Phases)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Spartan_WorkFlow_PhasesInfo = new Spartan_WorkFlow_Phases
                    {
                        PhasesId = varSpartan_WorkFlow_Phases.PhasesId
                        ,Phase_Number = varSpartan_WorkFlow_Phases.Phase_Number
                        ,Name = varSpartan_WorkFlow_Phases.Name
                        ,Phase_Type = varSpartan_WorkFlow_Phases.Phase_Type
                        ,Type_of_Work_Distribution = varSpartan_WorkFlow_Phases.Type_of_Work_Distribution
                        ,Type_Flow_Control = varSpartan_WorkFlow_Phases.Type_Flow_Control
                        ,Phase_Status = varSpartan_WorkFlow_Phases.Phase_Status

                    };

                    result = !IsNew ?
                        _ISpartan_WorkFlow_PhasesApiConsumer.Update(Spartan_WorkFlow_PhasesInfo, null, null).Resource.ToString() :
                         _ISpartan_WorkFlow_PhasesApiConsumer.Insert(Spartan_WorkFlow_PhasesInfo, null, null).Resource.ToString();

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
        /// Write Element Array of Spartan_WorkFlow_Phases script
        /// </summary>
        /// <param name="oSpartan_WorkFlow_PhasesElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Spartan_WorkFlow_PhasesModuleAttributeList)
        {
            for (int i = 0; i < Spartan_WorkFlow_PhasesModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_WorkFlow_PhasesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_WorkFlow_PhasesModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_WorkFlow_PhasesModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_WorkFlow_PhasesModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_WorkFlow_PhasesModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_WorkFlow_PhasesModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Spartan_WorkFlow_PhasesModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Spartan_WorkFlow_PhasesModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Spartan_WorkFlow_PhasesModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Spartan_WorkFlow_PhasesModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strSpartan_WorkFlow_PhasesScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_WorkFlow_Phases.js")))
            {
                strSpartan_WorkFlow_PhasesScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_WorkFlow_Phases element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_WorkFlow_PhasesModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_WorkFlow_PhasesScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_WorkFlow_PhasesScript.Substring(indexOfArray, strSpartan_WorkFlow_PhasesScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_WorkFlow_PhasesModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_WorkFlow_PhasesModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_WorkFlow_PhasesScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strSpartan_WorkFlow_PhasesScript.Substring(indexOfArrayHistory, strSpartan_WorkFlow_PhasesScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strSpartan_WorkFlow_PhasesScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_WorkFlow_PhasesScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_WorkFlow_PhasesScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Spartan_WorkFlow_PhasesModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strSpartan_WorkFlow_PhasesScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strSpartan_WorkFlow_PhasesScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strSpartan_WorkFlow_PhasesScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strSpartan_WorkFlow_PhasesScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_WorkFlow_Phases.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_WorkFlow_Phases.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_WorkFlow_Phases.js")))
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
        public ActionResult Spartan_WorkFlow_PhasesPropertyBag()
        {
            return PartialView("Spartan_WorkFlow_PhasesPropertyBag", "Spartan_WorkFlow_Phases");
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

            _ISpartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_WorkFlow_PhasesPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_WorkFlow_PhasesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_WorkFlow_Phasess == null)
                result.Spartan_WorkFlow_Phasess = new List<Spartan_WorkFlow_Phases>();

            var data = result.Spartan_WorkFlow_Phasess.Select(m => new Spartan_WorkFlow_PhasesGridModel
            {
                PhasesId = m.PhasesId
                ,Phase_Number = m.Phase_Number
                ,Name = m.Name

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_WorkFlow_PhasesList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_WorkFlow_PhasesList_" + DateTime.Now.ToString());
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

            _ISpartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_WorkFlow_PhasesPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_WorkFlow_PhasesApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_WorkFlow_Phasess == null)
                result.Spartan_WorkFlow_Phasess = new List<Spartan_WorkFlow_Phases>();

            var data = result.Spartan_WorkFlow_Phasess.Select(m => new Spartan_WorkFlow_PhasesGridModel
            {
                PhasesId = m.PhasesId
                ,Phase_Number = m.Phase_Number
                ,Name = m.Name

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
