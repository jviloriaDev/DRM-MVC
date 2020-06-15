using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_ObjectModel
    {
        [Required]
        public int Object_Id { get; set; }
        public string Name { get; set; }

    }
}

