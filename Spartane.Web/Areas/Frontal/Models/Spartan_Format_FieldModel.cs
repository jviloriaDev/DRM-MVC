using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Format_FieldModel
    {
        [Required]
        public int FormatFieldId { get; set; }
        public int? Format { get; set; }
        public string FormatFormat_Name { get; set; }
        public string Field_Path { get; set; }
        public string Physical_Field_Name { get; set; }
        public string Logical_Field_Name { get; set; }
        public string Creation_Date { get; set; }
        public string Creation_Hour { get; set; }
        [Range(0, 9999999999)]
        public int? Creation_User { get; set; }
        public string Properties { get; set; }

    }
}

