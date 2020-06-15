using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Spartan_WorkFlow;
using Spartane.Core.Domain.Spartan_WorkFlow_Status;
using Spartane.Core.Domain.Spartan_Object;
using Spartane.Core.Domain.Spartan_WorkFlow_Phases;
using Spartane.Core.Domain.Spartan_WorkFlow_Phase_Type;
using Spartane.Core.Domain.Spartan_WorkFlow_Type_Work_Distribution;
using Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control;
using Spartane.Core.Domain.Spartan_WorkFlow_Phase_Status;

using Spartane.Core.Domain.Spartan_WorkFlow_State;
using Spartane.Core.Domain.Spartan_WorkFlow_Phases;
using Spartane.Core.Domain.Spartan_Metadata;

using Spartane.Core.Domain.Spartan_WorkFlow_Conditions_by_State;
using Spartane.Core.Domain.Spartan_WorkFlow_Phases;
using Spartane.Core.Domain.Spartan_WorkFlow_State;
using Spartane.Core.Domain.Spartan_WorkFlow_Condition_Operator;
using Spartane.Core.Domain.Spartan_Metadata;
using Spartane.Core.Domain.Spartan_WorkFlow_Condition;
using Spartane.Core.Domain.Spartan_WorkFlow_Operator;

using Spartane.Core.Domain.Spartan_WorkFlow_Information_by_State;
using Spartane.Core.Domain.Spartan_WorkFlow_Phases;
using Spartane.Core.Domain.Spartan_WorkFlow_State;
using Spartane.Core.Domain.Spartan_Metadata;

using Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State;
using Spartane.Core.Domain.Spartan_WorkFlow_Phases;
using Spartane.Core.Domain.Spartan_WorkFlow_State;

using Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States;
using Spartane.Core.Domain.Spartan_WorkFlow_Phases;
using Spartane.Core.Domain.Spartan_WorkFlow_State;
using Spartane.Core.Domain.Spartan_Metadata;


using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Spartan_WorkFlow;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Object;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phases;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phase_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Type_Work_Distribution;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Type_Flow_Control;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phase_Status;

using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_State;

using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phases;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;

using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Conditions_by_State;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phases;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_State;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Condition_Operator;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Condition;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Operator;

using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Information_by_State;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phases;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_State;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;

using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Roles_by_State;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phases;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_State;

using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Matrix_of_States;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phases;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_State;
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

