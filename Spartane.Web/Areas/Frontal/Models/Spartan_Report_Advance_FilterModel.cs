using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Report_Advance_FilterModel
    {
        [Required]
        public int Clave { get; set; }
        public int? Report { get; set; }
        public string ReportReport_Name { get; set; }
        public int? AttributeId { get; set; }
        public string AttributeIdPhysical_Name { get; set; }
        public string Defect_Value_From { get; set; }
        public string Defect_Value_To { get; set; }

    }
}

