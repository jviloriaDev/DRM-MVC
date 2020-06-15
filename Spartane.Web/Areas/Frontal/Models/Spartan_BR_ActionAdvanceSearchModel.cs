using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_BR_ActionAdvanceSearchModel
    {
        public Spartan_BR_ActionAdvanceSearchModel()
        {

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromActionId { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromActionId", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToActionId { set; get; }

        public Filters DescriptionFilter { set; get; }
        public string Description { set; get; }

        public Filters ClassificationFilter { set; get; }
        public string AdvanceClassification { set; get; }
        public int[] AdvanceClassificationMultiple { set; get; }

        public Filters Implementation_CodeFilter { set; get; }
        public string Implementation_Code { set; get; }


    }
}
