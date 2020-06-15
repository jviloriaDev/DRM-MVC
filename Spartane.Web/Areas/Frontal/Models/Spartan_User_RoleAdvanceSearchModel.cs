using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_User_RoleAdvanceSearchModel
    {
        public Spartan_User_RoleAdvanceSearchModel()
        {

        }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        public string FromUser_Role_Id { set; get; }
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanZero")]
        [IsNumberAfterAttribute("FromUser_Role_Id", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "GreaterThanFrom")]
        public string ToUser_Role_Id { set; get; }

        public Filters DescriptionFilter { set; get; }
        public string Description { set; get; }

        public Filters StatusFilter { set; get; }
        public string AdvanceStatus { set; get; }
        public int[] AdvanceStatusMultiple { set; get; }


    }
}
