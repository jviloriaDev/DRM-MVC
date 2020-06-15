using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_Report;
using Spartane.Core.Domain.Spartan_Metadata;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Report_Filter
{
    /// <summary>
    /// Spartan_Report_Filter table
    /// </summary>
    public class Spartan_Report_Filter: BaseEntity
    {
        public int ReportFilterId { get; set; }
        public int? Report { get; set; }
        public int? Field { get; set; }
        public bool? QuickFilter { get; set; }
        public bool? AdvanceFilter { get; set; }

        [ForeignKey("Report")]
        public virtual Spartane.Core.Domain.Spartan_Report.Spartan_Report Report_Spartan_Report { get; set; }
        [ForeignKey("Field")]
        public virtual Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata Field_Spartan_Metadata { get; set; }

    }
}

