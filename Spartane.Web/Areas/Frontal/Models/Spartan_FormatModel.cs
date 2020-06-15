using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_FormatModel
    {
        [Required]
        public int FormatId { get; set; }
        public string Registration_Date { get; set; }
        public string Registration_Hour { get; set; }
        [Range(0, 9999999999)]
        public int? Registration_User { get; set; }
        public string Format_Name { get; set; }
        public short? Format_Type { get; set; }
        public string Format_TypeDescription { get; set; }
        public string Search { get; set; }
        [Range(0, 9999999999)]
        public int? Object { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
        public string Filter { get; set; }

       

    }
}

