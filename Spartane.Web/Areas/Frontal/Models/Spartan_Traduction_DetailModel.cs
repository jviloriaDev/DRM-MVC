using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Traduction_DetailModel
    {
        [Required]
        public int IdTraductionDetail { get; set; }
        public int? Concept { get; set; }
        public string ConceptConcept_Description { get; set; }
        [Range(0, 9999999999)]
        public int? IdConcept { get; set; }
        public string Original_Text { get; set; }
        public string Translated_Text { get; set; }

    }
}

