using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Traduction_ObjectModel
    {
        [Required]
        public int IdObject { get; set; }
        public string Object_Description { get; set; }
        public int? Object_Type { get; set; }
        public string Object_TypeObject_Type_Description { get; set; }

    }
}

