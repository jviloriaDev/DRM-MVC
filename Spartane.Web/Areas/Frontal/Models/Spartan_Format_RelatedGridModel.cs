using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Format_RelatedGridModel
    {
        public int Clave { get; set; }
        public int? FormatId { get; set; }
        public int? FormatIdFormatId { get; set; }
        public int? FormatId_Related { get; set; }
        public int? FormatId_RelatedFormatId { get; set; }
        public bool? Selected { get; set; }
        public string FormatName  { get; set; }
        public short? Order { get; set; }
        
    }
}

