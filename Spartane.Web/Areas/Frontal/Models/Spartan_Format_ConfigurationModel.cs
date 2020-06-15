using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Format_ConfigurationModel
    {
        [Required]
        public int Format { get; set; }
        public string Query_To_Fill_Fields { get; set; }
        public string Filter_to_Show { get; set; }

    }
}

