using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Business_RuleGridModel
    {
        public int BusinessRuleId { get; set; }
        public string Registration_Date { get; set; }
        public string Registration_Hour { get; set; }
        public int? User_who_registers { get; set; }
        public string Description { get; set; }
        public int? Object { get; set; }
        public int? Attribute { get; set; }
        public string Implementation_Code { get; set; }
        
    }
}

