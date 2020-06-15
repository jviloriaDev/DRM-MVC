using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Traduction_ObjectAdvanceSearchModel
    {
        public Spartan_Traduction_ObjectAdvanceSearchModel()
        {

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromIdObject { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromIdObject", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToIdObject { set; get; }

        public Filters Object_DescriptionFilter { set; get; }
        public string Object_Description { set; get; }

        public Filters Object_TypeFilter { set; get; }
        public string AdvanceObject_Type { set; get; }
        public int[] AdvanceObject_TypeMultiple { set; get; }


    }
}
