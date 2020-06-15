using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_Traduction_Concept_Type;
using Spartane.Core.Domain.Spartan_Traduction_Process;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Traduction_Process_Workflow
{
    /// <summary>
    /// Spartan_Traduction_Process_Workflow table
    /// </summary>
    public class Spartan_Traduction_Process_Workflow: BaseEntity
    {
        public int Clave { get; set; }
        public int? Concept { get; set; }
        public int? ID_of_Step { get; set; }
        public string Original_Text { get; set; }
        public string Translated_Text { get; set; }
        public int? Process { get; set; }

        [ForeignKey("Concept")]
        public virtual Spartane.Core.Domain.Spartan_Traduction_Concept_Type.Spartan_Traduction_Concept_Type Concept_Spartan_Traduction_Concept_Type { get; set; }
        [ForeignKey("Process")]
        public virtual Spartane.Core.Domain.Spartan_Traduction_Process.Spartan_Traduction_Process Process_Spartan_Traduction_Process { get; set; }

    }
}

