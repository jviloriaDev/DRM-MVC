using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_BR_Presentation_Control_Type;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_BR_Action_Param_Type
{
    /// <summary>
    /// Spartan_BR_Action_Param_Type table
    /// </summary>
    public class Spartan_BR_Action_Param_Type: BaseEntity
    {
        public int ParameterTypeId { get; set; }
        public string Description { get; set; }
        public int? Presentation_Control_Type { get; set; }
        public string Query_for_Fill_Condition { get; set; }
        public string Code_for_Fill_Condition { get; set; }
        public string Implementation_Code { get; set; }

        [ForeignKey("Presentation_Control_Type")]
        public virtual Spartane.Core.Domain.Spartan_BR_Presentation_Control_Type.Spartan_BR_Presentation_Control_Type Presentation_Control_Type_Spartan_BR_Presentation_Control_Type { get; set; }

    }
}

