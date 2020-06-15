using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_ReportMainModel
    {
        public Spartan_ReportModel Spartan_ReportInfo { set; get; }
        public Spartan_Report_Fields_DetailGridModelPost Spartan_Report_Fields_DetailGridInfo { set; get; }
        public Spartan_Report_FilterGridModelPost Spartan_Report_FilterGridInfo { set; get; }

    }

    public class Spartan_Report_Fields_DetailGridModelPost
    {
        public int DesignDetailId { get; set; }
        public string PathField { get; set; }
        public string Physical_Name { get; set; }
        public string Title { get; set; }
        public int? Function { get; set; }
        public int? Format { get; set; }
        public int? Order_Type { get; set; }
        public int? Field_Type { get; set; }
        public int? Order_Number { get; set; }
        public int? AttributeId { get; set; }
        public bool Subtotal { get; set; }

        public bool Removed { set; get; }
    }

    public class Spartan_Report_FilterGridModelPost
    {
        public int ReportFilterId { get; set; }
        public int? Field { get; set; }
        public bool? QuickFilter { get; set; }
        public bool? AdvanceFilter { get; set; }

        public bool Removed { set; get; }
    }



}

