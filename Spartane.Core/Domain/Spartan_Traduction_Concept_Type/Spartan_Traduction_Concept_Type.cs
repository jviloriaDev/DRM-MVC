using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Traduction_Concept_Type
{
    /// <summary>
    /// Spartan_Traduction_Concept_Type table
    /// </summary>
    public class Spartan_Traduction_Concept_Type: BaseEntity
    {
        public int IdConcept { get; set; }
        public string Concept_Description { get; set; }


    }
}

