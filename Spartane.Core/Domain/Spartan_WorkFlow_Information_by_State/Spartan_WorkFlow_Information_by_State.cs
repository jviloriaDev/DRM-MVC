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

namespace Spartane.Core.Domain.Spartan_WorkFlow_Information_by_State
{
    /// <summary>
    /// Spartan_WorkFlow_Information_by_State table
    /// </summary>
    public class Spartan_WorkFlow_Information_by_State: BaseEntity
    {
        public int? Spartan_WorkFlow { get; set; }
        public int Information_by_StateId { get; set; }
        public int? Phase { get; set; }
        public int? State { get; set; }
        public int? Folder { get; set; }
        public bool? Visible { get; set; }
        public bool? Read_Only { get; set; }
        public bool? Required { get; set; }
        public string Label { get; set; }

        [ForeignKey("Spartan_WorkFlow")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow.Spartan_WorkFlow Spartan_WorkFlow_Spartan_WorkFlow { get; set; }
        [ForeignKey("Phase")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases Phase_Spartan_WorkFlow_Phases { get; set; }
        [ForeignKey("State")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow_State.Spartan_WorkFlow_State State_Spartan_WorkFlow_State { get; set; }
        [ForeignKey("Folder")]
        public virtual Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata Folder_Spartan_Metadata { get; set; }

    }
}

