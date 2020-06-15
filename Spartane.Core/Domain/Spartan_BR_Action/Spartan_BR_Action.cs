using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_BR_Action_Classification;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_BR_Action
{
    /// <summary>
    /// Spartan_BR_Action table
    /// </summary>
    public class Spartan_BR_Action: BaseEntity
    {
        public int ActionId { get; set; }
        public string Description { get; set; }
        public short? Classification { get; set; }
        public string Implementation_Code { get; set; }

        [ForeignKey("Classification")]
        public virtual Spartane.Core.Domain.Spartan_BR_Action_Classification.Spartan_BR_Action_Classification Classification_Spartan_BR_Action_Classification { get; set; }

    }
}

