using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Traduction_Object_TypeModel
    {
        [Required]
        public int IdType { get; set; }
        public string Object_Type_Description { get; set; }

    }
}

