using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_WorkFlow_StateGridModel
    {
        public int StateId { get; set; }
        public int? Phase { get; set; }
        public string PhaseName { get; set; }
        public int? Attribute { get; set; }
        public string AttributeLogical_Name { get; set; }
        public int? State_Code { get; set; }
        public string Name { get; set; }
        public int? Value { get; set; }
        public string Text { get; set; }
        
    }
}

