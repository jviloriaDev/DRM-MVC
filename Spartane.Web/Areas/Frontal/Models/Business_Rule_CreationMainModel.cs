using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Business_Rule_CreationMainModel
    {
        public Business_Rule_CreationModel Business_Rule_CreationInfo { set; get; }
        public Spartan_BR_Conditions_DetailGridModelPost Spartan_BR_Conditions_DetailGridInfo { set; get; }
        public Spartan_BR_Actions_True_DetailGridModelPost Spartan_BR_Actions_True_DetailGridInfo { set; get; }
        public Spartan_BR_Actions_False_DetailGridModelPost Spartan_BR_Actions_False_DetailGridInfo { set; get; }
        public Spartan_BR_Operation_DetailGridModelPost Spartan_BR_Operation_DetailGridInfo { set; get; }
        public Spartan_BR_Process_Event_DetailGridModelPost Spartan_BR_Process_Event_DetailGridInfo { set; get; }
        public Spartan_BR_Peer_ReviewGridModelPost Spartan_BR_Peer_ReviewGridInfo { set; get; }
        public Spartan_BR_TestingGridModelPost Spartan_BR_TestingGridInfo { set; get; }
        public Spartan_BR_Scope_DetailGridModelPost Spartan_BR_Scope_DetailGridInfo { set; get; }

    }


    public class Spartan_BR_Peer_ReviewGridModelPost
    {
        public int Key_Peer_Review { get; set; }
        public int? User_that_reviewed { get; set; }
        public string Acceptance_Criteria { get; set; }
        public bool? It_worked { get; set; }
        public int? Rejection_reason { get; set; }
        public string Comments { get; set; }
        public int? Evidence { get; set; }
        public Grid_File EvidenceInfo { set; get; }

        public bool Removed { set; get; }
    }

    public class Spartan_BR_TestingGridModelPost
    {
        public int Key_Testing { get; set; }
        public int? User_that_reviewed { get; set; }
        public string Acceptance_Critera { get; set; }
        public bool? It_worked { get; set; }
        public int? Rejection_Reason { get; set; }
        public string Comments { get; set; }
        public int? Evidence { get; set; }
        public Grid_File EvidenceInfo { set; get; }

        public bool Removed { set; get; }
    }



}

