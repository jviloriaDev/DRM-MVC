using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_WorkFlow_Type_Flow_ControlModel
    {
        [Required]
        public short Type_Flow_ControlId { get; set; }
        public string Description { get; set; }

    }
}

