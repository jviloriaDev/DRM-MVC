using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Business_RuleMainModel
    {
        public Spartan_Business_RuleModel Spartan_Business_RuleInfo { set; get; }
        public Spartan_BR_Scope_DetailGridModelPost Spartan_BR_Scope_DetailGridInfo { set; get; }
        public Spartan_BR_Operation_DetailGridModelPost Spartan_BR_Operation_DetailGridInfo { set; get; }
        public Spartan_BR_Process_Event_DetailGridModelPost Spartan_BR_Process_Event_DetailGridInfo { set; get; }
        public Spartan_BR_Conditions_DetailGridModelPost Spartan_BR_Conditions_DetailGridInfo { set; get; }
        public Spartan_BR_Actions_True_DetailGridModelPost Spartan_BR_Actions_True_DetailGridInfo { set; get; }
        public Spartan_BR_Actions_False_DetailGridModelPost Spartan_BR_Actions_False_DetailGridInfo { set; get; }
        public Spartan_BR_Modifications_LogGridModelPost Spartan_BR_Modifications_LogGridInfo { set; get; }

    }

    public class Spartan_BR_Scope_DetailGridModelPost
    {
        public int ScopeDetailId { get; set; }
        public short? Scope { get; set; }

        public bool Removed { set; get; }
    }

    public class Spartan_BR_Operation_DetailGridModelPost
    {
        public int OperationDetailId { get; set; }
        public short? Operation { get; set; }

        public bool Removed { set; get; }
    }

    public class Spartan_BR_Process_Event_DetailGridModelPost
    {
        public int ProcessEventDetailId { get; set; }
        public short? Process_Event { get; set; }

        public bool Removed { set; get; }
    }

    public class Spartan_BR_Conditions_DetailGridModelPost
    {
        public int ConditionsDetailId { get; set; }
        public short? Condition_Operator { get; set; }
        public int? First_Operator_Type { get; set; }
        public string First_Operator_Value { get; set; }
        public short? Condition { get; set; }
        public int? Second_Operator_Type { get; set; }
        public string Second_Operator_Value { get; set; }

        public bool Removed { set; get; }
    }

    public class Spartan_BR_Actions_True_DetailGridModelPost
    {
        public int ActionsTrueDetailId { get; set; }
        public short? Action_Classification { get; set; }
        public int? Action { get; set; }
        public short? Action_Result { get; set; }
        public string Parameter_1 { get; set; }
        public string Parameter_2 { get; set; }
        public string Parameter_3 { get; set; }
        public string Parameter_4 { get; set; }
        public string Parameter_5 { get; set; }

        public bool Removed { set; get; }
    }

    public class Spartan_BR_Actions_False_DetailGridModelPost
    {
        public int ActionsFalseDetailId { get; set; }
        public short? Action_Classification { get; set; }
        public int? Action { get; set; }
        public short? Action_Result { get; set; }
        public string Parameter_1 { get; set; }
        public string Parameter_2 { get; set; }
        public string Parameter_3 { get; set; }
        public string Parameter_4 { get; set; }
        public string Parameter_5 { get; set; }

        public bool Removed { set; get; }
    }

    public class Spartan_BR_Modifications_LogGridModelPost
    {
        public int ModificationId { get; set; }
        public string Modification_Date { get; set; }
        public string Modification_Hour { get; set; }
        public int? Modification_User { get; set; }
        public string Comments { get; set; }
        public string Implementation_Code { get; set; }

        public bool Removed { set; get; }
    }



}

