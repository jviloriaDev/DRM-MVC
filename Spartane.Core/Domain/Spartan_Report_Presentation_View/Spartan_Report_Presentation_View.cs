using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_Report_Presentation_Type;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Report_Presentation_View
{
    /// <summary>
    /// Spartan_Report_Presentation_View table
    /// </summary>
    public class Spartan_Report_Presentation_View: BaseEntity
    {
        public int PresentationViewId { get; set; }
        public string Description { get; set; }
        public int? Presentation_Type { get; set; }

        [ForeignKey("Presentation_Type")]
        public virtual Spartane.Core.Domain.Spartan_Report_Presentation_Type.Spartan_Report_Presentation_Type Presentation_Type_Spartan_Report_Presentation_Type { get; set; }

    }
}

