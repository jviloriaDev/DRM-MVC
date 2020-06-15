using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Report_Presentation_ViewGridModel
    {
        public int PresentationViewId { get; set; }
        public string Description { get; set; }
        public int? Presentation_Type { get; set; }
        public string Presentation_TypeDescription { get; set; }
        
    }
}