using Spartane.Web.Areas.WebApiConsumer.Spartan_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Permissions;
using Spartane.Web.Areas.WebApiConsumer.GeneratePDF;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using System.Text;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Scope_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operation_Detail;
using Spartane.Web.Areas.WebApiConsumer.SpartaneQuery;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User_Role;
using Spartane.Web.Areas.WebApiConsumer.Business_Rule_Creation;
using Spartane.Core.Domain.Business_Rule_Creation;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Spartan_WorkFlowController : Controller
    {
        #region "variable declaration"

        private ISpartan_WorkFlowService service = null;
        private ISpartan_WorkFlowApiConsumer _ISpartan_WorkFlowApiConsumer;
        private ISpartan_WorkFlow_StatusApiConsumer _ISpartan_WorkFlow_StatusApiConsumer;
        private ISpartan_ObjectApiConsumer _ISpartan_ObjectApiConsumer;
        private ISpartan_WorkFlow_PhasesApiConsumer _ISpartan_WorkFlow_PhasesApiConsumer;
        private ISpartan_WorkFlow_Phase_TypeApiConsumer _ISpartan_WorkFlow_Phase_TypeApiConsumer;
        private ISpartan_WorkFlow_Type_Work_DistributionApiConsumer _ISpartan_WorkFlow_Type_Work_DistributionApiConsumer;
        private ISpartan_WorkFlow_Type_Flow_ControlApiConsumer _ISpartan_WorkFlow_Type_Flow_ControlApiConsumer;
        private ISpartan_WorkFlow_Phase_StatusApiConsumer _ISpartan_WorkFlow_Phase_StatusApiConsumer;

        private ISpartan_WorkFlow_StateApiConsumer _ISpartan_WorkFlow_StateApiConsumer;
        private ISpartan_MetadataApiConsumer _ISpartan_MetadataApiConsumer;

        private ISpartan_WorkFlow_Conditions_by_StateApiConsumer _ISpartan_WorkFlow_Conditions_by_StateApiConsumer;
        private ISpartan_WorkFlow_Condition_OperatorApiConsumer _ISpartan_WorkFlow_Condition_OperatorApiConsumer;
        private ISpartan_WorkFlow_ConditionApiConsumer _ISpartan_WorkFlow_ConditionApiConsumer;
        private ISpartan_WorkFlow_OperatorApiConsumer _ISpartan_WorkFlow_OperatorApiConsumer;

        private ISpartan_WorkFlow_Information_by_StateApiConsumer _ISpartan_WorkFlow_Information_by_StateApiConsumer;

        private ISpartan_WorkFlow_Roles_by_StateApiConsumer _ISpartan_WorkFlow_Roles_by_StateApiConsumer;

        private ISpartan_WorkFlow_Matrix_of_StatesApiConsumer _ISpartan_WorkFlow_Matrix_of_StatesApiConsumer;


        private IBusiness_Rule_CreationApiConsumer _IBusiness_Rule_CreationApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;
        private IGeneratePDFApiConsumer _IGeneratePDFApiConsumer;
        private ISpartan_FormatApiConsumer _ISpartan_FormatApiConsumer;
        private ISpartan_Format_PermissionsApiConsumer _ISpartan_Format_PermissionsApiConsumer;

        private ISpartan_BR_Scope_DetailApiConsumer _ISpartan_BR_Scope_DetailApiConsumer;
        private ISpartan_BR_Operation_DetailApiConsumer _ISpartan_BR_Operation_DetailApiConsumer;
        private ISpartaneQueryApiConsumer _ISpartaneQueryApiConsumer;
        private ISpartan_User_RoleApiConsumer _ISpartan_User_RoleApiConsumer;

        #endregion "variable declaration"

        #region "Constructor Declaration"


        public Spartan_WorkFlowController(ISpartan_WorkFlowService service, ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, ISpartan_WorkFlowApiConsumer Spartan_WorkFlowApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, IBusiness_Rule_CreationApiConsumer Business_Rule_CreationApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_WorkFlow_StatusApiConsumer Spartan_WorkFlow_StatusApiConsumer, ISpartan_ObjectApiConsumer Spartan_ObjectApiConsumer, ISpartan_WorkFlow_PhasesApiConsumer Spartan_WorkFlow_PhasesApiConsumer, ISpartan_WorkFlow_Phase_TypeApiConsumer Spartan_WorkFlow_Phase_TypeApiConsumer, ISpartan_WorkFlow_Type_Work_DistributionApiConsumer Spartan_WorkFlow_Type_Work_DistributionApiConsumer, ISpartan_WorkFlow_Type_Flow_ControlApiConsumer Spartan_WorkFlow_Type_Flow_ControlApiConsumer, ISpartan_WorkFlow_Phase_StatusApiConsumer Spartan_WorkFlow_Phase_StatusApiConsumer, ISpartan_WorkFlow_StateApiConsumer Spartan_WorkFlow_StateApiConsumer, ISpartan_MetadataApiConsumer Spartan_MetadataApiConsumer, ISpartan_WorkFlow_Conditions_by_StateApiConsumer Spartan_WorkFlow_Conditions_by_StateApiConsumer, ISpartan_WorkFlow_Condition_OperatorApiConsumer Spartan_WorkFlow_Condition_OperatorApiConsumer, ISpartan_WorkFlow_ConditionApiConsumer Spartan_WorkFlow_ConditionApiConsumer, ISpartan_WorkFlow_OperatorApiConsumer Spartan_WorkFlow_OperatorApiConsumer, ISpartan_WorkFlow_Information_by_StateApiConsumer Spartan_WorkFlow_Information_by_StateApiConsumer, ISpartan_WorkFlow_Roles_by_StateApiConsumer Spartan_WorkFlow_Roles_by_StateApiConsumer, ISpartan_WorkFlow_Matrix_of_StatesApiConsumer Spartan_WorkFlow_Matrix_of_StatesApiConsumer
            , ISpartan_BR_Scope_DetailApiConsumer Spartan_BR_Scope_DetailApiConsumer
            , ISpartan_BR_Operation_DetailApiConsumer Spartan_BR_Operation_DetailApiConsumer
            , ISpartaneQueryApiConsumer SpartaneQueryApiConsumer, ISpartan_User_RoleApiConsumer Spartan_User_RoleApiConsumer)
        {
            this._ISpartan_BR_Scope_DetailApiConsumer = Spartan_BR_Scope_DetailApiConsumer;
            this._ISpartan_BR_Operation_DetailApiConsumer = Spartan_BR_Operation_DetailApiConsumer;
            this._ISpartaneQueryApiConsumer = SpartaneQueryApiConsumer;
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._ISpartan_WorkFlowApiConsumer = Spartan_WorkFlowApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._IBusiness_Rule_CreationApiConsumer = Business_Rule_CreationApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
            this._ISpartan_WorkFlow_StatusApiConsumer = Spartan_WorkFlow_StatusApiConsumer;
            this._ISpartan_ObjectApiConsumer = Spartan_ObjectApiConsumer;
            this._ISpartan_WorkFlow_PhasesApiConsumer = Spartan_WorkFlow_PhasesApiConsumer;
            this._ISpartan_WorkFlow_Phase_TypeApiConsumer = Spartan_WorkFlow_Phase_TypeApiConsumer;
            this._ISpartan_WorkFlow_Type_Work_DistributionApiConsumer = Spartan_WorkFlow_Type_Work_DistributionApiConsumer;
            this._ISpartan_WorkFlow_Type_Flow_ControlApiConsumer = Spartan_WorkFlow_Type_Flow_ControlApiConsumer;
            this._ISpartan_WorkFlow_Phase_StatusApiConsumer = Spartan_WorkFlow_Phase_StatusApiConsumer;

            this._ISpartan_WorkFlow_StateApiConsumer = Spartan_WorkFlow_StateApiConsumer;
            this._ISpartan_WorkFlow_PhasesApiConsumer = Spartan_WorkFlow_PhasesApiConsumer;
            this._ISpartan_MetadataApiConsumer = Spartan_MetadataApiConsumer;

            this._ISpartan_WorkFlow_Conditions_by_StateApiConsumer = Spartan_WorkFlow_Conditions_by_StateApiConsumer;
            this._ISpartan_WorkFlow_PhasesApiConsumer = Spartan_WorkFlow_PhasesApiConsumer;
            this._ISpartan_WorkFlow_StateApiConsumer = Spartan_WorkFlow_StateApiConsumer;
            this._ISpartan_WorkFlow_Condition_OperatorApiConsumer = Spartan_WorkFlow_Condition_OperatorApiConsumer;
            this._ISpartan_MetadataApiConsumer = Spartan_MetadataApiConsumer;
            this._ISpartan_WorkFlow_ConditionApiConsumer = Spartan_WorkFlow_ConditionApiConsumer;
            this._ISpartan_WorkFlow_OperatorApiConsumer = Spartan_WorkFlow_OperatorApiConsumer;

            this._ISpartan_WorkFlow_Information_by_StateApiConsumer = Spartan_WorkFlow_Information_by_StateApiConsumer;
            this._ISpartan_WorkFlow_PhasesApiConsumer = Spartan_WorkFlow_PhasesApiConsumer;
            this._ISpartan_WorkFlow_StateApiConsumer = Spartan_WorkFlow_StateApiConsumer;
            this._ISpartan_MetadataApiConsumer = Spartan_MetadataApiConsumer;

            this._ISpartan_WorkFlow_Roles_by_StateApiConsumer = Spartan_WorkFlow_Roles_by_StateApiConsumer;
            this._ISpartan_WorkFlow_PhasesApiConsumer = Spartan_WorkFlow_PhasesApiConsumer;
            this._ISpartan_WorkFlow_StateApiConsumer = Spartan_WorkFlow_StateApiConsumer;

            this._ISpartan_WorkFlow_Matrix_of_StatesApiConsumer = Spartan_WorkFlow_Matrix_of_StatesApiConsumer;
            this._ISpartan_WorkFlow_PhasesApiConsumer = Spartan_WorkFlow_PhasesApiConsumer;
            this._ISpartan_WorkFlow_StateApiConsumer = Spartan_WorkFlow_StateApiConsumer;
            this._ISpartan_MetadataApiConsumer = Spartan_MetadataApiConsumer;

            this._ISpartan_User_RoleApiConsumer = Spartan_User_RoleApiConsumer;
        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Spartan_WorkFlow
        [ObjectAuth(ObjectId = (ModuleObjectId)120, PermissionType = PermissionTypes.Consult)]
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
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 120, ModuleId);
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
                var whereClauseFormat = "Object = 120 AND FormatId in (" + formats + ")";
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

        // GET: Frontal/Spartan_WorkFlow/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)120, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 120, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varSpartan_WorkFlow = new Spartan_WorkFlowModel();
			
            ViewBag.ObjectId = "120";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionSpartan_WorkFlow_Phases = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 122, ModuleId);
            ViewBag.PermissionSpartan_WorkFlow_Phases = permissionSpartan_WorkFlow_Phases;
            var permissionSpartan_WorkFlow_State = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 127, ModuleId);
            ViewBag.PermissionSpartan_WorkFlow_State = permissionSpartan_WorkFlow_State;
            var permissionSpartan_WorkFlow_Conditions_by_State = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 128, ModuleId);
            ViewBag.PermissionSpartan_WorkFlow_Conditions_by_State = permissionSpartan_WorkFlow_Conditions_by_State;
            var permissionSpartan_WorkFlow_Information_by_State = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 132, ModuleId);
            ViewBag.PermissionSpartan_WorkFlow_Information_by_State = permissionSpartan_WorkFlow_Information_by_State;
            var permissionSpartan_WorkFlow_Roles_by_State = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 133, ModuleId);
            ViewBag.PermissionSpartan_WorkFlow_Roles_by_State = permissionSpartan_WorkFlow_Roles_by_State;
            var permissionSpartan_WorkFlow_Matrix_of_States = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 134, ModuleId);
            ViewBag.PermissionSpartan_WorkFlow_Matrix_of_States = permissionSpartan_WorkFlow_Matrix_of_States;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlowApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Spartan_WorkFlowData = _ISpartan_WorkFlowApiConsumer.GetByKeyComplete(Id).Resource.Spartan_WorkFlows[0];
                if (Spartan_WorkFlowData == null)
                    return HttpNotFound();

                varSpartan_WorkFlow = new Spartan_WorkFlowModel
                {
                    WorkFlowId = (int)Spartan_WorkFlowData.WorkFlowId
                    ,Name = Spartan_WorkFlowData.Name
                    ,Description = Spartan_WorkFlowData.Description
                    ,Objective = Spartan_WorkFlowData.Objective
                    ,Status = Spartan_WorkFlowData.Status
                    ,StatusDescription =  (string)Spartan_WorkFlowData.Status_Spartan_WorkFlow_Status.Description
                    ,Object = Spartan_WorkFlowData.Object
                    ,ObjectName =  (string)Spartan_WorkFlowData.Object_Spartan_Object.Name

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_WorkFlow_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_WorkFlow_Statuss_Status = _ISpartan_WorkFlow_StatusApiConsumer.SelAll(true);
            if (Spartan_WorkFlow_Statuss_Status != null && Spartan_WorkFlow_Statuss_Status.Resource != null)
                ViewBag.Spartan_WorkFlow_Statuss_Status = Spartan_WorkFlow_Statuss_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.StatusId)
                }).ToList();
   _ISpartan_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Objects_Object = _ISpartan_ObjectApiConsumer.SelAll(true);
            if (Spartan_Objects_Object != null && Spartan_Objects_Object.Resource != null)
                ViewBag.Spartan_Objects_Object = Spartan_Objects_Object.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Object_Id)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varSpartan_WorkFlow);
        }
		
	[HttpGet]
        public ActionResult AddSpartan_WorkFlow(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 120);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _ISpartan_WorkFlowApiConsumer.SetAuthHeader(_tokenManager.Token);
			Spartan_WorkFlowModel varSpartan_WorkFlow= new Spartan_WorkFlowModel();
            var permissionSpartan_WorkFlow_Phases = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 32548, ModuleId);
            ViewBag.PermissionSpartan_WorkFlow_Phases = permissionSpartan_WorkFlow_Phases;
            var permissionSpartan_WorkFlow_State = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 32553, ModuleId);
            ViewBag.PermissionSpartan_WorkFlow_State = permissionSpartan_WorkFlow_State;
            var permissionSpartan_WorkFlow_Conditions_by_State = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 32556, ModuleId);
            ViewBag.PermissionSpartan_WorkFlow_Conditions_by_State = permissionSpartan_WorkFlow_Conditions_by_State;
            var permissionSpartan_WorkFlow_Information_by_State = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 32560, ModuleId);
            ViewBag.PermissionSpartan_WorkFlow_Information_by_State = permissionSpartan_WorkFlow_Information_by_State;
            var permissionSpartan_WorkFlow_Roles_by_State = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 32561, ModuleId);
            ViewBag.PermissionSpartan_WorkFlow_Roles_by_State = permissionSpartan_WorkFlow_Roles_by_State;
            var permissionSpartan_WorkFlow_Matrix_of_States = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 32562, ModuleId);
            ViewBag.PermissionSpartan_WorkFlow_Matrix_of_States = permissionSpartan_WorkFlow_Matrix_of_States;


            if (id.ToString() != "0")
            {
                var Spartan_WorkFlowsData = _ISpartan_WorkFlowApiConsumer.ListaSelAll(0, 1000, "WorkFlowId=" + id, "").Resource.Spartan_WorkFlows;
				
				if (Spartan_WorkFlowsData != null && Spartan_WorkFlowsData.Count > 0)
                {
					var Spartan_WorkFlowData = Spartan_WorkFlowsData.First();
					varSpartan_WorkFlow= new Spartan_WorkFlowModel
					{
						WorkFlowId  = Spartan_WorkFlowData.WorkFlowId 
	                    ,Name = Spartan_WorkFlowData.Name
                    ,Description = Spartan_WorkFlowData.Description
                    ,Objective = Spartan_WorkFlowData.Objective
                    ,Status = Spartan_WorkFlowData.Status
                    ,StatusDescription =  (string)Spartan_WorkFlowData.Status_Spartan_WorkFlow_Status.Description
                    ,Object = Spartan_WorkFlowData.Object
                    ,ObjectName =  (string)Spartan_WorkFlowData.Object_Spartan_Object.Name

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_WorkFlow_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_WorkFlow_Statuss_Status = _ISpartan_WorkFlow_StatusApiConsumer.SelAll(true);
            if (Spartan_WorkFlow_Statuss_Status != null && Spartan_WorkFlow_Statuss_Status.Resource != null)
                ViewBag.Spartan_WorkFlow_Statuss_Status = Spartan_WorkFlow_Statuss_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.StatusId)
                }).ToList();
   _ISpartan_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Objects_Object = _ISpartan_ObjectApiConsumer.SelAll(true);
            if (Spartan_Objects_Object != null && Spartan_Objects_Object.Resource != null)
                ViewBag.Spartan_Objects_Object = Spartan_Objects_Object.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Object_Id)
                }).ToList();


            return PartialView("AddSpartan_WorkFlow", varSpartan_WorkFlow);
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
        public ActionResult GetSpartan_WorkFlow_StatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_WorkFlow_StatusApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_ObjectAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_ObjectApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
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
        public ActionResult ShowAdvanceFilter(Spartan_WorkFlowAdvanceSearchModel model, int idFilter = -1)
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

            _ISpartan_WorkFlow_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_WorkFlow_Statuss_Status = _ISpartan_WorkFlow_StatusApiConsumer.SelAll(true);
            if (Spartan_WorkFlow_Statuss_Status != null && Spartan_WorkFlow_Statuss_Status.Resource != null)
                ViewBag.Spartan_WorkFlow_Statuss_Status = Spartan_WorkFlow_Statuss_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.StatusId)
                }).ToList();
   _ISpartan_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Objects_Object = _ISpartan_ObjectApiConsumer.SelAll(true);
            if (Spartan_Objects_Object != null && Spartan_Objects_Object.Resource != null)
                ViewBag.Spartan_Objects_Object = Spartan_Objects_Object.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Object_Id)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_WorkFlow_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_WorkFlow_Statuss_Status = _ISpartan_WorkFlow_StatusApiConsumer.SelAll(true);
            if (Spartan_WorkFlow_Statuss_Status != null && Spartan_WorkFlow_Statuss_Status.Resource != null)
                ViewBag.Spartan_WorkFlow_Statuss_Status = Spartan_WorkFlow_Statuss_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(), Value = Convert.ToString(m.StatusId)
                }).ToList();
   _ISpartan_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Objects_Object = _ISpartan_ObjectApiConsumer.SelAll(true);
            if (Spartan_Objects_Object != null && Spartan_Objects_Object.Resource != null)
                ViewBag.Spartan_Objects_Object = Spartan_Objects_Object.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(), Value = Convert.ToString(m.Object_Id)
                }).ToList();


            var previousFiltersObj = new Spartan_WorkFlowAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Spartan_WorkFlowAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Spartan_WorkFlowAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Spartan_WorkFlowPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _ISpartan_WorkFlowApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_WorkFlows == null)
                result.Spartan_WorkFlows = new List<Spartan_WorkFlow>();

            return Json(new
            {
                data = result.Spartan_WorkFlows.Select(m => new Spartan_WorkFlowGridModel
                    {
                    WorkFlowId = m.WorkFlowId
			,Name = m.Name
			,Description = m.Description
			,Objective = m.Objective
                        ,StatusDescription = (string)m.Status_Spartan_WorkFlow_Status.Description
                        ,ObjectName = (string)m.Object_Spartan_Object.Name

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_WorkFlow from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_WorkFlow Entity</returns>
        public ActionResult GetSpartan_WorkFlowList(int sEcho, int iDisplayStart, int iDisplayLength, string where, string order)
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
            _ISpartan_WorkFlowApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_WorkFlowPropertyMapper());
			if (!String.IsNullOrEmpty(where))
            {
                 configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True" && Session["AdvanceSearch"]!=null)
            {
				if (Session["AdvanceSearch"].GetType() == typeof(Spartan_WorkFlowAdvanceSearchModel))
                {
					var advanceFilter =
                    (Spartan_WorkFlowAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Spartan_WorkFlowPropertyMapper oSpartan_WorkFlowPropertyMapper = new Spartan_WorkFlowPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = oSpartan_WorkFlowPropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _ISpartan_WorkFlowApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_WorkFlows == null)
                result.Spartan_WorkFlows = new List<Spartan_WorkFlow>();

            return Json(new
            {
                aaData = result.Spartan_WorkFlows.Select(m => new Spartan_WorkFlowGridModel
            {
                    WorkFlowId = m.WorkFlowId
			,Name = m.Name
			,Description = m.Description
			,Objective = m.Objective
                        ,StatusDescription = (string)m.Status_Spartan_WorkFlow_Status.Description
                        ,ObjectName = (string)m.Object_Spartan_Object.Name

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetSpartan_WorkFlow_Object_Spartan_Object(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);

                var result = _ISpartan_ObjectApiConsumer.ListaSelAll(1, 20, " (cast(Spartan_Object.Object_Id as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Spartan_Object.Name as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where, " Spartan_Object.Name ASC ").Resource;
                return Json(result.Spartan_Objects.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
//Grid GetAutoComplete

//Grid GetAutoComplete
        [HttpGet]
        public JsonResult GetSpartan_WorkFlow_State_Attribute_Spartan_Metadata(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);

                var result = _ISpartan_MetadataApiConsumer.ListaSelAll(1, 20, " (cast(Spartan_Metadata.AttributeId as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Spartan_Metadata.Logical_Name as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where, " Spartan_Metadata.Logical_Name ASC ").Resource;
                return Json(result.Spartan_Metadatas.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

//Grid GetAutoComplete

//Grid GetAutoComplete
        [HttpGet]
        public JsonResult GetSpartan_WorkFlow_Information_by_State_Folder_Spartan_Metadata(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);

                var result = _ISpartan_MetadataApiConsumer.ListaSelAll(1, 20, " (cast(Spartan_Metadata.AttributeId as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Spartan_Metadata.Group_Name as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where, " Spartan_Metadata.Group_Name ASC ").Resource;
                return Json(result.Spartan_Metadatas.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

//Grid GetAutoComplete

//Grid GetAutoComplete
        [HttpGet]
        public JsonResult GetSpartan_WorkFlow_Matrix_of_States_Attribute_Spartan_Metadata(string query, string where)
        {
            try
            {
                if (String.IsNullOrEmpty(where))
                    where = "";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);

                var result = _ISpartan_MetadataApiConsumer.ListaSelAll(1, 20, " (cast(Spartan_Metadata.AttributeId as nvarchar(max)) LIKE '%" + query.Trim() + "%' or cast(Spartan_Metadata.Logical_Name as nvarchar(max)) LIKE '%" + query.Trim() + "%') " + where, " Spartan_Metadata.Logical_Name ASC ").Resource;
                return Json(result.Spartan_Metadatas.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }






        [NonAction]
        public string GetAdvanceFilter(Spartan_WorkFlowAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromWorkFlowId) || !string.IsNullOrEmpty(filter.ToWorkFlowId))
            {
                if (!string.IsNullOrEmpty(filter.FromWorkFlowId))
                    where += " AND Spartan_WorkFlow.WorkFlowId >= " + filter.FromWorkFlowId;
                if (!string.IsNullOrEmpty(filter.ToWorkFlowId))
                    where += " AND Spartan_WorkFlow.WorkFlowId <= " + filter.ToWorkFlowId;
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                switch (filter.NameFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_WorkFlow.Name LIKE '" + filter.Name + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_WorkFlow.Name LIKE '%" + filter.Name + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_WorkFlow.Name = '" + filter.Name + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_WorkFlow.Name LIKE '%" + filter.Name + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Description))
            {
                switch (filter.DescriptionFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_WorkFlow.Description LIKE '" + filter.Description + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_WorkFlow.Description LIKE '%" + filter.Description + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_WorkFlow.Description = '" + filter.Description + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_WorkFlow.Description LIKE '%" + filter.Description + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.Objective))
            {
                switch (filter.ObjectiveFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_WorkFlow.Objective LIKE '" + filter.Objective + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_WorkFlow.Objective LIKE '%" + filter.Objective + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_WorkFlow.Objective = '" + filter.Objective + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_WorkFlow.Objective LIKE '%" + filter.Objective + "%'";
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filter.AdvanceStatus))
            {
                switch (filter.StatusFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_WorkFlow_Status.Description LIKE '" + filter.AdvanceStatus + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_WorkFlow_Status.Description LIKE '%" + filter.AdvanceStatus + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_WorkFlow_Status.Description = '" + filter.AdvanceStatus + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_WorkFlow_Status.Description LIKE '%" + filter.AdvanceStatus + "%'";
                        break;
                }
            }
            else if (filter.AdvanceStatusMultiple != null && filter.AdvanceStatusMultiple.Count() > 0)
            {
                var StatusIds = string.Join(",", filter.AdvanceStatusMultiple);

                where += " AND Spartan_WorkFlow.Status In (" + StatusIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceObject))
            {
                switch (filter.ObjectFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_Object.Name LIKE '" + filter.AdvanceObject + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_Object.Name LIKE '%" + filter.AdvanceObject + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_Object.Name = '" + filter.AdvanceObject + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_Object.Name LIKE '%" + filter.AdvanceObject + "%'";
                        break;
                }
            }
            else if (filter.AdvanceObjectMultiple != null && filter.AdvanceObjectMultiple.Count() > 0)
            {
                var ObjectIds = string.Join(",", filter.AdvanceObjectMultiple);

                where += " AND Spartan_WorkFlow.Object In (" + ObjectIds + ")";
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

        public ActionResult GetSpartan_WorkFlow_Phases(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_WorkFlow_PhasesGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_WorkFlow_Phases.WorkFlow=" + RelationId;
            if("int" == "string")
            {
	           where = "Spartan_WorkFlow_Phases.WorkFlow='" + RelationId + "'";
            }
            var result = _ISpartan_WorkFlow_PhasesApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Spartan_WorkFlow_Phasess == null)
                result.Spartan_WorkFlow_Phasess = new List<Spartan_WorkFlow_Phases>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_WorkFlow_Phasess.Select(m => new Spartan_WorkFlow_PhasesGridModel
                {
                    PhasesId = m.PhasesId
			,Phase_Number = m.Phase_Number
			,Name = m.Name
                        ,Phase_Type = m.Phase_Type
                        ,Phase_TypeDescription = (string)m.Phase_Type_Spartan_WorkFlow_Phase_Type.Description
                        ,Type_of_Work_Distribution = m.Type_of_Work_Distribution
                        ,Type_of_Work_DistributionDescription = (string)m.Type_of_Work_Distribution_Spartan_WorkFlow_Type_Work_Distribution.Description
                        ,Type_Flow_Control = m.Type_Flow_Control
                        ,Type_Flow_ControlDescription = (string)m.Type_Flow_Control_Spartan_WorkFlow_Type_Flow_Control.Description
                        ,Phase_Status = m.Phase_Status
                        ,Phase_StatusDescription = (string)m.Phase_Status_Spartan_WorkFlow_Phase_Status.Description

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_WorkFlow_State(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_WorkFlow_StateGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_WorkFlow_StateApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_WorkFlow_State.Spartan_WorkFlow=" + RelationId;
            if("int" == "string")
            {
	           where = "Spartan_WorkFlow_State.Spartan_WorkFlow='" + RelationId + "'";
            }
            var result = _ISpartan_WorkFlow_StateApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Spartan_WorkFlow_States == null)
                result.Spartan_WorkFlow_States = new List<Spartan_WorkFlow_State>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_WorkFlow_States.Select(m => new Spartan_WorkFlow_StateGridModel
                {
                    StateId = m.StateId
                        ,Phase = m.Phase
                        ,PhaseName = (string)m.Phase_Spartan_WorkFlow_Phases.Name
                        ,Attribute = m.Attribute
                        ,AttributeLogical_Name = (string)m.Attribute_Spartan_Metadata.Logical_Name
			,State_Code = m.State_Code
			,Name = m.Name
			,Value = m.Value
			,Text = m.Text

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_WorkFlow_Conditions_by_State(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_WorkFlow_Conditions_by_StateGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_WorkFlow_Conditions_by_StateApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow=" + RelationId;
            if("int" == "string")
            {
	           where = "Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow='" + RelationId + "'";
            }
            var result = _ISpartan_WorkFlow_Conditions_by_StateApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Spartan_WorkFlow_Conditions_by_States == null)
                result.Spartan_WorkFlow_Conditions_by_States = new List<Spartan_WorkFlow_Conditions_by_State>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_WorkFlow_Conditions_by_States.Select(m => new Spartan_WorkFlow_Conditions_by_StateGridModel
                {
                    Conditions_by_StateId = m.Conditions_by_StateId
                        ,Phase = m.Phase
                        ,PhaseName = (string)m.Phase_Spartan_WorkFlow_Phases.Name
                        ,State = m.State
                        ,StateName = (string)m.State_Spartan_WorkFlow_State.Name
                        ,Condition_Operator = m.Condition_Operator
                        ,Condition_OperatorDescription = (string)m.Condition_Operator_Spartan_WorkFlow_Condition_Operator.Description
                        ,Attribute = m.Attribute
                        ,AttributeLogical_Name = (string)m.Attribute_Spartan_Metadata.Logical_Name
                        ,Condition = m.Condition
                        ,ConditionDescription = (string)m.Condition_Spartan_WorkFlow_Condition.Description
                        ,Operator = m.Operator
                        ,OperatorDescription = (string)m.Operator_Spartan_WorkFlow_Operator.Description
			,Operator_Value = m.Operator_Value
			,Priority = m.Priority

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_WorkFlow_Information_by_State(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_WorkFlow_Information_by_StateGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_WorkFlow_Information_by_StateApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow=" + RelationId;
            if("int" == "string")
            {
	           where = "Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow='" + RelationId + "'";
            }
            var result = _ISpartan_WorkFlow_Information_by_StateApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Spartan_WorkFlow_Information_by_States == null)
                result.Spartan_WorkFlow_Information_by_States = new List<Spartan_WorkFlow_Information_by_State>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_WorkFlow_Information_by_States.Select(m => new Spartan_WorkFlow_Information_by_StateGridModel
                {
                    Information_by_StateId = m.Information_by_StateId
                        ,Phase = m.Phase
                        ,PhaseName = (string)m.Phase_Spartan_WorkFlow_Phases.Name
                        ,State = m.State
                        ,StateName = (string)m.State_Spartan_WorkFlow_State.Name
                        ,Folder = m.Folder
                        ,FolderGroup_Name = (string)m.Folder_Spartan_Metadata.Group_Name
			,Visible = m.Visible
			,Read_Only = m.Read_Only
			,Required = m.Required
			,Label = m.Label

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_WorkFlow_Roles_by_State(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_WorkFlow_Roles_by_StateGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_WorkFlow_Roles_by_StateApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow=" + RelationId;
            if("int" == "string")
            {
	           where = "Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow='" + RelationId + "'";
            }
            var result = _ISpartan_WorkFlow_Roles_by_StateApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Spartan_WorkFlow_Roles_by_States == null)
                result.Spartan_WorkFlow_Roles_by_States = new List<Spartan_WorkFlow_Roles_by_State>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_WorkFlow_Roles_by_States.Select(m => new Spartan_WorkFlow_Roles_by_StateGridModel
                {
                    Roles_by_StateId = m.Roles_by_StateId
                        ,Phase = m.Phase
                        ,PhaseName = (string)m.Phase_Spartan_WorkFlow_Phases.Name
                        ,State = m.State
                        ,StateName = (string)m.State_Spartan_WorkFlow_State.Name
			,User_Role = m.User_Role
			,Phase_Transition = m.Phase_Transition
			,Permission_To_Consult = m.Permission_To_Consult
			,Permission_To_New = m.Permission_To_New
			,Permission_To_Modify = m.Permission_To_Modify
			,Permission_to_Delete = m.Permission_to_Delete
			,Permission_To_Export = m.Permission_To_Export
			,Permission_To_Print = m.Permission_To_Print
			,Permission_Settings = m.Permission_Settings

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_WorkFlow_Matrix_of_States(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_WorkFlow_Matrix_of_StatesGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_WorkFlow_Matrix_of_StatesApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow=" + RelationId;
            if("int" == "string")
            {
	           where = "Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow='" + RelationId + "'";
            }
            var result = _ISpartan_WorkFlow_Matrix_of_StatesApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Spartan_WorkFlow_Matrix_of_Statess == null)
                result.Spartan_WorkFlow_Matrix_of_Statess = new List<Spartan_WorkFlow_Matrix_of_States>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_WorkFlow_Matrix_of_Statess.Select(m => new Spartan_WorkFlow_Matrix_of_StatesGridModel
                {
                    Matrix_of_StatesId = m.Matrix_of_StatesId
                        ,Phase = m.Phase
                        ,PhaseName = (string)m.Phase_Spartan_WorkFlow_Phases.Name
                        ,State = m.State
                        ,StateName = (string)m.State_Spartan_WorkFlow_State.Name
                        ,Attribute = m.Attribute
                        ,AttributeLogical_Name = (string)m.Attribute_Spartan_Metadata.Logical_Name
			,Visible = m.Visible
			,Required = m.Required
			,Read_Only = m.Read_Only
			,Label = m.Label
			,Default_Value = m.Default_Value
			,Help_Text = m.Help_Text

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlowApiConsumer.SetAuthHeader(_tokenManager.Token);

                Spartan_WorkFlow varSpartan_WorkFlow = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _ISpartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Spartan_WorkFlow_Phases.WorkFlow=" + id;
                    if("int" == "string")
                    {
	                where = "Spartan_WorkFlow_Phases.WorkFlow='" + id + "'";
                    }
                    var Spartan_WorkFlow_PhasesInfo =
                        _ISpartan_WorkFlow_PhasesApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Spartan_WorkFlow_PhasesInfo.Spartan_WorkFlow_Phasess.Count > 0)
                    {
                        var resultSpartan_WorkFlow_Phases = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_WorkFlow_PhasesItem in Spartan_WorkFlow_PhasesInfo.Spartan_WorkFlow_Phasess)
                            resultSpartan_WorkFlow_Phases = resultSpartan_WorkFlow_Phases
                                              && _ISpartan_WorkFlow_PhasesApiConsumer.Delete(Spartan_WorkFlow_PhasesItem.PhasesId, null,null).Resource;

                        if (!resultSpartan_WorkFlow_Phases)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_WorkFlow_StateApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Spartan_WorkFlow_State.Spartan_WorkFlow=" + id;
                    if("int" == "string")
                    {
	                where = "Spartan_WorkFlow_State.Spartan_WorkFlow='" + id + "'";
                    }
                    var Spartan_WorkFlow_StateInfo =
                        _ISpartan_WorkFlow_StateApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Spartan_WorkFlow_StateInfo.Spartan_WorkFlow_States.Count > 0)
                    {
                        var resultSpartan_WorkFlow_State = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_WorkFlow_StateItem in Spartan_WorkFlow_StateInfo.Spartan_WorkFlow_States)
                            resultSpartan_WorkFlow_State = resultSpartan_WorkFlow_State
                                              && _ISpartan_WorkFlow_StateApiConsumer.Delete(Spartan_WorkFlow_StateItem.StateId, null,null).Resource;

                        if (!resultSpartan_WorkFlow_State)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_WorkFlow_Conditions_by_StateApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow=" + id;
                    if("int" == "string")
                    {
	                where = "Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow='" + id + "'";
                    }
                    var Spartan_WorkFlow_Conditions_by_StateInfo =
                        _ISpartan_WorkFlow_Conditions_by_StateApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Spartan_WorkFlow_Conditions_by_StateInfo.Spartan_WorkFlow_Conditions_by_States.Count > 0)
                    {
                        var resultSpartan_WorkFlow_Conditions_by_State = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_WorkFlow_Conditions_by_StateItem in Spartan_WorkFlow_Conditions_by_StateInfo.Spartan_WorkFlow_Conditions_by_States)
                            resultSpartan_WorkFlow_Conditions_by_State = resultSpartan_WorkFlow_Conditions_by_State
                                              && _ISpartan_WorkFlow_Conditions_by_StateApiConsumer.Delete(Spartan_WorkFlow_Conditions_by_StateItem.Conditions_by_StateId, null,null).Resource;

                        if (!resultSpartan_WorkFlow_Conditions_by_State)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_WorkFlow_Information_by_StateApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow=" + id;
                    if("int" == "string")
                    {
	                where = "Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow='" + id + "'";
                    }
                    var Spartan_WorkFlow_Information_by_StateInfo =
                        _ISpartan_WorkFlow_Information_by_StateApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Spartan_WorkFlow_Information_by_StateInfo.Spartan_WorkFlow_Information_by_States.Count > 0)
                    {
                        var resultSpartan_WorkFlow_Information_by_State = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_WorkFlow_Information_by_StateItem in Spartan_WorkFlow_Information_by_StateInfo.Spartan_WorkFlow_Information_by_States)
                            resultSpartan_WorkFlow_Information_by_State = resultSpartan_WorkFlow_Information_by_State
                                              && _ISpartan_WorkFlow_Information_by_StateApiConsumer.Delete(Spartan_WorkFlow_Information_by_StateItem.Information_by_StateId, null,null).Resource;

                        if (!resultSpartan_WorkFlow_Information_by_State)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_WorkFlow_Roles_by_StateApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow=" + id;
                    if("int" == "string")
                    {
	                where = "Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow='" + id + "'";
                    }
                    var Spartan_WorkFlow_Roles_by_StateInfo =
                        _ISpartan_WorkFlow_Roles_by_StateApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Spartan_WorkFlow_Roles_by_StateInfo.Spartan_WorkFlow_Roles_by_States.Count > 0)
                    {
                        var resultSpartan_WorkFlow_Roles_by_State = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_WorkFlow_Roles_by_StateItem in Spartan_WorkFlow_Roles_by_StateInfo.Spartan_WorkFlow_Roles_by_States)
                            resultSpartan_WorkFlow_Roles_by_State = resultSpartan_WorkFlow_Roles_by_State
                                              && _ISpartan_WorkFlow_Roles_by_StateApiConsumer.Delete(Spartan_WorkFlow_Roles_by_StateItem.Roles_by_StateId, null,null).Resource;

                        if (!resultSpartan_WorkFlow_Roles_by_State)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_WorkFlow_Matrix_of_StatesApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow=" + id;
                    if("int" == "string")
                    {
	                where = "Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow='" + id + "'";
                    }
                    var Spartan_WorkFlow_Matrix_of_StatesInfo =
                        _ISpartan_WorkFlow_Matrix_of_StatesApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Spartan_WorkFlow_Matrix_of_StatesInfo.Spartan_WorkFlow_Matrix_of_Statess.Count > 0)
                    {
                        var resultSpartan_WorkFlow_Matrix_of_States = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_WorkFlow_Matrix_of_StatesItem in Spartan_WorkFlow_Matrix_of_StatesInfo.Spartan_WorkFlow_Matrix_of_Statess)
                            resultSpartan_WorkFlow_Matrix_of_States = resultSpartan_WorkFlow_Matrix_of_States
                                              && _ISpartan_WorkFlow_Matrix_of_StatesApiConsumer.Delete(Spartan_WorkFlow_Matrix_of_StatesItem.Matrix_of_StatesId, null,null).Resource;

                        if (!resultSpartan_WorkFlow_Matrix_of_States)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _ISpartan_WorkFlowApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Spartan_WorkFlowModel varSpartan_WorkFlow)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _ISpartan_WorkFlowApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Spartan_WorkFlowInfo = new Spartan_WorkFlow
                    {
                        WorkFlowId = varSpartan_WorkFlow.WorkFlowId
                        ,Name = varSpartan_WorkFlow.Name
                        ,Description = varSpartan_WorkFlow.Description
                        ,Objective = varSpartan_WorkFlow.Objective
                        ,Status = varSpartan_WorkFlow.Status
                        ,Object = varSpartan_WorkFlow.Object

                    };

                    result = !IsNew ?
                        _ISpartan_WorkFlowApiConsumer.Update(Spartan_WorkFlowInfo, null, null).Resource.ToString() :
                         _ISpartan_WorkFlowApiConsumer.Insert(Spartan_WorkFlowInfo, null, null).Resource.ToString();

                    _ISpartaneQueryApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartaneQueryApiConsumer.ExecuteQuery("UPDATE Spartan_Object SET Description = object_id WHERE object_id =" + varSpartan_WorkFlow.Object);
                    MenuHelper.GetLatestMenu();

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

        [HttpGet]
        public JsonResult RegenerateRules(int workflowId)
        {
            int result = -1;
            if (!_tokenManager.GenerateToken())
                return Json("false");
            _IBusiness_Rule_CreationApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartaneQueryApiConsumer.SetAuthHeader(_tokenManager.Token);
            //FIND  THE RULES OF WORKFLOW
            var rules = _IBusiness_Rule_CreationApiConsumer.ListaSelAll(0, 1000, "WorkflowId = " + workflowId, "").Resource;
            if(rules.RowCount > 0)
            {
                foreach (var rule in rules.Business_Rule_Creations)
	            {
                    var ruleComplete = _IBusiness_Rule_CreationApiConsumer.GetByKey(rule.Key_Business_Rule_Creation, false).Resource;
                    RegenerateJS(ruleComplete.Key_Business_Rule_Creation, 4, ruleComplete.Object.Value);
                    //DELETE RULE OF DATABASE
                    _IBusiness_Rule_CreationApiConsumer.Delete(ruleComplete.Key_Business_Rule_Creation, null, null);
	            }
            }
            //FIND THE PHASES
            var phases = _ISpartan_WorkFlow_PhasesApiConsumer.ListaSelAll(0, 9999, "WorkFlow = " + workflowId, "").Resource;
            if (phases.RowCount > 0)
            {
                foreach (var phase in phases.Spartan_WorkFlow_Phasess)
                {
                    //GENERATE THE NEW RULES BY PHASE
                    _ISpartaneQueryApiConsumer.ExecuteQuery("exec spWorkFlowGenerateRulesInformation " + workflowId + ", " + phase.Phase_Number);
                }
            }
            //FIND THE NEW RULES
            rules = _IBusiness_Rule_CreationApiConsumer.ListaSelAll(0, 1000, "WorkflowId = " + workflowId, "").Resource;
            if (rules.RowCount > 0)
            {
                foreach (var rule in rules.Business_Rule_Creations)
                {
                    var ruleComplete = _IBusiness_Rule_CreationApiConsumer.GetByKey(rule.Key_Business_Rule_Creation, false).Resource;
                    //ACTIVATE THE RULE
                    ruleComplete.Status = 3;
                    result = _IBusiness_Rule_CreationApiConsumer.Update(ruleComplete, null, null).Resource;
                    //WRITE RULE IN JS FILE
                    if(result != -1)
                        RegenerateJS(ruleComplete.Key_Business_Rule_Creation, 3, ruleComplete.Object.Value);
                }
            }
            return Json("true", JsonRequestBehavior.AllowGet);
        }

        [NonAction]
        public bool CopySpartan_WorkFlow_Phases(int MasterId, int referenceId, List<Spartan_WorkFlow_PhasesGridModelPost> Spartan_WorkFlow_PhasesItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_WorkFlow_PhasesData = _ISpartan_WorkFlow_PhasesApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_WorkFlow_Phases.WorkFlow=" + referenceId,"").Resource;
                if (Spartan_WorkFlow_PhasesData == null || Spartan_WorkFlow_PhasesData.Spartan_WorkFlow_Phasess.Count == 0)
                    return true;

                var result = true;

                Spartan_WorkFlow_PhasesGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varSpartan_WorkFlow_Phases in Spartan_WorkFlow_PhasesData.Spartan_WorkFlow_Phasess)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Spartan_WorkFlow_Phases Spartan_WorkFlow_Phases1 = varSpartan_WorkFlow_Phases;

                    if (Spartan_WorkFlow_PhasesItems != null && Spartan_WorkFlow_PhasesItems.Any(m => m.PhasesId == Spartan_WorkFlow_Phases1.PhasesId))
                    {
                        modelDataToChange = Spartan_WorkFlow_PhasesItems.FirstOrDefault(m => m.PhasesId == Spartan_WorkFlow_Phases1.PhasesId);
                    }
                    //Chaning Id Value
                    varSpartan_WorkFlow_Phases.WorkFlow = MasterId;
                    var insertId = _ISpartan_WorkFlow_PhasesApiConsumer.Insert(varSpartan_WorkFlow_Phases,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.PhasesId = insertId;

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
        public ActionResult PostSpartan_WorkFlow_Phases(List<Spartan_WorkFlow_PhasesGridModelPost> Spartan_WorkFlow_PhasesItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_WorkFlow_Phases(MasterId, referenceId, Spartan_WorkFlow_PhasesItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_WorkFlow_PhasesItems != null && Spartan_WorkFlow_PhasesItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_WorkFlow_PhasesItem in Spartan_WorkFlow_PhasesItems)
                    {

                        //Removal Request
                        if (Spartan_WorkFlow_PhasesItem.Removed)
                        {
                            result = result && _ISpartan_WorkFlow_PhasesApiConsumer.Delete(Spartan_WorkFlow_PhasesItem.PhasesId, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Spartan_WorkFlow_PhasesItem.PhasesId = 0;

                        var Spartan_WorkFlow_PhasesData = new Spartan_WorkFlow_Phases
                        {
                            WorkFlow = MasterId
                            ,PhasesId = Spartan_WorkFlow_PhasesItem.PhasesId
                            ,Phase_Number = Spartan_WorkFlow_PhasesItem.Phase_Number
                            ,Name = Spartan_WorkFlow_PhasesItem.Name
                            ,Phase_Type = (Convert.ToInt16(Spartan_WorkFlow_PhasesItem.Phase_Type) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_WorkFlow_PhasesItem.Phase_Type))
                            ,Type_of_Work_Distribution = (Convert.ToInt16(Spartan_WorkFlow_PhasesItem.Type_of_Work_Distribution) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_WorkFlow_PhasesItem.Type_of_Work_Distribution))
                            ,Type_Flow_Control = (Convert.ToInt16(Spartan_WorkFlow_PhasesItem.Type_Flow_Control) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_WorkFlow_PhasesItem.Type_Flow_Control))
                            ,Phase_Status = (Convert.ToInt16(Spartan_WorkFlow_PhasesItem.Phase_Status) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_WorkFlow_PhasesItem.Phase_Status))

                        };

                        var resultId = Spartan_WorkFlow_PhasesItem.PhasesId > 0
                           ? _ISpartan_WorkFlow_PhasesApiConsumer.Update(Spartan_WorkFlow_PhasesData,null,null).Resource
                           : _ISpartan_WorkFlow_PhasesApiConsumer.Insert(Spartan_WorkFlow_PhasesData,null,null).Resource;

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

        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_TypeAll()
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
        public ActionResult GetSpartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Work_DistributionAll()
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
        public ActionResult GetSpartan_WorkFlow_Phases_Spartan_WorkFlow_Type_Flow_ControlAll()
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
        public ActionResult GetSpartan_WorkFlow_Phases_Spartan_WorkFlow_Phase_StatusAll()
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

        [NonAction]
        public bool CopySpartan_WorkFlow_State(int MasterId, int referenceId, List<Spartan_WorkFlow_StateGridModelPost> Spartan_WorkFlow_StateItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_WorkFlow_StateApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_WorkFlow_StateData = _ISpartan_WorkFlow_StateApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_WorkFlow_State.Spartan_WorkFlow=" + referenceId,"").Resource;
                if (Spartan_WorkFlow_StateData == null || Spartan_WorkFlow_StateData.Spartan_WorkFlow_States.Count == 0)
                    return true;

                var result = true;

                Spartan_WorkFlow_StateGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varSpartan_WorkFlow_State in Spartan_WorkFlow_StateData.Spartan_WorkFlow_States)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Spartan_WorkFlow_State Spartan_WorkFlow_State1 = varSpartan_WorkFlow_State;

                    if (Spartan_WorkFlow_StateItems != null && Spartan_WorkFlow_StateItems.Any(m => m.StateId == Spartan_WorkFlow_State1.StateId))
                    {
                        modelDataToChange = Spartan_WorkFlow_StateItems.FirstOrDefault(m => m.StateId == Spartan_WorkFlow_State1.StateId);
                    }
                    //Chaning Id Value
                    varSpartan_WorkFlow_State.Spartan_WorkFlow = MasterId;
                    var insertId = _ISpartan_WorkFlow_StateApiConsumer.Insert(varSpartan_WorkFlow_State,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.StateId = insertId;

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
        public ActionResult PostSpartan_WorkFlow_State(List<Spartan_WorkFlow_StateGridModelPost> Spartan_WorkFlow_StateItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_WorkFlow_State(MasterId, referenceId, Spartan_WorkFlow_StateItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_WorkFlow_StateItems != null && Spartan_WorkFlow_StateItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_WorkFlow_StateApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_WorkFlow_StateItem in Spartan_WorkFlow_StateItems)
                    {

                        //Removal Request
                        if (Spartan_WorkFlow_StateItem.Removed)
                        {
                            result = result && _ISpartan_WorkFlow_StateApiConsumer.Delete(Spartan_WorkFlow_StateItem.StateId, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Spartan_WorkFlow_StateItem.StateId = 0;

                        var Spartan_WorkFlow_StateData = new Spartan_WorkFlow_State
                        {
                            Spartan_WorkFlow = MasterId
                            ,StateId = Spartan_WorkFlow_StateItem.StateId
                            ,Phase = (Convert.ToInt32(Spartan_WorkFlow_StateItem.Phase) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_WorkFlow_StateItem.Phase))
                            ,Attribute = (Convert.ToInt32(Spartan_WorkFlow_StateItem.Attribute) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_WorkFlow_StateItem.Attribute))
                            ,State_Code = Spartan_WorkFlow_StateItem.State_Code
                            ,Name = Spartan_WorkFlow_StateItem.Name
                            ,Value = Spartan_WorkFlow_StateItem.Value
                            ,Text = Spartan_WorkFlow_StateItem.Text

                        };

                        var resultId = Spartan_WorkFlow_StateItem.StateId > 0
                           ? _ISpartan_WorkFlow_StateApiConsumer.Update(Spartan_WorkFlow_StateData,null,null).Resource
                           : _ISpartan_WorkFlow_StateApiConsumer.Insert(Spartan_WorkFlow_StateData,null,null).Resource;

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

        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_State_Spartan_WorkFlow_PhasesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_WorkFlow_PhasesApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_State_Spartan_MetadataAll()
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

        [NonAction]
        public bool CopySpartan_WorkFlow_Conditions_by_State(int MasterId, int referenceId, List<Spartan_WorkFlow_Conditions_by_StateGridModelPost> Spartan_WorkFlow_Conditions_by_StateItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_WorkFlow_Conditions_by_StateApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_WorkFlow_Conditions_by_StateData = _ISpartan_WorkFlow_Conditions_by_StateApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow=" + referenceId,"").Resource;
                if (Spartan_WorkFlow_Conditions_by_StateData == null || Spartan_WorkFlow_Conditions_by_StateData.Spartan_WorkFlow_Conditions_by_States.Count == 0)
                    return true;

                var result = true;

                Spartan_WorkFlow_Conditions_by_StateGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varSpartan_WorkFlow_Conditions_by_State in Spartan_WorkFlow_Conditions_by_StateData.Spartan_WorkFlow_Conditions_by_States)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Spartan_WorkFlow_Conditions_by_State Spartan_WorkFlow_Conditions_by_State1 = varSpartan_WorkFlow_Conditions_by_State;

                    if (Spartan_WorkFlow_Conditions_by_StateItems != null && Spartan_WorkFlow_Conditions_by_StateItems.Any(m => m.Conditions_by_StateId == Spartan_WorkFlow_Conditions_by_State1.Conditions_by_StateId))
                    {
                        modelDataToChange = Spartan_WorkFlow_Conditions_by_StateItems.FirstOrDefault(m => m.Conditions_by_StateId == Spartan_WorkFlow_Conditions_by_State1.Conditions_by_StateId);
                    }
                    //Chaning Id Value
                    varSpartan_WorkFlow_Conditions_by_State.Spartan_WorkFlow = MasterId;
                    var insertId = _ISpartan_WorkFlow_Conditions_by_StateApiConsumer.Insert(varSpartan_WorkFlow_Conditions_by_State,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.Conditions_by_StateId = insertId;

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
        public ActionResult PostSpartan_WorkFlow_Conditions_by_State(List<Spartan_WorkFlow_Conditions_by_StateGridModelPost> Spartan_WorkFlow_Conditions_by_StateItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_WorkFlow_Conditions_by_State(MasterId, referenceId, Spartan_WorkFlow_Conditions_by_StateItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_WorkFlow_Conditions_by_StateItems != null && Spartan_WorkFlow_Conditions_by_StateItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_WorkFlow_Conditions_by_StateApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_WorkFlow_Conditions_by_StateItem in Spartan_WorkFlow_Conditions_by_StateItems)
                    {

                        //Removal Request
                        if (Spartan_WorkFlow_Conditions_by_StateItem.Removed)
                        {
                            result = result && _ISpartan_WorkFlow_Conditions_by_StateApiConsumer.Delete(Spartan_WorkFlow_Conditions_by_StateItem.Conditions_by_StateId, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Spartan_WorkFlow_Conditions_by_StateItem.Conditions_by_StateId = 0;

                        var Spartan_WorkFlow_Conditions_by_StateData = new Spartan_WorkFlow_Conditions_by_State
                        {
                            Spartan_WorkFlow = MasterId
                            ,Conditions_by_StateId = Spartan_WorkFlow_Conditions_by_StateItem.Conditions_by_StateId
                            ,Phase = (Convert.ToInt32(Spartan_WorkFlow_Conditions_by_StateItem.Phase) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_WorkFlow_Conditions_by_StateItem.Phase))
                            ,State = (Convert.ToInt32(Spartan_WorkFlow_Conditions_by_StateItem.State) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_WorkFlow_Conditions_by_StateItem.State))
                            ,Condition_Operator = (Convert.ToInt32(Spartan_WorkFlow_Conditions_by_StateItem.Condition_Operator) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_WorkFlow_Conditions_by_StateItem.Condition_Operator))
                            ,Attribute = (Convert.ToInt32(Spartan_WorkFlow_Conditions_by_StateItem.Attribute) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_WorkFlow_Conditions_by_StateItem.Attribute))
                            ,Condition = (Convert.ToInt16(Spartan_WorkFlow_Conditions_by_StateItem.Condition) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_WorkFlow_Conditions_by_StateItem.Condition))
                            ,Operator = (Convert.ToInt16(Spartan_WorkFlow_Conditions_by_StateItem.Operator) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_WorkFlow_Conditions_by_StateItem.Operator))
                            ,Operator_Value = Spartan_WorkFlow_Conditions_by_StateItem.Operator_Value
                            ,Priority = Spartan_WorkFlow_Conditions_by_StateItem.Priority

                        };

                        var resultId = Spartan_WorkFlow_Conditions_by_StateItem.Conditions_by_StateId > 0
                           ? _ISpartan_WorkFlow_Conditions_by_StateApiConsumer.Update(Spartan_WorkFlow_Conditions_by_StateData,null,null).Resource
                           : _ISpartan_WorkFlow_Conditions_by_StateApiConsumer.Insert(Spartan_WorkFlow_Conditions_by_StateData,null,null).Resource;

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

        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_PhasesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_WorkFlow_PhasesApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_StateAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_StateApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_WorkFlow_StateApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_Condition_OperatorAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_Condition_OperatorApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_WorkFlow_Condition_OperatorApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_Conditions_by_State_Spartan_MetadataAll()
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
        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_ConditionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_ConditionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_WorkFlow_ConditionApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_Conditions_by_State_Spartan_WorkFlow_OperatorAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_OperatorApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_WorkFlow_OperatorApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_WorkFlow_Information_by_State(int MasterId, int referenceId, List<Spartan_WorkFlow_Information_by_StateGridModelPost> Spartan_WorkFlow_Information_by_StateItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_WorkFlow_Information_by_StateApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_WorkFlow_Information_by_StateData = _ISpartan_WorkFlow_Information_by_StateApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_WorkFlow_Information_by_State.Spartan_WorkFlow=" + referenceId,"").Resource;
                if (Spartan_WorkFlow_Information_by_StateData == null || Spartan_WorkFlow_Information_by_StateData.Spartan_WorkFlow_Information_by_States.Count == 0)
                    return true;

                var result = true;

                Spartan_WorkFlow_Information_by_StateGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varSpartan_WorkFlow_Information_by_State in Spartan_WorkFlow_Information_by_StateData.Spartan_WorkFlow_Information_by_States)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Spartan_WorkFlow_Information_by_State Spartan_WorkFlow_Information_by_State1 = varSpartan_WorkFlow_Information_by_State;

                    if (Spartan_WorkFlow_Information_by_StateItems != null && Spartan_WorkFlow_Information_by_StateItems.Any(m => m.Information_by_StateId == Spartan_WorkFlow_Information_by_State1.Information_by_StateId))
                    {
                        modelDataToChange = Spartan_WorkFlow_Information_by_StateItems.FirstOrDefault(m => m.Information_by_StateId == Spartan_WorkFlow_Information_by_State1.Information_by_StateId);
                    }
                    //Chaning Id Value
                    varSpartan_WorkFlow_Information_by_State.Spartan_WorkFlow = MasterId;
                    var insertId = _ISpartan_WorkFlow_Information_by_StateApiConsumer.Insert(varSpartan_WorkFlow_Information_by_State,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.Information_by_StateId = insertId;

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
        public ActionResult PostSpartan_WorkFlow_Information_by_State(List<Spartan_WorkFlow_Information_by_StateGridModelPost> Spartan_WorkFlow_Information_by_StateItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_WorkFlow_Information_by_State(MasterId, referenceId, Spartan_WorkFlow_Information_by_StateItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_WorkFlow_Information_by_StateItems != null && Spartan_WorkFlow_Information_by_StateItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_WorkFlow_Information_by_StateApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_WorkFlow_Information_by_StateItem in Spartan_WorkFlow_Information_by_StateItems)
                    {

                        //Removal Request
                        if (Spartan_WorkFlow_Information_by_StateItem.Removed)
                        {
                            result = result && _ISpartan_WorkFlow_Information_by_StateApiConsumer.Delete(Spartan_WorkFlow_Information_by_StateItem.Information_by_StateId, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Spartan_WorkFlow_Information_by_StateItem.Information_by_StateId = 0;

                        var Spartan_WorkFlow_Information_by_StateData = new Spartan_WorkFlow_Information_by_State
                        {
                            Spartan_WorkFlow = MasterId
                            ,Information_by_StateId = Spartan_WorkFlow_Information_by_StateItem.Information_by_StateId
                            ,Phase = (Convert.ToInt32(Spartan_WorkFlow_Information_by_StateItem.Phase) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_WorkFlow_Information_by_StateItem.Phase))
                            ,State = (Convert.ToInt32(Spartan_WorkFlow_Information_by_StateItem.State) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_WorkFlow_Information_by_StateItem.State))
                            ,Folder = (Convert.ToInt32(Spartan_WorkFlow_Information_by_StateItem.Folder) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_WorkFlow_Information_by_StateItem.Folder))
                            ,Visible = Spartan_WorkFlow_Information_by_StateItem.Visible
                            ,Read_Only = Spartan_WorkFlow_Information_by_StateItem.Read_Only
                            ,Required = Spartan_WorkFlow_Information_by_StateItem.Required
                            ,Label = Spartan_WorkFlow_Information_by_StateItem.Label

                        };

                        var resultId = Spartan_WorkFlow_Information_by_StateItem.Information_by_StateId > 0
                           ? _ISpartan_WorkFlow_Information_by_StateApiConsumer.Update(Spartan_WorkFlow_Information_by_StateData,null,null).Resource
                           : _ISpartan_WorkFlow_Information_by_StateApiConsumer.Insert(Spartan_WorkFlow_Information_by_StateData,null,null).Resource;

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

        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_Information_by_State_Spartan_WorkFlow_PhasesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_WorkFlow_PhasesApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_Information_by_State_Spartan_WorkFlow_StateAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_StateApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_WorkFlow_StateApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_Information_by_State_Spartan_MetadataAll()
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

        [NonAction]
        public bool CopySpartan_WorkFlow_Roles_by_State(int MasterId, int referenceId, List<Spartan_WorkFlow_Roles_by_StateGridModelPost> Spartan_WorkFlow_Roles_by_StateItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_WorkFlow_Roles_by_StateApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_WorkFlow_Roles_by_StateData = _ISpartan_WorkFlow_Roles_by_StateApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow=" + referenceId,"").Resource;
                if (Spartan_WorkFlow_Roles_by_StateData == null || Spartan_WorkFlow_Roles_by_StateData.Spartan_WorkFlow_Roles_by_States.Count == 0)
                    return true;

                var result = true;

                Spartan_WorkFlow_Roles_by_StateGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varSpartan_WorkFlow_Roles_by_State in Spartan_WorkFlow_Roles_by_StateData.Spartan_WorkFlow_Roles_by_States)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Spartan_WorkFlow_Roles_by_State Spartan_WorkFlow_Roles_by_State1 = varSpartan_WorkFlow_Roles_by_State;

                    if (Spartan_WorkFlow_Roles_by_StateItems != null && Spartan_WorkFlow_Roles_by_StateItems.Any(m => m.Roles_by_StateId == Spartan_WorkFlow_Roles_by_State1.Roles_by_StateId))
                    {
                        modelDataToChange = Spartan_WorkFlow_Roles_by_StateItems.FirstOrDefault(m => m.Roles_by_StateId == Spartan_WorkFlow_Roles_by_State1.Roles_by_StateId);
                    }
                    //Chaning Id Value
                    varSpartan_WorkFlow_Roles_by_State.Spartan_WorkFlow = MasterId;
                    var insertId = _ISpartan_WorkFlow_Roles_by_StateApiConsumer.Insert(varSpartan_WorkFlow_Roles_by_State,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.Roles_by_StateId = insertId;

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
        public ActionResult PostSpartan_WorkFlow_Roles_by_State(List<Spartan_WorkFlow_Roles_by_StateGridModelPost> Spartan_WorkFlow_Roles_by_StateItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_WorkFlow_Roles_by_State(MasterId, referenceId, Spartan_WorkFlow_Roles_by_StateItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_WorkFlow_Roles_by_StateItems != null && Spartan_WorkFlow_Roles_by_StateItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_WorkFlow_Roles_by_StateApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_WorkFlow_Roles_by_StateItem in Spartan_WorkFlow_Roles_by_StateItems)
                    {

                        //Removal Request
                        if (Spartan_WorkFlow_Roles_by_StateItem.Removed)
                        {
                            result = result && _ISpartan_WorkFlow_Roles_by_StateApiConsumer.Delete(Spartan_WorkFlow_Roles_by_StateItem.Roles_by_StateId, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Spartan_WorkFlow_Roles_by_StateItem.Roles_by_StateId = 0;

                        var Spartan_WorkFlow_Roles_by_StateData = new Spartan_WorkFlow_Roles_by_State
                        {
                            Spartan_WorkFlow = MasterId
                            ,Roles_by_StateId = Spartan_WorkFlow_Roles_by_StateItem.Roles_by_StateId
                            ,Phase = (Convert.ToInt32(Spartan_WorkFlow_Roles_by_StateItem.Phase) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_WorkFlow_Roles_by_StateItem.Phase))
                            ,State = (Convert.ToInt32(Spartan_WorkFlow_Roles_by_StateItem.State) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_WorkFlow_Roles_by_StateItem.State))
                            ,User_Role = Spartan_WorkFlow_Roles_by_StateItem.User_Role
                            ,Phase_Transition = Spartan_WorkFlow_Roles_by_StateItem.Phase_Transition
                            ,Permission_To_Consult = Spartan_WorkFlow_Roles_by_StateItem.Permission_To_Consult
                            ,Permission_To_New = Spartan_WorkFlow_Roles_by_StateItem.Permission_To_New
                            ,Permission_To_Modify = Spartan_WorkFlow_Roles_by_StateItem.Permission_To_Modify
                            ,Permission_to_Delete = Spartan_WorkFlow_Roles_by_StateItem.Permission_to_Delete
                            ,Permission_To_Export = Spartan_WorkFlow_Roles_by_StateItem.Permission_To_Export
                            ,Permission_To_Print = Spartan_WorkFlow_Roles_by_StateItem.Permission_To_Print
                            ,Permission_Settings = Spartan_WorkFlow_Roles_by_StateItem.Permission_Settings

                        };

                        var resultId = Spartan_WorkFlow_Roles_by_StateItem.Roles_by_StateId > 0
                           ? _ISpartan_WorkFlow_Roles_by_StateApiConsumer.Update(Spartan_WorkFlow_Roles_by_StateData,null,null).Resource
                           : _ISpartan_WorkFlow_Roles_by_StateApiConsumer.Insert(Spartan_WorkFlow_Roles_by_StateData,null,null).Resource;

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

        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_PhasesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_WorkFlow_PhasesApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_StateAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_StateApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_WorkFlow_StateApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_Roles_by_State_Spartan_WorkFlow_UserRoleAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_User_RoleApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_User_RoleApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_WorkFlow_Matrix_of_States(int MasterId, int referenceId, List<Spartan_WorkFlow_Matrix_of_StatesGridModelPost> Spartan_WorkFlow_Matrix_of_StatesItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_WorkFlow_Matrix_of_StatesApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_WorkFlow_Matrix_of_StatesData = _ISpartan_WorkFlow_Matrix_of_StatesApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow=" + referenceId,"").Resource;
                if (Spartan_WorkFlow_Matrix_of_StatesData == null || Spartan_WorkFlow_Matrix_of_StatesData.Spartan_WorkFlow_Matrix_of_Statess.Count == 0)
                    return true;

                var result = true;

                Spartan_WorkFlow_Matrix_of_StatesGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varSpartan_WorkFlow_Matrix_of_States in Spartan_WorkFlow_Matrix_of_StatesData.Spartan_WorkFlow_Matrix_of_Statess)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Spartan_WorkFlow_Matrix_of_States Spartan_WorkFlow_Matrix_of_States1 = varSpartan_WorkFlow_Matrix_of_States;

                    if (Spartan_WorkFlow_Matrix_of_StatesItems != null && Spartan_WorkFlow_Matrix_of_StatesItems.Any(m => m.Matrix_of_StatesId == Spartan_WorkFlow_Matrix_of_States1.Matrix_of_StatesId))
                    {
                        modelDataToChange = Spartan_WorkFlow_Matrix_of_StatesItems.FirstOrDefault(m => m.Matrix_of_StatesId == Spartan_WorkFlow_Matrix_of_States1.Matrix_of_StatesId);
                    }
                    //Chaning Id Value
                    varSpartan_WorkFlow_Matrix_of_States.Spartan_WorkFlow = MasterId;
                    var insertId = _ISpartan_WorkFlow_Matrix_of_StatesApiConsumer.Insert(varSpartan_WorkFlow_Matrix_of_States,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.Matrix_of_StatesId = insertId;

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
        public ActionResult PostSpartan_WorkFlow_Matrix_of_States(List<Spartan_WorkFlow_Matrix_of_StatesGridModelPost> Spartan_WorkFlow_Matrix_of_StatesItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_WorkFlow_Matrix_of_States(MasterId, referenceId, Spartan_WorkFlow_Matrix_of_StatesItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_WorkFlow_Matrix_of_StatesItems != null && Spartan_WorkFlow_Matrix_of_StatesItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_WorkFlow_Matrix_of_StatesApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_WorkFlow_Matrix_of_StatesItem in Spartan_WorkFlow_Matrix_of_StatesItems)
                    {

                        //Removal Request
                        if (Spartan_WorkFlow_Matrix_of_StatesItem.Removed)
                        {
                            result = result && _ISpartan_WorkFlow_Matrix_of_StatesApiConsumer.Delete(Spartan_WorkFlow_Matrix_of_StatesItem.Matrix_of_StatesId, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Spartan_WorkFlow_Matrix_of_StatesItem.Matrix_of_StatesId = 0;

                        var Spartan_WorkFlow_Matrix_of_StatesData = new Spartan_WorkFlow_Matrix_of_States
                        {
                            Spartan_WorkFlow = MasterId
                            ,Matrix_of_StatesId = Spartan_WorkFlow_Matrix_of_StatesItem.Matrix_of_StatesId
                            ,Phase = (Convert.ToInt32(Spartan_WorkFlow_Matrix_of_StatesItem.Phase) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_WorkFlow_Matrix_of_StatesItem.Phase))
                            ,State = (Convert.ToInt32(Spartan_WorkFlow_Matrix_of_StatesItem.State) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_WorkFlow_Matrix_of_StatesItem.State))
                            ,Attribute = (Convert.ToInt32(Spartan_WorkFlow_Matrix_of_StatesItem.Attribute) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_WorkFlow_Matrix_of_StatesItem.Attribute))
                            ,Visible = Spartan_WorkFlow_Matrix_of_StatesItem.Visible
                            ,Required = Spartan_WorkFlow_Matrix_of_StatesItem.Required
                            ,Read_Only = Spartan_WorkFlow_Matrix_of_StatesItem.Read_Only
                            ,Label = Spartan_WorkFlow_Matrix_of_StatesItem.Label
                            ,Default_Value = Spartan_WorkFlow_Matrix_of_StatesItem.Default_Value
                            ,Help_Text = Spartan_WorkFlow_Matrix_of_StatesItem.Help_Text

                        };

                        var resultId = Spartan_WorkFlow_Matrix_of_StatesItem.Matrix_of_StatesId > 0
                           ? _ISpartan_WorkFlow_Matrix_of_StatesApiConsumer.Update(Spartan_WorkFlow_Matrix_of_StatesData,null,null).Resource
                           : _ISpartan_WorkFlow_Matrix_of_StatesApiConsumer.Insert(Spartan_WorkFlow_Matrix_of_StatesData,null,null).Resource;

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

        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_PhasesAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_WorkFlow_PhasesApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_Matrix_of_States_Spartan_WorkFlow_StateAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_WorkFlow_StateApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_WorkFlow_StateApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_WorkFlow_Matrix_of_States_Spartan_MetadataAll()
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



        /// <summary>
        /// Write Element Array of Spartan_WorkFlow script
        /// </summary>
        /// <param name="oSpartan_WorkFlowElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Spartan_WorkFlowModuleAttributeList)
        {
            for (int i = 0; i < Spartan_WorkFlowModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Spartan_WorkFlowModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Spartan_WorkFlowModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Spartan_WorkFlowModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Spartan_WorkFlowModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Spartan_WorkFlowModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Spartan_WorkFlowModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Spartan_WorkFlowModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Spartan_WorkFlowModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Spartan_WorkFlowModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Spartan_WorkFlowModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Spartan_WorkFlowModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strSpartan_WorkFlowScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_WorkFlow.js")))
            {
                strSpartan_WorkFlowScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Spartan_WorkFlow element attributes
            string userChangeJson = jsSerialize.Serialize(Spartan_WorkFlowModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strSpartan_WorkFlowScript.IndexOf("inpuElementArray");
            string splittedString = strSpartan_WorkFlowScript.Substring(indexOfArray, strSpartan_WorkFlowScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Spartan_WorkFlowModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Spartan_WorkFlowModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strSpartan_WorkFlowScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strSpartan_WorkFlowScript.Substring(indexOfArrayHistory, strSpartan_WorkFlowScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strSpartan_WorkFlowScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strSpartan_WorkFlowScript.Substring(endIndexOfMainElement + indexOfArray, strSpartan_WorkFlowScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Spartan_WorkFlowModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Spartan_WorkFlowModuleAttributeList.ChildModuleAttributeList)
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
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Spartan_WorkFlow.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Spartan_WorkFlow.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Spartan_WorkFlow.js")))
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
        public ActionResult Spartan_WorkFlowPropertyBag()
        {
            return PartialView("Spartan_WorkFlowPropertyBag", "Spartan_WorkFlow");
        }

        public List<Business_Rule_Creation> GetBusinessRules(int ObjectId, int Attribute)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            List<Business_Rule_Creation> result = new List<Business_Rule_Creation>();
            _IBusiness_Rule_CreationApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (Attribute != 0)
            {
                result = _IBusiness_Rule_CreationApiConsumer.ListaSelAll(0, 1000, "Object = " + ObjectId + " AND Attribute = " + Attribute, "").Resource.Business_Rule_Creations;
            }
            else
            {
                List<Business_Rule_Creation> partialResult = _IBusiness_Rule_CreationApiConsumer.ListaSelAll(0, 1000, "Object = " + ObjectId, "").Resource.Business_Rule_Creations;
                foreach (var item in partialResult)
                {
                    if (item.Attribute == Attribute)
                    {
                        result.Add(item);
                    }
                    else//Busco las reglas con el event process en cuestion
                    {
                        _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                        var eventProcess = _ISpartan_BR_Process_Event_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + item.Key_Business_Rule_Creation, "").Resource;
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
        public ActionResult AddSpartan_WorkFlow_Phases(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_WorkFlow_Phases/AddSpartan_WorkFlow_Phases");
        }

        [HttpGet]
        public ActionResult AddSpartan_WorkFlow_State(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_WorkFlow_State/AddSpartan_WorkFlow_State");
        }

        [HttpGet]
        public ActionResult AddSpartan_WorkFlow_Conditions_by_State(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_WorkFlow_Conditions_by_State/AddSpartan_WorkFlow_Conditions_by_State");
        }

        [HttpGet]
        public ActionResult AddSpartan_WorkFlow_Information_by_State(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_WorkFlow_Information_by_State/AddSpartan_WorkFlow_Information_by_State");
        }

        [HttpGet]
        public ActionResult AddSpartan_WorkFlow_Roles_by_State(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_WorkFlow_Roles_by_State/AddSpartan_WorkFlow_Roles_by_State");
        }

        [HttpGet]
        public ActionResult AddSpartan_WorkFlow_Matrix_of_States(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_WorkFlow_Matrix_of_States/AddSpartan_WorkFlow_Matrix_of_States");
        }



        #endregion "Controller Methods"

        #region "Custom methods"

        public string RegenerateJS(int BussinessRuleId, short? Change, int ObjectId)
        {
            try
            {
                if (_tokenManager.GenerateToken())
                {
                    //_ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Scope_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Operation_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartaneQueryApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
                    string ObjectMR = "";
                    string Object = (string)_ISpartaneQueryApiConsumer.ExecuteQuery("SELECT URL FROM [dbo].[Spartan_Object] WHERE Object_Id=" + ObjectId).Resource;
                    var rule = _IBusiness_Rule_CreationApiConsumer.GetByKey(BussinessRuleId, false).Resource;
                    /*GET Scopes, Operation, Events*/
                    var scopes = _ISpartan_BR_Scope_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + BussinessRuleId, "").Resource;
                    var operations = _ISpartan_BR_Operation_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + BussinessRuleId, "").Resource;
                    var events = _ISpartan_BR_Process_Event_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + BussinessRuleId, "").Resource;
                    /*GET Scopes, Operation, Events*/
                    string section = "";
                    StringBuilder implementation = new StringBuilder(rule.Implementation_Code);
                    implementation = implementation.Replace("@LC@", "\"\n");
                    implementation = implementation.Replace("@LB@", "+\"");
                    if (Change == 4 || Change == 1)
                    {
                        implementation = new StringBuilder();
                    }
                    foreach (var scope in scopes.Spartan_BR_Scope_Details)
                    {
                        if (scope.Scope_Spartan_BR_Scope.Description == "Field")
                        {
                            FileWritter.Path = Request.PhysicalApplicationPath + "Uploads\\Scripts\\Rules\\" + Object + "CreateRules.js";
                            section = "//NEWBUSINESSRULE_NONE//";
                            FileWritter.Write(rule.Key_Business_Rule_Creation.ToString(),
                                rule.Attribute.Value.ToString(),
                                scope.Scope_Spartan_BR_Scope.Description,
                                "None",
                                section,
                                implementation,
                                (int)Change,
                                "Field");
                        }
                        else
                        {
                            if (operations.RowCount > 0)
                            {
                                foreach (var operation in operations.Spartan_BR_Operation_Details)
                                {
                                    if (operation.Operation_Spartan_BR_Operation.Description == "List")
                                    {
                                        FileWritter.Path = Request.PhysicalApplicationPath + "Uploads\\Scripts\\Rules\\" + Object + "IndexRules.js";
                                        foreach (var ev in events.Spartan_BR_Process_Event_Details)
                                        {
                                            section = "//NEWBUSINESSRULE_" + ev.Process_Event_Spartan_BR_Process_Event.Description.Replace(" ", "").ToUpper() + "//";
                                            FileWritter.Write(rule.Key_Business_Rule_Creation.ToString(),
                                                rule.Attribute.Value.ToString(),
                                                scope.Scope_Spartan_BR_Scope.Description,
                                                "None",
                                                section,
                                                implementation,
                                                (int)Change,
                                                operation.Operation_Spartan_BR_Operation.Description);
                                        }

                                    }
                                    else
                                    {
                                        FileWritter.Path = Request.PhysicalApplicationPath + "Uploads\\Scripts\\Rules\\" + Object + "CreateRules.js";

                                        foreach (var ev in events.Spartan_BR_Process_Event_Details)
                                        {
                                            if (ev.Process_Event_Spartan_BR_Process_Event.Description == "Screen Opening")
                                                section = "//NEWBUSINESSRULE_SCREENOPENING//";
                                            else
                                            {
                                                if (rule.Attribute.HasValue && rule.Attribute > 10)
                                                {
                                                    Spartan_Metadata att = _ISpartan_MetadataApiConsumer.GetByKey(rule.Attribute.Value, false).Resource;
                                                    if (att.Relation_Type.HasValue && att.Relation_Type.Value == 2)
                                                    {
                                                        ObjectMR = (string)_ISpartaneQueryApiConsumer.ExecuteQuery("SELECT URL FROM [dbo].[Spartan_Object] WHERE Object_Id=" + att.Related_Object_Id).Resource;
                                                        section = "//NEWBUSINESSRULE_" + ev.Process_Event_Spartan_BR_Process_Event.Description.Replace(" ", "").ToUpper() + "_" + ObjectMR + "//";
                                                    }
                                                }
                                                else
                                                {
                                                    section = "//NEWBUSINESSRULE_" + ev.Process_Event_Spartan_BR_Process_Event.Description.Replace(" ", "").ToUpper() + "//";
                                                }
                                            }

                                            FileWritter.Write(rule.Key_Business_Rule_Creation.ToString(),
                                                rule.Attribute.Value.ToString(),
                                                scope.Scope_Spartan_BR_Scope.Description,
                                                ev.Process_Event_Spartan_BR_Process_Event.Description.Replace(" ", "").ToUpper().ToString(),
                                                section,
                                                implementation,
                                                (int)Change,
                                                operation.Operation_Spartan_BR_Operation.Description);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
		
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

            _ISpartan_WorkFlowApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_WorkFlowPropertyMapper());
			
            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True")
            {
                var advanceFilter =
                    (Spartan_WorkFlowAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_WorkFlowApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_WorkFlows == null)
                result.Spartan_WorkFlows = new List<Spartan_WorkFlow>();

            var data = result.Spartan_WorkFlows.Select(m => new Spartan_WorkFlowGridModel
            {
                WorkFlowId = m.WorkFlowId
			,Name = m.Name
			,Description = m.Description
			,Objective = m.Objective
                        ,StatusDescription = (string)m.Status_Spartan_WorkFlow_Status.Description
                        ,ObjectName = (string)m.Object_Spartan_Object.Name

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Spartan_WorkFlowList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Spartan_WorkFlowList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "Spartan_WorkFlowList_" + DateTime.Now.ToString());
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

            _ISpartan_WorkFlowApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Spartan_WorkFlowPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _ISpartan_WorkFlowApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Spartan_WorkFlows == null)
                result.Spartan_WorkFlows = new List<Spartan_WorkFlow>();

            var data = result.Spartan_WorkFlows.Select(m => new Spartan_WorkFlowGridModel
            {
                WorkFlowId = m.WorkFlowId
			,Name = m.Name
			,Description = m.Description
			,Objective = m.Objective
                        ,StatusDescription = (string)m.Status_Spartan_WorkFlow_Status.Description
                        ,ObjectName = (string)m.Object_Spartan_Object.Name

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
