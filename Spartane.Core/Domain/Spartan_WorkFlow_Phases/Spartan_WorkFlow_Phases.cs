using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_WorkFlow;
using Spartane.Core.Domain.Spartan_WorkFlow_Phase_Type;
using Spartane.Core.Domain.Spartan_WorkFlow_Type_Work_Distribution;
using Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control;
using Spartane.Core.Domain.Spartan_WorkFlow_Phase_Status;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_WorkFlow_Phases
{
    /// <summary>
    /// Spartan_WorkFlow_Phases table
    /// </summary>
    public class Spartan_WorkFlow_Phases: BaseEntity
    {
        public int? WorkFlow { get; set; }
        public int PhasesId { get; set; }
        public short? Phase_Number { get; set; }
        public string Name { get; set; }
        public short? Phase_Type { get; set; }
        public short? Type_of_Work_Distribution { get; set; }
        public short? Type_Flow_Control { get; set; }
        public short? Phase_Status { get; set; }

        [ForeignKey("WorkFlow")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow.Spartan_WorkFlow WorkFlow_Spartan_WorkFlow { get; set; }
        [ForeignKey("Phase_Type")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow_Phase_Type.Spartan_WorkFlow_Phase_Type Phase_Type_Spartan_WorkFlow_Phase_Type { get; set; }
        [ForeignKey("Type_of_Work_Distribution")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow_Type_Work_Distribution.Spartan_WorkFlow_Type_Work_Distribution Type_of_Work_Distribution_Spartan_WorkFlow_Type_Work_Distribution { get; set; }
        [ForeignKey("Type_Flow_Control")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control.Spartan_WorkFlow_Type_Flow_Control Type_Flow_Control_Spartan_WorkFlow_Type_Flow_Control { get; set; }
        [ForeignKey("Phase_Status")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow_Phase_Status.Spartan_WorkFlow_Phase_Status Phase_Status_Spartan_WorkFlow_Phase_Status { get; set; }

    }
}

