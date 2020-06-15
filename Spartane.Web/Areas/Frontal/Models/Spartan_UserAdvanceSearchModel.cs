using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_UserAdvanceSearchModel
    {
        public Spartan_UserAdvanceSearchModel()
        {
            Image = RadioOptions.NoApply;

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromId_User { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromId_User", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToId_User { set; get; }

        public Filters NameFilter { set; get; }
        public string Name { set; get; }

        public Filters RoleFilter { set; get; }
        public string AdvanceRole { set; get; }
        public int[] AdvanceRoleMultiple { set; get; }

        public RadioOptions Image { set; get; }

        public Filters EmailFilter { set; get; }
        public string Email { set; get; }

        public Filters StatusFilter { set; get; }
        public string AdvanceStatus { set; get; }
        public int[] AdvanceStatusMultiple { set; get; }

        public Filters UsernameFilter { set; get; }
        public string Username { set; get; }

        public Filters PasswordFilter { set; get; }
        public string Password { set; get; }


    }
}
