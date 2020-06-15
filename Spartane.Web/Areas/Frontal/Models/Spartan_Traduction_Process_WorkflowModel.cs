using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Traduction_Process_WorkflowModel
    {
        [Required]
        public int Clave { get; set; }
        public int? Concept { get; set; }
        public string ConceptConcept_Description { get; set; }
        [Range(0, 9999999999)]
        public int? ID_of_Step { get; set; }
        public string Original_Text { get; set; }
        public string Translated_Text { get; set; }

    }
}

