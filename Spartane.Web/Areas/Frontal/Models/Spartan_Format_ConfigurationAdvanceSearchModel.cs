using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Format_ConfigurationAdvanceSearchModel
    {
        public Spartan_Format_ConfigurationAdvanceSearchModel()
        {

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromFormat { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromFormat", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToFormat { set; get; }

        public Filters Query_To_Fill_FieldsFilter { set; get; }
        public string Query_To_Fill_Fields { set; get; }

        public Filters Filter_to_ShowFilter { set; get; }
        public string Filter_to_Show { set; get; }


    }
}
