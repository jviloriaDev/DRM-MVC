using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Traduction_Concept_TypeModel
    {
        [Required]
        public int IdConcept { get; set; }
        public string Concept_Description { get; set; }

    }
}

