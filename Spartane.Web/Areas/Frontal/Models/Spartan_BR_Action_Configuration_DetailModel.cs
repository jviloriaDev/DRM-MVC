using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_BR_Action_Configuration_DetailModel
    {
        [Required]
        public int ActionConfigurationId { get; set; }
        public string Parameter_Name { get; set; }
        public int? Parameter_Type { get; set; }
        public string Parameter_TypeDescription { get; set; }

    }
}

