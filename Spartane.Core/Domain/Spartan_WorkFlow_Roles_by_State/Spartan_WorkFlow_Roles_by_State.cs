using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_WorkFlow;
using Spartane.Core.Domain.Spartan_WorkFlow_Phases;
using Spartane.Core.Domain.Spartan_WorkFlow_State;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_WorkFlow_Roles_by_State
{
    /// <summary>
    /// Spartan_WorkFlow_Roles_by_State table
    /// </summary>
    public class Spartan_WorkFlow_Roles_by_State: BaseEntity
    {
        public int? Spartan_WorkFlow { get; set; }
        public int Roles_by_StateId { get; set; }
        public int? Phase { get; set; }
        public int? State { get; set; }
        public short? User_Role { get; set; }
        public short? Phase_Transition { get; set; }
        public bool? Permission_To_Consult { get; set; }
        public bool? Permission_To_New { get; set; }
        public bool? Permission_To_Modify { get; set; }
        public bool? Permission_to_Delete { get; set; }
        public bool? Permission_To_Export { get; set; }
        public bool? Permission_To_Print { get; set; }
        public bool? Permission_Settings { get; set; }

        [ForeignKey("Spartan_WorkFlow")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow.Spartan_WorkFlow Spartan_WorkFlow_Spartan_WorkFlow { get; set; }
        [ForeignKey("Phase")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow_Phases.Spartan_WorkFlow_Phases Phase_Spartan_WorkFlow_Phases { get; set; }
        [ForeignKey("State")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow_State.Spartan_WorkFlow_State State_Spartan_WorkFlow_State { get; set; }

    }
}

