using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Report_Advance_FilterAdvanceSearchModel
    {
        public Spartan_Report_Advance_FilterAdvanceSearchModel()
        {

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromClave { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromClave", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToClave { set; get; }

        public Filters ReportFilter { set; get; }
        public string AdvanceReport { set; get; }
        public int[] AdvanceReportMultiple { set; get; }

        public Filters AttributeIdFilter { set; get; }
        public string AdvanceAttributeId { set; get; }
        public int[] AdvanceAttributeIdMultiple { set; get; }

        public Filters Defect_Value_FromFilter { set; get; }
        public string Defect_Value_From { set; get; }

        public Filters Defect_Value_ToFilter { set; get; }
        public string Defect_Value_To { set; get; }


    }
}
