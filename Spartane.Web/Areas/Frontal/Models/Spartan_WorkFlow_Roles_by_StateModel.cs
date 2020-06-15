using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_WorkFlow_Roles_by_StateModel
    {
        [Required]
        public int Roles_by_StateId { get; set; }
        public int? Phase { get; set; }
        public string PhaseName { get; set; }
        public int? State { get; set; }
        public string StateName { get; set; }
        [Range(0, 9999999999)]
        public short? User_Role { get; set; }
        [Range(0, 9999999999)]
        public short? Phase_Transition { get; set; }
        public bool Permission_To_Consult { get; set; }
        public bool Permission_To_New { get; set; }
        public bool Permission_To_Modify { get; set; }
        public bool Permission_to_Delete { get; set; }
        public bool Permission_To_Export { get; set; }
        public bool Permission_To_Print { get; set; }
        public bool Permission_Settings { get; set; }

    }
}

