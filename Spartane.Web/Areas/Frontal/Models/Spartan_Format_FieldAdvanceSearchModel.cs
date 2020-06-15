using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Format_FieldAdvanceSearchModel
    {
        public Spartan_Format_FieldAdvanceSearchModel()
        {

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromFormatFieldId { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromFormatFieldId", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFormatFieldId { set; get; }

        public Filters FormatFilter { set; get; }
        public string AdvanceFormat { set; get; }
        public int[] AdvanceFormatMultiple { set; get; }

        public Filters Field_PathFilter { set; get; }
        public string Field_Path { set; get; }

        public Filters Physical_Field_NameFilter { set; get; }
        public string Physical_Field_Name { set; get; }

        public Filters Logical_Field_NameFilter { set; get; }
        public string Logical_Field_Name { set; get; }

        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        public string FromCreation_Date { set; get; }
        [DataType(DataType.Date, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "InvalidDate")]
        [IsDateAfter("FromCreation_Date", true, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToCreation_Date { set; get; }

        public string ToCreation_Hour { set; get; }
        public string FromCreation_Hour { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromCreation_User { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromCreation_User", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToCreation_User { set; get; }

        public Filters PropertiesFilter { set; get; }
        public string Properties { set; get; }


    }
}
