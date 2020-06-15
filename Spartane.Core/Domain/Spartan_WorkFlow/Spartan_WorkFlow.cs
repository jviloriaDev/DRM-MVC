using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_WorkFlow_Status;
using Spartane.Core.Domain.Spartan_Object;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_WorkFlow
{
    /// <summary>
    /// Spartan_WorkFlow table
    /// </summary>
    public class Spartan_WorkFlow: BaseEntity
    {
        public int WorkFlowId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Objective { get; set; }
        public short? Status { get; set; }
        public int? Object { get; set; }

        [ForeignKey("Status")]
        public virtual Spartane.Core.Domain.Spartan_WorkFlow_Status.Spartan_WorkFlow_Status Status_Spartan_WorkFlow_Status { get; set; }
        [ForeignKey("Object")]
        public virtual Spartane.Core.Domain.Spartan_Object.Spartan_Object Object_Spartan_Object { get; set; }

    }
}

