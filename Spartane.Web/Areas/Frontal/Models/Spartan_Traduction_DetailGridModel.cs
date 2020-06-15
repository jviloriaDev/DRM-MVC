using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Traduction_DetailGridModel
    {
        public int IdTraductionDetail { get; set; }
        public int? Concept { get; set; }
        public string ConceptConcept_Description { get; set; }
        public int? IdConcept { get; set; }
        public string Original_Text { get; set; }
        public string Translated_Text { get; set; }
        
    }
}

