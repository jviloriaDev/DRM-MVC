using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_BR_Modifications_LogModel
    {
        [Required]
        public int ModificationId { get; set; }
        public string Modification_Date { get; set; }
        public string Modification_Hour { get; set; }
        [Range(0, 9999999999)]
        public int? Modification_User { get; set; }
        public string Comments { get; set; }
        public string Implementation_Code { get; set; }

    }
}

