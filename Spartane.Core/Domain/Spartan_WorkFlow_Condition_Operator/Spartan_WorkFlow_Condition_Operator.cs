using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_WorkFlow_Condition_Operator
{
    /// <summary>
    /// Spartan_WorkFlow_Condition_Operator table
    /// </summary>
    public class Spartan_WorkFlow_Condition_Operator: BaseEntity
    {
        public int Condition_OperatorId { get; set; }
        public string Description { get; set; }


    }
}

