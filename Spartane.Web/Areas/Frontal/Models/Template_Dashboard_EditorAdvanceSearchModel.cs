using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Template_Dashboard_EditorAdvanceSearchModel
    {
        public Template_Dashboard_EditorAdvanceSearchModel()
        {
            Template_Image_Thumbnail = RadioOptions.NoApply;

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromTemplate_Id { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromTemplate_Id", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToTemplate_Id { set; get; }

        public Filters DescriptionFilter { set; get; }
        public string Description { set; get; }

        public RadioOptions Template_Image_Thumbnail { set; get; }


    }
}
