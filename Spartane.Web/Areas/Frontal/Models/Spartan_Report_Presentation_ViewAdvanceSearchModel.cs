using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Report_Presentation_ViewAdvanceSearchModel
    {
        public Spartan_Report_Presentation_ViewAdvanceSearchModel()
        {

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromPresentationViewId { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromPresentationViewId", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToPresentationViewId { set; get; }

        public Filters DescriptionFilter { set; get; }
        public string Description { set; get; }

        public Filters Presentation_TypeFilter { set; get; }
        public string AdvancePresentation_Type { set; get; }
        public int[] AdvancePresentation_TypeMultiple { set; get; }


    }
}
