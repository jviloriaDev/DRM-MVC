using Spartane.Core.Domain.Spartan_BR_Action;
using Spartane.Core.Domain.Spartan_BR_Action_Classification;
using Spartane.Core.Domain.Spartan_BR_Action_Configuration_Detail;
using Spartane.Core.Domain.Spartan_BR_Action_Param_Type;
using Spartane.Core.Domain.Spartan_BR_Action_Result;
using Spartane.Core.Domain.Spartan_BR_Actions_False_Detail;
using Spartane.Core.Domain.Spartan_BR_Actions_True_Detail;
using Spartane.Core.Domain.Spartan_BR_Condition;
using Spartane.Core.Domain.Spartan_BR_Condition_Operator;
using Spartane.Core.Domain.Spartan_BR_Conditions_Detail;
using Spartane.Core.Domain.Spartan_BR_Operation;
using Spartane.Core.Domain.Spartan_BR_Operation_Detail;
using Spartane.Core.Domain.Spartan_BR_Operator_Type;
using Spartane.Core.Domain.Spartan_BR_Process_Event;
using Spartane.Core.Domain.Spartan_BR_Process_Event_Detail;
using Spartane.Core.Domain.Spartan_BR_Scope;
using Spartane.Core.Domain.Spartan_BR_Scope_Detail;
using Spartane.Core.Domain.Spartan_Business_Rule;
using Spartane.Core.Domain.Spartan_Metadata;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Classification;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Configuration_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Param_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Action_Result;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Actions_False_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Actions_True_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Condition;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Condition_Operator;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Conditions_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operation;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operation_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Operator_Type;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Scope;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Scope_Detail;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;
using Spartane.Web.Areas.WebApiConsumer.SpartaneQuery;
using Spartane.Web.Areas.WebApiConsumer.SpartaneObject;
using Spartane.Web.Helpers;
using Spartane.Web.Models;
using Spartane.Web.SqlModelMapper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Spartane.Core.Domain.SpartaneObject;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    public class BussinessRuleController : Controller
    {
        #region "variable declaration"
        private ISpartan_BR_ScopeApiConsumer _ISpartan_BR_ScopeApiConsumer;
        private ISpartan_BR_OperationApiConsumer _ISpartan_BR_OperationApiConsumer;
        private ISpartan_BR_Process_EventApiConsumer _ISpartan_BR_Process_EventApiConsumer;
        private ISpartan_BR_Operator_TypeApiConsumer _ISpartan_BR_Operator_TypeApiConsumer;
        private ISpartan_BR_ConditionApiConsumer _ISpartan_BR_ConditionApiConsumer;
        private ISpartan_BR_Condition_OperatorApiConsumer _ISpartan_BR_Condition_OperatorApiConsumer;
        private ISpartaneQueryApiConsumer _ISpartaneQueryApiConsumer;
        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Conditions_DetailApiConsumer _ISpartan_BR_Conditions_DetailApiConsumer;
        private ISpartan_BR_Operation_DetailApiConsumer _ISpartan_BR_Operation_DetailApiConsumer;
        private ISpartan_BR_Scope_DetailApiConsumer _ISpartan_BR_Scope_DetailApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartan_BR_Action_ClassificationApiConsumer _ISpartan_BR_Action_ClassificationApiConsumer;
        private ISpartan_BR_Action_ResultApiConsumer _ISpartan_BR_Action_ResultApiConsumer;
        private ISpartan_BR_ActionApiConsumer _ISpartan_BR_ActionApiConsumer;
        private ISpartan_BR_Actions_True_DetailApiConsumer _ISpartan_BR_Actions_True_DetailApiConsumer;
        private ISpartan_BR_Actions_False_DetailApiConsumer _ISpartan_BR_Actions_False_DetailApiConsumer;
        private ISpartan_BR_Action_Configuration_DetailApiConsumer _ISpartan_BR_Action_Configuration_DetailApiConsumer;
        private ISpartan_BR_Action_Param_TypeApiConsumer _ISpartan_BR_Action_Param_TypeApiConsumer;
        private ISpartan_MetadataApiConsumer _ISpartan_MetadataApiConsumer;
        private ISpartaneObjectApiConsumer _ISpartan_ObjectApiConsumer;

        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;
        #endregion "variable declaration"

        #region "Constructor Declaration"
        public BussinessRuleController(ITokenManager tokenManager, 
            IAuthenticationApiConsumer authenticationApiConsumer,
            ISpartan_UserApiConsumer UserApiConsumer,
            ISpartan_BR_ScopeApiConsumer Spartan_BR_ScopeApiConsumer,
            ISpartan_BR_OperationApiConsumer Spartan_BR_OperationApiConsumer,
            ISpartan_BR_Process_EventApiConsumer Spartan_BR_Process_EventApiConsumer,
            ISpartan_BR_Operator_TypeApiConsumer Spartan_BR_Operator_TypeApiConsumer,
            ISpartan_BR_ConditionApiConsumer Spartan_BR_ConditionApiConsumer,
            ISpartan_BR_Condition_OperatorApiConsumer Spartan_BR_Condition_OperatorApiConsumer,
            ISpartaneQueryApiConsumer SpartaneQueryApiConsumer,
            ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer,
            ISpartan_BR_Conditions_DetailApiConsumer Spartan_BR_Conditions_DetailApiConsumer,
            ISpartan_BR_Operation_DetailApiConsumer Spartan_BR_Operation_DetailApiConsumer,
            ISpartan_BR_Scope_DetailApiConsumer Spartan_BR_Scope_DetailApiConsumer,
            ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer,
            ISpartan_BR_Action_ClassificationApiConsumer Spartan_BR_Action_ClassificationApiConsumer,
            ISpartan_BR_Action_ResultApiConsumer Spartan_BR_Action_ResultApiConsumer,
            ISpartan_BR_ActionApiConsumer Spartan_BR_ActionApiConsumer,
            ISpartan_BR_Actions_True_DetailApiConsumer Spartan_BR_Actions_True_DetailApiConsumer,
            ISpartan_BR_Actions_False_DetailApiConsumer Spartan_BR_Actions_False_DetailApiConsumer,
            ISpartan_BR_Action_Configuration_DetailApiConsumer Spartan_BR_Action_Configuration_DetailApiConsumer,
            ISpartan_BR_Action_Param_TypeApiConsumer Spartan_BR_Action_Param_TypeApiConsumer,
            ISpartan_MetadataApiConsumer Spartan_MetadataApiConsumer,
            ISpartaneObjectApiConsumer Spartan_ObjectApiConsumer)
        {
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;

            this._ISpartan_BR_ScopeApiConsumer = Spartan_BR_ScopeApiConsumer;
            this._ISpartan_BR_OperationApiConsumer = Spartan_BR_OperationApiConsumer;
            this._ISpartan_BR_Process_EventApiConsumer = Spartan_BR_Process_EventApiConsumer;
            this._ISpartan_BR_Operator_TypeApiConsumer = Spartan_BR_Operator_TypeApiConsumer;
            this._ISpartan_BR_ConditionApiConsumer = Spartan_BR_ConditionApiConsumer;
            this._ISpartan_BR_Condition_OperatorApiConsumer = Spartan_BR_Condition_OperatorApiConsumer;
            this._ISpartaneQueryApiConsumer = SpartaneQueryApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Conditions_DetailApiConsumer = Spartan_BR_Conditions_DetailApiConsumer;
            this._ISpartan_BR_Operation_DetailApiConsumer = Spartan_BR_Operation_DetailApiConsumer;
            this._ISpartan_BR_Scope_DetailApiConsumer = Spartan_BR_Scope_DetailApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_BR_Action_ClassificationApiConsumer = Spartan_BR_Action_ClassificationApiConsumer;
            this._ISpartan_BR_Action_ResultApiConsumer = Spartan_BR_Action_ResultApiConsumer;
            this._ISpartan_BR_ActionApiConsumer = Spartan_BR_ActionApiConsumer;
            this._ISpartan_BR_Actions_True_DetailApiConsumer = Spartan_BR_Actions_True_DetailApiConsumer;
            this._ISpartan_BR_Actions_False_DetailApiConsumer = Spartan_BR_Actions_False_DetailApiConsumer;
            this._ISpartan_BR_Action_Configuration_DetailApiConsumer = Spartan_BR_Action_Configuration_DetailApiConsumer;
            this._ISpartan_BR_Action_Param_TypeApiConsumer = Spartan_BR_Action_Param_TypeApiConsumer;
            this._ISpartan_MetadataApiConsumer = Spartan_MetadataApiConsumer;
            this._ISpartan_ObjectApiConsumer = Spartan_ObjectApiConsumer;
        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        [HttpGet, ValidateInput(false)]
        public ActionResult AddBusinessRule(string FieldId, string FieldName, string ObjectId, string Attribute, string Screen, int BusinessRuleId = 0)
        {
            BusinessRuleModel oBusinessRuleModel = new BusinessRuleModel();
            oBusinessRuleModel.FieldId = FieldId;
            oBusinessRuleModel.FieldName = FieldName;
            oBusinessRuleModel.ObjectId = ObjectId;
            oBusinessRuleModel.Attribute = Attribute;
			oBusinessRuleModel.Screen = Screen;
            if (BusinessRuleId > 0)
            {
                oBusinessRuleModel.BusinessRuleId = BusinessRuleId;
            }
            return PartialView("AddBusinessRule", oBusinessRuleModel);
        }

        [HttpGet, ValidateInput(false)]
        public ActionResult RemoveBusinessRule(int BusinessRuleId, string FieldId, string FieldName, string Attribute, string ObjectId)
        {
            //BORRO
            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);
            //RegenerateJS(BusinessRuleId, false, Convert.ToInt32(ObjectId));
            _ISpartan_Business_RuleApiConsumer.Delete(BusinessRuleId, null, null);
            BusinessRuleModel model = new BusinessRuleModel
            {
                FieldId = FieldId,
                FieldName = FieldName,
                ObjectId = ObjectId,
                Attribute = Attribute,
                BusinessRules = GetBusinessRules(Convert.ToInt32(ObjectId), Convert.ToInt32(Attribute))
            };
            return PartialView("BusinessRule", model);
        }

        [HttpGet, ValidateInput(false)]
        public ActionResult BusinessRule(string FieldId, string FieldName, string Attribute, string ObjectId, string Screen)
        {
            BusinessRuleModel model = new BusinessRuleModel
            {
                FieldId = FieldId,
                FieldName = FieldName,
                ObjectId = ObjectId,
                Attribute = Attribute,
                Screen = Screen,
                BusinessRules = GetBusinessRules(Convert.ToInt32(ObjectId), Convert.ToInt32(Attribute))
            };
            return PartialView("BusinessRule", model);
        }

        public List<Spartan_Business_Rule> GetBusinessRules(int ObjectId, int Attribute)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            List<Spartan_Business_Rule> result = new List<Spartan_Business_Rule>();
            _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);
            //if (Attribute != 0)
            //{
                result = _ISpartan_Business_RuleApiConsumer.ListaSelAll(0, 1000, "Object = " + ObjectId + " AND Attribute = " + Attribute, "").Resource.Spartan_Business_Rules;
            //}
            /*else
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
            }*/
            return result;
        }

        public ActionResult GetBusinessRuleData(int BussinessRuleId)
        {
            PrincipalModel result = new PrincipalModel();
            if (BussinessRuleId != 0)
            {
                Spartan_Business_Rule resultBusinessRule = GetBusinessRuleById(BussinessRuleId);
                result.Name = resultBusinessRule.Description;
                result.ObjectId = resultBusinessRule.Object.Value;
                result.BussinessRuleId = BussinessRuleId;
                result.Scopes = GetScropeArrayByBussinesRuleId(BussinessRuleId);
                result.Operations = GetOperationArrayByBussinesRuleId(BussinessRuleId);
                result.Events = GetEventArrayByBussinesRuleId(BussinessRuleId);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private string[] GetEventArrayByBussinesRuleId(int BussinessRuleId)
        {
            string[] result = null;
            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
            var events = _ISpartan_BR_Process_Event_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + BussinessRuleId, "").Resource;
            if (events.RowCount > 0)
            {
                result = new string[8];
                int i = 0;
                foreach (var item in events.Spartan_BR_Process_Event_Details)
                {
                    result[i] = item.Process_Event_Spartan_BR_Process_Event.ProcessEventId.ToString();
                    i++;
                }
            }
            return result;
        }

        private string[] GetOperationArrayByBussinesRuleId(int BussinessRuleId)
        {
            string[] result = null;
            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Operation_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
            var operations = _ISpartan_BR_Operation_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + BussinessRuleId, "").Resource;
            if (operations.RowCount > 0)
            {
                result = new string[6];
                int i = 0;
                foreach (var item in operations.Spartan_BR_Operation_Details)
                {
                    result[i] = item.Operation_Spartan_BR_Operation.OperationId.ToString();
                    i++;
                }
            }
            return result;
        }

        private string[] GetScropeArrayByBussinesRuleId(int BussinessRuleId)
        {
            string[] result = null;
            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Scope_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
            var scopes = _ISpartan_BR_Scope_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + BussinessRuleId, "").Resource;
            if (scopes.RowCount > 0)
            {
                result = new string[4];
                int i = 0;
                foreach (var item in scopes.Spartan_BR_Scope_Details)
                {
                    result[i] = item.Scope_Spartan_BR_Scope.ScopeId.ToString();
                    i++;
                }
            }
            return result;
        }

        public ActionResult GetConditionsData(int BussinessRuleId)
        {
            List<Spartan_BR_Conditions_Detail> resultDatabase = GetConditionsByBusinessRuleId(BussinessRuleId);
            List<ConditionsModel> result = new List<ConditionsModel>();
            foreach (var item in resultDatabase)
            {
                result.Add(new ConditionsModel
                {
                     ConditionDetailId = item.ConditionsDetailId,
                     Operator = (Int32)item.Condition_Operator,
                     OperatorType1 = (Int32)item.First_Operator_Type,
                     OperatorValue1 = item.First_Operator_Value,
                     Condition = (Int32)item.Condition,
                     OperatorType2 = (Int32)item.Second_Operator_Type,
                     OperatorValue2 = item.Second_Operator_Value
                });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetActionData(int BussinessRuleId)
        {
            List<Spartan_BR_Actions_True_Detail> resultDatabase = GetActionsTrueByBusinessRuleId(BussinessRuleId);
            List<ActionsModel> result = new List<ActionsModel>();
            foreach (var item in resultDatabase)
            {
                result.Add(new ActionsModel
                {
                    ActionTrueDetailId = item.ActionsTrueDetailId,
                    ActionClassification = (Int32)item.Action_Classification,
                    Action = (Int32)item.Action,
                    ActionResult = (Int32)item.Action_Result,
                    Parameter1 = (item.Parameter_1 == "null") ? "" : item.Parameter_1,
                    Parameter2 = (item.Parameter_2 == "null") ? "" : item.Parameter_2,
                    Parameter3 = (item.Parameter_3 == "null") ? "" : item.Parameter_3,
                    Parameter4 = (item.Parameter_4 == "null") ? "" : item.Parameter_4,
                    Parameter5 = (item.Parameter_5 == "null") ? "" : item.Parameter_5
                });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetActionNotData(int BussinessRuleId)
        {
            List<Spartan_BR_Actions_False_Detail> resultDatabase = GetActionsFalseByBusinessRuleId(BussinessRuleId);
            List<ActionsNotModel> result = new List<ActionsNotModel>();
            foreach (var item in resultDatabase)
            {
                result.Add(new ActionsNotModel
                {
                    ActionFalseDetailId = item.ActionsFalseDetailId,
                    ActionClassification = (Int32)item.Action_Classification,
                    Action = (Int32)item.Action,
                    ActionResult = (Int32)item.Action_Result,
                    Parameter1 = (item.Parameter_1 == "null") ? "" : item.Parameter_1,
                    Parameter2 = (item.Parameter_2 == "null") ? "" : item.Parameter_2,
                    Parameter3 = (item.Parameter_3 == "null") ? "" : item.Parameter_3,
                    Parameter4 = (item.Parameter_4 == "null") ? "" : item.Parameter_4,
                    Parameter5 = (item.Parameter_5 == "null") ? "" : item.Parameter_5
                });
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public Spartan_Business_Rule GetBusinessRuleById(int BussinessRuleId)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _ISpartan_Business_RuleApiConsumer.GetByKey(BussinessRuleId, true).Resource;
            return result;
        }

        public List<Spartan_BR_Conditions_Detail> GetConditionsByBusinessRuleId(int BussinessRuleId)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Conditions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _ISpartan_BR_Conditions_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + BussinessRuleId, "").Resource;
            return result.Spartan_BR_Conditions_Details;
        }

        public List<Spartan_BR_Actions_True_Detail> GetActionsTrueByBusinessRuleId(int BussinessRuleId)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Actions_True_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _ISpartan_BR_Actions_True_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + BussinessRuleId, "").Resource;
            return result.Spartan_BR_Actions_True_Details;
        }

        public List<Spartan_BR_Actions_False_Detail> GetActionsFalseByBusinessRuleId(int BussinessRuleId)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartan_BR_Actions_False_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _ISpartan_BR_Actions_False_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + BussinessRuleId, "").Resource;
            return result.Spartan_BR_Actions_False_Details;
        }

        /// <summary>
        /// Get List of Spartan_BR_Scope from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_BR_Scope Entity</returns>
        public ActionResult GetScopeList()
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_BR_ScopeApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _ISpartan_BR_ScopeApiConsumer.ListaSelAll(0, 1000, "", "").Resource;
            if (result.Spartan_BR_Scopes == null)
                result.Spartan_BR_Scopes = new List<Spartan_BR_Scope>();

            return Json(new
            {
                aaData = result.Spartan_BR_Scopes.Select(m => new Spartan_BR_ScopeGridModel
                {
                    ScopeId = m.ScopeId
                ,
                    Description = m.Description

                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_BR_Scope from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_BR_Scope Entity</returns>
        public ActionResult GetOperationList()
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_BR_OperationApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _ISpartan_BR_OperationApiConsumer.ListaSelAll(0, 1000, "", "").Resource;
            if (result.Spartan_BR_Operations == null)
                result.Spartan_BR_Operations = new List<Spartan_BR_Operation>();

            return Json(new
            {
                aaData = result.Spartan_BR_Operations.Select(m => new Spartan_BR_OperationGridModel
                {
                    OperationId = m.OperationId
                ,
                    Description = m.Description

                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Spartan_BR_Process_Event from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Spartan_BR_Process_Event Entity</returns>
        public ActionResult GetEventProcessList(int Attribute)//CAMBIOS MANUALES(tambien agregue en la tabla de la db el campo Attribute)
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_BR_Process_EventApiConsumer.SetAuthHeader(_tokenManager.Token);
            string where = "Attribute = " + Attribute;
            if(Attribute > 10)
            {
                where = "";
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
                    Description = m.Description

                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }

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
                    Description = m.Description

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
                    Description = m.Description

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
                    Description = m.Description

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
                    Description = m.Description

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
                    Description = m.Description

                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetActionListByClassification(int classificationId)
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_BR_ActionApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _ISpartan_BR_ActionApiConsumer.ListaSelAll(0, 1000, "Classification = " + classificationId, "").Resource;
            if (result.Spartan_BR_Actions == null)
                result.Spartan_BR_Actions = new List<Spartan_BR_Action>();

            return Json(new
            {
                aaData = result.Spartan_BR_Actions.Select(m => new Spartan_BR_ActionGridModel
                {
                    ActionId = m.ActionId
                ,
                    Description = m.Description

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

        #region Save & Post

        [HttpPost]
        public ActionResult Post(PrincipalModel model)
        {
            try
            {
                bool isNew = false;
                var result = 0;
                if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);
                _ISpartaneQueryApiConsumer.SetAuthHeader(_tokenManager.Token);
                Spartan_Business_Rule entity = new Spartan_Business_Rule();
                entity.BusinessRuleId = model.BussinessRuleId;
                entity.Registration_Date = DateTime.Now;
                entity.Registration_Hour = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
                entity.Object = model.ObjectId;
                entity.Implementation_Code = "";
                entity.User_who_registers = 0;
                entity.Description = model.Name ?? "";
                entity.Attribute = model.Attribute;
                entity.StatusId = 1;
                //entity.AttributeGrid = false;
                isNew = model.BussinessRuleId == 0;
                if (!isNew)
                {
                    //RegenerateJS(model.BussinessRuleId, 4, model.ObjectId);
                }
                result = model.BussinessRuleId != 0 ?
                        _ISpartan_Business_RuleApiConsumer.Update(entity, null, null).Resource :
                         _ISpartan_Business_RuleApiConsumer.Insert(entity, null, null).Resource;
                if (model.BussinessRuleId == 0)
                    model.BussinessRuleId = result;

                SaveScopes(model.BussinessRuleId, model.Scopes, _tokenManager.Token);
                SaveOperations(model.BussinessRuleId, model.Operations, _tokenManager.Token);
                SaveEvents(model.BussinessRuleId, model.Events, _tokenManager.Token);
                return Json(model.BussinessRuleId, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        private void SaveScopes(int BussinessRuleId, string[] Scopes, string token)
        {
            _ISpartan_BR_Scope_DetailApiConsumer.SetAuthHeader(token);
            Spartan_BR_Scope_Detail scopeToSave = null;
            string[] ScopesArray = Scopes[0].Split(',');
            if (BussinessRuleId != 0)
            {
                Spartan_BR_Scope_DetailPagingModel scopesOfRule = _ISpartan_BR_Scope_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + BussinessRuleId, "").Resource;

                if (scopesOfRule.RowCount > 0)
                {
                    foreach (var scopeSaved in scopesOfRule.Spartan_BR_Scope_Details)
                    {
                        _ISpartan_BR_Scope_DetailApiConsumer.Delete(scopeSaved.ScopeDetailId, null, null);
                    }
                }
            }
            for (int i = 0; i < ScopesArray.Length; i++)
            {
                if (ScopesArray[i] != "")
                {
                    scopeToSave = new Spartan_BR_Scope_Detail();
                    scopeToSave.Business_Rule = BussinessRuleId;
                    scopeToSave.Scope = Convert.ToInt16(ScopesArray[i]);
                    _ISpartan_BR_Scope_DetailApiConsumer.Insert(scopeToSave, null, null);
                }
            }
        }

        private void SaveOperations(int BussinessRuleId, string[] Operations, string token)
        {
            _ISpartan_BR_Operation_DetailApiConsumer.SetAuthHeader(token);
            Spartan_BR_Operation_Detail operationToSave = null;
            string[] OperationsArray = Operations[0].Split(',');
            if (BussinessRuleId != 0)
            {
                Spartan_BR_Operation_DetailPagingModel operationsOfRule = _ISpartan_BR_Operation_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + BussinessRuleId, "").Resource;
                if (operationsOfRule.RowCount > 0)
                {
                    foreach (var operationSaved in operationsOfRule.Spartan_BR_Operation_Details)
                    {
                        _ISpartan_BR_Operation_DetailApiConsumer.Delete(operationSaved.OperationDetailId, null, null);
                    }
                }
            }
            for (int i = 0; i < OperationsArray.Length; i++)
            {
                if (OperationsArray[i] != "")
                {
                    operationToSave = new Spartan_BR_Operation_Detail();
                    operationToSave.Business_Rule = BussinessRuleId;
                    operationToSave.Operation = Convert.ToInt16(OperationsArray[i]);
                    _ISpartan_BR_Operation_DetailApiConsumer.Insert(operationToSave, null, null);
                }
            }
        }

        private void SaveEvents(int BussinessRuleId, string[] Events, string token)
        {
            _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(token);
            Spartan_BR_Process_Event_Detail eventToSave = null;
            string[] EventsArray = Events[0].Split(',');
            if (BussinessRuleId != 0)
            {
                Spartan_BR_Process_Event_DetailPagingModel eventsOfRule = _ISpartan_BR_Process_Event_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + BussinessRuleId, "").Resource;
                if (eventsOfRule.RowCount > 0)
                {
                    foreach (var eventSaved in eventsOfRule.Spartan_BR_Process_Event_Details)
                    {
                        _ISpartan_BR_Process_Event_DetailApiConsumer.Delete(eventSaved.ProcessEventDetailId, null, null);
                    }
                }
            }
            for (int i = 0; i < EventsArray.Length; i++)
            {
                if (EventsArray[i] != "")
                {
                    eventToSave = new Spartan_BR_Process_Event_Detail();
                    eventToSave.Business_Rule = BussinessRuleId;
                    eventToSave.Process_Event = Convert.ToInt16(EventsArray[i]);
                    _ISpartan_BR_Process_Event_DetailApiConsumer.Insert(eventToSave, null, null);
                }
            }
        }

        [HttpPost]
        public ActionResult PostConditions(List<ConditionsModel> ConditionItems, int BussinessRuleId)
        {
            try
            {
                bool result = false;
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Conditions_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                foreach (var ConditionItem in ConditionItems)
                {
                    if (ConditionItem.Removed)
                    {
                        result =  _ISpartan_BR_Conditions_DetailApiConsumer.Delete(ConditionItem.ConditionDetailId, null, null).Resource;
                        continue;
                    }

                    var ConditionData = new Spartan_BR_Conditions_Detail
                    {
                          Business_Rule = BussinessRuleId, 
                          ConditionsDetailId = ConditionItem.ConditionDetailId,
                          Condition = (Int16)ConditionItem.Condition,
                          First_Operator_Type = ConditionItem.OperatorType1,
                          Second_Operator_Type = ConditionItem.OperatorType2,
                          First_Operator_Value = ConditionItem.OperatorValue1,
                          Second_Operator_Value = ConditionItem.OperatorValue2,
                          Condition_Operator = (Int16)ConditionItem.Operator

                    };

                    var resultId = ConditionItem.ConditionDetailId > 0
                       ? _ISpartan_BR_Conditions_DetailApiConsumer.Update(ConditionData, null, null).Resource
                       : _ISpartan_BR_Conditions_DetailApiConsumer.Insert(ConditionData, null, null).Resource;

                    result = result && resultId != -1;
                }

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult PostActions(List<ActionsModel> ActionsItems, int BussinessRuleId)
        {
            try
            {
                bool result = false;
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Actions_True_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                foreach (var ActionItems in ActionsItems)
                {
                    if (ActionItems.Removed)
                    {
                        result = _ISpartan_BR_Actions_True_DetailApiConsumer.Delete(ActionItems.ActionTrueDetailId, null, null).Resource;
                        continue;
                    }

                    var ActionData = new Spartan_BR_Actions_True_Detail
                    {
                        Business_Rule = BussinessRuleId, 
                        ActionsTrueDetailId = ActionItems.ActionTrueDetailId,
                        Action_Classification = (Int16)ActionItems.ActionClassification,
                        Action_Result = (Int16)ActionItems.ActionResult,
                        Action = ActionItems.Action,
                        Parameter_1 = ActionItems.Parameter1,
                        Parameter_2 = ActionItems.Parameter2,
                        Parameter_3 = ActionItems.Parameter3,
                        Parameter_4 = ActionItems.Parameter4,
                        Parameter_5 = ActionItems.Parameter5
                    };

                    var resultId = ActionItems.ActionTrueDetailId > 0
                       ? _ISpartan_BR_Actions_True_DetailApiConsumer.Update(ActionData, null, null).Resource
                       : _ISpartan_BR_Actions_True_DetailApiConsumer.Insert(ActionData, null, null).Resource;

                    result = result && resultId != -1;
                }

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult PostActionsNot(List<ActionsNotModel> ActionsNotItems, int BussinessRuleId)
        {
            try
            {
                bool result = false;
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_BR_Actions_False_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                foreach (var ActionNotItems in ActionsNotItems)
                {
                    //Removal Request
                    if (ActionNotItems.Removed)
                    {
                        result = _ISpartan_BR_Actions_False_DetailApiConsumer.Delete(ActionNotItems.ActionFalseDetailId, null, null).Resource;
                        continue;
                    }

                    var ActionNotData = new Spartan_BR_Actions_False_Detail
                    {
                        Business_Rule = BussinessRuleId, 
                        ActionsFalseDetailId = ActionNotItems.ActionFalseDetailId,
                        Action_Classification = (Int16)ActionNotItems.ActionClassification,
                        Action_Result = (Int16)ActionNotItems.ActionResult,
                        Action = ActionNotItems.Action,
                        Parameter_1 = ActionNotItems.Parameter1,
                        Parameter_2 = ActionNotItems.Parameter2,
                        Parameter_3 = ActionNotItems.Parameter3,
                        Parameter_4 = ActionNotItems.Parameter4,
                        Parameter_5 = ActionNotItems.Parameter5
                    };

                    var resultId = ActionNotItems.ActionFalseDetailId > 0
                       ? _ISpartan_BR_Actions_False_DetailApiConsumer.Update(ActionNotData, null, null).Resource
                       : _ISpartan_BR_Actions_False_DetailApiConsumer.Insert(ActionNotData, null, null).Resource;

                    result = result && resultId != -1;
                }

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion "Save & Post"

        [HttpGet]
        public ActionResult ChangeActiveBusinessRule(int BussinessRuleId, bool Change)
        {
            try
            {
                var result = 0;
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);

                var rule = _ISpartan_Business_RuleApiConsumer.GetByKey(BussinessRuleId, false).Resource;
                rule.StatusId = (Change) ? 2 : 1;
                result = _ISpartan_Business_RuleApiConsumer.Update(rule, null, null).Resource;

                //RegenerateJS(BussinessRuleId, Change, Convert.ToInt32(rule.Object));
                    
                //FileWritter.Write(rule.Attribute, rule.Oper)
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        ///*public string RegenerateJS(int BussinessRuleId, bool Change, int ObjectId)
        //{
        //    try
        //    {
        //        if (_tokenManager.GenerateToken())
        //        {
        //            _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);
        //            _ISpartan_BR_Scope_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
        //            _ISpartan_BR_Operation_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
        //            _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
        //            _ISpartaneQueryApiConsumer.SetAuthHeader(_tokenManager.Token);
        //            _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
        //            string ObjectMR = "";
        //            string Object = (string)_ISpartaneQueryApiConsumer.ExecuteQuery("SELECT URL FROM [dbo].[Spartan_Object] WHERE Object_Id=" + ObjectId).Resource;
        //            var rule = _ISpartan_Business_RuleApiConsumer.GetByKey(BussinessRuleId, false).Resource;
        //            /*GET Scopes, Operation, Events*/
        //            var scopes = _ISpartan_BR_Scope_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + BussinessRuleId, "").Resource;
        //            var operations = _ISpartan_BR_Operation_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + BussinessRuleId, "").Resource;
        //            var events = _ISpartan_BR_Process_Event_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + BussinessRuleId, "").Resource;
        //            /*GET Scopes, Operation, Events*/
        //            string section = "";
        //            StringBuilder implementation = new StringBuilder(rule.Implementation_Code);
        //            implementation = implementation.Replace("@LC@", "\"\n");
        //            implementation = implementation.Replace("@LB@", "+\"");
        //            if (!Change)
        //            {
        //                implementation = new StringBuilder();
        //            }
        //            foreach (var scope in scopes.Spartan_BR_Scope_Details)
        //            {
        //                if (scope.Scope_Spartan_BR_Scope.Description == "Field")
        //                {
        //                    FileWritter.Path = Request.PhysicalApplicationPath + "Uploads\\Scripts\\Rules\\" + Object + "CreateRules.js";
        //                    section = "//NEWBUSINESSRULE_NONE//";
        //                    FileWritter.Write(rule.BusinessRuleId.ToString(),
        //                        rule.Attribute.Value.ToString(),
        //                        scope.Scope_Spartan_BR_Scope.Description,
        //                        "None",
        //                        section,
        //                        implementation,
        //                        !Change,
        //                        "Field");
        //                }
        //                else
        //                {
        //                    if (operations.RowCount > 0)
        //                    {
        //                        foreach (var operation in operations.Spartan_BR_Operation_Details)
        //                        {
        //                            if (operation.Operation_Spartan_BR_Operation.Description == "List")
        //                            {
        //                                FileWritter.Path = Request.PhysicalApplicationPath + "Uploads\\Scripts\\Rules\\" + Object + "IndexRules.js";
        //                                foreach (var ev in events.Spartan_BR_Process_Event_Details)
        //                                {
        //                                    section = "//NEWBUSINESSRULE_" + ev.Process_Event_Spartan_BR_Process_Event.Description.Replace(" ", "").ToUpper() + "//";
        //                                    FileWritter.Write(rule.BusinessRuleId.ToString(),
        //                                        rule.Attribute.Value.ToString(),
        //                                        scope.Scope_Spartan_BR_Scope.Description,
        //                                        "None",
        //                                        section,
        //                                        implementation,
        //                                        !Change,
        //                                        operation.Operation_Spartan_BR_Operation.Description);
        //                                }

        //                            }
        //                            else
        //                            {
        //                                FileWritter.Path = Request.PhysicalApplicationPath + "Uploads\\Scripts\\Rules\\" + Object + "CreateRules.js";

        //                                foreach (var ev in events.Spartan_BR_Process_Event_Details)
        //                                {
        //                                    if (ev.Process_Event_Spartan_BR_Process_Event.Description == "Screen Opening")
        //                                        section = "//NEWBUSINESSRULE_SCREENOPENING//";
        //                                    else
        //                                    {
        //                                        if (rule.Attribute.HasValue && rule.Attribute > 10)
        //                                        {
        //                                            Spartan_Metadata att = _ISpartan_MetadataApiConsumer.GetByKey(rule.Attribute.Value, false).Resource;
        //                                            if (att.Relation_Type.HasValue && att.Relation_Type.Value == 2)
        //                                            {
        //                                                ObjectMR = (string)_ISpartaneQueryApiConsumer.ExecuteQuery("SELECT URL FROM [dbo].[Spartan_Object] WHERE Object_Id=" + att.Related_Object_Id).Resource;
        //                                                section = "//NEWBUSINESSRULE_" + ev.Process_Event_Spartan_BR_Process_Event.Description.Replace(" ", "").ToUpper() + "_" + ObjectMR + "//";
        //                                            }
        //                                        }
        //                                        else
        //                                        {
        //                                            section = "//NEWBUSINESSRULE_" + ev.Process_Event_Spartan_BR_Process_Event.Description.Replace(" ", "").ToUpper() + "//";
        //                                        }
        //                                    }

        //                                    FileWritter.Write(rule.BusinessRuleId.ToString(),
        //                                        rule.Attribute.Value.ToString(),
        //                                        scope.Scope_Spartan_BR_Scope.Description,
        //                                        ev.Process_Event_Spartan_BR_Process_Event.Description.Replace(" ", "").ToUpper().ToString(),
        //                                        section,
        //                                        implementation,
        //                                        !Change,
        //                                        operation.Operation_Spartan_BR_Operation.Description);
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        return "";
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }
        //}
		

        /*[HttpGet]
        public ActionResult RegenerateRules(int id)
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);
            List<Spartan_Business_Rule> rules = _ISpartan_Business_RuleApiConsumer.ListaSelAll(0, 1000, "Object = " + id, "").Resource.Spartan_Business_Rules;
            int result;
            foreach (var rule in rules)
            {
                result = _ISpartan_Business_RuleApiConsumer.Update(rule, null, null).Resource;
                
            }
            foreach (var rule in rules)
            {
                RegenerateJS(rule.BusinessRuleId, false, id);
            }
            foreach (var rule in rules)
            {
                if (rule.StatusId.HasValue && rule.StatusId.Value == 2)
                    RegenerateJS(rule.BusinessRuleId, true, id);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }*/

        //[HttpGet]
        //public ActionResult RegenerateRules()
        //{
        //    string result = "";
        //    if (!_tokenManager.GenerateToken())
        //        return Json(null, JsonRequestBehavior.AllowGet);
        //    _ISpartan_ObjectApiConsumer.SetAuthHeader(_tokenManager.Token);
        //    List<SpartaneObject> objects = _ISpartan_ObjectApiConsumer.SelAll(false).Resource.ToList();
        //    foreach (var obj in objects)
        //    {
        //        result += RegenerateCatalogo(obj.Object_Id);
        //    }
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        //private string RegenerateCatalogo(int objectId)
        //{
        //    try
        //    {
        //        if (!_tokenManager.GenerateToken())
        //            return "Not permission";
        //        //return Json(null, JsonRequestBehavior.AllowGet);
        //        _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);
        //        List<Spartan_Business_Rule> rules = _ISpartan_Business_RuleApiConsumer.ListaSelAll(0, 1000, "Object = " + objectId, "").Resource.Spartan_Business_Rules;
        //        int result;
        //        foreach (var rule in rules)
        //        {
        //            result = _ISpartan_Business_RuleApiConsumer.Update(rule, null, null).Resource;

        //        }
        //        foreach (var rule in rules)
        //        {
        //            RegenerateJS(rule.BusinessRuleId, false, objectId);
        //        }
        //        foreach (var rule in rules)
        //        {
        //            if (rule.StatusId.HasValue && rule.StatusId.Value == 2)
        //                RegenerateJS(rule.BusinessRuleId, true, objectId);
        //        }
        //        return "Success:" + objectId;
        //    }
        //    catch (Exception ex)
        //    {
        //        return "No se regenero el objeto" + objectId + " - Error:" + ex.ToString();
        //    }
        //}

        #endregion "Controller Methods"

        #region "Custom methods"

        #endregion "Custom methods"
    }

    public class NameValue
    {
        public string name { get; set; }
        public string value { get; set; }
    }
}

