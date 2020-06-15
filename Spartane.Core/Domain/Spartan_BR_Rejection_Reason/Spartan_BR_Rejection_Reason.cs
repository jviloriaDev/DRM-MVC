using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_BR_Rejection_Reason
{
    /// <summary>
    /// Spartan_BR_Rejection_Reason table
    /// </summary>
    public class Spartan_BR_Rejection_Reason: BaseEntity
    {
        public int Key_Rejection_Reason { get; set; }
        public string Description { get; set; }


    }
}

