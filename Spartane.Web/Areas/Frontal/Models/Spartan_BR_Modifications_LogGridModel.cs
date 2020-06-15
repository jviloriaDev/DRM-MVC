using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_BR_Modifications_LogGridModel
    {
        public int ModificationId { get; set; }
        public string Modification_Date { get; set; }
        public string Modification_Hour { get; set; }
        public int? Modification_User { get; set; }
        public string Comments { get; set; }
        public string Implementation_Code { get; set; }
        
    }
}

