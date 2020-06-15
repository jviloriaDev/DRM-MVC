using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Business_RuleModel
    {
        [Required]
        public int BusinessRuleId { get; set; }
        public string Registration_Date { get; set; }
        public string Registration_Hour { get; set; }
        [Range(0, 9999999999)]
        public int? User_who_registers { get; set; }
        public string Description { get; set; }
        [Range(0, 9999999999)]
        public int? Object { get; set; }
        [Range(0, 9999999999)]
        public int? Attribute { get; set; }
        public string Implementation_Code { get; set; }

    }
}

