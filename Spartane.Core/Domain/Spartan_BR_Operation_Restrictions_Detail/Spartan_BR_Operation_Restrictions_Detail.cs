using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_BR_Action;
using Spartane.Core.Domain.Spartan_BR_Operation;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_BR_Operation_Restrictions_Detail
{
    /// <summary>
    /// Spartan_BR_Operation_Restrictions_Detail table
    /// </summary>
    public class Spartan_BR_Operation_Restrictions_Detail: BaseEntity
    {
        public int RestrictionId { get; set; }
        public int Action { get; set; }
        public short? Operation { get; set; }

        [ForeignKey("Action")]
        public virtual Spartane.Core.Domain.Spartan_BR_Action.Spartan_BR_Action Action_Spartan_BR_Action { get; set; }
        [ForeignKey("Operation")]
        public virtual Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation Operation_Spartan_BR_Operation { get; set; }

    }
}

