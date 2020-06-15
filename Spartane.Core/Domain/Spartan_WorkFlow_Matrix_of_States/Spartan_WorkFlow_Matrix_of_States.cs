using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_WorkFlow;
using Spartane.Core.Domain.Spartan_WorkFlow_Phases;
using Spartane.Core.Domain.Spartan_WorkFlow_State;
using Spartane.Core.Domain.Spartan_Metadata;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_WorkFlow_Matrix_of_States
{
    /// <summary>
    /// Spartan_WorkFlow_Matrix_of_States table
    /// </summary>
    public class Spartan_WorkFlow_Matrix_of_States: BaseEntity
    {
        public int? Spartan_WorkFlow { get; set; }
        public int Matrix_of_StatesId { get; set; }
        public int? Phase { get; set; }
        public int? State { get; set; }
        public int? Attribute { get; set; }
        public bool? Visible { get; set; }
        public bool? Required { get; set; }
        public bool? Read_Only { get; set; }
        public string Label { get; set; }
        public string Default_Value { get; set; }
        public string Help_Text { get; set; }

        [ForeignKey("Spartan_WorkFlow")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow.Spartan_WorkFlow Spartan_WorkFlow_Spartan_WorkFlow { get; set; }
        [ForeignKey("Phase")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases Phase_Spartan_WorkFlow_Phases { get; set; }
        [ForeignKey("State")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow_State.Spartan_WorkFlow_State State_Spartan_WorkFlow_State { get; set; }
        [ForeignKey("Attribute")]
        public virtual Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata Attribute_Spartan_Metadata { get; set; }

    }
}

