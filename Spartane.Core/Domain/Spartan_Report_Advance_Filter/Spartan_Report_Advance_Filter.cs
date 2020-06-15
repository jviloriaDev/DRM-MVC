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

namespace Spartane.Core.Domain.Spartan_Report_Advance_Filter
{
    /// <summary>
    /// Spartan_Report_Advance_Filter table
    /// </summary>
    public class Spartan_Report_Advance_Filter: BaseEntity
    {
        public int Clave { get; set; }
        public int? Report { get; set; }
        public int? AttributeId { get; set; }
        public int? ObjectId { get; set; }
        public string Defect_Value_From { get; set; }
        public string Defect_Value_To { get; set; }
        public string PathField { get; set; }
        public string CampoQuery { get; set; }
        public bool Visible { get; set; }

        [ForeignKey("Report")]
        public virtual Spartane.Core.Domain.Spartan_Report.Spartan_Report Report_Spartan_Report { get; set; }
        [ForeignKey("AttributeId")]
        public virtual Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata AttributeId_Spartan_Metadata { get; set; }

    }
}

