using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Report_Presentation_ViewModel
    {
        [Required]
        public int PresentationViewId { get; set; }
        public string Description { get; set; }
        public int? Presentation_Type { get; set; }
        public string Presentation_TypeDescription { get; set; }

    }
}

