using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_Format;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Format_Field
{
    /// <summary>
    /// Spartan_Format_Field table
    /// </summary>
    public class Spartan_Format_Field: BaseEntity
    {
        public int FormatFieldId { get; set; }
        public int? Format { get; set; }
        public string Field_Path { get; set; }
        public string Physical_Field_Name { get; set; }
        public string Logical_Field_Name { get; set; }
        public DateTime? Creation_Date { get; set; }
        public string Creation_Hour { get; set; }
        public int? Creation_User { get; set; }
        public string Properties { get; set; }
        public string Type_Html { get; set; }

        [ForeignKey("Format")]
        public virtual Spartane.Core.Domain.Spartan_Format.Spartan_Format Format_Spartan_Format { get; set; }

    }
}

