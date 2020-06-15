using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_ReportAdvanceSearchModel
    {
        public Spartan_ReportAdvanceSearchModel()
        {

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromReportId { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromReportId", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToReportId { set; get; }

        public Filters Report_NameFilter { set; get; }
        public string Report_Name { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromRegistration_Date { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromRegistration_Date", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToRegistration_Date { set; get; }

        public string ToRegistration_Hour { set; get; }
        public string FromRegistration_Hour { set; get; }

        public Filters Registration_UserFilter { set; get; }
        public string AdvanceRegistration_User { set; get; }
        public int[] AdvanceRegistration_UserMultiple { set; get; }

        public Filters ObjectFilter { set; get; }
        public string AdvanceObject { set; get; }
        public int[] AdvanceObjectMultiple { set; get; }

        public Filters Presentation_TypeFilter { set; get; }
        public string AdvancePresentation_Type { set; get; }
        public int[] AdvancePresentation_TypeMultiple { set; get; }

        public Filters Presentation_ViewFilter { set; get; }
        public string AdvancePresentation_View { set; get; }
        public int[] AdvancePresentation_ViewMultiple { set; get; }

        public Filters StatusFilter { set; get; }
        public string AdvanceStatus { set; get; }
        public int[] AdvanceStatusMultiple { set; get; }

        public Filters QueryFilter { set; get; }
        public string Query { set; get; }

        public Filters HeaderFilter { set; get; }
        public string Header { set; get; }

        public Filters FooterFilter { set; get; }
        public string Footer { set; get; }


    }
}
