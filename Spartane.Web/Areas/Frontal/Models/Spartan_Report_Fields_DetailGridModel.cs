using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Report_Fields_DetailGridModel
    {
        public int DesignDetailId { get; set; }
        public string PathField { get; set; }
        public string Physical_Name { get; set; }
        public string Title { get; set; }
        public int? Function { get; set; }
        public string FunctionDescription { get; set; }
        public int? Format { get; set; }
        public string FormatDescription { get; set; }
        public int? Order_Type { get; set; }
        public string Order_TypeDescription { get; set; }
        public int? Field_Type { get; set; }
        public string Field_TypeDescription { get; set; }
        public int? Order_Number { get; set; }
        public int? AttributeId { get; set; }
        public string AttributeIdLogical_Name { get; set; }
        public bool Subtotal { get; set; }
        
    }
}

