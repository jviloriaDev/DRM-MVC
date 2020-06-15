using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Spartane.Core.Domain.Spartan_Business_Rule;
namespace Spartane.Web.Areas.Frontal.Models
{
    public class BusinessRuleModel
    {
        public string FieldId { get; set; }
        public string FieldName { get; set; }
        public string ObjectId { get; set; }
        public string Attribute { get; set; }
        public int BusinessRuleId { get; set; }
        public string Screen { get; set; }
        public List<Spartan_Business_Rule> BusinessRules { get; set; }
    }

    public class PrincipalModel
    {
        public int BussinessRuleId { get; set; }
        public string Name { get; set; }
        public string[] Scopes { get; set; }
        public string[] Operations { get; set; }
        public string[] Events { get; set; }
        public int ObjectId { get; set; }
        public int Attribute { get; set; }
    }

    public class ConditionsModel
    {
        public int ConditionDetailId { get; set; }
        public int Operator { get; set; }
        public int OperatorType1 { get; set; }
        public string OperatorValue1 { get; set; }
        public int Condition { get; set; }
        public int OperatorType2 { get; set; }
        public string OperatorValue2 { get; set; }
        public bool Removed { get; set; }
    }

    public class ActionsModel
    {
        public int ActionTrueDetailId { get; set; }
        public int ActionClassification { get; set; }
        public int Action { get; set; }
        public int ActionResult { get; set; }
        public string Parameter1 { get; set; }
        public string Parameter2 { get; set; }
        public string Parameter3 { get; set; }
        public string Parameter4 { get; set; }
        public string Parameter5 { get; set; }
        public bool Removed { get; set; }
    }

    public class ActionsNotModel
    {
        public int ActionFalseDetailId { get; set; }
        public int ActionClassification { get; set; }
        public int Action { get; set; }
        public int ActionResult { get; set; }
        public string Parameter1 { get; set; }
        public string Parameter2 { get; set; }
        public string Parameter3 { get; set; }
        public string Parameter4 { get; set; }
        public string Parameter5 { get; set; }
        public bool Removed { get; set; }
    }
}