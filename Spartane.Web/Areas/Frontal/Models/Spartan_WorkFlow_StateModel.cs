using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_WorkFlow_StateModel
    {
        [Required]
        public int StateId { get; set; }
        public int? Phase { get; set; }
        public string PhaseName { get; set; }
        public int? Attribute { get; set; }
        public string AttributeLogical_Name { get; set; }
        [Range(0, 9999999999)]
        public int? State_Code { get; set; }
        public string Name { get; set; }
        [Range(0, 9999999999)]
        public int? Value { get; set; }
        public string Text { get; set; }

    }
}

