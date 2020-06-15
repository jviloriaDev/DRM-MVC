using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Business_Rule_Creation;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Spartan_BR_Conditions_Detail;
using Spartane.Core.Domain.Spartan_BR_Condition_Operator;
using Spartane.Core.Domain.Spartan_BR_Condition;

using Spartane.Core.Domain.Spartan_BR_Actions_True_Detail;
using Spartane.Core.Domain.Spartan_BR_Action_Classification;
using Spartane.Core.Domain.Spartan_BR_Action;
using Spartane.Core.Domain.Spartan_BR_Action_Result;

using Spartane.Core.Domain.Spartan_BR_Actions_False_Detail;
using Spartane.Core.Domain.Spartan_BR_Action_Classification;
using Spartane.Core.Domain.Spartan_BR_Action;
using Spartane.Core.Domain.Spartan_BR_Action_Result;

using Spartane.Core.Domain.Spartan_BR_Operation_Detail;
using Spartane.Core.Domain.Spartan_BR_Operation;

using Spartane.Core.Domain.Spartan_BR_Process_Event_Detail;
using Spartane.Core.Domain.Spartan_BR_Process_Event;

using Spartane.Core.Domain.Spartan_BR_Peer_Review;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Spartan_BR_Rejection_Reason;

using Spartane.Core.Domain.Spartan_BR_Testing;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Spartan_BR_Rejection_Reason;

using Spartane.Core.Domain.Spartan_BR_Scope_Detail;
using Spartane.Core.Domain.Spartan_BR_Scope;

using Spartane.Core.Domain.Spartan_BR_Status;
using Spartane.Core.Domain.Spartan_BR_Complexity;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Business_Rule_Creation;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Business_Rule_Creation;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Conditions_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Condition_Operator;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Condition;

using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Actions_True_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Classification;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Result;

using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Actions_False_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Classification;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Result;

using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operation_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operation;

using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event;

using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Peer_Review;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Rejection_Reason;

using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Testing;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Rejection_Reason;

using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Scope_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Scope;

