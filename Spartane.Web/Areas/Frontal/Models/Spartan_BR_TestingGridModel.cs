using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_BR_TestingGridModel
    {
        public int Key_Testing { get; set; }
        public int? User_that_reviewed { get; set; }
        public string User_that_reviewedName { get; set; }
        public string Acceptance_Critera { get; set; }
        public bool? It_worked { get; set; }
        public int? Rejection_Reason { get; set; }
        public string Rejection_ReasonDescription { get; set; }
        public string Comments { get; set; }
        public int? Evidence { get; set; } 
        public Grid_File EvidenceFileInfo { get; set; }
        
    }
}

