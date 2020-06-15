using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_WorkFlow_Matrix_of_StatesModel
    {
        [Required]
        public int Matrix_of_StatesId { get; set; }
        public int? Phase { get; set; }
        public string PhaseName { get; set; }
        public int? State { get; set; }
        public string StateName { get; set; }
        public int? Attribute { get; set; }
        public string AttributeLogical_Name { get; set; }
        public bool Visible { get; set; }
        public bool Required { get; set; }
        public bool Read_Only { get; set; }
        public string Label { get; set; }
        public string Default_Value { get; set; }
        public string Help_Text { get; set; }

    }
}

