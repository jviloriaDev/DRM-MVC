using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_WorkFlow_Phase_Type
{
    /// <summary>
    /// Spartan_WorkFlow_Phase_Type table
    /// </summary>
    public class Spartan_WorkFlow_Phase_Type: BaseEntity
    {
        public short Phase_TypeId { get; set; }
        public string Description { get; set; }


    }
}

