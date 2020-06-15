using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Report_Field_Type
{
    /// <summary>
    /// Spartan_Report_Field_Type table
    /// </summary>
    public class Spartan_Report_Field_Type: BaseEntity
    {
        public short FieldTypeId { get; set; }
        public string Description { get; set; }


    }
}

