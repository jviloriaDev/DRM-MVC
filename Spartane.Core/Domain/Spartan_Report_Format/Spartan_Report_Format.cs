using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Spartan_Report_Format
{
    /// <summary>
    /// Spartan_Report_Format table
    /// </summary>
    public class Spartan_Report_Format: BaseEntity
    {
        public int FormatId { get; set; }
        public string Description { get; set; }
        public string Format_Mask { get; set; }


    }
}

