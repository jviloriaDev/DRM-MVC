using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Spartan_Format_RelatedModel
    {
        [Required]
        public int Clave { get; set; }
	public int? FormatId { get; set; }
        public int? FormatIdFormatId { get; set; }
	public int? FormatId_Related { get; set; }
        public int? FormatId_RelatedFormatId { get; set; }
        [Range(0, 9999999999)]
        public short? Order { get; set; }

    }
}

