using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_WorkFlow;
using Spartane.Core.Domain.Spartan_WorkFlow_Phases;
using Spartane.Core.Domain.Spartan_Metadata;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_WorkFlow_State
{
    /// <summary>
    /// Spartan_WorkFlow_State table
    /// </summary>
    public class Spartan_WorkFlow_State: BaseEntity
    {
        public int? Spartan_WorkFlow { get; set; }
        public int StateId { get; set; }
        public int? Phase { get; set; }
        public int? Attribute { get; set; }
        public int? State_Code { get; set; }
        public string Name { get; set; }
        public int? Value { get; set; }
        public string Text { get; set; }

        [ForeignKey("Spartan_WorkFlow")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow.Spartan_WorkFlow Spartan_WorkFlow_Spartan_WorkFlow { get; set; }
        [ForeignKey("Phase")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases Phase_Spartan_WorkFlow_Phases { get; set; }
        [ForeignKey("Attribute")]
        public virtual Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata Attribute_Spartan_Metadata { get; set; }

    }
}

