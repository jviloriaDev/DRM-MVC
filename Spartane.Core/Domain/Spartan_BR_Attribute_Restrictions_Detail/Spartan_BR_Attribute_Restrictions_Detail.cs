using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_BR_Action;
using Spartane.Core.Domain.Spartan_Attribute_Type;
using Spartane.Core.Domain.Spartan_Attribute_Control_Type;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_BR_Attribute_Restrictions_Detail
{
    /// <summary>
    /// Spartan_BR_Attribute_Restrictions_Detail table
    /// </summary>
    public class Spartan_BR_Attribute_Restrictions_Detail: BaseEntity
    {
        public int RestrictionId { get; set; }
        public int Action { get; set; }
        public int? Attribute_Type { get; set; }
        public short? Control_Type { get; set; }

        [ForeignKey("Action")]
        public virtual Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_Action Action_Spartan_BR_Action { get; set; }
        [ForeignKey("Attribute_Type")]
        public virtual Spartane.Core.Domain.Spartan_Attribute_Type.Spartan_Attribute_Type Attribute_Type_Spartan_Attribute_Type { get; set; }
        [ForeignKey("Control_Type")]
        public virtual Spartane.Core.Domain.Spartan_Attribute_Control_Type.Spartan_Attribute_Control_Type Control_Type_Spartan_Attribute_Control_Type { get; set; }

    }
}

