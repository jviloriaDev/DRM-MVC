using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_BR_Operator_TypeAdvanceSearchModel
    {
        public Spartan_BR_Operator_TypeAdvanceSearchModel()
        {

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromOperatorTypeId { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromOperatorTypeId", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToOperatorTypeId { set; get; }

        public Filters DescriptionFilter { set; get; }
        public string Description { set; get; }

        public Filters Presentation_Control_TypeFilter { set; get; }
        public string AdvancePresentation_Control_Type { set; get; }
        public int[] AdvancePresentation_Control_TypeMultiple { set; get; }

        public Filters Query_for_Fill_ConditionFilter { set; get; }
        public string Query_for_Fill_Condition { set; get; }

        public Filters Code_for_Fill_ConditionFilter { set; get; }
        public string Code_for_Fill_Condition { set; get; }

        public Filters Implementation_CodeFilter { set; get; }
        public string Implementation_Code { set; get; }


    }
}
