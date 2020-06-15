using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_Business_Rule;
using Spartane.Core.Domain.Spartan_BR_Operation;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_BR_Operation_Detail
{
    /// <summary>
    /// Spartan_BR_Operation_Detail table
    /// </summary>
    public class Spartan_BR_Operation_Detail: BaseEntity
    {
        public int OperationDetailId { get; set; }
        public int Business_Rule { get; set; }
        public short? Operation { get; set; }

        [ForeignKey("Business_Rule")]
        public virtual Spartane.Core.Domain.Spartan_Business_Rule.Spartan_Business_Rule Business_Rule_Spartan_Business_Rule { get; set; }
        [ForeignKey("Operation")]
        public virtual Spartane.Core.Domain.Spartan_BR_Operation.Spartan_BR_Operation Operation_Spartan_BR_Operation { get; set; }

    }
}