using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Status;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Complexity;

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
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operator_Type;
using Spartane.Core.Domain.Spartan_BR_Action_Configuration_Detail;
using Spartane.Core.Domain.Spartan_BR_Operator_Type;
using Spartane.Web.Areas.WebApiConsumer.SpartaneQuery;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Configuration_Detail;
using Spartane.Core.Domain.Spartan_BR_Action_Param_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Param_Type;
using Spartane.Core.Domain.SpartaneObject;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Object;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;
using Spartane.Web.Areas.WebApiConsumer.SpartaneObject;
using Spartane.Core.Domain.Spartan_Metadata;
using System.Text;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_History;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Type_History;
using Spartane.Core.Domain.Spartan_BR_History;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Event_Restrictions_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operation_Restrictions_Detail;
using Spartane.Core.Domain.Spartan_BR_Operation_Restrictions_Detail;
using Spartane.Core.Domain.Spartan_BR_Event_Restrictions_Detail;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Business_Rule_CreationController : Controller
    {
        #region "variable declaration"

        private IBusiness_Rule_CreationService service = null;
        private IBusiness_Rule_CreationApiConsumer _IBusiness_Rule_CreationApiConsumer;
        private ISpartan_UserApiConsumer _ISpartan_UserApiConsumer;
        private ISpartan_BR_Conditions_DetailApiConsumer _ISpartan_BR_Conditions_DetailApiConsumer;
        private ISpartan_BR_Condition_OperatorApiConsumer _ISpartan_BR_Condition_OperatorApiConsumer;
        private ISpartan_BR_ConditionApiConsumer _ISpartan_BR_ConditionApiConsumer;

        private ISpartan_BR_Actions_True_DetailApiConsumer _ISpartan_BR_Actions_True_DetailApiConsumer;
        private ISpartan_BR_Action_ClassificationApiConsumer _ISpartan_BR_Action_ClassificationApiConsumer;
        private ISpartan_BR_ActionApiConsumer _ISpartan_BR_ActionApiConsumer;
        private ISpartan_BR_Action_ResultApiConsumer _ISpartan_BR_Action_ResultApiConsumer;

        private ISpartan_BR_Actions_False_DetailApiConsumer _ISpartan_BR_Actions_False_DetailApiConsumer;

        private ISpartan_BR_Operation_DetailApiConsumer _ISpartan_BR_Operation_DetailApiConsumer;
        private ISpartan_BR_OperationApiConsumer _ISpartan_BR_OperationApiConsumer;

        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartan_BR_Process_EventApiConsumer _ISpartan_BR_Process_EventApiConsumer;

        private ISpartan_BR_Peer_ReviewApiConsumer _ISpartan_BR_Peer_ReviewApiConsumer;
        private ISpartan_BR_Rejection_ReasonApiConsumer _ISpartan_BR_Rejection_ReasonApiConsumer;

        private ISpartan_BR_TestingApiConsumer _ISpartan_BR_TestingApiConsumer;

        private ISpartan_BR_Scope_DetailApiConsumer _ISpartan_BR_Scope_DetailApiConsumer;
        private ISpartan_BR_ScopeApiConsumer _ISpartan_BR_ScopeApiConsumer;

        private ISpartan_BR_StatusApiConsumer _ISpartan_BR_StatusApiConsumer;
        private ISpartan_BR_ComplexityApiConsumer _ISpartan_BR_ComplexityApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;
        private IGeneratePDFApiConsumer _IGeneratePDFApiConsumer;
        private ISpartan_FormatApiConsumer _ISpartan_FormatApiConsumer;
        private ISpartan_Format_PermissionsApiConsumer _ISpartan_Format_PermissionsApiConsumer;
        private ISpartan_BR_Operator_TypeApiConsumer _ISpartan_BR_Operator_TypeApiConsumer;
        private ISpartan_BR_Action_Configuration_DetailApiConsumer _ISpartan_BR_Action_Configuration_DetailApiConsumer;
        private ISpartaneQueryApiConsumer _ISpartaneQueryApiConsumer;
        private ISpartan_BR_Action_Param_TypeApiConsumer _ISpartan_BR_Action_Param_TypeApiConsumer;

        private ISpartan_BR_HistoryApiConsumer _ISpartan_BR_HistoryApiConsumer;
        private ISpartan_BR_Type_HistoryApiConsumer _ISpartan_BR_Type_HistoryApiConsumer;

        private ISpartaneObjectApiConsumer _ISpartan_ObjectApiConsumer;
        private ISpartan_MetadataApiConsumer _ISpartan_MetadataApiConsumer;

        private ISpartan_BR_Event_Restrictions_DetailApiConsumer _ISpartan_BR_Event_Restrictions_DetailApiConsumer;
        private ISpartan_BR_Operation_Restrictions_DetailApiConsumer _ISpartan_BR_Operation_Restrictions_DetailApiConsumer;

        #endregion "variable declaration"

        #region "Constructor Declaration"


        public Business_Rule_CreationController(IBusiness_Rule_CreationService service, ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IBusiness_Rule_CreationApiConsumer Business_Rule_CreationApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_UserApiConsumer Spartan_UserApiConsumer, ISpartan_BR_Conditions_DetailApiConsumer Spartan_BR_Conditions_DetailApiConsumer, ISpartan_BR_Condition_OperatorApiConsumer Spartan_BR_Condition_OperatorApiConsumer, ISpartan_BR_ConditionApiConsumer Spartan_BR_ConditionApiConsumer, ISpartan_BR_Actions_True_DetailApiConsumer Spartan_BR_Actions_True_DetailApiConsumer, ISpartan_BR_Action_ClassificationApiConsumer Spartan_BR_Action_ClassificationApiConsumer, ISpartan_BR_ActionApiConsumer Spartan_BR_ActionApiConsumer, ISpartan_BR_Action_ResultApiConsumer Spartan_BR_Action_ResultApiConsumer, ISpartan_BR_Actions_False_DetailApiConsumer Spartan_BR_Actions_False_DetailApiConsumer, ISpartan_BR_Operation_DetailApiConsumer Spartan_BR_Operation_DetailApiConsumer, ISpartan_BR_OperationApiConsumer Spartan_BR_OperationApiConsumer, ISpartan_BR_Process_EventApiConsumer Spartan_BR_Process_EventApiConsumer, ISpartan_BR_Peer_ReviewApiConsumer Spartan_BR_Peer_ReviewApiConsumer, ISpartan_BR_Rejection_ReasonApiConsumer Spartan_BR_Rejection_ReasonApiConsumer, ISpartan_BR_TestingApiConsumer Spartan_BR_TestingApiConsumer, ISpartan_BR_Scope_DetailApiConsumer Spartan_BR_Scope_DetailApiConsumer, ISpartan_BR_ScopeApiConsumer Spartan_BR_ScopeApiConsumer, ISpartan_BR_StatusApiConsumer Spartan_BR_StatusApiConsumer, ISpartan_BR_ComplexityApiConsumer Spartan_BR_ComplexityApiConsumer, ISpartan_BR_Operator_TypeApiConsumer Spartan_BR_Operator_TypeApiConsumer,
            ISpartan_BR_Action_Configuration_DetailApiConsumer Spartan_BR_Action_Configuration_DetailApiConsumer, ISpartaneQueryApiConsumer SpartaneQueryApiConsumer,
            ISpartan_BR_Action_Param_TypeApiConsumer Spartan_BR_Action_Param_TypeApiConsumer, ISpartaneObjectApiConsumer Spartan_ObjectApiConsumer,
            ISpartan_MetadataApiConsumer Spartan_MetadataApiConsumer, ISpartan_BR_HistoryApiConsumer Spartan_BR_HistoryApiConsumer, ISpartan_BR_Type_HistoryApiConsumer Spartan_BR_Type_HistoryApiConsumer,
            ISpartan_BR_Event_Restrictions_DetailApiConsumer Spartan_BR_Event_Restrictions_DetailApiConsumer, ISpartan_BR_Operation_Restrictions_DetailApiConsumer Spartan_BR_Operation_Restrictions_DetailApiConsumer)
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IBusiness_Rule_CreationApiConsumer = Business_Rule_CreationApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._ISpartan_BR_Conditions_DetailApiConsumer = Spartan_BR_Conditions_DetailApiConsumer;
            this._ISpartan_BR_Condition_OperatorApiConsumer = Spartan_BR_Condition_OperatorApiConsumer;
            this._ISpartan_BR_ConditionApiConsumer = Spartan_BR_ConditionApiConsumer;

            this._ISpartan_BR_Actions_True_DetailApiConsumer = Spartan_BR_Actions_True_DetailApiConsumer;
            this._ISpartan_BR_Action_ClassificationApiConsumer = Spartan_BR_Action_ClassificationApiConsumer;
            this._ISpartan_BR_ActionApiConsumer = Spartan_BR_ActionApiConsumer;
            this._ISpartan_BR_Action_ResultApiConsumer = Spartan_BR_Action_ResultApiConsumer;

            this._ISpartan_BR_Actions_False_DetailApiConsumer = Spartan_BR_Actions_False_DetailApiConsumer;
            this._ISpartan_BR_Action_ClassificationApiConsumer = Spartan_BR_Action_ClassificationApiConsumer;
            this._ISpartan_BR_ActionApiConsumer = Spartan_BR_ActionApiConsumer;
            this._ISpartan_BR_Action_ResultApiConsumer = Spartan_BR_Action_ResultApiConsumer;

            this._ISpartan_BR_Operation_DetailApiConsumer = Spartan_BR_Operation_DetailApiConsumer;
            this._ISpartan_BR_OperationApiConsumer = Spartan_BR_OperationApiConsumer;

            this._ISpartan_BR_Process_EventApiConsumer = Spartan_BR_Process_EventApiConsumer;

            this._ISpartan_BR_Peer_ReviewApiConsumer = Spartan_BR_Peer_ReviewApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._ISpartan_BR_Rejection_ReasonApiConsumer = Spartan_BR_Rejection_ReasonApiConsumer;

            this._ISpartan_BR_TestingApiConsumer = Spartan_BR_TestingApiConsumer;
            this._ISpartan_UserApiConsumer = Spartan_UserApiConsumer;
            this._ISpartan_BR_Rejection_ReasonApiConsumer = Spartan_BR_Rejection_ReasonApiConsumer;

            this._ISpartan_BR_Scope_DetailApiConsumer = Spartan_BR_Scope_DetailApiConsumer;
            this._ISpartan_BR_ScopeApiConsumer = Spartan_BR_ScopeApiConsumer;

            this._ISpartan_BR_StatusApiConsumer = Spartan_BR_StatusApiConsumer;
            this._ISpartan_BR_ComplexityApiConsumer = Spartan_BR_ComplexityApiConsumer;

            this._ISpartan_BR_Operator_TypeApiConsumer = Spartan_BR_Operator_TypeApiConsumer;
            this._ISpartan_BR_Action_Configuration_DetailApiConsumer = Spartan_BR_Action_Configuration_DetailApiConsumer;
            this._ISpartaneQueryApiConsumer = SpartaneQueryApiConsumer;
            this._ISpartan_BR_Action_Param_TypeApiConsumer = Spartan_BR_Action_Param_TypeApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;

            this._ISpartan_ObjectApiConsumer = Spartan_ObjectApiConsumer;
            this._ISpartan_MetadataApiConsumer = Spartan_MetadataApiConsumer;

            this._ISpartan_BR_HistoryApiConsumer = Spartan_BR_HistoryApiConsumer;
            this._ISpartan_BR_Type_HistoryApiConsumer = Spartan_BR_Type_HistoryApiConsumer;

            this._ISpartan_BR_Event_Restrictions_DetailApiConsumer = Spartan_BR_Event_Restrictions_DetailApiConsumer;
            this._ISpartan_BR_Operation_Restrictions_DetailApiConsumer = Spartan_BR_Operation_Restrictions_DetailApiConsumer;
        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Business_Rule_Creation
        [ObjectAuth(ObjectId = (ModuleObjectId)35351, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            return View();
        }

        // GET: Frontal/Business_Rule_Creation/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)35351, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0, int consult = 0, int ModuleId = 0)
        {
            var varBusiness_Rule_Creation = new Business_Rule_CreationModel();

            ViewBag.ObjectId = "35351";
            ViewBag.Operation = "New";

            ViewBag.IsNew = true;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {
                ViewBag.IsNew = false;
                ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IBusiness_Rule_CreationApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Business_Rule_CreationData = _IBusiness_Rule_CreationApiConsumer.GetByKeyComplete(Id).Resource.Business_Rule_Creations[0];
                if (Business_Rule_CreationData == null)
                    return HttpNotFound();

                varBusiness_Rule_Creation = new Business_Rule_CreationModel
                {
                    Key_Business_Rule_Creation = (int)Business_Rule_CreationData.Key_Business_Rule_Creation
                    ,
                    User = Business_Rule_CreationData.User
                    ,
                    UserName = (string)Business_Rule_CreationData.User_Spartan_User.Name
                    ,
                    Creation_Date = (Business_Rule_CreationData.Creation_Date == null ? string.Empty : Convert.ToDateTime(Business_Rule_CreationData.Creation_Date).ToString(ConfigurationProperty.DateFormat))
                    ,
                    Creation_Hour = Business_Rule_CreationData.Creation_Hour
                    ,
                    Last_Updated_Date = (Business_Rule_CreationData.Last_Updated_Date == null ? string.Empty : Convert.ToDateTime(Business_Rule_CreationData.Last_Updated_Date).ToString(ConfigurationProperty.DateFormat))
                    ,
                    Last_Updated_Hour = Business_Rule_CreationData.Last_Updated_Hour
                    ,
                    Time_that_took = Business_Rule_CreationData.Time_that_took
                    ,
                    Name = Business_Rule_CreationData.Name
                    ,
                    Documentation = Business_Rule_CreationData.Documentation
                    ,
                    Status = Business_Rule_CreationData.Status
                    ,
                    StatusDescription = CultureHelper.GetTraduction(Business_Rule_CreationData.Status_Spartan_BR_Status.StatusId.ToString(), "Spartan_BR_Status", Business_Rule_CreationData.Status_Spartan_BR_Status.Description, "Description")
                    ,
                    Complexity = Business_Rule_CreationData.Complexity
                    ,
                    ComplexityDescription = CultureHelper.GetTraduction(Business_Rule_CreationData.Complexity_Spartan_BR_Complexity.Key_Complexity.ToString(), "Spartan_BR_Complexity", Business_Rule_CreationData.Complexity_Spartan_BR_Complexity.Description, "Description")

                };
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.DocumentationSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varBusiness_Rule_Creation.Documentation).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_User = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_User != null && Spartan_Users_User.Resource != null)
                ViewBag.Spartan_Users_User = Spartan_Users_User.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(),
                    Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ISpartan_BR_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Statuss_Status = _ISpartan_BR_StatusApiConsumer.SelAll(true);
            if (Spartan_BR_Statuss_Status != null && Spartan_BR_Statuss_Status.Resource != null)
                ViewBag.Spartan_BR_Statuss_Status = Spartan_BR_Statuss_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.StatusId), "Spartan_BR_Status", m.Description, "Description"),
                    Value = Convert.ToString(m.StatusId)
                }).ToList();
            _ISpartan_BR_ComplexityApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Complexitys_Complexity = _ISpartan_BR_ComplexityApiConsumer.SelAll(true);
            if (Spartan_BR_Complexitys_Complexity != null && Spartan_BR_Complexitys_Complexity.Resource != null)
                ViewBag.Spartan_BR_Complexitys_Complexity = Spartan_BR_Complexitys_Complexity.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Key_Complexity), "Spartan_BR_Complexity", m.Description, "Description"),
                    Value = Convert.ToString(m.Key_Complexity)
                }).ToList();


            ViewBag.Consult = consult == 1;
            if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varBusiness_Rule_Creation);
        }

        [HttpGet]
        public ActionResult AddBusiness_Rule_Creation(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35351);
            ViewBag.Permission = permission;
            if (!_tokenManager.GenerateToken())
                return null;
            _IBusiness_Rule_CreationApiConsumer.SetAuthHeader(_tokenManager.Token);
            Business_Rule_CreationModel varBusiness_Rule_Creation = new Business_Rule_CreationModel();
            var permissionSpartan_BR_Conditions_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35352, ModuleId);
            ViewBag.PermissionSpartan_BR_Conditions_Detail = permissionSpartan_BR_Conditions_Detail;
            var permissionSpartan_BR_Actions_True_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35353, ModuleId);
            ViewBag.PermissionSpartan_BR_Actions_True_Detail = permissionSpartan_BR_Actions_True_Detail;
            var permissionSpartan_BR_Actions_False_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35354, ModuleId);
            ViewBag.PermissionSpartan_BR_Actions_False_Detail = permissionSpartan_BR_Actions_False_Detail;
            var permissionSpartan_BR_Operation_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35355, ModuleId);
            ViewBag.PermissionSpartan_BR_Operation_Detail = permissionSpartan_BR_Operation_Detail;
            var permissionSpartan_BR_Process_Event_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35356, ModuleId);
            ViewBag.PermissionSpartan_BR_Process_Event_Detail = permissionSpartan_BR_Process_Event_Detail;
            var permissionSpartan_BR_Peer_Review = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35347, ModuleId);
            ViewBag.PermissionSpartan_BR_Peer_Review = permissionSpartan_BR_Peer_Review;
            var permissionSpartan_BR_Testing = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35348, ModuleId);
            ViewBag.PermissionSpartan_BR_Testing = permissionSpartan_BR_Testing;
            var permissionSpartan_BR_Scope_Detail = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 35357, ModuleId);
            ViewBag.PermissionSpartan_BR_Scope_Detail = permissionSpartan_BR_Scope_Detail;


            if (id.ToString() != "0")
            {
                var Business_Rule_CreationsData = _IBusiness_Rule_CreationApiConsumer.ListaSelAll(0, 1000, "Key_Business_Rule_Creation=" + id, "").Resource.Business_Rule_Creations;

                if (Business_Rule_CreationsData != null && Business_Rule_CreationsData.Count > 0)
                {
                    var Business_Rule_CreationData = Business_Rule_CreationsData.First();
                    varBusiness_Rule_Creation = new Business_Rule_CreationModel
                    {
                        Key_Business_Rule_Creation = Business_Rule_CreationData.Key_Business_Rule_Creation
                        ,
                        User = Business_Rule_CreationData.User
                    ,
                        UserName = (string)Business_Rule_CreationData.User_Spartan_User.Name
                    ,
                        Creation_Date = (Business_Rule_CreationData.Creation_Date == null ? string.Empty : Convert.ToDateTime(Business_Rule_CreationData.Creation_Date).ToString(ConfigurationProperty.DateFormat))
                    ,
                        Creation_Hour = Business_Rule_CreationData.Creation_Hour
                    ,
                        Last_Updated_Date = (Business_Rule_CreationData.Last_Updated_Date == null ? string.Empty : Convert.ToDateTime(Business_Rule_CreationData.Last_Updated_Date).ToString(ConfigurationProperty.DateFormat))
                    ,
                        Last_Updated_Hour = Business_Rule_CreationData.Last_Updated_Hour
                    ,
                        Time_that_took = Business_Rule_CreationData.Time_that_took
                    ,
                        Name = Business_Rule_CreationData.Name
                    ,
                        Documentation = Business_Rule_CreationData.Documentation
                    ,
                        Status = Business_Rule_CreationData.Status
                    ,
                        StatusDescription = (string)Business_Rule_CreationData.Status_Spartan_BR_Status.Description
                    ,
                        Complexity = Business_Rule_CreationData.Complexity
                    ,
                        ComplexityDescription = (string)Business_Rule_CreationData.Complexity_Spartan_BR_Complexity.Description

                    };
                }
                _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                ViewBag.DocumentationSpartane_File = _ISpartane_FileApiConsumer.GetByKey(varBusiness_Rule_Creation.Documentation).Resource;

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_User = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_User != null && Spartan_Users_User.Resource != null)
                ViewBag.Spartan_Users_User = Spartan_Users_User.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(),
                    Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ISpartan_BR_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Statuss_Status = _ISpartan_BR_StatusApiConsumer.SelAll(true);
            if (Spartan_BR_Statuss_Status != null && Spartan_BR_Statuss_Status.Resource != null)
                ViewBag.Spartan_BR_Statuss_Status = Spartan_BR_Statuss_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(),
                    Value = Convert.ToString(m.StatusId)
                }).ToList();
            _ISpartan_BR_ComplexityApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Complexitys_Complexity = _ISpartan_BR_ComplexityApiConsumer.SelAll(true);
            if (Spartan_BR_Complexitys_Complexity != null && Spartan_BR_Complexitys_Complexity.Resource != null)
                ViewBag.Spartan_BR_Complexitys_Complexity = Spartan_BR_Complexitys_Complexity.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(),
                    Value = Convert.ToString(m.Key_Complexity)
                }).ToList();


            return PartialView("AddBusiness_Rule_Creation", varBusiness_Rule_Creation);
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

        public ActionResult GetSpartan_BR_History(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_HistoryGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_HistoryApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_BR_History.BusinessRule=" + RelationId;
            if ("int" == "string")
            {
                where = "Spartan_BR_History.BusinessRule='" + RelationId + "'";
            }
            var result = _ISpartan_BR_HistoryApiConsumer.ListaSelAll(start, pageSize, where, "Spartan_BR_History.Change_Date DESC, Spartan_BR_History.Hour_Date DESC").Resource;
            if (result.Spartan_BR_Historys == null)
                result.Spartan_BR_Historys = new List<Spartan_BR_History>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Historys.Select(m => new Spartan_BR_HistoryGridModel
                {
                    Key_History = m.Key_History
                        ,
                    User_logged = m.User_logged
                        ,
                    User_loggedName = (string)m.User_logged_Spartan_User.Name
                        ,
                    Status = m.Status
                        ,
                    StatusDescription = CultureHelper.GetTraduction(m.Status_Spartan_BR_Status.StatusId.ToString(), "Spartan_BR_Status", m.Status_Spartan_BR_Status.Description, "Description")
            ,
                    Change_Date = (m.Change_Date == null ? string.Empty : Convert.ToDateTime(m.Change_Date).ToString(ConfigurationProperty.DateFormat))
            ,
                    Hour_Date = m.Hour_Date
            ,
                    Time_elapsed = m.Time_elapsed
                        ,
                    Change_Type = m.Change_Type
                        ,
                    Change_TypeDescription = CultureHelper.GetTraduction(m.Change_Type_Spartan_BR_Type_History.Key_Type_History.ToString(), "Spartan_BR_Type_History", m.Change_Type_Spartan_BR_Type_History.Description, "Description")
            ,
                    Conditions = m.Conditions
            ,
                    Actions_True = m.Actions_True
            ,
                    Actions_False = m.Actions_False

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpGet]
        public ActionResult GetSpartan_BR_History_Spartan_UserAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_UserApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_BR_History_Spartan_BR_StatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_StatusApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
                    item.Description = CultureHelper.GetTraduction(Convert.ToString(item.StatusId), "Spartan_BR_Status", item.Description, "Description");
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_BR_History_Spartan_BR_Type_HistoryAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Type_HistoryApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Type_HistoryApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
                    item.Description = CultureHelper.GetTraduction(Convert.ToString(item.Key_Type_History), "Spartan_BR_Type_History", item.Description, "Description");
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_UserAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_UserApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_BR_StatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_StatusApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
                    item.Description = CultureHelper.GetTraduction(Convert.ToString(item.StatusId), "Spartan_BR_Status", item.Description, "Description");
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_BR_ComplexityAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_ComplexityApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_ComplexityApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
                    item.Description = CultureHelper.GetTraduction(Convert.ToString(item.Key_Complexity), "Spartan_BR_Complexity", item.Description, "Description");
                }
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
        public JsonResult ShowAdvanceFilter(Business_Rule_CreationAdvanceSearchModel model, int idFilter = -1)
        {
            if (ModelState.IsValid)
            {
                Session["AdvanceSearch"] = model;
                if (idFilter != -1)
                {
                    Session["AdvanceReportFilter"] = GetAdvanceFilter(model);
                    return Json(true, JsonRequestBehavior.AllowGet);
                    //return RedirectToAction("Index", "Report", new { id = idFilter });
                }
                return Json(true, JsonRequestBehavior.AllowGet);
                //return RedirectToAction("Index");
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

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_User = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_User != null && Spartan_Users_User.Resource != null)
                ViewBag.Spartan_Users_User = Spartan_Users_User.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(),
                    Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ISpartan_BR_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Statuss_Status = _ISpartan_BR_StatusApiConsumer.SelAll(true);
            if (Spartan_BR_Statuss_Status != null && Spartan_BR_Statuss_Status.Resource != null)
                ViewBag.Spartan_BR_Statuss_Status = Spartan_BR_Statuss_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(),
                    Value = Convert.ToString(m.StatusId)
                }).ToList();
            _ISpartan_BR_ComplexityApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Complexitys_Complexity = _ISpartan_BR_ComplexityApiConsumer.SelAll(true);
            if (Spartan_BR_Complexitys_Complexity != null && Spartan_BR_Complexitys_Complexity.Resource != null)
                ViewBag.Spartan_BR_Complexitys_Complexity = Spartan_BR_Complexitys_Complexity.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(),
                    Value = Convert.ToString(m.Key_Complexity)
                }).ToList();


            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_Users_User = _ISpartan_UserApiConsumer.SelAll(true);
            if (Spartan_Users_User != null && Spartan_Users_User.Resource != null)
                ViewBag.Spartan_Users_User = Spartan_Users_User.Resource.OrderBy(m => m.Name).Select(m => new SelectListItem
                {
                    Text = m.Name.ToString(),
                    Value = Convert.ToString(m.Id_User)
                }).ToList();
            _ISpartan_BR_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Statuss_Status = _ISpartan_BR_StatusApiConsumer.SelAll(true);
            if (Spartan_BR_Statuss_Status != null && Spartan_BR_Statuss_Status.Resource != null)
                ViewBag.Spartan_BR_Statuss_Status = Spartan_BR_Statuss_Status.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(),
                    Value = Convert.ToString(m.StatusId)
                }).ToList();
            _ISpartan_BR_ComplexityApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Spartan_BR_Complexitys_Complexity = _ISpartan_BR_ComplexityApiConsumer.SelAll(true);
            if (Spartan_BR_Complexitys_Complexity != null && Spartan_BR_Complexitys_Complexity.Resource != null)
                ViewBag.Spartan_BR_Complexitys_Complexity = Spartan_BR_Complexitys_Complexity.Resource.OrderBy(m => m.Description).Select(m => new SelectListItem
                {
                    Text = m.Description.ToString(),
                    Value = Convert.ToString(m.Key_Complexity)
                }).ToList();


            var previousFiltersObj = new Business_Rule_CreationAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Business_Rule_CreationAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Business_Rule_CreationAdvanceSearchModel());
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
                configuration = GridQueryHelper.GetConfiguration(filter, new Business_Rule_CreationPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IBusiness_Rule_CreationApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Business_Rule_Creations == null)
                result.Business_Rule_Creations = new List<Business_Rule_Creation>();

            return Json(new
            {
                data = result.Business_Rule_Creations.Select(m => new Business_Rule_CreationGridModel
                {
                    Key_Business_Rule_Creation = m.Key_Business_Rule_Creation
                    ,
                    UserName = (string)m.User_Spartan_User.Name
                    ,
                    Creation_Date = (m.Creation_Date == null ? string.Empty : Convert.ToDateTime(m.Creation_Date).ToString(ConfigurationProperty.DateFormat))
        ,
                    Creation_Hour = m.Creation_Hour
                    ,
                    Last_Updated_Date = (m.Last_Updated_Date == null ? string.Empty : Convert.ToDateTime(m.Last_Updated_Date).ToString(ConfigurationProperty.DateFormat))
        ,
                    Last_Updated_Hour = m.Last_Updated_Hour
        ,
                    Time_that_took = m.Time_that_took
        ,
                    Name = m.Name
        ,
                    Documentation = m.Documentation
                    ,
                    StatusDescription = CultureHelper.GetTraduction(m.Status_Spartan_BR_Status.StatusId.ToString(), "Spartan_BR_Status", m.Status_Spartan_BR_Status.Description, "Description") ?? (string)m.Status_Spartan_BR_Status.Description
                    ,
                    ComplexityDescription = CultureHelper.GetTraduction(m.Complexity_Spartan_BR_Complexity.Key_Complexity.ToString(), "Spartan_BR_Complexity", m.Complexity_Spartan_BR_Complexity.Description, "Description") ?? (string)m.Complexity_Spartan_BR_Complexity.Description

                }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Business_Rule_Creation from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Business_Rule_Creation Entity</returns>
        public ActionResult GetBusiness_Rule_CreationList(int ObjectId, int Attribute, int sEcho, int iDisplayStart, int iDisplayLength, string where, string order)
        {
            Session["ObjectIdRules"] = ObjectId;
            Session["AttributeRules"] = Attribute;
            where = HttpUtility.UrlEncode(where);
            int sortColumn = -1;
            string sortDirection = "asc";
            if (iDisplayLength == -1)
            {
                //length = TOTAL_ROWS;
                iDisplayLength = Int32.MaxValue;
            }
            // note: we only sort one column at a time
            if (Request.QueryString["iSortCol_0"] != null && Request.QueryString["iSortCol_0"] != "0")
            {
                sortColumn = int.Parse(Request.QueryString["iSortCol_0"]);
                order = "";
            }
            if (Request.QueryString["sSortDir_0"] != null)
            {
                sortDirection = Request.QueryString["sSortDir_0"];
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IBusiness_Rule_CreationApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Business_Rule_CreationPropertyMapper());
            if (!String.IsNullOrEmpty(where))
            {
                configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            //Adding Advance Search
            if (Session["AdvanceSearch"] != null)
            {
                if (Session["AdvanceSearch"].GetType() == typeof(Business_Rule_CreationAdvanceSearchModel))
                {
                    var advanceFilter =
                    (Business_Rule_CreationAdvanceSearchModel)Session["AdvanceSearch"];
                    configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
                }
                else
                {
                    Session.Remove("AdvanceSearch");
                }
            }

            Business_Rule_CreationPropertyMapper oBusiness_Rule_CreationPropertyMapper = new Business_Rule_CreationPropertyMapper();
            if (String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = oBusiness_Rule_CreationPropertyMapper.GetPropertyName(Convert.ToString(Request.QueryString["mDataProp_" + sortColumn])) + " " + sortDirection;
            }

            if (configuration.WhereClause != "")
                configuration.WhereClause += " AND ";
            configuration.WhereClause += "Business_Rule_Creation.Object = " + ObjectId + " AND Business_Rule_Creation.Attribute = " + Attribute;

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IBusiness_Rule_CreationApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Business_Rule_Creations == null)
                result.Business_Rule_Creations = new List<Business_Rule_Creation>();

            return Json(new
            {
                aaData = result.Business_Rule_Creations.Select(m => new Business_Rule_CreationGridModel
                {
                    Key_Business_Rule_Creation = m.Key_Business_Rule_Creation
                            ,
                    UserName = (string)m.User_Spartan_User.Name
                            ,
                    Creation_Date = (m.Creation_Date == null ? string.Empty : Convert.ToDateTime(m.Creation_Date).ToString(ConfigurationProperty.DateFormat))
                ,
                    Creation_Hour = m.Creation_Hour
                            ,
                    Last_Updated_Date = (m.Last_Updated_Date == null ? string.Empty : Convert.ToDateTime(m.Last_Updated_Date).ToString(ConfigurationProperty.DateFormat))
                ,
                    Last_Updated_Hour = m.Last_Updated_Hour
                ,
                    Time_that_took = m.Time_that_took
                ,
                    Name = m.Name
                ,
                    Documentation = m.Documentation
                            ,
                    StatusDescription = CultureHelper.GetTraduction(m.Status_Spartan_BR_Status.StatusId.ToString(), "Spartan_BR_Status", m.Status_Spartan_BR_Status.Description, "Description")
                            ,
                    ComplexityDescription = CultureHelper.GetTraduction(m.Complexity_Spartan_BR_Complexity.Key_Complexity.ToString(), "Spartan_BR_Complexity", m.Complexity_Spartan_BR_Complexity.Description, "Description")

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


        //Grid GetAutoComplete

        //Grid GetAutoComplete

        //Grid GetAutoComplete

        //Grid GetAutoComplete

        //Grid GetAutoComplete

        //Grid GetAutoComplete

        //Grid GetAutoComplete

        //Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(Business_Rule_CreationAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromKey_Business_Rule_Creation) || !string.IsNullOrEmpty(filter.ToKey_Business_Rule_Creation))
            {
                if (!string.IsNullOrEmpty(filter.FromKey_Business_Rule_Creation))
                    where += " AND Business_Rule_Creation.Key_Business_Rule_Creation >= " + filter.FromKey_Business_Rule_Creation;
                if (!string.IsNullOrEmpty(filter.ToKey_Business_Rule_Creation))
                    where += " AND Business_Rule_Creation.Key_Business_Rule_Creation <= " + filter.ToKey_Business_Rule_Creation;
            }

            if (!string.IsNullOrEmpty(filter.AdvanceUser))
            {
                switch (filter.UserFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_User.Name LIKE '" + filter.AdvanceUser + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUser + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_User.Name = '" + filter.AdvanceUser + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_User.Name LIKE '%" + filter.AdvanceUser + "%'";
                        break;
                }
            }
            else if (filter.AdvanceUserMultiple != null && filter.AdvanceUserMultiple.Count() > 0)
            {
                var UserIds = string.Join(",", filter.AdvanceUserMultiple);

                where += " AND Business_Rule_Creation.User In (" + UserIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.FromCreation_Date) || !string.IsNullOrEmpty(filter.ToCreation_Date))
            {
                var Creation_DateFrom = DateTime.ParseExact(filter.FromCreation_Date, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Creation_DateTo = DateTime.ParseExact(filter.ToCreation_Date, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromCreation_Date))
                    where += " AND Business_Rule_Creation.Creation_Date >= '" + Creation_DateFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToCreation_Date))
                    where += " AND Business_Rule_Creation.Creation_Date <= '" + Creation_DateTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromCreation_Hour) || !string.IsNullOrEmpty(filter.ToCreation_Hour))
            {
                if (!string.IsNullOrEmpty(filter.FromCreation_Hour))
                    where += " AND Convert(TIME,Business_Rule_Creation.Creation_Hour) >='" + filter.FromCreation_Hour + "'";
                if (!string.IsNullOrEmpty(filter.ToCreation_Hour))
                    where += " AND Convert(TIME,Business_Rule_Creation.Creation_Hour) <='" + filter.ToCreation_Hour + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromLast_Updated_Date) || !string.IsNullOrEmpty(filter.ToLast_Updated_Date))
            {
                var Last_Updated_DateFrom = DateTime.ParseExact(filter.FromLast_Updated_Date, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Last_Updated_DateTo = DateTime.ParseExact(filter.ToLast_Updated_Date, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromLast_Updated_Date))
                    where += " AND Business_Rule_Creation.Last_Updated_Date >= '" + Last_Updated_DateFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToLast_Updated_Date))
                    where += " AND Business_Rule_Creation.Last_Updated_Date <= '" + Last_Updated_DateTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromLast_Updated_Hour) || !string.IsNullOrEmpty(filter.ToLast_Updated_Hour))
            {
                if (!string.IsNullOrEmpty(filter.FromLast_Updated_Hour))
                    where += " AND Convert(TIME,Business_Rule_Creation.Last_Updated_Hour) >='" + filter.FromLast_Updated_Hour + "'";
                if (!string.IsNullOrEmpty(filter.ToLast_Updated_Hour))
                    where += " AND Convert(TIME,Business_Rule_Creation.Last_Updated_Hour) <='" + filter.ToLast_Updated_Hour + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromTime_that_took) || !string.IsNullOrEmpty(filter.ToTime_that_took))
            {
                if (!string.IsNullOrEmpty(filter.FromTime_that_took))
                    where += " AND Business_Rule_Creation.Time_that_took >= " + filter.FromTime_that_took;
                if (!string.IsNullOrEmpty(filter.ToTime_that_took))
                    where += " AND Business_Rule_Creation.Time_that_took <= " + filter.ToTime_that_took;
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                switch (filter.NameFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Business_Rule_Creation.Name LIKE '" + filter.Name + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Business_Rule_Creation.Name LIKE '%" + filter.Name + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Business_Rule_Creation.Name = '" + filter.Name + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Business_Rule_Creation.Name LIKE '%" + filter.Name + "%'";
                        break;
                }
            }

            if (filter.Documentation != RadioOptions.NoApply)
                where += " AND Business_Rule_Creation.Documentation " + (filter.Documentation == RadioOptions.Yes ? ">" : "==") + " 0";

            if (!string.IsNullOrEmpty(filter.AdvanceStatus))
            {
                switch (filter.StatusFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_BR_Status.Description LIKE '" + filter.AdvanceStatus + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_BR_Status.Description LIKE '%" + filter.AdvanceStatus + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_BR_Status.Description = '" + filter.AdvanceStatus + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_BR_Status.Description LIKE '%" + filter.AdvanceStatus + "%'";
                        break;
                }
            }
            else if (filter.AdvanceStatusMultiple != null && filter.AdvanceStatusMultiple.Count() > 0)
            {
                var StatusIds = string.Join(",", filter.AdvanceStatusMultiple);

                where += " AND Business_Rule_Creation.Status In (" + StatusIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceComplexity))
            {
                switch (filter.ComplexityFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Spartan_BR_Complexity.Description LIKE '" + filter.AdvanceComplexity + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Spartan_BR_Complexity.Description LIKE '%" + filter.AdvanceComplexity + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Spartan_BR_Complexity.Description = '" + filter.AdvanceComplexity + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Spartan_BR_Complexity.Description LIKE '%" + filter.AdvanceComplexity + "%'";
                        break;
                }
            }
            else if (filter.AdvanceComplexityMultiple != null && filter.AdvanceComplexityMultiple.Count() > 0)
            {
                var ComplexityIds = string.Join(",", filter.AdvanceComplexityMultiple);

                where += " AND Business_Rule_Creation.Complexity In (" + ComplexityIds + ")";
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

        public ActionResult GetSpartan_BR_Conditions_Detail(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_Conditions_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Conditions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_BR_Conditions_Detail.Business_Rule=" + RelationId;
            if ("int" == "string")
            {
                where = "Spartan_BR_Conditions_Detail.Business_Rule='" + RelationId + "'";
            }
            var result = _ISpartan_BR_Conditions_DetailApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            if (result.Spartan_BR_Conditions_Details == null)
                result.Spartan_BR_Conditions_Details = new List<Spartan_BR_Conditions_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Conditions_Details.Select(m => new Spartan_BR_Conditions_DetailGridModel
                {
                    ConditionsDetailId = m.ConditionsDetailId
            ,
                    First_Operator_Type = m.First_Operator_Type
                        ,
                    Condition_Operator = m.Condition_Operator
                        ,
                    Condition_OperatorDescription = CultureHelper.GetTraduction(m.Condition_Operator_Spartan_BR_Condition_Operator.ConditionOperatorId.ToString(), "Spartan_BR_Condition_Operator", m.Condition_Operator_Spartan_BR_Condition_Operator.Description, "Description")
            ,
                    First_Operator_Value = m.First_Operator_Value
            ,
                    Second_Operator_Type = m.Second_Operator_Type
            ,
                    Second_Operator_Value = m.Second_Operator_Value
                        ,
                    Condition = m.Condition
                        ,
                    ConditionDescription = CultureHelper.GetTraduction(m.Condition_Spartan_BR_Condition.ConditionId.ToString(), "Spartan_BR_Condition", m.Condition_Spartan_BR_Condition.Description, "Description")

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_BR_Actions_True_Detail(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_Actions_True_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Actions_True_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_BR_Actions_True_Detail.Business_Rule=" + RelationId;
            if ("int" == "string")
            {
                where = "Spartan_BR_Actions_True_Detail.Business_Rule='" + RelationId + "'";
            }
            var result = _ISpartan_BR_Actions_True_DetailApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            if (result.Spartan_BR_Actions_True_Details == null)
                result.Spartan_BR_Actions_True_Details = new List<Spartan_BR_Actions_True_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Actions_True_Details.Select(m => new Spartan_BR_Actions_True_DetailGridModel
                {
                    ActionsTrueDetailId = m.ActionsTrueDetailId
                        ,
                    Action_Classification = m.Action_Classification
                        ,
                    Action_ClassificationDescription = CultureHelper.GetTraduction(m.Action_Classification_Spartan_BR_Action_Classification.ClassificationId.ToString(), "Spartan_BR_Action_Classification", m.Action_Classification_Spartan_BR_Action_Classification.Description, "Description")
                        ,
                    Action = m.Action
                        ,
                    ActionDescription = CultureHelper.GetTraduction(m.Action_Spartan_BR_Action.ActionId.ToString(), "Spartan_BR_Action", m.Action_Spartan_BR_Action.Description, "Description")
                        ,
                    Action_Result = m.Action_Result
                        ,
                    Action_ResultDescription = CultureHelper.GetTraduction(m.Action_Result_Spartan_BR_Action_Result.ActionResultId.ToString(), "Spartan_BR_Action_Result", m.Action_Result_Spartan_BR_Action_Result.Description, "Description")
            ,
                    Parameter_1 = m.Parameter_1
            ,
                    Parameter_2 = m.Parameter_2
            ,
                    Parameter_3 = m.Parameter_3
            ,
                    Parameter_4 = m.Parameter_4
            ,
                    Parameter_5 = m.Parameter_5

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_BR_Actions_False_Detail(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_Actions_False_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Actions_False_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_BR_Actions_False_Detail.Business_Rule=" + RelationId;
            if ("int" == "string")
            {
                where = "Spartan_BR_Actions_False_Detail.Business_Rule='" + RelationId + "'";
            }
            var result = _ISpartan_BR_Actions_False_DetailApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            if (result.Spartan_BR_Actions_False_Details == null)
                result.Spartan_BR_Actions_False_Details = new List<Spartan_BR_Actions_False_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Actions_False_Details.Select(m => new Spartan_BR_Actions_False_DetailGridModel
                {
                    ActionsFalseDetailId = m.ActionsFalseDetailId
                        ,
                    Action_Classification = m.Action_Classification
                        ,
                    Action_ClassificationDescription = CultureHelper.GetTraduction(m.Action_Classification_Spartan_BR_Action_Classification.ClassificationId.ToString(), "Spartan_BR_Action_Classification", m.Action_Classification_Spartan_BR_Action_Classification.Description, "Description")
                        ,
                    Action = m.Action
                        ,
                    ActionDescription = CultureHelper.GetTraduction(m.Action_Spartan_BR_Action.ActionId.ToString(), "Spartan_BR_Action", m.Action_Spartan_BR_Action.Description, "Description")
                        ,
                    Action_Result = m.Action_Result
                        ,
                    Action_ResultDescription = CultureHelper.GetTraduction(m.Action_Result_Spartan_BR_Action_Result.ActionResultId.ToString(), "Spartan_BR_Action_Result", m.Action_Result_Spartan_BR_Action_Result.Description, "Description")
            ,
                    Parameter_1 = m.Parameter_1
            ,
                    Parameter_2 = m.Parameter_2
            ,
                    Parameter_3 = m.Parameter_3
            ,
                    Parameter_4 = m.Parameter_4
            ,
                    Parameter_5 = m.Parameter_5

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_BR_Operation_Detail(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_Operation_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Operation_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_BR_Operation_Detail.Business_Rule=" + RelationId;
            if ("int" == "string")
            {
                where = "Spartan_BR_Operation_Detail.Business_Rule='" + RelationId + "'";
            }
            var result = _ISpartan_BR_Operation_DetailApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            if (result.Spartan_BR_Operation_Details == null)
                result.Spartan_BR_Operation_Details = new List<Spartan_BR_Operation_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Operation_Details.Select(m => new Spartan_BR_Operation_DetailGridModel
                {
                    OperationDetailId = m.OperationDetailId
                        ,
                    Operation = m.Operation
                        ,
                    OperationDescription = CultureHelper.GetTraduction(m.Operation_Spartan_BR_Operation.OperationId.ToString(), "Spartan_BR_Operation", m.Operation_Spartan_BR_Operation.Description, "Description")

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_BR_Process_Event_Detail(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_Process_Event_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_BR_Process_Event_Detail.Business_Rule=" + RelationId;
            if ("int" == "string")
            {
                where = "Spartan_BR_Process_Event_Detail.Business_Rule='" + RelationId + "'";
            }
            var result = _ISpartan_BR_Process_Event_DetailApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            if (result.Spartan_BR_Process_Event_Details == null)
                result.Spartan_BR_Process_Event_Details = new List<Spartan_BR_Process_Event_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Process_Event_Details.Select(m => new Spartan_BR_Process_Event_DetailGridModel
                {
                    ProcessEventDetailId = m.ProcessEventDetailId
                        ,
                    Process_Event = m.Process_Event
                        ,
                    Process_EventDescription = CultureHelper.GetTraduction(m.Process_Event_Spartan_BR_Process_Event.ProcessEventId.ToString(), "Spartan_BR_Process_Event", m.Process_Event_Spartan_BR_Process_Event.Description, "Description")

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_BR_Peer_Review(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_Peer_ReviewGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Peer_ReviewApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_BR_Peer_Review.Business_Rule=" + RelationId;
            if ("int" == "string")
            {
                where = "Spartan_BR_Peer_Review.Business_Rule='" + RelationId + "'";
            }
            var result = _ISpartan_BR_Peer_ReviewApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            if (result.Spartan_BR_Peer_Reviews == null)
                result.Spartan_BR_Peer_Reviews = new List<Spartan_BR_Peer_Review>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Peer_Reviews.Select(m => new Spartan_BR_Peer_ReviewGridModel
                {
                    Key_Peer_Review = m.Key_Peer_Review
                        ,
                    User_that_reviewed = m.User_that_reviewed
                        ,
                    User_that_reviewedName = (string)m.User_that_reviewed_Spartan_User.Name
            ,
                    Acceptance_Criteria = m.Acceptance_Criteria
            ,
                    It_worked = m.It_worked
                        ,
                    Rejection_reason = m.Rejection_reason
                        ,
                    Rejection_reasonDescription = CultureHelper.GetTraduction(m.Rejection_reason_Spartan_BR_Rejection_Reason.Key_Rejection_Reason.ToString(), "Spartan_BR_Rejection_Reason", m.Rejection_reason_Spartan_BR_Rejection_Reason.Description, "Description")
            ,
                    Comments = m.Comments
            ,
                    EvidenceFileInfo = m.Evidence > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Evidence).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_BR_Testing(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_TestingGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_TestingApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_BR_Testing.Business_Rule=" + RelationId;
            if ("int" == "string")
            {
                where = "Spartan_BR_Testing.Business_Rule='" + RelationId + "'";
            }
            var result = _ISpartan_BR_TestingApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            if (result.Spartan_BR_Testings == null)
                result.Spartan_BR_Testings = new List<Spartan_BR_Testing>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Testings.Select(m => new Spartan_BR_TestingGridModel
                {
                    Key_Testing = m.Key_Testing
                        ,
                    User_that_reviewed = m.User_that_reviewed
                        ,
                    User_that_reviewedName = (string)m.User_that_reviewed_Spartan_User.Name
            ,
                    Acceptance_Critera = m.Acceptance_Critera
            ,
                    It_worked = m.It_worked
                        ,
                    Rejection_Reason = m.Rejection_Reason
                        ,
                    Rejection_ReasonDescription = CultureHelper.GetTraduction(m.Rejection_Reason_Spartan_BR_Rejection_Reason.Key_Rejection_Reason.ToString(), "Spartan_BR_Rejection_Reason", m.Rejection_Reason_Spartan_BR_Rejection_Reason.Description, "Description")
            ,
                    Comments = m.Comments
            ,
                    EvidenceFileInfo = m.Evidence > 0 ? (ConvertSpartane_FileToGridFile(_ISpartane_FileApiConsumer.GetByKey(m.Evidence).Resource)) : new Grid_File { FileId = 0, FileSize = 0, FileName = "" }

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public ActionResult GetSpartan_BR_Scope_Detail(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Spartan_BR_Scope_DetailGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Scope_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Spartan_BR_Scope_Detail.Business_Rule=" + RelationId;
            if ("int" == "string")
            {
                where = "Spartan_BR_Scope_Detail.Business_Rule='" + RelationId + "'";
            }
            var result = _ISpartan_BR_Scope_DetailApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            if (result.Spartan_BR_Scope_Details == null)
                result.Spartan_BR_Scope_Details = new List<Spartan_BR_Scope_Detail>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Spartan_BR_Scope_Details.Select(m => new Spartan_BR_Scope_DetailGridModel
                {
                    ScopeDetailId = m.ScopeDetailId
                        ,
                    Scope = m.Scope
                        ,
                    ScopeDescription = CultureHelper.GetTraduction(m.Scope.ToString(), "Spartan_BR_Scope", m.Scope_Spartan_BR_Scope.Description, "Description")

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
                _IBusiness_Rule_CreationApiConsumer.SetAuthHeader(_tokenManager.Token);
                _ISpartaneQueryApiConsumer.SetAuthHeader(_tokenManager.Token);
                Business_Rule_Creation varBusiness_Rule_Creation = null;
                if (id.ToString() != "0")
                {
                    var rule = _IBusiness_Rule_CreationApiConsumer.GetByKey(id, false).Resource;
                    RegenerateJS(id, 4, Convert.ToInt32(rule.Object));

                    string where = "";
                    _ISpartan_BR_Conditions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Spartan_BR_Conditions_Detail.Business_Rule=" + id;
                    if ("int" == "string")
                    {
                        where = "Spartan_BR_Conditions_Detail.Business_Rule='" + id + "'";
                    }
                    var Spartan_BR_Conditions_DetailInfo =
                        _ISpartan_BR_Conditions_DetailApiConsumer.ListaSelAll(1, int.MaxValue, where, "").Resource;

                    if (Spartan_BR_Conditions_DetailInfo.Spartan_BR_Conditions_Details.Count > 0)
                    {
                        var resultSpartan_BR_Conditions_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_BR_Conditions_DetailItem in Spartan_BR_Conditions_DetailInfo.Spartan_BR_Conditions_Details)
                            resultSpartan_BR_Conditions_Detail = resultSpartan_BR_Conditions_Detail
                                              && _ISpartan_BR_Conditions_DetailApiConsumer.Delete(Spartan_BR_Conditions_DetailItem.ConditionsDetailId, null, null).Resource;

                        if (!resultSpartan_BR_Conditions_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_BR_Actions_True_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Spartan_BR_Actions_True_Detail.Business_Rule=" + id;
                    if ("int" == "string")
                    {
                        where = "Spartan_BR_Actions_True_Detail.Business_Rule='" + id + "'";
                    }
                    var Spartan_BR_Actions_True_DetailInfo =
                        _ISpartan_BR_Actions_True_DetailApiConsumer.ListaSelAll(1, int.MaxValue, where, "").Resource;

                    if (Spartan_BR_Actions_True_DetailInfo.Spartan_BR_Actions_True_Details.Count > 0)
                    {
                        var resultSpartan_BR_Actions_True_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_BR_Actions_True_DetailItem in Spartan_BR_Actions_True_DetailInfo.Spartan_BR_Actions_True_Details)
                            resultSpartan_BR_Actions_True_Detail = resultSpartan_BR_Actions_True_Detail
                                              && _ISpartan_BR_Actions_True_DetailApiConsumer.Delete(Spartan_BR_Actions_True_DetailItem.ActionsTrueDetailId, null, null).Resource;

                        if (!resultSpartan_BR_Actions_True_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_BR_Actions_False_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Spartan_BR_Actions_False_Detail.Business_Rule=" + id;
                    if ("int" == "string")
                    {
                        where = "Spartan_BR_Actions_False_Detail.Business_Rule='" + id + "'";
                    }
                    var Spartan_BR_Actions_False_DetailInfo =
                        _ISpartan_BR_Actions_False_DetailApiConsumer.ListaSelAll(1, int.MaxValue, where, "").Resource;

                    if (Spartan_BR_Actions_False_DetailInfo.Spartan_BR_Actions_False_Details.Count > 0)
                    {
                        var resultSpartan_BR_Actions_False_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_BR_Actions_False_DetailItem in Spartan_BR_Actions_False_DetailInfo.Spartan_BR_Actions_False_Details)
                            resultSpartan_BR_Actions_False_Detail = resultSpartan_BR_Actions_False_Detail
                                              && _ISpartan_BR_Actions_False_DetailApiConsumer.Delete(Spartan_BR_Actions_False_DetailItem.ActionsFalseDetailId, null, null).Resource;

                        if (!resultSpartan_BR_Actions_False_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_BR_Operation_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Spartan_BR_Operation_Detail.Business_Rule=" + id;
                    if ("int" == "string")
                    {
                        where = "Spartan_BR_Operation_Detail.Business_Rule='" + id + "'";
                    }
                    var Spartan_BR_Operation_DetailInfo =
                        _ISpartan_BR_Operation_DetailApiConsumer.ListaSelAll(1, int.MaxValue, where, "").Resource;

                    if (Spartan_BR_Operation_DetailInfo.Spartan_BR_Operation_Details.Count > 0)
                    {
                        var resultSpartan_BR_Operation_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_BR_Operation_DetailItem in Spartan_BR_Operation_DetailInfo.Spartan_BR_Operation_Details)
                            resultSpartan_BR_Operation_Detail = resultSpartan_BR_Operation_Detail
                                              && _ISpartan_BR_Operation_DetailApiConsumer.Delete(Spartan_BR_Operation_DetailItem.OperationDetailId, null, null).Resource;

                        if (!resultSpartan_BR_Operation_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Spartan_BR_Process_Event_Detail.Business_Rule=" + id;
                    if ("int" == "string")
                    {
                        where = "Spartan_BR_Process_Event_Detail.Business_Rule='" + id + "'";
                    }
                    var Spartan_BR_Process_Event_DetailInfo =
                        _ISpartan_BR_Process_Event_DetailApiConsumer.ListaSelAll(1, int.MaxValue, where, "").Resource;

                    if (Spartan_BR_Process_Event_DetailInfo.Spartan_BR_Process_Event_Details.Count > 0)
                    {
                        var resultSpartan_BR_Process_Event_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_BR_Process_Event_DetailItem in Spartan_BR_Process_Event_DetailInfo.Spartan_BR_Process_Event_Details)
                            resultSpartan_BR_Process_Event_Detail = resultSpartan_BR_Process_Event_Detail
                                              && _ISpartan_BR_Process_Event_DetailApiConsumer.Delete(Spartan_BR_Process_Event_DetailItem.ProcessEventDetailId, null, null).Resource;

                        if (!resultSpartan_BR_Process_Event_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_BR_Peer_ReviewApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Spartan_BR_Peer_Review.Business_Rule=" + id;
                    if ("int" == "string")
                    {
                        where = "Spartan_BR_Peer_Review.Business_Rule='" + id + "'";
                    }
                    var Spartan_BR_Peer_ReviewInfo =
                        _ISpartan_BR_Peer_ReviewApiConsumer.ListaSelAll(1, int.MaxValue, where, "").Resource;

                    if (Spartan_BR_Peer_ReviewInfo.Spartan_BR_Peer_Reviews.Count > 0)
                    {
                        var resultSpartan_BR_Peer_Review = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_BR_Peer_ReviewItem in Spartan_BR_Peer_ReviewInfo.Spartan_BR_Peer_Reviews)
                            resultSpartan_BR_Peer_Review = resultSpartan_BR_Peer_Review
                                              && _ISpartan_BR_Peer_ReviewApiConsumer.Delete(Spartan_BR_Peer_ReviewItem.Key_Peer_Review, null, null).Resource;

                        if (!resultSpartan_BR_Peer_Review)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_BR_TestingApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Spartan_BR_Testing.Business_Rule=" + id;
                    if ("int" == "string")
                    {
                        where = "Spartan_BR_Testing.Business_Rule='" + id + "'";
                    }
                    var Spartan_BR_TestingInfo =
                        _ISpartan_BR_TestingApiConsumer.ListaSelAll(1, int.MaxValue, where, "").Resource;

                    if (Spartan_BR_TestingInfo.Spartan_BR_Testings.Count > 0)
                    {
                        var resultSpartan_BR_Testing = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_BR_TestingItem in Spartan_BR_TestingInfo.Spartan_BR_Testings)
                            resultSpartan_BR_Testing = resultSpartan_BR_Testing
                                              && _ISpartan_BR_TestingApiConsumer.Delete(Spartan_BR_TestingItem.Key_Testing, null, null).Resource;

                        if (!resultSpartan_BR_Testing)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }
                    _ISpartan_BR_Scope_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Spartan_BR_Scope_Detail.Business_Rule=" + id;
                    if ("int" == "string")
                    {
                        where = "Spartan_BR_Scope_Detail.Business_Rule='" + id + "'";
                    }
                    var Spartan_BR_Scope_DetailInfo =
                        _ISpartan_BR_Scope_DetailApiConsumer.ListaSelAll(1, int.MaxValue, where, "").Resource;

                    if (Spartan_BR_Scope_DetailInfo.Spartan_BR_Scope_Details.Count > 0)
                    {
                        var resultSpartan_BR_Scope_Detail = true;
                        //Removing associated job history with attachment
                        foreach (var Spartan_BR_Scope_DetailItem in Spartan_BR_Scope_DetailInfo.Spartan_BR_Scope_Details)
                            resultSpartan_BR_Scope_Detail = resultSpartan_BR_Scope_Detail
                                              && _ISpartan_BR_Scope_DetailApiConsumer.Delete(Spartan_BR_Scope_DetailItem.ScopeDetailId, null, null).Resource;

                        if (!resultSpartan_BR_Scope_Detail)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IBusiness_Rule_CreationApiConsumer.Delete(id, null, null).Resource;
                _ISpartaneQueryApiConsumer.ExecuteQuery("exec sp_InsSpartan_BR_History " + Convert.ToInt32(id) + ", " + Convert.ToInt32(Session["USERID"]) + ", 4");
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, int ObjectId, int Attribute, Business_Rule_CreationModel varBusiness_Rule_Creation)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IBusiness_Rule_CreationApiConsumer.SetAuthHeader(_tokenManager.Token);
                _ISpartaneQueryApiConsumer.SetAuthHeader(_tokenManager.Token);

                if (varBusiness_Rule_Creation.DocumentationRemoveAttachment != 0 && varBusiness_Rule_Creation.DocumentationFile == null)
                {
                    varBusiness_Rule_Creation.Documentation = 0;
                }

                if (varBusiness_Rule_Creation.DocumentationFile != null)
                {
                    var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(varBusiness_Rule_Creation.DocumentationFile);
                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    varBusiness_Rule_Creation.Documentation = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                    {
                        File = fileAsBytes,
                        Description = varBusiness_Rule_Creation.DocumentationFile.FileName,
                        File_Size = fileAsBytes.Length
                    }).Resource;
                }


                var result = "";
                var Business_Rule_CreationInfo = new Business_Rule_Creation
                {
                    Key_Business_Rule_Creation = varBusiness_Rule_Creation.Key_Business_Rule_Creation
                    ,
                    User = varBusiness_Rule_Creation.User
                    ,
                    Creation_Date = (!String.IsNullOrEmpty(varBusiness_Rule_Creation.Creation_Date)) ? DateTime.ParseExact(varBusiness_Rule_Creation.Creation_Date, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                    ,
                    Creation_Hour = varBusiness_Rule_Creation.Creation_Hour
                    ,
                    Last_Updated_Date = (!String.IsNullOrEmpty(varBusiness_Rule_Creation.Last_Updated_Date)) ? DateTime.ParseExact(varBusiness_Rule_Creation.Last_Updated_Date, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                    ,
                    Last_Updated_Hour = varBusiness_Rule_Creation.Last_Updated_Hour
                    ,
                    Time_that_took = varBusiness_Rule_Creation.Time_that_took
                    ,
                    Name = varBusiness_Rule_Creation.Name
                    ,
                    Documentation = (varBusiness_Rule_Creation.Documentation.HasValue && varBusiness_Rule_Creation.Documentation != 0) ? ((int?)Convert.ToInt32(varBusiness_Rule_Creation.Documentation.Value)) : null

                    ,
                    Status = 4
                    ,
                    Complexity = varBusiness_Rule_Creation.Complexity
                    ,
                    Object = ObjectId
                    ,
                    Attribute = Attribute

                };

                result = !IsNew ?
                    _IBusiness_Rule_CreationApiConsumer.Update(Business_Rule_CreationInfo, null, null).Resource.ToString() :
                     _IBusiness_Rule_CreationApiConsumer.Insert(Business_Rule_CreationInfo, null, null).Resource.ToString();
                if (!IsNew)
                {
                    _ISpartaneQueryApiConsumer.ExecuteQuery("exec sp_InsSpartan_BR_History " + Convert.ToInt32(result) + ", " + Convert.ToInt32(Session["USERID"]) + ", 1");
                    RegenerateJS(Business_Rule_CreationInfo.Key_Business_Rule_Creation, 4, Business_Rule_CreationInfo.Object.Value);
                }
                else
                {
                    _ISpartaneQueryApiConsumer.ExecuteQuery("exec sp_InsSpartan_BR_History " + Convert.ToInt32(result) + ", " + Convert.ToInt32(Session["USERID"]) + ", 3");
                }
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
        public bool CopySpartan_BR_Conditions_Detail(int MasterId, int referenceId, List<Spartan_BR_Conditions_DetailGridModelPost> Spartan_BR_Conditions_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_BR_Conditions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_BR_Conditions_DetailData = _ISpartan_BR_Conditions_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Conditions_Detail.Business_Rule=" + referenceId, "").Resource;
                if (Spartan_BR_Conditions_DetailData == null || Spartan_BR_Conditions_DetailData.Spartan_BR_Conditions_Details.Count == 0)
                    return true;

                var result = true;

                Spartan_BR_Conditions_DetailGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varSpartan_BR_Conditions_Detail in Spartan_BR_Conditions_DetailData.Spartan_BR_Conditions_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Spartan_BR_Conditions_Detail Spartan_BR_Conditions_Detail1 = varSpartan_BR_Conditions_Detail;

                    if (Spartan_BR_Conditions_DetailItems != null && Spartan_BR_Conditions_DetailItems.Any(m => m.ConditionsDetailId == Spartan_BR_Conditions_Detail1.ConditionsDetailId))
                    {
                        modelDataToChange = Spartan_BR_Conditions_DetailItems.FirstOrDefault(m => m.ConditionsDetailId == Spartan_BR_Conditions_Detail1.ConditionsDetailId);
                    }
                    //Chaning Id Value
                    varSpartan_BR_Conditions_Detail.Business_Rule = MasterId;
                    var insertId = _ISpartan_BR_Conditions_DetailApiConsumer.Insert(varSpartan_BR_Conditions_Detail, null, null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.ConditionsDetailId = insertId;

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
        public ActionResult PostSpartan_BR_Conditions_Detail(List<Spartan_BR_Conditions_DetailGridModelPost> Spartan_BR_Conditions_DetailItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_BR_Conditions_Detail(MasterId, referenceId, Spartan_BR_Conditions_DetailItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_BR_Conditions_DetailItems != null && Spartan_BR_Conditions_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Conditions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_BR_Conditions_DetailItem in Spartan_BR_Conditions_DetailItems)
                    {

                        //Removal Request
                        if (Spartan_BR_Conditions_DetailItem.Removed)
                        {
                            result = result && _ISpartan_BR_Conditions_DetailApiConsumer.Delete(Spartan_BR_Conditions_DetailItem.ConditionsDetailId, null, null).Resource;
                            continue;
                        }
                        if (referenceId.ToString() != MasterId.ToString())
                            Spartan_BR_Conditions_DetailItem.ConditionsDetailId = 0;

                        var Spartan_BR_Conditions_DetailData = new Spartan_BR_Conditions_Detail
                        {
                            Business_Rule = MasterId
                            ,
                            ConditionsDetailId = Spartan_BR_Conditions_DetailItem.ConditionsDetailId
                            ,
                            First_Operator_Type = Spartan_BR_Conditions_DetailItem.First_Operator_Type
                            ,
                            Condition_Operator = (Convert.ToInt16(Spartan_BR_Conditions_DetailItem.Condition_Operator) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Conditions_DetailItem.Condition_Operator))
                            ,
                            First_Operator_Value = Spartan_BR_Conditions_DetailItem.First_Operator_Value
                            ,
                            Second_Operator_Type = Spartan_BR_Conditions_DetailItem.Second_Operator_Type
                            ,
                            Second_Operator_Value = Spartan_BR_Conditions_DetailItem.Second_Operator_Value
                            ,
                            Condition = (Convert.ToInt16(Spartan_BR_Conditions_DetailItem.Condition) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Conditions_DetailItem.Condition))

                        };

                        var resultId = Spartan_BR_Conditions_DetailItem.ConditionsDetailId > 0
                           ? _ISpartan_BR_Conditions_DetailApiConsumer.Update(Spartan_BR_Conditions_DetailData, null, null).Resource
                           : _ISpartan_BR_Conditions_DetailApiConsumer.Insert(Spartan_BR_Conditions_DetailData, null, null).Resource;

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
        public ActionResult GetSpartan_BR_Conditions_Detail_Spartan_BR_Condition_OperatorAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Condition_OperatorApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Condition_OperatorApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
                    item.Description = CultureHelper.GetTraduction(Convert.ToString(item.ConditionOperatorId), "Spartan_BR_Condition_Operator", item.Description, "Description");
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_BR_Conditions_Detail_Spartan_BR_Operator_TypeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Operator_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Operator_TypeApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
                    item.Description = CultureHelper.GetTraduction(Convert.ToString(item.OperatorTypeId), "Spartan_BR_Operator_Type", item.Description, "Description");
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetSpartan_BR_Conditions_Detail_Spartan_BR_ConditionAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_ConditionApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_ConditionApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
                    item.Description = CultureHelper.GetTraduction(Convert.ToString(item.ConditionId), "Spartan_BR_Condition", item.Description, "Description");
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_BR_Actions_True_Detail(int MasterId, int referenceId, List<Spartan_BR_Actions_True_DetailGridModelPost> Spartan_BR_Actions_True_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_BR_Actions_True_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_BR_Actions_True_DetailData = _ISpartan_BR_Actions_True_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Actions_True_Detail.Business_Rule=" + referenceId, "").Resource;
                if (Spartan_BR_Actions_True_DetailData == null || Spartan_BR_Actions_True_DetailData.Spartan_BR_Actions_True_Details.Count == 0)
                    return true;

                var result = true;

                Spartan_BR_Actions_True_DetailGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varSpartan_BR_Actions_True_Detail in Spartan_BR_Actions_True_DetailData.Spartan_BR_Actions_True_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Spartan_BR_Actions_True_Detail Spartan_BR_Actions_True_Detail1 = varSpartan_BR_Actions_True_Detail;

                    if (Spartan_BR_Actions_True_DetailItems != null && Spartan_BR_Actions_True_DetailItems.Any(m => m.ActionsTrueDetailId == Spartan_BR_Actions_True_Detail1.ActionsTrueDetailId))
                    {
                        modelDataToChange = Spartan_BR_Actions_True_DetailItems.FirstOrDefault(m => m.ActionsTrueDetailId == Spartan_BR_Actions_True_Detail1.ActionsTrueDetailId);
                    }
                    //Chaning Id Value
                    varSpartan_BR_Actions_True_Detail.Business_Rule = MasterId;
                    var insertId = _ISpartan_BR_Actions_True_DetailApiConsumer.Insert(varSpartan_BR_Actions_True_Detail, null, null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.ActionsTrueDetailId = insertId;

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
        [ValidateInput(false)]
        public ActionResult PostSpartan_BR_Actions_True_Detail(List<Spartan_BR_Actions_True_DetailGridModelPost> Spartan_BR_Actions_True_DetailItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_BR_Actions_True_Detail(MasterId, referenceId, Spartan_BR_Actions_True_DetailItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_BR_Actions_True_DetailItems != null && Spartan_BR_Actions_True_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Actions_True_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_BR_Actions_True_DetailItem in Spartan_BR_Actions_True_DetailItems)
                    {

                        //Removal Request
                        if (Spartan_BR_Actions_True_DetailItem.Removed)
                        {
                            result = result && _ISpartan_BR_Actions_True_DetailApiConsumer.Delete(Spartan_BR_Actions_True_DetailItem.ActionsTrueDetailId, null, null).Resource;
                            continue;
                        }
                        if (referenceId.ToString() != MasterId.ToString())
                            Spartan_BR_Actions_True_DetailItem.ActionsTrueDetailId = 0;

                        var Spartan_BR_Actions_True_DetailData = new Spartan_BR_Actions_True_Detail
                        {
                            Business_Rule = MasterId
                            ,
                            ActionsTrueDetailId = Spartan_BR_Actions_True_DetailItem.ActionsTrueDetailId
                            ,
                            Action_Classification = (Convert.ToInt16(Spartan_BR_Actions_True_DetailItem.Action_Classification) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Actions_True_DetailItem.Action_Classification))
                            ,
                            Action = (Convert.ToInt32(Spartan_BR_Actions_True_DetailItem.Action) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_BR_Actions_True_DetailItem.Action))
                            ,
                            Action_Result = (Convert.ToInt16(Spartan_BR_Actions_True_DetailItem.Action_Result) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Actions_True_DetailItem.Action_Result))
                            ,
                            Parameter_1 = Spartan_BR_Actions_True_DetailItem.Parameter_1
                            ,
                            Parameter_2 = Spartan_BR_Actions_True_DetailItem.Parameter_2
                            ,
                            Parameter_3 = Spartan_BR_Actions_True_DetailItem.Parameter_3
                            ,
                            Parameter_4 = Spartan_BR_Actions_True_DetailItem.Parameter_4
                            ,
                            Parameter_5 = Spartan_BR_Actions_True_DetailItem.Parameter_5

                        };

                        var resultId = Spartan_BR_Actions_True_DetailItem.ActionsTrueDetailId > 0
                           ? _ISpartan_BR_Actions_True_DetailApiConsumer.Update(Spartan_BR_Actions_True_DetailData, null, null).Resource
                           : _ISpartan_BR_Actions_True_DetailApiConsumer.Insert(Spartan_BR_Actions_True_DetailData, null, null).Resource;

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
        public ActionResult GetSpartan_BR_Actions_True_Detail_Spartan_BR_Action_ClassificationAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Action_ClassificationApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Action_ClassificationApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
                    item.Description = CultureHelper.GetTraduction(Convert.ToString(item.ClassificationId), "Spartan_BR_Action_Classification", item.Description, "Description");
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_BR_Actions_True_Detail_Spartan_BR_ActionAll(string operations, string events)
        {
            try
            {
                List<Spartan_BR_Action> resultFinal = new List<Spartan_BR_Action>();
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_ActionApiConsumer.SetAuthHeader(_tokenManager.Token);
                _ISpartan_BR_Event_Restrictions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                _ISpartan_BR_Operation_Restrictions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var result = _ISpartan_BR_ActionApiConsumer.SelAll(false).Resource;
                var restrictionsOperations = _ISpartan_BR_Operation_Restrictions_DetailApiConsumer.ListaSelAll(0, 9999, "Spartan_BR_Operation_Restrictions_Detail.Operation IN (" + operations + ")", "").Resource;
                var restrictionsEvents = _ISpartan_BR_Event_Restrictions_DetailApiConsumer.ListaSelAll(0, 9999, "Spartan_BR_Event_Restrictions_Detail.Process_Event IN (" + events + ")", "").Resource;

                foreach (var item in result)
                {
                    if (!IsRestricted(item.ActionId, restrictionsOperations.Spartan_BR_Operation_Restrictions_Details, restrictionsEvents.Spartan_BR_Event_Restrictions_Details))
                    {
                        item.Description = CultureHelper.GetTraduction(Convert.ToString(item.ActionId), "Spartan_BR_Action", item.Description, "Description");
                        resultFinal.Add(item);
                    }
                }
                return Json(resultFinal.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        private bool IsRestricted(int Action, List<Spartan_BR_Operation_Restrictions_Detail> operationRestricted, List<Spartan_BR_Event_Restrictions_Detail> eventsRestricted)
        {
            Spartan_BR_Operation_Restrictions_Detail opRestricted = null;
            Spartan_BR_Event_Restrictions_Detail evRestricted = null;
            if (operationRestricted != null)
            {
                opRestricted = operationRestricted.Where(x => x.Action == Action).FirstOrDefault();
            }
            if (eventsRestricted != null)
            {
                evRestricted = eventsRestricted.Where(x => x.Action == Action).FirstOrDefault();
            }
            if (opRestricted != null || evRestricted != null)
                return true;
            return false;
        }
        [HttpGet]
        public ActionResult GetSpartan_BR_Actions_True_Detail_Spartan_BR_Action_ResultAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Action_ResultApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Action_ResultApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
                    item.Description = CultureHelper.GetTraduction(Convert.ToString(item.ActionResultId), "Spartan_BR_Action_Result", item.Description, "Description");
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_BR_Actions_False_Detail(int MasterId, int referenceId, List<Spartan_BR_Actions_False_DetailGridModelPost> Spartan_BR_Actions_False_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_BR_Actions_False_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_BR_Actions_False_DetailData = _ISpartan_BR_Actions_False_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Actions_False_Detail.Business_Rule=" + referenceId, "").Resource;
                if (Spartan_BR_Actions_False_DetailData == null || Spartan_BR_Actions_False_DetailData.Spartan_BR_Actions_False_Details.Count == 0)
                    return true;

                var result = true;

                Spartan_BR_Actions_False_DetailGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varSpartan_BR_Actions_False_Detail in Spartan_BR_Actions_False_DetailData.Spartan_BR_Actions_False_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Spartan_BR_Actions_False_Detail Spartan_BR_Actions_False_Detail1 = varSpartan_BR_Actions_False_Detail;

                    if (Spartan_BR_Actions_False_DetailItems != null && Spartan_BR_Actions_False_DetailItems.Any(m => m.ActionsFalseDetailId == Spartan_BR_Actions_False_Detail1.ActionsFalseDetailId))
                    {
                        modelDataToChange = Spartan_BR_Actions_False_DetailItems.FirstOrDefault(m => m.ActionsFalseDetailId == Spartan_BR_Actions_False_Detail1.ActionsFalseDetailId);
                    }
                    //Chaning Id Value
                    varSpartan_BR_Actions_False_Detail.Business_Rule = MasterId;
                    var insertId = _ISpartan_BR_Actions_False_DetailApiConsumer.Insert(varSpartan_BR_Actions_False_Detail, null, null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.ActionsFalseDetailId = insertId;

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
        [ValidateInput(false)]
        public ActionResult PostSpartan_BR_Actions_False_Detail(List<Spartan_BR_Actions_False_DetailGridModelPost> Spartan_BR_Actions_False_DetailItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_BR_Actions_False_Detail(MasterId, referenceId, Spartan_BR_Actions_False_DetailItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_BR_Actions_False_DetailItems != null && Spartan_BR_Actions_False_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Actions_False_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_BR_Actions_False_DetailItem in Spartan_BR_Actions_False_DetailItems)
                    {

                        //Removal Request
                        if (Spartan_BR_Actions_False_DetailItem.Removed)
                        {
                            result = result && _ISpartan_BR_Actions_False_DetailApiConsumer.Delete(Spartan_BR_Actions_False_DetailItem.ActionsFalseDetailId, null, null).Resource;
                            continue;
                        }
                        if (referenceId.ToString() != MasterId.ToString())
                            Spartan_BR_Actions_False_DetailItem.ActionsFalseDetailId = 0;

                        var Spartan_BR_Actions_False_DetailData = new Spartan_BR_Actions_False_Detail
                        {
                            Business_Rule = MasterId
                            ,
                            ActionsFalseDetailId = Spartan_BR_Actions_False_DetailItem.ActionsFalseDetailId
                            ,
                            Action_Classification = (Convert.ToInt16(Spartan_BR_Actions_False_DetailItem.Action_Classification) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Actions_False_DetailItem.Action_Classification))
                            ,
                            Action = (Convert.ToInt32(Spartan_BR_Actions_False_DetailItem.Action) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_BR_Actions_False_DetailItem.Action))
                            ,
                            Action_Result = (Convert.ToInt16(Spartan_BR_Actions_False_DetailItem.Action_Result) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Actions_False_DetailItem.Action_Result))
                            ,
                            Parameter_1 = Spartan_BR_Actions_False_DetailItem.Parameter_1
                            ,
                            Parameter_2 = Spartan_BR_Actions_False_DetailItem.Parameter_2
                            ,
                            Parameter_3 = Spartan_BR_Actions_False_DetailItem.Parameter_3
                            ,
                            Parameter_4 = Spartan_BR_Actions_False_DetailItem.Parameter_4
                            ,
                            Parameter_5 = Spartan_BR_Actions_False_DetailItem.Parameter_5

                        };

                        var resultId = Spartan_BR_Actions_False_DetailItem.ActionsFalseDetailId > 0
                           ? _ISpartan_BR_Actions_False_DetailApiConsumer.Update(Spartan_BR_Actions_False_DetailData, null, null).Resource
                           : _ISpartan_BR_Actions_False_DetailApiConsumer.Insert(Spartan_BR_Actions_False_DetailData, null, null).Resource;

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
        public ActionResult GetSpartan_BR_Actions_False_Detail_Spartan_BR_Action_ClassificationAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Action_ClassificationApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Action_ClassificationApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
                    item.Description = CultureHelper.GetTraduction(Convert.ToString(item.ClassificationId), "Spartan_BR_Action_Classification", item.Description, "Description");
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_BR_Actions_False_Detail_Spartan_BR_ActionAll(string operations, string events)
        {
            try
            {
                List<Spartan_BR_Action> resultFinal = new List<Spartan_BR_Action>();
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_ActionApiConsumer.SetAuthHeader(_tokenManager.Token);
                _ISpartan_BR_Event_Restrictions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                _ISpartan_BR_Operation_Restrictions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                var restrictionsOperations = _ISpartan_BR_Operation_Restrictions_DetailApiConsumer.ListaSelAll(0, 9999, "Spartan_BR_Operation_Restrictions_Detail.Operation IN (" + operations + ")", "").Resource;
                var restrictionsEvents = _ISpartan_BR_Event_Restrictions_DetailApiConsumer.ListaSelAll(0, 9999, "Spartan_BR_Event_Restrictions_Detail.Process_Event IN (" + events + ")", "").Resource;
                var result = _ISpartan_BR_ActionApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
                    if (!IsRestricted(item.ActionId, restrictionsOperations.Spartan_BR_Operation_Restrictions_Details, restrictionsEvents.Spartan_BR_Event_Restrictions_Details))
                    {
                        item.Description = CultureHelper.GetTraduction(Convert.ToString(item.ActionId), "Spartan_BR_Action", item.Description, "Description");
                        resultFinal.Add(item);
                    }
                }
                return Json(resultFinal.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_BR_Actions_False_Detail_Spartan_BR_Action_ResultAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Action_ResultApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Action_ResultApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
                    item.Description = CultureHelper.GetTraduction(Convert.ToString(item.ActionResultId), "Spartan_BR_Action_Result", item.Description, "Description");
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_BR_Operation_Detail(int MasterId, int referenceId, List<Spartan_BR_Operation_DetailGridModelPost> Spartan_BR_Operation_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_BR_Operation_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_BR_Operation_DetailData = _ISpartan_BR_Operation_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Operation_Detail.Business_Rule=" + referenceId, "").Resource;
                if (Spartan_BR_Operation_DetailData == null || Spartan_BR_Operation_DetailData.Spartan_BR_Operation_Details.Count == 0)
                    return true;

                var result = true;

                Spartan_BR_Operation_DetailGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varSpartan_BR_Operation_Detail in Spartan_BR_Operation_DetailData.Spartan_BR_Operation_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Spartan_BR_Operation_Detail Spartan_BR_Operation_Detail1 = varSpartan_BR_Operation_Detail;

                    if (Spartan_BR_Operation_DetailItems != null && Spartan_BR_Operation_DetailItems.Any(m => m.OperationDetailId == Spartan_BR_Operation_Detail1.OperationDetailId))
                    {
                        modelDataToChange = Spartan_BR_Operation_DetailItems.FirstOrDefault(m => m.OperationDetailId == Spartan_BR_Operation_Detail1.OperationDetailId);
                    }
                    //Chaning Id Value
                    varSpartan_BR_Operation_Detail.Business_Rule = MasterId;
                    var insertId = _ISpartan_BR_Operation_DetailApiConsumer.Insert(varSpartan_BR_Operation_Detail, null, null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.OperationDetailId = insertId;

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
        public ActionResult PostSpartan_BR_Operation_Detail(List<Spartan_BR_Operation_DetailGridModelPost> Spartan_BR_Operation_DetailItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                if (Spartan_BR_Operation_DetailItems != null && Spartan_BR_Operation_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Operation_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartaneQueryApiConsumer.SetAuthHeader(_tokenManager.Token);

                    if (MasterId != 0)
                    {
                        var delete = _ISpartaneQueryApiConsumer.ExecuteQuery("DELETE FROM Spartan_BR_Operation_Detail WHERE Business_Rule=" + MasterId).Resource;
                    }

                    foreach (var Spartan_BR_Operation_DetailItem in Spartan_BR_Operation_DetailItems)
                    {


                        if (referenceId.ToString() != MasterId.ToString())
                            Spartan_BR_Operation_DetailItem.OperationDetailId = 0;

                        var Spartan_BR_Operation_DetailData = new Spartan_BR_Operation_Detail
                        {
                            Business_Rule = MasterId
                            ,
                            OperationDetailId = Spartan_BR_Operation_DetailItem.OperationDetailId
                            ,
                            Operation = (Convert.ToInt16(Spartan_BR_Operation_DetailItem.Operation) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Operation_DetailItem.Operation))

                        };

                        var resultId = Spartan_BR_Operation_DetailItem.OperationDetailId > 0
                           ? _ISpartan_BR_Operation_DetailApiConsumer.Update(Spartan_BR_Operation_DetailData, null, null).Resource
                           : _ISpartan_BR_Operation_DetailApiConsumer.Insert(Spartan_BR_Operation_DetailData, null, null).Resource;

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
        public ActionResult GetSpartan_BR_Operation_Detail_Spartan_BR_OperationAll(string ScopeId = "0")
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_OperationApiConsumer.SetAuthHeader(_tokenManager.Token);
                string where = "";
                if (ScopeId != "0")
                {
                    where = " Spartan_BR_Operation.ScopeId IN (" + ScopeId + ")";
                }
                var result = _ISpartan_BR_OperationApiConsumer.ListaSelAll(0, 1000, where, "").Resource;
                if (result.Spartan_BR_Operations == null)
                    result.Spartan_BR_Operations = new List<Spartan_BR_Operation>();
                return Json(new
                {
                    aaData = result.Spartan_BR_Operations.Select(m => new Spartan_BR_OperationGridModel
                    {

                        OperationId = m.OperationId
                    ,
                        Description = CultureHelper.GetTraduction(m.OperationId.ToString(), "Spartan_BR_Operation", m.Description, "Description")

                    }).ToList()
                }, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_BR_Process_Event_Detail(int MasterId, int referenceId, List<Spartan_BR_Process_Event_DetailGridModelPost> Spartan_BR_Process_Event_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_BR_Process_Event_DetailData = _ISpartan_BR_Process_Event_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Process_Event_Detail.Business_Rule=" + referenceId, "").Resource;
                if (Spartan_BR_Process_Event_DetailData == null || Spartan_BR_Process_Event_DetailData.Spartan_BR_Process_Event_Details.Count == 0)
                    return true;

                var result = true;

                Spartan_BR_Process_Event_DetailGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varSpartan_BR_Process_Event_Detail in Spartan_BR_Process_Event_DetailData.Spartan_BR_Process_Event_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Spartan_BR_Process_Event_Detail Spartan_BR_Process_Event_Detail1 = varSpartan_BR_Process_Event_Detail;

                    if (Spartan_BR_Process_Event_DetailItems != null && Spartan_BR_Process_Event_DetailItems.Any(m => m.ProcessEventDetailId == Spartan_BR_Process_Event_Detail1.ProcessEventDetailId))
                    {
                        modelDataToChange = Spartan_BR_Process_Event_DetailItems.FirstOrDefault(m => m.ProcessEventDetailId == Spartan_BR_Process_Event_Detail1.ProcessEventDetailId);
                    }
                    //Chaning Id Value
                    varSpartan_BR_Process_Event_Detail.Business_Rule = MasterId;
                    var insertId = _ISpartan_BR_Process_Event_DetailApiConsumer.Insert(varSpartan_BR_Process_Event_Detail, null, null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.ProcessEventDetailId = insertId;

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
        public ActionResult PostSpartan_BR_Process_Event_Detail(List<Spartan_BR_Process_Event_DetailGridModelPost> Spartan_BR_Process_Event_DetailItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                if (Spartan_BR_Process_Event_DetailItems != null && Spartan_BR_Process_Event_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartaneQueryApiConsumer.SetAuthHeader(_tokenManager.Token);

                    if (MasterId != 0)
                    {
                        var delete = _ISpartaneQueryApiConsumer.ExecuteQuery("DELETE FROM Spartan_BR_Process_Event_Detail WHERE Business_Rule=" + MasterId).Resource;
                    }

                    foreach (var Spartan_BR_Process_Event_DetailItem in Spartan_BR_Process_Event_DetailItems)
                    {

                        if (referenceId.ToString() != MasterId.ToString())
                            Spartan_BR_Process_Event_DetailItem.ProcessEventDetailId = 0;

                        var Spartan_BR_Process_Event_DetailData = new Spartan_BR_Process_Event_Detail
                        {
                            Business_Rule = MasterId
                            ,
                            ProcessEventDetailId = Spartan_BR_Process_Event_DetailItem.ProcessEventDetailId
                            ,
                            Process_Event = (Convert.ToInt16(Spartan_BR_Process_Event_DetailItem.Process_Event) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Process_Event_DetailItem.Process_Event))

                        };

                        var resultId = Spartan_BR_Process_Event_DetailItem.ProcessEventDetailId > 0
                           ? _ISpartan_BR_Process_Event_DetailApiConsumer.Update(Spartan_BR_Process_Event_DetailData, null, null).Resource
                           : _ISpartan_BR_Process_Event_DetailApiConsumer.Insert(Spartan_BR_Process_Event_DetailData, null, null).Resource;

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
        public ActionResult GetSpartan_BR_Process_Event_Detail_Spartan_BR_Process_EventAll(string Attribute, string ScopeId = "0")
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Process_EventApiConsumer.SetAuthHeader(_tokenManager.Token);
                string where = "Spartan_BR_Process_Event.Attribute IN (" + Attribute + ")";
                /*if (!Attribute.Contains(","))
                {
                    where = "Spartan_BR_Process_Event.Attribute = 1";
                }*/
                if (Convert.ToInt32(Attribute) > 10)
                {
                    where = "Spartan_BR_Process_Event.Attribute = 1";
                }				
                if (ScopeId != "0")
                {
                    where += " AND Spartan_BR_Process_Event.ScopeId IN (" + ScopeId + ")";
                }
                var result = _ISpartan_BR_Process_EventApiConsumer.ListaSelAll(0, 1000, where, "").Resource;
                if (result.Spartan_BR_Process_Events == null)
                    result.Spartan_BR_Process_Events = new List<Spartan_BR_Process_Event>();
                return Json(new
                {
                    aaData = result.Spartan_BR_Process_Events.Select(m => new Spartan_BR_Process_EventGridModel
                    {
                        ProcessEventId = m.ProcessEventId
                    ,
                        Description = CultureHelper.GetTraduction(m.ProcessEventId.ToString(), "Spartan_BR_Process_Event", m.Description, "Description")

                    }).ToList()
                }, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_BR_Peer_Review(int MasterId, int referenceId, List<Spartan_BR_Peer_ReviewGridModelPost> Spartan_BR_Peer_ReviewItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_BR_Peer_ReviewApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_BR_Peer_ReviewData = _ISpartan_BR_Peer_ReviewApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Peer_Review.Business_Rule=" + referenceId, "").Resource;
                if (Spartan_BR_Peer_ReviewData == null || Spartan_BR_Peer_ReviewData.Spartan_BR_Peer_Reviews.Count == 0)
                    return true;

                var result = true;

                Spartan_BR_Peer_ReviewGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varSpartan_BR_Peer_Review in Spartan_BR_Peer_ReviewData.Spartan_BR_Peer_Reviews)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Spartan_BR_Peer_Review Spartan_BR_Peer_Review1 = varSpartan_BR_Peer_Review;

                    if (Spartan_BR_Peer_ReviewItems != null && Spartan_BR_Peer_ReviewItems.Any(m => m.Key_Peer_Review == Spartan_BR_Peer_Review1.Key_Peer_Review))
                    {
                        modelDataToChange = Spartan_BR_Peer_ReviewItems.FirstOrDefault(m => m.Key_Peer_Review == Spartan_BR_Peer_Review1.Key_Peer_Review);
                    }
                    //Chaning Id Value
                    varSpartan_BR_Peer_Review.Business_Rule = MasterId;
                    var insertId = _ISpartan_BR_Peer_ReviewApiConsumer.Insert(varSpartan_BR_Peer_Review, null, null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.Key_Peer_Review = insertId;

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
        public ActionResult PostSpartan_BR_Peer_Review(List<Spartan_BR_Peer_ReviewGridModelPost> Spartan_BR_Peer_ReviewItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_BR_Peer_Review(MasterId, referenceId, Spartan_BR_Peer_ReviewItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_BR_Peer_ReviewItems != null && Spartan_BR_Peer_ReviewItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Peer_ReviewApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_BR_Peer_ReviewItem in Spartan_BR_Peer_ReviewItems)
                    {
                        #region EvidenceInfo
                        //Checking if file exist if yes edit or add
                        if (Spartan_BR_Peer_ReviewItem.EvidenceInfo.Control != null && !Spartan_BR_Peer_ReviewItem.Removed)
                        {
                            var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(Spartan_BR_Peer_ReviewItem.EvidenceInfo.Control);
                            Spartan_BR_Peer_ReviewItem.EvidenceInfo.FileId = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                            {
                                File = fileAsBytes,
                                Description = Spartan_BR_Peer_ReviewItem.EvidenceInfo.Control.FileName,
                                File_Size = fileAsBytes.Length
                            }).Resource;
                        }
                        else if (!Spartan_BR_Peer_ReviewItem.Removed && Spartan_BR_Peer_ReviewItem.EvidenceInfo.RemoveFile)
                        {
                            Spartan_BR_Peer_ReviewItem.EvidenceInfo.FileId = 0;
                        }
                        #endregion EvidenceInfo

                        //Removal Request
                        if (Spartan_BR_Peer_ReviewItem.Removed)
                        {
                            result = result && _ISpartan_BR_Peer_ReviewApiConsumer.Delete(Spartan_BR_Peer_ReviewItem.Key_Peer_Review, null, null).Resource;
                            continue;
                        }
                        if (referenceId.ToString() != MasterId.ToString())
                            Spartan_BR_Peer_ReviewItem.Key_Peer_Review = 0;

                        var Spartan_BR_Peer_ReviewData = new Spartan_BR_Peer_Review
                        {
                            Business_Rule = MasterId
                            ,
                            Key_Peer_Review = Spartan_BR_Peer_ReviewItem.Key_Peer_Review
                            ,
                            User_that_reviewed = (Convert.ToInt32(Spartan_BR_Peer_ReviewItem.User_that_reviewed) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_BR_Peer_ReviewItem.User_that_reviewed))
                            ,
                            Acceptance_Criteria = Spartan_BR_Peer_ReviewItem.Acceptance_Criteria
                            ,
                            It_worked = Spartan_BR_Peer_ReviewItem.It_worked
                            ,
                            Rejection_reason = (Convert.ToInt32(Spartan_BR_Peer_ReviewItem.Rejection_reason) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_BR_Peer_ReviewItem.Rejection_reason))
                            ,
                            Comments = Spartan_BR_Peer_ReviewItem.Comments
                            ,
                            Evidence = Spartan_BR_Peer_ReviewItem.EvidenceInfo.FileId

                        };

                        var resultId = Spartan_BR_Peer_ReviewItem.Key_Peer_Review > 0
                           ? _ISpartan_BR_Peer_ReviewApiConsumer.Update(Spartan_BR_Peer_ReviewData, null, null).Resource
                           : _ISpartan_BR_Peer_ReviewApiConsumer.Insert(Spartan_BR_Peer_ReviewData, null, null).Resource;

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
        public ActionResult GetSpartan_BR_Peer_Review_Spartan_UserAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_UserApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_BR_Peer_Review_Spartan_BR_Rejection_ReasonAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Rejection_ReasonApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Rejection_ReasonApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
                    item.Description = CultureHelper.GetTraduction(Convert.ToString(item.Key_Rejection_Reason), "Spartan_BR_Rejection_Reason", item.Description, "Description");
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_BR_Testing(int MasterId, int referenceId, List<Spartan_BR_TestingGridModelPost> Spartan_BR_TestingItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_BR_TestingApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_BR_TestingData = _ISpartan_BR_TestingApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Testing.Business_Rule=" + referenceId, "").Resource;
                if (Spartan_BR_TestingData == null || Spartan_BR_TestingData.Spartan_BR_Testings.Count == 0)
                    return true;

                var result = true;

                Spartan_BR_TestingGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varSpartan_BR_Testing in Spartan_BR_TestingData.Spartan_BR_Testings)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Spartan_BR_Testing Spartan_BR_Testing1 = varSpartan_BR_Testing;

                    if (Spartan_BR_TestingItems != null && Spartan_BR_TestingItems.Any(m => m.Key_Testing == Spartan_BR_Testing1.Key_Testing))
                    {
                        modelDataToChange = Spartan_BR_TestingItems.FirstOrDefault(m => m.Key_Testing == Spartan_BR_Testing1.Key_Testing);
                    }
                    //Chaning Id Value
                    varSpartan_BR_Testing.Business_Rule = MasterId;
                    var insertId = _ISpartan_BR_TestingApiConsumer.Insert(varSpartan_BR_Testing, null, null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.Key_Testing = insertId;

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
        public ActionResult PostSpartan_BR_Testing(List<Spartan_BR_TestingGridModelPost> Spartan_BR_TestingItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_BR_Testing(MasterId, referenceId, Spartan_BR_TestingItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_BR_TestingItems != null && Spartan_BR_TestingItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_TestingApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Spartan_BR_TestingItem in Spartan_BR_TestingItems)
                    {
                        #region EvidenceInfo
                        //Checking if file exist if yes edit or add
                        if (Spartan_BR_TestingItem.EvidenceInfo.Control != null && !Spartan_BR_TestingItem.Removed)
                        {
                            var fileAsBytes = HttpPostedFileHelper.GetPostedFileAsBytes(Spartan_BR_TestingItem.EvidenceInfo.Control);
                            Spartan_BR_TestingItem.EvidenceInfo.FileId = (int)_ISpartane_FileApiConsumer.Insert(new Spartane_File()
                            {
                                File = fileAsBytes,
                                Description = Spartan_BR_TestingItem.EvidenceInfo.Control.FileName,
                                File_Size = fileAsBytes.Length
                            }).Resource;
                        }
                        else if (!Spartan_BR_TestingItem.Removed && Spartan_BR_TestingItem.EvidenceInfo.RemoveFile)
                        {
                            Spartan_BR_TestingItem.EvidenceInfo.FileId = 0;
                        }
                        #endregion EvidenceInfo

                        //Removal Request
                        if (Spartan_BR_TestingItem.Removed)
                        {
                            result = result && _ISpartan_BR_TestingApiConsumer.Delete(Spartan_BR_TestingItem.Key_Testing, null, null).Resource;
                            continue;
                        }
                        if (referenceId.ToString() != MasterId.ToString())
                            Spartan_BR_TestingItem.Key_Testing = 0;

                        var Spartan_BR_TestingData = new Spartan_BR_Testing
                        {
                            Business_Rule = MasterId
                            ,
                            Key_Testing = Spartan_BR_TestingItem.Key_Testing
                            ,
                            User_that_reviewed = (Convert.ToInt32(Spartan_BR_TestingItem.User_that_reviewed) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_BR_TestingItem.User_that_reviewed))
                            ,
                            Acceptance_Critera = Spartan_BR_TestingItem.Acceptance_Critera
                            ,
                            It_worked = Spartan_BR_TestingItem.It_worked
                            ,
                            Rejection_Reason = (Convert.ToInt32(Spartan_BR_TestingItem.Rejection_Reason) == 0 ? (Int32?)null : Convert.ToInt32(Spartan_BR_TestingItem.Rejection_Reason))
                            ,
                            Comments = Spartan_BR_TestingItem.Comments
                            ,
                            Evidence = Spartan_BR_TestingItem.EvidenceInfo.FileId

                        };

                        var resultId = Spartan_BR_TestingItem.Key_Testing > 0
                           ? _ISpartan_BR_TestingApiConsumer.Update(Spartan_BR_TestingData, null, null).Resource
                           : _ISpartan_BR_TestingApiConsumer.Insert(Spartan_BR_TestingData, null, null).Resource;

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
        public ActionResult GetSpartan_BR_Testing_Spartan_UserAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_UserApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_UserApiConsumer.SelAll(false).Resource;
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetSpartan_BR_Testing_Spartan_BR_Rejection_ReasonAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Rejection_ReasonApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_Rejection_ReasonApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
                    item.Description = CultureHelper.GetTraduction(Convert.ToString(item.Key_Rejection_Reason), "Spartan_BR_Rejection_Reason", item.Description, "Description");
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopySpartan_BR_Scope_Detail(int MasterId, int referenceId, List<Spartan_BR_Scope_DetailGridModelPost> Spartan_BR_Scope_DetailItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _ISpartan_BR_Scope_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Spartan_BR_Scope_DetailData = _ISpartan_BR_Scope_DetailApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_BR_Scope_Detail.Business_Rule=" + referenceId, "").Resource;
                if (Spartan_BR_Scope_DetailData == null || Spartan_BR_Scope_DetailData.Spartan_BR_Scope_Details.Count == 0)
                    return true;

                var result = true;

                Spartan_BR_Scope_DetailGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varSpartan_BR_Scope_Detail in Spartan_BR_Scope_DetailData.Spartan_BR_Scope_Details)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Spartan_BR_Scope_Detail Spartan_BR_Scope_Detail1 = varSpartan_BR_Scope_Detail;

                    if (Spartan_BR_Scope_DetailItems != null && Spartan_BR_Scope_DetailItems.Any(m => m.ScopeDetailId == Spartan_BR_Scope_Detail1.ScopeDetailId))
                    {
                        modelDataToChange = Spartan_BR_Scope_DetailItems.FirstOrDefault(m => m.ScopeDetailId == Spartan_BR_Scope_Detail1.ScopeDetailId);
                    }
                    //Chaning Id Value
                    varSpartan_BR_Scope_Detail.Business_Rule = MasterId;
                    var insertId = _ISpartan_BR_Scope_DetailApiConsumer.Insert(varSpartan_BR_Scope_Detail, null, null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.ScopeDetailId = insertId;

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
        public ActionResult PostSpartan_BR_Scope_Detail(List<Spartan_BR_Scope_DetailGridModelPost> Spartan_BR_Scope_DetailItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopySpartan_BR_Scope_Detail(MasterId, referenceId, Spartan_BR_Scope_DetailItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Spartan_BR_Scope_DetailItems != null && Spartan_BR_Scope_DetailItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartan_BR_Scope_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _ISpartaneQueryApiConsumer.SetAuthHeader(_tokenManager.Token);
                    if (MasterId != 0)
                    {
                        var delete = _ISpartaneQueryApiConsumer.ExecuteQuery("DELETE FROM Spartan_BR_Scope_Detail WHERE Business_Rule=" + MasterId).Resource;
                    }
                    foreach (var Spartan_BR_Scope_DetailItem in Spartan_BR_Scope_DetailItems)
                    {
                        if (referenceId.ToString() != MasterId.ToString())
                            Spartan_BR_Scope_DetailItem.ScopeDetailId = 0;

                        var Spartan_BR_Scope_DetailData = new Spartan_BR_Scope_Detail
                        {
                            Business_Rule = MasterId
                            ,
                            ScopeDetailId = Spartan_BR_Scope_DetailItem.ScopeDetailId
                            ,
                            Scope = (Convert.ToInt16(Spartan_BR_Scope_DetailItem.Scope) == 0 ? (Int16?)null : Convert.ToInt16(Spartan_BR_Scope_DetailItem.Scope))

                        };

                        var resultId = Spartan_BR_Scope_DetailItem.ScopeDetailId > 0
                           ? _ISpartan_BR_Scope_DetailApiConsumer.Update(Spartan_BR_Scope_DetailData, null, null).Resource
                           : _ISpartan_BR_Scope_DetailApiConsumer.Insert(Spartan_BR_Scope_DetailData, null, null).Resource;

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
        public ActionResult GetSpartan_BR_Scope_Detail_Spartan_BR_ScopeAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_ScopeApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _ISpartan_BR_ScopeApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
                    item.Description = CultureHelper.GetTraduction(Convert.ToString(item.ScopeId), "Spartan_BR_Scope", item.Description, "Description");
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Business_Rule_Creation script
        /// </summary>
        /// <param name="oBusiness_Rule_CreationElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Business_Rule_CreationModuleAttributeList)
        {
            for (int i = 0; i < Business_Rule_CreationModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Business_Rule_CreationModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Business_Rule_CreationModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Business_Rule_CreationModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Business_Rule_CreationModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
            if (Business_Rule_CreationModuleAttributeList.ChildModuleAttributeList != null)
            {
                for (int i = 0; i < Business_Rule_CreationModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
                {
                    for (int j = 0; j < Business_Rule_CreationModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
                    {
                        if (string.IsNullOrEmpty(Business_Rule_CreationModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
                        {
                            Business_Rule_CreationModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
                        }
                        if (string.IsNullOrEmpty(Business_Rule_CreationModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
                        {
                            Business_Rule_CreationModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
                        }
                    }
                }
            }
            string strBusiness_Rule_CreationScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Business_Rule_Creation.js")))
            {
                strBusiness_Rule_CreationScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Business_Rule_Creation element attributes
            string userChangeJson = jsSerialize.Serialize(Business_Rule_CreationModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strBusiness_Rule_CreationScript.IndexOf("inpuElementArray");
            string splittedString = strBusiness_Rule_CreationScript.Substring(indexOfArray, strBusiness_Rule_CreationScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Business_Rule_CreationModuleAttributeList.ChildModuleAttributeList);
            int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
            if (Business_Rule_CreationModuleAttributeList.ChildModuleAttributeList != null)
            {
                indexOfArrayHistory = strBusiness_Rule_CreationScript.IndexOf("});");
                if (indexOfArrayHistory != -1)
                {
                    splittedStringHistory = strBusiness_Rule_CreationScript.Substring(indexOfArrayHistory, strBusiness_Rule_CreationScript.Length - indexOfArrayHistory);
                    indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
                    endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
                }
            }
            string finalResponse = strBusiness_Rule_CreationScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strBusiness_Rule_CreationScript.Substring(endIndexOfMainElement + indexOfArray, strBusiness_Rule_CreationScript.Length - (endIndexOfMainElement + indexOfArray));

            var ResponseChild = string.Empty;
            if (Business_Rule_CreationModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Business_Rule_CreationModuleAttributeList.ChildModuleAttributeList)
                {
                    if (item != null && item.elements != null && item.elements.Count > 0)
                        ResponseChild += "\r\n  \n\r function set" + item.table + "Validation() { " +
                                        " \r\n var inpuElementChildArray =" + jsSerialize.Serialize(item.elements) + ";" +
                                        "  \r\n setInputEntityAttributes(inpuElementChildArray, \".\", 0);" +
                                        "  \r\n setDynamicRenderElement(); \n\r } ";

                }
            }
            finalResponse = finalResponse.Substring(0, finalResponse.IndexOf("});") + 4) + "\n\r";
            finalResponse += ResponseChild;


            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Business_Rule_Creation.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Business_Rule_Creation.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Business_Rule_Creation.js")))
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
        public ActionResult Business_Rule_CreationPropertyBag()
        {
            return PartialView("Business_Rule_CreationPropertyBag", "Business_Rule_Creation");
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
        public ActionResult AddSpartan_BR_Conditions_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_BR_Conditions_Detail/AddSpartan_BR_Conditions_Detail");
        }

        [HttpGet]
        public ActionResult AddSpartan_BR_Actions_True_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_BR_Actions_True_Detail/AddSpartan_BR_Actions_True_Detail");
        }

        [HttpGet]
        public ActionResult AddSpartan_BR_Actions_False_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_BR_Actions_False_Detail/AddSpartan_BR_Actions_False_Detail");
        }

        [HttpGet]
        public ActionResult AddSpartan_BR_Operation_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_BR_Operation_Detail/AddSpartan_BR_Operation_Detail");
        }

        [HttpGet]
        public ActionResult AddSpartan_BR_Process_Event_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_BR_Process_Event_Detail/AddSpartan_BR_Process_Event_Detail");
        }

        [HttpGet]
        public ActionResult AddSpartan_BR_Peer_Review(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_BR_Peer_Review/AddSpartan_BR_Peer_Review");
        }

        [HttpGet]
        public ActionResult AddSpartan_BR_Testing(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_BR_Testing/AddSpartan_BR_Testing");
        }

        [HttpGet]
        public ActionResult AddSpartan_BR_Scope_Detail(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Spartan_BR_Scope_Detail/AddSpartan_BR_Scope_Detail");
        }



        #endregion "Controller Methods"

        #region "Custom methods"

        [HttpGet]
        public FileStreamResult PrintFormats(int idFormat, string RecordId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _IGeneratePDFApiConsumer.SetAuthHeader(_tokenManager.Token);
            var bytePdf = _IGeneratePDFApiConsumer.GeneratePDF(idFormat, RecordId);

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
            int ObjectId = (int)Session["ObjectIdRules"];
            int Attribute = (int)Session["AttributeRules"];

            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return;

            _IBusiness_Rule_CreationApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Business_Rule_CreationPropertyMapper());

            //Adding Advance Search
            if (!string.IsNullOrEmpty(Request.QueryString["AdvanceSearch"]) && Request.QueryString["AdvanceSearch"] == "True")
            {
                var advanceFilter =
                    (Business_Rule_CreationAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
            if (configuration.WhereClause != "")
                configuration.WhereClause += " AND ";
            configuration.WhereClause += "Business_Rule_Creation.Object = " + ObjectId + " AND Business_Rule_Creation.Attribute = " + Attribute;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IBusiness_Rule_CreationApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Business_Rule_Creations == null)
                result.Business_Rule_Creations = new List<Business_Rule_Creation>();

            var data = result.Business_Rule_Creations.Select(m => new Business_Rule_CreationGridModel
            {
                Key_Business_Rule_Creation = m.Key_Business_Rule_Creation
                        ,
                UserName = (string)m.User_Spartan_User.Name
                        ,
                Creation_Date = (m.Creation_Date == null ? string.Empty : Convert.ToDateTime(m.Creation_Date).ToString(ConfigurationProperty.DateFormat))
            ,
                Creation_Hour = m.Creation_Hour
                        ,
                Last_Updated_Date = (m.Last_Updated_Date == null ? string.Empty : Convert.ToDateTime(m.Last_Updated_Date).ToString(ConfigurationProperty.DateFormat))
            ,
                Last_Updated_Hour = m.Last_Updated_Hour
            ,
                Time_that_took = m.Time_that_took
            ,
                Name = m.Name
            ,
                Documentation = m.Documentation
                        ,
                StatusDescription = (string)m.Status_Spartan_BR_Status.Description
                        ,
                ComplexityDescription = (string)m.Complexity_Spartan_BR_Complexity.Description

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Business_Rule_CreationList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Business_Rule_CreationList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "Business_Rule_CreationList_" + DateTime.Now.ToString());
                    break;
            }
        }

        [HttpGet]
        //[ObjectAuth(ObjectId = ModuleObjectId.EMPLEADOS_OBJECT, PermissionType = PermissionTypes.Export)]
        public ActionResult Print(string format, int pageIndex, int pageSize)
        {
            int ObjectId = (int)Session["ObjectIdRules"];
            int Attribute = (int)Session["AttributeRules"];

            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return null;

            _IBusiness_Rule_CreationApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Business_Rule_CreationPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;
            if (configuration.WhereClause != "")
                configuration.WhereClause += " AND ";
            configuration.WhereClause += "Business_Rule_Creation.Object = " + ObjectId + " AND Business_Rule_Creation.Attribute = " + Attribute;

            var result = _IBusiness_Rule_CreationApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Business_Rule_Creations == null)
                result.Business_Rule_Creations = new List<Business_Rule_Creation>();

            var data = result.Business_Rule_Creations.Select(m => new Business_Rule_CreationGridModel
            {
                Key_Business_Rule_Creation = m.Key_Business_Rule_Creation
                        ,
                UserName = (string)m.User_Spartan_User.Name
                        ,
                Creation_Date = (m.Creation_Date == null ? string.Empty : Convert.ToDateTime(m.Creation_Date).ToString(ConfigurationProperty.DateFormat))
            ,
                Creation_Hour = m.Creation_Hour
                        ,
                Last_Updated_Date = (m.Last_Updated_Date == null ? string.Empty : Convert.ToDateTime(m.Last_Updated_Date).ToString(ConfigurationProperty.DateFormat))
            ,
                Last_Updated_Hour = m.Last_Updated_Hour
            ,
                Time_that_took = m.Time_that_took
            ,
                Name = m.Name
            ,
                Documentation = m.Documentation
                        ,
                StatusDescription = (string)m.Status_Spartan_BR_Status.Description
                        ,
                ComplexityDescription = (string)m.Complexity_Spartan_BR_Complexity.Description

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"

        /// <summary>
        /// Get List of Spartan_BR_Condition from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_BR_Condition Entity</returns>
        public ActionResult GetConditionsList()
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_BR_ConditionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _ISpartan_BR_ConditionApiConsumer.ListaSelAll(0, 1000, "", "").Resource;
            if (result.Spartan_BR_Conditions == null)
                result.Spartan_BR_Conditions = new List<Spartan_BR_Condition>();

            return Json(new
            {
                aaData = result.Spartan_BR_Conditions.Select(m => new Spartan_BR_ConditionGridModel
                {
                    ConditionId = m.ConditionId
                ,
                    Description = CultureHelper.GetTraduction(m.ConditionId.ToString(), "Spartan_BR_Condition", m.Description, "Description")

                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_BR_Operator_Type from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_BR_Operator_Type Entity</returns>
        public ActionResult GetOperatorTypesList()
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_BR_Operator_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _ISpartan_BR_Operator_TypeApiConsumer.ListaSelAll(0, 1000, "", "").Resource;
            if (result.Spartan_BR_Operator_Types == null)
                result.Spartan_BR_Operator_Types = new List<Spartan_BR_Operator_Type>();

            return Json(new
            {
                aaData = result.Spartan_BR_Operator_Types.Select(m => new Spartan_BR_Operator_TypeGridModel
                {
                    OperatorTypeId = m.OperatorTypeId
                ,
                    Description = CultureHelper.GetTraduction(m.OperatorTypeId.ToString(), "Spartan_BR_Operator_Type", m.Description, "Description")

                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_BR_Condition_Operator from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_BR_Condition_Operator Entity</returns>
        public ActionResult GetConditionOperatorList()
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_BR_Condition_OperatorApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _ISpartan_BR_Condition_OperatorApiConsumer.ListaSelAll(0, 1000, "", "").Resource;
            if (result.Spartan_BR_Condition_Operators == null)
                result.Spartan_BR_Condition_Operators = new List<Spartan_BR_Condition_Operator>();

            return Json(new
            {
                aaData = result.Spartan_BR_Condition_Operators.Select(m => new Spartan_BR_Condition_OperatorGridModel
                {
                    ConditionOperatorId = m.ConditionOperatorId
                ,
                    Description = CultureHelper.GetTraduction(m.ConditionOperatorId.ToString(), "Spartan_BR_Condition_Operator", m.Description, "Description")

                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get Spartan_BR_Operator_Type from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return Spartan_BR_Operator_Type Entity</returns>
        public JsonResult GetOperatorTypeById(int id, string objectId, string attributeId)
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_BR_Operator_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _ISpartan_BR_Operator_TypeApiConsumer.GetByKey(id, true).Resource;
            if (!String.IsNullOrEmpty(result.Query_for_Fill_Condition.Trim()))
            {
                _ISpartaneQueryApiConsumer.SetAuthHeader(_tokenManager.Token);
                if (!String.IsNullOrEmpty(attributeId))
                {
                    if (Convert.ToInt32(attributeId) > 20)
                    {
                        string queryGetObjectId = "SELECT Object_Id FROM Spartan_Metadata WHERE AttributeId = " + attributeId;
                        string queryGetTypeOfAttribute = "SELECT Relation_Type FROM Spartan_Metadata WHERE AttributeId = " + attributeId;
                        string isMR = (string)_ISpartaneQueryApiConsumer.ExecuteQuery(queryGetTypeOfAttribute).Resource;
                        if (isMR == "2")
                        {
                            queryGetObjectId = "SELECT Related_Object_Id FROM Spartan_Metadata WHERE AttributeId = " + attributeId;
                        }
                        objectId = (string)_ISpartaneQueryApiConsumer.ExecuteQuery(queryGetObjectId).Resource;
                    }
                }
                string queryToGetFields = result.Query_for_Fill_Condition.Replace("@@ObjectId@@", objectId).ToString();
                queryToGetFields = queryToGetFields.Replace("@@AttributeId@@", attributeId);
                Dictionary<string, string> resultQuery = _ISpartaneQueryApiConsumer.ExecuteQueryDictionary(queryToGetFields).Resource;
                /*Dictionary<string, string> resultChanged = new Dictionary<string, string>();
                foreach (var item in resultQuery)
                {
                    resultChanged.Add(result.Implementation_Code.Replace("@@parameter.value@@", item.Value), item.Value);
                }*/
                return Json(new
                {
                    aaData = resultQuery//resultChanged
                }, JsonRequestBehavior.AllowGet);
            }
            return Json(new
            {
                aaData = ""
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetActionClassificationList()
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_BR_Action_ClassificationApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _ISpartan_BR_Action_ClassificationApiConsumer.ListaSelAll(0, 1000, "", "").Resource;
            if (result.Spartan_BR_Action_Classifications == null)
                result.Spartan_BR_Action_Classifications = new List<Spartan_BR_Action_Classification>();

            return Json(new
            {
                aaData = result.Spartan_BR_Action_Classifications.Select(m => new Spartan_BR_Action_ClassificationGridModel
                {
                    ClassificationId = m.ClassificationId
                ,
                    Description = CultureHelper.GetTraduction(m.ClassificationId.ToString(), "Spartan_BR_Action_Classification", m.Description, "Description")

                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetActionResultList()
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_BR_Action_ResultApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _ISpartan_BR_Action_ResultApiConsumer.ListaSelAll(0, 1000, "", "").Resource;
            if (result.Spartan_BR_Action_Results == null)
                result.Spartan_BR_Action_Results = new List<Spartan_BR_Action_Result>();

            return Json(new
            {
                aaData = result.Spartan_BR_Action_Results.Select(m => new Spartan_BR_Action_ResultGridModel
                {
                    ActionResultId = m.ActionResultId
                ,
                    Description = CultureHelper.GetTraduction(m.ActionResultId.ToString(), "Spartan_BR_Action_Result", m.Description, "Description")

                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetActionListByClassification(int classificationId, string operations, string events)
        {
            List<Spartan_BR_Action> resultFinal = new List<Spartan_BR_Action>();
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_BR_ActionApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_BR_Event_Restrictions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_BR_Operation_Restrictions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);

            var result = _ISpartan_BR_ActionApiConsumer.ListaSelAll(0, 1000, "Classification = " + classificationId, "").Resource;

            var restrictionsOperations = _ISpartan_BR_Operation_Restrictions_DetailApiConsumer.ListaSelAll(0, 9999, "Spartan_BR_Operation_Restrictions_Detail.Operation IN (" + operations + ")", "").Resource;
            var restrictionsEvents = _ISpartan_BR_Event_Restrictions_DetailApiConsumer.ListaSelAll(0, 9999, "Spartan_BR_Event_Restrictions_Detail.Process_Event IN (" + events + ")", "").Resource;

            if (result.Spartan_BR_Actions == null)
                result.Spartan_BR_Actions = new List<Spartan_BR_Action>();

            foreach (var item in result.Spartan_BR_Actions)
            {
                if (!IsRestricted(item.ActionId, restrictionsOperations.Spartan_BR_Operation_Restrictions_Details, restrictionsEvents.Spartan_BR_Event_Restrictions_Details))
                {
                    resultFinal.Add(item);
                }
            }

            return Json(new
            {
                aaData = resultFinal.Select(m => new Spartan_BR_ActionGridModel
                {
                    ActionId = m.ActionId
                ,
                    Description = CultureHelper.GetTraduction(m.ActionId.ToString(), "Spartan_BR_Action", m.Description, "Description")

                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetParametersByActionId(int actionId, string objectId, string attributeId)
        {
            List<object> result = new List<object>();
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartaneQueryApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_BR_Action_Configuration_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
            Spartan_BR_Action_Configuration_DetailPagingModel actionConfigurations = _ISpartan_BR_Action_Configuration_DetailApiConsumer.ListaSelAll(0, 1000, "Action = " + actionId, "").Resource;
            if (actionConfigurations.Spartan_BR_Action_Configuration_Details != null)
            {
                foreach (var configuration in actionConfigurations.Spartan_BR_Action_Configuration_Details)
                {
                    _ISpartan_BR_Action_Param_TypeApiConsumer.SetAuthHeader(_tokenManager.Token);
                    Spartan_BR_Action_Param_Type paramType = _ISpartan_BR_Action_Param_TypeApiConsumer.GetByKey(configuration.Parameter_Type.Value, false).Resource;
                    string queryToGetFields = "";
                    string parameterName = configuration.Parameter_Name;
                    int parameterType = paramType.Presentation_Control_Type.Value;
                    string parameterValueInput = paramType.Code_for_Fill_Condition;
                    Dictionary<string, string> parameterValueCombobox = null;
                    Dictionary<string, string> resultChanged = new Dictionary<string, string>();
                    if (parameterType == 2)
                    {
                        if (!String.IsNullOrEmpty(attributeId))
                        {
                            if (Convert.ToInt32(attributeId) > 20)
                            {
                                string queryGetObjectId = "SELECT Object_Id FROM Spartan_Metadata WHERE AttributeId = " + attributeId;
                                /*string queryGetTypeOfAttribute = "SELECT Relation_Type FROM Spartan_Metadata WHERE AttributeId = " + attributeId;
                                string isMR = (string)_ISpartaneQueryApiConsumer.ExecuteQuery(queryGetTypeOfAttribute).Resource;
                                if (isMR == "2")
                                {
                                    queryGetObjectId = "SELECT Related_Object_Id FROM Spartan_Metadata WHERE AttributeId = " + attributeId;
                                }*/
                                objectId = (string)_ISpartaneQueryApiConsumer.ExecuteQuery(queryGetObjectId).Resource;
                            }
                        }
                        queryToGetFields = paramType.Query_for_Fill_Condition.Replace("@@ObjectId@@", objectId).ToString();
                        queryToGetFields = queryToGetFields.Replace("@@AttributeId@@", attributeId).ToString();
                        parameterValueCombobox = new Dictionary<string, string>();
                        parameterValueCombobox = _ISpartaneQueryApiConsumer.ExecuteQueryDictionary(queryToGetFields).Resource;

                        /*foreach (var item in parameterValueCombobox)
                        {
                            resultChanged.Add(paramType.Implementation_Code.Replace("@@parameter.value@@", item.Value), item.Value);
                        }*/
                    }
                    var data = new
                    {
                        ControlName = parameterName,
                        ControlType = parameterType,
                        ControlDataTextbox = parameterValueInput,
                        ControlDataCombobox = parameterValueCombobox//resultChanged
                    };
                    result.Add(data);
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidateName(string name)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _IBusiness_Rule_CreationApiConsumer.SetAuthHeader(_tokenManager.Token);


            var result = _IBusiness_Rule_CreationApiConsumer.ListaSelAll(0, 10, "REPLACE(LOWER(LTRIM(RTRIM(Business_Rule_Creation.Name))), ' ', '') = REPLACE(LOWER(LTRIM(RTRIM('" + name + "'))), ' ', '')", "").Resource;
            if (result.RowCount == 0)
                return Json(true, JsonRequestBehavior.AllowGet);
            else
                return Json(false, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ChangeActiveBusinessRule(int BussinessRuleId, short? Change)
        {
            try
            {
                var result = 0;
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IBusiness_Rule_CreationApiConsumer.SetAuthHeader(_tokenManager.Token);

                var rule = _IBusiness_Rule_CreationApiConsumer.GetByKey(BussinessRuleId, false).Resource;
                rule.Status = Change;
                result = _IBusiness_Rule_CreationApiConsumer.Update(rule, null, null).Resource;

                RegenerateJS(BussinessRuleId, Change, Convert.ToInt32(rule.Object));

                //FileWritter.Write(rule.Attribute, rule.Oper)
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public string RegenerateJS(int BussinessRuleId, short? Change, int ObjectId)
        {
            try
            {
                if (_tokenManager.GenerateToken())
                {
                    _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);
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
                            if (scope.Scope_Spartan_BR_Scope.Description == "Object")
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
                            else//WEBAPI
                            {
                                if (operations.RowCount > 0)
                                {
                                    foreach (var operation in operations.Spartan_BR_Operation_Details)
                                    {
                                        FileWritter.Path = ConfigurationProperty.BaseDirectoyPhysicalWebApi + "Rules\\" + Object + "Rules.cs";
                                        foreach (var ev in events.Spartan_BR_Process_Event_Details)
                                        {
                                            section = "//NEWBUSINESSRULE_" + ev.Process_Event_Spartan_BR_Process_Event.Description.Replace(" ", "").ToUpper() + "//";
                                            FileWritter.Write(rule.Key_Business_Rule_Creation.ToString(),
                                                rule.Attribute.Value.ToString(),
                                                scope.Scope_Spartan_BR_Scope.Description,
                                                ev.Process_Event_Spartan_BR_Process_Event.Description,
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
        public ActionResult RegenerateRules()
        {
            string result = "";
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
            List<SpartaneObject> objects = _ISpartan_ObjectApiConsumer.SelAll(false).Resource.ToList();
            foreach (var obj in objects)
            {
                result += RegenerateCatalogo(obj.Object_Id);
            }
            return Content(result, "text/plain");
        }

        private string RegenerateCatalogo(int objectId)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return "Not permission";
                //return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);
                Business_Rule_CreationPagingModel rules = _IBusiness_Rule_CreationApiConsumer.ListaSelAll(0, 1000, "Business_Rule_Creation.Object = " + objectId, "").Resource;
                int result;
                if (rules.RowCount > 0)
                {
                    foreach (var rule in rules.Business_Rule_Creations)
                    {
                        result = _IBusiness_Rule_CreationApiConsumer.Update(rule, null, null).Resource;

                    }
                    foreach (var rule in rules.Business_Rule_Creations)
                    {
                        RegenerateJS(rule.Key_Business_Rule_Creation, 4, objectId);
                    }
                    foreach (var rule in rules.Business_Rule_Creations)
                    {
                        if (rule.Status.HasValue && rule.Status.Value != 4)
                            RegenerateJS(rule.Key_Business_Rule_Creation, rule.Status.Value, objectId);
                    }
                    return "Success:" + objectId + " \n";
                }
                else
                {
                    return "El objeto " + objectId + " no contiene reglas de negocio \n";
                }
            }
            catch (Exception ex)
            {
                return "No se regenero el objeto" + objectId + " - Error:" + ex.ToString() + " \n";
            }
        }

        public ActionResult GetSpartan_BR_StatusList()
        {
            _tokenManager.GenerateToken();
            _ISpartan_BR_StatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _ISpartan_BR_StatusApiConsumer.ListaSelAll(0, 10, "", "").Resource;
            if (result.Spartan_BR_Statuss == null)
                result.Spartan_BR_Statuss = new List<Spartan_BR_Status>();

            return Json(new
            {
                aaData = result.Spartan_BR_Statuss.Select(m => new Spartan_BR_StatusGridModel
                {
                    StatusId = m.StatusId
                ,
                    Description = CultureHelper.GetTraduction(m.StatusId.ToString(), "Spartan_BR_Status", m.Description, "Description")

                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangeStatus(int id, int status)
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartaneQueryApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartaneQueryApiConsumer.ExecuteQuery("UPDATE [Business_Rule_Creation] SET Status=" + status + " WHERE [Key_Business_Rule_Creation]=" + id);
            _IBusiness_Rule_CreationApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartaneQueryApiConsumer.ExecuteQuery("exec sp_InsSpartan_BR_History " + Convert.ToInt32(id) + ", " + Convert.ToInt32(Session["USERID"]) + ", 2");
            var rule = _IBusiness_Rule_CreationApiConsumer.GetByKey(id, false).Resource;
            RegenerateJS(id, (short)status, Convert.ToInt32(rule.Object));
            return Json("true", JsonRequestBehavior.AllowGet);
        }

        public ActionResult RegenerateWebApi(int ProjectId)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                bool result = GeneratorHelper.PublishWebApi(ProjectId, _tokenManager.Token);
                if (!result)
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
