using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_BR_Attribute_Restrictions_DetailModel
    {
        [Required]
        public int RestrictionId { get; set; }
        public int? Attribute_Type { get; set; }
        public string Attribute_TypeDescription { get; set; }
        public short? Control_Type { get; set; }
        public string Control_TypeDescription { get; set; }

    }
}

