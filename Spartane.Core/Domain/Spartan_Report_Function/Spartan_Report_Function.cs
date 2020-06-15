using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Report_Function
{
    /// <summary>
    /// Spartan_Report_Function table
    /// </summary>
    public class Spartan_Report_Function: BaseEntity
    {
        public int FunctionId { get; set; }
        public string Description { get; set; }


    }
}

