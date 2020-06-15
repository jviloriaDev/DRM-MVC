using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Report_FormatModel
    {
        [Required]
        public int FormatId { get; set; }
        public string Description { get; set; }
        public string Format_Mask { get; set; }

    }
}

