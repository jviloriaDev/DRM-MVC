using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_WorkFlow_PhasesModel
    {
        [Required]
        public int PhasesId { get; set; }
        [Range(0, 9999999999)]
        public short? Phase_Number { get; set; }
        public string Name { get; set; }
        public short? Phase_Type { get; set; }
        public string Phase_TypeDescription { get; set; }
        public short? Type_of_Work_Distribution { get; set; }
        public string Type_of_Work_DistributionDescription { get; set; }
        public short? Type_Flow_Control { get; set; }
        public string Type_Flow_ControlDescription { get; set; }
        public short? Phase_Status { get; set; }
        public string Phase_StatusDescription { get; set; }

    }
}

