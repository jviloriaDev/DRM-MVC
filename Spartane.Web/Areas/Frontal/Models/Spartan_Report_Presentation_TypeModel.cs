using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Report_Presentation_TypeModel
    {
        [Required]
        public int PresentationTypeId { get; set; }
        public string Description { get; set; }

    }
}

