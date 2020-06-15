using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_BR_Action_ResultModel
    {
        [Required]
        public short ActionResultId { get; set; }
        public string Description { get; set; }

    }
}

