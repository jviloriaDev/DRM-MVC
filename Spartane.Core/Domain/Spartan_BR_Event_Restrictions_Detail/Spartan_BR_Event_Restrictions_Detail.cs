using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_BR_Action;
using Spartane.Core.Domain.Spartan_BR_Process_Event;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_BR_Event_Restrictions_Detail
{
    /// <summary>
    /// Spartan_BR_Event_Restrictions_Detail table
    /// </summary>
    public class Spartan_BR_Event_Restrictions_Detail: BaseEntity
    {
        public int RestrictionId { get; set; }
        public int Action { get; set; }
        public short? Process_Event { get; set; }

        [ForeignKey("Action")]
        public virtual Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_Action Action_Spartan_BR_Action { get; set; }
        [ForeignKey("Process_Event")]
        public virtual Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event Process_Event_Spartan_BR_Process_Event { get; set; }

    }
}

