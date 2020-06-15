using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Format_Type
{
    /// <summary>
    /// Spartan_Format_Type table
    /// </summary>
    public class Spartan_Format_Type: BaseEntity
    {
        public short FormatTypeId { get; set; }
        public string Description { get; set; }


    }
}

