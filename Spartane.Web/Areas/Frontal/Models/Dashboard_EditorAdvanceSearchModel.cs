using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Dashboard_EditorAdvanceSearchModel
    {
        public Dashboard_EditorAdvanceSearchModel()
        {
            Show_in_Home = RadioOptions.NoApply;

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromDashboard_Id { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromDashboard_Id", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToDashboard_Id { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromRegistration_Date { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromRegistration_Date", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToRegistration_Date { set; get; }

        public Filters Registration_UserFilter { set; get; }
        public string AdvanceRegistration_User { set; get; }
        public int[] AdvanceRegistration_UserMultiple { set; get; }

        public Filters NameFilter { set; get; }
        public string Name { set; get; }

        public Filters Dashboard_TemplateFilter { set; get; }
        public string AdvanceDashboard_Template { set; get; }
        public int[] AdvanceDashboard_TemplateMultiple { set; get; }

        public RadioOptions Show_in_Home { set; get; }

        public Filters StatusFilter { set; get; }
        public string AdvanceStatus { set; get; }
        public int[] AdvanceStatusMultiple { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromSpartan_Object { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromSpartan_Object", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToSpartan_Object { set; get; }


    }
}
