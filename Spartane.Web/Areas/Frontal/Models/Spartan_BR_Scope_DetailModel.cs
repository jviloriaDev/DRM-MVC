using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_BR_Scope_DetailModel
    {
        [Required]
        public int ScopeDetailId { get; set; }
        public short? Scope { get; set; }
        public string ScopeDescription { get; set; }

    }
}

