using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Report_Fields_DetailModel
    {
        [Required]
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
        [Range(0, 9999999999)]
        public int? Order_Number { get; set; }
        public int? AttributeId { get; set; }
        public string AttributeIdLogical_Name { get; set; }
        public bool Subtotal { get; set; }

    }
}

