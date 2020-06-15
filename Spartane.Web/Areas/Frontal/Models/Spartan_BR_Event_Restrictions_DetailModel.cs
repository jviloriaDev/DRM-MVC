using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_BR_Event_Restrictions_DetailModel
    {
        [Required]
        public int RestrictionId { get; set; }
        public short? Process_Event { get; set; }
        public string Process_EventDescription { get; set; }

    }
}

