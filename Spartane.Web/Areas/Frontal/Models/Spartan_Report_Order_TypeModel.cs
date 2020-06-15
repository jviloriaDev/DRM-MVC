using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Report_Order_TypeModel
    {
        [Required]
        public int OrderTypeId { get; set; }
        public string Description { get; set; }
        public string Order_By { get; set; }

    }
}

