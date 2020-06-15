using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Report_FilterGridModel
    {
        public int ReportFilterId { get; set; }
        public int? Field { get; set; }
        public string FieldLogical_Name { get; set; }
        public bool? QuickFilter { get; set; }
        public bool? AdvanceFilter { get; set; }
        
    }
}

