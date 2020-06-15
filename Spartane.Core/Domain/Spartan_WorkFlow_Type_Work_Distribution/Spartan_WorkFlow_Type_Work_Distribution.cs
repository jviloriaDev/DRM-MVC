using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_WorkFlow_Type_Work_Distribution
{
    /// <summary>
    /// Spartan_WorkFlow_Type_Work_Distribution table
    /// </summary>
    public class Spartan_WorkFlow_Type_Work_Distribution: BaseEntity
    {
        public short Type_of_Work_DistributionId { get; set; }
        public string Description { get; set; }


    }
}

