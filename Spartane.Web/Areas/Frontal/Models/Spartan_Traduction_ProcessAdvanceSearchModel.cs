using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Traduction_ProcessAdvanceSearchModel
    {
        public Spartan_Traduction_ProcessAdvanceSearchModel()
        {

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromIdTraduction { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromIdTraduction", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToIdTraduction { set; get; }

        public Filters LanguageTFilter { set; get; }
        public string AdvanceLanguageT { set; get; }
        public int[] AdvanceLanguageTMultiple { set; get; }

        public Filters Object_TypeFilter { set; get; }
        public string AdvanceObject_Type { set; get; }
        public int[] AdvanceObject_TypeMultiple { set; get; }

        public Filters ObjectTFilter { set; get; }
        public string AdvanceObjectT { set; get; }
        public int[] AdvanceObjectTMultiple { set; get; }


    }
}
