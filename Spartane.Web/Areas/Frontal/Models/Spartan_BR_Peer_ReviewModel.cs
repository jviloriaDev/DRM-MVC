using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_BR_Peer_ReviewModel
    {
        [Required]
        public int Key_Peer_Review { get; set; }
        public int? User_that_reviewed { get; set; }
        public string User_that_reviewedName { get; set; }
        public string Acceptance_Criteria { get; set; }
        public bool It_worked { get; set; }
        public int? Rejection_reason { get; set; }
        public string Rejection_reasonDescription { get; set; }
        public string Comments { get; set; }
        public int? Evidence { get; set; }
        public HttpPostedFileBase EvidenceFile { set; get; }
        public int EvidenceRemoveAttachment { set; get; }

    }
}

