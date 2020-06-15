using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_BR_Attribute_Restrictions_DetailGridModel
    {
        public int RestrictionId { get; set; }
        public int? Attribute_Type { get; set; }
        public string Attribute_TypeDescription { get; set; }
        public short? Control_Type { get; set; }
        public string Control_TypeDescription { get; set; }
        
    }
}

