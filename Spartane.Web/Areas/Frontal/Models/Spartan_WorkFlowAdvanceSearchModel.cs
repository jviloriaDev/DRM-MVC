using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_WorkFlowAdvanceSearchModel
    {
        public Spartan_WorkFlowAdvanceSearchModel()
        {

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromWorkFlowId { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromWorkFlowId", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToWorkFlowId { set; get; }

        public Filters NameFilter { set; get; }
        public string Name { set; get; }

        public Filters DescriptionFilter { set; get; }
        public string Description { set; get; }

        public Filters ObjectiveFilter { set; get; }
        public string Objective { set; get; }

        public Filters StatusFilter { set; get; }
        public string AdvanceStatus { set; get; }
        public int[] AdvanceStatusMultiple { set; get; }

        public Filters ObjectFilter { set; get; }
        public string AdvanceObject { set; get; }
        public int[] AdvanceObjectMultiple { set; get; }


    }
}
