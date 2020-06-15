using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_User;
using Spartane.Core.Domain.Spartan_Object;
using Spartane.Core.Domain.Spartan_Report_Presentation_Type;
using Spartane.Core.Domain.Spartan_Report_Presentation_View;
using Spartane.Core.Domain.Spartan_Report_Status;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Report
{
    /// <summary>
    /// Spartan_Report table
    /// </summary>
    public class Spartan_Report: BaseEntity
    {
        public int ReportId { get; set; }
        public string Report_Name { get; set; }
        public DateTime? Registration_Date { get; set; }
        public string Registration_Hour { get; set; }
        public int? Registration_User { get; set; }
        public int? Object { get; set; }
        public int? Presentation_Type { get; set; }
        public int? Presentation_View { get; set; }
        public int? Status { get; set; }
        public string Query { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
        public bool TotalColumns { get; set; }
        public bool TotalRows { get; set; }

        [ForeignKey("Registration_User")]
        public virtual Spartane.Core.Domain.Spartan_User.Spartan_User User_Spartan_Report_User { get; set; }
        [ForeignKey("Object")]
        public virtual Spartane.Core.Domain.Spartan_Object.Spartan_Object Spartan_Object_Spartan_Report_Object { get; set; }
        [ForeignKey("Presentation_Type")]
        public virtual Spartane.Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type Presentation_Type_Spartan_Report_Presentation_Type { get; set; }
        [ForeignKey("Presentation_View")]
        public virtual Spartane.Core.Domain.Spartan_Report_Presentation_View.Spartan_Report_Presentation_View Presentation_View_Spartan_Report_Presentation_View { get; set; }
        [ForeignKey("Status")]
        public virtual Spartane.Core.Domain.Spartan_Report_Status.Spartan_Report_Status Status_Spartan_Report_Status { get; set; }

    }
}

