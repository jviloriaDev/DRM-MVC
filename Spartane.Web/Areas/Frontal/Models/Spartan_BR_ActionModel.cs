using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_BR_ActionModel
    {
        [Required]
        public int ActionId { get; set; }
        public string Description { get; set; }
        public short? Classification { get; set; }
        public string ClassificationDescription { get; set; }
        public string Implementation_Code { get; set; }

    }
}

