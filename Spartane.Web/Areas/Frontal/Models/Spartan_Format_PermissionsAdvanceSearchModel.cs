using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Format_PermissionsAdvanceSearchModel
    {
        public Spartan_Format_PermissionsAdvanceSearchModel()
        {
            Apply = RadioOptions.NoApply;

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromPermissionId { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromPermissionId", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToPermissionId { set; get; }

        public Filters FormatFilter { set; get; }
        public string AdvanceFormat { set; get; }
        public int[] AdvanceFormatMultiple { set; get; }

        public Filters Permission_TypeFilter { set; get; }
        public string AdvancePermission_Type { set; get; }
        public int[] AdvancePermission_TypeMultiple { set; get; }

        public RadioOptions Apply { set; get; }

        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromSpartan_User_Role { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromSpartan_User_Role", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToSpartan_User_Role { set; get; }


    }
}
