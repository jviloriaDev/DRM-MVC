using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_User_StatusModel
    {
        [Required]
        public int User_Status_Id { get; set; }
        public string Description { get; set; }

    }
}

