using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_BR_Type_History
{
    /// <summary>
    /// Spartan_BR_Type_History table
    /// </summary>
    public class Spartan_BR_Type_History: BaseEntity
    {
        public int Key_Type_History { get; set; }
        public string Description { get; set; }


    }
}

