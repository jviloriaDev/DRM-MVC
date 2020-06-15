using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_BR_Operator_TypeModel
    {
        [Required]
        public int OperatorTypeId { get; set; }
        public string Description { get; set; }
        public int? Presentation_Control_Type { get; set; }
        public string Presentation_Control_TypeDescription { get; set; }
        public string Query_for_Fill_Condition { get; set; }
        public string Code_for_Fill_Condition { get; set; }
        public string Implementation_Code { get; set; }

    }
}

