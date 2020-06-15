using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_Business_Rule;
using Spartane.Core.Domain.Spartan_BR_Process_Event;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_BR_Process_Event_Detail
{
    /// <summary>
    /// Spartan_BR_Process_Event_Detail table
    /// </summary>
    public class Spartan_BR_Process_Event_Detail: BaseEntity
    {
        public int ProcessEventDetailId { get; set; }
        public int Business_Rule { get; set; }
        public short? Process_Event { get; set; }

        [ForeignKey("Business_Rule")]
        public virtual Spartane.Core.Domain.Spartan_Business_Rule.Spartan_Business_Rule Business_Rule_Spartan_Business_Rule { get; set; }
        [ForeignKey("Process_Event")]
        public virtual Spartane.Core.Domain.Spartan_BR_Process_Event.Spartan_BR_Process_Event Process_Event_Spartan_BR_Process_Event { get; set; }

    }
}

