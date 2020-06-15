using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Spartan_Report;
using Spartane.Core.Domain.Spartan_Report_Function;
using Spartane.Core.Domain.Spartan_Report_Format;
using Spartane.Core.Domain.Spartan_Report_Order_Type;
using Spartane.Core.Domain.Spartan_Report_Field_Type;
using Spartane.Core.Domain.Spartan_Metadata;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Report_Fields_Detail
{
    /// <summary>
    /// Spartan_Report_Fields_Detail table
    /// </summary>
    public class Spartan_Report_Fields_Detail: BaseEntity
    {
        public int DesignDetailId { get; set; }
        public int? Report { get; set; }
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

        [ForeignKey("Report")]
        public virtual Spartane.Core.Domain.Spartan_Report.Spartan_Report Report_Spartan_Report { get; set; }
        [ForeignKey("Function")]
        public virtual Spartane.Core.Domain.Spartan_Report_Function.Spartan_Report_Function Function_Spartan_Report_Function { get; set; }
        [ForeignKey("Format")]
        public virtual Spartane.Core.Domain.Spartan_Report_Format.Spartan_Report_Format Format_Spartan_Report_Format { get; set; }
        [ForeignKey("Order_Type")]
        public virtual Spartane.Core.Domain.Spartan_Report_Order_Type.Spartan_Report_Order_Type Order_Type_Spartan_Report_Order_Type { get; set; }
        [ForeignKey("Field_Type")]
        public virtual Spartane.Core.Domain.Spartan_Report_Field_Type.Spartan_Report_Field_Type Field_Type_Spartan_Report_Field_Type { get; set; }
        [ForeignKey("AttributeId")]
        public virtual Spartane.Core.Domain.Spartan_Metadata.Spartan_Metadata AttributeId_Spartan_Metadata { get; set; }

    }
}

