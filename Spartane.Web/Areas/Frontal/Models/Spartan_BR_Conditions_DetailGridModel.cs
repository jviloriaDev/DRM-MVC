using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_BR_Conditions_DetailGridModel
    {
        public int ConditionsDetailId { get; set; }
        public short? Condition_Operator { get; set; }
        public string Condition_OperatorDescription { get; set; }
        public int? First_Operator_Type { get; set; }
        public string First_Operator_TypeDescription { get; set; }
        public string First_Operator_Value { get; set; }
        public short? Condition { get; set; }
        public string ConditionDescription { get; set; }
        public int? Second_Operator_Type { get; set; }
        public string Second_Operator_TypeDescription { get; set; }
        public string Second_Operator_Value { get; set; }
        
    }
}

