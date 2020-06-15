using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_BR_ConditionModel
    {
        [Required]
        public short ConditionId { get; set; }
        public string Description { get; set; }
        public string Implementation_Code { get; set; }

    }
}

