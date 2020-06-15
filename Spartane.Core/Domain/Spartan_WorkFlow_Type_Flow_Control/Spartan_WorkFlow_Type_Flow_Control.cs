using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_WorkFlow_Type_Flow_Control
{
    /// <summary>
    /// Spartan_WorkFlow_Type_Flow_Control table
    /// </summary>
    public class Spartan_WorkFlow_Type_Flow_Control: BaseEntity
    {
        public short Type_Flow_ControlId { get; set; }
        public string Description { get; set; }


    }
}

