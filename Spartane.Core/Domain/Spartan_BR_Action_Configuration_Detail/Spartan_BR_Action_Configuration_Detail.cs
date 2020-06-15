using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_BR_Action;
using Spartane.Core.Domain.Spartan_BR_Action_Param_Type;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_BR_Action_Configuration_Detail
{
    /// <summary>
    /// Spartan_BR_Action_Configuration_Detail table
    /// </summary>
    public class Spartan_BR_Action_Configuration_Detail: BaseEntity
    {
        public int ActionConfigurationId { get; set; }
        public int Action { get; set; }
        public string Parameter_Name { get; set; }
        public int? Parameter_Type { get; set; }

        [ForeignKey("Action")]
        public virtual Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_Action Action_Spartan_BR_Action { get; set; }
        [ForeignKey("Parameter_Type")]
        public virtual Spartane.Core.Domain.Spartan_BR_Action_Param_Type.Spartan_BR_Action_Param_Type Parameter_Type_Spartan_BR_Action_Param_Type { get; set; }

    }
}

